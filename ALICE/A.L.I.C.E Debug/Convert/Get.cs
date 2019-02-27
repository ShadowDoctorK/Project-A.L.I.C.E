using System;
using ALICE_Core;
using ALICE_Events;
using ALICE_Interface;
using ALICE_Objects;

namespace ALICE_Internal
{
    public static class Get
    {
        public static Environments Environment = new Environments();
        public static Variables Variable = new Variables();

        public class Variables
        {
            //public bool LocationFilter(string Filter, bool Answer = false)
            //{
            //    string MethodName = "Get Location Filter";

            //    try
            //    {
            //        bool Instance = Convert.ToBoolean(IPlatform.GetText(Filter));
            //        bool Maintain = Convert.ToBoolean(IPlatform.GetText(Filter + "_Maintain"));

            //        if (Instance) { Logger.DebugLine(MethodName, Filter + " = True.", Logger.Blue); Answer = true; }
            //        if (Maintain) { Logger.DebugLine(MethodName, Filter + "_Maintain = True.", Logger.Blue); Answer = true; }
            //        if (Instance == false && Maintain == false) { Logger.DebugLine(MethodName, Filter + " = False.", Logger.Yellow); }
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.Exception(MethodName, "Exception: " + ex);
            //        Logger.Exception(MethodName, "Something Went Wrong While Getting The Value For " + Filter);
            //    }

            //    return Answer;
            //}

            public decimal ALICE_EnginePower(decimal Engine = 0)
            {
                string MethodName = "Get Engine Power";

                try { Engine = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.EnginePower)); }
                catch (Exception) { Logger.Exception(MethodName, "[Text Variable] ALICE_EnginePower Was Not Set To A Valid Option. (0 - 8)"); return 0; }
                return Engine;
            }

            public decimal ALICE_SystemPower(decimal System = 0)
            {
                string MethodName = "Get System Power";

                try { System = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.SystemPower)); }
                catch (Exception) { Logger.Exception(MethodName, "[Text Variable] ALICE_SystemPower Was Not Set To A Valid Option. (0 - 8)"); return 0; }
                return System;
            }

            public decimal ALICE_WeaponPower(decimal Weapon = 0)
            {
                string MethodName = "Get Weapon Power";

                try { Weapon = Convert.ToDecimal(IPlatform.GetText(IPlatform.IVar.WeaponPower)); }
                catch (Exception) { Logger.Exception(MethodName, "[Text Variable] ALICE_WeaponPower Was Not Set To A Valid Option. (0 - 8)"); return 0; }
                return Weapon;
            }

            public bool ALICE_RecordPower(bool Record = false)
            {
                string MethodName = "Get Weapon Power";

                try { Record = Convert.ToBoolean(IPlatform.GetText(IPlatform.IVar.RecordPower)); }
                catch (Exception) { Logger.Exception(MethodName, "[Text Variable] ALICE_RecordPower Was Not Set To A Valid Option. (true or false)"); return false; }
                return Record;
            }
        }

        public class Environments
        {
            public string Space()
            {
                string Answer = IEnums.Normal_Space;

                if (IStatus.Hyperspace == true)
                {
                    Answer = IEnums.Hyperspace;
                }
                else if (IStatus.Supercruise == true)
                {
                    Answer = IEnums.Supercruise;
                }

                return Answer;
            }      
        }
    }
}
