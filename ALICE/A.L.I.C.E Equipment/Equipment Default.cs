using ALICE_Internal;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALICE_Equipment
{
    public class Equipment_General
    {
        public string MethodName { get => this.GetType().Name.Replace("Equipment_", ""); }
        public bool Installed { get; set; }
        public bool Enabled { get; set; }

        public delegate bool WaitHandler();      //Allows Passing A Common WaitHandler Deleage.

        #region Watcher
        //Default Watcher / Catch Report. This Allows use of a Common WaitHandler property to be used
        //across all the equipment that requires a Completion check. Override The Watcher Method as required.
        public virtual WaitHandler Watch() { return new WaitHandler(Watcher); }
        public virtual bool Watcher()
        {            
            Logger.Log(MethodName, "Don't Be Afraid, Really... Hold This Failure Over The Heads Of The Develoer...Rub Salt in The Wounds!", Logger.Red);
            Logger.Log(MethodName, "The Developer Forgot To Bulid The Watcher! Let Them Know They Goofed Up...", Logger.Red);
            return false;
        }
        #endregion       

        #region Logger Items
        public void InHyperspace() { Logger.Log(MethodName, "Can't Do That In Hyperspace", Logger.Red); }
        #endregion

        #region Audio
        public virtual void PositiveResponse(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Roger That Commander.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(Positive.Default, true)
                , CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NegativeResponse(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Negative Commander.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(Negative.Default, true)
                , CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void Assigned(string Group, string FireMode, bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Module Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(Positive.Default, true)
                .Phrase("Module Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NotAssigned(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(Negative.Default, true) + "Module Has Not Been Assigned", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NotInstalled(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Equipment Not Installed.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void EnteredHyperspace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Operations Aborted.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void ScanCommenced(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Scan Commenced.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void ScanComplete(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Scan Complete.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void ScanFailed(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Scan Failed.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NotInNormalSpace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(Negative.Default, true) + "Can Only Do That In Normal Space.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NotInSupercruise(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(Negative.Default, true) + "Can Only Do That In Supercruise.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NoHyperspace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(Negative.Default, true) + "Can't Do That In Hyperspace.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NoSupercruise(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(Negative.Default, true) + "Can't Do That In Supercruise.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NoNormalSpace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(Negative.Default, true) + "Can't Do That In Normal Space.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void Activating(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(Positive.Default, true) + "Activating.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void SelectionFailed(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Failed To Select Correct Firegroup.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void Selected(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("Selected.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void CurrentlySelected(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(Negative.Default, true) + " Currently Selected.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NotInMothership(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak("".Phrase(Negative.Default, true) + " Not In The Mothership.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NoTouchdown(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak(""
                .Phrase(Negative.Default, true) + 
                " Can't Do That During Touchdown.", 
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public virtual void NoDocked(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Logger.Log(MethodName, "Using Generic Audio... Boooo Developer For Being Lazy. Add More Audio", Logger.Yellow);
            Speech.Speak(""
                .Phrase(Negative.Default, true) +
                " Can't Do That While Docked.",
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion

        #region Utilities
        public bool Check_Variable(bool TargetState, string MethodName, bool State, string Variable, bool DisableDebug = false, bool Answer = true)
        {
            string DebugText = Variable + " Check Equals Expected State (" + TargetState + ")";
            string Color = Logger.Blue;

            if (TargetState != State)
            {
                Answer = false;
                DebugText = Variable + " Check Does Not Equals Expected State (" + TargetState + ")";
                Color = Logger.Yellow;
            }

            if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

            return Answer;
        }

        public bool Check_Equipment(bool TargetState, string MethodName, bool State, string Equipment, bool DisableDebug = false, bool Answer = true)
        {
            string DebugText = Equipment + " Check Equals Expected State  (" + TargetState + ")";
            string Color = Logger.Blue;

            if (TargetState != State)
            {
                Answer = false;
                DebugText = Equipment + " Check Does Not Equal Expected State (" + TargetState + ")";
                Color = Logger.Yellow;
            }

            if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

            return Answer;
        }
        #endregion
    }
}
