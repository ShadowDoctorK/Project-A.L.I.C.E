using ALICE_Internal;
using ALICE_Monitors;

namespace ALICE_Debug
{
    /// <summary>
    /// Static Collection Of The Debug Wraped Items Used For Internal Debugging & Logic Checks
    /// </summary>
    public static partial class ICheck
    {
        /// <summary>
        /// Simple Function To Check Plugin Is Initialized
        /// </summary>
        /// <param name="M">(Method) Simple Name Of The Calling Method</param>
        /// <returns>true or false</returns>
        public static bool Initialized(string M, bool L = true)
        {
            //Check Plugin Initialized
            if (IMonitors.Journal.Settings.Initialized == false)
            {
                //Debug Logger
                if (L) { Logger.DebugLine(M, "Plugin Not Initialized", Logger.Yellow); }
                return false;
            }

            return true;
        }

        /// <summary>
        /// Simple Function To Check Json Monitor Is Initialized
        /// </summary>
        /// <param name="M">(Method) Simple Name Of The Calling Method</param>
        /// <returns>true or false</returns>
        public static bool InitializedJson(string M, bool L = true)
        {
            //Check Plugin Initialized
            if (IMonitors.Json.Settings.Initialized == false)
            {
                //Debug Logger
                if (L) { Logger.DebugLine(M, "Json Monitor Not Initialized", Logger.Yellow); }
                return false;
            }

            return true;
        }

        /// <summary>
        /// Simple Function To Check Plugin Is Initialized
        /// </summary>
        /// <param name="M">(Method) Simple Name Of The Calling Method</param>
        /// <returns>true or false</returns>
        public static bool InitializedStatus(string M, bool L = true)
        {
            //Check Plugin Initialized
            if (IMonitors.Json.Status.InitialLoad == true)
            {
                //Debug Logger
                if (L) { Logger.DebugLine(M, "Status.Json Not Initialized", Logger.Yellow); }
                return false;
            }

            return true;
        }

        /// <summary>
        /// Simple Function To Check Settigns Monitor Is Initialized
        /// </summary>
        /// <param name="M">(Method) Simple Name Of The Calling Method</param>
        /// <returns>true or false</returns>
        public static bool InitializedSettings(string M, bool L = true)
        {
            //Check Plugin Initialized
            if (IMonitors.Settings.Settings.Initialized == true)
            {
                //Debug Logger
                if (L) { Logger.DebugLine(M, "Settings Monitor Not Initialized", Logger.Yellow); }
                return false;
            }

            return true;
        }
    }
}