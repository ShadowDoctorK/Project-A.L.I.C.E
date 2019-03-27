//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-28T15:57:14Z", "event":"ShipTargeted", "TargetLocked":true, "Ship":"typex_2", "Ship_Localised":"Alliance Crusader", "ScanStage":3, "PilotName":"$npc_name_decorate:#name=Patrick Augusto Fraioli;", "PilotName_Localised":"Patrick Augusto Fraioli", "PilotRank":"Competent", "ShieldHealth":100.000000, "HullHealth":100.000000, "Faction":"Kao Kach Purple Energy PLC", "LegalStatus":"Wanted", "Bounty":63187, "Subsystem":"$int_dronecontrol_resourcesiphon_size3_class3_name;", "Subsystem_Localised":"Hatch Breaker", "SubsystemHealth":100.000000 }

using ALICE_Actions;
using ALICE_Objects;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ShipTargeted : Base
    {
        //Stage 0:
        public bool TargetLocked { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public decimal ScanStage { get; set; }

        //Stage 1:
        public string PilotName { get; set; }
        public string PilotName_Localised { get; set; }
        public string PilotRank { get; set; }

        //Stage 2:
        public decimal ShieldHealth { get; set; }
        public decimal HullHealth { get; set; }

        //Stage 3:
        public string Faction { get; set; }
        public string LegalStatus { get; set; }
        public decimal Bounty { get; set; }
        public string Subsystem { get; set; }
        public string Subsystem_Localised { get; set; }
        public decimal SubsystemHealth { get; set; }

        //Default Constructor
        public ShipTargeted()
        {
            TargetLocked = Bool();
            Ship = Str();
            Ship_Localised = Str();
            ScanStage = Dec();
            PilotName = Str();
            PilotName_Localised = Str();
            PilotRank = Str();
            ShieldHealth = Dec();
            HullHealth = Dec();
            Faction = Str();
            LegalStatus = Str();
            Bounty = Dec();
            Subsystem = Str();
            Subsystem_Localised = Str();
            SubsystemHealth = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_ShipTargeted : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (ShipTargeted)O;

                Variables.Record(Name + "_TargetLocked", Event.TargetLocked);
                Variables.Switch(Name + "_Ship", Event.Ship_Localised, Event.Ship);
                Variables.Record(Name + "_ScanStage", Event.ScanStage);
                Variables.Switch(Name + "_Pilot", Event.PilotName_Localised, Event.PilotName);
                Variables.Record(Name + "_Rank", Event.PilotRank);
                Variables.Record(Name + "_Shields", Event.ShieldHealth);
                Variables.Record(Name + "_Hull", Event.HullHealth);
                Variables.Record(Name + "_Faction", Event.Faction);
                Variables.Record(Name + "_LegalStatus", Event.LegalStatus);
                Variables.Switch(Name + "_Bounty", Event.Bounty, 0);
                Variables.Switch(Name + "_Subsystem", Event.Subsystem_Localised, Event.Subsystem);
                Variables.Record(Name + "_SubsystemHealth", Event.SubsystemHealth);
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
                var Event = (ShipTargeted)O;

                //Update Current Target Object
                IObjects.TargetCurrent.Process(Event);

                //Targeting System Update
                if (Event.TargetLocked == true)
                {
                    Assisted.Targeting.Wait_Targeted = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}