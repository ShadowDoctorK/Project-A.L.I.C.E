using ALICE_Actions;
using ALICE_Debug;
using ALICE_Internal;
using System.Collections.Generic;
using System.Threading;

namespace ALICE_Interface
{
    public static partial class ICommands
    {
        public static CMD_Target CMDTarget = new CMD_Target();
    }

    public class CMD_Target : Commands
    {
        public void Search(List<string> Command)
        {
            switch (Command[1].Lookup<L1>())
            {
                case L1.Wingman_One:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Select:
                            Targeting.Select_Wingman(1, PlugIn.CommandAudio);
                            return;

                        case L2.Nav_Lock:
                            Targeting.Select_Wingmans_NavLock(1, PlugIn.CommandAudio);
                            return;

                        case L2.Target:
                            Targeting.Select_Wingmans_Target(1, PlugIn.CommandAudio);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Wingman_Two:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Select:
                            Targeting.Select_Wingman(2, PlugIn.CommandAudio);
                            return;

                        case L2.Nav_Lock:
                            Targeting.Select_Wingmans_NavLock(2, PlugIn.CommandAudio);
                            return;

                        case L2.Target:
                            Targeting.Select_Wingmans_Target(2, PlugIn.CommandAudio);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Wingman_Three:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Select:
                            Targeting.Select_Wingman(3, PlugIn.CommandAudio);
                            return;

                        case L2.Nav_Lock:
                            Targeting.Select_Wingmans_NavLock(3, PlugIn.CommandAudio);
                            return;

                        case L2.Target:
                            Targeting.Select_Wingmans_Target(3, PlugIn.CommandAudio);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Subsystem:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Next:
                            Targeting.Cycle_Subsystems(1, true, PlugIn.CommandAudio);
                            return;

                        case L2.Previous:
                            Targeting.Cycle_Subsystems(1, false, PlugIn.CommandAudio);
                            return;

                        case L2.Shield_Generator:
                            Assisted.Targeting.Subsystem_Target("Shield Generator", PlugIn.CommandAudio);
                            return;

                        case L2.Cargo_Hatch:
                            Assisted.Targeting.Subsystem_Target("Cargo Hatch", PlugIn.CommandAudio);
                            return;

                        case L2.FSD_Interdictor:
                            Assisted.Targeting.Subsystem_Target("FSD Interdictor", PlugIn.CommandAudio);
                            return;

                        case L2.Power_Distributor:
                            Assisted.Targeting.Subsystem_Target("Power Distributor", PlugIn.CommandAudio);
                            return;

                        case L2.Life_Support:
                            Assisted.Targeting.Subsystem_Target("Life Support", PlugIn.CommandAudio);
                            return;

                        case L2.Hyperdrive:
                            Assisted.Targeting.Subsystem_Target("FSD", PlugIn.CommandAudio);
                            return;

                        case L2.Power_Plant:
                            Assisted.Targeting.Subsystem_Target("Power Plant", PlugIn.CommandAudio);
                            return;

                        case L2.Engines:
                            Assisted.Targeting.Subsystem_Target("Drive", PlugIn.CommandAudio);
                            return;

                        case L2.Cargo_Scanner:
                            Assisted.Targeting.Subsystem_Target("Cargo Scanner", PlugIn.CommandAudio);
                            return;
                            
                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Hostile:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Next:
                            Thread HostileNext = new Thread((ThreadStart)(() => 
                            { Targeting.Cycle_Hostile_Targets(IGet.External.TargetCycle(ICommands.M, true), true); }))
                            { IsBackground = true }; HostileNext.Start();
                            return;

                        case L2.Previous:
                            Thread HostilePrevious = new Thread((ThreadStart)(() =>
                            { Targeting.Cycle_Hostile_Targets(IGet.External.TargetCycle(ICommands.M, true), false); }))
                            { IsBackground = true }; HostilePrevious.Start();
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.General:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Next:
                            Thread GeneralNext = new Thread((ThreadStart)(() =>
                            { Targeting.Cycle_Targets(IGet.External.TargetCycle(ICommands.M, true), true); }))
                            { IsBackground = true }; GeneralNext.Start();
                            return;

                        case L2.Previous:
                            Thread GeneralPrevious = new Thread((ThreadStart)(() =>
                            { Targeting.Cycle_Targets(IGet.External.TargetCycle(ICommands.M, true), false); }))
                            { IsBackground = true }; GeneralPrevious.Start();
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Scan:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Setting:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Blacklist:

                                    switch (Command[4].Lookup<L4>())
                                    {
                                        case L4.Enable:
                                            Assisted.Targeting.Flag_Blacklist = true;
                                            return;

                                        case L4.Disable:
                                            Assisted.Targeting.Flag_Blacklist = false;
                                            return;

                                        default:
                                            ICommands.LogInvalid(ICommands.M, Command, 4);
                                            return;
                                    }

                                case L3.Hostile_Faction:

                                    switch (Command[4].Lookup<L4>())
                                    {
                                        case L4.Enable:
                                            Assisted.Targeting.Flag_Hostile = true;
                                            return;

                                        case L4.Disable:
                                            Assisted.Targeting.Flag_Hostile = false;
                                            return;

                                        default:
                                            ICommands.LogInvalid(ICommands.M, Command, 4);
                                            return;
                                    }

                                case L3.Detailed_Scan:

                                    switch (Command[4].Lookup<L4>())
                                    {
                                        case L4.Enable:
                                            Assisted.Targeting.Flag_Detailed = true;
                                            return;

                                        case L4.Disable:
                                            Assisted.Targeting.Flag_Detailed = false;
                                            return;

                                        default:
                                            ICommands.LogInvalid(ICommands.M, Command, 4);
                                            return;
                                    }

                                case L3.Wanted:

                                    switch (Command[4].Lookup<L4>())
                                    {
                                        case L4.Enable:
                                            Assisted.Targeting.Flag_Wanted = true;
                                            return;

                                        case L4.Disable:
                                            Assisted.Targeting.Flag_Wanted = false;
                                            return;

                                        default:
                                            ICommands.LogInvalid(ICommands.M, Command, 4);
                                            return;
                                    }

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.General:
                            Assisted.Targeting.Hostile = false;
                            Assisted.Targeting.SeriesScan(PlugIn.CommandAudio);
                            return;

                        case L2.Hostile:
                            Assisted.Targeting.Hostile = true;
                            Assisted.Targeting.SeriesScan(PlugIn.CommandAudio);
                            return;

                        case L2.Pause:
                            Assisted.Targeting.Flag_Pause = true;
                            return;

                        case L2.Unpause:
                            //Continue Past Currently Maintained Target
                            if (Assisted.Targeting.Flag_Pause == false)
                            {
                                Assisted.Targeting.Flag_Maintain = false;
                            }

                            //Unpause A Paused Scan
                            Assisted.Targeting.Flag_Pause = false;
                            return;

                        case L2.Stop:
                            Assisted.Targeting.Flag_Stop = true;
                            return;

                        case L2.Blacklist:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Add_Pilot:
                                    Assisted.Targeting.BlackList_Pilot(PlugIn.CommandAudio);
                                    return;

                                case L3.Add_Faction:
                                    Assisted.Targeting.BlackList_Faction(PlugIn.CommandAudio);
                                    return;

                                case L3.Clear_All:
                                    Assisted.Targeting.BlackList_Reset(PlugIn.CommandAudio);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Whitelist:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Add_Pilot:
                                    Assisted.Targeting.WhiteList_Pilot(PlugIn.CommandAudio);
                                    return;

                                case L3.Add_Faction:
                                    Assisted.Targeting.WhiteList_Faction(PlugIn.CommandAudio);
                                    return;

                                case L3.Clear_All:
                                    Assisted.Targeting.WhiteList_Reset(PlugIn.CommandAudio);
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