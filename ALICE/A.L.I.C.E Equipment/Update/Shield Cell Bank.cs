namespace ALICE_Equipment
{
    public class Equipment_ShieldCellBank : Equipment_General
    {
        public Equipment_ShieldCellBank()
        {
            Settings.Equipment = IEquipment.E.Shield_Cell_Bank;
            Settings.Mode = IEquipment.M.Both;
            Settings.Installed = false;
            Settings.Enabled = true;
            Settings.Total = -1;
            Settings.Capacity = -1;
        }      
    }
}