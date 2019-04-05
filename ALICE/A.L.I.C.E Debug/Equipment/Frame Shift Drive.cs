#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static FrameShiftDrive FrameShiftDrive { get; set; } = new FrameShiftDrive();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class FrameShiftDrive : Debug
    {
        private static ALICE_Equipment.FrameShiftDrive E
        {
            get => IEquipment.FrameShiftDrive;
        }

        public bool Charging(string M, bool T, bool L = true)
        { return Evaluate(M, "Frame Shift Drive (Charging)", T, E.Charging, L); }

        public bool Cooldown(string M, bool T, bool L = true)
        { return Evaluate(M, "Frame Shift Drive (Cooldown)", T, E.Cooldown, L); }

        //public bool Prepairing(string M, bool T, bool L = true)
        //{ return Evaluate(M, "Frame Shift Drive (Prepairing)", T, E.Prepairing, L); }

        public bool PrepHyperspace(string M, bool T, bool L = true)
        { return Evaluate(M, "Frame Shift Drive (Prep Hyperspace)", T, E.PrepHyperspace, L); }

        public bool PrepSupercruise(string M, bool T, bool L = true)
        { return Evaluate(M, "Frame Shift Drive (Prep Supercruise)", T, E.PrepSupercruise, L); }

        public bool Disengaging(string M, bool T, bool L = true)
        { return Evaluate(M, "Frame Shift Drive (Disengaging)", T, E.Disengaging, L); }

        public bool Hyperspace(string M, bool T, bool L = true)
        { return Evaluate(M, "Frame Shift Drive (Hyperspace)", T, E.Hyperspace, L); }

        public bool Supercruise(string M, bool T, bool L = true)
        { return Evaluate(M, "Frame Shift Drive (Supercruise)", T, E.Supercruise, L); }

        public bool Enabled(string M, bool T, bool L = true)
        { return Evaluate(M, "Frame Shift Drive (Enabled)", T, E.Settings.Enabled, L); }

        public bool Marking(string M, bool T, bool L = true)
        { return Evaluate(M, "Frame Shift Drive (Marking)", T, E.Marking, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static FrameShiftDrive FrameShiftDrive { get; set; } = new FrameShiftDrive();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class FrameShiftDrive : Debug
    {
        private static ALICE_Equipment.FrameShiftDrive E
        {
            get => IEquipment.FrameShiftDrive;
        }

        public bool Charging(string M, bool L = true)
        { return Get(M, "Frame Shift Drive (Charging)", E.Charging, L); }

        public bool Cooldown(string M, bool L = true)
        { return Get(M, "Frame Shift Drive (Cooldown)", E.Cooldown, L); }

        //public bool Prepairing(string M, bool L = true)
        //{ return Get(M, "Frame Shift Drive (Prepairing)", E.Prepairing, L); }

        public bool PrepHyperspace(string M, bool L = true)
        { return Get(M, "Frame Shift Drive (Prep Hyperspace)", E.PrepHyperspace, L); }

        public bool PrepSupercruise(string M, bool L = true)
        { return Get(M, "Frame Shift Drive (Prep Supercruise)", E.PrepSupercruise, L); }

        public bool Disengaging(string M, bool L = true)
        { return Get(M, "Frame Shift Drive (Disengaging)", E.Disengaging, L); }

        public bool Hyperspace(string M, bool L = true)
        { return Get(M, "Frame Shift Drive (Hyperspace)", E.Hyperspace, L); }

        public bool Supercruise(string M, bool L = true)
        { return Get(M, "Frame Shift Drive (Supercruise)", E.Supercruise, L); }

        public bool Enabled(string M, bool L = true)
        { return Get(M, "Frame Shift Drive (Enabled)", E.Settings.Enabled, L); }
    }
}
#endregion

#region ISet
namespace ALICE_Debug
{
    using ALICE_DebugSet;

    public static partial class ISet
    {
        public static FrameShiftDrive FrameShiftDrive { get; set; } = new FrameShiftDrive();
    }
}

namespace ALICE_DebugSet
{
    using ALICE_Debug;
    using ALICE_Equipment;

    public class FrameShiftDrive : Debug
    {
        private static ALICE_Equipment.FrameShiftDrive E
        {
            get => IEquipment.FrameShiftDrive;
            set => IEquipment.FrameShiftDrive = value;
        }

        public void Charging(string M, bool V, bool L = true)
        { Set(M, "Frame Shift Drive (Charging)", ref E.Charging, V, L); }

        public void Cooldown(string M, bool V, bool L = true)
        { Set(M, "Frame Shift Drive (Cooldown)", ref E.Cooldown, V, L); }

        //public void Prepairing(string M, bool V, bool L = true)
        //{ Set(M, "Frame Shift Drive (Prepairing)", ref E.Prepairing, V, L); }

        public void PrepHyperspace(string M, bool V, bool L = true)
        { Set(M, "Frame Shift Drive (Prep Hyperspace)", ref E.PrepHyperspace, V, L); }

        public void PrepSupercruise(string M, bool V, bool L = true)
        { Set(M, "Frame Shift Drive (Prep Supercruise)", ref E.PrepSupercruise, V, L); }

        public void Disengaging(string M, bool V, bool L = true)
        { Set(M, "Frame Shift Drive (Disengaging)", ref E.Disengaging, V, L); }

        public void Hyperspace(string M, bool V, bool L = true)
        { Set(M, "Frame Shift Drive (Hyperspace)", ref E.Hyperspace, V, L); }

        public void Supercruise(string M, bool V, bool L = true)
        { Set(M, "Frame Shift Drive (Supercruise)", ref E.Supercruise, V, L); }

        public void Marking(string M, bool V, bool L = true)
        { Set(M, "Frame Shift Drive (Marking)", ref E.Marking, V, L); }
    }
}
#endregion
