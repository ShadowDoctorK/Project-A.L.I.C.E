#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static CompositeScanner CompositeScanner { get; set; } = new CompositeScanner();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class CompositeScanner : Debug
    {
        private static ALICE_Equipment.CompositeScanner E
        {
            get => IEquipment.CompositeScanner;
        }

        private readonly string Item = "Composite Scanner ";

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
        public static CompositeScanner CompositeScanner { get; set; } = new CompositeScanner();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class CompositeScanner : Debug
    {
        private static ALICE_Equipment.CompositeScanner E
        {
            get => IEquipment.CompositeScanner;
        }

        private readonly string Item = "Composite Scanner ";

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
        public static CompositeScanner CompositeScanner { get; set; } = new CompositeScanner();
    }
}

namespace ALICE_DebugSet
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class CompositeScanner : Debug
    {
        private static ALICE_Equipment.CompositeScanner E
        {
            get => IEquipment.CompositeScanner;
            set => IEquipment.CompositeScanner = value;
        }

        private readonly string Item = "Composite Scanner ";

        public void Installed(string M, bool V, bool L = true)
        { Set(M, Item + "(Installed)", ref E.Settings.Installed, V, L); }

        public void Enabled(string M, bool V, bool L = true)
        { Set(M, Item + "(Enabled)", ref E.Settings.Enabled, V, L); }
    }
}
#endregion
