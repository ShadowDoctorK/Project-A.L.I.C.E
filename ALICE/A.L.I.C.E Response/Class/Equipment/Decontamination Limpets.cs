using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {
        public static Decontamination_Limpets DecontaminationLimpets = new Decontamination_Limpets();
    }

    public class Decontamination_Limpets : Generic_Equipment
    {
        /// <summary>
        /// Audio used to report the position a module is assigned on the firegroup management system.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public override void Assigned(string Group, string FireMode, bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Decontamination Limpet Controller Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase("Decontamination Limpet Controller Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report Equipment is not installed.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public override void NotInstalled(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Decontamination Limpet Controller Not Installed.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase("Decontamination Limpet Controller Not Installed."),
                CA, V1, V2, V3, P, V);
        }
    }
}