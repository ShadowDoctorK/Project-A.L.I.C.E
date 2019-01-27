using System.Collections.Generic;
using System.Threading;
using ALICE_Objects;
using ALICE_Synthesizer;
using System.Media;
using System.IO;
using ALICE_Internal;

namespace ALICE_Actions
{
    public class System_Targeting
    {
        string MethodName = "Targeting System";

        public List<string> WhitelistPilot { get; set; }
        public List<string> WhiteListFaction { get; set; }
        public List<string> BlacklistPilot { get; set; }
        public List<string> BlackListFaction { get; set; }

        public int Interval = 1000;
        public bool Hostile = false;
        public bool Wait_Targeted = false;
        public bool Flag_Pause = false;
        public bool Flag_Stop = false;
        public bool Flag_Series = false;
        public bool Flag_Detailed = false;
        public bool Flag_Hostile = false;
        public bool Flag_Wanted = false;
        public bool Flag_Maintain = false;
        public bool Flag_Blacklist = false;
        public bool Save_Targeted = false;

        public System_Targeting()
        {
            BlackListFaction = new List<string>();
            BlacklistPilot = new List<string>();
            WhiteListFaction = new List<string>();
            WhitelistPilot = new List<string>();
        }

        #region Whitelist / Blacklist
        public void WhiteList_Reset(bool CommandAudio)
        {
            if (WhitelistPilot.Count != 0 || WhiteListFaction.Count != 0)
            {
                WhitelistPilot.Clear();
                WhiteListFaction.Clear();

                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Positive.Default, true)
                        .Phrase(GN_Targeting_System.Whitelist_Clear),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion
            }
            else
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(GN_Targeting_System.Whitelist_Empty),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion
            }
        }

        public void WhiteList_Pilot(bool CommandAudio)
        {
            string Pilot = IObjects.TargetCurrent.PilotName_Localised;

            if (Pilot != null)
            {
                if (WhitelistPilot.Contains(Pilot) == false)
                {
                    WhitelistPilot.Add(Pilot);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Targeting_System.Whitelist_Pilot)
                            .Replace("[PILOT]", IObjects.TargetCurrent.PilotName_Localised),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Targeting_System.Whitelist_Contains),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
        }

        public void WhiteList_Faction(bool CommandAudio)
        {
            string Faction = IObjects.TargetCurrent.Faction;

            if (Faction != null)
            {
                if (WhiteListFaction.Contains(Faction) == false)
                {
                    WhiteListFaction.Add(Faction);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Targeting_System.Whitelist_Faction)
                            .Replace("[PILOT]", IObjects.TargetCurrent.Faction),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Targeting_System.Whitelist_Contains),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
        }

        public void BlackList_Reset(bool CommandAudio)
        {
            if (BlacklistPilot.Count != 0 || BlackListFaction.Count != 0)
            {
                BlacklistPilot.Clear();
                BlackListFaction.Clear();

                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Positive.Default, true)
                        .Phrase(GN_Targeting_System.Blacklist_Clear),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion
            }
            else
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(GN_Targeting_System.Blacklist_Empty),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion
            }
        }

        public void BlackList_Pilot(bool CommandAudio)
        {
            string Pilot = IObjects.TargetCurrent.PilotName_Localised;

            if (Pilot != null)
            {
                if (BlacklistPilot.Contains(Pilot) == false)
                {
                    BlacklistPilot.Add(Pilot);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Targeting_System.Blacklist_Pilot)
                            .Replace("[PILOT]", IObjects.TargetCurrent.PilotName_Localised),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Targeting_System.Blacklist_Contains),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
        }

        public void BlackList_Faction(bool CommandAudio)
        {
            string Faction = IObjects.TargetCurrent.Faction;

            if (Faction != null)
            {
                if (BlackListFaction.Contains(Faction) == false)
                {
                    BlackListFaction.Add(Faction);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Targeting_System.Blacklist_Faction)
                            .Replace("[PILOT]", IObjects.TargetCurrent.Faction),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Targeting_System.Blacklist_Contains),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
        }
        #endregion

        #region Series Scan Methods
        public void SeriesScan(bool CommandAudio)
        {
            string MethodName = "Series Scan";

            #region Validation Checks
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(GN_Targeting_System.Hyperspace),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            if (Check.Environment.Vehicle(IVehicles.V.SRV, false, MethodName) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(GN_Targeting_System.SRV),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }
            #endregion

            #region Scan Logic
            //Begin Scan...
            if (Flag_Series == false)
            {
                Flag_Series = true;

                try
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Targeting_System.Scan_Start)
                            .Phrase(GN_Targeting_System.Scan_Start_Hostile_Modifier, false, Hostile),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    //While Not In Hyperspace & Vehicle Is Not SRV...
                    while (Check.Environment.Space(IEnums.Hyperspace, false, MethodName, true) == true && Check.Environment.Vehicle(IVehicles.V.SRV, false, MethodName, true) == true)
                    {
                        NewTarget:

                        #region Check: Validation / State
                        if (Scan_CheckValadation(MethodName) == false || Scan_CheckState(MethodName) == false)
                        { return; }
                        #endregion

                        #region Aquire Target
                        Flag_Maintain = false; decimal Attempt = 0; while (Scan_AquireTarget(MethodName) == false)
                        {
                            #region Check: Validation / State
                            if (Scan_CheckValadation(MethodName) == false || Scan_CheckState(MethodName) == false)
                            { return; }
                            #endregion

                            Attempt++; if (Attempt > 10)
                            {
                                #region Audio
                                if (PlugIn.Audio == "TTS")
                                {
                                    Speech.Speak
                                        (
                                        "".Phrase(GN_Targeting_System.Scan_No_Targets),
                                        CommandAudio
                                        );
                                }
                                else if (PlugIn.Audio == "File") { }
                                else if (PlugIn.Audio == "External") { }
                                #endregion

                                return;
                            }
                        }
                        #endregion

                        #region Evaluate: Target

                        #region Check: Target Lock
                        if (Scan_TargetLock(MethodName, CommandAudio) == false)
                        { goto NewTarget; }
                        #endregion

                        #region Check: Validation / State
                        if (Scan_CheckValadation(MethodName) == false || Scan_CheckState(MethodName) == false)
                        { return; }
                        #endregion

                        #region Wait: Scan Level 3
                        if ((Flag_Detailed == true || Flag_Wanted == true || Flag_Hostile == true || Flag_Blacklist == true) && IObjects.TargetCurrent.ScanStage < 3) //Add Subsystem Scans.
                        {
                            Logger.DebugLine(MethodName, "Waiting For Complete Target Information (Scan Level 3)", Logger.Blue);

                            #region Sound Effect
                            string FilePath = Paths.ALICE_Audio_Files + "Scan_AdditionData.wav";
                            SoundPlayer player = new SoundPlayer();

                            if (File.Exists(FilePath))
                            {
                                player.SoundLocation = FilePath;
                                player.Play();
                            }
                            #endregion

                            bool Result = Scan_LevelThree(MethodName, CommandAudio);
                            if (Result == false) { goto NewTarget; }
                        }
                        #endregion

                        #region WhiteList Check
                        if (WhiteList(MethodName) == false)
                        { goto NewTarget; }
                        #endregion

                        #region BlackList Check
                        //if (BlackList(MethodName) == true)
                        //{ Flag_Maintain = true; }
                        #endregion

                        //End: Target Evaluation
                        #endregion

                        #region Evaluate: Maintain Lock
                        if (Scan_Maintain(MethodName, CommandAudio) == true)
                        {
                            #region Target Subsystem
                            //Under Construction.
                            #endregion

                            #region Maintain Lock
                            while (Flag_Maintain == true)
                            {
                                #region Check: Validation / State
                                if (Scan_CheckValadation(MethodName) == false || Scan_CheckState(MethodName) == false)
                                { return; }
                                #endregion

                                #region Check: Target Lock
                                if (IObjects.TargetCurrent.Targeted == false)
                                {

                                }

                                if (Scan_TargetLock(MethodName, CommandAudio) == false)
                                { goto NewTarget; }
                                #endregion
                            }
                            #endregion
                        }
                        #endregion

                        Thread.Sleep(Interval);
                    }
                }
                finally
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Targeting_System.Scan_Terminated),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    Flag_Maintain = false;
                    Flag_Series = false;
                    Flag_Stop = false;
                    Flag_Pause = false;
                    Flag_Series = false;
                    Wait_Targeted = false;
                }
            }
            //Resume Scan...
            else if (Flag_Series == true)
            {
                Flag_Pause = false;
            }
            #endregion
        }

        public bool Scan_AquireTarget(string MethodName, bool Answer = false)
        {
            #region Validation / State Check
            if (Scan_CheckValadation(MethodName) == false || Scan_CheckState(MethodName) == false)
            { return Answer; }
            #endregion

            #region Target Variables
            string DebugText = "No Target Dectected", Color = Logger.Yellow;
            Wait_Targeted = true;
            #endregion

            #region Cycle Targets
            if (Hostile == false) { Targeting.Cycle_Targets(1, true); }
            else if (Hostile == true) { Targeting.Cycle_Hostile_Targets(1, true); }
            #endregion

            #region Target Detection
            decimal WaitCount = 0; while (Wait_Targeted == true)
            {
                WaitCount++; Thread.Sleep(100); if (WaitCount == 20)
                { return Answer; }
            }
            DebugText = "Target Aquired"; Color = Logger.Blue;
            Answer = true;
            #endregion

            Logger.DebugLine(MethodName, DebugText, Color);
            return Answer;
        }

        public bool Scan_CheckState(string MethodName, bool Answer = true)
        {
            if (Flag_Pause == true) { Logger.DebugLine(MethodName, "Pausing Scan.", Logger.Blue); Scan_Pause(MethodName); }
            if (Flag_Stop == true) { Answer = false; Logger.DebugLine(MethodName, "Terminating Scan.", Logger.Yellow); }

            return Answer;
        }

        public bool Scan_CheckValadation(string MethodName, bool Answer = true)
        {
            bool Environment = Check.Environment.Space(IEnums.Hyperspace, false, MethodName, true);
            bool Vehicle = Check.Environment.Vehicle(IVehicles.V.SRV, false, MethodName, true);

            if (Environment == false) { Answer = false; Logger.DebugLine(MethodName, "Environment Check Failed. (In Hyperspace)", Logger.Yellow); }
            if (Vehicle == false) { Answer = false; Logger.DebugLine(MethodName, "Vehicle Check Failed. (In SRV)", Logger.Yellow); }

            return Answer;
        }

        public bool Scan_TargetLock(string MethodName, bool CommandAudio)
        {
            bool Answer = IObjects.TargetCurrent.Targeted;

            if (IObjects.TargetCurrent.Targeted == false)
            {
                Logger.DebugLine(MethodName, "Target Lock Check Failed. (No Target Lock)", Logger.Yellow);

                if (Save_Targeted == true)
                {
                    NoTargetLock();
                    Save_Targeted = Answer;
                }
            }

            return Answer;
        }

        public bool Scan_Maintain(string MethodName, bool CommandAudio, bool Answer = false)
        {
            if (IObjects.TargetCurrent.LegalStatus.Contains("Wanted") && Flag_Wanted == true)
            {
                Logger.DebugLine(MethodName, "Wanted Target, Maintaining Lock...", Logger.Blue);

                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Targeting_System.Scan_Target_Aquired),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                Flag_Maintain = true;
                Answer = true;
            }
            else if (IObjects.TargetCurrent.LegalStatus.Contains("Enemy") && Flag_Hostile == true)
            {
                Logger.DebugLine(MethodName, "Wanted Target, Maintaining Lock...", Logger.Blue);

                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak(""
                        .Phrase(GN_Targeting_System.Scan_Target_Aquired),
                        CommandAudio);
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                Flag_Maintain = true;
                Answer = true;
            }
            else if (Flag_Blacklist == true && BlackList(MethodName) == true)
            {
                Logger.DebugLine(MethodName, "Blacklist Target, Maintaining Lock...", Logger.Blue);

                Flag_Maintain = true;
                Answer = true;
            }

            return Answer;
        }

        public void Scan_Stop()
        {
            Flag_Pause = false;
            Flag_Series = false;
        }

        public void Scan_Pause(string MethodName)
        {
            decimal PauseCount1 = 0,
                    PauseCount2 = 0,
                    PauseCount3 = 0;

            while (Flag_Pause == true)
            {
                PauseCount1++; Thread.Sleep(100); if (PauseCount1 == 10)
                {
                    PauseCount1 = 0; PauseCount2++; if (PauseCount2 == 15)
                    {
                        Logger.DebugLine(MethodName, "Scan Paused...", Logger.Yellow);

                        PauseCount2 = 0; PauseCount3++;

                        #region Sound Effect
                        string FilePath = Paths.ALICE_Audio_Files + "Scan_Paused.wav";
                        SoundPlayer player = new SoundPlayer();

                        if (File.Exists(FilePath))
                        {
                            player.SoundLocation = FilePath;
                            player.Play();
                        }
                        #endregion
                    }

                    if (PauseCount3 == 8)
                    {
                        Scan_Stop(); Logger.DebugLine(MethodName, "Terminating Scan From Paused State...", Logger.Yellow);
                        Flag_Stop = true; return;
                    }
                }
                if (Flag_Stop == true) { Scan_Stop(); return; }
            }
        }

        public bool Scan_LevelThree(string MethodName, bool CommandAudio)
        {
            bool Wait = true; while (Wait == true)
            {
                if (IObjects.TargetCurrent.ScanStage == 3)
                {
                    Wait = false;
                    return true;
                }

                if (Scan_TargetLock(MethodName, CommandAudio) == false)
                {
                    return false;
                }

                if (Scan_CheckState(MethodName) == false || Scan_CheckValadation(MethodName) == false)
                {
                    return false;
                }

                Thread.Sleep(250);
            }
            return true;
        }

        public bool WhiteList(string MethodName, bool Answer = true)
        {
            string Pilot = IObjects.TargetCurrent.PilotName_Localised;
            string Faction = IObjects.TargetCurrent.Faction;

            if (WhitelistPilot.Contains(Pilot) == true)
            {
                Logger.DebugLine(MethodName, Pilot + " Is On The White List. Aquring New Target...", Logger.Yellow);
                Answer = false;
            }

            if (WhiteListFaction.Contains(Faction) == true)
            {
                Logger.DebugLine(MethodName, Faction + " Is On The White List. Aquring New Target...", Logger.Yellow);
                Answer = false;
            }

            return Answer;
        }

        public bool BlackList(string MethodName, bool Answer = false)
        {
            string Pilot = IObjects.TargetCurrent.PilotName_Localised;
            string Faction = IObjects.TargetCurrent.Faction;

            if (BlacklistPilot.Contains(Pilot) == true)
            {
                Logger.DebugLine(MethodName, Pilot + " Is On The Black List.", Logger.Yellow);
                Answer = true;
            }

            if (BlackListFaction.Contains(Faction) == true)
            {
                Logger.DebugLine(MethodName, Faction + " Is On The Black List.", Logger.Yellow);
                Answer = true;
            }

            return Answer;
        }
        #endregion

        #region Subsystem Methods
        public void Subsystem_Target(string System, bool CommandAudio)
        {
            string MethodName = "Subsystem Target";

            int Count = 0; while (IObjects.TargetCurrent.Subsystem.Name != System)
            {
                
                if (Scan_TargetLock(MethodName, CommandAudio) == false) { return; }
                
                if (IObjects.TargetCurrent.Subsystem.Name != System)
                {
                    Targeting.Cycle_Subsystems(1, false, false);
                    Wait_Targeted = true;
                }

                #region Target Detection
                decimal WaitCount = 0; while (Wait_Targeted == true)
                {
                    WaitCount++; Thread.Sleep(100); if (WaitCount == 20)
                    { return; }
                }
                #endregion

                Count++; if (Count > 24)
                {
                    Logger.DebugLine(MethodName, System + " Was Not Found On The Target", Logger.Yellow);
                    return;
                }
            }
        }
        #endregion

        #region Sound Effects
        public void NoTargetLock()
        {
            try
            {
                string FilePath = Paths.ALICE_Audio_Files + "Scan_TargetLost.wav";
                SoundPlayer P = new SoundPlayer();

                if (File.Exists(FilePath)) { P.SoundLocation = FilePath; P.Play(); }
                else { Logger.Error(MethodName, "Unable To Locate Audio File: " + FilePath, Logger.Red); }
            }
            catch (System.Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }
        #endregion
    }
}
