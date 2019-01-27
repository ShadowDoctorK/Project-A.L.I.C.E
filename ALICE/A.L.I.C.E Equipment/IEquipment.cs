using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Equipment;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;

namespace ALICE_Core
{
    public static class IEquipment
    {
        /// <summary>
        /// (Equipment Firegroup Mode) Enum to allow easy reference for Hud Mode swtiching.
        /// </summary>
        public enum M
        {
            Default,
            Analysis,
            Combat,
            Both
        }

        /// <summary>
        /// (Equipment List) Enum to allow easy reference of Equipment
        /// </summary>
        public enum E
        {
            Default,
            Auto_Field_Maintenance_Unit,
            AX_Missile_Rack,
            AX_Multi_Cannon,            
            Beam_Laser,
            Bi_Weave_Shield_Generator,
            Burst_Laser,
            Business_Class_Passenger_Cabin,
            Cannon,
            Cargo_Rack,
            Cargo_Scanner,
            Chaff_Launcher,
            Collector_Limpet_Controller,
            Composite_Scanner,                      //Custom Addition
            Corrosion_Resistant_Cargo_Rack,
            Decontamination_Limpet_Controller,
            Detailed_Surface_Scanner,
            Discovery_Scanner,
            Economy_Class_Passenger_Cabin,
            Electronic_Countermeasure,
            Enhanced_Performance_Thrusters,
            Fighter_Hangar,
            First_Class_Passenger_Cabin,
            Fragment_Cannon,
            Frame_Shift_Drive,
            Frame_Shift_Drive_Interdictor,
            Frame_Shift_Wake_Scanner,
            Fuel_Scoop,
            Fuel_Tank,
            Fuel_Transfer_Limpet_Controller,
            Hatch_Breaker_Limpet_Controller,
            Heat_Sink_Launcher,
            Hull_Reinforcement_Package,           
            Kill_Warrant_Scanner,
            Life_Support,
            Lightweight_Alloy,
            Luxury_Passenger_Cabin,
            Military_Grade_Composite,
            Mine_Launcher,
            Mining_Laser,
            Mirrored_Surface_Composite,
            Missile_Rack,
            Module_Reinforcement_Package,
            Multi_Cannon,
            Planetary_Approach_Suite,
            Planetary_Vehicle_Hangar,
            Plasma_Accelerator,
            Point_Defence,
            Power_Distributor,
            Power_Plant,
            Prospector_Limpet_Controller,
            Pulse_Laser,
            Pulse_Wave_Scanner,                 //Custom Addition
            Rail_Gun,
            Reactive_Surface_Composite,
            Recon_Limpet_Controller,
            Refinery,
            Reinforced_Alloy,
            Remote_Release_Flak_Launcher,
            Repair_Limpet_Controller,
            Research_Limpet_Controller,
            Sensors,
            Shield_Booster,
            Shield_Cell_Bank,
            Shield_Generator,
            Shock_Mine_Launcher,
            Shutdown_Field_Neutraliser,
            Standard_Docking_Computer,
            Thrusters,
            Torpedo_Pylon,
            Xeno_Scanner
        }

        #region Equipment Properties
        /// <summary>
        /// Generic Equipment Reference used for Default responses.
        /// </summary>
        public static Equipment_General General = new Equipment_General();

        public static Equipment_CompositeScanner CompositeScanner = new Equipment_CompositeScanner();
        public static Equipment_DiscoveryScanner DiscoveryScanner = new Equipment_DiscoveryScanner();
        public static Equipment_DockingComputer DockingComputer = new Equipment_DockingComputer();
        public static Equipment_ExternalLights ExternalLights = new Equipment_ExternalLights();
        public static Equipment_ElectronicCountermeasure ElectronicCountermeasure = new Equipment_ElectronicCountermeasure();
        public static Equipment_FighterHanger FighterHanger = new Equipment_FighterHanger();
        public static Equipment_FrameShiftDrive FrameShiftDrive = new Equipment_FrameShiftDrive();
        public static Equipment_FSDInterdictor FSDInterdictor = new Equipment_FSDInterdictor();
        public static Equipment_FuelTank FuelTank = new Equipment_FuelTank();
        public static Equipment_LimpetCollector LimpetCollector = new Equipment_LimpetCollector();
        public static Equipment_LimpetDecontamination LimpetDecontamination = new Equipment_LimpetDecontamination();
        public static Equipment_LimpetHatchBreaker LimpetHatchBreaker = new Equipment_LimpetHatchBreaker();
        public static Equipment_LimpetFuel LimpetFuel = new Equipment_LimpetFuel();
        public static Equipment_LimpetProspector LimpetProspector = new Equipment_LimpetProspector();
        public static Equipment_LimpetRecon LimpetRecon = new Equipment_LimpetRecon();
        public static Equipment_LimpetRepair LimpetRepair = new Equipment_LimpetRepair();
        public static Equipment_LimpetResearch LimpetResearch = new Equipment_LimpetResearch();
        public static Equipment_PulseWaveScanner PulseWaveScanner = new Equipment_PulseWaveScanner();
        public static Equipment_ShieldCellBank ShieldCellBank = new Equipment_ShieldCellBank();
        public static Equipment_ShutdownFieldNeutraliser ShutdownFieldNeutraliser = new Equipment_ShutdownFieldNeutraliser();
        public static Equipment_SurfaceScanner SurfaceScanner = new Equipment_SurfaceScanner();
        public static Equipment_WakeScanner WakeScanner = new Equipment_WakeScanner();
        public static Equipment_XenoScanner XenoScanner = new Equipment_XenoScanner();
        #endregion

        public static string GetModuleName(Object_VehicleBase.Module Mod)
        {
            string ModuleName = "Module Detected: " + Mod.Class + Mod.Rating + " " + Mod.Name;
            if (Mod.Mount != null)
            {
                ModuleName = ModuleName + " (" + Mod.Mount + ")";
            }
            return ModuleName;
        }

        public static void ModuleStatus(Object_VehicleBase.Module Mod)
        {
            string MethodName = "Module Detection";

            /*
             * Notes: Finish converting the modules over and clean this method
             * up. Remove the sub switches and replace with the default processor
             * and the speical modules.
             */

            //Try To Convert Module
            E Equip = E.Default; try
            {
                Equip = Utilities.ToEnum<E>(Mod.Name.Replace(" ", "_").Replace("-", "_"));
            }
            catch (Exception)
            {
                
            }

            //Get the Current Vehicles Equipment Settings.
            //Or Default Settins If They Don't Exist.
            var Temp = IVehicles.Get(Equip);

            //Update Settings
            switch (Equip)
            {
                //Items Installed By Default
                //Composite Scanner
                //Full Spectrum Scanner / Discovery Scanner
                
                case E.Auto_Field_Maintenance_Unit:

                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.AX_Missile_Rack:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.AX_Missile_Rack = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }
                    
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.AX_Multi_Cannon:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.AX_Multi_Cannon = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Beam_Laser:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Beam_Laser = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Bi_Weave_Shield_Generator:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Bi_Weave_Shield_Generator = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Burst_Laser:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Burst_Laser = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Business_Class_Passenger_Cabin:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Business_Class_Passenger_Cabin = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Cannon:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Cannon = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Cargo_Rack:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Cargo_Rack = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Cargo_Scanner:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Cargo_Scanner = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Chaff_Launcher:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Chaff_Launcher = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Collector_Limpet_Controller:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Corrosion_Resistant_Cargo_Rack:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Corrosion_Resistant_Cargo_Rack = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Decontamination_Limpet_Controller:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                //Customized
                case E.Detailed_Surface_Scanner:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Economy_Class_Passenger_Cabin:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Economy_Class_Passenger_Cabin = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                //Customized
                case E.Electronic_Countermeasure:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Enhanced_Performance_Thrusters:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Enhanced_Performance_Thrusters = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                //Customized
                case E.Fighter_Hangar:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;

                    if (Mod.Class + Mod.Rating == "5D")
                    {
                        Temp.Total = 1;
                        Temp.Capacity = 6;
                    }
                    else if (Mod.Class + Mod.Rating == "6D")
                    {
                        Temp.Total = 2;
                        Temp.Capacity = 8;
                    }
                    else if (Mod.Class + Mod.Rating == "7D")
                    {
                        Temp.Total = 2;
                        Temp.Capacity = 15;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.First_Class_Passenger_Cabin:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.First_Class_Passenger_Cabin = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Fragment_Cannon:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Fragment_Cannon = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Frame_Shift_Drive:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                //Customized
                case E.Frame_Shift_Drive_Interdictor:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Frame_Shift_Wake_Scanner:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Fuel_Scoop:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Fuel_Scoop = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                //Customized
                case E.Fuel_Tank:
                    decimal Capacity = FuelTank.Capacity + Convert.ToDecimal(Mod.Capacity);
                    FuelTank.U_Capacity(MethodName, Capacity);
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Fuel_Transfer_Limpet_Controller:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Hatch_Breaker_Limpet_Controller:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Heat_Sink_Launcher:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Heat_Sink_Launcher = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Hull_Reinforcement_Package:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Hull_Reinforcement_Package = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Kill_Warrant_Scanner:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Kill_Warrant_Scanner = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Life_Support:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Life_Support = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Lightweight_Alloy:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Lightweight_Alloy = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Luxury_Passenger_Cabin:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Luxury_Passenger_Cabin = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Military_Grade_Composite:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Military_Grade_Composite = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Mine_Launcher:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Mine_Launcher = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Mining_Laser:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Mining_Laser = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Mirrored_Surface_Composite:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Mirrored_Surface_Composite = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Missile_Rack:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Missile_Rack = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Module_Reinforcement_Package:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Module_Reinforcement_Package = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Multi_Cannon:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Multi_Cannon = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Planetary_Approach_Suite:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Planetary_Approach_Suite = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Planetary_Vehicle_Hangar:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Planetary_Vehicle_Hangar = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Plasma_Accelerator:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Plasma_Accelerator = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Point_Defence:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Point_Defence = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Power_Distributor:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Power_Distributor = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Power_Plant:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Power_Plant = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Prospector_Limpet_Controller:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Pulse_Laser:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Pulse_Laser = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Rail_Gun:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Rail_Gun = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Reactive_Surface_Composite:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Reactive_Surface_Composite = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Recon_Limpet_Controller:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Refinery:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Refinery = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Reinforced_Alloy:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Reinforced_Alloy = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Remote_Release_Flak_Launcher:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Remote_Release_Flak_Launcher = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Repair_Limpet_Controller:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Research_Limpet_Controller:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Sensors:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Sensors = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Shield_Booster:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Shield_Booster = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Shield_Cell_Bank:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Shield_Generator:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Shield_Generator = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Shock_Mine_Launcher:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Shock_Mine_Launcher = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                //Customized
                case E.Shutdown_Field_Neutraliser:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Standard_Docking_Computer:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Thrusters:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Thrusters = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                case E.Torpedo_Pylon:

                    switch (IVehicles.Vehicle)
                    {
                        case IVehicles.V.Mothership:
                            IObjects.Mothership.E.Torpedo_Pylon = true;
                            break;
                        case IVehicles.V.Fighter:
                            break;
                        case IVehicles.V.SRV:
                            break;
                        default:
                            break;
                    }

                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                //Customized
                case E.Xeno_Scanner:
                    Temp.Equipment = Equip;
                    Temp.Installed = true;
                    Data.ShipModules.Add("A.L.I.C.E: " + GetModuleName(Mod));
                    break;

                default:
                    if (Data.ModulesIgnoreCheck(Mod.Item) == false)
                    {
                        Logger.DevUpdateLog(MethodName, "New Module Group Detected: " + Mod.Item, Logger.Red, true);
                    }
                    break;
            }

            //Set Settings
            if (Temp.Equipment != E.Default)
            { IVehicles.Set(Temp); }
        }
    }

    public class Equipment_General
    {
        public string MethodName { get => this.GetType().Name.Replace("Equipment_", ""); }
        public EquipmentConfig Settings = new EquipmentConfig();

        public delegate bool WaitHandler();      //Allows Passing A Common WaitHandler Deleage.

        #region Watcher
        //Default Watcher / Catch Report. This Allows use of a Common WaitHandler property to be used
        //across all the equipment that requires a Completion check. Override The Watcher Method as required.
        public virtual WaitHandler Watch() { return new WaitHandler(Watcher); }
        public virtual bool Watcher()
        {
            Logger.Log(MethodName, "Don't Be Afraid, Really... Hold This Failure Over The Heads Of The Develoer...Rub Salt in The Wounds!", Logger.Red);
            Logger.Log(MethodName, "The Developer Forgot To Bulid The Watcher! Let Them Know They Goofed Up...", Logger.Red);
            return false;
        }
        #endregion       

        #region Logger Items
        public void InHyperspace() { Logger.Log(MethodName, "Can't Do That In Hyperspace", Logger.Red); }
        #endregion

        #region Audio
        public virtual void PositiveResponse(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Roger That Commander.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                , CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NegativeResponse(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative Commander.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                , CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void Assigned(string Group, string FireMode, bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Module Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase("Module Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NotAssigned(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Module Has Not Been Assigned", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NotInstalled(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Equipment Not Installed.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void EnteredHyperspace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Operations Aborted.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void ScanCommenced(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Scan Commenced.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void ScanComplete(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Scan Complete.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void ScanFailed(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Scan Failed.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NotInNormalSpace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can Only Do That In Normal Space.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NotInSupercruise(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can Only Do That In Supercruise.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NoHyperspace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can't Do That In Hyperspace.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NoSupercruise(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can't Do That In Supercruise.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NoNormalSpace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can't Do That In Normal Space.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void Activating(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(GN_Positive.Default, true) + "Activating.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void SelectionFailed(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Failed To Select Correct Firegroup.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void Selected(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Selected.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void CurrentlySelected(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(GN_Negative.Default, true) + " Currently Selected.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NotInMothership(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(GN_Negative.Default, true) + " Not In The Mothership.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NoTouchdown(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak(""
                .Phrase(GN_Negative.Default, true) +
                " Can't Do That During Touchdown.",
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NoDocked(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak(""
                .Phrase(GN_Negative.Default, true) +
                " Can't Do That While Docked.",
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion

        #region Utilities
        public virtual void GetSettings()
        {
            Settings = IVehicles.Get(Settings.Equipment);
        }

        public bool Check_Variable(bool TargetState, string MethodName, bool State, string Variable, bool DisableDebug = false, bool Answer = true)
        {
            string DebugText = Variable + " Check Equals Expected State (" + TargetState + ")";
            string Color = Logger.Blue;

            if (TargetState != State)
            {
                Answer = false;
                DebugText = Variable + " Check Does Not Equals Expected State (" + TargetState + ")";
                Color = Logger.Yellow;
            }

            if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

            return Answer;
        }

        public bool Check_Equipment(bool TargetState, string MethodName, bool State, string Equipment, bool DisableDebug = false, bool Answer = true)
        {
            string DebugText = Equipment + " Check Equals Expected State  (" + TargetState + ")";
            string Color = Logger.Blue;

            if (TargetState != State)
            {
                Answer = false;
                DebugText = Equipment + " Check Does Not Equal Expected State (" + TargetState + ")";
                Color = Logger.Yellow;
            }

            if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

            return Answer;
        }
        #endregion
    }

    public class EquipmentConfigCollection
    {
        /// <summary>
        /// Collection of Modules Settings used by IEquipment & IVehicle when executing commands.
        /// </summary>
        public Dictionary<IEquipment.E, EquipmentConfig> Collection = new Dictionary<IEquipment.E, EquipmentConfig>();

        #region Support Methods
        /// <summary>
        /// Will get the Equipment settings from the Collection if it exists.
        /// </summary>
        /// <param name="Equip">Target Equipment</param>
        /// <returns>Module Settings or Default Constructor Settings If Not Found</returns>
        public EquipmentConfig Get(IEquipment.E Equip)
        {
            string MethodName = "Equipment Settings (Get)";

            try
            {
                switch (Exists(Equip))
                {
                    case IEnums.A.Postive:

                        //Debug Logger
                        Logger.DebugLine(MethodName, Equip + " Settings Found, Returning Settings", Logger.Yellow);

                        //Return Equipment Settings
                        return Collection[Equip];

                    case IEnums.A.Negative:

                        //Debug Logger
                        Logger.DebugLine(MethodName, Equip + " Settings Did Not Exist, Returning Default Settings", Logger.Blue);

                        //Return Default Settings
                        return new EquipmentConfig();

                    case IEnums.A.Error:

                        //Debug Logger
                        Logger.DebugLine(MethodName, Equip + " Collection Check Returned As Error, Returning Default Settings", Logger.Blue);

                        //Return Default Settings
                        return new EquipmentConfig();

                    default:
                        Logger.Error(MethodName, "Returned Using The Default Switch, Something Went Wrong. Returning Default Settings", Logger.Blue);
                        return new EquipmentConfig();
                }
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "Exception Occured Retrieving Settings " + Equip + ". Returning Default Settings");

                //Return False Due To Exception
                return new EquipmentConfig();
            }
        }

        /// <summary>
        /// Will Add the Equipment settings to the Collection or Update them if they already Exist.
        /// </summary>
        /// <param name="C"></param>
        /// <returns>True is Set, False if not Set.</returns>
        public bool Set(EquipmentConfig C)
        {
            string MethodName = "Equipment Settings (Set)";

            try
            {
                switch (Exists(C.Equipment))
                {
                    case IEnums.A.Postive:

                        //Debug Logger
                        Logger.DebugLine(MethodName, C.Equipment + " Collection Check Returned Positive, Updating Settings", Logger.Yellow);

                        //Update Settings
                        Collection[C.Equipment] = C;

                        //Set Value, Return True
                        return true;

                    case IEnums.A.Negative:

                        //Debug Logger
                        Logger.DebugLine(MethodName, C.Equipment + " Collection Check Returned Negative, Adding Settings", Logger.Blue);

                        //Add Settings
                        Collection.Add(C.Equipment, C);

                        //Set Value, Return True
                        return true;

                    case IEnums.A.Error:

                        //Debug Logger
                        Logger.DebugLine(MethodName, C.Equipment + " Collection Check Returned As Error, Abortted Update.", Logger.Blue);

                        //Didn't Set Value, Return False
                        return false;

                    default:
                        Logger.Error(MethodName, "Returned Using The Default Switch, Something Went Wrong.", Logger.Blue);
                        return false;
                }
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "Exception Occured Updating Settings " + C.Equipment);

                //Return False Due To Exception
                return false;
            }          
        }

        /// <summary>
        /// Checks the Collection to see if the Item Exist.
        /// </summary>
        /// <param name="Equip">The Equipment you want to check</param>
        /// <returns>Positive, Negative, Error</returns>
        public IEnums.A Exists(IEquipment.E Equip)
        {
            string MethodName = "Equipment Settings (Exists)";

            try
            {
                //Check If Item Exists, If It Does Return Postive
                if (Collection.ContainsKey(Equip)) { return IEnums.A.Postive; }
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "Exception Occured While Checking " + Equip);

                //On Exception Return Error
                return IEnums.A.Error;                
            }

            //Return Default Negative
            return IEnums.A.Negative;
        }
        #endregion
    }

    public class EquipmentConfig
    {
        public IEquipment.E Equipment { get; set; }
        public IEquipment.M Mode { get; set; }
        public bool Installed { get; set; }
        public bool Enabled { get; set; }
        public decimal Total { get; set; }
        public decimal Capacity { get; set; }

        public EquipmentConfig()
        {
            Equipment = IEquipment.E.Default;
            Mode = IEquipment.M.Default;
            Installed = false;
            Enabled = false;
            Total = -1;
            Capacity = -1;
        }
    }

    public class Equipment_Base
    {
        public T New<T>() { return default(T); }
    }
}