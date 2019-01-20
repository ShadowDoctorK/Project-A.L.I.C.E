//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-09-02T20:06:42Z", "event":"BuyExplorationData", "System":"Fong Dadia", "Cost":6897 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_BuyExplorationData : Event_Base
    {
        public Event_BuyExplorationData()
        {
            Name = "BuyExplorationData";
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
            BuyExplorationData Event = (BuyExplorationData)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("System", Event.System.ToString());
            Variable_Craft("Cost", Event.Cost.ToString());
            #endregion
        }
    }

    #region BuyExplorationData Event
    public class BuyExplorationData : Base
    {
        public string System { get; set; }
        public decimal Cost { get; set; }

        public BuyExplorationData()
        {
            System = Default.String;
            Cost = Default.Decimal;
        }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == "BuyExplorationData")
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.BuyExplorationData>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }
