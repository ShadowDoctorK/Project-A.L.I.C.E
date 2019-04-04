//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T05:46:45Z", "event":"Undocked", "StationName":"Morris Barracks", "StationType":"SurfaceStation", "MarketID":3524278272 }

using ALICE_Actions;
using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Response;
using System;
using System.Threading;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Undocked : Base
    {
        public string StationName { get; set; }
        public string StationType { get; set; }
        public decimal MarketID { get; set; }

        //Default Constructor
        public Undocked()
        {
            StationName = Str();
            StationType = Str();
            MarketID = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_Undocked : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (Undocked)O;

                Variables.Record(Name + "_Station", Event.StationName);
                Variables.Record(Name + "_Type", Event.StationType);
                Variables.Record(Name + "_Market", Event.MarketID);                
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
                ISet.LandingGear.Status(ClassName, true);
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
                var Event = (Undocked)O;

                //Audio - Undocked
                IResponse.Docking.Undocked(
                    ICheck.Initialized(ClassName));    //Check Plugin Initialized

                //Update Status Object
                IStatus.Docking.Update(Event);

                //Retract Landing Gear
                Thread.Sleep(250); Call.Action.LandingGear(false, false);

                //Update Firegroups
                Thread Action = 
                new Thread((ThreadStart)(() => 
                {
                    //Update Firegroups
                    Call.Firegroup.Update_Total(false);
                }))
                {
                    IsBackground = true
                };
                Action.Start();
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
                IEvents.FireInNoFireZone.I.FirstReport = true;
                IStatus.Hardpoints = false;
                IStatus.Touchdown = false;
                IStatus.CargoScoop = false;
                IStatus.Hyperspace = false;
                IStatus.Supercruise = false;
                IStatus.Fighter.Deployed = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}