using ALICE_Core;
using ALICE_Events;
using ALICE_Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Objects
{
    public class Object_CodexEntry : Object_Utilities
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Region { get; set; }
        public string Body { get; set; }
        public string Enviornment { get; set; }
        public decimal CodexID { get; set; }
        public decimal Address { get; set; }
        public string System { get; set; }
        public string EDCategory { get; set; }
        public string EDSubCategory { get; set; }
        public string EDName { get; set; }
        public string EDRegion { get; set; }

        public Object_CodexEntry()
        {
            EventTimeStamp = Default.DTime;
            ModfyingEvent = Default.String;
            Name = Default.String;
            Category = Default.String;
            Region = Default.String;
            SubCategory = Default.String;
            Body = Get_Body();
            Enviornment = Get_Enviornment();
            CodexID = Default.Decimal;
            Address = Get_Address();
            System = Get_System();
            EDCategory = Default.String;
            EDName = Default.String;
            EDRegion = Default.String;
            EDSubCategory = Default.String;
        }

        public void Process(CodexEntry Event)
        {
            EventTimeStamp = Event.Timestamp;
            ModfyingEvent = Event.Event;
            Name = Event.Name_Localised;
            Category = Event.Category_Localised;
            Region = Event.Region_Localised;
            SubCategory = Event.SubCategory_Localised;
            CodexID = Event.EntryID;
            EDCategory = Event.Category;
            EDName = Event.Name;
            EDRegion = Event.Region;
            EDSubCategory = Event.SubCategory;

            if (Data.CodexEntries.ContainsKey(this.CodexID) == false)
            {
                Data.CodexEntries.Add(this.CodexID, this);
            }

            Check_EntryType(this.EDName);
            Save_CodexEntry(this.CodexID, this.Name);
        }

        public decimal Get_Address()
        {
            return IObjects.SystemCurrent.Address;
        }

        public string Get_System()
        {
            return IObjects.SystemCurrent.Name;
        }

        public string Get_Body()
        {
            string Temp = Get.Event.SupercruiseExit.Body();            
            if (Temp == null) { Temp = Default.String; }
            return Temp;
        }

        public string Get_Enviornment()
        {            
            return Get.Environment.Space();
        }

        public void Check_EntryType(string EDName)
        {
            string MethodName = "Codex Entry Type";

            IEnums.CodexEntry Temp = Utilities.ToEnum<IEnums.CodexEntry>(EDName.Replace("$", "").Replace(";", ""));

            switch (Temp)
            {
                case IEnums.CodexEntry.Codex_Ent_Standard_Sudarsky_Class_III_Name:
                    break;

                case IEnums.CodexEntry.Codex_Ent_L_Cry_MetCry_Red_Name:
                    break;

                case IEnums.CodexEntry.Codex_Ent_L_Cry_MetCry_Pur_Name:
                    break;

                case IEnums.CodexEntry.Codex_Ent_L_Cry_MetCry_Gr_Name:
                    break;

                case IEnums.CodexEntry.Codex_Ent_Gas_Clds_Light_Name:
                    break;

                case IEnums.CodexEntry.Codex_Ent_Fumarole_SulphurDioxideMagma_Name:
                    break;

                case IEnums.CodexEntry.Codex_Ent_IceFumarole_WaterGeysers_Name:
                    break;

                default:
                    Logger.DevUpdateLog(MethodName, EDName + "Is Not Being Tracked Or Is A New Item", Logger.Red, true);
                    break;
            }
        }

        public void Save_CodexEntry(decimal CodexID, string Name)
        {
            string FileName = CodexID + " - " + Name + ".Codex";
            string Path = Paths.ALICE_CodexDiscoveries;
            if (Utilities.CheckDirectory(Path))
            {
                if (File.Exists(Path + FileName)) { return; }
                SaveValues<Object_CodexEntry>(this, FileName, Path);
            }
        }

        //public void Save_Anomaly()
        //{
        //    string FileName = this.CodexID + " - " + this.Name;
        //    string Path = Paths.ALICE_Anomalies + this.System + @"\";
        //    if (Utilities.CheckDirectory(Path))
        //    {
        //        if (File.Exists(Path + FileName)) { return; }
        //        SaveValues<Object_CodexEntry>(this, FileName, Path);
        //    }
        //}
    }
}
