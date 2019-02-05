using System;
using System.Linq;
using System.Threading;
using ALICE_Internal;
using ALICE_Actions;

namespace ALICE_Core
{
    public class IPower
    {
        string ClassName = "Power";

        public GamePower Game = new GamePower();
        public OrderedPower Order = new OrderedPower();
        private ProcessorPower Process = new ProcessorPower();
        private RecordedPower Recorded = new RecordedPower();
        private CalculatedDifference Difference = new CalculatedDifference();
        private ProcessorSetting Setting = new ProcessorSetting();

        public class Base
        {
            public decimal Weapon = 4;
            public decimal Engine = 4;
            public decimal System = 4;
        }
        public class CalculatedDifference : Base
        {
            public decimal Max = 0;
            public decimal AbsoluteMax = 0;

            public void Calculate()
            {
                Engine = Call.Power.Order.Engine - Call.Power.Process.Engine;
                System = Call.Power.Order.System - Call.Power.Process.System;
                Weapon = Call.Power.Order.Weapon - Call.Power.Process.Weapon;
            }

            public void UpdateAbsolute()
            {
                Calculate(); decimal[] Absolute =
                {
                    decimal.Parse((Call.Power.Difference.Engine.ToString().Trim('-'))),
                    decimal.Parse((Call.Power.Difference.System.ToString().Trim('-'))),
                    decimal.Parse((Call.Power.Difference.Weapon.ToString().Trim('-')))
                };
                AbsoluteMax = Absolute.Max();
            }

            public void UpdateMax()
            {
                Calculate(); decimal[] Numbers =
{
                    Call.Power.Difference.Engine,
                    Call.Power.Difference.System,
                    Call.Power.Difference.Weapon
                }; Max = Numbers.Max();
            }
        }
        public class GamePower : Base { }
        public class RecordedPower : Base { }
        public class ProcessorPower : Base
        {
            public void GetPower()
            {
                Engine = Call.Power.Game.Engine;
                System = Call.Power.Game.System;
                Weapon = Call.Power.Game.Weapon;
            }

            public void SetPower()
            {
                Call.Power.Game.Engine = Engine;
                Call.Power.Game.System = System;
                Call.Power.Game.Weapon = Weapon;
            }
        }
        public class OrderedPower : Base
        {
            public bool Record = false;
        }
        public class ProcessorSetting
        {
            public decimal Loop = 0;
            public bool Balance = true;
            public decimal Request { get; set; }
            public decimal Processed { get; set; }
            public bool Init = false;
            public object Lock_Power = new object();

            public ProcessorSetting()
            {
                Request = 0;
                Processed = 0;
            }
        }

        public void Initialize()
        {
            string MethodName = ClassName + " Initialize";

            try
            {
                Thread power =
                    new Thread((ThreadStart)(() =>
                    { Setting.Init = true; Set(4, 4, 4); }))
                    { IsBackground = true };
                power.Start();
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
                Logger.Exception(MethodName, "Something Went Wrong Initializing The Power Management System...");
            }
        }

        public void Set(decimal OrderWeapon, decimal OrderSystem, decimal OrderEngine, bool OrderRecord = false)
        {
            string MethodName = ClassName + " Control";

            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }

            if (OrderWeapon + OrderSystem + OrderEngine != 12)
            {
                return;
            }

            #region Power Settings
            Order.Engine = OrderEngine;
            Order.System = OrderSystem;
            Order.Weapon = OrderWeapon;
            Order.Record = OrderRecord;

            if (Order.Record)
            {
                Recorded.Engine = Game.Engine;
                Recorded.System = Game.System;
                Recorded.Weapon = Game.Weapon;
                Order.Record = false;
            }

            Setting.Request++;
            #endregion

            try
            {
                if (Monitor.TryEnter(Setting.Lock_Power))
                {
                    if (Setting.Init)
                    {
                        Setting.Processed = Setting.Request;
                        Setting.Init = false;
                    }

                    while (true)
                    {
                        #region Standby
                        StandBy:
                        while (Setting.Processed == Setting.Request)
                        {
                            //Standby
                            Thread.Sleep(100);
                            Process.GetPower();
                        }
                        Process.GetPower(); Setting.Balance = true; Start:
                        Setting.Processed = Setting.Request; Setting.Loop = 0;
                        #endregion

                        Logger.DebugLine(MethodName, "Ordered Power: S" + Order.System + " | E" + Order.Engine + " | W" + Order.Weapon, Logger.Yellow);

                        #region Balance Power (Check)
                        if (Order.Weapon == 4 && Order.Engine == 4 && Order.System == 4)
                        {
                            Call.Key.Press(Call.Key.Balance_Power_Distribution, 100, Call.Key.DelayPower);
                            Game.Engine = 4; Game.System = 4; Game.Weapon = 4;
                            goto StandBy;
                        }
                        #endregion

                        #region Logic Processor
                        while ((Process.Engine != Order.Engine || Process.System != Order.System || Process.Weapon != Order.Weapon) && Setting.Loop <= 20)
                        {
                            Logger.DebugLine(MethodName, "Processor Power: S" + Process.System + " | E" + Process.Engine + " | W" + Process.Weapon, Logger.Yellow);

                            if (CheckHyperspace(MethodName) == false)
                            {
                                //No Action Required.
                            }

                            #region Calculate Difference
                            Difference.UpdateMax();
                            Difference.UpdateAbsolute();
                            #endregion

                            if (CheckProcess() == false)
                            {
                                goto Start;
                            }

                            if (Setting.Balance && BalancePower())
                            {
                                Call.Key.Press(Call.Key.Balance_Power_Distribution, 100, Call.Key.DelayPower);
                                Setting.Balance = false; Process.Engine = 4; Process.System = 4; Process.Weapon = 4;
                                goto Start;
                            }
                            else
                            { Setting.Balance = false; }

                            Setting.Loop++;

                            #region Processor Logic
                            if (Difference.System == Difference.Max)
                            {
                                Call.Key.Press(Call.Key.Divert_Power_To_Systems, 100, Call.Key.DelayPower);

                                if (Process.System < 7)
                                {
                                    Process.System = Process.System + 2;

                                    if (Process.Engine == 0 || Process.Weapon == 0)
                                    {
                                        if (Process.Engine != 0)
                                        {
                                            Process.Engine = Process.Engine - 2;
                                        }
                                        else if (Process.Weapon != 0)
                                        {
                                            Process.Weapon = Process.Weapon - 2;
                                        }
                                    }
                                    else
                                    {
                                        Process.Engine--;
                                        Process.Weapon--;
                                    }
                                }
                                else
                                {
                                    Process.System = 8;

                                    if (Process.Engine == 1)
                                    {
                                        Process.Engine = 0;
                                    }
                                    else if (Process.Weapon == 1)
                                    {
                                        Process.Weapon = 0;
                                    }
                                }
                            }
                            else if (Difference.Engine == Difference.Max)
                            {
                                Call.Key.Press(Call.Key.Divert_Power_To_Engines, 100, Call.Key.DelayPower);

                                if (Process.Engine < 7)
                                {
                                    Process.Engine = Process.Engine + 2;

                                    if (Process.System == 0 || Process.Weapon == 0)
                                    {
                                        if (Process.System != 0)
                                        {
                                            Process.System = Process.System - 2;
                                        }
                                        else if (Process.Weapon != 0)
                                        {
                                            Process.Weapon = Process.Weapon - 2;
                                        }
                                    }
                                    else
                                    {
                                        Process.System--;
                                        Process.Weapon--;
                                    }
                                }
                                else
                                {
                                    Process.Engine = 8;

                                    if (Process.System == 1)
                                    {
                                        Process.System = 0;
                                    }
                                    else if (Process.Weapon == 1)
                                    {
                                        Process.Weapon = 0;
                                    }
                                }
                            }
                            else if (Difference.Weapon == Difference.Max)
                            {
                                Call.Key.Press(Call.Key.Divert_Power_To_Weapons, 100, Call.Key.DelayPower);

                                if (Process.Weapon < 7)
                                {
                                    Process.Weapon = Process.Weapon + 2;

                                    if (Process.System == 0 || Process.Engine == 0)
                                    {
                                        if (Process.System != 0)
                                        {
                                            Process.System = Process.System - 2;
                                        }
                                        else if (Process.Engine != 0)
                                        {
                                            Process.Engine = Process.Engine - 2;
                                        }
                                    }
                                    else
                                    {
                                        Process.System--;
                                        Process.Engine--;
                                    }
                                }
                                else
                                {
                                    Process.Weapon = 8;

                                    if (Process.System == 1)
                                    {
                                        Process.System = 0;
                                    }
                                    else if (Process.Engine == 1)
                                    {
                                        Process.Engine = 0;
                                    }
                                }
                            }
                            #endregion
                        }

                        Logger.DebugLine(MethodName, "Processor Power: S" + Process.System + " | E" + Process.Engine + " | W" + Process.Weapon, Logger.Yellow);
                        Process.SetPower();
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "An Exception Occured While Setting Power.");

                Monitor.Exit(Setting.Lock_Power);
            }
        }

        public void SetRecorded()
        {
            Set(Recorded.Weapon, Recorded.System, Recorded.Engine);
        }

        public void Engines(int Number)
        {
            while (Number != 0)
            {
                Call.Key.Press(Call.Key.Divert_Power_To_Engines, 100, Call.Key.DelayPower);
                Number--;
            }
        }

        public void Weapons(int Number)
        {
            while (Number != 0)
            {
                Call.Key.Press(Call.Key.Divert_Power_To_Weapons, 100, Call.Key.DelayPower);
                Number--;
            }
        }

        public void Systems(int Number)
        {
            while (Number != 0)
            {
                Call.Key.Press(Call.Key.Divert_Power_To_Systems, 100, Call.Key.DelayPower);
                Number--;
            }
        }

        #region Set Power Logic Support
        private bool CheckProcess(bool Answer = true)
        {
            string MethodName = "Power Manager (Process Check)";

            string DebugText = "Process Check Passed, Working On The Lastest Order.";
            string Color = Logger.Blue;

            if (Setting.Processed != Setting.Request)
            {
                DebugText = "Process Check Failed, Newer Order Detected...";
                Color = Logger.Yellow;

                Game.System = Process.System;
                Game.Engine = Process.Engine;
                Game.Weapon = Process.Weapon;
                Answer = false;
            }

            if (Answer == false)
            { Logger.DebugLine(MethodName, DebugText, Color); }

            return Answer;
        }

        private bool CheckHyperspace(string MethodName, bool Answer = true)
        {
            string DebugText = "";

            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName, true) == false)
            {
                while (Check.Environment.Space(IEnums.Hyperspace, false, MethodName, true) == false)
                {
                    Thread.Sleep(100);
                }

                DebugText = "Environment Check Failed (Hyperspace)";
                Answer = false;
            }

            if (Answer == false)
            { Logger.DebugLine(MethodName, DebugText, Logger.Yellow); }

            return Answer;
        }

        private bool BalancePower(bool Answer = false)
        {
            string MethodName = "Power Manager (Balance Power Check)";

            string DebugText = "Do Not Need To Balance.";
            string Color = Logger.Blue;

            if (Process.Engine == 4 && Process.Weapon == 4 && Process.System == 4)
            {
                Answer = false;
            }
            //if (Difference.AbsoluteMax == Difference.Max)
            //{
            //    Answer = true;
            //    DebugText = "Balance Power Check Passed, Do Not Need To Balance.";
            //    Color = Logger.Blue;
            //}
            //else
            else if (Difference.AbsoluteMax >= 4)
            {
                Answer = true;
                DebugText = "Balanceing Power...";
                Color = Logger.Yellow;
            }
            else if (Order.System == Order.Engine || Order.System == Order.Weapon || Order.Engine == Order.Weapon)
            {
                Answer = true;
                DebugText = "Balanceing Power...";
                Color = Logger.Yellow;
            }

            Logger.DebugLine(MethodName, DebugText, Color);

            return Answer;
        }
        #endregion
    }
}
