using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Status
{
    public class Status_Fighter
    {
        /* Data Sources
         * 1. DockFighter Event
         * 2. FighterDestroyed Event
         * 3. FighterRebuilt Event
         * 4. LaunchFighter Event
         */

        //Enum To Track Fighter Status
        public enum S { Default, Ready, Docked, Destroyed, Deployed }

        public S Status { get; set; }
        public bool Deployed { get; set; }
        public bool WaitLaunch { get; set; }

        public Status_Fighter()
        {
            Status = S.Default;
            Deployed = false;
            WaitLaunch = false;
        }

        public Responses Response = new Responses();
        public Checks Check = new Checks();
        public Logging Log = new Logging();

        public void Update(DockFighter Event)
        {
            Status = S.Docked;
            Deployed = false;
        }

        public void Update(FighterDestroyed Event)
        {
            Status = S.Destroyed;
            Deployed = false;
        }

        public void Update(FighterRebuilt Event)
        {
            Status = S.Ready;
        }

        public void Update(LaunchFighter Event)
        {
            Status = S.Deployed;
            WaitLaunch = false;
            Deployed = true;
        }

        public class Responses
        {
            string MethodName = "Fighter Status";

            public void Docked(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fighter Docked.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EQ_Fighter.Docked)
                    .Phrase(EQ_Fighter.Docked_Modifier, true),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Destroyed(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fighter Destroyed.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EQ_Fighter.Destroyed),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void RebuiltDestroyed(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fighter Constructed.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EQ_Fighter.Rebuilt_Docked),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void RebuiltDocked(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fighter Repaired.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EQ_Fighter.Rebuilt_Destroyed),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void RebuiltOther(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fighter Rebuilt.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EQ_Fighter.Rebuilt_Other),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }

        public class Checks
        {

        }

        public class Logging
        {

        }
    }
}