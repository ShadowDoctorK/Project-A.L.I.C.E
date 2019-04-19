using ALICE_Debug;
using ALICE_Equipment;
using ALICE_Settings;
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
                            ISettings.U_NoFireZone(true);
                            return;

                        case L2.Disable:
                            ISettings.U_NoFireZone(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_NoFireZone(!IGet.Report.NoFireZone(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Wanted_Target:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_TargetWanted(true);
                            return;

                        case L2.Disable:
                            ISettings.U_TargetWanted(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_TargetWanted(!IGet.Report.TargetWanted(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Hostile_Faction:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_TargetEnemy(true);
                            return;

                        case L2.Disable:
                            ISettings.U_TargetEnemy(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_TargetEnemy(!IGet.Report.TargetEnemy(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Collected_Bounties:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_CollectedBounty(true);
                            return;

                        case L2.Disable:
                            ISettings.U_CollectedBounty(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_CollectedBounty(!IGet.Report.CollectedBounty(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Collected_Materials:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_MaterialCollected(true);
                            return;

                        case L2.Disable:
                            ISettings.U_MaterialCollected(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_MaterialCollected(!IGet.Report.MaterialCollected(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Refined_Materials:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_MaterialRefined(true);
                            return;

                        case L2.Disable:
                            ISettings.U_MaterialRefined(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_MaterialRefined(!IGet.Report.MaterialRefined(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Station_Status:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_StationStatus(true);
                            return;

                        case L2.Disable:
                            ISettings.U_StationStatus(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_StationStatus(!IGet.Report.StationStatus(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Shield_State:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_ShieldState(true);
                            return;

                        case L2.Disable:
                            ISettings.U_ShieldState(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_ShieldState(!IGet.Report.ShieldState(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Masslock:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_Masslock(true);
                            return;

                        case L2.Disable:
                            ISettings.U_Masslock(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_Masslock(!IGet.Report.Masslock(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Fuel_Scooping:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Enable:
                            ISettings.U_FuelScoop(true);
                            return;

                        case L2.Disable:
                            ISettings.U_FuelScoop(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_FuelScoop(!IGet.Report.FuelScoop(ICommands.M));
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Fuel_Report:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Status:
                            IEquipment.FuelTank.FuelLevel(true);
                            return;

                        case L2.Enable:
                            ISettings.U_FuelStatus(true);
                            return;

                        case L2.Disable:
                            ISettings.U_FuelStatus(false);
                            return;

                        case L2.Toggle:
                            ISettings.U_FuelStatus(!IGet.Report.FuelStatus(ICommands.M));
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