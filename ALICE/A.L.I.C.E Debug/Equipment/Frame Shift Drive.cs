using ALICE_Debug;
using ALICE_Equipment;

namespace ALICE_DebugItems
{
    public class FrameShiftDrive : Debug
    {
        private static ALICE_Equipment.FrameShiftDrive E { get => IEquipment.FrameShiftDrive; }

        public bool Charging(string M, bool T, bool L)
        { return Evaluate(M, "Frame Shift Drive (Charging)", T, E.Charging, L); }

        public bool Charging(string M, bool L)
        { return Get(M, "Frame Shift Drive (Charging)", E.Charging, L); }

        public bool Cooldown(string M, bool T, bool L)
        { return Evaluate(M, "Frame Shift Drive (Cooldown)", T, E.Cooldown, L); }

        public bool Cooldown(string M, bool L)
        { return Get(M, "Frame Shift Drive (Cooldown)", E.Cooldown, L); }

        public bool Prepairing(string M, bool T, bool L)
        { return Evaluate(M, "Frame Shift Drive (Prepairing)", T, E.Prepairing, L); }

        public bool Prepairing(string M, bool L)
        { return Get(M, "Frame Shift Drive (Prepairing)", E.Prepairing, L); }

        public bool PrepHyperspace(string M, bool T, bool L)
        { return Evaluate(M, "Frame Shift Drive (Prep Hyperspace)", T, E.PrepHyperspace, L); }

        public bool PrepHyperspace(string M, bool L)
        { return Get(M, "Frame Shift Drive (Prep Hyperspace)", E.PrepHyperspace, L); }

        public bool PrepSupercruise(string M, bool T, bool L)
        { return Evaluate(M, "Frame Shift Drive (Prep Supercruise)", T, E.PrepSupercruise, L); }

        public bool PrepSupercruise(string M, bool L)
        { return Get(M, "Frame Shift Drive (Prep Supercruise)", E.PrepSupercruise, L); }

        public bool Disengaging(string M, bool T, bool L)
        { return Evaluate(M, "Frame Shift Drive (Disengaging)", T, E.Disengaging, L); }

        public bool Disengaging(string M, bool L)
        { return Get(M, "Frame Shift Drive (Disengaging)", E.Disengaging, L); }

        public bool Hyperspace(string M, bool T, bool L)
        { return Evaluate(M, "Frame Shift Drive (Hyperspace)", T, E.Hyperspace, L); }

        public bool Hyperspace(string M, bool L)
        { return Get(M, "Frame Shift Drive (Hyperspace)", E.Hyperspace, L); }

        public bool Supercruise(string M, bool T, bool L)
        { return Evaluate(M, "Frame Shift Drive (Supercruise)", T, E.Supercruise, L); }

        public bool Supercruise(string M, bool L)
        { return Get(M, "Frame Shift Drive (Supercruise)", E.Supercruise, L); }

        public bool Enabled(string M, bool T, bool L)
        { return Evaluate(M, "Frame Shift Drive (Enabled)", T, E.Settings.Enabled, L); }

        public bool Enabled(string M, bool L)
        { return Get(M, "Frame Shift Drive (Enabled)", E.Settings.Enabled, L); }
    }
}