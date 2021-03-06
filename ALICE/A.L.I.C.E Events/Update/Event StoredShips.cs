//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T05:40:46Z", "event":"StoredShips", "StationName":"Morris Barracks", "MarketID":3524278272, "StarSystem":"Lambda Andromedae", "ShipsHere":[  ], "ShipsRemote":[ { "ShipID":0, "ShipType":"Asp", "ShipType_Localised":"Asp Explorer", "StarSystem":"HR 8514", "ShipMarketID":3221503744, "TransferPrice":84995, "TransferTime":978, "Value":19655521, "Hot":false }, { "ShipID":5, "ShipType":"Anaconda", "Name":"Alexia", "StarSystem":"Nankul", "ShipMarketID":3221644800, "TransferPrice":475901, "TransferTime":885, "Value":127900211, "Hot":false }, { "ShipID":7, "ShipType":"Eagle", "StarSystem":"HR 8514", "ShipMarketID":3221503744, "TransferPrice":1191, "TransferTime":978, "Value":44800, "Hot":false }, { "ShipID":8, "ShipType":"Hauler", "StarSystem":"HR 8514", "ShipMarketID":3221503744, "TransferPrice":2616, "TransferTime":978, "Value":378252, "Hot":false }, { "ShipID":11, "ShipType":"Federation_Corvette", "ShipType_Localised":"Federal Corvette", "Name":"MORNINGSTAR", "StarSystem":"HR 8514", "ShipMarketID":3221503744, "TransferPrice":2902701, "TransferTime":978, "Value":679014823, "Hot":false }, { "ShipID":18, "ShipType":"Viper_MkIV", "ShipType_Localised":"Viper MkIV", "Name":"starfox", "StarSystem":"HR 8514", "ShipMarketID":3221503744, "TransferPrice":17232, "TransferTime":978, "Value":3798451, "Hot":false }, { "ShipID":28, "ShipType":"SideWinder", "Name":"suicidewinder", "StarSystem":"Run", "ShipMarketID":128027136, "TransferPrice":5275, "TransferTime":2176, "Value":373152, "Hot":false }, { "ShipID":32, "ShipType":"TypeX", "ShipType_Localised":"Alliance Chieftain", "StarSystem":"HR 8514", "ShipMarketID":3221503744, "TransferPrice":264827, "TransferTime":978, "Value":61737115, "Hot":false } ] }

using System;
using System.Collections.Generic;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class StoredShips : Base
    {
        public string StationName { get; set; }
        public decimal MarketID { get; set; }
        public string StarSystem { get; set; }
        public List<Ship> ShipsHere { get; set; }
        public List<Ship> ShipsRemote { get; set; }

        //Default Constructor
        public StoredShips()
        {
            StationName = Str();
            MarketID = Dec();
            StarSystem = Str();
            ShipsHere = new List<Ship>();
            ShipsRemote = new List<Ship>();
        }

        public class Ship : Catch
        {
            public decimal ShipID { get; set; }
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public string Name { get; set; }
            public string StarSystem { get; set; }
            public decimal ShipMarketID { get; set; }
            public decimal TransferPrice { get; set; }
            public decimal TransferTime { get; set; }
            public decimal Value { get; set; }
            public bool Hot { get; set; }
            public bool InTransit { get; set; }

            public Ship()
            {
                ShipID = Dec();
                ShipType = Str();
                ShipType_Localised = Str();
                Name = Str();
                StarSystem = Str();
                ShipMarketID = Dec();
                TransferPrice = Dec();
                TransferTime = Dec();
                Value = Dec();
                Hot = Bool();
                InTransit = Bool();
            }

            public class Item : Catch
            {
                public string Name { get; set; }
                public string Name_Localised { get; set; }
                public decimal StorageSlot { get; set; }
                public string StarSystem { get; set; }
                public decimal MarketID { get; set; }
                public decimal TransferCost { get; set; }
                public decimal TransferTime { get; set; }
                public decimal BuyPrice { get; set; }
                public bool Hot { get; set; }
                public string EngineerModifications { get; set; }
                public decimal Level { get; set; }
                public decimal Quality { get; set; }
                public bool InTransit { get; set; }

                public Item()
                {
                    Name = Str();
                    Name_Localised = Str();
                    StorageSlot = Dec();
                    StarSystem = Str();
                    MarketID = Dec();
                    TransferCost = Dec();
                    TransferTime = Dec();
                    BuyPrice = Dec();
                    Hot = Bool();
                    EngineerModifications = Str();
                    Level = Dec();
                    Quality = Dec();
                    InTransit = Bool();
                }
            }
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_StoredShips : Event
    {
        //No Processing
    }
}