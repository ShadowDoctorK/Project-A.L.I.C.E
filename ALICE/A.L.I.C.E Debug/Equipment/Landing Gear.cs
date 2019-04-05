#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static LandingGear LandingGear { get; set; } = new LandingGear();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class LandingGear : Debug
    {
        private static ALICE_Equipment.LandingGear E { get => IEquipment.LandingGear; }

        public bool Status(string M, bool T, bool L = true)
        { return Evaluate(M, "Landing Gear (Status)", T, E.Status, L); }

        public bool Enabled(string M, bool T, bool L = true)
        { return Evaluate(M, "Landing Gear (Enabled)", T, E.Settings.Enabled, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static LandingGear LandingGear { get; set; } = new LandingGear();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class LandingGear : Debug
    {
        private static ALICE_Equipment.LandingGear E { get => IEquipment.LandingGear; }

        public bool Status(string M, bool L = true)
        { return Get(M, "Landing Gear (Status)", E.Status, L); }

        public bool Enabled(string M, bool L = true)
        { return Get(M, "Landing Gear (Enabled)", E.Settings.Enabled, L); }
    }
}
#endregion

#region ISet
namespace ALICE_Debug
{
    using ALICE_DebugSet;

    public static partial class ISet
    {
        public static LandingGear LandingGear { get; set; } = new LandingGear();
    }
}

namespace ALICE_DebugSet
{
    using ALICE_Debug;
    using ALICE_Equipment;

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
#endregion