#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static External External { get; set; } = new External();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;

    public class External : Debug
    {
        //None
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static External External { get; set; } = new External();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Interface;
    using ALICE_Internal;
    using System;

    public class External : Debug
    {
        /// <summary>
        /// Will get the value for ALICE_DebugMode from the Starting Platform.
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool DebugMode(string M, bool L = true)
        {
            try
            {
                var Temp = Convert.ToBoolean(                                   //Convert String
                    Retreive(M, IPlatform.IVar.DebugMode, "false",              //Target Variable
                    "Not Set To A Valid Option (true - false) Or Could Not Be Converted. Using Fallback Value"));

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary>
        /// Will get the value for ALICE_ExtendedLogging from the Starting Platform.
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool ExtendedLogging(string M, bool L = true)
        {
            try
            {
                var Temp = Convert.ToBoolean(                                   //Convert String
                    Retreive(M, IPlatform.IVar.ExtendedLogging, "false",              //Target Variable
                    "Not Set To A Valid Option (true - false) Or Could Not Be Converted. Using Fallback Value"));

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary>
        /// Will get the value for ALICE_StatusLogging from the Starting Platform.
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool StatusLogging(string M, bool L = true)
        {
            try
            {
                var Temp = Convert.ToBoolean(                                   //Convert String
                    Retreive(M, IPlatform.IVar.StatusLogging, "false",          //Target Variable
                    "Not Set To A Valid Option (true - false) Or Could Not Be Converted. Using Fallback Value"));

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary>
        /// Will get the value for ALICE_VariableLogging from the Starting Platform.
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool VariableLogging(string M, bool L = true)
        {
            try
            {
                var Temp = Convert.ToBoolean(                                   //Convert String
                    Retreive(M, IPlatform.IVar.VariableLogging, "false",        //Target Variable
                    "Not Set To A Valid Option (true - false) Or Could Not Be Converted. Using Fallback Value"));

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool CommandAudio(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToBoolean(                                   //Convert String
                    Retreive(M, IPlatform.IVar.CommandAudio, "false",           //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));

                if (R) { ISet.External.CommandAudio(M, "false"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }            
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool ColdMod(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToBoolean(                                   //Convert String
                    Retreive(M, IPlatform.IVar.ColdMod, "false",           //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));

                if (R) { ISet.External.ColdMod(M, "false"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NavStars(string M, bool L = true)
        {
            try
            {
                return Convert.ToBoolean(                                       //Convert String
                    Retreive(M, IPlatform.IVar.NavStars, "false",               //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NavAsteroids(string M, bool L = true)
        {
            try
            {
                return Convert.ToBoolean(                                       //Convert String
                    Retreive(M, IPlatform.IVar.NavAsteroids, "false",           //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NavPlanets(string M, bool L = true)
        {
            try
            {
                return Convert.ToBoolean(                                       //Convert String
                    Retreive(M, IPlatform.IVar.NavPlanets, "false",             //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NavLandfalls(string M, bool L = true)
        {
            try
            {
                return Convert.ToBoolean(                                       //Convert String
                    Retreive(M, IPlatform.IVar.NavLandfalls, "false",           //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NavSettlements(string M, bool L = true)
        {
            try
            {
                return Convert.ToBoolean(                                       //Convert String
                    Retreive(M, IPlatform.IVar.NavSettlements, "false",         //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NavStations(string M, bool L = true)
        {
            try
            {
                return Convert.ToBoolean(                                       //Convert String
                    Retreive(M, IPlatform.IVar.NavStations, "false",            //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NavPoints(string M, bool L = true)
        {
            try
            {
                return Convert.ToBoolean(                                       //Convert String
                    Retreive(M, IPlatform.IVar.NavPoints, "false",              //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NavSignals(string M, bool L = true)
        {
            try
            {
                return Convert.ToBoolean(                                       //Convert String
                    Retreive(M, IPlatform.IVar.NavSignals, "false",             //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool NavSystems(string M, bool L = true)
        {
            try
            {
                return Convert.ToBoolean(                                       //Convert String
                    Retreive(M, IPlatform.IVar.NavSystems, "false",             //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public bool RecordPower(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToBoolean(                                   //Convert String
                    Retreive(M, IPlatform.IVar.RecordPower, "false",            //Target Variable
                    "Not Set To A Valid Option (true - false) Or Could Not Be Converted."));

                if (R) { ISet.External.RecordPower(M, "false"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return false;                                                   //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public decimal EnginePower(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToDecimal(                                   //Convert String
                    Retreive(M, IPlatform.IVar.EnginePower, "-1",               //Target Variable
                    "Was Not Set To A Valid Option. (0 - 8) Or Could Not Be Converted."));

                if (R) { ISet.External.EnginePower(M, "-1"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return -1;                                                      //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public decimal WeaponPower(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToDecimal(                                   //Convert String
                    Retreive(M, IPlatform.IVar.WeaponPower, "-1",               //Target Variable
                    "Was Not Set To A Valid Option. (0 - 8) Or Could Not Be Converted."));

                if (R) { ISet.External.WeaponPower(M, "-1"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return -1;                                                      //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public decimal SystemPower(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToDecimal(                                   //Convert String
                    Retreive(M, IPlatform.IVar.SystemPower, "-1",              //Target Variable
                    "Was Not Set To A Valid Option. (0 - 8) Or Could Not Be Converted."));

                if (R) { ISet.External.SystemPower(M, "-1"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return -1;                                                      //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public decimal FighterNumber(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToDecimal(                                   //Convert String
                    Retreive(M, IPlatform.IVar.FighterNumber, "-1",             //Target Variable
                    "Not Set To A Valid Option (1 - 2) Or Could Not Be Converted. Using Fallback Value"));

                if (R) { ISet.External.FighterNumber(M, "-1"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return -1;                                                      //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public string FireGroup(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Retreive(M, IPlatform.IVar.FireGroup, "",            //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value");

                if (R) { ISet.External.FireGroup(M, ""); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return "";                                                      //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public string FireMode(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Retreive(M, IPlatform.IVar.FireMode, "",            //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value");

                if (R) { ISet.External.FireMode(M, ""); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return "";                                                      //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public decimal FireGroupSelect(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToDecimal(                                   //Convert String
                    Retreive(M, IPlatform.IVar.FireGroupSelect, "-1",           //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));

                if (R) { ISet.External.FireGroupSelect(M, "-1"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return -1;                                                      //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public decimal FireGroupNum(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToDecimal(                                   //Convert String
                    Retreive(M, IPlatform.IVar.FireGroupNum, "-1",              //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));

                if (R) { ISet.External.FireGroupSelect(M, "-1"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return -1;                                                      //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public decimal BoostNum(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToDecimal(                                   //Convert String
                    Retreive(M, IPlatform.IVar.BoostNum, "-1",              //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));

                if (R) { ISet.External.FireGroupSelect(M, "-1"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return -1;                                                      //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public decimal BookmarkNum(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToDecimal(                                   //Convert String
                    Retreive(M, IPlatform.IVar.BookmarkNum, "-1",               //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));

                if (R) { ISet.External.FireGroupSelect(M, "-1"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return -1;                                                      //Default Exception Value
            }
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public decimal TargetCycle(string M, bool R, bool L = true)
        {
            try
            {
                var Temp = Convert.ToDecimal(                                   //Convert String
                    Retreive(M, IPlatform.IVar.TargetCycle, "-1",               //Target Variable
                    "Not Set To A Valid Option Or Could Not Be Converted. Using Fallback Value"));

                if (R) { ISet.External.FireGroupSelect(M, "-1"); }

                return Temp;
            }

            //Quiet Excpetion Handling
            catch (Exception ex)
            {
                Logger.DebugLine(M, "Exception: " + ex, Logger.Blue);           //Standard Debug Excption
                return -1;                                                      //Default Exception Value
            }
        }
    }
}
#endregion

#region ISet
namespace ALICE_Debug
{
    using ALICE_DebugSet;

    public static partial class ISet
    {
        public static External External { get; set; } = new External();
    }
}

namespace ALICE_DebugSet
{
    using ALICE_Debug;
    using ALICE_Interface;

    public class External : Debug
    {
        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void CommandAudio(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.CommandAudio, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void ColdMod(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.ColdMod, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void RecordPower(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.RecordPower, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void WeaponPower(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.WeaponPower, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void EnginePower(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.EnginePower, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void SystemPower(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.SystemPower, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void FighterNumber(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.FighterNumber, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void FireGroup(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.FireGroup, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void FireMode(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.FireMode, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void FireGroupSelect(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.FireGroupSelect, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void FireGroupNum(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.FireGroupNum, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void BoostNum(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.BoostNum, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void BookmarkNum(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.BookmarkNum, Val);
        }

        /// <summary></summary>
        /// <param name="M">(Method) The Simple Name Of The Calling Method</param>
        /// <param name="Val">(Value) The New Value Being Set</param>
        /// <param name="L">(Logger) Enables / Disables Logging</param>
        /// <returns></returns>
        public void TargetCycle(string M, string Val, bool L = true)
        {
            Pass(M, IPlatform.IVar.TargetCycle, Val);
        }
    }
}
#endregion;