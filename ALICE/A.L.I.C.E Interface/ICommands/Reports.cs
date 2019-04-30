using ALICE_Actions;
using ALICE_Debug;
using ALICE_Response;
using System.Collections.Generic;

namespace ALICE_Interface
{
    public static partial class ICommands
    {
        public static CMD_Report CMDReport = new CMD_Report();
    }

    public class CMD_Report : Commands
    {
        public void Search(List<string> Command)
        {
            switch (Command[1].Lookup<L1>())
            {
                case L1.No_Fire_Zone:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Report.NoFireZone(true);
                            return;

                        case L2.Disable:
                            IActions.Report.NoFireZone(false);
                            return;

                        case L2.Toggle:
                            IActions.Report.NoFireZone(!IGet.Report.NoFireZone(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Wanted_Target:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Report.TargetWanted(true);
                            return;

                        case L2.Disable:
                            IActions.Report.TargetWanted(false);
                            return;

                        case L2.Toggle:
                            IActions.Report.TargetWanted(!IGet.Report.TargetWanted(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Hostile_Faction:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Report.TargetEnemy(true);
                            return;

                        case L2.Disable:
                            IActions.Report.TargetEnemy(false);
                            return;

                        case L2.Toggle:
                            IActions.Report.TargetEnemy(!IGet.Report.TargetEnemy(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Collected_Bounties:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Report.CollectedBounty(true);
                            return;

                        case L2.Disable:
                            IActions.Report.CollectedBounty(false);
                            return;

                        case L2.Toggle:
                            IActions.Report.CollectedBounty(!IGet.Report.CollectedBounty(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Collected_Materials:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Report.MaterialCollected(true);
                            return;

                        case L2.Disable:
                            IActions.Report.MaterialCollected(false);
                            return;

                        case L2.Toggle:
                            IActions.Report.MaterialCollected(!IGet.Report.MaterialCollected(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Refined_Materials:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Report.MaterialRefined(true);
                            return;

                        case L2.Disable:
                            IActions.Report.MaterialRefined(false);
                            return;

                        case L2.Toggle:
                            IActions.Report.MaterialRefined(!IGet.Report.MaterialRefined(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Station_Status:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Report.StationStatus(true);
                            return;

                        case L2.Disable:
                            IActions.Report.StationStatus(false);
                            return;

                        case L2.Toggle:
                            IActions.Report.StationStatus(!IGet.Report.StationStatus(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Shield_State:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Report.ShieldState(true);
                            return;

                        case L2.Disable:
                            IActions.Report.ShieldState(false);
                            return;

                        case L2.Toggle:
                            IActions.Report.ShieldState(!IGet.Report.ShieldState(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Masslock:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Report.Masslock(true);
                            return;

                        case L2.Disable:
                            IActions.Report.Masslock(false);
                            return;

                        case L2.Toggle:
                            IActions.Report.Masslock(!IGet.Report.Masslock(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Fuel_Scooping:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            IActions.Report.FuelScoop(true);
                            return;

                        case L2.Disable:
                            IActions.Report.FuelScoop(false);
                            return;

                        case L2.Toggle:
                            IActions.Report.FuelScoop(!IGet.Report.FuelScoop(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Fuel_Report:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Status:
                            IResponse.Fuel.Level(true);
                            return;

                        case L2.Enable:
                            IActions.Report.FuelStatus(true);
                            return;

                        case L2.Disable:
                            IActions.Report.FuelStatus(false);
                            return;

                        case L2.Toggle:
                            IActions.Report.FuelStatus(!IGet.Report.FuelStatus(ICommands.M));
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