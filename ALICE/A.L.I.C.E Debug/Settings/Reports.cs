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
    using ALICE_Status;

    public class Reports : Debug
    {
        private readonly string Item = "Reports ";

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FuelStatus(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Fuel Status Report)", T, ISettings.User.FuelStatus(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FuelScoop(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Fuel Scoop Report)", T, ISettings.User.FuelScoop(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool ShieldState(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Shield State Report)", T, ISettings.User.ShieldState(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CollectedBounty(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Collected Bounty Report)", T, ISettings.User.CollectedBounty(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Masslock(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Masslock Report)", T, ISettings.User.Masslock(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool StationStatus(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Station Status Report)", T, ISettings.User.StationStatus(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool MaterialCollected(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Material Collected Report)", T, ISettings.User.MaterialCollected(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool MaterialRefined(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Material Refined Report)", T, ISettings.User.MaterialRefined(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool TargetWanted(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Wanted Target Report)", T, ISettings.User.TargetWanted(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool TargetEnemy(string M, bool T, bool L = true)
        { return Evaluate(M, Item + "(Hostile Faction Report)", T, ISettings.User.TargetEnemy(), L); }
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
    using ALICE_Status;

    public class Reports : Debug
    {
        private readonly string Item = "Reports ";

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FuelStatus(string M, bool L = true)
        { return Get(M, Item + "(Fuel Status Report)", ISettings.User.FuelStatus(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FuelScoop(string M, bool L = true)
        { return Get(M, Item + "(Fuel Scoop Report)", ISettings.User.FuelScoop(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool ShieldState(string M, bool L = true)
        { return Get(M, Item + "(Shield State Report)", ISettings.User.ShieldState(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CollectedBounty(string M, bool L = true)
        { return Get(M, Item + "(Collected Bounty Report)", ISettings.User.CollectedBounty(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Masslock(string M, bool L = true)
        { return Get(M, Item + "(Masslock Report)", ISettings.User.Masslock(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NoFireZone(string M, bool L = true)
        { return Get(M, Item + "(No Fire Zone Report)", ISettings.User.NoFireZone(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool StationStatus(string M, bool L = true)
        { return Get(M, Item + "(Station Status Report)", ISettings.User.StationStatus(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool MaterialCollected(string M, bool L = true)
        { return Get(M, Item + "(Material Collected Report)", ISettings.User.MaterialCollected(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool MaterialRefined(string M, bool L = true)
        { return Get(M, Item + "(Material Refined Report)", ISettings.User.MaterialRefined(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool TargetWanted(string M, bool L = true)
        { return Get(M, Item + "(Wanted Target Report)", ISettings.User.TargetWanted(), L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool TargetEnemy(string M, bool L = true)
        { return Get(M, Item + "(Hostile Faction Report)", ISettings.User.TargetEnemy(), L); }
    }
}
#endregion