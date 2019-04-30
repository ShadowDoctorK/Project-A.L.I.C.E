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
    using ALICE_Actions;

    public class DiscoveryScanner : Debug
    {
        private readonly string Item = "Discovery Scanner ";

        public bool Active(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Active)", T, IActions.DiscoveryScanner.Active, L); }

        public bool FirstScan(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(First Scan)", T, IActions.DiscoveryScanner.FirstScan, L); }
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
    using ALICE_Actions;
    using ALICE_Debug;

    public class DiscoveryScanner : Debug
    {
        private readonly string Item = "Discovery Scanner ";

        public bool Active(string M, bool L = true)
        { return Get(M, Item + "(Active)", IActions.DiscoveryScanner.Active, L); }

        public bool FirstScan(string M, bool L = true)
        { return Get(M, Item + "(First Scan)", IActions.DiscoveryScanner.FirstScan, L); }
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
    using ALICE_Actions;
    using ALICE_Debug;

    public class DiscoveryScanner : Debug
    {
        private readonly string Item = "Discovery Scanner ";

        public void Active(string M, bool V, bool L = true)
        { Set(M, Item + "(Active)", ref IActions.DiscoveryScanner.Active, V, L); }

        public void FirstScan(string M, bool V, bool L = true)
        { Set(M, Item + "(First Scan)", ref IActions.DiscoveryScanner.FirstScan, V, L); }
    }
}
#endregion
