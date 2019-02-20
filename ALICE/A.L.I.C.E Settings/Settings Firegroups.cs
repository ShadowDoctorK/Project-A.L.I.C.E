using ALICE_Core;
using ALICE_Equipment;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;
using ALICE_Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ALICE_Actions;

namespace ALICE_Settings
{
    /// <summary>
    /// The setting for the Firegroup Management System.
    /// These settings are controlled completely by the user and have no source from the game.
    /// </summary>
    public class Settings_Firegroups : Utilities
    {
        #region Properties
        public bool Default = true;  //Default Target For Ref Boolean.
        public enum Group { None, A, B, C, D, E, F, G, H };
        public enum Fire { None, Primary, Secondary }       
        public enum Item
        {
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
            ShieldCellFour
        }
        public enum S { Selected, NotAssigned, Failed, CurrentlySelected, InHyperspace }
        public enum A { Hyperspace, NotAssigned, Complete, Fail }

        public string ShipAssignment { get; set; }
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
        #endregion

        public Settings_Firegroups()
        {
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
        }

        /// <summary>
        /// Conducts validation checks on the target Equipment and assigns it if valid.
        /// </summary>
        /// <param name="Item">The target Equipment</param>
        /// <param name="FireGroup">The target Firegroup</param>
        /// <param name="FireMode">The target Fire Mode</param>
        public void Assign(Item Item, Group FireGroup, Fire FireMode)
        {
            string MethodName = "Firegroup System Set Assignment";

            switch (Item)
            {
                case Item.ECM:
                    #region Code
                    if (Check.Equipment.ECM(true, MethodName))
                    {
                        ECM = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.ElectronicCountermeasure.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.ElectronicCountermeasure.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LimpetCollector:
                    #region Code
                    if (Check.Equipment.CollectorLimpetController(true, MethodName))
                    {
                        LimpetCollector = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.LimpetCollector.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.LimpetCollector.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LimpetDecontamination:
                    #region Code
                    if (Check.Equipment.DecontaminationLimpetController(true, MethodName))
                    {
                        LimpetDecontamination = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.LimpetDecontamination.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.LimpetDecontamination.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LimpetFuel:
                    #region Code
                    if (Check.Equipment.FuelLimpetController(true, MethodName))
                    {
                        LimpetFuel = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.LimpetFuel.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.LimpetFuel.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LimpetHatchBreaker:
                    #region Code
                    if (Check.Equipment.HatchBreakerLimpetController(true, MethodName))
                    {
                        LimpetHatchBreaker = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.LimpetHatchBreaker.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.LimpetHatchBreaker.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LimpetRecon:
                    #region Code
                    if (Check.Equipment.ReconLimpetController(true, MethodName))
                    {
                        LimpetRecon = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.LimpetRecon.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.LimpetRecon.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LimpetRepair:
                    #region Code
                    if (Check.Equipment.RepairLimpetController(true, MethodName))
                    {
                        LimpetRepair = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.LimpetRepair.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.LimpetRepair.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LimpetResearch:
                    #region Code
                    if (Check.Equipment.ResearchLimpetController(true, MethodName))
                    {
                        LimpetResearch = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.LimpetResearch.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.LimpetResearch.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LimpetProspector:
                    #region Code
                    if (Check.Equipment.ProspectorLimpetController(true, MethodName))
                    {
                        LimpetProspector = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.LimpetProspector.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.LimpetProspector.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LauncherHeatSinkOne:
                    #region Code
                    if (Check.Equipment.HeatSinkLauncher(true, MethodName))
                    {
                        LauncherHeatSinkOne = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LauncherHeatSinkTwo:
                    #region Code
                    if (Check.Equipment.HeatSinkLauncher(true, MethodName))
                    {
                        LauncherHeatSinkTwo = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LauncherHeatSinkThree:
                    #region Code
                    if (Check.Equipment.HeatSinkLauncher(true, MethodName))
                    {
                        LauncherHeatSinkThree = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LauncherHeatSinkFour:
                    #region Code
                    if (Check.Equipment.HeatSinkLauncher(true, MethodName))
                    {
                        LauncherHeatSinkFour = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LauncherChaffOne:
                    #region Code
                    if (Check.Equipment.ChaffLauncher(true, MethodName))
                    {
                        LauncherChaffOne = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LauncherChaffTwo:
                    #region Code
                    if (Check.Equipment.ChaffLauncher(true, MethodName))
                    {
                        LauncherChaffTwo = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LauncherChaffThree:
                    #region Code
                    if (Check.Equipment.ChaffLauncher(true, MethodName))
                    {
                        LauncherChaffThree = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LauncherChaffFour:
                    #region Code
                    if (Check.Equipment.ChaffLauncher(true, MethodName))
                    {
                        LauncherChaffFour = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.LaserMinning:
                    #region Code
                    if (Check.Equipment.MiningLaser(true, MethodName))
                    {
                        LaserMinning = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.ScannerCagro:
                    #region Code
                    if (Check.Equipment.CagroScanner(true, MethodName))
                    {
                        ScannerCagro = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.ScannerComposite:
                    #region Code
                    //No Check Required. Default Ship Equipment.
                    ScannerComposite = new Assignemnt(FireGroup, FireMode, Item);
                    IEquipment.CompositeScanner.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    break;
                    #endregion

                case Item.ScannerDiscovery:
                    #region Code
                    //No Check Required. Default Ship Equipment.
                    ScannerDiscovery = new Assignemnt(FireGroup, FireMode, Item);
                    IEquipment.DiscoveryScanner.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    break;
                    #endregion

                case Item.ScannerKillwarrent:
                    #region Code
                    if (Check.Equipment.KillWarrantScanner(true, MethodName))
                    {
                        ScannerKillwarrent = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.ScannerSurface:
                    #region Code
                    if (Check.Equipment.SurfaceScanner(true, MethodName))
                    {
                        ScannerSurface = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.SurfaceScanner.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.SurfaceScanner.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.ScannerXeno:
                    #region Code
                    if (Check.Equipment.XenoScanner(true, MethodName))
                    {
                        ScannerXeno = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.General.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.General.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.ScannerWake:
                    #region Code
                    if (Check.Equipment.WakeScanner(true, MethodName))
                    {
                        ScannerWake = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.WakeScanner.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.WakeScanner.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.ShieldCellOne:
                    #region Code
                    if (Check.Equipment.ShieldCellBank(true, MethodName))
                    {
                        ShieldCellOne = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.ShieldCellBank.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.ShieldCellBank.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.ShieldCellTwo:
                    #region Code
                    if (Check.Equipment.ShieldCellBank(true, MethodName))
                    {
                        ShieldCellTwo = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.ShieldCellBank.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.ShieldCellBank.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.ShieldCellThree:
                    #region Code
                    if (Check.Equipment.ShieldCellBank(true, MethodName))
                    {
                        ShieldCellThree = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.ShieldCellBank.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.ShieldCellBank.NotInstalled(true);
                    }
                    break;
                    #endregion

                case Item.ShieldCellFour:
                    #region Code
                    if (Check.Equipment.ShieldCellBank(true, MethodName))
                    {
                        ShieldCellFour = new Assignemnt(FireGroup, FireMode, Item);
                        IEquipment.ShieldCellBank.Assigned(ToText(FireGroup), ToText(FireMode), true);
                    }
                    else
                    {
                        IEquipment.ShieldCellBank.NotInstalled(true);
                    }
                    break;
                    #endregion

                default:
                    Logger.DevUpdateLog(MethodName, Item.ToString() + " Logic Does Not Exist, Unable To Record Assignement.", Logger.Red);
                    return;
            }
            Logger.Log(MethodName, Item.ToString() + " Assigned To Firegroup \"" + FireGroup.ToString() + "\" " + FireMode.ToString() + " Fire", Logger.Yellow);

            ISettings.Firegroup.Save(MethodName);
            //SaveValues<Settings_Firegroups>(this, IObjects.Mothership.FingerPrint + ".FGConfig", Paths.ALICE_Settings);
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
                if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false) { return S.InHyperspace; }

                //Check HUD Mode
                if (Check.Variable.AnalysisMode(Mode, MethodName) == false) { Call.Action.AnalysisMode(false, false); }

                //Check Current Selection
                if (Check.Environment.Firegroup(Num, true, MethodName) == true) { return S.CurrentlySelected; }

                //Select The Correct Group. Two Attempts.
                decimal Count = 2; bool Selected = false; while (Count != 0 && Selected == false)
                {
                    Call.Firegroup.Select(Num, false, true, Mode); Thread.Sleep(1500); Count--;
                    Selected = Check.Environment.Firegroup(Num, true, MethodName);
                }

                //Report Selection
                if (Check.Environment.Firegroup(Num, true, MethodName)) { return S.Selected; }
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
        /// <param name="Track">The Variable To Track. Set To "True" If Not Tracking.</param>
        /// <param name="Duration">Duration In Miliseconds</param>
        /// <param name="Tracking">True Enables Tracking</param>
        /// <param name="Expected">The Expected Value For The Tracked Variable.</param>
        /// <param name="TrackDuration">The Duration In Miliseconds To Track The Variable.</param>
        /// <param name="SetStartValue">If Set To True It Will Set The Starting Value For The Tracked Variable.</param>
        /// <param name="StartValue">The Value To Set The Tracked Variable To During Start.</param>
        /// <returns></returns>
        public A Activate(Item I, int Duration = 75, bool Tracking = false, Equipment_General.WaitHandler Watcher = null)
        {
            string MethodName = "Assisted Firegroup Acivate";

            Assignemnt Temp = GetAssignemnt(I);
            bool Mode = CheckMode(I);

            Call.Action.AnalysisMode(Mode, false); Thread.Sleep(50);
            if (Temp.FireGroup != Group.None && Temp.FireMode != Fire.None)
            {
                //Activate
                if (Temp.FireMode == Fire.Primary)
                { Call.Key.Press(Call.Key.Primary_Fire_Press); }
                else if (Temp.FireMode == Fire.Secondary)
                { Call.Key.Press(Call.Key.Secondary_Fire_Press); }

                //Key Duration
                #region Duration Logic
                if (Duration <= 75) { Thread.Sleep(Duration); } else
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
                { Call.Key.Press(Call.Key.Primary_Fire_Release); }
                else if (Temp.FireMode == Fire.Secondary)
                { Call.Key.Press(Call.Key.Secondary_Fire_Release); }

                //Track Completeion
                #region Completion Check
                if (Tracking)
                {
                    try { if (Watcher.Invoke() == false) { return A.Fail; } }
                    catch (Exception ex) { Logger.Exception(MethodName, "Watcher Exception: " + ex); }  
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
                    Logger.Log(MethodName, "FireGroup Was Not a Valid Setting (" + Letter + ")", Logger.Yellow);
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
                    Logger.Log(MethodName, "FireMode Was Not a Valid Setting (" + Value + ")", Logger.Yellow);
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
                    return "Secondary";;
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
                case Item.ECM:
                    return false;
                case Item.FieldNeutraliser:
                    return true;
                case Item.FSDInterdictor:
                    return false;
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
                    return false;
                case Item.ShieldCellTwo:
                    return false;
                case Item.ShieldCellThree:
                    return false;
                case Item.ShieldCellFour:
                    return false;
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
            string MethodName = "Assisted Firegroup Get Assignement";

            switch (I)
            {
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
            //public bool AnalysisMode { get; set; }

            public Assignemnt()
            {
                FireGroup = Group.None;
                FireMode = Fire.None;
                Enabled = false;
                //AnalysisMode = false;
            }

            public Assignemnt(Group G, Fire F, Item I)
            {
                FireGroup = G;
                FireMode = F;
                Enabled = true;
                //AnalysisMode = CheckMode(I);
            }
        }
    }
}