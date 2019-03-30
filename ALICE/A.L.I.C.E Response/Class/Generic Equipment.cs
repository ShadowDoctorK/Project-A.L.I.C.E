using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public class Generic_Equipment
    {
        public string ClassName { get => this.GetType().Name.Replace("_", " "); }

        public void BadDev()
        {
            Logger.Log(ClassName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
        }

        public virtual void PositiveResponse(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Roger That Commander.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                , CA, V1, V2, V3, Priority, V);
        }

        public virtual void NegativeResponse(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Negative Commander.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                , CA, V1, V2, V3, Priority, V);
        }

        public virtual void Assigned(string Group, string FireMode, bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {            
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Module Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase("Module Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CA, V1, V2, V3, Priority, V);

            BadDev();
        }

        public virtual void NotAssigned(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Module Has Not Been Assigned", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void NotInstalled(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("Equipment Not Installed.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void EnteredHyperspace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("Operations Aborted.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void ScanCommenced(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("Scan Commenced.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void ScanComplete(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("Scan Complete.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void ScanFailed(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("Scan Failed.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void NotInNormalSpace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can Only Do That In Normal Space.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void NotInSupercruise(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can Only Do That In Supercruise.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void NoHyperspace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can't Do That In Hyperspace.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void NoSupercruise(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can't Do That In Supercruise.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void NoNormalSpace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + "Can't Do That In Normal Space.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void Activating(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Positive.Default, true) + ". Activating.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void SelectionFailed(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("Failed To Select Correct Firegroup.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void Selected(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("Selected.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void CurrentlySelected(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + " Currently Selected.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void NotInMothership(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true) + " Not In The Mothership.", CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void NoTouchdown(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(GN_Negative.Default, true) +
                " Can't Do That During Touchdown.",
                CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }

        public virtual void NoDocked(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int Priority = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(GN_Negative.Default, true) +
                " Can't Do That While Docked.",
                CA, V1, V2, V3, Priority, V);

            BadDev(); 
        }
    }
}
