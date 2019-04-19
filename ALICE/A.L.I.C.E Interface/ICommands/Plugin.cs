using ALICE_Internal;
using ALICE_Settings;
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

                    PlugIn.Initialize(true, true);
                    return;

                case L1.Pip_Speed:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Increase:
                            ISettings.PipSpeed(false);
                            return;

                        case L2.Decrease:
                            ISettings.PipSpeed(true);
                            return;                        

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Panel_Speed:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Increase:
                            ISettings.PanelSpeed(false);
                            return;

                        case L2.Decrease:
                            ISettings.PanelSpeed(true);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Fire_Group_Speed:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Increase:
                            ISettings.FireGroupSpeed(false);
                            return;

                        case L2.Decrease:
                            ISettings.FireGroupSpeed(true);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Throttle_Speed:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Increase:
                            ISettings.ThrottleSpeed(false);
                            return;

                        case L2.Decrease:
                            ISettings.ThrottleSpeed(true);
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
                            PlugIn.DebugMode = true;
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

                case L1.Monitor_Status:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Monitors.Json.Log = true;
                            Logger.Log(ICommands.M, "Status Monitor Logging: " + Monitors.Json.Log, Logger.Yellow);
                            return;

                        case L2.Disable:
                            Monitors.Json.Log = true;
                            Logger.Log(ICommands.M, "Status Monitor Logging: " + Monitors.Json.Log, Logger.Yellow);
                            return;

                        case L2.Toggle:
                            Monitors.Json.Log = !Monitors.Json.Log;
                            Logger.Log(ICommands.M, "Status Monitor Logging: " + Monitors.Json.Log, Logger.Yellow);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Master_Audio:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            Monitors.Json.Log = true;
                            Logger.Log(ICommands.M, "Status Monitor Logging: " + Monitors.Json.Log, Logger.Yellow);
                            return;

                        case L2.Disable:
                            Monitors.Json.Log = true;
                            Logger.Log(ICommands.M, "Status Monitor Logging: " + Monitors.Json.Log, Logger.Yellow);
                            return;

                        case L2.Toggle:
                            Monitors.Json.Log = !Monitors.Json.Log;
                            Logger.Log(ICommands.M, "Status Monitor Logging: " + Monitors.Json.Log, Logger.Yellow);
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