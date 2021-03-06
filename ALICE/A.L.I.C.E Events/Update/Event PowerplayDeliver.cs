//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-09-23T14:21:17Z", "event":"PowerplayDeliver", "Power":"Edmund Mahon", "Type":"$alliancelegaslativerecords_name;", "Type_Localised":"Alliance Legislative Records", "Count":600 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class PowerplayDeliver : Base
    {
        public string Power { get; set; }
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public decimal Count { get; set; }

        //Default Constructor
        public PowerplayDeliver()
        {
            Power = Str();
            Type = Str();
            Type_Localised = Str();
            Count = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_PowerplayDeliver : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (PowerplayDeliver)O;

                Variables.Record(Name + "_Power", Event.Power);
                Variables.Record(Name + "_Type", Event.Type_Localised);
                Variables.Record(Name + "_Count", Event.Count);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}