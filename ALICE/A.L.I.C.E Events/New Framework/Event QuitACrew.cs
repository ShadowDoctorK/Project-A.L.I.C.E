//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 11:56 PM
//Source Journal Line: { "timestamp":"2018-11-20T22:01:00Z", "event":"QuitACrew", "Captain":"$cmdr_decorate:#name=Donald Trump;" }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_QuitACrew : Base
    {
        public string Captain { get; set; }

        //Default Constructor
        public ASDF_QuitACrew()
        {
            Captain = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_QuitACrew : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (QuitACrew)O;

                Variables.Record(Name + "_Captain", Event.Captain);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(ex);
            }
        }

        //Plugin Logic Process
        public override void Process(object O)
        {
            try
            {
                var Event = (QuitACrew)O;
            }
            catch (Exception ex)
            {
                ExceptionProcess(ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment()
        {
            //No Updates
        }
    }
}