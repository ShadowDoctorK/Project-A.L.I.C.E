using ALICE_Debug;
using ALICE_Events;

namespace ALICE_DebugItems
{
    public class SupercruiseEntry : Debug
    {
        private static ALICE_Events.SupercruiseEntry E { get => IEvents.SupercruiseEntry.I; }

        public bool StarSystem(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "StarSystem", T, C, E.StarSystem, L); }

        public bool SystemAddress(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, "SystemAddress", T, C, E.SystemAddress, L); }
    }
}