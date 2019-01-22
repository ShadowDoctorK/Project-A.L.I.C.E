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
    public class Equipment_LimpetProspector : Equipment_General
    {
        public Equipment_LimpetProspector()
        {
            Installed = false;
            Enabled = true;
        }

        public Equipment_LimpetProspector New() { return new Equipment_LimpetProspector(); }

        #region Audio
        public override void NotInstalled(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Prospector Limpet Controller Not Installed.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(Negative.Default, true)
                .Phrase("Prospector Limpet Controller Not Installed."),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void Assigned(string Group, string FireMode, bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Prospector Limpet Controller Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(Positive.Default, true)
                .Phrase("Prospector Limpet Controller Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion
    }
}