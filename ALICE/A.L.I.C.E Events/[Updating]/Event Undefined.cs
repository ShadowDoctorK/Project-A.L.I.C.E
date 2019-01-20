﻿//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: Catch For All Undefined Events

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_Undefined : Event_Base
    {
        public List<string> Events = new List<string>();

        public Event_Undefined()
        {
            Name = "Undefined";
        }

        public void Logic()
        {
            string MethodName = "Event Manger (Undefined)";

            Undefined Event = (Undefined)IEvents.Events[Name];

            Logger.Log(MethodName, "We Have Detected A New/Undefined Event (" + Event.Event.ToString() + " | " + Event.Timestamp.ToString() + ")", Logger.Purple);
            Logger.Log(MethodName, "New Event Recorded In The Alice Log File. Please Forward Your Log To The Developer.", Logger.Purple);

            TriggerEvent();
        }

        public void Variables_Generate()
        {

        }
    }

    #region Undefined Event
    public class Undefined : Base
    {
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == "Undefined")
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.Undefined>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }
