using ALICE_Objects;
using ALICE_Equipment;

namespace ALICE_Internal
{
    public static class Check
    {
        public static Equipments Equipment = new Equipments();
        public static GameState State = new GameState();    

        public class Equipments : Base
        {
            public bool CagroScanner(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IObjects.Mothership.E.Cargo_Scanner;
                string Equipment = "Cargo Scanner";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool ChaffLauncher(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IObjects.Mothership.E.Chaff_Launcher;
                string Equipment = "Chaff Launcher";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool CollectorLimpetController(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.LimpetCollector.Settings.Installed;
                string Equipment = "Collector Limpet Controller";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool DecontaminationLimpetController(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.LimpetDecontamination.Settings.Installed;
                string Equipment = "Decontamination Limpet Controller";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool DockingComputer(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.DockingComputer.Settings.Installed;
                string Equipment = "Docking Computer";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool ECM(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.ElectronicCountermeasure.Settings.Installed;
                string Equipment = "Electronic Countermeasure";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool FuelLimpetController(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.LimpetFuel.Settings.Installed;
                string Equipment = "Fuel Limpet Controller";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool FighterHanger(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.FighterHanger.Settings.Installed;
                string Equipment = "Fighter Hanger";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool FighterHangerTotal(decimal TargetBay, string MethodName, bool DisableDebug = false)
            {
                decimal TotalBays = IEquipment.FighterHanger.Settings.Total;
                string Equipment = "Fighter Hanger Total";
                string DebugText = Equipment + " Check Failed. " + TotalBays + " Installed Fighter Bays.";
                string Color = Logger.Yellow;
                bool Answer = false;

                if (TargetBay <= TotalBays)
                {
                    Answer = true;
                    DebugText = Equipment + "Check Passed.";
                    Color = Logger.Blue;
                }

                Logger.DebugLine(MethodName, DebugText, Color);
                return Answer;
            }

            public bool HatchBreakerLimpetController(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.LimpetHatchBreaker.Settings.Installed;
                string Equipment = "Hatch Breaker Limpet Controller";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool HeatSinkLauncher(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IObjects.Mothership.E.Heat_Sink_Launcher;
                string Equipment = "Heat Sink Launcher";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool KillWarrantScanner(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IObjects.Mothership.E.Kill_Warrant_Scanner;
                string Equipment = "Kill Warrant Scanner";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool MiningLaser(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IObjects.Mothership.E.Mining_Laser;
                string Equipment = "Mining Laser";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool ProspectorLimpetController(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.LimpetProspector.Settings.Installed;
                string Equipment = "Prospector Limpet Controller";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool ReconLimpetController(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.LimpetRecon.Settings.Installed;
                string Equipment = "Recon Limpet Controller";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool ResearchLimpetController(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.LimpetResearch.Settings.Installed;
                string Equipment = "Research Limpet Controller";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool RepairLimpetController(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.LimpetRepair.Settings.Installed;
                string Equipment = "Repair Limpet Controller";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool ShieldCellBank(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.ShieldCellBank.Settings.Installed;
                string Equipment = "Shield Cell Bank";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool XenoScanner(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.XenoScanner.Settings.Installed;
                string Equipment = "Xeno Scanner";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool SurfaceScanner(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.SurfaceScanner.Settings.Installed;
                string Equipment = "Surface Scanner";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }

            public bool WakeScanner(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEquipment.WakeScanner.Settings.Installed;
                string Equipment = "Wake Scanner";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }
        }   

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