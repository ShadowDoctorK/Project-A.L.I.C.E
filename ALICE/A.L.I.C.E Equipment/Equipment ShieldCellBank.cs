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

        public Equipment_ShieldCellBank New() { return new Equipment_ShieldCellBank(); }

        #region Audio
        public override void NotInstalled(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Shield Cell Bank Not Installed.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase("Shield Cell Bank Not Installed."),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void Assigned(string Group, string FireMode, bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Shield Cell Bank Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase("Shield Cell Bank Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void Activating(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Speak("".Phrase(GN_Positive.Default, true).Phrase(EQ_Shield_Cell.Activating), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void NoHyperspace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Speak("".Phrase(GN_Positive.Default, true).Phrase(EQ_Shield_Cell.Hyperspace), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion
    }
}