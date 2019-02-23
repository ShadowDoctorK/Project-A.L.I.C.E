//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-30T04:28:32Z", "event":"FSDJump", "StarSystem":"Willapa", "SystemAddress":16063848785345, "StarPos":[-11.68750,-10.81250,65.56250], "SystemAllegiance":"Independent", "SystemEconomy":"$economy_Agri;", "SystemEconomy_Localised":"Agriculture", "SystemSecondEconomy":"$economy_Colony;", "SystemSecondEconomy_Localised":"Colony", "SystemGovernment":"$government_Corporate;", "SystemGovernment_Localised":"Corporate", "SystemSecurity":"$SYSTEM_SECURITY_high;", "SystemSecurity_Localised":"High Security", "Population":3105800092, "Powers":[ "Yuri Grom" ], "PowerplayState":"Exploited", "JumpDist":13.512, "FuelUsed":6.441426, "FuelLevel":22.980717, "Factions":[ { "Name":"Pilots Federation Local Branch", "FactionState":"None", "Government":"Democracy", "Influence":0.000000, "Allegiance":"PilotsFederation" }, { "Name":"Kokojina Jet Federal Limited", "FactionState":"Boom", "Government":"Corporate", "Influence":0.056000, "Allegiance":"Federation", "PendingStates":[ { "State":"Outbreak", "Trend":-1 } ] }, { "Name":"Willapa Resistance", "FactionState":"None", "Government":"Democracy", "Influence":0.102000, "Allegiance":"Independent", "PendingStates":[ { "State":"CivilWar", "Trend":0 } ] }, { "Name":"New Mambojas Labour", "FactionState":"None", "Government":"Democracy", "Influence":0.028000, "Allegiance":"Federation", "PendingStates":[ { "State":"Boom", "Trend":1 } ] }, { "Name":"Crimson Creative Network", "FactionState":"CivilWar", "Government":"Corporate", "Influence":0.137000, "Allegiance":"Federation", "PendingStates":[ { "State":"Boom", "Trend":1 }, { "State":"Famine", "Trend":0 } ], "RecoveringStates":[ { "State":"Outbreak", "Trend":0 } ] }, { "Name":"Willapa Solutions", "FactionState":"Boom", "Government":"Corporate", "Influence":0.413000, "Allegiance":"Independent", "PendingStates":[ { "State":"Outbreak", "Trend":1 } ] }, { "Name":"Willapa Defence Party", "FactionState":"Boom", "Government":"Dictatorship", "Influence":0.102000, "Allegiance":"Independent", "PendingStates":[ { "State":"Outbreak", "Trend":0 }, { "State":"CivilWar", "Trend":0 } ] }, { "Name":"Willapa Drug Empire", "FactionState":"CivilWar", "Government":"Anarchy", "Influence":0.077000, "Allegiance":"Independent", "PendingStates":[ { "State":"Outbreak", "Trend":1 } ], "RecoveringStates":[ { "State":"Boom", "Trend":0 } ] }, { "Name":"Redsheep Corporation", "FactionState":"None", "Government":"Corporate", "Influence":0.085000, "Allegiance":"Independent" } ], "SystemFaction":"Willapa Solutions", "FactionState":"Boom" }

using ALICE_Actions;
using ALICE_Core;
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
    public class ASDF_FSDJump : Base
    {
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
        public List<string> Powers { get; set; }
        public string PowerplayState { get; set; }
        public decimal JumpDist { get; set; }
        public decimal FuelUsed { get; set; }
        public decimal FuelLevel { get; set; }
        public decimal BoostUsed { get; set; }
        public List<Faction> Factions { get; set; }
        public FactionData SystemFaction { get; set; }

        //Default Constructor
        public ASDF_FSDJump()
        {
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
            Powers = new List<string>();
            PowerplayState = Str();
            JumpDist = Dec();
            FuelUsed = Dec();
            FuelLevel = Dec();
            BoostUsed = Dec();
            Factions = new List<Faction>();
            SystemFaction = new FactionData();
        }

        public class Faction : Catch
        {
            public string Name { get; set; }
            public string FactionState { get; set; }
            public string Government { get; set; }
            public decimal Influence { get; set; }
            public string Allegiance { get; set; }
            public string Happiness { get; set; }
            public decimal MyReputation { get; set; }
            public string Happiness_Localised { get; set; }
            public List<States> RecoveringStates { get; set; }
            public List<States> ActiveStates { get; set; }
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
                PendingStates = new List<States>();
                RecoveringStates = new List<States>();
                ActiveStates = new List<States>();
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
    public class QWER_FSDJump : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (FSDJump)O;

                Variables.Record(Name + "_System", Event.StarSystem);
                Variables.Record(Name + "_Address", Event.SystemAddress);
                Variables.Record(Name + "_Allegiance", Event.SystemAllegiance);
                Variables.Record(Name + "_Government", Event.SystemGovernment_Localised);
                Variables.Record(Name + "_PrimaryEconomy", Event.SystemEconomy_Localised);
                Variables.Record(Name + "_SecondaryEconomy", Event.SystemSecondEconomy_Localised);
                Variables.Record(Name + "_Security", Event.SystemSecurity_Localised);
                Variables.Record(Name + "_JumpDistance", Event.JumpDist);
                Variables.Record(Name + "_FuelLevel", Event.FuelLevel);
                Variables.Record(Name + "_FuelUsed", Event.FuelUsed);
                Variables.Record(Name + "_Faction", Event.SystemFaction.Name);
                Variables.Record(Name + "_State", Event.SystemFaction.FactionState);
                Variables.Record(Name + "_PowerplayState", Event.PowerplayState);
                Variables.Switch(Name + "_Population", Event.Population, 0);
                Variables.Switch(Name + "_Power1", Event.Powers, 0, "None");
                Variables.Switch(Name + "_Power2", Event.Powers, 1, "None");
            }
            catch (Exception ex)
            {
                ExceptionGenerate(ex);
            }
        }

        //Plugin Logic Process
        public override void Process(object O)
        {
            try
            {
                var Event = (FSDJump)O;

                //Save Previous Systems Information
                IObjects.SysetmPrevious = IObjects.SystemCurrent;

                //Check Arrival Report
                IStatus.System.TargetArrival(Event);

                //Check System Status & Update Current System Object
                IStatus.System.Status(Event);

                //Post Jump Safeties
                if (Check.Order.PostJumpSafety(true, ClassName))
                {
                    Call.Key.Press(Call.Key.Set_Speed_To_0, 0);
                }

                //Fuel Status Report
                IEquipment.FuelTank.ScoopingReset();
                if (Check.Report.FuelStatus(true, ClassName) == true)
                {
                    IEquipment.FuelTank.Report = true;
                }

                //Sleep
                Thread.Sleep(100);

                //Assisted System Scans
                IEquipment.DiscoveryScanner.FirstScan = true;
                IEquipment.DiscoveryScanner.Scan();

            }
            catch (Exception ex)
            {
                ExceptionProcess(ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment()
        {                        
            IStatus.WeaponSafety = false;
            IStatus.Planet.OrbitalMode = false;
            IStatus.Planet.DecentReport = false;
            IStatus.Supercruise = true;
            IStatus.Hyperspace = false;
            IStatus.Touchdown = false;
            IStatus.Docking.Docked = false;
            IStatus.LandingGear = false;
            IStatus.CargoScoop = false;
            IStatus.Fighter.Deployed = false;
            IStatus.Hardpoints = false;
        }
    }
}