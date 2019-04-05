#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static SupercruiseEntry SupercruiseEntry { get; set; } = new SupercruiseEntry();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Events;

    public class SupercruiseEntry : Debug
    {
        private static ALICE_Events.SupercruiseEntry E { get => IEvents.SupercruiseEntry.I; }

        public bool StarSystem(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "StarSystem", T, C, E.StarSystem, L); }

        public bool SystemAddress(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, "SystemAddress", T, C, E.SystemAddress, L); }
    }
}
#endregion