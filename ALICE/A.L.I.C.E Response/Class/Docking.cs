using ALICE_Debug;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Status;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {
        public static Docking Docking = new Docking();        
    }

    public class Docking
    {
        string ClassName = "Response Docking";

        /// <summary>
        /// Audio used to report docking preparations complete.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Preparations(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Collected: " + IStatus.Bounty.Reward, Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Docking_Preparations.Modifier, true)
                .Phrase(EQ_Shields.Offline, false, ICheck.Status.Shields(ClassName, false, true), false)
                .Phrase(GN_Docking_Preparations.Default),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report docking computer handover
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void StationHandover(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Station Handover Complete.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Docking_Request.Docking_Computer_Handover)
                .Token("[STATION]", IStatus.Docking.StationName),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report docking permission granted.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Granted(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Permission Granted. Landing Pad: " + IStatus.Docking.LandingPad, Logger.Yellow); }

            Speech.Speak
                (""
                .Phrase(GN_Docking_Request.Granted)
                .Phrase(GN_Docking_Request.Landing_Pad)
                .Token("[DOCKSTATION]", IStatus.Docking.StationName)
                .Token("[LANDINGPAD]", IStatus.Docking.LandingPad),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report docking permission already granted.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void AlreadyGranted(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Permission Already Granted. Landing Pad: " + IStatus.Docking.LandingPad, Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Docking_Request.Already_Granted)
                .Phrase(GN_Docking_Request.Landing_Pad)
                .Token("[DOCKSTATION]", IStatus.Docking.StationName)
                .Token("[LANDINGPAD]", IStatus.Docking.LandingPad),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report this ship is currently docked.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Docked(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Negative, Ship Is Docked.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(GN_Docking_Request.Docked),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report docking dendied due to active fighter.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void ActiveFighter(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Denial Reason: Acitve Fighter.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Docking_Request.Reason_Active_Fighter),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report docking denied due to distance from station.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Distance(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Denial Reason: Out Of Range.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Docking_Request.Reason_Distance),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report docking dendied due to active offences.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Offences(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Denial Reason: Active Offences.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Docking_Request.Reason_Offences),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report docking denied due to the station being hostile.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Hostile(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Denial Reason: Station Is Hostile.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Docking_Request.Reason_Hostile),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report docking dendied due to ship being too large.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void TooLarge(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Denial Reason: Ship Is Too Large.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Docking_Request.Reason_Too_Large),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report docking denied due to no free landing pads on the station.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void NoSpace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Denial Reason: Station Is Full, No Landing Pads Open.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Docking_Request.Reason_No_Space),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report that no reason was given for being denied docking.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void NoReason(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Denial Reason: No Reason Given.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Docking_Request.Reason_None_Given),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report it is unclear what docking was denied.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Unknown(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Denial Reason: Unknown.", Logger.Yellow); }

            Speech.Speak("It Is Unclear Why We Were Denied Docking Access Commander.",
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report docking and datalink connection.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Datalink(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Successfully Docked.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Facility_Report.Docked)
                .Phrase(GN_Facility_Report.Datalink)
                .Token("[STATION]", IObjects.FacilityCurrent.Name),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report the status of the station after docking.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void StationStatus(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Station Status Report Muted.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Facility_Report.Government)
                .Phrase(GN_Facility_Report.Economy)
                .Phrase(GN_Facility_Report.State, false, true, (Check.State.FacilityCurrent_State("None", false, ClassName)))
                .Token("[ECONOMY]", IObjects.FacilityCurrent.Economy)
                .Token("[GOVERNMENT]", IObjects.FacilityCurrent.Government)
                .Token("[ALLEGIANCE]", IObjects.FacilityCurrent.Allegiance)
                .Token("[STATION]", IObjects.FacilityCurrent.Name)
                .Token("[STATE]", IObjects.FacilityCurrent.ControlFactionState),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report the ship is undocked.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Undocked(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Ship Is Undocked.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Facility_Report.Undocked)
                .Phrase(GN_Facility_Report.Undocked_Modifier),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report entering the no fire zone.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void NoFireZoneEntered(string Station, bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Entered No Fire Zone.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EVT_NoFireZone.Entered)
                .Token("[STATION]", Station),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report exiting the no fire zone.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void NoFireZoneExited(string Station, bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Exited No Fire Zone.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EVT_NoFireZone.Exited)
                .Token("[STATION]", Station),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report weapon safeties enabled.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void WeaponSafetiesEnabling(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Enabled Weapon Safeties.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Hardpoints.Safety_Engaging),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report weapon safeties disabled.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void WeaponSafetiesDisabling(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Disabled Weapon Safeties.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Hardpoints.Safety_Disengaging),
                CA, V1, V2, V3, P, V);
        }


        /// <summary>
        /// Audio used to report hardpoints retracted and safeties enabled.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void WeaponSafetiesEnablingDeployed(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Retracting Hardpoints, Enabling Weapon Safeties.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Hardpoints.Safety_Engaging),
                CA, V1, V2, V3, P, V);
        }
    }
}