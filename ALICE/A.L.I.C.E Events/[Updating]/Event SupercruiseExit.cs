//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-14T20:07:57Z", "event":"SupercruiseExit", "StarSystem":"Col 173 Sector KY-Q d5-47", "SystemAddress":1625603164499, "Body":"Col 173 Sector KY-Q d5-47 8 c", "BodyID":24, "BodyType":"Planet" }

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
    public class Event_SupercruiseExit : Event_Base
    {
        public Event_SupercruiseExit()
        {
            Name = "SupercruiseExit";
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

            Process.SupercruiseExit((SupercruiseExit)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            SupercruiseExit Event = (SupercruiseExit)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("StarSystem", Event.StarSystem.Variable());
            Variable_Craft("SystemAddress", Event.SystemAddress.Variable());
            Variable_Craft("Body", Event.Body.Variable());
            Variable_Craft("BodyID", Event.BodyID.Variable());
            Variable_Craft("BodyType", Event.BodyType.Variable());
            #endregion
        }
    }

    #region SupercruiseExit Event
    public class SupercruiseExit : Base
    {
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public string Body { get; set; }
        public decimal BodyID { get; set; }
        public string BodyType { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == SupercruiseExit)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.SupercruiseExit>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }
