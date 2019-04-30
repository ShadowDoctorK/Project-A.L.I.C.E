using ALICE_Debug;
using ALICE_Internal;
using ALICE_Response;
using ALICE_Settings;
using System.Threading;

namespace ALICE_Actions
{
    public static partial class IActions
    {
        public static DiscoveryScanner DiscoveryScanner { get; set; } = new DiscoveryScanner();
    }

    public class DiscoveryScanner
    {
        public bool Active = false;           //Allows Tracking The Status Of Active Scans.
        public bool FirstScan = true;         //Allows Tracking The First Scan In System.
        public bool Mode { get; set; }

        public void Operate(bool CommandAudio, bool Sleep = false, bool SelectOnly = false)
        {
            string MethodName = "Discovery Scan";

            //Record Current Firegroup
            decimal Temp = IActions.Hardpoints.Current;

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

            ConfigurationHardpoints.Assignemnt Module = ISettings.Firegroups.Config.GetAssignemnt(ConfigurationHardpoints.Item.ScannerDiscovery);

            //Select Firegroup
            switch (ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.ScannerDiscovery))
            {
                case ConfigurationHardpoints.S.CurrentlySelected:
                    if (SelectOnly) { IResponse.DiscoveryScanner.CurrentlySelected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.Selected:
                    if (SelectOnly) { IResponse.DiscoveryScanner.Selected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.NotAssigned:
                    IResponse.DiscoveryScanner.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.Failed:
                    IResponse.DiscoveryScanner.SelectionFailed(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.InHyperspace:
                    IResponse.DiscoveryScanner.NoHyperspace(CommandAudio);
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
                IResponse.DiscoveryScanner.ScanCommenced(CommandAudio);
            }

            //Track Completion
            Active = true;

            //Acivate Module && Watch Return           
            switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.ScannerDiscovery, 8000, ref Active, 2000))
            {
                case ConfigurationHardpoints.A.Hyperspace:
                    IResponse.DiscoveryScanner.EnteredHyperspace(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.NotAssigned:
                    IResponse.DiscoveryScanner.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.Complete:
                    //Audio Removed, Not Required.
                    break;
                case ConfigurationHardpoints.A.Fail:
                    IResponse.DiscoveryScanner.ScanFailed(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            IActions.Hardpoints.Select(Temp, false);
        }

        public void Scan()
        {
            string MethodName = "Discovery Scan";

            //Check Plugin Initialized
            if (ICheck.Initialized(MethodName) == false) { return; }

            if (ICheck.Order.AssistSystemScan(MethodName, true, true))
            {
                Thread DisScan = new Thread((ThreadStart)(() =>
                {
                    Operate(true, true);
                }));
                DisScan.IsBackground = true;
                DisScan.Start();
            }
        }
    }
}
