//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-21T23:06:18Z", "event":"ReceiveText", "From":"$npc_name_decorate:#name=Henke 'Kniiip' Löfqvist;", "From_Localised":"Henke 'Kniiip' Löfqvist", "Message":"$Commuter_HostileScan05;", "Message_Localised":"Your ship's ID has been logged, any active hostilities will result in criminal charges being brought against you.", "Channel":"npc" }

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
    public class Event_ReceiveText : Event_Base
    {
        public Event_ReceiveText()
        {
            Name = "ReceiveText";
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

            Process.ReceivedText((ReceiveText)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            ReceiveText Event = (ReceiveText)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("From", Event.From.Variable());
            Variable_Craft("From_Localised", Event.From_Localised.Variable());
            Variable_Craft("Message", Event.Message.Variable());
            Variable_Craft("Message_Localised", Event.Message_Localised.Variable());
            Variable_Craft("Channel", Event.Channel.Variable());
            #endregion
        }
    }

    #region ReceiveText Event
    public class ReceiveText : Base
    {
        public string From { get; set; }
        public string From_Localised { get; set; }
        public string Message { get; set; }
        public string Message_Localised { get; set; }
        public string Channel { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == ReceiveText)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.ReceiveText>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }