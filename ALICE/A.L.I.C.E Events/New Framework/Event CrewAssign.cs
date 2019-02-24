//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-26T10:17:05Z", "event":"CrewAssign", "Name":"Mackenzie Witt", "CrewID":257296352, "Role":"OnShoreLeave" }

using ALICE_Core;
using ALICE_Internal;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_CrewAssign : Base
    {
        public string Name { get; set; }
        public decimal CrewID { get; set; }
        public string Role { get; set; }

        //Default Constructor
        public ASDF_CrewAssign()
        {
            Name = Str();
            CrewID = Dec();
            Role = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_CrewAssign : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (CrewAssign)O;

                Variables.Record(Name + "_Name", Event.Name);
                Variables.Record(Name + "_ID", Event.CrewID);
                Variables.Record(Name + "_DutyStatus", Event.Role);
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
                var Event = (CrewAssign)O;

                //Update Status Object
                IStatus.Crew.Update(Event);

                //Active Duty Audio
                IStatus.Crew.Response.ActiveDuty(
                    Check.Internal.TriggerEvents(true, ClassName));     //Check Log Has Initialized

                //On Shore Leave Audio
                IStatus.Crew.Response.OnShoreLeave(
                    Check.Internal.TriggerEvents(true, ClassName));     //Check Log Has Initialized
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}
