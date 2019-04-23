using ALICE_Interface;
using ALICE_Internal;
using System;

namespace ALICE_Debug
{
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
                string Temp = IPlatform.GetText(V);

                //Check Null Or Whitespace
                if (string.IsNullOrWhiteSpace(Temp) == false)
                {
                    S = Temp;
                }

                //Passed Check, Use Value
                else
                {
                    Logger.DebugLine(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": Returned Null Or Whitespace", Logger.Yellow);
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
                Logger.DebugLine(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": Resolved Value: " + S, Logger.Blue);
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
        public decimal Retreive(string M, IPlatform.IVar V, decimal D, string Er, bool L, decimal Min = 0, decimal Max = 1000000000)
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

                //Failed Check
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
                Logger.DebugLine(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": Resolved Value: " + S, Logger.Blue);
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

                //Check For True And False Values
                if (T.ToLower() == "true" || T.ToLower() == "false")
                {
                    S = Convert.ToBoolean(T);
                }

                //Failed Check
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
                Logger.DebugLine(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": Resolved Value: " + S, Logger.Blue);
            }

            return S;
        }

        /// <summary>
        /// Pass the Target Variable a value from value from the plugin to the Interface that started Project A.L.I.C.E (Ie Voice Macro or Voice Attack)
        /// </summary>        
        /// <param name="M">(Method) The Call Method.</param>
        /// <param name="V">(Variable) The Target Variable.</param>
        /// <param name="Val">(Value) The Value Being Set.</param>
        /// <param name="L">(Log) Enable / Disable The Logging Function.</param>        
        public void Pass(string M, IPlatform.IVar V, string Val, bool L = true)
        {
            bool Error = false;

            try
            {
                IPlatform.SetText(V, Val);
            }
            catch (Exception ex)
            {
                Logger.Exception(M, "Execption: " + ex);
                Error = true;
            }

            if (Error && L)
            {
                Logger.Error(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": " + "Unable To Update Variale.", Logger.Red);
            }

            if (L)
            {
                Logger.DebugLine(M, "[" + IPlatform.Interface + "] ALICE_" + V + ": Passed " + Val, Logger.Blue);
            }
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
        /// Will get the variable based on evaluating the case. Can be used to create custom properties.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P1">(Property) The Primary Property Being Checked</param>
        /// <param name="P2">(Property) The Alternate Property Returned If Check Fails</param>
        /// <param name="C">(Case) The Case That Causes The Primary Property To Fail.</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        /// <returns>The Property 1 If Pass', Property 2 If Property 1 Fails.</returns>
        public string Resolve(string M, string N, string P1, string P2, string C = "None", bool L = true)
        {
            //Check Value Does Not Equal Case
            if (P1 != C)
            {
                if (L) { Logger.DebugLine(M, "[Switch]: " + N + " = [1] " + P1, Logger.Blue); }
                return P1;
            }

            //Use Fallback Value
            else
            {
                if (L) { Logger.DebugLine(M, "[Switch]: " + N + " = [2] " + P2, Logger.Blue); }
                return P2;
            }
        }

        /// <summary>
        /// Get the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        /// <returns>The Property Value</returns>
        public string Get(string M, string N, string P, bool L = true)
        {
            if (L) { Logger.DebugLine(M, "[Get]: " + N + " = " + P, Logger.Blue); }
            return P;
        }

        /// <summary>
        /// Get the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        /// <returns>The Property Value</returns>
        public decimal Get(string M, string N, decimal P, bool L = true)
        {
            if (L) { Logger.DebugLine(M, "[Get]: " + N + " = " + P, Logger.Blue); }
            return P;
        }

        /// <summary>
        /// Get the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        /// <returns>The Property Value</returns>
        public bool Get(string M, string N, bool P, bool L = true)
        {
            if (L) { Logger.DebugLine(M, "[Get]: " + N + " = " + P, Logger.Blue); }
            return P;
        }

        /// <summary>
        /// Set the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <param name="V">(Value) The New Value</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        public void Set(string M, string N, ref decimal P, decimal V, bool L = true)
        {
            //Only Process Changes
            if (P == V) { return; }

            //Update Property
            P = V;

            //Debug Logger            
            if (L) { Logger.DebugLine(M, "[Set]: " + N + " = " + V, Logger.Yellow); }            
        }

        /// <summary>
        /// Set the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <param name="V">(Value) The New Value</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        public void Set(string M, string N, ref bool P, bool V, bool L = true)
        {
            //Only Process Changes
            if (P == V) { return; }

            //Update Property
            P = V;

            //Debug Logger            
            if (L) { Logger.DebugLine(M, "[Set]: " + N + " = " + V, Logger.Yellow); }
        }

        /// <summary>
        /// Set the value of the property wrapping the Debug Logger into the function.
        /// </summary>
        /// <param name="M">(Method) Calling Method Name</param>
        /// <param name="N">(Name) Simple Property Name</param>
        /// <param name="P">(Property) The Property Being Returned</param>
        /// <param name="V">(Value) The New Value</param>
        /// <param name="L">(Log) Enables / Disables Debug Logging Fucntion</param>
        public void Set(string M, string N, ref string P, string V, bool L = true)
        {
            //Only Process Changes
            if (P == V) { return; }

            //Update Property
            P = V;

            //Debug Logger            
            if (L) { Logger.DebugLine(M, "[Set]: " + N + " = " + V, Logger.Yellow); }
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