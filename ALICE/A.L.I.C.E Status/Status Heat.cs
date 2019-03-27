using ALICE_Debug;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Status
{
    public class Status_Heat
    {
        private readonly string MethodName = "Heat Status";

        public Responses Response = new Responses();

        public void Update(HeatDamage Event)
        {
            Response.Damage(
                ICheck.Initialized(MethodName));    //Check Plugin Initialized
        }

        public void Update(HeatWarning Event)
        {
            Response.Warning(
                ICheck.Initialized(MethodName));    //Check Plugin Initialized
        }

        public class Responses
        {
            string MethodName = "Heat Status";

            public void Damage(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Taking Heat Damage!", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EVT_HeatDamage.Default),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Warning(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Warning! Temprature Critical!", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EVT_HeatWarning.Default)
                    .Phrase(EVT_HeatWarning.Modifier, true),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }
    }
}
