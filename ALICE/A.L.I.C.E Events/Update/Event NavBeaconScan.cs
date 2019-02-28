//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-09-06T12:19:39Z", "event":"NavBeaconScan", "SystemAddress":16063849047465, "NumBodies":34 }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class NavBeaconScan : Base
    {
        public decimal SystemAddress { get; set; }
        public decimal NumBodies { get; set; }

        //Default Constructor
        public NavBeaconScan()
        {
            SystemAddress = Dec();
            NumBodies = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_NavBeaconScan : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (NavBeaconScan)O;

                Variables.Record(Name + "_Address", Event.SystemAddress);
                Variables.Record(Name + "_Bodies", Event.NumBodies);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment(object O)
        {
            try
            {
                IStatus.WeaponSafety = false;
                IStatus.Planet.OrbitalMode = false;
                IStatus.Planet.DecentReport = false;
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