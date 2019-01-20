using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ALICE_Ships_Datalink_Interface;
using ALICE_Ships_Environment_Interface;
using ALICE_Command_Interface;
using ALICE_Interface_Manager;
using System.Threading;
using ALICE.Properties;
using static ALICE_Ships_Datalink_Interface.GameState;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ALICE_Synthesizer;
using ALICE_Internal;

namespace ALICE_Interface_Manager
{
    public static class Interface_Manager
    {
        #region Shared Interface Items

        #region Readonly Variables
        public static readonly string Interface_VoiceAttack = "Voice Attack";
        public static readonly string Interface_VoiceMacro = "Voice Macro";
        public static readonly string Interface_Internal = "Internal";
        #endregion

        public static InterfaceManager vmInterface = new InterfaceManager();

        public static dynamic ProxyObject; //This is the object thats allows interfacing with Voice Attack.
        public static string Interface = Interface_Internal; //Voice Attack, Voice Macro, Internal
        private static readonly Dictionary<string, System.Drawing.Color> Colors = new Dictionary<string, Color>
        {
            { "Red", Color.Red }, { "Orange", Color.Orange }, { "Yellow", Color.Yellow }, { "Green", Color.Green }, { "Blue", Color.Blue },
            { "Indigo", Color.Indigo }, { "Violet", Color.Violet }, { "Black", Color.Black }, { "Brown", Color.Brown }, { "Cyan", Color.Cyan },
            { "HotPink", Color.HotPink }, { "Purple", Color.Purple }, { "Silver", Color.Silver }, { "YellowGreen", Color.YellowGreen },
            { "RoyalBlue", Color.RoyalBlue }, { "White", Color.White }
        };
        private static readonly Dictionary<string, ConsoleColor> ConsoleColors = new Dictionary<string, ConsoleColor>
        {
            { "Red", ConsoleColor.Red }, { "Orange", ConsoleColor.DarkRed }, { "Yellow", ConsoleColor.Yellow }, { "Green", ConsoleColor.Green }, { "Blue", ConsoleColor.Blue },
            { "Purple", ConsoleColor.Magenta }, { "Black", ConsoleColor.Black }, { "Cyan", ConsoleColor.Cyan }, { "DarkYellow", ConsoleColor.DarkYellow }, { "White", ConsoleColor.White },
            { "None", ConsoleColor.White }
        };

        #region Voice Attack Variable Wrapper
        public static readonly string ALICE_CommandAudio = "ALICE_CommandAudio";
        public static readonly string ALICE_FighterNumber = "ALICE_FighterNumber";
        #endregion

        public static void ExecuteCommand(string Command, bool CheckExists = true)
        {
            try
            {
                if (Interface == "Voice Attack")
                {
                    if (CheckExists == true)
                    {
                        if (ProxyObject.CommandExists(Command) == true) { ProxyObject.ExecuteCommand(Command); }
                        else { Interface_Manager.WriteToLog("A.L.I.C.E: Interface Manager: Command Does Not Exist - " + Command, "Red"); }
                    }
                    else { ProxyObject.ExecuteCommand(Command); }
                }
                else if (Interface == "Voice Macro")
                {
                    //string myCommand = vmCommand.CommandExists(Command);
                    //if (myCommand != null) { vmCommand.ExecuteMacro(myCommand); }
                    //else { Interface_Manager.WriteToLog("A.L.I.C.E: Interface Manager: Command Does Not Exist - " + Command, "Red"); }
                }
                else if (Interface == "Internal")
                { Interface_Manager.WriteToLog("(Internal Operation): Execute Command: " + Command, Logger.Blue); }
            }
            catch (Exception ex)
            { Interface_Manager.WriteToLog("A.L.I.C.E: Interface Managener Exception: (Execute Command)" + ex, "Red"); }
        }

        public static bool CommandExists(string Command)
        {
            bool Answer = false;
            try
            {
                if (Interface == "Voice Attack")
                {
                    Answer = ProxyObject.CommandExists(Command);
                }
                else if (Interface == "Voice Macro")
                {
                    //    string myCommand = vmCommand.CommandExists(Command);
                    //    if (myCommand != null)
                    //    {
                    //        Answer = true;
                    //    }
                }
            }
            catch (Exception ex)
            {
                Interface_Manager.WriteToLog("A.L.I.C.E: Interface Managener Exception: (Command Exist)" + ex, "Red");
            }

            return Answer;
        }

        public static string GetText(string VariableName)
        {
            string Answer = null;

            if (Interface == "Voice Attack")
            {
                Answer = ProxyObject.GetText(VariableName);
            }
            else if (Interface == "Voice Macro")
            {
                //Answer = vmCommand.GetVariable(VariableName + "_g");
            }

            return Answer;
        }

        public static void SetText(string VariableName, string VariableValue)
        {
            if (Interface == "Voice Attack")
            {
                ProxyObject.SetText(VariableName, VariableValue);
            }
            else if (Interface == "Voice Macro")
            {
                //vmCommand.SetVariable(VariableName + "_g", VariableValue);
            }
            else if (Interface == "Internal")
            {
                Interface_Manager.WriteToLog("(Internal Operation) Text Variable: " + VariableName + " = " + VariableValue, "Green");
            }
        }

        public static void WriteToLog(string LogText, string Color, string Debug = "")
        {
            if (Interface == "Voice Attack")
            {
                Logger.AliceLog(LogText);
                ProxyObject.WriteToLog(LogText, Color);
            }
            else if (Interface == "Voice Macro")
            {
                //Logger.AliceLog(LogText);
                //vmCommand.AddLogEntry(LogText, Colors[Color], "A1C09FFD-1996-41F4-90EF-BDB0DABC0472");
            }
            else //Internal Operations
            {
                if (ConsoleColors.ContainsKey(Color))
                { Console.ForegroundColor = (ConsoleColor)ConsoleColors[Color];}
                Console.WriteLine(LogText);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        #endregion

        #region Voice Attack Interface

        private static object Flag_Init = new object();

        public static string VA_DisplayName()
        {
            return "A.L.I.C.E: Ships Command Interface - v1.0.0b";
        }

        public static string VA_DisplayInfo()
        {
            return "A.L.I.C.E: Ships Command Interface - v1.0.0b";
        }

        public static Guid VA_Id()
        {
            return new Guid("{A1C09FFD-1996-41F4-90EF-BDB0DABC0473}");
        }
        public static void VA_StopCommand()
        {

        }

        public static void VA_Invoke1(dynamic vaProxy)
        {
            try
            {
                Interface_Manager.ProxyObject = vaProxy;
                string Command = vaProxy.Context;

                if (GameState.DebugMode == true)
                { Interface_Manager.WriteToLog("A.L.I.C.E (Debug Mode): Command Interface: (Voice Attack) Sent Command = " + Command, Logger.Blue); }

                CommandInterface.Invoke(Command);
            }
            catch (Exception ex)
            {
                Interface_Manager.WriteToLog("A.L.I.C.E: (Exception - Invoke): " + ex, "Red");
            }
        }

        public static void VA_Exit1(dynamic vaProxy)
        {
            Interface_Manager.WriteToLog("A.L.I.C.E: Command Interface Shutting Down...", "Purple");
        }

        public static void VA_Init1(dynamic vaProxy)
        {
            string MethodName = "Voice Attack Init";

            try
            {
                Paths.CreateDir();
                Paths.Load_UpdateBindsFile();

                Interface = Interface_VoiceAttack;
                Interface_Manager.ProxyObject = vaProxy;
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
            }

            Interface_Manager.WriteToLog("A.L.I.C.E: Configured For Voice Attack. Standing By To Initialize...", "Purple");
        }
        #endregion
    }
}

namespace ALICE_Command_Interface
{
    public static class CommandInterface
    {
        private static bool Check(this string Str, string Val, bool Answer = false)
        {
            if (Str.Contains(Val))
            {
                Answer = true;
                Logger.DebugLine("Command Interface", "Command Contains \"" + Val + "\"" , Logger.Green);
            }
            return Answer;
        }

        public static void Invoke(string Command)
        {
            string MethodName = "Command Interface";

            if (GameState.DebugMode == true)
            { Interface_Manager.WriteToLog("A.L.I.C.E (Debug Mode): Command Interface - Received Command = " + Command, Logger.Blue); }

            #region Command Audio Variable
            GameState.CommandAudio = false;
            try
            {
                if (GameState.DebugMode == true)
                { Logger.Log(MethodName, Interface_Manager.GetText(Interface_Manager.ALICE_CommandAudio), Logger.Blue); }

                GameState.CommandAudio = Convert.ToBoolean(Interface_Manager.GetText(Interface_Manager.ALICE_CommandAudio));
                Interface_Manager.SetText(Interface_Manager.ALICE_CommandAudio, "false");
            }
            catch (Exception)
            {
                Logger.Log(MethodName, "ALICE_CommandAudio Was Not Set To A Valid Option, Using Default Value (false).", Logger.Blue);
            }

            #endregion

            //#region Panel Controls
            if (Command.Check("Close Panels"))
            {
                if (GameState.DeveloperMode == true)
                { Interface_Manager.WriteToLog("A.L.I.C.E: Context Mode: " + Command + " - Check: Close Panels", "Green"); }

                //Call.BetaPan.ClosePanels();
            }

            #region Target Panel
            else if (Command.Check("Target Panel:"))
            {
                if (Command.Check("Navigation Tab"))
                {
                    if (Command.Check("Set Filters"))
                    {
                        Call.BetaPan.Target.Navigation.SetFilters();
                    }

                    else if (Command.Check("Galaxy Map"))
                    {
                        Call.BetaPan.Target.Navigation.GalaxyMap();
                    }

                    else if (Command.Check("System Map"))
                    {
                        Call.BetaPan.Target.Navigation.SystemMap();
                    }

                    else
                    {
                        Call.BetaPan.Target.Navigation.Open();
                    }
                }

                else if (Command.Check("Transactions Tab"))
                {
                    if (Command.Check("All"))
                    {
                        Call.BetaPan.Target.Transactions.All();
                    }

                    else if (Command.Check("Missions"))
                    {
                        Call.BetaPan.Target.Transactions.Missions();
                    }

                    else if (Command.Check("Passengers"))
                    {
                        Call.BetaPan.Target.Transactions.Passengers();
                    }

                    else if (Command.Check("Claims"))
                    {
                        Call.BetaPan.Target.Transactions.Claims();
                    }

                    else if (Command.Check("Fines"))
                    {
                        Call.BetaPan.Target.Transactions.Fines();
                    }

                    else if (Command.Check("Bounties"))
                    {
                        Call.BetaPan.Target.Transactions.Bounties();
                    }

                    else
                    {
                        Call.BetaPan.Target.Transactions.Open();
                    }
                }

                else if (Command.Check("Contacts Tab"))
                {
                    Call.BetaPan.Target.Contacts.Open();
                }

                else
                {
                    Call.BetaPan.Target.Panel(true);
                }
            }
            //End: Target Panel
            #endregion

            #region Comms Panel
            else if (Command.Check("Comms Panel:"))
            {
                if (Command.Check("Chat Tab"))
                {
                    Call.BetaPan.Comms.Chat.Open();
                }

                else if (Command.Check("Inbox Tab"))
                {
                    Call.BetaPan.Comms.Inbox.Open();
                }

                else if (Command.Check("Social Tab"))
                {
                    Call.BetaPan.Comms.Social.Open();
                }

                else if (Command.Check("History Tab"))
                {
                    Call.BetaPan.Comms.History.Open();
                }

                else if (Command.Check("Squadron Tab"))
                {
                    Call.BetaPan.Comms.Squadron.Open();
                }

                else if (Command.Check("Settings Tab"))
                {
                    Call.BetaPan.Comms.Settings.Open();
                }

                else
                {
                    Call.BetaPan.Comms.Panel(true);
                }
            }
            //End: Comms Panel
            #endregion

            #region Role Panel
            else if (Command.Check("Role Panel:"))
            {
                if (Command.Check("All Tab"))
                {
                    Call.BetaPan.Role.All.Open();
                }

                else if (Command.Check("Helm Tab"))
                {
                    Call.BetaPan.Role.Helm.Open();
                }

                else if (Command.Check("Fighters Tab"))
                {
                    Call.BetaPan.Role.Fighters.Open();
                }

                else if (Command.Check("SRV Tab"))
                {
                    Call.BetaPan.Role.SRV.Open();
                }

                else if (Command.Check("Crew Tab"))
                {
                    Call.BetaPan.Role.Crew.Open();
                }

                else if (Command.Check("Help Tab"))
                {
                    Call.BetaPan.Role.Help.Open();
                }

                else
                {
                    Call.BetaPan.Role.Panel(true);
                }
            }
            //End: Role Panel
            #endregion

            #region System Panel
            else if (Command.Check("System Panel:"))
            {
                if (Command.Check("Home Tab"))
                {
                    if (Command.Check("Galnet Today"))
                    {
                        Call.BetaPan.System.Home.GalnetNews();
                    }

                    else if (Command.Check("Holo-Me"))
                    {
                        Call.BetaPan.System.Home.HoloMe(); ;
                    }

                    else if (Command.Check("Engineers"))
                    {
                        Call.BetaPan.System.Home.Engineers();

                        Call.BetaPan.System.Open = false;
                        Call.BetaPan.Role.Open = false;
                        Call.BetaPan.Comms.Open = false;
                        Call.BetaPan.Target.Open = false;
                    }

                    else if (Command.Check("Codex"))
                    {
                        Call.BetaPan.System.Home.Codex();
                    }

                    else if (Command.Check("Squadrons"))
                    {
                        Call.BetaPan.System.Home.Squadrons();
                    }

                    else if (Command.Check("Galatic Powers"))
                    {
                        Call.BetaPan.System.Home.GalaticPowers();
                    }

                    else
                    {
                        Call.BetaPan.System.Home.Open();
                    }
                }

                else if (Command.Check("Modules Tab"))
                {
                    Call.BetaPan.System.Modules.Open();
                }

                else if (Command.Check("Fire Groups Tab"))
                {
                    Call.BetaPan.System.FireGroups.Open();
                }

                else if (Command.Check("Ship Tab"))
                {
                    if (Command.Check("Functions"))
                    {
                        Call.BetaPan.System.Ship.Functions();
                    }

                    else if (Command.Check("Preferences"))
                    {
                        Call.BetaPan.System.Ship.Preferences();
                    }

                    else if (Command.Check("Statistics"))
                    {
                        Call.BetaPan.System.Ship.Statistics();
                    }

                    else
                    {
                        Call.BetaPan.System.Ship.Open();
                    }
                }

                else if (Command.Check("Inventory Tab"))
                {
                    if (Command.Check("Ships Cargo"))
                    {
                        Call.BetaPan.System.Inventory.ShipsCargo();
                    }

                    else if (Command.Check("Refinery"))
                    {
                        Call.BetaPan.System.Inventory.Refinery();
                    }

                    else if (Command.Check("Materials"))
                    {
                        Call.BetaPan.System.Inventory.Materials();
                    }

                    else if (Command.Check("Data"))
                    {
                        Call.BetaPan.System.Inventory.Data();
                    }

                    else if (Command.Check("Synthesis"))
                    {
                        Call.BetaPan.System.Inventory.Synthesis();
                    }

                    else if (Command.Check("Cabins"))
                    {
                        Call.BetaPan.System.Inventory.Cabins();
                    }

                    else
                    {
                        Call.BetaPan.System.Inventory.Open();
                    }
                }

                else if (Command.Check("Status Tab"))
                {
                    if (Command.Check("System Factions"))
                    {
                        Call.BetaPan.System.Status.SystemFactions();
                    }

                    else if (Command.Check("Reputation"))
                    {
                        Call.BetaPan.System.Status.Reputation();
                    }

                    else if (Command.Check("Session Log"))
                    {
                        Call.BetaPan.System.Status.SessionLog();
                    }

                    else if (Command.Check("Finance"))
                    {
                        Call.BetaPan.System.Status.Finance();
                    }

                    else if (Command.Check("Permits"))
                    {
                        Call.BetaPan.System.Status.Permits();
                    }

                    else 
                    {
                        Call.BetaPan.System.Status.Open();
                    }
                }

                else if (Command.Check("Media Tab"))
                {
                    Call.BetaPan.System.Media.Open();
                }

                else
                {
                    Call.BetaPan.System.Panel(true);
                }
            }
            //End: System Panel
            #endregion

            #region Galaxy Map
            if (Command.Check("Galaxy Map:"))
            {
                if (Command.Check("Open"))
                {
                    Call.BetaPan.GalaxyMap.Panel(true);
                }

                else if (Command.Check("Close"))
                {
                    Call.BetaPan.GalaxyMap.Panel(false);
                }

                else if (Command.Check("Info"))
                {
                    Call.BetaPan.GalaxyMap.Info.Open();
                }

                else if (Command.Check("Search"))
                {
                    Call.BetaPan.GalaxyMap.Search.Open();
                }

                else if (Command.Check("Bookmarks"))
                {
                    if (Command.Check("Plot"))
                    {
                        //Re-Development
                    }

                    else
                    {
                        Call.BetaPan.GalaxyMap.Bookmarks.Open();
                    }
                }

                else if (Command.Check("Configuration"))
                {
                    Call.BetaPan.GalaxyMap.Config.Open();
                }

                else if (Command.Check("Options"))
                {
                    Call.BetaPan.GalaxyMap.Options.Open();
                }
            }
            //End Region: Galaxy Map
            #endregion

            #region System Map
            else if (Command.Check("System Map:"))
            {
                if (Command.Check("Open"))
                {
                    Call.BetaPan.SystemMap.Panel(true);
                }
                else if (Command.Check("Close"))
                {
                    Call.BetaPan.SystemMap.Panel(false);
                }
                //else if (Command.Check("Summary"))
                //{
                //    Call.BetaPan.SystemMap_Tab_Select(1, GameState.CommandAudio);
                //}
                //else if (Command.Check("Body Info"))
                //{
                //    Call.BetaPan.SystemMap_Tab_Select(2, GameState.CommandAudio);
                //}
                //else if (Command.Check("Local Bookmarks"))
                //{
                //    Call.BetaPan.SystemMap_Tab_Select(3, GameState.CommandAudio);
                //}
                //else if (Command.Check("Points Of Interest"))
                //{
                //    Call.BetaPan.SystemMap_Tab_Select(4, GameState.CommandAudio);
                //}
            }
            //End Region: System Map
            #endregion

            #region Actions
            else if (Command.Check("Actions:"))
            {
                if (Command.Check("Request Docking"))
                {
                    ComplexActions.DockingProcedure(true, GameState.CommandAudio);
                }
                else if (Command.Check("Cancel Docking"))
                {
                    ComplexActions.DockingProcedure(false, GameState.CommandAudio);
                }
                else if (Command.Check("Deploy Fighter"))
                {
                    if (Command.Check("Player"))
                    {
                        decimal Num;

                        try
                        {
                            Num = Convert.ToDecimal(Interface_Manager.GetText("ALICE_FighterNumber"));
                            Logger.DebugLine(MethodName, "Targeting Fighter " + Num + " For Deployment", Logger.Yellow);
                        }
                        catch (Exception)
                        {
                            Logger.DebugLine(MethodName, "ALICE_FighterNumer Is Not A Valid Number", Logger.Yellow);
                            return;
                        }

                        if (Num == 1 || Num == 2)
                        {
                            ComplexActions.DeployFighter(Num, true, GameState.CommandAudio);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (Command.Check("Crew"))
                    {
                        decimal Num;

                        try
                        {
                            Num = Convert.ToDecimal(Interface_Manager.GetText("ALICE_FighterNumber"));
                            Logger.DebugLine(MethodName, "Targeting Fighter " + Num + " For Deployment", Logger.Yellow);
                        }
                        catch (Exception)
                        {
                            Logger.DebugLine(MethodName, "ALICE_FighterNumer Is Not A Valid Number", Logger.Yellow);
                            return;
                        }

                        if (Num == 1 || Num == 2)
                        {
                            ComplexActions.DeployFighter(Num, false, GameState.CommandAudio);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if (Command.Check("Prepare To Dock"))
                {
                    ComplexActions.DockingPreps(GameState.CommandAudio);
                }
                else if (Command.Check("Prepare To Land"))
                {
                    ComplexActions.LandingPreps(GameState.CommandAudio);
                }
                else if (Command.Check("Discovery Scan"))
                {
                    VehicleOperation.DiscoveryScan(false, GameState.CommandAudio);
                }
                else if (Command.Check("Shield Cell"))
                {
                    string Module;

                    if (Command.Check("One"))
                    {
                        Module = "shieldcellbank1";
                    }
                    else if (Command.Check("Two"))
                    {
                        Module = "shieldcellbank2";
                    }
                    else if (Command.Check("Three"))
                    {
                        Module = "shieldcellbank3";
                    }
                    else if (Command.Check("Four"))
                    {
                        Module = "shieldcellbank4";
                    }
                    else
                    {
                        Logger.DebugLine(MethodName, "No Valid Shield Cell Selected", Logger.Yellow);

                        return;
                    }

                    VehicleOperation.ShieldCell(Module, GameState.CommandAudio);
                }
            }
            //End: Actions
            #endregion

            #region Targeting
            else if (Command.Check("Targeting:"))
            {
                decimal Cycle = 1;

                if (Command.Check("Scan"))
                {
                    if (Command.Check("General"))
                    {
                        Assisted.Targeting.Hostile = false;
                        Assisted.Targeting.SeriesScan(CommandAudio);
                    }
                    else if (Command.Check("Hostile Faction"))
                    {
                        if (Command.Check("Enabled"))
                        {
                            Assisted.Targeting.Flag_Hostile = true;
                        }
                        else if (Command.Check("Disabled"))
                        {
                            Assisted.Targeting.Flag_Hostile = false;
                        }
                    }
                    else if (Command.Check("Hostile"))
                    {
                        Assisted.Targeting.Hostile = true;
                        Assisted.Targeting.SeriesScan(CommandAudio);
                    }
                    else if (Command.Check("Stop"))
                    {
                        Assisted.Targeting.Flag_Stop = true;
                    }
                    else if (Command.Check("Pause"))
                    {
                        Assisted.Targeting.Flag_Pause = true;
                    }
                    else if (Command.Check("Unpause"))
                    {
                        if (Assisted.Targeting.Flag_Pause == false)
                        {
                            Assisted.Targeting.Flag_Maintain = false;
                        }

                        Assisted.Targeting.Flag_Pause = false;
                    }
                    else if (Command.Check("Level Three"))
                    {
                        if (Command.Check("Enabled"))
                        {
                            Assisted.Targeting.Flag_Detailed = true;
                        }
                        else if (Command.Check("Disabled"))
                        {
                            Assisted.Targeting.Flag_Detailed = false;
                        }
                    }
                    else if (Command.Check("Wanted"))
                    {
                        if (Command.Check("Enabled"))
                        {
                            Assisted.Targeting.Flag_Wanted = true;
                        }
                        else if (Command.Check("Disabled"))
                        {
                            Assisted.Targeting.Flag_Wanted = false;
                        }
                    }
                    else if (Command.Check("BlackScan"))
                    {
                        if (Command.Check("Enabled"))
                        {
                            Assisted.Targeting.Flag_Blacklist = true;
                        }
                        else if (Command.Check("Disabled"))
                        {
                            Assisted.Targeting.Flag_Blacklist = false;
                        }
                    }
                    else if (Command.Check("Whitelist"))
                    {
                        if (Command.Check("Add Pilot"))
                        {
                            Assisted.Targeting.WhiteList_Pilot(CommandAudio);
                        }
                        else if (Command.Check("Add Faction"))
                        {
                            Assisted.Targeting.WhiteList_Faction(CommandAudio);
                        }
                        else if (Command.Check("Clear All"))
                        {
                            Assisted.Targeting.WhiteList_Reset(CommandAudio);
                        }
                    }
                    else if (Command.Check("Blacklist"))
                    {
                        if (Command.Check("Add Pilot"))
                        {
                            Assisted.Targeting.BlackList_Pilot(CommandAudio);
                        }
                        else if (Command.Check("Add Faction"))
                        {
                            Assisted.Targeting.BlackList_Faction(CommandAudio);
                        }
                        else if (Command.Check("Clear All"))
                        {
                            Assisted.Targeting.BlackList_Reset(CommandAudio);
                        }
                    }
                }
                else if (Command.Check("General"))
                {
                    Assisted.Targeting.Flag_Pause = true;

                    try
                    {
                        Cycle = Convert.ToDecimal(Interface_Manager.GetText("ALICE_TargetCycle"));
                    }
                    catch (Exception)
                    {
                        Interface_Manager.WriteToLog("A.L.I.C.E: Targeting: ALICE_TargetCycle Was Not Set To A Valid Option, Using Default Value (1).", Logger.Blue);
                    }

                    if (Command.Check("Next"))
                    {
                        Thread thread = new Thread((ThreadStart)(() => { Targeting.Cycle_Targets(Cycle, true); }))
                        {
                            IsBackground = true
                        };
                        thread.Start();

                    }
                    else if (Command.Check("Previous"))
                    {
                        Thread thread = new Thread((ThreadStart)(() => { Targeting.Cycle_Targets(Cycle, false); }))
                        {
                            IsBackground = true
                        };
                        thread.Start();
                    }
                }
                else if (Command.Check("Hostile"))
                {
                    Assisted.Targeting.Flag_Pause = true;

                    try
                    {
                        Cycle = Convert.ToDecimal(Interface_Manager.GetText("ALICE_TargetCycle"));
                    }
                    catch (Exception)
                    {
                        Interface_Manager.WriteToLog("A.L.I.C.E: Targeting: ALICE_TargetCycle Was Not Set To A Valid Option, Using Default Value (1).", Logger.Blue);
                    }

                    if (Command.Check("Next"))
                    {
                        Thread thread = new Thread((ThreadStart)(() => { Targeting.Cycle_Hostile_Targets(Cycle, true); }))
                        {
                            IsBackground = true
                        };
                        thread.Start();
                    }
                    else if (Command.Check("Previous"))
                    {
                        Thread thread = new Thread((ThreadStart)(() => { Targeting.Cycle_Hostile_Targets(Cycle, false); }))
                        {
                            IsBackground = true
                        };
                        thread.Start();
                    }
                }
                else if (Command.Check("Subsystem"))
                {
                    if (Command.Check("Record"))
                    {
                        //Targeting.Scan_AllSubsystems();

                        return;
                    }

                    if (Command.Check("Next"))
                    {
                        Targeting.Cycle_Subsystems(1, true, GameState.CommandAudio); //ref GameState.TargetShip.CurrentSubsystem);

                        return;
                    }
                    else if (Command.Check("Previous"))
                    {
                        Targeting.Cycle_Subsystems(1, false, GameState.CommandAudio); //ref GameState.TargetShip.CurrentSubsystem);

                        return;
                    }

                    #region Modules
                    else if (Command.Check("Shield Generator"))
                    {
                        Targeting.Scan_OrdSubsystemName = "Shield Generator";
                    }
                    else if (Command.Check("Cargo Hatch"))
                    {
                        Targeting.Scan_OrdSubsystemName = "Cargo Hatch";
                    }
                    else if (Command.Check("FSD Interdictor"))
                    {
                        Targeting.Scan_OrdSubsystemName = "FSD Interdictor";
                    }
                    else if (Command.Check("Power Distributor"))
                    {
                        Targeting.Scan_OrdSubsystemName = "Power Distributor";
                    }
                    else if (Command.Check("Life Support"))
                    {
                        Targeting.Scan_OrdSubsystemName = "Life Support";
                    }
                    else if (Command.Check("Hyperdrive"))
                    {
                        Targeting.Scan_OrdSubsystemName = "FSD";
                    }
                    else if (Command.Check("Power Plant"))
                    {
                        Targeting.Scan_OrdSubsystemName = "Power Plant";
                    }
                    else if (Command.Check("Engine"))
                    {
                        Targeting.Scan_OrdSubsystemName = "Drive";
                    }
                    else if (Command.Check("Cargo Scanner"))
                    {
                        Targeting.Scan_OrdSubsystemName = "Cargo Scanner";
                    }
                    #endregion

                    //else if (Command.Check("CargoScanner"))
                    //{
                    //    Targeting.Scan_OrdSubsystemName = "CargoScanner";
                    //}

                    //ADD the Following Items
                    //Kill Warrent Scanner
                    //All Weapons
                    //Wake Scanner

                    Assisted.Targeting.Subsystem_Target(Targeting.Scan_OrdSubsystemName, CommandAudio);
                }
                else if (Command.Check("Wingman One"))
                {
                    Assisted.Targeting.Flag_Pause = true;

                    if (Command.Check("Target Select"))
                    {
                        Targeting.Select_Wingmans_Target(1, GameState.CommandAudio);

                        return;
                    }
                    else if (Command.Check("Nav-Lock"))
                    {
                        Targeting.Select_Wingmans_NavLock(1, GameState.CommandAudio);

                        return;
                    }

                    Targeting.Select_Wingman(1, GameState.CommandAudio);
                }
                else if (Command.Check("Wingman Two"))
                {
                    Assisted.Targeting.Flag_Pause = true;

                    if (Command.Check("Target Select"))
                    {
                        Targeting.Select_Wingmans_Target(2, GameState.CommandAudio);

                        return;
                    }
                    else if (Command.Check("Nav-Lock"))
                    {
                        Targeting.Select_Wingmans_NavLock(2, GameState.CommandAudio);

                        return;
                    }

                    Targeting.Select_Wingman(2, GameState.CommandAudio);
                }
                else if (Command.Check("Wingman Three"))
                {
                    Assisted.Targeting.Flag_Pause = true;

                    if (Command.Check("Target Select"))
                    {
                        Targeting.Select_Wingmans_Target(3, GameState.CommandAudio);

                        return;
                    }
                    else if (Command.Check("Nav-Lock"))
                    {
                        Targeting.Select_Wingmans_NavLock(3, GameState.CommandAudio);

                        return;
                    }

                    Targeting.Select_Wingman(3, GameState.CommandAudio);
                }
            }
            //End: Targeting
            #endregion

            #region Orders
            else if (Command.Check("Orders:"))
            {
                if (Command.Check("Automatic System Scans"))
                {
                    if (Command.Check("Enable"))
                    {
                        Call.Order.AutoSystemScans(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Call.Order.AutoSystemScans(false);
                    }
                }
                else if (Command.Check("Automatic Docking Procedures:"))
                {
                    if (Command.Check("Enable"))
                    {
                        Call.Order.AutoDockingProcedure(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Call.Order.AutoDockingProcedure(false);
                    }
                }
                else if (Command.Check("Automatic Refuel:"))
                {
                    if (Command.Check("Enable"))
                    {
                        Call.Order.AutoRefuel(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Call.Order.AutoRefuel(false);
                    }
                }
                else if (Command.Check("Automatic Rearm:"))
                {
                    if (Command.Check("Enable"))
                    {
                        Call.Order.AutoRearm(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Call.Order.AutoRearm(false);
                    }
                }
                else if (Command.Check("Automatic Repair:"))
                {
                    if (Command.Check("Enable"))
                    {
                        Call.Order.AutoRepair(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Call.Order.AutoRepair(false);
                    }
                }
                else if (Command.Check("Automatic Hanger Entry:"))
                {
                    if (Command.Check("Enable"))
                    {
                        Call.Order.AutoHangerEntry(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Call.Order.AutoHangerEntry(false);
                    }
                }
                else if (Command.Check("Combat Power Management"))
                {
                    if (Command.Check("Enable"))
                    {
                        Call.Order.CombatPowerManagement(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Call.Order.CombatPowerManagement(false);
                    }
                }
                else if (Command.Check("Post Jump Safety:"))
                {
                    if (Command.Check("Enable"))
                    {
                        Call.Order.PostJumpSafety(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Call.Order.PostJumpSafety(false);
                    }
                }
                else if (Command.Check("Weapon Safety"))
                {
                    if (Command.Check("Enable"))
                    {
                        Call.Order.WeaponSafety(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Call.Order.WeaponSafety(false);
                    }
                }
            }
            #endregion

            #region Combat Power Management
            else if (Command.Check("Combat Power Management:"))
            {
                if (Call.Order.Mode_CombatPower == true)
                {
                    if (GameState.DebugMode == true)
                    { Interface_Manager.WriteToLog("A.L.I.C.E: Context Mode - Combat Power Management Enabled", "Green"); }
                }
                else
                {
                    if (GameState.DebugMode == true)
                    { Interface_Manager.WriteToLog("A.L.I.C.E: Context Mode - Combat Power Management Disabled", "Red"); }
                    return;
                }

                if (Command.Check("Maintain Engines"))
                {
                    Assisted.CombatPower.Maintain_Engines(CommandAudio);
                }
                else if (Command.Check("Maintain Systems"))
                {
                    Assisted.CombatPower.Maintain_Systems(CommandAudio);
                }
                else if (Command.Check("Default State"))
                {
                    Assisted.CombatPower.Setting.Send_Power_To = Assisted.CombatPower.Setting.Default_State;                    
                }
                else if (Command.Check("Power Weapons"))
                {
                    Assisted.CombatPower.Setting.Send_Power_To = Assisted.CombatPower.Str.Weapons;
                }
                else if (Command.Check("Engines"))
                {
                    Assisted.CombatPower.Defense_Engines(CommandAudio);
                }
                else if (Command.Check("Systems"))
                {
                    Assisted.CombatPower.Defense_Systems(CommandAudio);
                }
                else if (Command.Check("Heavy"))
                {
                    Assisted.CombatPower.Weapons_Heavy(CommandAudio);
                }
                else if (Command.Check("Balance"))
                {
                    Assisted.CombatPower.Weapons_Balance(CommandAudio);
                }
                else if (Command.Check("Light"))
                {
                    Assisted.CombatPower.Weapons_Light(CommandAudio);
                }

                if (GameState.Status.Hardpoints == true)
                {
                    Assisted.CombatPower.CombatPowerManagement();
                }

            }
            //End: Combat Power Management
            #endregion

            #region Power Management
            else if (Command.Check("Power Management:"))
            {
                if (Command.Check("Restore Power"))
                {
                    Call.Power.SetRecorded();
                }
                else if (Command.Check("Pip To Weapons") || Command.Check("Pip To Hardpoints"))
                {
                    if (Command.Check("One")) { Call.Power.Weapons(1); }
                    else if (Command.Check("Two")) { Call.Power.Weapons(2); }
                    else if (Command.Check("Three")) { Call.Power.Weapons(3); }
                    else if (Command.Check("Four")) { Call.Power.Weapons(4); }
                }
                else if (Command.Check("Pip To Engines") || Command.Check("Pip To Thrusters"))
                {
                    if (Command.Check("One")) { Call.Power.Engines(1); }
                    else if (Command.Check("Two")) { Call.Power.Engines(2); }
                    else if (Command.Check("Three")) { Call.Power.Engines(3); }
                    else if (Command.Check("Four")) { Call.Power.Engines(4); }
                }
                else if (Command.Check("Pip To Systems") || Command.Check("Pip To Shields"))
                {
                    if (Command.Check("One")) { Call.Power.Systems(1); }
                    else if (Command.Check("Two")) { Call.Power.Systems(2); }
                    else if (Command.Check("Three")) { Call.Power.Systems(3); }
                    else if (Command.Check("Four")) { Call.Power.Systems(4); }
                }
                else if (Command.Check("Set Power"))
                {
                    Thread power =
                    new Thread((ThreadStart)(() =>
                    { Call.Power.Set(Get.Variable.ALICE_WeaponPower(), Get.Variable.ALICE_SystemPower(), Get.Variable.ALICE_EnginePower(), Get.Variable.ALICE_RecordPower()); }))
                    { IsBackground = true };
                    power.Start();
                }
            }
            //End: Power Management
            #endregion

            #region Equipment
            else if (Command.Check("Equipment:"))
            {
                if (Command.Check("Cargo Scoop"))
                {
                    if (Command.Check("Deploy"))
                    {
                        VehicleOperation.CargoScoop(true, CommandAudio);
                    }
                    else if (Command.Check("Retract"))
                    {
                        VehicleOperation.CargoScoop(false, CommandAudio);
                    }
                }
                else if (Command.Check("External Lights"))
                {
                    if (Command.Check("Energize"))
                    {
                        VehicleOperation.ExternalLights(true, CommandAudio);
                    }
                    else if (Command.Check("Deenergize"))
                    {
                        VehicleOperation.ExternalLights(false, CommandAudio);
                    }
                }
                else if (Command.Check("Landing Gear"))
                {
                    if (Command.Check("Deploy"))
                    {
                        VehicleOperation.LandingGear(true, CommandAudio);
                    }
                    else if (Command.Check("Retract"))
                    {
                        VehicleOperation.LandingGear(false, CommandAudio);
                    }
                }
                else if (Command.Check("Silent Running"))
                {
                    if (Command.Check("Enable"))
                    {
                        VehicleOperation.SilentRunning(true, CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        VehicleOperation.SilentRunning(false, CommandAudio);
                    }
                }
                else if (Command.Check("Hardpoints"))
                {
                    if (Command.Check("Deploy"))
                    {
                        VehicleOperation.Hardpoint(true, CommandAudio);
                    }
                    else if (Command.Check("Retract"))
                    {
                        VehicleOperation.Hardpoint(false, CommandAudio);
                    }
                }
                else if (Command.Check("Fighter Order"))
                {
                    if (Command.Check("Attack Target"))
                    {
                        ComplexActions.Fighter_AttackMyTarget(CommandAudio);
                    }
                    else if (Command.Check("Defend"))
                    {
                        ComplexActions.Fighter_Defending(CommandAudio);
                    }
                    else if (Command.Check("Engage At Will"))
                    {
                        ComplexActions.Fighter_EngageAtWill(CommandAudio);
                    }
                    else if (Command.Check("Follow"))
                    {
                        ComplexActions.Fighter_Follow(CommandAudio);
                    }
                    else if (Command.Check("Hold"))
                    {
                        ComplexActions.Fighter_HoldPosition(CommandAudio);
                    }
                    else if (Command.Check("Maintain"))
                    {
                        ComplexActions.Fighter_MaintainFormation(CommandAudio);
                    }
                    else if (Command.Check("Recall"))
                    {
                        ComplexActions.Fighter_Recall(CommandAudio);
                    }
                }
                else if (Command.Check("Shield Cell"))
                {
                    if (Command.Check("Activate"))
                    {
                        VehicleOperation.Activate_ShieldCell(CommandAudio);
                    }
                }
                else if (Command.Check("Heatsink Launcher"))
                {
                    if (Command.Check("Activate"))
                    {
                        VehicleOperation.Activate_Heatsink(CommandAudio);
                    }
                }
                else if (Command.Check("Chaff Launcher"))
                {
                    if (Command.Check("Activate"))
                    {
                        VehicleOperation.Activate_Chaff(CommandAudio);
                    }
                }

            }
            //End: Equipment
            #endregion

            #region Fire Groups
            else if (Command.Check("Fire Group:"))
            {
                if (Command.Check("Select"))
                {
                    decimal FireGroup = 1;

                    try
                    {
                        FireGroup = Convert.ToDecimal(Interface_Manager.GetText("ALICE_FireGroupSelect"));
                    }
                    catch (Exception)
                    {
                        Interface_Manager.WriteToLog("A.L.I.C.E: Fire Groups: ALICE_FireGroupSelect Was Not Set To A Valid Option, Using Default Value (1).", Logger.Blue);
                    }

                    if (FireGroup > 0 && FireGroup < 9)
                    {
                        FireGroupManagement.SelectFireGroup(FireGroup, ref GameState.Status.FireGroup, GameState.CommandAudio);
                    }
                    else
                    {
                        Interface_Manager.WriteToLog("A.L.I.C.E: Fire Groups: ALICE_FireGroupSelect Must Be A Number Between 1 & 8.", "Red");
                        return;
                    }

                }
                else if (Command.Check("Default"))
                {
                    decimal FireGroup = 1;

                    try
                    {
                        FireGroup = Convert.ToDecimal(Interface_Manager.GetText("ALICE_FireGroupNum"));
                    }
                    catch (Exception)
                    {
                        Interface_Manager.WriteToLog("A.L.I.C.E: Fire Groups: ALICE_FireGroupNum Was Not Set To A Valid Option, Using Default Value (1).", Logger.Blue);
                    }

                    if (FireGroup > 0 && FireGroup < 9)
                    {
                        FireGroupManagement.SetDefaultFireGroup(FireGroup);
                    }
                    else
                    {
                        Interface_Manager.WriteToLog("A.L.I.C.E: Fire Groups: ALICE_FireGroupNum Must Be A Number Between 1 & 8.", "Red");
                        return;
                    }
                }
                else if (Command.Check("Total"))
                {
                    decimal FireGroup = 1;

                    try
                    {
                        FireGroup = Convert.ToDecimal(Interface_Manager.GetText("ALICE_FireGroupNum"));
                    }
                    catch (Exception)
                    {
                        Interface_Manager.WriteToLog("A.L.I.C.E: Fire Groups: ALICE_FireGroupNum Was Not Set To A Valid Option, Using Default Value (1).", Logger.Blue);
                    }

                    if (FireGroup > 0 && FireGroup < 9)
                    {
                        FireGroupManagement.SetTotalFireGroup(FireGroup);
                    }
                    else
                    {
                        Interface_Manager.WriteToLog("A.L.I.C.E: Fire Groups: ALICE_FireGroupNum Must Be A Number Between 1 & 8.", "Red");
                        return;
                    }
                }
                else if (Command.Check("Update"))
                {
                    FireGroupManagement.UpdateFireGroup(GameState.CommandAudio);
                }
                else if (Command.Check("Assign"))
                {
                    string Module = "";
                    int FireGroupNum = 0;
                    string Position = "";
                    decimal ModuleNumber = 0;

                    if (Command.Check("Cargo Scanner"))
                    {
                        Module = FireGroupManagerProp.Modules["Cargo Scanner"];
                    }
                    else if (Command.Check("Repair Limpet Controller"))
                    {
                        Module = FireGroupManagerProp.Modules["Repair Limpet"];
                    }
                    else if (Command.Check("Collector Limpet Controller"))
                    {
                        Module = FireGroupManagerProp.Modules["Collector Limpet"];
                    }
                    else if (Command.Check("Discovery Scanner"))
                    {
                        Module = FireGroupManagerProp.Modules["Discovery Scanner"];
                    }
                    else if (Command.Check("FSD Interdictor"))
                    {
                        Module = FireGroupManagerProp.Modules["FSD Interdictor"];
                    }
                    else if (Command.Check("Heat Sink Launcher"))
                    {
                        Module = "heatsinklauncher";
                    }
                    else if (Command.Check("ECM"))
                    {
                        Module = FireGroupManagerProp.Modules["ECM"];
                    }
                    else if (Command.Check("Mining Laser"))
                    {
                        Module = FireGroupManagerProp.Modules["Mining Laser"];
                    }
                    else if (Command.Check("Cargo Scanner"))
                    {
                        Module = FireGroupManagerProp.Modules["Cargo Scanner"];
                    }
                    else if (Command.Check("Shield Cell"))
                    {
                        if (Command.Check("One"))
                        {
                            Module = FireGroupManagerProp.Modules["Shield Cell"];
                            ModuleNumber = 1;
                        }
                        else if (Command.Check("Two"))
                        {
                            Module = FireGroupManagerProp.Modules["Shield Cell"];
                            ModuleNumber = 2;
                        }
                        else if (Command.Check("Three"))
                        {
                            Module = FireGroupManagerProp.Modules["Shield Cell"];
                            ModuleNumber = 3;
                        }
                        else if (Command.Check("Four"))
                        {
                            Module = FireGroupManagerProp.Modules["Shield Cell"];
                            ModuleNumber = 4;
                        }
                    }

                    try
                    {
                        FireGroupNum = Convert.ToInt32(Interface_Manager.GetText("ALICE_FireGroupNum"));
                    }
                    catch (Exception ex)
                    {
                        Interface_Manager.WriteToLog(" ", "Red");
                        Interface_Manager.WriteToLog("------------------------------------------------------------------------------------", "Red");
                        Interface_Manager.WriteToLog("A.L.I.C.E: Fire Group Assignment: [Text Variable] ALICE_FireGroupNum Invalid Setting", "Red");
                        Interface_Manager.WriteToLog("A.L.I.C.E: Fire Group Assignment: (Execption) " + ex, "Red");
                        Interface_Manager.WriteToLog("------------------------------------------------------------------------------------", "Red");
                        Interface_Manager.WriteToLog(" ", "Red");
                    }

                    try
                    {
                        Position = Interface_Manager.GetText("ALICE_FireGroupPosition").ToUpper();
                    }
                    catch (Exception ex)
                    {
                        Interface_Manager.WriteToLog(" ", "Red");
                        Interface_Manager.WriteToLog("-----------------------------------------------------------------------------------------", "Red");
                        Interface_Manager.WriteToLog("A.L.I.C.E: Fire Group Assignment: [Text Variable] ALICE_FireGroupPosition Invalid Setting", "Red");
                        Interface_Manager.WriteToLog("A.L.I.C.E: Fire Group Assignment: (Execption) " + ex, "Red");
                        Interface_Manager.WriteToLog("-----------------------------------------------------------------------------------------", "Red");
                        Interface_Manager.WriteToLog(" ", "Red");
                    }

                    if ((FireGroupNum > 0 || FireGroupNum < 9) && (Position == "PRIMARY" || Position == "SECONDARY"))
                    {
                        if (GameState.DeveloperMode == true)
                        { Interface_Manager.WriteToLog("A.L.I.C.E: Received Values - ALICE_FireGroupNum = " + FireGroupNum + " | ALICE_FireGroupPosition = " + Position + " | ALICE_FireGroupModuleNumber = " + ModuleNumber, "Green"); }

                        GameState.FireGroupManagerProp.Module_Assignment(Module, FireGroupNum, Position, ModuleNumber);
                    }
                    else
                    {
                        Interface_Manager.WriteToLog(" ", "Red");
                        Interface_Manager.WriteToLog("------------------------------------------------------------------------------------", "Red");
                        Interface_Manager.WriteToLog("A.L.I.C.E: [Deci] ALICE_FireGroupModuleNumber ( 0 - 4 ) | The Auto Default Is 0, But Is Set 1 - 4 With Items Like Shield Cells (Optional Variable)", Logger.Blue);
                        Interface_Manager.WriteToLog("A.L.I.C.E: [Text] ALICE_ FireGroupPosition ( PRIMARY / SECONDARY ) | PRIMARY / SECONDARY Is Case Sensitive, It Must Be All Caps", Logger.Blue);
                        Interface_Manager.WriteToLog("A.L.I.C.E: [Inte] ALICE_FireGroupNum ( 0 - 8 ) | 0 = Remove, 1 - 8 = Assign To That Fire Group", Logger.Blue);
                        Interface_Manager.WriteToLog("A.L.I.C.E: Received Values - ALICE_FireGroupNum = " + FireGroupNum + " | ALICE_FireGroupPosition = " + Position + " | ALICE_FireGroupModuleNumber = " + ModuleNumber, "Red");
                        Interface_Manager.WriteToLog("A.L.I.C.E: Fire Group Assignment: Invalid Settings, Please Ensure Your Setting The Following Variables", "Red");
                        Interface_Manager.WriteToLog("------------------------------------------------------------------------------------", "Red");
                        Interface_Manager.WriteToLog(" ", "Red");
                    }

                    Interface_Manager.SetText("ALICE_FireGroupPosition", "");
                    Interface_Manager.SetText("ALICE_FireGroupModuleNumber", "");
                    Interface_Manager.SetText("ALICE_FireGroupNum", "");

                    Module = "";
                    FireGroupNum = 0;
                    Position = "";
                    ModuleNumber = 0;
                }
                else if (Command.Check("Module"))
                {
                    string Module = "";

                    if (Command.Check("Cargo Scanner"))
                    {
                        Module = FireGroupManagerProp.Modules["Cargo Scanner"];
                    }
                    else if (Command.Check("Repair Limpet Controller"))
                    {
                        Module = FireGroupManagerProp.Modules["Repair Limpet"];
                    }
                    else if (Command.Check("Collector Limpet Controller"))
                    {
                        Module = FireGroupManagerProp.Modules["Collector Limpet"];
                    }
                    else if (Command.Check("Discovery Scanner"))
                    {
                        Module = FireGroupManagerProp.Modules["Discovery Scanner"];
                    }
                    else if (Command.Check("FSD Interdictor"))
                    {
                        Module = FireGroupManagerProp.Modules["FSD Interdictor"];
                    }
                    else if (Command.Check("Heat Sink Launcher"))
                    {
                        Module = "heatsinklauncher";
                    }
                    else if (Command.Check("ECM"))
                    {
                        Module = FireGroupManagerProp.Modules["ECM"];
                    }
                    else if (Command.Check("Mining Laser"))
                    {
                        Module = FireGroupManagerProp.Modules["Mining Laser"];
                    }
                    else if (Command.Check("Cargo Scanner"))
                    {
                        Module = FireGroupManagerProp.Modules["Cargo Scanner"];
                    }
                    else if (Command.Check("Shield Cell"))
                    {
                        if (Command.Check("One"))
                        {
                            Module = FireGroupManagerProp.Modules["Shield Cell"] + "1";
                        }
                        else if (Command.Check("Two"))
                        {
                            Module = FireGroupManagerProp.Modules["Shield Cell"] + "2";
                        }
                        else if (Command.Check("Three"))
                        {
                            Module = FireGroupManagerProp.Modules["Shield Cell"] + "3";
                        }
                        else if (Command.Check("Four"))
                        {
                            Module = FireGroupManagerProp.Modules["Shield Cell"] + "4";
                        }
                    }

                    FireGroupManagement.SelectAssignedModule(Module);
                    Thread.Sleep(100 + Plugin_Controls.Sleep_FireGroupSpeed);

                    if (Command.Check("Activate"))
                    {
                        string Position = GameState.FireGroupManagerProp.Module_AssignedPosition(Module);

                        if (Position == "PRIMARY")
                        {
                            Call.Key.Press(Call.Key.Primary_Fire, 0);
                        }
                        else if (Position == "SECONDARY")
                        {
                            Call.Key.Press(Call.Key.Secondary_Fire, 0);
                        }
                    }
                }
            }
            //End: Fire Groups
            #endregion

            #region Interactions
            else if (Command.Check("Interactions:"))
            {
                if (Command.Check("Response Check"))
                {
                    if (Command.Check("Yes") == true)
                    {
                        Plugin_Controls.ResponseCheck(true);
                    }
                    else if (Command.Check("No") == true)
                    {
                        Plugin_Controls.ResponseCheck(false);
                    }
                }
            }
            #endregion

            #region Navigation
            else if (Command.Check("Navigation:"))
            {
                if (Command.Check("Abort Jump"))
                {
                    VehicleOperation.AbortJump(GameState.CommandAudio);
                }
                else if (Command.Check("Hyperspace"))
                {
                    VehicleOperation.Hyperspace(true, GameState.CommandAudio);
                }
                else if (Command.Check("Supercruise"))
                {
                    VehicleOperation.Supercruise(true, GameState.CommandAudio);
                }
                else if (Command.Check("Disengage"))
                {
                    VehicleOperation.Supercruise(false, GameState.CommandAudio);
                }
            }
            //End: Navigation
            #endregion

            #region Plugin
            if (Command.Check("Plugin:"))
            {
                if (Command.Check("Initialize"))
                {
                    PlugIn.Initialize(Interface_Manager.Interface_VoiceAttack, true, true);
                }
                else if (Command.Check("Pip Speed"))
                {
                    if (Command.Check("Increase"))
                    {
                        Plugin_Controls.PipSpeed(false);
                    }
                    else if (Command.Check("Decrease"))
                    {
                        Plugin_Controls.PipSpeed(true);
                    }
                }
                else if (Command.Check("Panel Speed"))
                {
                    if (Command.Check("Increase"))
                    {
                        Plugin_Controls.PanelSpeed(false);
                    }
                    else if (Command.Check("Decrease"))
                    {
                        Plugin_Controls.PanelSpeed(true);
                    }
                }
                else if (Command.Check("Fire Group Speed"))
                {
                    if (Command.Check("Increase"))
                    {
                        Plugin_Controls.FireGroupSpeed(false);
                    }
                    else if (Command.Check("Decrease"))
                    {
                        Plugin_Controls.FireGroupSpeed(true);
                    }
                }
                else if (Command.Check("Throttle Speed"))
                {
                    if (Command.Check("Increase"))
                    {
                        Plugin_Controls.ThrottleSpeed(false);
                    }
                    else if (Command.Check("Decrease"))
                    {
                        Plugin_Controls.ThrottleSpeed(true);
                    }
                }
                else if (Command.Check("Developer Mode"))
                {
                    if (Command.Check("Enable"))
                    {
                        GameState.DeveloperMode = true;
                    }
                    else if (Command.Check("Disable"))
                    {
                        GameState.DeveloperMode = false;
                    }
                }
                else if (Command.Check("Debug Mode"))
                {
                    if (Command.Check("Enable"))
                    {
                        GameState.DebugMode = true;
                    }
                    else if (Command.Check("Disable"))
                    {
                        GameState.DebugMode = false;
                    }
                }
                else if (Command.Check("Master Audio"))
                {
                    if (Command.Check("Enable"))
                    {
                        GameState.MasterAudio = true;
                    }
                    else if (Command.Check("Disable"))
                    {
                        GameState.MasterAudio = false;
                    }
                }
            }
            //End: Plugin
            #endregion

            #region Reports
            else if (Command.Check("Reports"))
            {
                if (Command.Check("Ship Loadout"))
                {
                    if (Command.Check("To Log"))
                    {
                        GameState.ShipProp.WTL_ShipsLoadout();
                    }
                }
                else if (Command.Check("No Fire Zone"))
                {
                    if (Command.Check("Enable"))
                    {
                        Reports.Report_NoFireZone(true, CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Reports.Report_NoFireZone(false, CommandAudio);
                    }
                }
                else if (Command.Check("Wanted Target"))
                {
                    if (Command.Check("Enable"))
                    {
                        Reports.Report_TargetWanted(true, CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Reports.Report_TargetWanted(false, CommandAudio);
                    }
                }
                else if (Command.Check("Enemy Target"))
                {
                    if (Command.Check("Enable"))
                    {
                        Reports.Report_TargetEnemy(true, CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Reports.Report_TargetEnemy(false, CommandAudio);
                    }
                }
                else if (Command.Check("Collected Bounties"))
                {
                    if (Command.Check("Enable"))
                    {
                        Reports.Report_CollectedBounty(true, CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Reports.Report_CollectedBounty(false, CommandAudio);
                    }
                }
                else if (Command.Check("Material Collected"))
                {
                    if (Command.Check("Enable"))
                    {
                        Reports.Report_MaterialCollected(true, CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Reports.Report_MaterialCollected(false, CommandAudio);
                    }
                }
                else if (Command.Check("Material Refined"))
                {
                    if (Command.Check("Enable"))
                    {
                        Reports.Report_MaterialRefined(true, CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Reports.Report_MaterialRefined(false, CommandAudio);
                    }
                }
                else if (Command.Check("Station Status"))
                {
                    if (Command.Check("Enable"))
                    {
                        Reports.Report_StationStatus(true, CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Reports.Report_StationStatus(false, CommandAudio);
                    }
                }
                else if (Command.Check("Shield State"))
                {
                    if (Command.Check("Enable"))
                    {
                        Reports.Report_ShieldState(true, CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Reports.Report_ShieldState(false, CommandAudio);
                    }
                }
                else if (Command.Check("Fuel Scooping"))
                {
                    if (Command.Check("Enable"))
                    {
                        Reports.Report_FuelScoop(true, CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Reports.Report_FuelScoop(false, CommandAudio);
                    }
                }
                else if (Command.Check("Fuel Report"))
                {
                    if (Command.Check("Enable"))
                    {
                        Reports.Report_FuelStatus(true, CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Reports.Report_FuelStatus(false, CommandAudio);
                    }
                }
            }
            #endregion

            #region Throttle
            else if (Command.Check("Throttle:"))
            {
                if (Command.Check("Boost Engines"))
                {
                    decimal BoostNum = 1;

                    try
                    { BoostNum = Convert.ToDecimal(Interface_Manager.GetText("ALICE_BoostNum")); }
                    catch (Exception)
                    { Interface_Manager.WriteToLog("A.L.I.C.E: Throttle: ALICE_BoostNum Was Not Set Or Was Not A Vaild Entry. Using Default Value (1)", Logger.Blue); }

                    Interface_Manager.SetText("ALICE_BoostNum", null);

                    VehicleOperation.Boost(BoostNum, true, GameState.CommandAudio);
                }
                else if (Command.Check("Boost Stop"))
                {
                    VehicleOperation.Num_Boost = 0;
                }
                else if (Command.Check("15"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_15();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_15(true);
                    }
                }
                else if (Command.Check("20"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_20();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_20(true);
                    }
                }
                else if (Command.Check("25"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_25();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_25(true);
                    }
                }
                else if (Command.Check("30"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_30();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_30(true);
                    }
                }
                else if (Command.Check("35"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_35();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_35(true);
                    }
                }
                else if (Command.Check("40"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_40();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_40(true);
                    }
                }
                else if (Command.Check("45"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_45();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_45(true);
                    }
                }
                else if (Command.Check("50"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_50();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_50(true);
                    }
                }
                else if (Command.Check("55"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_55();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_55(true);
                    }
                }
                else if (Command.Check("60"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_60();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_60(true);
                    }
                }
                else if (Command.Check("65"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_65();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_65(true);
                    }
                }
                else if (Command.Check("70"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_70();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_70(true);
                    }
                }
                else if (Command.Check("75"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_75();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_75(true);
                    }
                }
                else if (Command.Check("80"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_80();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_80(true);
                    }
                }
                else if (Command.Check("85"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_85();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_85(true);
                    }
                }
                else if (Command.Check("90"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_90();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_90(true);
                    }
                }
                else if (Command.Check("95"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_95();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_95(true);
                    }
                }
                else if (Command.Check("100"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_100();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_100(true);
                    }
                }
                else if (Command.Check("10"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_10();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_10(true);
                    }
                }
                else if (Command.Check("0"))
                {
                    VehicleOperation.Throttle_0();
                }
                else if (Command.Check("5"))
                {
                    if (Command.Check("Positive"))
                    {
                        VehicleOperation.Throttle_5();
                    }
                    else if (Command.Check("Negative"))
                    {
                        VehicleOperation.Throttle_5(true);
                    }
                }
            }
            #endregion

            #region Overrides
            if (Command.Check("Override:"))
            {
                if (Command.Check("Automatic Docking"))
                {
                    Overrides.Override_AutoDocking();
                }
            }
            #endregion

            #region Miscellaneous
            if (Command.Check("Interaction:"))
            {
                if (Command.Check("General"))
                {
                    if (Command.Check("A.L.I.C.E"))
                    {
                        Call.Interactions.Res_Alice();
                    }
                    else if (Command.Check("I Love You"))
                    {
                        Call.Interactions.Res_I_Love_You();
                    }
                    else if (Command.Check("Thank You"))
                    {
                        Call.Interactions.Res_Thank_You();
                    }
                }
                else if (Command.Check("Story"))
                {
                    if (Command.Check("Bio"))
                    {
                        Call.Interactions.Res_Bio();
                    }
                    else if (Command.Check("Name"))
                    {
                        Call.Interactions.Res_Name();
                    }

                }
            }
            #endregion         
        }
    }
}