using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Synthesis;
using CSCore.Streams.Effects;
using System.IO;
using Newtonsoft.Json;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Community_Toolkit
{
    /// <summary>
    /// Interaction logic for Synthesizer_Controls.xaml
    /// </summary>
    public partial class Synthesizer_Controls : UserControl
    {
        public static SynthSetting Settings = GetSynthSetting();
        public static List<string> Voices = GetInstalledVoices();
        public static List<string> Phases = new List<string>()
        {
            "Phase 0",
            "Phase 90",
            "Phase 180",
            "Phase -90",
            "Phase -180"
        };

        public Synthesizer_Controls()
        {
            InitializeComponent();
            ComboBox_VoiceSelection.ItemsSource = Voices;
            ComboBox_Phase_Flange.ItemsSource = Phases;

            Voice_Update();
            Chorus_Update();
            Reverb_Update();
            Echo_Update();
            Flange_Update();        
        }

        public static void SaveSettings(SynthSetting Settings)
        {
            using (FileStream FS = new FileStream(Paths.ALICE_Settings + @"Synthesizer.Settings", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter file = new StreamWriter(FS))
                {
                    var JSON = JsonConvert.SerializeObject(Settings);
                    file.WriteLine(JSON);
                }
            }          
        }

        public static SynthSetting LoadSettings()
        {
            SynthSetting Temp = new SynthSetting();
            if (File.Exists(Paths.ALICE_Settings + @"Synthesizer.Settings"))
            {
                using (FileStream FS = new FileStream(Paths.ALICE_Settings + @"Synthesizer.Settings", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader SR = new StreamReader(FS))
                {
                    while (!SR.EndOfStream)
                    {
                        Temp = JsonConvert.DeserializeObject<SynthSetting>(SR.ReadLine());
                    }
                }
            }
            else
            {
                SaveSettings(Temp);
            }
            return Temp;
        }

        public static SynthSetting GetSynthSetting()
        {
            SynthSetting Temp = new SynthSetting();

            try
            {
                Temp = LoadSettings();
            }
            catch (Exception)
            {

            }   

            return Temp;
        }

        public static List<string> GetInstalledVoices()
        {
            SpeechSynthesizer Synth = new SpeechSynthesizer();
            List<string> List = new List<string>();
            foreach (var Voice in Synth.GetInstalledVoices())
            {
                if (Voice.Enabled == true)
                {
                    List.Add(Voice.VoiceInfo.Name);
                }
            }

            return List;
        }

        private void btn_LoadSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool SavedMasterAudio = PlugIn.MasterAudio;
                PlugIn.MasterAudio = true;
                ISynthesizer.Settings = Settings;
                Speech.Speak(TextBox_TestVoice.Text, true);
                PlugIn.MasterAudio = SavedMasterAudio;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btn_SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            SaveSettings(Settings);

            System.Windows.MessageBox.Show("Settings Updated, Restart To Apply New Voice.");
        }

        #region Voice
        private void Voice_Update()
        {
            TextBox_SpeechRate.Text = Settings.Rate.ToString();
            TextBox_SpeechVolume.Text = Settings.Volume.ToString();
        }

        private void SpeechVolume_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Volume = (int)Slider_SpeechVolume.Value;
            Voice_Update();
        }

        private void ComboBox_VoiceSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Settings.Voice = ComboBox_VoiceSelection.SelectedValue.ToString();
        }
        #endregion

        #region Chorus
        private void Chorus_Update()
        {
            TextBox_Delay_Chorus.Text = Settings.Chorus.Delay.ToString();
            TextBox_Depth_Chorus.Text = Settings.Chorus.Depth.ToString();
            TextBox_Feedback_Chorus.Text = Settings.Chorus.Feedback.ToString();
            TextBox_Frequency_Chorus.Text = Settings.Chorus.Frequency.ToString();
            TextBox_WetDryMix_Chorus.Text = Settings.Chorus.WetDryMix.ToString();
            if (Settings.Chorus.Enabled) { CheckBox_Chorus.IsChecked = true; }
            else { CheckBox_Chorus.IsChecked = false; }
        }

        private void CheckBox_Chorus_Checked(object sender, RoutedEventArgs e)
        {
            Settings.Chorus.Enabled = true;
        }

        private void CheckBox_Chorus_Unchecked(object sender, RoutedEventArgs e)
        {
            Settings.Chorus.Enabled = false;
        }

        private void Chorus_Depth_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Chorus.Depth = (float)Slider_Depth_Chorus.Value;
            Chorus_Update();
        }

        private void Chorus_WetDryMix_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Chorus.WetDryMix = (float)Slider_WetDryMix_Chorus.Value;
            Chorus_Update();
        }

        private void Chorus_Delay_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Chorus.Delay = (float)Slider_Delay_Chorus.Value;
            Chorus_Update();
        }

        private void Chorus_Frequency_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Chorus.Frequency = (float)Slider_Frequency_Chorus.Value;
            Chorus_Update();
        }

        private void Chorus_Feedback_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Chorus.Feedback = (float)Slider_Feedback_Chorus.Value;
            Chorus_Update();
        }
        #endregion

        #region Reverb
        private void Reverb_Update()
        {
            TextBox_ReverbMix_Reverb.Text = Settings.Reverb.ReverbMix.ToString();
            TextBox_ReverbTime_Reverb.Text = Settings.Reverb.ReverbTime.ToString();
            if (Settings.Reverb.Enabled) { CheckBox_Reverb.IsChecked = true; }
            else { CheckBox_Reverb.IsChecked = false; }
        }

        private void CheckBox_Reverb_Unchecked(object sender, RoutedEventArgs e)
        {
            Settings.Reverb.Enabled = false;
        }

        private void CheckBox_Reverb_Checked(object sender, RoutedEventArgs e)
        {
            Settings.Reverb.Enabled = true;
        }

        private void Reverb_Time_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Reverb.ReverbTime = (float)Slider_ReverbTime_Reverb.Value;
            Reverb_Update();
        }

        private void Reverb_Mix_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Reverb.ReverbMix = (float)Slider_ReverbMix_Reverb.Value;
            Reverb_Update();
        }
        #endregion

        #region Echo
        private void Echo_Update()
        {
            TextBox_Feedback_Echo.Text = Settings.Echo.Feedback.ToString();
            TextBox_LeftDelay_Echo.Text = Settings.Echo.LeftDelay.ToString();
            TextBox_RightDelay_Echo.Text = Settings.Echo.RightDelay.ToString();
            TextBox_WetDryMix_Echo.Text = Settings.Echo.WetDryMix.ToString();
            if (Settings.Echo.Enabled) { CheckBox_Echo.IsChecked = true; }
            else { CheckBox_Echo.IsChecked = false; }
        }

        private void CheckBox_Echo_Checked(object sender, RoutedEventArgs e)
        {
            Settings.Echo.Enabled = true;
        }

        private void CheckBox_Echo_Unchecked(object sender, RoutedEventArgs e)
        {
            Settings.Echo.Enabled = false;
        }

        private void Echo_LeftDelay_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Echo.LeftDelay = (float)Slider_LeftDelay_Echo.Value;
            Echo_Update();
        }

        private void Echo_RightDelay_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Echo.RightDelay = (float)Slider_RightDelay_Echo.Value;
            Echo_Update();
        }

        private void Echo_WetDryMix_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Echo.WetDryMix = (float)Slider_WetDryMix_Echo.Value;
            Echo_Update();
        }

        private void Echo_Feedback_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Echo.Feedback = (float)Slider_Feedback_Echo.Value;
            Echo_Update();
        }
        #endregion

        #region Distortion

        #endregion

        #region Flange
        private void Flange_Update()
        {
            TextBox_Delay_Flange.Text = Settings.Flange.Delay.ToString();
            TextBox_Depth_Flange.Text = Settings.Flange.Depth.ToString();
            TextBox_Feedback_Flange.Text = Settings.Flange.Feedback.ToString();
            TextBox_Frequency_Flange.Text = Settings.Flange.Frequency.ToString();
            TextBox_WetDryMix_Flange.Text = Settings.Flange.WetDryMix.ToString();
            if (Settings.Flange.Enabled) { CheckBox_Flange.IsChecked = true; }
            else { CheckBox_Flange.IsChecked = false; }
        }

        private void CheckBox_Flange_Checked(object sender, RoutedEventArgs e)
        {
            Settings.Flange.Enabled = true;
        }

        private void CheckBox_Flange_Unchecked(object sender, RoutedEventArgs e)
        {
            Settings.Flange.Enabled = false;
        }

        private void ComboBox_Phase_Flange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox_Phase_Flange.SelectedItem)
            {
                case "Phase 0":
                    Settings.Flange.Phase = FlangerPhase.PhaseZero;
                    break;
                case "Phase 90":
                    Settings.Flange.Phase = FlangerPhase.Phase90;
                    break;
                case "Phase 180":
                    Settings.Flange.Phase = FlangerPhase.Phase180;
                    break;
                case "Phase -90":
                    Settings.Flange.Phase = FlangerPhase.PhaseNegative90;
                    break;
                case "Phase -180":
                    Settings.Flange.Phase = FlangerPhase.PhaseNegative180;
                    break;
                default:
                    Settings.Flange.Phase = FlangerPhase.PhaseZero;
                    break;
            }
            Flange_Update();
        }

        private void Slider_WetDryMix_Flange_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Flange.WetDryMix = (float)Slider_WetDryMix_Flange.Value;
            Flange_Update();
        }

        private void Slider_Frequency_Flange_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Flange.Frequency = (float)Slider_Frequency_Flange.Value;
            Flange_Update();
        }

        private void Slider_Delay_Flange_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Flange.Delay = (float)Slider_Delay_Flange.Value;
            Flange_Update();
        }

        private void Slider_Depth_Flange_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Flange.Depth = (float)Slider_Depth_Flange.Value;
            Flange_Update();
        }

        private void Slider_Feedback_Flange_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Flange.Feedback = (float)Slider_Feedback_Flange.Value;
            Flange_Update();
        }
        #endregion
    }

    #region Synthesizer Settings
    //public class SynthSetting
    //{
    //    public ChorusSetting Chorus { get; set; }
    //    public ReverbSetting Reverb { get; set; }
    //    public EchoSetting Echo { get; set; }
    //    public FlangeSetting Flange { get; set; }
    //    public GargleSetting Gargle { get; set; }
    //    public DistortionSetting Distortion { get; set; }
    //    public string Voice { get; set; }
    //    public int Rate { get; set; }
    //    public int Volume { get; set; }

    //    public SynthSetting()
    //    {
    //        Chorus = new ChorusSetting();
    //        Reverb = new ReverbSetting();
    //        Echo = new EchoSetting();
    //        Flange = new FlangeSetting();
    //        Gargle = new GargleSetting();
    //        Distortion = new DistortionSetting();
    //        Voice = null;
    //        Rate = 1;
    //        Volume = 75;
    //    }

    //    public class ChorusSetting
    //    {
    //        public bool Enabled { get; set; }

    //        public float Depth { get; set; }
    //        public float WetDryMix { get; set; }
    //        public float Delay { get; set; }
    //        public float Frequency { get; set; }
    //        public float Feedback { get; set; }

    //        public ChorusSetting()
    //        {
    //            Enabled = true;

    //            Depth = (float)10;
    //            //Range: 0 to 100 / Default: 10
    //            WetDryMix = (float)50;
    //            //Range: 0 to 100 / Default: 50 (Balanced)
    //            Delay = (float)10;
    //            //Range: 0 to 100 / Default: 10
    //            Frequency = (float)1.1;
    //            //Range: 0 to 10 / Default: 1.1
    //            Feedback = (float)10;
    //            //Range: -99 to 99 / Default: 10
    //        }
    //    }

    //    public class ReverbSetting
    //    {
    //        public bool Enabled { get; set; }

    //        public float ReverbTime { get; set; }
    //        public float ReverbMix { get; set; }

    //        public ReverbSetting()
    //        {
    //            Enabled = true;

    //            ReverbTime = (float)300;
    //            //Range: 0.001 to 3000 / Default: 1000
    //            ReverbMix = (float)-5;
    //            //Range: -96 to 0 / Default: 0
    //        }
    //    }

    //    public class EchoSetting
    //    {
    //        public bool Enabled { get; set; }

    //        public float LeftDelay { get; set; }
    //        public float RightDelay { get; set; }
    //        public float WetDryMix { get; set; }
    //        public float Feedback { get; set; }

    //        public EchoSetting()
    //        {
    //            Enabled = true;

    //            LeftDelay = (float)10;
    //            //Range: 1 to 2000 / Default: 500
    //            RightDelay = (float)10;
    //            //Range: 1 to 2000 / Default: 500
    //            WetDryMix = (float)50;
    //            //Range: 0 to 100 / Default: 50 (Balanced)
    //            Feedback = (float)0;
    //            //Range: 0 to 100 / Default: 50
    //        }
    //    }

    //    public class FlangeSetting
    //    {
    //        public bool Enabled { get; set; }

    //        public float Delay { get; set; }
    //        public float Depth { get; set; }
    //        public float Feedback { get; set; }
    //        public float Frequency { get; set; }
    //        public FlangerPhase Phase { get; set; }
    //        public float WetDryMix { get; set; }

    //        public FlangeSetting()
    //        {
    //            Enabled = false;

    //            Delay = (float)2;
    //            //Range 0ms to 4ms / Default: 2ms
    //            Depth = (float)100;
    //            //Range 0 to 100 / Default: 100
    //            Feedback = (float)50;
    //            //Range -99 to 99 / Default: -50
    //            Frequency = (float)0;
    //            //Range 0 to 10 / Default: 0.25
    //            Phase = (float)0;
    //            //Phases: 0 - Negative 180 , 1 - Negative 90, 2 - Zero, 3 - Positive 90, 4 - Positive 180
    //            WetDryMix = (float)50;
    //            //Range: 0 to 100 / Default 50
    //        }
    //    }

    //    public class GargleSetting
    //    {
    //        public bool Enabled { get; set; }

    //        public float RateHz { get; set; }
    //        public GargleWaveShape WaveShape { get; set; }

    //        public GargleSetting()
    //        {
    //            Enabled = false;

    //            RateHz = (float)20;
    //            //Range 20hz to 1000hz
    //            WaveShape = (float)0;
    //            //Wave Shapes: 0 - Triangle, 1 - Square
    //        }
    //    }

    //    public class DistortionSetting
    //    {
    //        public bool Enabled { get; set; }

    //        public float Edge { get; set; }
    //        public float Gain { get; set; }
    //        public float PostEQBandwidth { get; set; }
    //        public float PostEQCenterFrequency { get; set; }

    //        public DistortionSetting()
    //        {
    //            Enabled = false;

    //            Edge = (float)0;
    //            //Range: 0 to 100 / Default: 15
    //            Gain = (float)0;
    //            //Range: 0 to 100 / Default: 15
    //            PostEQBandwidth = (float)2400;
    //            //Range: 0 to 100 / Default: 15
    //            PostEQCenterFrequency = (float)2400;
    //            //Range: 0 to 100 / Default: 15
    //        }
    //    }
    //}
    #endregion
}
