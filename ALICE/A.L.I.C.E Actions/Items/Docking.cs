using ALICE_Core;
using ALICE_Debug;
using ALICE_Equipment;
using ALICE_Internal;
using ALICE_Response;
using System.Threading;

namespace ALICE_Actions
{
    public static partial class IActions
    {     
        public static Docking Docking { get; set; } = new Docking();
    }

    public class Docking
    {
        /// <summary>
        /// Send or Cancels a docking request with the target station.
        /// </summary>
        /// <param name="Request">True to dock, False to abort docking.</param>
        /// <param name="CommandAudio">Command level audio swtich.</param>
        /// <param name="PlayerCMD">Indicates if its a internal or player execution.</param>
        public void Request(IEnums.CMD Request, bool CommandAudio, bool PlayerCMD = true)
        {
            string MethodName = "Docking Request";

            switch (Request)
            {
                //Request Docking
                case IEnums.CMD.True:

                    #region Validation
                    //Pending Request Check 
                    if (IStatus.Docking.Sending == true || IStatus.Docking.Pending == true)
                    {
                        //Audio - Request Pending.
                        Logger.DebugLine(MethodName, "Request Pending", Logger.Blue);
                        return;
                    }

                    //Check Docking State
                    switch (IStatus.Docking.State)
                    {
                        case IEnums.DockingState.Granted:
                            IResponse.Docking.AlreadyGranted(CommandAudio);
                            return;

                        case IEnums.DockingState.Docked:
                            IResponse.Docking.Docked(CommandAudio);
                            return;

                        default:
                            break;
                    }
                    #endregion

                    #region Send Request
                    //Send Request

                    //Audio - Postive Response
                    IResponse.General.Positve(
                        CommandAudio,           //Check Command Audio
                        PlayerCMD);             //Check Player Called Command

                    IStatus.Docking.Sending = true;
                    Call.Panel.Target.Contacts.DockingRequest();
                    Call.Panel.Target.Panel(false);

                    //Watch For Request To Send
                    if (IStatus.Docking.WatchRequest() == false)
                    {
                        Logger.Log(MethodName, "Looks Like Something Went Wrong, Reqeust Didnt Send. Try Again.", Logger.Red);
                        return;
                    }

                    //Watch For Station Response
                    if (IStatus.Docking.WatchResponse() == false)
                    {
                        Logger.Log(MethodName, "Looks Like The Station Is Taking Too Long To Respond. I've Lost Intrest.", Logger.Red);
                        return;
                    }

                    //Station Response
                    switch (IStatus.Docking.State)
                    {
                        case IEnums.DockingState.Granted:

                            IResponse.Docking.Granted(CommandAudio);
                            break;

                        case IEnums.DockingState.Denied:

                            switch (IStatus.Docking.Denial)
                            {
                                case IEnums.DockingDenial.ActiveFighter:
                                    IResponse.Docking.ActiveFighter(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.Distance:
                                    IResponse.Docking.Distance(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.Offences:
                                    IResponse.Docking.Offences(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.Hostile:
                                    IResponse.Docking.Hostile(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.TooLarge:
                                    IResponse.Docking.TooLarge(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.NoSpace:
                                    IResponse.Docking.NoSpace(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.NoReason:
                                    IResponse.Docking.NoReason(CommandAudio);
                                    break;

                                default:
                                    IResponse.Docking.Unknown(CommandAudio);
                                    break;
                            }
                            break;

                        default:
                            break;
                    }
                    #endregion

                    #region Assisted Docking
                    if (ICheck.Order.AssistDocking(MethodName, true, true))
                    {
                        switch (Check.Equipment.DockingComputer(true, MethodName))
                        {
                            case true:
                                Call.Key.Press(Call.Key.Set_Speed_To_0, 0, Call.Key.DelayThrottle);
                                IResponse.Docking.StationHandover(CommandAudio);

                                //Resets the Report Bool for if the docking computer is not
                                //installed. This allows us to report again if Assisted Docking
                                //is enabled and there is no docking computer again.
                                IEquipment.DockingComputer.AsisstedDockingReport = true;

                                //Return: Docking Preps Controlled By Auto Docking.
                                return;

                            case false:
                                IEquipment.DockingComputer.NotInstalled(CommandAudio,
                                    IEquipment.DockingComputer.AsisstedDockingReport);

                                //Prevents Reporting No Docking Computer more then once.
                                IEquipment.DockingComputer.AsisstedDockingReport = false;
                                break;
                        }
                    }
                    #endregion

                    #region Docking Preparations
                    IStatus.Docking.WatchStarportEntry();
                    #endregion

                    break;

                //Cancel Docking
                case IEnums.CMD.False:

                    switch (IStatus.Docking.State)
                    {
                        case IEnums.DockingState.Granted:

                            if (ICheck.LandingGear.Status(MethodName, true, true) == true)
                            {
                                Call.Action.LandingGear(false, false);
                            }
                            Call.Panel.Target.Contacts.DockingRequest();
                            Call.Panel.Target.Panel(false);
                            return;

                        case IEnums.DockingState.Docked:
                            IResponse.Docking.Docked(CommandAudio);
                            return;

                        default:
                            break;
                    }

                    return;
            }
        }

        /// <summary>
        /// Alligns the ship for docking.
        /// </summary>
        /// <param name="CommandAudio">Command level audio switch.</param>
        public void Preparations(bool CommandAudio)
        {
            string ClassName = "Docking Preparations";

            IStatus.Docking.Preparations = true;

            if (ICheck.Status.SilentRunning(ClassName, true) == true)
            {
                Call.Action.SilentRunning(false, CommandAudio);
                Call.Power.Set(0, 4, 8);
            }
            else
            {
                Call.Power.Set(0, 8, 4);
            }

            Call.Action.LandingGear(true, false);
            Call.Action.CargoScoop(false, false);

            Thread.Sleep(2000);

            //Audio - Docking Preparations
            IResponse.Docking.Preparations(
                CommandAudio,                       //Check Command Level Audio
                ICheck.Initialized(ClassName));     //Check Plugin Initialized
        }
    }
}
