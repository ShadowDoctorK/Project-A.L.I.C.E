namespace ALICE_Settings
{
    using ALICE_Status;

    public static class Settings
    {
        public static Mothership Mothership
        {
            get => IStatus.Mothership;
            set => IStatus.Mothership = value;
        }
    }
}

namespace ALICE_Status
{
    using ALICE_Debug;
    using ALICE_Events;
    using ALICE_Internal;
    using ALICE_Settings;
    using System;

    public static partial class IStatus
    {
        public static Mothership Mothership { get; set; } = new Mothership();
    }

    public class Mothership
    {
        private readonly string C = "Mothership";

        /// <summary>
        /// Allows tracking and control for updating older data version when updates occur.
        /// </summary>
        public string DataVersion = "1.0.0";                        //Custom
        public DateTime Updated { get; set; }                       //Custom  
        public string EventName { get; set; }                       //Custom

        public decimal ID { get; set; }                             //Loadout Event
        public string Name { get; set; }                            //Loadout Event
        public string Type { get; set; }                            //Loadout Event
        public string Identifier { get; set; }                      //Loadout Event
        public decimal UnladenMass { get; set; }                    //Loadout Event
        public decimal CargoCapacity { get; set; }                  //Loadout Event
        public decimal MaxJumpRange { get; set; }                   //Loadout Event
        public ValueData Value { get; set; }                        //Loadout Event
        public FuelData Fuel { get; set; }                          //Multi Source
        public string FingerPrint                                   //Derived
        {
            get => ID + " " + Type + " (" + IStatus.Commander + ")";
        }

        public Modules Module { get; set; } = new Modules();

        public Mothership()
        {
            EventName = "Default";
            ID = -1;
            Name = "Default";
            Type = "None";
            Identifier = "None";
            UnladenMass = -1;
            CargoCapacity = -1;
            MaxJumpRange = -1;
            Value = new ValueData();
            Fuel = new FuelData();
        }

        public void Update(LoadGame Event)
        {
            //Check Vehicle Is Mothership
            if (IStatus.Vehicle != IStatus.V.Mothership) { return; }

            //Check Event Was After Last Update
            if (Updated >= Event.Timestamp) { return; }

            //Update Ship Information
            ID = Event.ShipID;
            Name = Event.ShipName;
            Type = Event.Ship;
            Identifier = Event.ShipIdent;
            Fuel.Capacity = Event.FuelCapacity;

            //Object Tracking
            Updated = Event.Timestamp;
            EventName = Event.Event;
        }

        public void Update(Loadout Event)
        {
            //Check Vehicle Is Mothership
            if (IStatus.Vehicle != IStatus.V.Mothership) { return; }

            //Check Event Was After Last Update
            if (Updated >= Event.Timestamp) { return; }

            //Update Ship Information
            ID = Event.ShipID;
            Name = Event.ShipName;
            Type = Event.Ship;
            Identifier = Event.ShipIdent;
            UnladenMass = Event.UnladenMass;
            CargoCapacity = Event.CargoCapacity;
            MaxJumpRange = Event.MaxJumpRange;
            Value.Hull = Event.HullValue;
            Value.Modules = Event.ModulesValue;
            Value.Rebuy = Event.Rebuy;
            Fuel.Capacity = Event.FuelCapacity.Main;
            Fuel.Reservior = Event.FuelCapacity.Reserve;

            //Update Modules
            Module = new Modules(Event);

            //Object Tracking
            Updated = Event.Timestamp;
            EventName = Event.Event;

            //Update Ship
            ISettings.Shipyard.UpdateShip(
                C,                                      //Method Name
                IStatus.Commander,                      //Commander Name
                ID,                                     //Ship ID
                ISettings.Shipyard.Convert(C, Event));  //Loadout Event String

            //Save Shipyard
            ISettings.Shipyard.Save();
        }

        public void Update(SetUserShipName Event)
        {       
            //Check Initialized
            if (ICheck.Initialized(C) == false) { return; }

            //Check Change Required
            if (Name == Event.UserShipName) { return; }

            //Check Event Was After Last Update
            if (Updated > Event.Timestamp) { return; }

            try
            {
                //Check Ship ID
                if (Event.ShipID != ID)
                {
                    Logger.Log(C, "Unable To Resovle Ship Name Change. ID's Don't Match. Ship: " + ID + " | Event: " + Event.ShipID, Logger.Red);
                    return;
                }

                //Delete Old Settings File

                //Update Name & Ident
                Name = Event.UserShipName;
                Identifier = Event.UserShipId;

                //Save New Settings File
                Updated = Event.Timestamp;
                EventName = Event.Event;
            }
            catch (Exception ex)
            {
                Logger.Exception(C, "Exception " + ex);
                Logger.Exception(C, "Exception Occured When Updating Ships Information");
            }

        }

        private string GetFingerPrint(string ID, string Type)
        {
            return ID + " " + Type + " (" + IStatus.Commander + ")";
        }

        public class ValueData
        {
            public decimal Total { get => Hull + Modules; }
            public decimal Hull { get; set; }               //Loadout Event
            public decimal Modules { get; set; }            //Loadout Event
            public decimal Rebuy { get; set; }              //Loadout Event
        }      
    }   
}