using System.Threading;
using ALICE_Actions;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Settings;

namespace ALICE_Core
{
    public class IFiregroups
    {
        public bool Update { get; set; }
        //public decimal Total { get; set; }
        public decimal Current { get; set; }
        //public decimal Default { get; set; }

        public IFiregroups()
        {
            Update = true;
        }

        public void Select(decimal Target, bool CommandAudio, bool HudSwitch = false, bool HudMode = false)
        {
            string MethodName = "Firegroup Select";

            #region Validation
            //Check Space
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio - Cant Do That
                return;
            }

            //Check Valid Group
            if (Target < 1 || Target > 8)
            {
                Logger.Log(MethodName, Target + " Is Not A Valid Fire Group. Must Be A Number Between 1 & 8.", Logger.Red);
                return;
            }
            #endregion

            #region HUD Mode
            if (HudSwitch)
            {
                if (ICheck.Status.AnalysisMode(MethodName, HudMode) == false)
                {
                    IActions.Hardpoints.Mode(HudMode, CommandAudio); Thread.Sleep(500);
                }                
            }
            #endregion

            Logger.DebugLine(MethodName, "Target Firegroup: " + Target + " | Current Firegroup: " + Current, Logger.Yellow);

            if (Target <= ISettings.Firegroup.Groups)
            {
                if (Target < Current)
                {
                    decimal Cycle = Current - Target; while (Cycle != 0 && Cycle > 0)
                    { IKeyboard.Press(IKey.Cycle_Previous_Fire_Group, 100, IKey.DelayFireGroup); Cycle--; }
                }
                else if (Target > Current)
                {
                    decimal Cycle = Target - Current; while (Cycle != 0 && Cycle > 0)
                    { IKeyboard.Press(IKey.Cycle_Next_Fire_Group, 100, IKey.DelayFireGroup); Cycle--; }
                }

                Current = Target;

                //Audio - Selected
                return;
            }

            //Audio - Not Valid
            Logger.Log(MethodName, "Not A Valid Firegroup. Total Groups Detected: " + ISettings.Firegroup.Groups, Logger.Red);
            return;
        }

        public void Update_Total(bool CommandAudio)
        {
            string MethodName = "Update Fire Groups";

            //Check Plugin Initialized
            if (ICheck.Initialized(MethodName) == false) { return; }

            decimal Saved = Current;
            decimal Tracked = 1;

            #region Valid Command Checks
            //Docked Check
            if (ICheck.Docking.Status(MethodName, true, IEnums.DockingState.Docked, true) == true)
            {
                return;
            }

            //Touchdown Check
            if (ICheck.Status.Touchdown(MethodName, false) == false)
            {
                return;
            }
            #endregion

            IKeyboard.Press(IKey.Cycle_Next_Fire_Group, 1500, IKey.DelayFireGroup);

            decimal Count = 10; while (Call.Firegroup.Current != Saved && Count != 0)
            {
                Count--; if (Current > Tracked) { Tracked = Current; }
                IKeyboard.Press(IKey.Cycle_Next_Fire_Group, 1500, IKey.DelayFireGroup);
                Logger.DebugLine(MethodName, "Tracking Group: " + Tracked, Logger.Yellow);
            }

            if (Count == 0)
            {
                Logger.Log(MethodName, "Inaccurate Firegroup Detection, Try Again...", Logger.Red);
                return;
            }

            if (ISettings.Firegroup.Groups != Tracked)
            {
                //Audio Updating Complete
                //Audio Total Changed 

                ISettings.Firegroup.Groups = Tracked;                
                ISettings.Firegroup.Save(MethodName);
            }

            Logger.Log(MethodName, "Total Firegroups Updated To " + Tracked, Logger.Yellow, true);
        }
    }
}
