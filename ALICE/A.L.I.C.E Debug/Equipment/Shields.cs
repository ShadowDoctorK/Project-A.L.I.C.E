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

        public bool Installed(string M, bool T, bool L = true)
        { return Evaluate(M, "Shields (Installed)", T, E.Settings.Installed, L); }

        public bool Status(string M, bool T, bool L = true)
        { return Evaluate(M, "Shields (Status)", T, E.Status, L); }

        public bool Enabled(string M, bool T, bool L = true)
        { return Evaluate(M, "Shields (Enabled)", T, E.Settings.Enabled, L); }

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

        public bool Installed(string M, bool L = true)
        { return Get(M, "Shields (Installed)", E.Settings.Installed, L); }

        public bool Status(string M, bool L = true)
        { return Get(M, "Shields (Status)", E.Status, L); }

        public bool Enabled(string M, bool L = true)
        { return Get(M, "Shields (Enabled)", E.Settings.Enabled, L); }
    }
}
#endregion