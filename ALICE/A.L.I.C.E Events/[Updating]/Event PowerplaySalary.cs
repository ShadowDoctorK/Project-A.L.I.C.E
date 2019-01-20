//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-11T20:24:46Z", "event":"PowerplaySalary", "Power":"Aisling Duval", "Amount":19000 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_PowerplaySalary : Event_Base
    {
        public Event_PowerplaySalary()
        {
            Name = "PowerplaySalary";
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

            //Custom Logic Here.

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            PowerplaySalary Event = (PowerplaySalary)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Power", Event.Power.Variable());
            Variable_Craft("Amount", Event.Amount.Variable());
            #endregion
        }
    }

    #region PowerplaySalary Event
    public class PowerplaySalary : Base
    {
        public string Power { get; set; }
        public decimal Amount { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == PowerplaySalary)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.PowerplaySalary>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }
