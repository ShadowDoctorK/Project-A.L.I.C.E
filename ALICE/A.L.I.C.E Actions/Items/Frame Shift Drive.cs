using ALICE_Core;
using ALICE_Debug;
using ALICE_Equipment;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Response;
using System.Threading;

namespace ALICE_Actions
{
    public static partial class IActions
    {     
        public static FrameShiftDrive FrameShiftDrive { get; set; } = new FrameShiftDrive();
    }

    public class FrameShiftDrive
    {       
        public enum Validate { Pass, Vehicle, Touchdown, Docked, Hyperspace, Supercruise, NormalSpace }        
        public enum Charge { None, Hyperspace, Supercruise, Unknown }
        public enum Prepare { None, Hyperspace, Supercruise, MarkHyperspace, MarkSupercruise }

        /// <summary>
        /// Will Check Various States And Abort Jump If Able.
        /// </summary>
        /// <param name="A">(Audio) Enable / Disables Audio On The Command Level</param>
        public void AbortJump(bool A)
        {
            string MethodName = "Abort Jump";

            //Operating In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }

            //Check Charging State
            switch (ChargeState(MethodName))
            {
                case Charge.None:
                    //No Action Required
                    return;

                default:
                    //Abort Sucessful
                    if (IEquipment.FrameShiftDrive.Abort() == true)
                    {
                        IResponse.FrameShiftDrive.AbortSuccessful(A);
                    }
                    //Abort Failed
                    else
                    {
                        IResponse.FrameShiftDrive.AbortFailed(A);
                        return;
                    }

                    ISet.FrameShiftDrive.PrepHyperspace(MethodName, false);
                    ISet.FrameShiftDrive.PrepSupercruise(MethodName, false);
                    break;
            }
        }

        /// <summary>
        /// Will Check Various States And Align The Frame Shift Drive For Hyperspace.
        /// </summary>
        /// <param name="A">(Audio) Enable / Disable Command Level Audio</param>
        /// <param name="S">(State) Start or Stop</param>
        /// <param name="M">(Mark) Enable / Disables Waiting For Mark</param>
        public void Hyperspace(bool A, bool S, bool M = false)
        {
            string MethodName = "Hyperspace";

            //Validation Checks
            switch (Validation(MethodName, A, 
                true,   //Vehcile
                true,   //Touchdown
                true,   //Docked
                true,   //Hyperspace
                false,  //Supercruise
                false,  //Normal Space
                false,  //Masslock
                false,  //Cooldown
                ref IEquipment.FrameShiftDrive.PrepHyperspace))
            {
                case Validate.Pass:
                    //Continue
                    break;

                case Validate.Hyperspace:
                    //Currently In Hyperspace
                    IResponse.FrameShiftDrive.HS_CurrentlyHyperspace(A);
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;

                default:
                    //Failed, Exit
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;
            }

            //Charge State Checks
            switch (ChargeState(MethodName))
            {
                case Charge.None:
                    //Continue
                    break;

                case Charge.Hyperspace:
                    //Already Charging For Hyperspace
                    IResponse.FrameShiftDrive.HS_CurrentlyCharging(A);
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;

                case Charge.Supercruise:
                    //Stop Charging For Supercruise
                    IEquipment.FrameShiftDrive.Abort(); break;

                case Charge.Unknown:
                    //Unknown State Stop Charging.
                    IEquipment.FrameShiftDrive.Abort(); break;

                default:
                    //Unknown Error Reset
                    IEquipment.FrameShiftDrive.Reset(MethodName, true, true, true);
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;
            }

            //Prepration State Checks
            switch (PreparationState(MethodName))
            {
                case Prepare.None:
                    //Continue
                    break;

                case Prepare.Hyperspace:
                    //Already Preparing For Hyperspace
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;

                case Prepare.Supercruise:
                    //Reset Supercruise Call Items And Continue
                    IEquipment.FrameShiftDrive.Prepair(MethodName, false); break;

                case Prepare.MarkHyperspace:
                    //Set Mark To False To Continue With Previous Call
                    IEquipment.FrameShiftDrive.Reset(MethodName, false, true, false);
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;

                case Prepare.MarkSupercruise:
                    //Reset Supercruise Call Items And Continue
                    IEquipment.FrameShiftDrive.Reset(MethodName, true, true, false); break;                    

                default:
                    //Unknown Error Reset
                    IEquipment.FrameShiftDrive.Reset(MethodName, true, true, true);
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;
            }

            //Initial Equipment Line Up
            LineUp(MethodName, true, true, false);      //Cargo Scoop, Landing Gear

            //Enter Hyperspace
            if (S == true)
            {
                //Prepare For Hyperspace
                IEquipment.FrameShiftDrive.Prepair(MethodName, true, true);
                IResponse.FrameShiftDrive.HS_Prepairing(A);

                //Check If We Are Waiting For A Mark
                if (M)
                {
                    //Track Marking
                    ISet.FrameShiftDrive.Marking(MethodName, true);

                    //Sleep To Queue Audio In Synthesizer Correctly
                    Thread.Sleep(100);

                    //On Your Mark Audio
                    IStatus.Interaction.Response.OnYourMark(A, false);

                    //Wait 30 Seconds For Mark
                    switch (IStatus.Interaction.WaitForMark(MethodName, 30000, 
                        ref IEquipment.FrameShiftDrive.Marking, 
                        ref IStatus.Interaction.Marker))
                    {
                        case ALICE_Status.Status_Interaction.Marks.NoResponse:
                            IEquipment.FrameShiftDrive.Reset(MethodName, true, true, false);
                            IEquipment.FrameShiftDrive.Returned(MethodName);
                            return;

                        case ALICE_Status.Status_Interaction.Marks.Mark:
                            ISet.FrameShiftDrive.Marking(MethodName, false);
                            break;

                        case ALICE_Status.Status_Interaction.Marks.EarlyReturn:
                            IEquipment.FrameShiftDrive.Reset(MethodName, false, true, false);
                            IEquipment.FrameShiftDrive.Returned(MethodName);
                            return;

                        default:
                            IEquipment.FrameShiftDrive.Reset(MethodName, true, true, false);
                            IEquipment.FrameShiftDrive.Returned(MethodName);
                            return;
                    }
                }

                //Prepairing Check
                if (ICheck.FrameShiftDrive.PrepHyperspace(MethodName, true) == false)
                {
                    //Jump Was Aborted While We Waited, Exit Method.
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;
                }

                //Validation Checks Prior To Start Incase Something Changed
                //While We Were Waiting On Mark, Masslock, or Cooldown.
                switch (Validation(MethodName, A, 
                    true,   //Vehcile
                    true,   //Touchdown
                    true,   //Docked
                    true,   //Hyperspace
                    false,  //Supercruise
                    false,  //Normal Space
                    true,   //Masslock
                    true,   //Cooldown
                    ref IEquipment.FrameShiftDrive.PrepHyperspace))
                {
                    case Validate.Pass:
                        //Continue
                        break;

                    default:
                        //Failed, Exit
                        IEquipment.FrameShiftDrive.Returned(MethodName);
                        return;
                }
                //Final Equipment Line Up
                LineUp(MethodName, true, true, true);       //Cargo Scoop, Landing Gear, Hardpoints

                //Notes: Charge Audio Controlled By Status.Json Events.

                //Start & Monitor
                if (IEquipment.FrameShiftDrive.Start(true) == false)
                {
                    IResponse.FrameShiftDrive.FailedToEngage(A);
                    IEquipment.FrameShiftDrive.Reset(MethodName, true, true, false);
                }
            }
        }

        /// <summary>
        /// Will Check Various States And Align The Frame Shift Drive For Supercruise/Normal Space.
        /// </summary>
        /// <param name="A">(Audio) Enable / Disable Command Level Audio</param>
        /// <param name="S">(State) True = Enter Supercruise / False = Exis Supercruise</param>
        /// <param name="M">(Mark) Enable / Disables Waiting For Mark</param>
        public void Supercruise(bool A, bool S, bool M = false)
        {
            string MethodName = "Supercruise";

            //Validation Checks
            switch (Validation(MethodName, A,
                true,   //Vehcile
                true,   //Touchdown
                true,   //Docked
                true,   //Hyperspace
                S,      //Supercruise   (True If Entering Supercruise)
                !S,     //Normal Space  (True If Existing Supercruise)
                false,  //Masslock
                false,  //Cooldown
                ref IEquipment.FrameShiftDrive.PrepSupercruise))
            {
                case Validate.Pass:
                    //Continue
                    break;

                case Validate.Supercruise:
                    //Currently In Supercruise
                    IResponse.FrameShiftDrive.SC_CurrentlySupercruise(A);
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;

                case Validate.NormalSpace:
                    //Currently In Hyperspace
                    IResponse.FrameShiftDrive.SC_CurrentlyNormalSpace(A);
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;

                default:
                    //Failed, Exit
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;
            }

            //Charge State Checks
            switch (ChargeState(MethodName))
            {
                case Charge.None:
                    //Continue
                    break;

                case Charge.Hyperspace:
                    //Stop Charging For Hyperspace
                    IEquipment.FrameShiftDrive.Abort(); break;

                case Charge.Supercruise:
                    //Already Charging For Supercruise
                    IResponse.FrameShiftDrive.SC_CurrentlyCharging(A);
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;

                case Charge.Unknown:
                    //Unknown State Stop Charging.
                    IEquipment.FrameShiftDrive.Abort(); break;

                default:
                    //Unknown Error Reset
                    IEquipment.FrameShiftDrive.Reset(MethodName, true, true, true);
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;
            }

            //Prepration State Checks
            switch (PreparationState(MethodName))
            {
                case Prepare.None:
                    //Continue
                    break;

                case Prepare.Hyperspace:
                    //Reset Hyperspace Call Items And Continue
                    IEquipment.FrameShiftDrive.Prepair(MethodName, false); break;

                case Prepare.Supercruise:
                    //Already Preparing For Supercruise
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;

                case Prepare.MarkHyperspace:
                    //Reset Hyperspace Call Items And Continue
                    IEquipment.FrameShiftDrive.Reset(MethodName, true, true, false); break;

                case Prepare.MarkSupercruise:
                    //Set Mark To False To Continue With Previous Call
                    IEquipment.FrameShiftDrive.Reset(MethodName, false, true, false);
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;

                default:
                    //Unknown Error Reset
                    IEquipment.FrameShiftDrive.Reset(MethodName, true, true, true);
                    IEquipment.FrameShiftDrive.Returned(MethodName);
                    return;
            }

            //Initial Equipment Line Up
            LineUp(MethodName, true, true, false);      //Cargo Scoop, Landing Gear

            //Check Normal Space
            if (ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space))
            {
                //Enter Supercruise
                if (S == true)
                {
                    //Prepare For Supercruise
                    IEquipment.FrameShiftDrive.Prepair(MethodName, true);
                    IResponse.FrameShiftDrive.SC_Prepairing(A);

                    //Check If We Are Waiting For A Mark
                    if (M)
                    {
                        //Track Marking
                        ISet.FrameShiftDrive.Marking(MethodName, true);

                        //Sleep To Queue Audio In Synthesizer Correctly
                        Thread.Sleep(100);

                        //On Your Mark Audio
                        IStatus.Interaction.Response.OnYourMark(A, false);

                        //Wait 30 Seconds For Mark
                        switch (IStatus.Interaction.WaitForMark(MethodName, 30000, 
                            ref IEquipment.FrameShiftDrive.Marking, 
                            ref IStatus.Interaction.Marker))
                        {
                            case ALICE_Status.Status_Interaction.Marks.NoResponse:
                                IEquipment.FrameShiftDrive.Reset(MethodName, true, true, false);
                                IEquipment.FrameShiftDrive.Returned(MethodName);
                                return;

                            case ALICE_Status.Status_Interaction.Marks.Mark:
                                ISet.FrameShiftDrive.Marking(MethodName, false);
                                break;

                            case ALICE_Status.Status_Interaction.Marks.EarlyReturn:
                                IEquipment.FrameShiftDrive.Reset(MethodName, false, true, false);
                                IEquipment.FrameShiftDrive.Returned(MethodName);
                                return;

                            default:
                                IEquipment.FrameShiftDrive.Reset(MethodName, true, true, false);
                                IEquipment.FrameShiftDrive.Returned(MethodName);
                                return;
                        }
                    }

                    //Prepairing Check
                    if (ICheck.FrameShiftDrive.PrepSupercruise(MethodName, true) == false)
                    {
                        //Jump Was Aborted While We Waited, Exit Method.
                        IEquipment.FrameShiftDrive.Returned(MethodName);
                        return;
                    }

                    //Validation Checks Prior To Start Incase Something Changed
                    //While We Were Waiting On Mark, Masslock, or Cooldown.
                    switch (Validation(MethodName, A,
                        true,   //Vehcile
                        true,   //Touchdown
                        true,   //Docked
                        true,   //Hyperspace
                        false,  //Supercruise
                        false,  //Normal Space
                        true,   //Masslock
                        true,   //Cooldown
                        ref IEquipment.FrameShiftDrive.PrepSupercruise))
                    {
                        case Validate.Pass:
                            //Continue
                            break;

                        default:
                            //Failed, Exit
                            IEquipment.FrameShiftDrive.Returned(MethodName);
                            return;
                    }
                    //Final Equipment Line Up
                    LineUp(MethodName, true, true, true);       //Cargo Scoop, Landing Gear, Hardpoints

                    //Notes: Charge Audio Controlled By Status.Json Events.

                    //Start & Monitor
                    if (IEquipment.FrameShiftDrive.Start(false) == false)
                    {
                        IResponse.FrameShiftDrive.FailedToEngage(A);
                        IEquipment.FrameShiftDrive.Reset(MethodName, true, true, false);
                    }
                }
                //Already In Normal Space
                else if (S == false)
                {
                    return;
                }
            }
            //Check Supercruise
            else if (ICheck.Environment.Space(MethodName, true, IEnums.Supercruise))
            {
                //Disengage
                if (S == false)
                {
                    //Check If We Are Waiting For A Mark
                    if (M)
                    {
                        //Track Marking
                        ISet.FrameShiftDrive.Marking(MethodName, true);

                        //Sleep To Queue Audio In Synthesizer Correctly
                        Thread.Sleep(100);

                        //On Your Mark Audio
                        IStatus.Interaction.Response.OnYourMark(A, false);

                        //Wait 30 Seconds For Mark
                        switch (IStatus.Interaction.WaitForMark(MethodName, 30000, 
                            ref IEquipment.FrameShiftDrive.Marking,
                            ref IStatus.Interaction.Marker))
                        {
                            case ALICE_Status.Status_Interaction.Marks.NoResponse:
                                IEquipment.FrameShiftDrive.Reset(MethodName, true, true, false);
                                IEquipment.FrameShiftDrive.Returned(MethodName);
                                return;

                            case ALICE_Status.Status_Interaction.Marks.Mark:
                                ISet.FrameShiftDrive.Marking(MethodName, false);
                                break;

                            case ALICE_Status.Status_Interaction.Marks.EarlyReturn:
                                IEquipment.FrameShiftDrive.Reset(MethodName, false, true, false);
                                IEquipment.FrameShiftDrive.Returned(MethodName);
                                return;

                            default:
                                IEquipment.FrameShiftDrive.Reset(MethodName, true, true, false);
                                IEquipment.FrameShiftDrive.Returned(MethodName);
                                return;
                        }
                    }

                    //Disengagin Audio
                    IResponse.FrameShiftDrive.SC_Disengaging(A);

                    //Stop & Monitor
                    if (IEquipment.FrameShiftDrive.Stop() == false)
                    {
                        //Too Fast Audio
                        IResponse.FrameShiftDrive.TooFast(A);

                        //Watch Response For 10 Seconds
                        switch (IStatus.Interaction.Question(10000))
                        {
                            case ALICE_Status.Status_Interaction.Answers.NoResponse:

                                //Log
                                Logger.Log(MethodName, "No Response Detected", Logger.Yellow, true);
                                ISet.FrameShiftDrive.Disengaging(MethodName, false);

                                break;
                            case ALICE_Status.Status_Interaction.Answers.Yes:

                                //Postive Response Audio
                                IEquipment.FrameShiftDrive.PositiveResponse(A);

                                //Emergency Stop & Montor
                                if (IEquipment.FrameShiftDrive.Stop(true) == false)
                                {
                                    IResponse.FrameShiftDrive.FailedToDisengage(A);
                                    ISet.FrameShiftDrive.Disengaging(MethodName, false);
                                }

                                break;

                            case ALICE_Status.Status_Interaction.Answers.No:

                                //Postive Response Audio
                                IEquipment.FrameShiftDrive.PositiveResponse(A);

                                //Reset
                                ISet.FrameShiftDrive.Disengaging(MethodName, false);

                                break;

                            default:
                                ISet.FrameShiftDrive.Disengaging(MethodName, false);
                                break;
                        }
                    }
                }

                //Already In Supercruise
                else if (S == true)
                {                    
                    return;
                }                
            }
        }

        /// <summary>
        /// Support Fucntion That Allows Checking Various Validation States, "Pass" Will
        /// Return If All Checks We're Validated.
        /// </summary>
        /// <param name="A">(Audio) Enable / Disable Command Level Audio</param>
        /// <param name="V">(Vehicle) Enable / Disable Vehicle Checks</param>
        /// <param name="T">(Touchdown) Enable / Disable Touchdown Checks</param>
        /// <param name="D">(Docked) Enable / Disable Docked Checks</param>
        /// <param name="H">(Hyperspace) Enable / Disable Hyperspace Checks</param>
        /// <param name="ML">(Masslock) Enable / Disable Masslock Checks</param>
        /// <param name="C">(Cooldown) Enable / Disable FSD Cooldown Checks</param>
        /// <returns>Pass, Vehicle, Touchdown, Docked, Hyperspace</returns>
        public Validate Validation(string M, bool A, bool V, bool T, bool D, bool H, bool S, bool N, bool ML, bool C, ref bool Prep)
        {
            //Hyperspace Check
            if (H)
            {
                if (ICheck.Environment.Space(M, false, IEnums.Hyperspace) == false)
                {
                    return Validate.Hyperspace;
                }
            }

            //Hyperspace Check
            if (S)
            {
                if (ICheck.Environment.Space(M, false, IEnums.Supercruise) == false)
                {
                    return Validate.Hyperspace;
                }
            }

            //Normal Space Check
            if (N)
            {
                if (ICheck.Environment.Space(M, false, IEnums.Normal_Space) == false)
                {
                    return Validate.Hyperspace;
                }
            }

            //Vehicle Check
            if (V)
            {
                if (ICheck.Status.Vehicle(M, IVehicles.V.Mothership, true) == false)
                {
                    IEquipment.FrameShiftDrive.NotInMothership(A);
                    return Validate.Vehicle;
                }
            }

            //Touchdown Check
            if (T)
            {
                if (ICheck.Status.Touchdown(M, false) == false)
                {
                    IEquipment.FrameShiftDrive.NoTouchdown(A);
                    return Validate.Touchdown;
                }
            }

            //Docked Check
            if (D)
            {
                if (ICheck.Docking.Status(M, false, IEnums.DockingState.Docked) == false)
                {
                    IEquipment.FrameShiftDrive.NoDocked(A);
                    return Validate.Docked;
                }
            }

            //Masslock Check
            if (ML)
            {
                if (ICheck.Masslock.Status(M, false) == false)
                {
                    IResponse.FrameShiftDrive.Masslocked(A);

                    while (ICheck.Masslock.Status(M, false, false) == false && Prep == true)
                    {
                        //Wait Till Free Of Masslock.
                        Thread.Sleep(100);
                    }
                }
            }

            //Cooldown Check
            if (C)
            {
                if (ICheck.FrameShiftDrive.Cooldown(M, false) == false)
                {
                    IResponse.FrameShiftDrive.CoolingDown(A);

                    while (ICheck.FrameShiftDrive.Cooldown(M, false, false) == false && Prep == true)
                    {
                        //Wait For FSD To Cool Down.
                        Thread.Sleep(100);
                    }
                }
            }

            return Validate.Pass;
        }

        /// <summary>
        /// Support Function That Returns The Charge State Of The FSD.
        /// </summary>
        /// <returns>None, Hyperspace, Supercruise, Unknown</returns>
        public Charge ChargeState(string M)
        {
            //Check Charging State
            if (ICheck.FrameShiftDrive.Charging(M, false) == false)
            {
                //Check Supercruise Charge
                if (ICheck.FrameShiftDrive.Supercruise(M, false) == false)
                {
                    return Charge.Supercruise;
                }
                //Check Hyperspace Charge
                else if (ICheck.FrameShiftDrive.Supercruise(M, false) == false)
                {
                    return Charge.Hyperspace;
                }
                //Unknown Charge State
                else
                {
                    return Charge.Unknown;
                }
            }

            //No Charge State
            return Charge.None;
        }

        /// <summary>
        /// Support Function That Returns The Prepartions State Of The FSD.
        /// </summary>
        /// <returns>None, Hyperspace, Supercruise, MarkHyperspace, MarkSupercruise</returns>
        public Prepare PreparationState(string M)
        {
            //Check Hyperspace Preps
            if (ICheck.FrameShiftDrive.PrepHyperspace(M, false, true) == false)
            {
                //Check Waiting For Mark
                if (ICheck.FrameShiftDrive.Marking(M, false) == false)
                {
                    return Prepare.MarkHyperspace;
                }

                return Prepare.Hyperspace;
            }
            //Check Supercruise Preps
            else if (ICheck.FrameShiftDrive.PrepSupercruise(M, false, true) == false)
            {
                //Check Waiting For Mark
                if (ICheck.FrameShiftDrive.Marking(M, false) == false)
                {
                    return Prepare.MarkSupercruise;
                }

                return Prepare.Supercruise;
            }

            return Prepare.None;
        }

        /// <summary>
        /// Support Function That Allows Config Check For Various Equipment. If The Check Fails
        /// The Function Will Align The Equipment To The Required State.
        /// </summary>
        /// <param name="C">(Cargo Scoop) Enables / Disables Validation</param>
        /// <param name="L">(Landing Gear) Enables / Disables Validation</param>
        /// <param name="H">(Hardpoints)  Enables / Disables Validation</param>
        public void LineUp(string M, bool C, bool L, bool H)
        {
            //Cargo Scoop Check
            if (C)
            {
                if (ICheck.Status.CargoScoop(M, false) == false)
                {
                    Call.Action.CargoScoop(false, false);
                }
            }

            //Landing Gear Check
            if (L)
            {
                if (ICheck.LandingGear.Status(M, false, true) == false)
                {
                    Call.Action.LandingGear(false, false);
                }
            }

            //Hardpoints Check
            if (H)
            {
                if (ICheck.Status.Hardpoints(M, false) == false)
                {
                    IActions.Hardpoints.Operate(false, false);                    
                }
            }
        }
    }
}
