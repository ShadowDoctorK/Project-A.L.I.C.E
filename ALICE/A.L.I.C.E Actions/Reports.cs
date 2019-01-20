using ALICE_Objects;
using ALICE_Synthesizer;
using ALICE_Internal;
using ALICE_Core;

namespace ALICE_Actions
{
    public class Reports
    {
        //#region Shared Methods / Functions
        //public bool Report_Update(bool CurrentState, bool NewState, string ItemName)
        //{
        //    if (CurrentState == true)
        //    {
        //        if (NewState == true)
        //        {
        //            #region Audio
        //            if (PlugIn.Audio == "TTS")
        //            {
        //                Speech.Response
        //                    (
        //                    "".Speak(Negative.Default, true)
        //                    .Speak(Report_Generic.Currently_Enabled)
        //                    .Replace("[ITEM]", ItemName),
        //                    true
        //                    );
        //            }
        //            else if (PlugIn.Audio == "File") { }
        //            else if (PlugIn.Audio == "External") { }
        //            #endregion
        //        }
        //        else if (NewState == false)
        //        {
        //            #region Audio
        //            if (PlugIn.Audio == "TTS")
        //            {
        //                Speech.Response
        //                    (
        //                    "".Speak(Positive.Default, true)
        //                    .Speak(Report_Generic.Disabled)
        //                    .Replace("[ITEM]", ItemName),
        //                    true
        //                    );
        //            }
        //            else if (PlugIn.Audio == "File") { }
        //            else if (PlugIn.Audio == "External") { }
        //            #endregion
        //        }
        //    }
        //    else if (CurrentState == false)
        //    {
        //        if (NewState == true)
        //        {
        //            #region Audio
        //            if (PlugIn.Audio == "TTS")
        //            {
        //                Speech.Response
        //                    (
        //                    "".Speak(Positive.Default, true)
        //                    .Speak(Report_Generic.Enabled)
        //                    .Replace("[ITEM]", ItemName),
        //                    true
        //                    );
        //            }
        //            else if (PlugIn.Audio == "File") { }
        //            else if (PlugIn.Audio == "External") { }
        //            #endregion
        //        }
        //        else if (NewState == false)
        //        {
        //            #region Audio
        //            if (PlugIn.Audio == "TTS")
        //            {
        //                Speech.Response
        //                    (
        //                    "".Speak(Negative.Default, true)
        //                    .Speak(Report_Generic.Currently_Disabled)
        //                    .Replace("[ITEM]", ItemName),
        //                    true
        //                    );
        //            }
        //            else if (PlugIn.Audio == "File") { }
        //            else if (PlugIn.Audio == "External") { }
        //            #endregion
        //        }
        //    }

        //    return NewState;
        //}
        //#endregion

        //#region Reports
        //public bool Report_Update(bool CurrentState, bool NewState, string ItemName)
        //{
        //    if (CurrentState == true)
        //    {
        //        if (NewState == true)
        //        {
        //            #region Audio
        //            if (PlugIn.Audio == "TTS")
        //            {
        //                Speech.Response
        //                    (
        //                    "".Speak(Negative.Default, true)
        //                    .Speak(Report_Generic.Currently_Enabled)
        //                    .Replace("[ITEM]", ItemName),
        //                    true
        //                    );
        //            }
        //            else if (PlugIn.Audio == "File") { }
        //            else if (PlugIn.Audio == "External") { }
        //            #endregion
        //        }
        //        else if (NewState == false)
        //        {
        //            #region Audio
        //            if (PlugIn.Audio == "TTS")
        //            {
        //                Speech.Response
        //                    (
        //                    "".Speak(Positive.Default, true)
        //                    .Speak(Report_Generic.Disabled)
        //                    .Replace("[ITEM]", ItemName),
        //                    true
        //                    );
        //            }
        //            else if (PlugIn.Audio == "File") { }
        //            else if (PlugIn.Audio == "External") { }
        //            #endregion
        //        }
        //    }
        //    else if (CurrentState == false)
        //    {
        //        if (NewState == true)
        //        {
        //            #region Audio
        //            if (PlugIn.Audio == "TTS")
        //            {
        //                Speech.Response
        //                    (
        //                    "".Speak(Positive.Default, true)
        //                    .Speak(Report_Generic.Enabled)
        //                    .Replace("[ITEM]", ItemName),
        //                    true
        //                    );
        //            }
        //            else if (PlugIn.Audio == "File") { }
        //            else if (PlugIn.Audio == "External") { }
        //            #endregion
        //        }
        //        else if (NewState == false)
        //        {
        //            #region Audio
        //            if (PlugIn.Audio == "TTS")
        //            {
        //                Speech.Response
        //                    (
        //                    "".Speak(Negative.Default, true)
        //                    .Speak(Report_Generic.Currently_Disabled)
        //                    .Replace("[ITEM]", ItemName),
        //                    true
        //                    );
        //            }
        //            else if (PlugIn.Audio == "File") { }
        //            else if (PlugIn.Audio == "External") { }
        //            #endregion
        //        }
        //    }

        //    return NewState;
        //}

        //public void FuelScoop(bool State)
        //{
        //    string Item = "Fuel Scooping";
        //    Monitors.Report.Settings.FuelScoop = Report_Update(Monitors.Report.Settings.FuelScoop, State, Item);
        //    Monitors.Report.SaveValues();
        //}

        //public void FuelStatus(bool State)
        //{
        //    string Item = "Fuel Status";
        //    Monitors.Report.Settings.FuelStatus = Report_Update(Monitors.Report.Settings.FuelStatus, State, Item);
        //    Monitors.Report.SaveValues();
        //}

        //public void MaterialCollected(bool State)
        //{
        //    string Item = "Material Collection";
        //    Monitors.Report.Settings.MaterialCollected = Report_Update(Monitors.Report.Settings.MaterialCollected, State, Item);
        //    Monitors.Report.SaveValues();
        //}

        //public void MaterialRefined(bool State)
        //{
        //    string Item = "Material Refining";
        //    Monitors.Report.Settings.MaterialRefined = Report_Update(Monitors.Report.Settings.MaterialRefined, State, Item);
        //    Monitors.Report.SaveValues();
        //}

        //public void NoFireZone(bool State)
        //{
        //    string Item = "No Fire Zone";
        //    Monitors.Report.Settings.NoFireZone = Report_Update(Monitors.Report.Settings.NoFireZone, State, Item);
        //    Monitors.Report.SaveValues();
        //}

        //public void StationStatus(bool State)
        //{
        //    string Item = "Station Status";
        //    Monitors.Report.Settings.StationStatus = Report_Update(Monitors.Report.Settings.StationStatus, State, Item);
        //    Monitors.Report.SaveValues();
        //}

        //public void ShieldState(bool State)
        //{
        //    string Item = "Shield State";
        //    Monitors.Report.Settings.ShieldState = Report_Update(Monitors.Report.Settings.ShieldState, State, Item);
        //    Monitors.Report.SaveValues();
        //}

        //public void CollectedBounty(bool State)
        //{
        //    string Item = "Target Bounty";
        //    Monitors.Report.Settings.CollectedBounty = Report_Update(Monitors.Report.Settings.CollectedBounty, State, Item);
        //    Monitors.Report.SaveValues();
        //}

        //public void TargetEnemy(bool State)
        //{
        //    string Item = "Enemy Faction";
        //    Monitors.Report.Settings.TargetEnemy = Report_Update(Monitors.Report.Settings.TargetEnemy, State, Item);
        //    Monitors.Report.SaveValues();
        //}

        //public void TargetWanted(bool State)
        //{
        //    string Item = "Wanted Target";
        //    Monitors.Report.Settings.TargetWanted = Report_Update(Monitors.Report.Settings.TargetWanted, State, Item);
        //    Monitors.Report.SaveValues();
        //}

        //public void Masslock(bool State)
        //{
        //    string Item = "Masslock";
        //    Monitors.Report.Settings.Masslock = Report_Update(Monitors.Report.Settings.Masslock, State, Item);
        //    Monitors.Report.SaveValues();
        //}
        //#endregion

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
                            Speech.Response
                                (
                                "".Speak(Shields.Online),
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
                            Speech.Response
                                (
                                "".Speak(Shields.Offline),
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
