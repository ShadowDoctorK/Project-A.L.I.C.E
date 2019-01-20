//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-28T15:57:14Z", "event":"ShipTargeted", "TargetLocked":true, "Ship":"typex_2", "Ship_Localised":"Alliance Crusader", "ScanStage":3, "PilotName":"$npc_name_decorate:#name=Patrick Augusto Fraioli;", "PilotName_Localised":"Patrick Augusto Fraioli", "PilotRank":"Competent", "ShieldHealth":100.000000, "HullHealth":100.000000, "Faction":"Kao Kach Purple Energy PLC", "LegalStatus":"Wanted", "Bounty":63187, "Subsystem":"$int_dronecontrol_resourcesiphon_size3_class3_name;", "Subsystem_Localised":"Hatch Breaker", "SubsystemHealth":100.000000 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_ShipTargeted : Event_Base
    {
        public Event_ShipTargeted()
        {
            Name = "ShipTargeted";
        }

        public void Logic()
        {
            if (IEvents.WriteVariables && WriteVariables)
            {
                try
                {
                    Variables_Clear();
                    Variables_Generate();
                    Variables_Write();
                }
                catch (Exception ex)
                {
                    Logger.Exception(Name, "An Exception Occured While Updating Variables");
                    Logger.Exception(Name, "Exception: " + ex);
                }
            }

            IObjects.Logic_ShipTargeted((ShipTargeted)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            ShipTargeted Event = (ShipTargeted)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("TargetLocked", Event.TargetLocked.Variable());
            Variable_Craft("Ship", Event.Ship.Variable());
            Variable_Craft("Ship_Localised", Event.Ship_Localised.Variable());
            Variable_Craft("ScanStage", Event.ScanStage.Variable());
            Variable_Craft("PilotName", Event.PilotName.Variable());
            Variable_Craft("PilotName_Localised", Event.PilotName_Localised.Variable());
            Variable_Craft("PilotRank", Event.PilotRank.Variable());
            Variable_Craft("ShieldHealth", Event.ShieldHealth.Variable());
            Variable_Craft("HullHealth", Event.HullHealth.Variable());
            Variable_Craft("Faction", Event.Faction.Variable());
            Variable_Craft("LegalStatus", Event.LegalStatus.Variable());
            Variable_Craft("Bounty", Event.Bounty.Variable());
            Variable_Craft("Subsystem", Event.Subsystem.Variable());
            Variable_Craft("Subsystem_Localised", Event.Subsystem_Localised.Variable());
            Variable_Craft("SubsystemHealth", Event.SubsystemHealth.Variable());
            #endregion
        }
    }

    #region ShipTargeted Event
    public class ShipTargeted : Base
    {
        public bool TargetLocked { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public decimal ScanStage { get; set; }
        public string PilotName { get; set; }
        public string PilotName_Localised { get; set; }
        public string PilotRank { get; set; }
        public decimal ShieldHealth { get; set; }
        public decimal HullHealth { get; set; }
        public string Faction { get; set; }
        public string LegalStatus { get; set; }
        public decimal Bounty { get; set; }
        public string Subsystem { get; set; }
        public string Subsystem_Localised { get; set; }
        public decimal SubsystemHealth { get; set; }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == ShipTargeted)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.ShipTargeted>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }
