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
    using ALICE_Status;

    public class FrameShiftDrive : Debug
    {
        private readonly string Item = "Frame Shift Drive ";

        public bool Charging(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Charging)", T, IStatus.FrameShiftDrive.Charging, L); }

        public bool Cooldown(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Cooldown)", T,IStatus.FrameShiftDrive.Cooldown, L); }

        public bool PrepHyperspace(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Prep Hyperspace)", T,IStatus.FrameShiftDrive.PrepHyperspace, L); }

        public bool PrepSupercruise(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Prep Supercruise)", T,IStatus.FrameShiftDrive.PrepSupercruise, L); }

        public bool Disengaging(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Disengaging)", T,IStatus.FrameShiftDrive.Disengaging, L); }

        public bool Hyperspace(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Hyperspace)", T,IStatus.FrameShiftDrive.Hyperspace, L); }

        public bool Supercruise(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Supercruise)", T,IStatus.FrameShiftDrive.Supercruise, L); }

        public bool Marking(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Marking)", T,IStatus.FrameShiftDrive.Marking, L); }
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
    using ALICE_Status;

    public class FrameShiftDrive : Debug
    {
        private readonly string Item = "Frame Shift Drive ";

        public bool Charging(string M, bool L = true)
        { return Get(M, Item + "(Charging)",IStatus.FrameShiftDrive.Charging, L); }

        public bool Cooldown(string M, bool L = true)
        { return Get(M, Item + "(Cooldown)",IStatus.FrameShiftDrive.Cooldown, L); }

        public bool PrepHyperspace(string M, bool L = true)
        { return Get(M, Item + "(Prep Hyperspace)",IStatus.FrameShiftDrive.PrepHyperspace, L); }

        public bool PrepSupercruise(string M, bool L = true)
        { return Get(M, Item + "(Prep Supercruise)",IStatus.FrameShiftDrive.PrepSupercruise, L); }

        public bool Disengaging(string M, bool L = true)
        { return Get(M, Item + "(Disengaging)",IStatus.FrameShiftDrive.Disengaging, L); }

        public bool Hyperspace(string M, bool L = true)
        { return Get(M, Item + "(Hyperspace)",IStatus.FrameShiftDrive.Hyperspace, L); }

        public bool Supercruise(string M, bool L = true)
        { return Get(M, Item + "(Supercruise)",IStatus.FrameShiftDrive.Supercruise, L); }
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
    using ALICE_Status;

    public class FrameShiftDrive : Debug
    {
        private readonly string Item = "Frame Shift Drive ";

        public void Charging(string M, bool V, bool L = true)
        { Set(M, Item + "(Charging)", ref IStatus.FrameShiftDrive.Charging, V, L); }

        public void Cooldown(string M, bool V, bool L = true)
        { Set(M, Item + "(Cooldown)", ref IStatus.FrameShiftDrive.Cooldown, V, L); }

        public void PrepHyperspace(string M, bool V, bool L = true)
        { Set(M, Item + "(Prep Hyperspace)", ref IStatus.FrameShiftDrive.PrepHyperspace, V, L); }

        public void PrepSupercruise(string M, bool V, bool L = true)
        { Set(M, Item + "(Prep Supercruise)", ref IStatus.FrameShiftDrive.PrepSupercruise, V, L); }

        public void Disengaging(string M, bool V, bool L = true)
        { Set(M, Item + "(Disengaging)", ref IStatus.FrameShiftDrive.Disengaging, V, L); }

        public void Hyperspace(string M, bool V, bool L = true)
        { Set(M, Item + "(Hyperspace)", ref IStatus.FrameShiftDrive.Hyperspace, V, L); }

        public void Supercruise(string M, bool V, bool L = true)
        { Set(M, Item + "(Supercruise)", ref IStatus.FrameShiftDrive.Supercruise, V, L); }

        public void Marking(string M, bool V, bool L = true)
        { Set(M, Item + "(Marking)", ref IStatus.FrameShiftDrive.Marking, V, L); }
    }
}
#endregion
