//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T03:03:18Z", "event":"DockingTimeout", "MarketID":3221503744, "StationName":"Hennen Station", "StationType":"Bernal" }

using ALICE_Status;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class DockingTimeout : Base
    {
        public string StationName { get; set; }
        public string StationType { get; set; }
        public decimal MarketID { get; set; }

        //Default Constructor
        public DockingTimeout()
        {
            StationName = Str();
            StationType = Str();        
            MarketID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_DockingTimeout : Event
    {
        //Event Instance
        public DockingTimeout I { get; set; } = new DockingTimeout();

        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                Variables.Record(Name + "_Station", I.StationName);
                Variables.Record(Name + "_Type", I.StationType);
                Variables.Record(Name + "_Market", I.MarketID);
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
                I = (DockingTimeout)O;
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
                //Update Status Obbject
                IStatus.Docking.Update(I);
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment(object O)
        {
            try
            {
                IStatus.Supercruise = false;
                IStatus.Hyperspace = false;
                IStatus.Touchdown = false;
                IStatus.Docking.Docked = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}