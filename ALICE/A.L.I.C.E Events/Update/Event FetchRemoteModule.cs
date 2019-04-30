//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-10-30T23:00:09Z", "event":"FetchRemoteModule", "StorageSlot":104, "StoredItem":"$int_modulereinforcement_size4_class2_name;", "StoredItem_Localised":"Module Reinforcement", "ServerId":128737277, "TransferCost":329, "TransferTime":463, "Ship":"typex", "ShipID":59 }

using ALICE_Debug;
using ALICE_Status;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class FetchRemoteModule : Base
    {
        public decimal StorageSlot { get; set; }
        public string StoredItem { get; set; }
        public string StoredItem_Localised { get; set; }
        public decimal ServerId { get; set; }
        public decimal TransferCost { get; set; }
        public decimal TransferTime { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }

        //Default Constructor
        public FetchRemoteModule()
        {
            StorageSlot = Dec();
            StoredItem = Str();
            StoredItem_Localised = Str();
            ServerId = Dec();
            TransferCost = Dec();
            TransferTime = Dec();
            Ship = Str();
            ShipID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_FetchRemoteModule : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (FetchRemoteModule)O;

                Variables.Record(Name + "_Storage", Event.StorageSlot);
                Variables.Record(Name + "_Module", Event.StoredItem_Localised);
                Variables.Record(Name + "_Cost", Event.TransferCost);
                Variables.Record(Name + "_Time", Event.TransferTime);
                Variables.Record(Name + "_Ship", Event.Ship);
                Variables.Record(Name + "_ShipID", Event.ShipID);
                Variables.Record(Name + "_EDModule", Event.StoredItem);
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
                ISet.Status.LandingGear(ClassName, true);
                IStatus.Docking.Docked = true;
                IStatus.Supercruise = false;
                IStatus.Hyperspace = false;
                IStatus.Touchdown = false;
                IStatus.Hardpoints = false;
                IStatus.Fighter.Deployed = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}