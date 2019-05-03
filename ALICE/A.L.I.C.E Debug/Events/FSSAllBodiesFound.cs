#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static FSSAllBodiesFound FSSAllBodiesFound { get; set; } = new FSSAllBodiesFound();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Events;

    public class FSSAllBodiesFound : Debug
    {
        private static ALICE_Events.FSSAllBodiesFound E { get => IEvents.FSSAllBodiesFound.I; }

        public bool SystemName(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "System Name", T, C, E.SystemName, L); }

        public bool SystemAddress(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, "System Address", T, C, E.SystemAddress, L); }

        public bool Count(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, "Count", T, C, E.Count, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static FSSAllBodiesFound FSSAllBodiesFound { get; set; } = new FSSAllBodiesFound();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Events;

    public class FSSAllBodiesFound : Debug
    {
        private static ALICE_Events.FSSAllBodiesFound E { get => IEvents.FSSAllBodiesFound.I; }

        public string SystemName(string M, bool L = true)
        { return Get(M, "System Name", E.SystemName, L); }

        public decimal SystemAddress(string M, bool L = true)
        { return Get(M, "System Address", E.SystemAddress, L); }

        public decimal Count(string M, bool L = true)
        { return Get(M, "Count", E.Count, L); }
    }
}
#endregion