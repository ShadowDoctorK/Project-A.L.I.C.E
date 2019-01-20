using ALICE_Internal;
using CSCore.Streams.Effects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Synthesizer
{
    public static class ISynthesizer
    {      
        //User Settings For the Synthesizer
        public static SynthSetting Settings = LoadSettings();

        //Enum Used to feedback more data when a Boolean doesn't meet the requirements
        public enum Answer { Default, Positive, Negative, Error }

        //Collection of the Responses Used By The Synthesizer To Generate Responses
        public static ResponseCollection Response = new ResponseCollection();

        #region Methods
        #endregion
    }

    public class ResponseCollection
    {
        //Collection Of Responses
        public Dictionary<string, Response> Storage = new Dictionary<string, Response>();

        /// <summary>
        /// Add A Response To the Collection of Responses.
        /// </summary>
        /// <param name="R">The Response you want to add.</param>
        /// <param name="M">When set to true and the same response exists it will merge the reponse your adding to the existing data.</param>
        public void Add(Response R, bool M)
        {
            //Check If Response Is In the Dictionary
            if (Storage.ContainsKey(R.Name) == false)
            {
                //Add New Response
                Storage.Add(R.Name, R);
            }
            //Response Exists, Do We Merge...
            else if (M)
            {
                //Pass Response To Merge
                Merge(R);
            }
        }

        /// <summary>
        /// Will Merge the Response you pass with the Collection if the response exists.
        /// </summary>
        /// <param name="A">The Response you want to add to the collection.</param>      
        private void Merge(Response A)
        {
            string MethodName = "Response (Merge)";            

            try
            {
                //Check Response Exists
                if (ResponseExists(A.Name) == false)
                {
                    //Response Doesn't Exist, Return
                    Logger.DebugLine(MethodName, A.Name + " Doesn't Exist. Skipping The Merge.", Logger.Blue);
                    return;
                }                

                //Begin Merging Responses
                foreach (var Seg in A.Segments)
                {
                    //Get Reference To The Segment List
                    List<Response.Segment> SegList = Storage[A.Name].GetSegments();

                    //Check Response A Contains Target Segment
                    if (Storage[A.Name].SegmentExists(A.Name))
                    {
                        //Get Response A's Index For The Target Segment
                        int Index = Storage[A.Name].GetSegmentIndex(Seg);

                        //Attempt To Add New Information
                        foreach (var Line in Seg.Lines)
                        {
                            //This Is The Most Likely To Fail, Catching Errors
                            //To Allow The Foreach Loop To Continue To Process
                            try
                            {
                                //Response Methods Will Auto Filter Duplicates
                                SegList[Index].AddLine(Line);
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "Exception Occured While Merging Response Data, Attempting To Continuing");
                            }                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "(Failed) The Hamster That Merges Responses Died...");
            }
        }

        /// <summary>
        /// Validates that the Target Response and Segement Exists for use.
        /// </summary>
        /// <param name="R">Response Name</param>
        /// <param name="S">Segment Name</param>
        /// <returns>Postive, Negative or Error</returns>
        public ISynthesizer.Answer ResponseValidation(string R, string S)
        {
            string MethodName = "Response (Validation)";

            try
            {
                //Check If Response Exists
                if (ResponseExists(R))
                {
                    //Check If Segment Exists
                    if (Storage[R].SegmentExists(S))
                    {
                        //Validation Passed, Return Postive Answer
                        return ISynthesizer.Answer.Positive;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "Exception Occured, Returing Failed Validation.");
                return ISynthesizer.Answer.Error;
            }

            //Validation Failed, Return Negative Answer
            return ISynthesizer.Answer.Negative;
        }

        /// <summary>
        /// Get the target Response if it exists.
        /// </summary>
        /// <param name="R">Response Name</param>
        /// <returns>Response if it exists, Null if it does not.</returns>
        public Response GetResponse(string R)
        {
            if (ResponseExists(R)) { return Storage[R]; }
            return null;
        }

        /// <summary>
        /// Updates the target Response if it exists.
        /// </summary>
        /// <param name="R">Response Name</param>
        public void SetResponse(Response R)
        {
            if (ResponseExists(R.Name)) { Storage[R.Name] = R; }           
        }

        /// <summary>
        /// Simple Check To Verify the Reponse Exists
        /// </summary>
        /// <param name="R">Response Name</param>
        /// <returns>True if exists</returns>
        public bool ResponseExists(string R)
        {
            if (Storage.ContainsKey(R)) { return true; }
            return false;
        }
    }

    public class SynthSetting
    {
        public ChorusSetting Chorus { get; set; }
        public ReverbSetting Reverb { get; set; }
        public EchoSetting Echo { get; set; }
        public FlangeSetting Flange { get; set; }
        public GargleSetting Gargle { get; set; }
        public DistortionSetting Distortion { get; set; }
        public string Voice { get; set; }
        public int Rate { get; set; }
        public int Volume { get; set; }
        public static readonly string FileName = "Synthisizer.Settings";

        public SynthSetting()
        {
            Chorus = new ChorusSetting();
            Reverb = new ReverbSetting();
            Echo = new EchoSetting();
            Flange = new FlangeSetting();
            Gargle = new GargleSetting();
            Distortion = new DistortionSetting();
            Voice = null;
            Rate = 1;
            Volume = 85;
        }

        public class ChorusSetting
        {
            public bool Enabled { get; set; }

            public float Depth { get; set; }
            public float WetDryMix { get; set; }
            public float Delay { get; set; }
            public float Frequency { get; set; }
            public float Feedback { get; set; }

            public ChorusSetting()
            {
                Enabled = true;

                Depth = (float)10;
                //Range: 0 to 100 / Default: 10
                WetDryMix = (float)50;
                //Range: 0 to 100 / Default: 50 (Balanced)
                Delay = (float)10;
                //Range: 0 to 100 / Default: 10
                Frequency = (float)1.1;
                //Range: 0 to 10 / Default: 1.1
                Feedback = (float)10;
                //Range: -99 to 99 / Default: 10
            }
        }

        public class ReverbSetting
        {
            public bool Enabled { get; set; }

            public float ReverbTime { get; set; }
            public float ReverbMix { get; set; }

            public ReverbSetting()
            {
                Enabled = false;

                ReverbTime = (float)300;
                //Range: 0.001 to 3000 / Default: 1000
                ReverbMix = (float)-20;
                //Range: -96 to 0 / Default: 0
            }
        }

        public class EchoSetting
        {
            public bool Enabled { get; set; }

            public float LeftDelay { get; set; }
            public float RightDelay { get; set; }
            public float WetDryMix { get; set; }
            public float Feedback { get; set; }

            public EchoSetting()
            {
                Enabled = true;

                LeftDelay = (float)10;
                //Range: 1 to 2000 / Default: 500
                RightDelay = (float)10;
                //Range: 1 to 2000 / Default: 500
                WetDryMix = (float)50;
                //Range: 0 to 100 / Default: 50 (Balanced)
                Feedback = (float)0;
                //Range: 0 to 100 / Default: 50
            }
        }

        public class FlangeSetting
        {
            public bool Enabled { get; set; }

            public float Delay { get; set; }
            public float Depth { get; set; }
            public float Feedback { get; set; }
            public float Frequency { get; set; }
            public FlangerPhase Phase { get; set; }
            public float WetDryMix { get; set; }

            public FlangeSetting()
            {
                Enabled = false;

                Delay = (float)2;
                //Range 0ms to 4ms / Default: 2ms
                Depth = (float)100;
                //Range 0 to 100 / Default: 100
                Feedback = (float)50;
                //Range -99 to 99 / Default: -50
                Frequency = (float)0;
                //Range 0 to 10 / Default: 0.25
                Phase = (float)0;
                //Phases: 0 - Negative 180 , 1 - Negative 90, 2 - Zero, 3 - Positive 90, 4 - Positive 180
                WetDryMix = (float)50;
                //Range: 0 to 100 / Default 50
            }
        }

        public class GargleSetting
        {
            public bool Enabled { get; set; }

            public float RateHz { get; set; }
            public GargleWaveShape WaveShape { get; set; }


            public GargleSetting()
            {
                Enabled = false;

                RateHz = (float)20;
                //Range 20hz to 1000hz
                WaveShape = (float)0;
                //Wave Shapes: 0 - Triangle, 1 - Square
            }
        }

        public class DistortionSetting
        {
            public bool Enabled { get; set; }

            public float Edge { get; set; }
            public float Gain { get; set; }
            public float PostEQBandwidth { get; set; }
            public float PostEQCenterFrequency { get; set; }

            public DistortionSetting()
            {
                Enabled = false;

                Edge = (float)0;
                //Range: 0 to 100 / Default: 15
                Gain = (float)0;
                //Range: 0 to 100 / Default: 15
                PostEQBandwidth = (float)2400;
                //Range: 0 to 100 / Default: 15
                PostEQCenterFrequency = (float)2400;
                //Range: 0 to 100 / Default: 15
            }
        }

        #region Support Methods
        public SynthSetting Load()
        {
            string MethodName = "Synthesizer (Load Settings)";

            //Create New Synthesizer Settings
            SynthSetting S = new SynthSetting();

            //Check If User Settings Exist
            if (File.Exists(Paths.ALICE_Settings + FileName))
            {
                //Load Existing User Settings
                using (FileStream FS = new FileStream(Paths.ALICE_Settings + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader SR = new StreamReader(FS))
                {
                    try
                    {
                        while (!SR.EndOfStream)
                        {
                            S = JsonConvert.DeserializeObject<SynthSetting>(SR.ReadLine());
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(MethodName, "Execption: " + ex);
                        Logger.Exception(MethodName, "Execption Occured While Loading Setting, Using Default Synthesizer Settings");
                    }                    
                }
            }
            else
            {
                //Settings Do Not Exist, Create Default Settings
                SaveSettings(S);
            }

            //Return Synthesizer Settings
            return S;
        }

        public static void SaveSettings(SynthSetting Settings)
        {
            using (FileStream FS = new FileStream(Paths.ALICE_Settings + FileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter file = new StreamWriter(FS))
                {
                    var JSON = JsonConvert.SerializeObject(Settings);
                    file.WriteLine(JSON);
                }
            }

            Speech.Settings = Settings;
        }
        #endregion
    }
}
