#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static DockingComputer DockingComputer { get; set; } = new DockingComputer();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class DockingComputer : Debug
    {
        private static ALICE_Equipment.DockingComputer E
        {
            get => IEquipment.DockingComputer;
        }

        private readonly string Item = "Docking Computer ";

        public bool Installed(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Installed)", T, E.Settings.Installed, L); }

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
        public static DockingComputer DockingComputer { get; set; } = new DockingComputer();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class DockingComputer : Debug
    {
        private static ALICE_Equipment.DockingComputer E
        {
            get => IEquipment.DockingComputer;
        }

        private readonly string Item = "Docking Computer ";

        public bool Installed(string M, bool L = true)
        { return Get(M, Item + "(Installed)", E.Settings.Installed, L); }

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
        public static DockingComputer DockingComputer { get; set; } = new DockingComputer();
    }
}

namespace ALICE_DebugSet
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class DockingComputer : Debug
    {
        private static ALICE_Equipment.DockingComputer E
        {
            get => IEquipment.DockingComputer;
            set => IEquipment.DockingComputer = value;
        }

        private readonly string Item = "Docking Computer ";

        public void Installed(string M, bool V, bool L = true)
        { Set(M, Item + "(Installed)", ref E.Settings.Installed, V, L); }

        public void Enabled(string M, bool V, bool L = true)
        { Set(M, Item + "(Enabled)", ref E.Settings.Enabled, V, L); }
    }
}
#endregion
