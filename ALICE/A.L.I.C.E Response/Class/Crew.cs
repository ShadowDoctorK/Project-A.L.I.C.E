using ALICE_Core;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public class Crew
    {
        string ClassName = "Response Crew";

        public void ActiveDuty(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, IStatus.Crew.Name + " Is Onboard And Ready For Duty", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(NPC_Crew.Active_Duty)
                .Token("[CREW MEMBER]", IStatus.Crew.Name),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void OnShoreLeave(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, IStatus.Crew.Name + " Is On Shore Leave", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(NPC_Crew.On_Shore_Leave)
                .Token("[CREW MEMBER]", IStatus.Crew.Name),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void Hire(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, IStatus.Crew.Name + " Has Been Added To Crew Manifest", Logger.Yellow); }

            Speech.Speak("[CREW MEMBER] Has Been Added To The Crew Manifest, And Granted Access To The Ship."
                .Token("[CREW MEMBER]", IStatus.Crew.Name),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void Fire(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, IStatus.Crew.Name + " Has Been Released From Service", Logger.Yellow); }

            Speech.Speak("[CREW MEMBER] Has Been Removed From The Crew Manifest, And Ship Access Revoked."
                .Token("[CREW MEMBER]", IStatus.Crew.Name),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
    }
}