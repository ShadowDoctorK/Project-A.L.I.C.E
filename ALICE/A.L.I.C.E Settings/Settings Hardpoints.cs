using ALICE_Actions;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Response;
using ALICE_Status;
using System.Collections.Generic;
using System.Threading;

namespace ALICE_Settings
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
        /// Gets Target Config If Exists, Creates A New One If It Doesn't.
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>        
        /// <param name="ID">(Ship ID) The Games Ship ID Number.</param>
        /// <returns>Ships Saved Loadout Event</returns>
        public void GetConfig(string M, decimal ID, string A)
        {
            string MethodName = ClassName + " (Get Config)";

            //Only Process Different IDs
            if (ShipID != ID)
            {
                //Retrieve Config
                if (Storage.ContainsKey(ID))
                {
                    Config = Storage[ID];

                    if (ID != -1)
                    {
                        Logger.Log("Firegroup Settings", "[Loaded] " + IStatus.Mothership.FingerPrint, Logger.Purple);
                    }                    
                }

                //New Config
                else
                {
                    Config = new ConfigurationHardpoints()
                    {
                        ShipAssignment = A
                    };

                    Storage.Add(ID, Config);
                }

                ShipID = ID;
                Assigntment = A;

                //Save Settings
                Save();
            }
        }

        /// <summary>
        /// Updates Target Config.
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>        
        /// <param name="ID">(Ship ID) The Games Ship ID Number.</param>
        /// <param name="A">(Ship Assignment) The Ship Type/Name.</param>
        /// <returns>Ships Saved Loadout Event</returns>
        public void UpdateConfig(string M, decimal ID, string A)
        {
            string MethodName = ClassName + " (Update Config)";

            //Update Config
            if (Storage.ContainsKey(ID))
            {
                //Update
                Storage[ID] = Config;

                //Save Settings
                Save();
            }
            else
            {
                //Error Logger
                Logger.Error(MethodName, "Ship ID " + ID + " Does Not Exist!", Logger.Red);
            }            
        }

        public void Save()
        {
            SaveValues<SettingsHardpoints>(ISettings.Firegroups, "Firegroup.Settings");
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

        /// <summary>
        /// Conducts validation checks on the target Equipment and assigns it if valid.
        /// </summary>
        /// <param name="Item">The target Equipment</param>
        /// <param name="FireGroup">The target Firegroup</param>
        /// <param name="FireMode">The target Fire Mode</param>
        public void Assign(Item Item, Group FireGroup, Fire FireMode)
        {
            string MethodName = "Assisted Firegroup (Assign)";

            switch (Item)
            {
                case Item.Weapons1:

                    //Default Weapons Group
                    Weapons1 = new Assignemnt(FireGroup, Fire.Primary, Item);
                    IResponse.Hardpoints.MainWeaponsAssigned(ToText(FireGroup), true);
                    break;

                case Item.Weapons2:

                    //Default Weapons Group
                    Weapons2 = new Assignemnt(FireGroup, Fire.Primary, Item);
                    IResponse.Hardpoints.SecondaryWeaponsAssigned(ToText(FireGroup), true);
                    break;

                case Item.ECM:
                    #region Code
                    if (ICheck.Mothership.M.ECM(MethodName, true))
                    {
                        ECM = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ECM.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ECM.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LimpetCollector:
                    #region Code
                    if (ICheck.Mothership.M.CollectorLimpet(MethodName, true))
                    {
                        LimpetCollector = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.CollectorLimpets.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.CollectorLimpets.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LimpetDecontamination:
                    #region Code
                    if (ICheck.Mothership.M.DecontaminationLimpet(MethodName, true))
                    {
                        LimpetDecontamination = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.DecontaminationLimpets.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.DecontaminationLimpets.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LimpetFuel:
                    #region Code
                    if (ICheck.Mothership.M.FuelLimpet(MethodName, true))
                    {
                        LimpetFuel = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.FuelLimpets.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.FuelLimpets.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LimpetHatchBreaker:
                    #region Code
                    if (ICheck.Mothership.M.HatchBreakerLimpet(MethodName, true))
                    {
                        LimpetHatchBreaker = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.HatchBreakerLimpets.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.HatchBreakerLimpets.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LimpetRecon:
                    #region Code
                    if (ICheck.Mothership.M.ReconLimpet(MethodName, true))
                    {
                        LimpetRecon = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ReconLimpets.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ReconLimpets.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LimpetRepair:
                    #region Code
                    if (ICheck.Mothership.M.RepairLimpet(MethodName, true))
                    {
                        LimpetRepair = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.RepairLimpets.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.RepairLimpets.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LimpetResearch:
                    #region Code
                    if (ICheck.Mothership.M.ResearchLimpet(MethodName, true))
                    {
                        LimpetResearch = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ResearchLimpets.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ResearchLimpets.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LimpetProspector:
                    #region Code
                    if (ICheck.Mothership.M.ProspectorLimpet(MethodName, true))
                    {
                        LimpetProspector = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ProspectorLimpets.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ProspectorLimpets.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LauncherHeatSinkOne:
                    #region Code
                    if (ICheck.Mothership.M.HeatSink(MethodName, true))
                    {
                        LauncherHeatSinkOne = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.Heatsink.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.Heatsink.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LauncherHeatSinkTwo:
                    #region Code
                    if (ICheck.Mothership.M.HeatSink(MethodName, true))
                    {
                        LauncherHeatSinkTwo = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.Heatsink.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.Heatsink.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LauncherHeatSinkThree:
                    #region Code
                    if (ICheck.Mothership.M.HeatSink(MethodName, true))
                    {
                        LauncherHeatSinkThree = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.Heatsink.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.Heatsink.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LauncherHeatSinkFour:
                    #region Code
                    if (ICheck.Mothership.M.HeatSink(MethodName, true))
                    {
                        LauncherHeatSinkFour = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.Heatsink.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.Heatsink.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LauncherChaffOne:
                    #region Code
                    if (ICheck.Mothership.M.Chaff(MethodName, true))
                    {
                        LauncherChaffOne = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ChaffLauncher.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ChaffLauncher.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LauncherChaffTwo:
                    #region Code
                    if (ICheck.Mothership.M.Chaff(MethodName, true))
                    {
                        LauncherChaffTwo = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ChaffLauncher.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ChaffLauncher.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LauncherChaffThree:
                    #region Code
                    if (ICheck.Mothership.M.Chaff(MethodName, true))
                    {
                        LauncherChaffThree = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ChaffLauncher.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ChaffLauncher.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LauncherChaffFour:
                    #region Code
                    if (ICheck.Mothership.M.Chaff(MethodName, true))
                    {
                        LauncherChaffFour = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ChaffLauncher.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ChaffLauncher.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.LaserMinning:
                    #region Code
                    if (ICheck.Mothership.M.MiningLaser(MethodName, true))
                    {
                        LaserMinning = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.MiningLaser.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.MiningLaser.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.ScannerCagro:
                    #region Code
                    if (ICheck.Mothership.M.CargoScanner(MethodName, true))
                    {
                        ScannerCagro = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.CargoScanner.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.CargoScanner.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.ScannerComposite:
                    #region Code
                    //No Check Required. Default Ship Equipment.
                    ScannerComposite = new Assignemnt(FireGroup, FireMode, Item);
                    IResponse.CompositeScanner.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    break;
                #endregion

                case Item.ScannerDiscovery:
                    #region Code
                    //No Check Required. Default Ship Equipment.
                    ScannerDiscovery = new Assignemnt(FireGroup, FireMode, Item);
                    IResponse.DiscoveryScanner.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    break;
                #endregion

                case Item.ScannerKillwarrent:
                    #region Code
                    if (ICheck.Mothership.M.KillWarrantScanner(MethodName, true))
                    {
                        ScannerKillwarrent = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.KillWarrentScanner.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.KillWarrentScanner.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.ScannerSurface:
                    #region Code
                    if (ICheck.Mothership.M.SurfaceScanner(MethodName, true))
                    {
                        ScannerSurface = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.SurfaceScanner.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.SurfaceScanner.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.ScannerXeno:
                    #region Code
                    if (ICheck.Mothership.M.XenoScanner(MethodName, true))
                    {
                        ScannerXeno = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.XenoScanner.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.XenoScanner.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.ScannerWake:
                    #region Code
                    if (ICheck.Mothership.M.WakeScanner(MethodName, true))
                    {
                        ScannerWake = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.WakeScanner.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.WakeScanner.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.ShieldCellOne:
                    #region Code
                    if (ICheck.Mothership.M.ShieldCell(MethodName, true))
                    {
                        ShieldCellOne = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ShieldCell.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ShieldCell.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.ShieldCellTwo:
                    #region Code
                    if (ICheck.Mothership.M.ShieldCell(MethodName, true))
                    {
                        ShieldCellTwo = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ShieldCell.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ShieldCell.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.ShieldCellThree:
                    #region Code
                    if (ICheck.Mothership.M.ShieldCell(MethodName, true))
                    {
                        ShieldCellThree = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ShieldCell.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ShieldCell.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.ShieldCellFour:
                    #region Code
                    if (ICheck.Mothership.M.ShieldCell(MethodName, true))
                    {
                        ShieldCellFour = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.ShieldCell.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.ShieldCell.NotInstalled(true);
                    }
                    break;
                #endregion

                case Item.PulseWaveAnalyser:
                    #region Code
                    if (ICheck.Mothership.M.PulseWaveAnalyser(MethodName, true))
                    {
                        PulseWaveAnalyser = new Assignemnt(FireGroup, FireMode, Item);
                        IResponse.PulseWaveAnalyser.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IResponse.PulseWaveAnalyser.NotInstalled(true);
                    }
                    break;
                #endregion

                default:
                    Logger.DevUpdateLog(MethodName, Item.ToString() + " Logic Does Not Exist, Unable To Record Assignement.", Logger.Red);
                    return;
            }
            Logger.Log(MethodName, Item.ToString() + " Assigned To Firegroup \"" + FireGroup.ToString() + "\" " + FireMode.ToString() + " Fire", Logger.Yellow);

            //Save Settings
            ISettings.Firegroups.Save();
        }

        /// <summary>
        /// Will conduct validation checks on the target Equipment and select it if valid.
        /// </summary>
        /// <param name="I">The target Equipment.</param>
        /// <returns>Selected, NotAssigned, Failed, CurrentlySelected, InHyperspace</returns>
        public S Select(Item I)
        {
            string MethodName = "Assisted Firegroup (Select)";

            Assignemnt Temp = GetAssignemnt(I);
            bool Mode = CheckMode(I);
            if (Temp.FireGroup != Group.None && Temp.FireMode != Fire.None)
            {
                //Convert To Decimal
                decimal Num = ConvertGroupFromEnum(Temp.FireGroup);

                //Check Environment Condition
                if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
                {
                    return S.InHyperspace;
                }

                //Check HUD Mode
                if (ICheck.Status.AnalysisMode(MethodName, Mode) == false)
                {
                    IActions.Hardpoints.Mode(Mode, false);
                }

                //Check Current Selection
                if (ICheck.Status.FireGroup(MethodName, Num, true) == true)
                {
                    return S.CurrentlySelected;
                }

                //Select The Correct Group. Two Attempts.
                decimal Count = 2; bool Selected = false; while (Count != 0 && Selected == false)
                {
                    IActions.Hardpoints.Select(Num, false, true, Mode); Thread.Sleep(1500); Count--;
                    Selected = ICheck.Status.FireGroup(MethodName, Num, true);
                }

                //Report Selection
                if (ICheck.Status.FireGroup(MethodName, Num, true)) { return S.Selected; }
                Logger.Log(MethodName, "Failed To Select The Correct Fire Group. Try Again", Logger.Red);
                return S.Failed;
            }
            else
            {
                //Report Not Assigned
                Logger.Log(MethodName, I.ToString() + " Assignment Information: Firegroup \"" + Temp.FireGroup.ToString() + "\" " + Temp.FireMode.ToString() + " Fire", Logger.Yellow, true);
                Logger.Log(MethodName, "Module Group Not Assigned", Logger.Red);
                return S.NotAssigned;
            }
        }

        /// <summary>
        /// Activates The Target Module. Will Allow Completeion Tracking, and Duration For Activation. Will Check The Tracked Variable Once Every 50ms.
        /// </summary>
        /// <param name="I">The Target Module.</param>
        /// <param name="Track">The Variable To Track For Response Or Completion. Set To "False" If Not Tracking.</param>
        /// <param name="Duration">Duration In Miliseconds. Use 75 Click Activation.</param>
        /// <param name="Time">Time To Monitor The Tracked Variable</param>
        /// <returns></returns>
        public A Activate(Item I, int Duration, ref bool Track, decimal Time = -1)
        {
            string MethodName = "Assisted Firegroup (Acivate)";

            Assignemnt Temp = GetAssignemnt(I);
            bool Mode = CheckMode(I);

            //Firegroup Mode Selection
            IActions.Hardpoints.Mode(Mode, false); Thread.Sleep(50);

            if (Temp.FireGroup != Group.None && Temp.FireMode != Fire.None)
            {
                //Activate
                if (Temp.FireMode == Fire.Primary)
                { IKeyboard.Press(IKey.Primary_Fire_Press); }
                else if (Temp.FireMode == Fire.Secondary)
                { IKeyboard.Press(IKey.Secondary_Fire_Press); }

                //Key Duration
                #region Duration Logic
                if (Duration <= 75) { Thread.Sleep(Duration); }
                else
                {
                    bool Hold = true; decimal Count = Duration / 50; while (IStatus.Hyperspace == false && Hold == true)
                    { Thread.Sleep(50); if (Count <= 0) { Hold = false; } Count--; }

                    if (Count > 0)
                    {
                        Logger.Log(MethodName, "Entered Hyperspace", Logger.Red);
                        return A.Hyperspace;
                    }
                }
                #endregion

                //Release
                if (Temp.FireMode == Fire.Primary)
                { IKeyboard.Press(IKey.Primary_Fire_Release); }
                else if (Temp.FireMode == Fire.Secondary)
                { IKeyboard.Press(IKey.Secondary_Fire_Release); }

                //Track Completeion
                #region Completion Check
                if (Track != false && Time != -1)
                {
                    decimal Count = Time / 50; while (Track)
                    {
                        Count--; if (Count <= 0)
                        {
                            Track = false; return A.Fail;
                        }
                        Thread.Sleep(50);
                    }
                }
                #endregion

                return A.Complete;
            }
            else
            {
                Logger.Log(MethodName, I.ToString() + " Assignment Information: Firegroup \"" + Temp.FireGroup.ToString() + "\" " + Temp.FireMode.ToString() + " Fire", Logger.Yellow, true);
                Logger.Log(MethodName, "Module Fire Mode Not Assigned", Logger.Red);
                return A.NotAssigned;
            }
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
            //Total FireGroups Less Than Assigned Disble
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