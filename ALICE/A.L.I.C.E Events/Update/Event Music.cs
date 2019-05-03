//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T04:04:28Z", "event":"Music", "MusicTrack":"DestinationFromSupercruise" }

using ALICE_Status;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Music : Base
    {
        public string MusicTrack { get; set; }

        //Default Constructor
        public Music()
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
    public class Event_Music : Event
    {
        //Event Instance
        public Music I = new Music();

        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                Variables.Record(Name + "_Track", I.MusicTrack);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }

        //Plugin Logic Preparations
        public override void Prepare(object O)
        {
            try
            {
                //Update Event Instance
                I = (Music)O;
            }
            catch (Exception ex)
            {
                ExceptionPrepare(Name, ex);
            }
        }

        //Plugin Logic Process
        public override void Process(object O)
        {
            try
            {
                //Update Status Object
                IStatus.Music.Update(I);
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}