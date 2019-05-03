using ALICE_Actions;
using ALICE_Debug;
using ALICE_Status;
using System.Collections.Generic;
using System.Threading;

namespace ALICE_Interface
{
    public static partial class ICommands
    {
        public static CMD_Power CMDPower = new CMD_Power();
    }

    public class CMD_Power : Commands
    {
        public void Search(List<string> Command)
        {
            switch (Command[1].Lookup<L1>())
            {
                case L1.Set:
                    Thread power =
                    new Thread((ThreadStart)(() =>
                    {
                        Call.Power.Set(
                            IGet.External.WeaponPower(ICommands.M, true),                            
                            IGet.External.SystemPower(ICommands.M, true),
                            IGet.External.EnginePower(ICommands.M, true), 
                            IGet.External.RecordPower(ICommands.M, true));
                    }))
                    { IsBackground = true };
                    power.Start();
                    return;

                case L1.Restore:
                    Call.Power.SetRecorded();
                    return;

                case L1.Weapons:

                    switch (Command[2].Lookup<L2>())
                    {
                       
                        case L2.One:
                            Call.Power.Weapons(1);
                            return;

                        case L2.Two:
                            Call.Power.Weapons(2);
                            return;

                        case L2.Three:
                            Call.Power.Weapons(3);
                            return;

                        case L2.Four:
                            Call.Power.Weapons(4);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Engines:

                    switch (Command[2].Lookup<L2>())
                    {

                        case L2.One:
                            Call.Power.Engines(1);
                            return;

                        case L2.Two:
                            Call.Power.Engines(2);
                            return;

                        case L2.Three:
                            Call.Power.Engines(3);
                            return;

                        case L2.Four:
                            Call.Power.Engines(4);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Systems:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.One:
                            Call.Power.Systems(1);
                            return;

                        case L2.Two:
                            Call.Power.Systems(2);
                            return;

                        case L2.Three:
                            Call.Power.Systems(3);
                            return;

                        case L2.Four:
                            Call.Power.Systems(4);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Manager:

                    //Check Enabled
                    if (ICheck.Order.CombatPower(ICommands.M, true) == false) { return; }

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Maintain_Engines:
                            Assisted.Power.Maintain_Engines(
                                IGet.External.CommandAudio(ICommands.M));       //Get Command Audio From Platform 
                            break;

                        case L2.Maintain_Systems:
                            Assisted.Power.Maintain_Systems(
                                IGet.External.CommandAudio(ICommands.M));       //Get Command Audio From Platform 
                            break;

                        case L2.Defense:
                            Assisted.Power.Setting.Send_Power_To = Assisted.Power.Setting.Default_State;
                            break;

                        case L2.Offense:
                            Assisted.Power.Setting.Send_Power_To = Assisted.Power.Str.Weapons;
                            break;

                        case L2.Engines:
                            Assisted.Power.Defense_Engines(
                                IGet.External.CommandAudio(ICommands.M));       //Get Command Audio From Platform 
                            break;

                        case L2.Systems:
                            Assisted.Power.Defense_Systems(
                                IGet.External.CommandAudio(ICommands.M));       //Get Command Audio From Platform 
                            break;

                        case L2.Heavy:
                            Assisted.Power.Weapons_Heavy(
                                IGet.External.CommandAudio(ICommands.M));       //Get Command Audio From Platform 
                            break;

                        case L2.Balance:
                            Assisted.Power.Weapons_Balance(
                                IGet.External.CommandAudio(ICommands.M));       //Get Command Audio From Platform 
                            break;

                        case L2.Light:
                            Assisted.Power.Weapons_Light(
                                IGet.External.CommandAudio(ICommands.M));       //Get Command Audio From Platform 
                            break;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                    //Execute Change If Hardpoints Deployed
                    if (IStatus.Hardpoints == true)
                    {
                        Assisted.Power.CombatPowerManagement();
                    }

                    return;

                default:
                    ICommands.LogInvalid(ICommands.M, Command, 1);
                    return;
            }
        }
    }
}