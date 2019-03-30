using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {
        public static Frame_Shift_Drive FrameShiftDrive = new Frame_Shift_Drive();
    }

    public class Frame_Shift_Drive : Generic_Equipment
    {
        public void AbortSuccessful(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Charing Aborted.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.Abort_Successful),
                CA, V1, V2, V3, P, V);
        }

        public void AbortFailed(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Failed To Aborted.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Abort_Failed),
                CA, V1, V2, V3, P, V);
        }

        public void CoolingDown(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Stand By, Frame Shift Drive Is Cooling Down.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Cooldown),
                CA, V1, V2, V3, P, V);
        }

        public void SC_CurrentlyHyperspace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Negative, Can't Do That In Hyperspace.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.SC_Currently_Hyperspace),
                CA, V1, V2, V3, P, V);
        }

        public void TooFast(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Too Fast For A Safe Drop, Would You Like To Emergency Disengage?", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Too_Fast),
                CA, V1, V2, V3, P, V);
        }

        public void SC_Disengaging(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Disengaging...", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.SC_Disengaging),
                CA, V1, V2, V3, P, V);
        }

        public void SC_Prepairing(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Prepairing Ship For Supercruise", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.SC_Preparing),
                CA, V1, V2, V3, P, V);
        }

        public void HS_Prepairing(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Prepairing Ship For Hyperspace", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.HS_Preparing),
                CA, V1, V2, V3, P, V);
        }

        public void HS_CurrentlyCharging(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Negative, Currently Charging For Hyperspace", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.HS_Currently_Charging),
                CA, V1, V2, V3, P, V);
        }

        public void SC_CurrentlyCharging(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Negative, Currently Charging For Supercruise", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.SC_Currently_Charging),
                CA, V1, V2, V3, P, V);
        }

        public void SC_CurrentlySupercruise(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Negative, Currently Operating In Supercruise", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.SC_Currently_Supercruise),
                CA, V1, V2, V3, P, V);
        }

        public void SC_CurrentlyNormalSpace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Negative, Currently Operating In Normal Space.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.SC_Currently_Normal_Space),
                CA, V1, V2, V3, P, V);
        }

        public void HS_CurrentlyHyperspace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Negative, Currently Operating In Hyperspace", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.HS_Currently_Hyperspace),
                CA, V1, V2, V3, P, V);
        }

        public void SC_Entering(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Entering Supercruise.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.SC_Entering),
                CA, V1, V2, V3, P, V);
        }

        public void HS_Entering(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Entering Supercruise.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.HS_Entering),
                CA, V1, V2, V3, P, V);
        }

        public override void NoTouchdown(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Negative, Ship Is Touched Down.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.Negaive, true)
                .Phrase(EQ_Frame_Shift_Drive.Touchdown),
                CA, V1, V2, V3, P, V);
        }

        public override void NoDocked(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Negative, Ship Is Docked.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Frame_Shift_Drive.Negaive, true)
                .Phrase(EQ_Frame_Shift_Drive.Docked),
                CA, V1, V2, V3, P, V);
        }

        public void Masslocked(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Masslocked, Exit The Area To Continue...", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Masslock),
                CA, V1, V2, V3, P, V);
        }

        public void ChargingStart(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Charging...", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Drive_Charging),
                CA, V1, V2, V3, P, V);
        }

        public void FailedToEngage(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Failed To Engage.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Failed_to_Engage),
                CA, V1, V2, V3, P, V);
        }

        public void FailedToDisengage(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Failed To Disengage.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Frame_Shift_Drive.Failed_to_Disengage),
                CA, V1, V2, V3, P, V);
        }
    }
}
