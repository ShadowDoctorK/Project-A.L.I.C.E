using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Actions;
using ALICE_Internal;
using System.Threading;
using ALICE_Debug;
using ALICE_Keybinds;

namespace ALICE_Panels
{
    public class GalaxyMapPanel : BasePanel
    {
        public InfoTab Info { get; set; }
        public SearchTab Search { get; set; }
        public BookmarksTab Bookmarks { get; set; }
        public ConfigTab Config { get; set; }
        public OptionsTab Options { get; set; }

        public GalaxyMapPanel()
        {
            Open = false;
            Pos = 1;
            Name = IEnums.MapGalaxy;
            Info = new InfoTab();
            Search = new SearchTab();
            Bookmarks = new BookmarksTab();
            Config = new ConfigTab();
            Options = new OptionsTab();
        }

        public class InfoTab : BaseTab
        {
            public InfoTab()
            {
                Tab = 1;
            }

            public override void Open(string MethodName)
            {
                if (ICheck.Panel.GalaxyMap.Open(MethodName, false) == true)
                {
                    Call.Panel.GalaxyMap.Pos = 1;
                }

                if (CheckEnvironment(MethodName) == false) { return; }
                if (CheckMap(MethodName, true, false, true) == false)
                { if (CloseMap(MethodName, true, false, true) == false) { return; } }
                CheckOverlays(MethodName);
                Panel_Target();
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.GalaxyMap.Info(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.GalaxyMap.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.System.Panel(true);
                WaitMap(MethodName, IEnums.MapGalaxy, true);
                Call.Panel.GalaxyMap.UpdateTab(Tab, 100);
            }
        }

        public class SearchTab : BaseTab
        {
            public SearchTab()
            {
                Tab = 2;
            }

            public override void Open(string MethodName)
            {
                if (ICheck.Panel.GalaxyMap.Open(MethodName, false) == true)
                {
                    Call.Panel.GalaxyMap.Pos = 1;
                }

                if (CheckEnvironment(MethodName) == false) { return; }
                if (CheckMap(MethodName, true, false, true) == false)
                { if (CloseMap(MethodName, true, false, true) == false) { return; } }
                CheckOverlays(MethodName);
                Panel_Target();
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.GalaxyMap.Search(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.GalaxyMap.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.GalaxyMap.Panel(true);
                WaitMap(MethodName, IEnums.MapGalaxy, true);
                Call.Panel.GalaxyMap.UpdateTab(Tab, 100);
            }
        }

        public class BookmarksTab : BaseTab
        {
            public BookmarksTab()
            {
                Main = 1;
                Tab = 3;
            }

            public override void Open(string MethodName)
            {
                if (ICheck.Panel.GalaxyMap.Open(MethodName, false) == true)
                { Call.Panel.GalaxyMap.Pos = 1; }

                if (CheckEnvironment(MethodName) == false) { return; }
                if (CheckMap(MethodName, true, false, true) == false)
                { if (CloseMap(MethodName, true, false, true) == false) { return; } }
                CheckOverlays(MethodName);
                Panel_Target();
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.GalaxyMap.Bookmarks(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.GalaxyMap.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.GalaxyMap.Panel(true);
                WaitMap(MethodName, IEnums.MapGalaxy, true);

                //Pause On Bookmarks. When Bookmarks Load The Game Lags And
                //The Panels Can Missfire. The Pause Helps Keep Alignment.
                if (Tab > 3)
                {
                    Call.Panel.GalaxyMap.UpdateTab(3, 100);
                    Thread.Sleep(300);
                    Call.Panel.GalaxyMap.UpdateTab(Tab, 100);
                }
                else
                {
                    Call.Panel.GalaxyMap.UpdateTab(Tab, 100);
                }
            }

            public void PlotBookmark(decimal Number)
            {
                string MethodName = "Plot Bookmark";
                Open(MethodName);

                UpdateCursor(1, 2, false, 100);
                Main = UpdateCursor(Number, Main, true, 100);                
                Select(100); Select(100);
                Call.Panel.GalaxyMap.Panel(false);
            }

            public void ResetBookmarks()
            {
                string MethodName = "Reset Bookmarks";
                Open(MethodName);

                IKeyboard.Press(IKey.UI_Panel_Left, 100);
                IKeyboard.Press(IKey.UI_Panel_Up_Press, 3000);
                IKeyboard.Press(IKey.UI_Panel_Up_Release, 0);
                Main = 1;
                Logger.Log(MethodName, "Attempted To Reset Bookmarks. If Incorrect Please Place On Bookmart #1.", Logger.Yellow);
            }
        }

        public class ConfigTab : BaseTab
        {
            public ConfigTab()
            {
                Tab = 4;
            }

            public override void Open(string MethodName)
            {
                if (ICheck.Panel.GalaxyMap.Open(MethodName, false) == true)
                { Call.Panel.GalaxyMap.Pos = 1; }

                if (CheckEnvironment(MethodName) == false) { return; }
                if (CheckMap(MethodName, true, false, true) == false)
                { if (CloseMap(MethodName, true, false, true) == false) { return; } }
                CheckOverlays(MethodName);
                Panel_Target();
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.GalaxyMap.Config(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.GalaxyMap.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.GalaxyMap.Panel(true);
                WaitMap(MethodName, IEnums.MapGalaxy, true);
                Call.Panel.GalaxyMap.UpdateTab(Tab, 100);
            }
        }

        public class OptionsTab : BaseTab
        {
            public OptionsTab()
            {
                Tab = 5;
            }

            public override void Open(string MethodName)
            {
                if (ICheck.Panel.GalaxyMap.Open(MethodName, false) == true)
                { Call.Panel.GalaxyMap.Pos = 1; }

                if (CheckEnvironment(MethodName) == false) { return; }
                if (CheckMap(MethodName, true, false, true) == false)
                { if (CloseMap(MethodName, true, false, true) == false) { return; } }
                CheckOverlays(MethodName);
                Panel_Target();
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.GalaxyMap.Options(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.GalaxyMap.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.GalaxyMap.Panel(true);
                WaitMap(MethodName, IEnums.MapGalaxy, true);
                Call.Panel.GalaxyMap.UpdateTab(Tab, 100);
            }
        }
    }
}