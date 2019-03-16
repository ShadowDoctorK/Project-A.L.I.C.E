//Code Generated By CMDR Shadow Doctor K
//Class File Generated: 02/26/2019 8:59 PM
//Source Journal Line: (Custom A.L.I.C.E Event)
//Reference Journal Line (Warning): { "timestamp":"2018-11-22T01:47:28Z", "event":"ReceiveText", "From":"Hennen Station", "Message":"$DockingPadBlockWarningComms;", "Message_Localised":"Loitering infraction detected, clear pad approach immediately to avoid lethal response", "Channel":"npc" }
//Reference Journal Line (Minor): { "timestamp":"2018-11-22T01:47:55Z", "event":"CommitCrime", "CrimeType":"dockingMinorBlockingLandingPad", "Faction":"Eureka Mining Co-Operative", "Fine":300 }
//Reference Journal Line (Major): 
//Reference Journal Line (Lethal): { "timestamp":"2018-11-22T16:26:09Z", "event":"ReceiveText", "From":"Hennen Station", "Message":"$DockingPadBlockHostileComms;", "Message_Localised":"Docking pad violation, lethal response authorised", "Channel":"npc" }

using ALICE_Debug;
using ALICE_Internal;
using ALICE_Synthesizer;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class BlockLandingPad : Base
    {
        public string Station { get; set; }
        public string Faction { get; set; }
        public string Violation { get; set; }
        public decimal Amount { get; set; }
        public string Charge { get; set; }

        //Default Constructor
        public BlockLandingPad()
        {
            Station = Str();
            Faction = Str();
            Violation = Str();            
            Charge = Str();
            Amount = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_BlockLandingPad : Event
    {
        //Event Instance
        public BlockLandingPad I { get; set; } = new BlockLandingPad();

        //Construct Event
        public void Construct(ReceiveText Event)
        {
            try
            {
                I = new BlockLandingPad()
                {
                    Event = "BlockLandingPad",
                    Timestamp = Event.Timestamp,
                    Station = Event.From,
                    Faction = "None",
                    Violation = "Warning",
                    Charge = "None",
                    Amount = 0
                };

                Record(Name, I);
                Logic();
            }
            catch (Exception ex)
            {
                ExceptionConstruct(Name, ex);
            }
        }

        //Construct Event
        public void Construct(CommitCrime Event)
        {
            try
            {
                I.Timestamp = Event.Timestamp;
                I.Faction = Event.Faction;
                
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
                else if(Event.Bounty != -1)
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
                Variables.Record(Name + "_Station", I.Station);
                Variables.Record(Name + "_Faction", I.Faction);
                Variables.Record(Name + "_Violation", I.Violation);
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
                //Audio - Block Airlock Warning
                if (ICheck.BlockLandingPad.Violation(ClassName, true, "Warning", true))
                {
                    Speech.Speak(""
                        .Phrase(Crime.Block_Landing_Pad_Warning),
                        ICheck.Initialized(ClassName));                     //Check Plugin Initialized
                }

                //Audio - Block Airlock Minor
                if (ICheck.BlockLandingPad.Violation(ClassName, true, "Minor", true))
                {
                    Speech.Speak
                        (
                        "".Phrase(Crime.Block_Landing_Pad_Minor)
                        .Phrase(Crime.Block_Relocate)
                        .Phrase(Crime.Fine, true)
                        .Token("[AMOUNT]", I.Amount)                        //Pass Amount
                        .Token("[STATON]", I.Station),                      //Pass Station Name
                        ICheck.Initialized(ClassName)                       //Check Plugin Initialized
                        );
                }
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}