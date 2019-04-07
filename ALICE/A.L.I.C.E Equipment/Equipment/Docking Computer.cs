using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Equipment
{
    public static partial class IEquipment
    {
        public static DockingComputer DockingComputer { get; set; } = new DockingComputer();
    }

    public class DockingComputer : Equipment_General
    {
        public bool AsisstedDockingReport { get; set; }     //Allows Tracking Docking Computer Report For Assisted Docking.

        public DockingComputer()
        {
            Settings.Equipment = IEquipment.E.Standard_Docking_Computer;
            Settings.Mode = IEquipment.M.Default;
            Settings.Installed = false;
            Settings.Enabled = true;

            //Custom Properites
            AsisstedDockingReport = true;
        }
    }
}