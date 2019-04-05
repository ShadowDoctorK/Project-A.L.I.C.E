#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Masslock Masslock { get; set; } = new Masslock();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Events;

    public class Masslock : Debug
    {
        public bool Status(string M, bool T, bool L = true)
        { return Evaluate(M, "Masslock (Status)", T, IEvents.Masslock.I.Status, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static Masslock Masslock { get; set; } = new Masslock();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Events;

    public class Masslock : Debug
    {
        public bool Status(string M, bool L = true)
        { return Get(M, "Masslock (Status)", IEvents.Masslock.I.Status, L); }
    }
}
#endregion