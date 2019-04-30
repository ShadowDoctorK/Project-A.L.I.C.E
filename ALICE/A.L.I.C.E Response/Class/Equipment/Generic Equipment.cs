using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {
        public static Generic_Equipment GenericEquipment = new Generic_Equipment();
    }

    public class Generic_Equipment
    {
        public string ClassName { get => this.GetType().Name.Replace("_", " "); }

        public void BadDev()
        {
            Logger.Log(ClassName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
        }

        /// <summary>
        /// Audio used to give a postive response.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void PositiveResponse(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Roger That Commander.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                , CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// Audio used to give a negative response.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void NegativeResponse(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Negative Commander.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                , CA, V1, V2, V3, P, V);
        }

        /// <summary>
        /// (Generic) Audio used to report the position a module is assigned on the firegroup management system.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void Assigned(string Group, string FireMode, bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {            
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Module Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase("Module Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CA, V1, V2, V3, P, V);

            BadDev();
        }

        /// <summary>
        /// (Generic) Audio used to report a module is not assigned to the firegroup management system.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void NotAssigned(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Module Has Not Been Assigned", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report equipment is not installed.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void NotInstalled(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("Equipment Not Installed.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report entering hyperspace.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void EnteredHyperspace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("Entered Hyperspace, Operations Aborted.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report commencing a scan.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void ScanCommenced(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("Scan Commenced.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report completing a scan.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void ScanComplete(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("Scan Complete.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report a scan failed.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void ScanFailed(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("Scan Failed.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report operation can not be completed because user is not in normal space.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void NotInNormalSpace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can Only Do That In Normal Space.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report operations can no be completed because user is not in supercruise.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void NotInSupercruise(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can Only Do That In Supercruise.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report operations can not be completed because user is in hyperspace.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void NoHyperspace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can't Do That In Hyperspace.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report operations can not be completed because user is in supercruise.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void NoSupercruise(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can't Do That In Supercruise.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report operations can no be completed because user is in normal space.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void NoNormalSpace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can't Do That In Normal Space.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report activation.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void Activating(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Positive.Default, true) + ". Activating.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report failing to select the correct firegroup.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void SelectionFailed(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("Failed To Select Correct Firegroup.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report firegroup was selected.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void Selected(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("Selected.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report the target firegroup is currently selected.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void CurrentlySelected(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + " Currently Selected.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report user is not in the mothership.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void NotInMothership(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + " Not In The Mothership.", CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report user can not do the action due to being touched down.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void NoTouchdown(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(GN_Negative.Default, true) +
                " Can't Do That During Touchdown.",
                CA, V1, V2, V3, P, V);

            BadDev(); 
        }

        /// <summary>
        /// (Generic) Audio used to report user can not do the action due to being docked.
        /// </summary>
        /// <param name="CA">(Command Audio) Allows enabling or disabling audio on the command level.</param>
        /// <param name="V1">(Variable 1) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V2">(Variable 2) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="V3">(Variable 3) Additional variable provided to resolve complex logic to enable or disable audio.</param>
        /// <param name="P">(Priority) Set priority level to jump the queue for lower priority items.</param>
        /// <param name="V">(Voice) Pass a valid installed voice to override the default settings.</param>
        public virtual void NoDocked(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(GN_Negative.Default, true) +
                " Can't Do That While Docked.",
                CA, V1, V2, V3, P, V);

            BadDev(); 
        }
    }
}
