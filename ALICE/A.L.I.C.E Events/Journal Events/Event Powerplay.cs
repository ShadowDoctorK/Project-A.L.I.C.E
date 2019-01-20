//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T02:31:46Z", "event":"Powerplay", "Power":"Aisling Duval", "Rank":0, "Merits":0, "Votes":0, "TimePledged":29814365 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Ships_Datalink_Interface;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_Powerplay : Event_Base
    {
        public Event_Powerplay()
        {
            Name = "Powerplay";
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
            Powerplay Event = (Powerplay)Manager.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Power", Event.Power.Variable());
            Variable_Craft("Rank", Event.Rank.Variable());
            Variable_Craft("Merits", Event.Merits.Variable());
            Variable_Craft("Votes", Event.Votes.Variable());
            Variable_Craft("TimePledged", Event.TimePledged.Variable());
            #endregion
        }
    }

    #region Powerplay Event
    public class Powerplay : Base
    {
        public string Power { get; set; }
        public decimal Rank { get; set; }
        public decimal Merits { get; set; }
        public decimal Votes { get; set; }
        public decimal TimePledged { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == Powerplay)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.Powerplay>(RawLine);
//     Manager.UpdateEvents(EventName, Event);
//     Manager.Bounty.Logic();
// }
