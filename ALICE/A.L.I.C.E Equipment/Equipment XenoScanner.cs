using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Core;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Equipment
{
    public class Equipment_XenoScanner : Equipment_General
    {
        public Equipment_XenoScanner()
        {
            Settings.Equipment = IEquipment.E.Xeno_Scanner;
            Settings.Mode = IEquipment.M.Analysis;            
            Settings.Installed = false;
            Settings.Enabled = true;
        }

        public Equipment_XenoScanner New() { return new Equipment_XenoScanner(); }

        #region Audio
        
        #endregion
    }
}