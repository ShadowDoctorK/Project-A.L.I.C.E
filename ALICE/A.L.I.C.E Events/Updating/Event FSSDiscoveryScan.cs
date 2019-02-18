//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 9:56 PM
//Source Journal Line: { "timestamp":"2018-11-21T02:14:32Z", "event":"FSSDiscoveryScan", "Progress":0.000000, "BodyCount":66, "NonBodyCount":0 }

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
    public class Event_FSSDiscoveryScan : Event_Base
    {
        public Event_FSSDiscoveryScan()
        {
            Name = "FSSDiscoveryScan";
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

            Process.FSSDiscoveryScan((FSSDiscoveryScan)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            FSSDiscoveryScan Event = (FSSDiscoveryScan)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Progress", Event.Progress.ToString());
            Variable_Craft("BodyCount", Event.BodyCount.ToString());
            Variable_Craft("NonBodyCount", Event.NonBodyCount.ToString());
            #endregion
        }
    }

    #region FSSDiscoveryScan Event
    public class FSSDiscoveryScan : Base
    {
        public decimal Progress { get; set; }
        public decimal BodyCount { get; set; }
        public decimal NonBodyCount { get; set; }

        public FSSDiscoveryScan()
        {
            Progress = Default.Decimal;
            BodyCount = Default.Decimal;
            NonBodyCount = Default.Decimal;
        }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == "FSSDiscoveryScan")
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.FSSDiscoveryScan>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }