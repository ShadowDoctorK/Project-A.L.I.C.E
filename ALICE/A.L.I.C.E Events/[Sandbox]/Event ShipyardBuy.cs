//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T05:41:47Z", "event":"ShipyardBuy", "ShipType":"krait_mkii", "ShipType_Localised":"Krait MkII", "ShipPrice":38942075, "SellOldShip":"Python", "SellShipID":29, "SellPrice":66502062, "MarketID":3524278272 }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_ShipyardBuy : Base
    {
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public decimal ShipPrice { get; set; }
        public string SellOldShip { get; set; }
        public decimal SellShipID { get; set; }
        public decimal SellPrice { get; set; }
        public decimal MarketID { get; set; }
        public string StoreOldShip { get; set; }
        public decimal StoreShipID { get; set; }

        //Default Constructor
        public ASDF_ShipyardBuy()
        {
            ShipType = Str();
            ShipType_Localised = Str();
            ShipPrice = Dec();
            SellOldShip = Str();
            SellShipID = Dec();
            SellPrice = Dec();
            MarketID = Dec();
            StoreOldShip = Str();
            StoreShipID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_ShipyardBuy : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (ShipyardBuy)O;

                Variables.Switch(Name + "_Type", Event.ShipType_Localised, Event.ShipType);
                Variables.Record(Name + "_PurchasePrice", Event.ShipPrice);
                Variables.Record(Name + "_Market", Event.MarketID);
                Variables.Switch(Name + "_SellPrice", Event.SellPrice, 0);

                switch (Variables.Switch(Name + "_PreviousShip", Event.SellOldShip, Event.StoreOldShip))
                {
                    //Sold Ship
                    case true:
                        Variables.Record(Name + "_PreviousShipID", Event.SellShipID);
                        Variables.Record(Name + "_PreviousShipAction", "Sold");
                        break;

                    //Stored Ship
                    case false:
                        Variables.Record(Name + "_PreviousShipID", Event.StoreShipID);
                        Variables.Record(Name + "_PreviousShipAction", "Stored");
                        break;

                    default:
                        break;
                }                
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }

        //Plugin Logic Process
        public override void Process(object O)
        {
            try
            {
                var Event = (ShipyardBuy)O;

                //Update Status Object
                IStatus.Shipyard.Update(Event);
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}