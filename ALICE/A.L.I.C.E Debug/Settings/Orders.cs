#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Orders Order { get; set; } = new Orders();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Settings;

    public class Orders : Debug
    {
        public bool AssistDocking(string M, bool T, bool L = true)
        { return Evaluate(M, "Assisted Docking Procedures", T, ISettings.AssistDocking, L); }

        public bool AssistSystemScan(string M, bool T, bool L = true)
        { return Evaluate(M, "Assisted System Scans", T, ISettings.AssistSystemScan, L); }

        public bool AssistRefuel(string M, bool T, bool L = true)
        { return Evaluate(M, "Assisted Station Refueling", T, ISettings.AssistRefuel, L); }

        public bool AssistRearm(string M, bool T, bool L = true)
        { return Evaluate(M, "Assisted Station Rearming", T, ISettings.AssistRearm, L); }

        public bool AssistRepair(string M, bool T, bool L = true)
        { return Evaluate(M, "Assisted Station Repairing", T, ISettings.AssistRepair, L); }

        public bool AssistHangerEntry(string M, bool T, bool L = true)
        { return Evaluate(M, "Assisted Hanger Entry", T, ISettings.AssistHangerEntry, L); }

        public bool CombatPower(string M, bool T, bool L = true)
        { return Evaluate(M, "Combat Power Management", T, ISettings.CombatPower, L); }

        public bool PostJumpSafety(string M, bool T, bool L = true)
        { return Evaluate(M, "Post Jump Safeties", T, ISettings.PostHyperspaceSafety, L); }

        public bool WeaponSafety(string M, bool T, bool L = true)
        { return Evaluate(M, "Weapon Safety Interlocks", T, ISettings.WeaponSafety, L); }
    }
}
#endregion