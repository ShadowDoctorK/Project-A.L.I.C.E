#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Panel Panel { get; set; } = new Panel();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Actions;
    using ALICE_Debug;

    public class Panel
    {
        public PanelSystem System { get; set; } = new PanelSystem();
        public PanelRole Role { get; set; } = new PanelRole();
        public PanelComms Comms { get; set; } = new PanelComms();
        public PanelTarget Target { get; set; } = new PanelTarget();
        public MapGalaxy GalaxyMap { get; set; } = new MapGalaxy();
        public MapSystem SystemMap { get; set; } = new MapSystem();

        public class PanelSystem : Debug
        {
            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
            /// <param name="T">(Target) The Expected State</param>
            /// <param name="L">(Logger) Enables / Disables Logging</param>
            /// <returns></returns>
            public bool Open(string M, bool T, bool L = true)
            { return Evaluate(M, "System Panel (Open)", T, Call.Panel.System.Open, L); }

            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target State?</param>
            /// <param name="C">(Check) The State You're Checking</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Position(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, "System Panel (Position)", T, C, Call.Panel.System.Pos, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Home(string M, bool T, bool L = true)
            { return Evaluate(M, "System Panel (Home Tab)", T, Call.Panel.System.Pos, Call.Panel.System.Home.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Modules(string M, bool T, bool L = true)
            { return Evaluate(M, "System Panel (Modules Tab)", T, Call.Panel.System.Pos, Call.Panel.System.Modules.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool FireGroups(string M, bool T, bool L = true)
            { return Evaluate(M, "System Panel (Fire Groups Tab)", T, Call.Panel.System.Pos, Call.Panel.System.FireGroups.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Ship(string M, bool T, bool L = true)
            { return Evaluate(M, "System Panel (Ship Tab)", T, Call.Panel.System.Pos, Call.Panel.System.Ship.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Inventory(string M, bool T, bool L = true)
            { return Evaluate(M, "System Panel (Inventory Tab)", T, Call.Panel.System.Pos, Call.Panel.System.Inventory.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Status(string M, bool T, bool L = true)
            { return Evaluate(M, "System Panel (Status Tab)", T, Call.Panel.System.Pos, Call.Panel.System.Status.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Media(string M, bool T, bool L = true)
            { return Evaluate(M, "System Panel (Media Tab)", T, Call.Panel.System.Pos, Call.Panel.System.Media.Tab, L); }
        }

        public class PanelRole : Debug
        {
            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
            /// <param name="T">(Target) The Expected State</param>
            /// <param name="L">(Logger) Enables / Disables Logging</param>
            /// <returns></returns>
            public bool Open(string M, bool T, bool L = true)
            { return Evaluate(M, "Role Panel (Open)", T, Call.Panel.Role.Open, L); }

            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target State?</param>
            /// <param name="C">(Check) The State You're Checking</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Position(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, "Role Panel (Position)", T, C, Call.Panel.Role.Pos, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool All(string M, bool T, bool L = true)
            { return Evaluate(M, "Role Panel (All Tab)", T, Call.Panel.Role.Pos, Call.Panel.Role.All.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Helm(string M, bool T, bool L = true)
            { return Evaluate(M, "Role Panel (Helm Tab)", T, Call.Panel.Role.Pos, Call.Panel.Role.Helm.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Fighters(string M, bool T, bool L = true)
            { return Evaluate(M, "Role Panel (Fighters Tab)", T, Call.Panel.Role.Pos, Call.Panel.Role.Fighters.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool SRV(string M, bool T, bool L = true)
            { return Evaluate(M, "Role Panel (SRV Tab)", T, Call.Panel.Role.Pos, Call.Panel.Role.SRV.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Crew(string M, bool T, bool L = true)
            { return Evaluate(M, "Role Panel (Crew Tab)", T, Call.Panel.Role.Pos, Call.Panel.Role.Crew.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Help(string M, bool T, bool L = true)
            { return Evaluate(M, "Role Panel (Help Tab)", T, Call.Panel.Role.Pos, Call.Panel.Role.Help.Tab, L); }
        }

        public class PanelComms : Debug
        {
            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
            /// <param name="T">(Target) The Expected State</param>
            /// <param name="L">(Logger) Enables / Disables Logging</param>
            /// <returns></returns>
            public bool Open(string M, bool T, bool L = true)
            { return Evaluate(M, "Comms Panel (Open)", T, Call.Panel.Comms.Open, L); }

            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target State?</param>
            /// <param name="C">(Check) The State You're Checking</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Position(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, "Comms Panel (Position)", T, C, Call.Panel.Comms.Pos, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Chat(string M, bool T, bool L = true)
            { return Evaluate(M, "Comms Panel (Chat Tab)", T, Call.Panel.Comms.Pos, Call.Panel.Comms.Chat.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Inbox(string M, bool T, bool L = true)
            { return Evaluate(M, "Comms Panel (Inbox Tab)", T, Call.Panel.Comms.Pos, Call.Panel.Comms.Inbox.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Social(string M, bool T, bool L = true)
            { return Evaluate(M, "Comms Panel (Social Tab)", T, Call.Panel.Comms.Pos, Call.Panel.Comms.Social.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool History(string M, bool T, bool L = true)
            { return Evaluate(M, "Comms Panel (History Tab)", T, Call.Panel.Comms.Pos, Call.Panel.Comms.History.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Squadron(string M, bool T, bool L = true)
            { return Evaluate(M, "Comms Panel (Squadron Tab)", T, Call.Panel.Comms.Pos, Call.Panel.Comms.Squadron.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Settings(string M, bool T, bool L = true)
            { return Evaluate(M, "Comms Panel (Settings Tab)", T, Call.Panel.Comms.Pos, Call.Panel.Comms.Settings.Tab, L); }
        }

        public class PanelTarget : Debug
        {
            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
            /// <param name="T">(Target) The Expected State</param>
            /// <param name="L">(Logger) Enables / Disables Logging</param>
            /// <returns></returns>
            public bool Open(string M, bool T, bool L = true)
            { return Evaluate(M, "Target Panel (Open)", T, Call.Panel.Target.Open, L); }

            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target State?</param>
            /// <param name="C">(Check) The State You're Checking</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Position(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, "Target Panel (Position)", T, C, Call.Panel.Target.Pos, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Navigation(string M, bool T, bool L = true)
            { return Evaluate(M, "Target Panel (Navigation Tab)", T, Call.Panel.Target.Pos, Call.Panel.Target.Navigation.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Transactions(string M, bool T, bool L = true)
            { return Evaluate(M, "Target Panel (Transactions Tab)", T, Call.Panel.Target.Pos, Call.Panel.Target.Transactions.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Contacts(string M, bool T, bool L = true)
            { return Evaluate(M, "Target Panel (Contacts Tab)", T, Call.Panel.Target.Pos, Call.Panel.Target.Contacts.Tab, L); }
        }

        public class MapGalaxy : Debug
        {
            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
            /// <param name="T">(Target) The Expected State</param>
            /// <param name="L">(Logger) Enables / Disables Logging</param>
            /// <returns></returns>
            public bool Open(string M, bool T, bool L = true)
            { return Evaluate(M, "Galaxy Map (Open)", T, Call.Panel.GalaxyMap.Open, L); }

            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target State?</param>
            /// <param name="C">(Check) The State You're Checking</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Position(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, "Galaxy Map (Position)", T, C, Call.Panel.GalaxyMap.Pos, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Info(string M, bool T, bool L = true)
            { return Evaluate(M, "Galaxy Map (Info Tab)", T, Call.Panel.GalaxyMap.Pos, Call.Panel.GalaxyMap.Info.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Search(string M, bool T, bool L = true)
            { return Evaluate(M, "Galaxy Map (Search Tab)", T, Call.Panel.GalaxyMap.Pos, Call.Panel.GalaxyMap.Search.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Bookmarks(string M, bool T, bool L = true)
            { return Evaluate(M, "Galaxy Map (Bookmarks Tab)", T, Call.Panel.GalaxyMap.Pos, Call.Panel.GalaxyMap.Bookmarks.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Config(string M, bool T, bool L = true)
            { return Evaluate(M, "Galaxy Map (Config Tab)", T, Call.Panel.GalaxyMap.Pos, Call.Panel.GalaxyMap.Config.Tab, L); }

            /// <summary> </summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target Tab?</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Options(string M, bool T, bool L = true)
            { return Evaluate(M, "Galaxy Map (Options Tab)", T, Call.Panel.GalaxyMap.Pos, Call.Panel.GalaxyMap.Options.Tab, L); }
        }

        public class MapSystem : Debug
        {
            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
            /// <param name="T">(Target) The Expected State</param>
            /// <param name="L">(Logger) Enables / Disables Logging</param>
            /// <returns></returns>
            public bool Open(string M, bool T, bool L = true)
            { return Evaluate(M, "System Map (Open)", T, Call.Panel.SystemMap.Open, L); }

            /// <summary></summary>
            /// <param name="M">(Method) The Simple Name For The Calling Method</param>
            /// <param name="T">(Target) Is The Target State?</param>
            /// <param name="C">(Check) The State You're Checking</param>
            /// <param name="L">(Logging) Enable / Disbale Logging</param>
            /// <returns></returns>
            public bool Position(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, "System Map (Position)", T, C, Call.Panel.SystemMap.Pos, L); }         
        }
    }
}
#endregion