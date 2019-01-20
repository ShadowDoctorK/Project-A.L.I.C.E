//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T05:19:10Z", "event":"RestockVehicle", "Type":"independent_fighter", "Loadout":"three", "Cost":1030, "Count":1 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Ships_Datalink_Interface;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_RestockVehicle : Event_Base
    {
        public Event_RestockVehicle()
        {
            Name = "RestockVehicle";
        }

        public void Logic()
        {
            if (Manager.WriteVariables && WriteVariables)
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
            RestockVehicle Event = (RestockVehicle)Manager.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Type", Event.Type.Variable());
            Variable_Craft("Loadout", Event.Loadout.Variable());
            Variable_Craft("Cost", Event.Cost.Variable());
            Variable_Craft("Count", Event.Count.Variable());
            #endregion
        }
    }

    #region RestockVehicle Event
    public class RestockVehicle : Base
    {
        public string Type { get; set; }
        public string Loadout { get; set; }
        public decimal Cost { get; set; }
        public decimal Count { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == RestockVehicle)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.RestockVehicle>(RawLine);
//     Manager.UpdateEvents(EventName, Event);
//     Manager.Bounty.Logic();
// }
