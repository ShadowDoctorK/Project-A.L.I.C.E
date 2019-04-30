using ALICE_Internal;
using ALICE_Status;
using ALICE_Synthesizer;
using System.Collections.Generic;

namespace ALICE_Response
{
    public static partial class IResponse
    {     
        public static Fuel Fuel = new Fuel();
    }

    public class Fuel
    {
        string ClassName = "Response Crew";

        /// <summary>
        /// Audio used to report fuel scooping ended.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void ScoopingEnd(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Scooping Complete. Reserves: " + IStatus.Fuel.GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Fuel_Report.Scoop_End)
                .Phrase(GN_Fuel_Report.Scoop_Collected, true)
                .Phrase(GN_Fuel_Report.Level_Percent, true)
                .Replace("[PERCENT]", IStatus.Fuel.PercentToString(2))
                .Replace("[FUELTONS]", IStatus.Fuel.ScoopingDiffToString(2)),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report fuel scooping started.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void ScoopingStart(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Scooping Commenced. Reserves: " + IStatus.Fuel.GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Fuel_Report.Scoop_Start),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report fuel level.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Level(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Fuel Level. Reserves: " + IStatus.Fuel.GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(Speech.Pick(new List<string>[] { GN_Fuel_Report.Level_Percent, GN_Fuel_Report.Level_Tons }))
                .Replace("[PERCENT]", IStatus.Fuel.PercentToString(2))
                .Replace("[FUELTONS]", IStatus.Fuel.TonsToString(2)),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report fuel critical.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Critical(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Fuel Critical. Reserves: " + IStatus.Fuel.GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Fuel_Report.Critical_Level)
                .Phrase(Speech.Pick(new List<string>[] { GN_Fuel_Report.Level_Percent, GN_Fuel_Report.Level_Tons }))
                .Token("[PERCENT]", decimal.Round(IStatus.Fuel.GetPercent(), 0).ToString())
                .Token("[FUELTONS]", decimal.Round(IStatus.Fuel.Main, 1).ToString()),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report fuel low.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Low(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Fuel Low. Reserves: " + IStatus.Fuel.GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Fuel_Report.Low_Level)
                .Phrase(Speech.Pick(new List<string>[] { GN_Fuel_Report.Level_Percent, GN_Fuel_Report.Level_Tons }))
                .Token("[PERCENT]", decimal.Round(IStatus.Fuel.GetPercent(), 0).ToString())
                .Token("[FUELTONS]", decimal.Round(IStatus.Fuel.Main, 1).ToString()),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report fuel below half capacity.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void HalfThreshold(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Fuel Half Capacity. Reserves: " + IStatus.Fuel.GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""                
                .Phrase(Speech.Pick(new List<string>[] { GN_Fuel_Report.Level_Percent, GN_Fuel_Report.Level_Tons }))
                .Token("[PERCENT]", decimal.Round(IStatus.Fuel.GetPercent(), 0).ToString())
                .Token("[FUELTONS]", decimal.Round(IStatus.Fuel.Main, 1).ToString()),
                CA, V1, V2, V3, P, V);
        }
    }
}