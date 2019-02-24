//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-30T02:29:40Z", "event":"MissionFailed", "Name":"Mission_Massacre_Conflict_War_name", "MissionID":429329489 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_MissionFailed : Base
    {
        public string Name { get; set; }
        public decimal MissionID { get; set; }

        //Default Constructor
        public ASDF_MissionFailed()
        {
            Name = Str();
            MissionID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_MissionFailed : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (MissionFailed)O;

                Variables.Record(Name + "_Name", Event.Name);
                Variables.Record(Name + "_ID", Event.MissionID);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}