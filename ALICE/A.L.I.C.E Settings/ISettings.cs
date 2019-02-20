
using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

namespace ALICE_Settings
{
    public static class ISettings
    {
        #region User Settings        
        private static Settings_User User = Load(User, ISettings.SettingsUser, "Initialize");
        private static Settings_User RefUser = Load(RefUser, ISettings.SettingsUser, "Initialize");

        public static bool UserSettingsSave = false;
        public static bool UserSettingsUpdating = false;
        public static void UserSettingsLoad(bool UpdateRef = false)
        {
            string MethodName = "Load User Settings";

            User = ISettings.Load(User, ISettings.SettingsUser, MethodName);
            if (UpdateRef) { RefUser = ISettings.Load(RefUser, ISettings.SettingsUser, MethodName); }
        }
        public static void UserSettingsCompare(Settings_User S)
        {
            string MethodName = "User Settings (Compare)";

            if (RefUser == null) { RefUser = ISettings.Load(RefUser, ISettings.SettingsUser, MethodName); }
            if (User == null) { User = ISettings.Load(User, ISettings.SettingsUser, MethodName); }

            try
            {
                if (IEvents.TriggerEvents)
                {
                    #region Orders
                    if (User.WeaponSafety != RefUser.WeaponSafety)
                    {
                        Order_Update(RefUser.WeaponSafety, User.WeaponSafety, "Weapon Safety Interlocks");
                    }

                    if (User.CombatPower != RefUser.CombatPower)
                    {
                        Order_Update(RefUser.CombatPower, User.CombatPower, "Combat Power Management");
                    }

                    if (User.AssistSystemScan != RefUser.AssistSystemScan)
                    {
                        Order_Update(RefUser.AssistSystemScan, User.AssistSystemScan, "Assisted System Scans");
                    }

                    if (User.AssistDocking != RefUser.AssistDocking)
                    {
                        Order_Update(RefUser.AssistDocking, User.AssistDocking, "Assisted Docking Procedures");
                    }

                    if (User.AssistHangerEntry != RefUser.AssistHangerEntry)
                    {
                        Order_Update(RefUser.AssistHangerEntry, User.AssistHangerEntry, "Assisted Hanger Entry");
                    }

                    if (User.PostHyperspaceSafety != RefUser.PostHyperspaceSafety)
                    {
                        Order_Update(RefUser.PostHyperspaceSafety, User.PostHyperspaceSafety, "Post Jump Safeties");
                    }
                    #endregion

                    #region Reports
                    if (User.FuelScoop != RefUser.FuelScoop)
                    {
                        Report_Update(RefUser.FuelScoop, User.FuelScoop, "Fuel Scooping");
                    }

                    if (User.FuelStatus != RefUser.FuelStatus)
                    {
                        Report_Update(RefUser.FuelStatus, User.FuelStatus, "Fuel Status");
                    }

                    if (User.MaterialCollected != RefUser.MaterialCollected)
                    {
                        Report_Update(RefUser.MaterialCollected, User.MaterialCollected, "Collected Material");
                    }

                    if (User.MaterialRefined != RefUser.MaterialRefined)
                    {
                        Report_Update(RefUser.MaterialRefined, User.MaterialRefined, "Refined Material");
                    }

                    if (User.NoFireZone != RefUser.NoFireZone)
                    {
                        Report_Update(RefUser.NoFireZone, User.NoFireZone, "No Fire Zone");
                    }

                    if (User.StationStatus != RefUser.StationStatus)
                    {
                        Report_Update(RefUser.StationStatus, User.StationStatus, "Station Status");
                    }

                    if (User.ShieldState != RefUser.ShieldState)
                    {
                        Report_Update(RefUser.ShieldState, User.ShieldState, "Shield State");
                    }

                    if (User.CollectedBounty != RefUser.CollectedBounty)
                    {
                        Report_Update(RefUser.CollectedBounty, User.CollectedBounty, "Collected Bounty");
                    }

                    if (User.TargetEnemy != RefUser.TargetEnemy)
                    {
                        Report_Update(RefUser.TargetEnemy, User.TargetEnemy, "Hostile Faction");
                    }

                    if (User.Masslock != RefUser.Masslock)
                    {
                        Report_Update(RefUser.Masslock, User.Masslock, "Masslock");
                    }

                    if (User.HighGravDescent != RefUser.HighGravDescent)
                    {
                        Report_Update(RefUser.HighGravDescent, User.HighGravDescent, "High Gravity Descent");
                    }

                    if (User.GlideStatus != RefUser.GlideStatus)
                    {
                        Report_Update(RefUser.GlideStatus, User.GlideStatus, "Glide Status");
                    }

                    if (User.ScanTravelDist != RefUser.ScanTravelDist)
                    {
                        Report_Update(RefUser.ScanTravelDist, User.ScanTravelDist, "Travel Distance Threshold");
                    }

                    if (User.LandableVolcanism != RefUser.LandableVolcanism)
                    {
                        Report_Update(RefUser.LandableVolcanism, User.LandableVolcanism, "Landable Volcanism");
                    }
                    #endregion
                }
            }
            catch (NullReferenceException ex)
            {
                Logger.Exception(MethodName, "Null Reference Exception: " + ex);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
            }
            
            RefUser = Load(RefUser, ISettings.SettingsUser, MethodName, false);
        }

        //Updated Via U_Commander Method
        public static string Commander
        {
            get => User.Commander;
            set
            {
                if (User.Commander != value)
                {
                    User.Commander = value;
                    RefUser.Commander = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.OffsetPanels = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.OffsetPips = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.OffsetFireGroups = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.OffsetThrottle = value;
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.WeaponSafety = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.CombatPower = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.AssistSystemScan = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.AssistDocking = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.AssistRefuel = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.AssistRearm = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.AssistRepair = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.AssistHangerEntry = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.PostHyperspaceSafety = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.FuelScoop = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.FuelStatus = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.MaterialCollected = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.MaterialRefined = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.NoFireZone = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.StationStatus = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.ShieldState = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.CollectedBounty = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.TargetEnemy = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.TargetWanted = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.Masslock = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.HighGravDescent = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.GlideStatus = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.ScanTravelDist = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.LandableVolcanism = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.ScanDistLimit = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.BodyEarthLike = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.BodyWaterTerra = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.BodyHMCTerra = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.BodyAmmonia = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.BodyRockyTerra = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.BodyWater = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.BodyMetalRich = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.BodyGasGiantII = value;
                    if (IEvents.TriggerEvents == false) { return; }
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
                    RefUser.BodyHMC = value;
                    if (IEvents.TriggerEvents == false) { return; }
                    if (UserSettingsUpdating == false) { UserSettingsSave = true; }
                    Logger.Simple("High Metal Content = " + value, Logger.Green);
                }
            }
        }
        #endregion

        #region Update Methods

        #region PlugIn
        /// <summary>
        /// Increase or Decrease the Pip Speed by 25ms 
        /// </summary>
        /// <param name="Increase">True = Increase & False = Decrease</param>
        public static void PipSpeed(bool Increase)
        {
            string MethodName = "Pip Offset";

            if (Increase == true)
            {
                OffsetPips = OffsetPips + 25;
            }
            else if (Increase == false)
            {
                OffsetPips = OffsetPips - 25;
                if (OffsetPips < 0) { OffsetPips = 0; }
            }

            Logger.DebugLine(MethodName, "Offset = " + OffsetPips, Logger.Purple);
        }

        /// <summary>
        /// Increase or Decrease the Panel Speed by 25ms 
        /// </summary>
        /// <param name="Increase">True = Increase & False = Decrease</param>
        public static void PanelSpeed(bool Increase)
        {
            string MethodName = "Panel Offset";

            if (Increase == true)
            {
                OffsetPanels = OffsetPanels + 25;
            }
            else if (Increase == false)
            {
                OffsetPanels = OffsetPanels - 25;
                if (OffsetPanels < 0) { OffsetPanels = 0; }
            }

            Logger.DebugLine(MethodName, "Offset = " + OffsetPanels, Logger.Purple);
        }

        /// <summary>
        /// Increase or Decrease the Fire Group Speed by 25ms 
        /// </summary>
        /// <param name="Increase">True = Increase & False = Decrease</param>
        public static void FireGroupSpeed(bool Increase)
        {
            string MethodName = "Fire Group Offset";

            if (Increase == true)
            {
                OffsetFireGroups = OffsetFireGroups + 25;
            }
            else if (Increase == false)
            {
                OffsetFireGroups = OffsetFireGroups - 25;
                if (OffsetFireGroups < 0) { OffsetFireGroups = 0; }
            }

            Logger.DebugLine(MethodName, "Offset = " + OffsetFireGroups, Logger.Purple);
        }

        /// <summary>
        /// Increase or Decrease the Pip Speed by 25ms 
        /// </summary>
        /// <param name="Increase">True = Increase & False = Decrease</param>
        public static void ThrottleSpeed(bool Increase)
        {
            string MethodName = "Throttle Speed";

            if (Increase == true)
            {
                OffsetThrottle = OffsetThrottle + 25;
            }
            else if (Increase == false)
            {
                OffsetThrottle = OffsetThrottle - 25;
                if (OffsetThrottle < 0) { OffsetThrottle = 0; }
            }

            Logger.DebugLine(MethodName, "Offset = " + OffsetThrottle, Logger.Purple);
        }
        #endregion

        #region Orders
        public static bool Order_Update(bool CurrentState, bool NewState, string ItemName)
        {
            if (CurrentState == true)
            {
                if (NewState == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Order_Updated.Currently_Enabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else if (NewState == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Order_Updated.Disabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
            else if (CurrentState == false)
            {
                if (NewState == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Order_Updated.Enabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else if (NewState == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Order_Updated.Currently_Disabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
            return NewState;
        }

        public static void U_AutoSystemScans(bool State)
        {
            string Item = "Assisted System Scans";
            AssistSystemScan = Order_Update(AssistSystemScan, State, Item);
        }

        public static void U_AutoDockingProcedure(bool State)
        {
            string Item = "Assisted Docking Procedures";
            AssistDocking = Order_Update(AssistDocking, State, Item);
        }

        public static void U_AutoRefuel(bool State)
        {
            string Item = "Assisted Station Refueling";
            AssistRefuel = Order_Update(AssistRefuel, State, Item);
        }

        public static void U_AutoRearm(bool State)
        {
            string Item = "Assisted Station Rearming";
            AssistRearm = Order_Update(AssistRearm, State, Item);
        }

        public static void U_AutoRepair(bool State)
        {
            string Item = "Assisted Station Repairing";
            AssistRepair = Order_Update(AssistRepair, State, Item);
        }

        public static void U_AutoHangerEntry(bool State)
        {
            string Item = "Assisted Hanger Entry";
            AssistHangerEntry = Order_Update(AssistHangerEntry, State, Item);
        }

        public static void U_CombatPower(bool State)
        {
            string Item = "Combat Power Management";
            CombatPower = Order_Update(CombatPower, State, Item);
        }

        public static void U_PostJumpSafety(bool State)
        {
            string Item = "Post Jump Safeties";
            PostHyperspaceSafety = Order_Update(PostHyperspaceSafety, State, Item);
        }

        public static void U_WeaponSafety(bool State)
        {
            string Item = "Weapon Safety Interlocks";
            WeaponSafety = Order_Update(WeaponSafety, State, Item);
        }
        #endregion

        #region Reports
        public static bool Report_Update(bool CurrentState, bool NewState, string ItemName)
        {
            if (CurrentState == true)
            {
                if (NewState == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Report_Updated.Currently_Enabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else if (NewState == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Report_Updated.Disabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
            else if (CurrentState == false)
            {
                if (NewState == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Report_Updated.Enabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else if (NewState == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Report_Updated.Currently_Disabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }

            return NewState;
        }

        public static void U_FuelScoop(bool State)
        {
            string Item = "Fuel Scooping";
            FuelScoop = Report_Update(FuelScoop, State, Item);
        }

        public static void U_FuelStatus(bool State)
        {
            string Item = "Fuel Status";
            FuelStatus = Report_Update(FuelStatus, State, Item);
        }

        public static void U_MaterialCollected(bool State)
        {
            string Item = "Material Collection";
            MaterialCollected = Report_Update(MaterialCollected, State, Item);
        }

        public static void U_MaterialRefined(bool State)
        {
            string Item = "Material Refining";
            MaterialRefined = Report_Update(MaterialRefined, State, Item);
        }

        public static void U_NoFireZone(bool State)
        {
            string Item = "No Fire Zone";
            NoFireZone = Report_Update(NoFireZone, State, Item);
        }

        public static void U_StationStatus(bool State)
        {
            string Item = "Station Status";
            StationStatus = Report_Update(StationStatus, State, Item);
        }

        public static void U_ShieldState(bool State)
        {
            string Item = "Shield State";
            ShieldState = Report_Update(ShieldState, State, Item);
        }

        public static void U_CollectedBounty(bool State)
        {
            string Item = "Target Bounty";
            CollectedBounty = Report_Update(CollectedBounty, State, Item);
        }

        public static void U_TargetEnemy(bool State)
        {
            string Item = "Enemy Faction";
            TargetEnemy = Report_Update(TargetEnemy, State, Item);
        }

        public static void U_TargetWanted(bool State)
        {
            string Item = "Wanted Target";
            TargetWanted = Report_Update(TargetWanted, State, Item);
        }

        public static void U_Masslock(bool State)
        {
            string Item = "Masslock";
            Masslock = Report_Update(Masslock, State, Item);
        }

        public static void U_GlideStatus(bool State)
        {
            string Item = "Glide Status";
            GlideStatus = Report_Update(GlideStatus, State, Item);
        }

        public static void U_HighGravDescent(bool State)
        {
            string Item = "High Gravity Descent";
            HighGravDescent = Report_Update(HighGravDescent, State, Item);
        }

        public static void U_LandableVolcanism(bool State)
        {
            string Item = "Landable Volcanism";
            LandableVolcanism = Report_Update(LandableVolcanism, State, Item);
        }

        public static void U_ScanTravelDist(bool State)
        {
            string Item = "Travel Distance Threshold";
            ScanTravelDist = Report_Update(ScanTravelDist, State, Item);
        }
        #endregion

        #region Navigation
        /// <summary>
        /// Will Update the Scan Distance Limit setting.
        /// </summary>
        /// <param name="D">New Distance Limit In LS</param>
        public static void U_ScanDistLimit(int D)
        {
            string MethodName = "Update Scan Distance Limit";

            if (D != ScanDistLimit)
            {
                ScanDistLimit = D;
            }
        }

        public static void U_BodyAmmonia(bool V)
        {
            string MethodName = "Update Ammonia";

            BodyAmmonia = V;
        }

        public static void U_BodyEarthLike(bool V)
        {
            string MethodName = "Update Earthlike";

            BodyEarthLike = V;
        }

        public static void U_BodyGasGiantII(bool V)
        {
            string MethodName = "Update Gas Giant II";

            BodyGasGiantII = V;
        }

        public static void U_BodyHMC(bool V)
        {
            string MethodName = "Update High Metal Content";

            BodyHMC = V;
        }

        public static void U_BodyHMCTerra(bool V)
        {
            string MethodName = "Update High Metal Content (Terraformable)";

            BodyHMCTerra = V;
        }

        public static void U_BodyMetalRich(bool V)
        {
            string MethodName = "Update Metal Rich World";

            BodyMetalRich = V;
        }

        public static void U_BodyRockyTerra(bool V)
        {
            string MethodName = "Update Rocky Body (Terraformable)";

            BodyRockyTerra = V;
        }

        public static void U_BodyWater(bool V)
        {
            string MethodName = "Update Water World";

            BodyWater = V;
        }

        public static void U_BodyWaterTerra(bool V)
        {
            string MethodName = "Update Water World (Terraformable)";

            BodyWaterTerra = V;
        }
        #endregion

        #endregion

        //End: User Settings
        #endregion

        private static DirectoryInfo DirSettings = new DirectoryInfo(Paths.ALICE_Settings);         

        public static readonly string SettingsUser = "CurrentUser";
        public static readonly string SettingsFiregroup = "CurrentFiregroup";

        public static string MothershipFingerPrint { get; set; }

        public static Settings_PlugIn Plugin = new Settings_PlugIn();

        public static WatchUserSettings Watcher = new WatchUserSettings();
        public static Settings_Firegroups Firegroup = new Settings_Firegroups();

        #region Miscellaneous
        public static bool LogAllBodies = true;
        #endregion

        #region Propery Updates
        /// <summary>
        /// Updates the Commander Property for ISettings and any Subsettings being handled by ISettings.
        /// </summary>
        /// <param name="CMDRName">The Commanders Name</param>
        public static void U_Commander(string MethodName, string CMDRName)
        {
            //Try Loading Commanders Settings
            User = User.Load(CMDRName, MethodName);

            //Check Settings Arn't Null
            if (User == null) { User = new Settings_User(); }

            //Will Update Name If Default Is Returned
            Commander = CMDRName;
        }

        /// <summary>
        /// Updates The MothershipFingerPrint Property for ISettings and any Subsettings being handled by ISettings.
        /// </summary>
        /// <param name="FingerPrint">The New Finger Print</param>
        public static void U_MothershipFingerPrint(string MethodName, string FingerPrint)
        {
            //Update Property
            ISettings.MothershipFingerPrint = FingerPrint;
            ISettings.Firegroup = ISettings.Firegroup.Load();
            ISettings.Firegroup.Save(MethodName);
        }
        #endregion

        #region Save/Load Methods
        /// <summary>
        /// Checks/Loads the Commanders User Settings if the File Exists. Else it will load the defaults and create a User Settings file.
        /// </summary>
        /// <param name="S">The Settings Object</param>
        /// <param name="CMDRName">The Commanders Name</param>
        /// <returns>Returns the Users Settings or Default if its not found</returns>
        public static Settings_User Load(this Settings_User S, string CMDRName, string MethodName, bool Logging = true)
        {
            //Create Default Settings
            if (S == null) { S = new Settings_User(); }

            try
            {
                //Check & Load Settings
                if (File.Exists(Paths.ALICE_Settings + CMDRName + ".Settings"))
                {
                    S = (Settings_User)LoadValues<Settings_User>(CMDRName + ".Settings");
                    if (Logging) { Logger.DebugLine(MethodName, CMDRName + ".Settings Loaded", Logger.Blue); }                    
                }
                //Create New Settings File
                else
                {
                    S.Commander = CMDRName; S.Save(MethodName);
                    if (Logging) { Logger.Log(MethodName, "Created " + CMDRName + "'s User Settings.", Logger.Purple); }
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
        public static void Save(this Settings_User S, string MethodName)
        {
            if (S == null) { return; }

            try
            {
                S.TimeStamp = DateTime.UtcNow;
                if (S.Commander != "CurrentUser") { ISettings.SaveValues<Settings_User>(S, S.Commander + ".Settings"); }
                ISettings.SaveValues<Settings_User>(S, SettingsUser + ".Settings");
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
        public static void SaveUserOnly(this Settings_User S, string MethodName)
        {
            if (S == null) { return; }

            try
            {
                S.TimeStamp = User.TimeStamp;
                if (S.Commander != "CurrentUser") { ISettings.SaveValues<Settings_User>(S, S.Commander + ".Settings"); }                
                Logger.DebugLine(MethodName, S.Commander + " Settings Updated", Logger.Blue);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception:" + ex);
                Logger.Exception(MethodName, "Something Went Wrong And Settings Were Not Saved.");
                return;
            }
        }

        /// <summary>
        /// Checks/Loads the Motherships Firegroup Configuration if the File Exist. Else it will load the defaults and create a new File.
        /// </summary>
        /// <param name="S">The Settings Object</param>
        /// <returns>Returns the Ships Settings or Default if its not found</returns>
        public static Settings_Firegroups Load(this Settings_Firegroups S)
        {
            string MethodName = "Firegroup Settings (Load)";
            string FileName = MothershipFingerPrint + ".FGConfig";

            //Create Default Settings
            if (S == null) { S = new Settings_Firegroups(); } 

            try
            {
                //Check & Load Settings
                if (File.Exists(Paths.ALICE_Settings + FileName))
                {
                    S = (Settings_Firegroups)LoadValues<Settings_Firegroups>(FileName);
                }
                //Create New Settings File
                else
                {
                    ISettings.Firegroup.ShipAssignment = MothershipFingerPrint; ISettings.Firegroup.Save(MethodName);
                    Logger.Log(MethodName, "Created " + MothershipFingerPrint + "'s Firegroup Settings.", Logger.Purple);
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception:" + ex);
                Logger.Exception(MethodName, "Something Went Wrong Loading The Firegroup Settings, Returned Default Settings");
            }

            //Return Settings
            return S;
        }

        /// <summary>
        /// Try To Save The Ships Firegroup Settings. Catches, Logs and Reports Exceptions.
        /// </summary>
        public static void Save(this Settings_Firegroups S, string MethodName)
        {
            try
            {
                ISettings.SaveValues<Settings_Firegroups>(S, S.ShipAssignment + ".FGConfig");
                ISettings.SaveValues<Settings_Firegroups>(S, SettingsFiregroup + ".FGConfig");
                Logger.DebugLine(MethodName, "Firegroup Settings Saved", Logger.Blue);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception:" + ex);
                Logger.Exception(MethodName, "Something Went Wrong And Firegroup Settings Were Not Saved.");
            }
        }
        #endregion

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

        public class Settings_PlugIn
        {
            public LoggingSettings Log = new LoggingSettings();
            public DebugSettings Debug = new DebugSettings();

            public class DebugSettings
            {
                public bool Responses { get; set; }
                public bool Keypress { get; set; }
                public bool Commands { get; set; }
                public bool Actions { get; set; }

                public DebugSettings()
                {
                    Responses = false;
                    Keypress = false;
                    Commands = false;
                    Actions = false;
                }
            }

            public class LoggingSettings
            {
                public bool Extended { get; set; }
                public bool Debug { get; set; }
                public bool Developer { get; set; }

                public LoggingSettings()
                {
                    Extended = true;
                    Developer = false;
                    Debug = false;
                }
            }
        }

        public class WatchUserSettings : Base
        {
            public WatchUserSettings()
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
                            ISettings.UserSettingsLoad(true);
                        }

                        if (Monitor.TryEnter(LockFlag))
                        {
                            while (Enabled)
                            {
                                Thread.Sleep(1000);

                                //Check If Settings Need Saved
                                if (UserSettingsSave)
                                {
                                    //Reset Save Tracker
                                    UserSettingsSave = false;

                                    //Save Settings & Update Timestamp
                                    ISettings.Save(User, MethodName);
                                }

                                //Check File Timestamp
                                if (CheckSettings(ISettings.SettingsUser + ".Settings"))
                                {
                                    //Disable Saving
                                    UserSettingsUpdating = true;

                                    //Load Settings
                                    User = ISettings.Load(User, ISettings.SettingsUser, MethodName);                                 

                                    //Update Commander Settings
                                    SaveUserOnly(User, MethodName);

                                    //Enable Saving
                                    UserSettingsUpdating = false;
                                }

                                ISettings.UserSettingsCompare(User);
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
}
