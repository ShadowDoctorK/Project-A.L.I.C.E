//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-28T20:38:29Z", "event":"Progress", "Combat":35, "Trade":11, "Explore":91, "Empire":100, "Federation":13, "CQC":89 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Progress : Base
    {
        public decimal Combat { get; set; }
        public decimal Trade { get; set; }
        public decimal Explore { get; set; }
        public decimal Empire { get; set; }
        public decimal Federation { get; set; }
        public decimal CQC { get; set; }

        //Default Constructor
        public Progress()
        {
            Combat = Dec();
            Trade = Dec();
            Explore = Dec();
            Empire = Dec();
            Federation = Dec();
            CQC = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_Progress : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (Progress)O;

                Variables.Record(Name + "_Combat", Event.Combat);
                Variables.Record(Name + "_Trade", Event.Trade);
                Variables.Record(Name + "_Explore", Event.Explore);
                Variables.Record(Name + "_Empire", Event.Empire);
                Variables.Record(Name + "_Federation", Event.Federation);                
                Variables.Record(Name + "_CQC", Event.CQC);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}