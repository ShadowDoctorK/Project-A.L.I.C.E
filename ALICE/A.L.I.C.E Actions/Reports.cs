using ALICE_Objects;
using ALICE_Synthesizer;
using ALICE_Internal;
using ALICE_Core;

namespace ALICE_Actions
{
    public class Reports
    {        
        //This will be removed and merged with the correct Objects
        //IE. Equipment, Status, or other object controls.
        #region NewReports Class
        public Cls_FSDCharging FSDCharging = new Cls_FSDCharging();
        public Cls_FSDCooldown FSDCooldown = new Cls_FSDCooldown();
        public Cls_GPSLocation GPSLocation = new Cls_GPSLocation();
        public Cls_Masslock MassLock = new Cls_Masslock();
        public Cls_Shield Shield = new Cls_Shield();
        public Cls_SilentRunning SilentRunning = new Cls_SilentRunning();

        public class Cls_Base
        {
            public bool Recorded { get; set; }
            public string ClassName { get; set; }
        }

        public class Cls_Shield : Cls_Base
        {
            public Cls_Shield()
            {
                ClassName = "Shield ";
                Recorded = false;
            }

            public void Status(bool Status)
            {
                string MethodName = ClassName + "Status";

                #region Status == Recorded
                if (Status == Recorded) { return; }
                #endregion

                #region Status != Recorded
                else if (Status != Recorded)
                {
                    if (Status == true)
                    {
                        Logger.DebugLine(MethodName, "True", Logger.Yellow);

                        #region Audio
                        if (PlugIn.Audio == "TTS")
                        {
                            Speech.Speak
                                (
                                "".Phrase(EQ_Shields.Online),
                                true,
                                Check.Internal.JsonInitialized(true, MethodName)                                
                                );
                        }
                        else if (PlugIn.Audio == "File") { }
                        else if (PlugIn.Audio == "External") { }
                        #endregion
                    }
                    else if (Status == false)
                    {
                        Logger.DebugLine(MethodName, "False", Logger.Yellow);

                        #region Audio
                        if (PlugIn.Audio == "TTS")
                        {
                            Speech.Speak
                                (
                                "".Phrase(EQ_Shields.Offline),
                                true,
                                Check.Internal.JsonInitialized(true, MethodName)
                                );
                        }
                        else if (PlugIn.Audio == "File") { }
                        else if (PlugIn.Audio == "External") { }
                        #endregion
                    }

                    Recorded = Status;
                }
                #endregion
            }
        }

        public class Cls_Masslock : Cls_Base
        {
            public Cls_Masslock()
            {
                ClassName = "Masslock ";
                Recorded = false;
            }

            public void Status(bool Status)
            {
                string MethodName = ClassName + "Status";

                #region Status == Recorded
                if (Status == Recorded)
                {
                    return;
                }
                #endregion

                #region Status != Recorded
                else if (Status != Recorded)
                {
                    if (Status == true)
                    {
                        Logger.DebugLine(MethodName, "True", Logger.Yellow);
                    }
                    else if (Status == false)
                    {
                        Logger.DebugLine(MethodName, "False", Logger.Yellow);
                    }

                    Recorded = Status;
                }
                #endregion
            }
        }

        public class Cls_FSDCharging : Cls_Base
        {
            public Cls_FSDCharging()
            {
                ClassName = "FSD Charging ";
                Recorded = false;
            }

            public void Status(bool Status)
            {
                string MethodName = ClassName + "Status";

                #region Status == Recorded
                if (Status == Recorded) { return; }
                #endregion

                #region Status != Recorded
                else if (Status != Recorded)
                { 
                    if (Status == true && Check.Internal.TriggerEvents(true, MethodName) == true)
                    {
                        Logger.DebugLine(MethodName, "True", Logger.Yellow);
                        IEquipment.FrameShiftDrive.ChargingStart(true);
                    }
                    else if (Status == false && Check.Internal.TriggerEvents(true, MethodName) == true)
                    {
                        Logger.DebugLine(MethodName, "False", Logger.Yellow);
                        //Logger.Log(MethodName, "Developer Needs To Add Frameshift Drive Powering Down Audio... Remind Him.", Logger.Red);
                    }

                    Recorded = Status;
                }
                #endregion
            }
        }

        public class Cls_FSDCooldown : Cls_Base
        {
            public Cls_FSDCooldown()
            {
                ClassName = "FSD Cooldown ";
                Recorded = false;
            }

            public void Status(bool Status)
            {
                string MethodName = ClassName + "Status";

                #region Status == Recorded
                if (Status == Recorded)
                {
                    return;
                }
                #endregion

                #region Status != Recorded
                else if (Status != Recorded)
                {
                    if (Status == true)
                    {
                        Logger.DebugLine(MethodName, "True", Logger.Yellow);
                    }
                    else if (Status == false)
                    {
                        Logger.DebugLine(MethodName, "False", Logger.Yellow);
                    }

                    Recorded = Status;
                }
                #endregion
            }
        }

        public class Cls_SilentRunning : Cls_Base
        {
            public Cls_SilentRunning()
            {
                ClassName = "Silent Running ";
                Recorded = false;
            }

            public void Status(bool Status)
            {
                string MethodName = ClassName + "Status";

                #region Status == Recorded
                if (Status == Recorded)
                {
                    return;
                }
                #endregion

                #region Status != Recorded
                else if (Status != Recorded)
                {
                    if (Status == true)
                    {
                        Logger.DebugLine(MethodName, "True", Logger.Yellow);
                    }
                    else if (Status == false)
                    {
                        Logger.DebugLine(MethodName, "False", Logger.Yellow);
                    }

                    Recorded = Status;
                }
                #endregion
            }
        }

        public class Cls_GPSLocation : Cls_Base
        {
            public Cls_GPSLocation()
            {
                ClassName = "GPS Location ";
                Recorded = false;
            }

            public void Status(bool Status)
            {
                string MethodName = ClassName + "Status";

                #region Status == Recorded
                if (Status == Recorded)
                {
                    return;
                }
                #endregion

                #region Status != Recorded
                else if (Status != Recorded)
                {
                    if (Status == true)
                    {
                        Logger.DebugLine(MethodName, "True", Logger.Yellow);
                    }
                    else if (Status == false)
                    {
                        Logger.DebugLine(MethodName, "False", Logger.Yellow);
                    }

                    Recorded = Status;
                }
                #endregion
            }
        }
        #endregion
    }
}
