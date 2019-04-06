using ALICE_Debug;
using ALICE_Internal;
using System.Threading;

namespace ALICE_Actions
{
    public static partial class IActions
    {
        public static Throttle Throttle { get; set; } = new Throttle();    
    }

    public class Throttle
    {
        public decimal Num_Boost = 0;

        public void Boost(decimal Times, bool ModifyPower, bool CommandAudio)
        {
            string MethodName = "Boost";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio
                return;
            }

            if (ICheck.Environment.Space(MethodName, false, IEnums.Supercruise) == false)
            {
                //Audio
                return;
            }
            #endregion

            #region Module Checks
            bool Pause = false;

            if (ICheck.Status.CargoScoop(MethodName, false) == false)
            {
                Call.Action.CargoScoop(false, false);
                Pause = true;
            }

            if (ICheck.LandingGear.Status(MethodName, false, true) == false)
            {
                Call.Action.LandingGear(false, false);
                Pause = true;
            }

            if (Pause == true)
            {
                Thread.Sleep(100);
            }
            #endregion

            #region Action: Set Power
            if (ModifyPower &&
                (ICheck.Status.Hardpoints(MethodName, false) == true &&
                ICheck.Order.CombatPower(MethodName, true, true) == false))
            {
                Call.Power.Set(0, 4, 8, true);
            }
            #endregion

            #region Action: Boost
            Num_Boost = Times; while (Num_Boost >= 1)
            { Num_Boost--; Call.Key.Press(Call.Key.Engine_Boost, 8000); }
            #endregion

            #region Action: Set Saved Power
            if (ModifyPower && (ICheck.Status.Hardpoints(MethodName, false) == true && ICheck.Order.CombatPower(MethodName, true, true)) == false)
            { Call.Power.SetRecorded(); }
            #endregion
        }

        public void S100(bool Negative = false)
        {
            string MethodName = "Throttle 100 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative) { Call.Key.Press(Call.Key.Set_Speed_To_Minus_100, 0, Call.Key.DelayThrottle); }
            else { Call.Key.Press(Call.Key.Set_Speed_To_100, 0); }
            #endregion
        }

        public void S95(bool Negative = false)
        {
            string MethodName = "Throttle 95 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void S90(bool Negative = false)
        {
            string MethodName = "Throttle 90 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_100, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_100, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void S85(bool Negative = false)
        {
            string MethodName = "Throttle 85 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void S80(bool Negative = false)
        {
            string MethodName = "Throttle 80 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_100, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_100, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void S75(bool Negative = false)
        {
            string MethodName = "Throttle 75 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_75, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_75, 0);
            }
            #endregion
        }

        public void S70(bool Negative = false)
        {
            string MethodName = "Throttle 70 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void S65(bool Negative = false)
        {
            string MethodName = "Throttle 65 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void S60(bool Negative = false)
        {
            string MethodName = "Throttle 60 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void S55(bool Negative = false)
        {
            string MethodName = "Throttle 55 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void S50(bool Negative = false)
        {
            string MethodName = "Throttle 50 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_50, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_50, 0);
            }
            #endregion
        }

        public void S45(bool Negative = false)
        {
            string MethodName = "Throttle 45 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void S40(bool Negative = false)
        {
            string MethodName = "Throttle 40 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void S35(bool Negative = false)
        {
            string MethodName = "Throttle 35 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void S30(bool Negative = false)
        {
            string MethodName = "Throttle 30 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void S25(bool Negative = false)
        {
            string MethodName = "Throttle 25 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_25, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_25, 0);
            }
            #endregion
        }

        public void S20(bool Negative = false)
        {
            string MethodName = "Throttle 20 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_0, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_0, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void S15(bool Negative = false)
        {
            string MethodName = "Throttle 15 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void S10(bool Negative = false)
        {
            string MethodName = "Throttle 10 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_0, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_0, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void S5(bool Negative = false)
        {
            string MethodName = "Throttle 5 (" + Negative.ToString() + ")";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void S0()
        {
            string MethodName = "Throttle 0";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            Call.Key.Press(Call.Key.Set_Speed_To_0, 0);
            #endregion
        }
    }
}
