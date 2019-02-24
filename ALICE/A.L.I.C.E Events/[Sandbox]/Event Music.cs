//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T04:04:28Z", "event":"Music", "MusicTrack":"DestinationFromSupercruise" }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_Music : Base
    {
        public string MusicTrack { get; set; }

        //Default Constructor
        public ASDF_Music()
        {
            MusicTrack = "NoTrack";
        }

        public class Discover : Catch
        {
            public string SystemName { get; set; }
            public decimal NumBodies { get; set; }

            public Discover()
            {
                SystemName = Str();
                NumBodies = Dec();
            }
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_Music : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (Music)O;

                Variables.Record(Name + "_Track", Event.MusicTrack);
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
                var Event = (Music)O;

                //Update Status Object
                IStatus.Music.Update(Event);
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