using ALICE_Actions;
using ALICE_Core;
using ALICE_Debug;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Keybinds;
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

        public void Update(Docked Event)
        {
            ISet.Docking.Status(MethodName, IEnums.DockingState.Docked);
            Denial = IEnums.DockingDenial.NoReason;
            StationName = Event.StationName;
            StationType = Event.StationType;
            LandingPad = -1;
            Pending = false;
            Sending = false;
            Docked = true;
        }

        public void Update(DockingCancelled Event)
        {
            ISet.Docking.Status(MethodName, IEnums.DockingState.Cancelled);
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
            ISet.Docking.Status(MethodName, IEnums.DockingState.Cancelled);
            State = IEnums.DockingState.Cancelled;
            Denial = IEnums.DockingDenial.NoReason;
            LandingPad = -1;
            Pending = false;
            Sending = false;
            Docked = false;
        }

        public void Update(DockingGranted Event)
        {
            ISet.Docking.Status(MethodName, IEnums.DockingState.Granted);            
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
            ISet.Docking.Status(MethodName, IEnums.DockingState.Requested);
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
            ISet.Docking.Status(MethodName, IEnums.DockingState.Denied);
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
            ISet.Docking.Status(MethodName, IEnums.DockingState.Undocked);
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
                    ISet.Docking.Status(MethodName, IEnums.DockingState.Docked); break;          
                    
                default:
                    ISet.Docking.Status(MethodName, IEnums.DockingState.Undocked); break;
            }

            Docked = Event.Docked;
            StationName = Event.StationName;
            StationType = Event.StationType;
            Denial = IEnums.DockingDenial.NoReason;
            LandingPad = -1;
            Pending = false;
            Sending = false;
        }

        public void Update(SupercruiseEntry Event)
        {
            ISet.Docking.Status(MethodName, IEnums.DockingState.Undocked);
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
            ISet.Docking.Status(MethodName, IEnums.DockingState.Undocked);
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
            int Counter = 0; while  (Pending == true && ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space, false))
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
                    if (ICheck.Music.MusicTrack(MethodName, false, IEnums.Starport, true) == false)
                    {
                        //Already Inside Starport
                        return;
                    }

                    //Watch Entering Starport While Docking State Is False
                    while (ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space, false) == true &&
                        ICheck.LandingGear.Status(MethodName, false) == true)
                    {
                        if (IGet.Music.MusicTrack(MethodName) == IEnums.Starport && 
                            (IStatus.Docking.Preparations == false || ICheck.LandingGear.Status(MethodName, false)))
                        {
                            IStatus.Docking.Preparations = true; IActions.Docking.Preparations(true); return;
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
            if (ICheck.Order.AssistDocking(MethodName, true, true) == false)
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
                    ICheck.Masslock.Status(MethodName, true) == true)
                    {
                        IActions.Docking.Request(IEnums.CMD.True, true, false);
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

            if (ICheck.Docking.Status(MethodName, true, IEnums.DockingState.Docked) == false)
            {
                return;
            }
            
            //Station Services & Assisted Hanger Entry
            Thread Action =
            new Thread((ThreadStart)(() =>
            {
                #region Hanger Entry & Open Station Services
                Thread.Sleep(1000);

                IKeyboard.Press(IKey.UI_Panel_Up_Press, 500);
                IKeyboard.Press(IKey.UI_Panel_Up_Release, 100);

                //Assisted Hanger Entry
                if (ICheck.Order.AssistHangerEntry(MethodName, true, true))
                {
                    IKeyboard.Press(IKey.UI_Panel_Down, 100);
                    IKeyboard.Press(IKey.UI_Panel_Select, 100);
                    IKeyboard.Press(IKey.UI_Panel_Up, 100);
                }

                IKeyboard.Press(IKey.UI_Panel_Select, 100);
                #endregion
            }))
            { IsBackground = true };
            Action.Start();
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
