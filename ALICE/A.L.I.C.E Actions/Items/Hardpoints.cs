using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Response;
using System.Threading;

namespace ALICE_Actions
{
    public static partial class IActions
    {
        public static Hardpoints Hardpoints { get; set; } = new Hardpoints();    
    }

    public class Hardpoints
    {
        /// <summary>
        /// Enum used to control the Mode the hardpoints are in.
        /// </summary>
        public enum M { None, Analysis, Combat }

        /// <summary>
        /// Swithces between Analysis and Combat Mode.
        /// </summary>
        /// <param name="CMD">(Command) True = Analysis Mode, False = Combat Mode</param>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        public void Mode(bool CMD, bool CommandAudio)
        {
            string MethodName = "Hardpoints (Mode)";

            #region Status == Command
            if (IStatus.AnalysisMode == CMD)
            {
                if (CMD == true)
                {
                    return;
                }
                else if (CMD == false)
                {
                    return;
                }
            }
            #endregion

            #region Status != Command
            else if (IStatus.AnalysisMode != CMD)
            {
                if (CMD == true)
                {
                    IKeyboard.Press(IKey.Toggle_HUD_Mode, 0);
                    IStatus.AnalysisMode = true;
                    return;
                }
                else if (CMD == false)
                {
                    IKeyboard.Press(IKey.Toggle_HUD_Mode, 0);
                    IStatus.AnalysisMode = false;
                    return;
                }
            }
            #endregion
        }

        /// <summary>
        /// Operates the ships hardpoints.
        /// </summary>
        /// <param name="CMD">(Command) True = Deploy, False = Retract</param>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="W">(Default) True will change to the users default firegroup.</param>
        /// <param name="MD">(Mode) Pass the mode you want the hardpoints in.</param>
        public void Operate(bool CMD, bool CA, bool D = false, M MD = M.None)
        {
            string MethodName = "Hardpoints (Operate)";

            #region Valid Command Checks
            //Check Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio - In Hyperspace
                IResponse.Hardpoints.NoHyperspace(CA);
                
                return;
            }

            //Check Docked
            if (ICheck.Docking.Status(MethodName, false, IEnums.DockingState.Docked, true) == false)
            {
                //Audio - Docked
                IResponse.Hardpoints.NoDocked(CA);

                return;
            }

            //Check Touchdown
            if (ICheck.Status.Touchdown(MethodName, false) == false)
            {
                //Audio - Docked
                IResponse.Hardpoints.NoTouchdown(CA);

                return;
            }

            //Check Supercruise (Deploy Only)
            if (ICheck.Environment.Space(MethodName, true, IEnums.Supercruise) == true && CMD == true)
            {
                //Audio - Docked
                IResponse.Hardpoints.NoSupercruise(CA);

                return;
            }
            #endregion

            //Check Weapon Safety Disabled
            if (ICheck.Status.WeaponSafety(MethodName, false))
            {
                #region Weapons Called

                #endregion
                //Default Group
                if (D)
                {
                    Default(MethodName, CA);
                }

                //Hardpoint Mode
                switch (MD)
                {
                    case M.Analysis:
                        Mode(true, false);
                        break;

                    case M.Combat:
                        Mode(false, false);
                        break;

                    default:
                        //No Action
                        break;
                }

                //Check If Weapons Was Ordered
                if (IGet.Status.Hardpoints(MethodName) == true  //Check Hardpoints Deployed
                    && CMD == true                              //Check Order Is Deploy
                    && MD == M.Combat)                          //Check Mode Ordered Is Combat
                {
                    //Select Default Group
                    Default(MethodName, CA);

                    //Postive Response
                    IResponse.Hardpoints.PositiveResponse(CA);

                    return;
                }
            }         

            #region Status == Command
            if (IGet.Status.Hardpoints(MethodName) == CMD)
            {
                if (CMD == true)
                {
                    //Weapons
                    if (MD == M.Combat)
                    {
                        //Audio - Currently Deployed
                        IResponse.Hardpoints.DeployedWeapons(CA);
                    }

                    //Hardpoints
                    else
                    {
                        //Audio - Currently Deployed
                        IResponse.Hardpoints.DeployedHardpoints(CA);
                    }

                    return;
                }
                else if (CMD == false)
                {
                    //Weapons
                    if (MD == M.Combat)
                    {
                        //Audio - Currently Retracted
                        IResponse.Hardpoints.RetractedWeapons(CA);
                    }

                    //Hardpoints
                    else
                    {
                        //Audio - Currently Retracted
                        IResponse.Hardpoints.RetractedHardpoints(CA);
                    }

                    return;
                }
            }
            #endregion

            #region Status != Command
            else if (IGet.Status.Hardpoints(MethodName) != CMD)
            {
                //Deploy
                if (CMD == true)
                {
                    //Weapon Safey Check
                    if (Safeties(MethodName, CA) == false)
                    {
                        return;
                    }
                    else
                    {
                        //Default Group
                        if (D)
                        {
                            Default(MethodName, CA);
                        }

                        //Hardpoint Mode
                        switch (MD)
                        {
                            case M.Analysis:
                                Mode(true, false);
                                break;

                            case M.Combat:
                                Mode(false, false);
                                break;

                            default:
                                //No Action
                                break;
                        }
                    }
                    
                    IKeyboard.Press(IKey.Deploy_Hardpoints, 0);

                    //Weapons
                    if (MD == M.Combat)
                    {
                        //Audio - Deploying
                        IResponse.Hardpoints.DeployingHardpoints(CA);
                    }

                    //Hardpoints
                    else
                    {
                        //Audio - Deploying
                        IResponse.Hardpoints.DeployingWeapons(CA);
                    }
                }

                //Retract
                else if (CMD == false)
                {
                    IKeyboard.Press(IKey.Deploy_Hardpoints, 0);

                    //Weapons
                    if (Call.Firegroup.Current == Call.Firegroup.Default        //Weapons Group Selected
                        && ICheck.Status.AnalysisMode(MethodName, false))       //In Combat Mode
                    {
                        //Audio - Retracting
                        IResponse.Hardpoints.RetractingWeapons(CA);
                    }

                    //Hardpoints
                    else
                    {
                        //Audio - Retracting
                        IResponse.Hardpoints.RetractingHardpoints(CA);
                    }

                    //Set Weapon Safeties
                    if (ICheck.Order.WeaponSafety(MethodName, true)                     //Check Enabled   
                     && ICheck.SupercruiseExit.BodyType(MethodName, true, "Station"))   //Check In Station's Space
                    {
                        //Audio - Enabling Weapon Safeties
                        IResponse.Docking.WeaponSafetiesEnabling(CA);

                        //Set Weapon Safeties
                        ISet.Status.WeaponSafety(MethodName, true);
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Function used to select the user defined default firegroup.
        /// </summary>
        /// <param name="M">(Method) The simple name of the Method calling the function.</param>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        public void Default(string M, bool CA)
        {
            //Select Default Group
            Call.Firegroup.Select(Call.Firegroup.Default, false);
            Thread.Sleep(100);
        }

        /// <summary>
        /// Function used to interact with the user to disable safeties.
        /// </summary>
        /// <param name="M">(Method) The simple name of the Method calling the function.</param>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <returns>True = Disabled, False = Not Disabled.</returns>
        public bool Safeties(string M, bool CA)
        {
            string MethodName = "Hardpoints (Safeties)";

            //Check Weapon Safety Disabled
            if (ICheck.Status.WeaponSafety(M, false))
            {
                return true;
            }

            //Audio - Override Question
            IResponse.Hardpoints.SafetiesOverride(CA);

            //Monitor Response
            Thread.Sleep(1500); switch (IStatus.Interaction.Question(10000))
            {
                case ALICE_Status.Status_Interaction.Answers.NoResponse:

                    //Debug Logger
                    Logger.DebugLine(M, "Question: No Response.", Logger.Yellow);

                    return false;

                case ALICE_Status.Status_Interaction.Answers.Yes:

                    //Audio - Postive Response
                    IResponse.Hardpoints.PositiveResponse(CA);

                    //Disabled Weapon Safeties
                    ISet.Status.WeaponSafety(MethodName, false);

                    return true;

                case ALICE_Status.Status_Interaction.Answers.No:

                    //Audio - Safeties Remain
                    IResponse.Hardpoints.SafetiesRemain(CA);

                    return false;

                default:
                    //No Action
                    return false;
            }
        }
    }
}