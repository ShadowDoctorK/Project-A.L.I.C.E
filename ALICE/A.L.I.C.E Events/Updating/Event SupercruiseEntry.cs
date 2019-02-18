//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-14T22:27:55Z", "event":"SupercruiseEntry", "StarSystem":"Col 173 Sector KY-Q d5-47", "SystemAddress":1625603164499 }

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
    public class Event_SupercruiseEntry : Event_Base
    {
        public Event_SupercruiseEntry()
        {
            Name = "SupercruiseEntry";
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

            Process.SupercruiseEntry((SupercruiseEntry)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            SupercruiseEntry Event = (SupercruiseEntry)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("StarSystem", Event.StarSystem.Variable());
            Variable_Craft("SystemAddress", Event.SystemAddress.Variable());
            #endregion
        }
    }

    #region SupercruiseEntry Event
    public class SupercruiseEntry : Base
    {
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == SupercruiseEntry)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.SupercruiseEntry>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }