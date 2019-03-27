//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-30T04:22:34Z", "event":"StartJump", "JumpType":"Hyperspace", "StarSystem":"Col 285 Sector AI-K a38-4", "SystemAddress":75737990056832, "StarClass":"TTS" }

using ALICE_Actions;
using ALICE_Core;
using ALICE_Debug;
using ALICE_Equipment;
using ALICE_Internal;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class StartJump : Base
    {
        public string JumpType { get; set; }
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public string StarClass { get; set; }

        //Default Constructor
        public StartJump()
        {
            JumpType = Str();
            StarSystem = Str();
            SystemAddress = Dec();
            StarClass = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_StartJump : Event
    {
        //Event Instance
        public StartJump I { get; set; } = new StartJump();

        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (StartJump)O;

                Variables.Record(Name + "_Type", Event.JumpType);
                Variables.Record(Name + "_DestinationSystem", Event.StarSystem);
                Variables.Record(Name + "_Address", Event.SystemAddress);
                Variables.Record(Name + "_StarClass", Event.StarClass);
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
                //Property Updates
                ISet.FrameShiftDrive.PrepHyperspace(ClassName, false);
                ISet.FrameShiftDrive.PrepSupercruise(ClassName, false);
                IStatus.Hyperspace = false;

               //Update Event Instance
               I = (StartJump)O;
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
                if (I.JumpType == IEnums.Hyperspace)
                {
                    ISet.FrameShiftDrive.Hyperspace(ClassName, true);
                    ISet.FrameShiftDrive.Supercruise(ClassName, false);
                }
                else
                {
                    ISet.FrameShiftDrive.Hyperspace(ClassName, false);
                    ISet.FrameShiftDrive.Supercruise(ClassName, true);                    
                }

                //Audio - Supercruise
                IEquipment.FrameShiftDrive.SC_Entering(
                    ICheck.Initialized(ClassName),                            //Check Plugin Initialized
                    ICheck.FrameShiftDrive.Supercruise(ClassName, true));     //Check Supercruise Charge State

                //Audio - Hyperspace
                IEquipment.FrameShiftDrive.HS_Entering(
                    ICheck.Initialized(ClassName),                            //Check Plugin Initialized
                    ICheck.FrameShiftDrive.Hyperspace(ClassName, true));      //Chekc Hyperspace Charge State

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
                Call.Panel.MainFourIsFalse();                
                IStatus.Hardpoints = false;
                IStatus.Touchdown = false;
                IStatus.CargoScoop = false;
                ISet.LandingGear.Status(ClassName, false);
                IStatus.Fighter.Deployed = false;
                IStatus.Docking.Docked = false;
                IStatus.WeaponSafety = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}