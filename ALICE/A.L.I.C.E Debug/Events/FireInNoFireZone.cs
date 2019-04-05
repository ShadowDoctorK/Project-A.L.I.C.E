#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static FireInNoFireZone FireInNoFireZone { get; set; } = new FireInNoFireZone();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Events;

    public class FireInNoFireZone : Debug
    {
        private static ALICE_Events.FireInNoFireZone E { get => IEvents.FireInNoFireZone.I; }

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

        public bool FirstReport(string M, bool C, bool L = true)
        { return Evaluate(M, "FirstReport", C, E.FirstReport, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static FireInNoFireZone FireInNoFireZone { get; set; } = new FireInNoFireZone();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Events;

    public class FireInNoFireZone : Debug
    {
        private static ALICE_Events.FireInNoFireZone E { get => IEvents.FireInNoFireZone.I; }

        public string Charge(string M, bool L = true)
        { return Get(M, "Charge", E.Charge, L); }

        public decimal Amount(string M, bool L = true)
        { return Get(M, "Amount", E.Amount, L); }
    }
}
#endregion