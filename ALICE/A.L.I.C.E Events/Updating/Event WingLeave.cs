//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T06:19:59Z", "event":"WingLeave" }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_WingLeave : Event_Base
    {
        public Event_WingLeave()
        {
            Name = "WingLeave";
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
            WingLeave Event = (WingLeave)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            #endregion
        }
    }

    #region WingLeave Event
    public class WingLeave : Base
    {
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == WingLeave)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.WingLeave>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }