using ALICE_Debug;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {
        public static Full_Spectrum_Scanner FullSpectrumScanner = new Full_Spectrum_Scanner();
    }

    public class Full_Spectrum_Scanner : Generic_Equipment
    {
        /// <summary>
        /// Audio used to report the scan completion of a system.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void AllBodiesDiscovered(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EVT_FSSAllBodiesFound.Complete)
                .Phrase(EVT_FSSAllBodiesFound.Body_Report, true)
                .Token("[SYSTEMNAME]", IGet.FSSAllBodiesFound.SystemName(ClassName))
                .Token("[BODYCOUNT]", IGet.FSSAllBodiesFound.Count(ClassName)),
                CA, V1, V2, V3, P, V);
        }          
    }
}