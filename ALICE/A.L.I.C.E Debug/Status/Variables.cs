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
    using ALICE_Actions;
    using ALICE_Debug;
    using ALICE_Internal;
    using ALICE_Status;

    public class Variables : Debug
    {
        private string ClassName = "(Status) ";

        /// <summary>
        /// Checks and evalutes altitude based on entered limits.
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method.</param>
        /// <param name="LA">(Low Altitude) The Low Altitude Limit.</param>
        /// <param name="HA">(High Altitude) The High Altitude Limit.</param>
        /// <param name="I">(Inside) True Checks You're Inside The Altitude Limits. False Checks You're Outside The Altitude Limits.</param>
        /// <param name="L">(Logger) Enables / Disables Logging.</param>
        /// <returns></returns>
        public bool Altitude(string M, decimal LA, decimal HA, bool I, bool L = true)
        {
            //Set Prefix For Check Value
            string S = "Inside "; if (I == false) { S = "Outside "; }
            string N = ClassName + "Altitude";
            decimal Altitude = IStatus.Altitude;

            //Check Inside Band
            if (I == true && (LA <= Altitude && Altitude <= HA))
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + S + LA + " - " + HA + ")", Logger.Yellow); }
                return false;
            }

            //Check Outside Band
            if (I == false && (LA > Altitude && Altitude > HA))
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + S + LA + " - " + HA + ")", Logger.Yellow); }
                return false;
            }

            //Passed
            if (L) { Logger.DebugLine(M, "[Pass]: " + N + " Equals Expected State (" + S + LA + " - " + HA + ")", Logger.Blue); }
            return true;
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AnalysisMode(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Analysis Mode", T, IStatus.AnalysisMode, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CargoScoop(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Cargo Scoop", T, IStatus.CargoScoop, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Crew(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "NPC Crew", T, IStatus.NPC_Crew, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool ExternalLights(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "External Lights", T, IStatus.ExternalLights, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FlightAssist(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Flight Assist", T, IStatus.FlightAssist, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FireGroup(string M, decimal C, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Fire Group", true, C, IActions.Hardpoints.Current, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FighterDeployed(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Fighter Deployed", T, IStatus.Fighter.Deployed, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FuelScooping(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Fuel Scooping", T, IStatus.FuelScooping, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Hardpoints(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Hardpoints", T, IStatus.Hardpoints, L); }


        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool LandingGear(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Landing Gear", T, IStatus.LandingGear, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Overheating(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Overheating", T, IStatus.Overheating, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Shields(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Shields", T, IStatus.Shields.Status, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool SilentRunning(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Silent Running", T, IStatus.SilentRunning, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Touchdown(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Touchdown", T, IStatus.Touchdown, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool WeaponSafety(string M, bool T, bool L = true)
        { return Evaluate(M, ClassName + "Weapon Safety", T, IStatus.WeaponSafety, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="C">(Check) The State You're Checking</param>
        /// <param name="T">(Target) The Expected State</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Vehicle(string M, IStatus.V C, bool T, bool L = true)
        {
            //Set Prefix For Check Value
            string S = ""; if (T == false) { S = "Not "; }
            string N = ClassName + "Vehicle";
            IStatus.V P = IStatus.Vehicle;

            //Check
            if (T == true && C != P)
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + S + C + ")", Logger.Yellow); }
                return false;
            }

            //Check
            if (T == false && C == P)
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + S + C + ")", Logger.Yellow); }
                return false;
            }

            //Passed
            if (L) { Logger.DebugLine(M, "[Pass]: " + N + " Equals Expected State (" + S + C + ")", Logger.Blue); }
            return true;
        }
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
    using ALICE_Debug;
    using ALICE_Status;

    public class Variables : Debug
    {
        private string ClassName = "(Status) ";

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool AnalysisMode(string M, bool L = true)
        { return Get(M, ClassName + "Analysis Mode", IStatus.AnalysisMode, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CargoScoop(string M, bool L = true)
        { return Get(M, ClassName + "Cargo Scoop", IStatus.CargoScoop, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool ExternalLights(string M, bool L = true)
        { return Get(M, ClassName + "External Lights", IStatus.ExternalLights, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool FlightAssist(string M, bool L = true)
        { return Get(M, ClassName + "Flight Assist", IStatus.FlightAssist, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Hardpoints(string M, bool L = true)
        { return Get(M, ClassName + "Hardpoints", IStatus.Hardpoints, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool LandingGear(string M, bool L = true)
        { return Get(M, ClassName + "Landing Gear", IStatus.LandingGear, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NightVision(string M, bool L = true)
        { return Get(M, ClassName + "Night Vision", IStatus.NightVision, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Overheating(string M, bool L = true)
        { return Get(M, ClassName + "Overheating", IStatus.Overheating, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool SilentRunning(string M, bool L = true)
        { return Get(M, ClassName + "Silent Running", IStatus.SilentRunning, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool Shields(string M, bool L = true)
        { return Get(M, ClassName + "Shields", IStatus.Shields.Status, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool WeaponSafety(string M, bool L = true)
        { return Get(M, ClassName + "Weapon Safety", IStatus.WeaponSafety, L); }
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
    using ALICE_Status;

    public class Variables : Debug
    {
        private string ClassName = "(Status) ";

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="V">(Value) New Property Value</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void WeaponSafety(string M, bool V, bool L = true)
        { Set(M, ClassName + "Weapon Safety", ref IStatus.WeaponSafety, V, L); }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="V">(Value) New Property Value</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void LandingGear(string M, bool V, bool L = true)
        { Set(M, ClassName + "Landing Gear", ref IStatus.LandingGear, V, L); }
    }
}
#endregion