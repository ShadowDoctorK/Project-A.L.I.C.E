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
    public class Equipment_FighterHanger : Equipment_General
    {        
        public Equipment_FighterHanger()
        {
            Settings.Equipment = IEquipment.E.Fighter_Hangar;
            Settings.Mode = IEquipment.M.Default;
            Settings.Installed = false;
            Settings.Enabled = true;
            Settings.Total = -1;
            Settings.Capacity = -1;
        }

        public Equipment_FighterHanger New() { return new Equipment_FighterHanger(); }

        #region Audio
        
        #endregion
    }
}