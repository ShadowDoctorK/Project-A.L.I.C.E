using ALICE_Debug;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Response;
using ALICE_Settings;
using ALICE_Status;

namespace ALICE_Actions
{
    public static partial class IActions
    {
        public static Heatsink Heatsink { get; set; } = new Heatsink();    
    }

    public class Heatsink
    {
        /// <summary>
        /// Checks gamestate, then activates a heatsink if logic pass'
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="Cold">(Modifier) Enabled parts of the audio based on modified activation.</param>
        public void Activate(bool CA, bool Cold = false)
        {
            string MethodName = "Activate Heatsink";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio - In Hyperspace
                IResponse.Heatsink.NoHyperspace(CA);

                return;
            }
            #endregion

            #region Module Checks
            if (ICheck.Mothership.M.HeatSink(MethodName, true) == false)
            {
                //Audio - Not Installed.
                IResponse.Heatsink.NotInstalled
                    ((CA || Cold));                //Enable Audio For Cold Shield Cell Activation             

                return;
            }
            #endregion

            #region Activation
            IKeyboard.Press(IKey.Deploy_Heat_Sink, 0);

            //Audio - Activating
            IResponse.Heatsink.Activating(CA);
            #endregion
        }

        /// <summary>
        /// Checks game state, then activates the target Heatsink on the firegroup management system.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="I">(Item) The Target Item.</param>
        /// <param name="S">(Select Only) True will only select the module.</param>
        public void Target(bool CA, ConfigurationHardpoints.Item I, bool S = false)
        {
            string MethodName = "Sheild Cell (Target)";

            //Record Current Firegroup
            decimal Temp = IActions.Hardpoints.Current;         

            #region Vaildtion Checks
            //Check Space
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IResponse.Heatsink.NoHyperspace(CA);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroups.Config.Select(I))
            {
                case ConfigurationHardpoints.S.CurrentlySelected:

                    if (S) //Only When Selecting Module
                    {
                        //Audio - Currently Selected
                        IResponse.Heatsink.CurrentlySelected(CA);
                    }
                    break;

                case ConfigurationHardpoints.S.Selected:

                    if (S) //Only When Selecting Module
                    {
                        //Audio - Selected
                        IResponse.Heatsink.Selected(CA);
                    }
                    break;

                case ConfigurationHardpoints.S.NotAssigned:

                    //Audio - Not Assigned
                    IResponse.Heatsink.NotAssigned(CA);
                    return;

                case ConfigurationHardpoints.S.Failed:

                    //Audio - Selection Failed
                    IResponse.Heatsink.SelectionFailed(CA);
                    return;

                case ConfigurationHardpoints.S.InHyperspace:

                    //Audio - In Hyperspace
                    IResponse.Heatsink.NoHyperspace(CA);
                    return;

                default:

                    //No Action
                    return;
            }

            //Stop If Only Selecting Item.
            if (S) { return; }

            //Activate Module
            switch (ISettings.Firegroups.Config.Activate(I, 75, ref IStatus.False))
            {
                case ConfigurationHardpoints.A.Hyperspace:

                    //No Actions
                    return;

                case ConfigurationHardpoints.A.NotAssigned:

                    IResponse.Heatsink.NotAssigned(CA);
                    return;

                case ConfigurationHardpoints.A.Complete:

                    IResponse.Heatsink.Activating(CA);
                    break;

                default:

                    //No Actions
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            IActions.Hardpoints.Select(Temp, false);
        }
    }
}
