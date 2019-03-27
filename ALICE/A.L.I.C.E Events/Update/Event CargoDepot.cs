//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-22T00:11:26Z", "event":"CargoDepot", "MissionID":427614351, "UpdateType":"Deliver", "CargoType":"PerformanceEnhancers", "CargoType_Localised":"Performance Enhancers", "Count":584, "StartMarketID":0, "EndMarketID":3221503744, "ItemsCollected":0, "ItemsDelivered":584, "TotalItemsToDeliver":2061, "Progress":0.000000 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class CargoDepot : Base
    {
        public decimal MissionID { get; set; }
        public string UpdateType { get; set; }
        public string CargoType { get; set; }
        public string CargoType_Localised { get; set; }
        public decimal Count { get; set; }
        public decimal StartMarketID { get; set; }
        public decimal EndMarketID { get; set; }
        public decimal ItemsCollected { get; set; }
        public decimal ItemsDelivered { get; set; }
        public decimal TotalItemsToDeliver { get; set; }
        public decimal Progress { get; set; }

        //Default Constructor
        public CargoDepot()
        {
            MissionID = Dec();
            UpdateType = Str();
            CargoType = Str();
            CargoType_Localised = Str();
            Count = Dec();
            StartMarketID = Dec();
            EndMarketID = Dec();
            ItemsCollected = Dec();
            ItemsDelivered = Dec();
            TotalItemsToDeliver = Dec();
            Progress = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_CargoDepot : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (CargoDepot)O;

                Variables.Record(Name + "_Mission", Event.MissionID);
                Variables.Record(Name + "_Update", Event.UpdateType);
                Variables.Record(Name + "_Cargo", Event.CargoType_Localised);
                Variables.Record(Name + "_Count", Event.Count);
                Variables.Record(Name + "_StartStation", Event.StartMarketID);
                Variables.Record(Name + "_EndStation", Event.EndMarketID);
                Variables.Record(Name + "_Collected", Event.ItemsCollected);
                Variables.Record(Name + "_Delivered", Event.ItemsDelivered);
                Variables.Record(Name + "_Total", Event.TotalItemsToDeliver);
                Variables.Record(Name + "_Progress", Event.Progress);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}