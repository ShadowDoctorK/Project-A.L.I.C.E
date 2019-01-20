//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T05:19:58Z", "event":"SellDrones", "Type":"Drones", "Count":19, "SellPrice":100, "TotalSale":1900 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_SellDrones : Event_Base
    {
        public Event_SellDrones()
        {
            Name = "SellDrones";
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
            SellDrones Event = (SellDrones)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Type", Event.Type.Variable());
            Variable_Craft("Count", Event.Count.Variable());
            Variable_Craft("SellPrice", Event.SellPrice.Variable());
            Variable_Craft("TotalSale", Event.TotalSale.Variable());
            #endregion
        }
    }

    #region SellDrones Event
    public class SellDrones : Base
    {
        public string Type { get; set; }
        public decimal Count { get; set; }
        public decimal SellPrice { get; set; }
        public decimal TotalSale { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == SellDrones)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.SellDrones>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }
