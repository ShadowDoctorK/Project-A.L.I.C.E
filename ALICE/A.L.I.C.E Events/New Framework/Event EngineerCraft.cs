//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-11-08T10:45:21Z", "event":"EngineerCraft", "Slot":"PowerDistributor", "Module":"int_powerdistributor_size6_class5", "Ingredients":[ { "Name":"industrialfirmware", "Name_Localised":"Cracked Industrial Firmware", "Count":1 }, { "Name":"fedproprietarycomposites", "Name_Localised":"Proprietary Composites", "Count":1 }, { "Name":"militarysupercapacitors", "Name_Localised":"Military Supercapacitors", "Count":1 } ], "Engineer":"The Dweller", "EngineerID":300180, "BlueprintID":128673734, "BlueprintName":"PowerDistributor_HighCapacity", "Level":5, "Quality":0.176000, "Modifiers":[ { "Label":"Integrity", "Value":156.091202, "OriginalValue":124.000000, "LessIsGood":0 }, { "Label":"WeaponsCapacity", "Value":68.434998, "OriginalValue":50.000000, "LessIsGood":0 }, { "Label":"WeaponsRecharge", "Value":4.264000, "OriginalValue":5.200000, "LessIsGood":0 }, { "Label":"EnginesCapacity", "Value":47.904503, "OriginalValue":35.000000, "LessIsGood":0 }, { "Label":"EnginesRecharge", "Value":2.624000, "OriginalValue":3.200000, "LessIsGood":0 }, { "Label":"SystemsCapacity", "Value":47.904503, "OriginalValue":35.000000, "LessIsGood":0 }, { "Label":"SystemsRecharge", "Value":2.624000, "OriginalValue":3.200000, "LessIsGood":0 } ] }

using ALICE_Core;
using System;
using System.Collections.Generic;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_EngineerCraft : Base
    {
        public string Slot { get; set; }
        public string Module { get; set; }
        public string ApplyExperimentalEffect { get; set; }
        public string Engineer { get; set; }
        public decimal EngineerID { get; set; }
        public string BlueprintName { get; set; }
        public decimal BlueprintID { get; set; }
        public decimal Level { get; set; }
        public decimal Quality { get; set; }
        public string ExperimentalEffect { get; set; }
        public string ExperimentalEffect_Localised { get; set; }
        public List<CraftModifier> Modifiers { get; set; }
        public List<CraftIngredient> Ingredients { get; set; }

        //Default Constructor
        public ASDF_EngineerCraft()
        {
            Slot = Str();
            Module = Str();
            ApplyExperimentalEffect = Str();
            Engineer = Str();
            EngineerID = Dec();
            BlueprintName = Str();
            BlueprintID = Dec();
            Level = Dec();
            Quality = Dec();
            ExperimentalEffect = Str();
            ExperimentalEffect_Localised = Str();
            Modifiers = new List<CraftModifier>();
            Ingredients = new List<CraftIngredient>();
        }

        public class CraftModifier : Catch
        {
            public string Label { get; set; }
            public decimal Value { get; set; }
            public decimal OriginalValue { get; set; }
            public bool LessIsGood { get; set; }
            public string ValueStr { get; set; }
            public string ValueStr_Localised { get; set; }

            public CraftModifier()
            {
                Label = Str();
                Value = Dec();
                OriginalValue = Dec();
                LessIsGood = Bool();
                ValueStr = Str();
                ValueStr_Localised = Str();
            }
        }

        public class CraftIngredient : Catch
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public decimal Count { get; set; }

            public CraftIngredient()
            {
                Name = Str();
                Name_Localised = Str();
                Count = Dec();
            }
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_EngineerCraft : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (EngineerCraft)O;

                Variables.Record(Name + "_Engineer", Event.Engineer);
                Variables.Record(Name + "_ID", Event.EngineerID);
                Variables.Record(Name + "_Module", Event.Module);
                Variables.Record(Name + "_Slot", Event.Slot);
                Variables.Record(Name + "_Blueprint", Event.BlueprintName);
                Variables.Record(Name + "_BlueprintID", Event.BlueprintID);
                Variables.Record(Name + "_Level", Event.Level);
                Variables.Record(Name + "_Quality", Event.Quality);
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
                var Event = (EngineerCraft)O;
            }
            catch (Exception ex)
            {
                ExceptionProcess(ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment()
        {
            IStatus.Supercruise = false;
            IStatus.Hyperspace = false;
            IStatus.Touchdown = false;
            IStatus.Docking.Docked = true;
            IStatus.Hardpoints = false;
            IStatus.LandingGear = true;
            IStatus.Fighter.Deployed = false;
        }
    }
}