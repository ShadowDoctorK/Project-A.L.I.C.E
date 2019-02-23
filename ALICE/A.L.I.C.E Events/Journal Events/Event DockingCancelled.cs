//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T03:03:18Z", "event":"DockingCancelled", "MarketID":3221503744, "StationName":"Hennen Station", "StationType":"Bernal" }

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
    public class Event_DockingCancelled : Event_Base
    {
        public Event_DockingCancelled()
        {
            Name = "DockingCancelled";
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

            Process.DockingCancelled((DockingCancelled)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            DockingCancelled Event = (DockingCancelled)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("MarketID", Event.MarketID.Variable());
            Variable_Craft("StationName", Event.StationName.Variable());
            Variable_Craft("StationType", Event.StationType.Variable());
            #endregion
        }
    }

    #region DockingCancelled Event
    public class DockingCancelled : Base
    {
        public decimal MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }

        public DockingCancelled()
        {
            MarketID = Default.Decimal;
            StationName = Default.String;
            StationType = Default.String;
        }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == DockingCancelled)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.DockingCancelled>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }