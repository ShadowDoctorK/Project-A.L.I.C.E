using System.Threading;
using ALICE_Actions;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Response;

namespace ALICE_Equipment
{
    public class FrameShiftDrive : Equipment_General
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

        public bool Supercruise = false;
        public bool Hyperspace = false;
        public bool Charging = false;
        public bool Cooldown = false;
        public bool Disengaging = false;
        public bool PrepHyperspace = false;
        public bool PrepSupercruise = false;
        public bool Marking = false;

        public FrameShiftDrive()
        {
            Settings.Equipment = IEquipment.E.Frame_Shift_Drive;
            Settings.Mode = IEquipment.M.Default;
            Settings.Installed = true;
            Settings.Enabled = true;
        }

        public void U_Charging(bool B)
        {
            //Only Process If Different
            if (B == Charging) { return; }

            //Update Charging
            ISet.FrameShiftDrive.Charging(MethodName, B);

            //Reset Charging States
            if (B == false)
            {
                ISet.FrameShiftDrive.Hyperspace(MethodName, false);
                ISet.FrameShiftDrive.Supercruise(MethodName, false);
            }

            //Audio - Charging Started:
            IResponse.FrameShiftDrive.ChargingStart(
                ICheck.FrameShiftDrive.Charging(MethodName, true),    //Check Charging State
                ICheck.InitializedStatus(MethodName));                //Check Status.Json Initialized
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
                Call.Key.Press(Call.Key.Hyperspace_Jump, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Supercruise, 0);
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
                ISet.FrameShiftDrive.Hyperspace(MethodName, true);
                ISet.FrameShiftDrive.Supercruise(MethodName, false);

                //Preparations
                ISet.FrameShiftDrive.PrepHyperspace(MethodName, false);
                ISet.FrameShiftDrive.PrepSupercruise(MethodName, false);
            }
            else
            {
                //Charge Mode
                ISet.FrameShiftDrive.Supercruise(MethodName, true);
                ISet.FrameShiftDrive.Hyperspace(MethodName, false);

                //Preparations
                ISet.FrameShiftDrive.PrepHyperspace(MethodName, false);
                ISet.FrameShiftDrive.PrepSupercruise(MethodName, false);
            }

            return true;
        }

        public bool Stop(bool EmergencyDrop = false)
        {
            ISet.FrameShiftDrive.Disengaging(MethodName, true);

            //Keypress
            if (EmergencyDrop == false)
            {
                Call.Key.Press(Call.Key.Supercruise, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Supercruise, 200);
                Call.Key.Press(Call.Key.Supercruise, 0);
            }

            //Watch FSD Disengaging
            ISet.FrameShiftDrive.Disengaging(MethodName, true);
            int Count = 0; while (Disengaging == true)
            {
                if (Count > 50)
                {
                    return false;
                }
                Thread.Sleep(100); Count++;
            }

            ISet.FrameShiftDrive.Disengaging(MethodName, true);

            //Disengaged
            return true;
        }

        public bool Abort()
        {
            //Keypress
            if (Charging)
            {
                Call.Key.Press(Call.Key.Toggle_Frame_Shift_Drive, 0);
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
            ISet.FrameShiftDrive.PrepHyperspace(MethodName, false);
            ISet.FrameShiftDrive.PrepSupercruise(MethodName, false);

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
                    ISet.FrameShiftDrive.PrepHyperspace(MethodName, true);
                    ISet.FrameShiftDrive.PrepSupercruise(MethodName, false);

                    //Audio - Prepair For Hyperspace
                }
                //Supercruise
                else
                {
                    ISet.FrameShiftDrive.PrepSupercruise(MethodName, true);
                    ISet.FrameShiftDrive.PrepHyperspace(MethodName, false);

                    //Audio - Prepair For Supercruise
                }
            }
            //Reset Preprations
            else
            {
                ISet.FrameShiftDrive.PrepSupercruise(MethodName, false);
                ISet.FrameShiftDrive.PrepHyperspace(MethodName, false);
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
                ISet.FrameShiftDrive.Supercruise(MethodName, false);
                ISet.FrameShiftDrive.Hyperspace(MethodName, false);
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