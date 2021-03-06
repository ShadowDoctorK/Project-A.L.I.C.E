//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-09-03T15:26:04Z", "event":"PowerplayVote", "Power":"Edmund Mahon", "Votes":5, "VoteToConsolidate":1 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class PowerplayVote : Base
    {
        public string Power { get; set; }
        public decimal Votes { get; set; }
        public decimal VoteToConsolidate { get; set; }

        //Default Constructor
        public PowerplayVote()
        {
            Power = Str();
            Votes = Dec();
            VoteToConsolidate = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_PowerplayVote : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (PowerplayVote)O;

                Variables.Record(Name + "_Power", Event.Power);
                Variables.Record(Name + "_Votes", Event.Votes);
                Variables.Record(Name + "_Consolidate", Event.VoteToConsolidate);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}