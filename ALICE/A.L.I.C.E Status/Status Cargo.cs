using ALICE_Actions;
using ALICE_Core;
using ALICE_Events;
using ALICE_Interface;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALICE_Status
{
    public class Status_Cargo
    {
        
        public decimal Total { get; set; }




        public Responses Response = new Responses();
        public Checks Check = new Checks();
        public Logging Log = new Logging();

        public void Update()
        {
           
        }

        public class Responses
        {
            string MethodName = "Cargo Status";

            public void Refined(string Item, bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Collected: " + Item, Logger.Yellow); }

                Speech.Speak(Item + "Refined.",
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
