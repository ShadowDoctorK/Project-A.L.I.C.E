//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-29T00:33:24Z", "event":"FactionKillBond", "Reward":59800, "AwardingFaction":"The Fuel Rats Mischief", "VictimFaction":"Constitution Party of Fuelum" }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_FactionKillBond : Base
    {
        public decimal Reward { get; set; }
        public string AwardingFaction { get; set; }
        public string AwardingFaction_Localised { get; set; }
        public string VictimFaction { get; set; }
        public string VictimFaction_Localised { get; set; }

        //Default Constructor
        public ASDF_FactionKillBond()
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
    public class QWER_FactionKillBond : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (FactionKillBond)O;

                Variables.Record(Name + "_Credits", Event.Reward);

                //Victim Faction
                if (Event.VictimFaction_Localised != "None")
                {
                    Variables.Record(Name + "_VictimFaction", Event.VictimFaction_Localised);
                }
                else
                {
                    Variables.Record(Name + "_VictimFaction", Event.VictimFaction);
                }

                //Awarding Faction
                if (Event.AwardingFaction_Localised != "None")
                {
                    Variables.Record(Name + "_AwardingFaction", Event.AwardingFaction_Localised);
                }
                else
                {
                    Variables.Record(Name + "_AwardingFaction", Event.AwardingFaction);
                }
            }
            catch (Exception ex)
            {
                ExceptionGenerate(ex);
            }
        }
        
        //Plugin Logic Process
        public override void Process(object O)
        {
            try
            {
                var Event = (FactionKillBond)O;
            }
            catch (Exception ex)
            {
                ExceptionProcess(ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment()
        {
            IStatus.Supercruise = false;
            IStatus.Hyperspace = false;
            IStatus.Touchdown = false;
            IStatus.Docked = false;
        }
    }
}