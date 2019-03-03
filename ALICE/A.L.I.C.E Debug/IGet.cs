using ALICE_DebugGet;

namespace ALICE_Debug
{
    /// <summary>
    /// Static Collection Of The Debug Wraped Items Used For Internal Debugging
    /// </summary>
    public static class IGet
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

        #region Status
        private static Docking _Docking = new Docking();
        public static Docking Docking
        {
            get => _Docking; set => _Docking = value;
        }
        #endregion

        #region Events
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

        private static ShipyardArrived _ShipyardArrived = new ShipyardArrived();
        public static ShipyardArrived ShipyardArrived
        {
            get => _ShipyardArrived; set => _ShipyardArrived = value;
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
    }
}