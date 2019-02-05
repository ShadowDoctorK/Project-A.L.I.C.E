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

        /// <summary>
        /// Generates a list of all enabled voices.
        /// </summary>
        /// <returns>List of Enabled Voices.</returns>
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

        private static readonly object SpeechLock = new object();
        private static readonly object InstanceLock = new object();
        private ISoundOut activeSpeech;        
        private int ActiveSpeechPriority;
        private static SpeechService I;

        public static SpeechService Instance
        {
            get
            {
                //Instance Is Null & Lock Is Open
                if (I == null && Monitor.TryEnter(InstanceLock))
                {
                    I = new SpeechService();
                    //Logger.Event("Synthesizer Initialized.");
                }

                //Return Instance
                return I;
            }
        }

        /// <summary>
        /// Process' the passed variable after vaildation to the Generator for Synthesis.
        /// </summary>
        /// <param name="S">(Sentence) This is the text that the Synthesizer will attempt to process.</param>
        /// <param name="W">(Wait) Tells the Synthesizer if it should wait to process the incomming item.</param>
        /// <param name="P">(Priority) Tells the Synthesizer what the priority is for the incomming item.</param>
        /// <param name="V">(Voice) Tells the Synthesizer what voice to use for the incomming item.</param>
        public void Process(string S, bool W, int P = 3, string V = null)
        {
            //If String Is Null Or Whitespace, Return.
            //Whitespace Items: Space, Tab, Linefeed, Carriage-return, Formfeed, Vertical-tab, and Newline characters
            if (string.IsNullOrWhiteSpace(S)) { return; }      
            
            //If Voice (V) Was Passed Validate It Prior To Using It.
            if (V == null && Voices.Contains(ISynthesizer.Settings.Voice))
            { V = ISynthesizer.Settings.Voice; }

            //Generate Response & Play
            Generate(
                S,                                          //Sentence
                V,                                          //Voice
                ISynthesizer.Settings.Echo.Enabled,         //Echo Settings
                ISynthesizer.Settings.Distortion.Enabled,   //Distortion Settings
                ISynthesizer.Settings.Chorus.Enabled,       //Chorus Settings
                ISynthesizer.Settings.Reverb.Enabled,       //Reverb Settings
                ISynthesizer.Settings.Gargle.Enabled,       //Gargle Settings
                ISynthesizer.Settings.Flange.Enabled,       //Flange Settings
                0,                                          //Compressor Level
                W,                                          //Wait
                P                                           //Priority Level
                );
        }

        /// <summary>
        /// Will Generate a MemoryStream of the Text and Voice using the settings passed then play it back once generation is complete.
        /// </summary>
        /// <param name="S">(Sentence) The Text you want said.</param>
        /// <param name="V">(Voice) The target voice.</param>
        /// <param name="Echo">Is Echo Enabled?</param>
        /// <param name="Distortion">Is Distortion Enabled?</param>
        /// <param name="Chorus">Is Chorus Enabled?</param>
        /// <param name="Reverb">Is Reverb Enabled?</param>
        /// <param name="Gargle">Is Gargle Enabled?</param>
        /// <param name="Flange">Is Flange Enabled?</param>
        /// <param name="CL">(Compressor Level) Default is Zero.</param>
        /// <param name="W">(Wait) Do We Wait Till Playback Is Complete?</param>
        /// <param name="P">(Priority) The Priority Level for this response.</param>
        public void Generate(string S, string V, bool Echo, bool Distortion, bool Chorus, bool Reverb, bool Gargle, bool Flange, int CL, bool W = true, int P = 3)
        {
            string MethodName = "Synthesizer (Generate)";

            //Validate Text (Again)
            if (S == null || S.Trim() == "") { return; }

            //if (string.IsNullOrWhiteSpace(voice))
            //    voice = ;

            Thread T = new Thread((ThreadStart)(() =>
            {
                try
                {
                    //Create Stream For Playback Using The Voice And Text
                    using (MemoryStream ResponseStream = GetMemoryStream(V, S))
                    {
                        //Check If Stream Is Null
                        if (ResponseStream == null)
                        {
                            //Returned Null, Looks Like There Was A Problem
                            Logger.DebugLine(MethodName, "The Memory Stream Returned Was Null", Logger.Blue);
                        }
                        else if (ResponseStream.Length < 50L)
                        {
                            //Returned Empty Stream, Nothing To Say.
                            Logger.DebugLine(MethodName, "The Memory Stream Returned Was An Empty Stream", Logger.Blue);
                        }
                        else
                        {
                            //To The Start Of The Stream.
                            ResponseStream.Seek(0L, SeekOrigin.Begin);

                            //Create A New WaveFileReader Using The Stream.
                            IWaveSource Source = (IWaveSource)new WaveFileReader((Stream)ResponseStream);

                            //Add Effects To The Stream.
                            this.Effects(ref Source, Chorus, Reverb, Echo, Distortion, Gargle, Flange);

                            //Check If The Priority Is Higher Than Whats Playing
                            if (P < this.ActiveSpeechPriority)
                            {
                                //Stopping Current Response
                                this.StopCurrentSpeech();
                            }

                            //Playing Response
                            this.Play(ref Source, P);
                        }
                    }
                }
                catch (ThreadAbortException ex)
                {
                    Logger.Exception(MethodName, "Excetion: " + ex);
                    Logger.Exception(MethodName, "Something Went Wrong While Synthesizing The Audio...");
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Excetion: " + ex);
                    Logger.Exception(MethodName, "Something Went Wrong While Synthesizing The Audio...");
                }
            }));
            //Set A Background Thread. If We Close Main Thread We Kill Background.
            T.IsBackground = true;

            try
            {
                T.Start();
                if (!W) { return; }                    
                T.Join();
            }
            catch (ThreadAbortException ex)
            {
                Thread.ResetAbort();
            }
        }


        /// <summary>
        /// Stops Currently Playing Speech.
        /// </summary>
        public void ShutUp() { StopCurrentSpeech(); }

        //Pitch Modification Is Under Construction.
        private void PitchModification(ref ISampleSource pitch, bool PitchChange = false)
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
                        Depth = (float)ISynthesizer.Settings.Chorus.Depth,
                        //Range: 0 to 100 / Default: 10
                        WetDryMix = (float)ISynthesizer.Settings.Chorus.WetDryMix,
                        //Range: 0 to 100 / Default: 50 (Balanced)
                        Delay = (float)ISynthesizer.Settings.Chorus.Delay,
                        //Range: 0 to 20 / Default: 10
                        Frequency = (float)ISynthesizer.Settings.Chorus.Frequency,
                        //Range: 0 to 10 / Default: 1.1
                        Feedback = (float)ISynthesizer.Settings.Chorus.Feedback
                        //Range: -99 to 99 / Default: 10
                    }));
                }
                #endregion

                #region Reverb
                if (Reverb)
                {
                    Source = (IWaveSource)Source.AppendSource<IWaveSource, DmoWavesReverbEffect>((Func<IWaveSource, DmoWavesReverbEffect>)(x => new DmoWavesReverbEffect(x)
                    {
                        ReverbTime = (float)ISynthesizer.Settings.Reverb.ReverbTime,
                        //Range: 0.001 to 3000 / Default: 1000
                        ReverbMix = (float)ISynthesizer.Settings.Reverb.ReverbMix
                        //Range: -96 to 0 / Default: 0
                    }));
                }
                #endregion

                #region Echo
                if (Echo)
                {
                    Source = (IWaveSource)Source.AppendSource<IWaveSource, DmoEchoEffect>((Func<IWaveSource, DmoEchoEffect>)(x => new DmoEchoEffect(x)
                    {
                        LeftDelay = (float)ISynthesizer.Settings.Echo.LeftDelay,
                        //Range: 1 to 2000 / Default: 500
                        RightDelay = (float)ISynthesizer.Settings.Echo.RightDelay,
                        //Range: 1 to 2000 / Default: 500
                        WetDryMix = (float)ISynthesizer.Settings.Echo.WetDryMix,
                        //Range: 0 to 100 / Default: 50 (Balanced)
                        Feedback = (float)ISynthesizer.Settings.Echo.Feedback
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

        /// <summary>
        /// Returns a MemoryStream for the Voice and Text passed.
        /// </summary>
        /// <param name="V">Target Voice</param>
        /// <param name="S">Text to speak.</param>
        /// <returns></returns>
        private MemoryStream GetMemoryStream(string V, string S)
        {
            string MethodName = "Synthesizer (Get Memory Stream)";

            try
            {

                MemoryStream Stream = new MemoryStream();
                this.speak(Stream, V, S);
                if (Stream.Length == 0L) { this.speak(Stream, V, Regex.Replace(S, "<.*?>", string.Empty)); }                    
                return Stream;
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "Something Went Wrong While Generating The Memory Stream.");
            }

            //Return Default Null Stream.
            return (MemoryStream)null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ResponseStream"></param>
        /// <param name="V"></param>
        /// <param name="S"></param>
        private void speak(MemoryStream ResponseStream, string V, string S)
        {
            string MethodName = "Synthesizer (Speak)";

            Thread thread1 = new Thread((ThreadStart)(() =>
            {
                try
                {
                    SpeechSynthesizer Synthesize = new SpeechSynthesizer(); try
                    {
                        if (V != null)
                        {
                            if (!V.Contains("Microsoft Server Speech Text to Speech Voice"))
                            {
                                try
                                {
                                    //Selecting voice
                                    Thread thread2 = new Thread((ThreadStart)(() => Synthesize.SelectVoice(V)));
                                    thread2.Start();
                                    if (!thread2.Join(TimeSpan.FromSeconds(2.0)))
                                    {
                                        //Failed to select voice
                                        thread2.Abort();
                                    }
                                }
                                catch (Exception)
                                {
                                    Logger.Exception(MethodName, V + " Was Is Not A Valid Voice. Please Select A Different Voice.");
                                    this.StopCurrentSpeech();
                                    return;
                                }
                            }
                        }
                        //Post-Selection
                        Synthesize.Rate = Rate;
                        Synthesize.Volume = ISynthesizer.Settings.Volume;
                        Synthesize.SetOutputToWaveStream((Stream)ResponseStream);

                        //Check If We Are Processing SSML
                        if (S.Contains("<"))
                        {
                            //Obtaining best guess culture
                            string str = this.bestGuessCulture(Synthesize);
                            if (str.Length > 0)
                            {
                                str = " xml:lang=\"" + this.bestGuessCulture(Synthesize) + "\"";
                            }
                            else
                            {
                                //SSML attribute xml:lang not applicable for Cereproc voices, no culture applies
                                S = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\"" + str + ">" + this.StripSSML(S) + "</speak>";
                            }                              

                            //Feeding SSML to synthesizer
                            Synthesize.SpeakSsml(S);
                        }

                        //Processing Raw Text
                        else
                        {
                            //Feeding normal text to synthesizer
                            Synthesize.Speak(S);
                        }
                        //Save output to Array
                        ResponseStream.ToArray();
                    }
                    finally
                    {
                        if (Synthesize != null) { Synthesize.Dispose(); }                            
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
            ResponseStream.Position = 0L;
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
                    lock (SpeechLock)
                    {
                        //Checking to see if we can start speech
                        if (this.activeSpeech == null)
                        {
                            //We can - setting active speech
                            this.activeSpeech = soundout;
                            this.ActiveSpeechPriority = priority;
                            flag = true;
                            //Playing sound buffer
                            soundout.Play();
                        }
                    }
                }
                Thread.Sleep(10);
            }
        }

        private string StripSSML(string text)
        {
            return Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(SecurityElement.Escape(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(text, "(<.+?src=\")(.:)(.*?\\/>)", "$1$2SSSSS$3"), "(<[^>]*)\"", "$1ZZZZZ"), "(<[^>]*)\"", "$1ZZZZZ"), "(<[^>]*)\"", "$1ZZZZZ"), "(<[^>]*)\"", "$1ZZZZZ"), "<(audio.*?)>", "XXXXX$1YYYYY"), "<(break.*?)>", "XXXXX$1YYYYY"), "<(play.*?)>", "XXXXX$1YYYYY"), "<(phoneme.*?)>", "XXXXX$1YYYYY"), "<(/phoneme)>", "XXXXX$1YYYYY"), "<(prosody.*?)>", "XXXXX$1YYYYY"), "<(/prosody)>", "XXXXX$1YYYYY"), "<(emphasis.*?)>", "XXXXX$1YYYYY"), "<(/emphasis)>", "XXXXX$1YYYYY")), "XXXXX", "<"), "YYYYY", ">"), "ZZZZZ", "\""), "SSSSS", "\\");
        }

        private void StopCurrentSpeech()
        {
            lock (SpeechLock)
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
}
