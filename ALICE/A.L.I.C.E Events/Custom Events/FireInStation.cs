//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 12:20 AM
//Source Journal Line: (Custom A.L.I.C.E Event)
//Reference Journal Line: { "timestamp":"2018-11-22T17:11:53Z", "event":"CommitCrime", "CrimeType":"fireInStation", "Faction":"Eureka Mining Co-Operative", "Bounty":100 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class FireInStation : Base
    {
        public string Violation { get; set; }
        public string Faction { get; set; }
        public string Charge { get; set; }
        public decimal Amount { get; set; }

        //Default Constructor
        public FireInStation()
        {
            Violation = Str();
            Faction = Str();
            Charge = Str();
            Amount = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_FireInStation : Event
    {
        //Event Instance
        public FireInStation I { get; set; } = new FireInStation();

        //Construct Event
        public void Construct(CommitCrime Event)
        {
            try
            {
                I = new FireInStation()
                {
                    Event = "FireInStation",
                    Timestamp = Event.Timestamp,
                    Faction = Event.Faction
                };

                if (Event.CrimeType.Contains("Minor"))
                {
                    I.Violation = "Minor";
                }
                else if (Event.CrimeType.Contains("Major"))
                {
                    I.Violation = "Major";
                }
                else
                {
                    I.Violation = "Unknown";
                }

                if (Event.Fine != -1)
                {
                    I.Charge = "Fine";
                    I.Amount = Event.Fine;
                }
                else if (Event.Bounty != -1)
                {
                    I.Charge = "Bounty";
                    I.Amount = Event.Bounty;
                }
                else
                {
                    I.Charge = "Unknown";
                    I.Amount = 0;
                }

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
                Variables.Record(Name + "_Violation", I.Violation);
                Variables.Record(Name + "_Faction", I.Faction);
                Variables.Record(Name + "_Charge", I.Charge);
                Variables.Record(Name + "_Amount", I.Amount);
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
                //Audio - FireInStation
                //IStatus.Crime.Response.FireInStation(
                //    I.Victim,                                           //Victims Information
                //    ICheck.Initialized(ClassName),                      //Check Plugin Initialized
                //    (I.Victim != IEvents.StationHostile.I.Name));       //Check Victim Is Not A Local Station
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}