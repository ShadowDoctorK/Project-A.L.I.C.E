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
    public class Equipment_CompositeScanner : Equipment_General
    {
        public Equipment_CompositeScanner()
        {
            Installed = true;
            Enabled = true;
        }

        public Equipment_CompositeScanner New() { return new Equipment_CompositeScanner(); }

        #region Audio
        public override void Assigned(string Group, string FireMode, bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Composite Scanner Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Response(""
                .Speak(Positive.Default, true)
                .Speak("Composite Scanner Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion
    }
}