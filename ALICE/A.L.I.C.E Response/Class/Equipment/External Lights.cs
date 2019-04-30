using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {
        public static Lights Lights = new Lights();
    }

    public class Lights : Generic_Equipment
    {
        public override void NoHyperspace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "External Lights: Can't Do That In Hyperspace.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_External_Lights.No_Hyperspace),
                CA, V1, V2, V3, P, V);
        }

        public void Energizing(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "External Lights: Energizing.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_External_Lights.Energizing),
                CA, V1, V2, V3, P, V);
        }

        public void Deenergizing(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "External Lights: Deenergizing.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_External_Lights.Deenergizing),
                CA, V1, V2, V3, P, V);
        }

        public void Energized(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "External Lights: Already Energized.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_External_Lights.Currently_Energized),
                CA, V1, V2, V3, P, V);
        }

        public void Deenergized(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "External Lights: Already Deenergized.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_External_Lights.Currently_Deenergized),
                CA, V1, V2, V3, P, V);
        }
    }
}