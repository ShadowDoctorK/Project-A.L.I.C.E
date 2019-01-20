using System;
using ALICE_Events;
using ALICE_Interface;
using ALICE_Objects;

namespace ALICE_Internal
{
    public static class Get
    {
        public static Environments Environment = new Environments();
        public static Variables Variable = new Variables();
        public static Events Event = new Events();

        public class Events
        {
            public GetBlockLandingPadWarning BlockLandingPadWarning = new GetBlockLandingPadWarning();
            public GetBlockAirLockWarning BlockAirLockWarning = new GetBlockAirLockWarning();
            public GetDocked Docked = new GetDocked();
            public GetMasslock Masslock = new GetMasslock();
            public GetNoFireZone NoFireZone = new GetNoFireZone();
            public GetSupercruiseExit SupercruiseExit = new GetSupercruiseExit();

            public class GetBlockAirLockWarning
            {
                public BlockAirlockWarning BlockAirlockWarning()
                {
                    string EventName = IEnums.BlockAirlockWarning;
                    BlockAirlockWarning Temp = null;

                    if (IEvents.EventExist(EventName))
                    {
                        Temp = (BlockAirlockWarning)IEvents.GetEvent(EventName);
                    }
                    return Temp;
                }

                public string Station()
                {
                    BlockAirlockWarning Event = BlockAirlockWarning();

                    if (Event != null)
                    { return Event.Station; }

                    return null;
                }
            }

            public class GetBlockLandingPadWarning
            {
                public BlockLandingPadWarning BlockLandingPadWarning()
                {
                    string EventName = IEnums.BlockLandingPadWarning;
                    BlockLandingPadWarning Temp = null;

                    if (IEvents.EventExist(EventName))
                    {
                        Temp = (BlockLandingPadWarning)IEvents.GetEvent(EventName);
                    }
                    return Temp;
                }

                public string Station()
                {
                    BlockLandingPadWarning Event = BlockLandingPadWarning();

                    if (Event != null)
                    { return Event.Station; }

                    return null;
                }
            }

            public class GetDocked
            {
                public Docked Docked()
                {
                    string EventName = IEnums.Docked;
                    Docked Temp = null;

                    if (IEvents.EventExist(EventName))
                    {
                        Temp = (Docked)IEvents.GetEvent(EventName);
                    }
                    return Temp;
                }

                public string StationName()
                {
                    Docked Event = Docked();
                    if (Event != null)
                    { return Event.StationName; }

                    return null;
                }

                public string StarSystem()
                {
                    Docked Event = Docked();
                    if (Event != null)
                    { return Event.StarSystem; }

                    return null;
                }
            }

            public class GetMasslock
            {
                public ALICE_Events.Masslock Masslock()
                {
                    string EventName = IEnums.Masslock;
                    ALICE_Events.Masslock Temp = null;

                    if (IEvents.EventExist(EventName))
                    {
                        Temp = (ALICE_Events.Masslock)IEvents.GetEvent(EventName);
                    }
                    return Temp;
                }

                public bool Masslocked()
                {
                    ALICE_Events.Masslock Event = Masslock();

                    if (Event != null)
                    { return Event.Masslocked; }

                    return false;
                }
            }

            public class GetNoFireZone
            {
                public NoFireZone NoFireZone()
                {
                    string EventName = IEnums.NoFireZone;
                    NoFireZone Temp = null;

                    if (IEvents.EventExist(EventName))
                    {
                        Temp = (NoFireZone)IEvents.GetEvent(EventName);
                    }
                    return Temp;
                }

                public string Station()
                {
                    NoFireZone Event = NoFireZone();
                    if (Event != null)
                    { return Event.Station; }

                    return null;
                }
            }

            public class GetSupercruiseExit
            {
                public SupercruiseExit SupercruiseExit()
                {
                    string EventName = IEnums.SupercruiseExit;
                    SupercruiseExit Temp = null;

                    if (IEvents.EventExist(EventName))
                    {
                        Temp = (SupercruiseExit)IEvents.GetEvent(EventName);
                    }
                    return Temp;
                }

                public string Body()
                {
                    SupercruiseExit Event = SupercruiseExit();

                    if (Event != null)
                    { return Event.Body; }

                    return null;
                }

                public string BodyType()
                {
                    SupercruiseExit Event = SupercruiseExit();
                    if (Event != null)
                    { return Event.BodyType; }

                    return null;
                }
            }
        }

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

                if (IObjects.Status.Hyperspace == true)
                { Answer = IEnums.Hyperspace; }
                else if (IObjects.Status.Supercruise == true)
                { Answer = IEnums.Supercruise; }

                return Answer;
            }      
        }
    }
}
