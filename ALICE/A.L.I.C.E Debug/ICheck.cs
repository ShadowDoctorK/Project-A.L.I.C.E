using ALICE_DebugItems;
using ALICE_Internal;

namespace ALICE_Debug
{
    /// <summary>
    /// Static Collection Of The Debug Wraped Items Used For Internal Debugging & Logic Checks
    /// </summary>
    public static class ICheck
    {
        #region Events
        public static Assault Assault = new Assault();
        public static BlockAirlock BlockAirlock = new BlockAirlock();
        public static BlockLandingPad BlockLandingPad = new BlockLandingPad();
        public static Docked Docked = new Docked();
        public static FireInNoFireZone FireInNoFireZone = new FireInNoFireZone();
        public static Music Music = new Music();
        public static NoFireZone NoFireZone = new NoFireZone();
        public static ShipyardArrived ShipyardArrived = new ShipyardArrived();
        public static SupercruiseEntry SupercruiseEntry = new SupercruiseEntry();
        public static SupercruiseExit SupercruiseExit = new SupercruiseExit();
        #endregion

        #region Equipment
        public static LandingGear LandingGear = new LandingGear();
        #endregion

        /// <summary>
        /// Simple Function To Check Plugin Is Initialized
        /// </summary>
        /// <param name="M">(Method) Simple Name Of The Calling Method</param>
        /// <returns>true or false</returns>
        public static bool Initialized(string M)
        {
            //Check Plugin Initialized
            if (Check.Internal.TriggerEvents(true, M) == false)
            {
                //Debug Logger
                Logger.DebugLine(M, "Plugin Not Initialized", Logger.Yellow);
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Base Debug Wrapper Class
    /// </summary>
    public class Debug
    {
        /// <summary>
        /// Checks a boolean property wrapping the Debug Logger into the check.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) The Simple Variable Name</param>
        /// <param name="T">(Target) Expected State</param>
        /// <param name="P">(Property) Property Being Checked</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        /// <returns></returns>
        public bool Evaluate(string M, string N, bool C, bool P, bool L = true)
        {
            //Check
            if (C != P)
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + C + ")", Logger.Yellow); }
                return false;
            }

            //Passed
            if (L) { Logger.DebugLine(M, "[Pass]: " + N + " Equals Expected State (" + C + ")", Logger.Blue); }
            return true;
        }

        /// <summary>
        /// Checks a string property wrapping the Debug Logger into the check.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) The Simple Variable Name</param>
        /// <param name="C">(Check) The State Your Evaluating</param>
        /// <param name="T">(Target) Is Expected State</param>
        /// <param name="P">(Property) Property Being Checked</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        /// <returns></returns>
        public bool Evaluate(string M, string N, bool T, string C, string P, bool L = true)
        {
            //Set Prefix For Check Value
            string S = ""; if (T == false) { S = "Not "; }

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
        /// Checks a decimal property wrapping the Debug Logger into the check.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) The Simple Variable Name</param>
        /// <param name="C">(Check) The State Your Evaluating</param>
        /// <param name="T">(Target) Is Expected State</param>
        /// <param name="P">(Property) Property Being Checked</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        /// <returns></returns>
        public bool Evaluate(string M, string N, bool T, decimal C, decimal P, bool L = true)
        {
            //Set Prefix For Check Value
            string S = ""; if (T == false) { S = "Not "; }

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
        /// Get the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <returns>The Property Value</returns>
        public string Get(string M, string N, string P, bool L = true)
        {
            if (L) { Logger.DebugLine(M, "[Value]: " + N + " Equals - " + P, Logger.Blue); }
            return P;
        }

        /// <summary>
        /// Get the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <returns>The Property Value</returns>
        public decimal Get(string M, string N, decimal P, bool L = true)
        {
            if (L) { Logger.DebugLine(M, "[Value]: " + N + " Equals - " + P, Logger.Blue); }
            return P;
        }

        /// <summary>
        /// Get the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <returns>The Property Value</returns>
        public bool Get(string M, string N, bool P, bool L = true)
        {
            if (L) { Logger.DebugLine(M, "[Value]: " + N + " Equals - " + P, Logger.Blue); }
            return P;
        }
    }
}