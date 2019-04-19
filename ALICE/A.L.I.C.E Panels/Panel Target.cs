using ALICE_Actions;
using ALICE_Internal;
using System.Threading;
using ALICE_Settings;
using ALICE_Debug;

namespace ALICE_Panels
{
    public class TargetPanel : BasePanel
    {
        public NavigationTab Navigation { get; set; }
        public TransactionsTab Transactions { get; set; }
        public ContactsTab Contacts { get; set; }

        public TargetPanel()
        {
            Open = false;
            Pos = 1;
            Name = IEnums.Target;
            Navigation = new NavigationTab();
            Transactions = new TransactionsTab();
            Contacts = new ContactsTab();
        }

        public class NavigationTab : BaseTab
        {
            #region Notes
            //1. Set Filters / Reset Filters
            //2. Galaxy Map (Keybind Exists)
            //3. System Map (Keybind Exists)
            #endregion

            public bool FilterCheck = true;
            public bool FiltersSet = false;
            public bool Stars = false;
            public bool Asteroids = false;
            public bool Planets = false;
            public bool Landfalls = false;
            public bool Settlements = false;
            public bool Stations = false;
            public bool PointsOfInst = false;
            public bool Signals = false;
            public bool Systems = false;

            public NavigationTab()
            {
                Main = 2;
                Tab = 1;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.Target.Navigation(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.Target.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.Target.Panel(true);
                Call.Panel.Target.UpdateTab(Tab);
            }

            public void SetFilters()
            {
                string MethodName = "Set Filters";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                if (Main != 1) { Main = UpdateCursor(1, Main, true); }
            }

            public void GalaxyMap()
            {
                string MethodName = "Galaxy Map";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                if (Main != 2) { Main = UpdateCursor(2, Main, true); }
            }

            public void SystemMap()
            {
                string MethodName = "System Map";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                if (Main != 3) { Main = UpdateCursor(3, Main, true); }
            }

            /// <summary>
            /// Controls setting and clearing filters in the "Set Navigation Filters" submenu.
            /// </summary>
            /// <param name="Set">True = Set, Flase = Clear</param>
            /// <param name="Star">(Stars) Pass "True" To Enable Filter</param>
            /// <param name="Aste">(Asteroids) Pass "True" To Enable Filter</param>
            /// <param name="Plan">(Planets) Pass "True" To Enable Filter</param>
            /// <param name="Land">(Landfalls) Pass "True" To Enable Filter</param>
            /// <param name="Sett">(Settlements) Pass "True" To Enable Filter</param>
            /// <param name="Stat">(Station) Pass "True" To Enable Filter</param>
            /// <param name="Poin">(Points Of Instrest)  Pass "True" To Enable Filter</param>
            /// <param name="Sign">(Signals)  Pass "True" To Enable Filter</param>
            /// <param name="Syst">(Systems)  Pass "True" To Enable Filter</param>
            public void FilterLocations(bool Set, bool Star = false, bool Aste = false, bool Plan = false, bool Land = false, bool Sett = false, bool Stat = false, bool Poin = false, bool Sign = false, bool Syst = false)
            {
                //Track The Menu Position
                decimal Position = 1;

                //Check If First Run, Verify Filter Status With CMDR
                if (FilterCheck == true && Set)
                {
                    //Ask CMDR for status of filters.
                }

                //If We Are Setting Filters, Check The If Filters Changed
                if (Set && (Star != Stars || Aste != Asteroids || Plan != Planets || Land != Landfalls || Sett != Settlements ||
                    Stat != Stations || Poin != PointsOfInst ||  Sign != Signals || Syst != Systems))
                {
                    //Move Cursor From Submenu To Set Filters And Select It.
                    SetFilters(); Select(150);

                    //Process Filters
                    if (Star)
                    {
                        Select(50);
                    }

                    if (Aste)
                    {
                        Position = UpdateCursor(2, Position, true, 50); Select(50);
                    }

                    if (Plan)
                    {
                        Position = UpdateCursor(3, Position, true, 50); Select(50);
                    }

                    if (Land)
                    {
                        Position = UpdateCursor(4, Position, true, 50); Select(50);
                    }

                    if (Sett)
                    {
                        Position = UpdateCursor(5, Position, true, 50); Select(50);
                    }

                    if (Stat)
                    {
                        Position = UpdateCursor(6, Position, true, 50); Select(50);
                    }

                    if (Poin)
                    {
                        Position = UpdateCursor(7, Position, true, 50); Select(50);
                    }

                    if (Sign)
                    {
                        Position = UpdateCursor(8, Position, true, 50); Select(50);
                    }

                    if (Syst)
                    {
                        Position = UpdateCursor(9, Position, true, 50); Select(50);
                    }

                    //Allow Time For UI To Update & Exit Submenu
                    Thread.Sleep(250); Back();

                    //Move Cursor To Locations Submenu
                    Thread.Sleep(50); UpdateCursor(3, 1, false);
                }

                //Reset Location Filters
                else if (Set == false && FiltersSet)
                {
                    //Move To Set Filters
                    SetFilters();

                    //Move To Reset Option "X" And Reset
                    UpdateCursor(2, 1, false, 150); Select();
                }  
            }
        }

        public class TransactionsTab : BaseTab
        {
            #region Notes
            //1. Transactions
            //2. Missions
            //3. Passengers
            //4. Claims
            //5. Fines
            //6. Bounties
            #endregion

            public TransactionsTab()
            {
                Main = 1;
                Tab = 2;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.Target.Transactions(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.Target.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.Target.Panel(true);
                Call.Panel.Target.UpdateTab(Tab);
            }

            public void All()
            {
                string MethodName = "All";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                if (Main != 1) { Main = UpdateCursor(1, Main, true); }
                UpdateCursor(2, 1, false);
            }

            public void Missions()
            {
                string MethodName = "Missions";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                if (Main != 2) { Main = UpdateCursor(2, Main, true); }
                UpdateCursor(2, 1, false);
            }

            public void Passengers()
            {
                string MethodName = "Passengers";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                if (Main != 3) { Main = UpdateCursor(3, Main, true); }
                UpdateCursor(2, 1, false);
            }

            public void Claims()
            {
                string MethodName = "Claims";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                if (Main != 4) { Main = UpdateCursor(4, Main, true); }
                UpdateCursor(2, 1, false);
            }

            public void Fines()
            {
                string MethodName = "Fines";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                if (Main != 5) { Main = UpdateCursor(5, Main, true); }
                UpdateCursor(2, 1, false);
            }

            public void Bounties()
            {
                string MethodName = "Bounties";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                if (Main != 6) { Main = UpdateCursor(6, Main, true); }
                UpdateCursor(2, 1, false);
            }
        }

        public class ContactsTab : BaseTab
        {
            public ContactsTab()
            {
                Main = 1;
                Tab = 3;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.Target.Contacts(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.Target.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.Target.Panel(true);
                Call.Panel.Target.UpdateTab(Tab);
            }

            public void DockingRequest()
            {
                string MethodName = "Docking Request";
                bool Load = false; if (Call.Panel.Target.Pos != 3) { Load = true; } 
                Open(MethodName);

                if (Load) { Thread.Sleep(100); UpdateCursor(1, 2, false); }
                Thread.Sleep(ISettings.OffsetPanels);
                UpdateCursor(2, 1, false); Select();
            }
        }
    }
}
