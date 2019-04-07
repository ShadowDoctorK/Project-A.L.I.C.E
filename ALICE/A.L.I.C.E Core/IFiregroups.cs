using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ALICE.Properties;
using ALICE_Actions;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Objects;

namespace ALICE_Core
{
    public class IFiregroups
    {
        public bool Update { get; set; }
        public decimal Total { get; set; }
        public decimal Current { get; set; }
        public decimal Default { get; set; }

        public IFiregroups()
        {
            Update = true;
            Total = GetTotal();
            Default = GetDefault();
        }

        public void Select(decimal Target, bool CommandAudio, bool HudSwitch = false, bool AnalysisMode = false)
        {
            string MethodName = "Firegroup Select";

            #region Validation
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio - Cant Do That
                return;
            }
            #endregion

            #region HUD Mode
            if (HudSwitch && AnalysisMode == true)
            {
                if (ICheck.Status.AnalysisMode(MethodName, true) == false)
                {
                    Call.Action.AnalysisMode(true, false); Thread.Sleep(500);
                }                
            }
            else if (HudSwitch && AnalysisMode == false)
            {
                if (ICheck.Status.AnalysisMode(MethodName, false) == false)
                {
                    Call.Action.AnalysisMode(false, false); Thread.Sleep(500);
                }
            }
            #endregion

            Logger.DebugLine(MethodName, "Target Firegroup: " + Target + " | Current Firegroup: " + Current, Logger.Yellow);

            if (Target <= Total)
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
            Logger.Log(MethodName, "Not A Valid Firegroup. Total Groups Detected: " + Call.Firegroup.Total, Logger.Red);
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

            if (Total != Tracked)
            {
                //Audio Updating Complete
                //Audio Total Changed 

                Total = Tracked;
                Miscellanous.Default["FireGroup_Total"] = Total;
                Miscellanous.Default.Save();
            }

            Logger.Log(MethodName, "Total Firegroups Updated To " + Tracked, Logger.Yellow, true);
        }

        public void Update_Default(decimal Number)
        {
            string MethodName = "Update Default Group";

            Default = Number;
            Miscellanous.Default["FireGroup_Default"] = Default;
            Miscellanous.Default.Save();
            Logger.Log(MethodName, "Default Firegroup Updated To " + Number, Logger.Yellow, true);
        }

        public decimal GetTotal()
        {
            string MethodName = "Firegroup Load Total";
            try { return Convert.ToDecimal(Miscellanous.Default["FireGroup_Total"]); }
            catch (Exception)
            {
                Logger.Exception(MethodName, "Something Went Wrong. Using Default Of 1.");
                return 1;
            }
        }

        public decimal GetDefault()
        {
            string MethodName = "Firegroup Load Default";
            try { return Convert.ToDecimal(Miscellanous.Default["FireGroup_Default"]); }
            catch (Exception)
            {
                Logger.Exception(MethodName, "Something Went Wrong. Using Default Of 1.");
                return 1;
            }
        }
    }
}
