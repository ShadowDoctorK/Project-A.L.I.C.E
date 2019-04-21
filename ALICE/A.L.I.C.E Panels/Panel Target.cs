using ALICE_Actions;
using ALICE_Internal;
using System.Threading;
using ALICE_Settings;
using ALICE_Debug;
using ALICE_Core;
using ALICE_Response;
using ALICE_Synthesizer;
using ALICE_Keybinds;

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
                    SetFilters();

                    //Ask CMDR for status of filters.
                    IResponse.Panels.QuestionFilters(true);

                    //Monitor Response
                    Thread.Sleep(1500); switch (IStatus.Interaction.Question(6000))
                    {
                        case ALICE_Status.Status_Interaction.Answers.NoResponse:

                            //Debug Logger
                            Logger.DebugLine(MethodName, "Question: No Response.", Logger.Yellow);

                            //Close Taret Panel
                            Call.Panel.Target.Panel(false);
                            return;

                        case ALICE_Status.Status_Interaction.Answers.Yes:

                            //Audio - Postive Response
                            IResponse.General.Positve(true);

                            //Move To Reset Option "X" And Reset
                            UpdateCursor(2, 1, false, 150); Select(150);
                            break;

                        case ALICE_Status.Status_Interaction.Answers.No:

                            //Audio - Safeties Remain
                            IResponse.General.Positve(true);                            
                            break;

                        default:

                            //Close Taret Panel
                            Call.Panel.Target.Panel(false);
                            return;                            
                    }

                    FiltersSet = false;
                    FilterCheck = false;
                }

                //If Filters Are Set & We Are Setting New Filters
                if (Set && FiltersSet)
                {
                    //Move To Set Filters
                    SetFilters();

                    //Move To Reset Option "X" And Reset
                    UpdateCursor(2, 1, false, 150); Select();
                    Thread.Sleep(100);
                }

                //If We Are Setting Filters, Check The If Filters Changed
                if (Set && (Star != Stars || Aste != Asteroids || Plan != Planets || Land != Landfalls || Sett != Settlements ||
                    Stat != Stations || Poin != PointsOfInst ||  Sign != Signals || Syst != Systems))
                {
                    //Move Cursor From Submenu To Set Filters And Select It.
                    SetFilters(); Select(150);

                    Thread.Sleep(100);

                    //Process Filters
                    if (Star)
                    {
                        Select(50);
                        Thread.Sleep(50);
                    }

                    IKeyboard.Press(IKey.UI_Panel_Down, 100, IKey.DelayPanel);

                    if (Aste)
                    {
                        Select(50);
                        Thread.Sleep(50);
                    }

                    IKeyboard.Press(IKey.UI_Panel_Down, 100, IKey.DelayPanel);

                    if (Plan)
                    {
                        Select(50);
                        Thread.Sleep(50);
                    }

                    IKeyboard.Press(IKey.UI_Panel_Down, 100, IKey.DelayPanel);

                    if (Land)
                    {
                        Select(50);
                        Thread.Sleep(50);
                    }

                    IKeyboard.Press(IKey.UI_Panel_Down, 100, IKey.DelayPanel);

                    if (Sett)
                    {
                        Select(50);
                        Thread.Sleep(50);
                    }

                    IKeyboard.Press(IKey.UI_Panel_Down, 100, IKey.DelayPanel);

                    if (Stat)
                    {
                        Select(50);
                        Thread.Sleep(50);
                    }

                    IKeyboard.Press(IKey.UI_Panel_Down, 100, IKey.DelayPanel);

                    if (Poin)
                    {
                        Select(50);
                        Thread.Sleep(50);
                    }

                    IKeyboard.Press(IKey.UI_Panel_Down, 100, IKey.DelayPanel);

                    if (Sign)
                    {
                        Select(50);
                        Thread.Sleep(50);
                    }

                    IKeyboard.Press(IKey.UI_Panel_Down, 100, IKey.DelayPanel);

                    if (Syst)
                    {
                        Select(50);
                        Thread.Sleep(50);
                    }

                    //Allow Time For UI To Update & Exit Submenu
                    Thread.Sleep(250); Back(50);

                    //Move Cursor To Locations Submenu
                    Thread.Sleep(50); UpdateCursor(3, 1, false);

                    //Update Filters Set
                    FiltersSet = true;
                }

                //Reset Location Filters
                else if (Set == false && FiltersSet)
                {
                    //Move To Set Filters
                    SetFilters();

                    //Move To Reset Option "X" And Reset
                    UpdateCursor(2, 1, false, 150); Select();

                    //Update Filters Set
                    FiltersSet = false;
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
