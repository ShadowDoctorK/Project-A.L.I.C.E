//Code Generated By CMDR Shadow Doctor K
//Class File Generated: 02/26/2019 8:59 PM
//Source Journal Line: (Custom A.L.I.C.E Event)
//Reference Journal Line: { "timestamp":"2018-10-11T19:32:41Z", "event":"ReceiveText", "From":"Rayhan al-Biruni Orbital", "Message":"$STATION_NoFireZone_entered;", "Message_Localised":"No fire zone entered.", "Channel":"npc" }
//Reference Journal Line: { "timestamp":"2018-10-11T19:24:25Z", "event":"ReceiveText", "From":"Hennen Station", "Message":"$STATION_NoFireZone_exited;", "Message_Localised":"No fire zone left.", "Channel":"npc" }

using ALICE_Actions;
using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Response;
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
        public NoFireZone I { get; set; } = new NoFireZone();

        //Construct Custom Event
        public void Construct(ReceiveText Event)
        {
            try
            {
                I = new NoFireZone()
                {
                    Event = "NoFireZone",
                    Timestamp = Event.Timestamp,
                    Station = Event.From,
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

        //Construct Custom Event
        public void Construct(SupercruiseExit Event)
        {
            try
            {
                I = new NoFireZone()
                {
                    Event = "NoFireZone",
                    Timestamp = Event.Timestamp,
                    Station = "Unknown",
                    Status = false,
                    Message = "SupercruiseExit"
                };

                if (Event.BodyType == "Station")
                {
                    I.Station = Event.Body;
                }

                Record(Name, I);
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
                    IResponse.Docking.NoFireZoneEntered(
                        I.Station,                                                  //Pass Station Name
                        ICheck.Initialized(ClassName));                             //Check Plugin Initialized

                    Thread.Sleep(100);

                    //Check Weapons Safeties
                    if (ICheck.Order.WeaponSafety(ClassName, true, true) && ICheck.Initialized(ClassName))
                    {
                        //Enable Safeies
                        IStatus.WeaponSafety = true;

                        //Swtich To Analysis Mode
                        IActions.Hardpoints.Mode(true, true);                        

                        //Check Hardpoints
                        if (ICheck.Status.Hardpoints(ClassName, true) == true)
                        {
                            //Store Hardpoints
                            IActions.Hardpoints.Operate(false, false);

                            //Audio - Enabling Weapon Safeties (Deployed)
                            IResponse.Docking.WeaponSafetiesEnablingDeployed(
                                ICheck.Initialized(ClassName));                     //Check Plugin Initialized

                            return;
                        }

                        //Audio - Enabling Weapon Safeties
                        IResponse.Docking.WeaponSafetiesEnabling(
                            ICheck.Initialized(ClassName));                         //Check Plugin Initialized
                    }
                }

                //Exiting No Fire Zone
                else if (I.Status == false)
                {
                    IStatus.WeaponSafety = false;

                    //Audio - Exited No Fire Zone
                    IResponse.Docking.NoFireZoneExited(
                        I.Station,                                                  //Pass Station Name
                        ICheck.Initialized(ClassName));                             //Check Plugin Initialized

                    Thread.Sleep(100);

                    if (ICheck.Order.WeaponSafety(ClassName, true, true))
                    {
                        //Audio - Disabling Weapon Safeties
                        IResponse.Docking.WeaponSafetiesDisabling(
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