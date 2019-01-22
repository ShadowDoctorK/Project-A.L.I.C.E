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
        public static Random RanNum = new Random();
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
        /// <param name="W">Allows disabling Weight feature to use all choices.</param>
        /// <param name="E">Allows you to link the phrase to a function to decide if the Segment is enabled or disabled.</param>
        /// <param name="FalseIsGood">Allows you to link the phrase to a function to decide if the Segment is enabled or disabled.</param>
        /// <param name="Percent">Percent chance the Unique/Alternate strings will be used in the response.</param>
        /// <param name="Override">Allows you to Force the use of Alterante or Standard Lines</param>
        /// <returns>Returns the updated working string, or the unmodified string for error and validation failures.</returns>
        public static string Phrase(this string Text, List<string> Segment, bool R = false, bool W = true, bool E = true, 
            bool FalseIsGood = false, int Percent = 20, ISynthesizer.Line Override = ISynthesizer.Line.Default)
        {
            string MethodName = "Speak (Extend)";

            string Res = "";
            int Seg = -1;

            /* Notes:
             * Segement is a list containing the Response Name and the Segment Name.
             * Segment[0] = Response Name
             * Segment[1] = Segment Name
             */

            //Validate Segment Param
            if (Segment.Count() != 2) { return Text; }

            //Validate Response & Segment
            switch (ISynthesizer.Response.Validation(Segment[0], Segment[1]))
            {       
                //Validation Passed
                case ISynthesizer.Answer.Positive:
                    Logger.DebugLine(MethodName, Segment[0] + " | " + Segment[1] + " Passed Validation", Logger.Blue);
                    //Set Variables
                    Res = Segment[0];
                    Seg = ISynthesizer.Response.Storage[Res].GetSegmentIndex(Segment[1]);
                    break;

                //Validation Failed
                case ISynthesizer.Answer.Negative:
                    Logger.DebugLine(MethodName, Segment[0] + " | " + Segment[1] + " Did Not Pass Validation", Logger.Blue);
                    return Text; ;
                
                //Validation Returned Error State
                case ISynthesizer.Answer.Error:
                    Logger.DebugLine(MethodName, Segment[0] + " | " + Segment[1] + " Validation Check Returned An Error", Logger.Blue);
                    return Text;

                default:
                    Logger.Error(MethodName, "Response Validaton Returned Using The Switch Default", Logger.Blue);
                    return Text;
            }

            //Enabled Checks:
            //1. False = Postive & Enable is true, Return Text 
            if (FalseIsGood == true && E == true) { return Text; }
            //2. True = Postive & Enable is false, Return Text
            if (FalseIsGood == false && E == false) { return Text; }
            
            //Randomization Check: Return If Greater Than 499
            if (R) { if (RanNum.Next(0, 1000) >= 500) { return Text; } }

            try
            {
                //Resolve Line Type & Get Line Segment.
                string TempText = ""; switch (Override)
                {
                    //Default Setting To Let Method Resolve
                    case ISynthesizer.Line.Default:

                        //Using Alternate String
                        if (RanNum.Next(0, 1000) / 10 <= Percent)
                        {
                            //Get A Random String
                            TempText = ISynthesizer.Response.Storage[Res].Segments[Seg].GetLine(W, true);
                        }
                        //Using Standard String
                        else
                        {
                            //Get A Random String
                            TempText = ISynthesizer.Response.Storage[Res].Segments[Seg].GetLine(W, false);
                        }
                        break;

                    //Override Setting Foricing Standard Line Use
                    case ISynthesizer.Line.Standard:
                        //Get A Random String
                        TempText = ISynthesizer.Response.Storage[Res].Segments[Seg].GetLine(W, false);
                        break;

                    //Override Setting Forcing Alternate Line Use
                    case ISynthesizer.Line.Alternate:
                        //Get A Random String
                        TempText = ISynthesizer.Response.Storage[Res].Segments[Seg].GetLine(W, true);
                        break;

                    default:
                        Logger.Error(MethodName, "Line Selection Returned Using The Switch Default", Logger.Blue);
                        break;
                }

                //Return Completed Text
                return Text + Pause + TempText;

            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "The Speech Hamsters Had A Problem Working With The Response: " + Segment[0] + " | " + Segment[1]);
                return Text;
            }
        }

        /// <summary>
        /// Extension Method to allow adding strings to the response.
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="AddedText"></param>
        /// <returns></returns>
        public static string Phrase(this string Text, string AddedText)
        {
            return Text + Pause + AddedText;
        }

        //Pick(new List<string>[] { Alice.Online, Alice.Online, Alice.Online });
        public static List<string> Pick(List<string>[] Selections)
        {
            try
            {
                if (Selections.Count() == 0) { return null; }
                return Selections[RanNum.Next(0, Selections.Count() - 1)];
            }
            catch (Exception) { }

            return null;
        }

        /// <summary>
        /// Checks that the string is not null or empty and replaces the "Token Word".
        /// </summary>
        /// <param name="Text">The String your working with</param>
        /// <param name="TokenName">The Token string to be replaced</param>
        /// <param name="TargetText">The Text to replace the Token with.</param>
        /// <returns>Returns the updated working string.</returns>
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
        /// <param name="Text">The String your working with</param>
        /// <param name="TokenName">The Token string to be replaced</param>
        /// <param name="TargetText">The Text to replace the Token with.</param>
        /// <returns>Returns the updated working string.</returns>
        public static string Token(this string Text, string TokenName, decimal TargetText)
        {
            if (Text.Contains(TokenName)) { Text = Text.Replace(TokenName, TargetText.ToString()); }
            return Text;
        }
        #endregion
    }
}
