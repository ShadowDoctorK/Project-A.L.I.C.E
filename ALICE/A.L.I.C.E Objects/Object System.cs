using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Internal;
using ALICE_Events;
using ALICE_Settings;

namespace ALICE_Objects
{
    public class Object_System : Object_Utilities
    {
        #region Properties
        public string Name { get; set; }
        public decimal Address { get; set; }
        public Coordinates Coordinate { get; set; }
        public bool FirstVisit { get; set; }
        public decimal StellarBodies { get; set; }
        public decimal SignalBodies { get; set; }
        public bool AllBodiesFound { get; set; }
        public string Allegiance { get; set; }
        public string PrimaryEconomy { get; set; }        
        public string SecondaryEconomy { get; set; }
        public string Government { get; set; }
        public string Security { get; set; }
        public decimal Population { get; set; }
        public List<string> Powers { get; set; }
        public string PowerplayState { get; set; }
        public string ControlFaction { get; set; }
        public string ControlFactionState { get; set; }
        public Dictionary<string, Object_Factions> Factions { get; set; }
        public Dictionary<decimal, Object_Facility> Facilities { get; set; }
        public Dictionary<decimal, Object_StellarBody> Bodies { get; set; }
        public List<string> CodexEntries { get; set; }

        //Example: 340.0 = Game Version 3.4.0, Alice Game Version Release 0.
        //Example: 341.4 = Game Version 3.4.1, Alice Game Version Release 4.
        public decimal DataVersion { get; set; }
        #endregion

        public Object_System()
        {
            Name = IObjects.String;
            Address = IObjects.Decimal;
            Coordinate = new Coordinates();
            FirstVisit = true;
            StellarBodies = IObjects.Decimal;
            SignalBodies = IObjects.Decimal;
            Allegiance = IObjects.String;
            PrimaryEconomy = IObjects.String;
            SecondaryEconomy = IObjects.String;
            Government = IObjects.String;
            Security = IObjects.String;
            Population = IObjects.Decimal;
            Powers = new List<string>();
            PowerplayState = IObjects.String;
            ControlFaction = IObjects.String;
            ControlFactionState = IObjects.String;
            Factions = new Dictionary<string, Object_Factions>();
            Facilities = new Dictionary<decimal, Object_Facility>();
            Bodies = new Dictionary<decimal, Object_StellarBody>();
            CodexEntries = new List<string>();
            DataVersion = Default.Decimal;
        }

        #region Event Updates
        public Object_System Update_SystemData(FSDJump Event)
        {
            Object_System Temp = Get_SystemData(Event.SystemAddress);
            if (Temp.EventTimeStamp <= Event.Timestamp)
            {
                Temp.Update_TimeStamp(Event.Timestamp);
                Temp.Update_ModifyingEvent(Event.Event);
                Temp.Update_Name(Event.StarSystem);
                Temp.Update_Address(Event.SystemAddress);
                Temp.Update_Coordinate(Event.StarPos);
                Temp.Update_Allegiance(Event.SystemAllegiance);
                Temp.Update_PrimaryEconomy(Event.SystemEconomy_Localised);
                Temp.Update_SecondaryEconomy(Event.SystemSecondEconomy_Localised);
                Temp.Update_Government(Event.SystemGovernment_Localised);
                Temp.Update_Security(Event.SystemSecurity_Localised);
                Temp.Update_Population(Event.Population);
                Temp.Update_Powers(Event.Powers);
                Temp.Update_PowerplayState(Event.PowerplayState);
                Temp.Update_ControlFaction(Event.SystemFaction.Name);
                Temp.Update_ControlFactionState(Event.SystemFaction.FactionState);
                Temp.Update_Factions(Event.Factions, Event.Event, Event.Timestamp);
                Temp.Update_Coordinate(Event.StarPos);
            }
            
            Temp.Update_SystemList();
            return Temp;
        }
        public Object_System Update_SystemData(Location Event)
        {
            Object_System Temp = Get_SystemData(Event.SystemAddress);
            if (Temp.EventTimeStamp <= Event.Timestamp)
            {
                Temp.Update_TimeStamp(Event.Timestamp);
                Temp.Update_ModifyingEvent(Event.Event);
                Temp.Update_Name(Event.StarSystem);
                Temp.Update_Address(Event.SystemAddress);
                Temp.Update_Coordinate(Event.StarPos);
                Temp.Update_Allegiance(Event.SystemAllegiance);
                Temp.Update_PrimaryEconomy(Event.SystemEconomy_Localised);
                Temp.Update_SecondaryEconomy(Event.SystemSecondEconomy_Localised);
                Temp.Update_Government(Event.SystemGovernment_Localised);
                Temp.Update_Security(Event.SystemSecurity_Localised);
                Temp.Update_Population(Event.Population);
                Temp.Update_Powers(Event.Powers);
                Temp.Update_PowerplayState(Event.PowerplayState);
                Temp.Update_ControlFaction(Event.SystemFaction.Name);
                Temp.Update_ControlFactionState(Event.SystemFaction.FactionState);
                Temp.Update_Factions(Event.Factions, Event.Event, Event.Timestamp);
                Temp.Update_Coordinate(Event.StarPos);
            }

            Temp.Update_SystemList();
            return Temp;
        }
        public Object_System Update_SystemData(FSSDiscoveryScan Event)
        {
            string MethodName = "System Data Update";

            Object_System Temp = Get_SystemData(IObjects.SystemCurrent.Address);
            if (Temp.EventTimeStamp <= Event.Timestamp)
            {
                Temp.Update_TimeStamp(Event.Timestamp);
                Temp.Update_ModifyingEvent(Event.Event);
                Temp.StellarBodies = Event.BodyCount;
                Temp.SignalBodies = Event.NonBodyCount;
            }
            Temp.Update_SystemList();
            return Temp;
        }
        public Object_System Update_SystemData(FSSAllBodiesFound Event)
        {
            Object_System Temp = Get_SystemData(IObjects.SystemCurrent.Address);
            if (Temp.EventTimeStamp <= Event.Timestamp)
            {
                Temp.Update_TimeStamp(Event.Timestamp);
                Temp.Update_ModifyingEvent(Event.Event);
                Temp.AllBodiesFound = true;
                Temp.StellarBodies = Event.Count;
            }
            Temp.Update_SystemList();
            return Temp;
        }
        public Object_System Update_CodexEntries(CodexEntry Event)
        {
            Object_System Temp = Get_SystemData(IObjects.SystemCurrent.Address);

            if (Temp.CodexEntries.Contains(Event.Name_Localised) == false)
            {
                Temp.CodexEntries.Add(Event.Name_Localised);
            }
            Temp.Update_SystemList();
            return Temp;
        }
        public Object_System Load(decimal SystemAddress)
        {
            return Get_SystemData(SystemAddress);
        }
        public void Update_StellarBody(SAAScanComplete Event)
        {
            if (Bodies.ContainsKey(Event.BodyID))
            {
                Bodies[Event.BodyID].SurfaceScanned = true;
                Update_SystemList();
            }
            else
            {
                Object_StellarBody Temp = new Object_StellarBody();                  
                Temp.Update_ModfyingEvent(Event.Event);
                Temp.Update_EventTimeStamp(Event.Timestamp);
                Temp.Update_ID(Event.BodyID);
                Temp.Update_Name(Event.BodyName);
                Temp.SurfaceScanned = true;
                Temp.BodyType = "Unknown";

                Bodies.Add(Temp.ID, Temp);
                Update_SystemList();
            }
        }
        public void Update_StellarBody(Scan Event)
        {
            Object_StellarBody Temp = Get_StellarBody(Event.BodyID);

            if (Temp.EventTimeStamp < Event.Timestamp)
            {
                if (Event.BodyName.Contains("A Belt Cluster")) { Temp.BodyType = "Asteroid Belt"; }
                else if (Event.BodyName.Contains(" Ring")) { Temp.BodyType = "Ring"; }
                else if (Event.PlanetClass != Default.String) { Temp.BodyType = "Planet"; }
                else if (Event.StarType != Default.String) { Temp.BodyType = "Star"; }
                else { Temp.BodyType = "Unknown"; }

                Temp.Update_EventTimeStamp(Event.Timestamp);
                Temp.Update_ModfyingEvent(Event.Event);
                Temp.Update_Name(Event.BodyName);
                Temp.Update_ID(Event.BodyID);
                Temp.Update_ScanType(Event.ScanType);
                Temp.Update_DistFromArrival(Event.DistanceFromArrivalLS);
                Temp.Update_TidalLock(Event.TidalLock);
                Temp.Update_TerraformState(Event.TerraformState);
                Temp.Update_PlanetClass(Event.PlanetClass);
                Temp.Update_Atmosphere(Event.Atmosphere);
                Temp.Update_AtmosphereType(Event.AtmosphereType);
                Temp.Update_Volcanism(Event.Volcanism);
                Temp.Update_MassEM(Event.MassEM);
                Temp.Update_StarType(Event.StarType);
                Temp.Update_StellarMass(Event.StellarMass);
                Temp.Update_Radius(Event.Radius);
                Temp.Update_Gravity(Event.SurfaceGravity);
                Temp.Update_AbsoluteMagnitude(Event.AbsoluteMagnitude);
                Temp.Update_Age(Event.Age_MY);
                Temp.Update_Temperature(Event.SurfaceTemperature);
                Temp.Update_Pressure(Event.SurfacePressure);
                Temp.Update_Landable(Event.Landable);
                Temp.Update_Luminosity(Event.Luminosity);
                Temp.Update_SemiMajorAxis(Event.SemiMajorAxis);
                Temp.Update_Eccentricity(Event.Eccentricity);
                Temp.Update_OrbitalInclination(Event.OrbitalInclination);
                Temp.Update_OrbitalPeriod(Event.OrbitalPeriod);
                Temp.Update_Periapsis(Event.Periapsis);
                Temp.Update_RotationPeriod(Event.RotationPeriod);
                Temp.Update_AxialTilt(Event.AxialTilt);
                Temp.Update_ReserveLevel(Event.ReserveLevel);
                Temp.Update_Parents(Event.Parents);
                Temp.Update_AtmosphereComposition(Event.AtmosphereComposition);
                Temp.Update_Materials(Event.Materials);
                Temp.Update_Composition(Event.Composition);
                Temp.Update_Rings(Event.Rings);

                Update_StellarBody(Temp);
            }
        }
        public void Update_Facility(Docked Event)
        {
            IObjects.FacilityPrevious = IObjects.FacilityCurrent;
            IObjects.FacilityCurrent = new Object_Facility();
            IObjects.FacilityCurrent = Get_Facility(Event);

            if (IObjects.FacilityCurrent.EventTimeStamp <= Event.Timestamp)
            {
                IObjects.FacilityCurrent.Update_TimeStamp(Event.Timestamp);
                IObjects.FacilityCurrent.Update_ModifyingEvent(IObjects.StringCheck(Event.Event));
                IObjects.FacilityCurrent.Update_Name(IObjects.StringCheck(Event.StationName));
                IObjects.FacilityCurrent.Update_Type(IObjects.StringCheck(Event.StationType));
                IObjects.FacilityCurrent.Update_System(IObjects.StringCheck(Event.StarSystem));
                IObjects.FacilityCurrent.Update_Address(Event.SystemAddress);
                IObjects.FacilityCurrent.Update_MarketID(Event.MarketID);
                IObjects.FacilityCurrent.Update_ControlFaction(IObjects.StringCheck(Event.StationFaction.Name));
                IObjects.FacilityCurrent.Update_ControlFactionState(IObjects.StringCheck(Event.StationFaction.FactionState));
                IObjects.FacilityCurrent.Update_Government(IObjects.StringCheck(Event.StationGovernment_Localised));
                IObjects.FacilityCurrent.Update_Allegiance(IObjects.StringCheck(Event.StationAllegiance));
                IObjects.FacilityCurrent.Update_Services(Event.StationServices);
                IObjects.FacilityCurrent.Update_Economy(IObjects.StringCheck(Event.StationEconomy_Localised));
                IObjects.FacilityCurrent.Update_DistFromStar(Event.DistFromStarLS);
                IObjects.FacilityCurrent.Update_Economies(Event.StationEconomies);
                IObjects.FacilityCurrent.Update_FacilityType(IObjects.StringCheck(Event.StationType));
            }
            
            IObjects.SystemCurrent.Update_Facility(IObjects.FacilityCurrent);
        }
        public void Update_FirstVisit(decimal SystemAddress)
        {
            Object_System Temp = Get_SystemData(SystemAddress);

            if (Temp.FirstVisit == true)
            {
                Temp.FirstVisit = false;
                Temp.Update_SystemList();
            }
        }
        #endregion

        #region Update Methods
        //System Methods
        public Object_System Get_SystemData(decimal SystemAddress)
        {
            Object_System Temp = new Object_System();
            if (Data.Systems.ContainsKey(SystemAddress))
            { Temp = Data.Systems[SystemAddress]; }
            return Temp;
        }

        public void Update_ModifyingEvent(string EventName) { this.ModfyingEvent = IObjects.StringCheck(EventName); }
        public void Update_TimeStamp(DateTime TimeStamp) { this.EventTimeStamp = TimeStamp; }
        public void Update_Name(string Value) { this.Name = IObjects.StringCheck(Value); }
        public void Update_Address(decimal Value) { this.Address = Value; }
        public void Update_StellarBodies(decimal Value) { this.StellarBodies = Value; }
        public void Update_SignalBodies(decimal Value) { this.SignalBodies = Value; }
        public void Update_Allegiance(string Value) { this.Allegiance = IObjects.StringCheck(Value); }
        public void Update_PrimaryEconomy(string Value) { this.PrimaryEconomy = IObjects.StringCheck(Value); }
        public void Update_SecondaryEconomy(string Value) { this.SecondaryEconomy = IObjects.StringCheck(Value); }
        public void Update_Government(string Value) { this.Government = IObjects.StringCheck(Value); }
        public void Update_Security(string Value) { this.Security = IObjects.StringCheck(Value); }
        public void Update_Population(decimal Value) { this.Population = Value; }
        public void Update_Powers(List<string> Value) { this.Powers = Value; }
        public void Update_PowerplayState(string Value) { this.PowerplayState = IObjects.StringCheck(Value); }
        public void Update_ControlFaction(string Value) { this.ControlFaction = IObjects.StringCheck(Value); }
        public void Update_ControlFactionState(string Value) { this.ControlFactionState = IObjects.StringCheck(Value); }
        public void Update_Coordinate(List<decimal> Value)
        { this.Coordinate.X = Value[0]; this.Coordinate.Y = Value[1]; this.Coordinate.Z = Value[2]; }
        public void Update_Factions(List<FSDJump.Faction> Value, string EventName, DateTime TimeStamp)
        {
            this.Factions = new Dictionary<string, Object_Factions>();
            foreach (var Fact in Value)
            {
                Object_Factions TempFact = new Object_Factions(Fact)
                {
                    EventTimeStamp = TimeStamp,
                    ModfyingEvent = EventName
                };
                Factions.Add(TempFact.Name, TempFact);
            } 
        }
        public void Update_Factions(List<Location.Faction> Value, string EventName, DateTime TimeStamp)
        {
            this.Factions = new Dictionary<string, Object_Factions>();
            foreach (var Fact in Value)
            {
                Object_Factions TempFact = new Object_Factions(Fact);
                TempFact.EventTimeStamp = TimeStamp;
                TempFact.ModfyingEvent = EventName;
                Factions.Add(TempFact.Name, TempFact);
            }
        }
        public void Update_DataVersion() { this.DataVersion = PlugIn.DataVersion; }

        public void Update_SystemList()
        {
            DataVersion = PlugIn.DataVersion;

            if (Data.Systems.ContainsKey(this.Address))
            {
                Data.Systems[this.Address] = this;
            }
            else
            {
                Data.Systems.Add(this.Address, this);
            }

            IObjects.SystemCurrent = Data.Systems[this.Address];

            SaveValues<Object_System>(this, this.Name + ".System", Paths.ALICE_SystemData);
        }

        //Stellar Body Methods
        public Object_StellarBody Get_StellarBody(decimal BodyID)
        {
            Object_StellarBody Temp = new Object_StellarBody();
            if (Bodies.ContainsKey(BodyID)) { Temp = Bodies[BodyID]; }
            return Temp;
        }
        private void Update_StellarBody(Object_StellarBody Body)
        {
            string MethodName = "Stellar Body Update";

            if (Bodies.ContainsKey(Body.ID)) { Bodies[Body.ID] = Body; }
            else { Bodies.Add(Body.ID, Body); }

            Update_SystemList();

            if (PlugIn.ExtendedLogging && Check.Internal.TriggerEvents(true, MethodName, true)) { Log_SystemBodies(); }
        }
        
        //Facility Methods
        public Object_Facility Get_Facility(decimal FacilityMarketID)
        {
            Object_Facility Temp = new Object_Facility();
            if (Facilities.ContainsKey(FacilityMarketID)) { Temp = Facilities[FacilityMarketID]; }
            return Temp;
        }
        public Object_Facility Get_Facility(Docked Event)
        {
            Object_Facility Temp = new Object_Facility(Event);
            if (Facilities.ContainsKey(Event.MarketID)) { Temp = Facilities[Event.MarketID]; }
            return Temp;
        }
        public void Update_Facility(Object_Facility Facility)
        {
            if (Facilities.ContainsKey(Facility.MarketID)) { Facilities[Facility.MarketID] = Facility; }
            else { Facilities.Add(Facility.MarketID, Facility); }

            Update_SystemList();
        }
        #endregion

        #region Utility Methods
        public void Log_SystemBodies()
        {
            int BodyCount = 0;
            if (this.StellarBodies == -1) { return; }

            List<decimal> SortList = Bodies.Keys.ToList(); SortList.Sort(); SortList.Reverse();

            Logger.Basic(" ", Logger.Yellow);
            foreach (var Item in SortList)
            {
                //Landable / Class
                string Type = ""; string Scanned = ""; string Gravity = "";
                
                //Log Only Non-Detail Scanned Planets
                if (ISettings.LogAllBodies == false && Bodies[Item].SurfaceScanned == false)
                {
                    BodyCount++;                    
                    if (Bodies[Item].Landable == true) { Gravity = " | Grav: " + Decimal.Round(Bodies[Item].Gravity, 3); }
                    if (Bodies[Item].PlanetClass != Default.String)
                    {
                        Type = Bodies[Item].PlanetClass.Replace(" content", "").Replace(" body", "");
                        if (Bodies[Item].SurfaceScanned == false) { Scanned = "[  ] "; }
                        else { Scanned = "[X] "; }
                    }
                    else { Type = Bodies[Item].BodyType; }

                    //Geysers on Landable Planets
                    if (Bodies[Item].Volcanism != Default.String && Bodies[Item].Landable == true)
                    { Logger.Basic(Bodies[Item].Volcanism, Logger.Yellow, "----- " + Item); }

                    //Terraformable
                    if (Bodies[Item].PlanetClass != Default.String && Bodies[Item].TerraformState != Default.String)
                    { Logger.Basic(Bodies[Item].TerraformState, Logger.Yellow, "----- " + Item); }

                    Logger.Basic(Scanned + Bodies[Item].Name + " (" + Type + ") " + Gravity, Logger.Yellow, " - ID " + Item);
                }
                //Log All Bodies
                else if (ISettings.LogAllBodies)
                {
                    BodyCount++;
                    if (Bodies[Item].Landable == true) { Gravity = " | Grav: " + Decimal.Round(Bodies[Item].Gravity, 3); }
                    if (Bodies[Item].PlanetClass != Default.String)
                    {
                        Type = Bodies[Item].PlanetClass.Replace(" content", "").Replace(" body", "");
                        if (Bodies[Item].SurfaceScanned == false) { Scanned = "[  ] "; }
                        else { Scanned = "[X] "; }
                    }
                    else { Type = Bodies[Item].BodyType; }

                    //Geysers on Landable Planets
                    if (Bodies[Item].Volcanism != Default.String && Bodies[Item].Landable == true)
                    { Logger.Basic(Bodies[Item].Volcanism, Logger.Yellow, "----- " + Item); }

                    //Terraformable
                    if (Bodies[Item].PlanetClass != Default.String && Bodies[Item].TerraformState != Default.String)
                    { Logger.Basic(Bodies[Item].TerraformState, Logger.Yellow, "----- " + Item); }

                    Logger.Basic(Scanned + Bodies[Item].Name + " (" + Type + ") " + Gravity, Logger.Yellow, " - ID " + Item);
                }
            }

            if (BodyCount == 0) { Logger.Basic("No Sellar Bodies To Display", Logger.Yellow); }

            Logger.Basic(this.Name + " || Fully Scanned: " + this.AllBodiesFound + " ====== ", Logger.Yellow, " ====== System Bodies Update: ");
            Logger.Basic(" ", Logger.Yellow);
        }
        #endregion

        public class Coordinates
        {
            public decimal X { get; set; }
            public decimal Y { get; set; }
            public decimal Z { get; set; }

            public Coordinates()
            { X = IObjects.Decimal; Y = IObjects.Decimal; Z = IObjects.Decimal; }
            public Coordinates(List<decimal> Value)
            { X = Value[0]; Y = Value[1]; Z = Value[2]; }
        }
    }   
}
