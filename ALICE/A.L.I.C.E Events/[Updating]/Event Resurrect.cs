//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-19T04:53:49Z", "event":"Resurrect", "Option":"rebuy", "Cost":34226497, "Bankrupt":false }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_Resurrect : Event_Base
    {
        public Event_Resurrect()
        {
            Name = "Resurrect";
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
            Resurrect Event = (Resurrect)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Option", Event.Option.Variable());
            Variable_Craft("Cost", Event.Cost.Variable());
            Variable_Craft("Bankrupt", Event.Bankrupt.Variable());
            #endregion
        }
    }

    #region Resurrect Event
    public class Resurrect : Base
    {
        public string Option { get; set; }
        public decimal Cost { get; set; }
        public string Bankrupt { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == Resurrect)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.Resurrect>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }
