using ALICE_Internal;
using ALICE_Status;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {     
        public static Crew Crew = new Crew();
    }

    public class Crew
    {
        string ClassName = "Response Crew";

        /// <summary>
        /// Audio used to report crew member is on active duty.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void ActiveDuty(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, IStatus.Crew.Name + " Is Onboard And Ready For Duty", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(NPC_Crew.Active_Duty)
                .Token("[CREW MEMBER]", IStatus.Crew.Name),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report crew memeber is on shore.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void OnShoreLeave(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, IStatus.Crew.Name + " Is On Shore Leave", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(NPC_Crew.On_Shore_Leave)
                .Token("[CREW MEMBER]", IStatus.Crew.Name),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report a crew member was hired.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Hire(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, IStatus.Crew.Name + " Has Been Added To Crew Manifest", Logger.Yellow); }

            Speech.Speak("[CREW MEMBER] Has Been Added To The Crew Manifest, And Granted Access To The Ship."
                .Token("[CREW MEMBER]", IStatus.Crew.Name),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report a crew member was fired.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Fire(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, IStatus.Crew.Name + " Has Been Released From Service", Logger.Yellow); }

            Speech.Speak("[CREW MEMBER] Has Been Removed From The Crew Manifest, And Ship Access Revoked."
                .Token("[CREW MEMBER]", IStatus.Crew.Name),
                CA, V1, V2, V3, P, V);
        }
    }
}