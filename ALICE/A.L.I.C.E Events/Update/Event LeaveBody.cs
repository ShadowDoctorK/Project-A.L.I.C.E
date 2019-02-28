//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-14T23:16:32Z", "event":"LeaveBody", "StarSystem":"Col 173 Sector KY-Q d5-47", "SystemAddress":1625603164499, "Body":"Col 173 Sector KY-Q d5-47 8 c", "BodyID":24 }

using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class LeaveBody : Base
    {
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public string Body { get; set; }
        public decimal BodyID { get; set; }

        //Default Constructor
        public LeaveBody()
        {
            StarSystem = Str();
            SystemAddress = Dec();
            Body = Str();
            BodyID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_LeaveBody : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (LeaveBody)O;

                Variables.Record(Name + "_System", Event.StarSystem);
                Variables.Record(Name + "_Address", Event.SystemAddress);
                Variables.Record(Name + "_Name", Event.Body);
                Variables.Record(Name + "_ID", Event.BodyID);                
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
                var Event = (LeaveBody)O;

                //Update Status Object
                IStatus.Planet.OrbitalCruise(false);

                //Orbital Cruise Exit Audio
                IStatus.Planet.Response.OrbitaCruiseExit(
                    ICheck.Initialized(ClassName));         //Check Plugin Initialized
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment(object O)
        {
            try
            {
                IStatus.Touchdown = false;
                IStatus.LandingGear = false;
                IStatus.Hyperspace = false;
                IStatus.Docking.Docked = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}