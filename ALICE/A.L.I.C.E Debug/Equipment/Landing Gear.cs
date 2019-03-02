using ALICE_Debug;
using ALICE_Equipment;

namespace ALICE_DebugItems
{
    public class LandingGear : Debug
    {
        private static ALICE_Equipment.LandingGear E { get => IEquipment.LandingGear; }

        public bool Status(string M, bool T, bool L)
        { return Evaluate(M, "Landing Gear (Status)", T, E.Status, L); }

        public bool Status(string M, bool L)
        { return Get(M, "Landing Gear (Status)", E.Status, L); }

        public bool Enabled(string M, bool T, bool L)
        { return Evaluate(M, "Landing Gear (Enabled)", T, E.Settings.Enabled, L); }

        public bool Enabled(string M, bool L)
        { return Get(M, "Landing Gear (Enabled)", E.Settings.Enabled, L); }
    }
}