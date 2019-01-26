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
        public decimal Bays { get; set; }
        public decimal BayCapacity { get; set; }

        public Equipment_FighterHanger()
        {
            Installed = false;
            Enabled = true;
            Bays = -1;
            BayCapacity = -1;
        }

        public Equipment_FighterHanger New() { return new Equipment_FighterHanger(); }

        #region Audio
        
        #endregion
    }
}