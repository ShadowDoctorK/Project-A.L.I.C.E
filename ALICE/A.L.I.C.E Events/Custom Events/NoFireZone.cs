//Code Generated By CMDR Shadow Doctor K
//Class File Generated: 02/26/2019 8:59 PM
//Source Journal Line: (Custom A.L.I.C.E Event)
//Reference Journal Line: { "timestamp":"2018-10-11T19:32:41Z", "event":"ReceiveText", "From":"Rayhan al-Biruni Orbital", "Message":"$STATION_NoFireZone_entered;", "Message_Localised":"No fire zone entered.", "Channel":"npc" }
//Reference Journal Line: { "timestamp":"2018-10-11T19:24:25Z", "event":"ReceiveText", "From":"Hennen Station", "Message":"$STATION_NoFireZone_exited;", "Message_Localised":"No fire zone left.", "Channel":"npc" }

using ALICE_Actions;
using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using System;
using System.Threading;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class NoFireZone : Base
    {
        public bool Status { get; set; }
        public string Station { get; set; }
        public string Message { get; set; }

        //Default Constructor
        public NoFireZone()
        {
            Status = Bool();
            Station = "The Station";
            Message = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_NoFireZone : Event
    {
        //Event Instance
        private NoFireZone i = new NoFireZone();
        public NoFireZone I
        {
            get => i;
            set => i = value;
        }

        //Construct Custom Event
        public void Construct(ReceiveText Event)
        {
            try
            {
                I = new NoFireZone()
                {
                    Event = "NoFireZone",
                    Timestamp = Event.Timestamp,
                    Station = "Unknown",
                    Status = false,
                    Message = Event.Message
                };

                if (Event.Message.Contains("entered"))
                {
                    I.Status = true;
                }                

                Record(Name, I);
                Logic();
            }
            catch (Exception ex)
            {
                ExceptionConstruct(Name, ex);
            }
        }

        //Construct Custom Event
        public void Construct(SupercruiseEntry Event)
        {
            try
            {
                I = new NoFireZone()
                {
                    Event = "NoFireZone",
                    Timestamp = Event.Timestamp,
                    Station = "Unknown",
                    Status = false,
                    Message = "SupercruiseEntry"
                };

                Record(Name, I);
                Logic();
            }
            catch (Exception ex)
            {
                ExceptionConstruct(Name, ex);
            }
        }

        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                Variables.Record(Name + "_Status", I.Status);
                Variables.Record(Name + "_Station", I.Station);
                Variables.Record(Name + "_Message", I.Message);
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
                //Entering No Fire Zone
                if (I.Status == true)
                {
                    IEvents.FireInNoFireZone.I.FirstReport = true;

                    //Audio - Entered No Fire Zone
                    IStatus.Docking.Response.NoFireZoneEntered(
                        I.Station,                                                  //Pass Station Name
                        ICheck.Initialized(ClassName));                             //Check Plugin Initialized

                    Thread.Sleep(100);

                    if (ICheck.Order.WeaponSafety(ClassName, true))
                    {
                        IStatus.WeaponSafety = true;
                        Call.Action.AnalysisMode(true, false);

                        if (Check.Variable.Hardpoints(true, ClassName) == true)
                        {
                            Call.Action.Hardpoint(false, false);

                            //Audio - Enabling Weapon Safeties (Deployed)
                            IStatus.Docking.Response.WeaponSafetiesEnablingDeployed(
                                ICheck.Initialized(ClassName));                     //Check Plugin Initialized

                            return;
                        }

                        //Audio - Enabling Weapon Safeties
                        IStatus.Docking.Response.WeaponSafetiesEnablingDeployed(
                            ICheck.Initialized(ClassName));                         //Check Plugin Initialized
                    }
                }

                //Exiting No Fire Zone
                else if (I.Status == false)
                {
                    IStatus.WeaponSafety = false;

                    //Audio - Exited No Fire Zone
                    IStatus.Docking.Response.NoFireZoneExited(
                        I.Station,                                                  //Pass Station Name
                        ICheck.Initialized(ClassName));                             //Check Plugin Initialized

                    Thread.Sleep(100);

                    if (ICheck.Order.WeaponSafety(ClassName, true))
                    {
                        //Audio - Disabling Weapon Safeties
                        IStatus.Docking.Response.WeaponSafetiesDisabling(
                            ICheck.Initialized(ClassName));                         //Check Plugin Initialized
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}