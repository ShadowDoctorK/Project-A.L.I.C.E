#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static DiscoveryScanner DiscoveryScanner { get; set; } = new DiscoveryScanner();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class DiscoveryScanner : Debug
    {
        private static ALICE_Equipment.DiscoveryScanner E
        {
            get => IEquipment.DiscoveryScanner;
        }

        private readonly string Item = "Discovery Scanner ";

        public bool Installed(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Installed)", T, E.Settings.Installed, L); }

        public bool Enabled(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Enabled)", T, E.Settings.Enabled, L); }

        public bool Active(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Active)", T, E.Active, L); }

        public bool FirstScan(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(First Scan)", T, E.FirstScan, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static DiscoveryScanner DiscoveryScanner { get; set; } = new DiscoveryScanner();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class DiscoveryScanner : Debug
    {
        private static ALICE_Equipment.DiscoveryScanner E
        {
            get => IEquipment.DiscoveryScanner;
        }

        private readonly string Item = "Discovery Scanner ";

        public bool Installed(string M, bool L = true)
        { return Get(M, Item + "(Installed)", E.Settings.Installed, L); }

        public bool Enabled(string M, bool L = true)
        { return Get(M, Item + "(Enabled)", E.Settings.Enabled, L); }

        public bool Active(string M, bool L = true)
        { return Get(M, Item + "(Active)", E.Active, L); }

        public bool FirstScan(string M, bool L = true)
        { return Get(M, Item + "(First Scan)", E.FirstScan, L); }
    }
}
#endregion

#region ISet
namespace ALICE_Debug
{
    using ALICE_DebugSet;

    public static partial class ISet
    {
        public static DiscoveryScanner DiscoveryScanner { get; set; } = new DiscoveryScanner();
    }
}

namespace ALICE_DebugSet
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class DiscoveryScanner : Debug
    {
        private static ALICE_Equipment.DiscoveryScanner E
        {
            get => IEquipment.DiscoveryScanner;
            set => IEquipment.DiscoveryScanner = value;
        }

        private readonly string Item = "Discovery Scanner ";

        public void Installed(string M, bool V, bool L = true)
        { Set(M, Item + "(Installed)", ref E.Settings.Installed, V, L); }

        public void Enabled(string M, bool V, bool L = true)
        { Set(M, Item + "(Enabled)", ref E.Settings.Enabled, V, L); }

        public void Active(string M, bool V, bool L = true)
        { Set(M, Item + "(Active)", ref E.Active, V, L); }

        public void FirstScan(string M, bool V, bool L = true)
        { Set(M, Item + "(First Scan)", ref E.FirstScan, V, L); }
    }
}
#endregion
