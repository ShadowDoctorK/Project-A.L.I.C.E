//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-09-06T12:19:39Z", "event":"NavBeaconScan", "SystemAddress":16063849047465, "NumBodies":34 }

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
    public class Event_NavBeaconScan : Event_Base
    {
        public Event_NavBeaconScan()
        {
            Name = "NavBeaconScan";
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

            Process.NavBeconScan((NavBeaconScan)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            NavBeaconScan Event = (NavBeaconScan)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("SystemAddress", Event.SystemAddress.ToString());
            Variable_Craft("NumBodies", Event.NumBodies.ToString());
            #endregion
        }
    }

    #region NavBeaconScan Event
    public class NavBeaconScan : Base
    {
        public decimal SystemAddress { get; set; }
        public decimal NumBodies { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == "NavBeaconScan")
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.NavBeaconScan>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }