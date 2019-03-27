//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-07T10:54:48Z", "event":"Reputation", "Empire":75.000000, "Federation":85.554298, "Independent":34.256901 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Reputation : Base
    {
        public decimal Empire { get; set; }
        public decimal Federation { get; set; }
        public decimal Independent { get; set; }
        public decimal Alliance { get; set; }

        //Default Constructor
        public Reputation()
        {
            Empire = Dec();
            Federation = Dec();
            Independent = Dec();
            Alliance = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_Reputation : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (Reputation)O;

                /* Developer Notes:
                 * Reputation Thresholds
                 * Hostile:     -100 -> -90
                 * Unfriendly:  -90 -> -35
                 * Neutral:     -35 -> +04
                 * Cordial:     +04 -> +35
                 * Friendly:    +35 -> +90
                 * Allied:      +90 -> +100
                 */
                Variables.Record(Name + "_Empire", Event.Empire);
                Variables.Record(Name + "_Federation", Event.Federation);
                Variables.Record(Name + "_Independent", Event.Independent);
                Variables.Record(Name + "_Alliance", Event.Alliance);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}