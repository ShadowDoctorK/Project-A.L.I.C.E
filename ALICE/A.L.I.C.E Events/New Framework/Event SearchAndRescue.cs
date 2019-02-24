//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 11:56 PM
//Source Journal Line: { "timestamp":"2018-11-20T22:01:00Z", "event":"SearchAndRescue", "Name":"occupiedcryopod", "Count":2, "Reward":5310 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_SearchAndRescue : Base
    {
        public string Name { get; set; }
        public decimal Count { get; set; }
        public decimal Reward { get; set; }

        //Default Constructor
        public ASDF_SearchAndRescue()
        {
            Name = Str();            
            Count = Dec();
            Reward = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_SearchAndRescue : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (SearchAndRescue)O;

                Variables.Record(Name + "_Name", Event.Name);                
                Variables.Record(Name + "_Count", Event.Count);
                Variables.Record(Name + "_Reward", Event.Reward);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}