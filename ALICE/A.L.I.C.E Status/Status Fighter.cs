using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Status
{
    public class Status_Fighter
    {
        //No Tracked Properties

        public Responses Response = new Responses();
        public Checks Check = new Checks();
        public Logging Log = new Logging();

        public void Update(DockFighter Event)
        {

        }

        public class Responses
        {
            string MethodName = "Fighter Status";

            public void Docked(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fighter Docked.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EQ_Fighter.Docked)
                    .Phrase(EQ_Fighter.Docked_Modifier, true),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }

        public class Checks
        {

        }

        public class Logging
        {

        }
    }
}