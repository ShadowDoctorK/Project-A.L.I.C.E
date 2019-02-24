using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Objects
{
    public class Object_Target
    {
        /* The following Journal Lines can be used as a reference to understand the Objects Flow and Logic.
            { "timestamp":"2018-10-26T11:41:10Z", "event":"ShipTargeted", "TargetLocked":true, "Ship":"type7", "Ship_Localised":"Type-7 Transporter", "ScanStage":0 }
            { "timestamp":"2018-10-26T11:41:11Z", "event":"ShipTargeted", "TargetLocked":true, "Ship":"type7", "Ship_Localised":"Type-7 Transporter", "ScanStage":1, "PilotName":"$npc_name_decorate:#name=Klemke The Awesomenator;", "PilotName_Localised":"Klemke The Awesomenator", "PilotRank":"Harmless" }
            { "timestamp":"2018-10-26T11:41:13Z", "event":"ShipTargeted", "TargetLocked":true, "Ship":"type7", "Ship_Localised":"Type-7 Transporter", "ScanStage":2, "PilotName":"$npc_name_decorate:#name=Klemke The Awesomenator;", "PilotName_Localised":"Klemke The Awesomenator", "PilotRank":"Harmless", "ShieldHealth":0.000000, "HullHealth":45.130104 }
            { "timestamp":"2018-10-26T11:41:15Z", "event":"ShipTargeted", "TargetLocked":true, "Ship":"type7", "Ship_Localised":"Type-7 Transporter", "ScanStage":3, "PilotName":"$npc_name_decorate:#name=Klemke The Awesomenator;", "PilotName_Localised":"Klemke The Awesomenator", "PilotRank":"Harmless", "ShieldHealth":0.000000, "HullHealth":33.011375, "Faction":"Kao Kach Purple Energy PLC", "LegalStatus":"Wanted", "Bounty":10395 }
            { "timestamp":"2018-10-26T11:41:22Z", "event":"ShipTargeted", "TargetLocked":false }
        */

        public string MethodName = "Target";
        public Subsystem_Tracking Subsystem = new Subsystem_Tracking();

        //ShipTargetted Event Properties
        public bool Targeted { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public decimal ScanStage { get; set; }
        public string PilotName { get; set; }
        public string PilotName_Localised { get; set; }
        public string PilotRank { get; set; }
        public decimal ShieldHealth { get; set; }
        public decimal HullHealth { get; set; }
        public string Faction { get; set; }
        public string LegalStatus { get; set; }
        public decimal Bounty { get; set; }  

        //Custom Properties
        public bool FullScan = false;                       //Tracks if the Initial Scan Stage 3 Has been processed.

        //Subsystem Properties
        public Dictionary<decimal, Subsys> Subsystems { get; set; }
        public string SubsystemArrayStart = "";
        public bool SubsystemArrayRecord = false;
        public bool DeepScan = false;

        /// <summary>
        /// List containing Module Names that a ship can only have one of.
        /// </summary>
        public static readonly List<string> RestrictedModules = new List<string>(new string[]
        {
            "Manifest Scanner",
            "Power Plant",
            "FSD",
            "Power Distributor",
            "Shield Generator",
            "Cargo Hatch",
            "Life Support",
            "FSD Interdictor"
        });

        public Object_Target()
        {
            Targeted = true;
            ScanStage = 0;

            Subsystems = new Dictionary<decimal, Subsys>();
            SubsystemArrayStart = "";
            SubsystemArrayRecord = false;
            DeepScan = false;
        }

        #region Support Methods
        /// <summary>
        /// Creates a new Target Object.
        /// </summary>
        /// <param name="Event">If a ShipTargeted Event is passed it will the events settings.</param>
        /// <returns>Returns a new Target Object</returns>      
        public Object_Target New(ShipTargeted Event = null)
        {
            //Create A New Target Object.
            Object_Target Temp = new Object_Target();

            //Update
            if (Event != null)
            {
                //Temp = Temp.Update(Event);
            }

            //Return The New Target Object.
            return Temp;
        }

        public void Process(ShipTargeted Event)
        {
            string MethodName = "Target (Process)";

            if (Check.Internal.TriggerEvents(true, MethodName) == false) { return; }

            #region Target vs Event Debug Lines
            Logger.DebugLine(MethodName, "Target Locked: " + Targeted + " | Event: " + Event.TargetLocked, Logger.Yellow);
            Logger.DebugLine(MethodName, "Scan Stage: " + ScanStage + " | Event: " + Event.ScanStage, Logger.Yellow);
            Logger.DebugLine(MethodName, "ED Ship: " + Ship + " | Event: " + Event.Ship, Logger.Yellow);
            Logger.DebugLine(MethodName, "Ship: " + Ship_Localised + " | Event: " + Event.Ship_Localised, Logger.Yellow);
            Logger.DebugLine(MethodName, "ED Pilot Name: " + PilotName + " | Event: " + Event.PilotName, Logger.Yellow);
            Logger.DebugLine(MethodName, "PilotName: " + PilotName_Localised + " | Event: " + Event.PilotName_Localised, Logger.Yellow);
            Logger.DebugLine(MethodName, "Pilot Rank: " + PilotRank + " | Event: " + Event.PilotRank, Logger.Yellow);
            Logger.DebugLine(MethodName, "Shield Health: " + ShieldHealth + " | Event: " + Event.ShieldHealth, Logger.Yellow);
            Logger.DebugLine(MethodName, "Hull Health: " + HullHealth + " | Event: " + Event.HullHealth, Logger.Yellow);
            Logger.DebugLine(MethodName, "Faction: " + Faction + " | Event: " + Event.Faction + " | Full Scan: " + FullScan, Logger.Yellow);
            Logger.DebugLine(MethodName, "Legal Status: " + LegalStatus + " | Event: " + Event.LegalStatus + " | Full Scan: " + FullScan, Logger.Yellow);
            Logger.DebugLine(MethodName, "Bounty: " + Bounty + " | Event: " + Event.Bounty + " | Full Scan: " + FullScan, Logger.Yellow);
            Logger.DebugLine(MethodName, "ED Subsystem: " + Subsystem.NameED + " | Event: " + Event.Subsystem, Logger.Yellow);
            Logger.DebugLine(MethodName, "Subsystem: " + Subsystem.Name + " | Event: " + Event.Subsystem_Localised, Logger.Yellow);
            Logger.DebugLine(MethodName, "Subsystem Health: " + Subsystem.Health + " | Event: " + Event.SubsystemHealth, Logger.Yellow);
            #endregion

            #region Scan Stage 0:
            /* 
             1. Target Lock Status
             2. Scan Stage
             3. Ship Type (Game File)
             4. Ship Type (Display Name)
             */

            //1. Target Lock Status:
            //Check If Target Lock Was Lost.
            if (Event.TargetLocked == false)
            {
                //Extened Logging Entry
                Logger.Log(MethodName, "No Target Lock", Logger.Yellow, true);

                //Set Targeted To False.
                Targeted = false;

                //Return So We Can Save/Check Data If We Regain.
                return;
            }
            //Check If We've Aquired New Target Lock.
            else if (Targeted != Event.TargetLocked && Targeted == false)
            {
                //Extened Logging Entry
                Logger.Log(MethodName, "Target Locked", Logger.Yellow, true);

                //Set Targeted To False.
                Targeted = true;
            }

            //2. Scan Stage Check
            if (ScanStage != Event.ScanStage)
            {
                //If Event ScanStage Is Lower Than Object ScanStage.
                if (ScanStage > Event.ScanStage)
                {
                    //Debug Logging.
                    Logger.DebugLine(MethodName, "New Target Based On Lower Scan Stage", Logger.Blue);

                    //Update All Properties.
                    Update(Event);
                }
                else
                {
                    //Update ScanStage Property
                    ScanStage = Event.ScanStage;
                }
            }

            //3. Ship Type
            if (Ship != Event.Ship)
            {
                //Ship Should Be Initially Set During Scan Stage 0.
                //If Its Different Then Its A New Target.
                if (ScanStage != 0)
                {
                    //Debug Logging.
                    Logger.DebugLine(MethodName, "New Target Based On Different Ship Type", Logger.Blue);

                    //Update All Properties.
                    Update(Event);
                }
                else
                {
                    //Update Ship Property
                    Ship = Event.Ship;
                }
            }

            //4. Ship Type (Localized)
            if (Ship_Localised != Event.Ship_Localised)
            {
                //Ship_Localized Should Be Initially Set During Scan Stage 0.
                //If Its Different Then Its A New Target.
                if (ScanStage != 0)
                {
                    //Debug Logging.
                    Logger.DebugLine(MethodName, "New Target Based On Different Ship Type (Localized)", Logger.Blue);

                    //Update All Properties.
                    Update(Event);
                }
                else
                {
                    //Update ScanStage Property
                    Ship_Localised = Event.Ship_Localised;
                }
            }
            #endregion

            #region Scan Stage 1:
            /*
             1. Pilots Name (Game File)
             2. Pilots Name (Display Name)
             3. Pilots Rank           
            */

            if (Event.ScanStage >= 1)
            {
                //1.Pilots Name(Game File)
                if (PilotName != Event.PilotName)
                {
                    //PilotName Should Be Initially Set During Scan Stage 1.
                    //If Its Different Then Its A New Target.
                    if (ScanStage != 1)
                    {
                        //Debug Logging.
                        Logger.DebugLine(MethodName, "New Target Based On Different Pilot Name", Logger.Blue);
                    
                        //Update All Properties.
                        Update(Event);
                    }
                    else
                    {
                        //Update PilotName Property
                        PilotName = Event.PilotName;
                    }
                }

                //2. Pilots Name (Display Name)
                if (PilotName_Localised != Event.PilotName_Localised)
                {
                    //PilotName_Localised Should Be Initially Set During Scan Stage 1.
                    //If Its Different Then Its A New Target.
                    if (ScanStage != 1)
                    {
                        //Debug Logging.
                        Logger.DebugLine(MethodName, "New Target Based On Different Pilot Name (Localized)", Logger.Blue);

                        //Update All Properties.
                        Update(Event);
                    }
                    else
                    {
                        //Update PilotName_Localised Property
                        PilotName_Localised = Event.PilotName_Localised.Replace("unmanned ", "");
                    }
                }

                //3. Pilots Rank
                if (PilotRank != Event.PilotRank)
                {
                    //PilotRank Should Be Initially Set During Scan Stage 1.
                    //If Its Different Then Its A New Target.
                    if (ScanStage != 1)
                    {
                        //Debug Logging.
                        Logger.DebugLine(MethodName, "New Target Based On Different Pilot Rank", Logger.Blue);

                        //Update All Properties.
                        Update(Event);
                    }
                    else
                    {
                        //Update PilotRank Property
                        PilotRank = Event.PilotRank;
                    }
                }
            }
            #endregion

            #region Scan Stage 2:
            /*
             1. Shield Health
             2. Hull Health
             Notes: Values Not Useable For Target Tracking.
             */

            if (Event.ScanStage >= 2)
            {
                //1. Shield Health
                if (ShieldHealth != Event.ShieldHealth)
                {
                    ShieldHealth = Event.ShieldHealth;
                }

                //2. Hull Health
                if (HullHealth != Event.HullHealth)
                {
                    HullHealth = Event.HullHealth;
                }
            }
            #endregion

            #region Scan Stage 3:
            /*
             1. Faction
             2. Legal Status
             3. Bounty
             4. Subsystem
             5. Subsystem (Localized)
             6. Subsystem Health
             Notes: Faction Is The Only Useable Item For Target Tracking.
             */

            if (Event.ScanStage == 3)
            {
                //1. Faction               
                if (Faction != Event.Faction)
                {
                    //Faction Should Be Initially Set During Scan Stage 3.
                    //If Its Different Then Its A New Target.
                    if (FullScan == true)
                    {
                        //Debug Logging.
                        Logger.DebugLine(MethodName, "New Target Based On Different Faction", Logger.Blue);

                        //Update All Properties.
                        Update(Event);
                    }
                    else
                    {
                        //Update Faction Property
                        Faction = Event.Faction;
                    }
                }

                //2. Legal Status               
                if (LegalStatus != Event.LegalStatus)
                {
                    //Initial Report
                    if (FullScan == false)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, "Intial Legal Status Report: " + LegalStatus, Logger.Blue);

                        //Update Property
                        LegalStatus = Event.LegalStatus;

                        //Audio - Hostile Faction Report
                        //Note: Using "Contains" Allows For WantedEnemy Targets To Trigger Both Wanted & Hostile Faction Reports.
                        HostileFaction(true, Check.Report.TargetEnemy(true, MethodName), (Event.LegalStatus.Contains("Enemy")), Check.Internal.TriggerEvents(true, MethodName));

                        //Audio - Wanted Report                  
                        //Note: Using "Contains" Allows For WantedEnemy Targets To Trigger Both Wanted & Hostile Faction Reports.
                        Wanted(true, Check.Report.TargetWanted(true, MethodName), (Event.LegalStatus.Contains("Wanted")), Check.Internal.TriggerEvents(true, MethodName));
                    }
                    else
                    {
                        //Debug Logging.
                        Logger.DebugLine(MethodName, "New Target Based On Different Legal Status", Logger.Blue);

                        //Update All Properties.
                        Update(Event);
                    }
                }

                //3. Bounty               
                if (Bounty != Event.Bounty)
                {
                    //Inital Report
                    if (FullScan == false)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, "Intial Bounty Report: " + Bounty + " Credits.", Logger.Blue);

                        //Update Property
                        Bounty = Event.Bounty;

                        //Audio - Initial Bounty Report
                        BountyReport(true, Check.Report.TargetWanted(true, MethodName), (Event.LegalStatus.Contains("Wanted")), Check.Internal.TriggerEvents(true, MethodName));
                    }

                    //Bounty Updated
                    else
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, "Intial Bounty Report: " + Bounty + " Credits.", Logger.Blue);
                        
                        //Update Property
                        Bounty = Event.Bounty;

                        //Audio - Updated Bounty Report
                        BountyUpdate(true, Check.Report.TargetWanted(true, MethodName), (Event.LegalStatus.Contains("Wanted")), Check.Internal.TriggerEvents(true, MethodName));
                    }
                }

                //4. Subsystem               
                if (Subsystem.NameED != Event.Subsystem)
                {
                    //Update Properties
                    Subsystem.NameED = Event.Subsystem;
                    Subsystem.Name = Event.Subsystem_Localised;

                    //Process Subsystem
                    Subsystem.Process(Event);
                }

                //5. Subsystem (Localised)
                else if (Subsystem.Name != Event.Subsystem_Localised)
                {
                    //Update Properties
                    Subsystem.Name = Event.Subsystem_Localised;
                    
                    //Process Subsystem
                    Subsystem.Process(Event);
                }

                //6. Subsystem Health
                if (Subsystem.Health != Event.SubsystemHealth)
                {
                    Subsystem.Health = Event.SubsystemHealth;
                }

                //Set FullScan To True So We Can Track ScanStage 3 Changes
                //After The Initial ScanStage 3 Checks/Process.
                FullScan = true;
            }
            #endregion
        }

        /// <summary>
        /// Will Update the Properties for the Target Object to the Event's values.
        /// </summary>
        /// <param name="Event">The Event containing the Updates.</param>
        private void Update(ShipTargeted Event)
        {
            string MethodName = "Target (Update)";

            //Initial Resets
            SubsystemArrayStart = "";
            SubsystemArrayRecord = false;
            Subsystems.Clear();
            DeepScan = false;
            FullScan = false;

            #region Scan Stage 0:
            //Update Targeted Property.
            //This Property Is Updated During The Process Method.

            //Update ScanStage Property
            ScanStage = Event.ScanStage;

            //Update Ship Property.
            Ship = Event.Ship;

            //Update Ship Property.
            Ship_Localised = Event.Ship_Localised;
            #endregion

            #region Scan Stage 1:
            //Update PilotName Property.
            PilotName = Event.PilotName;

            //Update PilotName_Localised Property.
            PilotName_Localised = Event.PilotName_Localised.Replace("unmanned ", "");

            //Update PilotRank Property.
            PilotRank = Event.PilotRank;
            #endregion

            #region Scan Stage 2:
            //Update ShieldHealth Property.
            ShieldHealth = Event.ShieldHealth;

            //Update HullHealth Property.
            HullHealth = Event.HullHealth;
            #endregion

            #region Scan Stage 3:
            //Update Faction Property.
            Faction = Event.Faction;

            //Update LegalStatus Property.
            LegalStatus = Event.LegalStatus;

            //Update Bounty Property.
            Bounty = Event.Bounty;

            //Update Subsystem Property.
            Subsystem.NameED = Event.Subsystem;

            //Update Subsystem_Localised Property.
            Subsystem.Name = Event.Subsystem_Localised;

            //Update SubsystemHealth Property.
            Subsystem.Health = Event.SubsystemHealth;
            #endregion

            //Update Fully Scanned
            if (ScanStage == 3) { FullScan = true; }

            //Logger.DebugLine(MethodName, "Target Locked: " + Targeted, Logger.Yellow);
            //Logger.DebugLine(MethodName, "Scan Stage: " + ScanStage, Logger.Yellow);
            //Logger.DebugLine(MethodName, "ED Ship: " + Ship, Logger.Yellow);
            //Logger.DebugLine(MethodName, "Ship: " + Ship_Localised, Logger.Yellow);
            //Logger.DebugLine(MethodName, "ED Pilot Name: " + PilotName, Logger.Yellow);
            //Logger.DebugLine(MethodName, "PilotName: " + PilotName_Localised, Logger.Yellow);
            //Logger.DebugLine(MethodName, "Pilot Rank: " + PilotRank, Logger.Yellow);
            //Logger.DebugLine(MethodName, "Shield Health: " + ShieldHealth, Logger.Yellow);
            //Logger.DebugLine(MethodName, "Hull Health: " + HullHealth, Logger.Yellow);
            //Logger.DebugLine(MethodName, "Faction: " + Faction, Logger.Yellow);
            //Logger.DebugLine(MethodName, "Legal Status: " + LegalStatus, Logger.Yellow);
            //Logger.DebugLine(MethodName, "Bounty: " + Bounty, Logger.Yellow);
            //Logger.DebugLine(MethodName, "ED Subsystem: " + Subsystem.NameED, Logger.Yellow);
            //Logger.DebugLine(MethodName, "Subsystem: " + Subsystem.Name, Logger.Yellow);
            //Logger.DebugLine(MethodName, "Subsystem Health: " + Subsystem.Health, Logger.Yellow);

            Logger.DebugLine(MethodName, "All Target Properties Updated. Fully Scanned: " + FullScan, Logger.Blue);
        }
        #endregion

        #region Audio
        public void Wanted(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            //Plug In Muted. Write Report To Log.
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Selected Target Is Wanted.", Logger.Yellow); }

            //Text To Speech
            Speech.Speak(""
                .Phrase(GN_Target_Ship.Wanted)
                .Token("[PILOT]", PilotName_Localised)
                .Token("CMDR", "Commander"),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);            
        }

        public void BountyReport(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            //Plug In Muted. Write Report To Log.
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Selected Targets Bounty: " + Bounty, Logger.Yellow); }

            //Text To Speech
            Speech.Speak(""
                .Phrase(GN_Target_Ship.Bounty)
                .Token("[NUM]", Bounty)
                .Token("[PILOT]", PilotName_Localised)
                .Token("CMDR", "Commander"),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void BountyUpdate(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            //Plug In Muted. Write Report To Log.
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Selected Targets Bounty: " + Bounty, Logger.Yellow); }

            //Text To Speech
            Speech.Speak(""
                .Phrase(GN_Target_Ship.Bounty_Update)
                .Token("[NUM]", Bounty)
                .Token("[PILOT]", PilotName_Localised)
                .Token("CMDR", "Commander"),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void HostileFaction(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            //Plug In Muted. Write Report To Log.
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Selected Target Is A Hostile Faction.", Logger.Yellow); }

            //Text To Speech
            Speech.Speak(""
                .Phrase(GN_Target_Ship.Hostile_Faction)
                .Token("[FACTION]", Faction),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion

        public class Subsys
        {
            public string Name;
            public decimal ItemNumber;
            public decimal Health;

            public Subsys()
            {
                Name = "Unknown";
                ItemNumber = -1;
                Health = -1;
            }
        }

        public class Subsystem_Tracking
        {
            //ShipTargeted Properties
            public string Name { get; set; }
            public string NameED { get; set; }
            public decimal Health { get; set; }

            //Custom Properties
            public decimal Current = 0;
            public bool Wait = false;

            public Dictionary<decimal, Subsys> Tracked = new Dictionary<decimal, Subsys>();

            public void Process(ShipTargeted Event)
            {

            }

            public void Clear() { Tracked.Clear(); }

            public decimal Count() { return Tracked.Count(); }
        }
    }
}
