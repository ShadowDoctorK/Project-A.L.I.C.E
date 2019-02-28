//Code Generated By CMDR Shadow Doctor K
//Class File Generated: 02/26/2019 8:59 PM
//Source Journal Line: (Custom A.L.I.C.E Event)

using ALICE_Actions;
using ALICE_Core;
using ALICE_Debug;
using ALICE_Equipment;
using ALICE_Internal;
using System;
using System.Collections.Generic;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ShipyardArrived : Base
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string EndStation { get; set; }
        public decimal Time { get; set; }
        public string Ship { get; set; }
        public bool ThreeMinOut { get; set; }

        //Default Constructor
        public ShipyardArrived()
        {
            StartLocation = Str();
            EndLocation = Str();
            EndStation = Str();
            Time = Dec();
            Ship = Str();
            ThreeMinOut = Bool();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_ShipyardArrived : Event
    {
        //Event Instance
        private ShipyardArrived i = new ShipyardArrived();
        public ShipyardArrived I
        {
            get => i;
            set => i = value;
        }

        //Construct Event
        public void Construct(ShipyardTransfer Event)
        {
            I = new ShipyardArrived()
            {
                EndLocation = ICheck.Docked.System(ClassName),
                EndStation = ICheck.Docked.Station(ClassName),
                StartLocation = Event.System,
                Time = Event.TransferTime,
                ThreeMinOut = true
            };

            if (Event.ShipType_Localised != null)
            {
                I.Ship = Event.ShipType_Localised;
            }
            else
            {
                I.Ship = Event.ShipType;
            }

            Record(Name, I);

            //Monitor Ships (Controls Logic)
            IStatus.Shipyard.Update(I);
        }

        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                Variables.Record(Name + "_Ship", I.Ship);
                Variables.Switch(Name + "_Status", I.ThreeMinOut, "ThreeMinWarning", "Arrived");
                Variables.Record(Name + "_StartLocation", I.StartLocation);
                Variables.Record(Name + "_EndLocation", I.EndLocation);
                Variables.Record(Name + "_EndStation", I.EndStation);
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
                //Audio - Three Min Arrival Warning
                IStatus.Shipyard.Response.ThreeMinWarning(
                    ICheck.Initialized(ClassName),                          //Check Plugin Initialized
                    ICheck.ShipyardArrived.ThreeMinOut(ClassName, true),    //Check Three Min Warning
                    ICheck.ShipyardArrived.Time(ClassName, false, 0));      //Check Time Is Not Zero                    

                //Audio - Arrived
                IStatus.Shipyard.Response.Arrived(                    
                    ICheck.Initialized(ClassName),                          //Check Plugin Initialized
                    ICheck.ShipyardArrived.Time(ClassName, true, 0));       //Check Time Is Zero  
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}