using ALICE_Debug;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Response;

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
            if (Check.Equipment.HeatSinkLauncher(true, MethodName) == false)
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
    }
}
