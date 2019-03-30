namespace ALICE_Equipment
{
    public class Equipment_CompositeScanner : Equipment_General
    {
        public Equipment_CompositeScanner()
        {
            Settings.Equipment = IEquipment.E.Composite_Scanner;
            Settings.Mode = IEquipment.M.Analysis;
            Settings.Installed = true;
            Settings.Enabled = true;            
        }
    }
}