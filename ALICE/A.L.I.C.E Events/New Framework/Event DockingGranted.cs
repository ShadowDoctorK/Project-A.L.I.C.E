//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T05:39:17Z", "event":"DockingGranted", "LandingPad":10, "MarketID":3524278272, "StationName":"Morris Barracks", "StationType":"SurfaceStation" }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_DockingGranted : Base
    {
        public decimal MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
        public decimal LandingPad { get; set; }

        //Default Constructor
        public ASDF_DockingGranted()
        {
            MarketID = Dec();
            StationName = Str();
            StationType = Str();
            LandingPad = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_DockingGranted : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (DockingGranted)O;

                Variables.Record(Name + "_Market", Event.MarketID);
                Variables.Record(Name + "_Station", Event.StationName);
                Variables.Record(Name + "_Type", Event.StationType);
                Variables.Record(Name + "_LandingPad", Event.LandingPad);
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
                var Event = (DockingGranted)O;

                //Update Status Obbject
                IStatus.Docking.Update(Event);
            }
            catch (Exception ex)
            {
                ExceptionProcess(ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment()
        {
            IStatus.Supercruise = false;
            IStatus.Hyperspace = false;
            IStatus.Touchdown = false;
            IStatus.Docking.Docked = false;
        }
    }
}