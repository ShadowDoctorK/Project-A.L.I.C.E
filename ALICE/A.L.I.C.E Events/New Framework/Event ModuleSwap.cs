//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-28T15:40:20Z", "event":"ModuleSwap", "MarketID":3221503744, "FromSlot":"Slot08_Size4", "ToSlot":"Slot10_Size3", "FromItem":"$int_cargorack_size3_class1_name;", "FromItem_Localised":"Cargo Rack", "ToItem":"Null", "Ship":"federation_corvette", "ShipID":11 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_ModuleSwap : Base
    {
        public decimal MarketID { get; set; }
        public string FromSlot { get; set; }
        public string ToSlot { get; set; }
        public string FromItem { get; set; }
        public string FromItem_Localised { get; set; }
        public string ToItem { get; set; }
        public string ToItem_Localised { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }

        //Default Constructor
        public ASDF_ModuleSwap()
        {
            MarketID = Dec();
            FromSlot = Str();
            ToSlot = Str();
            FromItem = Str();
            FromItem_Localised = Str();
            ToItem = Str();
            ToItem_Localised = Str();
            Ship = Str();
            ShipID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_ModuleSwap : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (ModuleSwap)O;

                Variables.Record(Name + "_MarketID", Event.MarketID);
                Variables.Record(Name + "_FromSlot", GetSlot(Event.FromSlot, false));
                Variables.Record(Name + "_ToSlot", GetSlot(Event.ToSlot, false));
                Variables.Record(Name + "_FromItem", Event.FromItem);
                Variables.Record(Name + "_ToItem", Event.ToItem);
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