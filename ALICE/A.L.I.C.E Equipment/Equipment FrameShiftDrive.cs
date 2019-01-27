using System.Threading;
using ALICE_Actions;
using ALICE_Core;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Equipment
{
    public class Equipment_FrameShiftDrive : Equipment_General
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
        
        public bool Supercruise { get; set; }
        public bool Hyperspace { get; set; }
        public bool Charging { get; set; }
        public bool Cooldown { get; set; }
        public bool Prepairing { get; set; }
        public bool Disengaging { get; set; }

        public Equipment_FrameShiftDrive()
        {
            Settings.Equipment = IEquipment.E.Frame_Shift_Drive;
            Settings.Mode = IEquipment.M.Analysis;
            Settings.Installed = true;
            Settings.Enabled = true;

            Supercruise = false;
            Hyperspace = false;
            Charging = false;
            Cooldown = false;
            Prepairing = false;
            Disengaging = false;
        }

        public Equipment_FrameShiftDrive New() { return new Equipment_FrameShiftDrive(); }

        #region Controls
        /// <summary>
        /// Will Attempt To Start Charging The FSD. Then Watch For It To Start
        /// </summary>
        /// <param name="HyperspaceCharge">True = Charing For Hyperspace.</param>
        /// <returns>True = FSD Started, False = FSD Failed To Engage.</returns>
        public bool Start(bool HyperspaceCharge)
        {
            //Keypress
            if (HyperspaceCharge) { Call.Key.Press(Call.Key.Hyperspace_Jump, 0); }
            else { Call.Key.Press(Call.Key.Supercruise, 0); }

            //Watch FSD Starting (3.25 Seconds)
            Thread.Sleep(250); decimal Count = 0;
            while (Charging == false)
            { Count++; Thread.Sleep(100); if (Count >= 30) { return false; } }

            //Started
            if (HyperspaceCharge) { Supercruise = false; Hyperspace = true; }
            else { Supercruise = true; Hyperspace = false; }
            return true;
        }

        public bool Stop(bool EmergencyDrop = false)
        {
            //Keypress
            if (EmergencyDrop == false) { Call.Key.Press(Call.Key.Supercruise, 0); }
            else { Call.Key.Press(Call.Key.Supercruise, 200); Call.Key.Press(Call.Key.Supercruise, 0); }
            
            //Watch FSD Disengaging
            Disengaging = true; int Count = 0; while (Disengaging == true)
            { if (Count > 50) { return false; } Thread.Sleep(100); Count++; }

            //Disengaged
            return true;
        }

        public bool Abort()
        {
            //Keypress
            if (Charging) { Call.Key.Press(Call.Key.Toggle_Frame_Shift_Drive, 0); }

            //Watch FSD Abort
            int Count = 0; while (Charging == true)
            { if (Count > 30) { return false; } Thread.Sleep(100); Count++; }

            //Aborted
            return true;
        }
        #endregion        

        #region Checks
        public bool SupercruiseCharge(bool TargetState, string MethodName, bool DisableDebug = false)
        {
            bool State = IEquipment.FrameShiftDrive.Supercruise;
            string Equipment = "Charging Supercruise";
            return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
        }

        public bool HyperspaceCharge(bool TargetState, string MethodName, bool DisableDebug = false)
        {
            bool State = IEquipment.FrameShiftDrive.Hyperspace;
            string Equipment = "Charging Hyperspace";
            return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
        }

        public bool ChargingState(bool TargetState, string MethodName, bool DisableDebug = false)
        {
            bool State = IEquipment.FrameShiftDrive.Charging;
            string Equipment = "FSD Charge State";
            return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
        }

        public bool CooldownState(bool TargetState, string MethodName, bool DisableDebug = false)
        {
            bool State = IEquipment.FrameShiftDrive.Cooldown;
            string Equipment = "FSD Cooldown State";
            return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
        }

        public bool PreparingState(bool TargetState, string MethodName, bool DisableDebug = false)
        {
            bool State = IEquipment.FrameShiftDrive.Prepairing;
            string Equipment = "FSD Preparation State";
            return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
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