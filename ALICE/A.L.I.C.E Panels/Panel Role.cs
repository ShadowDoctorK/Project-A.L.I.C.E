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
    public class RolePanel : BasePanel
    {
        public AllTab All { get; set; }
        public HelmTab Helm { get; set; }
        public FightersTab Fighters { get; set; }
        public SRVTab SRV { get; set; }
        public CrewTab Crew { get; set; }
        public HelpTab Help { get; set; }

        public RolePanel()
        {
            Open = false;
            Pos = 1;
            Name = IEnums.Role;
            All = new AllTab();
            Helm = new HelmTab();
            Fighters = new FightersTab();
            SRV = new SRVTab();
            Crew = new CrewTab();
            Help = new HelpTab();
        }

        public class AllTab : BaseTab
        {
            public AllTab()
            {
                Tab = 1;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.Role.All(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.Role.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.Role.Panel(true);
                Call.Panel.Role.UpdateTab(Tab);
            }
        }

        public class HelmTab : BaseTab
        {
            public HelmTab()
            {
                Tab = 2;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.Role.Helm(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.Role.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.Role.Panel(true);
                Call.Panel.Role.UpdateTab(Tab);
            }
        }

        public class FightersTab : BaseTab
        {
            public FightersTab()
            {
                Main = 1;
                Tab = 3;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.Role.Fighters(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.Role.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.Role.Panel(true);
                Call.Panel.Role.UpdateTab(Tab);
            }
        }

        public class SRVTab : BaseTab
        {
            public SRVTab()
            {
                Main = 1;
                Tab = 4;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.Role.SRV(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.Role.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.Role.Panel(true);
                Call.Panel.Role.UpdateTab(Tab);
            }
        }

        public class CrewTab : BaseTab
        {
            public CrewTab()
            {
                Tab = 5;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.Role.Crew(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.Role.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.Role.Panel(true);
                Call.Panel.Role.UpdateTab(Tab);
            }
        }

        public class HelpTab : BaseTab
        {
            public HelpTab()
            {
                Tab = 6;
            }

            public bool CheckTab(string MethodName)
            {
                return ICheck.Panel.Role.Help(MethodName, true);
            }

            public bool CheckPanel(string MethodName)
            {
                return ICheck.Panel.Role.Open(MethodName, true);
            }

            public override void Panel_Target()
            {
                Call.Panel.Role.Panel(true);
                Call.Panel.Role.UpdateTab(Tab);
            }
        }
    }
}
