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
    public class Equipment_WakeScanner : Equipment_General
    {
        public Equipment_WakeScanner()
        {
            Settings.Equipment = IEquipment.E.Frame_Shift_Wake_Scanner;
            Settings.Mode = IEquipment.M.Analysis;
            Settings.Installed = false;
            Settings.Enabled = true;
        }

        #region Audio

        #endregion
    }
}