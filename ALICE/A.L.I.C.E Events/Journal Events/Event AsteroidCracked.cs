//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 02/16/2019 11:03 PM
//Source Journal Line: { "timestamp":"2019-02-10T23:39:02Z", "event":"AsteroidCracked", "Body":"NLTT 2969 2 A Ring" }

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
    public class Event_AsteroidCracked : Event_Base
    {
        public Event_AsteroidCracked()
        {
            Name = "AsteroidCracked";
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

            Process.AsteroidCracked((AsteroidCracked)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            AsteroidCracked Event = (AsteroidCracked)GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Body", Event.Body.ToString());
            #endregion
        }
    }

    #region AsteroidCracked Event
    public class AsteroidCracked : Base
    {
        public string Body { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == "AsteroidCracked")
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.AsteroidCracked>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.AsteroidCracked.Logic();
// }