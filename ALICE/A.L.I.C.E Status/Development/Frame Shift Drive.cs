using System.Threading;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Response;

namespace ALICE_Status
{
    public static partial class IStatus
    {
        public static FrameShiftDrive FrameShiftDrive { get; set; } = new FrameShiftDrive();
    }

    public class FrameShiftDrive
    {
        /* Notes:
         * Validation Checks (Expected States)
         * 1. Mothership = true
         * 2. Touchdown = false
         * 3. Docking = false
         * 4. Cargo Scoop = false
         * 5. Landing Gear = false
         * 6. Hardpoings = false
         * 7. (Supercruise) Supercruise = false
         * 8. Hyperspace = false         
         */

        public readonly string ClassName = "Frame Shift Drive";

        public bool Supercruise = false;
        public bool Hyperspace = false;
        public bool Charging = false;
        public bool Cooldown = false;
        public bool Disengaging = false;
        public bool PrepHyperspace = false;
        public bool PrepSupercruise = false;
        public bool Marking = false;

        public void U_Charging(bool B)
        {
            //Only Process If Different
            if (B == Charging) { return; }

            //Update Charging
            ISet.FrameShiftDrive.Charging(ClassName, B);

            //Reset Charging States
            if (B == false)
            {
                ISet.FrameShiftDrive.Hyperspace(ClassName, false);
                ISet.FrameShiftDrive.Supercruise(ClassName, false);
            }

            //Audio - Charging Started:
            IResponse.FrameShiftDrive.ChargingStart(
                ICheck.FrameShiftDrive.Charging(ClassName, true),    //Check Charging State
                ICheck.InitializedStatus(ClassName));                //Check Status.Json Initialized
        }

        #region Controls
        /// <summary>
        /// Will Attempt To Start Charging The FSD. Then Watch For It To Start
        /// </summary>
        /// <param name="HyperspaceCharge">True = Charing For Hyperspace.</param>
        /// <returns>True = FSD Started, False = FSD Failed To Engage.</returns>
        public bool Start(bool HyperspaceCharge)
        {
            //Keypress
            if (HyperspaceCharge)
            {
                IKeyboard.Press(IKey.Hyperspace_Jump, 0);
            }
            else
            {
                IKeyboard.Press(IKey.Supercruise, 0);
            }

            //Watch FSD Starting (3.25 Seconds)
            Thread.Sleep(250); decimal Count = 0; while (Charging == false)
            {
                Count++; Thread.Sleep(100); if (Count >= 30)
                {
                    return false;
                }
            }

            //Started
            if (HyperspaceCharge)
            {
                //Charge Mode
                ISet.FrameShiftDrive.Hyperspace(ClassName, true);
                ISet.FrameShiftDrive.Supercruise(ClassName, false);

                //Preparations
                ISet.FrameShiftDrive.PrepHyperspace(ClassName, false);
                ISet.FrameShiftDrive.PrepSupercruise(ClassName, false);
            }
            else
            {
                //Charge Mode
                ISet.FrameShiftDrive.Supercruise(ClassName, true);
                ISet.FrameShiftDrive.Hyperspace(ClassName, false);

                //Preparations
                ISet.FrameShiftDrive.PrepHyperspace(ClassName, false);
                ISet.FrameShiftDrive.PrepSupercruise(ClassName, false);
            }

            return true;
        }

        public bool Stop(bool EmergencyDrop = false)
        {
            ISet.FrameShiftDrive.Disengaging(ClassName, true);

            //Keypress
            if (EmergencyDrop == false)
            {
                IKeyboard.Press(IKey.Supercruise, 0);
            }
            else
            {
                IKeyboard.Press(IKey.Supercruise, 200);
                IKeyboard.Press(IKey.Supercruise, 0);
            }

            //Watch FSD Disengaging
            ISet.FrameShiftDrive.Disengaging(ClassName, true);
            int Count = 0; while (Disengaging == true)
            {
                if (Count > 50)
                {
                    return false;
                }
                Thread.Sleep(100); Count++;
            }

            ISet.FrameShiftDrive.Disengaging(ClassName, true);

            //Disengaged
            return true;
        }

        public bool Abort()
        {
            //Keypress
            if (Charging)
            {
                IKeyboard.Press(IKey.Toggle_Frame_Shift_Drive, 0);
            }

            //Watch FSD Abort
            int Count = 0; while (Charging == true)
            {
                if (Count > 30)
                {
                    return false;
                }
                Thread.Sleep(100); Count++;
            }

            //Preparations
            ISet.FrameShiftDrive.PrepHyperspace(ClassName, false);
            ISet.FrameShiftDrive.PrepSupercruise(ClassName, false);

            //Aborted
            return true;
        }

        /// <summary>
        /// Configure Frame Shift Drive Preparations
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="S">(State) Setting Or Resetting Preps</param>
        /// <param name="H">(Hyperspace) Set Hyperspace Preps. Defaults To Supercruise</param>
        public void Prepair(string M, bool S, bool H = false)
        {
            //Set Preprations
            if (S)
            {
                //Hyperspace
                if (H)
                {
                    ISet.FrameShiftDrive.PrepHyperspace(ClassName, true);
                    ISet.FrameShiftDrive.PrepSupercruise(ClassName, false);

                    //Audio - Prepair For Hyperspace
                }
                //Supercruise
                else
                {
                    ISet.FrameShiftDrive.PrepSupercruise(ClassName, true);
                    ISet.FrameShiftDrive.PrepHyperspace(ClassName, false);

                    //Audio - Prepair For Supercruise
                }
            }
            //Reset Preprations
            else
            {
                ISet.FrameShiftDrive.PrepSupercruise(ClassName, false);
                ISet.FrameShiftDrive.PrepHyperspace(ClassName, false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="M"></param>
        /// <param name="Prep"></param>
        /// <param name="Mark"></param>
        /// <param name="Mode"></param>
        public void Reset(string M, bool Prep, bool Mark, bool Mode)
        {
            if (Prep)
            {
                ISet.FrameShiftDrive.PrepHyperspace(M, false);
                ISet.FrameShiftDrive.PrepSupercruise(M, false);
            }                       
            if (Mark)
            {
                ISet.FrameShiftDrive.Marking(M, false);
            }            
            if (Mode)
            {
                ISet.FrameShiftDrive.Supercruise(ClassName, false);
                ISet.FrameShiftDrive.Hyperspace(ClassName, false);
            }
        }

        /// <summary>
        /// Reference Method To Allow Posting Debug Line For Returning.
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        public void Returned(string M)
        {
            Logger.DebugLine(M, "Returned From Logic", Logger.Yellow);
        }
        #endregion            
    }
}