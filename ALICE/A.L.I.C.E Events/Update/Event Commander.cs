//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T02:31:19Z", "event":"Commander", "Name":"Shadow Doctor K" }

using ALICE_Settings;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Commander : Base
    {
        public string Name { get; set; }
        public string FID { get; set; }

        //Default Constructor
        public Commander()
        {
            Name = Str();
            FID = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_Commander : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (Commander)O;

                Variables.Record(Name + "_Name", Event.Name);
                Variables.Record(Name + "_ID", Event.FID);
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
                var Event = (Commander)O;

                //Load Commander Settings
                ISettings.U_Commander(ClassName, Event.Name);
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}