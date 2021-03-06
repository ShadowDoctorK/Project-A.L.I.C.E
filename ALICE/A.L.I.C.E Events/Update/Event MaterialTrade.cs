//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-10-20T12:28:45Z", "event":"MaterialTrade", "MarketID":3229126144, "TraderType":"manufactured", "Paid":{ "Material":"protoheatradiators", "Material_Localised":"Proto Heat Radiators", "Category":"$MICRORESOURCE_CATEGORY_Manufactured;", "Category_Localised":"Manufactured", "Quantity":6 }, "Received":{ "Material":"heatvanes", "Material_Localised":"Heat Vanes", "Category":"$MICRORESOURCE_CATEGORY_Manufactured;", "Category_Localised":"Manufactured", "Quantity":18 } }

using ALICE_Debug;
using ALICE_Status;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class MaterialTrade : Base
    {
        public decimal MarketID { get; set; }
        public string TraderType { get; set; }
        public TradeMat Paid { get; set; }
        public TradeMat Received { get; set; }

        //Default Constructor
        public MaterialTrade()
        {
            MarketID = Dec();
            TraderType = Str();
            Paid = new TradeMat();
            Received = new TradeMat();
        }

        public class TradeMat : Catch
        {
            public string Material { get; set; }
            public string Material_Localised { get; set; }
            public string Category { get; set; }
            public string Category_Localised { get; set; }
            public decimal Quantity { get; set; }

            public TradeMat()
            {
                Material = Str();
                Material_Localised = Str();
                Category = Str();
                Category_Localised = Str();
                Quantity = Dec();
            }
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_MaterialTrade : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (MaterialTrade)O;

                Variables.Record(Name + "_Market", Event.MarketID);
                Variables.Record(Name + "_Trader", Event.TraderType);

                Variables.Switch(Name + "_PaidMaterial", Event.Paid.Material_Localised, Event.Paid.Material);
                Variables.Switch(Name + "_PaidCatagory", Event.Paid.Category_Localised, Event.Paid.Category);
                Variables.Record(Name + "_PaidQuantity", Event.Paid.Quantity);

                Variables.Switch(Name + "_ReceivedMaterial", Event.Received.Material_Localised, Event.Received.Material);
                Variables.Switch(Name + "_ReceivedCatagory", Event.Received.Category_Localised, Event.Received.Category);
                Variables.Record(Name + "_ReceivedQuantity", Event.Received.Quantity);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment(object O)
        {
            try
            {
                IStatus.Docking.Docked = true;
                ISet.Status.LandingGear(ClassName, true);
                IStatus.Planet.OrbitalMode = false;
                IStatus.Planet.DecentReport = false;
                IStatus.Supercruise = false;
                IStatus.Hyperspace = false;
                IStatus.Touchdown = false;
                IStatus.CargoScoop = false;
                IStatus.Fighter.Deployed = false;
                IStatus.Hardpoints = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}