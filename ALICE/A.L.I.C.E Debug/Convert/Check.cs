﻿using ALICE_Actions;
using ALICE_Objects;
using ALICE_Core;
using ALICE_Equipment;

namespace ALICE_Internal
{
    public static class Check
    {
        public static Environments Environment = new Environments();
        public static Equipments Equipment = new Equipments();
        public static Variables Variable = new Variables();
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
                string Equipment = "Surface Scanner";
                return Check_Equipment(TargetState, MethodName, State, Equipment, DisableDebug);
            }
        }

        public class Environments : Base
        {
            public bool Vehicle(IVehicles.V TargetVehcile, bool TargetState, string MethodName, bool DisableDebug = false, bool Answer = true)
            {
                IVehicles.V Vehic = IVehicles.Vehicle;
                string Not = ""; if (TargetState == false) { Not = "Not "; }
                string DebugText = "Vehcile Check Passed (" + Not + TargetVehcile + ")";
                string Color = Logger.Blue;

                if (TargetState == true && Vehic != TargetVehcile)
                {
                    Answer = false;
                    DebugText = "Vehcile Does Not Equal " + TargetVehcile;
                    Color = Logger.Yellow;
                }
                else if (TargetState == false && Vehic == TargetVehcile)
                {
                    Answer = false;
                    DebugText = "Vehcile Equals " + TargetVehcile;
                    Color = Logger.Yellow;
                }

                if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                return Answer;
            }

            public bool Altitude(decimal LowAltitude, decimal HighAltitude, bool InsideBand, string MethodName, bool DisableDebug = false, bool Answer = true)
            {
                decimal Altitude = IStatus.Altitude;
                string DebugText = "Altitude Check Passed (Low: " + LowAltitude + " | High: " + HighAltitude + ")";
                string Color = Logger.Blue;

                if (InsideBand == false && (Altitude >= LowAltitude && Altitude <= HighAltitude))
                {
                    Answer = false;
                    DebugText = "Altitude Check Failed - Inside Band (Low: " + LowAltitude + " | High: " + HighAltitude + ")";
                    Color = Logger.Yellow;
                }
                //Checking Inside Band - We Are Outside of Altitude Band, Return False.
                else if (InsideBand == true && (Altitude < LowAltitude || Altitude > HighAltitude))
                {
                    Answer = false;
                    DebugText = "Altitude Check Failed - Outside Band (Low: " + LowAltitude + " | High: " + HighAltitude + ")";
                    Color = Logger.Yellow;
                }

                if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                return Answer;
            }

            public bool Firegroup(decimal Target, bool IsTarget, string MethodName, bool DisableDebug = false, bool Answer = true)
            {
                decimal Firegroup = Call.Firegroup.Current;
                string Not = ""; if (IsTarget == false) { Not = "Not "; }
                string DebugText = "Firegroup Check Passed (" + Not + Target + ")";
                string Color = Logger.Blue;

                if (IsTarget == true && Firegroup != Target)
                {
                    Answer = false;
                    DebugText = "Firegroup Does Not Equal " + Target;
                    Color = Logger.Yellow;
                }
                else if (IsTarget == false && Firegroup == Target)
                {
                    Answer = false;
                    DebugText = "Firegroup Equals " + Target;
                    Color = Logger.Yellow;
                }

                if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                return Answer;
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

        public class Variables : Base
        {
            public bool AnalysisMode(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.AnalysisMode;
                string Variable = "Analysis Mode";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            #region Cargo Scoop
            public bool CargoScoop(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.CargoScoop;
                string Variable = "Cargo Scoop";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool CargoScoop(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Cargo Scoop";
                bool Value = IStatus.CargoScoop;
                if (DisableDebug == false) { Logger.DebugLine(MethodName, Variable + " Check Returned (" + Value + ")", Logger.Blue); }

                return Value;
            }
            #endregion

            public bool NPC_Crew(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.NPC_Crew;
                string Variable = "NPC Crew";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool FighterDeployed(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.Fighter.Deployed;
                string Variable = "Fighter Deployed";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool FlightAssist(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.FlightAssist;
                string Variable = "Flight Assist";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool FlightAssist(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Flight Assist";
                bool Value = IStatus.FlightAssist;
                if (DisableDebug == false) { Logger.DebugLine(MethodName, Variable + " Check Returned (" + Value + ")", Logger.Blue); }

                return Value;
            }

            public bool FuelScooping(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.FuelScooping;
                string Variable = "Fuel Scooping";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            #region Hardpoints
            public bool Hardpoints(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.Hardpoints;
                string Variable = "Hardpoints";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool Hardpoints(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Hardpoints";
                bool Value = IStatus.Hardpoints;
                if (DisableDebug == false) { Logger.DebugLine(MethodName, Variable + " Check Returned (" + Value + ")", Logger.Blue); }

                return Value;
            }
            #endregion

            #region Over Heating
            public bool Overheating(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.Overheating;
                string Variable = "Over Heating";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool Overheating(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Over Heating";
                bool Value = IStatus.Overheating;
                if (DisableDebug == false) { Logger.DebugLine(MethodName, Variable + " Check Returned (" + Value + ")", Logger.Blue); }

                return Value;
            }
            #endregion

            #region Silent Running
            public bool SilentRunning(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.SilentRunning;
                string Variable = "Silent Running";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool SilentRunning(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Silent Running";
                bool Value = IStatus.SilentRunning;
                if (DisableDebug == false) { Logger.DebugLine(MethodName, Variable + " Check Returned (" + Value + ")", Logger.Blue); }

                return Value;
            }
            #endregion

            public bool Touchdown(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.Touchdown;
                string Variable = "Touchdown";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
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