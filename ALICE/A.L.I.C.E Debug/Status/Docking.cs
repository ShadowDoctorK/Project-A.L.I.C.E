using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;

namespace ALICE_DebugItems
{
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
        public bool Status(string M, bool T, IEnums.DockingState C, bool L)
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
        public bool DeniedReason(string M, bool T, IEnums.DockingDenial C, bool L)
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