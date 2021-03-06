//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-10-06T09:26:51Z", "event":"DatalinkScan", "Message":"$DATAPOINT_GAMEPLAY_complete;", "Message_Localised":"Alert: All Data Point telemetry links established, Intel package created." }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class DatalinkScan : Base
    {
        public string Message { get; set; }
        public string Message_Localised { get; set; }

        //Default Constructor
        public DatalinkScan()
        {
            Message = Str();
            Message_Localised = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_DatalinkScan : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (DatalinkScan)O;

                Variables.Record(Name + "_Message", Event.Message_Localised);
                Variables.Record(Name + "_EDMessage", Event.Message);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}