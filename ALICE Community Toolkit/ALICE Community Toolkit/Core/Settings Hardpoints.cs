using ALICE_Internal;
using System.Collections.Generic;

namespace ALICE_Community_Toolkit
{
    /// <summary>
    /// The setting for the Firegroup Management System.
    /// These settings are controlled completely by the user and have no source from the game.
    /// </summary>
    public class SettingsHardpoints : SettingsUtilities
    {
        private string ClassName = "Hardpoints Settings";

        public string Assigntment { get; set; } = "Default";
        public decimal ShipID { get; set; } = -1;

        //Collection Of Config Settings
        public Dictionary<decimal, ConfigurationHardpoints> Storage { get; set; } = new Dictionary<decimal, ConfigurationHardpoints>();

        //Current Vehicles Config Settings
        public ConfigurationHardpoints Config = new ConfigurationHardpoints();

        public SettingsHardpoints()
        {
            Storage = new Dictionary<decimal, ConfigurationHardpoints>();
            Config = new ConfigurationHardpoints();
        }

        /// <summary>
        /// Updates Target Config.
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>        
        /// <param name="ID">(Ship ID) The Games Ship ID Number.</param>
        /// <param name="A">(Ship Assignment) The Ship Type/Name.</param>
        /// <returns>Ships Saved Loadout Event</returns>
        public void UpdateConfig()
        {
            string MethodName = ClassName + " (Update Config)";

            if (TKSettings.Save == false) { return; }

            //Update Config
            if (Storage.ContainsKey(ShipID))
            {
                //Update
                Storage[ShipID] = Config;

                //Save Settings
                TKSettings.Firegroup.Save();
            }
            else
            {
                //Error Logger
                Logger.Error(MethodName, "Ship ID " + ShipID + " Does Not Exist!", Logger.Red);
            }            
        }

        public void Save()
        {
            SaveValues<SettingsHardpoints>(TKSettings.Firegroup, "Firegroup.Settings");
        }

        public SettingsHardpoints Load()
        {
            return (SettingsHardpoints)LoadValues<SettingsHardpoints>("Firegroup.Settings");
        }
    }

    public class ConfigurationHardpoints
    {
        #region Properties
        public bool Default = true;  //Default Target For Ref Boolean.
        public enum Group { None, A, B, C, D, E, F, G, H };
        public enum Fire { None, Primary, Secondary }
        public enum Item
        {
            Weapons1,
            Weapons2,
            ECM,
            FieldNeutraliser,
            FSDInterdictor,
            LimpetCollector,
            LimpetDecontamination,
            LimpetFuel,
            LimpetHatchBreaker,
            LimpetRecon,
            LimpetRepair,
            LimpetResearch,
            LimpetProspector,
            LauncherHeatSinkOne,
            LauncherHeatSinkTwo,
            LauncherHeatSinkThree,
            LauncherHeatSinkFour,
            LauncherChaffOne,
            LauncherChaffTwo,
            LauncherChaffThree,
            LauncherChaffFour,
            LaserMinning,
            ScannerCagro,
            ScannerComposite,
            ScannerDiscovery,
            ScannerKillwarrent,
            ScannerSurface,
            ScannerXeno,
            ScannerWake,
            ShieldCellOne,
            ShieldCellTwo,
            ShieldCellThree,
            ShieldCellFour,
            PulseWaveAnalyser
        }
        public enum S { Selected, NotAssigned, Failed, CurrentlySelected, InHyperspace }
        public enum A { Hyperspace, NotAssigned, Complete, Fail }

        public string ShipAssignment { get; set; } = "Default";
        public decimal Groups { get; set; }
        public Assignemnt Weapons1 { get; set; }
        public Assignemnt Weapons2 { get; set; }
        public Assignemnt ECM { get; set; }
        public Assignemnt FSDInterdictor { get; set; }
        public Assignemnt FieldNeutraliser { get; set; }
        public Assignemnt LimpetCollector { get; set; }
        public Assignemnt LimpetDecontamination { get; set; }
        public Assignemnt LimpetFuel { get; set; }
        public Assignemnt LimpetHatchBreaker { get; set; }
        public Assignemnt LimpetProspector { get; set; }
        public Assignemnt LimpetRecon { get; set; }
        public Assignemnt LimpetRepair { get; set; }
        public Assignemnt LimpetResearch { get; set; }
        public Assignemnt LauncherChaffOne { get; set; }
        public Assignemnt LauncherChaffTwo { get; set; }
        public Assignemnt LauncherChaffThree { get; set; }
        public Assignemnt LauncherChaffFour { get; set; }
        public Assignemnt LauncherHeatSinkOne { get; set; }
        public Assignemnt LauncherHeatSinkTwo { get; set; }
        public Assignemnt LauncherHeatSinkThree { get; set; }
        public Assignemnt LauncherHeatSinkFour { get; set; }
        public Assignemnt LaserMinning { get; set; }
        public Assignemnt ScannerCagro { get; set; }
        public Assignemnt ScannerComposite { get; set; }
        public Assignemnt ScannerDiscovery { get; set; }
        public Assignemnt ScannerKillwarrent { get; set; }
        public Assignemnt ScannerSurface { get; set; }
        public Assignemnt ScannerXeno { get; set; }
        public Assignemnt ScannerWake { get; set; }
        public Assignemnt ShieldCellOne { get; set; }
        public Assignemnt ShieldCellTwo { get; set; }
        public Assignemnt ShieldCellThree { get; set; }
        public Assignemnt ShieldCellFour { get; set; }
        public Assignemnt PulseWaveAnalyser { get; set; }
        #endregion

        public ConfigurationHardpoints()
        {
            Groups = 1;

            //Main Weapons Group
            Weapons1 = new Assignemnt
            {
                FireGroup = Group.A,
                FireMode = Fire.Primary
            };

            //Secondary Weapons Group
            Weapons2 = new Assignemnt
            {
                FireGroup = Group.A,
                FireMode = Fire.Primary
            };

            ECM = new Assignemnt();
            FieldNeutraliser = new Assignemnt();
            FSDInterdictor = new Assignemnt();
            LimpetCollector = new Assignemnt();
            LimpetDecontamination = new Assignemnt();
            LimpetFuel = new Assignemnt();
            LimpetHatchBreaker = new Assignemnt();
            LimpetProspector = new Assignemnt();
            LimpetRecon = new Assignemnt();
            LimpetRepair = new Assignemnt();
            LimpetResearch = new Assignemnt();
            LauncherChaffOne = new Assignemnt();
            LauncherChaffTwo = new Assignemnt();
            LauncherChaffThree = new Assignemnt();
            LauncherChaffFour = new Assignemnt();
            LauncherHeatSinkOne = new Assignemnt();
            LauncherHeatSinkTwo = new Assignemnt();
            LauncherHeatSinkThree = new Assignemnt();
            LauncherHeatSinkFour = new Assignemnt();
            LaserMinning = new Assignemnt();
            ScannerCagro = new Assignemnt();
            ScannerComposite = new Assignemnt();
            ScannerDiscovery = new Assignemnt();
            ScannerKillwarrent = new Assignemnt();
            ScannerSurface = new Assignemnt();
            ScannerXeno = new Assignemnt();
            ScannerWake = new Assignemnt();
            ShieldCellOne = new Assignemnt();
            ShieldCellTwo = new Assignemnt();
            ShieldCellThree = new Assignemnt();
            ShieldCellFour = new Assignemnt();
            PulseWaveAnalyser = new Assignemnt();
        }

        #region Support / Conversion Items
        public decimal ConvertGroupFromEnum(Group G)
        {
            switch (G)
            {
                case Group.None:
                    return -1;
                case Group.A:
                    return 1;
                case Group.B:
                    return 2;
                case Group.C:
                    return 3;
                case Group.D:
                    return 4;
                case Group.E:
                    return 5;
                case Group.F:
                    return 6;
                case Group.G:
                    return 7;
                case Group.H:
                    return 8;
                default:
                    return -1;
            }
        }

        public Group ConvertGroupFromDecimal(decimal G)
        {
            switch (G)
            {
                case 1:
                    return Group.A;
                case 2:
                    return Group.B;
                case 3:
                    return Group.C;
                case 4:
                    return Group.D;
                case 5:
                    return Group.E;
                case 6:
                    return Group.F;
                case 7:
                    return Group.G;
                case 8:
                    return Group.H;
                default:
                    return Group.A;
            }
        }

        public decimal ConvertFireFromEnum(Fire F)
        {
            switch (F)
            {
                case Fire.None:
                    return -1;
                case Fire.Primary:
                    return 1;
                case Fire.Secondary:
                    return 2;
                default:
                    return -1;
            }
        }

        public Group ConvertGroupToEnum(string Letter)
        {
            string MethodName = "Convert FireGroup";
            switch (Letter)
            {
                case "A":
                    return Group.A;
                case "B":
                    return Group.B;
                case "C":
                    return Group.C;
                case "D":
                    return Group.D;
                case "E":
                    return Group.E;
                case "F":
                    return Group.F;
                case "G":
                    return Group.G;
                case "H":
                    return Group.H;
                default:
                    Logger.Log(MethodName, "FireGroup Was Not a Valid Setting (" + Letter + "). Please Use A - H.", Logger.Yellow);
                    return Group.None;
            }
        }

        public Fire ConverFireToEnum(string Value)
        {
            string MethodName = "Convert FireMode";
            switch (Value)
            {
                case "Primary":
                    return Fire.Primary;
                case "Secondary":
                    return Fire.Secondary;
                default:
                    Logger.Log(MethodName, "FireMode Was Not a Valid Setting (" + Value + "). Please Use Primary Or Secondary.", Logger.Yellow);
                    return Fire.None;
            }
        }

        /// <summary>
        /// Returns a string for the Fire Group used in creation of responses.
        /// </summary>
        /// <param name="G">The FireGroup</param>
        /// <returns></returns>
        public string ToText(Group G)
        {
            switch (G)
            {
                case Group.None:
                    return "None";
                case Group.A:
                    return "Alpha";
                case Group.B:
                    return "Bravo";
                case Group.C:
                    return "Charlie";
                case Group.D:
                    return "Delta";
                case Group.E:
                    return "Echo";
                case Group.F:
                    return "Foxtrot";
                case Group.G:
                    return "Golf";
                case Group.H:
                    return "Hotel";
                default:
                    return "None";
            }
        }

        /// <summary>
        /// Returns a string for the Fire Mode used in creation of responses.
        /// </summary>
        /// <param name="F">The FireMode</param>
        /// <returns></returns>
        public string ToText(Fire F)
        {
            switch (F)
            {
                case Fire.None:
                    return "None";
                case Fire.Primary:
                    return "Primary";
                case Fire.Secondary:
                    return "Secondary";
                default:
                    return "None";
            }
        }

        /// <summary>
        /// Returns the Analysis Mode State for the Module.
        /// </summary>
        /// <param name="I">The Module to be Checked.</param>
        /// <returns>True = Analysis Mode, False = Combat Mode.</returns>
        public static bool CheckMode(Item I)
        {
            string MethodName = "Firegroup Check Mode";

            switch (I)
            {
                case Item.Weapons1:
                    return false;                   //Combat Mode
                case Item.Weapons2:
                    return false;                   //Combat Mode
                case Item.ECM:
                    return false;                   //Combat Mode
                case Item.FieldNeutraliser:
                    return true;
                case Item.FSDInterdictor:
                    return false;                   //Combat Mode
                case Item.LimpetCollector:
                    return true;
                case Item.LimpetDecontamination:
                    return true;
                case Item.LimpetFuel:
                    return true;
                case Item.LimpetHatchBreaker:
                    return false;
                case Item.LimpetRecon:
                    return true;
                case Item.LimpetRepair:
                    return true;
                case Item.LimpetResearch:
                    return true;
                case Item.LimpetProspector:
                    return true;
                case Item.LauncherHeatSinkOne:
                    return false;
                case Item.LauncherHeatSinkTwo:
                    return false;
                case Item.LauncherHeatSinkThree:
                    return false;
                case Item.LauncherHeatSinkFour:
                    return false;
                case Item.LauncherChaffOne:
                    return false;
                case Item.LauncherChaffTwo:
                    return false;
                case Item.LauncherChaffThree:
                    return false;
                case Item.LauncherChaffFour:
                    return false;
                case Item.LaserMinning:
                    return true;
                case Item.ScannerCagro:
                    return false;
                case Item.ScannerComposite:
                    return true;
                case Item.ScannerDiscovery:
                    return true;
                case Item.ScannerKillwarrent:
                    return true;
                case Item.ScannerSurface:
                    return true;
                case Item.ScannerXeno:
                    return true;
                case Item.ShieldCellOne:
                    return false;                   //Combat Mode
                case Item.ShieldCellTwo:
                    return false;                   //Combat Mode
                case Item.ShieldCellThree:
                    return false;                   //Combat Mode
                case Item.ShieldCellFour:
                    return false;                   //Combat Mode
                case Item.PulseWaveAnalyser:
                    return true;
                default:
                    Logger.Log(MethodName, I + " Hud Mode Not Defined, Using Default \"False\"", Logger.Red);
                    return false;
            }
        }

        public static bool CheckEnabled(Assignemnt A)
        {
            //Total Firegroup Less Than Assigned Disble
            //Module Not Installed Disable
            //Module Turned Off Disable
            return true;
        }

        public Assignemnt GetAssignemnt(Item I)
        {
            string MethodName = "Assisted Firegroup (Get Assignement)";

            switch (I)
            {
                case Item.Weapons1:
                    return Weapons1;
                case Item.Weapons2:
                    return Weapons2;
                case Item.ECM:
                    return ECM;
                case Item.LimpetCollector:
                    return LimpetCollector;
                case Item.LimpetDecontamination:
                    return LimpetDecontamination;
                case Item.LimpetFuel:
                    return LimpetFuel;
                case Item.LimpetHatchBreaker:
                    return LimpetHatchBreaker;
                case Item.LimpetRecon:
                    return LimpetRecon;
                case Item.LimpetRepair:
                    return LimpetRepair;
                case Item.LimpetResearch:
                    return LimpetResearch;
                case Item.LimpetProspector:
                    return LimpetProspector;
                case Item.LauncherHeatSinkOne:
                    return LauncherHeatSinkOne;
                case Item.LauncherHeatSinkTwo:
                    return LauncherHeatSinkTwo;
                case Item.LauncherHeatSinkThree:
                    return LauncherHeatSinkThree;
                case Item.LauncherHeatSinkFour:
                    return LauncherHeatSinkFour;
                case Item.LauncherChaffOne:
                    return LauncherChaffOne;
                case Item.LauncherChaffTwo:
                    return LauncherChaffTwo;
                case Item.LauncherChaffThree:
                    return LauncherChaffThree;
                case Item.LauncherChaffFour:
                    return LauncherChaffFour;
                case Item.LaserMinning:
                    return LaserMinning;
                case Item.ScannerCagro:
                    return ScannerCagro;
                case Item.ScannerComposite:
                    return ScannerComposite;
                case Item.ScannerDiscovery:
                    return ScannerDiscovery;
                case Item.ScannerKillwarrent:
                    return ScannerKillwarrent;
                case Item.ScannerSurface:
                    return ScannerSurface;
                case Item.ScannerXeno:
                    return ScannerXeno;
                case Item.ShieldCellOne:
                    return ShieldCellOne;
                case Item.ShieldCellTwo:
                    return ShieldCellTwo;
                case Item.ShieldCellThree:
                    return ShieldCellThree;
                case Item.ShieldCellFour:
                    return ShieldCellFour;
                case Item.PulseWaveAnalyser:
                    return PulseWaveAnalyser;
                default:
                    Logger.DevUpdateLog(MethodName, I.ToString() + " Logic Does Not Exist, Unable To Get Assignement.", Logger.Red);
                    return new Assignemnt();
            }
        }
        #endregion

        public class Assignemnt
        {
            public Group FireGroup { get; set; }
            public Fire FireMode { get; set; }
            public bool Enabled { get; set; }

            public Assignemnt()
            {
                FireGroup = Group.None;
                FireMode = Fire.None;
                Enabled = false;
            }

            public Assignemnt(Group G, Fire F, Item I)
            {
                FireGroup = G;
                FireMode = F;
                Enabled = true;
            }
        }
    }
}