using ALICE_Debug;
using ALICE_Equipment;

namespace ALICE_DebugItems
{
    public class Shields : Debug
    {
        private static ALICE_Equipment.Shields E { get => IEquipment.Shields; }

        public bool Installed(string M, bool T, bool L)
        { return Evaluate(M, "Shields (Installed)", T, E.Settings.Installed, L); }

        public bool Installed(string M, bool L)
        { return Get(M, "Shields (Installed)", E.Settings.Installed, L); }

        public bool Status(string M, bool T, bool L)
        { return Evaluate(M, "Shields (Status)", T, E.Status, L); }

        public bool Status(string M, bool L)
        { return Get(M, "Shields (Status)", E.Status, L); }

        public bool Enabled(string M, bool T, bool L)
        { return Evaluate(M, "Shields (Enabled)", T, E.Settings.Enabled, L); }

        public bool Enabled(string M, bool L)
        { return Get(M, "Shields (Enabled)", E.Settings.Enabled, L); }
    }
}