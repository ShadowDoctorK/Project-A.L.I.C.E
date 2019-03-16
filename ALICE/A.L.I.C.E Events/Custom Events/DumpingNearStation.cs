//Code Generated By CMDR Shadow Doctor K
//Class File Generated: 02/26/2019 8:59 PM
//Source Journal Line: (Custom A.L.I.C.E Event)
//Reference Journal Line: 

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class DumpingNearStation : Base
    {
        public string Violation { get; set; }
        public string Victim { get; set; }
        public string Faction { get; set; }
        public string Charge { get; set; }
        public decimal Amount { get; set; }

        //Default Constructor
        public DumpingNearStation()
        {
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
    public class Event_DumpingNearStation : Event
    {
        //Event Instance
        public DumpingNearStation I { get; set; } = new DumpingNearStation();

        //Construct Event
        public void Construct(CommitCrime Event)
        {
            try
            {
                I = new DumpingNearStation()
                {
                    Event = "DumpingNearStation",
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
                //Audio - DumpingNearStation
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}