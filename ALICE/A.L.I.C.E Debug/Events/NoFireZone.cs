#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static NoFireZone NoFireZone { get; set; } = new NoFireZone();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Events;

    public class NoFireZone : Debug
    {
        private static ALICE_Events.NoFireZone E { get => IEvents.NoFireZone.I; }

        public bool Status(string M, bool T, bool L = true)
        { return Evaluate(M, "Status", T, E.Status, L); }

        public bool Station(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Station", T, C, E.Station, L); }

        public bool Message(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Message", T, C, E.Message, L); }
    }
}
#endregion