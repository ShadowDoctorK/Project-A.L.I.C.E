using System.Threading;
using ALICE_Actions;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Equipment
{
    public class FrameShiftDrive : Equipment_General
    {
        /* Notes:
         * Validation Checks (Expected States)
         * 1. Mothership = true
         * 2. Touchdown = false
         * 3. Docking = false
         * 4. Cargo Scoop = false
         * 5. Landing Gear = false
         * 6. Hardpoings = false
         * 7. (Supercruise) Supercruise = false
         * 8. Hyperspace = false         
         */

        public bool Supercruise = false;
        public bool Hyperspace = false;
        public bool Charging = false;
        public bool Cooldown = false;
        //public bool Prepairing = false;
        public bool Disengaging = false;
        public bool PrepHyperspace = false;
        public bool PrepSupercruise = false;
        public bool Marking = false;

        public FrameShiftDrive()
        {
            Settings.Equipment = IEquipment.E.Frame_Shift_Drive;
            Settings.Mode = IEquipment.M.Default;
            Settings.Installed = true;
            Settings.Enabled = true;
        }

        public void U_Charging(bool B)
        {
            //Only Process If Different
            if (B == Charging) { return; }

            //Update Charging
            ISet.FrameShiftDrive.Charging(MethodName, B);

            //Reset Charging States
            if (B == false)
            {
                ISet.FrameShiftDrive.Hyperspace(MethodName, false);
                ISet.FrameShiftDrive.Supercruise(MethodName, false);
            }

            //Audio - Charging Started:
            ChargingStart(
                ICheck.FrameShiftDrive.Charging(MethodName, true),    //Check Charging State
                ICheck.InitializedStatus(MethodName));                //Check Status.Json Initialized
        }

        #region Controls
        /// <summary>
        /// Will Attempt To Start Charging The FSD. Then Watch For It To Start
        /// </summary>
        /// <param name="HyperspaceCharge">True = Charing For Hyperspace.</param>
        /// <returns>True = FSD Started, False = FSD Failed To Engage.</returns>
        public bool Start(bool HyperspaceCharge)
        {
            //Keypress
            if (HyperspaceCharge)
            {
                Call.Key.Press(Call.Key.Hyperspace_Jump, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Supercruise, 0);
            }

            //Watch FSD Starting (3.25 Seconds)
            Thread.Sleep(250); decimal Count = 0; while (Charging == false)
            {
                Count++; Thread.Sleep(100); if (Count >= 30)
                {
                    return false;
                }
            }

            //Started
            if (HyperspaceCharge)
            {
                //Charge Mode
                ISet.FrameShiftDrive.Hyperspace(MethodName, true);
                ISet.FrameShiftDrive.Supercruise(MethodName, false);

                //Preparations
                ISet.FrameShiftDrive.PrepHyperspace(MethodName, false);
                ISet.FrameShiftDrive.PrepSupercruise(MethodName, false);
            }
            else
            {
                //Charge Mode
                ISet.FrameShiftDrive.Supercruise(MethodName, true);
                ISet.FrameShiftDrive.Hyperspace(MethodName, false);

                //Preparations
                ISet.FrameShiftDrive.PrepHyperspace(MethodName, false);
                ISet.FrameShiftDrive.PrepSupercruise(MethodName, false);
            }

            return true;
        }

        public bool Stop(bool EmergencyDrop = false)
        {
            ISet.FrameShiftDrive.Disengaging(MethodName, true);

            //Keypress
            if (EmergencyDrop == false)
            {
                Call.Key.Press(Call.Key.Supercruise, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Supercruise, 200);
                Call.Key.Press(Call.Key.Supercruise, 0);
            }

            //Watch FSD Disengaging
            ISet.FrameShiftDrive.Disengaging(MethodName, true);
            int Count = 0; while (Disengaging == true)
            {
                if (Count > 50)
                {
                    return false;
                }
                Thread.Sleep(100); Count++;
            }

            ISet.FrameShiftDrive.Disengaging(MethodName, true);

            //Disengaged
            return true;
        }

        public bool Abort()
        {
            //Keypress
            if (Charging)
            {
                Call.Key.Press(Call.Key.Toggle_Frame_Shift_Drive, 0);
            }

            //Watch FSD Abort
            int Count = 0; while (Charging == true)
            {
                if (Count > 30)
                {
                    return false;
                }
                Thread.Sleep(100); Count++;
            }

            //Preparations
            ISet.FrameShiftDrive.PrepHyperspace(MethodName, false);
            ISet.FrameShiftDrive.PrepSupercruise(MethodName, false);

            //Aborted
            return true;
        }

        /// <summary>
        /// Configure Frame Shift Drive Preparations
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="S">(State) Setting Or Resetting Preps</param>
        /// <param name="H">(Hyperspace) Set Hyperspace Preps. Defaults To Supercruise</param>
        public void Prepair(string M, bool S, bool H = false)
        {
            //Set Preprations
            if (S)
            {
                //Hyperspace
                if (H)
                {
                    ISet.FrameShiftDrive.PrepHyperspace(MethodName, true);
                    ISet.FrameShiftDrive.PrepSupercruise(MethodName, false);

                    //Audio - Prepair For Hyperspace
                }
                //Supercruise
                else
                {
                    ISet.FrameShiftDrive.PrepSupercruise(MethodName, true);
                    ISet.FrameShiftDrive.PrepHyperspace(MethodName, false);

                    //Audio - Prepair For Supercruise
                }
            }
            //Reset Preprations
            else
            {
                ISet.FrameShiftDrive.PrepSupercruise(MethodName, false);
                ISet.FrameShiftDrive.PrepHyperspace(MethodName, false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="M"></param>
        /// <param name="Prep"></param>
        /// <param name="Mark"></param>
        /// <param name="Mode"></param>
        public void Reset(string M, bool Prep, bool Mark, bool Mode)
        {
            if (Prep)
            {
                ISet.FrameShiftDrive.PrepHyperspace(M, false);
                ISet.FrameShiftDrive.PrepSupercruise(M, false);
            }                       
            if (Mark)
            {
                ISet.FrameShiftDrive.Marking(M, false);
            }            
            if (Mode)
            {
                ISet.FrameShiftDrive.Supercruise(MethodName, false);
                ISet.FrameShiftDrive.Hyperspace(MethodName, false);
            }
        }

        /// <summary>
        /// Reference Method To Allow Posting Debug Line For Returning.
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        public void Returned(string M)
        {
            Logger.DebugLine(M, "Returned From Logic", Logger.Yellow);
        }
        #endregion            

        #region Audio
        public void AbortSuccessful(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Charing Aborted.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.Abort_Successful),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void AbortFailed(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Failed To Aborted.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Abort_Failed),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void CoolingDown(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Stand By, Frame Shift Drive Is Cooling Down.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Cooldown),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void SC_CurrentlyHyperspace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative, Can't Do That In Hyperspace.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.SC_Currently_Hyperspace), 
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void TooFast(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Too Fast For A Safe Drop, Would You Like To Emergency Disengage?", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Too_Fast),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void SC_Disengaging(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Disengaging...", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.SC_Disengaging),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void SC_Prepairing(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Prepairing Ship For Supercruise", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.SC_Preparing),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void HS_Prepairing(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Prepairing Ship For Hyperspace", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.HS_Preparing),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void HS_CurrentlyCharging(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative, Currently Charging For Hyperspace", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.HS_Currently_Charging),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void SC_CurrentlyCharging(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative, Currently Charging For Supercruise", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.SC_Currently_Charging),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void SC_CurrentlySupercruise(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative, Currently Operating In Supercruise", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.SC_Currently_Supercruise),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void SC_CurrentlyNormalSpace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative, Currently Operating In Normal Space.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.SC_Currently_Normal_Space),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void HS_CurrentlyHyperspace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative, Currently Operating In Hyperspace", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.HS_Currently_Hyperspace),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void SC_Entering(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Entering Supercruise.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.SC_Entering),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void HS_Entering(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Entering Supercruise.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.HS_Entering),                
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void NoTouchdown(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative, Ship Is Touched Down.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.Negaive, true)
                .Phrase(EQ_Frame_Shift_Drive.Touchdown), 
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void NoDocked(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative, Ship Is Docked.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.Negaive, true)
                .Phrase(EQ_Frame_Shift_Drive.Docked),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void Masslocked(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Masslocked, Exit The Area To Continue...", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Masslock),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void ChargingStart(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Charging...", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Drive_Charging),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void FailedToEngage(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Failed To Engage.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Failed_to_Engage),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void FailedToDisengage(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Failed To Disengage.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Failed_to_Disengage),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        #endregion
    }
}