//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T05:55:46Z", "event":"ModuleBuy", "Slot":"PowerDistributor", "SellItem":"$int_powerdistributor_size7_class1_name;", "SellItem_Localised":"Power Distributor", "SellPrice":211766, "BuyItem":"$int_powerdistributor_size7_class5_name;", "BuyItem_Localised":"Power Distributor", "MarketID":3226535936, "BuyPrice":8272137, "Ship":"krait_mkii", "ShipID":29 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_ModuleBuy : Base
    {
        public string Slot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public string StoredItem { get; set; }
        public string StoredItem_Localised { get; set; }
        public decimal SellPrice { get; set; }
        public string BuyItem { get; set; }
        public string BuyItem_Localised { get; set; }
        public decimal MarketID { get; set; }
        public decimal BuyPrice { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }

        //Default Constructor
        public ASDF_ModuleBuy()
        {
            Slot = Str();
            SellItem = Str();
            SellItem_Localised = Str();
            StoredItem = Str();
            SellPrice = Dec();
            BuyItem = Str();
            BuyItem_Localised = Str();
            MarketID = Dec();
            BuyPrice = Dec();
            Ship = Str();
            ShipID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_ModuleBuy : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (ModuleBuy)O;

                Variables.Record(Name + "_Ship", Event.Ship);
                Variables.Record(Name + "_ShipID", Event.ShipID);
                Variables.Record(Name + "_Slot", GetSlot(Event.Slot, false));
                Variables.Switch(Name + "_SellItem", Event.SellItem_Localised, Event.SellItem);
                Variables.Switch(Name + "_StoredItem", Event.StoredItem_Localised, Event.StoredItem);
                Variables.Switch(Name + "_BuyItem", Event.BuyItem_Localised, Event.BuyItem);
                Variables.Record(Name + "_SellPrice", Event.SellPrice);
                Variables.Record(Name + "_BuyPrice", Event.BuyPrice);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}