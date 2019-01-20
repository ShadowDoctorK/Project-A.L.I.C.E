//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-09-23T14:08:18Z", "event":"PowerplayCollect", "Power":"Edmund Mahon", "Type":"$alliancelegaslativerecords_name;", "Type_Localised":"Alliance Legislative Records", "Count":50 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Ships_Datalink_Interface;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_PowerplayCollect : Event_Base
    {
        public Event_PowerplayCollect()
        {
            Name = "PowerplayCollect";
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
            PowerplayCollect Event = (PowerplayCollect)Manager.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Power", Event.Power.ToString());
            Variable_Craft("Type", Event.Type.ToString());
            Variable_Craft("Type_Localised", Event.Type_Localised.ToString());
            Variable_Craft("Count", Event.Count.ToString());
            #endregion
        }
    }

    #region PowerplayCollect Event
    public class PowerplayCollect : Base
    {
        public string Power { get; set; }
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public decimal Count { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == "PowerplayCollect")
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.PowerplayCollect>(RawLine);
//     Manager.UpdateEvents(EventName, Event);
//     Manager.Bounty.Logic();
// }
