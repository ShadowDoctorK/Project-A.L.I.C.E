//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 11:56 PM
//Source Journal Line: { "timestamp":"2018-11-20T22:01:00Z", "event":"CrewFire", "Name":"Donald Trump" }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Actions;
using ALICE_Internal;
using ALICE_EventLogic;

namespace ALICE_Events
{
    public class Event_CrewFire : Event_Base
    {
        public Event_CrewFire()
        {
            Name = "CrewFire";
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

            Process.CrewFire((CrewFire)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            CrewFire Event = (CrewFire)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Name", Event.Name.ToString());
            #endregion
        }
    }

    #region CrewFire Event
    public class CrewFire : Base
    {
        public string Name { get; set; }
        public decimal CrewID { get; set; }

        public CrewFire()
        {
            Name = Default.String;
            CrewID = Default.Decimal;
        }
    }
    #endregion
}


//Journal Reader Code Chunk.

// else if (EventName == "CrewFire")
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.CrewFire>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.CrewFire.Logic();
// }