//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 11:56 PM
//Source Journal Line: { "timestamp":"2018-11-20T22:01:00Z", "event":"QuitACrew", "Captain":"$cmdr_decorate:#name=Donald Trump;" }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Actions;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_QuitACrew : Event_Base
    {
        public Event_QuitACrew()
        {
            Name = "QuitACrew";
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

            //IObjects.Logic_QuitACrew((QuitACrew)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            QuitACrew Event = (QuitACrew)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Captain", Event.Captain.ToString());
            #endregion
        }
    }

    #region QuitACrew Event
    public class QuitACrew : Base
    {
        public string Captain { get; set; }
    }
    #endregion
}


//Journal Reader Code Chunk.

// else if (EventName == "QuitACrew")
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.QuitACrew>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.QuitACrew.Logic();
// }
