using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {
        public static Orders Order = new Orders();        
    }

    public class Orders
    {
        string ClassName = "Response Orders";
        
        /// <summary>
        /// Audio used to report target order was already enabled.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void CurrentlyEnabled(string Item, bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, Item + ": Already Enabled", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(GN_Order_Updated.Currently_Enabled)
                .Token("[ITEM]", Item),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report target order was already disabled.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void CurrentlyDisabled(string Item, bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, Item + ": Already Disabled", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(GN_Order_Updated.Currently_Disabled)
                .Token("[ITEM]", Item),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report target order was already enabled.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Disabled(string Item, bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, Item + ": Disabled", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(GN_Order_Updated.Disabled)
                .Token("[ITEM]", Item),
                CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to report target order was already enabled.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public void Enabled(string Item, bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, Item + ": Enabled", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(GN_Order_Updated.Enabled)
                .Token("[ITEM]", Item),
                CA, V1, V2, V3, P, V);
        }
    }
}