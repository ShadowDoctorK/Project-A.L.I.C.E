using ALICE_Internal;

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
            if (PlugIn.M_Journal.Settings.Initialized == false)
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
            if (PlugIn.M_Json.Settings.Initialized == false)
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
            if (PlugIn.M_Json.Status.InitialLoad == true)
            {
                //Debug Logger
                if (L) { Logger.DebugLine(M, "Status.Json Not Initialized", Logger.Yellow); }
                return false;
            }

            return true;
        }
    }
}