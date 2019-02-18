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
    }
}
