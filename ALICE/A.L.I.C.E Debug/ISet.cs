using ALICE_DebugSet;

namespace ALICE_Debug
{
    /// <summary>
    /// Static Collection Of The Debug Wraped Items Used For Internal Debugging
    /// </summary>
    public static class ISet
    {
        //Status
        public static Docking Docking { get; set; } = new Docking();

        //Equipment
        public static FrameShiftDrive FrameShiftDrive { get; set; } = new FrameShiftDrive();
        public static LandingGear LandingGear { get; set; } = new LandingGear();
    }
}