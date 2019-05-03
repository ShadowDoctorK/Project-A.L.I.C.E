using ALICE_Actions;
using ALICE_Internal;
using System.Collections.Generic;

namespace ALICE_Interface
{
    public static partial class ICommands
    {
        public static CMD_Plugin CMDPlugin = new CMD_Plugin();
    }

    public class CMD_Plugin : Commands
    {
        public void Search(List<string> Command)
        {
            switch (Command[1].Lookup<L1>())
            {
                case L1.Initialize:

                    PlugIn.Initialize(true, true, true);
                    return;

                case L1.Pip_Speed:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Increase:
                            IActions.Order.PipSpeed(false);
                            return;

                        case L2.Decrease:
                            IActions.Order.PipSpeed(true);
                            return;                        

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Panel_Speed:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Increase:
                            IActions.Order.PanelSpeed(false);
                            return;

                        case L2.Decrease:
                            IActions.Order.PanelSpeed(true);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Fire_Group_Speed:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Increase:
                            IActions.Order.FireGroupSpeed(false);
                            return;

                        case L2.Decrease:
                            IActions.Order.FireGroupSpeed(true);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Throttle_Speed:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Increase:
                            IActions.Order.ThrottleSpeed(false);
                            return;

                        case L2.Decrease:
                            IActions.Order.ThrottleSpeed(true);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Extended_Logging:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            PlugIn.ExtendedLogging = true;
                            Logger.Log(ICommands.M, "Extended Logging: " + PlugIn.ExtendedLogging, Logger.Yellow);
                            return;

                        case L2.Disable:
                            PlugIn.ExtendedLogging = true;
                            Logger.Log(ICommands.M, "Extended Logging: " + PlugIn.ExtendedLogging, Logger.Yellow);
                            return;

                        case L2.Toggle:
                            PlugIn.ExtendedLogging = !PlugIn.ExtendedLogging;
                            Logger.Log(ICommands.M, "Extended Logging: " + PlugIn.ExtendedLogging, Logger.Yellow);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Debug_Mode:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            PlugIn.DebugMode = true;
                            Logger.Log(ICommands.M, "Debug Logging: " + PlugIn.DebugMode, Logger.Yellow);
                            return;

                        case L2.Disable:
                            PlugIn.DebugMode = false;
                            Logger.Log(ICommands.M, "Debug Logging: " + PlugIn.DebugMode, Logger.Yellow);
                            return;

                        case L2.Toggle:
                            PlugIn.DebugMode = !PlugIn.DebugMode;
                            Logger.Log(ICommands.M, "Debug Logging: " + PlugIn.DebugMode, Logger.Yellow);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Variable_Mode:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            PlugIn.VariableLogging = true;
                            Logger.Log(ICommands.M, "Event Variable Logging: " + PlugIn.VariableLogging, Logger.Yellow);
                            return;

                        case L2.Disable:
                            PlugIn.VariableLogging = true;
                            Logger.Log(ICommands.M, "Event Variable Logging: " + PlugIn.VariableLogging, Logger.Yellow);
                            return;

                        case L2.Toggle:
                            PlugIn.VariableLogging = !PlugIn.VariableLogging;
                            Logger.Log(ICommands.M, "Event Variable Logging: " + PlugIn.VariableLogging, Logger.Yellow);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Master_Audio:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            PlugIn.MasterAudio = true;
                            Logger.Log(ICommands.M, "Master Audio: " + PlugIn.MasterAudio, Logger.Yellow);
                            return;

                        case L2.Disable:
                            PlugIn.MasterAudio = false;
                            Logger.Log(ICommands.M, "Master Audio: " + PlugIn.MasterAudio, Logger.Yellow);
                            return;

                        case L2.Toggle:
                            PlugIn.MasterAudio = !PlugIn.MasterAudio;
                            Logger.Log(ICommands.M, "Master Audio: " + PlugIn.MasterAudio, Logger.Yellow);
                            return;

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