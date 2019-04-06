#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Variables Status { get; set; } = new Variables();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Core;
    using ALICE_Debug;

    public class Variables : Debug
    {
        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AnalysisMode(string M, bool T, bool L = true)
        { return Evaluate(M, "Analysis Mode", T, IStatus.AnalysisMode, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CargoScoop(string M, bool T, bool L = true)
        { return Evaluate(M, "Cargo Scoop", T, IStatus.CargoScoop, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Crew(string M, bool T, bool L = true)
        { return Evaluate(M, "NPC Crew", T, IStatus.NPC_Crew, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FlightAssist(string M, bool T, bool L = true)
        { return Evaluate(M, "Flight Assist", T, IStatus.FlightAssist, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FighterDeployed(string M, bool T, bool L = true)
        { return Evaluate(M, "Fighter Deployed", T, IStatus.Fighter.Deployed, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FuelScooping(string M, bool T, bool L = true)
        { return Evaluate(M, "Fuel Scooping", T, IStatus.FuelScooping, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Hardpoints(string M, bool T, bool L = true)
        { return Evaluate(M, "Hardpoints", T, IStatus.Hardpoints, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Overheating(string M, bool T, bool L = true)
        { return Evaluate(M, "Overheating", T, IStatus.Overheating, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool SilentRunning(string M, bool T, bool L = true)
        { return Evaluate(M, "Silent Running", T, IStatus.SilentRunning, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Touchdown(string M, bool T, bool L = true)
        { return Evaluate(M, "Touchdown", T, IStatus.Touchdown, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static Variables Status { get; set; } = new Variables();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Core;
    using ALICE_Debug;

    public class Variables : Debug
    {
        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CargoScoop(string M, bool L = true)
        { return Get(M, "Cargo Scoop", IStatus.CargoScoop, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FlightAssist(string M, bool L = true)
        { return Get(M, "Flight Assist", IStatus.FlightAssist, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Hardpoints(string M, bool L = true)
        { return Get(M, "Hardpoints", IStatus.Hardpoints, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Overheating(string M, bool L = true)
        { return Get(M, "Overheating", IStatus.Overheating, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool SilentRunning(string M, bool L = true)
        { return Get(M, "Silent Running", IStatus.SilentRunning, L); }
    }
}
#endregion

#region ISet
namespace ALICE_Debug
{
    using ALICE_DebugSet;

    public static partial class ISet
    {
        public static Variables Status { get; set; } = new Variables();
    }
}

namespace ALICE_DebugSet
{
    using ALICE_Debug;

    public class Variables : Debug
    {
        //Empty
    }
}
#endregion