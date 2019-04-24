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

        private readonly string Item = "Frame Shift Drive ";

        public bool Installed(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Installed)", T, E.Settings.Installed, L); }

        public bool Enabled(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Enabled)", T, E.Settings.Enabled, L); }

        public bool Charging(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Charging)", T, E.Charging, L); }

        public bool Cooldown(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Cooldown)", T, E.Cooldown, L); }

        public bool PrepHyperspace(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Prep Hyperspace)", T, E.PrepHyperspace, L); }

        public bool PrepSupercruise(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Prep Supercruise)", T, E.PrepSupercruise, L); }

        public bool Disengaging(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Disengaging)", T, E.Disengaging, L); }

        public bool Hyperspace(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Hyperspace)", T, E.Hyperspace, L); }

        public bool Supercruise(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Supercruise)", T, E.Supercruise, L); }

        public bool Marking(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Marking)", T, E.Marking, L); }
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

        private readonly string Item = "Frame Shift Drive ";

        public bool Installed(string M, bool L = true)
        { return Get(M, Item + "(Installed)", E.Settings.Installed, L); }

        public bool Enabled(string M, bool L = true)
        { return Get(M, Item + "(Enabled)", E.Settings.Enabled, L); }

        public bool Charging(string M, bool L = true)
        { return Get(M, Item + "(Charging)", E.Charging, L); }

        public bool Cooldown(string M, bool L = true)
        { return Get(M, Item + "(Cooldown)", E.Cooldown, L); }

        public bool PrepHyperspace(string M, bool L = true)
        { return Get(M, Item + "(Prep Hyperspace)", E.PrepHyperspace, L); }

        public bool PrepSupercruise(string M, bool L = true)
        { return Get(M, Item + "(Prep Supercruise)", E.PrepSupercruise, L); }

        public bool Disengaging(string M, bool L = true)
        { return Get(M, Item + "(Disengaging)", E.Disengaging, L); }

        public bool Hyperspace(string M, bool L = true)
        { return Get(M, Item + "(Hyperspace)", E.Hyperspace, L); }

        public bool Supercruise(string M, bool L = true)
        { return Get(M, Item + "(Supercruise)", E.Supercruise, L); }
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

        private readonly string Item = "Frame Shift Drive ";

        public void Installed(string M, bool V, bool L = true)
        { Set(M, Item + "(Installed)", ref E.Settings.Installed, V, L); }

        public void Enabled(string M, bool V, bool L = true)
        { Set(M, Item + "(Enabled)", ref E.Settings.Enabled, V, L); }

        public void Charging(string M, bool V, bool L = true)
        { Set(M, Item + "(Charging)", ref E.Charging, V, L); }

        public void Cooldown(string M, bool V, bool L = true)
        { Set(M, Item + "(Cooldown)", ref E.Cooldown, V, L); }

        public void PrepHyperspace(string M, bool V, bool L = true)
        { Set(M, Item + "(Prep Hyperspace)", ref E.PrepHyperspace, V, L); }

        public void PrepSupercruise(string M, bool V, bool L = true)
        { Set(M, Item + "(Prep Supercruise)", ref E.PrepSupercruise, V, L); }

        public void Disengaging(string M, bool V, bool L = true)
        { Set(M, Item + "(Disengaging)", ref E.Disengaging, V, L); }

        public void Hyperspace(string M, bool V, bool L = true)
        { Set(M, Item + "(Hyperspace)", ref E.Hyperspace, V, L); }

        public void Supercruise(string M, bool V, bool L = true)
        { Set(M, Item + "(Supercruise)", ref E.Supercruise, V, L); }

        public void Marking(string M, bool V, bool L = true)
        { Set(M, Item + "(Marking)", ref E.Marking, V, L); }
    }
}
#endregion
