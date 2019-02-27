//Code Generated By CMDR Shadow Doctor K
//Class File Generated: 11/20/2018 12:20 AM
//Source Journal Line: (Custom A.L.I.C.E Event)

using ALICE_Core;
using ALICE_Interface;
using ALICE_Internal;
using ALICE_Synthesizer;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class AliceOnline : Base
    {
        public IPlatform.Interfaces Interface { get; set; }
        public string Version { get; set; }

        //Default Constructor
        public AliceOnline()
        {
            Event = "AliceOnline";
            Timestamp = DateTime.Now.ToUniversalTime();
            Interface = IPlatform.Interface;
            Version = "Three Point Four Point Zero";
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_AliceOnline : Event
    {
        //Event Instance
        public AliceOnline I = new AliceOnline();

        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                Variables.Record(Name + "_Interface", I.Interface.ToString());
                Variables.Record(Name + "_Initialized", I.Timestamp);
                Variables.Record(Name + "_Version", "3.4.0");
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
                //Audio - AliceOnline
                IStatus.Interaction.Response.Online(
                    Check.Internal.TriggerEvents(true, ClassName));     //Check Plugin Initialized
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}