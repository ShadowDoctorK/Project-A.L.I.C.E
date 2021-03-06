//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-19T02:39:00Z", "event":"Screenshot", "Filename":"\\ED_Pictures\\Screenshot_0004.bmp", "Width":3840, "Height":2160, "System":"NGC 2451A Sector EC-L b8-5", "Body":"NGC 2451A Sector EC-L b8-5 AB" }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Screenshot : Base
    {
        public string Filename { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string System { get; set; }
        public string Body { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        //Default Constructor
        public Screenshot()
        {
            Filename = Str();
            Width = Dec();
            Height = Dec();
            System = Str();
            Body = Str();
            Latitude = Dec();
            Longitude = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_Screenshot : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (Screenshot)O;

                Variables.Record(Name + "_Filename", Event.Filename);
                Variables.Record(Name + "_Width", Event.Width);
                Variables.Record(Name + "_Height", Event.Height);
                Variables.Record(Name + "_System", Event.System);
                Variables.Record(Name + "_Body", Event.Body);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}