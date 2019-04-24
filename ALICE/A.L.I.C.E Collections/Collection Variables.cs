using ALICE_Debug;
using ALICE_Interface;
using ALICE_Internal;
using System;
using System.Collections.Generic;

namespace ALICE_Collections
{
    /// <summary>
    /// Custom Collection that handles Variable storage and controls with other Platforms.
    /// </summary>
    public class CollectionVariables
    {
        /// <summary>
        /// Collection of variable Name / Value for each Property processed by the generator for an Event
        /// </summary>
        public Dictionary<string, string> Storage = new Dictionary<string, string>();

        /// <summary>
        /// Enabled / Disables variable genration per event.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Readonly string defining the Class Name for tracking use with the Logger function.
        /// </summary>
        private readonly string ClassName = "Variable";

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CollectionVariables()
        {
            Enabled = false;
        }

        /// <summary>
        /// Writes all variables contained in the Collection to the current Platform.
        /// </summary>
        public void Write()
        {
            string MethodName = ClassName + " (Write)";

            try
            {
                //Platform Validation
                switch (IPlatform.Interface)
                {
                    case IPlatform.Interfaces.Internal:

                        //Nothing To Do

                        return;

                    default:

                        //Write Variables
                        foreach (var Variable in Storage)
                        {
                            //Debug Logger
                            //Logger.DebugLine(MethodName, Variable.Key + " = " + Variable.Value, "Orange");

                            //Pass Variable to Interface. Disable Prefix.
                            IPlatform.SetText(Variable.Key, Variable.Value, false, ICheck.Initialized(MethodName, false));

                            if (PlugIn.VariableLogging 
                            && (Variable.Value != "" || Variable.Value != null) 
                            && ICheck.Initialized(ClassName, false)
                            )                               
                            {
                                Logger.Simple(Variable.Key + " = " + Variable.Value, "Orange");
                            }
                        }

                        break;
                }                
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);
            }
        }

        /// <summary>
        /// Clears all variables contained in the Collection from the current Platform.
        /// </summary>
        public void Clear()
        {
            string MethodName = ClassName + " (Clear)";

            try
            {
                //Platform Validation
                switch (IPlatform.Interface)
                {
                    //case IPlatform.Interfaces.Internal:

                    //    //Nothing To Do

                    //    return;

                    default:

                        //Clear Variables
                        foreach (var Variable in Storage)
                        {
                            //Pass Variable to Interface.
                            IPlatform.SetText(Variable.Key, null, ICheck.Initialized(MethodName, false));
                        }

                        break;
                }

                //Reset Collection
                Storage = new Dictionary<string, string>();
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);
            }
        }

        /// <summary>
        /// Will set the variable based on evaluating the switch case. This Method allows a single simple function to pick between two variable values.
        /// </summary>
        /// <param name="VariableName">Full name of the Variable</param>
        /// <param name="VariableVallue">Primary Target Value</param>
        /// <param name="FallbackValue">Backup Value</param>
        /// <param name="Case">Trigger that will cause the use of the Fallback Value</param>
        public bool Switch(string VariableName, string VariableVallue, string FallbackValue, string Case = "None")
        {
            //Check Value Does Not Equal Case
            if (VariableVallue != Case)
            {
                Record(VariableName, VariableVallue);
                return true;
            }
            //Use Fallback Value
            else
            {
                Record(VariableName, FallbackValue);
                return false;
            }
        }

        /// <summary>
        /// Will set the variable based on evaluating the switch case. This Method allows a single simple function to pick between two variable values.
        /// </summary>
        /// <param name="VariableName">Full name of the Variable</param>
        /// <param name="VariableVallue">Primary Target Value</param>
        /// <param name="FallbackValue">Backup Value</param>
        /// <param name="Case">Trigger that will cause the use of the Fallback Value</param>
        /// <returns>Returns true if Target Value was used, false if Fallback Value was used</returns>
        public bool Switch(string VariableName, decimal VariableValue, decimal FallbackValue, decimal Case = -1)
        {
            //Check Value Does Not Equal Case
            if (VariableValue != Case)
            {
                Record(VariableName, VariableValue);
                return true;
            }
            //Use Fallback Value
            else
            {
                Record(VariableName, FallbackValue);
                return false;
            }
        }

        /// <summary>
        /// Will set the variable based on evaluating the switch case. This Method allows a single simple function to pick between two variable values.
        /// </summary>
        /// <param name="VariableName">Full name of the Variable</param>
        /// <param name="VariableVallue">Primary Target Value</param>
        /// <param name="FallbackValue">Backup Value</param>
        /// <param name="Case">Trigger that will cause the use of the Fallback Value</param>
        /// <returns>Returns true if Target Value was used, false if Fallback Value was used</returns>
        public bool Switch(string VariableName, decimal VariableValue, string FallbackValue, decimal Case = -1)
        {
            //Check Value Does Not Equal Case
            if (VariableValue != Case)
            {
                Record(VariableName, VariableValue);
                return true;
            }
            //Use Fallback Value
            else
            {
                Record(VariableName, FallbackValue);
                return false;
            }
        }

        /// <summary>
        /// Will set the variable based on evaluating the switch case. This Method allows a single simple function to pick between two values based on the passed boolean.
        /// </summary>
        /// <param name="VariableName">Full name of the Variable</param>
        /// <param name="State">State of the boolean value being checked</param>
        /// <param name="VariableVallue">Primary Target Value</param>
        /// <param name="FallbackValue">Backup Value</param>
        /// <param name="Case">Trigger that will cause the use of the Fallback Value</param>
        /// <returns>Returns true if Target Value was used, false if Fallback Value was used</returns>
        public bool Switch(string VariableName, bool State, string VariableValue, string FallbackValue, bool Case = false)
        {
            //Check Value Does Not Equal Case
            if (State != Case)
            {                
                Record(VariableName, VariableValue);
                return true;
            }
            //Use Fallback Value
            else
            {
                Record(VariableName, FallbackValue);
                return false;
            }
        }

        /// <summary>
        /// Will set the variable based on validating the list item exists then evalutating the vaule against the case. Will use the fallback value 
        /// if the item doesn't exist, or the evaluation against the case fails.
        /// </summary>
        /// <param name="VariableName">Full name of the Variable</param>
        /// <param name="Values">The list you're working with</param>
        /// <param name="TargetItem">The item you want to check</param>
        /// <param name="FallbackValue">Backup Value</param>
        /// <param name="Case">Trigger that will cause the use of the Fallback Value</param>
        /// <returns>Returns true if Target Value was used, false if Fallback Value was used</returns>
        public bool Switch(string VariableName, List<string> Values, int TargetItem, string FallbackValue, string Case = "None")
        {
            try
            {
                //Check Target Item Exists
                if (Values.Count - 1 < TargetItem)
                {
                    //Use Fallback Value
                    Record(VariableName, FallbackValue);
                    return false;
                }

                //Check Value Does Not Equal Case
                if (Values[TargetItem] != Case)
                {
                    Record(VariableName, Values[TargetItem]);
                    return true;
                }
                //Use Fallback Value
                else
                {
                    Record(VariableName, FallbackValue);
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }            
        }

        /// <summary>
        /// Will check that the Value does not equal the Case. If it does it will not set the value.
        /// </summary>
        /// <param name="VariableName">Full name of the Variable</param>
        /// <param name="VariableVallue">Value to check</param>        
        /// <param name="Case">Trigger that will cause the variable to not be set</param>
        public bool Validate(string VariableName, string VariableVallue, string Case = "None")
        {
            //Check Value Does Not Equal Case
            if (VariableVallue != Case)
            {
                Record(VariableName, VariableVallue);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Will check that the Value does not equal the Case. If it does it will not set the value.
        /// </summary>
        /// <param name="VariableName">Full name of the Variable</param>
        /// <param name="VariableVallue">Value to check</param>        
        /// <param name="Case">Trigger that will cause the variable to not be set</param>
        public bool Validate(string VariableName, decimal VariableVallue, decimal Case = -1)
        {
            //Check Value Does Not Equal Case
            if (VariableVallue != Case)
            {
                Record(VariableName, VariableVallue);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Will check that the Value does not equal the Case. If it does it will not set the value.
        /// </summary>
        /// <param name="VariableName">Full name of the Variable</param>
        /// <param name="VariableVallue">Value to check</param>        
        /// <param name="Case">Trigger that will cause the variable to not be set</param>
        public bool Validate(string VariableName, bool VariableVallue, bool Case = false)
        {
            //Check Value Does Not Equal Case
            if (VariableVallue != Case)
            {
                Record(VariableName, VariableVallue);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Records the passed variable information.
        /// </summary>
        public void Record(string VariableName, string VariableValue)
        {
            string MethodName = ClassName + " (Record)";

            try
            {
                //Platform Validation
                switch (IPlatform.Interface)
                {
                    //case IPlatform.Interfaces.Internal:

                    //    //Nothing To Do

                    //    return;

                    default:

                        //Validate Variables Value
                        if (VariableValue != null)
                        {
                            if (Storage.ContainsKey(VariableName) == false)
                            {
                                //Store Variable
                                Storage.Add(VariableName, VariableValue);
                            }
                            else
                            {
                                Logger.AliceLog(VariableName + " Already Existed In The Collection.");
                            }
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);
            }
        }

        /// <summary>
        /// Records the passed variable information.
        /// </summary>
        public void Record(string VariableName, DateTime VariableValue)
        {
            string MethodName = ClassName + " (Record)";

            try
            {
                //Platform Validation
                switch (IPlatform.Interface)
                {
                    //case IPlatform.Interfaces.Internal:

                    //    //Nothing To Do

                    //    return;

                    default:

                        //Validate Variables Value
                        if (VariableValue != null)
                        {
                            //Store Variable
                            Storage.Add(VariableName, VariableValue.ToString());
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);
            }
        }

        /// <summary>
        /// Records the passed variable information.
        /// </summary>
        public void Record(string VariableName, decimal VariableValue)
        {
            string MethodName = ClassName + " (Record)";

            try
            {
                //Platform Validation
                switch (IPlatform.Interface)
                {
                    //case IPlatform.Interfaces.Internal:

                    //    //Nothing To Do

                    //    return;

                    default:

                        //Store Variable
                        Storage.Add(VariableName, VariableValue.ToString());

                        break;
                }
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);
            }
        }

        /// <summary>
        /// Records the passed variable information.
        /// </summary>
        public void Record(string VariableName, bool VariableValue)
        {
            string MethodName = ClassName + " (Record)";

            try
            {
                //Platform Validation
                switch (IPlatform.Interface)
                {
                    //case IPlatform.Interfaces.Internal:

                    //    //Nothing To Do

                    //    return;

                    default:

                        //Store Variable
                        Storage.Add(VariableName, VariableValue.ToString());

                        break;
                }
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);
            }
        }
    }
}
