//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2019-01-25T22:02:06Z", "event":"Docked", "StationName":"Haxel Port", "StationType":"Ocellus", "StarSystem":"LTT 15574", "SystemAddress":670149191105, "MarketID":3230440960, "StationFaction":{ "Name":"Democrats of LTT 15574", "FactionState":"Investment" }, "StationGovernment":"$government_Democracy;", "StationGovernment_Localised":"Democracy", "StationAllegiance":"Federation", "StationServices":[ "Dock", "Autodock", "BlackMarket", "Commodities", "Contacts", "Exploration", "Missions", "Outfitting", "CrewLounge", "Rearm", "Refuel", "Repair", "Shipyard", "Tuning", "Workshop", "MissionsGenerated", "FlightController", "StationOperations", "Powerplay", "SearchAndRescue", "MaterialTrader", "StationMenu" ], "StationEconomy":"$economy_Industrial;", "StationEconomy_Localised":"Industrial", "StationEconomies":[ { "Name":"$economy_Industrial;", "Name_Localised":"Industrial", "Proportion":0.770000 }, { "Name":"$economy_Extraction;", "Name_Localised":"Extraction", "Proportion":0.230000 } ], "DistFromStarLS":716.390076 }

using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Objects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Docked : Base
    {
        public string StationName { get; set; }
        public string StationType { get; set; }
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public decimal MarketID { get; set; }
        public FactionData StationFaction { get; set; }
        public string StationGovernment { get; set; }
        public string StationGovernment_Localised { get; set; }
        public string StationAllegiance { get; set; }
        public List<string> StationServices { get; set; }
        public string StationEconomy { get; set; }
        public string StationEconomy_Localised { get; set; }
        public List<EconomyData> StationEconomies { get; set; }
        public decimal DistFromStarLS { get; set; }
        public bool CockpitBreach { get; set; }
        public bool Wanted { get; set; }
        public bool ActiveFine { get; set; }

        //Default Constructor
        public Docked()
        {
            StationName = Str();
            StationType = Str();
            StarSystem = Str();
            SystemAddress = Dec();
            MarketID = Dec();
            StationFaction = new FactionData();
            StationGovernment = Str();
            StationGovernment_Localised = Str();
            StationAllegiance = "Independant";
            StationServices = new List<string>();
            StationEconomy = Str();
            StationEconomy_Localised = Str();
            StationEconomies = new List<EconomyData>();
            DistFromStarLS = Dec();
            CockpitBreach = Bool();
            Wanted = Bool();
            ActiveFine = Bool();
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
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_Docked : Event
    {
        //Event Instance
        private Docked i = new Docked();
        public Docked I
        {
            get => i;
            set=> i = value;
        }

        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                Variables.Record(Name + "_Station", I.StationName);
                Variables.Record(Name + "_Type", I.StationType);
                Variables.Record(Name + "_System", I.StarSystem);
                Variables.Record(Name + "_Address", I.SystemAddress);
                Variables.Record(Name + "_Market", I.MarketID);
                Variables.Record(Name + "_Faction", I.StationFaction.Name);
                Variables.Record(Name + "_State", I.StationFaction.FactionState);
                Variables.Record(Name + "_Government", I.StationGovernment_Localised);
                Variables.Record(Name + "_Allegiance", I.StationAllegiance);
                Variables.Record(Name + "_Economy", I.StationEconomy_Localised);
                Variables.Record(Name + "_CokpitBreach", I.CockpitBreach);
                Variables.Record(Name + "_Wanted", I.Wanted);
                Variables.Record(Name + "_ActiveFine", I.ActiveFine);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }

        //Plugin Logic Preparations
        public override void Prepare(object O)
        {
            try
            {
                //Update Event Instance
                I = (Docked)O;
            }
            catch (Exception ex)
            {
                ExceptionPrepare(Name, ex);
            }
        }

        //Plugin Logic Process
        public override void Process(object O)
        {
            try
            {
                //Update Current System Object
                IObjects.SystemCurrent.Update_Facility(I);

                //Docked Datalink Audio
                IStatus.Docking.Response.Datalink(
                    ICheck.Report.StationStatus(ClassName, true, true),         //Check User Settings Report Enabled
                    ICheck.Initialized(ClassName),                              //Check Plugin Initialized
                    (IStatus.Docking.State == IEnums.DockingState.Granted));    //Check Docking State Is Granted

                //Sleep To Maintain Audio Order
                Thread.Sleep(100);

                //Docked Datalink Audio
                IStatus.Docking.Response.StationStatus(
                    ICheck.Report.StationStatus(ClassName, true, true),         //Check User Settings Report Enabled
                    ICheck.Initialized(ClassName),                              //Check Plugin Initialized
                    (IStatus.Docking.State == IEnums.DockingState.Granted));    //Check Docking State Is Granted

                //Enter Station Services & Conduct Post Docking Actions
                IStatus.Docking.PostDockingActions();
                IStatus.Docking.Update(I);

                //Extended Logging
                IStatus.Docking.Log.Status();
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment(object O)
        {
            try
            {
                IVehicles.Vehicle = IVehicles.V.Mothership;
                IStatus.Hardpoints = false;
                IStatus.Touchdown = false;
                IStatus.LandingGear = true;
                IStatus.Fighter.Deployed = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}