//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T05:41:49Z", "event":"ShipyardNew", "ShipType":"krait_mkii", "ShipType_Localised":"Krait MkII", "NewShipID":29 }

using ALICE_Status;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ShipyardNew : Base
    {
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public decimal NewShipID { get; set; }

        //Default Constructor
        public ShipyardNew()
        {
            ShipType = Str();
            ShipType_Localised = Str();
            NewShipID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_ShipyardNew : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (ShipyardNew)O;

                Variables.Switch(Name + "_Type", Event.ShipType_Localised, Event.ShipType);
                Variables.Record(Name + "_ID", Event.NewShipID);
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
                var Event = (ShipyardNew)O;

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