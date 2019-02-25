using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Status
{
    public class Status_Cargo
    {        
        public decimal Total { get; set; }

        public Responses Response = new Responses();

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
    }
}
