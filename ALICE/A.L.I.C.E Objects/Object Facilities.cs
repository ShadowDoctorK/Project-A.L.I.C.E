using ALICE_Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Objects
{
    public class Object_Facility : Object_Base
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string System { get; set; }
        public decimal Address { get; set; }
        public decimal MarketID { get; set; }
        public string ControlFaction { get; set; }
        public string ControlFactionState { get; set; }
        public string Government { get; set; }
        public string Allegiance { get; set; }
        public List<string> Services { get; set; }
        public string Economy { get; set; }
        public List<StationEconomy> Economies { get; set; }
        public decimal DistFromStar { get; set; }
        public bool Station { get; set; }
        public bool Settlement { get; set; }
        public bool AsteroidBase { get; set; }
        public bool UnknownType { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public Object_Facility()
        {
            Name = IObjects.String;
            Type = IObjects.String;
            System = IObjects.String;
            Address = IObjects.Decimal;
            MarketID = IObjects.Decimal;
            ControlFaction = IObjects.String;
            ControlFactionState = IObjects.String;
            Government = IObjects.String;
            Allegiance = IObjects.String;
            Services = new List<string>();
            Economy = IObjects.String;
            Economies = new List<StationEconomy>();
            DistFromStar = IObjects.Decimal;
            Station = IObjects.False;
            Settlement = IObjects.False;
            AsteroidBase = IObjects.False;
            Latitude = IObjects.Decimal;
            Longitude = IObjects.Decimal;            
        }

        public Object_Facility(Docked Event)
        {
            Name = IObjects.StringCheck(Event.StationName);
            Type = IObjects.StringCheck(Event.StationType);
            System = IObjects.StringCheck(Event.StarSystem);
            Address = Event.SystemAddress;
            MarketID = Event.MarketID;
            ControlFaction = IObjects.StringCheck(Event.StationFaction);
            ControlFactionState = IObjects.StringCheck(Event.FactionState);
            Government = IObjects.StringCheck(Event.StationGovernment_Localised);
            Allegiance = IObjects.StringCheck(Event.StationAllegiance);
            Services = Event.StationServices;
            Economy = IObjects.StringCheck(Event.StationEconomy_Localised);
            Economies = new List<StationEconomy>();
            foreach (var Item in Event.StationEconomies)
            {
                Economies.Add(new StationEconomy(Item));
            }
            DistFromStar = Event.DistFromStarLS;
            Station = IObjects.False;
            Settlement = IObjects.False;
            AsteroidBase = IObjects.False;
            Latitude = IObjects.Decimal;
            Longitude = IObjects.Decimal;
        }

        public class StationEconomy
        {
            public string Name { get; set; }
            public decimal Proportion { get; set; }

            public StationEconomy()
            {
                Name = IObjects.String;
                Proportion = IObjects.Decimal;
            }

            public StationEconomy(Docked.StationEco StationEconomy)
            {
                Name = IObjects.StringCheck(StationEconomy.Name_Localised);
                Proportion = StationEconomy.Proportion;
            }
        }

        public void Update_ModifyingEvent(string EventName) { this.ModfyingEvent = IObjects.StringCheck(EventName); }
        public void Update_TimeStamp(DateTime TimeStamp) { this.EventTimeStamp = TimeStamp; }
        public void Update_Name(string Value) { this.Name = Value; }
        public void Update_Type(string Value) { this.Type = Value; }
        public void Update_System(string Value) { this.System = Value; }
        public void Update_Address(decimal Value) { this.Address = Value; }
        public void Update_MarketID(decimal Value) { this.MarketID = Value; }
        public void Update_ControlFaction(string Value) { this.ControlFaction = Value; }
        public void Update_ControlFactionState(string Value) { this.ControlFactionState = Value; }
        public void Update_Government(string Value) { this.Government = Value; }
        public void Update_Allegiance(string Value) { this.Allegiance = Value; }
        public void Update_Services(List<string> Value) { this.Services = Value; }
        public void Update_Economy(string Value) { this.Economy = Value; }
        public void Update_DistFromStar(decimal Value) { this.DistFromStar = Value; }
        public void Update_Economies(List<Docked.StationEco> Value)
        {
            List<StationEconomy> Temp = new List<StationEconomy>();
            foreach (var Item in Value)
            { Temp.Add(new StationEconomy(Item)); }
            this.Economies = Temp;
        }

        public void Update_FacilityType(string FacilityType)
        {
            switch (FacilityType)
            {
                case "Bernal":
                    Station = true;
                    break;
                case "Orbis":
                    Station = true;
                    break;
                case "Coriolis":
                    Station = true;
                    break;
                case "Ocellus":
                    Station = true;
                    break;
                case "Outpost":
                    Station = true;
                    break;
                case "CraterOutpost":
                    Settlement = true;
                    break;
                case "AsteroidBase":
                    AsteroidBase = true;
                    break;
                default:
                    UnknownType = true;
                    break;
            }
        }
        public void Update_Position() { }
    }
}
