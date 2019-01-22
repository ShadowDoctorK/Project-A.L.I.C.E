﻿using ALICE_Actions;
using ALICE_Core;
using ALICE_Events;
using ALICE_Interface;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALICE_Status
{
    public class Status_Docking
    {
        /*Data Sources
        * 1. Docked Event
        * 2. Undocked Event
        * 3. DockingDenied Event
        * 4. DockingRequested Event
        * 5. DockingGranted Event
        * 6. DockingCancelled Event
        * 7. Location Event
        */

        public IEnums.DockingState State = IEnums.DockingState.Undocked;
        public IEnums.DockingDenial Denial = IEnums.DockingDenial.NoReason;
        public string StationName = "Unknown";
        public string StationType = "Unknown";
        public decimal LandingPad = -1;
        //public string DeniedReason = "NoReason";

        public bool Preparations = false;
        public bool Sending = false;
        public bool Pending = false;
        public Logging Log = new Logging();
        public Responces Response = new Responces();
        public Checks Check = new Checks();

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
                    var MusicEvent = new Music();

                    //Watch Entering Starport While Docking State Is False
                    while (MusicEvent.MusicTrack != "Starport" && ALICE_Internal.Check.Environment.Space(IEnums.Docked, false, MethodName, true) == true)
                    {
                        if (IEvents.Events["Music"] != null) { MusicEvent = (Music)IEvents.GetEvent("Music"); }

                        if (MusicEvent.MusicTrack == "Starport" && IStatus.Docking.Preparations == false)
                        { IStatus.Docking.Preparations = true; Call.Action.DockingPreparations(true); return; }
                        Thread.Sleep(100);
                    }
                })) { IsBackground = true };
                thread.Start();                
            }
        }

        public class Responces
        {
            string MethodName = "Docking";

            public void Positve(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Aye Aye Commander." + IStatus.Docking.LandingPad, Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Positive.Default),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void StationHandover(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Station Handover Complete.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Docking_Request.Docking_Computer_Handover)
                    .Token("[STATION]", IStatus.Docking.StationName),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Granted(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Permission Granted. Landing Pad: " + IStatus.Docking.LandingPad, Logger.Yellow); }

                Speech.Speak
                    (""
                    .Phrase(Docking_Request.Granted)
                    .Phrase(Docking_Request.Landing_Pad)
                    .Token("[DOCKSTATION]", IStatus.Docking.StationName)
                    .Token("[LANDINGPAD]", IStatus.Docking.LandingPad),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void AlreadyGranted(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Permission Already Granted. Landing Pad: " + IStatus.Docking.LandingPad, Logger.Yellow); }

                Speech.Speak (""
                    .Phrase(Docking_Request.Already_Granted)
                    .Phrase(Docking_Request.Landing_Pad)
                    .Token("[DOCKSTATION]", IStatus.Docking.StationName)
                    .Token("[LANDINGPAD]", IStatus.Docking.LandingPad),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice );
            }

            public void Docked(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative, Ship Is Docked.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Negative.Default, true)
                    .Phrase(Docking_Request.Docked),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void ActiveFighter(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Acitve Fighter.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Docking_Request.Reason_Active_Fighter),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Distance(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Out Of Range.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Docking_Request.Reason_Distance),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Offences(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Acitve Offences.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Docking_Request.Reason_Offences),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Hostile(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Station Is Hostile.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Docking_Request.Reason_Hostile),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void TooLarge(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Ship Is Too Large.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Docking_Request.Reason_Too_Large),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void NoSpace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Station Is Full, No Landing Pads Open.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Docking_Request.Reason_No_Space),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void NoReason(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: No Reason Given.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Docking_Request.Reason_None_Given),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Unknown(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Denial Reason: Unknown.", Logger.Yellow); }

                Speech.Speak("It Is Unclear Why We Were Denied Docking Access Commander.",
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }

        public class Checks
        {

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
                if (ALICE_Internal.Check.Internal.TriggerEvents(true, MethodName) == false) { return; }

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
