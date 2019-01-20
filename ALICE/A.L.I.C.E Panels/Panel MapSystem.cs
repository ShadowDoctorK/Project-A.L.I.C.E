using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Actions;
using ALICE_Internal;

namespace ALICE_Panels
{
    public class SystemMapPanel : BasePanel
    {
        public SystemMapPanel()
        {
            Open = false;
            Pos = 1;
            Name = IEnums.MapSystem;
            SummaryTab Summary = new SummaryTab();
            InfoTab Info = new InfoTab();
            BookmarksTab Bookmarks = new BookmarksTab();
            LocationsTab Locations = new LocationsTab();
        }

        public class SummaryTab : BaseTab
        {
            public SummaryTab()
            {
                Tab = 1;
            }

            public override void Panel_Target()
            {
                Call.Panel.SystemMap.Panel(true);
                Call.Panel.SystemMap.UpdateTab(Tab);
            }
        }

        public class InfoTab : BaseTab
        {
            public InfoTab()
            {
                Tab = 2;
            }

            public override void Panel_Target()
            {
                Call.Panel.SystemMap.Panel(true);
                Call.Panel.SystemMap.UpdateTab(Tab);
            }
        }

        public class BookmarksTab : BaseTab
        {
            public BookmarksTab()
            {
                Main = 1;
                Tab = 3;
            }

            public override void Panel_Target()
            {
                Call.Panel.SystemMap.Panel(true);
                Call.Panel.SystemMap.UpdateTab(Tab);
            }
        }

        public class LocationsTab : BaseTab
        {
            public LocationsTab()
            {
                Tab = 4;
            }

            public override void Panel_Target()
            {
                Call.Panel.SystemMap.Panel(true);
                Call.Panel.SystemMap.UpdateTab(Tab);
            }
        }
    }
}
