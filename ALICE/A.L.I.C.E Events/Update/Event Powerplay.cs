//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T02:31:46Z", "event":"Powerplay", "Power":"Aisling Duval", "Rank":0, "Merits":0, "Votes":0, "TimePledged":29814365 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Powerplay : Base
    {
        public string Power { get; set; }
        public decimal Rank { get; set; }
        public decimal Merits { get; set; }
        public decimal Votes { get; set; }
        public decimal TimePledged { get; set; }

        //Default Constructor
        public Powerplay()
        {
            Power = Str();
            Rank = Dec();
            Merits = Dec();
            Votes = Dec();
            TimePledged = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_Powerplay : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (Powerplay)O;

                Variables.Record(Name + "_Power", Event.Power);
                Variables.Record(Name + "_Rank", Event.Rank);
                Variables.Record(Name + "_Merits", Event.Merits);
                Variables.Record(Name + "_Votes", Event.Votes);
                Variables.Record(Name + "_Time", Event.TimePledged);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}