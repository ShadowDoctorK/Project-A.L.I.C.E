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
    public class Equipment_ExternalLights : Equipment_General
    {
        public Equipment_ExternalLights()
        {
            Installed = true;
            Enabled = true;
        }

        public Equipment_ExternalLights New() { return new Equipment_ExternalLights(); }

        #region Audio
        public override void NoHyperspace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Response("".Speak(Negative.Default, true).Speak(EQ_External_Lights.No_Hyperspace), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void Energizing(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Response("".Speak(Positive.Default, true).Speak(EQ_External_Lights.Energizing), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void Deenergizing(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Response("".Speak(Positive.Default, true).Speak(EQ_External_Lights.Deenergizing), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void CurrentlyDeenergized(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Response("".Speak(Negative.Default, true).Speak(EQ_External_Lights.Currently_Deenergized), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void CurrentlyEnergized(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Response("".Speak(Negative.Default, true).Speak(EQ_External_Lights.Currently_Energized), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion
    }
}