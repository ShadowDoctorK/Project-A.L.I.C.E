//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 12:20 AM
//Source Journal Line: (Custom A.L.I.C.E Event)
//Reference Journal Line: { "timestamp":"2018-11-22T16:26:09Z", "event":"ReceiveText", "From":"Hennen Station", "Message":"$DockingPadBlockHostileComms;", "Message_Localised":"Docking pad violation, lethal response authorised", "Channel":"npc" }

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
    public class Event_BlockAirlockHostile : Event_Base
    {
        public Event_BlockAirlockHostile()
        {
            Name = "BlockAirlockHostile";
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

            Process.BlockAirlockHostile((BlockAirlockHostile)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            BlockAirlockHostile Event = (BlockAirlockHostile)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Station", Event.Station.ToString());
            #endregion
        }

        public void Construct(ReceiveText Event)
        {
            BlockAirlockHostile Temp = new BlockAirlockHostile()
            {
                Station = Event.From
            };

            UpdateEvents(Name, Temp);
            Logic();
        }
    }

    #region BlockAirlockHostile Event
    public class BlockAirlockHostile : Base
    {
        public string Station { get; set; }        
    }
    #endregion
}
