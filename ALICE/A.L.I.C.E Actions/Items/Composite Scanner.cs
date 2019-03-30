using ALICE_Debug;
using ALICE_Equipment;
using ALICE_Internal;
using ALICE_Settings;

namespace ALICE_Actions
{
    public static partial class IActions
    {
        public static void CompositeScaner(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Composite Scan";

            //Record Current Firegroup
            decimal Temp = Call.Firegroup.Current;

            #region Vaildtion Checks           
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IEquipment.CompositeScanner.NoHyperspace(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            Settings_Firegroups.Assignemnt Module = ISettings.Firegroup.GetAssignemnt(Settings_Firegroups.Item.ScannerComposite);

            //Select Firegroup
            switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerComposite))
            {
                case Settings_Firegroups.S.CurrentlySelected:
                    if (SelectOnly) { IEquipment.CompositeScanner.CurrentlySelected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.Selected:
                    if (SelectOnly) { IEquipment.CompositeScanner.Selected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.CompositeScanner.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    IEquipment.CompositeScanner.SelectionFailed(CommandAudio);
                    return;
                case Settings_Firegroups.S.InHyperspace:
                    IEquipment.General.InHyperspace();
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Commenced Audio
            if (Module.FireGroup != Settings_Firegroups.Group.None &&
                Module.FireMode != Settings_Firegroups.Fire.None)
            {
                IEquipment.CompositeScanner.ScanCommenced(CommandAudio);
            }

            //Acivate Module
            switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.ScannerComposite, 8000))
            {
                case Settings_Firegroups.A.Hyperspace:
                    IEquipment.CompositeScanner.EnteredHyperspace(CommandAudio);
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.CompositeScanner.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:
                    IEquipment.CompositeScanner.ScanComplete(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            Call.Firegroup.Select(Temp, false);
        }
    }
}
