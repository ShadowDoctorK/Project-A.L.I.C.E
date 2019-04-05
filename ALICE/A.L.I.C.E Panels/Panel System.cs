using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Actions;
using ALICE_Internal;
using ALICE_Debug;

namespace ALICE_Panels
{
    public class SystemPanel : BasePanel
    {
        public HomeTab Home { get; set; }
        public ModulesTab Modules { get; set; }
        public FireGroupTab FireGroups { get; set; }
        public ShipTab Ship { get; set; }
        public InventoryTab Inventory { get; set; }
        public StatusTab Status { get; set; }
        public MediaTab Media { get; set; }

        public SystemPanel()
        {
            Open = false;
            Pos = 1;
            Name = IEnums.System;
            Home = new HomeTab();
            Modules = new ModulesTab();
            FireGroups = new FireGroupTab();
            Ship = new ShipTab();
            Inventory = new InventoryTab();
            Status = new StatusTab();
            Media = new MediaTab();
        }

        public override void TabPrep(decimal Select)
        {
            if (ICheck.Panel.System.Home(MethodName, true) == false)
            {
                Call.Panel.System.Home.Main = 3;
            }
        }

        public class HomeTab : BaseTab
        {
            public decimal Column { get; set; }

            public HomeTab()
            {
                Main = 3;
                Column = 1;
                Tab = 1;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.System.Home(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.System.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.System.Panel(true);
                Call.Panel.System.UpdateTab(Tab);
            }

            public void GalnetNews()
            {
                string MethodName = "Galnet News";
                Open(MethodName);

                if (Main != 1) { Main = UpdateCursor(1, Main, true); }
                if (Column != 1) { Column = UpdateCursor(1, Column, false); }
                Select(); //Galnet News Returns you to the System Panel.
            }

            public void HoloMe()
            {
                string MethodName = "Holo Me";
                Open(MethodName);

                if (Main != 1) { Main = UpdateCursor(1, Main, true); }
                if (Column != 2) { Column = UpdateCursor(2, Column, false); }
                Select(); MainFourIsFalse();
            }

            public void Engineers()
            {
                string MethodName = "Engineers";
                Open(MethodName);

                if (Main != 1) { Main = UpdateCursor(1, Main, true); }
                if (Column != 3) { Column = UpdateCursor(3, Column, false); }
                Select(); MainFourIsFalse();
            }

            public void Codex()
            {
                string MethodName = "Codex";
                Open(MethodName);

                if (Main != 2) { Main = UpdateCursor(2, Main, true); }
                if (Column != 1) { Column = UpdateCursor(1, Column, false); }
                Select(); MainFourIsFalse();
            }

            public void Squadrons()
            {
                string MethodName = "Squadrons";
                Open(MethodName);

                if (Main != 2) { Main = UpdateCursor(2, Main, true); }
                if (Column != 2) { Column = UpdateCursor(2, Column, false); }
                Select(); MainFourIsFalse();
            }

            public void GalaticPowers()
            {
                string MethodName = "Galatic Powers";
                Open(MethodName);

                if (Main != 2) { Main = UpdateCursor(2, Main, true); }
                if (Column != 3) { Column = UpdateCursor(3, Column, false); }
                Select(); MainFourIsFalse();
            }
        }

        public class ModulesTab : BaseTab
        {
            public ModulesTab()
            {
                Tab = 2;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.System.Modules(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.System.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.System.Panel(true);
                Call.Panel.System.UpdateTab(Tab);
            }
        }

        public class FireGroupTab : BaseTab
        {
            public FireGroupTab()
            {
                Tab = 3;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.System.FireGroups(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.System.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.System.Panel(true);
                Call.Panel.System.UpdateTab(Tab);
            }
        }

        public class ShipTab : BaseTab
        {
            public decimal FuncRow { get; set; }
            public decimal PrefRow { get; set; }

            public ShipTab()
            {
                Main = 1;
                Tab = 4;
                FuncRow = 1;
                PrefRow = 1;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.System.Ship(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.System.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.System.Panel(true);
                Call.Panel.System.UpdateTab(Tab);
            }

            public void Functions()
            {
                string MethodName = "Functions";
                Open(MethodName);

                Main = UpdateCursor(1, Main, true);
            }

            public void Preferences()
            {
                string MethodName = "Preferences";
                Open(MethodName);

                Main = UpdateCursor(2, Main, true);
            }

            public void Statistics()
            {
                string MethodName = "Statistics";
                Open(MethodName);

                Main = UpdateCursor(3, Main, true);
            }
        }

        public class InventoryTab : BaseTab
        {
            #region Notes
            //1. Ship Cargo
            //2. Refinery
            //3. Materials
            //4. Data
            //5. Synthesis
            //6. Cabins
            #endregion

            public InventoryTab()
            {
                Main = 1;
                Tab = 5;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.System.Inventory(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.System.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.System.Panel(true);
                Call.Panel.System.UpdateTab(Tab);
            }

            public void ShipsCargo()
            {
                string MethodName = "Ships Cargo";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                Main = UpdateCursor(1, Main, true);
                UpdateCursor(2, 1, false);
            }

            public void Refinery()
            {
                string MethodName = "Refinery";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                Main = UpdateCursor(2, Main, true);
                UpdateCursor(2, 1, false);
            }

            public void Materials()
            {
                string MethodName = "Materials";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                Main = UpdateCursor(3, Main, true);
                UpdateCursor(2, 1, false);
            }

            public void Data()
            {
                string MethodName = "Data";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                Main = UpdateCursor(4, Main, true);
                UpdateCursor(2, 1, false);
            }

            public void Synthesis()
            {
                string MethodName = "Synthesis";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                Main = UpdateCursor(5, Main, true);
                UpdateCursor(2, 1, false);
            }

            public void Cabins()
            {
                string MethodName = "Cabins";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                Main = UpdateCursor(6, Main, true);
                UpdateCursor(2, 1, false);
            }
        }

        public class StatusTab : BaseTab
        {
            #region Notes
            //1. System Factions
            //2. Reputation
            //3. Session Log
            //4. Finance
            //5. Permits
            #endregion

            public StatusTab()
            {
                Tab = 6;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.System.Status(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.System.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.System.Panel(true);
                Call.Panel.System.UpdateTab(Tab);
            }

            public void SystemFactions()
            {
                string MethodName = "System Factions";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                Main = UpdateCursor(1, Main, true);
                UpdateCursor(2, 1, false);
            }

            public void Reputation()
            {
                string MethodName = "Reputation";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                Main = UpdateCursor(2, Main, true);
                UpdateCursor(2, 1, false);
            }

            public void SessionLog()
            {
                string MethodName = "Session Log";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                Main = UpdateCursor(3, Main, true);
                UpdateCursor(2, 1, false);
            }

            public void Finance()
            {
                string MethodName = "Finance";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                Main = UpdateCursor(4, Main, true);
                UpdateCursor(2, 1, false);
            }

            public void Permits()
            {
                string MethodName = "Permits";
                Open(MethodName);

                UpdateCursor(1, 2, false);
                Main = UpdateCursor(5, Main, true);
                UpdateCursor(2, 1, false);
            }
        }

        public class MediaTab : BaseTab
        {
            public MediaTab()
            {
                Tab = 7;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.System.Media(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.System.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.System.Panel(true);
                Call.Panel.System.UpdateTab(Tab);
            }
        }
    }
}