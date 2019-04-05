#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static BlockLandingPad BlockLandingPad { get; set; } = new BlockLandingPad();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Events;

    public class BlockLandingPad : Debug
    {
        private static ALICE_Events.BlockLandingPad E { get => IEvents.BlockLandingPad.I; }

        public bool Station(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Station", T, C, E.Station, L); }

        public bool Faction(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Faction", T, C, E.Faction, L); }

        public bool Violation(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Violation", T, C, E.Violation, L); }

        public bool Amount(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, "Amount", T, C, E.Amount, L); }

        public bool Charge(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Charge", T, C, E.Charge, L); }
    }
}
#endregion