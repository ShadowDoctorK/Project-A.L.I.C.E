﻿using System;
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
    public class Equipment_LimpetFuel : Equipment_General
    {
        public Equipment_LimpetFuel()
        {
            Settings.Equipment = IEquipment.E.Fuel_Transfer_Limpet_Controller;
            Settings.Mode = IEquipment.M.Analysis;
            Settings.Installed = false;
            Settings.Enabled = true;
            Settings.Total = -1;
            Settings.Capacity = -1;
        }

        public Equipment_LimpetFuel New() { return new Equipment_LimpetFuel(); }

        #region Audio
        public override void NotInstalled(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fuel Limpet Controller Not Installed.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase("Fuel Limpet Controller Not Installed."),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void Assigned(string Group, string FireMode, bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fuel Limpet Controller Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase("Fuel Limpet Controller Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion
    }
}