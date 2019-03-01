//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 12:20 AM
//Source Journal Line: (Custom A.L.I.C.E Event)

using ALICE_Debug;
using ALICE_Equipment;
using ALICE_Internal;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class FuelHalfThreshold : Base
    {
        //No Properties
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_FuelHalfThreshold : Event
    {
        //Event Instance
        private FuelHalfThreshold i = new FuelHalfThreshold();
        public FuelHalfThreshold I
        {
            get => i;
            set => i = value;
        }

        //Construct Event
        public void Construct(CommitCrime Event)
        {
            try
            {
                I = new FuelHalfThreshold()
                {
                    //No Properties
                };

                Record(Name, I);
                Logic();
            }
            catch (Exception ex)
            {
                ExceptionConstruct(Name, ex);
            }
        }

        //Plugin Logic Process
        public override void Process(object O)
        {
            try
            {
                //Notes: Commented Out Audio Due To Main Audio Playing Twice.   

                //Audio - FuelHalfThreshold
                //IEquipment.FuelTank.FuelHalf(
                //    ICheck.Initialized(ClassName),                      //Check Plugin Initialized
                //    ICheck.InitializedStatus(ClassName),                //Check Status.Json Initialized
                //    Check.Variable.FuelScooping(false, ClassName));     //Check Not Fuel Scooping     

                //Update Status Object
                IEquipment.FuelTank.HalfThreshold = true;
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}