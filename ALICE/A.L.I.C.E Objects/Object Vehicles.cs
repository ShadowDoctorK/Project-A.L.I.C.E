using ALICE_Actions;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Objects
{
    public class Object_Mothership : Object_Base
    {
        public string Ship { get; set; }
        public decimal ShipID { get; set; }
        public string ShipName { get; set; }
        public string ShipIdent { get; set; }
        public decimal HullValue { get; set; }
        public decimal ModulesValue { get; set; }
        public decimal Rebuy { get; set; }
        public string FingerPrint { get; set; }
        public decimal FighterHangerTotal = 0;
        public decimal FighterPerHanger = 0;

        public Object_Mothership()
        {
            #region Event Based Properties
            Ship = Default.String;
            ShipID = Default.Decimal;
            ShipName = Default.String;
            ShipIdent = Default.String;
            HullValue = Default.Decimal;
            ModulesValue = Default.Decimal;
            Rebuy = Default.Decimal;

            Modules = new List<Module>();
            #endregion

            #region Custom / Derived Properties
            FingerPrint = Default.String;
            #endregion
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

        #region Modules
        public List<Module> Modules { get; set; }

        public class Module : ObjectCore
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
                Slot = null;
                Item = null;
                On = true;
                Priority = -1;
                Health = -1;
                Value = -1;
                AmmoInClip = -1;
                AmmoInHopper = -1;

                Engineering = new EngineeringInfo();
            }

            public class EngineeringInfo : ObjectCore
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
                    Engineer = null;
                    EngineerID = -1;
                    BlueprintID = -1;
                    BlueprintName = null;
                    Level = -1;
                    Quality = -1;
                    ExperimentalEffect = null;
                    ExperimentalEffect_Localised = null;

                    Modifiers = new List<Modifer>();
                }

                public class Modifer : ObjectCore
                {
                    public string Label { get; set; }
                    public decimal Value { get; set; }
                    public decimal OriginalValue { get; set; }
                    public decimal LessIsGood { get; set; }

                    public Modifer()
                    {
                        Label = null;
                        Value = -1;
                        OriginalValue = -1;
                        LessIsGood = -1;
                    }
                }
            }
        }

        //Generated Code
        #region Ship Module Variables (10/16/2018 10:09 PM)
        //public bool Discovery_Scanner = false;
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
        //public bool Collector_Limpet_Controller = false;
        public bool Corrosion_Resistant_Cargo_Rack = false;
        //public bool Decontamination_Limpet_Controller = false;
        public bool Economy_Class_Passenger_Cabin = false;
        //public bool Electronic_Countermeasure = false;
        public bool Enhanced_Performance_Thrusters = false;
        public bool Fighter_Hangar = false;
        public bool First_Class_Passenger_Cabin = false;
        public bool Fragment_Cannon = false;
        public bool Frame_Shift_Drive = false;
        //public bool Frame_Shift_Drive_Interdictor = false;
        //public bool Frame_Shift_Wake_Scanner = false;
        public bool Fuel_Scoop = false;
        public bool Fuel_Tank = false;
        //public bool Fuel_Transfer_Limpet_Controller = false;
        //public bool Hatch_Breaker_Limpet_Controller = false;
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
        //public bool Prospector_Limpet_Controller = false;
        public bool Pulse_Laser = false;
        public bool Rail_Gun = false;
        public bool Reactive_Surface_Composite = false;
        //public bool Recon_Limpet_Controller = false;
        public bool Refinery = false;
        public bool Reinforced_Alloy = false;
        public bool Remote_Release_Flak_Launcher = false;
        //public bool Repair_Limpet_Controller = false;
        //public bool Research_Limpet_Controller = false;
        public bool Sensors = false;
        public bool Shield_Booster = false;
        //public bool Shield_Cell_Bank = false;
        public bool Shield_Generator = false;
        public bool Shock_Mine_Launcher = false;
        //public bool Shutdown_Field_Neutraliser = false;
        public bool Standard_Docking_Computer = false;
        public bool Thrusters = false;
        public bool Torpedo_Pylon = false;
        //public bool Xeno_Scanner = false;
        #endregion

        //End Region: Modules
        #endregion

        public void U_FingerPrint(LoadGame Event)
        {
            FingerPrint = Event.ShipID + " " + Event.Ship + " (" + ISettings.Commander + ")";
            ISettings.Firegroup.ShipAssignment = FingerPrint;
        }

        public void U_FingerPrint(Loadout Event)
        {
            FingerPrint = Event.ShipID + " " + Event.Ship + " (" + ISettings.Commander + ")";
            ISettings.Firegroup.ShipAssignment = FingerPrint;
        }
    }
}
