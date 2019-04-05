using ALICE_Core;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {
        public static Bounty Bounty = new Bounty();        
    }

    public class Bounty
    {
        string ClassName = "Response Bounty";

        public void Collected(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Collected: " + IStatus.Bounty.Reward, Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EVT_Bounty.Collected)
                .Token("[NUM]", IStatus.Bounty.Reward)
                .Token("[SHIPTYPE]", IStatus.Bounty.Victim)
                .Token("[PILOTNAME]", IStatus.Bounty.Pilot),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
    }
}