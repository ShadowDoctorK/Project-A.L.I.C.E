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
        private readonly string Item = "Orders ";

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistDocking(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Assisted Docking Procedures)", T, ISettings.AssistDocking, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistSystemScan(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Assisted System Scans)", T, ISettings.AssistSystemScan, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistRefuel(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Assisted Station Refueling)", T, ISettings.AssistRefuel, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistRearm(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Assisted Station Rearming)", T, ISettings.AssistRearm, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistRepair(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Assisted Station Repairing)", T, ISettings.AssistRepair, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistHangerEntry(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Assisted Hanger Entry)", T, ISettings.AssistHangerEntry, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CombatPower(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Combat Power Management)", T, ISettings.CombatPower, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool PostJumpSafety(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Post Jump Safeties)", T, ISettings.PostHyperspaceSafety, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool WeaponSafety(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Weapon Safety Interlocks)", T, ISettings.WeaponSafety, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static Orders Order { get; set; } = new Orders();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Settings;

    public class Orders : Debug
    {
        private readonly string Item = "Orders ";

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistDocking(string M, bool L = true)
        { return Get(M, Item + "(Assisted Docking Procedures)", ISettings.AssistDocking, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistSystemScan(string M, bool L = true)
        { return Get(M, Item + "(Assisted System Scans)", ISettings.AssistSystemScan, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistRefuel(string M, bool L = true)
        { return Get(M, Item + "(Assisted Station Refueling)", ISettings.AssistRefuel, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistRearm(string M, bool L = true)
        { return Get(M, Item + "(Assisted Station Rearming)", ISettings.AssistRearm, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistRepair(string M, bool L = true)
        { return Get(M, Item + "(Assisted Station Repairing)", ISettings.AssistRepair, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AssistHangerEntry(string M, bool L = true)
        { return Get(M, Item + "(Assisted Hanger Entry)", ISettings.AssistHangerEntry, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CombatPower(string M, bool L = true)
        { return Get(M, Item + "(Combat Power Management)", ISettings.CombatPower, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool PostJumpSafety(string M, bool L = true)
        { return Get(M, Item + "(Post Jump Safeties)", ISettings.PostHyperspaceSafety, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool WeaponSafety(string M, bool L = true)
        { return Get(M, Item + "(Weapon Safety Interlocks)", ISettings.WeaponSafety, L); }
    }
}
#endregion