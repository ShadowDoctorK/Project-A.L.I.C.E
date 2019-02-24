//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2019-01-25T22:02:06Z", "event":"Location", "Docked":true, "StationName":"Haxel Port", "StationType":"Bernal", "MarketID":3230440960, "StationFaction":{ "Name":"Democrats of LTT 15574", "FactionState":"Investment" }, "StationGovernment":"$government_Democracy;", "StationGovernment_Localised":"Democracy", "StationAllegiance":"Federation", "StationServices":[ "Dock", "Autodock", "BlackMarket", "Commodities", "Contacts", "Exploration", "Missions", "Outfitting", "CrewLounge", "Rearm", "Refuel", "Repair", "Shipyard", "Tuning", "Workshop", "MissionsGenerated", "FlightController", "StationOperations", "Powerplay", "SearchAndRescue", "MaterialTrader", "StationMenu" ], "StationEconomy":"$economy_Industrial;", "StationEconomy_Localised":"Industrial", "StationEconomies":[ { "Name":"$economy_Industrial;", "Name_Localised":"Industrial", "Proportion":0.770000 }, { "Name":"$economy_Extraction;", "Name_Localised":"Extraction", "Proportion":0.230000 } ], "StarSystem":"LTT 15574", "SystemAddress":670149191105, "StarPos":[-55.93750,1.93750,63.59375], "SystemAllegiance":"Federation", "SystemEconomy":"$economy_Industrial;", "SystemEconomy_Localised":"Industrial", "SystemSecondEconomy":"$economy_Extraction;", "SystemSecondEconomy_Localised":"Extraction", "SystemGovernment":"$government_Democracy;", "SystemGovernment_Localised":"Democracy", "SystemSecurity":"$SYSTEM_SECURITY_high;", "SystemSecurity_Localised":"High Security", "Population":10712223, "Body":"Haxel Port", "BodyID":70, "BodyType":"Station", "Factions":[ { "Name":"Democrats of LTT 15574", "FactionState":"Investment", "Government":"Democracy", "Influence":0.263736, "Allegiance":"Federation", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Happy", "MyReputation":100.000000, "ActiveStates":[ { "State":"Investment" } ] }, { "Name":"LFT 1448 Independents", "FactionState":"None", "Government":"Democracy", "Influence":0.300699, "Allegiance":"Federation", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Happy", "MyReputation":100.000000, "RecoveringStates":[ { "State":"War", "Trend":0 } ] }, { "Name":"Pilots Federation Local Branch", "FactionState":"None", "Government":"Democracy", "Influence":0.000000, "Allegiance":"PilotsFederation", "Happiness":"", "MyReputation":50.096100 }, { "Name":"Revolutionary Party of Chamunda", "FactionState":"None", "Government":"Democracy", "Influence":0.102897, "Allegiance":"Federation", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Happy", "MyReputation":100.000000, "PendingStates":[ { "State":"War", "Trend":0 } ] }, { "Name":"LTT 15574 Regulatory State", "FactionState":"None", "Government":"Dictatorship", "Influence":0.018981, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Happy", "MyReputation":3.000000 }, { "Name":"Gold United Systems", "FactionState":"None", "Government":"Corporate", "Influence":0.102897, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Happy", "MyReputation":23.553699, "PendingStates":[ { "State":"War", "Trend":0 } ] }, { "Name":"LTT 15574 Holdings", "FactionState":"None", "Government":"Corporate", "Influence":0.080919, "Allegiance":"Federation", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Happy", "MyReputation":100.000000, "RecoveringStates":[ { "State":"War", "Trend":0 } ] }, { "Name":"LTT 15574 Focus", "FactionState":"None", "Government":"Dictatorship", "Influence":0.056943, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Happy", "MyReputation":5.103000 }, { "Name":"Brotherhood of the Dragon", "FactionState":"None", "Government":"Corporate", "Influence":0.072927, "Allegiance":"Federation", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Happy", "MyReputation":18.226601 } ], "SystemFaction":{ "Name":"Democrats of LTT 15574", "FactionState":"Investment" } }

using ALICE_Core;
using ALICE_Internal;
using ALICE_Objects;
using System;
using System.Collections.Generic;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_Location : Base
    {
        //Docked State
        public bool Docked { get; set; }

        //Position Data
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        //Station Data
        public string StationName { get; set; }
        public string StationType { get; set; }
        public decimal MarketID { get; set; }
        public FactionData StationFaction { get; set; }
        public string StationGovernment { get; set; }
        public string StationGovernment_Localised { get; set; }
        public string StationAllegiance { get; set; }
        public List<string> StationServices { get; set; }
        public string StationEconomy { get; set; }
        public string StationEconomy_Localised { get; set; }
        public List<EconomyData> StationEconomies { get; set; }

        //System Data
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public List<decimal> StarPos { get; set; }
        public string SystemAllegiance { get; set; }
        public string SystemEconomy { get; set; }
        public string SystemEconomy_Localised { get; set; }
        public string SystemSecondEconomy { get; set; }
        public string SystemSecondEconomy_Localised { get; set; }
        public string SystemGovernment { get; set; }
        public string SystemGovernment_Localised { get; set; }
        public string SystemSecurity { get; set; }
        public string SystemSecurity_Localised { get; set; }
        public decimal Population { get; set; }
        public string Body { get; set; }
        public decimal BodyID { get; set; }
        public string BodyType { get; set; }
        public List<Faction> Factions { get; set; }
        public FactionData SystemFaction { get; set; }
        public List<string> Powers { get; set; }
        public string PowerplayState { get; set; }

        //Default Constructor
        public ASDF_Location()
        {
            //Docked State
            Docked = Bool();

            //Position Data
            Latitude = Dec();
            Longitude = Dec();

            //Station Data
            StationName = Str();
            StationType = Str();
            MarketID = Dec();
            StationFaction = new FactionData();
            StationGovernment = Str();
            StationGovernment_Localised = Str();
            StationAllegiance = Str();
            StationServices = new List<string>();
            StationEconomy = Str();
            StationEconomy_Localised = Str();
            StationEconomies = new List<EconomyData>();

            //System Data
            StarSystem = Str();
            SystemAddress = Dec();
            StarPos = new List<decimal>();
            SystemAllegiance = Str();
            SystemEconomy = Str();
            SystemEconomy_Localised = Str();
            SystemSecondEconomy = Str();
            SystemSecondEconomy_Localised = Str();
            SystemGovernment = Str();
            SystemGovernment_Localised = Str();
            SystemSecurity = Str();
            SystemSecurity_Localised = Str();
            Population = Dec();
            Body = Str();
            BodyID = Dec();
            BodyType = Str();
            Factions = new List<Faction>();
            SystemFaction = new FactionData();
            Powers = new List<string>();
            PowerplayState = Str();
        }

        public class Faction : Catch
        {
            public string Name { get; set; }
            public string FactionState { get; set; }
            public string Government { get; set; }
            public decimal Influence { get; set; }
            public string Allegiance { get; set; }
            public string Happiness { get; set; }
            public string Happiness_Localised { get; set; }
            public decimal MyReputation { get; set; }
            public List<States> ActiveStates { get; set; }
            public List<States> RecoveringStates { get; set; }
            public List<States> PendingStates { get; set; }

            public Faction()
            {
                Name = Str();
                FactionState = Str();
                Government = Str();
                Influence = Dec();
                Allegiance = Str();
                Happiness = Str();
                Happiness_Localised = Str();
                MyReputation = Dec();
                ActiveStates = new List<States>();
                PendingStates = new List<States>();
                RecoveringStates = new List<States>();
            }
        }

        public class EconomyData : Catch
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public decimal Proportion { get; set; }

            public EconomyData()
            {
                Name = Str();
                Name_Localised = Str();
                Proportion = Dec();
            }
        }

        public class FactionData : Catch
        {
            public string Name { get; set; }
            public string FactionState { get; set; }

            public FactionData()
            {
                Name = Str();
                FactionState = Str();
            }
        }

        public class States : Catch
        {
            public string State { get; set; }
            public decimal Trend { get; set; }

            public States()
            {
                State = Str();
                Trend = Dec();
            }
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_Location : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (Location)O;

                //Docked State
                Variables.Record(Name + "_Docked", Event.Docked);

                //Position Date
                Variables.Record(Name + "_Latitude", Event.Latitude);
                Variables.Record(Name + "_Longitude", Event.Longitude);
                Variables.Record(Name + "_BodyName", Event.Body);                
                Variables.Record(Name + "_BodyType", Event.BodyType);

                //Station Data
                Variables.Record(Name + "_StationName", Event.StationName);
                Variables.Record(Name + "_StationType", Event.StationType);
                Variables.Record(Name + "_Market", Event.MarketID);
                Variables.Record(Name + "_StationFaction", Event.StationFaction.Name);
                Variables.Record(Name + "_StationState", Event.StationFaction.FactionState);
                Variables.Record(Name + "_StationGovernment", Event.StationGovernment_Localised);
                Variables.Record(Name + "_StationAllegiance", Event.StationAllegiance);
                Variables.Record(Name + "_StationEconomy", Event.StationEconomy_Localised);

                //System Data
                Variables.Record(Name + "_SystemName", Event.StarSystem);
                Variables.Record(Name + "_SystemAddress", Event.SystemAddress);                
                Variables.Record(Name + "_SystemFaction", Event.SystemFaction.Name);
                Variables.Record(Name + "_SystemState", Event.SystemFaction.FactionState);
                Variables.Record(Name + "_SystemSecurity", Event.SystemSecurity_Localised);
                Variables.Record(Name + "_SystemGovernment", Event.SystemGovernment_Localised);
                Variables.Record(Name + "_SystemAllegiance", Event.SystemAllegiance);
                Variables.Record(Name + "_SystemPrimaryEconomy", Event.SystemEconomy_Localised);
                Variables.Record(Name + "_SystemSecondaryEconomy", Event.SystemSecondEconomy_Localised);
                Variables.Switch(Name + "_SystemPopulation", Event.Population, 0);
                Variables.Switch(Name + "_SystemPower1", Event.Powers, 0, "None");
                Variables.Switch(Name + "_SystemPower2", Event.Powers, 1, "None");
                Variables.Record(Name + "_SystemPowerplayState", Event.PowerplayState);
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
                var Event = (Location)O;

                //Update Docked State
                IStatus.Docking.Update(Event);

                //Update Current System Object
                IObjects.SysetmPrevious = IObjects.SystemCurrent;                
                IObjects.SystemCurrent = IObjects.SystemCurrent.Update_SystemData(Event);
                
                //Extended Logging
                IStatus.Docking.Log.Status();
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}