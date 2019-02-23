//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T03:46:56Z", "event":"FuelScoop", "Scooped":5.007301, "Total":29.415503 }

using ALICE_EventLogic;
using ALICE_Internal;
using System;

namespace ALICE_Events
{
    public class Event_FuelScoop : Event_Base
    {
        public Event_FuelScoop()
        {
            Name = "FuelScoop";
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

            Process.FuelScoop((FuelScoop)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            FuelScoop Event = (FuelScoop)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Scooped", Event.Scooped.Variable());
            Variable_Craft("Total", Event.Total.Variable());
            #endregion
        }
    }

    #region FuelScoop Event
    public class FuelScoop : Base
    {
        public decimal Scooped { get; set; }
        public decimal Total { get; set; }

        public FuelScoop()
        {
            Scooped = Default.Decimal;
            Total = Default.Decimal;
        }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == FuelScoop)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.FuelScoop>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }
