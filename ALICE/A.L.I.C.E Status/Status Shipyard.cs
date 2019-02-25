using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;
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

            public void ThreeMinWarning(string Destination, string Ship, string Station, bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "3 Min Till Your " + Ship + " Arrives In " + Destination, Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EVT_Shipyard_Arrived.Three_Min_Warning)
                    .Token("[DESTINATION]", Destination)
                    .Token("[SHIP]", Ship)
                    .Token("[STATION]", Station),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }
    }
}
