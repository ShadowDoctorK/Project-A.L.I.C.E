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
    public class Status_Messages
    {
        public Responses Response = new Responses();

        public void Update(ReceiveText Event)
        {
            //No Logic
        }

        public void Update(SendText Event)
        {
            //No Logic
        }     

        public class Responses
        {
            string MethodName = "Messages Status";

            public void StationDamaged(string Station, bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Warning! Damaged " + Station, Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Station_Reports.Damaged)
                    .Token("[STATON]", Station),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void StationHostile(string Station, bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Attention! " + Station + " Is Hostile.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Station_Reports.Hostile)
                    .Token("[STATON]", Station),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }
    }
}
