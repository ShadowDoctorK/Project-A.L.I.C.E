#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Docking Docking { get; set; } = new Docking();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Core;
    using ALICE_Debug;
    using ALICE_Internal;

    public class Docking : Debug
    {
        /// <summary>
        /// Check that evaulates the Checked State to a true or false statement.
        /// </summary>
        /// <param name="M">(Method) The Simple Name For The Calling Method</param>
        /// <param name="T">(Target) Is The Target State?</param>
        /// <param name="C">(Check) The State You're Checking</param>
        /// <param name="L">(Logging) Enable / Disbale Logging</param>
        /// <returns></returns>
        public bool Status(string M, bool T, IEnums.DockingState C, bool L = true)
        {
            //Set Prefix For Check Value
            string S = ""; if (T == false) { S = "Not "; }
            string N = "Docking State";
            IEnums.DockingState P = IStatus.Docking.State;

            //Check
            if (T == true && C != P)
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + S + C + ")", Logger.Yellow); }
                return false;
            }

            //Check
            if (T == false && C == P)
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + S + C + ")", Logger.Yellow); }
                return false;
            }

            //Passed
            if (L) { Logger.DebugLine(M, "[Pass]: " + N + " Equals Expected State (" + S + C + ")", Logger.Blue); }
            return true;
        }

        /// <summary>
        /// Check that evaulates the Checked State to a true or false statement.
        /// </summary>
        /// <param name="M">(Method) The Simple Name For The Calling Method</param>
        /// <param name="T">(Target) Is The Target State?</param>
        /// <param name="C">(Check) The State You're Checking</param>
        /// <param name="L">(Logging) Enable / Disbale Logging</param>
        /// <returns></returns>
        public bool Denied(string M, bool T, IEnums.DockingDenial C, bool L = true)
        {
            //Set Prefix For Check Value
            string S = ""; if (T == false) { S = "Not "; }
            string N = "Docking Denial";
            IEnums.DockingDenial P = IStatus.Docking.Denial;

            //Check
            if (T == true && C != P)
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + S + C + ")", Logger.Yellow); }
                return false;
            }

            //Check
            if (T == false && C == P)
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + S + C + ")", Logger.Yellow); }
                return false;
            }

            //Passed
            if (L) { Logger.DebugLine(M, "[Pass]: " + N + " Equals Expected State (" + S + C + ")", Logger.Blue); }
            return true;
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
        public static Docking Docking { get; set; } = new Docking();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Core;
    using ALICE_Debug;
    using ALICE_Internal;

    public class Docking : Debug
    {
        /// <summary>
        /// Gets the property value while wrapping in Debug Logging.
        /// </summary>
        /// <param name="M">(Method) The Simple Name For The Calling Method</param>
        /// <returns></returns>
        public IEnums.DockingState Status(string M)
        {
            //Debug Logger
            Logger.DebugLine(M, "[Get]: Docking (Status) = " + IStatus.Docking.State, Logger.Yellow);

            //Return Property
            return IStatus.Docking.State;
        }
    }
}
#endregion

#region ISet
namespace ALICE_Debug
{
    using ALICE_DebugSet;

    public static partial class ISet
    {
        public static Docking Docking { get; set; } = new Docking();
    }
}

namespace ALICE_DebugSet
{
    using ALICE_Core;
    using ALICE_Debug;
    using ALICE_Internal;

    public class Docking : Debug
    {
        /// <summary>
        /// Sets the property value while wrapping in Debug Logging.
        /// </summary>
        /// <param name="M">(Method) The Simple Name For The Calling Method</param>
        /// <param name="V">(Value) The New Value</param>
        public void Status(string M, IEnums.DockingState V)
        {
            //Only Process Changes
            if (IStatus.Docking.State == V) { return; }

            //Update Property
            IStatus.Docking.State = V;

            //Debug Logger
            Logger.DebugLine(M, "[Set]: Docking (Status) = " + V, Logger.Yellow);
        }
    }
}
#endregion