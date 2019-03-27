//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 9:56 PM
//Source Journal Line: { "timestamp":"2018-11-21T02:20:36Z", "event":"CodexEntry", "EntryID":1300502, "Name":"$Codex_Ent_TRF_High_Metal_Content_No_Atmos_Name;", "Name_Localised":"Terraformable", "SubCategory":"$Codex_SubCategory_Terrestrials;", "SubCategory_Localised":"Terrestrials", "Category":"$Codex_Category_StellarBodies;", "Category_Localised":"StellarBodies", "Region":"$Codex_RegionName_18;", "Region_Localised":"Inner Orion Spur", "System":"Col 173 Sector KY-Q d5-47", "SystemAddress":1, "IsNewEntry":true }

using ALICE_Objects;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class CodexEntry : Base
    {
        public decimal SystemAddress { get; set; }
        public decimal EntryID { get; set; }
        public bool IsNewEntry { get; set; }
        public decimal VoucherAmount { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public string SubCategory { get; set; }
        public string SubCategory_Localised { get; set; }
        public string Category { get; set; }
        public string Category_Localised { get; set; }
        public string Region { get; set; }
        public string Region_Localised { get; set; }
        public string System { get; set; }

        //Default Constructor
        public CodexEntry()
        {
            EntryID = Dec();
            SystemAddress = Dec();
            Name = Str();
            Name_Localised = Str();
            SubCategory = Str();
            SubCategory_Localised = Str();
            Category = Str();
            Category_Localised = Str();
            Region = Str();
            Region_Localised = Str();
            System = Str();
            IsNewEntry = Bool();
            VoucherAmount = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_CodexEntry : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (CodexEntry)O;

                Variables.Record(Name + "_ID", Event.EntryID);
                Variables.Record(Name + "_System", Event.System);
                Variables.Record(Name + "_Address", Event.SystemAddress);
                Variables.Record(Name + "_Name", Event.Name_Localised);
                Variables.Record(Name + "_NewDiscovery", Event.IsNewEntry);
                Variables.Record(Name + "_Region", Event.Region_Localised);
                Variables.Record(Name + "_Category", Event.Category_Localised);
                Variables.Record(Name + "_SubCategory", Event.SubCategory_Localised);
                Variables.Record(Name + "_Credits", Event.VoucherAmount);
                Variables.Record(Name + "_EDName", Event.Name);
                Variables.Record(Name + "_EDRegion", Event.Region);
                Variables.Record(Name + "_EDSubCategory", Event.SubCategory);
                Variables.Record(Name + "_EDCategory", Event.Category);
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
                var Event = (CodexEntry)O;

                //Process Codex Data
                var Entry = new Object_CodexEntry();
                Entry.Process(Event);

                //Update Current System Information
                IObjects.SystemCurrent.Update_CodexEntries(Event);
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}
