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

            public void Assult(string Victim, bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Assulted " + Victim, Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(Crime.Assult)
                    .Token("[VICTIM]", Victim),
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
