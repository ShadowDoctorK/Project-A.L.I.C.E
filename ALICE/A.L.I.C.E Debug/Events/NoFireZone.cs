using ALICE_Debug;
using ALICE_Events;

namespace ALICE_DebugItems
{
    public class NoFireZone : Debug
    {
        private static ALICE_Events.NoFireZone E { get => IEvents.NoFireZone.I; }

        public bool Status(string M, bool T, bool L)
        { return Evaluate(M, "Status", T, E.Status, L); }

        public bool Station(string M, bool T, string C, bool L)
        { return Evaluate(M, "Station", T, C, E.Station, L); }

        public bool Message(string M, bool T, string C, bool L)
        { return Evaluate(M, "Message", T, C, E.Message, L); }
    }
}