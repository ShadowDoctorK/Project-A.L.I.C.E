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
    public class Status_Messages
    {
        public Responses Response = new Responses();
        public Checks Check = new Checks();
        public Logging Log = new Logging();

        public void Update(ReceiveText Event)
        {
            //Generate Custom Events
            EventGeneration(Event);
        }

        public void EventGeneration(ReceiveText Event)
        {
            //No Fire Zone
            if (Event.Message.Contains(IEnums.NoFireZone))
            { IEvents.NoFireZone.Construct(Event); }

            //Block Landing Pad Warning
            else if (Event.Message.Contains(IEnums.DockingPadBlockWarning))
            { IEvents.BlockLandingPadWarning.Construct(Event); }

            //Block Airlock Warning
            else if (Event.Message.Contains(IEnums.DockingDoorBlockWarning))
            { IEvents.BlockAirlockWarning.Construct(Event); }

            //Block Landing Pad Hostile
            else if (Event.Message.Contains(IEnums.DockingPadBlockHostile))
            { IEvents.BlockLandingPadWarning.Construct(Event); }

            //Block Airlock Hostile
            else if (Event.Message.Contains(IEnums.DockingDoorBlockHostile))
            { IEvents.BlockAirlockWarning.Construct(Event); }

            //Station Damage
            else if (Event.Message.Contains(IEnums.AccidentalDamage))
            { IEvents.StationDamage.Construct(Event); }

            //Station Hostile
            else if (Event.Message.Contains(IEnums.StationAggressorResponse))
            { IEvents.StationHostile.Construct(Event); }

            else
            {
                Logger.DeveloperLog("Develoer Record: [ReceiveText:Message] " + Event.Message);
            }
        }

        public class Responses
        {
            string MethodName = "Messages Status";
        }

        public class Checks
        {

        }

        public class Logging
        {

        }
    }
}
