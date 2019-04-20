using ALICE_Actions;
using ALICE_Core;
using ALICE_Debug;
using ALICE_Equipment;
using ALICE_Internal;
using ALICE_Settings;
using System.Collections.Generic;

namespace ALICE_Interface
{
    public static partial class ICommands
    {
        public static CMD_Actions CMDActions = new CMD_Actions();
    }

    public class CMD_Actions : Commands
    {
        public void Search(List<string> Command)
        {
            switch (Command[1].Lookup<L1>())
            {
                case L1.Override:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Crew:
                            Call.Overrides.Crew(PlugIn.CommandAudio);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Docking:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Request:
                            IActions.Docking.Request(IEnums.CMD.True, PlugIn.CommandAudio, true);
                            return;

                        case L2.Cancel:
                            IActions.Docking.Request(IEnums.CMD.False, PlugIn.CommandAudio);
                            return;

                        case L2.Prepair:
                            IActions.Docking.Preparations(PlugIn.CommandAudio);
                            return;
                       
                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Fighter:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Deploy:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Player:
                                    IActions.Fighter.Deploy(IGet.External.FighterNumber(ICommands.M, true), true, PlugIn.CommandAudio);
                                    return;

                                case L3.Crew:
                                    IActions.Fighter.Deploy(IGet.External.FighterNumber(ICommands.M, true), false, PlugIn.CommandAudio);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Attack_My_Target:
                            IActions.Fighter.AttackMyTarget(PlugIn.CommandAudio);
                            return;

                        case L2.Defend:
                            IActions.Fighter.Defending(PlugIn.CommandAudio);
                            return;

                        case L2.Engage_At_Will:
                            IActions.Fighter.EngageAtWill(PlugIn.CommandAudio);
                            return;

                        case L2.Follow:
                            IActions.Fighter.Follow(PlugIn.CommandAudio);
                            return;

                        case L2.Hold:
                            IActions.Fighter.HoldPosition(PlugIn.CommandAudio);
                            return;

                        case L2.Maintain:
                            IActions.Fighter.Recall(PlugIn.CommandAudio);
                            return;

                        case L2.Recall:
                            IActions.Fighter.Recall(PlugIn.CommandAudio);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Frame_Shift_Drive:

                    //Track Marking Commands
                    bool OnMyMark = false;

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Cancel:
                            IActions.FrameShiftDrive.AbortJump(PlugIn.CommandAudio);
                            return;

                        case L2.Supercruise:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Mark:
                                    OnMyMark = true;
                                    break;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    break;
                            }

                            IActions.FrameShiftDrive.Supercruise(PlugIn.CommandAudio, true, OnMyMark);

                            return;

                        case L2.Hyperspace:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Mark:
                                    OnMyMark = true;
                                    break;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    break;
                            }

                            IActions.FrameShiftDrive.Hyperspace(PlugIn.CommandAudio, true, OnMyMark);

                            return;

                        case L2.Disengage:                           

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Mark:
                                    OnMyMark = true;
                                    break;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    break;
                            }

                            IActions.FrameShiftDrive.Supercruise(PlugIn.CommandAudio, false, OnMyMark);

                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Hardpoints:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Deploy:
                            IActions.Hardpoints.Operate(true, PlugIn.CommandAudio, false);
                            return;
                       
                        case L2.Retract:
                            IActions.Hardpoints.Operate(false, PlugIn.CommandAudio, false, Hardpoints.M.Analysis);
                            return;

                        case L2.Weapons:
                            IActions.Hardpoints.Operate(true, PlugIn.CommandAudio, true, Hardpoints.M.Combat);
                            return;

                        case L2.Select:
                            Call.Firegroup.Select(IGet.External.FireGroupSelect(ICommands.M, true), PlugIn.CommandAudio);
                            return;

                        case L2.Default:
                            Call.Firegroup.Update_Default(IGet.External.FireGroupNum(ICommands.M, true));
                            return;

                        case L2.Update:
                            Call.Firegroup.Update_Total(PlugIn.CommandAudio);
                            return;

                        case L2.Mode:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Combat:
                                    IActions.Hardpoints.Mode(false, PlugIn.CommandAudio);
                                    return;

                                case L3.Analysis:
                                    IActions.Hardpoints.Mode(true, PlugIn.CommandAudio);
                                    return;

                                case L3.Toggle:
                                    IActions.Hardpoints.Mode(!IGet.Status.AnalysisMode(ICommands.M),PlugIn.CommandAudio);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Heatsink:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    //CONSTRUCTION
                                    return;

                                case L3.Two:
                                    //CONSTRUCTION
                                    return;

                                case L3.Three:
                                    //CONSTRUCTION
                                    return;

                                case L3.Four:
                                    //CONSTRUCTION
                                    return;

                                default:
                                    IActions.Heatsink.Activate(PlugIn.CommandAudio);
                                    return;
                            }

                        case L2.Select:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LauncherHeatSinkOne);
                                    return;

                                case L3.Two:
                                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LauncherHeatSinkTwo);
                                    return;

                                case L3.Three:
                                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LauncherHeatSinkThree);
                                    return;

                                case L3.Four:
                                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LauncherHeatSinkFour);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Assign:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    ISettings.Firegroup.Assign(
                                        Settings_Firegroups.Item.LauncherHeatSinkOne,
                                        ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Two:
                                    ISettings.Firegroup.Assign(
                                        Settings_Firegroups.Item.LauncherHeatSinkTwo,
                                        ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Three:
                                    ISettings.Firegroup.Assign(
                                        Settings_Firegroups.Item.LauncherHeatSinkThree,
                                        ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Four:
                                    ISettings.Firegroup.Assign(
                                        Settings_Firegroups.Item.LauncherHeatSinkFour,
                                        ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Shield_Cell:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    IActions.ShieldCell.Target(
                                        PlugIn.CommandAudio, 
                                        Settings_Firegroups.Item.ShieldCellOne,
                                        IGet.External.ColdMod(ICommands.M, true));
                                    return;

                                case L3.Two:
                                    IActions.ShieldCell.Target(
                                        PlugIn.CommandAudio,
                                        Settings_Firegroups.Item.ShieldCellTwo,
                                        IGet.External.ColdMod(ICommands.M, true));
                                    return;

                                case L3.Three:
                                    IActions.ShieldCell.Target(
                                        PlugIn.CommandAudio,
                                        Settings_Firegroups.Item.ShieldCellThree,
                                        IGet.External.ColdMod(ICommands.M, true));
                                    return;

                                case L3.Four:
                                    IActions.ShieldCell.Target(
                                        PlugIn.CommandAudio,
                                        Settings_Firegroups.Item.ShieldCellFour,
                                        IGet.External.ColdMod(ICommands.M, true));
                                    return;

                                default:
                                    IActions.ShieldCell.Activate(PlugIn.CommandAudio, IGet.External.ColdMod(ICommands.M, true));
                                    return;
                            }
                           
                        case L2.Select:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    IActions.ShieldCell.Target(
                                        PlugIn.CommandAudio,
                                        Settings_Firegroups.Item.ShieldCellOne,
                                        false, true);
                                    return;

                                case L3.Two:
                                    IActions.ShieldCell.Target(
                                        PlugIn.CommandAudio,
                                        Settings_Firegroups.Item.ShieldCellTwo,
                                        false, true);
                                    return;

                                case L3.Three:
                                    IActions.ShieldCell.Target(
                                        PlugIn.CommandAudio,
                                        Settings_Firegroups.Item.ShieldCellThree,
                                        false, true);
                                    return;

                                case L3.Four:
                                    IActions.ShieldCell.Target(
                                        PlugIn.CommandAudio,
                                        Settings_Firegroups.Item.ShieldCellFour,
                                        false, true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);

                                    return;
                            }

                        case L2.Assign:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    ISettings.Firegroup.Assign(
                                        Settings_Firegroups.Item.ShieldCellOne,
                                        ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Two:
                                    ISettings.Firegroup.Assign(
                                        Settings_Firegroups.Item.ShieldCellTwo,
                                        ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Three:
                                    ISettings.Firegroup.Assign(
                                        Settings_Firegroups.Item.ShieldCellThree,
                                        ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Four:
                                    ISettings.Firegroup.Assign(
                                        Settings_Firegroups.Item.ShieldCellFour,
                                        ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Landing_Gear:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Deploy:
                            Call.Action.LandingGear(true, PlugIn.CommandAudio);
                            return;

                        case L2.Retract:
                            Call.Action.LandingGear(false, PlugIn.CommandAudio);
                            return;

                        case L2.Toggle:
                            Call.Action.LandingGear(!IGet.LandingGear.Status(ICommands.M), PlugIn.CommandAudio);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Cargo_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            ICommands.LogNotImplemented(ICommands.M, Command, 2);
                            return;

                        case L2.Select:
                            ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerCagro);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.ScannerCagro,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Wake_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            ICommands.LogNotImplemented(ICommands.M, Command, 2);
                            return;

                        case L2.Select:
                            ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerWake);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.ScannerWake,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.ECM:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            ICommands.LogNotImplemented(ICommands.M, Command, 2);
                            return;

                        case L2.Select:
                            ISettings.Firegroup.Select(Settings_Firegroups.Item.ECM);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.ECM,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Field_Neutraliser:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            ICommands.LogNotImplemented(ICommands.M, Command, 2);
                            return;

                        case L2.Select:
                            ISettings.Firegroup.Select(Settings_Firegroups.Item.FieldNeutraliser);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.FieldNeutraliser,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.FSD_Interdictor:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            ICommands.LogNotImplemented(ICommands.M, Command, 2);
                            return;

                        case L2.Select:
                            ISettings.Firegroup.Select(Settings_Firegroups.Item.FSDInterdictor);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.FSDInterdictor,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Mining_Laser:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            ICommands.LogNotImplemented(ICommands.M, Command, 2);
                            return;

                        case L2.Select:
                            ISettings.Firegroup.Select(Settings_Firegroups.Item.LaserMinning);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.LaserMinning,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Kill_Warrent_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            ICommands.LogNotImplemented(ICommands.M, Command, 2);
                            return;

                        case L2.Select:
                            ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerKillwarrent);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.ScannerKillwarrent,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }                    

                case L1.Xeno_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.XenoScanner(PlugIn.CommandAudio, false);
                            return;

                        case L2.Select:
                            Call.Action.XenoScanner(PlugIn.CommandAudio, true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.ScannerXeno,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Composite_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            IActions.CompositeScaner(PlugIn.CommandAudio, false);
                            return;

                        case L2.Select:
                            IActions.CompositeScaner(PlugIn.CommandAudio, true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.ScannerComposite,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }                    

                case L1.Night_Vision:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.NightVision(true, PlugIn.CommandAudio);
                            return;

                        case L2.Disable:
                            Call.Action.NightVision(false, PlugIn.CommandAudio);
                            return;

                        case L2.Toggle:
                            Call.Action.NightVision(!IStatus.NightVision, PlugIn.CommandAudio);
                            return;

                        default:
                            return;
                    }

                case L1.Flight_Assist:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.FlightAssist(true, PlugIn.CommandAudio);
                            return;

                        case L2.Disable:
                            Call.Action.FlightAssist(false, PlugIn.CommandAudio);
                            return;

                        case L2.Toggle:
                            Call.Action.FlightAssist(!IStatus.FlightAssist, PlugIn.CommandAudio);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Cargo_Scoop:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Deploy:
                            Call.Action.CargoScoop(true, PlugIn.CommandAudio);
                            return;

                        case L2.Retract:
                            Call.Action.CargoScoop(false, PlugIn.CommandAudio);
                            return;

                        case L2.Toggle:
                            Call.Action.CargoScoop(!IStatus.CargoScoop, PlugIn.CommandAudio);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Lights:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.ExternalLights(true, PlugIn.CommandAudio);
                            return;

                        case L2.Disable:
                            Call.Action.ExternalLights(false, PlugIn.CommandAudio);
                            return;

                        case L2.Toggle:
                            Call.Action.ExternalLights(!IEquipment.ExternalLights.Settings.Enabled, PlugIn.CommandAudio);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Slient_Running:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.SilentRunning(true, PlugIn.CommandAudio);
                            return;

                        case L2.Disable:
                            Call.Action.SilentRunning(false, PlugIn.CommandAudio);
                            return;

                        case L2.Toggle:
                            Call.Action.SilentRunning(!IStatus.SilentRunning, PlugIn.CommandAudio);
                            return;
                       
                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Chaff:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    return;

                                case L3.Two:
                                    return;

                                case L3.Three:
                                    return;

                                case L3.Four:
                                    return;

                                default:
                                    Call.Action.Activate_Chaff(PlugIn.CommandAudio);
                                    return;
                            }

                        case L2.Select:
                            return;

                        case L2.Assign:
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Full_Spectrum_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.Full_Spectrum_Scanner(true, PlugIn.CommandAudio);
                            return;

                        case L2.Disable:
                            Call.Action.Full_Spectrum_Scanner(false, PlugIn.CommandAudio);
                            return;

                        case L2.Toggle:
                            Call.Action.Full_Spectrum_Scanner(!IStatus.Lights, PlugIn.CommandAudio);
                            return;
                      
                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Surface_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.SurfaceScaner(true, PlugIn.CommandAudio);
                            return;

                        case L2.Disable:
                            Call.Action.SurfaceScaner(false, PlugIn.CommandAudio);
                            return;

                        case L2.Toggle:
                            Call.Action.SurfaceScaner(!IEquipment.SurfaceScanner.Mode, PlugIn.CommandAudio);
                            return;

                        case L2.Select:
                            Call.Action.SurfaceScaner(true, PlugIn.CommandAudio, true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.ScannerSurface,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Discovery_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            IActions.DiscoveryScanner(PlugIn.CommandAudio);
                            return;

                        case L2.Select:
                            IActions.DiscoveryScanner(true, false, true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.ScannerDiscovery,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Collector_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.CollectorLimpet(PlugIn.CommandAudio, false);
                            return;

                        case L2.Select:
                            Call.Action.CollectorLimpet(PlugIn.CommandAudio, true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.LimpetCollector,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Decontamination_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            ICommands.LogNotImplemented(ICommands.M, Command, 2);
                            return;

                        case L2.Select:
                            ISettings.Firegroup.Select(Settings_Firegroups.Item.LimpetDecontamination);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.LimpetDecontamination,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Fuel_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.FuelLimpet(PlugIn.CommandAudio, false);
                            return;

                        case L2.Select:
                            Call.Action.FuelLimpet(PlugIn.CommandAudio, true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.LimpetFuel,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Hatch_Breaker_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            ICommands.LogNotImplemented(ICommands.M, Command, 2);
                            return;

                        case L2.Select:
                            ISettings.Firegroup.Select(Settings_Firegroups.Item.LimpetHatchBreaker);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.LimpetHatchBreaker,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Prospector_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.ProspectorLimpet(PlugIn.CommandAudio, false);
                            return;

                        case L2.Select:
                            Call.Action.ProspectorLimpet(PlugIn.CommandAudio, true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.LimpetProspector,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Recon_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.ReconLimpet(PlugIn.CommandAudio, false);
                            return;

                        case L2.Select:
                            Call.Action.ReconLimpet(PlugIn.CommandAudio, true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.LimpetRecon,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Repair_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.RepairLimpet(PlugIn.CommandAudio, false);
                            return;

                        case L2.Select:
                            Call.Action.RepairLimpet(PlugIn.CommandAudio, true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.LimpetRepair,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Research_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            ICommands.LogNotImplemented(ICommands.M, Command, 2);
                            return;

                        case L2.Select:
                            ISettings.Firegroup.Select(Settings_Firegroups.Item.LimpetResearch);
                            return;

                        case L2.Assign:
                            ISettings.Firegroup.Assign(
                                Settings_Firegroups.Item.LimpetResearch,
                                ISettings.Firegroup.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroup.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Launch:
                    Call.Action.Launch(PlugIn.CommandAudio);
                    return;

                case L1.Landing:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Prepair:
                            Call.Action.LandingPreparations(PlugIn.CommandAudio);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Throttle:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Boost:

                            switch (Command[3].Lookup<L3>())
                            {
                                 case L3.Series:
                                    IActions.Throttle.Boost(IGet.External.BoostNum(ICommands.M, true), true, PlugIn.CommandAudio);
                                    return;

                                case L3.Stop:
                                    IActions.Throttle.Num_Boost = 0;
                                    return;

                                default:
                                    IActions.Throttle.Boost(1, true, PlugIn.CommandAudio);
                                    return;
                            }

                        case L2.S0:
                            IActions.Throttle.S0();
                            return;

                        case L2.S5:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S5();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S5(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S10:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S10();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S10(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S15:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S15();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S15(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S20:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S20();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S20(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S25:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S25();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S25(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S30:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S30();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S30(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S35:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S35();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S35(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S40:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S40();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S40(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S45:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S45();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S45(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S50:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S50();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S50(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S55:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S55();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S55(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S60:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S60();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S60(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S65:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S65();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S65(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S70:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S70();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S70(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S75:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S75();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S75(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S80:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S80();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S80(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S85:
                            
                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S85();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S85(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S90:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S90();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S90(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S95:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S95();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S95(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.S100:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Positive:
                                    IActions.Throttle.S100();
                                    return;

                                case L3.Negative:
                                    IActions.Throttle.S100(true);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                default:
                    ICommands.LogInvalid(ICommands.M, Command, 1);
                    return;
            }
        }
    }
}