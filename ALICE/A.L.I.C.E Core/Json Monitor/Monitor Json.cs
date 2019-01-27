using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using ALICE_Actions;
using ALICE_Objects;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using ALICE_Interface;
using ALICE_Internal;
using ALICE_Events;
using ALICE_Core;
using ALICE_EventLogic;

namespace ALICE_Monitors
{
    public class Monitor_Json
    {
        #region Properties
        //Settings
        private DirectoryInfo GameData = new DirectoryInfo(Paths.LogDirectory);
        public MonitorSettings Settings { get; set; }

        //FileData Objects
        public FileCargo Cargo = new FileCargo(false);
        public FileMarket Market = new FileMarket(false);
        public FileModules Modules = new FileModules(false);
        public FileOutfitting Outfitting = new FileOutfitting(false);
        public FileShipyard Shipyard = new FileShipyard(false);
        public FileStatus Status = new FileStatus(false);

        //Utilites
        public Checks Check = new Checks();

        //Collections
        public List<string> Storage;
        private string Line = "";
        #endregion

        #region Constructors
        /// <summary>
        /// Will create a Json Montior with all options set to default.
        /// Settings: Enabled = True, Initialized = False, AutoRestart = True
        /// Cargo.Json = Enabled
        /// Market.Json = Enabled
        /// Modules.Json = Enabled
        /// Outfitting.Json = Enabled
        /// Shipyard.Json = Enabled
        /// Status.Json = Enabled
        /// </summary>
        public Monitor_Json()
        {
            Settings = new MonitorSettings(true, false, true);
            Cargo = new FileCargo(true);
            Market = new FileMarket(true);
            Modules = new FileModules(true);
            Outfitting = new FileOutfitting(true);
            Shipyard = new FileShipyard(true);
            Status = new FileStatus(true);
        }

        /// <summary>
        /// Will create a Json Monitor with all the options set by the User.
        /// </summary>
        /// <param name="E">Enable Monitor</param>
        /// <param name="I">Monitor Initiliaztion State On Start</param>
        /// <param name="R">AutoRestart on Failure / Exceptions</param>
        /// <param name="Car">Monitor Cargo.Json</param>
        /// <param name="Mar">Monitor Market.Json</param>
        /// <param name="Mod">Monitor Modules.Json</param>
        /// <param name="Out">Monitor Outfitting.Json</param>
        /// <param name="Shi">Monitor Shipyard.Json</param>
        /// <param name="Sta">Monitor Status.Json</param>
        public Monitor_Json(bool E, bool I, bool R, bool Car = true, bool Mar = true, bool Mod = true, bool Out = true, bool Shi = true, bool Sta = true)
        {
            Settings = new MonitorSettings(E, I, R);
            Cargo = new FileCargo(Car);
            Market = new FileMarket(Mar);
            Modules = new FileModules(Mod);
            Outfitting = new FileOutfitting(Out);
            Shipyard = new FileShipyard(Shi);
            Status = new FileStatus(Sta);
        }
        #endregion

        public void Start()
        {
            string MethodName = "Json Monitor";

            try
            {                               
                //Enter Monitor State And Lock The Door Behind Us...
                if (Monitor.TryEnter(Settings.Lock))
                {
                    //Start Monitoring
                    Start: try
                    {
                        while (Settings.Enabled)
                        {
                            //Cargo.Json Check
                            try
                            {
                                if (Cargo.Enabled && Cargo.File == null) { Cargo.GetFileInfo(); }
                                if (Cargo.Enabled && Cargo.File != null && CheckFile(ref Cargo.File, ref Cargo.InitialLoad))
                                {
                                    UpdateCargo();
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "(Cargo.Json) The Cargo Hamster Is Trying To Fix His Wheel...");
                            }

                            //Market.Json Check
                            try
                            {
                                if (Market.Enabled && Market.File == null) { Market.GetFileInfo(); }
                                if (Market.Enabled && Market.File != null && CheckFile(ref Market.File, ref Market.InitialLoad))
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "(Market.Json) The Market Hamster Is Trying To Fix His Wheel...");
                            }

                            //Modules.Json Check
                            try
                            {
                                if (Modules.Enabled && Modules.File == null) { Modules.GetFileInfo(); }
                                if (Modules.Enabled && Modules.File != null && CheckFile(ref Modules.File, ref Modules.InitialLoad))
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "(Modules.Json) The Modules Hamster Is Trying To Fix His Wheel...");
                            }

                            //Outfitting.Json Check
                            try
                            {
                                if (Outfitting.Enabled && Outfitting.File == null) { Outfitting.GetFileInfo(); }
                                if (Outfitting.Enabled && Outfitting.File != null && CheckFile(ref Outfitting.File, ref Outfitting.InitialLoad))
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "(Outfitting.Json) The Outfitting Hamster Is Trying To Fix His Wheel...");
                            }

                            //Shipyard.Json Check
                            try
                            {
                                if (Shipyard.Enabled && Shipyard.File == null) { Shipyard.GetFileInfo(); }
                                if (Shipyard.Enabled && Shipyard.File != null && CheckFile(ref Shipyard.File, ref Shipyard.InitialLoad))
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "(Shipyard.Json) The Shipyard Hamster Is Trying To Fix His Wheel...");
                            }

                            //Status.Json Check
                            try
                            {
                                if (Status.Enabled && Status.File == null) { Status.GetFileInfo(); }
                                if (Status.Enabled && Status.File != null && CheckFile(ref Status.File, ref Status.InitialLoad))
                                {
                                    UpdateStatus();
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "(Status.Json) The Status Hamster Is Trying To Fix His Wheel...");
                            }

                            //Check Initialized
                            if (Settings.Initialized == false)
                            {
                                //Log Init
                                Settings.Initialized = true;
                            }

                            //Sleep for 1/10th Of A Second
                            Thread.Sleep(100);
                        }                         
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(MethodName, "Exception: " + ex);
                        Logger.Exception(MethodName, "The Hamsters Are Running Away...");

                        if (Settings.AutoRestart)
                        {
                            //Log Restarting
                            Logger.Exception(MethodName, "(Restarting) We Caught The Hamsters, Lets Try Again...");
                            goto Start;
                        }
                        else
                        {
                            //Log Exiting
                            Logger.Exception(MethodName, "(Stopping) The Hamsters Got Away...");
                        }
                    }
                    finally
                    {
                        Monitor.Exit(Settings.Lock);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "All The Hamsters Died, The Wheels Stopped Turning...");
            }
        }

        /// <summary>
        /// Process' The Cargo.json File.
        /// </summary>
        private void UpdateCargo()
        {
            string MethodName = "Cargo Update";

            try
            {
                //Read File                
                using (StreamReader SR = new StreamReader(GetFileStream(Cargo.File.FullName)))
                {
                    if (!SR.EndOfStream) { Line = SR.ReadLine(); }
                }

                var Value = JsonConvert.DeserializeObject<ALICE_Events.Cargo>(Line);

                #region Logic Processor: Cargo
                switch (Value.Vessel)
                {
                    case "Ship":

                        break;

                    default:
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "(Failed) The Cargo Hamster Made A Mistake And Forgot What He Was Doing...");
            }
        }

        /// <summary>
        /// Process' The Status.json File.
        /// </summary>
        private void UpdateStatus()
        {
            string MethodName = "Status Update";

            try
            {
                //Read File                
                using (StreamReader SR = new StreamReader(GetFileStream(Status.File.FullName)))
                {                    
                    if (!SR.EndOfStream) { Line = SR.ReadLine(); }
                }

                var Value = JsonConvert.DeserializeObject<ALICE_Events.Status>(Line);

                #region Logic Processor: Status

                #region Flags

                #region Night Vision
                if (Value.Flags >= 268435456)
                {
                    Value.Flags = Value.Flags - 268435456;
                    IObjects.Status.NightVision = true;
                }
                else
                {
                    IObjects.Status.NightVision = false;
                }
                #endregion

                #region Analysis Mode
                if (Value.Flags >= 134217728)
                {
                    Value.Flags = Value.Flags - 134217728;
                    IObjects.Status.AnalysisMode = true;
                }
                else
                {
                    IObjects.Status.AnalysisMode = false;
                }
                #endregion

                #region Vehicle Flags
                if (Value.Flags >= 67108864)
                {
                    IVehicles.Vehicle = IVehicles.V.SRV;
                    Value.Flags = Value.Flags - 67108864;
                }
                if (Value.Flags >= 33554432)
                {
                    IVehicles.Vehicle = IVehicles.V.Fighter;
                    Value.Flags = Value.Flags - 33554432;
                }
                if (Value.Flags >= 16777216)
                {
                    IVehicles.Vehicle = IVehicles.V.Mothership;
                    Value.Flags = Value.Flags - 16777216;
                }
                #endregion

                #region Interdiction Flag
                if (Value.Flags >= 8388608)
                {
                    IObjects.Status.Interdiction = true;
                    Value.Flags = Value.Flags - 8388608;
                }
                else
                {
                    IObjects.Status.Interdiction = false;
                }
                #endregion

                #region Is In Danger Flag
                if (Value.Flags >= 4194304)
                {
                    IObjects.Status.InDanger = true;
                    Value.Flags = Value.Flags - 4194304;
                }
                else
                {
                    IObjects.Status.InDanger = false;
                }
                #endregion

                #region Has Lat & Lon Flag
                if (Value.Flags >= 2097152)
                {
                    IObjects.Status.HasLatLong = true;
                    Value.Flags = Value.Flags - 2097152;
                    Process.Position(Value.Latitude, Value.Longitude, Value.Altitude, Value.Heading);

                    Call.Report.GPSLocation.Status(false);
                }
                else
                {
                    IObjects.Status.HasLatLong = false;

                    Call.Report.GPSLocation.Status(false);
                }
                #endregion

                #region Overheating Flag
                if (Value.Flags >= 1048576)
                {
                    Value.Flags = Value.Flags - 1048576;
                    IObjects.Status.Overheating = true;
                }
                else
                {
                    IObjects.Status.Overheating = false;
                }
                #endregion

                #region Low Fuel (25%) Flag
                if (Value.Flags >= 524288)
                {
                    Value.Flags = Value.Flags - 524288;
                    IObjects.Status.LowFuel = true;
                }
                else
                {
                    IObjects.Status.LowFuel = false;
                }
                #endregion

                #region FSD Cooldown
                if (Value.Flags >= 262144)
                {
                    Value.Flags = Value.Flags - 262144;
                    IEquipment.FrameShiftDrive.Cooldown = true;

                    Call.Report.FSDCooldown.Status(true);
                }
                else
                {
                    IEquipment.FrameShiftDrive.Cooldown = false;

                    Call.Report.FSDCooldown.Status(false);
                }
                #endregion

                #region FSD Charging
                if (Value.Flags >= 131072)
                {
                    //FSD Charging
                    Value.Flags = Value.Flags - 131072;
                    IEquipment.FrameShiftDrive.Charging = true;
                    Call.Report.FSDCharging.Status(true);
                }
                else
                {
                    IEquipment.FrameShiftDrive.Charging = false;
                    IEquipment.FrameShiftDrive.Hyperspace = false;
                    IEquipment.FrameShiftDrive.Supercruise = false;
                    Call.Report.FSDCharging.Status(false);
                }
                #endregion

                #region Masslocked
                if (Value.Flags >= 65536)
                {
                    Value.Flags = Value.Flags - 65536;
                    IObjects.Status.Masslocked = true;

                    IEvents.Masslock.Construct(true);
                }
                else
                {
                    IObjects.Status.Masslocked = false;

                    IEvents.Masslock.Construct(false);
                }
                #endregion

                #region SRV Drive Assist
                if (Value.Flags >= 32768)
                {
                    //SRV Drive Assist
                    Value.Flags = Value.Flags - 32768;
                    IObjects.Status.SRV_DriveAssist = true;
                }
                else
                {
                    IObjects.Status.SRV_DriveAssist = false;
                }
                #endregion

                #region SRV Close To Mothership
                if (Value.Flags >= 16384)
                {
                    //SRV Under Ship
                    Value.Flags = Value.Flags - 16384;
                    IObjects.Status.SRV_NearMothership = true;
                }
                else
                {
                    IObjects.Status.SRV_NearMothership = false;
                }
                #endregion

                #region SRV Turret
                if (Value.Flags >= 8192)
                {
                    //SRV Turret
                    IObjects.Status.SRV_Turret = true;
                    Value.Flags = Value.Flags - 8192;
                }
                else
                {
                    IObjects.Status.SRV_Turret = false;
                }
                #endregion

                #region SRV Handbreak
                if (Value.Flags >= 4096)
                {
                    //SRV Handbreak
                    IObjects.Status.SRV_Handbreak = true;
                    Value.Flags = Value.Flags - 4096;
                }
                else
                {
                    IObjects.Status.SRV_Handbreak = false;
                }
                #endregion

                #region Scooping Fuel
                if (Value.Flags >= 2048)
                {
                    IObjects.Status.FuelScooping = true;
                    Value.Flags = Value.Flags - 2048;

                    if (IObjects.Mothership.F.ScoopingCommenced == false && Settings.Initialized)
                    { IObjects.Mothership.F.ReportScooping(MethodName); }
                }
                else
                {
                    IObjects.Status.FuelScooping = false;
                    if (IObjects.Mothership.F.ScoopingCommenced == true && Settings.Initialized)
                    { IObjects.Mothership.F.ReportScooping(MethodName); }
                    //Reset variables once we finish scooping.
                    if (IObjects.Mothership.F.ScoopingCompleted == true && Settings.Initialized)
                    { Thread.Sleep(100); IObjects.Mothership.F.ScoopingReset(); }
                }
                #endregion

                #region Silent Running
                if (Value.Flags >= 1024)
                {
                    //Silent Running
                    Value.Flags = Value.Flags - 1024;
                    IObjects.Status.SilentRunning = true;

                    Call.Report.SilentRunning.Status(true);
                }
                else
                {
                    IObjects.Status.SilentRunning = false;

                    Call.Report.SilentRunning.Status(false);
                }
                #endregion

                #region Cargo Scoop
                if (Value.Flags >= 512)
                {
                    //Cargo Scoop Deployed
                    Value.Flags = Value.Flags - 512;
                    IObjects.Status.CargoScoop = true;
                }
                else
                {
                    IObjects.Status.CargoScoop = false;
                }
                #endregion

                #region External Lights
                if (Value.Flags >= 256)
                {
                    //Light On
                    Value.Flags = Value.Flags - 256;
                    IObjects.Status.Lights = true;
                }
                else
                {
                    IObjects.Status.Lights = false;
                }
                #endregion

                #region In A Wing
                if (Value.Flags >= 128)
                {
                    //In a Wing
                    Value.Flags = Value.Flags - 128;
                    IObjects.Status.InWing = true;
                }
                else
                {
                    IObjects.Status.InWing = false;
                }
                #endregion

                #region Hardpoints
                if (Value.Flags >= 64)
                {
                    //Hardpoints Deployed
                    IObjects.Status.Hardpoints = true;
                    Value.Flags = Value.Flags - 64;
                }
                else
                {
                    IObjects.Status.Hardpoints = false;
                }
                #endregion

                #region Flight Assist
                if (Value.Flags >= 32)
                {
                    //Flight Assist Off
                    IObjects.Status.FlightAssist = true;
                    Value.Flags = Value.Flags - 32;
                }
                else
                {
                    IObjects.Status.FlightAssist = false;
                }
                #endregion

                #region Supercruise
                if (Value.Flags >= 16)
                {
                    //Supercruise
                    IObjects.Status.Supercruise = true;
                    Value.Flags = Value.Flags - 16;
                }
                else
                {
                    IObjects.Status.Supercruise = false;
                }
                #endregion

                #region Shields
                //Shields Online...
                if (Value.Flags >= 8)
                {
                    IObjects.Status.Shields = true;
                    Value.Flags = Value.Flags - 8;

                    Call.Report.Shield.Status(true);
                }
                //Shields Offline...
                else
                {
                    IObjects.Status.Shields = false;

                    Call.Report.Shield.Status(false);
                }
                #endregion

                #region Landing Gear
                if (Value.Flags >= 4)
                {
                    //Landing Gear Down
                    IObjects.Status.LandingGear = true;
                    Value.Flags = Value.Flags - 4;
                }
                else
                {
                    IObjects.Status.LandingGear = false;
                }
                #endregion

                #region Touchdown
                if (Value.Flags >= 2)
                {
                    //Touchdown
                    IObjects.Status.Touchdown = true;
                    Value.Flags = Value.Flags - 2;
                }
                else
                {
                    IObjects.Status.Touchdown = false;
                }
                #endregion

                #region Docked
                if (Value.Flags == 1)
                {
                    IStatus.Docking.State = IEnums.DockingState.Docked;
                    IObjects.Status.Docked = true;
                    IObjects.Status.WeaponSafety = true;
                    Value.Flags = Value.Flags - 1;
                }
                else
                {
                    IObjects.Status.Docked = false;
                }
                #endregion

                if (Value.Flags != 0)
                {
                    Logger.Error(MethodName, "Please Inform The Developer.", Logger.Red);
                    Logger.Error(MethodName, "Warning, Accuracy Of The Game Information Can Not Be Verified. Some This Might Not Work Correctly.", Logger.Red);
                    Logger.Error(MethodName, "(" + Value.Flags + ") We Didn't Fully Resolve The Status Flag. Looks Like New Items Were Added.", Logger.Red);
                }

                //Flags End Region
                #endregion

                #region Pip Flag
                if (Value.Pips.Count != 0)
                {
                    Call.Power.Game.System = Value.Pips[0];
                    Call.Power.Game.Engine = Value.Pips[1];
                    Call.Power.Game.Weapon = Value.Pips[2];
                }
                #endregion

                #region Fire Group Flag
                Call.Firegroup.Current = Value.FireGroup + 1;
                #endregion

                #region GUI Flag
                IObjects.Status.GUI_Focus = Value.GuiFocus;

                #region 3.4 Panel Items
                if (IObjects.Status.GUI_Focus == 0)
                {
                    // No Focus - Close All Panels
                    Call.Panel.Comms.Open = false;
                    Call.Panel.Role.Open = false;
                    Call.Panel.System.Open = false;
                    Call.Panel.Target.Open = false;
                    Call.Panel.SystemMap.Open = false;
                    Call.Panel.GalaxyMap.Open = false;
                    //Call.Panel.StarportServicesFocus = false;
                }
                else if (IObjects.Status.GUI_Focus == 1)
                {
                    Call.Panel.System.Open = true;
                    Call.Panel.Comms.Open = false;
                    Call.Panel.Role.Open = false;
                    Call.Panel.Target.Open = false;
                    Call.Panel.SystemMap.Open = false;
                    Call.Panel.GalaxyMap.Open = false;
                }
                else if (IObjects.Status.GUI_Focus == 2)
                {
                    Call.Panel.Target.Open = true;
                    Call.Panel.Comms.Open = false;
                    Call.Panel.Role.Open = false;
                    Call.Panel.System.Open = false;
                    Call.Panel.SystemMap.Open = false;
                    Call.Panel.GalaxyMap.Open = false;

                }
                else if (IObjects.Status.GUI_Focus == 3)
                {
                    Call.Panel.Comms.Open = true;
                    Call.Panel.Role.Open = false;
                    Call.Panel.System.Open = false;
                    Call.Panel.Target.Open = false;
                    Call.Panel.SystemMap.Open = false;
                    Call.Panel.GalaxyMap.Open = false;

                }
                else if (IObjects.Status.GUI_Focus == 4)
                {
                    Call.Panel.Role.Open = true;
                    Call.Panel.Comms.Open = false;
                    Call.Panel.System.Open = false;
                    Call.Panel.Target.Open = false;
                    Call.Panel.SystemMap.Open = false;
                    Call.Panel.GalaxyMap.Open = false;
                }
                else if (IObjects.Status.GUI_Focus == 5)
                {
                    //Call.Panel.StarportServicesFocus = true;
                    Call.Panel.Comms.Open = false;
                    Call.Panel.Role.Open = false;
                    Call.Panel.System.Open = false;
                    Call.Panel.Target.Open = false;
                    Call.Panel.SystemMap.Open = false;
                    Call.Panel.GalaxyMap.Open = false;
                }
                else if (IObjects.Status.GUI_Focus == 6)
                {
                    Call.Panel.GalaxyMap.Open = true;
                    Call.Panel.Comms.Open = false;
                    Call.Panel.Role.Open = false;
                    Call.Panel.System.Open = false;
                    Call.Panel.Target.Open = false;
                    Call.Panel.SystemMap.Open = false;
                    //Call.Panel.StarportServicesFocus = false;
                }
                else if (IObjects.Status.GUI_Focus == 7)
                {
                    Call.Panel.SystemMap.Open = true;
                    Call.Panel.Comms.Open = false;
                    Call.Panel.Role.Open = false;
                    Call.Panel.System.Open = false;
                    Call.Panel.Target.Open = false;
                    Call.Panel.GalaxyMap.Open = false;
                    //Call.Panel.StarportServicesFocus = false;
                }
                #endregion

                #endregion

                IObjects.Status.Altitude = Value.Altitude;
                IObjects.Status.Latitude = Value.Latitude;
                IObjects.Status.Longitude = Value.Longitude;
                IObjects.Status.Heading = Value.Heading;
                IObjects.Status.CargoMass = Value.Cargo;

                IVehicles.SetFuelLevels(Value.Fuel);

                //End: Logic Processor: Status
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "(Failed) The Status Hamster Made A Mistake And Forgot What He Was Doing...");
            }
        }

        /// <summary>
        /// Checks Referenced File for Changes.
        /// </summary>
        /// <param name="F">FileInfo you want to check.</param>
        /// <returns>True for Updates</returns>
        private bool CheckFile(ref FileInfo F, ref bool InitialLoad)
        {
            string MethodName = "Json Monitor (Check File)";

            try
            {                
                //Check File Exist
                if (File.Exists(F.FullName) == false)
                {
                    //Log File Doesn't Exist
                    Logger.DebugLine(MethodName, F.Name + " Does Not Exist", Logger.Blue);
                    return false;
                }

                //Check For Newer Write Time.
                FileInfo Temp = new FileInfo(F.FullName);
                if (Temp.LastWriteTime != F.LastWriteTime || InitialLoad)
                {
                    //Save New FileInfo, Return True.
                    Logger.DebugLine(MethodName, F.Name + " Updated", Logger.Blue);
                    F = Temp; InitialLoad = false; return true;
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "(Failed) The Check Hamster Made A Mistake And Forgot What He Was Doing...");
            }

            //No Change, Return False.
            return false;
        }

        /// <summary>
        /// Opens A Readonly FileStream with ReadWrite sharing.
        /// </summary>
        /// <param name="FilePath">Path of your file.</param>
        /// <returns>Returns a FileStream.</returns>
        private FileStream GetFileStream(string FilePath)
        {
            return new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        #region Settings
        public class MonitorSettings
        {
            public bool Enabled { get; set; }
            public bool Initialized { get; set; }
            public bool AutoRestart { get; set; }
            public object Lock { get; set; }

            public MonitorSettings(bool E, bool I, bool R)
            {
                Lock = new object();
                Enabled = E;
                Initialized = I;
                AutoRestart = R;
            }
        }

        public class FileCargo : FileBase
        {
            public FileCargo(bool E)
            {
                File = null;
                Stamp = new DateTime();
                Enabled = E;
                Name = "Cargo.json";
            }
        }

        public class FileStatus : FileBase
        {
            public FileStatus(bool E)
            {
                File = null;
                Stamp = new DateTime();
                Enabled = E;
                Name = "Status.json";
            }
        }

        public class FileMarket : FileBase
        {
            public FileMarket(bool E)
            {
                File = null;
                Stamp = new DateTime();
                Enabled = E;
                Name = "Market.json";
            }
        }

        public class FileModules : FileBase
        {
            public FileModules(bool E)
            {
                File = null;
                Stamp = new DateTime();
                Enabled = E;
                Name = "Modules.json";
            }
        }

        public class FileOutfitting : FileBase
        {
            public FileOutfitting(bool E)
            {
                File = null;
                Stamp = new DateTime();
                Enabled = E;
                Name = "Outfitting.json";
            }
        }

        public class FileShipyard : FileBase
        {
            public FileShipyard(bool E)
            {
                File = null;
                Stamp = new DateTime();
                Enabled = E;
                Name = "Shipyard.json";
            }
        }

        public class FileBase
        {
            public FileInfo File = null;
            public DateTime Stamp { get; set; }
            public bool Enabled { get; set; }
            public string Name { get; set; }
            public bool InitialLoad = true;
            private DirectoryInfo GameData = new DirectoryInfo(Paths.LogDirectory);

            public void GetFileInfo()
            {
                string MethodName = "Json Mointor (File Target)";

                try
                {
                    //Find FileInfo
                    foreach (FileInfo Temp in GameData.EnumerateFiles(Name, SearchOption.TopDirectoryOnly))
                    {
                        File = Temp;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "(Failed) The File Hamster Made A Mistake And Forgot What He Was Doing...");
                }

                //Check If We Located File
                if (File != null)
                {                    
                    Logger.DebugLine(MethodName, Name + " Located", Logger.Blue);
                }
                else
                {
                    Logger.DebugLine(MethodName, Name + " Not Found", Logger.Red);
                }                
            }
        }
        #endregion

        #region Utilites
        public class Checks
        {
            
        }
        #endregion
    }
}
