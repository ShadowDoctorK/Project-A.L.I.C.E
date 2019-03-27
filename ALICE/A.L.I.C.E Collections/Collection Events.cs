using ALICE_Events;
using ALICE_Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Collections
{
    /// <summary>
    /// Custom Collection that handles Event storage and the controls to interface with the Collection.
    /// </summary>
    public class CollectionEvents
    {
        /// <summary>
        /// Collection of variable Name / Value for each Property processed by the generator for an Event
        /// </summary>
        private Dictionary<IEnums.Events, object> _Storage = new Dictionary<IEnums.Events, object>();

        /// <summary>
        /// Collection of variable Name / Value for each Property processed by the generator for an Event
        /// </summary>
        public Dictionary<IEnums.Events, object> Storage
        {
            get => _Storage;
            set => _Storage = value;
        }

        /// <summary>
        /// Readonly string defining the Class Name for tracking use with the Logger function.
        /// </summary>
        private readonly string ClassName = "Event";

        /// <summary>
        /// Records the event object in Event Storage.
        /// </summary>
        /// <param name="E">(Event Name) Target Event's Name</param>
        /// <param name="O">(Object) The Associated Event's Object</param>
        /// <returns>Postive = Recorded, Negative = Not Recorded</returns>
        public IEnums.A Record(IEnums.Events E, object O)
        {
            string MethodName = ClassName + " (Record)";

            switch (Exist(E))
            {
                case IEnums.A.Postive:

                    //Event Exist, Update
                    Storage[E] = O;

                    //Event Recorded
                    return IEnums.A.Postive;

                case IEnums.A.Negative:

                    //Does Not Exist, Add
                    Storage.Add(E, O);

                    //Event Recorded
                    return IEnums.A.Postive;

                case IEnums.A.Error:

                    //Event Not Recorded
                    return IEnums.A.Negative;

                default:

                    //Error Logger
                    Logger.Error(MethodName, "Returned Using Default Swtich, Event Was Not Recorded", Logger.Red);

                    //Event Not Recorded
                    return IEnums.A.Negative;
            }
        }

        /// <summary>
        /// Checks if the target Event Exists in Storage.
        /// </summary>
        /// <param name="E">(Event Name) Target Event</param>
        /// <returns>Postive, Negative or Error</returns>
        public IEnums.A Exist(IEnums.Events E)
        {
            string MethodName = ClassName + " (Exist)";

            try
            {
                //Check For Event
                if (Storage.ContainsKey(E) == true)
                {
                    //Exists, Return Postive
                    return IEnums.A.Postive;
                }

                //Debug Logger
                Logger.DebugLine(MethodName, E + " Has Not Been Recorded Yet.", Logger.Yellow);

                //Event Does Not Exist, Return Negative
                return IEnums.A.Negative;
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);

                //Exception Occured, Return Error
                return IEnums.A.Error;
            }
        }

        /// <summary>
        /// Gets the target Event
        /// </summary>
        /// <param name="E">(Event Name) Target Event</param>
        /// <returns>Object Data or Null</returns>
        public object Get(IEnums.Events E)
        {
            string MethodName = ClassName + " (Get)";
            object Temp = null;

            switch (Exist(E))
            {
                case IEnums.A.Postive:

                    //Get Object
                    Temp = Storage[E];

                    //Return Object
                    return Temp;

                case IEnums.A.Negative:

                    //Return Null
                    return Temp;

                case IEnums.A.Error:

                    //Return Null
                    return Temp;

                default:

                    //Error Logger
                    Logger.Error(MethodName, "Returned Using Default Swtich, Returning Null", Logger.Red);

                    //Return Null
                    return Temp;
            }
        }       
    }
}
