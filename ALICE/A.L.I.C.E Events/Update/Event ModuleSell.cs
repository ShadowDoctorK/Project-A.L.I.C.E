//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-30T04:08:50Z", "event":"ModuleSell", "MarketID":3223901184, "Slot":"Slot03_Size7", "SellItem":"$int_hullreinforcement_size5_class2_name;", "SellItem_Localised":"Hull Reinforcement", "SellPrice":450000, "Ship":"federation_corvette", "ShipID":11 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ModuleSell : Base
    {
        public decimal MarketID { get; set; }
        public string Slot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public decimal SellPrice { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }

        //Default Constructor
        public ModuleSell()
        {
            MarketID = Dec();
            Slot = Str();
            SellItem = Str();
            SellItem_Localised = Str();
            SellPrice = Dec();
            Ship = Str();
            ShipID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_ModuleSell : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (ModuleSell)O;

                Variables.Record(Name + "_MarketID", Event.MarketID);
                Variables.Record(Name + "_Slot", GetSlot(Event.Slot, false));
                Variables.Switch(Name + "_SellItem", Event.SellItem_Localised, Event.SellItem);
                Variables.Record(Name + "_SellPrice", Event.SellPrice);
                Variables.Record(Name + "_Ship", Event.Ship);
                Variables.Record(Name + "_ShipID", Event.ShipID);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}