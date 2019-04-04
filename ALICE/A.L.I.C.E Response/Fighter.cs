using ALICE_Core;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {     
        public static Fighter Fighter = new Fighter();
    }

    public class Fighter
    {
        string ClassName = "Response Crew";

        /// <summary>
        /// Audio used to report unable to launch fighter because player is not in normal space.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void NotNormalSpace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Unable To Deploy Fighter: Not In Normal Space.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Fighter.Not_Normal_Space),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report unable to launch fighter because player is not in the mothership.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void NotInMothership(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Unable To Deploy Fighter: Not In The Mothership.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Fighter.Not_Mothership),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report unable to launch fighter because mothership is docked.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void MothershipDocked(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Unable To Deploy Fighter: Ship Is Docked.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Fighter.Mothership_Docked),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report unable to launch fighter because mothership is touched down.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void MothershipTouchdown(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Unable To Deploy Fighter: Ship Is Touched Down.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Fighter.Touchdown),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report unable to launch fighter because player is inside the no fire zone.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void InNoFireZone(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Unable To Deploy Fighter: Inside No Fire Zone.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Fighter.No_Fire_Zone),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report unable to launch fighter because altitude is too low.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void LowAltitude(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Unable To Deploy Fighter: Low Altitude.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Fighter.Altitude),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report unable to launch fighter because none are installed.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void NoFighter(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Unable To Deploy Fighter: Not Installed.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Fighter.No_Fighter_Hanger),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report unable to launch fighter because the hanger called does not exist.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void NoHanger(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Unable To Deploy Fighter: Hanger Not Installed.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Fighter.Hanger_Total),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report launched a crew controlled fighter.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void LaunchedCrew(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Launchd Fighter (Crew)", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Fighter.Launch),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report launched a player controlled fighter.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void LaunchedPlayer(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Launchd Fighter (Player)", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Fighter.Launch)
                .Phrase(EQ_Fighter.Launch_Player_Modifer),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report fighter launch was no detected after command execution.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void LaunchError(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Fighter Failed To Deploy", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Fighter.Launch_Error),
                CA, V1, V2, V3, P, V);
        }
    }
}