//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-29T00:33:24Z", "event":"FactionKillBond", "Reward":59800, "AwardingFaction":"The Fuel Rats Mischief", "VictimFaction":"Constitution Party of Fuelum" }

using ALICE_Status;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class FactionKillBond : Base
    {
        public decimal Reward { get; set; }
        public string AwardingFaction { get; set; }
        public string AwardingFaction_Localised { get; set; }
        public string VictimFaction { get; set; }
        public string VictimFaction_Localised { get; set; }

        //Default Constructor
        public FactionKillBond()
        {
            Reward = Dec();
            AwardingFaction = Str();
            AwardingFaction_Localised = Str();
            VictimFaction = Str();
            VictimFaction_Localised = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_FactionKillBond : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (FactionKillBond)O;

                Variables.Record(Name + "_Credits", Event.Reward);
                Variables.Switch(Name + "_VictimFaction", Event.VictimFaction_Localised, Event.VictimFaction);
                Variables.Switch(Name + "_AwardingFaction", Event.AwardingFaction_Localised, Event.AwardingFaction);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment(object O)
        {
            try
            {
                IStatus.Supercruise = false;
                IStatus.Hyperspace = false;
                IStatus.Touchdown = false;
                IStatus.Docking.Docked = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}
