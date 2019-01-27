using ALICE_Actions;
using ALICE_Core;
using ALICE_Equipment;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Settings;
using ALICE_Status;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Objects
{
    public class Object_Mothership : Object_VehicleBase
    {
        string MethodName = "Mothership";

        /// <summary>
        /// Allows tracking and control for updating older data version when updates occur.
        /// </summary>
        string DataVersion = "1.0.0";

        /// <summary>
        /// Motherships Information
        /// </summary>
        public Information I = new Information();

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
                //Custom Properties
                I.U_FingerPrint(Event.Event, Event.ShipID, Event.Ship);

                //Event Properties
                I.U_ShipID(Event.Event, Event.ShipID);
                I.U_Identifier(Event.Event, Event.ShipID, Event.ShipIdent);
                I.U_Name(Event.Event, Event.ShipID, Event.ShipName);
                I.U_Type(Event.Event, Event.ShipID, Event.Ship);
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
                //Custom Properties
                I.U_FingerPrint(Event.Event, Event.ShipID, Event.Ship);

                //Event Properties
                I.U_ShipID(Event.Event, Event.ShipID);
                I.U_Identifier(Event.Event, Event.ShipID, Event.ShipIdent);
                I.U_Name(Event.Event, Event.ShipID, Event.ShipName);
                I.U_Rebuy(Event.Event, Event.ShipID, Event.Rebuy);
                I.U_Type(Event.Event, Event.ShipID, Event.Ship);
                I.U_ValueHull(Event.Event, Event.ShipID, Event.HullValue);
                I.U_ValueModules(Event.Event, Event.ShipID, Event.ModulesValue);
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
                    IEquipment.ModuleStatus(Temp);

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

        public void Update(SetUserShipName Event)
        {
            string MethodName = "Loadout (Update)";

            if (I.Name == Event.UserShipName) { return; }

            try
            {
                //Custom Properties
                I.U_FingerPrint(Event.Event, Event.ShipID, Event.Ship);

                //Event Properties
                I.U_ShipID(Event.Event, Event.ShipID);
                I.U_Type(Event.Event, Event.ShipID, Event.Ship);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception " + ex);
                Logger.Exception(MethodName, "Exception Occured When Updating Ships Information");
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

        public Object_Mothership Load(string MethodName, string FingerPrint)
        {
            Object_Mothership M = new Object_Mothership();

            //Load Last Updated Ship File
            if (FingerPrint == null)
            {
                Logger.Log(MethodName, "Loading Last Updated Ship File.", Logger.Yellow);

                //Find Last Updated File.
                FileInfo Temp = null; DirectoryInfo Dir = new DirectoryInfo(Paths.ALICE_Settings);
                foreach (FileInfo ShipFile in Dir.EnumerateFiles("*.Ship", SearchOption.TopDirectoryOnly))
                {
                    if (Temp == null || Temp.LastWriteTime < ShipFile.LastWriteTime)
                    {
                        Temp = ShipFile;
                    }
                }

                //Debug Logger
                Logger.DebugLine(MethodName, "Attempting To Load: " + Temp.Name, Logger.Blue);

                try
                {
                    //Check & Load Settings
                    if (File.Exists(Temp.FullName))
                    {
                        M = (Object_Mothership)LoadValues<Object_Mothership>(Temp.FullName);
                        Logger.DebugLine(MethodName, Temp.Name + ".Ship Loaded", Logger.Blue);
                    }
                    //Create New Settings File
                    else
                    {
                        Logger.Log(MethodName, "No Ship Files Were Loaded, Returning Default Values", Logger.Red);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception:" + ex);
                    Logger.Exception(MethodName, "Something Went Wrong Loading The Ship File, Returned Default Settings");
                }
            }

            //Load Target Ship File
            else
            {
                try
                {
                    //Check & Load Settings
                    if (File.Exists(Paths.ALICE_Settings + FingerPrint + ".Ship"))
                    {
                        M = (Object_Mothership)LoadValues<Object_Mothership>(FingerPrint + ".Ship");
                        Logger.DebugLine(MethodName, FingerPrint + ".Ship Loaded", Logger.Blue);
                    }
                    //Create New Settings File
                    else
                    {
                        M.Save(M, MethodName);
                        Logger.Log(MethodName, "Created " + FingerPrint + " Ship File.", Logger.Purple);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception:" + ex);
                    Logger.Exception(MethodName, "Something Went Wrong Loading The Ship File, Returned Default Settings");
                }
            }           

            //Return Settings
            return M;
        }

        public void Save(Object_Mothership M, string MethodName)
        {
            try
            {                
                SaveValues<Object_Mothership>(M, M.I.FingerPrint + ".Ship");                
                Logger.DebugLine(MethodName, M.I.FingerPrint + " Ship File Saved", Logger.Blue);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception:" + ex);
                Logger.Exception(MethodName, "Something Went Wrong And File Was Not Saved.");
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
            public void U_ShipID(string MethodName, decimal ShipID)
            {
                //ShipID Checks should be conducted prior to processing
                //the Event Updates.
                ID = ShipID;
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

            public void U_FingerPrint(string MethodName, decimal ID, string Type)
            {
                FingerPrint = ID + " " + Type + " (" + ISettings.Commander + ")";
                ISettings.Firegroup.ShipAssignment = FingerPrint;
                ISettings.U_MothershipFingerPrint(MethodName, FingerPrint);
            }
            #endregion
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
        /// Vehicle Equipment Status
        /// </summary>
        public Equipment E = new Equipment();

        /// <summary>
        /// Vehicle Cargo Status
        /// </summary>
        public Status_Cargo C = new Status_Cargo();

        /// <summary>
        /// Vehcile Fule Status
        /// </summary>
        public Status_Fuel F = new Status_Fuel();

        #region Base Save/Load Methods
        /// <summary>
        /// Generic Loader for Deserializing JSON settings.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="FileName">The name of the target file.</param>
        /// <param name="FilePath">The path of the target file. Default Path is the Settings Folder.</param>
        /// <returns></returns>
        public static object LoadValues<T>(string FileName, string FilePath = null)
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

        /// <summary>
        /// Generic Saver for Serializing object settings to JSON.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="Settings">The Object</param>
        /// <param name="FileName">The name of the target file.</param>
        /// <param name="FilePath">The path of the target file. Default Path is the Settings Folder.</param>
        public static void SaveValues<T>(object Settings, string FileName, string FilePath = null)
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
        #endregion

        public class Equipment
        {
            /// <summary>
            /// Current Ships Loadout.
            /// </summary>
            public List<Module> Outfitting = new List<Module>();

            /// <summary>
            /// Collection of Equipment Config's
            /// </summary>
            public EquipmentConfigCollection Settings = new EquipmentConfigCollection();

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
            //public bool Frame_Shift_Drive = false;
            public bool Fuel_Scoop = false;
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