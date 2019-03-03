using System;
using ALICE_Actions;
using System.Threading;
using ALICE_Internal;
using ALICE_Core;
using ALICE_Settings;
using ALICE_Equipment;
using ALICE_Debug;

namespace ALICE_Interface
{
    public static class ICommands
    {
        static readonly string MethodName = "Interface Manager Commands";

        private static bool Check(this string Str, string Val, bool Answer = false)
        {
            if (Str.Contains(Val))
            {
                Answer = true;
                Logger.DebugLine("Command Interface", "Command Contains \"" + Val + "\"", Logger.Green);
            }
            return Answer;
        }

        private static bool GetCommandAudio(bool Answer = false)
        {
            PlugIn.CommandAudio = false;
            try
            {
                Logger.DebugLine(MethodName, "Command Audio = " + IPlatform.GetText(IPlatform.IVar.CommandAudio), Logger.Blue);
                Answer = Convert.ToBoolean(IPlatform.GetText(IPlatform.IVar.CommandAudio));
                IPlatform.SetText(IPlatform.IVar.CommandAudio, "false");
            }
            catch (Exception)
            { Logger.Exception(MethodName, "ALICE_CommandAudio Was Not Set To A Valid Option, Using Default Value \"false\"."); }

            return Answer;
        }

        private static bool GetColdMod(bool Answer = false)
        {
            try
            {
                Logger.DebugLine(MethodName, "Cold Modifier = " + IPlatform.GetText(IPlatform.IVar.ColdMod), Logger.Blue);
                Answer = Convert.ToBoolean(IPlatform.GetText(IPlatform.IVar.ColdMod));
                IPlatform.SetText(IPlatform.IVar.ColdMod, "false");
            }
            catch (Exception)
            { Logger.Exception(MethodName, "ALICE_ColdMod Was Not Set To A Valid Option, Using Default Value \"false\"."); }

            return Answer;
        }

        public static void Invoke(string Command)
        {
            string MethodName = "Command Interface";

            Logger.DebugLine(MethodName, "Received Command: " + Command, Logger.Blue);

            PlugIn.CommandAudio = GetCommandAudio();

            #region 3.4 Panel Controls
            if (Command.Check("Close Panels"))
            { Call.Key.Press(Call.Key.UI_Back); }

            #region Target Panel
            else if (Command.Check("Target Panel:"))
            {
                if (Command.Check("Navigation Tab"))
                {
                    if (Command.Check("Set Filters"))
                    {
                        Call.Panel.Target.Navigation.SetFilters();
                    }

                    else if (Command.Check("Galaxy Map"))
                    {
                        Call.Panel.Target.Navigation.GalaxyMap();
                    }

                    else if (Command.Check("System Map"))
                    {
                        Call.Panel.Target.Navigation.SystemMap();
                    }

                    else
                    {
                        Call.Panel.Target.Navigation.Open(MethodName);
                    }
                }

                else if (Command.Check("Transactions Tab"))
                {
                    if (Command.Check("All"))
                    {
                        Call.Panel.Target.Transactions.All();
                    }

                    else if (Command.Check("Missions"))
                    {
                        Call.Panel.Target.Transactions.Missions();
                    }

                    else if (Command.Check("Passengers"))
                    {
                        Call.Panel.Target.Transactions.Passengers();
                    }

                    else if (Command.Check("Claims"))
                    {
                        Call.Panel.Target.Transactions.Claims();
                    }

                    else if (Command.Check("Fines"))
                    {
                        Call.Panel.Target.Transactions.Fines();
                    }

                    else if (Command.Check("Bounties"))
                    {
                        Call.Panel.Target.Transactions.Bounties();
                    }

                    else
                    {
                        Call.Panel.Target.Transactions.Open(MethodName);
                    }
                }

                else if (Command.Check("Contacts Tab"))
                {
                    Call.Panel.Target.Contacts.Open(MethodName);
                }

                else
                {
                    Call.Panel.Target.Panel(true);
                }
            }
            //End: Target Panel
            #endregion

            #region Comms Panel
            else if (Command.Check("Comms Panel:"))
            {
                if (Command.Check("Chat Tab"))
                {
                    Call.Panel.Comms.Chat.Open(MethodName);
                }

                else if (Command.Check("Inbox Tab"))
                {
                    Call.Panel.Comms.Inbox.Open(MethodName);
                }

                else if (Command.Check("Social Tab"))
                {
                    Call.Panel.Comms.Social.Open(MethodName);
                }

                else if (Command.Check("History Tab"))
                {
                    Call.Panel.Comms.History.Open(MethodName);
                }

                else if (Command.Check("Squadron Tab"))
                {
                    Call.Panel.Comms.Squadron.Open(MethodName);
                }

                else if (Command.Check("Settings Tab"))
                {
                    Call.Panel.Comms.Settings.Open(MethodName);
                }

                else
                {
                    Call.Panel.Comms.Panel(true);
                }
            }
            //End: Comms Panel
            #endregion

            #region Role Panel
            else if (Command.Check("Role Panel:"))
            {
                if (Command.Check("All Tab"))
                {
                    Call.Panel.Role.All.Open(MethodName);
                }

                else if (Command.Check("Helm Tab"))
                {
                    Call.Panel.Role.Helm.Open(MethodName);
                }

                else if (Command.Check("Fighters Tab"))
                {
                    Call.Panel.Role.Fighters.Open(MethodName);
                }

                else if (Command.Check("SRV Tab"))
                {
                    Call.Panel.Role.SRV.Open(MethodName);
                }

                else if (Command.Check("Crew Tab"))
                {
                    Call.Panel.Role.Crew.Open(MethodName);
                }

                else if (Command.Check("Help Tab"))
                {
                    Call.Panel.Role.Help.Open(MethodName);
                }

                else
                {
                    Call.Panel.Role.Panel(true);
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
                        Call.Panel.System.Home.GalnetNews();
                    }

                    else if (Command.Check("Holo-Me"))
                    {
                        Call.Panel.System.Home.HoloMe();
                    }

                    else if (Command.Check("Engineers"))
                    {
                        Call.Panel.System.Home.Engineers();

                        Call.Panel.System.Open = false;
                        Call.Panel.Role.Open = false;
                        Call.Panel.Comms.Open = false;
                        Call.Panel.Target.Open = false;
                    }

                    else if (Command.Check("Codex"))
                    {
                        Call.Panel.System.Home.Codex();
                    }

                    else if (Command.Check("Squadrons"))
                    {
                        Call.Panel.System.Home.Squadrons();
                    }

                    else if (Command.Check("Galatic Powers"))
                    {
                        Call.Panel.System.Home.GalaticPowers();
                    }

                    else
                    {
                        Call.Panel.System.Home.Open(MethodName);
                    }
                }

                else if (Command.Check("Modules Tab"))
                {
                    Call.Panel.System.Modules.Open(MethodName);
                }

                else if (Command.Check("Fire Groups Tab"))
                {
                    Call.Panel.System.FireGroups.Open(MethodName);
                }

                else if (Command.Check("Ship Tab"))
                {
                    if (Command.Check("Functions"))
                    {
                        Call.Panel.System.Ship.Functions();
                    }

                    else if (Command.Check("Preferences"))
                    {
                        Call.Panel.System.Ship.Preferences();
                    }

                    else if (Command.Check("Statistics"))
                    {
                        Call.Panel.System.Ship.Statistics();
                    }

                    else
                    {
                        Call.Panel.System.Ship.Open(MethodName);
                    }
                }

                else if (Command.Check("Inventory Tab"))
                {
                    if (Command.Check("Ships Cargo"))
                    {
                        Call.Panel.System.Inventory.ShipsCargo();
                    }

                    else if (Command.Check("Refinery"))
                    {
                        Call.Panel.System.Inventory.Refinery();
                    }

                    else if (Command.Check("Materials"))
                    {
                        Call.Panel.System.Inventory.Materials();
                    }

                    else if (Command.Check("Data"))
                    {
                        Call.Panel.System.Inventory.Data();
                    }

                    else if (Command.Check("Synthesis"))
                    {
                        Call.Panel.System.Inventory.Synthesis();
                    }

                    else if (Command.Check("Cabins"))
                    {
                        Call.Panel.System.Inventory.Cabins();
                    }

                    else
                    {
                        Call.Panel.System.Inventory.Open(MethodName);
                    }
                }

                else if (Command.Check("Status Tab"))
                {
                    if (Command.Check("System Factions"))
                    {
                        Call.Panel.System.Status.SystemFactions();
                    }

                    else if (Command.Check("Reputation"))
                    {
                        Call.Panel.System.Status.Reputation();
                    }

                    else if (Command.Check("Session Log"))
                    {
                        Call.Panel.System.Status.SessionLog();
                    }

                    else if (Command.Check("Finance"))
                    {
                        Call.Panel.System.Status.Finance();
                    }

                    else if (Command.Check("Permits"))
                    {
                        Call.Panel.System.Status.Permits();
                    }

                    else
                    {
                        Call.Panel.System.Status.Open(MethodName);
                    }
                }

                else if (Command.Check("Media Tab"))
                {
                    Call.Panel.System.Media.Open(MethodName);
                }

                else
                {
                    Call.Panel.System.Panel(true);
                }
            }
            //End: System Panel
            #endregion

            #region Galaxy Map
            if (Command.Check("Galaxy Map:"))
            {
                if (Command.Check("Open"))
                {
                    Call.Panel.GalaxyMap.Panel(true);
                }

                else if (Command.Check("Close"))
                {
                    Call.Panel.GalaxyMap.Panel(false);
                }

                else if (Command.Check("Info"))
                {
                    Call.Panel.GalaxyMap.Info.Open(MethodName);
                }

                else if (Command.Check("Search"))
                {
                    Call.Panel.GalaxyMap.Search.Open(MethodName);
                }

                else if (Command.Check("Bookmarks"))
                {
                    if (Command.Check("Plot"))
                    {
                        decimal Num = 1; try
                        {
                            Num = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.BookmarkNum));
                        }
                        catch (Exception ex)
                        {
                            Logger.Exception(MethodName, "Bookmark Plot Exception" + ex);
                            Logger.Log(MethodName, "ALICE_BookmarkNum Was Not Set, Or Couldn't Be Converted.", Logger.Red);
                            return;
                        }

                        Call.Panel.GalaxyMap.Bookmarks.PlotBookmark(Num);
                    }
                    else if (Command.Check("Reset"))
                    {
                        Call.Panel.GalaxyMap.Bookmarks.ResetBookmarks();
                    }
                    else
                    {
                        Call.Panel.GalaxyMap.Bookmarks.Open(MethodName);
                    }
                }

                else if (Command.Check("Configuration"))
                {
                    Call.Panel.GalaxyMap.Config.Open(MethodName);
                }

                else if (Command.Check("Options"))
                {
                    Call.Panel.GalaxyMap.Options.Open(MethodName);
                }
            }
            //End Region: Galaxy Map
            #endregion

            #region System Map
            else if (Command.Check("System Map:"))
            {
                if (Command.Check("Open"))
                {
                    Call.Panel.SystemMap.Panel(true);
                }
                else if (Command.Check("Close"))
                {
                    Call.Panel.SystemMap.Panel(false);
                }
                //else if (Command.Check("Summary"))
                //{
                //    Call.Panel.SystemMap_Tab_Select(1, PlugIn.CommandAudio);
                //}
                //else if (Command.Check("Body Info"))
                //{
                //    Call.Panel.SystemMap_Tab_Select(2, PlugIn.CommandAudio);
                //}
                //else if (Command.Check("Local Bookmarks"))
                //{
                //    Call.Panel.SystemMap_Tab_Select(3, PlugIn.CommandAudio);
                //}
                //else if (Command.Check("Points Of Interest"))
                //{
                //    Call.Panel.SystemMap_Tab_Select(4, PlugIn.CommandAudio);
                //}
            }
            //End Region: System Map
            #endregion

            //End Region: 3.4 Panels
            #endregion

            else if (Command.Check("Actions:")) { ActionCommands(Command); }

            else if (Command.Check("Plugin:")) { PlugInCommands(Command); }

            else if (Command.Check("Fire Group:")) { FiregroupCommands(Command); }

            #region Targeting
            else if (Command.Check("Targeting:"))
            {
                decimal Cycle = 1;

                if (Command.Check("Scan"))
                {
                    if (Command.Check("General"))
                    {
                        Assisted.Targeting.Hostile = false;
                        Assisted.Targeting.SeriesScan(PlugIn.CommandAudio);
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
                        Assisted.Targeting.SeriesScan(PlugIn.CommandAudio);
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
                            Assisted.Targeting.WhiteList_Pilot(PlugIn.CommandAudio);
                        }
                        else if (Command.Check("Add Faction"))
                        {
                            Assisted.Targeting.WhiteList_Faction(PlugIn.CommandAudio);
                        }
                        else if (Command.Check("Clear All"))
                        {
                            Assisted.Targeting.WhiteList_Reset(PlugIn.CommandAudio);
                        }
                    }
                    else if (Command.Check("Blacklist"))
                    {
                        if (Command.Check("Add Pilot"))
                        {
                            Assisted.Targeting.BlackList_Pilot(PlugIn.CommandAudio);
                        }
                        else if (Command.Check("Add Faction"))
                        {
                            Assisted.Targeting.BlackList_Faction(PlugIn.CommandAudio);
                        }
                        else if (Command.Check("Clear All"))
                        {
                            Assisted.Targeting.BlackList_Reset(PlugIn.CommandAudio);
                        }
                    }
                }
                else if (Command.Check("General"))
                {
                    Assisted.Targeting.Flag_Pause = true;

                    try
                    {
                        Cycle = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.TargetCycle));
                    }
                    catch (Exception)
                    {
                        IPlatform.WriteToInterface("A.L.I.C.E: Targeting: ALICE_TargetCycle Was Not Set To A Valid Option, Using Default Value (1).", Logger.Blue);
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
                        Cycle = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.TargetCycle));
                    }
                    catch (Exception)
                    {
                        IPlatform.WriteToInterface("A.L.I.C.E: Targeting: ALICE_TargetCycle Was Not Set To A Valid Option, Using Default Value (1).", Logger.Blue);
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
                        Targeting.Cycle_Subsystems(1, true, PlugIn.CommandAudio); //ref IObjects.TargetShip.CurrentSubsystem);

                        return;
                    }
                    else if (Command.Check("Previous"))
                    {
                        Targeting.Cycle_Subsystems(1, false, PlugIn.CommandAudio); //ref IObjects.TargetShip.CurrentSubsystem);

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

                    Assisted.Targeting.Subsystem_Target(Targeting.Scan_OrdSubsystemName, PlugIn.CommandAudio);
                }
                else if (Command.Check("Wingman One"))
                {
                    Assisted.Targeting.Flag_Pause = true;

                    if (Command.Check("Target Select"))
                    {
                        Targeting.Select_Wingmans_Target(1, PlugIn.CommandAudio);

                        return;
                    }
                    else if (Command.Check("Nav-Lock"))
                    {
                        Targeting.Select_Wingmans_NavLock(1, PlugIn.CommandAudio);

                        return;
                    }

                    Targeting.Select_Wingman(1, PlugIn.CommandAudio);
                }
                else if (Command.Check("Wingman Two"))
                {
                    Assisted.Targeting.Flag_Pause = true;

                    if (Command.Check("Target Select"))
                    {
                        Targeting.Select_Wingmans_Target(2, PlugIn.CommandAudio);

                        return;
                    }
                    else if (Command.Check("Nav-Lock"))
                    {
                        Targeting.Select_Wingmans_NavLock(2, PlugIn.CommandAudio);

                        return;
                    }

                    Targeting.Select_Wingman(2, PlugIn.CommandAudio);
                }
                else if (Command.Check("Wingman Three"))
                {
                    Assisted.Targeting.Flag_Pause = true;

                    if (Command.Check("Target Select"))
                    {
                        Targeting.Select_Wingmans_Target(3, PlugIn.CommandAudio);

                        return;
                    }
                    else if (Command.Check("Nav-Lock"))
                    {
                        Targeting.Select_Wingmans_NavLock(3, PlugIn.CommandAudio);

                        return;
                    }

                    Targeting.Select_Wingman(3, PlugIn.CommandAudio);
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
                        ISettings.U_AutoSystemScans(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_AutoSystemScans(false);
                    }
                }
                else if (Command.Check("Automatic Docking Procedures:"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_AutoDockingProcedure(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_AutoDockingProcedure(false);
                    }
                }
                else if (Command.Check("Automatic Refuel:"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_AutoRefuel(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_AutoRefuel(false);
                    }
                }
                else if (Command.Check("Automatic Rearm:"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_AutoRearm(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_AutoRearm(false);
                    }
                }
                else if (Command.Check("Automatic Repair:"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_AutoRepair(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_AutoRepair(false);
                    }
                }
                else if (Command.Check("Automatic Hanger Entry:"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_AutoHangerEntry(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_AutoHangerEntry(false);
                    }
                }
                else if (Command.Check("Combat Power Management"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_CombatPower(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_CombatPower(false);
                    }
                }
                else if (Command.Check("Post Jump Safety:"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_PostJumpSafety(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_PostJumpSafety(false);
                    }
                }
                else if (Command.Check("Weapon Safety"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_WeaponSafety(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_WeaponSafety(false);
                    }
                }
            }
            #endregion

            #region Combat Power Management
            else if (Command.Check("Combat Power Management:"))
            {
                if (ICheck.Order.CombatPower(MethodName, true, true))
                {
                    if (PlugIn.DebugMode == true)
                    { IPlatform.WriteToInterface("A.L.I.C.E: Context Mode - Combat Power Management Enabled", "Green"); }
                }
                else
                {
                    if (PlugIn.DebugMode == true)
                    { IPlatform.WriteToInterface("A.L.I.C.E: Context Mode - Combat Power Management Disabled", "Red"); }
                    return;
                }

                if (Command.Check("Maintain Engines"))
                {
                    Assisted.Power.Maintain_Engines(PlugIn.CommandAudio);
                }
                else if (Command.Check("Maintain Systems"))
                {
                    Assisted.Power.Maintain_Systems(PlugIn.CommandAudio);
                }
                else if (Command.Check("Default State"))
                {
                    Assisted.Power.Setting.Send_Power_To = Assisted.Power.Setting.Default_State;
                }
                else if (Command.Check("Power Weapons"))
                {
                    Assisted.Power.Setting.Send_Power_To = Assisted.Power.Str.Weapons;
                }
                else if (Command.Check("Engines"))
                {
                    Assisted.Power.Defense_Engines(PlugIn.CommandAudio);
                }
                else if (Command.Check("Systems"))
                {
                    Assisted.Power.Defense_Systems(PlugIn.CommandAudio);
                }
                else if (Command.Check("Heavy"))
                {
                    Assisted.Power.Weapons_Heavy(PlugIn.CommandAudio);
                }
                else if (Command.Check("Balance"))
                {
                    Assisted.Power.Weapons_Balance(PlugIn.CommandAudio);
                }
                else if (Command.Check("Light"))
                {
                    Assisted.Power.Weapons_Light(PlugIn.CommandAudio);
                }

                if (IStatus.Hardpoints == true)
                {
                    Assisted.Power.CombatPowerManagement();
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
                    {
                        Call.Power.Set(
                            IGet.Platform.WeaponPower(MethodName),
                            IGet.Platform.EnginePower(MethodName),
                            IGet.Platform.SystemPower(MethodName),
                            IGet.Platform.RecordPower(MethodName));
                    }))
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
                        Call.Action.CargoScoop(true, PlugIn.CommandAudio);
                    }
                    else if (Command.Check("Retract"))
                    {
                        Call.Action.CargoScoop(false, PlugIn.CommandAudio);
                    }
                }
                else if (Command.Check("External Lights"))
                {
                    if (Command.Check("Energize"))
                    {
                        Call.Action.ExternalLights(true, PlugIn.CommandAudio);
                    }
                    else if (Command.Check("Deenergize"))
                    {
                        Call.Action.ExternalLights(false, PlugIn.CommandAudio);
                    }
                }
                else if (Command.Check("Landing Gear"))
                {
                    if (Command.Check("Deploy"))
                    {
                        Call.Action.LandingGear(true, PlugIn.CommandAudio);
                    }
                    else if (Command.Check("Retract"))
                    {
                        Call.Action.LandingGear(false, PlugIn.CommandAudio);
                    }
                }
                else if (Command.Check("Silent Running"))
                {
                    if (Command.Check("Enable"))
                    {
                        Call.Action.SilentRunning(true, PlugIn.CommandAudio);
                    }
                    else if (Command.Check("Disable"))
                    {
                        Call.Action.SilentRunning(false, PlugIn.CommandAudio);
                    }
                }
                else if (Command.Check("Hardpoints"))
                {
                    if (Command.Check("Deploy"))
                    {
                        Call.Action.Hardpoint(true, PlugIn.CommandAudio);
                    }
                    else if (Command.Check("Retract"))
                    {
                        Call.Action.Hardpoint(false, PlugIn.CommandAudio);
                    }
                }
                else if (Command.Check("Fighter Order"))
                {
                    if (Command.Check("Attack Target"))
                    {
                        IActions.Fighter.AttackMyTarget(PlugIn.CommandAudio);
                    }
                    else if (Command.Check("Defend"))
                    {
                        IActions.Fighter.Defending(PlugIn.CommandAudio);
                    }
                    else if (Command.Check("Engage At Will"))
                    {
                        IActions.Fighter.EngageAtWill(PlugIn.CommandAudio);
                    }
                    else if (Command.Check("Follow"))
                    {
                        IActions.Fighter.Follow(PlugIn.CommandAudio);
                    }
                    else if (Command.Check("Hold"))
                    {
                        IActions.Fighter.HoldPosition(PlugIn.CommandAudio);
                    }
                    else if (Command.Check("Maintain"))
                    {
                        IActions.Fighter.Recall(PlugIn.CommandAudio);
                    }
                    else if (Command.Check("Recall"))
                    {
                        IActions.Fighter.Recall(PlugIn.CommandAudio);                        
                    }
                }
                else if (Command.Check("Shield Cell"))
                {
                    if (Command.Check("Activate"))
                    {
                        Call.Action.Activate_ShieldCell(PlugIn.CommandAudio);
                    }
                }
                else if (Command.Check("Heatsink Launcher"))
                {
                    if (Command.Check("Activate"))
                    {
                        Call.Action.Activate_Heatsink(PlugIn.CommandAudio);
                    }
                }
                else if (Command.Check("Chaff Launcher"))
                {
                    if (Command.Check("Activate"))
                    {
                        Call.Action.Activate_Chaff(PlugIn.CommandAudio);
                    }
                }

            }
            //End: Equipment
            #endregion

            #region Interactions
            else if (Command.Check("Interactions:"))
            {
                if (Command.Check("Response Check"))
                {
                    if (Command.Check("Yes") == true)
                    {
                        IStatus.Interaction.Yes();
                    }
                    else if (Command.Check("No") == true)
                    {
                        IStatus.Interaction.No();
                    }
                    else if (Command.Check("Mark") == true)
                    {
                        IStatus.Interaction.Mark();
                    }
                }                
            }
            #endregion

            #region Navigation
            else if (Command.Check("Navigation:"))
            {
                if (Command.Check("Abort Jump"))
                {
                    IActions.FrameShiftDrive.AbortJump(PlugIn.CommandAudio);
                }
                else if (Command.Check("Hyperspace"))
                {
                    bool OnMyMark = false;
                    if (Command.Check("On My Mark")) { OnMyMark = true; }

                    IActions.FrameShiftDrive.Hyperspace(PlugIn.CommandAudio, true, OnMyMark);
                }
                else if (Command.Check("Supercruise"))
                {
                    bool OnMyMark = false;
                    if (Command.Check("On My Mark")) { OnMyMark = true; }

                    IActions.FrameShiftDrive.Supercruise(PlugIn.CommandAudio, true, OnMyMark);
                }
                else if (Command.Check("Disengage"))
                {
                    bool OnMyMark = false;
                    if (Command.Check("On My Mark")) { OnMyMark = true; }

                    IActions.FrameShiftDrive.Supercruise(PlugIn.CommandAudio, false, OnMyMark);
                }
            }
            //End: Navigation
            #endregion

            #region Reports
            else if (Command.Check("Reports"))
            {
                if (Command.Check("Ship Loadout"))
                {
                    if (Command.Check("To Log"))
                    {
                        //IObjects.ShipProp.WTL_ShipsLoadout();
                    }
                }
                else if (Command.Check("No Fire Zone"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_NoFireZone(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_NoFireZone(false);
                    }
                }
                else if (Command.Check("Wanted Target"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_TargetWanted(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_TargetWanted(false);
                    }
                }
                else if (Command.Check("Enemy Target"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_TargetEnemy(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_TargetEnemy(false);
                    }
                }
                else if (Command.Check("Collected Bounties"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_CollectedBounty(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_CollectedBounty(false);
                    }
                }
                else if (Command.Check("Material Collected"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_MaterialCollected(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_MaterialCollected(false);
                    }
                }
                else if (Command.Check("Material Refined"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_MaterialRefined(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_MaterialRefined(false);
                    }
                }
                else if (Command.Check("Station Status"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_StationStatus(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_StationStatus(false);
                    }
                }
                else if (Command.Check("Shield State"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_ShieldState(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_ShieldState(false);
                    }
                }
                else if (Command.Check("Masslock"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_Masslock(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_Masslock(false);
                    }
                }
                else if (Command.Check("Fuel Scooping"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_FuelScoop(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_FuelScoop(false);
                    }
                }
                else if (Command.Check("Fuel Report"))
                {
                    if (Command.Check("Enable"))
                    {
                        ISettings.U_FuelStatus(true);
                    }
                    else if (Command.Check("Disable"))
                    {
                        ISettings.U_FuelStatus(false);
                    }
                    else if (Command.Check("Status"))
                    {
                        IEquipment.FuelTank.FuelLevel(true);
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
                    { BoostNum = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.BoostNum)); }
                    catch (Exception)
                    { IPlatform.WriteToInterface("A.L.I.C.E: Throttle: ALICE_BoostNum Was Not Set Or Was Not A Vaild Entry. Using Default Value (1)", Logger.Blue); }

                    IPlatform.SetText(IPlatform.IVar.BoostNum, null);

                    Call.Action.Boost(BoostNum, true, PlugIn.CommandAudio);
                }
                else if (Command.Check("Boost Stop"))
                {
                    Call.Action.Num_Boost = 0;
                }
                else if (Command.Check("15"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_15();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_15(true);
                    }
                }
                else if (Command.Check("20"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_20();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_20(true);
                    }
                }
                else if (Command.Check("25"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_25();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_25(true);
                    }
                }
                else if (Command.Check("30"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_30();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_30(true);
                    }
                }
                else if (Command.Check("35"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_35();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_35(true);
                    }
                }
                else if (Command.Check("40"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_40();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_40(true);
                    }
                }
                else if (Command.Check("45"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_45();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_45(true);
                    }
                }
                else if (Command.Check("50"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_50();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_50(true);
                    }
                }
                else if (Command.Check("55"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_55();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_55(true);
                    }
                }
                else if (Command.Check("60"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_60();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_60(true);
                    }
                }
                else if (Command.Check("65"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_65();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_65(true);
                    }
                }
                else if (Command.Check("70"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_70();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_70(true);
                    }
                }
                else if (Command.Check("75"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_75();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_75(true);
                    }
                }
                else if (Command.Check("80"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_80();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_80(true);
                    }
                }
                else if (Command.Check("85"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_85();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_85(true);
                    }
                }
                else if (Command.Check("90"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_90();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_90(true);
                    }
                }
                else if (Command.Check("95"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_95();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_95(true);
                    }
                }
                else if (Command.Check("100"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_100();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_100(true);
                    }
                }
                else if (Command.Check("10"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_10();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_10(true);
                    }
                }
                else if (Command.Check("0"))
                {
                    Call.Action.Throttle_0();
                }
                else if (Command.Check("5"))
                {
                    if (Command.Check("Positive"))
                    {
                        Call.Action.Throttle_5();
                    }
                    else if (Command.Check("Negative"))
                    {
                        Call.Action.Throttle_5(true);
                    }
                }
            }
            #endregion

            #region Overrides
            if (Command.Check("Override:"))
            {
                if (Command.Check("Crew"))
                {
                    Call.Overrides.Crew(PlugIn.CommandAudio);
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
                        IStatus.Interaction.Response.Alice(true);                        
                    }
                    else if (Command.Check("I Love You"))
                    {
                        IStatus.Interaction.Response.ILoveYou(true);
                    }
                    else if (Command.Check("Thank You"))
                    {
                        IStatus.Interaction.Response.ThankYou(true);
                    }                    
                }
                else if (Command.Check("Story"))
                {
                    if (Command.Check("Bio"))
                    {   
                        
                    }
                    else if (Command.Check("Name"))
                    {
                        
                    }

                }
            }
            #endregion         
        }

        public static void ActionCommands(string Command)
        {
            if (Command.Check("Analysis Mode"))
            {
                if (Command.Check("Enable"))
                {
                    Call.Action.AnalysisMode(true, PlugIn.CommandAudio);
                }
                else if (Command.Check("Disable"))
                {
                    Call.Action.AnalysisMode(false, PlugIn.CommandAudio);
                }
                else if (Command.Check("Toggle"))
                {
                    Call.Action.AnalysisMode(!IStatus.AnalysisMode, PlugIn.CommandAudio);
                }
            }
            else if (Command.Check("Cancel Docking"))
            {
                Call.Action.Docking(IEnums.CMD.False, PlugIn.CommandAudio);
            }
            else if (Command.Check("Request Docking"))
            {
                Call.Action.Docking(IEnums.CMD.True, PlugIn.CommandAudio, true);
            }
            else if (Command.Check("Deploy Fighter"))
            {
                if (Command.Check("Player"))
                {
                    decimal Num;

                    try
                    {
                        Num = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.FighterNumber));
                        Logger.DebugLine(MethodName, "Targeting Fighter " + Num + " For Deployment", Logger.Yellow);
                    }
                    catch (Exception)
                    {
                        Logger.DebugLine(MethodName, "ALICE_FighterNumer Is Not A Valid Number", Logger.Yellow);
                        return;
                    }

                    if (Num == 1 || Num == 2)
                    {
                        IActions.Fighter.Deploy(Num, true, PlugIn.CommandAudio);
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
                        Num = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.FighterNumber));
                        Logger.DebugLine(MethodName, "Targeting Fighter " + Num + " For Deployment", Logger.Yellow);
                    }
                    catch (Exception)
                    {
                        Logger.DebugLine(MethodName, "ALICE_FighterNumer Is Not A Valid Number", Logger.Yellow);
                        return;
                    }

                    if (Num == 1 || Num == 2)
                    {
                        IActions.Fighter.Deploy(Num, false, PlugIn.CommandAudio);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (Command.Check("Prepare To Dock"))
            {
                Call.Action.DockingPreparations(PlugIn.CommandAudio);
            }
            else if (Command.Check("Prepare To Land"))
            {
                Call.Action.LandingPreparations(PlugIn.CommandAudio);
            }
            else if (Command.Check("Discovery Scan"))
            {
                Call.Action.DiscoveryScanner(PlugIn.CommandAudio);
            }
            else if (Command.Check("Xeno Scan"))
            {
                Call.Action.XenoScanner(PlugIn.CommandAudio);
            }
            else if (Command.Check("Composite Scan"))
            {
                Call.Action.CompositeScaner(PlugIn.CommandAudio);
            }
            else if (Command.Check("Shield Cell"))
            {
                if (Command.Check("One"))
                {
                    Call.Action.SheildCell(true, Settings_Firegroups.Item.ShieldCellOne, GetColdMod());
                }
                else if (Command.Check("Two"))
                {
                    Call.Action.SheildCell(true, Settings_Firegroups.Item.ShieldCellTwo, GetColdMod());
                }
                else if (Command.Check("Three"))
                {
                    Call.Action.SheildCell(true, Settings_Firegroups.Item.ShieldCellThree, GetColdMod());
                }
                else if (Command.Check("Four"))
                {
                    Call.Action.SheildCell(true, Settings_Firegroups.Item.ShieldCellThree, GetColdMod());
                }
            }
            else if (Command.Check("Night Vision"))
            {
                if (Command.Check("Enable"))
                {
                    Call.Action.NightVision(true, PlugIn.CommandAudio);
                }
                else if (Command.Check("Disable"))
                {
                    Call.Action.NightVision(false, PlugIn.CommandAudio);
                }
                else if (Command.Check("Toggle"))
                {
                    Call.Action.NightVision(!IStatus.NightVision, PlugIn.CommandAudio);
                }
            }
            else if (Command.Check("Flight Assist"))
            {
                if (Command.Check("Enable"))
                {
                    Call.Action.FlightAssist(true, PlugIn.CommandAudio);
                }
                else if (Command.Check("Disable"))
                {
                    Call.Action.FlightAssist(false, PlugIn.CommandAudio);
                }
                else if (Command.Check("Toggle"))
                {
                    Call.Action.FlightAssist(!IStatus.NightVision, PlugIn.CommandAudio);
                }
            }
            else if (Command.Check("Full Spectrum Scanner"))
            {
                if (Command.Check("Enable"))
                {
                    Call.Action.Full_Spectrum_Scanner(true, PlugIn.CommandAudio);
                }
                else if (Command.Check("Disable"))
                {
                    Call.Action.Full_Spectrum_Scanner(false, PlugIn.CommandAudio);
                }
                else if (Command.Check("Toggle"))
                {
                    Call.Action.Full_Spectrum_Scanner(!IEquipment.DiscoveryScanner.Mode, PlugIn.CommandAudio);
                }
            }
            else if (Command.Check("Surface Scanner"))
            {
                if (Command.Check("Enable"))
                {
                    Call.Action.SurfaceScaner(true, PlugIn.CommandAudio);
                }
                else if (Command.Check("Disable"))
                {
                    Call.Action.SurfaceScaner(false, PlugIn.CommandAudio);
                }
                else if (Command.Check("Toggle"))
                {
                    Call.Action.SurfaceScaner(!IEquipment.SurfaceScanner.Mode, PlugIn.CommandAudio);
                }
            }
            else if (Command.Check("Launch"))
            {
                Call.Action.Launch(PlugIn.CommandAudio);
            }
        }

        public static void PlugInCommands(string Command)
        {
            if (Command.Check("Initialize"))
            {
                PlugIn.Initialize(true, true);
            }
            else if (Command.Check("Pip Speed"))
            {
                if (Command.Check("Increase"))
                {
                    ISettings.PipSpeed(false);
                }
                else if (Command.Check("Decrease"))
                {
                    ISettings.PipSpeed(true);
                }
            }
            else if (Command.Check("Panel Speed"))
            {
                if (Command.Check("Increase"))
                {
                    ISettings.PanelSpeed(false);
                }
                else if (Command.Check("Decrease"))
                {
                    ISettings.PanelSpeed(true);
                }
            }
            else if (Command.Check("Fire Group Speed"))
            {
                if (Command.Check("Increase"))
                {
                    ISettings.FireGroupSpeed(false);
                }
                else if (Command.Check("Decrease"))
                {
                    ISettings.FireGroupSpeed(true);
                }
            }
            else if (Command.Check("Throttle Speed"))
            {
                if (Command.Check("Increase"))
                {
                    ISettings.ThrottleSpeed(false);
                }
                else if (Command.Check("Decrease"))
                {
                    ISettings.ThrottleSpeed(true);
                }
            }
            else if (Command.Check("Extended Logging"))
            {
                if (Command.Check("Enable"))
                {
                    PlugIn.ExtendedLogging = true;
                    Logger.Log(MethodName, "Extended Logging Enabled", Logger.Yellow);
                }
                else if (Command.Check("Disable"))
                {
                    PlugIn.ExtendedLogging = false;
                    Logger.Log(MethodName, "Extended Logging Disabled", Logger.Yellow);
                }
            }
            else if (Command.Check("Debug Mode"))
            {
                if (Command.Check("Enable"))
                {
                    PlugIn.DebugMode = true;
                    Logger.Log(MethodName, "Debug Mode Enabled", Logger.Yellow);
                }
                else if (Command.Check("Disable"))
                {
                    PlugIn.DebugMode = false;
                    Logger.Log(MethodName, "Debug Mode Disabled", Logger.Yellow);
                }
            }
            else if (Command.Check("Monitor Status"))
            {
                if (Command.Check("Enable"))
                {
                    Monitors.Json.Log = true;
                    Logger.Log(MethodName, "Status Monitor Logging Enabled", Logger.Yellow);
                }
                else if (Command.Check("Disable"))
                {
                    Monitors.Json.Log = true;
                    Logger.Log(MethodName, "Status Monitor Logging Disabled", Logger.Yellow);
                }
            }
            else if (Command.Check("Master Audio"))
            {
                if (Command.Check("Enable"))
                {
                    PlugIn.MasterAudio = true;
                }
                else if (Command.Check("Disable"))
                {
                    PlugIn.MasterAudio = false;
                }
            }
            else if (Command.Check("Logger:"))
            {
                if (Command.Check("Stellar Bodies:"))
                {
                    if (Command.Check("All"))
                    {
                        ISettings.LogAllBodies = true;
                        Logger.Log(MethodName, "Logging All Bodies.", Logger.Yellow);
                    }
                    else if (Command.Check("Unscanned"))
                    {
                        ISettings.LogAllBodies = false;
                        Logger.Log(MethodName, "Logging Unscanned Bodies.", Logger.Yellow);
                    }
                }
            }
            else if (Command.Check("Screenshot"))
            {
                IScreenshot.Save();
            }

        }

        public static void FiregroupCommands(string Command)
        {
            if (Command.Check("Select"))
            {
                decimal FireGroup = -1;

                try
                { FireGroup = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.FireGroupSelect)); }
                catch (Exception)
                { IPlatform.WriteToInterface("A.L.I.C.E: Fire Groups: ALICE_FireGroupSelect Was Not Set To A Valid Option, Using Default Value (1).", Logger.Blue); }

                if (FireGroup > 0 && FireGroup < 9)
                { Call.Firegroup.Select(FireGroup, PlugIn.CommandAudio); }
                else
                { IPlatform.WriteToInterface("A.L.I.C.E: Fire Groups: ALICE_FireGroupSelect Must Be A Number Between 1 & 8.", "Red"); return; }

            }
            else if (Command.Check("Default"))
            {
                decimal FireGroup = 1;

                try
                {
                    FireGroup = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.FireGroupNum));
                }
                catch (Exception)
                {
                    IPlatform.WriteToInterface("A.L.I.C.E: Fire Groups: ALICE_FireGroupNum Was Not Set To A Valid Option, Using Default Value (1).", Logger.Blue);
                }

                if (FireGroup > 0 && FireGroup < 9)
                {
                    Call.Firegroup.Update_Default(FireGroup);
                }
                else
                {
                    IPlatform.WriteToInterface("A.L.I.C.E: Fire Groups: ALICE_FireGroupNum Must Be A Number Between 1 & 8.", "Red");
                    return;
                }
            }
            else if (Command.Check("Total"))
            {
                decimal FireGroup = 1;

                try
                {
                    FireGroup = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.FireGroupNum));
                }
                catch (Exception)
                {
                    IPlatform.WriteToInterface("A.L.I.C.E: Fire Groups: ALICE_FireGroupNum Was Not Set To A Valid Option, Using Default Value (1).", Logger.Blue);
                }

                if (FireGroup > 0 && FireGroup < 9)
                {
                    //FireGroupManagement.SetTotalFireGroup(FireGroup);
                }
                else
                {
                    IPlatform.WriteToInterface("A.L.I.C.E: Fire Groups: ALICE_FireGroupNum Must Be A Number Between 1 & 8.", "Red");
                    return;
                }
            }
            else if (Command.Check("Update"))
            {
                Call.Firegroup.Update_Total(PlugIn.CommandAudio);
            }
            else if (Command.Check("Assign"))
            {
                string FireGroup = "None";
                string FireMode = "None";

                try { FireGroup = IPlatform.GetText(IPlatform.IVar.FireGroup); }
                catch (Exception) { Logger.Exception(MethodName, "Unable to Get \"ALICE_FireGroup\""); }

                try { FireMode = IPlatform.GetText(IPlatform.IVar.FireMode); }
                catch (Exception) { Logger.Exception(MethodName, "Unable to Get \"ALICE_FireMode\""); }

                if (FireGroup == "None" || FireMode == "None")
                {
                    Logger.Log(MethodName, "Value Not Equal None", Logger.Red);
                    Logger.Log(MethodName, "FireGroup = " + FireGroup + " | FireMode = " + FireMode, Logger.Red);
                }

                if (Command.Check("Cargo Scanner"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ScannerCagro,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Composite Scanner"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ScannerComposite,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Discovery Scanner"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ScannerDiscovery,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Wake Scanner"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ScannerWake,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("ECM"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ECM,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Field Neutraliser"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.FieldNeutraliser,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("FSD Interdictor"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.FSDInterdictor,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Heatsink One"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LauncherHeatSinkOne,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Heatsink Two"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LauncherHeatSinkTwo,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Heatsink Three"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LauncherHeatSinkThree,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Heatsink Four"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LauncherHeatSinkFour,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Shield Cell One"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ShieldCellOne,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Shield Cell Two"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ShieldCellTwo,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Shield Cell Three"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ShieldCellThree,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Shield Cell Four"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ShieldCellFour,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Kill Warrent Scanner"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ScannerKillwarrent,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Mining Laser"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LaserMinning,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Surface Scanner"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ScannerSurface,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Xeno Scanner"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.ScannerXeno,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Collector Limpet"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LimpetCollector,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Decontamination Limpet"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LimpetDecontamination,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Fuel Limpet"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LimpetFuel,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Hatch Breaker Limpet"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LimpetHatchBreaker,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Prospector Limpet"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LimpetProspector,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Recon Limpet"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LimpetRecon,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Repair Limpet"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LimpetRepair,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }
                else if (Command.Check("Research Limpet"))
                {
                    ISettings.Firegroup.Assign
                        (
                        Settings_Firegroups.Item.LimpetResearch,
                        ISettings.Firegroup.ConvertGroupToEnum(FireGroup),
                        ISettings.Firegroup.ConverFireToEnum(FireMode)
                        );
                }

                IPlatform.SetText(IPlatform.IVar.FireGroup, "");
                IPlatform.SetText(IPlatform.IVar.FireMode, "");
            }
            else if (Command.Check("Module"))
            {
                if (Command.Check("Cargo Scanner"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerCagro);
                }
                else if (Command.Check("Composite Scanner"))
                {
                    Call.Action.CompositeScaner(PlugIn.CommandAudio, true);
                }
                else if (Command.Check("Discovery Scanner"))
                {
                    Call.Action.DiscoveryScanner(true, false, true);
                }
                else if (Command.Check("Wake Scanner"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerWake);
                }
                else if (Command.Check("ECM"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.ECM);
                }
                else if (Command.Check("Field Neutraliser"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.ECM);
                }
                else if (Command.Check("FSD Interdictor"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.FSDInterdictor);
                }
                else if (Command.Check("Field Neutraliser"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.FieldNeutraliser);
                }
                else if (Command.Check("FSD Interdictor"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.FSDInterdictor);
                }
                else if (Command.Check("Heatsink One"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LauncherHeatSinkOne);
                }
                else if (Command.Check("Heatsink Two"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LauncherHeatSinkTwo);
                }
                else if (Command.Check("Heatsink Three"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LauncherHeatSinkThree);
                }
                else if (Command.Check("Heatsink Four"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LauncherHeatSinkFour);
                }
                else if (Command.Check("Shield Cell One"))
                {
                    Call.Action.SheildCell(PlugIn.CommandAudio, Settings_Firegroups.Item.ShieldCellOne, false, true);
                }
                else if (Command.Check("Shield Cell Two"))
                {
                    Call.Action.SheildCell(PlugIn.CommandAudio, Settings_Firegroups.Item.ShieldCellOne, false, true);
                }
                else if (Command.Check("Shield Cell Three"))
                {
                    Call.Action.SheildCell(PlugIn.CommandAudio, Settings_Firegroups.Item.ShieldCellOne, false, true);
                }
                else if (Command.Check("Shield Cell Four"))
                {
                    Call.Action.SheildCell(PlugIn.CommandAudio, Settings_Firegroups.Item.ShieldCellOne, false, true);
                }
                else if (Command.Check("Kill Warrent Scanner"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerKillwarrent);
                }
                else if (Command.Check("Mining Laser"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LaserMinning);
                }
                else if (Command.Check("Surface Scanner"))
                {
                    Call.Action.SurfaceScaner(true, PlugIn.CommandAudio, true);
                }
                else if (Command.Check("Xeno Scanner"))
                {
                    Call.Action.XenoScanner(PlugIn.CommandAudio, true);
                }
                else if (Command.Check("Collector Limpet"))
                {
                    bool Select = true;
                    if (Command.Check("Activate")) { Select = false; }
                    Call.Action.CollectorLimpet(PlugIn.CommandAudio, Select);                    
                }
                else if (Command.Check("Decontamination Limpet"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LimpetDecontamination);
                }
                else if (Command.Check("Fuel Limpet"))
                {
                    bool Select = true;
                    if (Command.Check("Activate")) { Select = false; }
                    Call.Action.FuelLimpet(PlugIn.CommandAudio, Select);                    
                }
                else if (Command.Check("Hatch Breaker Limpet"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LimpetHatchBreaker);
                }
                else if (Command.Check("Prospector Limpet"))
                {
                    bool Select = true;
                    if (Command.Check("Activate")) { Select = false; }
                    Call.Action.ProspectorLimpet(PlugIn.CommandAudio, Select);                   
                }
                else if (Command.Check("Recon Limpet"))
                {
                    bool Select = true;
                    if (Command.Check("Activate")) { Select = false; }
                    Call.Action.ReconLimpet(PlugIn.CommandAudio, Select);
                }
                else if (Command.Check("Repair Limpet"))
                {
                    bool Select = true;
                    if (Command.Check("Activate")) { Select = false; }
                    Call.Action.RepairLimpet(PlugIn.CommandAudio, Select);                    
                }
                else if (Command.Check("Reserch Limpet"))
                {
                    ISettings.Firegroup.Select(Settings_Firegroups.Item.LimpetResearch);
                }
            }
        }       
    }
}
