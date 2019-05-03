using ALICE_Actions;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Settings;
using ALICE_Status;
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
                            Call.Overrides.Crew(
                                IGet.External.CommandAudio(ICommands.M));                       //Get Command Audio From Platform 
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Docking:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Request:
                            IActions.Docking.Request(
                                IEnums.CMD.True,                                                //Request Docking
                                IGet.External.CommandAudio(ICommands.M),                        //Get Command Audio From Platform 
                                true);                                                          //Player Initiated Command
                            return;

                        case L2.Cancel:
                            IActions.Docking.Request(
                                IEnums.CMD.False,                                               //Cancel Docking
                                IGet.External.CommandAudio(ICommands.M));                       //Get Command Audio From Platform 
                            return;

                        case L2.Prepare:
                            IActions.Docking.Preparations(
                                IGet.External.CommandAudio(ICommands.M));                       //Get Command Audio From Platform 
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
                                    IActions.Fighter.Deploy(
                                        IGet.External.FighterNumber(ICommands.M, true),         //Get Fighter Number From Platform
                                        true,                                                   //Deploy Player
                                        IGet.External.CommandAudio(ICommands.M));               //Get Command Audio From Platform
                                    return;

                                case L3.Crew:
                                    IActions.Fighter.Deploy(
                                        IGet.External.FighterNumber(ICommands.M, true),         //Get Fighter Number From Platform
                                        false,                                                  //Deploy Crew Member
                                        IGet.External.CommandAudio(ICommands.M));               //Get Command Audio From Platform
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Attack_My_Target:
                            IActions.Fighter.AttackMyTarget(
                                IGet.External.CommandAudio(ICommands.M));                       //Get Command Audio From Platform         
                            return;

                        case L2.Defend:
                            IActions.Fighter.Defending(
                                IGet.External.CommandAudio(ICommands.M));                       //Get Command Audio From Platform 
                            return;

                        case L2.Engage_At_Will:
                            IActions.Fighter.EngageAtWill(
                                IGet.External.CommandAudio(ICommands.M));                       //Get Command Audio From Platform 
                            return;

                        case L2.Follow:
                            IActions.Fighter.Follow(
                                IGet.External.CommandAudio(ICommands.M));                       //Get Command Audio From Platform 
                            return;

                        case L2.Hold:
                            IActions.Fighter.HoldPosition(
                                IGet.External.CommandAudio(ICommands.M));                       //Get Command Audio From Platform 
                            return;

                        case L2.Maintain:
                            IActions.Fighter.MaintainFormation(
                                IGet.External.CommandAudio(ICommands.M));                       //Get Command Audio From Platform 
                            return;

                        case L2.Recall:
                            IActions.Fighter.Recall(
                                IGet.External.CommandAudio(ICommands.M));                       //Get Command Audio From Platform 
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
                            IActions.FrameShiftDrive.AbortJump(
                                IGet.External.CommandAudio(ICommands.M));                       //Get Command Audio From Platform 
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

                            IActions.FrameShiftDrive.Supercruise(IGet.External.CommandAudio(ICommands.M), true, OnMyMark);

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

                            IActions.FrameShiftDrive.Hyperspace(IGet.External.CommandAudio(ICommands.M), true, OnMyMark);

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

                            IActions.FrameShiftDrive.Supercruise(IGet.External.CommandAudio(ICommands.M), false, OnMyMark);

                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Hardpoints:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Deploy:
                            IActions.Hardpoints.Operate(
                                true,                                                   //Deploy
                                IGet.External.CommandAudio(ICommands.M));               //Get Command Audio From Platform                               
                            return;
                       
                        case L2.Retract:
                            IActions.Hardpoints.Operate(
                                false,                                                  //Retract
                                IGet.External.CommandAudio(ICommands.M),                //Get Command Audio From Platform                                
                                Hardpoints.M.Analysis);                                 //Switch Mode To Analysis
                            return;

                        case L2.Weapons:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    IActions.Hardpoints.Weapons(
                                        IGet.External.CommandAudio(ICommands.M), 1);   //Get Command Audio From Platform
                                    break;
                                        
                                case L3.Two:
                                    IActions.Hardpoints.Weapons(
                                        IGet.External.CommandAudio(ICommands.M), 2);   //Get Command Audio From Platform
                                    break;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    break;
                            }

                            return;

                        case L2.Select:
                            IActions.Hardpoints.Select(
                                IGet.External.FireGroupSelect(ICommands.M, true),       //Get Variable From Platform + Reset
                                IGet.External.CommandAudio(ICommands.M));               //Get Command Audio From Platform
                            return;

                        case L2.Default:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    IActions.Hardpoints.WeaponsGroup(1, 
                                        IGet.External.FireGroup(ICommands.M, true));
                                    return;

                                case L3.Two:
                                    IActions.Hardpoints.WeaponsGroup(2, 
                                        IGet.External.FireGroup(ICommands.M, true));
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Update:
                            IActions.Hardpoints.TotalGroups(
                                IGet.External.CommandAudio(ICommands.M));               //Get Command Audio From Platform
                            return;

                        case L2.Mode:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Combat:
                                    IActions.Hardpoints.Mode(
                                        false, 
                                        IGet.External.CommandAudio(ICommands.M));
                                    return;

                                case L3.Analysis:
                                    IActions.Hardpoints.Mode(
                                        true, 
                                        IGet.External.CommandAudio(ICommands.M));
                                    return;

                                case L3.Toggle:
                                    IActions.Hardpoints.Mode(
                                        !IGet.Status.AnalysisMode(ICommands.M),
                                        IGet.External.CommandAudio(ICommands.M));
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Groups:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Prospect:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Assign:
                                    ISettings.Firegroups.Config.Assign(
                                        ConfigurationHardpoints.Item.Prospecting,
                                        ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)), 
                                        ConfigurationHardpoints.Fire.Primary);
                                    return;

                                case L3.Select:
                                    ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.Prospecting);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Collection:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Assign:
                                    ISettings.Firegroups.Config.Assign(
                                        ConfigurationHardpoints.Item.Collecting,
                                        ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ConfigurationHardpoints.Fire.Primary);
                                    return;

                                case L3.Select:
                                    ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.Collecting);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Extraction:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Assign:
                                    ISettings.Firegroups.Config.Assign(
                                        ConfigurationHardpoints.Item.Extracting,
                                        ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ConfigurationHardpoints.Fire.Primary);
                                    return;

                                case L3.Select:
                                    ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.Extracting);
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
                                    IActions.Heatsink.Target(
                                        IGet.External.CommandAudio(ICommands.M),
                                        ConfigurationHardpoints.Item.ShieldCellOne);
                                    return;

                                case L3.Two:
                                    IActions.Heatsink.Target(
                                        IGet.External.CommandAudio(ICommands.M),
                                        ConfigurationHardpoints.Item.ShieldCellTwo);
                                    return;

                                case L3.Three:
                                    IActions.Heatsink.Target(
                                        IGet.External.CommandAudio(ICommands.M),
                                        ConfigurationHardpoints.Item.ShieldCellThree);
                                    return;

                                case L3.Four:
                                    IActions.Heatsink.Target(
                                        IGet.External.CommandAudio(ICommands.M),
                                        ConfigurationHardpoints.Item.ShieldCellFour);
                                    return;

                                default:
                                    IActions.Heatsink.Activate(
                                        IGet.External.CommandAudio(ICommands.M));
                                    return;
                            }

                        case L2.Select:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    ISettings.Firegroups.Config.Select(
                                        ConfigurationHardpoints.Item.LauncherHeatSinkOne);
                                    return;

                                case L3.Two:
                                    ISettings.Firegroups.Config.Select(
                                        ConfigurationHardpoints.Item.LauncherHeatSinkTwo);
                                    return;

                                case L3.Three:
                                    ISettings.Firegroups.Config.Select(
                                        ConfigurationHardpoints.Item.LauncherHeatSinkThree);
                                    return;

                                case L3.Four:
                                    ISettings.Firegroups.Config.Select(
                                        ConfigurationHardpoints.Item.LauncherHeatSinkFour);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Assign:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    ISettings.Firegroups.Config.Assign(
                                        ConfigurationHardpoints.Item.LauncherHeatSinkOne,
                                        ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Two:
                                    ISettings.Firegroups.Config.Assign(
                                        ConfigurationHardpoints.Item.LauncherHeatSinkTwo,
                                        ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Three:
                                    ISettings.Firegroups.Config.Assign(
                                        ConfigurationHardpoints.Item.LauncherHeatSinkThree,
                                        ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Four:
                                    ISettings.Firegroups.Config.Assign(
                                        ConfigurationHardpoints.Item.LauncherHeatSinkFour,
                                        ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
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
                                        IGet.External.CommandAudio(ICommands.M), 
                                        ConfigurationHardpoints.Item.ShieldCellOne,
                                        IGet.External.ColdMod(ICommands.M, true));
                                    return;

                                case L3.Two:
                                    IActions.ShieldCell.Target(
                                        IGet.External.CommandAudio(ICommands.M),
                                        ConfigurationHardpoints.Item.ShieldCellTwo,
                                        IGet.External.ColdMod(ICommands.M, true));
                                    return;

                                case L3.Three:
                                    IActions.ShieldCell.Target(
                                        IGet.External.CommandAudio(ICommands.M),
                                        ConfigurationHardpoints.Item.ShieldCellThree,
                                        IGet.External.ColdMod(ICommands.M, true));
                                    return;

                                case L3.Four:
                                    IActions.ShieldCell.Target(
                                        IGet.External.CommandAudio(ICommands.M),
                                        ConfigurationHardpoints.Item.ShieldCellFour,
                                        IGet.External.ColdMod(ICommands.M, true));
                                    return;

                                default:
                                    IActions.ShieldCell.Activate(
                                        IGet.External.CommandAudio(ICommands.M),
                                        IGet.External.ColdMod(ICommands.M, false));
                                    return;
                            }
                           
                        case L2.Select:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    IActions.ShieldCell.Target(
                                        IGet.External.CommandAudio(ICommands.M),
                                        ConfigurationHardpoints.Item.ShieldCellOne,
                                        false, true);
                                    return;

                                case L3.Two:
                                    IActions.ShieldCell.Target(
                                        IGet.External.CommandAudio(ICommands.M),
                                        ConfigurationHardpoints.Item.ShieldCellTwo,
                                        false, true);
                                    return;

                                case L3.Three:
                                    IActions.ShieldCell.Target(
                                        IGet.External.CommandAudio(ICommands.M),
                                        ConfigurationHardpoints.Item.ShieldCellThree,
                                        false, true);
                                    return;

                                case L3.Four:
                                    IActions.ShieldCell.Target(
                                        IGet.External.CommandAudio(ICommands.M),
                                        ConfigurationHardpoints.Item.ShieldCellFour,
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
                                    ISettings.Firegroups.Config.Assign(
                                        ConfigurationHardpoints.Item.ShieldCellOne,
                                        ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Two:
                                    ISettings.Firegroups.Config.Assign(
                                        ConfigurationHardpoints.Item.ShieldCellTwo,
                                        ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Three:
                                    ISettings.Firegroups.Config.Assign(
                                        ConfigurationHardpoints.Item.ShieldCellThree,
                                        ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                                    return;

                                case L3.Four:
                                    ISettings.Firegroups.Config.Assign(
                                        ConfigurationHardpoints.Item.ShieldCellFour,
                                        ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                        ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
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
                            Call.Action.LandingGear(true, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Retract:
                            Call.Action.LandingGear(false, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Toggle:
                            Call.Action.LandingGear(!IGet.Status.LandingGear(ICommands.M), 
                                IGet.External.CommandAudio(ICommands.M));
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
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.ScannerCagro);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.ScannerCagro,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
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
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.ScannerWake);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.ScannerWake,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
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
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.ECM);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.ECM,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
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
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.FieldNeutraliser);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.FieldNeutraliser,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
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
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.FSDInterdictor);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.FSDInterdictor,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Mining_Laser:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Select:
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.LaserMinning);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.LaserMinning,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Abrasion_Blaster:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Select:
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.AbrasionBlaster);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.AbrasionBlaster,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Sub_Surface_Displacement:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Select:
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.DisplacementMissile);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.DisplacementMissile,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Seismic_Charge_Launcher:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Select:
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.SeismicChargeLauncher);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.SeismicChargeLauncher,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
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
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.ScannerKillwarrent);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.ScannerKillwarrent,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }                    

                case L1.Xeno_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.XenoScanner(IGet.External.CommandAudio(ICommands.M), false);
                            return;

                        case L2.Select:
                            Call.Action.XenoScanner(IGet.External.CommandAudio(ICommands.M), true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.ScannerXeno,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Composite_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            IActions.CompositeScaner(IGet.External.CommandAudio(ICommands.M), false);
                            return;

                        case L2.Select:
                            IActions.CompositeScaner(IGet.External.CommandAudio(ICommands.M), true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.ScannerComposite,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Pulse_Wave_Analyser:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            IActions.PulseWaveAnalyser.Operate(IGet.External.CommandAudio(ICommands.M));
                            return;
                            
                        case L2.Select:
                            IActions.PulseWaveAnalyser.Operate(IGet.External.CommandAudio(ICommands.M), true);
                            return;

                        case L2.Pulse:
                            IActions.PulseWaveAnalyser.Scan();
                            return;

                        case L2.Deactivate:
                            IActions.PulseWaveAnalyser.Maintain = false;
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.PulseWaveAnalyser,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Night_Vision:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.NightVision(true, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Disable:
                            Call.Action.NightVision(false, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Toggle:
                            Call.Action.NightVision(!IGet.Status.NightVision(ICommands.M), 
                                IGet.External.CommandAudio(ICommands.M));
                            return;

                        default:
                            return;
                    }

                case L1.Flight_Assist:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.FlightAssist(true, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Disable:
                            Call.Action.FlightAssist(false, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Toggle:
                            Call.Action.FlightAssist(!IGet.Status.FlightAssist(ICommands.M), 
                                IGet.External.CommandAudio(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Cargo_Scoop:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Deploy:
                            Call.Action.CargoScoop(true, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Retract:
                            Call.Action.CargoScoop(false, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Toggle:
                            Call.Action.CargoScoop(!IGet.Status.CargoScoop(ICommands.M), 
                                IGet.External.CommandAudio(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Lights:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.ExternalLights(true, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Disable:
                            Call.Action.ExternalLights(false, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Toggle:
                            Call.Action.ExternalLights(!IGet.Status.ExternalLights(ICommands.M), 
                                IGet.External.CommandAudio(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Silent_Running:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.SilentRunning(true, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Disable:
                            Call.Action.SilentRunning(false, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Toggle:
                            Call.Action.SilentRunning(!IGet.Status.SilentRunning(ICommands.M), 
                                IGet.External.CommandAudio(ICommands.M));
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
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                case L3.Two:
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                case L3.Three:
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                case L3.Four:
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                default:
                                    Call.Action.Activate_Chaff(IGet.External.CommandAudio(ICommands.M));
                                    return;
                            }

                        case L2.Select:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                case L3.Two:
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                case L3.Three:
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                case L3.Four:
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Assign:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.One:
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                case L3.Two:
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                case L3.Three:
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                case L3.Four:
                                    ICommands.LogNotImplemented(ICommands.M, Command, 3);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Full_Spectrum_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.Full_Spectrum_Scanner(true, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Disable:
                            Call.Action.Full_Spectrum_Scanner(false, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Toggle:
                            Call.Action.Full_Spectrum_Scanner(!IStatus.Lights, IGet.External.CommandAudio(ICommands.M));
                            return;
                      
                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Surface_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Call.Action.SurfaceScaner(true, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Disable:
                            Call.Action.SurfaceScaner(false, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Toggle:
                            Call.Action.SurfaceScaner(!IStatus.ModeSurfScanner, IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Select:
                            Call.Action.SurfaceScaner(true, IGet.External.CommandAudio(ICommands.M), true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.ScannerSurface,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Discovery_Scanner:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            IActions.DiscoveryScanner.Operate(IGet.External.CommandAudio(ICommands.M));
                            return;

                        case L2.Select:
                            IActions.DiscoveryScanner.Operate(true, false, true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.ScannerDiscovery,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Collector_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.CollectorLimpet(IGet.External.CommandAudio(ICommands.M), false);
                            return;

                        case L2.Select:
                            Call.Action.CollectorLimpet(IGet.External.CommandAudio(ICommands.M), true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.LimpetCollector,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
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
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.LimpetDecontamination);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.LimpetDecontamination,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Fuel_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.FuelLimpet(IGet.External.CommandAudio(ICommands.M), false);
                            return;

                        case L2.Select:
                            Call.Action.FuelLimpet(IGet.External.CommandAudio(ICommands.M), true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.LimpetFuel,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
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
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.LimpetHatchBreaker);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.LimpetHatchBreaker,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Prospector_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.ProspectorLimpet(IGet.External.CommandAudio(ICommands.M), false);
                            return;

                        case L2.Select:
                            Call.Action.ProspectorLimpet(IGet.External.CommandAudio(ICommands.M), true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.LimpetProspector,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Recon_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.ReconLimpet(IGet.External.CommandAudio(ICommands.M), false);
                            return;

                        case L2.Select:
                            Call.Action.ReconLimpet(IGet.External.CommandAudio(ICommands.M), true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.LimpetRecon,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Repair_Limpet:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Activate:
                            Call.Action.RepairLimpet(IGet.External.CommandAudio(ICommands.M), false);
                            return;

                        case L2.Select:
                            Call.Action.RepairLimpet(IGet.External.CommandAudio(ICommands.M), true);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.LimpetRepair,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
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
                            ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.LimpetResearch);
                            return;

                        case L2.Assign:
                            ISettings.Firegroups.Config.Assign(
                                ConfigurationHardpoints.Item.LimpetResearch,
                                ISettings.Firegroups.Config.ConvertGroupToEnum(IGet.External.FireGroup(ICommands.M, true)),
                                ISettings.Firegroups.Config.ConverFireToEnum(IGet.External.FireMode(ICommands.M, true)));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Launch:
                    Call.Action.Launch(IGet.External.CommandAudio(ICommands.M));
                    return;

                case L1.Landing:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Prepare:
                            Call.Action.LandingPreparations(IGet.External.CommandAudio(ICommands.M));
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
                                    IActions.Throttle.Boost(IGet.External.BoostNum(ICommands.M, true), true, IGet.External.CommandAudio(ICommands.M));
                                    return;

                                case L3.Stop:
                                    IActions.Throttle.Num_Boost = 0;
                                    return;

                                default:
                                    IActions.Throttle.Boost(1, true, IGet.External.CommandAudio(ICommands.M));
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