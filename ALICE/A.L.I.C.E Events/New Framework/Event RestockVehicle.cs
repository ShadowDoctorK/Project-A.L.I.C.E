//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T05:19:10Z", "event":"RestockVehicle", "Type":"independent_fighter", "Loadout":"three", "Cost":1030, "Count":1 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_RestockVehicle : Base
    {
        public string Type { get; set; }
        public string Loadout { get; set; }
        public decimal Cost { get; set; }
        public decimal Count { get; set; }

        //Default Constructor
        public ASDF_RestockVehicle()
        {
            Type = Str();
            Loadout = Str();
            Cost = Dec();
            Count = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_RestockVehicle : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (RestockVehicle)O;

                Variables.Record(Name + "_Type", Event.Type);
                Variables.Record(Name + "_Loadout", Event.Loadout);
                Variables.Record(Name + "_Credits", Event.Cost);
                Variables.Record(Name + "_Count", Event.Count);
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
                var Event = (RestockVehicle)O;
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