//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-03T03:22:09Z", "event":"ApproachSettlement", "Name":"$Ancient_Small_005;", "Name_Localised":"Guardian Structure", "MarketID":2952790016 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_ApproachSettlement : Base
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public decimal MarketID { get; set; }

        //Default Constructor
        public ASDF_ApproachSettlement()
        {
            Name = Str();
            Name_Localised = Str();
            MarketID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_ApproachSettlement : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (ApproachSettlement)O;

                Variables.Record(Name + "_Name", Event.Name_Localised);
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
                var Event = (ApproachSettlement)O;
            }
            catch (Exception ex)
            {
                ExceptionProcess(ex);
            }
        }
    }
}
