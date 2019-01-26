using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Core;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;

namespace ALICE_Equipment
{
    public class Equipment_FuelTank : Equipment_General
    {
        public decimal Capacity { get; set; }

        public Equipment_FuelTank()
        {
            Installed = false;
            Enabled = true;            
            Capacity = -1;
        }

        public Equipment_FuelTank New() { return new Equipment_FuelTank(); }

        public void U_Capacity(string MethodName, decimal C)
        {
            //Validate Capcity
            if (C == -1)
            {
                Logger.Error(MethodName, "Invalid Fuel Capacity. Capacity Not Updated. Attempting To Continue.", Logger.Red);
                return;
            }

            //Udpate Fuel Tank Capacity
            Capacity = C;

            //Update Fuel Status Capacity
            IObjects.Mothership.F.Capacity = C;
        }

        #region Audio
        
        #endregion
    }
}