//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 12:20 AM
//Source Journal Line: (Custom A.L.I.C.E Event)
//Reference Journal Line: { "timestamp":"2018-11-22T17:11:53Z", "event":"CommitCrime", "CrimeType":"fireInStation", "Faction":"Eureka Mining Co-Operative", "Bounty":100 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;
using ALICE_EventLogic;

namespace ALICE_Events
{
    public class Event_FireInStation : Event_Base
    {
        public Event_FireInStation()
        {
            Name = "FireInStation";
        }

        public void Logic()
        {
            if (IEvents.WriteVariables && WriteVariables)
            {
                try
                {
                    Variables_Clear();
                    Variables_Generate();
                    Variables_Write();
                }
                catch (Exception ex)
                {
                    Logger.Exception(Name, "An Exception Occured While Updating Variables");
                    Logger.Exception(Name, "Exception: " + ex);
                }
            }

            //Process.FireInStation((FireInStation)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            FireInStation Event = (FireInStation)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Faction", Event.Faction.ToString());
            Variable_Craft("Amount", Event.Amount.ToString());
            Variable_Craft("ChargeType", Event.ChargeType.ToString());
            #endregion
        }

        public void Construct(CommitCrime Event)
        {
            FireInStation Temp = new FireInStation()
            {
                ChargeType = "Bounty",
                Faction = Event.Faction,
                Amount = Event.Bounty
            };

            UpdateEvents(Name, Temp);
            Logic();
        }
    }

    #region FireInStation Event
    public class FireInStation : Base
    {
        public string Faction { get; set; }
        public decimal Amount { get; set; }
        public string ChargeType { get; set; }
    }
    #endregion
}