using CSCore;
using CSCore.Codecs.WAV;
using CSCore.SoundOut;
using CSCore.Streams.Effects;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;
using System.Speech.Synthesis;
using System.Collections.Generic;
using ALICE_Objects;
using ALICE_Interface;
using Newtonsoft.Json;
using System.Media;
using ALICE_Internal;

namespace ALICE_Synthesizer
{
    #region Synthesizer
    public class SpeechService
    {
        //Variables for the synthesier config
        //These will get moved to a config class
        //They will be set by the config form window by the user.
        public string ShipModel;
        public bool isAudio = true;
        public int Rate = 1;
        public int WaveExtend = 500;
        public List<string> Voices = GetInstalledVoices();

        //End Variables

        public static List<string> GetInstalledVoices()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            List<string> List = new List<string>();
            foreach (var Voice in synth.GetInstalledVoices())
            {
                if (Voice.Enabled == true)
                {
                    List.Add(Voice.VoiceInfo.Name);
                }
            }
            synth.Dispose();
            return List;
        }

        private static readonly object activeSpeechLock = new object();
        private static readonly object instanceLock = new object();
        private ISoundOut activeSpeech;
        private int activeSpeechPriority;
        private static SpeechService instance;

        public static SpeechService Instance
        {
            get
            {
                if (SpeechService.instance == null)
                {
                    lock (SpeechService.instanceLock)
                    {
                        if (SpeechService.instance == null)
                        {
                            //No Speech service instance: creating one
                            SpeechService.instance = new SpeechService();
                        }
                    }
                }
                return SpeechService.instance;
            }
        }

        public void Say(string speech, bool wait, int priority = 3, string voice = null)
        {
            if (speech == null)
                return;
            if (voice == null && Voices.Contains(Speech.Settings.Voice))
                voice = Speech.Settings.Voice;
            this.Speak(speech, voice, Speech.Settings.Echo.Enabled, Speech.Settings.Distortion.Enabled, Speech.Settings.Chorus.Enabled, Speech.Settings.Reverb.Enabled, Speech.Settings.Gargle.Enabled, Speech.Settings.Flange.Enabled, 0, wait, priority);
        }

        public void ShutUp()
        {
            this.StopCurrentSpeech();
        }

        //Lets Synth the Text String
        public void Speak(string speech, string voice, bool Echo, bool Distortion, bool Chorus, bool Reverb, bool Gargle, bool Flange, int compressLevel, bool wait = true, int priority = 3)
        {
            string MethodName = "Synthesizer (Speak)";

            if (speech == null || speech.Trim() == "") { return; }

            //if (string.IsNullOrWhiteSpace(voice))
            //    voice = ;

            Thread thread = new Thread((ThreadStart)(() =>
            {
                try
                {
                    using (MemoryStream speechStream = this.getSpeechStream(voice, speech))
                    {
                        if (speechStream == null)
                        {
                            //getSpeechStream() returned null; nothing to say
                        }
                        else if (speechStream.Length < 50L)
                        {
                            //getSpeechStream() returned empty stream; nothing to say
                        }
                        else
                        {
                            //ISampleSource pitch = (ISampleSource)new    //((Stream)speechStream);
                            //this.addPitchModification(ref pitch, true);

                            //Seeking back to the beginning of the stream
                            speechStream.Seek(0L, SeekOrigin.Begin);
                            IWaveSource Source = (IWaveSource)new WaveFileReader((Stream)speechStream);
                            this.Effects(ref Source, Chorus, Reverb, Echo, Distortion, Gargle, Flange);

                            if (priority < this.activeSpeechPriority)
                            {
                                //About to StopCurrentSpeech
                                this.StopCurrentSpeech();
                            }
                            this.Play(ref Source, priority);
                        }
                    }
                }
                catch (ThreadAbortException ex)
                {
                    //Thread aborted
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Excetion: " + ex);
                    Logger.Exception(MethodName, "Something Went Wrong While Synthesizing The Audio...");
                }
            }));
            thread.IsBackground = true;
            try
            {
                thread.Start();
                //if (!wait)
                //    return;
                thread.Join();
            }
            catch (ThreadAbortException ex)
            {
                Thread.ResetAbort();
            }
        }

        private void addPitchModification(ref ISampleSource pitch, bool PitchChange = false)
        {
            if (PitchChange)
            {
                //Adding reverb
                pitch = (ISampleSource)pitch.AppendSource<ISampleSource, PitchShifter>((Func<ISampleSource, PitchShifter>)(x => new PitchShifter(x)
                {
                    PitchShiftFactor = (float)-5
                }));
            }
        }

        private void Effects(ref IWaveSource Source, bool Chorus, bool Reverb, bool Echo, bool Distortion, bool Gargle, bool Flange)
        {
            string MethodName = "Synthesizer (Add Effects)";
            try
            {
                #region Check: Extend Wave Source
                if (Chorus != false || Reverb != false || Echo != false || Gargle != false || Distortion != false || Flange != false)
                {
                    Source = (IWaveSource)Source.AppendSource<IWaveSource, ExtendedDurationWaveSource>((Func<IWaveSource, ExtendedDurationWaveSource>)(x => new ExtendedDurationWaveSource(x, WaveExtend)));
                }
                #endregion

                #region Chorus
                if (Chorus)
                {
                    Source = (IWaveSource)Source.AppendSource<IWaveSource, DmoChorusEffect>((Func<IWaveSource, DmoChorusEffect>)(x => new DmoChorusEffect(x)
                    {
                        Depth = (float)Speech.Settings.Chorus.Depth,
                        //Range: 0 to 100 / Default: 10
                        WetDryMix = (float)Speech.Settings.Chorus.WetDryMix,
                        //Range: 0 to 100 / Default: 50 (Balanced)
                        Delay = (float)Speech.Settings.Chorus.Delay,
                        //Range: 0 to 20 / Default: 10
                        Frequency = (float)Speech.Settings.Chorus.Frequency,
                        //Range: 0 to 10 / Default: 1.1
                        Feedback = (float)Speech.Settings.Chorus.Feedback
                        //Range: -99 to 99 / Default: 10
                    }));
                }
                #endregion

                #region Reverb
                if (Reverb)
                {
                    Source = (IWaveSource)Source.AppendSource<IWaveSource, DmoWavesReverbEffect>((Func<IWaveSource, DmoWavesReverbEffect>)(x => new DmoWavesReverbEffect(x)
                    {
                        ReverbTime = (float)Speech.Settings.Reverb.ReverbTime,
                        //Range: 0.001 to 3000 / Default: 1000
                        ReverbMix = (float)Speech.Settings.Reverb.ReverbMix
                        //Range: -96 to 0 / Default: 0
                    }));
                }
                #endregion

                #region Echo
                if (Echo)
                {
                    Source = (IWaveSource)Source.AppendSource<IWaveSource, DmoEchoEffect>((Func<IWaveSource, DmoEchoEffect>)(x => new DmoEchoEffect(x)
                    {
                        LeftDelay = (float)Speech.Settings.Echo.LeftDelay,
                        //Range: 1 to 2000 / Default: 500
                        RightDelay = (float)Speech.Settings.Echo.RightDelay,
                        //Range: 1 to 2000 / Default: 500
                        WetDryMix = (float)Speech.Settings.Echo.WetDryMix,
                        //Range: 0 to 100 / Default: 50 (Balanced)
                        Feedback = (float)Speech.Settings.Echo.Feedback
                        //Range: 0 to 100 / Default: 50
                    }));
                }
                #endregion

                #region Gargle
                if (Gargle)
                {
                    Source = (IWaveSource)Source.AppendSource<IWaveSource, DmoGargleEffect>((Func<IWaveSource, DmoGargleEffect>)(x => new DmoGargleEffect(x)
                    {
                        RateHz = 20,
                        //Range 20hz to 1000hz
                        WaveShape = GargleWaveShape.Square
                        //Trangle or Square
                    }));
                }
                #endregion

                #region Flange
                if (Flange)
                {
                    Source = (IWaveSource)Source.AppendSource<IWaveSource, DmoFlangerEffect>((Func<IWaveSource, DmoFlangerEffect>)(x => new DmoFlangerEffect(x)
                    {
                        Delay = (float)0,
                        //Range 0ms to 4ms / Default: 2ms
                        Depth = (float)10,
                        //Range 0 to 100 / Default: 10
                        Feedback = (float)50,
                        //Range -99 to 99 / Default: -50
                        Frequency = (float)4.25,
                        //Range 0 to 10 / Default: 0.25
                        Phase = FlangerPhase.PhaseZero,
                        //Phases: 0 - Negative 180 , 1 - Negative 90, 2 - Zero, 3 - Positive 90, 4 - Positive 180
                        WetDryMix = (float)50
                        //Range: 0 to 100 / Default 50
                    }));
                }
                #endregion

                #region Distortion
                if (Distortion)
                {
                    Source = (IWaveSource)Source.AppendSource<IWaveSource, DmoDistortionEffect>((Func<IWaveSource, DmoDistortionEffect>)(x => new DmoDistortionEffect(x)
                    {
                        Edge = (float)0,
                        //Range: 0 to 100 / Default: 15
                        Gain = (float)0,
                        //Range: 0 to 100 / Default: 15
                        PostEQBandwidth = (float)2400,
                        //Range: 0 to 100 / Default: 15
                        PostEQCenterFrequency = (float)2400
                        //Range: 0 to 100 / Default: 15
                    }));
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Excetion: " + ex);
                Logger.Exception(MethodName, "Something Went Wrong While Synthesizing The Audio...");
            }
        }

        private void Play(ref IWaveSource source, int priority)
        {
            string MethodName = "Synthesizer (Play)";

            if (source == null)
            {
                //Source is null; skipping
            }
            else
            {
                EventWaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                try
                {
                    using (ISoundOut soundOut = this.GetSoundOut())
                    {
                        try
                        {
                            soundOut.Initialize(source);
                        }
                        catch (COMException ex)
                        {
                            Logger.Exception(MethodName, "COMExcetion: " + ex);
                            Logger.Exception(MethodName, "Something Went Wrong While Synthesizing The Audio...");
                            return;
                        }
                        soundOut.Stopped += (EventHandler<PlaybackStoppedEventArgs>)((s, e) => waitHandle.Set());
                        TimeSpan time = source.GetTime(source.Length);
                        //Starting speech
                        this.StartSpeech(soundOut, priority);
                        //Waiting for speech
                        waitHandle.WaitOne(time);
                        this.StopCurrentSpeech();
                    }
                }
                finally
                {
                    if (waitHandle != null)
                        waitHandle.Dispose();
                }
            }
        }

        private MemoryStream getSpeechStream(string voice, string speech)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                this.speak(stream, voice, speech);
                if (stream.Length == 0L)
                    this.speak(stream, voice, Regex.Replace(speech, "<.*?>", string.Empty));
                return stream;
            }
            catch (Exception ex)
            {
                //Speech failed
            }
            return (MemoryStream)null;
        }

        private void speak(MemoryStream stream, string voice, string speech)
        {
            string MethodName = "Synthesizer (Speak)";

            Thread thread1 = new Thread((ThreadStart)(() =>
            {
                try
                {
                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    try
                    {
                        if (voice != null)
                        {
                            if (!voice.Contains("Microsoft Server Speech Text to Speech Voice"))
                            {
                                try
                                {
                                    //Selecting voice
                                    Thread thread2 = new Thread((ThreadStart)(() => synth.SelectVoice(voice)));
                                    thread2.Start();
                                    if (!thread2.Join(TimeSpan.FromSeconds(2.0)))
                                    {
                                        //Failed to select voice
                                        thread2.Abort();
                                    }
                                }
                                catch (Exception)
                                {
                                    Logger.Exception(MethodName, voice + " Was Is Not A Valid Voice. Please Select A Different Voice.");
                                    this.StopCurrentSpeech();
                                    return;
                                }
                            }
                        }
                        //Post-selection
                        synth.Rate = Rate;
                        synth.Volume = Speech.Settings.Volume;
                        synth.SetOutputToWaveStream((Stream)stream);
                        if (speech.Contains("<"))
                        {
                            //Obtaining best guess culture
                            string str = this.bestGuessCulture(synth);
                            if (str.Length > 0)
                            {
                                str = " xml:lang=\"" + this.bestGuessCulture(synth) + "\"";
                            }
                            else
                                //SSML attribute xml:lang not applicable for Cereproc voices, no culture applies
                                speech = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\"" + str + ">" + this.escapeSsml(speech) + "</speak>";
                            //Feeding SSML to synthesizer
                            synth.SpeakSsml(speech);
                        }
                        else
                        {
                            //Feeding normal text to synthesizer
                            synth.Speak(speech);
                        }
                        //Save output to Array
                        stream.ToArray();
                    }
                    finally
                    {
                        if (synth != null)
                            synth.Dispose();
                    }
                }
                catch (ThreadAbortException ex)
                {
                    //Thread aborted
                }
                catch (Exception ex)
                {
                    //speech failed
                }
            }));
            thread1.Start();
            thread1.Join();
            stream.Position = 0L;
        }

        private string bestGuessCulture(SpeechSynthesizer synth)
        {
            string str = "en-US";
            if (synth != null && synth.Voice != null)
                str = !synth.Voice.Name.Contains("CereVoice") ? synth.Voice.Culture.Name : string.Empty;
            return str;
        }

        private void StartSpeech(ISoundOut soundout, int priority)
        {
            bool flag = false;
            while (!flag)
            {
                if (this.activeSpeech == null)
                {
                    lock (SpeechService.activeSpeechLock)
                    {
                        //Checking to see if we can start speech
                        if (this.activeSpeech == null)
                        {
                            //We can - setting active speech
                            this.activeSpeech = soundout;
                            this.activeSpeechPriority = priority;
                            flag = true;
                            //Playing sound buffer
                            soundout.Play();
                        }
                    }
                }
                Thread.Sleep(10);
            }
        }

        private string escapeSsml(string text)
        {
            return Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(SecurityElement.Escape(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(text, "(<.+?src=\")(.:)(.*?\\/>)", "$1$2SSSSS$3"), "(<[^>]*)\"", "$1ZZZZZ"), "(<[^>]*)\"", "$1ZZZZZ"), "(<[^>]*)\"", "$1ZZZZZ"), "(<[^>]*)\"", "$1ZZZZZ"), "<(audio.*?)>", "XXXXX$1YYYYY"), "<(break.*?)>", "XXXXX$1YYYYY"), "<(play.*?)>", "XXXXX$1YYYYY"), "<(phoneme.*?)>", "XXXXX$1YYYYY"), "<(/phoneme)>", "XXXXX$1YYYYY"), "<(prosody.*?)>", "XXXXX$1YYYYY"), "<(/prosody)>", "XXXXX$1YYYYY"), "<(emphasis.*?)>", "XXXXX$1YYYYY"), "<(/emphasis)>", "XXXXX$1YYYYY")), "XXXXX", "<"), "YYYYY", ">"), "ZZZZZ", "\""), "SSSSS", "\\");
        }

        private void StopCurrentSpeech()
        {
            lock (SpeechService.activeSpeechLock)
            {
                if (this.activeSpeech == null)
                    return;
                //Stopping active speech
                this.activeSpeech.Stop();
                //Disposing of active speech
                this.activeSpeech.Dispose();
                this.activeSpeech = (ISoundOut)null;
            }
        }

        private void WaitForCurrentSpeech()
        {
            //Waiting for current speech to end
            while (this.activeSpeech != null)
                Thread.Sleep(10);
        }

        private ISoundOut GetSoundOut()
        {
            if (WasapiOut.IsSupportedOnCurrentPlatform)
                return (ISoundOut)new WasapiOut();
            return (ISoundOut)new DirectSoundOut();
        }
    }

    public class ExtendedDurationWaveSource : WaveAggregatorBase
    {
        private int bytesToExtend;

        public override long Length { get; }

        public ExtendedDurationWaveSource(IWaveSource waveSource, int milliSecondsToExtend)
          : base(waveSource)
        {
            this.bytesToExtend = (int)waveSource.GetRawElements((long)milliSecondsToExtend);
            this.Length = base.Length + (long)this.bytesToExtend;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int num = this.BaseSource.Read(buffer, offset, count);
            if (num >= count)
                return num;
            int length = Math.Min(count - num, this.bytesToExtend);
            if (length > 0)
                Array.Clear((Array)buffer, offset, length);
            this.bytesToExtend = this.bytesToExtend - length;
            return length;
        }
    }
    #endregion

    #region Speech
    //public static class Speech
    //{
    //    public static SynthSetting Settings = LoadSettings();

    //    #region Variables
    //    public static Random random = new Random();
    //    public static string Pause = " ... ";
    //    #endregion

    //    #region Methods / Functions
    //    public static void SaveSettings(SynthSetting Settings)
    //    {
    //        using (FileStream FS = new FileStream(Paths.ALICE_Settings + @"Synthisizer.Setting", FileMode.Create, FileAccess.Write, FileShare.None))
    //        {
    //            using (StreamWriter file = new StreamWriter(FS))
    //            {
    //                var JSON = JsonConvert.SerializeObject(Settings);
    //                file.WriteLine(JSON);
    //            }
    //        }

    //        Speech.Settings = Settings;
    //    }

    //    public static SynthSetting LoadSettings()
    //    {
    //        SynthSetting Temp = new SynthSetting();
    //        if (File.Exists(Paths.ALICE_Settings + @"Synthisizer.Setting"))
    //        {
    //            using (FileStream FS = new FileStream(Paths.ALICE_Settings + @"Synthisizer.Setting", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    //            using (StreamReader SR = new StreamReader(FS))
    //            {
    //                while (!SR.EndOfStream)
    //                {
    //                    Temp = JsonConvert.DeserializeObject<SynthSetting>(SR.ReadLine());
    //                }
    //            }
    //        }
    //        else
    //        {
    //            SaveSettings(Temp);
    //        }
    //        return Temp;
    //    }
    
    //    /// <summary>
    //    /// Adds the passed text to the Queue for the Synthesizer to play it for the User.
    //    /// </summary>
    //    /// <param name="Line">Text to pass to the Synthezier</param>
    //    /// <param name="CommandAudio">Command Level Audio control. True or False</param>
    //    /// <param name="Var_1">Customizable Trigger #1 to allow extra control of audio playback. True or False</param>
    //    /// <param name="Var_2">Customizable Trigger #2 to allow extra control of audio playback. True or False</param>
    //    /// <param name="Var_3">Customizable Trigger #3 to allow extra control of audio playback. True or False</param>
    //    /// <param name="Priority">Allows you to set the priority level. 0 - 3, 3 Being the Lowest, 0 Being the Highest.</param>
    //    /// <param name="Voice">Allows you to delcare a voice other then the system default to speak the line.</param>
    //    public static void Response(string Line, bool CommandAudio, bool Var_1 = true, bool Var_2 = true, bool Var_3 = true, int Priority = 3, string Voice = null)
    //    {
    //        string MethodName = "Response";

    //        if (PlugIn.MasterAudio && CommandAudio && Var_1 && Var_2 && Var_3)
    //        {
    //            Thread thread = new Thread((ThreadStart)(() => { SpeechService.Instance.Say(Line, true, Priority, Voice); })) { IsBackground = true };
    //            thread.Start();
    //        }
    //        else
    //        {
    //            if (PlugIn.MasterAudio == false) { Logger.DebugLine(MethodName, "Audio Disbled, Master Audio Set To False (A.L.I.C.E Is Muted).", Logger.Red); }
    //            else if (CommandAudio == false) { Logger.DebugLine(MethodName, "Audio Disbled, Command Audio Set To False.", Logger.Red); }
    //            else if (Var_1 == false) { Logger.DebugLine(MethodName, "Audio Disbled, Custom Variable 1 Set To False.", Logger.Red); }
    //            else if (Var_2 == false) { Logger.DebugLine(MethodName, "Audio Disbled, Custom Variable 2 Set To False.", Logger.Red); }
    //            else if (Var_3 == false) { Logger.DebugLine(MethodName, "Audio Disbled, Custom Variable 3 Set To False.", Logger.Red); }
    //        }
    //    }

    //    /// <summary>
    //    /// Extention Method to create a random dynamic responses.
    //    /// </summary>
    //    /// <param name="Text">Target Text for the Extension</param>
    //    /// <param name="Segment">List<string> which contains the Target Response Key, and the Target Segment in that response.</string></param>
    //    /// <param name="Random">Allows the function to randomly decide if the Segments will be appended.</param>
    //    /// <param name="Enabled">Allows you to link the phrase to a GS Boolean to decide if the Segment is enabled or disabled.</param>
    //    /// <param name="TrueIsGood">Allows you switch if "False" equals a passable response for the Enabled Variable.</param>
    //    /// <param name="Percent">Percent Chance Segment 2 will be selected for Processing.</param>
    //    /// <param name="Segment2">If a second segment is passed it will automatically pick between Segment 1 and Segment 2 for processing. Only returning one of the two.</param>
    //    /// <returns></returns>
    //    public static string Speak(this string Text, List<string> Segment, bool Random = false, bool Enabled = true, bool TrueIsGood = true, int Percent = -1, List<string> Segment2 = null)
    //    {
    //        string MethodName = "Speak";

    //        #region Validation Checks
    //        if (Segment != null)
    //        {
    //            if (Database.Responses.ContainsKey(Segment[0]) == true)
    //            {
    //                if (Database.Responses[Segment[0]].Segments.ContainsKey(Segment[1]) == false)
    //                {
    //                    Logger.Error(MethodName, Segment[0] + ": The Target Segment (" + Segment[1] + ") Does Not Exist.", Logger.Red);
    //                    return Text;
    //                }                                    
    //            }
    //            else
    //            {                    
    //                Logger.Error(MethodName, Segment[0] + ": The Target Response Does Not Exist.", Logger.Red);
    //                return Text;
    //            }
    //        }

    //        if (Segment2 != null)
    //        {
    //            if (Database.Responses.ContainsKey(Segment2[0]) == true)
    //            {
    //                if (Database.Responses[Segment2[0]].Segments.ContainsKey(Segment2[1]) == false)
    //                {
    //                    Logger.Error(MethodName, Segment2[0] + ": The Target Segment (" + Segment2[1] + ") Does Not Exist.", Logger.Red);
    //                    return Text;
    //                }
    //            }
    //            else
    //            {
    //                Logger.Error(MethodName, Segment2[0] + ": The Target Response Does Not Exist.", Logger.Red);
    //                return Text;
    //            }
    //        }
    //        #endregion

    //        try
    //        {
    //            int Alternate = 0;
    //            if (TrueIsGood == true) { if (Enabled == false) { return Text; } }
    //            if (TrueIsGood == false) { if (Enabled == true) { return Text; } }
    //            if (Random) { if (random.Next(0, 100) <= 50) { return Text; } }
    //            if (Segment2 != null) { Alternate = random.Next(0, 100); }

    //            if (Alternate <= Percent)
    //            {
    //                if (Database.Responses[Segment2[0]].Segments[Segment2[1]].Count <= 0)
    //                {
    //                    Logger.Error(MethodName, "There Might Be A Problem Loading The Responses. Try Running As Administrator", Logger.Red);
    //                    Logger.Error(MethodName, "Processing Error: " + Segment2[0] + " | " + Segment2[1], Logger.Red);
    //                    return Text;
    //                }

    //                int SegNum = random.Next(0, Database.Responses[Segment2[0]].Segments[Segment2[1]].Count - 1);
    //                Text = Text + Database.Responses[Segment2[0]].Segments[Segment2[1]][SegNum];
    //            }
    //            else
    //            {
    //                if (Database.Responses[Segment[0]].Segments[Segment[1]].Count <= 0)
    //                {
    //                    Logger.Error(MethodName, "There Might Be A Problem Loading The Responses. Try Running As Administrator", Logger.Red);
    //                    Logger.Error(MethodName, "Processing Error: " + Segment2[0] + " | " + Segment2[1], Logger.Red);
    //                    return Text;
    //                }

    //                int SegNum = random.Next(0, Database.Responses[Segment[0]].Segments[Segment[1]].Count - 1);
    //                Text = Text + Database.Responses[Segment[0]].Segments[Segment[1]][SegNum];
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Logger.Exception(MethodName, "Execption: " + ex);
    //            Logger.Exception(MethodName, "Encountered An Exception During Synthesis:");
    //            if (Segment2 != null) { Logger.Exception(MethodName, @"Primary Response Key " + Segment2[0] + " | Segment Key " + Segment2[1]); }                
    //            Logger.Exception(MethodName, @"Primary Response Key " + Segment[0] + " | Segment Key " + Segment[1]);
    //            return Text;
    //        }

    //        return Text + Pause;
    //    }

    //    public static string Speak(this string Text, string AddedText)
    //    {
    //        return Text + Pause + AddedText;
    //    }

    //    /// <summary>
    //    /// Checks that the string is not null or empty and replaces the "Token Word".
    //    /// </summary>
    //    /// <param name="Text"></param>
    //    /// <param name="TokenName"></param>
    //    /// <param name="TargetText"></param>
    //    /// <returns></returns>
    //    public static string Token(this string Text, string TokenName, string TargetText)
    //    {
    //        string MethodName = "Token Replacement";

    //        if (TargetText == null) { Logger.Log(MethodName, "Token: " + TokenName + " - The Target Text For The Token Was Null.", Logger.Red); return Text; }
    //        if (Text.Contains(TokenName)) { Text = Text.Replace(TokenName, TargetText); }
    //        return Text;
    //    }

    //    /// <summary>
    //    /// Converts Decimal Value and repleaces the "Token Word".
    //    /// </summary>
    //    /// <param name="Text"></param>
    //    /// <param name="TokenName"></param>
    //    /// <param name="TargetText"></param>
    //    /// <returns></returns>
    //    public static string Token(this string Text, string TokenName, decimal TargetText)
    //    {
    //        if (Text.Contains(TokenName)) { Text = Text.Replace(TokenName, TargetText.ToString()); }
    //        return Text;
    //    }
    //    #endregion
    //}
    #endregion

    #region Database
    public static class Database
    {
       #region Responses
        public static Dictionary<string, Response> Responses = new Dictionary<string, Response>();

        /// <summary>
        /// Will Load all response files in the target directory.
        /// </summary>
        /// <param name="FilePath">Auto Populated FilePath based on DLL Location</param>
        public static void Response_Load(string FilePath = null)
        {
            string MethodName = "Synthesizer (Response Load)";

            FilePath = Paths.ALICE_Response;
            FileStream FS = null;
            try
            {
                DirectoryInfo directory1 = new DirectoryInfo(Paths.ALICE_Response);
                foreach (FileInfo ResponseFile in directory1.EnumerateFiles("*.response", SearchOption.TopDirectoryOnly))
                {
                    FS = new FileStream(ResponseFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        while (!SR.EndOfStream)
                        {
                            string Line = SR.ReadLine();
                            var NewRes = JsonConvert.DeserializeObject<Response>(Line);
                            if (!Responses.ContainsKey(NewRes.ResponseName))
                            { Responses.Add(NewRes.ResponseName, NewRes); }
                            else if (Responses.ContainsKey(NewRes.ResponseName))
                            {
                                foreach (var Seg in NewRes.Segments)
                                {
                                    foreach (var Str in Seg.Value)
                                    {
                                        Responses[NewRes.ResponseName].Segments[Seg.Key].Add(Str);
                                    }
                                }
                            }
                        }
                    }
                }

                DirectoryInfo directory2 = new DirectoryInfo(Paths.ALICE_ResponseUser);
                foreach (FileInfo ResponseFile in directory2.EnumerateFiles("*.response", SearchOption.TopDirectoryOnly))
                {
                    FS = new FileStream(ResponseFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        while (!SR.EndOfStream)
                        {
                            string Line = SR.ReadLine();
                            var NewRes = JsonConvert.DeserializeObject<Response>(Line);
                            if (!Responses.ContainsKey(NewRes.ResponseName))
                            { Responses.Add(NewRes.ResponseName, NewRes); }
                            else if(Responses.ContainsKey(NewRes.ResponseName))
                            {
                                foreach (var Seg in NewRes.Segments)
                                {
                                    foreach (var Str in Seg.Value)
                                    {
                                        Responses[NewRes.ResponseName].Segments[Seg.Key].Add(Str);
                                    }
                                }
                            }

                            Logger.Log(MethodName, "User Response Loaded (" + NewRes.ResponseName + ")", Logger.Blue);
                        }
                    }
                }
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }
        #endregion
    }

    //public class Response
    //{
    //    public string ResponseName { get; set; }
    //    public List<string> SegmentNames { get; set; }
    //    public Dictionary<string, List<string>> Segments { get; set; }

    //    public Response()
    //    {
    //        ResponseName = null;
    //        SegmentNames = new List<string>();
    //        Segments = new Dictionary<string, List<string>>();
    //    }

    //    [JsonExtensionData]
    //    public IDictionary<string, object> Undefined { get; set; }

    //    public IDictionary<string, object> UndefinedProperties()
    //    {
    //        return Undefined;
    //    }
    //}

    #endregion

    #region Response Wrappers (01/06/2019 8:10 AM)

    //public static class Alice
    //{
    //    public static List<string> Default = new List<string> { "Alice", "S0" };
    //    public static List<string> Special = new List<string> { "Alice", "S1" };
    //    public static List<string> Online = new List<string> { "Alice", "S2" };
    //}

    //public static class Bounty
    //{
    //    public static List<string> Collected = new List<string> { "Bounty", "S0" };
    //}

    //public static class Cargo_Scoop
    //{
    //    public static List<string> Not_Normal_Space = new List<string> { "Cargo Scoop", "S0" };
    //    public static List<string> Fighter = new List<string> { "Cargo Scoop", "S1" };
    //    public static List<string> Touchdown = new List<string> { "Cargo Scoop", "S2" };
    //    public static List<string> Currently_Deployed = new List<string> { "Cargo Scoop", "S3" };
    //    public static List<string> Currently_Retracted = new List<string> { "Cargo Scoop", "S4" };
    //    public static List<string> Retracting = new List<string> { "Cargo Scoop", "S5" };
    //    public static List<string> Deploying = new List<string> { "Cargo Scoop", "S6" };
    //    public static List<string> Docked = new List<string> { "Cargo Scoop", "S7" };
    //}

    //public static class Chaff_Launcher
    //{
    //    public static List<string> Activating = new List<string> { "Chaff Launcher", "S0" };
    //    public static List<string> Hyperspace = new List<string> { "Chaff Launcher", "S1" };
    //    public static List<string> Supercruise = new List<string> { "Chaff Launcher", "S2" };
    //}

    //public static class Combat_Power
    //{
    //    public static List<string> Online = new List<string> { "Combat Power", "S0" };
    //    public static List<string> Offline = new List<string> { "Combat Power", "S1" };
    //    public static List<string> Weapons_Light = new List<string> { "Combat Power", "S2" };
    //    public static List<string> Weapons_Balance = new List<string> { "Combat Power", "S3" };
    //    public static List<string> Weapons_Heavy = new List<string> { "Combat Power", "S4" };
    //    public static List<string> Maintain_Engines = new List<string> { "Combat Power", "S5" };
    //    public static List<string> Maintain_Systems = new List<string> { "Combat Power", "S6" };
    //    public static List<string> Defense_Engines = new List<string> { "Combat Power", "S7" };
    //    public static List<string> Defense_Systems = new List<string> { "Combat Power", "S8" };
    //}

    //public static class Crime
    //{
    //    public static List<string> Default = new List<string> { "Crime", "S0" };
    //    public static List<string> Assult = new List<string> { "Crime", "S1" };
    //    public static List<string> Block_Airlock_Minor = new List<string> { "Crime", "S2" };
    //    public static List<string> Block_Airlock_Warning = new List<string> { "Crime", "S3" };
    //    public static List<string> Block_Landing_Pad_Minor = new List<string> { "Crime", "S4" };
    //    public static List<string> Block_Landing_Pad_Warning = new List<string> { "Crime", "S5" };
    //    public static List<string> Disobey_Police = new List<string> { "Crime", "S6" };
    //    public static List<string> Dumping_Dangerous = new List<string> { "Crime", "S7" };
    //    public static List<string> Dumping_Near_Station = new List<string> { "Crime", "S8" };
    //    public static List<string> Fire_In_No_Fire_Zone = new List<string> { "Crime", "S9" };
    //    public static List<string> Illegal_Cargo = new List<string> { "Crime", "S10" };
    //    public static List<string> Interdicting = new List<string> { "Crime", "S11" };
    //    public static List<string> Murder = new List<string> { "Crime", "S12" };
    //    public static List<string> Piracy = new List<string> { "Crime", "S13" };
    //    public static List<string> Trespass_Minor = new List<string> { "Crime", "S14" };
    //    public static List<string> Wreckless_Flying = new List<string> { "Crime", "S15" };
    //    public static List<string> Wreckless_Flying_Damage = new List<string> { "Crime", "S16" };
    //    public static List<string> Fine = new List<string> { "Crime", "S17" };
    //    public static List<string> Bounty = new List<string> { "Crime", "S18" };
    //    public static List<string> Block_Relocate = new List<string> { "Crime", "S19" };
    //}

    //public static class Docking_Preparations
    //{
    //    public static List<string> Default = new List<string> { "Docking Preparations", "S0" };
    //    public static List<string> Modifier = new List<string> { "Docking Preparations", "S1" };
    //}

    //public static class Docking_Request
    //{
    //    public static List<string> Already_Granted = new List<string> { "Docking Request", "S0" };
    //    public static List<string> Denied = new List<string> { "Docking Request", "S1" };
    //    public static List<string> Docked = new List<string> { "Docking Request", "S2" };
    //    public static List<string> Docking_Computer_Handover = new List<string> { "Docking Request", "S3" };
    //    public static List<string> Granted = new List<string> { "Docking Request", "S4" };
    //    public static List<string> Landing_Pad = new List<string> { "Docking Request", "S5" };
    //    public static List<string> Reason_None_Given = new List<string> { "Docking Request", "S6" };
    //    public static List<string> Reason_Active_Fighter = new List<string> { "Docking Request", "S7" };
    //    public static List<string> Reason_Distance = new List<string> { "Docking Request", "S8" };
    //    public static List<string> Reason_Offences = new List<string> { "Docking Request", "S9" };
    //    public static List<string> Reason_Hostile = new List<string> { "Docking Request", "S10" };
    //    public static List<string> Reason_Too_Large = new List<string> { "Docking Request", "S11" };
    //    public static List<string> Reason_No_Space = new List<string> { "Docking Request", "S12" };
    //    public static List<string> No_Docking_Computer = new List<string> { "Docking Request", "S13" };
    //    public static List<string> No_Docking_Computer_Modifier = new List<string> { "Docking Request", "S14" };
    //}

    //public static class EQ_Discovery_Scanner
    //{
    //    public static List<string> Entered_Hyperspace = new List<string> { "EQ Discovery Scanner", "S0" };
    //    public static List<string> Scan_Failed = new List<string> { "EQ Discovery Scanner", "S1" };
    //    public static List<string> New_Returns = new List<string> { "EQ Discovery Scanner", "S2" };
    //    public static List<string> No_Returns = new List<string> { "EQ Discovery Scanner", "S3" };
    //    public static List<string> Not_Assigned = new List<string> { "EQ Discovery Scanner", "S4" };
    //    public static List<string> Not_Installed = new List<string> { "EQ Discovery Scanner", "S5" };
    //    public static List<string> Scan_Complete = new List<string> { "EQ Discovery Scanner", "S6" };
    //    public static List<string> Scan_Commenced = new List<string> { "EQ Discovery Scanner", "S7" };
    //    public static List<string> Updating = new List<string> { "EQ Discovery Scanner", "S8" };
    //    public static List<string> FSS_Activating = new List<string> { "EQ Discovery Scanner", "S9" };
    //    public static List<string> FSS_Deactivating = new List<string> { "EQ Discovery Scanner", "S10" };
    //    public static List<string> FSS_Currently_Deactivated = new List<string> { "EQ Discovery Scanner", "S11" };
    //    public static List<string> FSS_Currently_Activated = new List<string> { "EQ Discovery Scanner", "S12" };
    //}

    //public static class EQ_External_Lights
    //{
    //    public static List<string> Currently_Energized = new List<string> { "EQ External Lights", "S0" };
    //    public static List<string> Currently_Deenergized = new List<string> { "EQ External Lights", "S1" };
    //    public static List<string> Energizing = new List<string> { "EQ External Lights", "S2" };
    //    public static List<string> Deenergizing = new List<string> { "EQ External Lights", "S3" };
    //    public static List<string> No_Hyperspace = new List<string> { "EQ External Lights", "S4" };
    //}

    //public static class EQ_Frame_Shift_Drive
    //{
    //    public static List<string> Abort_Successful = new List<string> { "EQ Frame Shift Drive", "S0" };
    //    public static List<string> Abort_Failed = new List<string> { "EQ Frame Shift Drive", "S1" };
    //    public static List<string> Drive_Charging = new List<string> { "EQ Frame Shift Drive", "S2" };
    //    public static List<string> Docked = new List<string> { "EQ Frame Shift Drive", "S3" };
    //    public static List<string> Failed_to_Engage = new List<string> { "EQ Frame Shift Drive", "S4" };
    //    public static List<string> Failed_to_Disengage = new List<string> { "EQ Frame Shift Drive", "S5" };
    //    public static List<string> Masslock = new List<string> { "EQ Frame Shift Drive", "S6" };
    //    public static List<string> Too_Fast = new List<string> { "EQ Frame Shift Drive", "S7" };
    //    public static List<string> Touchdown = new List<string> { "EQ Frame Shift Drive", "S8" };
    //    public static List<string> Cooldown = new List<string> { "EQ Frame Shift Drive", "S9" };
    //    public static List<string> HS_Entering = new List<string> { "EQ Frame Shift Drive", "S10" };
    //    public static List<string> SC_Entering = new List<string> { "EQ Frame Shift Drive", "S11" };
    //    public static List<string> HS_Preparing = new List<string> { "EQ Frame Shift Drive", "S12" };
    //    public static List<string> SC_Preparing = new List<string> { "EQ Frame Shift Drive", "S13" };
    //    public static List<string> HS_Currently_Hyperspace = new List<string> { "EQ Frame Shift Drive", "S14" };
    //    public static List<string> SC_Currently_Hyperspace = new List<string> { "EQ Frame Shift Drive", "S15" };
    //    public static List<string> SC_Currently_Normal_Space = new List<string> { "EQ Frame Shift Drive", "S16" };
    //    public static List<string> SC_Currently_Supercruise = new List<string> { "EQ Frame Shift Drive", "S17" };
    //    public static List<string> SC_Disengaging = new List<string> { "EQ Frame Shift Drive", "S18" };
    //    public static List<string> SC_Currently_Charging = new List<string> { "EQ Frame Shift Drive", "S19" };
    //    public static List<string> HS_Currently_Charging = new List<string> { "EQ Frame Shift Drive", "S20" };
    //    public static List<string> Drive_Charging_Special = new List<string> { "EQ Frame Shift Drive", "S21" };
    //    public static List<string> Negaive_Speical = new List<string> { "EQ Frame Shift Drive", "S22" };
    //    public static List<string> HS_Entering_Special = new List<string> { "EQ Frame Shift Drive", "S23" };
    //    public static List<string> SC_Entering_Special = new List<string> { "EQ Frame Shift Drive", "S24" };
    //}

    //public static class Facility_Report
    //{
    //    public static List<string> Datalink = new List<string> { "Facility Report", "S0" };
    //    public static List<string> Docked = new List<string> { "Facility Report", "S1" };
    //    public static List<string> Economy = new List<string> { "Facility Report", "S2" };
    //    public static List<string> Government = new List<string> { "Facility Report", "S3" };
    //    public static List<string> State = new List<string> { "Facility Report", "S4" };
    //    public static List<string> Undocked = new List<string> { "Facility Report", "S5" };
    //    public static List<string> Undocked_Modifier = new List<string> { "Facility Report", "S6" };
    //}

    //public static class Fighter
    //{
    //    public static List<string> Destroyed = new List<string> { "Fighter", "S0" };
    //    public static List<string> Docked = new List<string> { "Fighter", "S1" };
    //    public static List<string> Launch_Error = new List<string> { "Fighter", "S2" };
    //    public static List<string> Launch = new List<string> { "Fighter", "S3" };
    //    public static List<string> Order_Attack_Target = new List<string> { "Fighter", "S4" };
    //    public static List<string> Order_Defend = new List<string> { "Fighter", "S5" };
    //    public static List<string> Order_Engage_At_Will = new List<string> { "Fighter", "S6" };
    //    public static List<string> Order_Follow = new List<string> { "Fighter", "S7" };
    //    public static List<string> Order_Hold_Position = new List<string> { "Fighter", "S8" };
    //    public static List<string> Order_Maintain_Formation = new List<string> { "Fighter", "S9" };
    //    public static List<string> Order_Recall_NPC = new List<string> { "Fighter", "S10" };
    //    public static List<string> Order_Recall_Player = new List<string> { "Fighter", "S11" };
    //    public static List<string> Rebuilt_Destroyed = new List<string> { "Fighter", "S12" };
    //    public static List<string> Rebuilt_Docked = new List<string> { "Fighter", "S13" };
    //    public static List<string> Rebuilt_Other = new List<string> { "Fighter", "S14" };
    //    public static List<string> Launch_Player_Modifer = new List<string> { "Fighter", "S15" };
    //    public static List<string> Docked_Modifier = new List<string> { "Fighter", "S16" };
    //    public static List<string> Not_Normal_Space = new List<string> { "Fighter", "S17" };
    //    public static List<string> Not_Mothership = new List<string> { "Fighter", "S18" };
    //    public static List<string> Mothership_Docked = new List<string> { "Fighter", "S19" };
    //    public static List<string> Touchdown = new List<string> { "Fighter", "S20" };
    //    public static List<string> No_Fire_Zone = new List<string> { "Fighter", "S21" };
    //    public static List<string> Altitude = new List<string> { "Fighter", "S22" };
    //    public static List<string> No_Fighter_Hanger = new List<string> { "Fighter", "S23" };
    //    public static List<string> Hanger_Total = new List<string> { "Fighter", "S24" };
    //}

    //public static class Fuel_Report
    //{
    //    public static List<string> Level_Percent = new List<string> { "Fuel Report", "S0" };
    //    public static List<string> Scoop_Start = new List<string> { "Fuel Report", "S1" };
    //    public static List<string> Scoop_End = new List<string> { "Fuel Report", "S2" };
    //    public static List<string> Scoop_Collected = new List<string> { "Fuel Report", "S3" };
    //    public static List<string> Critical_Level = new List<string> { "Fuel Report", "S4" };
    //    public static List<string> Low_Level = new List<string> { "Fuel Report", "S5" };
    //    public static List<string> Level_Tons = new List<string> { "Fuel Report", "S6" };
    //}

    //public static class Galaxy_Map
    //{
    //    public static List<string> Open = new List<string> { "Galaxy Map", "S0" };
    //    public static List<string> Search = new List<string> { "Galaxy Map", "S1" };
    //    public static List<string> Bookmarks = new List<string> { "Galaxy Map", "S2" };
    //    public static List<string> Configuration = new List<string> { "Galaxy Map", "S3" };
    //    public static List<string> Options = new List<string> { "Galaxy Map", "S4" };
    //    public static List<string> Searching = new List<string> { "Galaxy Map", "S5" };
    //    public static List<string> Hyperspace = new List<string> { "Galaxy Map", "S6" };
    //    public static List<string> Not_Mothership = new List<string> { "Galaxy Map", "S7" };
    //    public static List<string> Currently_Open = new List<string> { "Galaxy Map", "S8" };
    //    public static List<string> Currently_Closed = new List<string> { "Galaxy Map", "S9" };
    //    public static List<string> Failed_To_Open = new List<string> { "Galaxy Map", "S10" };
    //    public static List<string> Close = new List<string> { "Galaxy Map", "S11" };
    //}

    //public static class GN_Apology
    //{
    //    public static List<string> Default = new List<string> { "GN Apology", "S0" };
    //}

    //public static class GN_Planetary_Interaction
    //{
    //    public static List<string> Landing = new List<string> { "GN Planetary Interaction", "S0" };
    //    public static List<string> Landing_Modifier = new List<string> { "GN Planetary Interaction", "S1" };
    //    public static List<string> Takeoff = new List<string> { "GN Planetary Interaction", "S2" };
    //    public static List<string> Takeoff_Modifier = new List<string> { "GN Planetary Interaction", "S3" };
    //    public static List<string> Ship_Recalled = new List<string> { "GN Planetary Interaction", "S4" };
    //    public static List<string> Ship_Dismissed = new List<string> { "GN Planetary Interaction", "S5" };
    //    public static List<string> Approach_Settlement = new List<string> { "GN Planetary Interaction", "S6" };
    //    public static List<string> Glide_Complete = new List<string> { "GN Planetary Interaction", "S7" };
    //    public static List<string> Glide_Commenced = new List<string> { "GN Planetary Interaction", "S8" };
    //    public static List<string> Glide_Failed = new List<string> { "GN Planetary Interaction", "S9" };
    //    public static List<string> Orbital_Cruise_Entry = new List<string> { "GN Planetary Interaction", "S10" };
    //    public static List<string> Orbital_Cruise_Exit = new List<string> { "GN Planetary Interaction", "S11" };
    //    public static List<string> Orbital_Descent_Prep = new List<string> { "GN Planetary Interaction", "S12" };
    //    public static List<string> Orbital_Descent_Aborted = new List<string> { "GN Planetary Interaction", "S13" };
    //    public static List<string> Orbital_Gravity_Warning = new List<string> { "GN Planetary Interaction", "S14" };
    //    public static List<string> Orbital_Not_Scanned = new List<string> { "GN Planetary Interaction", "S15" };
    //}

    //public static class Hardpoints
    //{
    //    public static List<string> Currently_Deployed = new List<string> { "Hardpoints", "S0" };
    //    public static List<string> Currently_Retracted = new List<string> { "Hardpoints", "S1" };
    //    public static List<string> Deploying = new List<string> { "Hardpoints", "S2" };
    //    public static List<string> Hyperspace = new List<string> { "Hardpoints", "S3" };
    //    public static List<string> Retracting = new List<string> { "Hardpoints", "S4" };
    //    public static List<string> Safety_Engaged = new List<string> { "Hardpoints", "S5" };
    //    public static List<string> Safety_Remains = new List<string> { "Hardpoints", "S6" };
    //    public static List<string> Supercruise = new List<string> { "Hardpoints", "S7" };
    //    public static List<string> Safety_Disengaged = new List<string> { "Hardpoints", "S8" };
    //    public static List<string> Safety_Engaging = new List<string> { "Hardpoints", "S9" };
    //    public static List<string> Safety_Disengaging = new List<string> { "Hardpoints", "S10" };
    //}

    //public static class Heat_Damage
    //{
    //    public static List<string> Default = new List<string> { "Heat Damage", "S0" };
    //}

    //public static class Heat_Warning
    //{
    //    public static List<string> Default = new List<string> { "Heat Warning", "S0" };
    //    public static List<string> Modifier = new List<string> { "Heat Warning", "S1" };
    //}

    //public static class Heatsink_Launcher
    //{
    //    public static List<string> Activating = new List<string> { "Heatsink Launcher", "S0" };
    //    public static List<string> Hyperspace = new List<string> { "Heatsink Launcher", "S1" };
    //}

    //public static class Hull_Damage
    //{
    //    public static List<string> Default = new List<string> { "Hull Damage", "S0" };
    //}

    //public static class I_Love_You
    //{
    //    public static List<string> Default = new List<string> { "I Love You", "S0" };
    //}

    //public static class Landing_Gear
    //{
    //    public static List<string> Not_Normal_Space = new List<string> { "Landing Gear", "S0" };
    //    public static List<string> Not_Mothership = new List<string> { "Landing Gear", "S1" };
    //    public static List<string> Fighter_Deployed = new List<string> { "Landing Gear", "S2" };
    //    public static List<string> Docked = new List<string> { "Landing Gear", "S3" };
    //    public static List<string> Touchdown = new List<string> { "Landing Gear", "S4" };
    //    public static List<string> Currently_Deployed = new List<string> { "Landing Gear", "S5" };
    //    public static List<string> Currently_Retracted = new List<string> { "Landing Gear", "S6" };
    //    public static List<string> Deploying = new List<string> { "Landing Gear", "S7" };
    //    public static List<string> Retracting = new List<string> { "Landing Gear", "S8" };
    //}

    //public static class Landing_Preparations
    //{
    //    public static List<string> Default = new List<string> { "Landing Preparations", "S0" };
    //    public static List<string> Modifier = new List<string> { "Landing Preparations", "S1" };
    //}

    //public static class Masslock
    //{
    //    public static List<string> Entered = new List<string> { "Masslock", "S0" };
    //    public static List<string> Exited = new List<string> { "Masslock", "S1" };
    //    public static List<string> Current = new List<string> { "Masslock", "S2" };
    //}

    //public static class Module
    //{
    //    public static List<string> Not_Installed = new List<string> { "Module", "S0" };
    //}

    //public static class Negative
    //{
    //    public static List<string> Default = new List<string> { "Negative", "S0" };
    //}

    //public static class No_Fire_Zone
    //{
    //    public static List<string> Entered = new List<string> { "No Fire Zone", "S0" };
    //    public static List<string> Exited = new List<string> { "No Fire Zone", "S1" };
    //}

    //public static class NPC_Crew
    //{
    //    public static List<string> Active_Duty = new List<string> { "NPC Crew", "S0" };
    //    public static List<string> On_Shore_Leave = new List<string> { "NPC Crew", "S1" };
    //}

    //public static class Order_Generic
    //{
    //    public static List<string> Currently_Disabled = new List<string> { "Order Generic", "S0" };
    //    public static List<string> Currently_Enabled = new List<string> { "Order Generic", "S1" };
    //    public static List<string> Disabled = new List<string> { "Order Generic", "S2" };
    //    public static List<string> Enabled = new List<string> { "Order Generic", "S3" };
    //}

    //public static class Positive
    //{
    //    public static List<string> Default = new List<string> { "Positive", "S0" };
    //}

    //public static class Report_Generic
    //{
    //    public static List<string> Currently_Disabled = new List<string> { "Report Generic", "S0" };
    //    public static List<string> Currently_Enabled = new List<string> { "Report Generic", "S1" };
    //    public static List<string> Disabled = new List<string> { "Report Generic", "S2" };
    //    public static List<string> Enabled = new List<string> { "Report Generic", "S3" };
    //}

    //public static class Shield_Cell
    //{
    //    public static List<string> Activating = new List<string> { "Shield Cell", "S0" };
    //    public static List<string> Hyperspace = new List<string> { "Shield Cell", "S1" };
    //}

    //public static class Shields
    //{
    //    public static List<string> Online = new List<string> { "Shields", "S0" };
    //    public static List<string> Offline = new List<string> { "Shields", "S1" };
    //}

    //public static class Ship_Targeted
    //{
    //    public static List<string> Wanted = new List<string> { "Ship Targeted", "S0" };
    //    public static List<string> Enemy_Faction = new List<string> { "Ship Targeted", "S1" };
    //}

    //public static class Shipyard_Arrived
    //{
    //    public static List<string> Three_Min_Warning = new List<string> { "Shipyard Arrived", "S0" };
    //    public static List<string> Arrived = new List<string> { "Shipyard Arrived", "S1" };
    //}

    //public static class Shipyard_Tansfer
    //{
    //}

    //public static class Silent_Running
    //{
    //    public static List<string> Not_Normal_Space = new List<string> { "Silent Running", "S0" };
    //    public static List<string> Not_Mothership = new List<string> { "Silent Running", "S1" };
    //    public static List<string> Currently_Active = new List<string> { "Silent Running", "S2" };
    //    public static List<string> Currently_Secured = new List<string> { "Silent Running", "S3" };
    //    public static List<string> Activating = new List<string> { "Silent Running", "S4" };
    //    public static List<string> Securing = new List<string> { "Silent Running", "S5" };
    //}

    //public static class Station
    //{
    //    public static List<string> Damaged = new List<string> { "Station", "S0" };
    //    public static List<string> Hostile = new List<string> { "Station", "S1" };
    //    public static List<string> Player_Targeted = new List<string> { "Station", "S2" };
    //}

    //public static class System_Map
    //{
    //    public static List<string> Open = new List<string> { "System Map", "S0" };
    //    public static List<string> Summary = new List<string> { "System Map", "S1" };
    //    public static List<string> Body_Info = new List<string> { "System Map", "S2" };
    //    public static List<string> Local_Bookmarks = new List<string> { "System Map", "S3" };
    //    public static List<string> Points_Of_Interest = new List<string> { "System Map", "S4" };
    //    public static List<string> Failed_To_Open = new List<string> { "System Map", "S5" };
    //    public static List<string> Currently_Open = new List<string> { "System Map", "S6" };
    //    public static List<string> Currently_Closed = new List<string> { "System Map", "S7" };
    //    public static List<string> Close = new List<string> { "System Map", "S8" };
    //    public static List<string> Hyperspace = new List<string> { "System Map", "S9" };
    //    public static List<string> Not_Mothership = new List<string> { "System Map", "S10" };
    //}

    //public static class System_Report
    //{
    //    public static List<string> Arrived = new List<string> { "System Report", "S0" };
    //    public static List<string> Allegiance = new List<string> { "System Report", "S1" };
    //    public static List<string> Government = new List<string> { "System Report", "S2" };
    //    public static List<string> Security = new List<string> { "System Report", "S3" };
    //    public static List<string> Entry_Report = new List<string> { "System Report", "S4" };
    //}

    //public static class Target_System
    //{
    //    public static List<string> Whitelist_Pilot = new List<string> { "Target System", "S0" };
    //    public static List<string> Whitelist_Faction = new List<string> { "Target System", "S1" };
    //    public static List<string> Whitelist_Clear = new List<string> { "Target System", "S2" };
    //    public static List<string> Hyperspace = new List<string> { "Target System", "S3" };
    //    public static List<string> SRV = new List<string> { "Target System", "S4" };
    //    public static List<string> Scan_Start = new List<string> { "Target System", "S5" };
    //    public static List<string> Scan_No_Targets = new List<string> { "Target System", "S6" };
    //    public static List<string> Scan_Data_Standby = new List<string> { "Target System", "S7" };
    //    public static List<string> Scan_Target_Aquired = new List<string> { "Target System", "S8" };
    //    public static List<string> Scan_Target_Lost = new List<string> { "Target System", "S9" };
    //    public static List<string> Scan_Pause = new List<string> { "Target System", "S10" };
    //    public static List<string> Scan_Terminated = new List<string> { "Target System", "S11" };
    //    public static List<string> Scan_Continue = new List<string> { "Target System", "S12" };
    //    public static List<string> Scan_Start_Hostile_Modifier = new List<string> { "Target System", "S13" };
    //    public static List<string> Whitelist_Empty = new List<string> { "Target System", "S14" };
    //    public static List<string> Whitelist_Contains = new List<string> { "Target System", "S15" };
    //    public static List<string> Blacklist_Pilot = new List<string> { "Target System", "S16" };
    //    public static List<string> Blacklist_Faction = new List<string> { "Target System", "S17" };
    //    public static List<string> Blacklist_Clear = new List<string> { "Target System", "S18" };
    //    public static List<string> Blacklist_Empty = new List<string> { "Target System", "S19" };
    //    public static List<string> Blacklist_Contains = new List<string> { "Target System", "S20" };
    //}

    //public static class Thank_You
    //{
    //    public static List<string> Default = new List<string> { "Thank You", "S0" };
    //    public static List<string> Special = new List<string> { "Thank You", "S1" };
    //}

    //public static class Weapons_Safety
    //{
    //    public static List<string> Disengaged = new List<string> { "Weapons Safety", "S0" };
    //    public static List<string> Engaged = new List<string> { "Weapons Safety", "S1" };
    //}

    #endregion
}
