//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 01/18/2018 5:27 AM
//Source Journal Line: { "timestamp":"2019-01-18T08:54:12Z", "event":"ReservoirReplenished", "FuelMain":29.326540, "FuelReservoir":0.830000 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ReservoirReplenished : Base
    {
        public decimal FuelMain { get; set; }
        public decimal FuelReservoir { get; set; }

        //Default Constructor
        public ReservoirReplenished()
        {
            FuelMain = Dec();
            FuelReservoir = Dec();            
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_ReservoirReplenished : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (ReservoirReplenished)O;

                Variables.Record(Name + "_FuelMain", Event.FuelMain);
                Variables.Record(Name + "_FuelReservoir", Event.FuelReservoir);                
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}