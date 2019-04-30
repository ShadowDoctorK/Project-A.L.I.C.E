using ALICE_Data;
using ALICE_Events;
using ALICE_Internal;
using System;

namespace ALICE_Status
{
    public static partial class IStatus
    {
        public static Modules Module { get; set; } = new Modules();
    }

    public class Modules
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

            //Custom
            Composite_Scanner,
            Discovery_Scanner,

            //Generated
            Abrasion_Blaster,
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
            Corrosion_Resistant_Cargo_Rack,
            Decontamination_Limpet_Controller,
            Detailed_Surface_Scanner,
            Economy_Class_Passenger_Cabin,
            Electronic_Countermeasure,
            Enhanced_Performance_Thrusters,
            Enzyme_Missile_Rack,
            Fighter_Hangar,
            First_Class_Passenger_Cabin,
            Fragment_Cannon,
            Frame_Shift_Drive,
            Frame_Shift_Drive_Interdictor,
            Frame_Shift_Wake_Scanner,
            Fuel_Scoop,
            Fuel_Tank,
            Fuel_Transfer_Limpet_Controller,
            Guardian_FSD_Booster,
            Guardian_Gauss_Cannon,
            Guardian_Hull_Reinforcement,
            Guardian_Hybrid_Power_Distributor,
            Guardian_Hybrid_Power_Plant,
            Guardian_Module_Reinforcement,
            Guardian_Plasma_Charger,
            Guardian_Shard_Cannon,
            Guardian_Shield_Reinforcement,
            Hatch_Breaker_Limpet_Controller,
            Heat_Sink_Launcher,
            Hull_Reinforcement_Package,
            Kill_Warrant_Scanner,
            Life_Support,
            Lightweight_Alloy,
            Luxury_Passenger_Cabin,
            Meta_Alloy_Hull_Reinforcement,
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
            Pulse_Wave_Analyser,
            Rail_Gun,
            Reactive_Surface_Composite,
            Recon_Limpet_Controller,
            Refinery,
            Reinforced_Alloy,
            Remote_Release_Flak_Launcher,
            Remote_Release_Flechette_Launcher,
            Repair_Limpet_Controller,
            Research_Limpet_Controller,
            Seismic_Charge_Launcher,
            Sensors,
            Shield_Booster,
            Shield_Cell_Bank,
            Shield_Generator,
            Shock_Cannon,
            Shock_Mine_Launcher,
            Shutdown_Field_Neutraliser,
            Standard_Docking_Computer,
            Sub_Surface_Displacement_Missile,
            Thrusters,
            Torpedo_Pylon,
            Xeno_Scanner
        }

        #region Miscellaneous
        public Equipment DiscoveryScanner = new Equipment
        {
            Installed = true
        };
        public Equipment ComositeScanner = new Equipment
        {
            Installed = true
        };
        #endregion

        #region Hardpoints
        public Equipment AbrasionBlaster { get; set; } = new Equipment();   
        public Equipment BeamLaser { get; set; } = new Equipment();
        public Equipment BurstLaser { get; set; } = new Equipment();
        public Equipment Cannon { get; set; } = new Equipment();
        public Equipment MissileRack { get; set; } = new Equipment();
        public Equipment GaussCannon { get; set; } = new Equipment();
        public Equipment PlasmaCharger { get; set; } = new Equipment();
        public Equipment ShardCannon { get; set; } = new Equipment();
        public Equipment FragmentCannon { get; set; } = new Equipment();
        public Equipment MiningLaser { get; set; } = new Equipment();
        public Equipment MineLauncher { get; set; } = new Equipment();
        public Equipment MultiCannon { get; set; } = new Equipment();
        public Equipment PlasmaAccelerator { get; set; } = new Equipment();
        public Equipment PulseLaser { get; set; } = new Equipment();
        public Equipment RailGun { get; set; } = new Equipment();
        public Equipment FlakLauncher { get; set; } = new Equipment();
        public Equipment FlechetteLauncher { get; set; } = new Equipment();
        public Equipment ChargeLauncher { get; set; } = new Equipment();
        public Equipment DisplacementMissile { get; set; } = new Equipment();
        public Equipment ShockCannon { get; set; } = new Equipment();
        public Equipment Torpedos { get; set; } = new Equipment();
        #endregion

        #region Optional
        public Equipment AFMU { get; set; } = new Equipment();
        public Equipment ApproachSuite { get; set; } = new Equipment();
        public Equipment CargoRack { get; set; } = new Equipment();
        public Equipment DockingComputer { get; set; } = new Equipment();
        public Equipment FSDInterdictor { get; set; } = new Equipment();
        public Equipment FuelScoop { get; set; } = new Equipment();
        public Equipment Shields { get; set; } = new Equipment();
        public Equipment PassengerCabin { get; set; } = new Equipment();
        public Equipment FSDBooster { get; set; } = new Equipment();
        public Equipment Refinery { get; set; } = new Equipment();
        public Equipment ShieldBooster { get; set; } = new Equipment();
        public Equipment ShieldCell { get; set; } = new Equipment();
        public Equipment ShieldGenerator { get; set; } = new Equipment();

        //Scanners
        public Equipment CargoScanner { get; set; } = new Equipment();
        public Equipment SurfaceScanner { get; set; } = new Equipment();

        //Hangers
        public Equipment FighterHangar { get; set; } = new Equipment();
        public Equipment VehicleHangar { get; set; } = new Equipment();

        //Reinforcements
        public Equipment HullReinforcement { get; set; } = new Equipment();
        public Equipment ModuleReinforcement { get; set; } = new Equipment();
        public Equipment ShieldReinforcement { get; set; } = new Equipment();

        //Limpets
        public Equipment CollectorLimpet { get; set; } = new Equipment();
        public Equipment DecontaminationLimpet { get; set; } = new Equipment();
        public Equipment FuelLimpet { get; set; } = new Equipment();
        public Equipment HatchBreakerLimpet { get; set; } = new Equipment();
        public Equipment ProspectorLimpet { get; set; } = new Equipment();
        public Equipment ReconLimpet { get; set; } = new Equipment();
        public Equipment RepairLimpet { get; set; } = new Equipment();
        public Equipment ResearchLimpet { get; set; } = new Equipment();
        #endregion

        #region Utilities
        //Defense
        public Equipment ECM { get; set; } = new Equipment();
        public Equipment Chaff { get; set; } = new Equipment();
        public Equipment HeatSink { get; set; } = new Equipment();
        public Equipment PointDefence { get; set; } = new Equipment();

        //Scanners
        public Equipment FieldNeutraliser { get; set; } = new Equipment();
        public Equipment KillWarrantScanner { get; set; } = new Equipment();
        public Equipment PulseWaveAnalyser { get; set; } = new Equipment();
        public Equipment XenoScanner { get; set; } = new Equipment();
        public Equipment WakeScanner { get; set; } = new Equipment();
        #endregion

        public Modules()
        {
            //No Logic
        }

        public Modules(Loadout Event)
        {
            foreach (var Mod in Event.Modules)
            {
                Process(Mod);
            }
        }

        public void Process(Loadout.Module Mod)
        {
            string MethodName = "Modules (Process)";

            //Try To Convert Module
            E Equip = E.Default; try
            {
                Equip = IEnums.ToEnum<E>(IData.Module.GetData(Mod.Item).Name.Replace(" ", "_").Replace("-", "_"), false);
            }
            catch (Exception ex)
            {
                Logger.Log(MethodName, "Unable To Resolve " + Mod.Item, Logger.Yellow);
            }

            switch (Equip)
            {
                case E.Abrasion_Blaster:
                    AbrasionBlaster.Installed = true;
                    break;

                case E.Auto_Field_Maintenance_Unit:
                    AFMU.Installed = true;
                    break;

                case E.AX_Missile_Rack:
                    MissileRack.Installed = true;
                    break;

                case E.AX_Multi_Cannon:
                    MultiCannon.Installed = true;
                    break;

                case E.Beam_Laser:
                    BeamLaser.Installed = true;
                    break;

                case E.Bi_Weave_Shield_Generator:
                    Shields.Installed = true;
                    break;

                case E.Burst_Laser:
                    BurstLaser.Installed = true;
                    break;

                case E.Business_Class_Passenger_Cabin:
                    PassengerCabin.Installed = true;
                    break;

                case E.Cannon:
                    Cannon.Installed = true;
                    break;

                case E.Cargo_Rack:
                    CargoRack.Installed = true;
                    break;

                case E.Cargo_Scanner:
                    CargoScanner.Installed = true;
                    break;

                case E.Chaff_Launcher:
                    Chaff.Installed = true;
                    break;

                case E.Collector_Limpet_Controller:
                    CollectorLimpet.Installed = true;
                    break;

                case E.Corrosion_Resistant_Cargo_Rack:
                    CargoRack.Installed = true;
                    break;

                case E.Decontamination_Limpet_Controller:
                    DecontaminationLimpet.Installed = true;
                    break;

                case E.Detailed_Surface_Scanner:
                    SurfaceScanner.Installed = true;
                    break;

                case E.Economy_Class_Passenger_Cabin:
                    PassengerCabin.Installed = true;
                    break;

                case E.Electronic_Countermeasure:
                    ECM.Installed = true;
                    break;

                case E.Enhanced_Performance_Thrusters:
                    //No Logic
                    break;

                case E.Enzyme_Missile_Rack:
                    MissileRack.Installed = true;
                    break;

                case E.Fighter_Hangar:
                    FighterHangar.Installed = true;                    
                    break;

                case E.First_Class_Passenger_Cabin:
                    PassengerCabin.Installed = true;
                    break;

                case E.Fragment_Cannon:
                    FragmentCannon.Installed = true;
                    break;

                case E.Frame_Shift_Drive:
                    //No Logic
                    break;

                case E.Frame_Shift_Drive_Interdictor:
                    FSDInterdictor.Installed = true;
                    break;

                case E.Frame_Shift_Wake_Scanner:
                    WakeScanner.Installed = true;
                    break;

                case E.Fuel_Scoop:
                    FuelScoop.Installed = true;
                    break;

                case E.Fuel_Tank:
                    //No Logic
                    break;

                case E.Fuel_Transfer_Limpet_Controller:
                    FuelLimpet.Installed = true;
                    break;

                case E.Guardian_FSD_Booster:
                    FSDBooster.Installed = true;
                    break;

                case E.Guardian_Gauss_Cannon:
                    GaussCannon.Installed = true;
                    break;

                case E.Guardian_Hull_Reinforcement:
                    HullReinforcement.Installed = true;
                    break;

                case E.Guardian_Hybrid_Power_Distributor:
                    //No Logic
                    break;

                case E.Guardian_Hybrid_Power_Plant:
                    //No Logic
                    break;

                case E.Guardian_Module_Reinforcement:
                    ModuleReinforcement.Installed = true;
                    break;

                case E.Guardian_Plasma_Charger:
                    PlasmaCharger.Installed = true;
                    break;

                case E.Guardian_Shard_Cannon:
                    ShardCannon.Installed = true;
                    break;

                case E.Guardian_Shield_Reinforcement:
                    ShieldReinforcement.Installed = true;
                    break;

                case E.Hatch_Breaker_Limpet_Controller:
                    HatchBreakerLimpet.Installed = true;
                    break;

                case E.Heat_Sink_Launcher:
                    HeatSink.Installed = true;
                    break;

                case E.Hull_Reinforcement_Package:
                    HullReinforcement.Installed = true;
                    break;

                case E.Kill_Warrant_Scanner:
                    KillWarrantScanner.Installed = true;
                    break;

                case E.Life_Support:
                    //No Logic
                    break;

                case E.Lightweight_Alloy:
                    //No Logic
                    break;

                case E.Luxury_Passenger_Cabin:
                    PassengerCabin.Installed = true;
                    break;

                case E.Meta_Alloy_Hull_Reinforcement:
                    HullReinforcement.Installed = true;
                    break;

                case E.Military_Grade_Composite:
                    //No Logic
                    break;

                case E.Mine_Launcher:
                    MineLauncher.Installed = true;
                    break;

                case E.Mining_Laser:
                    MiningLaser.Installed = true;
                    break;

                case E.Mirrored_Surface_Composite:
                    //No Logic
                    break;

                case E.Missile_Rack:
                    MissileRack.Installed = true;
                    break;

                case E.Module_Reinforcement_Package:
                    ModuleReinforcement.Installed = true;
                    break;

                case E.Multi_Cannon:
                    MultiCannon.Installed = true;
                    break;

                case E.Planetary_Approach_Suite:
                    ApproachSuite.Installed = true;
                    break;

                case E.Planetary_Vehicle_Hangar:
                    VehicleHangar.Installed = true;
                    break;

                case E.Plasma_Accelerator:
                    PlasmaAccelerator.Installed = true;
                    break;

                case E.Point_Defence:
                    PointDefence.Installed = true;
                    break;

                case E.Power_Distributor:
                    //No Logic
                    break;

                case E.Power_Plant:
                    //No Logic
                    break;

                case E.Prospector_Limpet_Controller:
                    ProspectorLimpet.Installed = true;
                    break;

                case E.Pulse_Laser:
                    PulseLaser.Installed = true;
                    break;

                case E.Pulse_Wave_Analyser:
                    PulseWaveAnalyser.Installed = true;
                    break;

                case E.Rail_Gun:
                    RailGun.Installed = true;
                    break;

                case E.Reactive_Surface_Composite:
                    //No Logic
                    break;

                case E.Recon_Limpet_Controller:
                    ReconLimpet.Installed = true;
                    break;

                case E.Refinery:
                    Refinery.Installed = true;
                    break;

                case E.Reinforced_Alloy:
                    //No Logic
                    break;

                case E.Remote_Release_Flak_Launcher:
                    FlakLauncher.Installed = true;
                    break;

                case E.Remote_Release_Flechette_Launcher:
                    FlechetteLauncher.Installed = true;
                    break;

                case E.Repair_Limpet_Controller:
                    RepairLimpet.Installed = true;
                    break;

                case E.Research_Limpet_Controller:
                    ResearchLimpet.Installed = true;
                    break;

                case E.Seismic_Charge_Launcher:
                    ChargeLauncher.Installed = true;
                    break;

                case E.Sensors:
                    //No Logic
                    break;

                case E.Shield_Booster:
                    ShieldBooster.Installed = true;
                    break;

                case E.Shield_Cell_Bank:
                    ShieldCell.Installed = true;
                    break;

                case E.Shield_Generator:
                    Shields.Installed = true;
                    break;

                case E.Shock_Cannon:
                    ShockCannon.Installed = true;
                    break;

                case E.Shock_Mine_Launcher:
                    MineLauncher.Installed = true;
                    break;

                case E.Shutdown_Field_Neutraliser:
                    FieldNeutraliser.Installed = true;
                    break;

                case E.Standard_Docking_Computer:
                    DockingComputer.Installed = true;
                    break;

                case E.Sub_Surface_Displacement_Missile:
                    DisplacementMissile.Installed = true;
                    break;

                case E.Thrusters:
                    //No Logic
                    break;

                case E.Torpedo_Pylon:
                    Torpedos.Installed = true;
                    break;

                case E.Xeno_Scanner:
                    XenoScanner.Installed = true;
                    break;

                default:
                    Logger.DevUpdateLog(MethodName, "New Module Group Detected: " + Mod.Item, Logger.Yellow, true);
                    break;
            }
        }

        public class Equipment
        {
            public bool Installed = false;
            public decimal Total = -1;
            public decimal Units = -1;
        }        
    }
}