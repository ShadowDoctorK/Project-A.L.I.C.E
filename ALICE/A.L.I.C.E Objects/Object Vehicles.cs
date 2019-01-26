using ALICE_Actions;
using ALICE_Core;
using ALICE_Equipment;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Settings;
using ALICE_Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Objects
{
    public class Object_Mothership : Object_VehicleBase
    {
        string MethodName = "Mothership";

        /// <summary>
        /// Motherships Information
        /// </summary>
        public Information I = new Information();

        /// <summary>
        /// Motherships Equipment Loadout
        /// </summary>
        public Equipment E = new Equipment();

        public Object_Mothership()
        {
            I = new Information();
            E = new Equipment();
            C = new Status_Cargo();
            F = new Status_Fuel();            
        }

        /// <summary>
        /// Resets The Motherships Values
        /// </summary>
        /// <param name="MethodName">The Name of the Method thats exectuing this.</param>
        public void New(string MethodName)
        {
            I = new Information();
            E = new Equipment();
            C = new Status_Cargo();
            F = new Status_Fuel();
        }

        public void Update(LoadGame Event)
        {
            string MethodName = "Load Game (Update)";

            try
            {

            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception " + ex);
                Logger.Exception(MethodName, "Exception Occured When Updating Ships Information");
            }
        }

        public void Update(Loadout Event)
        {
            string MethodName = "Loadout (Update)";

            try
            {
                I.U_ShipID(Event.Event, Event.ShipID);
                I.U_Identifier(Event.Event, Event.ShipID, Event.ShipIdent);
                I.U_Name(Event.Event, Event.ShipID, Event.ShipName);
                I.U_Rebuy(Event.Event, Event.ShipID, Event.Rebuy);
                I.U_Type(Event.Event, Event.ShipID, Event.Ship);
                I.U_ValueHull(Event.Event, Event.ShipID, Event.HullValue);
                I.U_ValueModules(Event.Event, Event.ShipID, Event.ModulesValue);
                I.U_FingerPrint(Event.Event);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception " + ex);
                Logger.Exception(MethodName, "Exception Occured When Updating Ships Information");
            }               

            foreach (var Mod in Event.Modules)
            {
                try
                {
                    //Generate Module
                    Module Temp = new Module(Mod);

                    //Add Game Module Data
                    Data.GameModule GM = Data.GetGameModule(Temp.Item);
                    Temp.Name = GM.Name;
                    Temp.Rating = GM.Rating;
                    Temp.Class = GM.Class;
                    Temp.Price = GM.Price;
                    Temp.Capacity = GM.Capacity;
                    Temp.Ship = GM.Ship;
                    Temp.Mount = GM.Mount;

                    //Update Modules Status
                    E.ModuleStatus(Temp);

                    //Update Outfitting
                    E.U_Module(Temp);                    
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception " + ex);
                    Logger.Exception(MethodName, "Exception Occured When Assigning The Following Slot: " + Mod.Slot + " | Item: " + Mod.Item);
                }                
            }

            if (EventTimeStamp < Event.Timestamp)
            {
                //Debug Logger
                Logger.DebugLine(MethodName, "Object Time Stamp Updated.", Logger.Blue);

                //Update Properties
                EventTimeStamp = Event.Timestamp;
                ModfyingEvent = Event.Event;
            }
        }

        public class Information
        {
            public decimal ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string Identifier { get; set; }
            public decimal Rebuy { get; set; }
            public decimal ValueModules { get; set; }
            public decimal ValueHull { get; set; }
            public string FingerPrint { get; set; }

            public Information()
            {
                ID = Default.Decimal;
                Name = Default.String;
                Type = Default.String;
                Identifier = Default.String;
                Rebuy = Default.Decimal;
                ValueHull = Default.Decimal;
                ValueModules = Default.Decimal;
                FingerPrint = Default.String;
            }

            #region Support Methods
            public void U_ShipID(string MethodName, decimal ID)
            {
                if (ShipID == -1)
                {
                    ShipID = ID;
                }
                else if (ShipID != ID)
                {
                    Logger.DebugLine(MethodName, "Ship ID Changed", Logger.Blue);
                }
                else
                {
                    ShipID =
                }
            }

            public void U_Type(string MethodName, decimal ShipID, string ShipType)
            {
                //Validation
                if (ShipID != ID)
                {
                    //Debug Logger
                    Logger.Error(MethodName, "Data Validation Failed, Incorrect Ship ID.", Logger.Red);

                    //Validation Failed, Return.
                    return;
                }

                //Update Property
                Type = ShipType;
            }

            public void U_Name(string MethodName, decimal ShipID, string ShipName)
            {
                //Validation
                if (ShipID != ID)
                {
                    //Debug Logger
                    Logger.Error(MethodName, "Data Validation Failed, Incorrect Ship ID.", Logger.Red);

                    //Validation Failed, Return.
                    return;
                }

                //Update Property
                Name = ShipName;
            }

            public void U_Identifier(string MethodName, decimal ShipID, string ShipIdent)
            {
                //Validation
                if (ShipID != ID)
                {
                    //Debug Logger
                    Logger.Error(MethodName, "Data Validation Failed, Incorrect Ship ID.", Logger.Red);

                    //Validation Failed, Return.
                    return;
                }

                //Update Property
                Identifier = ShipIdent;
            }

            public void U_ValueHull(string MethodName, decimal ShipID, decimal HullValue)
            {
                //Validation
                if (ShipID != ID)
                {
                    //Debug Logger
                    Logger.Error(MethodName, "Data Validation Failed, Incorrect Ship ID.", Logger.Red);

                    //Validation Failed, Return.
                    return;
                }

                //Update Property
                ValueHull = HullValue;
            }

            public void U_ValueModules(string MethodName, decimal ShipID, decimal ModuleValue)
            {
                //Validation
                if (ShipID != ID)
                {
                    //Debug Logger
                    Logger.Error(MethodName, "Data Validation Failed, Incorrect Ship ID.", Logger.Red);

                    //Validation Failed, Return.
                    return;
                }

                //Update Property
                ValueModules = ModuleValue;
            }

            public void U_Rebuy(string MethodName, decimal ShipID, decimal RebuyCost)
            {
                //Validation
                if (ShipID != ID)
                {
                    //Debug Logger
                    Logger.Error(MethodName, "Data Validation Failed, Incorrect Ship ID.", Logger.Red);

                    //Validation Failed, Return.
                    return;
                }

                //Update Property
                Rebuy = RebuyCost;
            }

            public void U_FingerPrint(string MethodName)
            {
                FingerPrint = ID + " " + Type + " (" + ISettings.Commander + ")";
                ISettings.Firegroup.ShipAssignment = FingerPrint;
                ISettings.U_MothershipFingerPrint(MethodName, FingerPrint);
            }
            #endregion
        }

        public class Equipment
        {
            /// <summary>
            /// Current Ships Loadout.
            /// </summary>
            public List<Module> Outfitting = new List<Module>();

            #region Equipment Properties
            /// <summary>
            /// Generic Equipment Reference used for Default responses.
            /// </summary>
            public Equipment_General General = new Equipment_General();

            public Equipment_CompositeScanner CompositeScanner = new Equipment_CompositeScanner();
            public Equipment_DiscoveryScanner DiscoveryScanner = new Equipment_DiscoveryScanner();
            public Equipment_DockingComputer DockingComputer = new Equipment_DockingComputer();
            public Equipment_ExternalLights ExternalLights = new Equipment_ExternalLights();
            public Equipment_ElectronicCountermeasure ElectronicCountermeasure = new Equipment_ElectronicCountermeasure();
            public Equipment_FighterHanger FighterHanger = new Equipment_FighterHanger();
            public Equipment_FrameShiftDrive FrameShiftDrive = new Equipment_FrameShiftDrive();
            public Equipment_FSDInterdictor FSDInterdictor = new Equipment_FSDInterdictor();
            public Equipment_LimpetCollector LimpetCollector = new Equipment_LimpetCollector();
            public Equipment_LimpetDecontamination LimpetDecontamination = new Equipment_LimpetDecontamination();
            public Equipment_LimpetHatchBreaker LimpetHatchBreaker = new Equipment_LimpetHatchBreaker();
            public Equipment_LimpetFuel LimpetFuel = new Equipment_LimpetFuel();
            public Equipment_LimpetRecon LimpetRecon = new Equipment_LimpetRecon();
            public Equipment_LimpetRepair LimpetRepair = new Equipment_LimpetRepair();
            public Equipment_LimpetResearch LimpetResearch = new Equipment_LimpetResearch();
            public Equipment_LimpetProspector LimpetProspector = new Equipment_LimpetProspector();
            public Equipment_PulseWaveScanner PulseWaveScanner = new Equipment_PulseWaveScanner();
            public Equipment_ShieldCellBank ShieldCellBank = new Equipment_ShieldCellBank();
            public Equipment_SurfaceScanner SurfaceScanner = new Equipment_SurfaceScanner();
            public Equipment_ShutdownFieldNeutraliser ShutdownFieldNeutraliser = new Equipment_ShutdownFieldNeutraliser();
            public Equipment_WakeScanner WakeScanner = new Equipment_WakeScanner();
            public Equipment_XenoScanner XenoScanner = new Equipment_XenoScanner();
            #endregion

            #region Ship Module Variables (Convert To Equipment)
            public bool Auto_Field_Maintenance_Unit = false;
            public bool AX_Missile_Rack = false;
            public bool AX_Multi_Cannon = false;
            public bool Beam_Laser = false;
            public bool Bi_Weave_Shield_Generator = false;
            public bool Burst_Laser = false;
            public bool Business_Class_Passenger_Cabin = false;
            public bool Cannon = false;
            public bool Cargo_Rack = false;
            public bool Cargo_Scanner = false;
            public bool Chaff_Launcher = false;
            public bool Corrosion_Resistant_Cargo_Rack = false;
            public bool Economy_Class_Passenger_Cabin = false;
            public bool Enhanced_Performance_Thrusters = false;            
            public bool First_Class_Passenger_Cabin = false;
            public bool Fragment_Cannon = false;
            public bool Frame_Shift_Drive = false;
            public bool Fuel_Scoop = false;
            public bool Fuel_Tank = false;
            public bool Heat_Sink_Launcher = false;
            public bool Hull_Reinforcement_Package = false;
            public bool Kill_Warrant_Scanner = false;
            public bool Life_Support = false;
            public bool Lightweight_Alloy = false;
            public bool Luxury_Passenger_Cabin = false;
            public bool Military_Grade_Composite = false;
            public bool Mine_Launcher = false;
            public bool Mining_Laser = false;
            public bool Mirrored_Surface_Composite = false;
            public bool Missile_Rack = false;
            public bool Module_Reinforcement_Package = false;
            public bool Multi_Cannon = false;
            public bool Planetary_Approach_Suite = false;
            public bool Planetary_Vehicle_Hangar = false;
            public bool Plasma_Accelerator = false;
            public bool Point_Defence = false;
            public bool Power_Distributor = false;
            public bool Power_Plant = false;
            public bool Pulse_Laser = false;
            public bool Rail_Gun = false;
            public bool Reactive_Surface_Composite = false;
            public bool Refinery = false;
            public bool Reinforced_Alloy = false;
            public bool Remote_Release_Flak_Launcher = false;
            public bool Sensors = false;
            public bool Shield_Booster = false;
            public bool Shield_Generator = false;
            public bool Shock_Mine_Launcher = false;
            public bool Thrusters = false;
            public bool Torpedo_Pylon = false;
            #endregion

            public void U_Module(Module Module)
            {
                bool NewModule = true;
                int ListNumber = 0;

                foreach (Object_Mothership.Module Mod in Outfitting)
                {
                    if (Module.Slot == Mod.Slot)
                    {
                        NewModule = false;
                        Outfitting[ListNumber] = Module;
                    }
                    ListNumber++;
                }

                if (NewModule == true)
                {
                    Outfitting.Add(Module);
                }
            }

            public void ModuleStatus(Module Mod)
            {
                string MethodName = "Module Detection";

                #region Module Detection / Toggles (12/21/2018 5:23 PM)

                IEnums.ModuleGroup M = Utilities.ToEnum<IEnums.ModuleGroup>(Mod.Name.Replace(" ", "_").Replace("-", "_"));

                switch (M)
                {
                    //Items Installed By Default
                    //Composite Scanner
                    //Full Spectrum Scanner / Discovery Scanner

                    case IEnums.ModuleGroup.Auto_Field_Maintenance_Unit:
                        Auto_Field_Maintenance_Unit = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.AX_Missile_Rack:
                        AX_Missile_Rack = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.AX_Multi_Cannon:
                        AX_Multi_Cannon = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Beam_Laser:
                        Beam_Laser = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Bi_Weave_Shield_Generator:
                        Bi_Weave_Shield_Generator = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Burst_Laser:
                        Burst_Laser = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Business_Class_Passenger_Cabin:
                        Business_Class_Passenger_Cabin = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Cannon:
                        Cannon = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Cargo_Rack:
                        Cargo_Rack = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Cargo_Scanner:
                        Cargo_Scanner = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Chaff_Launcher:
                        Chaff_Launcher = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Collector_Limpet_Controller:
                        LimpetCollector.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Corrosion_Resistant_Cargo_Rack:
                        Corrosion_Resistant_Cargo_Rack = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Decontamination_Limpet_Controller:
                        LimpetDecontamination.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Detailed_Surface_Scanner:
                        SurfaceScanner.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Economy_Class_Passenger_Cabin:
                        Economy_Class_Passenger_Cabin = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Electronic_Countermeasure:
                        ElectronicCountermeasure.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Enhanced_Performance_Thrusters:
                        Enhanced_Performance_Thrusters = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Fighter_Hangar:
                        FighterHanger.Installed = true;

                        if (Mod.Class + Mod.Rating == "5D")
                        {
                            FighterHanger.Bays = 1;
                            FighterHanger.BayCapacity = 6;
                        }
                        else if (Mod.Class + Mod.Rating == "6D")
                        {
                            FighterHanger.Bays = 2;
                            FighterHanger.BayCapacity = 8;
                        }
                        else if (Mod.Class + Mod.Rating == "7D")
                        {
                            FighterHanger.Bays = 2;
                            FighterHanger.BayCapacity = 15;
                        }

                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.First_Class_Passenger_Cabin:
                        First_Class_Passenger_Cabin = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Fragment_Cannon:
                        Fragment_Cannon = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Frame_Shift_Drive:
                        Frame_Shift_Drive = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Frame_Shift_Drive_Interdictor:
                        FSDInterdictor.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Frame_Shift_Wake_Scanner:
                        WakeScanner.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Fuel_Scoop:
                        Fuel_Scoop = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Fuel_Tank:
                        Fuel_Tank = true;
                        IStatus.Fuel.Capacity = IStatus.Fuel.Capacity + Convert.ToDecimal(Mod.Capacity);
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Fuel_Transfer_Limpet_Controller:
                        LimpetFuel.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Hatch_Breaker_Limpet_Controller:
                        LimpetHatchBreaker.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Heat_Sink_Launcher:
                        Heat_Sink_Launcher = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Hull_Reinforcement_Package:
                        Hull_Reinforcement_Package = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Kill_Warrant_Scanner:
                        Kill_Warrant_Scanner = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Life_Support:
                        Life_Support = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Lightweight_Alloy:
                        Lightweight_Alloy = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Luxury_Passenger_Cabin:
                        Luxury_Passenger_Cabin = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Military_Grade_Composite:
                        Military_Grade_Composite = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Mine_Launcher:
                        Mine_Launcher = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Mining_Laser:
                        Mining_Laser = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Mirrored_Surface_Composite:
                        Mirrored_Surface_Composite = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Missile_Rack:
                        Missile_Rack = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Module_Reinforcement_Package:
                        Module_Reinforcement_Package = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Multi_Cannon:
                        Multi_Cannon = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Planetary_Approach_Suite:
                        Planetary_Approach_Suite = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Planetary_Vehicle_Hangar:
                        Planetary_Vehicle_Hangar = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Plasma_Accelerator:
                        Plasma_Accelerator = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Point_Defence:
                        Point_Defence = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Power_Distributor:
                        Power_Distributor = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Power_Plant:
                        Power_Plant = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Prospector_Limpet_Controller:
                        LimpetProspector.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Pulse_Laser:
                        Pulse_Laser = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Rail_Gun:
                        Rail_Gun = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Reactive_Surface_Composite:
                        Reactive_Surface_Composite = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Recon_Limpet_Controller:
                        LimpetRecon.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Refinery:
                        Refinery = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Reinforced_Alloy:
                        Reinforced_Alloy = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Remote_Release_Flak_Launcher:
                        Remote_Release_Flak_Launcher = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Repair_Limpet_Controller:
                        LimpetRepair.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Research_Limpet_Controller:
                        LimpetResearch.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Sensors:
                        Sensors = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Shield_Booster:
                        Shield_Booster = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Shield_Cell_Bank:
                        ShieldCellBank.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Shield_Generator:
                        Shield_Generator = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Shock_Mine_Launcher:
                        Shock_Mine_Launcher = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Shutdown_Field_Neutraliser:
                        ShutdownFieldNeutraliser.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Standard_Docking_Computer:
                        DockingComputer.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Thrusters:
                        Thrusters = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    case IEnums.ModuleGroup.Torpedo_Pylon:
                        Torpedo_Pylon = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    //Customized
                    case IEnums.ModuleGroup.Xeno_Scanner:
                        XenoScanner.Installed = true;
                        Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                        break;

                    default:
                        if (Data.ModulesIgnoreCheck(Mod.Item) == false)
                        {
                            Logger.DevUpdateLog(MethodName, "New Module Group Detected: " + Mod.Item, Logger.Red, true);
                        }
                        break;

                }
                #endregion
            }

            private string GetModuleName(Module M)
            {
                string ModuleName = "Module Detected: " + M.Class + M.Rating + " " + M.Name;
                if (M.Mount != null)
                {
                    ModuleName = ModuleName + " (" + M.Mount + ")";
                }
                return ModuleName;
            }

            public void Log_ShipsLoadout()
            {
                Logger.Simple(" ", Logger.Yellow);

                foreach (var Mod in Outfitting)
                {                    
                    Logger.Simple("Slot: " + Mod.Slot + " | " + Mod.Item, Logger.Yellow);
                }

                Logger.Simple("Ship Finger Print: " + IObjects.Mothership.I.FingerPrint, Logger.Yellow);
                Logger.Simple("SHIP LOADOUT REPORT", Logger.Yellow);
                Logger.Simple(" ", Logger.Yellow);                
            }
        }

        public class Module
        {
            //Always Used
            public string Slot { get; set; }
            public string Item { get; set; }
            public bool On { get; set; }
            public decimal Priority { get; set; }
            public decimal Health { get; set; }
            public decimal Value { get; set; }
            public decimal AmmoInHopper { get; set; }
            public decimal AmmoInClip { get; set; }
            public EngineeringInfo Engineering { get; set; }

            #region Added Module Data
            public string Name { get; set; }
            public string Rating { get; set; }
            public string Class { get; set; }
            public string Price { get; set; }
            public string Capacity { get; set; }
            public string Ship { get; set; }
            public string Mount { get; set; }
            #endregion

            public Module()
            {
                Slot = "None";
                Item = "None";
                On = true;
                Priority = -1;
                Health = -1;
                Value = -1;
                AmmoInClip = -1;
                AmmoInHopper = -1;

                Engineering = new EngineeringInfo();
            }

            public Module(Loadout.Module M)
            {
                Slot = M.Slot;
                Item = M.Item;
                On = M.On;
                Priority = M.Priority;
                Health = M.Health;
                Value = M.Value;
                AmmoInClip = M.AmmoInClip;
                AmmoInHopper = M.AmmoInHopper;

                Engineering = new EngineeringInfo(M.Engineering);
            }

            public class EngineeringInfo
            {
                public string Engineer { get; set; }
                public decimal EngineerID { get; set; }
                public decimal BlueprintID { get; set; }
                public string BlueprintName { get; set; }
                public decimal Level { get; set; }
                public decimal Quality { get; set; }
                public string ExperimentalEffect { get; set; }
                public string ExperimentalEffect_Localised { get; set; }
                public List<Modifer> Modifiers { get; set; }

                public EngineeringInfo()
                {
                    Engineer = "None";
                    EngineerID = -1;
                    BlueprintID = -1;
                    BlueprintName = "None";
                    Level = -1;
                    Quality = -1;
                    ExperimentalEffect = "None";
                    ExperimentalEffect_Localised = "None";

                    Modifiers = new List<Modifer>();
                }

                public EngineeringInfo(Loadout.EngineeringInfo E)
                {
                    Engineer = E.Engineer;
                    EngineerID = E.EngineerID;
                    BlueprintID = E.BlueprintID;
                    BlueprintName = E.BlueprintName;
                    Level = E.Level;
                    Quality = E.Quality;
                    ExperimentalEffect = E.ExperimentalEffect;
                    ExperimentalEffect_Localised = E.ExperimentalEffect_Localised;

                    Modifiers = new List<Modifer>();

                    foreach (var Item in E.Modifiers)
                    {
                        Modifiers.Add(new Modifer(Item));
                    }
                }

                public class Modifer
                {
                    public string Label { get; set; }
                    public decimal Value { get; set; }
                    public decimal OriginalValue { get; set; }
                    public decimal LessIsGood { get; set; }

                    public Modifer()
                    {
                        Label = "None";
                        Value = -1;
                        OriginalValue = -1;
                        LessIsGood = -1;
                    }

                    public Modifer(Loadout.Modifer M)
                    {
                        Label = M.Label;
                        Value = M.Value;
                        OriginalValue = M.OriginalValue;
                        LessIsGood = M.LessIsGood;
                    }
                }
            }
        }
    }

    public class Object_Fighter : Object_VehicleBase
    {

    }

    public class Object_SRV : Object_VehicleBase
    {

    }

    public class Object_VehicleBase : Object_Base
    {
        /// <summary>
        /// Vehicle Cargo Status
        /// </summary>
        public Status_Cargo C = new Status_Cargo();

        /// <summary>
        /// Vehcile Fule Status
        /// </summary>
        public Status_Fuel F = new Status_Fuel();
    }
}

#region Cargo
//public static Dictionary<string, Commodity> Cargo = new Dictionary<string, Commodity>();

//public class Commodity : Data.Commodity
//{
//    public Commodity() { }

//    public List<Manifest> Stock = new List<Manifest>();

//    //{ "timestamp":"2018-10-28T16:19:35Z", "event":"MarketBuy", "MarketID":3221644800, "Type":"progenitorcells", "Type_Localised":"Progenitor Cells", "Count":584, "BuyPrice":6593, "TotalCost":3850312 }
//    //{ "timestamp":"2018-10-28T16:06:40Z", "event":"CargoDepot", "MissionID":429184741, "UpdateType":"Deliver", "CargoType":"PersonalWeapons", "CargoType_Localised":"Personal Weapons", "Count":584, "StartMarketID":0, "EndMarketID":3221503744, "ItemsCollected":0, "ItemsDelivered":584, "TotalItemsToDeliver":882, "Progress":0.000000 }
//    //{ "timestamp":"2018-10-28T16:06:41Z", "event":"CargoDepot", "MissionID":429184741, "UpdateType":"WingUpdate", "StartMarketID":0, "EndMarketID":3221503744, "ItemsCollected":0, "ItemsDelivered":584, "TotalItemsToDeliver":882, "Progress":0.000000 }
//    //{ "timestamp":"2018-10-28T19:06:50Z", "event":"MarketSell", "MarketID":3224098560, "Type":"beryllium", "Count":584, "SellPrice":9170, "TotalSale":5355280, "AvgPricePaid":7350 }

//    public class Manifest
//    {
//        public string Source { get; set; }
//        public decimal MarketID { get; set; }
//        public decimal Count { get; set; }
//        public decimal BuyPrice { get; set; }
//        public decimal TotalCost { get; set; }
//        public bool Stolen { get; set; }

//        public Manifest() { }
//    }          
//}
#endregion