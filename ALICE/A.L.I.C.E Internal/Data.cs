using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ALICE_Events;
using ALICE_Objects;

namespace ALICE_Internal
{
    public static class Data
    {
        public static List<Commodity> Commodities = Load_Comodities();
        public static List<GameModule> Modules = new List<GameModule>();
        public static Dictionary<decimal, Object_System> Systems = Load_Systems();
        public static Dictionary<decimal, Object_CodexEntry> CodexEntries = Load_CodexEntries();

        public static List<string> ShipModules = new List<string>();

        #region System Data
        public static Dictionary<decimal, Object_System> Load_Systems()
        {
            Dictionary<decimal, Object_System> Temp = new Dictionary<decimal, Object_System>();
            DirectoryInfo GameDir = new DirectoryInfo(Paths.ALICE_SystemData);

            foreach (FileInfo FileData in GameDir.EnumerateFiles("*.System", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    Object_System System = (Object_System)LoadValues<Object_System>(FileData.FullName);

                    //Check Loaded Data For Data Version Updates.
                    System = UpdateDataVersion(System);

                    Temp.Add(System.Address, System);
                }
                catch (Exception) { }
            }
            return Temp;
        }

        public static Object_System UpdateDataVersion(Object_System Sys)
        {
            string MethodName = "System Data Version Update";

            bool DataUpdated = false;

            #region Update To Version 340.0
            if (Sys.DataVersion == -1)
            {
                //NOTES: Updates Stellar Body Gravity Data. Logged Gravity Is 10X the Actual.
                //1. Divides Gravity By 10.
                //2. Sets Intial Data Version
                try
                {
                    DataUpdated = true;
                    Dictionary<decimal, Object_StellarBody> TempBodies = new Dictionary<decimal, Object_StellarBody>();
                    foreach (var Body in Sys.Bodies.Values)
                    {
                        if (Body.Gravity != -1) { Body.Gravity = Body.Gravity / 10; }
                        TempBodies.Add(Body.ID, Body);
                    }
                    Sys.Bodies = TempBodies;
                    Sys.DataVersion = 340.0M;
                }
                catch (Exception ex)
                {
                    Logger.ContactDeveloper();
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "System Name: " + Sys.Name);
                    Logger.Exception(MethodName, "Updating To 340.0");
                }
            }
            #endregion

            if (DataUpdated) { Sys.SaveValues<Object_System>(Sys, Sys.Name + ".System", Paths.ALICE_SystemData); }

            return Sys;
        }

        #endregion

        #region Codex Entries
        public static Dictionary<decimal, Object_CodexEntry> Load_CodexEntries()
        {
            Dictionary<decimal, Object_CodexEntry> Temp = new Dictionary<decimal, Object_CodexEntry>();
            DirectoryInfo GameDir = new DirectoryInfo(Paths.ALICE_CodexDiscoveries);

            foreach (FileInfo FileData in GameDir.EnumerateFiles("*.Codex", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    Object_CodexEntry System = (Object_CodexEntry)LoadValues<Object_CodexEntry>(FileData.FullName);
                    Temp.Add(System.Address, System);
                }
                catch (Exception) { }
            }
            return Temp;
        }
        #endregion

        #region Commodities
        public static List<Commodity> Load_Comodities()
        {
            List<Commodity> Items = null;

            string Dir = Paths.ALICE_Resources;
            DirectoryInfo directory = new DirectoryInfo(Dir);
            foreach (FileInfo ModuleFile in directory.EnumerateFiles("Commodities.Json", SearchOption.TopDirectoryOnly))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                { MissingMemberHandling = MissingMemberHandling.Ignore };

                FileStream FS = null;
                try
                {
                    FS = new FileStream(ModuleFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        while (!SR.EndOfStream)
                        {
                            string Line = SR.ReadLine();
                            var NewCom = JsonConvert.DeserializeObject<List<Commodity>>(Line);
                            Items = NewCom;
                        }
                    }
                }
                finally
                {
                    if (FS != null)
                    { FS.Dispose(); }
                }
            }

            return Items;
        }

        public static Commodity GetGameCommodity(string CommodityName)
        {
            return Commodities.Where(x => x.Name.ToLower() == CommodityName.ToLower()).FirstOrDefault();
        }

        public class Commodity
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public string PriceAverage { get; set; }
            public string PriceBuyMin { get; set; }
            public string PriceBuyMax { get; set; }
            public string PriceSellMin { get; set; }
            public string PriceSellMax { get; set; }
            public string Rare { get; set; }
            public string ItemID { get; set; }
        }
        #endregion

        #region Modules
        public static readonly List<string> ModulesIgnore = new List<string>()
        {
            "PaintJob",
            "Decal",
            "Nameplate",
            "Shipkit",
            "Customisation",
            "VoicePack",
            "Cockpit",
            "ModularCargoBayDoor",
            "Guardian"
        };

        public static bool ModulesIgnoreCheck(string Module)
        {
            foreach (string Item in ModulesIgnore)
            {
                if (Module.ToLower().Contains(Item.ToLower())) { return true; }
            }

            return false;
        }

        public static void Load_Modules()
        {
            string Dir = Paths.ALICE_Resources;
            DirectoryInfo directory = new DirectoryInfo(Dir);
            foreach (FileInfo ModuleFile in directory.EnumerateFiles("Modules.Json", SearchOption.TopDirectoryOnly))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                { MissingMemberHandling = MissingMemberHandling.Ignore };

                FileStream FS = null;
                try
                {
                    FS = new FileStream(ModuleFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        while (!SR.EndOfStream)
                        {
                            string Line = SR.ReadLine();
                            var NewMod = JsonConvert.DeserializeObject<List<GameModule>>(Line);
                            Modules = NewMod;
                        }
                    }
                }
                finally
                {
                    if (FS != null)
                    { FS.Dispose(); }
                }
            }
        }

        public static GameModule GetGameModule(string ModuleItem)
        {
            string MethodName = "Get Game Module";

            var Temp = Modules.Where(x => x.Item.ToLower() == ModuleItem.ToLower()).FirstOrDefault();

            if (Temp == null)
            {
                Temp = new GameModule();
                Logger.DebugLine(MethodName, "Returned Null, Passing Default Values.", Logger.Blue);
            }

            return Temp;
        }

        public class GameModule
        {
            public string Item { get; set; }
            public string Name { get; set; }
            public string Rating { get; set; }
            public string Class { get; set; }
            public string Price { get; set; }
            public string Capacity { get; set; }
            public string Ship { get; set; }
            public string Mount { get; set; }

            public GameModule()
            {
                Item = Default.String;
                Name = Default.String;
                Rating = Default.String;
                Class = Default.String;
                Price = Default.String;
                Capacity = Default.String;
                Ship = Default.String;
                Mount = Default.String;
            }
        }

        //Generated Code
        #region Module Wrapper (10/16/2018 8:33 PM)
        public static class ModuleGroup
        {
            public static string Lightweight_Alloy = "Lightweight Alloy";
            public static string Reinforced_Alloy = "Reinforced Alloy";
            public static string Military_Grade_Composite = "Military Grade Composite";
            public static string Mirrored_Surface_Composite = "Mirrored Surface Composite";
            public static string Reactive_Surface_Composite = "Reactive Surface Composite";
            public static string Pulse_Laser = "Pulse Laser";
            public static string Burst_Laser = "Burst Laser";
            public static string Beam_Laser = "Beam Laser";
            public static string Cannon = "Cannon";
            public static string Fragment_Cannon = "Fragment Cannon";
            public static string Multi_Cannon = "Multi-Cannon";
            public static string Plasma_Accelerator = "Plasma Accelerator";
            public static string Rail_Gun = "Rail Gun";
            public static string Missile_Rack = "Missile Rack";
            public static string Mine_Launcher = "Mine Launcher";
            public static string Torpedo_Pylon = "Torpedo Pylon";
            public static string Chaff_Launcher = "Chaff Launcher";
            public static string Electronic_Countermeasure = "Electronic Countermeasure";
            public static string Heat_Sink_Launcher = "Heat Sink Launcher";
            public static string Point_Defence = "Point Defence";
            public static string Mining_Laser = "Mining Laser";
            public static string Standard_Docking_Computer = "Standard Docking Computer";
            public static string Power_Plant = "Power Plant";
            public static string Thrusters = "Thrusters";
            public static string Frame_Shift_Drive = "Frame Shift Drive";
            public static string Life_Support = "Life Support";
            public static string Power_Distributor = "Power Distributor";
            public static string Sensors = "Sensors";
            public static string Shield_Generator = "Shield Generator";
            public static string Shield_Cell_Bank = "Shield Cell Bank";
            public static string Cargo_Rack = "Cargo Rack";
            public static string Fuel_Tank = "Fuel Tank";
            public static string Hatch_Breaker_Limpet_Controller = "Hatch Breaker Limpet Controller";
            public static string Cargo_Scanner = "Cargo Scanner";
            public static string Frame_Shift_Wake_Scanner = "Frame Shift Wake Scanner";
            public static string Kill_Warrant_Scanner = "Kill Warrant Scanner";
            public static string Basic_Discovery_Scanner = "Basic Discovery Scanner";
            public static string Intermediate_Discovery_Scanner = "Intermediate Discovery Scanner";
            public static string Advanced_Discovery_Scanner = "Advanced Discovery Scanner";
            public static string Detailed_Surface_Scanner = "Detailed Surface Scanner";
            public static string Fuel_Scoop = "Fuel Scoop";
            public static string Refinery = "Refinery";
            public static string Frame_Shift_Drive_Interdictor = "Frame Shift Drive Interdictor";
            public static string Auto_Field_Maintenance_Unit = "Auto Field-Maintenance Unit";
            public static string Shield_Booster = "Shield Booster";
            public static string Hull_Reinforcement_Package = "Hull Reinforcement Package";
            public static string Collector_Limpet_Controller = "Collector Limpet Controller";
            public static string Fuel_Transfer_Limpet_Controller = "Fuel Transfer Limpet Controller";
            public static string Prospector_Limpet_Controller = "Prospector Limpet Controller";
            public static string Shock_Mine_Launcher = "Shock Mine Launcher";
            public static string Planetary_Vehicle_Hangar = "Planetary Vehicle Hangar";
            public static string Bi_Weave_Shield_Generator = "Bi-Weave Shield Generator";
            public static string Planetary_Approach_Suite = "Planetary Approach Suite";
            public static string Enhanced_Performance_Thrusters = "Enhanced Performance Thrusters";
            public static string Corrosion_Resistant_Cargo_Rack = "Corrosion Resistant Cargo Rack";
            public static string Fighter_Hangar = "Fighter Hangar";
            public static string Economy_Class_Passenger_Cabin = "Economy Class Passenger Cabin";
            public static string Business_Class_Passenger_Cabin = "Business Class Passenger Cabin";
            public static string First_Class_Passenger_Cabin = "First Class Passenger Cabin";
            public static string Luxury_Passenger_Cabin = "Luxury Passenger Cabin";
            public static string Module_Reinforcement_Package = "Module Reinforcement Package";
            public static string Repair_Limpet_Controller = "Repair Limpet Controller";
            public static string AX_Missile_Rack = "AX Missile Rack";
            public static string Xeno_Scanner = "Xeno Scanner";
            public static string Research_Limpet_Controller = "Research Limpet Controller";
            public static string AX_Multi_Cannon = "AX Multi-Cannon";
            public static string Remote_Release_Flak_Launcher = "Remote Release Flak Launcher";
            public static string Shutdown_Field_Neutraliser = "Shutdown Field Neutraliser";
            public static string Decontamination_Limpet_Controller = "Decontamination Limpet Controller";
            public static string Recon_Limpet_Controller = "Recon Limpet Controller";
        }

        #endregion

        //End Region: Moudles
        #endregion

        #region Support Methods
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

        public static object LoadValues<T>(string FilePath = null)
        {
            T Temp = default(T);
            if (FilePath == null) { FilePath = Paths.ALICE_Settings; }

            FileStream FS = null;
            try
            {
                if (File.Exists(FilePath))
                {
                    FS = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
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
        #endregion
    }
}
