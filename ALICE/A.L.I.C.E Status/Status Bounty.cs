using ALICE_Core;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Status
{
    public class Status_Bounty
    {
        /// <summary>
        /// Enum used for the derived Vehicle Property
        /// </summary>
        public enum V { Unknown, Ship, Skimmer }        

        public string Pilot = "Unknown Pilot";          //From TargetCurrent Object
        public V Vehicle = V.Unknown;                   //Derived Property
        public decimal Reward = 0;                      //Bounty Event
        public decimal Shared = -1;                     //Bounty Event
        public string Victim = "Unknown";               //Bounty Event
        public string VictimFaction = "Unknown";        //Bounty Event

        public Responses Response = new Responses();
        public Checks Check = new Checks();
        public Logging Log = new Logging();

        public void Update(Bounty Event)
        {
            string MethodName = "Bounty Status (Update)";

            try
            {
                Victim = Event.Target;
                VictimFaction = Event.VictimFaction_Localised;
                Shared = Event.SharedWithOthers;

                switch (ValidateVehicle(Event))
                {
                    case V.Ship:
                        Reward = Event.TotalReward;
                        break;

                    case V.Skimmer:
                        Reward = Event.Reward;
                        break;

                    default:
                        Logger.Error(MethodName, "Returned Using Default Swtich", Logger.Red);
                        Reward = 0;
                        break;
                }

                Pilot = IObjects.TargetCurrent.PilotName_Localised;
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
            }            
        }

        public V ValidateVehicle(Bounty Event)
        {
            //Skimmer
            if (Event.Reward != -1)
            {
                Vehicle = V.Skimmer;
            }
            //Ship
            else
            {
                Vehicle = V.Ship;
            }

            return Vehicle;
        }

        public class Responses
        {
            string MethodName = "Bounty Status";

            public void Collected(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Collected: " + IStatus.Bounty.Reward, Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EVT_Bounty.Collected)
                    .Token("[NUM]", IStatus.Bounty.Reward)
                    .Token("[SHIPTYPE]", IStatus.Bounty.Victim)
                    .Token("[PILOTNAME]", IStatus.Bounty.Pilot),
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
