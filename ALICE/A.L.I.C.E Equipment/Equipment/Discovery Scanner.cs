using System.Threading;
using ALICE_Actions;
using ALICE_Debug;

namespace ALICE_Equipment
{
    public static partial class IEquipment
    {
        public static DiscoveryScanner DiscoveryScanner { get; set; } = new DiscoveryScanner();
    }

    public class DiscoveryScanner : Equipment_General
    {
        public bool Active = false;           //Allows Tracking The Status Of Active Scans.
        public bool FirstScan = true;         //Allows Tracking The First Scan In System.
        public bool Mode { get; set; }

        public DiscoveryScanner()
        {
            Settings.Equipment = IEquipment.E.Discovery_Scanner;
            Settings.Mode = IEquipment.M.Analysis;
            Settings.Installed = true;
            Settings.Enabled = true;
        }

        public void Scan()
        {
            //Check Plugin Initialized
            if (ICheck.Initialized(MethodName) == false) { return; }

            if (ICheck.Order.AssistSystemScan(MethodName, true, true))
            {
                Thread DisScan = new Thread((ThreadStart)(() => 
                {
                    IActions.DiscoveryScanner(true, true);
                }));
                DisScan.IsBackground = true;
                DisScan.Start();
            }
        }

        #region Watcher
        //Sets "Active" to true when constructed. Then watches the variable for 2 seconds when Invoked.
        public override WaitHandler Watch() { Active = true; return new WaitHandler(Watcher); }
        public override bool Watcher()
        {
            decimal Count = 2000 / 50; while (Active)
            {
                Count--; if (Count <= 0)
                {
                    Active = false; return false;
                }
                Thread.Sleep(50);
            }

            return true;
        }
        #endregion
    }
}