//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 12:20 AM
//Source Journal Line: (Custom A.L.I.C.E Event)
//Reference Journal Line: { "timestamp":"2018-11-22T01:47:28Z", "event":"ReceiveText", "From":"Hennen Station", "Message":"$DockingPadBlockWarningComms;", "Message_Localised":"Loitering infraction detected, clear pad approach immediately to avoid lethal response", "Channel":"npc" }

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
    public class Event_BlockLandingPadWarning : Event_Base
    {
        public Event_BlockLandingPadWarning()
        {
            Name = "BlockLandingPadWarning";
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

            Process.BlockLandingPadWarning((BlockLandingPadWarning)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            BlockLandingPadWarning Event = (BlockLandingPadWarning)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Station", Event.Station.ToString());
            #endregion
        }

        public void Construct(ReceiveText Event)
        {
            BlockLandingPadWarning Temp = new BlockLandingPadWarning()
            {
                Station = Event.From
            };

            UpdateEvents(Name, Temp);
            Logic();
        }
    }

    #region BlockLandingPadWarning Event
    public class BlockLandingPadWarning : Base
    {
        public string Station { get; set; }        
    }
    #endregion
}
