using ALICE_DebugSet;

namespace ALICE_Debug
{
    /// <summary>
    /// Static Collection Of The Debug Wraped Items Used For Internal Debugging
    /// </summary>
    public static class ISet
    {
        private static Docking _Docking = new Docking();
        public static Docking Docking
        {
            get => _Docking; set => _Docking = value;
        }

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
    }
}