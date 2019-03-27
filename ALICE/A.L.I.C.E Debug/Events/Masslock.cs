using ALICE_Debug;
using ALICE_Events;

namespace ALICE_DebugCheck
{
    public class Masslock : Debug
    {
        public bool Status(string M, bool T, bool L = true)
        { return Evaluate(M, "Masslock (Status)", T, IEvents.Masslock.I.Status, L); }
    }
}

namespace ALICE_DebugGet
{
    public class Masslock : Debug
    {
        public bool Status(string M, bool L = true)
        { return Get(M, "Masslock (Status)", IEvents.Masslock.I.Status, L); }
    }
}