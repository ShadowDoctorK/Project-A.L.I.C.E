//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-03T04:15:57Z", "event":"MaterialCollected", "Category":"Manufactured", "Name":"guardian_sentinel_wreckagecomponents", "Name_Localised":"Guardian Wreckage Components", "Count":3 }

using ALICE_Core;
using ALICE_Internal;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_MaterialCollected : Base
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public decimal Count { get; set; }

        //Default Constructor
        public ASDF_MaterialCollected()
        {
            Category = Str();
            Name = Str();
            Name_Localised = Str();
            Count = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_MaterialCollected : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (MaterialCollected)O;

                Variables.Record(Name + "_Catagory", Event.Category);
                Variables.Switch(Name + "_Name", Event.Name_Localised, Event.Name);
                Variables.Record(Name + "_Count", Event.Count);
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
                var Event = (MaterialCollected)O;

                IStatus.Materials.Response.Collected(
                        Event.Name,                                        //Material
                        Check.Internal.TriggerEvents(true, ClassName),     //Check Plugin Initialized
                        Check.Report.MaterialCollected(true, ClassName));  //Check Material Reports Enabled 
            }
            catch (Exception ex)
            {
                ExceptionProcess(ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment()
        {
            IStatus.Hyperspace = false;
        }
    }
}