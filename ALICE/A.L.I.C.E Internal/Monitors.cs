using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;
using ALICE_Actions;
using ALICE_Objects;
using ALICE_Core;
using ALICE_Settings;

namespace ALICE_Internal
{
    public static class Monitors
    {
        public static Ships Ship = new Ships();
        public static Jsons Json = new Jsons();
        public static Internals Internal = new Internals();
        public static Panels Panel = new Panels();
        public static Users User = new Users();
        public static Reports Report = new Reports();
        public static Firegroups Firegroup = new Firegroups();

        private static DirectoryInfo DirSettings = new DirectoryInfo(Paths.ALICE_Settings);

        public static void StartMonitors(bool StartShip, bool StartJson, bool StartInternal, bool StartPanel, bool StartUser, bool StartFiregroup)
        {
            if (StartShip) { Ship.StartMonitor(); }
            if (StartJson) { Json.Enabled = true; Json.StartMonitor(); }
            if (StartInternal) { Internal.StartMonitor(); }
            if (StartPanel) { Panel.StartMonitor(); }
            if (StartUser) { User.Enabled = true; User.Log = true; User.StartMonitor(); }
            if (StartFiregroup) { Firegroup.Enabled = true; Firegroup.Log = true; Firegroup.StartMonitor(); }
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

        public class Ships : Base
        {
            public void StartMonitor()
            {
                Thread thread =
                new Thread((ThreadStart)(() =>
                {
                    try
                    {
                        if (Monitor.TryEnter(LockFlag))
                        {
                            Watch();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(MethodName, "Exception " + ex);
                        Logger.Exception(MethodName, "Something Went Wrong With The Montor. Its Not Working Right Now, But Shouldn't Impact Your Experience...");
                    }
                    finally
                    {
                        Monitor.Exit(LockFlag);
                    }
                }))
                { IsBackground = true }; thread.Start();
            }

            public Ships()
            {
                Enabled = false;
                LockFlag = new object();
                MethodName = "Ship Monitor";
            }

            public void Watch()
            {

            }
        }

        public class Jsons : Base
        {
            public bool UpdatePosition { get; set; }
            public bool UpdatePower { get; set; }

            public void StartMonitor()
            {
                Thread thread =
                new Thread((ThreadStart)(() =>
                {
                    try
                    {
                        if (Monitor.TryEnter(LockFlag))
                        {
                            Watch();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(MethodName, "Exception " + ex);
                        Logger.Exception(MethodName, "Something Went Wrong With The Montor. Its Not Working Right Now, But Shouldn't Impact Your Experience...");
                    }
                    finally
                    {
                        Monitor.Exit(LockFlag);
                    }
                }))
                { IsBackground = true }; thread.Start();
            }

            public Jsons()
            {
                Enabled = false;
                LockFlag = new object();
                MethodName = "Json Monitor";
                Log = false;
                UpdateNumber = 0;

                UpdatePosition = true;
                UpdatePower = false;
            }

            #region Enums
            public IVehicles.V Vehicle = IVehicles.V.Default;
            #endregion

            #region Booleans
            public bool NightVision = false;
            public bool AnalysisMode = false;
            public bool Interdiction = false;
            public bool InDanger = false;
            public bool HasLatLong = false;
            public bool Overheating = false;
            public bool LowFuel = false;
            public bool FSDCooldown = false;
            public bool FSDCharging = false;
            public bool Masslocked = false;
            public bool SRVDriveAssist = false;
            public bool SRVNearMothership = false;
            public bool SRVTurret = false;
            public bool SRVHandbreak = false;
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

            #region Decimals
            public decimal System = 0;
            public decimal Engine = 0;
            public decimal Weapon = 0;
            public decimal FireGroup = 0;
            public decimal GUIFocus = 0;
            public decimal Altitude = 0;
            public decimal Latitude = 0;
            public decimal Longitude = 0;
            public decimal Heading = 0;
            public decimal CargoMass = 0;
            public decimal Fuel = 0;
            #endregion

            public void Watch()
            {
                List<string> Updates = new List<string>();

                while (Enabled)
                {
                    Thread.Sleep(500);

                    #region Strings
                    if (Vehicle != IVehicles.Vehicle)
                    {
                        Vehicle = IVehicles.Vehicle;
                        Updates.Add("(" + MethodName + ") Vehicle = " + Vehicle);
                    }
                    #endregion

                    #region Booleans
                    if (NightVision != IObjects.Status.NightVision)
                    {
                        NightVision = IObjects.Status.NightVision;
                        Updates.Add("(" + MethodName + ") NightVision = " + NightVision);
                    }
                    if (AnalysisMode != IObjects.Status.AnalysisMode)
                    {
                        AnalysisMode = IObjects.Status.AnalysisMode;
                        Updates.Add("(" + MethodName + ") AnalysisMode = " + AnalysisMode);
                    }
                    if (Interdiction != IObjects.Status.Interdiction)
                    {
                        Interdiction = IObjects.Status.Interdiction;
                        Updates.Add("(" + MethodName + ") Interdiction = " + Interdiction);
                    }
                    if (InDanger != IObjects.Status.InDanger)
                    {
                        InDanger = IObjects.Status.InDanger;
                        Updates.Add("(" + MethodName + ") InDanger = " + InDanger);
                    }
                    if (HasLatLong != IObjects.Status.HasLatLong)
                    {
                        HasLatLong = IObjects.Status.HasLatLong;
                        Updates.Add("(" + MethodName + ") HasLatLong = " + HasLatLong);
                    }
                    if (Overheating != IObjects.Status.Overheating)
                    {
                        Overheating = IObjects.Status.Overheating;
                        Updates.Add("(" + MethodName + ") Overheating = " + Overheating);
                    }
                    if (LowFuel != IObjects.Status.LowFuel)
                    {
                        LowFuel = IObjects.Status.LowFuel;
                        Updates.Add("(" + MethodName + ") LowFuel = " + LowFuel);
                    }
                    if (FSDCooldown != IEquipment.FrameShiftDrive.Cooldown)
                    {
                        FSDCooldown = IEquipment.FrameShiftDrive.Cooldown;
                        Updates.Add("(" + MethodName + ") FSDCooldown = " + FSDCooldown);
                    }
                    if (FSDCharging != IEquipment.FrameShiftDrive.Charging)
                    {
                        FSDCharging = IEquipment.FrameShiftDrive.Charging;
                        Updates.Add("(" + MethodName + ") FSDCharging = " + FSDCharging);
                    }
                    if (Masslocked != IObjects.Status.Masslocked)
                    {
                        Masslocked = IObjects.Status.Masslocked;
                        Updates.Add("(" + MethodName + ") Masslocked = " + Masslocked);
                    }
                    if (SRVDriveAssist != IObjects.Status.SRV_DriveAssist)
                    {
                        SRVDriveAssist = IObjects.Status.SRV_DriveAssist;
                        Updates.Add("(" + MethodName + ") SRVDriveAssist = " + SRVDriveAssist);
                    }
                    if (SRVNearMothership != IObjects.Status.SRV_NearMothership)
                    {
                        SRVNearMothership = IObjects.Status.SRV_NearMothership;
                        Updates.Add("(" + MethodName + ") SRVUnderShip = " + SRVNearMothership);
                    }
                    if (SRVTurret != IObjects.Status.SRV_Turret)
                    {
                        SRVTurret = IObjects.Status.SRV_Turret;
                        Updates.Add("(" + MethodName + ") SRVTurret = " + SRVTurret);
                    }
                    if (SRVHandbreak != IObjects.Status.SRV_Handbreak)
                    {
                        SRVHandbreak = IObjects.Status.SRV_Handbreak;
                        Updates.Add("(" + MethodName + ") SRVHandbreak = " + SRVHandbreak);
                    }
                    if (FuelScooping != IObjects.Status.FuelScooping)
                    {
                        FuelScooping = IObjects.Status.FuelScooping;
                        Updates.Add("(" + MethodName + ") FuelScooping = " + FuelScooping);
                    }
                    if (CargoScoop != IObjects.Status.CargoScoop)
                    {
                        CargoScoop = IObjects.Status.CargoScoop;
                        Updates.Add("(" + MethodName + ") CargoScoop = " + CargoScoop);
                    }
                    if (Lights != IObjects.Status.Lights)
                    {
                        Lights = IObjects.Status.Lights;
                        Updates.Add("(" + MethodName + ") Lights = " + Lights);
                    }
                    if (InWing != IObjects.Status.InWing)
                    {
                        InWing = IObjects.Status.InWing;
                        Updates.Add("(" + MethodName + ") InWing = " + InWing);
                    }
                    if (Hardpoints != IObjects.Status.Hardpoints)
                    {
                        Hardpoints = IObjects.Status.Hardpoints;
                        Updates.Add("(" + MethodName + ") Hardpoints = " + Hardpoints);
                    }
                    if (FlightAssist != IObjects.Status.FlightAssist)
                    {
                        FlightAssist = IObjects.Status.FlightAssist;
                        Updates.Add("(" + MethodName + ") FlightAssist = " + FlightAssist);
                    }
                    if (Supercruise != IObjects.Status.Supercruise)
                    {
                        Supercruise = IObjects.Status.Supercruise;
                        Updates.Add("(" + MethodName + ") Supercruise = " + Supercruise);
                    }
                    if (Shields != IObjects.Status.Shields)
                    {
                        Shields = IObjects.Status.Shields;
                        Updates.Add("(" + MethodName + ") Shields = " + Shields);
                    }
                    if (LandingGear != IObjects.Status.LandingGear)
                    {
                        LandingGear = IObjects.Status.LandingGear;
                        Updates.Add("(" + MethodName + ") LandingGear = " + LandingGear);
                    }
                    if (Touchdown != IObjects.Status.Touchdown)
                    {
                        Touchdown = IObjects.Status.Touchdown;
                        Updates.Add("(" + MethodName + ") Touchdown = " + Touchdown);
                    }
                    if (Docked != IObjects.Status.Docked)
                    {
                        Docked = IObjects.Status.Docked;
                        Updates.Add("(" + MethodName + ") Docked = " + Docked);
                    }
                    #endregion

                    #region Decimals
                    if (UpdatePower && System != Call.Power.Game.System)
                    {
                        System = Call.Power.Game.System;
                        Updates.Add("(" + MethodName + ") System = " + System);
                    }
                    if (UpdatePower && Engine != Call.Power.Game.Engine)
                    {
                        Engine = Call.Power.Game.Engine;
                        Updates.Add("(" + MethodName + ") Engine = " + Engine);
                    }
                    if (UpdatePower && Weapon != Call.Power.Game.Weapon)
                    {
                        Weapon = Call.Power.Game.Weapon;
                        Updates.Add("(" + MethodName + ") Weapon = " + Weapon);
                    }
                    if (UpdatePosition && Altitude != IObjects.Status.Altitude)
                    {
                        Altitude = IObjects.Status.Altitude;
                        Updates.Add("(" + MethodName + ") Altitude = " + Altitude);
                    }
                    if (UpdatePosition && Latitude != IObjects.Status.Latitude)
                    {
                        Latitude = IObjects.Status.Latitude;
                        Updates.Add("(" + MethodName + ") Latitude = " + Latitude);
                    }
                    if (UpdatePosition && Longitude != IObjects.Status.Longitude)
                    {
                        Longitude = IObjects.Status.Longitude;
                        Updates.Add("(" + MethodName + ") Longitude = " + Longitude);
                    }
                    if (UpdatePosition && Heading != IObjects.Status.Heading)
                    {
                        Heading = IObjects.Status.Heading;
                        Updates.Add("(" + MethodName + ") Heading = " + Heading);
                    }
                    if (GUIFocus != IObjects.Status.GUI_Focus)
                    {
                        GUIFocus = IObjects.Status.GUI_Focus;
                        Updates.Add("(" + MethodName + ") GUIFocus = " + GUIFocus);
                    }
                    if (FireGroup != Call.Firegroup.Current)
                    {
                        FireGroup = Call.Firegroup.Current;
                        Updates.Add("(" + MethodName + ") FireGroup = " + FireGroup);
                    }
                    if (Fuel != IEquipment.FuelTank.Main)
                    {
                        Fuel = IEquipment.FuelTank.Main;
                        Updates.Add("(" + MethodName + ") Fuel = " + Fuel);
                    }
                    if (CargoMass != IObjects.Status.CargoMass)
                    {
                        CargoMass = IObjects.Status.CargoMass;
                        Updates.Add("(" + MethodName + ") Cargo (In Tons) = " + CargoMass);
                    }
                    #endregion

                    #region Write Updates
                    if (Updates.Count > 0)
                    {
                        if (Log && Check.Internal.TriggerEvents(true, MethodName))
                        {
                            foreach (string Line in Updates)
                            {
                                Logger.Simple(Line, Logger.Green);
                            }
                        }
                        UpdateNumber++;
                        Updates = new List<string>();
                    }
                    #endregion
                }
                Logger.Log(MethodName, "Stopped Watching...", Logger.Yellow);
            }
        }

        public class Internals : Base
        {
            public void StartMonitor()
            {
                Thread thread =
                new Thread((ThreadStart)(() =>
                {
                    try
                    {
                        if (Monitor.TryEnter(LockFlag))
                        {
                            Watch();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(MethodName, "Exception " + ex);
                        Logger.Exception(MethodName, "Something Went Wrong With The Montor. Its Not Working Right Now, But Shouldn't Impact Your Experience...");
                    }
                    finally
                    {
                        Monitor.Exit(LockFlag);
                    }
                }))
                { IsBackground = true }; thread.Start();
            }

            public Internals()
            {
                Enabled = false;
                LockFlag = new object();
                MethodName = "Internal Monitor";
            }

            public void Watch()
            {

            }
        }

        public class Users : Base
        {            
            public List<string> Updates = new List<string>();

            public Users()
            {
                Enabled = false;
                LockFlag = new object();
                MethodName = "Settings Monitor";
                Log = true;
                UpdateNumber = 0;
                TimeStamp = "None";
                ISettings.Reference = ISettings.Reference.Load(ISettings.SettingsUser, MethodName);
                ISettings.Toolkit = ISettings.Toolkit.Load(ISettings.SettingsUser, MethodName);
            }

            public void StartMonitor()
            {
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

                                //Check File Timestamp
                                if (CheckSettings(ISettings.SettingsUser + ".Settings"))
                                {
                                    //Load Toolkit Settings
                                    ISettings.Toolkit = ISettings.Toolkit.Load(ISettings.SettingsUser, "Monitor (Toolkit)");
                                    //Look For Changes
                                    if (WatchToolkit())
                                    {
                                        //Sync All Settings
                                        UpdateSettings(ISettings.Toolkit);
                                    }
                                }

                                //Check For Internal Changes
                                WatchInternal();
                            }

                            Logger.Log(MethodName, "Stopped Watching...", Logger.Yellow);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(MethodName, "Exception " + ex);
                        Logger.Exception(MethodName, "Something Went Wrong With The Montor. Its Not Working Right Now, But Shouldn't Impact Your Experience...");
                    }
                    finally
                    {
                        Monitor.Exit(LockFlag);
                    }
                }))
                { IsBackground = true }; thread.Start();
            }

            public void UpdateSettings(Settings_User S)
            {
                string MethodName = "Setting Monitor (Update)";

                ISettings.Reference = S;
                ISettings.Toolkit = S;
                ISettings.User = S;
                ISettings.User.Save(MethodName);
            }

            public void WatchInternal()
            {
                #region PlugIn
                if (ISettings.Reference.OffsetFireGroups != ISettings.User.OffsetFireGroups)
                {
                    ISettings.Reference.OffsetFireGroups = ISettings.User.OffsetFireGroups;
                    Updates.Add(MethodName + ": Firegroup Offset = " + ISettings.Reference.OffsetFireGroups);
                }
                if (ISettings.Reference.OffsetPanels != ISettings.User.OffsetPanels)
                {
                    ISettings.Reference.OffsetPanels = ISettings.User.OffsetPanels;
                    Updates.Add(MethodName + ": Panel Offset = " + ISettings.Reference.OffsetPanels);
                }
                if (ISettings.Reference.OffsetPips != ISettings.User.OffsetPips)
                {
                    ISettings.Reference.OffsetPips = ISettings.User.OffsetPips;
                    Updates.Add(MethodName + ": Power Offset = " + ISettings.Reference.OffsetPips);
                }
                if (ISettings.Reference.OffsetThrottle != ISettings.User.OffsetThrottle)
                {
                    ISettings.Reference.OffsetThrottle = ISettings.User.OffsetThrottle;
                    Updates.Add(MethodName + ": Throttle Offset = " + ISettings.Reference.OffsetThrottle);
                }
                #endregion

                #region Orders
                if (ISettings.Reference.WeaponSafety != ISettings.User.WeaponSafety)
                {
                    ISettings.Reference.WeaponSafety = ISettings.User.WeaponSafety;
                    Updates.Add(MethodName + ": Weapon Safties = " + ISettings.Reference.WeaponSafety);
                }
                if (ISettings.Reference.CombatPower != ISettings.User.CombatPower)
                {
                    ISettings.Reference.CombatPower = ISettings.User.CombatPower;
                    Updates.Add(MethodName + ": Assisted Combat Power = " + ISettings.Reference.CombatPower);
                }
                if (ISettings.Reference.AssistSystemScan != ISettings.User.AssistSystemScan)
                {
                    ISettings.Reference.AssistSystemScan = ISettings.User.AssistSystemScan;
                    Updates.Add(MethodName + ": Assisted System Scans = " + ISettings.Reference.AssistSystemScan);
                }
                if (ISettings.Reference.AssistDocking != ISettings.User.AssistDocking)
                {
                    ISettings.Reference.AssistDocking = ISettings.User.AssistDocking;
                    Updates.Add(MethodName + ": Assisted Docking Procedures = " + ISettings.Reference.AssistDocking);
                }
                if (ISettings.Reference.AssistRefuel != ISettings.User.AssistRefuel)
                {
                    ISettings.Reference.AssistRefuel = ISettings.User.AssistRefuel;
                    Updates.Add(MethodName + ": Assisted Refuel = " + ISettings.Reference.AssistRefuel);
                }
                if (ISettings.Reference.AssistRearm != ISettings.User.AssistRearm)
                {
                    ISettings.Reference.AssistRearm = ISettings.User.AssistRearm;
                    Updates.Add(MethodName + ": Assisted Rearm = " + ISettings.Reference.AssistRearm);
                }
                if (ISettings.Reference.AssistRepair != ISettings.User.AssistRepair)
                {
                    ISettings.Reference.AssistRepair = ISettings.User.AssistRepair;
                    Updates.Add(MethodName + ": Assisted Repair = " + ISettings.Reference.AssistRepair);
                }
                if (ISettings.Reference.AssistHangerEntry != ISettings.User.AssistHangerEntry)
                {
                    ISettings.Reference.AssistHangerEntry = ISettings.User.AssistHangerEntry;
                    Updates.Add(MethodName + ": Assisted Hanger Entry = " + ISettings.Reference.AssistHangerEntry);
                }
                if (ISettings.Reference.PostHyperspaceSafety != ISettings.User.PostHyperspaceSafety)
                {
                    ISettings.Reference.PostHyperspaceSafety = ISettings.User.PostHyperspaceSafety;
                    Updates.Add(MethodName + ":  Post Hyperspace Safties = " + ISettings.Reference.PostHyperspaceSafety);
                }
                #endregion

                #region Reports
                if (ISettings.Reference.FuelScoop != ISettings.User.FuelScoop)
                {
                    ISettings.Reference.FuelScoop = ISettings.User.FuelScoop;
                    Updates.Add(MethodName + ": Fuel Scoop = " + ISettings.Reference.FuelScoop);
                }
                if (ISettings.Reference.FuelStatus != ISettings.User.FuelStatus)
                {
                    ISettings.Reference.FuelStatus = ISettings.User.FuelStatus;
                    Updates.Add(MethodName + ": Fuel Status = " + ISettings.Reference.FuelStatus);
                }
                if (ISettings.Reference.MaterialCollected != ISettings.User.MaterialCollected)
                {
                    ISettings.Reference.MaterialCollected = ISettings.User.MaterialCollected;
                    Updates.Add(MethodName + ": Material Collected = " + ISettings.Reference.MaterialCollected);
                }
                if (ISettings.Reference.MaterialRefined != ISettings.User.MaterialRefined)
                {
                    ISettings.Reference.MaterialRefined = ISettings.User.MaterialRefined;
                    Updates.Add(MethodName + ": Material Refined = " + ISettings.Reference.MaterialRefined);
                }
                if (ISettings.Reference.NoFireZone != ISettings.User.NoFireZone)
                {
                    ISettings.Reference.NoFireZone = ISettings.User.NoFireZone;
                    Updates.Add(MethodName + ": No Fire Zone = " + ISettings.Reference.NoFireZone);
                }
                if (ISettings.Reference.StationStatus != ISettings.User.StationStatus)
                {
                    ISettings.Reference.StationStatus = ISettings.User.StationStatus;
                    Updates.Add(MethodName + ": Station Status = " + ISettings.Reference.StationStatus);
                }
                if (ISettings.Reference.ShieldState != ISettings.User.ShieldState)
                {
                    ISettings.Reference.ShieldState = ISettings.User.ShieldState;
                    Updates.Add(MethodName + ": Shield State = " + ISettings.Reference.ShieldState);
                }
                if (ISettings.Reference.CollectedBounty != ISettings.User.CollectedBounty)
                {
                    ISettings.Reference.CollectedBounty = ISettings.User.CollectedBounty;
                    Updates.Add(MethodName + ": Collected Bounty = " + ISettings.Reference.CollectedBounty);
                }
                if (ISettings.Reference.TargetEnemy != ISettings.User.TargetEnemy)
                {
                    ISettings.Reference.TargetEnemy = ISettings.User.TargetEnemy;
                    Updates.Add(MethodName + ": Hostile Faction = " + ISettings.Reference.TargetEnemy);
                }
                if (ISettings.Reference.TargetWanted != ISettings.User.TargetWanted)
                {
                    ISettings.Reference.TargetWanted = ISettings.User.TargetWanted;
                    Updates.Add(MethodName + ": Wanted Target = " + ISettings.Reference.TargetWanted);
                }
                if (ISettings.Reference.Masslock != ISettings.User.Masslock)
                {
                    ISettings.Reference.Masslock = ISettings.User.Masslock;
                    Updates.Add(MethodName + ": Masslock = " + ISettings.Reference.Masslock);
                }
                #endregion

                #region Navigation
                if (ISettings.Reference.ScanDistLimit != ISettings.User.ScanDistLimit)
                {
                    ISettings.Reference.ScanDistLimit = ISettings.User.ScanDistLimit;
                    Updates.Add(MethodName + ": Scan Distance Limit = " + ISettings.Reference.ScanDistLimit);
                }
                #endregion

                #region Write Updates
                if (Updates.Count > 0)
                {
                    if (Log && Check.Internal.TriggerEvents(true, MethodName))
                    {
                        foreach (string Line in Updates)
                        {
                            Logger.Simple(Line, Logger.Green);
                        }
                    }
                    UpdateNumber++;
                    Updates = new List<string>();
                }
                #endregion
            }

            public bool WatchToolkit()
            {
                //Track Updates
                bool Updated = false;

                if (ISettings.User == null) { return Updated; }

                #region PlugIn
                if (ISettings.User.OffsetFireGroups != ISettings.Toolkit.OffsetFireGroups)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Firegroup Offset = " + ISettings.Toolkit.OffsetFireGroups);
                    ISettings.User.OffsetFireGroups = ISettings.Toolkit.OffsetFireGroups;
                }
                if (ISettings.User.OffsetPanels != ISettings.Toolkit.OffsetPanels)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Panel Offset = " + ISettings.Toolkit.OffsetPanels);
                    ISettings.User.OffsetPanels = ISettings.Toolkit.OffsetPanels;
                }
                if (ISettings.User.OffsetPips != ISettings.Toolkit.OffsetPips)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Power Offset = " + ISettings.Toolkit.OffsetPips);
                    ISettings.User.OffsetPips = ISettings.Toolkit.OffsetPips;
                }
                if (ISettings.User.OffsetThrottle != ISettings.Toolkit.OffsetThrottle)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Throttle Offset = " + ISettings.Toolkit.OffsetThrottle);
                    ISettings.User.OffsetThrottle = ISettings.Toolkit.OffsetThrottle;
                }
                #endregion

                #region Orders
                if (ISettings.User.WeaponSafety != ISettings.Toolkit.WeaponSafety)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Weapon Safties = " + ISettings.Toolkit.WeaponSafety);
                    ISettings.User.U_WeaponSafety(ISettings.Toolkit.WeaponSafety);
                }
                if (ISettings.User.CombatPower != ISettings.Toolkit.CombatPower)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Assisted Combat Power = " + ISettings.Toolkit.CombatPower);
                    ISettings.User.U_CombatPower(ISettings.Toolkit.CombatPower);
                }
                if (ISettings.User.AssistSystemScan != ISettings.Toolkit.AssistSystemScan)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Assisted System Scans = " + ISettings.Toolkit.AssistSystemScan);
                    ISettings.User.U_AutoSystemScans(ISettings.Toolkit.AssistSystemScan);
                }
                if (ISettings.User.AssistDocking != ISettings.Toolkit.AssistDocking)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Assisted Docking Procedures = " + ISettings.Toolkit.AssistDocking);
                    ISettings.User.U_AutoDockingProcedure(ISettings.Toolkit.AssistDocking);
                }
                if (ISettings.User.AssistRefuel != ISettings.Toolkit.AssistRefuel)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Assisted Refuel = " + ISettings.Toolkit.AssistRefuel);
                    ISettings.User.U_AutoRefuel(ISettings.Toolkit.AssistRefuel);
                }
                if (ISettings.User.AssistRearm != ISettings.Toolkit.AssistRearm)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Assisted Rearm = " + ISettings.Toolkit.AssistRearm);
                    ISettings.User.U_AutoRearm(ISettings.Toolkit.AssistRearm);
                }
                if (ISettings.User.AssistRepair != ISettings.Toolkit.AssistRepair)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Assisted Repair = " + ISettings.Toolkit.AssistRepair);
                    ISettings.User.U_AutoRepair(ISettings.Toolkit.AssistRepair);
                }
                if (ISettings.User.AssistHangerEntry != ISettings.Toolkit.AssistHangerEntry)
                {
                    Updates.Add(MethodName + " (Toolkit Update):  Assisted Hanger Entry = " + ISettings.Toolkit.AssistHangerEntry);
                    ISettings.User.U_AutoHangerEntry(ISettings.Toolkit.AssistHangerEntry);
                }
                if (ISettings.User.PostHyperspaceSafety != ISettings.Toolkit.PostHyperspaceSafety)
                {
                    Updates.Add(MethodName + " (Toolkit Update):   Post Hyperspace Safties = " + ISettings.Toolkit.PostHyperspaceSafety);
                    ISettings.User.U_PostJumpSafety(ISettings.Toolkit.PostHyperspaceSafety);
                }
                #endregion

                #region Reports
                if (ISettings.User.FuelScoop != ISettings.Toolkit.FuelScoop)
                {
                    Updates.Add(MethodName + " (Toolkit Update): Fuel Scoop = " + ISettings.Toolkit.FuelScoop);
                    ISettings.User.U_FuelScoop(ISettings.Toolkit.FuelScoop);
                }
                if (ISettings.User.FuelStatus != ISettings.Toolkit.FuelStatus)
                {
                    Updates.Add(MethodName + " (Toolkit Update): Fuel Status = " + ISettings.Toolkit.FuelStatus);
                    ISettings.User.U_FuelStatus(ISettings.Toolkit.FuelStatus);
                }
                if (ISettings.User.MaterialCollected != ISettings.Toolkit.MaterialCollected)
                {
                    Updates.Add(MethodName + " (Toolkit Update): Collected Materials = " + ISettings.Toolkit.MaterialCollected);
                    ISettings.User.U_MaterialCollected(ISettings.Toolkit.MaterialCollected);
                }
                if (ISettings.User.MaterialRefined != ISettings.Toolkit.MaterialRefined)
                {
                    Updates.Add(MethodName + " (Toolkit Update): Refined Materials = " + ISettings.Toolkit.MaterialRefined);
                    ISettings.User.U_MaterialRefined(ISettings.Toolkit.MaterialRefined);
                }
                if (ISettings.User.NoFireZone != ISettings.Toolkit.NoFireZone)
                {
                    Updates.Add(MethodName + " (Toolkit Update): No Fire Zone = " + ISettings.Toolkit.NoFireZone);
                    ISettings.User.U_NoFireZone(ISettings.Toolkit.NoFireZone);
                }
                if (ISettings.User.StationStatus != ISettings.Toolkit.StationStatus)
                {
                    Updates.Add(MethodName + " (Toolkit Update): Station Status = " + ISettings.Toolkit.StationStatus);
                    ISettings.User.U_StationStatus(ISettings.Toolkit.StationStatus);
                }
                if (ISettings.User.ShieldState != ISettings.Toolkit.ShieldState)
                {
                    Updates.Add(MethodName + " (Toolkit Update): Shield State = " + ISettings.Toolkit.ShieldState);
                    ISettings.User.U_ShieldState(ISettings.Toolkit.ShieldState);
                }
                if (ISettings.User.CollectedBounty != ISettings.Toolkit.CollectedBounty)
                {
                    Updates.Add(MethodName + " (Toolkit Update): Collected Bounties = " + ISettings.Toolkit.CollectedBounty);
                    ISettings.User.U_CollectedBounty(ISettings.Toolkit.CollectedBounty);
                }
                if (ISettings.User.TargetEnemy != ISettings.Toolkit.TargetEnemy)
                {
                    Updates.Add(MethodName + " (Toolkit Update): Enemy Factions = " + ISettings.Toolkit.TargetEnemy);
                    ISettings.User.U_TargetEnemy(ISettings.Toolkit.TargetEnemy);
                }
                if (ISettings.User.TargetWanted != ISettings.Toolkit.TargetWanted)
                {
                    Updates.Add(MethodName + " (Toolkit Update): Wanted Targets = " + ISettings.Toolkit.TargetWanted);
                    ISettings.User.U_TargetWanted(ISettings.Toolkit.TargetWanted);
                }
                if (ISettings.User.Masslock != ISettings.Toolkit.Masslock)
                {
                    Updates.Add(MethodName + " (Toolkit Update): Masslock = " + ISettings.Toolkit.Masslock);
                    ISettings.User.U_Masslock(ISettings.Toolkit.Masslock);
                }
                #endregion

                #region Navigation
                if (ISettings.User.ScanDistLimit != ISettings.Toolkit.ScanDistLimit)
                {
                    Updates.Add(MethodName + " (Toolkit Update): Scan Distance Limit = " + ISettings.Toolkit.ScanDistLimit);
                    ISettings.User.U_ScanDistLimit(ISettings.Toolkit.ScanDistLimit);
                }
                #endregion

                #region Write Updates
                if (Updates.Count > 0)
                {
                    Updated = true; if (Log && Check.Internal.TriggerEvents(true, MethodName))
                    {
                        foreach (string Line in Updates)
                        {
                            Logger.Simple(Line, Logger.Green);
                        }
                    }
                    UpdateNumber++;
                    Updates = new List<string>();
                }
                #endregion

                //Return If There Were Updates
                return Updated;
            }
        }

        public class Firegroups : Base
        {                     
            public List<string> Updates = new List<string>();

            public Firegroups()
            {
                Enabled = false;
                LockFlag = new object();
                MethodName = "Firegroup Monitor";
                Log = true;
                UpdateNumber = 0;
                TimeStamp = "None";
            }

            public void StartMonitor()
            {
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

                                //Check File Timestamp
                                if (CheckSettings(ISettings.SettingsFiregroup + ".FGConfig"))
                                {
                                    //Load Toolkit Settings
                                    ISettings.Firegroup = (Settings_Firegroups)ISettings.LoadValues<Settings_Firegroups>(ISettings.SettingsFiregroup + ".FGConfig");
                                    ISettings.Firegroup.Save(MethodName); CheckSettings(ISettings.SettingsFiregroup + ".FGConfig");
                                    Logger.Log(MethodName, "(Toolkit) Firegroup Settings Updated", Logger.Green);
                                }
                            }

                            Logger.Log(MethodName, "Stopped Watching...", Logger.Yellow);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(MethodName, "Exception " + ex);
                        Logger.Exception(MethodName, "Something Went Wrong With The Montor. Its Not Working Right Now, But Shouldn't Impact Your Experience...");
                    }
                    finally
                    {
                        Monitor.Exit(LockFlag);
                    }
                }))
                { IsBackground = true }; thread.Start();
            }
        }

        public class Panels : Base
        {
            public void StartMonitor()
            {
                Thread tooklit =
                new Thread((ThreadStart)(() =>
                {
                    try
                    {
                        if (Monitor.TryEnter(LockFlag))
                        {
                            Watch();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(MethodName, "Exception " + ex);
                        Logger.Exception(MethodName, "Something Went Wrong With The Montor. Its Not Working Right Now, But Shouldn't Impact Your Experience...");
                    }
                    finally
                    {
                        Monitor.Exit(LockFlag);
                    }
                }))
                { IsBackground = true }; tooklit.Start();
            }

            public Panels()
            {
                Enabled = false;
                LockFlag = new object();
                MethodName = "Panel Monitor";
            }

            public void Watch()
            {

            }
        }
    }
}
