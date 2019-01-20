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
    public class Equipment_SurfaceScanner : Equipment_General
    {
        public bool Mode { get; set; }

        public Equipment_SurfaceScanner()
        {
            Mode = false;
            Installed = false;
            Enabled = true;
        }

        public Equipment_SurfaceScanner New() { return new Equipment_SurfaceScanner(); }

        #region Audio
        public override void NotInstalled(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Surface Scanner Not Installed.", Logger.Yellow); }

            Speech.Response(""
                .Speak(Negative.Default, true)
                .Speak("Surface Scanner Not Installed."),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void Assigned(string Group, string FireMode, bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Surface Scanner Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Response(""
                .Speak(Positive.Default, true)
                .Speak("Surface Scanner Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion
    }
}