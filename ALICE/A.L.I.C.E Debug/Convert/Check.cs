using ALICE_Objects;

namespace ALICE_Internal
{
    public static class Check
    {
        public static GameState State = new GameState();    

        public class GameState : Base
        {
            public bool FacilityCurrent_State(string CheckState, bool IsTarget, string MethodName, bool DisableDebug = false, bool Answer = true)
            {
                string Item = IObjects.FacilityCurrent.ControlFactionState;
                string Not = ""; if (IsTarget == false) { Not = "Not "; }
                string DebugText = "Current Facility State Check Passed (" + Not + CheckState + ")";
                string Color = Logger.Blue;

                if (IsTarget == true && Item != CheckState)
                {
                    Answer = false;
                    DebugText = "Current Facility State Does Not Equal " + CheckState + " (" + Item + ")";
                    Color = Logger.Yellow;
                }
                else if (IsTarget == false && Item == CheckState)
                {
                    Answer = false;
                    DebugText = "Current Facility State Equals " + CheckState + " (" + Item + ")";
                    Color = Logger.Yellow;
                }

                if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                return Answer;
            }
        }

        public class Base
        {
            public bool Check_Variable(bool TargetState, string MethodName, bool State, string Variable, bool DisableDebug = false, bool Answer = true)
            {
                string DebugText = Variable + " Check Equals Expected State (" + TargetState + ")";
                string Color = Logger.Blue;

                if (TargetState != State)
                {
                    Answer = false;
                    DebugText = Variable + " Check Does Not Equals Expected State (" + TargetState + ")";
                    Color = Logger.Yellow;
                }

                if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                return Answer;
            }

            public bool Check_PanelTab(decimal TargetTab, string MethodName, decimal CurrentTab, string Variable, bool DisableDebug = false, bool Answer = true)
            {
                string DebugText = Variable + " Check Equals Expected State (" + TargetTab + ")";
                string Color = Logger.Blue;

                if (TargetTab != CurrentTab)
                {
                    Answer = false;
                    DebugText = Variable + " Check Does Not Equals Expected State (" + TargetTab + ")";
                    Color = Logger.Yellow;
                }

                if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                return Answer;
            }

            public bool Check_Report(bool TargetState, string MethodName, bool State, string Report, bool DisableDebug = false, bool Answer = true)
            {
                string DebugText = Report + " Check Equals Expected State (" + TargetState + ")";
                string Color = Logger.Blue;

                if (TargetState != State)
                {
                    Answer = false;
                    DebugText = Report + " Check Does Not Equal Expected State (" + TargetState + ")";
                    Color = Logger.Yellow;
                }

                if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                return Answer;
            }

            public bool Check_Order(bool TargetState, string MethodName, bool State, string Order, bool DisableDebug = false, bool Answer = true)
            {
                string DebugText = Order + " Check Equals Expected State (" + TargetState + ")";
                string Color = Logger.Blue;

                if (TargetState != State)
                {
                    Answer = false;
                    DebugText = Order + " Check Does Not Equal Expected State (" + TargetState + ")";
                    Color = Logger.Yellow;
                }

                if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                return Answer;
            }

            public bool Check_Equipment(bool TargetState, string MethodName, bool State, string Equipment, bool DisableDebug = false, bool Answer = true)
            {
                string DebugText = Equipment + " Check Equals Expected State  (" + TargetState + ")";
                string Color = Logger.Blue;

                if (TargetState != State)
                {
                    Answer = false;
                    DebugText = Equipment + " Check Does Not Equal Expected State (" + TargetState + ")";
                    Color = Logger.Yellow;
                }

                if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                return Answer;
            }
        }
    }
}