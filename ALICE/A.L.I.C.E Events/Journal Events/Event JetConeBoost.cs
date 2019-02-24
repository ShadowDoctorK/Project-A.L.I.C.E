//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 12/20/2018 8:58 PM
//Source Journal Line: { "timestamp":"2018-12-20T20:56:52Z", "event":"JetConeBoost", "BoostValue":1.500000 }

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
    public class Event_JetConeBoost : Event_Base
    {
        public Event_JetConeBoost()
        {
            Name = "JetConeBoost";
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

            //GameState.Logic_JetConeBoost((JetConeBoost)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            JetConeBoost Event = (JetConeBoost)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("BoostValue", Event.BoostValue.ToString());
            #endregion
        }
    }

    #region JetConeBoost Event
    public class JetConeBoost : Base
    {
        public decimal BoostValue { get; set; }

        public JetConeBoost()
        {
            BoostValue = Default.Decimal;
        }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == "JetConeBoost")
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.JetConeBoost>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.JetConeBoost.Logic();
// }