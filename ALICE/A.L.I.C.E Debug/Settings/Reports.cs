#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Reports Report { get; set; } = new Reports();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Settings;

    public class Reports : Debug
    {
        private readonly string Item = "Reports ";

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FuelStatus(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Fuel Status Report)", T, ISettings.FuelStatus, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FuelScoop(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Fuel Scoop Report)", T, ISettings.FuelScoop, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool ShieldState(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Shield State Report)", T, ISettings.ShieldState, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CollectedBounty(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Collected Bounty Report)", T, ISettings.CollectedBounty, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Masslock(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Masslock Report)", T, ISettings.Masslock, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool StationStatus(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Station Status Report)", T, ISettings.StationStatus, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool MaterialCollected(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Material Collected Report)", T, ISettings.MaterialCollected, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool MaterialRefined(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Material Refined Report)", T, ISettings.MaterialRefined, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool TargetWanted(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Wanted Target Report)", T, ISettings.TargetWanted, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool TargetEnemy(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Hostile Faction Report)", T, ISettings.TargetEnemy, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static Reports Report { get; set; } = new Reports();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Settings;

    public class Reports : Debug
    {
        private readonly string Item = "Reports ";

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FuelStatus(string M, bool L = true)
        { return Get(M, Item + "(Fuel Status Report)", ISettings.FuelStatus, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FuelScoop(string M, bool L = true)
        { return Get(M, Item + "(Fuel Scoop Report)", ISettings.FuelScoop, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool ShieldState(string M, bool L = true)
        { return Get(M, Item + "(Shield State Report)", ISettings.ShieldState, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CollectedBounty(string M, bool L = true)
        { return Get(M, Item + "(Collected Bounty Report)", ISettings.CollectedBounty, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Masslock(string M, bool L = true)
        { return Get(M, Item + "(Masslock Report)", ISettings.Masslock, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NoFireZone(string M, bool L = true)
        { return Get(M, Item + "(No Fire Zone Report)", ISettings.NoFireZone, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool StationStatus(string M, bool L = true)
        { return Get(M, Item + "(Station Status Report)", ISettings.StationStatus, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool MaterialCollected(string M, bool L = true)
        { return Get(M, Item + "(Material Collected Report)", ISettings.MaterialCollected, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool MaterialRefined(string M, bool L = true)
        { return Get(M, Item + "(Material Refined Report)", ISettings.MaterialRefined, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool TargetWanted(string M, bool L = true)
        { return Get(M, Item + "(Wanted Target Report)", ISettings.TargetWanted, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool TargetEnemy(string M, bool L = true)
        { return Get(M, Item + "(Hostile Faction Report)", ISettings.TargetEnemy, L); }
    }
}
#endregion