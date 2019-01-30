using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Core;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;

namespace ALICE_Equipment
{
    public class Equipment_ShutdownFieldNeutraliser : Equipment_General
    {
        public Equipment_ShutdownFieldNeutraliser()
        {
            Settings.Equipment = IEquipment.E.Shutdown_Field_Neutraliser;
            Settings.Mode = IEquipment.M.Both;
            Settings.Installed = false;
            Settings.Enabled = true;
        }

        public Equipment_ShutdownFieldNeutraliser New() { return new Equipment_ShutdownFieldNeutraliser(); }

        #region Audio

        #endregion
    }
}