#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static SupercruiseExit SupercruiseExit { get; set; } = new SupercruiseExit();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Events;

    public class SupercruiseExit : Debug
    {
        private static ALICE_Events.SupercruiseExit E { get => IEvents.SupercruiseExit.I; }

        public bool StarSystem(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "StarSystem", T, C, E.StarSystem, L); }

        public bool SystemAddress(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, "SystemAddress", T, C, E.SystemAddress, L); }

        public bool Body(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Body", T, C, E.Body, L); }

        public bool BodyType(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "BodyType", T, C, E.BodyType, L); }

        public bool BodyID(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, "BodyID", T, C, E.BodyID, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static SupercruiseExit SupercruiseExit { get; set; } = new SupercruiseExit();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Events;

    public class SupercruiseExit : Debug
    {
        private static ALICE_Events.SupercruiseExit E { get => IEvents.SupercruiseExit.I; }

        public string Body(string M, bool L = true)
        { return Get(M, "Body", E.Body, L); }
    }
}
#endregion