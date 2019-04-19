using ALICE_Actions;
using ALICE_Debug;
using ALICE_Keybinds;
using System.Collections.Generic;

namespace ALICE_Interface
{
    public static partial class ICommands
    {
        public static CMD_Panels CMDPanels = new CMD_Panels();
    }

    public class CMD_Panels : Commands
    {
        public void Search(List<string> Command)
        {
            switch (Command[1].Lookup<L1>())
            {
                case L1.Close:
                    IKeyboard.Press(IKey.UI_Back);
                    return;

                case L1.Target:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Select:
                            Call.Panel.Target.Panel(true);
                            return;

                        case L2.Navigation:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Target.Navigation.Open(ICommands.M);
                                    return;

                                case L3.Set_Locations:
                                    Call.Panel.Target.Navigation.FilterLocations(true,
                                        IGet.External.NavStars(ICommands.M),
                                        IGet.External.NavAsteroids(ICommands.M),
                                        IGet.External.NavPlanets(ICommands.M),
                                        IGet.External.NavLandfalls(ICommands.M),
                                        IGet.External.NavSettlements(ICommands.M),
                                        IGet.External.NavStations(ICommands.M),
                                        IGet.External.NavPoints(ICommands.M),
                                        IGet.External.NavSignals(ICommands.M),
                                        IGet.External.NavSystems(ICommands.M));
                                    return;

                                case L3.Reset_Locations:
                                    Call.Panel.Target.Navigation.FilterLocations(false);
                                    return;

                                case L3.Set_Filters:
                                    Call.Panel.Target.Navigation.SetFilters();
                                    return;

                                case L3.Galaxy_Map:
                                    Call.Panel.Target.Navigation.GalaxyMap();
                                    return;

                                case L3.System_Map:
                                    Call.Panel.Target.Navigation.SystemMap();
                                    return;
                           
                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Transactions:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Target.Transactions.Open(ICommands.M);
                                    return;

                                case L3.All:
                                    Call.Panel.Target.Transactions.All();
                                    return;

                                case L3.Missions:
                                    Call.Panel.Target.Transactions.Missions();
                                    return;

                                case L3.Passengers:
                                    Call.Panel.Target.Transactions.Passengers();
                                    return;

                                case L3.Claims:
                                    Call.Panel.Target.Transactions.Claims();
                                    return;

                                case L3.Fines:
                                    Call.Panel.Target.Transactions.Fines();
                                    return;

                                case L3.Bounties:
                                    Call.Panel.Target.Transactions.Bounties();
                                    return;
                           
                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Contacts:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Target.Contacts.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }
                       
                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Comms:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Select:
                            Call.Panel.Comms.Panel(true);
                            return;

                        case L2.Chat:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Comms.Chat.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Inbox:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Comms.Inbox.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Social:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Comms.Social.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.History:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Comms.History.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Squadron:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Comms.Squadron.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Settings:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Comms.Settings.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Role:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Select:
                            Call.Panel.Role.Panel(true);
                            return;

                        case L2.All:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Role.All.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }
                           
                        case L2.Helm:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Role.Helm.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }
                            
                        case L2.Fighters:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Role.Fighters.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }
                            
                        case L2.SRV:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Role.SRV.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }
                           
                        case L2.Crew:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Role.Crew.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Help:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.Role.Help.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.System:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Select:
                            Call.Panel.System.Panel(true);
                            return;

                        case L2.Home:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.System.Home.Open(ICommands.M);
                                    return;

                                case L3.Galnet_Today:
                                    Call.Panel.System.Home.GalnetNews();
                                    return;

                                case L3.Holo_Me:
                                    Call.Panel.System.Home.HoloMe();
                                    return;

                                case L3.Engineers:
                                    Call.Panel.System.Home.Engineers();

                                    //Set All Panels To False
                                    Call.Panel.MainFourIsFalse();                                    
                                    return;

                                case L3.Codex:
                                    Call.Panel.System.Home.Codex();
                                    return;

                                case L3.Squadrons:
                                    Call.Panel.System.Home.Squadrons();
                                    return;

                                case L3.Galatic_Powers:
                                    Call.Panel.System.Home.GalaticPowers();
                                    return;                               

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 2);
                                    return;
                            }

                        case L2.Modules:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.System.Modules.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Fire_Groups:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.System.FireGroups.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Ship:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.System.Ship.Open(ICommands.M);
                                    return;

                                case L3.Functions:
                                    Call.Panel.System.Ship.Functions();
                                    return;

                                case L3.Preferences:
                                    Call.Panel.System.Ship.Preferences();
                                    return;

                                case L3.Statistics:
                                    Call.Panel.System.Ship.Statistics();
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Inventory:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.System.Inventory.Open(ICommands.M);
                                    return;

                                case L3.Ships_Cargo:
                                    Call.Panel.System.Inventory.ShipsCargo();
                                    return;

                                case L3.Refinery:
                                    Call.Panel.System.Inventory.Refinery();
                                    return;

                                case L3.Materials:
                                    Call.Panel.System.Inventory.Materials();
                                    return;

                                case L3.Data:
                                    Call.Panel.System.Inventory.Data();
                                    return;

                                case L3.Synthesis:
                                    Call.Panel.System.Inventory.Synthesis();
                                    return;

                                case L3.Cabins:
                                    Call.Panel.System.Inventory.Cabins();
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Status:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.System.Status.Open(ICommands.M);
                                    return;

                                case L3.System_Factions:
                                    Call.Panel.System.Status.SystemFactions();
                                    return;

                                case L3.Reputation:
                                    Call.Panel.System.Status.Reputation();
                                    return;

                                case L3.Session_Log:
                                    Call.Panel.System.Status.SessionLog();
                                    return;

                                case L3.Finance:
                                    Call.Panel.System.Status.Finance();
                                    return;

                                case L3.Permits:
                                    Call.Panel.System.Status.Permits();
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Media:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.System.Media.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.Galaxy_Map:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Open:
                            Call.Panel.GalaxyMap.Panel(true);
                            return;

                        case L2.Close:
                            Call.Panel.GalaxyMap.Panel(false);
                            return;

                        case L2.Info:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.GalaxyMap.Info.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Search:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.GalaxyMap.Search.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Bookmarks:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.GalaxyMap.Bookmarks.Open(ICommands.M);
                                    return;

                                case L3.Plot:
                                    Call.Panel.GalaxyMap.Bookmarks.PlotBookmark(IGet.External.BookmarkNum(ICommands.M, true));
                                    return;

                                case L3.Reset:
                                    Call.Panel.GalaxyMap.Bookmarks.ResetBookmarks();
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Configuration:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.GalaxyMap.Config.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        case L2.Options:

                            switch (Command[3].Lookup<L3>())
                            {
                                case L3.Select:
                                    Call.Panel.GalaxyMap.Options.Open(ICommands.M);
                                    return;

                                default:
                                    ICommands.LogInvalid(ICommands.M, Command, 3);
                                    return;
                            }

                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                case L1.System_Map:

                    switch (Command[2].Lookup<L2>())
                    {
                        case L2.Open:
                            Call.Panel.SystemMap.Panel(true);
                            return;

                        case L2.Close:
                            Call.Panel.SystemMap.Panel(false);
                            return;
                    
                        default:
                            ICommands.LogInvalid(ICommands.M, Command, 2);
                            return;
                    }

                default:
                    ICommands.LogInvalid(ICommands.M, Command, 1);
                    return;
            }
        }
    }
}