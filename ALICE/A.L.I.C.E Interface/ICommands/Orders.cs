using ALICE_Actions;
using ALICE_Debug;
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
                            IActions.Order.AutoSystemScans(true);
                            return;

                        case L2.Disable:
                            IActions.Order.AutoSystemScans(false);
                            return;

                        case L2.Toggle:
                            IActions.Order.AutoSystemScans(!IGet.Order.AssistSystemScan(ICommands.M));
                            return;
                       
                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }                    

                case L1.Docking_Procedures:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Order.AutoDockingProcedure(true);
                            return;

                        case L2.Disable:
                            IActions.Order.AutoDockingProcedure(false);
                            return;

                        case L2.Toggle:
                            IActions.Order.AutoDockingProcedure(!IGet.Order.AssistDocking(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Station_Refuel:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            //IActions.Order.AutoRefuel(true);
                            return;

                        case L2.Disable:
                            //IActions.Order.AutoRefuel(false);
                            return;

                        case L2.Toggle:
                            //IActions.Order.AutoRefuel(!IGet.Order.AssistRefuel(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Station_Rearm:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            //IActions.Order.AutoRearm(true);
                            return;

                        case L2.Disable:
                            //IActions.Order.AutoRearm(false);
                            return;

                        case L2.Toggle:
                            //IActions.Order.AutoRearm(!IGet.Order.AssistRearm(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Station_Repair:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            //IActions.Order.AutoRepair(true);
                            return;

                        case L2.Disable:
                            //IActions.Order.AutoRepair(false);
                            return;

                        case L2.Toggle:
                            //IActions.Order.AutoRepair(!IGet.Order.AssistRepair(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Hanger_Entry:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Order.AutoHangerEntry(true);
                            return;

                        case L2.Disable:
                            IActions.Order.AutoHangerEntry(false);
                            return;

                        case L2.Toggle:
                            IActions.Order.AutoHangerEntry(!IGet.Order.AssistHangerEntry(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Assisted_Power:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Order.CombatPower(true);
                            return;

                        case L2.Disable:
                            IActions.Order.CombatPower(false);
                            return;

                        case L2.Toggle:
                            IActions.Order.CombatPower(!IGet.Order.CombatPower(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Post_Jump_Safety:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Order.PostJumpSafety(true);
                            return;

                        case L2.Disable:
                            IActions.Order.PostJumpSafety(false);
                            return;

                        case L2.Toggle:
                            IActions.Order.PostJumpSafety(!IGet.Order.PostJumpSafety(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Weapon_Safety:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Order.WeaponSafety(true);
                            return;

                        case L2.Disable:
                            IActions.Order.WeaponSafety(false);
                            return;

                        case L2.Toggle:
                            IActions.Order.WeaponSafety(!IGet.Order.WeaponSafety(ICommands.M));
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