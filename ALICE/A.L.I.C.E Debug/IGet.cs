using ALICE_DebugGet;

namespace ALICE_Debug
{
    /// <summary>
    /// Static Collection Of The Debug Wraped Items Used For Internal Debugging
    /// </summary>
    public static class IGet
    {
        public static Platform Platform { get; set; } = new Platform();
        public static Environment Environment { get; set; } = new Environment();

        //Status
        public static Docking Docking { get; set; } = new Docking();

        //Events
        public static Docked Docked { get; set; } = new Docked();
        public static FireInNoFireZone FireInNoFireZone { get; set; } = new FireInNoFireZone();
        public static Masslock Masslock { get; set; } = new Masslock();
        public static Music Music { get; set; } = new Music();
        public static ShipyardArrived ShipyardArrived { get; set; } = new ShipyardArrived();
        public static SupercruiseExit SupercruiseExit { get; set; } = new SupercruiseExit();

        //Equipment
        public static FrameShiftDrive FrameShiftDrive { get; set; } = new FrameShiftDrive();
        public static LandingGear LandingGear { get; set; } = new LandingGear();
        public static Shields Shields { get; set; } = new Shields();
    }
}