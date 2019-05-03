using ALICE_Debug;
using ALICE_Internal;
using ALICE_Response;
using ALICE_Settings;
using ALICE_Status;

namespace ALICE_Actions
{
    public static partial class IActions
    {
        public static void CompositeScaner(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Composite Scan";

            //Record Current Firegroup
            decimal Temp = IActions.Hardpoints.Current;

            #region Vaildtion Checks           
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IResponse.CompositeScanner.NoHyperspace(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            ConfigurationHardpoints.Assignemnt Module = ISettings.Firegroups.Config.GetAssignemnt(ConfigurationHardpoints.Item.ScannerComposite);

            //Select Firegroup
            switch (ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.ScannerComposite))
            {
                case ConfigurationHardpoints.S.CurrentlySelected:
                    if (SelectOnly) { IResponse.CompositeScanner.CurrentlySelected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.Selected:
                    if (SelectOnly) { IResponse.CompositeScanner.Selected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.NotAssigned:
                    IResponse.CompositeScanner.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.Failed:
                    IResponse.CompositeScanner.SelectionFailed(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.InHyperspace:
                    IResponse.CompositeScanner.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Commenced Audio
            if (Module.FireGroup != ConfigurationHardpoints.Group.None &&
                Module.FireMode != ConfigurationHardpoints.Fire.None)
            {
                IResponse.CompositeScanner.ScanCommenced(CommandAudio);
            }

            //Acivate Module
            switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.ScannerComposite, 8000, ref IStatus.False))
            {
                case ConfigurationHardpoints.A.Hyperspace:
                    IResponse.CompositeScanner.EnteredHyperspace(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.NotAssigned:
                    IResponse.CompositeScanner.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.Complete:
                    IResponse.CompositeScanner.ScanComplete(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            IActions.Hardpoints.Select(Temp, false);
        }
    }
}
