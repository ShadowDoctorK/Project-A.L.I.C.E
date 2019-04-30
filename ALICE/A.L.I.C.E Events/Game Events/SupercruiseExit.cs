//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-14T20:07:57Z", "event":"SupercruiseExit", "StarSystem":"Col 173 Sector KY-Q d5-47", "SystemAddress":1625603164499, "Body":"Col 173 Sector KY-Q d5-47 8 c", "BodyID":24, "BodyType":"Planet" }

using ALICE_Actions;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Status;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class SupercruiseExit : Base
    {
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public string Body { get; set; }
        public decimal BodyID { get; set; }
        public string BodyType { get; set; }

        //Default Constructor
        public SupercruiseExit()
        {
            StarSystem = Str();
            SystemAddress = Dec();
            Body = Str();
            BodyID = Dec();
            BodyType = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_SupercruiseExit : Event
    {
        //Event Instance
        public SupercruiseExit I { get; set; } = new SupercruiseExit();

        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                Variables.Record(Name + "_System", I.StarSystem);
                Variables.Record(Name + "_Address", I.SystemAddress);
                Variables.Record(Name + "_Body", I.Body);
                Variables.Record(Name + "_ID", I.BodyID);
                Variables.Record(Name + "_Type", I.BodyType);
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
                I = (SupercruiseExit)O;

                IStatus.FrameShiftDrive.Reset(ClassName, true, true, true);
                IStatus.FrameShiftDrive.Disengaging = false;
                IEvents.FireInNoFireZone.I.FirstReport = true;
                Call.Panel.MainFourIsFalse();
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
                //Update NoFireZone Event
                IEvents.NoFireZone.Construct(I);

                //Update Status Object
                IStatus.Docking.Update(I);

                //Assisted Docking Procedure
                IStatus.Docking.AssistedDocking(I);

                //Glide Monitor
                IStatus.Planet.Glide(I);

                //Assisted Landing Preparations
                IStatus.Planet.AssistedLanding(I);
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
                IStatus.Docking.State = IEnums.DockingState.Undocked;
                IStatus.Fighter.Deployed = false;
                IStatus.Supercruise = false;
                IStatus.Hyperspace = false;
                IStatus.Hardpoints = false;
                IStatus.Touchdown = false;
                IStatus.CargoScoop = false;
                ISet.Status.LandingGear(ClassName, false);
                IStatus.WeaponSafety = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}