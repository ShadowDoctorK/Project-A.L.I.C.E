using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {
        public static Panels Panels = new Panels();        
    }

    public class Panels
    {
        string ClassName = "Response Panels";

        public void QuestionFilters(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Question: Are There Any Active Filters?", Logger.Yellow); }

            Speech.Speak(""
               .Phrase("Are There Any Active Filters?"),
               CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
    }
}