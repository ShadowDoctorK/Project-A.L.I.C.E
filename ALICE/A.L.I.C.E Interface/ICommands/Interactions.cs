using ALICE_Core;
using System.Collections.Generic;

namespace ALICE_Interface
{
    public static partial class ICommands
    {
        public static CMD_Interactions CMDInteraction = new CMD_Interactions();
    }

    public class CMD_Interactions : Commands
    {
        public void Search(List<string> Command)
        {
            switch (Command[1].Lookup<L1>())
            {
                case L1.Custom:
                    return;

                case L1.Response:

                    switch (Command[2].Lookup<R1>())
                    {
                        case R1.Yes:
                            IStatus.Interaction.Yes();
                            return;

                        case R1.No:
                            IStatus.Interaction.No();
                            return;

                        case R1.Mark:
                            IStatus.Interaction.Mark();
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.General:

                    switch (Command[2].Lookup<R1>())
                    {
                        case R1.ALICE:
                            IStatus.Interaction.Response.Alice(true);
                            return;

                        case R1.I_Love_You:
                            IStatus.Interaction.Response.ILoveYou(true);
                            return;

                        case R1.Thank_You:
                            IStatus.Interaction.Response.ThankYou(true);
                            return;

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }
                
                default:
                    ICommands.LogInvalid(ICommands.M, Command, 1);
                    break;
            }
        }
    }
}