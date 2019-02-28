//Code Generated By CMDR Shadow Doctor K
//Class File Generated: 02/26/2019 8:59 PM
//Source Journal Line: (Custom A.L.I.C.E Event)
//Reference Journal Line: { "timestamp":"2018-11-22T16:57:24Z", "event":"CommitCrime", "CrimeType":"fireInNoFireZone", "Faction":"Independent Detention Foundation", "Fine":100 }

using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class FireInNoFireZone : Base
    {
        public bool FirstReport { get; set; }
        public string Violation { get; set; }
        public string Victim { get; set; }
        public string Faction { get; set; }
        public string Charge { get; set; }
        public decimal Amount { get; set; }

        //Default Constructor
        public FireInNoFireZone()
        {
            FirstReport = true;
            Violation = Str();
            Victim = Str();
            Faction = Str();
            Charge = Str();
            Amount = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_FireInNoFireZone : Event
    {
        //Event Instance
        private FireInNoFireZone i = new FireInNoFireZone();
        public FireInNoFireZone I
        {
            get => i;
            set => i = value;
        }

        //Construct Event
        public void Construct(CommitCrime Event)
        {
            try
            {
                I = new FireInNoFireZone()
                {
                    Event = "FireInNoFireZone",
                    Timestamp = Event.Timestamp,
                    Victim = Event.Victim,
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
                Variables.Record(Name + "_Victim", I.Victim);
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
                //Audio - FireInNoFireZone
                IStatus.Crime.Response.FireInNoFireZone(
                    Check.Internal.TriggerEvents(true, ClassName),              //Check Plugin Initialized
                    ICheck.FireInNoFireZone.FirstReport(ClassName, true));     //Check First Time Reporting

                //Update First Report
                I.FirstReport = false;
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}
