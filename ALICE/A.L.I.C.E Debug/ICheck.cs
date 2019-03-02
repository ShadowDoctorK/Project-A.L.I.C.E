using ALICE_Core;
using ALICE_DebugItems;
using ALICE_Interface;
using ALICE_Internal;
using System;

namespace ALICE_Debug
{
    /// <summary>
    /// Static Collection Of The Debug Wraped Items Used For Internal Debugging & Logic Checks
    /// </summary>
    public static class ICheck
    {
        private static Platform _Platform = new Platform();
        public static Platform Platform
        {
            get => _Platform; set => _Platform = value;
        }

        private static Orders _Orders = new Orders();
        public static Orders Order
        {
            get => _Orders; set => _Orders = value;
        }

        private static Reports _Reports = new Reports();
        public static Reports Report
        {
            get => _Reports; set => _Reports = value;
        }

        #region Status
        private static Docking _Docking = new Docking();
        public static Docking Docking
        {
            get => _Docking; set => _Docking = value;
        }
        #endregion

        #region Events
        private static Assault _Assault = new Assault();
        public static Assault Assault
        {
            get => _Assault; set => _Assault = value;
        }

        private static BlockAirlock _BlockAirlock = new BlockAirlock();
        public static BlockAirlock BlockAirlock
        {
            get => _BlockAirlock; set => _BlockAirlock = value;
        }

        private static BlockLandingPad _BlockLandingPad = new BlockLandingPad();
        public static BlockLandingPad BlockLandingPad
        {
            get => _BlockLandingPad; set => _BlockLandingPad = value;
        }

        private static Docked _Docked = new Docked();
        public static Docked Docked
        {
            get => _Docked; set => _Docked = value;
        }

        private static FireInNoFireZone _FireInNoFireZone = new FireInNoFireZone();
        public static FireInNoFireZone FireInNoFireZone
        {
            get => _FireInNoFireZone; set => _FireInNoFireZone = value;
        }

        private static Music _Music = new Music();
        public static Music Music
        {
            get => _Music; set => _Music = value;
        }

        private static NoFireZone _NoFireZone = new NoFireZone();
        public static NoFireZone NoFireZone
        {
            get => _NoFireZone; set => _NoFireZone = value;
        }

        private static ShipyardArrived _ShipyardArrived = new ShipyardArrived();
        public static ShipyardArrived ShipyardArrived
        {
            get => _ShipyardArrived; set => _ShipyardArrived = value;
        }

        private static SupercruiseEntry _SupercruiseEntry = new SupercruiseEntry();
        public static SupercruiseEntry SupercruiseEntry
        {
            get => _SupercruiseEntry; set => _SupercruiseEntry = value;
        }

        private static SupercruiseExit _SupercruiseExit = new SupercruiseExit();
        public static SupercruiseExit SupercruiseExit
        {
            get => _SupercruiseExit; set => _SupercruiseExit = value;
        }

        #endregion

        #region Equipment
        private static FrameShiftDrive _FrameShiftDrive = new FrameShiftDrive();
        public static FrameShiftDrive FrameShiftDrive
        {
            get => _FrameShiftDrive; set => _FrameShiftDrive = value;
        }

        private static LandingGear _LandingGear = new LandingGear();
        public static LandingGear LandingGear
        {
            get => _LandingGear; set => _LandingGear = value;
        }

        private static Shields _Shields = new Shields();
        public static Shields Shields
        {
            get => _Shields; set => _Shields = value;
        }
        #endregion

        /// <summary>
        /// Simple Function To Check Plugin Is Initialized
        /// </summary>
        /// <param name="M">(Method) Simple Name Of The Calling Method</param>
        /// <returns>true or false</returns>
        public static bool Initialized(string M, bool L = true)
        {
            //Check Plugin Initialized
            if (PlugIn.M_Journal.Settings.Initialized == false)
            {
                //Debug Logger
                if (L) { Logger.DebugLine(M, "Plugin Not Initialized", Logger.Yellow); }
                return false;
            }

            return true;
        }

        /// <summary>
        /// Simple Function To Check Json Monitor Is Initialized
        /// </summary>
        /// <param name="M">(Method) Simple Name Of The Calling Method</param>
        /// <returns>true or false</returns>
        public static bool InitializedJson(string M, bool L = true)
        {
            //Check Plugin Initialized
            if (PlugIn.M_Json.Settings.Initialized == false)
            {
                //Debug Logger
                if (L) { Logger.DebugLine(M, "Json Monitor Not Initialized", Logger.Yellow); }
                return false;
            }

            return true;
        }

        /// <summary>
        /// Simple Function To Check Plugin Is Initialized
        /// </summary>
        /// <param name="M">(Method) Simple Name Of The Calling Method</param>
        /// <returns>true or false</returns>
        public static bool InitializedStatus(string M, bool L = true)
        {
            //Check Plugin Initialized
            if (PlugIn.M_Json.Status.InitialLoad == true)
            {
                //Debug Logger
                if (L) { Logger.DebugLine(M, "Status.Json Not Initialized", Logger.Yellow); }
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Base Debug Wrapper Class
    /// </summary>
    public class Debug
    {
        /// <summary>
        /// Retrieves the Target Variables value from the Interface that started Project A.L.I.C.E (Ie Voice Macro or Voice Attack)
        /// </summary>
        /// <param name="M">(Method) The Call Method</param>
        /// <param name="V">(Variable) The Target Variable</param>
        /// <param name="D">(Default) The Default Fallback Value</param>
        /// <param name="Er">(Error) The Error Text Provided Upon Fallback</param>
        /// <param name="L">(Log) Enable / Disable The Logging Function</param>
        /// <returns></returns>
        public string Retreive(string M, IPlatform.IVar V, string D, string Er, bool L = true)
        {
            string S = D;
            bool Error = false;

            try
            {
                S = IPlatform.GetText(V);
            }
            catch (Exception ex)
            {
                Logger.Exception(M, "Execption: " + ex);
                Error = true;
            }

            if (Error && L)
            {
                Logger.Error(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": " + Er, Logger.Red);
            }

            if (L)
            {
                Logger.DebugLine(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": Returned " + S, Logger.Blue);
            }

            return S;
        }

        /// <summary>
        /// Retrieves the Target Variables value from the Interface that started Project A.L.I.C.E (Ie Voice Macro or Voice Attack)
        /// </summary>
        /// <param name="M">(Method) The Call Method</param>
        /// <param name="V">(Variable) The Target Variable</param>
        /// <param name="D">(Default) The Default Fallback Value</param>
        /// <param name="Er">(Error) The Error Text Provided Upon Fallback</param>
        /// <param name="Min">(Minimum) The Min Allowed Value</param>
        /// <param name="Max">(Maximum) The Max Allowed Value</param>
        /// <param name="L">(Log) Enable / Disable The Logging Function</param>
        /// <returns></returns>
        public decimal Retreive(string M, IPlatform.IVar V, decimal D, string Er, decimal Min = 0, decimal Max = 1000000000, bool L = true)
        {
            decimal S = D;
            bool Error = false;

            try
            {
                //Get Text Value From Platform
                string T = IPlatform.GetText(V);

                //Check Only Numbers
                if (IsDigitsOnly(T))
                {
                    //Convert Value
                    S = Convert.ToDecimal(T);

                    //Check Range
                    if (S > Max || S < Min)
                    {
                        Error = true;
                    }
                }   
                else
                {
                    Error = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(M, "Execption: " + ex);
                Error = true;
            }

            if (Error && L)
            {
                Logger.Error(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": " + Er, Logger.Red);
            }

            if (L)
            {
                Logger.DebugLine(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": Returned " + S, Logger.Blue);
            }

            return S;
        }

        /// <summary>
        /// Retrieves the Target Variables value from the Interface that started Project A.L.I.C.E (Ie Voice Macro or Voice Attack)
        /// </summary>
        /// <param name="M">(Method) The Call Method</param>
        /// <param name="V">(Variable) The Target Variable</param>
        /// <param name="Er">(Error) The Error Text Provided Upon Fallback</param>
        /// <param name="L">(Log) Enable / Disable The Logging Function</param>
        /// <returns></returns>
        public bool Retreive(string M, IPlatform.IVar V, string Er, bool L = true)
        {
            bool S = false;
            bool Error = false;

            try
            {
                string T = IPlatform.GetText(V);

                if (T.ToLower() == "true" || T.ToLower() == "false")
                {
                    S = Convert.ToBoolean(T);
                }
                else
                {
                    Error = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(M, "Execption: " + ex);
                Error = true;
            }

            if (Error && L)
            {
                Logger.Error(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": " + Er, Logger.Red);
            }

            if (L)
            {
                Logger.DebugLine(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": Returned " + S, Logger.Blue);
            }

            return S;
        }

        /// <summary>
        /// Checks a boolean property wrapping the Debug Logger into the check.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) The Simple Variable Name</param>
        /// <param name="T">(Target) Expected State</param>
        /// <param name="P">(Property) Property Being Checked</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        /// <returns></returns>
        public bool Evaluate(string M, string N, bool C, bool P, bool L = true)
        {
            //Check
            if (C != P)
            {
                //Failed
                if (L) { Logger.DebugLine(M, "[Fail]: " + N + " Does Not Equal Expected State (" + C + ")", Logger.Yellow); }
                return false;
            }

            //Passed
            if (L) { Logger.DebugLine(M, "[Pass]: " + N + " Equals Expected State (" + C + ")", Logger.Blue); }
            return true;
        }

        /// <summary>
        /// Checks a string property wrapping the Debug Logger into the check.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) The Simple Variable Name</param>
        /// <param name="C">(Check) The State Your Evaluating</param>
        /// <param name="T">(Target) Is Expected State</param>
        /// <param name="P">(Property) Property Being Checked</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        /// <returns></returns>
        public bool Evaluate(string M, string N, bool T, string C, string P, bool L = true)
        {
            //Set Prefix For Check Value
            string S = ""; if (T == false) { S = "Not "; }

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

        /// <summary>
        /// Checks a decimal property wrapping the Debug Logger into the check.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) The Simple Variable Name</param>
        /// <param name="C">(Check) The State Your Evaluating</param>
        /// <param name="T">(Target) Is Expected State</param>
        /// <param name="P">(Property) Property Being Checked</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        /// <returns></returns>
        public bool Evaluate(string M, string N, bool T, decimal C, decimal P, bool L = true)
        {
            //Set Prefix For Check Value
            string S = ""; if (T == false) { S = "Not "; }

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

        /// <summary>
        /// Get the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <returns>The Property Value</returns>
        public string Get(string M, string N, string P, bool L = true)
        {
            if (L) { Logger.DebugLine(M, "[Value]: " + N + " Equals - " + P, Logger.Blue); }
            return P;
        }

        /// <summary>
        /// Get the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <returns>The Property Value</returns>
        public decimal Get(string M, string N, decimal P, bool L = true)
        {
            if (L) { Logger.DebugLine(M, "[Value]: " + N + " Equals - " + P, Logger.Blue); }
            return P;
        }

        /// <summary>
        /// Get the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <returns>The Property Value</returns>
        public bool Get(string M, string N, bool P, bool L = true)
        {
            if (L) { Logger.DebugLine(M, "[Value]: " + N + " Equals - " + P, Logger.Blue); }
            return P;
        }

        /// <summary>
        /// Fucntion To Check String Contains Only Numbers
        /// </summary>
        /// <param name="S">(String) Text You Want To Check</param>
        /// <returns></returns>
        private bool IsDigitsOnly(string S)
        {
            foreach (char C in S)
            {
                if (C < '0' || C > '9')
                {
                    return false;
                }                    
            }

            return true;
        }
    }
}