using ALICE_Events;
using ALICE_Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Status
{
    public class Status_Shipyard
    {
        public readonly string MethodName = "Shipyard Status";

        public Responses Response = new Responses();
        //public Checks Check = new Checks();
        public Logging Log = new Logging();

        public void Update(Shipyard Event)
        {

        }

        public void Update(ShipyardTransfer Event)
        {
            if (Check.Internal.TriggerEvents(true, MethodName)) { return; }

            //Construct Shipyard Arrived Event
            IEvents.ShipyardArrived.Construct(Event);
        }

        public void Update(ShipyardBuy Event)
        {

        }

        public void Update(ShipyardNew Event)
        {

        }

        public void Update(ShipyardSwap Event)
        {

        }

        public void Update(ShipyardArrived Event)
        {

        }

        public class Responses
        {
            string MethodName = "Shipyard Status";
        }

        public class Checks
        {

        }

        public class Logging
        {

        }
    }
}
