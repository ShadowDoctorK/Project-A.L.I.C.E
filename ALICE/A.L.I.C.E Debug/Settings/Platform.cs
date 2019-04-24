#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Platform Platform { get; set; } = new Platform();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Interface;

    public class Platform : Debug
    {
        /// <summary>
        /// Will Check If The Starting Platform Contains The Target Command.
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="C">(Command) The Target Command Name</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CommandExist(string M, string C, bool L, bool T = true)
        {
            return Evaluate(M, "Command Exist", T, IPlatform.CommandExists(C), L);
        }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static Platform Platform { get; set; } = new Platform();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;

    public class Platform : Debug
    {
        //None
    }
}
#endregion