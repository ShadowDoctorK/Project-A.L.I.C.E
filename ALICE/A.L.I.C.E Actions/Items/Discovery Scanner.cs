using ALICE_Debug;
using ALICE_Equipment;
using ALICE_Internal;
using ALICE_Settings;
using System.Threading;

namespace ALICE_Actions
{
    public static partial class IActions
    {
        public static void DiscoveryScanner(bool CommandAudio, bool Sleep = false, bool SelectOnly = false)
        {
            string MethodName = "Discovery Scan";

            //Record Current Firegroup
            decimal Temp = Call.Firegroup.Current;

            #region Vaildtion Checks
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio
                return;
            }
            #endregion

            #region Fire Group Management
            //Sleep Is Used After The FSDJump Event To Allow Game Time To Respond After Loading The New System
            if (Sleep == true) { Thread.Sleep(3000); }

            Settings_Firegroups.Assignemnt Module = ISettings.Firegroup.GetAssignemnt(Settings_Firegroups.Item.ScannerDiscovery);

            //Select Firegroup
            switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerDiscovery))
            {
                case Settings_Firegroups.S.CurrentlySelected:
                    if (SelectOnly) { IEquipment.DiscoveryScanner.CurrentlySelected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.Selected:
                    if (SelectOnly) { IEquipment.DiscoveryScanner.Selected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.DiscoveryScanner.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    IEquipment.DiscoveryScanner.SelectionFailed(CommandAudio);
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
                IEquipment.DiscoveryScanner.ScanCommenced(CommandAudio);
            }

            //Acivate Module && Watch Return
            switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.ScannerDiscovery,
                8000, true, IEquipment.DiscoveryScanner.Watcher))
            {
                case Settings_Firegroups.A.Hyperspace:
                    IEquipment.DiscoveryScanner.EnteredHyperspace(CommandAudio);
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.DiscoveryScanner.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:
                    //Audio Removed, Not Required.
                    break;
                case Settings_Firegroups.A.Fail:
                    IEquipment.DiscoveryScanner.ScanFailed(CommandAudio);
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
