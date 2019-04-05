#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Docked Docked { get; set; } = new Docked();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Events;

    public class Docked : Debug
    {
        private static ALICE_Events.Docked E { get => IEvents.Docked.I; }

        public bool Station(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "StationName", T, C, E.StationName, L); }

        public bool Type(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "StationType", T, C, E.StationType, L); }

        public bool System(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "StarSystem", T, C, E.StarSystem, L); }

        public bool Address(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, "SystemAddress", T, C, E.SystemAddress, L); }

        public bool Market(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, "MarketID", T, C, E.MarketID, L); }

        public bool Government(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "StationGovernment", T, C, E.StationGovernment_Localised, L); }

        public bool Allegiance(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "StationAllegiance", T, C, E.StationAllegiance, L); }

        public bool Economy(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "StationEconomy", T, C, E.StationEconomy_Localised, L); }

        public bool Faction(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "StationFaction", T, C, E.StationFaction.Name, L); }

        public bool State(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "FactionState", T, C, E.StationFaction.FactionState, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static Docked Docked { get; set; } = new Docked();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Events;

    public class Docked : Debug
    {
        private static ALICE_Events.Docked E { get => IEvents.Docked.I; }

        public string Station(string M, bool L = true)
        { return Get(M, "StationName", E.StationName, L); }

        public string Type(string M, bool L = true)
        { return Get(M, "StationType", E.StationType, L); }

        public string System(string M, bool L = true)
        { return Get(M, "System", E.StarSystem, L); }

        public string Government(string M, bool L = true)
        { return Get(M, "StationGovernment", E.StationGovernment_Localised, L); }

        public string Allegiance(string M, bool L = true)
        { return Get(M, "StationAllegiance", E.StationAllegiance, L); }

        public string Economy(string M, bool L = true)
        { return Get(M, "StationEconomy", E.StationEconomy_Localised, L); }

        public string Faction(string M, bool L = true)
        { return Get(M, "StationFaction", E.StationFaction.Name, L); }

        public string State(string M, bool L = true)
        { return Get(M, "FactionState", E.StationFaction.FactionState, L); }
    }
}
#endregion