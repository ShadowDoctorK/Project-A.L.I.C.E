//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-19T02:39:00Z", "event":"Screenshot", "Filename":"\\ED_Pictures\\Screenshot_0004.bmp", "Width":3840, "Height":2160, "System":"NGC 2451A Sector EC-L b8-5", "Body":"NGC 2451A Sector EC-L b8-5 AB" }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_Screenshot : Event_Base
    {
        public Event_Screenshot()
        {
            Name = "Screenshot";
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
            Screenshot Event = (Screenshot)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Filename", Event.Filename.Variable());
            Variable_Craft("Width", Event.Width.Variable());
            Variable_Craft("Height", Event.Height.Variable());
            Variable_Craft("System", Event.System.Variable());
            Variable_Craft("Body", Event.Body.Variable());
            #endregion
        }
    }

    #region Screenshot Event
    public class Screenshot : Base
    {
        public string Filename { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string System { get; set; }
        public string Body { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == Screenshot)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.Screenshot>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }