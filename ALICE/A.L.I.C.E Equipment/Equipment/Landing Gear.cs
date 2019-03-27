using ALICE_Core;

namespace ALICE_Equipment
{
    public class LandingGear : Equipment_General
    {
        public bool Status = false;    //Status.Json Property

        public LandingGear()
        {
            Settings.Equipment = IEquipment.E.Default;
            Settings.Mode = IEquipment.M.Default;            
            Settings.Installed = true;
            Settings.Enabled = true;            
        }

        #region Audio

        #endregion
    }
}