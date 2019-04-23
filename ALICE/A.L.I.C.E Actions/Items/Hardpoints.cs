using ALICE_Core;
using ALICE_Debug;
using ALICE_Equipment;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Response;
using ALICE_Settings;
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

            #region Status == Command
            if (IGet.Status.Hardpoints(MethodName) == CMD)
            {
                if (CMD == true)
                {
                    //Audio - Currently Deployed
                    IResponse.Hardpoints.DeployedHardpoints(CA);

                    return;
                }
                else if (CMD == false)
                {
                    //Audio - Currently Retracted
                    IResponse.Hardpoints.RetractedHardpoints(CA);

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
                    
                    IKeyboard.Press(IKey.Deploy_Hardpoints, 0);

                    //Audio - Deploying
                    IResponse.Hardpoints.DeployingHardpoints(CA);
                }

                //Retract
                else if (CMD == false)
                {
                    IKeyboard.Press(IKey.Deploy_Hardpoints, 0);

                    //Audio - Retracting
                    IResponse.Hardpoints.RetractingHardpoints(CA);

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
        /// /// Function To Call Up Weapons
        /// </summary>
        /// <param name="CA">(Command Audio) Enable Or Disable Audio On The Command Level.</param>
        /// <param name="G">(Group) Weapons Group 1 Or 2.</param>
        public void Weapons(bool CA, int G)
        {
            string MethodName = "Hardpoints (Weapons)";

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
            if (ICheck.Environment.Space(MethodName, true, IEnums.Supercruise) == true)
            {
                //Audio - Docked
                IResponse.Hardpoints.NoSupercruise(CA);

                return;
            }
            #endregion

            //Hardpoints Retracted
            if (ICheck.Status.Hardpoints(MethodName, false))
            {
                //Weapon Safey Check
                if (Safeties(MethodName, CA) == false)
                {
                    return;
                }

                //Keypress
                IKeyboard.Press(IKey.Deploy_Hardpoints, 0);

                //Audio - Deploying Weapons
                IResponse.Hardpoints.DeployingWeapons(CA);

                //Main Weapons
                if (G == 1)
                {
                    //Select Weapons And Configure Mode
                    switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.Weapons1))
                    {
                        case Settings_Firegroups.S.Failed:
                            IEquipment.General.SelectionFailed(CA);
                            break;

                        default:
                            break;
                    }
                }

                //Secondary Weapons
                else
                {
                    //Select Weapons And Configure Mode
                    switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.Weapons2))
                    {
                        case Settings_Firegroups.S.Failed:
                            IEquipment.General.SelectionFailed(CA);
                            break;

                        default:
                            break;
                    }
                }
            }

            //Hardpoints Deployed
            else
            {
                //Main Weapons
                if (G == 1)
                {
                    //Select Weapons And Configure Mode
                    switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.Weapons1))
                    {
                        case Settings_Firegroups.S.Selected:
                            IEquipment.General.Selected(CA);
                            break;

                        case Settings_Firegroups.S.Failed:
                            IEquipment.General.SelectionFailed(CA);
                            break;

                        case Settings_Firegroups.S.CurrentlySelected:
                            IEquipment.General.CurrentlySelected(CA);
                            break;

                        default:
                            break;
                    }
                }

                //Secondary Weapons
                else
                {
                    //Select Weapons And Configure Mode
                    switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.Weapons2))
                    {
                        case Settings_Firegroups.S.Selected:
                            IEquipment.General.Selected(CA);
                            break;

                        case Settings_Firegroups.S.Failed:
                            IEquipment.General.SelectionFailed(CA);
                            break;

                        case Settings_Firegroups.S.CurrentlySelected:
                            IEquipment.General.CurrentlySelected(CA);
                            break;

                        default:
                            break;
                    }
                }
            }
           
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

        /// <summary>
        /// Sets Weapon Groups.
        /// </summary>
        /// <param name="S">(Weapons Set) Main = 1, Secondary = 2.</param>
        /// <param name="G">(Group) Group Number.</param>
        public void WeaponsGroup(decimal S, string G)
        {
            string MethodName = "Hardpoints (Weapons Group)";

            //Main Weapons Group
            if (S == 1)
            {
                ISettings.Firegroup.Assign(Settings_Firegroups.Item.Weapons1,
                    ISettings.Firegroup.ConvertGroupToEnum(G),
                    Settings_Firegroups.Fire.Primary);
            }

            //Secodnary Weapons Group
            else
            {
                ISettings.Firegroup.Assign(Settings_Firegroups.Item.Weapons2,
                    ISettings.Firegroup.ConvertGroupToEnum(G),
                    Settings_Firegroups.Fire.Primary);
            }            
        }
    }
}