//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-28T21:01:59Z", "event":"SendText", "To":"Maddemondog", "Message":"I'll be there shortly. Just helping a beta tester with something real quick. I had to smash a Medium sized bug that only affected people with a fresh install." }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class SendText : Base
    {
        public string To { get; set; }
        public string Message { get; set; }

        //Default Constructor
        public SendText()
        {
            To = Str();
            Message = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_SendText : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (SendText)O;

                Variables.Record(Name + "_To", Event.To);
                Variables.Record(Name + "_Message", Event.Message);
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
                var Event = (SendText)O;

                //Update Status Object
                IStatus.Messages.Update(Event);
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}