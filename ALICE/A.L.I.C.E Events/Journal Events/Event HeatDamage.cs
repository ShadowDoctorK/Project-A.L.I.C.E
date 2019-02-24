//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-22T01:03:24Z", "event":"HeatDamage" }

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
    public class Event_HeatDamage : Event_Base
    {
        public Event_HeatDamage()
        {
            Name = "HeatDamage";
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

            Process.HeatDamage((HeatDamage)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            HeatDamage Event = (HeatDamage)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            #endregion
        }
    }

    #region HeatDamage Event
    public class HeatDamage : Base
    {
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == HeatDamage)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.HeatDamage>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }