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

        private readonly string Item = "Landing Gear ";

        public bool Installed(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Installed)", T, E.Settings.Installed, L); }

        public bool Enabled(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Enabled)", T, E.Settings.Enabled, L); }

        public bool Status(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Status)", T, E.Status, L); }
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

        private readonly string Item = "Landing Gear ";

        public bool Installed(string M, bool L = true)
        { return Get(M, Item + "(Installed)", E.Settings.Installed, L); }

        public bool Enabled(string M, bool L = true)
        { return Get(M, Item + "(Enabled)", E.Settings.Enabled, L); }

        public bool Status(string M, bool L = true)
        { return Get(M, Item + "(Status)", E.Status, L); }
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

        private readonly string Item = "Landing Gear ";

        public void Installed(string M, bool V, bool L = true)
        { Set(M, Item + "(Installed)", ref E.Settings.Installed, V, L); }

        public void Enabled(string M, bool V, bool L = true)
        { Set(M, Item + "(Enabled)", ref E.Settings.Enabled, V, L); }

        public void Status(string M, bool V, bool L = true)
        { Set(M, Item + "(Status)", ref E.Status, V, L); }
    }
}
#endregion