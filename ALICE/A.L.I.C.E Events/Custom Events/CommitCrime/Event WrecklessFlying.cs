//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 12:20 AM
//Source Journal Line: (Custom A.L.I.C.E Event)
//Reference Journal Line:

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
    public class Event_WrecklessFlying : Event_Base
    {
        public Event_WrecklessFlying()
        {
            Name = "WrecklessFlying";
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

            Process.WrecklessFlying((WrecklessFlying)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            WrecklessFlying Event = (WrecklessFlying)IEvents.GetEvent(Name);

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
            WrecklessFlying Temp = new WrecklessFlying()
            {
                ChargeType = "Fine",
                Faction = Event.Faction,
                Amount = Event.Fine
            };

            UpdateEvents(Name, Temp);
            Logic();
        }
    }

    #region WrecklessFlying Event
    public class WrecklessFlying : Base
    {
        public string Faction { get; set; }
        public decimal Amount { get; set; }
        public string ChargeType { get; set; }
    }
    #endregion
}
