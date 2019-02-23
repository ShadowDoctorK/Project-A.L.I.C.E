using ALICE_Events;
using ALICE_Actions;
using ALICE_Interface;
using ALICE_Objects;
using ALICE_Monitors;
using ALICE_Core;
using ALICE_Settings;

namespace ALICE_Internal
{
    public static class Check
    {
        public static Environments Environment = new Environments();
        public static Equipments Equipment = new Equipments();
        public static Dockings Docking = new Dockings();
        public static Panels Panel = new Panels();
        public static Reports Report = new Reports();
        public static Orders Order = new Orders();
        public static Variables Variable = new Variables();
        public static Events Event = new Events();
        public static GameState State = new GameState();
        public static Internals Internal = new Internals();

        public class Panels : Base
        {
            #region System Panel
            public bool System(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = Call.Panel.System.Open;
                string Variable = "System Panel (Open)";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool Home(string MethodName, bool DisableDebug = false)
            {
                string Variable = "System Panel (Home Tab)";
                decimal Target = Call.Panel.System.Home.Tab;
                decimal Current = Call.Panel.System.Pos;
                return Check_PanelTab(Target, MethodName, Current, Variable);
            }

            public bool Modules(string MethodName, bool DisableDebug = false)
            {
                string Variable = "System Panel (Modules Tab)";
                decimal Target = Call.Panel.System.Modules.Tab;
                decimal Current = Call.Panel.System.Pos;
                return Check_PanelTab(Target, MethodName, Current, Variable);
            }

            public bool FireGroups(string MethodName, bool DisableDebug = false)
            {
                string Variable = "System Panel (FireGroups Tab)";
                decimal Target = Call.Panel.System.FireGroups.Tab;
                decimal Current = Call.Panel.System.Pos;
                return Check_PanelTab(Target, MethodName, Current, Variable);
            }

            public bool Ship(string MethodName, bool DisableDebug = false)
            {
                string Variable = "System Panel (Ship Tab)";
                decimal Target = Call.Panel.System.Ship.Tab;
                decimal Current = Call.Panel.System.Pos;
                return Check_PanelTab(Target, MethodName, Current, Variable);
            }

            public bool Inventory(string MethodName, bool DisableDebug = false)
            {
                string Variable = "System Panel (Inventory Tab)";
                decimal Target = Call.Panel.System.Inventory.Tab;
                decimal Current = Call.Panel.System.Pos;
                return Check_PanelTab(Target, MethodName, Current, Variable);
            }

            public bool Status(string MethodName, bool DisableDebug = false)
            {
                string Variable = "System Panel (Status Tab)";
                decimal Target = Call.Panel.System.Status.Tab;
                decimal Current = Call.Panel.System.Pos;
                return Check_PanelTab(Target, MethodName, Current, Variable);
            }

            public bool Media(string MethodName, bool DisableDebug = false)
            {
                string Variable = "System Panel (Media Tab)";
                decimal Target = Call.Panel.System.Media.Tab;
                decimal Current = Call.Panel.System.Pos;
                return Check_PanelTab(Target, MethodName, Current, Variable);
            }
            #endregion

            #region Role Panel
            public bool Role(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = Call.Panel.Role.Open;
                string Variable = "Role Panel";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool All(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Role Panel (All Tab)";
                decimal Role = Call.Panel.Role.All.Tab;
                decimal Current = Call.Panel.Role.Pos;
                return Check_PanelTab(Role, MethodName, Current, Variable);
            }

            public bool Helm(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Role Panel (Helm Tab)";
                decimal Role = Call.Panel.Role.Helm.Tab;
                decimal Current = Call.Panel.Role.Pos;
                return Check_PanelTab(Role, MethodName, Current, Variable);
            }

            public bool Fighters(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Role Panel (EQ_Fighters Tab)";
                decimal Role = Call.Panel.Role.Fighters.Tab;
                decimal Current = Call.Panel.Role.Pos;
                return Check_PanelTab(Role, MethodName, Current, Variable);
            }

            public bool SRV(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Role Panel (SRV Tab)";
                decimal Role = Call.Panel.Role.SRV.Tab;
                decimal Current = Call.Panel.Role.Pos;
                return Check_PanelTab(Role, MethodName, Current, Variable);
            }

            public bool Crew(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Role Panel (Crew Tab)";
                decimal Role = Call.Panel.Role.Crew.Tab;
                decimal Current = Call.Panel.Role.Pos;
                return Check_PanelTab(Role, MethodName, Current, Variable);
            }

            public bool Help(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Role Panel (Help Tab)";
                decimal Role = Call.Panel.Role.Help.Tab;
                decimal Current = Call.Panel.Role.Pos;
                return Check_PanelTab(Role, MethodName, Current, Variable);
            }
            #endregion

            #region Comms Panel
            public bool Comms(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = Call.Panel.Comms.Open;
                string Variable = "Comms Panel";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool Chat(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Comms Panel (Chat Tab)";
                decimal Comms = Call.Panel.Comms.Chat.Tab;
                decimal Current = Call.Panel.Comms.Pos;
                return Check_PanelTab(Comms, MethodName, Current, Variable);
            }

            public bool Inbox(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Comms Panel (Inbox Tab)";
                decimal Comms = Call.Panel.Comms.Inbox.Tab;
                decimal Current = Call.Panel.Comms.Pos;
                return Check_PanelTab(Comms, MethodName, Current, Variable);
            }

            public bool Social(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Comms Panel (Social Tab)";
                decimal Comms = Call.Panel.Comms.Social.Tab;
                decimal Current = Call.Panel.Comms.Pos;
                return Check_PanelTab(Comms, MethodName, Current, Variable);
            }

            public bool History(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Comms Panel (History Tab)";
                decimal Comms = Call.Panel.Comms.History.Tab;
                decimal Current = Call.Panel.Comms.Pos;
                return Check_PanelTab(Comms, MethodName, Current, Variable);
            }

            public bool Squadron(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Comms Panel (Squadron Tab)";
                decimal Comms = Call.Panel.Comms.Squadron.Tab;
                decimal Current = Call.Panel.Comms.Pos;
                return Check_PanelTab(Comms, MethodName, Current, Variable);
            }

            public bool Settings(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Comms Panel (Settings Tab)";
                decimal Comms = Call.Panel.Comms.Settings.Tab;
                decimal Current = Call.Panel.Comms.Pos;
                return Check_PanelTab(Comms, MethodName, Current, Variable);
            }
            #endregion

            #region Target Panel
            public bool Target(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = Call.Panel.Target.Open;
                string Variable = "Target Panel";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool Navigation(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Target Panel (Navigation Tab)";
                decimal Target = Call.Panel.Target.Navigation.Tab;
                decimal Current = Call.Panel.Target.Pos;
                return Check_PanelTab(Target, MethodName, Current, Variable);
            }

            public bool Transactions(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Target Panel (Transactions Tab)";
                decimal Target = Call.Panel.Target.Transactions.Tab;
                decimal Current = Call.Panel.Target.Pos;
                return Check_PanelTab(Target, MethodName, Current, Variable);
            }

            public bool Contacts(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Target Panel (Contacts Tab)";
                decimal Target = Call.Panel.Target.Contacts.Tab;
                decimal Current = Call.Panel.Target.Pos;
                return Check_PanelTab(Target, MethodName, Current, Variable);
            }
            #endregion

            #region Galaxy Map
            public bool GalaxyMap(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = Call.Panel.GalaxyMap.Open;
                string Variable = "Galaxy Map";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool Info(string MethodName, bool DisableDebug = false)
            {
                string Variable = "GalaxyMap Panel (Information Tab)";
                decimal GalaxyMap = Call.Panel.GalaxyMap.Info.Tab;
                decimal Current = Call.Panel.GalaxyMap.Pos;
                return Check_PanelTab(GalaxyMap, MethodName, Current, Variable);
            }

            public bool Search(string MethodName, bool DisableDebug = false)
            {
                string Variable = "GalaxyMap Panel (Search Tab)";
                decimal GalaxyMap = Call.Panel.GalaxyMap.Search.Tab;
                decimal Current = Call.Panel.GalaxyMap.Pos;
                return Check_PanelTab(GalaxyMap, MethodName, Current, Variable);
            }

            public bool Bookmarks(string MethodName, bool DisableDebug = false)
            {
                string Variable = "GalaxyMap Panel (Bookmarks Tab)";
                decimal GalaxyMap = Call.Panel.GalaxyMap.Bookmarks.Tab;
                decimal Current = Call.Panel.GalaxyMap.Pos;
                return Check_PanelTab(GalaxyMap, MethodName, Current, Variable);
            }

            public bool Config(string MethodName, bool DisableDebug = false)
            {
                string Variable = "GalaxyMap Panel (Config Tab)";
                decimal GalaxyMap = Call.Panel.GalaxyMap.Config.Tab;
                decimal Current = Call.Panel.GalaxyMap.Pos;
                return Check_PanelTab(GalaxyMap, MethodName, Current, Variable);
            }

            public bool Options(string MethodName, bool DisableDebug = false)
            {
                string Variable = "GalaxyMap Panel (Options Tab)";
                decimal GalaxyMap = Call.Panel.GalaxyMap.Options.Tab;
                decimal Current = Call.Panel.GalaxyMap.Pos;
                return Check_PanelTab(GalaxyMap, MethodName, Current, Variable);
            }
            #endregion

            #region System Map
            public bool SystemMap(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = Call.Panel.SystemMap.Open;
                string Variable = "System Map";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }
            #endregion
        }

        public class Orders : Base
        {
            public bool AssistDocking(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.AssistDocking;
                string Order = "Assisted Docking Procedures";
                return Check_Order(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool AssistSystemScan(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.AssistSystemScan;
                string Order = "Assisted System Scans";
                return Check_Order(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool AssistRefuel(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.AssistRefuel;
                string Order = "Assisted Station Refueling";
                return Check_Order(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool AssistRearm(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.AssistRearm;
                string Order = "Assisted Station Rearming";
                return Check_Order(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool AssistRepair(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.AssistRepair;
                string Order = "Assisted Station Repairing";
                return Check_Order(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool AssistHangerEntry(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.AssistHangerEntry;
                string Order = "Assisted Hanger Entry";
                return Check_Order(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool CombatPower(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.CombatPower;
                string Order = "Combat Power Management";
                return Check_Order(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool PostJumpSafety(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.PostHyperspaceSafety;
                string Order = "Post Jump Safeties";
                return Check_Order(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool WeaponSafety(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.WeaponSafety;
                string Order = "Weapon Safety Interlocks";
                return Check_Order(TargetState, MethodName, State, Order, DisableDebug);
            }
        }

        public class Reports : Base
        {
            public bool FuelStatus(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.FuelStatus;
                string Order = "Fuel Report";
                return Check_Report(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool FuelScoop(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.FuelScoop;
                string Order = "Fuel Scoop";
                return Check_Report(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool ShieldState(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.ShieldState;
                string Order = "Shield State";
                return Check_Report(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool CollectedBounty(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.CollectedBounty;
                string Order = "Collected Bounty";
                return Check_Report(TargetState, MethodName, State, Order, DisableDebug);
            }

            public bool Masslock(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.Masslock;
                string Order = "Masslock";
                return Check_Report(TargetState, MethodName, State, Order, DisableDebug);
            }
            public bool StationStatus(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.StationStatus;
                string Order = "Station Status";
                return Check_Report(TargetState, MethodName, State, Order, DisableDebug);
            }
            public bool MaterialCollected(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.MaterialCollected;
                string Order = "Material Collected";
                return Check_Report(TargetState, MethodName, State, Order, DisableDebug);
            }
            public bool MaterialRefined(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.MaterialRefined;
                string Order = "Material Refined";
                return Check_Report(TargetState, MethodName, State, Order, DisableDebug);
            }
            public bool TargetWanted(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.TargetWanted;
                string Order = "Wanted Target";
                return Check_Report(TargetState, MethodName, State, Order, DisableDebug);
            }
            public bool TargetEnemy(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = ISettings.TargetEnemy;
                string Order = "Hostile Faction";
                return Check_Report(TargetState, MethodName, State, Order, DisableDebug);
            }
        }

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
            public bool Space(string TargetEnvironment, bool DesiredEnvironment, string MethodName, bool DisableDebug = false, bool Answer = true)
            {
                string Environment = IEnums.Normal_Space;
                string Not = ""; if (DesiredEnvironment == false) { Not = "Not "; }
                string DebugText = "Environment Check Passed (" + Not + TargetEnvironment + ")";
                string Color = Logger.Blue;

                if (IStatus.Hyperspace == true)
                { Environment = IEnums.Hyperspace; }

                else if (IStatus.Supercruise == true)
                { Environment = IEnums.Supercruise; }

                if (DesiredEnvironment == true && Environment != TargetEnvironment)
                {
                    Answer = false;
                    DebugText = "Environment Does Not Equal " + TargetEnvironment;
                    Color = Logger.Yellow;
                }
                else if (DesiredEnvironment == false && Environment == TargetEnvironment)
                {
                    Answer = false;
                    DebugText = "Environment Equals " + TargetEnvironment;
                    Color = Logger.Yellow;
                }

                if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                return Answer;
            }

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

        public class Dockings
        {
            public bool Status(IEnums.DockingState TargetStatus, bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool Answer = true;
                IEnums.DockingState Status = IStatus.Docking.State;
                string Not = ""; if (TargetState == false) { Not = "Not "; }
                string DebugText = "Docking Status Check Passed, Equals Expected State (" + Not + TargetStatus + ")";
                string Color = Logger.Blue;

                if (TargetState == true && Status != TargetStatus)
                {
                    Answer = false;
                    DebugText = "Docking Status Check Failed, Not Equal Checked State (" + TargetStatus + ")";
                    Color = Logger.Yellow;
                }
                else if (TargetState == false && Status == TargetStatus)
                {
                    Answer = false;
                    DebugText = "Docking Status Check Failed, Equals Checked State (" + TargetStatus + ")";
                    Color = Logger.Yellow;
                }

                if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                return Answer;
            }

            public bool DeniedReason(IEnums.DockingDenial TargetReason, bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool Answer = true;
                IEnums.DockingDenial Reason = IStatus.Docking.Denial;
                string DebugText = "Reason Check Passed (" + TargetReason + ")";
                string Color = Logger.Blue;

                if (TargetState == true && Reason != TargetReason)
                {
                    Answer = false;
                    DebugText = "Reason Does Not Equal " + TargetReason;
                    Color = Logger.Yellow;
                }
                else if (TargetState == false && Reason == TargetReason)
                {
                    Answer = false;
                    DebugText = "Reason Equals " + TargetReason;
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

        public class Internals : Base
        {
            public bool TriggerEvents(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IEvents.TriggerEvents;
                string Variable = "Trigger Events";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool CommandExist(string CommandName, string MethodName, bool DisableDebug = false)
            {
                bool State = IPlatform.CommandExists(CommandName);
                string Variable = "Command Exist";
                return Check_Variable(true, MethodName, State, Variable, DisableDebug);
            }

            public bool JsonInitialized(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = PlugIn.M_Json.Settings.Initialized;
                string Variable = "JSON Reader Initialized";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
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

            #region Landing Gear
            public bool LandingGear(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.LandingGear;
                string Variable = "Landing Gear";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

            public bool LandingGear(string MethodName, bool DisableDebug = false)
            {
                string Variable = "Landing Gear";
                bool Value = IStatus.LandingGear;
                if (DisableDebug == false) { Logger.DebugLine(MethodName, Variable + " Check Returned (" + Value + ")", Logger.Blue); }
                return Value;
            }
            #endregion

            public bool MassLocked(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.Masslocked;
                string Variable = "Mass Locked";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

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

            public bool Shields(bool TargetState, string MethodName, bool DisableDebug = false)
            {
                bool State = IStatus.Shields;
                string Variable = "Shields";
                return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
            }

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

        public class Events
        {
            #region Static Instances
            public C_Masslock Masslock = new C_Masslock();
            public C_Music Music = new C_Music();
            public C_NoFireZone NoFireZone = new C_NoFireZone();
            public C_SupercruiseExit SupercruiseExit = new C_SupercruiseExit();
            #endregion

            #region Class Objects

            public class C_Music : Base
            {
                public string EventName = IEnums.Music;

                public bool MusicTrack(string CheckMusic, bool IsTarget, string MethodName, bool DisableDebug = false, bool Answer = true)
                {
                    Music Event = (Music)IEvents.GetEvent(IEnums.Music);

                    string DebugText = CheckMusic + " Check Equals Expected State (" + IsTarget + ")";
                    string Color = Logger.Blue;

                    if (Event == null)
                    {
                        if (IsTarget == true) { return false; }
                        if (IsTarget == false) { return true; }
                    }

                    if (IsTarget == true && Event.MusicTrack != CheckMusic)
                    {
                        Answer = false;
                        DebugText = CheckMusic + " Check Does Not Equal Expected State (" + IsTarget + ")";
                        Color = Logger.Red;
                    }

                    else if (IsTarget == false && Event.MusicTrack == CheckMusic)
                    {
                        Answer = false;
                        DebugText = CheckMusic + " Check Does Not Equal Expected State (" + IsTarget + ")";
                        Color = Logger.Red;
                    }

                    if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                    return Answer;
                }

            }

            public class C_NoFireZone : Base
            {
                public string EventName = IEnums.NoFireZone;

                public bool Entered(bool TargetState, string MethodName, bool DisableDebug = false, bool Answer = false)
                {
                    NoFireZone Event = (NoFireZone)IEvents.GetEvent(IEnums.NoFireZone);

                    if (Event == null)
                    {
                        if (TargetState == true) { return false; }
                        if (TargetState == false) { return true; }
                    }

                    bool State = Event.Entered;
                    string Variable = "No Fire Zone";
                    return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
                }

            }

            public class C_Masslock : Base
            {
                public string EventName = IEnums.Masslock;

                public bool Masslocked(bool TargetState, string MethodName, bool DisableDebug = false, bool Answer = false)
                {
                    ALICE_Events.Masslock Event = (ALICE_Events.Masslock)IEvents.GetEvent(IEnums.Masslock);

                    if (Event == null)
                    {
                        if (TargetState == true) { return false; }
                        if (TargetState == false) { return true; }
                    }

                    bool State = Event.Masslocked;
                    string Variable = "Masslocked";
                    return Check_Variable(TargetState, MethodName, State, Variable, DisableDebug);
                }

            }

            public class C_SupercruiseExit
            {
                public string EventName = IEnums.SupercruiseExit;

                public bool BodyType(string TargetBodyType, bool TargetState, string MethodName, bool DisableDebug = false, bool Answer = true)
                {
                    SupercruiseExit Event = (SupercruiseExit)IEvents.GetEvent(IEnums.SupercruiseExit);

                    string DebugText = TargetBodyType + " Check Equals Expected State (" + TargetBodyType + ")";
                    string Color = Logger.Blue;

                    if (Event == null)
                    {
                        if (TargetState == true) { return false; }
                        if (TargetState == false) { return true; }
                    }

                    if (TargetState == true && Event.BodyType != TargetBodyType)
                    {
                        Answer = false;
                        DebugText = TargetBodyType + " Check Does Not Equal Expected State (" + TargetState + ")";
                        Color = Logger.Red;
                    }
                    else if (TargetState == false && Event.BodyType == TargetBodyType)
                    {
                        Answer = false;
                        DebugText = TargetBodyType + " Check Does Not Equal Expected State (" + TargetState + ")";
                        Color = Logger.Red;
                    }

                    if (DisableDebug == false) { Logger.DebugLine(MethodName, DebugText, Color); }

                    return Answer;
                }
            }
            #endregion
        }
    }
}
