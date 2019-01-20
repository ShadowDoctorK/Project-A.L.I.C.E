using ALICE_Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALICE_Synthesizer
{
    public static class Speech
    {
        #region Variables
        public static Random random = new Random();
        public static readonly string Pause = " ... ";
        #endregion

        #region Methods / Functions

        /// <summary>
        /// Adds the passed text to the Queue for the Synthesizer so it will play it for the User.
        /// </summary>
        /// <param name="Text">Text to pass to the Synthezier</param>
        /// <param name="CommandAudio">Command Level Audio control. True or False</param>
        /// <param name="Var_1">Customizable Trigger #1 to allow extra control of audio playback. True or False</param>
        /// <param name="Var_2">Customizable Trigger #2 to allow extra control of audio playback. True or False</param>
        /// <param name="Var_3">Customizable Trigger #3 to allow extra control of audio playback. True or False</param>
        /// <param name="Priority">Allows you to set the priority level. 0 - 3, 3 Being the Lowest, 0 Being the Highest.</param>
        /// <param name="Voice">Allows you to delcare a voice other then the system default to speak the line.</param>
        public static void Speak(string Text, bool CommandAudio, bool Var_1 = true, bool Var_2 = true, bool Var_3 = true, int Priority = 3, string Voice = null)
        {
            string MethodName = "Response";

            if (PlugIn.MasterAudio && CommandAudio && Var_1 && Var_2 && Var_3)
            {
                Thread thread = new Thread((ThreadStart)(() => { SpeechService.Instance.Say(Text, true, Priority, Voice); })) { IsBackground = true };
                thread.Start();
            }
            else
            {
                if (PlugIn.MasterAudio == false) { Logger.DebugLine(MethodName, "Audio Disbled, Master Audio Set To False (A.L.I.C.E Is Muted).", Logger.Red); }
                else if (CommandAudio == false) { Logger.DebugLine(MethodName, "Audio Disbled, Command Audio Set To False.", Logger.Red); }
                else if (Var_1 == false) { Logger.DebugLine(MethodName, "Audio Disbled, Custom Variable 1 Set To False.", Logger.Red); }
                else if (Var_2 == false) { Logger.DebugLine(MethodName, "Audio Disbled, Custom Variable 2 Set To False.", Logger.Red); }
                else if (Var_3 == false) { Logger.DebugLine(MethodName, "Audio Disbled, Custom Variable 3 Set To False.", Logger.Red); }
            }
        }

        /// <summary>
        /// Extention Method to create a random dynamic responses.
        /// </summary>
        /// <param name="Text">Target Text for the Extension</param>
        /// <param name="Segment">List<string> which contains the Target Response Key, and the Target Segment in that response.</string></param>
        /// <param name="R">Allows the method to randomly decide if the Segments will be appended.</param>
        /// <param name="E">Allows you to link the phrase to a function to decide if the Segment is enabled or disabled.</param>
        /// <param name="TrueIsGood">Allows you switch if "False" equals postive response for the Enabled Variable.</param>
        /// <param name="Percent">Percent chance the Unique/Alternate strings will be used in the response.</param>
        /// <returns></returns>
        public static string Speak(this string Text, List<string> Segment, bool R = false, bool E = true, bool FalseIsGood = false, int Percent = 15)
        {
            string MethodName = "Speak (Extend)";

            #region Validation Checks
            //Enable Checks:
            //1. False = Postive & Enable is true, Return Text 
            if (FalseIsGood == true && E == true) { return Text; }
            //2. True = Postive & Enable is false, Return Text
            if (FalseIsGood == false && E == false) { return Text; }


            #endregion

            try
            {
                int Alternate = 0;
                if (Random) { if (random.Next(0, 100) <= 50) { return Text; } }
                if (Segment2 != null) { Alternate = random.Next(0, 100); }

                if (Alternate <= Percent)
                {
                    if (Database.Responses[Segment2[0]].Segments[Segment2[1]].Count <= 0)
                    {
                        Logger.Error(MethodName, "There Might Be A Problem Loading The Responses. Try Running As Administrator", Logger.Red);
                        Logger.Error(MethodName, "Processing Error: " + Segment2[0] + " | " + Segment2[1], Logger.Red);
                        return Text;
                    }

                    int SegNum = random.Next(0, Database.Responses[Segment2[0]].Segments[Segment2[1]].Count - 1);
                    Text = Text + Database.Responses[Segment2[0]].Segments[Segment2[1]][SegNum];
                }
                else
                {
                    if (Database.Responses[Segment[0]].Segments[Segment[1]].Count <= 0)
                    {
                        Logger.Error(MethodName, "There Might Be A Problem Loading The Responses. Try Running As Administrator", Logger.Red);
                        Logger.Error(MethodName, "Processing Error: " + Segment2[0] + " | " + Segment2[1], Logger.Red);
                        return Text;
                    }

                    int SegNum = random.Next(0, Database.Responses[Segment[0]].Segments[Segment[1]].Count - 1);
                    Text = Text + Database.Responses[Segment[0]].Segments[Segment[1]][SegNum];
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
                Logger.Exception(MethodName, "Encountered An Exception During Synthesis:");
                if (Segment2 != null) { Logger.Exception(MethodName, @"Primary Response Key " + Segment2[0] + " | Segment Key " + Segment2[1]); }
                Logger.Exception(MethodName, @"Primary Response Key " + Segment[0] + " | Segment Key " + Segment[1]);
                return Text;
            }

            return Text + Pause;
        }

        public static string Speak(this string Text, string AddedText)
        {
            return Text + Pause + AddedText;
        }

        /// <summary>
        /// Checks that the string is not null or empty and replaces the "Token Word".
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="TokenName"></param>
        /// <param name="TargetText"></param>
        /// <returns></returns>
        public static string Token(this string Text, string TokenName, string TargetText)
        {
            string MethodName = "Token Replacement";

            if (TargetText == null) { Logger.Log(MethodName, "Token: " + TokenName + " - The Target Text For The Token Was Null.", Logger.Red); return Text; }
            if (Text.Contains(TokenName)) { Text = Text.Replace(TokenName, TargetText); }
            return Text;
        }

        /// <summary>
        /// Converts Decimal Value and repleaces the "Token Word".
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="TokenName"></param>
        /// <param name="TargetText"></param>
        /// <returns></returns>
        public static string Token(this string Text, string TokenName, decimal TargetText)
        {
            if (Text.Contains(TokenName)) { Text = Text.Replace(TokenName, TargetText.ToString()); }
            return Text;
        }
        #endregion
    }
}
