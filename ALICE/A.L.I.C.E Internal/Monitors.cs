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
        public static Reports Report = new Reports();
        public static Firegroups Firegroup = new Firegroups();

        private static DirectoryInfo DirSettings = new DirectoryInfo(Paths.ALICE_Settings);

        public static void StartMonitors(bool StartShip, bool StartJson, bool StartInternal, bool StartPanel, bool StartFiregroup)
        {
            if (StartShip) { Ship.StartMonitor(); }
            if (StartJson) { Json.Enabled = true; Json.StartMonitor(); }
            if (StartInternal) { Internal.StartMonitor(); }
            if (StartPanel) { Panel.StartMonitor(); }
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
                    if (NightVision != IStatus.NightVision)
                    {
                        NightVision = IStatus.NightVision;
                        Updates.Add("(" + MethodName + ") NightVision = " + NightVision);
                    }
                    if (AnalysisMode != IStatus.AnalysisMode)
                    {
                        AnalysisMode = IStatus.AnalysisMode;
                        Updates.Add("(" + MethodName + ") AnalysisMode = " + AnalysisMode);
                    }
                    if (Interdiction != IStatus.Interdiction)
                    {
                        Interdiction = IStatus.Interdiction;
                        Updates.Add("(" + MethodName + ") Interdiction = " + Interdiction);
                    }
                    if (InDanger != IStatus.InDanger)
                    {
                        InDanger = IStatus.InDanger;
                        Updates.Add("(" + MethodName + ") InDanger = " + InDanger);
                    }
                    if (HasLatLong != IStatus.HasLatLong)
                    {
                        HasLatLong = IStatus.HasLatLong;
                        Updates.Add("(" + MethodName + ") HasLatLong = " + HasLatLong);
                    }
                    if (Overheating != IStatus.Overheating)
                    {
                        Overheating = IStatus.Overheating;
                        Updates.Add("(" + MethodName + ") Overheating = " + Overheating);
                    }
                    if (LowFuel != IStatus.LowFuel)
                    {
                        LowFuel = IStatus.LowFuel;
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
                    if (Masslocked != IStatus.Masslocked)
                    {
                        Masslocked = IStatus.Masslocked;
                        Updates.Add("(" + MethodName + ") Masslocked = " + Masslocked);
                    }
                    if (SRVDriveAssist != IStatus.SRV_DriveAssist)
                    {
                        SRVDriveAssist = IStatus.SRV_DriveAssist;
                        Updates.Add("(" + MethodName + ") SRVDriveAssist = " + SRVDriveAssist);
                    }
                    if (SRVNearMothership != IStatus.SRV_NearMothership)
                    {
                        SRVNearMothership = IStatus.SRV_NearMothership;
                        Updates.Add("(" + MethodName + ") SRVUnderShip = " + SRVNearMothership);
                    }
                    if (SRVTurret != IStatus.SRV_Turret)
                    {
                        SRVTurret = IStatus.SRV_Turret;
                        Updates.Add("(" + MethodName + ") SRVTurret = " + SRVTurret);
                    }
                    if (SRVHandbreak != IStatus.SRV_Handbreak)
                    {
                        SRVHandbreak = IStatus.SRV_Handbreak;
                        Updates.Add("(" + MethodName + ") SRVHandbreak = " + SRVHandbreak);
                    }
                    if (FuelScooping != IStatus.FuelScooping)
                    {
                        FuelScooping = IStatus.FuelScooping;
                        Updates.Add("(" + MethodName + ") FuelScooping = " + FuelScooping);
                    }
                    if (CargoScoop != IStatus.CargoScoop)
                    {
                        CargoScoop = IStatus.CargoScoop;
                        Updates.Add("(" + MethodName + ") CargoScoop = " + CargoScoop);
                    }
                    if (Lights != IStatus.Lights)
                    {
                        Lights = IStatus.Lights;
                        Updates.Add("(" + MethodName + ") Lights = " + Lights);
                    }
                    if (InWing != IStatus.InWing)
                    {
                        InWing = IStatus.InWing;
                        Updates.Add("(" + MethodName + ") InWing = " + InWing);
                    }
                    if (Hardpoints != IStatus.Hardpoints)
                    {
                        Hardpoints = IStatus.Hardpoints;
                        Updates.Add("(" + MethodName + ") Hardpoints = " + Hardpoints);
                    }
                    if (FlightAssist != IStatus.FlightAssist)
                    {
                        FlightAssist = IStatus.FlightAssist;
                        Updates.Add("(" + MethodName + ") FlightAssist = " + FlightAssist);
                    }
                    if (Supercruise != IStatus.Supercruise)
                    {
                        Supercruise = IStatus.Supercruise;
                        Updates.Add("(" + MethodName + ") Supercruise = " + Supercruise);
                    }
                    if (Shields != IStatus.Shields)
                    {
                        Shields = IStatus.Shields;
                        Updates.Add("(" + MethodName + ") Shields = " + Shields);
                    }
                    if (LandingGear != IStatus.LandingGear)
                    {
                        LandingGear = IStatus.LandingGear;
                        Updates.Add("(" + MethodName + ") LandingGear = " + LandingGear);
                    }
                    if (Touchdown != IStatus.Touchdown)
                    {
                        Touchdown = IStatus.Touchdown;
                        Updates.Add("(" + MethodName + ") Touchdown = " + Touchdown);
                    }
                    if (Docked != IStatus.Docking.Docked)
                    {
                        Docked = IStatus.Docking.Docked;
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
                    if (UpdatePosition && Altitude != IStatus.Altitude)
                    {
                        Altitude = IStatus.Altitude;
                        Updates.Add("(" + MethodName + ") Altitude = " + Altitude);
                    }
                    if (UpdatePosition && Latitude != IStatus.Latitude)
                    {
                        Latitude = IStatus.Latitude;
                        Updates.Add("(" + MethodName + ") Latitude = " + Latitude);
                    }
                    if (UpdatePosition && Longitude != IStatus.Longitude)
                    {
                        Longitude = IStatus.Longitude;
                        Updates.Add("(" + MethodName + ") Longitude = " + Longitude);
                    }
                    if (UpdatePosition && Heading != IStatus.Heading)
                    {
                        Heading = IStatus.Heading;
                        Updates.Add("(" + MethodName + ") Heading = " + Heading);
                    }
                    if (GUIFocus != IStatus.GUI_Focus)
                    {
                        GUIFocus = IStatus.GUI_Focus;
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
                    if (CargoMass != IStatus.CargoMass)
                    {
                        CargoMass = IStatus.CargoMass;
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
                                    Logger.Log(MethodName, "Firegroup Settings Updated", Logger.Green);
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
