using ALICE_Debug;
using ALICE_Equipment;

namespace ALICE_DebugCheck
{
    public class LandingGear : Debug
    {
        private static ALICE_Equipment.LandingGear E { get => IEquipment.LandingGear; }

        public bool Status(string M, bool T, bool L = true)
        { return Evaluate(M, "Landing Gear (Status)", T, E.Status, L); }

        public bool Enabled(string M, bool T, bool L = true)
        { return Evaluate(M, "Landing Gear (Enabled)", T, E.Settings.Enabled, L); }
    }
}

namespace ALICE_DebugGet
{
    public class LandingGear : Debug
    {
        private static ALICE_Equipment.LandingGear E { get => IEquipment.LandingGear; }

        public bool Status(string M, bool L = true)
        { return Get(M, "Landing Gear (Status)", E.Status, L); }

        public bool Enabled(string M, bool L = true)
        { return Get(M, "Landing Gear (Enabled)", E.Settings.Enabled, L); }
    }
}

namespace ALICE_DebugSet
{
    public class LandingGear : Debug
    {
        private static ALICE_Equipment.LandingGear E
        {
            get => IEquipment.LandingGear;
            set => IEquipment.LandingGear = value;
        }

        public void Status(string M, bool V, bool L = true)
        { Set(M, "Landing Gear (Status)", ref E.Status, V, L); }
    }
}