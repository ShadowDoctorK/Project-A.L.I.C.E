using ALICE_Internal;
using ALICE_Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using WinForms = System.Windows.Forms;

namespace ALICE_Community_Toolkit
{
    public static class Data
    {
        #region User Settings
        private static Settings_User_TK User = Load(User, ISettings.SettingsUser, "Initialize");

        public static bool UserSettingsSave = false;
        public static bool UserSettingsUpdating = false;
        public static void UserSettingsLoad(bool UpdateRef = false)
        {
            string MethodName = "Load User Settings";

            User = Load(User, ISettings.SettingsUser, MethodName);
        }        

        public static string Commander
        {
            get => User.Commander;
            set
            {
                if (User.Commander != value)
                {
                    User.Commander = value;                    
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                }
            }
        }

        #region Plugin
        public static int OffsetPanels
        {
            get => User.OffsetPanels;
            set
            {
                if (User.OffsetPanels != value)
                {
                    User.OffsetPanels = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Panel Offset = " + value + "ms", Logger.Green);
                }
            }
        }

        public static int OffsetPips
        {
            get => User.OffsetPips;
            set
            {
                if (User.OffsetPips != value)
                {
                    User.OffsetPips = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Pip Offset = " + value + "ms", Logger.Green);
                }
            }
        }

        public static int OffsetFireGroups
        {
            get => User.OffsetFireGroups;
            set
            {
                if (User.OffsetFireGroups != value)
                {
                    User.OffsetFireGroups = value;
                    Logger.Simple("Firegroup Offset = " + value + "ms", Logger.Green);
                }
            }
        }

        public static int OffsetThrottle
        {
            get => User.OffsetThrottle;
            set
            {
                if (User.OffsetThrottle != value)
                {
                    User.OffsetThrottle = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Throttle Offset = " + value + "ms", Logger.Green);
                }
            }
        }
        #endregion

        #region Orders
        public static bool WeaponSafety
        {
            get => User.WeaponSafety;
            set
            {
                if (User.WeaponSafety != value)
                {
                    User.WeaponSafety = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Weapon Safeties = " + value, Logger.Green);
                }
            }
        }

        public static bool CombatPower
        {
            get => User.CombatPower;
            set
            {
                if (User.CombatPower != value)
                {
                    User.CombatPower = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Assisted Combat Power = " + value, Logger.Green);
                }
            }
        }

        public static bool AssistSystemScan
        {
            get => User.AssistSystemScan;
            set
            {
                if (User.AssistSystemScan != value)
                {
                    User.AssistSystemScan = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Assisted System Scans = " + value, Logger.Green);
                }
            }
        }

        public static bool AssistDocking
        {
            get => User.AssistDocking;
            set
            {
                if (User.AssistDocking != value)
                {
                    User.AssistDocking = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Assisted Docking Procedures = " + value, Logger.Green);
                }
            }
        }

        public static bool AssistRefuel
        {
            get => User.AssistRefuel;
            set
            {
                if (User.AssistRefuel != value)
                {
                    User.AssistRefuel = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Assisted Refueling = " + value, Logger.Green);
                }
            }
        }

        public static bool AssistRearm
        {
            get => User.AssistRearm;
            set
            {
                if (User.AssistRearm != value)
                {
                    User.AssistRearm = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Assisted Rearming = " + value, Logger.Green);
                }
            }
        }

        public static bool AssistRepair
        {
            get => User.AssistRepair;
            set
            {
                if (User.AssistRepair != value)
                {
                    User.AssistRepair = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Assisted Repairing = " + value, Logger.Green);
                }
            }
        }

        public static bool AssistHangerEntry
        {
            get => User.AssistHangerEntry;
            set
            {
                if (User.AssistHangerEntry != value)
                {
                    User.AssistHangerEntry = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Assisted Hanger Entry = " + value, Logger.Green);
                }
            }
        }

        public static bool PostHyperspaceSafety
        {
            get => User.PostHyperspaceSafety;
            set
            {
                if (User.PostHyperspaceSafety != value)
                {
                    User.PostHyperspaceSafety = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Post Jump Speed Safety = " + value, Logger.Green);
                }
            }
        }
        #endregion

        #region Reports
        public static bool FuelScoop
        {
            get => User.FuelScoop;
            set
            {
                if (User.FuelScoop != value)
                {
                    User.FuelScoop = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Fuel Scoop = " + value, Logger.Green);
                }
            }
        }

        public static bool FuelStatus
        {
            get => User.FuelStatus;
            set
            {
                if (User.FuelStatus != value)
                {
                    User.FuelStatus = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Fuel Status = " + value, Logger.Green);
                }
            }
        }

        public static bool MaterialCollected
        {
            get => User.MaterialCollected;
            set
            {
                if (User.MaterialCollected != value)
                {
                    User.MaterialCollected = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Material Collected = " + value, Logger.Green);
                }
            }
        }

        public static bool MaterialRefined
        {
            get => User.MaterialRefined;
            set
            {
                if (User.MaterialRefined != value)
                {
                    User.MaterialRefined = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Material Refined = " + value, Logger.Green);
                }
            }
        }

        public static bool NoFireZone
        {
            get => User.NoFireZone;
            set
            {
                if (User.NoFireZone != value)
                {
                    User.NoFireZone = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("No Fire Zone = " + value, Logger.Green);
                }
            }
        }

        public static bool StationStatus
        {
            get => User.StationStatus;
            set
            {
                if (User.StationStatus != value)
                {
                    User.StationStatus = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Station Status = " + value, Logger.Green);
                }
            }
        }

        public static bool ShieldState
        {
            get => User.ShieldState;
            set
            {
                if (User.ShieldState != value)
                {
                    User.ShieldState = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Shield States = " + value, Logger.Green);
                }
            }
        }

        public static bool CollectedBounty
        {
            get => User.CollectedBounty;
            set
            {
                if (User.CollectedBounty != value)
                {
                    User.CollectedBounty = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Collected Bounty = " + value, Logger.Green);
                }
            }
        }

        public static bool TargetEnemy
        {
            get => User.TargetEnemy;
            set
            {
                if (User.TargetEnemy != value)
                {
                    User.TargetEnemy = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Hostile Faction Target = " + value, Logger.Green);
                }
            }
        }

        public static bool TargetWanted
        {
            get => User.TargetWanted;
            set
            {
                if (User.TargetWanted != value)
                {
                    User.TargetWanted = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Wanted Target = " + value, Logger.Green);
                }
            }
        }

        public static bool Masslock
        {
            get => User.Masslock;
            set
            {
                if (User.Masslock != value)
                {
                    User.Masslock = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Masslock States = " + value, Logger.Green);
                }
            }
        }

        public static bool HighGravDescent
        {
            get => User.HighGravDescent;
            set
            {
                if (User.HighGravDescent != value)
                {
                    User.HighGravDescent = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("High Gravity Descent = " + value, Logger.Green);
                }
            }
        }

        public static bool GlideStatus
        {
            get => User.GlideStatus;
            set
            {
                if (User.GlideStatus != value)
                {
                    User.GlideStatus = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Glide Status = " + value, Logger.Green);
                }
            }
        }

        public static bool ScanTravelDist
        {
            get => User.ScanTravelDist;
            set
            {
                if (User.ScanTravelDist != value)
                {
                    User.ScanTravelDist = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Travel Distance Threshold = " + value, Logger.Green);
                }
            }
        }

        public static bool LandableVolcanism
        {
            get => User.LandableVolcanism;
            set
            {
                if (User.LandableVolcanism != value)
                {
                    User.LandableVolcanism = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Landable Volcanism = " + value, Logger.Green);
                }
            }
        }
        #endregion

        #region Exploration
        public static int ScanDistLimit
        {
            get => User.ScanDistLimit;
            set
            {
                if (User.ScanDistLimit != value)
                {
                    User.ScanDistLimit = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Travel Distance Threshold Updated", Logger.Green);
                }
            }
        }

        public static bool BodyEarthLike
        {
            get => User.BodyEarthLike;
            set
            {
                if (User.BodyEarthLike != value)
                {
                    User.BodyEarthLike = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Earthlike Worlds = " + value, Logger.Green);
                }
            }
        }

        public static bool BodyWaterTerra
        {
            get => User.BodyWaterTerra;
            set
            {
                if (User.BodyWaterTerra != value)
                {
                    User.BodyWaterTerra = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Water Worlds (Terraformable) = " + value, Logger.Green);
                }
            }
        }

        public static bool BodyHMCTerra
        {
            get => User.BodyHMCTerra;
            set
            {
                if (User.BodyHMCTerra != value)
                {
                    User.BodyHMCTerra = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("High Metal Content (Terraformable) = " + value, Logger.Green);
                }
            }
        }

        public static bool BodyAmmonia
        {
            get => User.BodyAmmonia;
            set
            {
                if (User.BodyAmmonia != value)
                {
                    User.BodyAmmonia = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Ammonia Worlds = " + value, Logger.Green);
                }
            }
        }

        public static bool BodyRockyTerra
        {
            get => User.BodyRockyTerra;
            set
            {
                if (User.BodyRockyTerra != value)
                {
                    User.BodyRockyTerra = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Rocky (Terraformable) = " + value, Logger.Green);
                }
            }
        }

        public static bool BodyWater
        {
            get => User.BodyWater;
            set
            {
                if (User.BodyWater != value)
                {
                    User.BodyWater = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Water Worlds = " + value, Logger.Green);
                }
            }
        }

        public static bool BodyMetalRich
        {
            get => User.BodyMetalRich;
            set
            {
                if (User.BodyMetalRich != value)
                {
                    User.BodyMetalRich = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Metal Rich = " + value, Logger.Green);
                }
            }
        }

        public static bool BodyGasGiantII
        {
            get => User.BodyGasGiantII;
            set
            {
                if (User.BodyGasGiantII != value)
                {
                    User.BodyGasGiantII = value;                   
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("Gas Giant II = " + value, Logger.Green);
                }
            }
        }

        public static bool BodyHMC
        {
            get => User.BodyHMC;
            set
            {
                if (User.BodyHMC != value)
                {
                    User.BodyHMC = value;                  
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("High Metal Content = " + value, Logger.Green);
                }
            }
        }
        #endregion

        //End: User Settings
        #endregion

        public static WatchUserSettingsTK Watcher = new WatchUserSettingsTK();
        private static Settings_Firegroups _Firegroup = new Settings_Firegroups();
        public static Settings_Firegroups Firegroup
        {
            get => _Firegroup;
            set
            {
                _Firegroup = value;
                MainWindow.UpdateButtons();
            }
        }
        public static object LockFlag = new object();
        public static object SaveLockFlag = new object();
        public static bool Enabled = true;
        public static string TimeStampUser = null;
        public static string TimeStampFiregroup = null;
        public static bool SaveFiregroup = true;
        public static bool SettingInit = false;
        public static readonly DirectoryInfo DirSettings = new DirectoryInfo(Paths.ALICE_Settings);

        public static List<string> Group = new List<string>()
        {
            "None",
            "Alpha",
            "Bravo",
            "Charlie",
            "Delta",
            "Echo",
            "Foxtrot",
            "Golf",
            "Hotel"
        };

        public static List<string> Fire = new List<string>()
        {
            "None",
            "Primary",
            "Secondary"
        };

        public static List<string> SCTravelTime = new List<string>()
        {
            "Unlimited",
            "1000 ls (1:00 Min)",
            "5000 ls (2:20 Min)",
            "10K ls (2:50 Min)",
            "25K ls (3:50 Min)",
            "50K ls (5:00 Min)",
            "100K ls (6:25 Min)",
            "150K ls (7:30 Min)",
            "200K ls (8:30 Min)",
            "300K ls (10:12 Min)",            
            "400K ls (11:45 Min)",            
            "500K ls (13:10 Min)",
            "600K ls (14:20 Min)",
            "700K ls (15:50 Min)",
            "800K ls (17:20 Min)",
            "900K ls (18:05 Min)",
            "1000K ls (19:25 Min)",
            "1100K ls (20:33 Min)",
            "1200K ls (21:40 Min)",
            "1300K ls (22:46 Min)",
            "1400K ls (23:51 Min)",
            "1500K ls (24:54 Min)",
            "1600K ls (25:58 Min)",
            "1700K ls (27:00 Min)",
            "1800K ls (28:00 Min)",
            "1900K ls (29:00 Min)",
            "2000K ls (30:00 Min)",
        };

        #region Support Methods / Functions
        /// <summary>
        /// Checks/Loads the Commanders User Settings if the File Exists. Else it will load the defaults and create a User Settings file.
        /// </summary>
        /// <param name="S">The Settings Object</param>
        /// <param name="CMDRName">The Commanders Name</param>
        /// <returns>Returns the Users Settings or Default if its not found</returns>
        public static Settings_User_TK Load(this Settings_User_TK S, string CMDRName, string MethodName)
        {
            //Create Default Settings
            if (S == null) { S = new Settings_User_TK(); }

            try
            {
                //Check & Load Settings
                if (File.Exists(Paths.ALICE_Settings + CMDRName + ".Settings"))
                {
                    S = (Settings_User_TK)LoadValues<Settings_User_TK>(CMDRName + ".Settings");
                    Logger.DebugLine(MethodName, CMDRName + ".Settings Loaded", Logger.Blue);
                }
                //Create New Settings File
                else
                {
                    S.Commander = CMDRName; S.Save(MethodName);
                    Logger.Log(MethodName, "Created " + CMDRName + "'s User Settings.", Logger.Purple);
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception:" + ex);
                Logger.Exception(MethodName, "Something Went Wrong Loading The Users Settings, Returned Default Settings");
            }

            //Return Settings
            return S;
        }

        /// <summary>
        /// Try To Save The User Settings. Catches, Logs and Reports Exceptions.
        /// </summary>
        public static void Save(this Settings_User_TK S, string MethodName)
        {
            if (S == null) { return; }

            try
            {
                S.TimeStamp = DateTime.UtcNow;
                SaveValues<Settings_User_TK>(S, ISettings.SettingsUser + ".Settings");
                Logger.DebugLine(MethodName, "User Settings Saved", Logger.Blue);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception:" + ex);
                Logger.Exception(MethodName, "Something Went Wrong And Settings Were Not Saved.");
            }
        }

        /// <summary>
        /// Try To Save The User Settings. Catches, Logs and Reports Exceptions.
        /// </summary>
        public static DateTime Save(this Settings_User_TK S, string MethodName, bool ReturnTime)
        {
            if (S == null) { return default(DateTime); }

            try
            {
                S.TimeStamp = DateTime.UtcNow;
                SaveValues<Settings_User_TK>(S, ISettings.SettingsUser + ".Settings");
                Logger.DebugLine(MethodName, "User Settings Saved", Logger.Blue);
                return S.TimeStamp;
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception:" + ex);
                Logger.Exception(MethodName, "Something Went Wrong And Settings Were Not Saved.");
                return default(DateTime);
            }
        }

        public static void SaveFiregroupSettings()
        {
            string MethodName = "Firegroup Settings (Save)";

            if (Monitor.TryEnter(SaveLockFlag))
            {
                Start:
                try
                {
                    if (SaveFiregroup == false) { return; }
                    SaveValues<Settings_Firegroups>(Firegroup, ISettings.SettingsFiregroup + ".FGConfig");
                    Logger.Log(MethodName, "Firegroup Settings Saved", Logger.Yellow);
                }
                catch (Exception)
                {
                    Logger.Exception(MethodName, "Couldn't Access The File, Trying Again...");
                    Thread.Sleep(100); goto Start;
                }
                finally
                {
                    Monitor.Exit(SaveLockFlag);
                }
            }
        }

        public static void LoadFiregroupSettings()
        {
            string MethodName = "Firegroup Settings (Load)";

            Firegroup = (Settings_Firegroups)LoadValues<Settings_Firegroups>(ISettings.SettingsFiregroup + ".FGConfig");
            Logger.Log(MethodName, "Firegroup Settings Loaded", Logger.Yellow);
        }

        public static SolidColorBrush GetTextColor(bool Value)
        {
            SolidColorBrush Brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            if (Value) { Brush = new SolidColorBrush(Color.FromRgb(0, 255, 0)); }

            return Brush;
        }

        public static SolidColorBrush GetFGLabelColor(int A, int B)
        {
            //Default Color Red
            SolidColorBrush Brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            //Return Yellow
            if ((A == 0 && B != 0) || (A != 0 && B == 0))
            {
                Brush = new SolidColorBrush(Color.FromRgb(212, 230, 30));
            }            
            //Return Green
            else if (A != 0 && B != 0)
            {
                Brush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
            
            //Return Color
            return Brush;
        }

        public static void SaveValues<T>(object Settings, string FileName, string FilePath = null)
        {
            string MethodName = "(Toolkit) Save Values";

            try
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
            catch (Exception)
            {
                Logger.Exception(MethodName, "Couldn't Access The File, Trying Again...");
            }
        }

        public static object LoadValues<T>(string FileName, string FilePath = null)
        {
            string MethodName = "(Toolkit) Load Values";

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
                            Logger.Log(MethodName, "Loaded Settings", Logger.Yellow);
                        }
                    }
                }

                return Temp;
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception" + ex);
                Logger.Exception(MethodName, "Somthing Went Wrong While Loading Values");
                return Temp;
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }

        public static void StartMonitor()
        {
            string MethodName = "(Toolkit) Monitor";
            Thread thread =
            new Thread((ThreadStart)(() =>
            {
                try
                {
                    if (Monitor.TryEnter(LockFlag))
                    {
                        while (Enabled)
                        {
                            Thread.Sleep(1000);

                            //if (CheckSettings(ISettings.SettingsUser + ".Settings"))
                            //{
                            //    LoadUserSettings();
                            //    MainWindow.UpdateButtons();
                            //}

                            if (CheckSettings(ISettings.SettingsFiregroup + ".FGConfig"))
                            {
                                LoadFiregroupSettings();
                                MainWindow.UpdateButtons();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception" + ex);
                    Logger.Exception(MethodName, "Somthing Went Wrong With The Monitor");
                }
                finally
                {
                    Monitor.Exit(LockFlag);
                }
            }))
            { IsBackground = true }; thread.Start();
        }

        public static bool CheckSettings(string FileName)
        {
            string MethodName = "(Toolkit) Check Settings";
            string TimeStamp = null; switch (FileName)
            {
                case "CurrentUser.Settings":
                    TimeStamp = TimeStampUser;
                    break;
                case "CurrentFiregroup.FGConfig":
                    TimeStamp = TimeStampFiregroup;
                    break;
                default:
                    Logger.Log(MethodName, "File Name Does Not Match Expected Options.", Logger.Yellow);
                    return false;
            }

            try
            {
                foreach (FileInfo File in DirSettings.EnumerateFiles(FileName, SearchOption.TopDirectoryOnly))
                {
                    if (TimeStamp == null || TimeStamp != File.LastWriteTime.ToString())
                    {
                        switch (FileName)
                        {
                            case "CurrentUser.Settings":
                                TimeStampUser = File.LastWriteTime.ToString();
                                break;
                            case "CurrentFiregroup.FGConfig":
                                TimeStampFiregroup = File.LastWriteTime.ToString();
                                break;
                        }
                        Logger.Log(MethodName, "Settings Update Detected", Logger.Yellow);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception" + ex);
                Logger.Exception(MethodName, "We Encountered An Error While Checking The Settings File");
                return false;
            }
        }
        #endregion

        public class WatchUserSettingsTK : Base
        {
            public WatchUserSettingsTK()
            {
                Enabled = true;
                LockFlag = new object();
                MethodName = "Settings Monitor";
                Log = true;
                UpdateNumber = 0;
                TimeStamp = "None";
            }

            public void Watch()
            {
                string MethodName = "Watcher (Settings)";

                Thread thread =
                new Thread((ThreadStart)(() =>
                {
                    try
                    {
                        if (CheckSettings(ISettings.SettingsUser + ".Settings"))
                        {
                            Data.UserSettingsLoad(true);
                        }
                        if (Monitor.TryEnter(LockFlag))
                        {
                            while (Enabled)
                            {
                                Thread.Sleep(1000);

                                //Check If Settings Need Saved
                                if (Data.UserSettingsSave)
                                {
                                    //Reset Save Tracker
                                    UserSettingsSave = false;

                                    //Logger
                                    Logger.Log(MethodName, "Saving User Settings", Logger.Yellow);

                                    //Save Settings & Update Timestamp
                                    Save(User, MethodName);
                                }

                                //Check File Timestamp
                                if (CheckSettings(ISettings.SettingsUser + ".Settings"))
                                {
                                    //Disable Saving
                                    UserSettingsUpdating = true;

                                    //Load Settings
                                    User = Load(User, ISettings.SettingsUser, MethodName);

                                    //Enable Saving
                                    UserSettingsUpdating = false;

                                    //Update UI Buttons
                                    MainWindow.UpdateButtons();
                                }
                            }

                            Logger.Log(MethodName, "Stopped Watching...", Logger.Yellow);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(MethodName, "Exception " + ex);
                        Logger.Exception(MethodName, "Something Went Wrong With The Settings Watcher...");
                    }
                    finally
                    {
                        Monitor.Exit(LockFlag);
                    }
                }))
                { IsBackground = true }; thread.Start();
            }
        }

        public class Base
        {
            public bool Enabled { get; set; }
            public object LockFlag { get; set; }
            public string MethodName { get; set; }
            public bool Log { get; set; }
            public decimal UpdateNumber { get; set; }
            public string TimeStamp { get; set; }
            public string SettingsFile { get; set; }

            public bool CheckSettings(string FileName)
            {
                try
                {
                    foreach (FileInfo Settings in DirSettings.EnumerateFiles(FileName, SearchOption.TopDirectoryOnly))
                    {
                        if (TimeStamp == null || TimeStamp != Settings.LastWriteTime.ToString())
                        {
                            TimeStamp = Settings.LastWriteTime.ToString();
                            return true;
                        }
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "Something Went Wrong While Checking The Settings File...");
                    return false;
                }
            }
        }
    }

    public static class Paths
    {
        #region File Names
        public static readonly string ALICE_BindsFile = "A.L.I.C.E Profile.3.0.binds";
        public static readonly string FILE_AliceManual = "Project A.L.I.C.E.pdf";
        #endregion

        #region Folder Names
        public static readonly string Folder_Default = @"\Default";
        #endregion

        #region Folder Paths
        public static readonly string ToolKitLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static readonly string Binds_Location = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Local\Frontier Developments\Elite Dangerous\Options\Bindings\");
        public static readonly string ALICE_Audio_Files = ToolKitLocation + @"\A.L.I.C.E Audio Files\";
        public static readonly string ALICE_Resources = ToolKitLocation + @"\A.L.I.C.E Resources\";
        public static readonly string ALICE_Response = ToolKitLocation + @"\A.L.I.C.E Response\";
        public static readonly string ALICE_ResponseUser = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Responses\";
        public static readonly string ALICE_Log_Files = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Log Files\";
        public static readonly string ALICE_Settings = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Settings\";
        public static readonly string ALICE_SystemData = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Systems\";
        public static readonly string ALICE_RootFolder = ToolKitLocation + @"\";
        #endregion

        #region File Paths  
        public static readonly string ALICE_BindsPath = Binds_Location + ALICE_BindsFile;
        public static readonly string ALICE_ManualPath = ALICE_RootFolder + FILE_AliceManual;
        #endregion

        #region Methods / Functions
        public static string ShowBinds(string path = "")
        {
            WinForms.OpenFileDialog dialog = new WinForms.OpenFileDialog
            {
                DefaultExt = ".binds",
                Filter = "Binds (*.binds)|*.binds",
                FilterIndex = 2,
                InitialDirectory = Paths.Binds_Location
            };
            if (dialog.ShowDialog() == WinForms.DialogResult.OK)
            {
                path = dialog.FileName;
            }
            return path;
        }

        public static void CreateDir()
        {
            try
            {
                Directory.CreateDirectory(Paths.ALICE_Settings);
                Directory.CreateDirectory(Paths.ALICE_Response);
                Directory.CreateDirectory(Paths.ALICE_ResponseUser);
                Directory.CreateDirectory(Paths.ALICE_Log_Files);
                Directory.CreateDirectory(Paths.ALICE_Settings);
                Directory.CreateDirectory(Paths.ALICE_SystemData);
            }
            catch (Exception) { }
        }
        #endregion

        #region Known Folder Paths

        /// <summary>
        /// Class containing methods to retrieve specific file system paths.
        /// </summary>
        public static class KnownFolders
        {
            private static string[] _knownFolderGuids = new string[]
            {
                "{56784854-C6CB-462B-8169-88E350ACB882}", // Contacts
                "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", // Desktop
                "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}", // Documents
                "{374DE290-123F-4565-9164-39C4925E467B}", // Downloads
                "{1777F761-68AD-4D8A-87BD-30B759FA33DD}", // Favorites
                "{BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968}", // Links
                "{4BD8D571-6D19-48D3-BE97-422220080E43}", // Music
                "{33E28130-4E1E-4676-835A-98395C3BC3BB}", // Pictures
                "{4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4}", // SavedGames
                "{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}", // SavedSearches
                "{18989B1D-99B5-455B-841C-AB7C74E4DDFC}", // Videos
            };

            /// <summary>
            /// Gets the current path to the specified known folder as currently configured. This does
            /// not require the folder to be existent.
            /// </summary>
            /// <param name="knownFolder">The known folder which current path will be returned.</param>
            /// <returns>The default path of the known folder.</returns>
            /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path
            ///     could not be retrieved.</exception>
            public static string GetPath(KnownFolder knownFolder)
            {
                return GetPath(knownFolder, false);
            }

            /// <summary>
            /// Gets the current path to the specified known folder as currently configured. This does
            /// not require the folder to be existent.
            /// </summary>
            /// <param name="knownFolder">The known folder which current path will be returned.</param>
            /// <param name="defaultUser">Specifies if the paths of the default user (user profile
            ///     template) will be used. This requires administrative rights.</param>
            /// <returns>The default path of the known folder.</returns>
            /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path
            ///     could not be retrieved.</exception>
            public static string GetPath(KnownFolder knownFolder, bool defaultUser)
            {
                return GetPath(knownFolder, KnownFolderFlags.DontVerify, defaultUser);
            }

            private static string GetPath(KnownFolder knownFolder, KnownFolderFlags flags,
                bool defaultUser)
            {
                int result = SHGetKnownFolderPath(new Guid(_knownFolderGuids[(int)knownFolder]),
                    (uint)flags, new IntPtr(defaultUser ? -1 : 0), out IntPtr outPath);
                if (result >= 0)
                {
                    return Marshal.PtrToStringUni(outPath);
                }
                else
                {
                    throw new ExternalException("Unable to retrieve the known folder path. It may not "
                        + "be available on this system.", result);
                }
            }

            [DllImport("Shell32.dll")]
            private static extern int SHGetKnownFolderPath(
                [MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken,
                out IntPtr ppszPath);

            [Flags]
            private enum KnownFolderFlags : uint
            {
                SimpleIDList = 0x00000100,
                NotParentRelative = 0x00000200,
                DefaultPath = 0x00000400,
                Init = 0x00000800,
                NoAlias = 0x00001000,
                DontUnexpand = 0x00002000,
                DontVerify = 0x00004000,
                Create = 0x00008000,
                NoAppcontainerRedirection = 0x00010000,
                AliasOnly = 0x80000000
            }
        }

        /// <summary>
        /// Standard folders registered with the system. These folders are installed with Windows Vista
        /// and later operating systems, and a computer will have only folders appropriate to it
        /// installed.
        /// </summary>
        public enum KnownFolder
        {
            Contacts,
            Desktop,
            Documents,
            Downloads,
            Favorites,
            Links,
            Music,
            Pictures,
            SavedGames,
            SavedSearches,
            Videos
        }
        #endregion
    }

    /// <summary>
    /// This is a collection of the users settings from various parts of the Core Files.
    /// These settings are controlled completely by the user and have no source from the game.
    /// </summary>
    public class Settings_User_TK
    {
        public DateTime TimeStamp { get; set; }

        public string Commander = "Default";

        #region Plugin
        public int OffsetPanels { get; set; }
        public int OffsetPips { get; set; }
        public int OffsetFireGroups { get; set; }
        public int OffsetThrottle { get; set; }
        #endregion

        #region Orders
        public bool WeaponSafety { get; set; }
        public bool CombatPower { get; set; }
        public bool AssistSystemScan { get; set; }
        public bool AssistDocking { get; set; }
        public bool AssistRefuel { get; set; }
        public bool AssistRearm { get; set; }
        public bool AssistRepair { get; set; }
        public bool AssistHangerEntry { get; set; }
        public bool PostHyperspaceSafety { get; set; }
        #endregion

        #region Reports
        public bool FuelScoop { get; set; }
        public bool FuelStatus { get; set; }
        public bool MaterialCollected { get; set; }
        public bool MaterialRefined { get; set; }
        public bool NoFireZone { get; set; }
        public bool StationStatus { get; set; }
        public bool ShieldState { get; set; }
        public bool CollectedBounty { get; set; }
        public bool TargetEnemy { get; set; }
        public bool TargetWanted { get; set; }
        public bool Masslock { get; set; }
        public bool HighGravDescent { get; set; }
        public bool GlideStatus { get; set; }
        public bool ScanTravelDist { get; set; }
        public bool LandableVolcanism { get; set; }
        #endregion

        #region Exploration
        public int ScanDistLimit { get; set; }
        public bool BodyEarthLike { get; set; }
        public bool BodyWaterTerra { get; set; }
        public bool BodyHMCTerra { get; set; }
        public bool BodyAmmonia { get; set; }
        public bool BodyRockyTerra { get; set; }
        public bool BodyWater { get; set; }
        public bool BodyMetalRich { get; set; }
        public bool BodyGasGiantII { get; set; }
        public bool BodyHMC { get; set; }
        #endregion

        public Settings_User_TK()
        {
            Commander = "Default";
            OffsetFireGroups = 0;
            OffsetPanels = 0;
            OffsetPips = 0;
            OffsetThrottle = 0;

            WeaponSafety = true;
            CombatPower = true;
            PostHyperspaceSafety = true;

            FuelScoop = true;
            FuelStatus = true;
            MaterialCollected = true;
            MaterialRefined = true;
            NoFireZone = true;
            StationStatus = true;
            ShieldState = true;
            CollectedBounty = true;
            TargetEnemy = true;
            TargetWanted = true;
            Masslock = true;
            HighGravDescent = true;
            GlideStatus = true;
            ScanTravelDist = true;
            LandableVolcanism = true;

            ScanDistLimit = 0;
            BodyAmmonia = true;
            BodyEarthLike = true;
            BodyHMCTerra = true;
            BodyMetalRich = true;
            BodyRockyTerra = true;
            BodyWater = true;
            BodyWaterTerra = true;
        }
    }
}
