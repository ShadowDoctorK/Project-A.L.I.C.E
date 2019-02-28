//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 02/16/2019 11:03 PM
//Source Journal Line: { "timestamp":"2019-02-10T23:39:02Z", "event":"AsteroidCracked", "Body":"NLTT 2969 2 A Ring" }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class AsteroidCracked : Base
    {
        public string Body { get; set; }

        //Default Constructor
        public AsteroidCracked()
        {
            Body = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_AsteroidCracked : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (AsteroidCracked)O;

                Variables.Record(Name + "_Location", Event.Body);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}