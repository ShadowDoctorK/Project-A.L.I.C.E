//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T05:42:16Z", "event":"Outfitting", "MarketID":3524278272, "StationName":"Morris Barracks", "StarSystem":"Lambda Andromedae" }
//Source Outfitting.Json:
/*
{ "timestamp":"2018-12-22T04:14:08Z", "event":"Outfitting", "MarketID":3229906432, "StationName":"Barentsz Vision", "StarSystem":"Sengen Sama", "Horizons":true, "Items":[ 
{ "id":128049430, "Name":"hpt_beamlaser_fixed_large", "BuyPrice":1177600 }, 
{ "id":128049434, "Name":"hpt_beamlaser_gimbal_large", "BuyPrice":2396160 }, 
...
(Deleted Excess Items / Example Only)
...
{ "id":128666665, "Name":"int_fuelscoop_size6_class3", "BuyPrice":1797726 }, 
{ "id":128666679, "Name":"int_fuelscoop_size4_class5", "BuyPrice":2862364 }] }
*/

using System;
using System.Collections.Generic;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Outfitting : Base
    {
        //Shared Properties
        public decimal MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }

        //Outfitting.Json Properties
        public bool Horizons { get; set; }
        public List<OutfittingItem> Items { get; set; }

        //Default Constructor
        public Outfitting()
        {
            MarketID = Dec();
            StationName = Str();
            StarSystem = Str();
            Horizons = Bool();
            Items = new List<OutfittingItem>();
        }

        public class OutfittingItem : Catch
        {
            public decimal id { get; set; }
            public string Name { get; set; }
            public decimal BuyPrice { get; set; }

            public OutfittingItem()
            {
                id = Dec();
                Name = Str();
                BuyPrice = Dec();
            }
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_Outfitting : Event
    {
        //No Processing
    }
}