#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Shields Shields { get; set; } = new Shields();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class Shields : Debug
    {
        private static ALICE_Equipment.Shields E { get => IEquipment.Shields; }

        private readonly string Item = "Shields ";

        public bool Installed(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Installed)", T, E.Settings.Installed, L); }

        public bool Status(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Status)", T, E.Status, L); }

        public bool Enabled(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Enabled)", T, E.Settings.Enabled, L); }

    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static Shields Shields { get; set; } = new Shields();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class Shields : Debug
    {
        private static ALICE_Equipment.Shields E { get => IEquipment.Shields; }

        private readonly string Item = "Shields ";

        public bool Installed(string M, bool L = true)
        { return Get(M, Item + "(Installed)", E.Settings.Installed, L); }

        public bool Status(string M, bool L = true)
        { return Get(M, Item + "(Status)", E.Status, L); }

        public bool Enabled(string M, bool L = true)
        { return Get(M, Item + "(Enabled)", E.Settings.Enabled, L); }
    }
}
#endregion

#region ISet
namespace ALICE_Debug
{
    using ALICE_DebugSet;

    public static partial class ISet
    {
        public static Shields Shields { get; set; } = new Shields();
    }
}

namespace ALICE_DebugSet
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class Shields : Debug
    {
        private static ALICE_Equipment.Shields E
        {
            get => IEquipment.Shields;
            set => IEquipment.Shields = value;
        }

        private readonly string Item = "Shields ";

        public void Installed(string M, bool V, bool L = true)
        { Set(M, Item + "(Installed)", ref E.Settings.Installed, V, L); }

        public void Enabled(string M, bool V, bool L = true)
        { Set(M, Item + "(Enabled)", ref E.Settings.Enabled, V, L); }
    }
}
#endregion