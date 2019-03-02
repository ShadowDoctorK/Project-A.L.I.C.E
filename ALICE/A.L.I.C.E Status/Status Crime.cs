using ALICE_Debug;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Status
{
    public class Status_Crime
    {
        public Responses Response = new Responses();

        public class Responses
        {
            string MethodName = "Crime Status";

            public void Assault(string Victim, bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Assulted " + Victim, Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Crime.Assult)
                    .Token("[VICTIM]", Victim),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void FireInNoFireZone(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fire In No Fire Zone.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Crime.Fire_In_No_Fire_Zone)
                    .Phrase(Crime.Fine)
                    .Token("[AMOUNT]", ICheck.FireInNoFireZone.Amount(MethodName, true)),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Generic(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Crime Committed", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Crime.Default),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }
    }
}