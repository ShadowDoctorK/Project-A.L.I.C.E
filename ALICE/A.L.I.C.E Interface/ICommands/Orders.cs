using ALICE_Debug;
using ALICE_Settings;
using System.Collections.Generic;

namespace ALICE_Interface
{
    public static partial class ICommands
    {
        public static CMD_Order CMDOrder = new CMD_Order();
    }

    public class CMD_Order : Commands
    {
        public void Search(List<string> Command)
        {
            switch (Command[1].Lookup<L1>())
            {
                case L1.System_Scans:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_AutoSystemScans(true);
                            return;

                        case L2.Disable:
                            ISettings.U_AutoSystemScans(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_AutoSystemScans(!IGet.Order.AssistSystemScan(ICommands.M));
                            return;
                       
                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }                    

                case L1.Docking_Procedures:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_AutoDockingProcedure(true);
                            return;

                        case L2.Disable:
                            ISettings.U_AutoDockingProcedure(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_AutoDockingProcedure(!IGet.Order.AssistDocking(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Station_Refuel:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_AutoRefuel(true);
                            return;

                        case L2.Disable:
                            ISettings.U_AutoRefuel(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_AutoRefuel(!IGet.Order.AssistRefuel(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Station_Rearm:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_AutoRearm(true);
                            return;

                        case L2.Disable:
                            ISettings.U_AutoRearm(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_AutoRearm(!IGet.Order.AssistRearm(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Station_Repair:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_AutoRepair(true);
                            return;

                        case L2.Disable:
                            ISettings.U_AutoRepair(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_AutoRepair(!IGet.Order.AssistRepair(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Hanger_Entry:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_AutoHangerEntry(true);
                            return;

                        case L2.Disable:
                            ISettings.U_AutoHangerEntry(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_AutoHangerEntry(!IGet.Order.AssistHangerEntry(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Assisted_Power:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_CombatPower(true);
                            return;

                        case L2.Disable:
                            ISettings.U_CombatPower(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_CombatPower(!IGet.Order.CombatPower(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Post_Jump_Safety:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_PostJumpSafety(true);
                            return;

                        case L2.Disable:
                            ISettings.U_PostJumpSafety(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_PostJumpSafety(!IGet.Order.PostJumpSafety(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Weapon_Safety:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_WeaponSafety(true);
                            return;

                        case L2.Disable:
                            ISettings.U_WeaponSafety(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_WeaponSafety(!IGet.Order.WeaponSafety(ICommands.M));
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