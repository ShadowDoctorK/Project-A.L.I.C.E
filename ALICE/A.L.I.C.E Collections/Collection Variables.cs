using ALICE_Interface;
using ALICE_Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            //Pass Variable to Interface.
                            IPlatform.SetText(Variable.Key, Variable.Value);
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
                            IPlatform.SetText(Variable.Key, null);
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
        public void Switch(string VariableName, string VariableVallue, string FallbackValue, string Case = "None")
        {
            //Check Value Does Not Equal Case
            if (VariableVallue != Case)
            {
                Record(VariableName, VariableVallue);
            }
            //Use Fallback Value
            else
            {
                Record(VariableName, FallbackValue);
            }
        }

        /// <summary>
        /// Will set the variable based on evaluating the switch case. This Method allows a single simple function to pick between two variable values.
        /// </summary>
        /// <param name="VariableName">Full name of the Variable</param>
        /// <param name="VariableVallue">Primary Target Value</param>
        /// <param name="FallbackValue">Backup Value</param>
        /// <param name="Case">Trigger that will cause the use of the Fallback Value</param>
        public void Switch(string VariableName, decimal VariableVallue, decimal FallbackValue, decimal Case = -1)
        {
            //Check Value Does Not Equal Case
            if (VariableVallue != Case)
            {
                Record(VariableName, VariableVallue);
            }
            //Use Fallback Value
            else
            {
                Record(VariableName, FallbackValue);
            }
        }

        /// <summary>
        /// Will set the variable based on evaluating the switch case. This Method allows a single simple function to pick between two variable values.
        /// </summary>
        /// <param name="VariableName">Full name of the Variable</param>
        /// <param name="VariableVallue">Primary Target Value</param>
        /// <param name="FallbackValue">Backup Value</param>
        /// <param name="Case">Trigger that will cause the use of the Fallback Value</param>
        public void Switch(string VariableName, decimal VariableVallue, string FallbackValue, decimal Case = -1)
        {
            //Check Value Does Not Equal Case
            if (VariableVallue != Case)
            {
                Record(VariableName, VariableVallue);
            }
            //Use Fallback Value
            else
            {
                Record(VariableName, FallbackValue);
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
        public void Switch(string VariableName, bool State, string VariableVallue, string FallbackValue, bool Case = false)
        {
            //Check Value Does Not Equal Case
            if (State != Case)
            {                
                Record(VariableName, VariableVallue);
            }
            //Use Fallback Value
            else
            {
                Record(VariableName, FallbackValue);
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
        public void Switch(string VariableName, List<string> Values, int TargetItem, string FallbackValue, string Case = "None")
        {
            try
            {
                //Check Target Item Exists
                if (Values.Count - 1 < TargetItem)
                {
                    //Use Fallback Value
                    Record(VariableName, FallbackValue);
                    return;
                }

                //Check Value Does Not Equal Case
                if (Values[TargetItem] != Case)
                {
                    Record(VariableName, Values[TargetItem]);
                }
                //Use Fallback Value
                else
                {
                    Record(VariableName, FallbackValue);
                }
            }
            catch (Exception)
            {
                
            }            
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
                            //Store Variable
                            Storage.Add(VariableName, VariableValue);
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
