//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T04:29:22Z", "event":"ModuleInfo" }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Ships_Datalink_Interface;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_ModuleInfo : Event_Base
    {
        public Event_ModuleInfo()
        {
            Name = "ModuleInfo";
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

            //Custom Logic Here.

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            ModuleInfo Event = (ModuleInfo)Manager.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            #endregion
        }
    }

    #region ModuleInfo Event
    public class ModuleInfo : Base
    {
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == ModuleInfo)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.ModuleInfo>(RawLine);
//     Manager.UpdateEvents(EventName, Event);
//     Manager.Bounty.Logic();
// }
