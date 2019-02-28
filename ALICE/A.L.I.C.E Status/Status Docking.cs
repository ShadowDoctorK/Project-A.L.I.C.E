using ALICE_Actions;
using ALICE_Core;
using ALICE_Debug;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Settings;
using ALICE_Synthesizer;
using System.Threading;

namespace ALICE_Status
{
    public class Status_Docking
    {
        /* Data Sources
         * 1. Docked Event
         * 2. Undocked Event
         * 3. DockingDenied Event
         * 4. DockingRequested Event
         * 5. DockingGranted Event
         * 6. DockingCancelled Event
         * 7. Location Event
         */

        private readonly string MethodName = "Docking Status";

        public bool Docked = false;                                             //Status.Json Property
        public IEnums.DockingState State = IEnums.DockingState.Undocked;        //Event Property
        public IEnums.DockingDenial Denial = IEnums.DockingDenial.NoReason;     //Event Property
        public string StationName = "Unknown";                                  //Event Property
        public string StationType = "Unknown";                                  //Event Property
        public decimal LandingPad = -1;                                         //Event Property

        public bool Preparations = false;                                       //Custom Property
        public bool Sending = false;                                            //Custom Property
        public bool Pending = false;                                            //Custom Property

        public Logging Log = new Logging();
        public Responces Response = new Responces();

        public void Update(Docked Event)
        {
            State = IEnums.DockingState.Docked;
            StationName = Event.StationName;
            StationType = Event.StationType;
            Denial = IEnums.DockingDenial.NoReason;
            LandingPad = -1;
            Pending = false;
            Sending = false;
            Docked = true;
        }

        public void Update(DockingCancelled Event)
        {
            State = IEnums.DockingState.Cancelled;
            StationName = Event.StationName;
            StationType = Event.StationType;
            Denial = IEnums.DockingDenial.NoReason;
            LandingPad = -1;
            Pending = false;
            Sending = false;
            Docked = false;
        }

        public void Update(DockingTimeout Event)
        {
            //Marking A Cancelled To Keep Things Simple
            State = IEnums.DockingState.Cancelled;
            Denial = IEnums.DockingDenial.NoReason;
            LandingPad = -1;
            Pending = false;
            Sending = false;
            Docked = false;
        }

        public void Update(DockingGranted Event)
        {
            State = IEnums.DockingState.Granted;
            StationName = Event.StationName;
            StationType = Event.StationType;
            Denial = IEnums.DockingDenial.NoReason;
            LandingPad = Event.LandingPad;
            Pending = false;
            Sending = false;
            Docked = false;
        }

        public void Update(DockingRequested Event)
        {
            State = IEnums.DockingState.Requested;
            StationName = Event.StationName;
            StationType = Event.StationType;
            Denial = IEnums.DockingDenial.NoReason;
            LandingPad = -1;
            Pending = true;
            Sending = false;
            Docked = false;
        }

        public void Update(DockingDenied Event)
        {
            State = IEnums.DockingState.Denied;
            StationName = Event.StationName;
            StationType = Event.StationType;

            //Convert & Set Denial Reason
            Denial = IEnums.ToEnum<IEnums.DockingDenial>(Event.Reason);

            //Track New Denial Reasons
            if (Denial == IEnums.DockingDenial.NotSet)
            {
                Logger.DevUpdateLog(MethodName, "New Denial Reason Detected: " + Event.Reason, Logger.Yellow);
            }

            LandingPad = -1;
            Pending = false;
            Sending = false;
            Docked = false;
        }

        public void Update(Undocked Event)
        {
            State = IEnums.DockingState.Undocked;
            StationName = Event.StationName;
            StationType = Event.StationType;
            Denial = IEnums.DockingDenial.NoReason;
            LandingPad = -1;
            Preparations = false;
            Pending = false;
            Sending = false;
            Docked = false;
        }

        public void Update(Location Event)
        {
            switch (Event.Docked)
            {
                case true:
                    State = IEnums.DockingState.Docked; Docked = true; break;                    
                default:
                    State = IEnums.DockingState.Undocked; Docked = false; break;
            }

            Docked = Event.Docked;
            StationName = Event.StationName;
            StationType = Event.StationType;
            Denial = IEnums.DockingDenial.NoReason;
            LandingPad = -1;
            Pending = true;
            Sending = false;
        }

        public void Update(SupercruiseEntry Event)
        {
            State = IEnums.DockingState.Undocked;
            Denial = IEnums.DockingDenial.NoReason;
            StationName = "Unknown";
            StationType = "Unknown";
            LandingPad = -1;
            Pending = false;
            Sending = false;
            Preparations = false;
            Docked = false;
        }

        public void Update(SupercruiseExit Event)
        {
            State = IEnums.DockingState.Undocked;
            Denial = IEnums.DockingDenial.NoReason;
            StationName = Event.Body;
            StationType = "Unknown";
            LandingPad = -1;
            Pending = false;
            Sending = false;
            Preparations = false;
            Docked = false;
        }

        public bool WatchRequest()
        {
            string MethodName = "Watch Request";

            //Watch For Request To Send
            Logger.DebugLine(MethodName, "Waiting For Request To Send. (5 Seconds)", Logger.Blue);
            int Counter = 0; while (Sending == true)
            {
                Thread.Sleep(100); if (Counter > 50) { Sending = false; return false; } Counter++;
            }

            //Request Sent
            return true;
        }

        public bool WatchResponse()
        {
            string MethodName = "Watch Response";

            //Watch For Facility Response
            Logger.DebugLine(MethodName, "Waiting For Response To Pending Request. (10 Seconds)", Logger.Blue);
            int Counter = 0; while  (Pending == true && ALICE_Internal.Check.Environment.Space(IEnums.Normal_Space, true, MethodName, true))
            {                
                Thread.Sleep(100); if (Counter > 100) { Pending = false; return false; } Counter++;                
            }

            return true;
        }

        public void WatchStarportEntry()
        {
            string MethodName = "Watch Starport Entry";

            if (IStatus.Docking.Preparations == false)
            {
                Thread thread = new Thread((ThreadStart)(() => 
                {
                    //Check
                    if (ICheck.Music.MusicTrack(MethodName, false, IEnums.Starport) == false)
                    {
                        //Already Inside Starport
                        return;
                    }

                    //Watch Entering Starport While Docking State Is False
                    while (Check.Environment.Space(IEnums.Normal_Space, true, MethodName, true) == true &&
                        IStatus.LandingGear == false)
                    {
                        if (ICheck.Music.MusicTrack(MethodName) == IEnums.Starport && 
                            (IStatus.Docking.Preparations == false || IStatus.LandingGear == false))
                        {
                            IStatus.Docking.Preparations = true; Call.Action.DockingPreparations(true); return;
                        }
                        Thread.Sleep(100);
                    }
                })) { IsBackground = true };
                thread.Start();                
            }
        }

        /// <summary>
        /// Will conduct event checks and Monitor for Assisted Docking as required.
        /// </summary>
        /// <param name="Event">SupercruiseExit Event</param>
        public void AssistedDocking(SupercruiseExit Event)
        {
            string MethodName = "Docking Status (Assisted Docking)";

            //Check Plugin Initialized
            if (ICheck.Initialized(MethodName) == false) { return; }

            //Check Order Enabled
            if (ICheck.Order.AssistDocking(MethodName, true) == false)
            {
                //No Logger Required. Check Already Logs.
                return;
            }

            //Check BodyType is Planet
            if (Event.BodyType != IEnums.Station)
            {
                Logger.DebugLine(MethodName, "Body Type Is Not A Station", Logger.Yellow);
                return;
            }

            //Assisted Docking
            Thread thread =
            new Thread((ThreadStart)(() =>
            {
                Logger.Log(MethodName, "Standing By To Send Docking Request...", Logger.Yellow, true);

                //While Assisted Docking is True and BodyType equals Station Check For Next Trigger for 60 Seconds.
                int i = 600;
                while (i > 0 &&
                ICheck.Order.AssistDocking(MethodName, true, false) == true && 
                ICheck.SupercruiseExit.BodyType(MethodName, true, IEnums.Station, false) == true)               
                {
                    //Check NoFireZone and Masslock. If both true send a Docking Request.
                    i--; if (
                    ICheck.NoFireZone.Status(MethodName, true) == true && 
                    Check.Variable.MassLocked(true, MethodName) == true)
                    {
                        Call.Action.Docking(IEnums.CMD.True, true, false);
                        return;
                    }
                    Thread.Sleep(100);
                }
                Logger.Log(MethodName, "Switched To Manual Docking. You Took Too Long...", Logger.Yellow, true);
            }))
            { IsBackground = false };
            thread.Start();
        }
        
        public void PostDockingActions()
        {
            string MethodName = "Post Docking";

            //Validate Plugin Is Initialized
            if (ICheck.Initialized(MethodName) == false) { return; }

            if(State != IEnums.DockingState.Granted)
            {
                Logger.DebugLine(MethodName, "Docking State Does Not Equal Granted", Logger.Yellow);
                return;
            }

            //Station Services & Assisted Hanger Entry
            Thread Action =
            new Thread((ThreadStart)(() =>
            {
                #region Hanger Entry & Open Station Services
                Thread.Sleep(1000 + ISettings.OffsetPanels);

                Call.Key.Press(Call.Key.UI_Panel_Up_Press, 500);
                Call.Key.Press(Call.Key.UI_Panel_Up_Release, 100);

                //Assisted Hanger Entry
                if (ICheck.Order.AssistHangerEntry(MethodName, true))
                {
                    Call.Key.Press(Call.Key.UI_Panel_Down, 100);
                    Call.Key.Press(Call.Key.UI_Panel_Select, 100);
                    Call.Key.Press(Call.Key.UI_Panel_Up, 100);
                }

                Call.Key.Press(Call.Key.UI_Panel_Select, 100);
                #endregion
            }))
            { IsBackground = true };
            Action.Start();
        }

        public class Responces
        {
            string MethodName = "Docking Status";

            public void Positve(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Aye Aye Commander." + IStatus.Docking.LandingPad, Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Positive.Default),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void StationHandover(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Station Handover Complete.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Docking_Request.Docking_Computer_Handover)
                    .Token("[STATION]", IStatus.Docking.StationName),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Granted(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Permission Granted. Landing Pad: " + IStatus.Docking.LandingPad, Logger.Yellow); }

                Speech.Speak
                    (""
                    .Phrase(GN_Docking_Request.Granted)
                    .Phrase(GN_Docking_Request.Landing_Pad)
                    .Token("[DOCKSTATION]", IStatus.Docking.StationName)
                    .Token("[LANDINGPAD]", IStatus.Docking.LandingPad),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void AlreadyGranted(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Permission Already Granted. Landing Pad: " + IStatus.Docking.LandingPad, Logger.Yellow); }

                Speech.Speak (""
                    .Phrase(GN_Docking_Request.Already_Granted)
                    .Phrase(GN_Docking_Request.Landing_Pad)
                    .Token("[DOCKSTATION]", IStatus.Docking.StationName)
                    .Token("[LANDINGPAD]", IStatus.Docking.LandingPad),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice );
            }

            public void Docked(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative, Ship Is Docked.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Negative.Default, true)
                    .Phrase(GN_Docking_Request.Docked),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void ActiveFighter(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Acitve Fighter.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Docking_Request.Reason_Active_Fighter),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Distance(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Out Of Range.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Docking_Request.Reason_Distance),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Offences(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Acitve Offences.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Docking_Request.Reason_Offences),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Hostile(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Station Is Hostile.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Docking_Request.Reason_Hostile),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void TooLarge(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Ship Is Too Large.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Docking_Request.Reason_Too_Large),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void NoSpace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Station Is Full, No Landing Pads Open.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Docking_Request.Reason_No_Space),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void NoReason(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: No Reason Given.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Docking_Request.Reason_None_Given),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Unknown(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Unknown.", Logger.Yellow); }

                Speech.Speak("It Is Unclear Why We Were Denied Docking Access Commander.",
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Datalink(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Successfully Docked.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Facility_Report.Docked)
                    .Phrase(GN_Facility_Report.Datalink)
                    .Token("[STATION]", IObjects.FacilityCurrent.Name),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void StationStatus(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Station Status Report Muted.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Facility_Report.Government)
                    .Phrase(GN_Facility_Report.Economy)
                    .Phrase(GN_Facility_Report.State, false, true, (Check.State.FacilityCurrent_State("None", false, MethodName)))
                    .Token("[ECONOMY]", IObjects.FacilityCurrent.Economy)
                    .Token("[GOVERNMENT]", IObjects.FacilityCurrent.Government)
                    .Token("[ALLEGIANCE]", IObjects.FacilityCurrent.Allegiance)
                    .Token("[STATION]", IObjects.FacilityCurrent.Name)
                    .Token("[STATE]", IObjects.FacilityCurrent.ControlFactionState),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Undocked(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Ship Is Undocked.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Facility_Report.Undocked)
                    .Phrase(GN_Facility_Report.Undocked_Modifier),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void NoFireZoneEntered(string Station, bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Entered No Fire Zone.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EVT_NoFireZone.Entered)
                    .Token("[STATION]", Station),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void NoFireZoneExited(string Station, bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Exited No Fire Zone.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EVT_NoFireZone.Exited)
                    .Token("[STATION]", Station),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void WeaponSafetiesEnabling(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Enabled Weapon Safeties.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EQ_Hardpoints.Safety_Engaging),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void WeaponSafetiesDisabling(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Disabled Weapon Safeties.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EQ_Hardpoints.Safety_Disengaging),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void WeaponSafetiesEnablingDeployed(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Retracting Hardpoints, Enabling Weapon Safeties.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EQ_Hardpoints.Safety_Disengaging),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }

        public class Logging
        {
            /// <summary>
            /// Logs The Currently Recorded Docking Status.
            /// </summary>
            public void Status()
            {
                string MethodName = "Docking Status";

                //Startup Check
                if (ICheck.Initialized(MethodName) == false) { return; }

                //Log Items
                if (IStatus.Docking.Denial != IEnums.DockingDenial.NoReason) { Logger.Log(MethodName, "Denial Reason: " + IStatus.Docking.Denial, Logger.Yellow, true); }
                if (IStatus.Docking.LandingPad != -1) { Logger.Log(MethodName, "Landing Pad: " + IStatus.Docking.LandingPad, Logger.Yellow, true); }
                Logger.Log(MethodName, "Request State: " + IStatus.Docking.State, Logger.Yellow, true);
                Logger.Log(MethodName, "Station Type: " + IStatus.Docking.StationType, Logger.Yellow, true);
                Logger.Log(MethodName, "Station Name: " + IStatus.Docking.StationName, Logger.Yellow, true);
            }
        }        
    }
}
