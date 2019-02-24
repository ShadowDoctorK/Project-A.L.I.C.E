//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T02:31:19Z", "event":"Rank", "Combat":6, "Trade":6, "Explore":5, "Empire":7, "Federation":12, "CQC":0 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_Rank : Base
    {
        public decimal Combat { get; set; }
        public decimal Trade { get; set; }
        public decimal Explore { get; set; }
        public decimal Empire { get; set; }
        public decimal Federation { get; set; }
        public decimal CQC { get; set; }

        //Default Constructor
        public ASDF_Rank()
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
    public class QWER_Rank : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (Rank)O;

                Variables.Record(Name + "_Combat", Event.Combat);
                Variables.Record(Name + "_Trade", Event.Trade);
                Variables.Record(Name + "_Explore", Event.Explore);
                Variables.Record(Name + "_Empire", Event.Empire);
                Variables.Record(Name + "_Federation", Event.Federation);
                Variables.Record(Name + "_CQC", Event.CQC);
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
                var Event = (Rank)O;
            }
            catch (Exception ex)
            {
                ExceptionProcess(ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment()
        {
            //No Updates
        }
    }
}