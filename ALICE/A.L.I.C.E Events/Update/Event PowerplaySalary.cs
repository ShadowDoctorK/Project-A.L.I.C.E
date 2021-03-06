//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-11T20:24:46Z", "event":"PowerplaySalary", "Power":"Aisling Duval", "Amount":19000 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class PowerplaySalary : Base
    {
        public string Power { get; set; }
        public decimal Amount { get; set; }

        //Default Constructor
        public PowerplaySalary()
        {
            Power = Str();
            Amount = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_PowerplaySalary : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (PowerplaySalary)O;

                Variables.Record(Name + "_Power", Event.Power);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}
