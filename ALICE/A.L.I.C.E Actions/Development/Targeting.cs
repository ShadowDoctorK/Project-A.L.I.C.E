using ALICE_Debug;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Objects;
using ALICE_Status;
using System.Threading;

namespace ALICE_Actions
{
    public static partial class IActions
    {
        public static Targeting Targeting = new Targeting();       
    }

    public class Targeting
    {
        public string Scan_OrdSubsystemName = "";

        #region Simple Target Actions
        public void Subsystems(decimal Cycle, bool Forward, bool CommandAudio)
        {
            string MethodName = "Cycle Subsystems";

            if (ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space) == false)
            {
                return;
            }

            while (Cycle != 0 && Cycle > 0)
            {
                if (Forward == true)
                {
                    IKeyboard.Press(IKey.Cycle_Next_Subsystem, 150);
                }
                else if (Forward == false)
                {
                    IKeyboard.Press(IKey.Cycle_Previous_Subsystem, 150);
                }

                if (IObjects.TargetCurrent.Targeted == false)
                {
                    return;
                }

                Cycle--;
                //CurrentSubsystemPos++;
            }
        }

        public void HostileTargets(decimal Cycle, bool Forward)
        {
            string MethodName = "Cycle Hostile Target";

            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio
                return;
            }

            while (Cycle != 0 && Cycle > 0)
            {
                if (Forward == true)
                {
                    IKeyboard.Press(IKey.Cycle_Next_Hostile_Target, 0);
                }
                else if (Forward == false)
                {
                    IKeyboard.Press(IKey.Cycle_Previous_Hostile_Ship, 0);
                }
                Cycle--;
                Thread.Sleep(100);
            }
        }

        public void Target(decimal Cycle, bool Forward)
        {
            string MethodName = "Cycle Target";

            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio
                return;
            }

            while (Cycle != 0 && Cycle > 0)
            {
                if (Forward == true)
                {
                    IKeyboard.Press(IKey.Cycle_Next_Target, 0);
                }
                else if (Forward == false)
                {
                    IKeyboard.Press(IKey.Cycle_Previous_Ship, 0);
                }
                Cycle--;
                Thread.Sleep(100);
            }
        }

        public void Wingman(decimal W, bool CommandAudio)
        {
            string MethodName = "Select Wingman";

            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio
                return;
            }

            if (IStatus.InWing == false)
            {
                //Audio - We are not in a wing.
                return;
            }

            if (W == 1)
            {
                IKeyboard.Press(IKey.Select_Wingman_1, 0);
            }
            else if (W == 2)
            {
                IKeyboard.Press(IKey.Select_Wingman_2, 0);
            }
            else if (W == 3)
            {
                IKeyboard.Press(IKey.Select_Wingman_3, 0);
            }

            Thread.Sleep(100);

            //Variable Audio Responce based on Deicmal "Wingman"
        }

        public void WingmansTarget(decimal W, bool CommandAudio)
        {
            if (IStatus.InWing == false)
            {
                //Audio - We are not in a wing.
                return;
            }

            if (W != 0)
            {
                Wingman(W, false);
            }

            IKeyboard.Press(IKey.Select_Wingmans_Target, 100);

            //DYNAMIC AUDIO
        }

        public void WingmansNavLock(decimal W, bool CommandAudio)
        {
            if (IStatus.InWing == false)
            {
                //Audio - We are not in a wing.
                return;
            }

            if (W != 0)
            {
                Wingman(W, false);
            }
            IKeyboard.Press(IKey.Wingman_NavLock, 100);

            //DYNAMIC AUDIO
        }

        #endregion
    }
}
