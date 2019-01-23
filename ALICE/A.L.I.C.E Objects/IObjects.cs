using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using ALICE.Properties;
using ALICE_Interface;
using ALICE_Actions;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;
using ALICE_JournalReader;
using ALICE_Core;
using ALICE_Status;
using ALICE_Settings;

namespace ALICE_Objects
{
    /// <summary>
    /// Static Game State Data.
    /// </summary>
    public static class IObjects
    {
        #region Default Values
        public static readonly string String = "None";
        public static readonly decimal Decimal = -1;
        public static readonly bool False = false;
        public static readonly bool True = true;

        public static string StringCheck(this string Value)
        {
            if (Value == "" || Value == null) { Value = IObjects.String; }
            return Value;
        }
        #endregion

        #region Static Objects
        public static Object_Engineers Engineer = new Object_Engineers();
        public static Object_Mothership Mothership = new Object_Mothership();
        public static Object_System SystemCurrent = new Object_System();
        public static Object_System SysetmPrevious = new Object_System();
        public static Object_StellarBody StellarBodyCurrent = new Object_StellarBody();
        public static Object_Facility FacilityCurrent = new Object_Facility();
        public static Object_Facility FacilityPrevious = new Object_Facility();
        #endregion

        #region Old Items (Requires Updates / Conversion)

        #region Game State Objects
        public static Status Status = new Status();
        public static Target TargetShip = new Target();
        public static Target PreviousTarget = new Target();
        
        #endregion

        #region Object Mangement Methods
        public static void New_Ship()
        {
            Mothership = new Object_Mothership();
        }

        //Object Mangement Methods
        #endregion

        #region Event Methods (Logic Table)
        public static void Logic_LoadGame(LoadGame Event)
        {
            string MethodName = "Logic LoadGame";

            ISettings.U_Commander(MethodName, Event.Commander);

            if (Event.Ship.ToLower().Contains("testbuggy") == false && Event.Ship.ToLower().Contains("fighter") == false)
            {
                ShipProp.Update_ShipID(Event.ShipID);
                ShipProp.Update_Ship(Event.ShipID, Event.Ship);
                ShipProp.Update_ShipName(Event.ShipID, Event.ShipName);
                ShipProp.Update_ShipIdent(Event.ShipID, Event.ShipIdent);

                IObjects.Mothership.U_FingerPrint(Event);
                ISettings.U_MothershipFingerPrint(MethodName, Event.Ship, Event.ShipID);
            }

            #region Logic Table
            Call.ResetPanels();
            ISettings.Firegroup.Load();        
            IStatus.Fuel.Update(Event);
            #endregion
        }

        public static void Logic_Loadout(Loadout Event)
        {
            string MethodName = "Logic - Loadout";

            #region Reset Ship Modules (10/16/2018 10:09 PM)
            Data.ShipModules.Clear();

            IObjects.Mothership.FighterHangerTotal = 0;
            IStatus.Fuel.Capacity = 0;

            IObjects.Mothership.Auto_Field_Maintenance_Unit = false;
            IObjects.Mothership.AX_Missile_Rack = false;
            IObjects.Mothership.AX_Multi_Cannon = false;
            IObjects.Mothership.Beam_Laser = false;
            IObjects.Mothership.Bi_Weave_Shield_Generator = false;
            IObjects.Mothership.Burst_Laser = false;
            IObjects.Mothership.Business_Class_Passenger_Cabin = false;
            IObjects.Mothership.Cannon = false;
            IObjects.Mothership.Cargo_Rack = false;
            IObjects.Mothership.Cargo_Scanner = false;
            IObjects.Mothership.Chaff_Launcher = false;
            //IObjects.Mothership.Collector_Limpet_Controller = false;
            IObjects.Mothership.Corrosion_Resistant_Cargo_Rack = false;
            //IObjects.Mothership.Decontamination_Limpet_Controller = false;            
            IObjects.Mothership.Economy_Class_Passenger_Cabin = false;
            //IObjects.Mothership.Electronic_Countermeasure = false;
            IObjects.Mothership.Enhanced_Performance_Thrusters = false;
            IObjects.Mothership.Fighter_Hangar = false;
            IObjects.Mothership.First_Class_Passenger_Cabin = false;
            IObjects.Mothership.Fragment_Cannon = false;
            IObjects.Mothership.Frame_Shift_Drive = false;
            //IObjects.Mothership.Frame_Shift_Drive_Interdictor = false;
            //IObjects.Mothership.Frame_Shift_Wake_Scanner = false;
            IObjects.Mothership.Fuel_Scoop = false;
            IObjects.Mothership.Fuel_Tank = false;
            //IObjects.Mothership.Fuel_Transfer_Limpet_Controller = false;
            //IObjects.Mothership.Hatch_Breaker_Limpet_Controller = false;
            IObjects.Mothership.Heat_Sink_Launcher = false;
            IObjects.Mothership.Hull_Reinforcement_Package = false;
            IObjects.Mothership.Kill_Warrant_Scanner = false;
            IObjects.Mothership.Life_Support = false;
            IObjects.Mothership.Lightweight_Alloy = false;
            IObjects.Mothership.Luxury_Passenger_Cabin = false;
            IObjects.Mothership.Military_Grade_Composite = false;
            IObjects.Mothership.Mine_Launcher = false;
            IObjects.Mothership.Mining_Laser = false;
            IObjects.Mothership.Mirrored_Surface_Composite = false;
            IObjects.Mothership.Missile_Rack = false;
            IObjects.Mothership.Module_Reinforcement_Package = false;
            IObjects.Mothership.Multi_Cannon = false;
            IObjects.Mothership.Planetary_Approach_Suite = false;
            IObjects.Mothership.Planetary_Vehicle_Hangar = false;
            IObjects.Mothership.Plasma_Accelerator = false;
            IObjects.Mothership.Point_Defence = false;
            IObjects.Mothership.Power_Distributor = false;
            IObjects.Mothership.Power_Plant = false;
            //IObjects.Mothership.Prospector_Limpet_Controller = false;
            IObjects.Mothership.Pulse_Laser = false;
            IObjects.Mothership.Rail_Gun = false;
            IObjects.Mothership.Reactive_Surface_Composite = false;
            //IObjects.Mothership.Recon_Limpet_Controller = false;
            IObjects.Mothership.Refinery = false;
            IObjects.Mothership.Reinforced_Alloy = false;
            IObjects.Mothership.Remote_Release_Flak_Launcher = false;
            //IObjects.Mothership.Repair_Limpet_Controller = false;
            //IObjects.Mothership.Research_Limpet_Controller = false;
            IObjects.Mothership.Sensors = false;
            IObjects.Mothership.Shield_Booster = false;
            //IObjects.Mothership.Shield_Cell_Bank = false;
            IObjects.Mothership.Shield_Generator = false;
            IObjects.Mothership.Shock_Mine_Launcher = false;
            //IObjects.Mothership.Shutdown_Field_Neutraliser = false;
            IObjects.Mothership.Standard_Docking_Computer = false;
            IObjects.Mothership.Thrusters = false;
            IObjects.Mothership.Torpedo_Pylon = false;
            //IObjects.Mothership.Xeno_Scanner = false;
            #endregion

            #region Equipment Resets
            IEquipment.ElectronicCountermeasure.Installed = false;
            IEquipment.FSDInterdictor.Installed = false;
            IEquipment.LimpetCollector.Installed = false;
            IEquipment.LimpetDecontamination.Installed = false;
            IEquipment.LimpetFuel.Installed = false;
            IEquipment.LimpetHatchBreaker.Installed = false;
            IEquipment.LimpetProspector.Installed = false;
            IEquipment.LimpetRecon.Installed = false;
            IEquipment.LimpetRepair.Installed = false;
            IEquipment.LimpetResearch.Installed = false;
            IEquipment.PulseWaveScanner.Installed = false;
            IEquipment.ShieldCellBank.Installed = false;
            IEquipment.ShutdownFieldNeutraliser.Installed = false;
            IEquipment.SurfaceScanner.Installed = false;
            IEquipment.WakeScanner.Installed = false;
            IEquipment.XenoScanner.Installed = false;
            #endregion

            #region Update Player Ship Information
            if (Event.Ship.ToLower().Contains("testbuggy") == true || Event.Ship.ToLower().Contains("fighter") == true)
            {
                IPlatform.WriteToInterface("A.L.I.C.E: Loadout Manager: Looks Like The Loadout Event Doesn't Contain A Normal Player Ship (EQ_Fighter or SRV)", Logger.Blue);
                return;
            }

            Mothership = new Object_Mothership();

            if (PlugIn.DebugMode == true)
            { IPlatform.WriteToInterface("A.L.I.C.E: Loadout Manager: New Ship Instance Created", Logger.Blue); }

            ShipProp.Update_ShipID(Event.ShipID);
            ShipProp.Update_Ship(Event.ShipID, Event.Ship);
            ShipProp.Update_ShipName(Event.ShipID, Event.ShipName);
            ShipProp.Update_ShipIdent(Event.ShipID, Event.ShipIdent);

            IObjects.Mothership.U_FingerPrint(Event);
            ISettings.U_MothershipFingerPrint(MethodName, Event.Ship, Event.ShipID);

            foreach (Loadout.Module module in Event.Modules)
            {
                try
                {
                    Object_Mothership.Module Module = new Object_Mothership.Module
                    {
                        Slot = module.Slot,
                        Item = module.Item
                    };
                    if (module.Health != -1)
                    { Module.Health = module.Health; }
                    if (module.Priority != -1)
                    { Module.Priority = module.Priority; }
                    if (module.On == true || module.On == false)
                    { Module.On = module.On; }
                    if (module.Value != -1)
                    { Module.Value = module.Value; }
                    if (module.AmmoInClip != -1)
                    { Module.AmmoInClip = module.AmmoInClip; }
                    if (module.AmmoInHopper != -1)
                    { Module.AmmoInHopper = module.AmmoInHopper; }
                    if (module.Engineering != null)
                    {
                        Module.Engineering.Engineer = module.Engineering.Engineer;
                        Module.Engineering.EngineerID = module.Engineering.EngineerID;
                        Module.Engineering.BlueprintName = module.Engineering.BlueprintName;
                        Module.Engineering.BlueprintID = module.Engineering.BlueprintID;
                        Module.Engineering.Level = module.Engineering.Level;
                        Module.Engineering.Quality = module.Engineering.Quality;
                        if (module.Engineering.ExperimentalEffect != null)
                        { Module.Engineering.ExperimentalEffect = module.Engineering.ExperimentalEffect; }
                        if (module.Engineering.ExperimentalEffect_Localised != null)
                        { Module.Engineering.ExperimentalEffect_Localised = module.Engineering.ExperimentalEffect_Localised; }

                        foreach (Loadout.Module.EngineeringInfo.Modifer modifier in module.Engineering.Modifiers)
                        {
                            Object_Mothership.Module.EngineeringInfo.Modifer Modifier = new Object_Mothership.Module.EngineeringInfo.Modifer
                            {
                                Label = modifier.Label,
                                Value = modifier.Value,
                                OriginalValue = modifier.OriginalValue,
                                LessIsGood = modifier.LessIsGood
                            };
                            Module.Engineering.Modifiers.Add(Modifier);
                        }
                    }
                    Data.GameModule GM = Data.GetGameModule(Module.Item);
                    if (GM == null) { GM = new Data.GameModule(); }
                    if (GM != null)
                    {
                        Module.Name = GM.Name;
                        Module.Rating = GM.Rating;
                        Module.Class = GM.Class;
                        Module.Price = GM.Price;
                        Module.Capacity = GM.Capacity;
                        Module.Ship = GM.Ship;
                        Module.Mount = GM.Mount;
                    }
                    StatusProp.Update_ModuleStatus(Module);
                    Mothership.Modules.Add(Module);
                }
                catch (Exception ex)
                {
                    Logger.ContactDeveloper();
                    Logger.Exception(MethodName, "Exception " + ex);
                    Logger.Exception(MethodName, "Exception Occured When Assigning The Following Slot: " + module.Slot + " | Item: " + module.Item);                    
                }
            }
            #endregion

            if (IObjects.Mothership.Fighter_Hangar == false)
            {
                IObjects.Status.NPC_Crew = false;
                Miscellanous.Default["NPC_Crew"] = IObjects.Status.NPC_Crew;
                Miscellanous.Default.Save();
            }

            Logger.Log(MethodName, "Loaded " + IObjects.Mothership.FingerPrint, Logger.Purple);
            ISettings.Firegroup.Load();
        }

        public static void Logic_SetUserShipName(SetUserShipName Event)
        {
            ShipProp.Update_ShipName(Event.ShipID, Event.UserShipName);
        }

        public static void Logic_ShipTargeted(ShipTargeted Event)
        {
            string MethodName = "Logic - ShipTargeted";

            #region Validation Check: Trigger Events = True
            if (Check.Internal.TriggerEvents(true, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Update Target Ship Information
            if (PlugIn.DebugMode == true)
            { IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: Validating Target Information. Scan Stage: " + Event.ScanStage, "Green"); }

            if (Event.TargetLocked == false)
            {
                if (PlugIn.DebugMode == true)
                { IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: Loss Target Lock", Logger.Blue); }

                //PreviousTarget = TargetShip;
                TargetShip = TargetProp.New_Target();
                TargetShip.TargetLocked = false;
            }

            //if (Event.PilotName == PreviousTarget.PilotName && Event.ScanStage == 3)
            //{
            //    if (PlugIn.DebugMode == true)
            //    { IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: Regained Target Lock On " + Event.PilotName_Localised, Logger.Blue); }
            //}
            if (TargetShip.PilotName != Event.PilotName && TargetShip.PilotName == null)
            {
                TargetProp.Update_TargetValues(Event);

                //if (PlugIn.DebugMode == true)
                //{ IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: New Target - " + TargetShip.PilotName_Localised, Logger.Purple); }
            }
            else if (TargetShip.PilotName != Event.PilotName && TargetShip.PilotName != null)
            {
                //Must be a new Target
                TargetShip = TargetProp.New_Target();
                TargetProp.Update_TargetValues(Event);

                if (PlugIn.DebugMode == true)
                {
                    IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: New Target Based On Different Pilot Name", Logger.Blue);

                    if (Event.PilotName == null)
                    { IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: New Target: (No Pilot Name Due To Scan Level)", Logger.Purple); }
                    else
                    { IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: New Target: " + TargetShip.PilotName_Localised, Logger.Purple); }
                }
            }

            if (TargetShip.Ship != Event.Ship)
            {
                if (TargetShip.Ship != Event.Ship && TargetShip.Ship != "")
                {
                    //Must be a new Target
                    TargetShip = TargetProp.New_Target();
                    TargetProp.Update_TargetValues(Event);

                    //if (PlugIn.DebugMode == true)
                    //{ IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: New Target Based On Different Ship Type", Logger.Blue); }
                }
                else
                {
                    string Ship = Event.Ship;
                    TargetShip.Ship = Ship;
                }
            }

            if (TargetShip.ScanStage != Event.ScanStage)
            {
                if (Event.ScanStage < TargetShip.ScanStage)
                {
                    //New Target
                    TargetShip = TargetProp.New_Target();
                    TargetProp.Update_TargetValues(Event);

                    //if (PlugIn.DebugMode == true)
                    //{ IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: New Target Based On Lower Scan Level", Logger.Blue); }
                }
                else
                {
                    decimal ScanStage = Event.ScanStage;
                    TargetShip.ScanStage = ScanStage;
                    //Audio Triggers for each scan step.
                }

                //if (PlugIn.DebugMode == true )
                //{ IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: Scan Stage: " + TargetShip.ScanStage, "Green"); }

            }

            if (TargetShip.PilotRank != Event.PilotRank)
            {
                if (TargetShip.PilotRank != Event.PilotRank && TargetShip.PilotRank != "")
                {
                    //New Target
                    TargetShip = TargetProp.New_Target();
                    TargetProp.Update_TargetValues(Event);

                    //if (PlugIn.DebugMode == true)
                    //{ IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: New Target Based On Different Pilot Rank", Logger.Blue); }
                }
                else
                {
                    string PilotRank = Event.PilotRank;
                    TargetShip.PilotRank = PilotRank;
                }
            }

            if (TargetShip.ShieldHealth != Event.ShieldHealth)
            {
                decimal ShieldHealth = Event.ShieldHealth;
                TargetShip.ShieldHealth = ShieldHealth;
            }

            if (TargetShip.HullHealth != Event.HullHealth)
            {
                decimal HullHealth = Event.HullHealth;
                TargetShip.HullHealth = HullHealth;
            }

            if (TargetShip.Faction != Event.Faction)
            {
                if (TargetShip.Faction != Event.Faction && TargetShip.Faction != null)
                {
                    //New Target
                    TargetShip = TargetProp.New_Target();
                    TargetProp.Update_TargetValues(Event);

                    //if (PlugIn.DebugMode == true)
                    //{ IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: New Target Based On Different Faction", Logger.Blue); }
                }
                else
                {
                    string Faction = Event.Faction;
                    TargetShip.Faction = Faction;
                }
            }

            if (TargetShip.Subsystem != Event.Subsystem)
            {
                //if (PlugIn.DebugMode == true)
                //{ IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: Targeted Subsystem - " + Event.Subsystem_Localised, "Green"); }

                string SubsystemName = Event.Subsystem;
                TargetShip.Subsystem = SubsystemName;

                string Subsystem_LocalisedName = Event.Subsystem_Localised;
                TargetShip.Subsystem_Localised = Subsystem_LocalisedName;

                TargetProp.Process_Subsytem(Event);
            }
            else if (TargetShip.Subsystem == Event.Subsystem && TargetShip.DeepScan == false && Event.Subsystem != null)
            {
                //if (PlugIn.DebugMode == true)
                //{ IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: Targeted Subsystem - " + Event.Subsystem_Localised, "Green"); }

                TargetProp.Process_Subsytem(Event);
            }

            if (TargetShip.LegalStatus != Event.LegalStatus)
            {
                string LegalStatus = Event.LegalStatus;
                TargetShip.LegalStatus = LegalStatus;

                //if (PlugIn.DebugMode == true)
                //{ IPlatform.WriteToInterface("A.L.I.C.E: Target Validation: Legal Status: " + TargetShip.LegalStatus, "Green"); }

                #region Audio: Ship Targeted (Wanted) || Ship Targeted (Enemy)
                if (PlugIn.MasterAudio == true && Check.Internal.TriggerEvents(true, MethodName) == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(EVT_ShipTargeted.Wanted).Replace("[NUM]", Event.Bounty.ToString())
                            .Replace("[PILOT]", Event.PilotName_Localised),
                            Check.Report.TargetWanted(true, MethodName),
                            (Event.LegalStatus == "Wanted")
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(EVT_ShipTargeted.Enemy_Faction)
                            .Replace("[FACTION]", Event.Faction),
                            Check.Report.TargetEnemy(true, MethodName),
                            (Event.LegalStatus == "Enemy")
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                #endregion
            }

            #endregion

            if (PlugIn.DebugMode == true)
            {
                TargetProp.WTL_TargetShipInfo();
            }

            if (Event.TargetLocked == true)
            {
                Assisted.Targeting.Wait_Targeted = false;
                //Targeting.Scan_TargetedWait = false;
            }
        }
               
        //End Event Update Mehtods
        #endregion

        #region Propery Methods
     
        public static class ShipProp
        {
            public static void Update_ShipID(decimal ShipID)
            {
                Mothership.ShipID = ShipID;
            }

            public static void Update_Ship(decimal ShipID, string ShipType)
            {
                if (ShipID == Mothership.ShipID)
                {
                    Mothership.Ship = ShipType;
                    return;
                }
                Update_Error_CurrentShip();
            }

            public static void Update_ShipName(decimal ShipID, string ShipName)
            {
                if (ShipID == Mothership.ShipID)
                {
                    Mothership.ShipName = ShipName;
                    return;
                }
                Update_Error_CurrentShip();
            }

            public static void Update_ShipIdent(decimal ShipID, string ShipIdent)
            {
                if (ShipID == Mothership.ShipID)
                {
                    Mothership.ShipIdent = ShipIdent;
                    return;
                }
                Update_Error_CurrentShip();
            }

            public static void Update_HullValue(decimal ShipID, decimal HullValue)
            {
                if (ShipID == Mothership.ShipID)
                {
                    Mothership.HullValue = HullValue;
                    return;
                }
                Update_Error_CurrentShip();
            }

            public static void Update_ModulesValue(decimal ShipID, decimal ModulesValue = -1, bool Calculate = false)
            {
                if (Calculate == false)
                {
                    if (ShipID == Mothership.ShipID)
                    {
                        if (ModulesValue != -1)
                        {
                            Mothership.ModulesValue = ModulesValue;
                            return;
                        }
                    }
                }
                else if (Calculate == true)
                {
                    //On Module Swaps Recalculate Value.
                    return;
                }
                Update_Error_CurrentShip();
            }

            public static void Update_Rebuy(decimal ShipID, decimal Rebuy, bool Calculate = false)
            {
                if (Calculate == false)
                {
                    if (ShipID == Mothership.ShipID)
                    {
                        Mothership.Rebuy = Rebuy;
                        return;
                    }
                }
                else if (Calculate == true)
                {
                    Mothership.Rebuy = Mothership.HullValue + Mothership.ModulesValue;
                    return;
                }
                Update_Error_CurrentShip();
            }

            public static void Update_Module(decimal ShipID, Object_Mothership.Module Module)
            {
                bool NewModule = true;
                int ListNumber = 0;

                foreach (Object_Mothership.Module module in Mothership.Modules)
                {
                    if (Module.Slot == module.Slot)
                    {
                        NewModule = false;
                        Mothership.Modules[ListNumber] = Module;
                    }
                    ListNumber++;
                }

                if (NewModule == true)
                {
                    Mothership.Modules.Add(Module);
                }
            }
            
            public static void Update_Error_CurrentShip()
            {
                IPlatform.WriteToInterface("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", "Red");
                Logger.ContactDeveloper();
                IPlatform.WriteToInterface("A.L.I.C.E: Event Information: Event = " + JournalReader.EventName + " | Time Stamp = " + JournalReader.EventTimeStamp, "Red");
                IPlatform.WriteToInterface("A.L.I.C.E: Object Error Occured (Current Ship) - Event Value Is Not Valid For The Current Ship", "Red");
                IPlatform.WriteToInterface("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", "Red");
            }

            public static void WTL_ShipsLoadout()
            {
                IPlatform.WriteToInterface(" ", Logger.Purple);
                IPlatform.WriteToInterface("--------------------------------------------------------------------------", Logger.Purple);

                foreach (Object_Mothership.Module module in Mothership.Modules)
                {
                    IPlatform.WriteToInterface("A.L.I.C.E: Slot: " + module.Slot + " || " + module.Item, "Green");
                }

                IPlatform.WriteToInterface("A.L.I.C.E: Ship Finger Print: " + IObjects.Mothership.FingerPrint, Logger.Purple);
                IPlatform.WriteToInterface("A.L.I.C.E: SHIP LOADOUT REPORT", Logger.Purple);
                IPlatform.WriteToInterface("--------------------------------------------------------------------------", Logger.Purple);
                IPlatform.WriteToInterface(" ", Logger.Purple);

            }
        }

        public static class TargetProp
        {
            public static readonly List<string> SingleUnitModules = new List<string>(new string[]
            {
                "Manifest Scanner", "Power Plant", "FSD", "Power Distributor", "Shield Generator", "Cargo Hatch", "Life Support", "FSD Interdictor"
            });

            public static Target New_Target()
            {
                Target newTarget = new Target();
                return newTarget;
            }

            public static void Update_TargetValues(ShipTargeted Event)
            {
                string Ship = Event.Ship;
                decimal ScanStage = Event.ScanStage;
                string PilotName = Event.PilotName;

                string PilotName_Localised = null;
                if (Event.PilotName_Localised != null)
                {
                    PilotName_Localised = Event.PilotName_Localised.Replace("unmanned ", "");
                }

                string PilotRank = Event.PilotRank;
                decimal ShieldHealth = Event.ShieldHealth;
                decimal HullHealth = Event.HullHealth;
                string Faction = Event.Faction;
                string Subsystem = Event.Subsystem;
                string LegalStatus = Event.LegalStatus;
                decimal SubsystemCount = 0;
                decimal CurrentSubsystem = 0;
                decimal Bounty = Event.Bounty;
                bool TargetLock = Event.TargetLocked;

                TargetShip.Ship = Ship;
                TargetShip.ScanStage = ScanStage;
                TargetShip.PilotName = PilotName;
                TargetShip.PilotName_Localised = PilotName_Localised;
                TargetShip.PilotRank = PilotRank;
                TargetShip.ShieldHealth = ShieldHealth;
                TargetShip.HullHealth = HullHealth;
                TargetShip.Faction = Faction;
                TargetShip.Subsystem = Subsystem;
                TargetShip.LegalStatus = LegalStatus;
                TargetShip.SubsystemCount = SubsystemCount;
                TargetShip.CurrentSubsystem = CurrentSubsystem;
                TargetShip.Bounty = Bounty;
                TargetShip.TargetLocked = TargetLock;

                TargetShip.SubsystemArrayStart = "";
                TargetShip.SubsystemArrayRecord = false;
                TargetShip.Subsystems.Clear();
                TargetShip.DeepScan = false;
            }

            public static void Process_Subsytem(ShipTargeted Event)
            {
                if (TargetShip.DeepScan == true)
                {
                    if (SingleUnitModules.Contains(Event.Subsystem_Localised) == true)
                    {
                        //Lets help keep things aligned
                        TargetShip.CurrentSubsystem = Check_Subsystem(Event.Subsystem_Localised);
                    }
                    return;
                }
                else if (TargetShip.DeepScan == false)
                {
                    if (TargetShip.SubsystemArrayRecord == false)
                    {
                        return;
                    }
                    else if (TargetShip.SubsystemArrayRecord == true)
                    {
                        // Check if Array is Empty
                        if (TargetShip.SubsystemArrayStart == "")
                        {
                            //Must be the first Subsystems

                            //Add Check to see if the module is a valid single unit starting module
                            if (SingleUnitModules.Contains(Event.Subsystem_Localised) == true)
                            {
                                TargetShip.SubsystemArrayStart = Event.Subsystem_Localised;
                            }
                            else
                            {
                                //Wait till we find a good starting point.
                                return;
                            }
                        }
                        else if (Event.Subsystem_Localised == TargetShip.SubsystemArrayStart)
                        {
                            //We've recorded all subsystems
                            TargetShip.CurrentSubsystem = 0;
                            TargetShip.DeepScan = true;
                            return;
                        }

                        //Check if it exist in the Array.
                        decimal Position = Check_Subsystem(Event.Subsystem_Localised);
                        decimal SubsystemNumber = TargetShip.SubsystemCount;

                        //Create new entry
                        TargetShip.Subsystems[SubsystemNumber] = new Target.Subsys
                        {
                            Name = Event.Subsystem_Localised
                        };

                        if (Position == -1)
                        {
                            //Doesn't Exist in the Array
                            TargetShip.Subsystems[SubsystemNumber].ItemNumber = 0;
                        }
                        else if (Position != -1)
                        {
                            //Does Exist in the Array, lets add another and increase the Item number by 1.
                            TargetShip.Subsystems[SubsystemNumber].ItemNumber = TargetShip.Subsystems[Position].ItemNumber + 1;
                        }
                    }

                    TargetShip.SubsystemCount++;
                }
            }

            public static decimal Check_Subsystem(string Subsystem)
            {
                decimal Position = -1;
                Target.Subsys SubsystemInfo = new Target.Subsys();

                foreach (KeyValuePair<decimal, Target.Subsys> SubsystemItem in IObjects.TargetShip.Subsystems)
                {
                    SubsystemInfo = SubsystemItem.Value;

                    if (SubsystemInfo.Name.Contains(Subsystem) == true)
                    {
                        Position = SubsystemItem.Key;
                        //return Position;
                    }
                }

                return Position;
            }

            public static void WTL_Subsystems()
            {
                IPlatform.WriteToInterface(" ", Logger.Purple);
                IPlatform.WriteToInterface("=====================================================", Logger.Purple);

                foreach (KeyValuePair<decimal, Target.Subsys> SS in TargetShip.Subsystems)
                {
                    IPlatform.WriteToInterface("A.L.I.C.E: Module Number: " + SS.Key + " | Subsystem Name: " + SS.Value.Name, "Green");
                }

                IPlatform.WriteToInterface("A.L.I.C.E: Complete Subsystem Report:", Logger.Purple);
                IPlatform.WriteToInterface("=====================================================", Logger.Purple);
                IPlatform.WriteToInterface(" ", Logger.Purple);
            }

            public static void WTL_TargetShipInfo()
            {
                IPlatform.WriteToInterface(" ", Logger.Purple);
                //IPlatform.WriteToInterface("=====================================================", Logger.Purple);

                //IPlatform.WriteToInterface("A.L.I.C.E: Bounty: " + TargetShip.Bounty, "Green");
                IPlatform.WriteToInterface("A.L.I.C.E: Legal Status: " + TargetShip.LegalStatus, "Green");
                IPlatform.WriteToInterface("A.L.I.C.E: Subsystem: " + TargetShip.Subsystem_Localised, "Green");
                IPlatform.WriteToInterface("A.L.I.C.E: Faction: " + TargetShip.Faction, "Green");
                //IPlatform.WriteToInterface("A.L.I.C.E: Hull: " + TargetShip.HullHealth, "Green");
                //IPlatform.WriteToInterface("A.L.I.C.E: Shields: " + TargetShip.ShieldHealth, "Green");
                IPlatform.WriteToInterface("A.L.I.C.E: Pilot Rank: " + TargetShip.PilotRank, "Green");
                IPlatform.WriteToInterface("A.L.I.C.E: Pilot Name (Normalized): " + TargetShip.PilotName_Localised, "Green");
                //IPlatform.WriteToInterface("A.L.I.C.E: Pilot Name: " + TargetShip.PilotName, "Green");
                IPlatform.WriteToInterface("A.L.I.C.E: Ship (Normalized): " + TargetShip.Ship_Localised, "Green");
                //IPlatform.WriteToInterface("A.L.I.C.E: Ship: " + TargetShip.Ship , "Green");

                //IPlatform.WriteToInterface("A.L.I.C.E: Target Locked: " + TargetShip.TargetLocked, "Green");
                IPlatform.WriteToInterface("A.L.I.C.E: Scan Level: " + TargetShip.ScanStage, "Green");

                //IPlatform.WriteToInterface("A.L.I.C.E: Target Report:", Logger.Purple);
                //IPlatform.WriteToInterface("=====================================================", Logger.Purple);
                IPlatform.WriteToInterface(" ", Logger.Purple);
            }
        }

        public static class StatusProp
        {
            public static string GenerateModuleName(Object_Mothership.Module Module)
            {
                string ModuleName = "Module Detected: " + Module.Class + Module.Rating + " " + Module.Name;
                if (Module.Mount != null)
                {
                    ModuleName = ModuleName + " (" + Module.Mount + ")";
                }
                return ModuleName;
            }

            public static void Update_ModuleStatus(Object_Mothership.Module Module)
            {
                string MethodName = "Module Detection";

                #region Module Detection / Toggles (12/21/2018 5:23 PM)

                IEnums.ModuleGroup M = Utilities.ToEnum<IEnums.ModuleGroup>(Module.Name.Replace(" ", "_").Replace("-", "_"));

                switch (M)
                {
                    //Items Installed By Default
                    //Composite Scanner
                    //Full Spectrum Scanner / Discovery Scanner

                    case IEnums.ModuleGroup.Auto_Field_Maintenance_Unit:
                        IObjects.Mothership.Auto_Field_Maintenance_Unit = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.AX_Missile_Rack:
                        IObjects.Mothership.AX_Missile_Rack = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.AX_Multi_Cannon:
                        IObjects.Mothership.AX_Multi_Cannon = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Beam_Laser:
                        IObjects.Mothership.Beam_Laser = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Bi_Weave_Shield_Generator:
                        IObjects.Mothership.Bi_Weave_Shield_Generator = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Burst_Laser:
                        IObjects.Mothership.Burst_Laser = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Business_Class_Passenger_Cabin:
                        IObjects.Mothership.Business_Class_Passenger_Cabin = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Cannon:
                        IObjects.Mothership.Cannon = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Cargo_Rack:
                        IObjects.Mothership.Cargo_Rack = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Cargo_Scanner:
                        IObjects.Mothership.Cargo_Scanner = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Chaff_Launcher:
                        IObjects.Mothership.Chaff_Launcher = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Collector_Limpet_Controller:
                        IEquipment.LimpetCollector.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Corrosion_Resistant_Cargo_Rack:
                        IObjects.Mothership.Corrosion_Resistant_Cargo_Rack = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Decontamination_Limpet_Controller:
                        IEquipment.LimpetDecontamination.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Detailed_Surface_Scanner:
                        IEquipment.SurfaceScanner.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Economy_Class_Passenger_Cabin:
                        IObjects.Mothership.Economy_Class_Passenger_Cabin = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Electronic_Countermeasure:
                        IEquipment.ElectronicCountermeasure.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Enhanced_Performance_Thrusters:
                        IObjects.Mothership.Enhanced_Performance_Thrusters = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Fighter_Hangar:
                        IObjects.Mothership.Fighter_Hangar = true;

                        if (Module.Class + Module.Rating == "5D")
                        {
                            IObjects.Mothership.FighterHangerTotal = 1;
                            IObjects.Mothership.FighterPerHanger = 6;
                        }
                        else if (Module.Class + Module.Rating == "6D")
                        {
                            IObjects.Mothership.FighterHangerTotal = 2;
                            IObjects.Mothership.FighterPerHanger = 8;
                        }
                        else if (Module.Class + Module.Rating == "7D")
                        {
                            IObjects.Mothership.FighterHangerTotal = 2;
                            IObjects.Mothership.FighterPerHanger = 15;
                        }

                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.First_Class_Passenger_Cabin:
                        IObjects.Mothership.First_Class_Passenger_Cabin = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Fragment_Cannon:
                        IObjects.Mothership.Fragment_Cannon = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Frame_Shift_Drive:
                        IObjects.Mothership.Frame_Shift_Drive = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Frame_Shift_Drive_Interdictor:
                        IEquipment.FSDInterdictor.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Frame_Shift_Wake_Scanner:
                        IEquipment.WakeScanner.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Fuel_Scoop:
                        IObjects.Mothership.Fuel_Scoop = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Fuel_Tank:
                        IObjects.Mothership.Fuel_Tank = true;
                        IStatus.Fuel.Capacity = IStatus.Fuel.Capacity + Convert.ToDecimal(Module.Capacity);
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Fuel_Transfer_Limpet_Controller:
                        IEquipment.LimpetFuel.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Hatch_Breaker_Limpet_Controller:
                        IEquipment.LimpetHatchBreaker.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Heat_Sink_Launcher:
                        IObjects.Mothership.Heat_Sink_Launcher = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Hull_Reinforcement_Package:
                        IObjects.Mothership.Hull_Reinforcement_Package = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Kill_Warrant_Scanner:
                        IObjects.Mothership.Kill_Warrant_Scanner = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Life_Support:
                        IObjects.Mothership.Life_Support = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Lightweight_Alloy:
                        IObjects.Mothership.Lightweight_Alloy = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Luxury_Passenger_Cabin:
                        IObjects.Mothership.Luxury_Passenger_Cabin = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Military_Grade_Composite:
                        IObjects.Mothership.Military_Grade_Composite = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Mine_Launcher:
                        IObjects.Mothership.Mine_Launcher = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Mining_Laser:
                        IObjects.Mothership.Mining_Laser = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Mirrored_Surface_Composite:
                        IObjects.Mothership.Mirrored_Surface_Composite = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Missile_Rack:
                        IObjects.Mothership.Missile_Rack = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Module_Reinforcement_Package:
                        IObjects.Mothership.Module_Reinforcement_Package = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Multi_Cannon:
                        IObjects.Mothership.Multi_Cannon = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Planetary_Approach_Suite:
                        IObjects.Mothership.Planetary_Approach_Suite = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Planetary_Vehicle_Hangar:
                        IObjects.Mothership.Planetary_Vehicle_Hangar = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Plasma_Accelerator:
                        IObjects.Mothership.Plasma_Accelerator = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Point_Defence:
                        IObjects.Mothership.Point_Defence = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Power_Distributor:
                        IObjects.Mothership.Power_Distributor = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Power_Plant:
                        IObjects.Mothership.Power_Plant = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Prospector_Limpet_Controller:
                        IEquipment.LimpetProspector.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Pulse_Laser:
                        IObjects.Mothership.Pulse_Laser = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Rail_Gun:
                        IObjects.Mothership.Rail_Gun = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Reactive_Surface_Composite:
                        IObjects.Mothership.Reactive_Surface_Composite = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Recon_Limpet_Controller:
                        IEquipment.LimpetRecon.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Refinery:
                        IObjects.Mothership.Refinery = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Reinforced_Alloy:
                        IObjects.Mothership.Reinforced_Alloy = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Remote_Release_Flak_Launcher:
                        IObjects.Mothership.Remote_Release_Flak_Launcher = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Repair_Limpet_Controller:
                        IEquipment.LimpetRepair.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Research_Limpet_Controller:
                        IEquipment.LimpetResearch.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Sensors:
                        IObjects.Mothership.Sensors = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Shield_Booster:
                        IObjects.Mothership.Shield_Booster = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Shield_Cell_Bank:
                        IEquipment.ShieldCellBank.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Shield_Generator:
                        IObjects.Mothership.Shield_Generator = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Shock_Mine_Launcher:
                        IObjects.Mothership.Shock_Mine_Launcher = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;
                    
                    //Customized
                    case IEnums.ModuleGroup.Shutdown_Field_Neutraliser:
                        IEquipment.ShutdownFieldNeutraliser.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Standard_Docking_Computer:
                        IObjects.Mothership.Standard_Docking_Computer = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Thrusters:
                        IObjects.Mothership.Thrusters = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    case IEnums.ModuleGroup.Torpedo_Pylon:
                        IObjects.Mothership.Torpedo_Pylon = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Xeno_Scanner:
                        IEquipment.XenoScanner.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                        break;

                    default:
                        if (Data.ModulesIgnoreCheck(Module.Item) == false)
                        {
                            Logger.DevUpdateLog(MethodName, "New Module Group Detected: " + Module.Item, Logger.Red, true);
                        }                        
                        break;

                }
                #endregion

                #region Module Detection / Toggles (10/16/2018 10:09 PM)

                ////if (Module.Name == "Advanced Discovery Scanner")
                ////{
                ////    IObjects.Mothership.Discovery_Scanner = true;

                ////    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                ////}
                ////else 
                //if (Module.Name == "Auto Field-Maintenance Unit")
                //{
                //    IObjects.Mothership.Auto_Field_Maintenance_Unit = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "AX Missile Rack")
                //{
                //    IObjects.Mothership.AX_Missile_Rack = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "AX Multi-Cannon")
                //{
                //    IObjects.Mothership.AX_Multi_Cannon = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                ////else if (Module.Name == "Basic Discovery Scanner")
                ////{
                ////    IObjects.Mothership.Discovery_Scanner = true;

                ////    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                ////}
                //else if (Module.Name == "Beam Laser")
                //{
                //    IObjects.Mothership.Beam_Laser = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Bi-Weave Shield Generator")
                //{
                //    IObjects.Mothership.Bi_Weave_Shield_Generator = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Burst Laser")
                //{
                //    IObjects.Mothership.Burst_Laser = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Business Class Passenger Cabin")
                //{
                //    IObjects.Mothership.Business_Class_Passenger_Cabin = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Cannon")
                //{
                //    IObjects.Mothership.Cannon = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Cargo Rack")
                //{
                //    IObjects.Mothership.Cargo_Rack = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Cargo Scanner")
                //{
                //    IObjects.Mothership.Cargo_Scanner = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Chaff Launcher")
                //{
                //    IObjects.Mothership.Chaff_Launcher = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Collector Limpet Controller")
                //{
                //    IObjects.Mothership.Collector_Limpet_Controller = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Corrosion Resistant Cargo Rack")
                //{
                //    IObjects.Mothership.Corrosion_Resistant_Cargo_Rack = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Decontamination Limpet Controller")
                //{
                //    IObjects.Mothership.Decontamination_Limpet_Controller = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Detailed Surface Scanner")
                //{
                //    IObjects.Mothership.Detailed_Surface_Scanner = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Economy Class Passenger Cabin")
                //{
                //    IObjects.Mothership.Economy_Class_Passenger_Cabin = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Electronic Countermeasure")
                //{
                //    IObjects.Mothership.Electronic_Countermeasure = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Enhanced Performance Thrusters")
                //{
                //    IObjects.Mothership.Enhanced_Performance_Thrusters = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Fighter Hangar")
                //{
                //    IObjects.Mothership.Fighter_Hangar = true;

                //    if (Module.Class + Module.Rating == "5D")
                //    {
                //        IObjects.Mothership.FighterHangerTotal = 1;
                //        IObjects.Mothership.FighterPerHanger = 6;
                //    }
                //    else if (Module.Class + Module.Rating == "6D")
                //    {
                //        IObjects.Mothership.FighterHangerTotal = 2;
                //        IObjects.Mothership.FighterPerHanger = 8;
                //    }
                //    else if (Module.Class + Module.Rating == "7D")
                //    {
                //        IObjects.Mothership.FighterHangerTotal = 2;
                //        IObjects.Mothership.FighterPerHanger = 15;
                //    }

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "First Class Passenger Cabin")
                //{
                //    IObjects.Mothership.First_Class_Passenger_Cabin = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Fragment Cannon")
                //{
                //    IObjects.Mothership.Fragment_Cannon = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Frame Shift Drive")
                //{
                //    IObjects.Mothership.Frame_Shift_Drive = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Frame Shift Drive Interdictor")
                //{
                //    IObjects.Mothership.Frame_Shift_Drive_Interdictor = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Frame Shift Wake Scanner")
                //{
                //    IObjects.Mothership.Frame_Shift_Wake_Scanner = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Fuel Scoop")
                //{
                //    IObjects.Mothership.Fuel_Scoop = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Fuel Tank")
                //{
                //    IObjects.Mothership.Fuel_Tank = true;

                //    Status.Fuel.Capacity = Status.Fuel.Capacity + Convert.ToDecimal(Module.Capacity);

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Fuel Transfer Limpet Controller")
                //{
                //    IObjects.Mothership.Fuel_Transfer_Limpet_Controller = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Hatch Breaker Limpet Controller")
                //{
                //    IObjects.Mothership.Hatch_Breaker_Limpet_Controller = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Heat Sink Launcher")
                //{
                //    IObjects.Mothership.Heat_Sink_Launcher = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Hull Reinforcement Package")
                //{
                //    IObjects.Mothership.Hull_Reinforcement_Package = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                ////else if (Module.Name == "Intermediate Discovery Scanner")
                ////{
                ////    IObjects.Mothership.Discovery_Scanner = true;

                ////    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                ////}
                //else if (Module.Name == "Kill Warrant Scanner")
                //{
                //    IObjects.Mothership.Kill_Warrant_Scanner = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Life Support")
                //{
                //    IObjects.Mothership.Life_Support = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Lightweight Alloy")
                //{
                //    IObjects.Mothership.Lightweight_Alloy = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Luxury Passenger Cabin")
                //{
                //    IObjects.Mothership.Luxury_Passenger_Cabin = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Military Grade Composite")
                //{
                //    IObjects.Mothership.Military_Grade_Composite = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Mine Launcher")
                //{
                //    IObjects.Mothership.Mine_Launcher = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Mining Laser")
                //{
                //    IObjects.Mothership.Mining_Laser = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Mirrored Surface Composite")
                //{
                //    IObjects.Mothership.Mirrored_Surface_Composite = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Missile Rack")
                //{
                //    IObjects.Mothership.Missile_Rack = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Module Reinforcement Package")
                //{
                //    IObjects.Mothership.Module_Reinforcement_Package = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Multi-Cannon")
                //{
                //    IObjects.Mothership.Multi_Cannon = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Planetary Approach Suite")
                //{
                //    IObjects.Mothership.Planetary_Approach_Suite = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Planetary Vehicle Hangar")
                //{
                //    IObjects.Mothership.Planetary_Vehicle_Hangar = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Plasma Accelerator")
                //{
                //    IObjects.Mothership.Plasma_Accelerator = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Point Defence")
                //{
                //    IObjects.Mothership.Point_Defence = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Power Distributor")
                //{
                //    IObjects.Mothership.Power_Distributor = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Power Plant")
                //{
                //    IObjects.Mothership.Power_Plant = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Prospector Limpet Controller")
                //{
                //    IObjects.Mothership.Prospector_Limpet_Controller = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Pulse Laser")
                //{
                //    IObjects.Mothership.Pulse_Laser = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Rail Gun")
                //{
                //    IObjects.Mothership.Rail_Gun = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Reactive Surface Composite")
                //{
                //    IObjects.Mothership.Reactive_Surface_Composite = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Recon Limpet Controller")
                //{
                //    IObjects.Mothership.Recon_Limpet_Controller = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Refinery")
                //{
                //    IObjects.Mothership.Refinery = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Reinforced Alloy")
                //{
                //    IObjects.Mothership.Reinforced_Alloy = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Remote Release Flak Launcher")
                //{
                //    IObjects.Mothership.Remote_Release_Flak_Launcher = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Repair Limpet Controller")
                //{
                //    IObjects.Mothership.Repair_Limpet_Controller = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Research Limpet Controller")
                //{
                //    IObjects.Mothership.Research_Limpet_Controller = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Sensors")
                //{
                //    IObjects.Mothership.Sensors = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Shield Booster")
                //{
                //    IObjects.Mothership.Shield_Booster = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Shield Cell Bank")
                //{
                //    IObjects.Mothership.Shield_Cell_Bank = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Shield Generator")
                //{
                //    IObjects.Mothership.Shield_Generator = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Shock Mine Launcher")
                //{
                //    IObjects.Mothership.Shock_Mine_Launcher = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Shutdown Field Neutraliser")
                //{
                //    IObjects.Mothership.Shutdown_Field_Neutraliser = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Standard Docking Computer")
                //{
                //    IObjects.Mothership.Standard_Docking_Computer = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Thrusters")
                //{
                //    IObjects.Mothership.Thrusters = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Torpedo Pylon")
                //{
                //    IObjects.Mothership.Torpedo_Pylon = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}
                //else if (Module.Name == "Xeno Scanner")
                //{
                //    IObjects.Mothership.Xeno_Scanner = true;

                //    Data.ShipModules.Add("A.L.I.C.E: " + GenerateModuleName(Module));
                //}

                #endregion
            }
        }

        //End Properties Methods
        #endregion
    }

    #region Objects
    public class ObjectCore
    {
        public DateTime TimeStamp { get; set; }
    }

    public class Status
    {
        #region Status.Json Properties
        public IEnums.Vehicles Vehicle = IEnums.Vehicles.Mothership;

        //public decimal FireGroup = 1;
        public decimal GUI_Focus = 0;
        public decimal Latitude = -1;
        public decimal Longitude = -1;
        public decimal Heading = -1;
        public decimal Altitude = -1;
        //public Status_Fuel Fuel = new Status_Fuel();
        public decimal CargoMass = -1;

        public bool NightVision = false;
        public bool AnalysisMode = false;
        public bool Interdiction = false;
        public bool InDanger = false;
        public bool HasLatLong = false;
        public bool Overheating = false;
        public bool LowFuel = false;
        //public bool FSD_Cooldown = false;
        //public bool FSD_Charging = false;
        public bool Masslocked = false;
        public bool SRV_DriveAssist = false;
        public bool SRV_NearMothership = false;
        public bool SRV_Turret = false;
        public bool SRV_Handbreak = false;
        public bool FuelScooping = false;
        public bool SilentRunning = false;
        public bool CargoScoop = false;
        public bool Lights = false;
        public bool InWing = false;
        public bool Hardpoints = false;
        public bool FlightAssist = false;
        public bool Supercruise = false;
        public bool Shields = false;
        public bool LandingGear = false;
        public bool Touchdown = false;
        public bool Docked = false;
        #endregion

        #region Event Based Properties
        //StartJump Event
        public bool Hyperspace = false;

        //Launch, Destroyed & Docked Fighter Event
        public bool FighterDeployed = false;

        //Music Event
        public bool FSSMode = false;
        #endregion

        #region Equipment
        public bool WeaponSafety = false;
        #endregion

        #region Miscellaneous
        public bool NPC_Crew = Convert.ToBoolean(Miscellanous.Default["NPC_Crew"]);
        public string FighterStatus = "Ready";
        public bool LandingPreps = false;
        #endregion
    }

    public class Target
    {
        #region Event Properties
        public bool TargetLocked { get; set; }
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
        public string Subsystem { get; set; }
        public string Subsystem_Localised { get; set; }
        public decimal SubsystemHealth { get; set; }
        #endregion

        #region Custom Properties
        public decimal SubsystemCount = 0;
        public decimal CurrentSubsystem = 0;

        //Subsystem Recording
        public Dictionary<decimal, Subsys> Subsystems { get; set; }
        public string SubsystemArrayStart = "";
        public bool SubsystemArrayRecord = false;
        public bool DeepScan = false;
        #endregion

        public Target()
        {
            TargetLocked = true;
            ScanStage = 0;

            SubsystemCount = 0;
            CurrentSubsystem = 0;

            Subsystems = new Dictionary<decimal, Subsys>();
            SubsystemArrayStart = "";
            SubsystemArrayRecord = false;
            DeepScan = false;
        }

        public class Subsys
        {
            public string Name;
            public decimal ItemNumber;
            public decimal Health;

            public Subsys()
            {
                Name = "";
                ItemNumber = 0;
                Health = 100;
            }
        }
    }
    #endregion

    //End Region: Old Items (Requires Updates / Conversion)
    #endregion

    public class Object_Utilities : Object_Base
    {
        public void SaveValues<T>(object Settings, string FileName, string FilePath = null)
        {
            if (FilePath == null) { FilePath = Paths.ALICE_Settings; }

            using (FileStream FS = new FileStream(FilePath + FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter file = new StreamWriter(FS))
                {
                    var Line = JsonConvert.SerializeObject((T)Settings);
                    file.WriteLine(Line);
                }
            }
        }

        public object LoadValues<T>(string FileName, string FilePath = null)
        {
            T Temp = default(T);
            if (FilePath == null) { FilePath = Paths.ALICE_Settings; }
            if (FileName == null) { return null; }

            FileStream FS = null;
            try
            {
                if (File.Exists(FilePath + FileName))
                {
                    FS = new FileStream(FilePath + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        while (!SR.EndOfStream)
                        {
                            string Line = SR.ReadLine();
                            Temp = JsonConvert.DeserializeObject<T>(Line);
                        }
                    }
                }

                return Temp;
            }
            catch (Exception)
            {
                return Temp;
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }
    }

    public class Object_Base
    {
        public DateTime EventTimeStamp { get; set; }
        public string ModfyingEvent { get; set; }
    }
}
