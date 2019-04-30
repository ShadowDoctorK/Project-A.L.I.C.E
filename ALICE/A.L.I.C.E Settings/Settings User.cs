using ALICE_Internal;
using ALICE_Status;
using System.Collections.Generic;

namespace ALICE_Settings
{
    /// <summary>
    /// This is a collection of the users settings from various parts of the Core Files.
    /// These settings are controlled completely by the user and have no source from the game.
    /// </summary>
    public class SettingsUser : SettingsUtilities
    {
        public string Commander { get; set; } = "Default";

        public Dictionary<string, Settings> Storage { get; set; } = new Dictionary<string, Settings>()
        {
            { "Default", new Settings() }
        };

        public void LogMissingCommander(string M)
        {
            //Debug Logger
            Logger.DebugLine(M, "User Settings Does Not Have An Entry For (" + IStatus.Commander + ")", Logger.Yellow);
        }

        public void Save()
        {
            SaveValues<SettingsUser>(ISettings.User, "User.Settings");
        }

        public SettingsUser Load()
        {
            return (SettingsUser)LoadValues<SettingsUser>("User.Settings");
        }

        #region Get Values
        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public string CMDR()
        {
            //Return Value
            return Storage[Commander].Commander;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public string BindsFile()
        {
            //Return Value
            return Storage[Commander].BindsFile;
        }

        #region Plugin
        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public int OffsetPanels()
        {
            //Return Value
            return Storage[Commander].OffsetPanels;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public int OffsetPips()
        {
            //Return Value
            return Storage[Commander].OffsetPips;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public int OffsetThrottle()
        {
            //Return Value
            return Storage[Commander].OffsetThrottle;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public int OffsetFireGroups()
        {
            //Return Value
            return Storage[Commander].OffsetFireGroups;
        }
        #endregion

        #region Orders
        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool WeaponSafety()
        {
            //Return Value
            return Storage[Commander].WeaponSafety;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool CombatPower()
        {
            //Return Value
            return Storage[Commander].CombatPower;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool AssistSystemScan()
        {
            //Return Value
            return Storage[Commander].AssistSystemScan;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool AssistDocking()
        {
            //Return Value
            return Storage[Commander].AssistDocking;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool AssistHangerEntry()
        {
            //Return Value
            return Storage[Commander].AssistHangerEntry;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool PostHyperspaceSafety()
        {
            //Return Value
            return Storage[Commander].PostHyperspaceSafety;
        }
        #endregion

        #region Reports
        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool FuelScoop()
        {
            //Return Value
            return Storage[Commander].FuelScoop;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool FuelStatus()
        {
            //Return Value
            return Storage[Commander].FuelStatus;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool MaterialCollected()
        {
            //Return Value
            return Storage[Commander].MaterialCollected;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool MaterialRefined()
        {
            //Return Value
            return Storage[Commander].MaterialRefined;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool NoFireZone()
        {
            //Return Value
            return Storage[Commander].NoFireZone;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool ShieldState()
        {
            //Return Value
            return Storage[Commander].ShieldState;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool StationStatus()
        {
            //Return Value
            return Storage[Commander].StationStatus;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool CollectedBounty()
        {
            //Return Value
            return Storage[Commander].CollectedBounty;
        }

        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool TargetEnemy()
        {
            //Return Value
            return Storage[Commander].TargetEnemy;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool TargetWanted()
        {
            //Return Value
            return Storage[Commander].TargetWanted;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool Masslock()
        {
            //Return Value
            return Storage[Commander].Masslock;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool HighGravDescent()
        {
            //Return Value
            return Storage[Commander].HighGravDescent;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool GlideStatus()
        {
            //Return Value
            return Storage[Commander].GlideStatus;
        }

        #region Navigation
        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool ScanTravelDist()
        {
            //Return Value
            return Storage[Commander].ScanTravelDist;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool LandableVolcanism()
        {
            //Return Value
            return Storage[Commander].LandableVolcanism;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public int ScanDistLimit()
        {
            //Return Value
            return Storage[Commander].ScanDistLimit;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool BodyEarthLike()
        {
            //Return Value
            return Storage[Commander].BodyEarthLike;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool BodyWaterTerra()
        {
            //Return Value
            return Storage[Commander].BodyWaterTerra;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool BodyHMCTerra()
        {
            //Return Value
            return Storage[Commander].BodyHMCTerra;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool BodyAmmonia()
        {
            //Return Value
            return Storage[Commander].BodyAmmonia;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool BodyRockyTerra()
        {
            //Return Value
            return Storage[Commander].BodyRockyTerra;
        }
        
        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool BodyWater()
        {
            //Return Value
            return Storage[Commander].BodyWater;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool BodyMetalRich()
        {
            //Return Value
            return Storage[Commander].BodyMetalRich;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool BodyGasGiantII()
        {
            //Return Value
            return Storage[Commander].BodyGasGiantII;
        }

        /// <summary>
        /// Get The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        public bool BodyHMC()
        {
            //Return Value
            return Storage[Commander].BodyHMC;
        }

        //End: Navigation
        #endregion

        //End: Reports
        #endregion

        //End: Get Values
        #endregion

        #region Set Values
        public void CMDR(string M, string C)
        {
            //Update Tracked Value
            Commander = C;

            if (Storage.ContainsKey(C) == false)
            {
                //Add New Commander
                Storage.Add(C, new Settings());

                //Debug Logger
                Logger.DebugLine(M, "New Commander Settings Created (" + C + ")", Logger.Yellow);

                //Save Settings
                ISettings.User.Save();
            }
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void BindsFile(string M, string V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].BindsFile != V)
                {
                    Storage[Commander].BindsFile = V;

                    //Logger
                    Logger.Simple("Binds File = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        #region Plugin
        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void OffsetPanels(string M, int V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].OffsetPanels != V)
                {
                    Storage[Commander].OffsetPanels = V;

                    //Logger
                    Logger.Simple("Panel Offset = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void OffsetPips(string M, int V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].OffsetPips != V)
                {
                    Storage[Commander].OffsetPips = V;

                    //Logger
                    Logger.Simple("Power Offset = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void OffsetThrottle(string M, int V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].OffsetThrottle != V)
                {
                    Storage[Commander].OffsetThrottle = V;

                    //Logger
                    Logger.Simple("Throttle Offset = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void OffsetFireGroups(string M, int V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].OffsetFireGroups != V)
                {
                    Storage[Commander].OffsetFireGroups = V;

                    //Logger
                    Logger.Simple("Fire Group Offset = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }      
        #endregion

        #region Orders
        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void WeaponSafety(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].WeaponSafety != V)
                {
                    Storage[Commander].WeaponSafety = V;

                    //Logger
                    Logger.Simple("Weapon Safeties = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void CombatPower(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].CombatPower != V)
                {
                    Storage[Commander].CombatPower = V;

                    //Logger
                    Logger.Simple("Assisted Combat Power = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void AssistSystemScan(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].AssistSystemScan != V)
                {
                    Storage[Commander].AssistSystemScan = V;

                    //Logger
                    Logger.Simple("Assisted System Scans = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void AssistDocking(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].AssistDocking != V)
                {
                    Storage[Commander].AssistDocking = V;

                    //Logger
                    Logger.Simple("Assisted Docking Procedures = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void AssistHangerEntry(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].AssistHangerEntry != V)
                {
                    Storage[Commander].AssistHangerEntry = V;

                    //Logger
                    Logger.Simple("Assisted Hanger Entry = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void PostHyperspaceSafety(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].PostHyperspaceSafety != V)
                {
                    Storage[Commander].PostHyperspaceSafety = V;

                    //Logger
                    Logger.Simple("Post Jump Safeties = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }
        #endregion

        #region Reports
        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void FuelScoop(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].FuelScoop != V)
                {
                    Storage[Commander].FuelScoop = V;

                    //Logger
                    Logger.Simple("Report: Fuel Scoop = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void FuelStatus(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(Commander))
            {
                //Update Value
                if (Storage[Commander].FuelStatus != V)
                {
                    Storage[Commander].FuelStatus = V;

                    //Logger
                    Logger.Simple("Report: Fuel Status = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void MaterialCollected(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].MaterialCollected != V)
                {
                    Storage[IStatus.Commander].MaterialCollected = V;

                    //Logger
                    Logger.Simple("Report: Material Collected = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void MaterialRefined(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].MaterialRefined != V)
                {
                    Storage[IStatus.Commander].MaterialRefined = V;

                    //Logger
                    Logger.Simple("Report: Material Refined = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void NoFireZone(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].NoFireZone != V)
                {
                    Storage[IStatus.Commander].NoFireZone = V;

                    //Logger
                    Logger.Simple("Report: No Fire Zone = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void ShieldState(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].ShieldState != V)
                {
                    Storage[IStatus.Commander].ShieldState = V;

                    //Logger
                    Logger.Simple("Report: Shield State = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void StationStatus(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].StationStatus != V)
                {
                    Storage[IStatus.Commander].StationStatus = V;

                    //Logger
                    Logger.Simple("Report: Station Status = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void CollectedBounty(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].CollectedBounty != V)
                {
                    Storage[IStatus.Commander].CollectedBounty = V;

                    //Logger
                    Logger.Simple("Report: Collected Bounty = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void TargetEnemy(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].TargetEnemy != V)
                {
                    Storage[IStatus.Commander].TargetEnemy = V;

                    //Logger
                    Logger.Simple("Report: Hostile Factions = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void TargetWanted(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].TargetWanted != V)
                {
                    Storage[IStatus.Commander].TargetWanted = V;

                    //Logger
                    Logger.Simple("Report: Wanted Targets = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void Masslock(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].Masslock != V)
                {
                    Storage[IStatus.Commander].Masslock = V;

                    //Logger
                    Logger.Simple("Report: Masslock = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void HighGravDescent(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].HighGravDescent != V)
                {
                    Storage[IStatus.Commander].HighGravDescent = V;

                    //Logger
                    Logger.Simple("Report: High Gravity Descent = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void GlideStatus(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].GlideStatus != V)
                {
                    Storage[IStatus.Commander].GlideStatus = V;

                    //Logger
                    Logger.Simple("Report: Glide Status = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        #region Navigation
        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void ScanTravelDist(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].ScanTravelDist != V)
                {
                    Storage[IStatus.Commander].ScanTravelDist = V;

                    //Logger
                    Logger.Simple("Report: Trave Distance Threshold = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void LandableVolcanism(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].LandableVolcanism != V)
                {
                    Storage[IStatus.Commander].LandableVolcanism = V;

                    //Logger
                    Logger.Simple("Report: Landable Volcanism = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void ScanDistLimit(string M, int V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].ScanDistLimit != V)
                {
                    Storage[IStatus.Commander].ScanDistLimit = V;

                    //Logger
                    Logger.Simple("Report: Travel Distance Threshold = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void BodyEarthLike(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].BodyEarthLike != V)
                {
                    Storage[IStatus.Commander].BodyEarthLike = V;

                    //Logger
                    Logger.Simple("Report: EarthLike Worlds = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void BodyWaterTerra(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].BodyWaterTerra != V)
                {
                    Storage[IStatus.Commander].BodyWaterTerra = V;

                    //Logger
                    Logger.Simple("Report: Water Worlds (Terraformable) = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void BodyHMCTerra(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].BodyHMCTerra != V)
                {
                    Storage[IStatus.Commander].BodyHMCTerra = V;

                    //Logger
                    Logger.Simple("Report: High Metal Content (Terraformable) = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void BodyAmmonia(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].BodyAmmonia != V)
                {
                    Storage[IStatus.Commander].BodyAmmonia = V;

                    //Logger
                    Logger.Simple("Report: Ammonia Worlds = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void BodyRockyTerra(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].BodyRockyTerra != V)
                {
                    Storage[IStatus.Commander].BodyRockyTerra = V;

                    //Logger
                    Logger.Simple("Report: Rocky (Terraformable) = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void BodyWater(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].BodyWater != V)
                {
                    Storage[IStatus.Commander].BodyWater = V;

                    //Logger
                    Logger.Simple("Report: Water Worlds = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void BodyMetalRich(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].BodyMetalRich != V)
                {
                    Storage[IStatus.Commander].BodyMetalRich = V;

                    //Logger
                    Logger.Simple("Report: Metal Rich = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void BodyGasGiantII(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].BodyGasGiantII != V)
                {
                    Storage[IStatus.Commander].BodyGasGiantII = V;

                    //Logger
                    Logger.Simple("Report: Gas Giant II = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }

        /// <summary>
        /// Updates The Matching User Setting For the Loaded User
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="V">(Value) The Being Set.</param>
        public void BodyHMC(string M, bool V, bool S = false)
        {
            if (Storage.ContainsKey(IStatus.Commander))
            {
                //Update Value
                if (Storage[IStatus.Commander].BodyHMC != V)
                {
                    Storage[IStatus.Commander].BodyHMC = V;

                    //Logger
                    Logger.Simple("Report: High Metal Content = " + V, Logger.Green);

                    //Save Settings
                    if (S)
                    {
                        ISettings.User.Save();
                    }
                }

                return;
            }

            LogMissingCommander(M);
        }
        //End: Navigation
        #endregion

        //End: Reports
        #endregion

        //End: Set Values
        #endregion

        public class Settings
        {
            public string Commander { get; set; } = "Default";

            #region Plugin
            //Speed Offsets
            public int OffsetPanels { get; set; } = 0;
            public int OffsetPips { get; set; } = 0;
            public int OffsetFireGroups { get; set; } = 0;
            public int OffsetThrottle { get; set; } = 0;

            //Keybinds
            public bool UsersBindFile { get; set; } = false;
            public string BindsFile { get; set; } = "A.L.I.C.E Profile.3.0.binds";
            #endregion

            #region Orders
            public bool WeaponSafety { get; set; } = true;
            public bool CombatPower { get; set; } = true;
            public bool AssistSystemScan { get; set; } = false;
            public bool AssistDocking { get; set; } = false;
            public bool AssistRefuel { get; set; } = false;
            public bool AssistRearm { get; set; } = false;
            public bool AssistRepair { get; set; } = false;
            public bool AssistHangerEntry { get; set; } = true;
            public bool PostHyperspaceSafety { get; set; } = true;
            #endregion

            #region Reports                                         
            public bool FuelScoop { get; set; } = true;
            public bool FuelStatus { get; set; } = true;
            public bool MaterialCollected { get; set; } = true;
            public bool MaterialRefined { get; set; } = true;
            public bool NoFireZone { get; set; } = true;
            public bool StationStatus { get; set; } = true;
            public bool ShieldState { get; set; } = true;
            public bool CollectedBounty { get; set; } = true;
            public bool TargetEnemy { get; set; } = true;
            public bool TargetWanted { get; set; } = true;
            public bool Masslock { get; set; } = true;
            public bool HighGravDescent { get; set; } = true;
            public bool GlideStatus { get; set; } = true;
            public bool ScanTravelDist { get; set; } = true;
            public bool LandableVolcanism { get; set; } = true;
            #endregion

            #region Exploration                                       
            public int ScanDistLimit { get; set; } = 0;
            public bool BodyEarthLike { get; set; } = true;
            public bool BodyWaterTerra { get; set; } = true;
            public bool BodyHMCTerra { get; set; } = true;
            public bool BodyAmmonia { get; set; } = true;
            public bool BodyRockyTerra { get; set; } = true;
            public bool BodyWater { get; set; } = true;
            public bool BodyMetalRich { get; set; } = true;
            public bool BodyGasGiantII { get; set; } = false;
            public bool BodyHMC { get; set; } = false;
            #endregion
        }
    }
}
