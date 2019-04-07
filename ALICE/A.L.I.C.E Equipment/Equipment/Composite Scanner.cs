namespace ALICE_Equipment
{
    public static partial class IEquipment
    {
        public static CompositeScanner CompositeScanner { get; set; } = new CompositeScanner();
    }

    public class CompositeScanner : Equipment_General
    {
        public CompositeScanner()
        {
            Settings.Equipment = IEquipment.E.Composite_Scanner;
            Settings.Mode = IEquipment.M.Analysis;
            Settings.Installed = true;
            Settings.Enabled = true;            
        }
    }
}