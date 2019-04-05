#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Assault Assault { get; set; } = new Assault();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Events;

    public class Assault : Debug
    {
        private static ALICE_Events.Assault E { get => IEvents.Assault.I; }

        public bool Violation(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Violation", T, C, E.Violation, L); }

        public bool Victim(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Victim", T, C, E.Victim, L); }

        public bool Faction(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Faction", T, C, E.Faction, L); }

        public bool Charge(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Charge", T, C, E.Charge, L); }

        public bool Amount(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, "Amount", T, C, E.Amount, L); }
    }
}
#endregion
