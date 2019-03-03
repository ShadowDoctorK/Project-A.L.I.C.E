using ALICE_DebugCheck;
using ALICE_Internal;

namespace ALICE_Debug
{
    /// <summary>
    /// Static Collection Of The Debug Wraped Items Used For Internal Debugging & Logic Checks
    /// </summary>
    public static class ICheck
    {
        private static Platform _Platform = new Platform();
        public static Platform Platform
        {
            get => _Platform; set => _Platform = value;
        }

        private static Environment _Environment = new Environment();
        public static Environment Environment
        {
            get => _Environment; set => _Environment = value;
        }

        private static Orders _Orders = new Orders();
        public static Orders Order
        {
            get => _Orders; set => _Orders = value;
        }

        private static Reports _Reports = new Reports();
        public static Reports Report
        {
            get => _Reports; set => _Reports = value;
        }

        #region Status
        private static Docking _Docking = new Docking();
        public static Docking Docking
        {
            get => _Docking; set => _Docking = value;
        }
        #endregion

        #region Events
        private static Assault _Assault = new Assault();
        public static Assault Assault
        {
            get => _Assault; set => _Assault = value;
        }

        private static BlockAirlock _BlockAirlock = new BlockAirlock();
        public static BlockAirlock BlockAirlock
        {
            get => _BlockAirlock; set => _BlockAirlock = value;
        }

        private static BlockLandingPad _BlockLandingPad = new BlockLandingPad();
        public static BlockLandingPad BlockLandingPad
        {
            get => _BlockLandingPad; set => _BlockLandingPad = value;
        }

        private static Docked _Docked = new Docked();
        public static Docked Docked
        {
            get => _Docked; set => _Docked = value;
        }

        private static FireInNoFireZone _FireInNoFireZone = new FireInNoFireZone();
        public static FireInNoFireZone FireInNoFireZone
        {
            get => _FireInNoFireZone; set => _FireInNoFireZone = value;
        }

        private static Masslock _Masslock = new Masslock();
        public static Masslock Masslock
        {
            get => _Masslock; set => _Masslock = value;
        }

        private static Music _Music = new Music();
        public static Music Music
        {
            get => _Music; set => _Music = value;
        }

        private static NoFireZone _NoFireZone = new NoFireZone();
        public static NoFireZone NoFireZone
        {
            get => _NoFireZone; set => _NoFireZone = value;
        }

        private static ShipyardArrived _ShipyardArrived = new ShipyardArrived();
        public static ShipyardArrived ShipyardArrived
        {
            get => _ShipyardArrived; set => _ShipyardArrived = value;
        }

        private static SupercruiseEntry _SupercruiseEntry = new SupercruiseEntry();
        public static SupercruiseEntry SupercruiseEntry
        {
            get => _SupercruiseEntry; set => _SupercruiseEntry = value;
        }

        private static SupercruiseExit _SupercruiseExit = new SupercruiseExit();
        public static SupercruiseExit SupercruiseExit
        {
            get => _SupercruiseExit; set => _SupercruiseExit = value;
        }

        #endregion

        #region Equipment
        private static FrameShiftDrive _FrameShiftDrive = new FrameShiftDrive();
        public static FrameShiftDrive FrameShiftDrive
        {
            get => _FrameShiftDrive; set => _FrameShiftDrive = value;
        }

        private static LandingGear _LandingGear = new LandingGear();
        public static LandingGear LandingGear
        {
            get => _LandingGear; set => _LandingGear = value;
        }

        private static Shields _Shields = new Shields();
        public static Shields Shields
        {
            get => _Shields; set => _Shields = value;
        }
        #endregion

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