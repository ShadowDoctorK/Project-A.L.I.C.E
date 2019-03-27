using ALICE_DebugCheck;
using ALICE_Internal;

namespace ALICE_Debug
{
    /// <summary>
    /// Static Collection Of The Debug Wraped Items Used For Internal Debugging & Logic Checks
    /// </summary>
    public static class ICheck
    {
        //Settings
        public static Platform Platform { get; set; } = new Platform();
        public static Environment Environment { get; set; } = new Environment();
        public static Orders Order { get; set; } = new Orders();
        public static Reports Report { get; set; } = new Reports();

        //Status
        public static Docking Docking { get; set; } = new Docking();

        //Events
        public static Assault Assault { get; set; } = new Assault();
        public static BlockAirlock BlockAirlock { get; set; } = new BlockAirlock();
        public static BlockLandingPad BlockLandingPad { get; set; } = new BlockLandingPad();
        public static Docked Docked { get; set; } = new Docked();
        public static FireInNoFireZone FireInNoFireZone { get; set; } = new FireInNoFireZone();
        public static Masslock Masslock { get; set; } = new Masslock();
        public static Music Music { get; set; } = new Music();
        public static NoFireZone NoFireZone { get; set; } = new NoFireZone();
        public static ShipyardArrived ShipyardArrived { get; set; } = new ShipyardArrived();
        public static SupercruiseEntry SupercruiseEntry { get; set; } = new SupercruiseEntry();
        public static SupercruiseExit SupercruiseExit { get; set; } = new SupercruiseExit();


        //Equipment
        public static FrameShiftDrive FrameShiftDrive { get; set; } = new FrameShiftDrive();
        public static LandingGear LandingGear { get; set; } = new LandingGear();
        public static Shields Shields { get; set; } = new Shields();


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