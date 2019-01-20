//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 12:20 AM
//Source Journal Line: (Custom A.L.I.C.E Event)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;
using ALICE_EventLogic;

namespace ALICE_Events
{
    public class Event_FuelHalfThreshold : Event_Base
    {
        public Event_FuelHalfThreshold()
        {
            Name = "FuelHalfThreshold";
            FuelHalfThreshold Temp = new FuelHalfThreshold();
            UpdateEvents(Name, Temp);
        }

        public void Logic()
        {
            if (IEvents.WriteVariables && WriteVariables)
            {
                try
                {
                    Variables_Clear();
                    Variables_Generate();
                    Variables_Write();
                }
                catch (Exception ex)
                {
                    Logger.Exception(Name, "An Exception Occured While Updating Variables");
                    Logger.Exception(Name, "Exception: " + ex);
                }
            }

            Process.FuelHalfThreshold((FuelHalfThreshold)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            FuelHalfThreshold Event = (FuelHalfThreshold)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables

            #endregion
        }

    }

    #region FuelHalfThreshold Event
    public class FuelHalfThreshold : Base
    {

    }
    #endregion
}
