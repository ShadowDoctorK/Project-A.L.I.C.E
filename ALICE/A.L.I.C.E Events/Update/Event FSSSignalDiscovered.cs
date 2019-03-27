//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/21/2018 10:41 PM
//Source Journal Line: { "timestamp":"2018-11-22T02:28:11Z", "event":"FSSSignalDiscovered", "SystemAddress":560216394091, "SignalName":"$USS;", "SignalName_Localised":"Unidentified signal source", "USSType":"$USS_Type_ValuableSalvage;", "USSType_Localised":"Encoded emissions", "SpawningState":"$FactionState_None;", "SpawningState_Localised":"None", "SpawningFaction":"$faction_none;", "SpawningFaction_Localised":"None", "ThreatLevel":0, "TimeRemaining":1715.851929 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class FSSSignalDiscovered : Base
    {
        public decimal SystemAddress { get; set; }
        public string SignalName { get; set; }
        public string SignalName_Localised { get; set; }
        public string USSType { get; set; }
        public string USSType_Localised { get; set; }
        public string SpawningState { get; set; }
        public string SpawningState_Localised { get; set; }
        public string SpawningFaction { get; set; }
        public string SpawningFaction_Localised { get; set; }
        public decimal ThreatLevel { get; set; }
        public decimal TimeRemaining { get; set; }
        public bool IsStation { get; set; }

        //Default Constructor
        public FSSSignalDiscovered()
        {
            SignalName = Str();
            SignalName_Localised = Str();
            USSType = Str();
            USSType_Localised = Str();
            SpawningState = Str();
            SpawningState_Localised = Str();
            SpawningFaction = Str();
            SpawningFaction_Localised = Str();
            ThreatLevel = Dec();
            TimeRemaining = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_FSSSignalDiscovered : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (FSSSignalDiscovered)O;

                Variables.Record(Name + "_Address", Event.SystemAddress);
                Variables.Record(Name + "_Name", Event.SignalName_Localised);
                Variables.Record(Name + "_USSType", Event.USSType_Localised);
                Variables.Record(Name + "_State", Event.SpawningState_Localised);
                Variables.Record(Name + "_Faction", Event.SpawningFaction_Localised);
                Variables.Switch(Name + "_Threat", Event.ThreatLevel, "0");
                Variables.Switch(Name + "_Lifetime", Event.TimeRemaining, "No Expiration");
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}