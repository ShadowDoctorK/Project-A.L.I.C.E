//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 11:56 PM
//Source Journal Line: { "timestamp":"2018-11-20T22:01:00Z", "event":"ScientificResearch", "Name":"nickel", "Category":"Raw", "Count":5 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_ScientificResearch : Base
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Count { get; set; }
        public decimal MarketID { get; set; }

        //Default Constructor
        public ASDF_ScientificResearch()
        {
            Name = Str();
            Category = Str();
            Count = Dec();
            MarketID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_ScientificResearch : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (ScientificResearch)O;

                Variables.Record(Name + "_Name", Event.Name);
                Variables.Record(Name + "_Category", Event.Category);
                Variables.Record(Name + "_Count", Event.Count);
                Variables.Record(Name + "_Market", Event.MarketID);
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
                var Event = (ScientificResearch)O;
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