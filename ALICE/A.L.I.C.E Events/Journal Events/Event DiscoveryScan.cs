//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-03T02:45:39Z", "event":"DiscoveryScan", "SystemAddress":13869120169369, "Bodies":16 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Ships_Datalink_Interface;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_DiscoveryScan : Event_Base
    {
        public Event_DiscoveryScan()
        {
            Name = "DiscoveryScan";
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

            GameState.Logic_DiscoveryScan((DiscoveryScan)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            DiscoveryScan Event = (DiscoveryScan)Manager.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("SystemAddress", Event.SystemAddress.Variable());
            Variable_Craft("Bodies", Event.Bodies.Variable());
            #endregion
        }
    }

    #region DiscoveryScan Event
    public class DiscoveryScan : Base
    {
        public decimal SystemAddress { get; set; }
        public decimal Bodies { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == DiscoveryScan)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.DiscoveryScan>(RawLine);
//     Manager.UpdateEvents(EventName, Event);
//     Manager.Bounty.Logic();
// }
