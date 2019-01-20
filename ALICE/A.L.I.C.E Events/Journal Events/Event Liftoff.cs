//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-15T03:11:17Z", "event":"Liftoff", "PlayerControlled":true, "Latitude":-15.108140, "Longitude":-102.934616 }

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
    public class Event_Liftoff : Event_Base
    {
        public Event_Liftoff()
        {
            Name = "Liftoff";
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

            Process.Liftoff((Liftoff)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            Liftoff Event = (Liftoff)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("PlayerControlled", Event.PlayerControlled.Variable());
            Variable_Craft("Latitude", Event.Latitude.Variable());
            Variable_Craft("Longitude", Event.Longitude.Variable());
            #endregion
        }
    }

    #region Liftoff Event
    public class Liftoff : Base
    {
        public bool PlayerControlled { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public Liftoff()
        {
            PlayerControlled = Default.False;
            Latitude = Default.Decimal;
            Longitude = Default.Decimal;
        }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == Liftoff)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.Liftoff>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }
