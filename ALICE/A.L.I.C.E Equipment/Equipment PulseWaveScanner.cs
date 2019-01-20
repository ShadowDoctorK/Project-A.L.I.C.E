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
    public class Equipment_PulseWaveScanner : Equipment_General
    {
        public Equipment_PulseWaveScanner()
        {
            Installed = false;
            Enabled = true;
        }

        public Equipment_PulseWaveScanner New() { return new Equipment_PulseWaveScanner(); }

        #region Audio
        
        #endregion
    }
}