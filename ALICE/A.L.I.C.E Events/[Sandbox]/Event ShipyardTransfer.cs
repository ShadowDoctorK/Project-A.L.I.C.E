//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-14T04:06:20Z", "event":"ShipyardTransfer", "ShipType":"Anaconda", "ShipID":5, "System":"Nankul", "ShipMarketID":3221644800, "Distance":10.294160, "TransferPrice":105577, "TransferTime":402, "MarketID":3221503744 }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_ShipyardTransfer : Base
    {
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public decimal ShipID { get; set; }
        public string System { get; set; }
        public decimal ShipMarketID { get; set; }
        public decimal Distance { get; set; }
        public decimal TransferPrice { get; set; }
        public decimal TransferTime { get; set; }
        public decimal MarketID { get; set; }

        //Default Constructor
        public ASDF_ShipyardTransfer()
        {
            ShipType = Str();
            ShipType_Localised = Str();
            ShipID = Dec();
            System = Str();
            ShipMarketID = Dec();
            Distance = Dec();
            TransferPrice = Dec();
            TransferTime = Dec();
            MarketID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_ShipyardTransfer : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (ShipyardTransfer)O;

                Variables.Switch(Name + "_Type", Event.ShipType_Localised, Event.ShipType);
                Variables.Record(Name + "_ID", Event.ShipID);
                Variables.Record(Name + "_System", Event.System);
                Variables.Record(Name + "_FromMarket", Event.ShipMarketID);
                Variables.Record(Name + "_ToMarket", Event.MarketID);
                Variables.Record(Name + "_Distance", Event.Distance);
                Variables.Record(Name + "_Price", Event.TransferPrice);
                Variables.Record(Name + "_Time", Event.TransferTime);
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
                var Event = (ShipyardTransfer)O;

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