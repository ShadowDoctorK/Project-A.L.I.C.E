using System;
using System.IO;
using System.Threading;
using ALICE_Events;
using ALICE_Actions;
using ALICE_Interface;
using ALICE_JournalReader;
using ALICE_Synthesizer;
using ALICE_Monitors;
using ALICE.Properties;
using SysDiag = System.Diagnostics;
using System.Linq;
using ALICE_Settings;

namespace ALICE_Internal
{
    public static class PlugIn
    {
        public static Monitor_Json M_Json = new Monitor_Json(true, false, true, false, false, false, false, false, true);

        public static readonly string VersionShort = "3.4.0.2";
        public static readonly string VersionLong = "3.4.0.2 (Open Beta 1.2.3)";
        public static readonly decimal DataVersion = 340.0M;

        public enum Output { TTS, File, External }
        public static Output Respond { get; set; }

        public static bool MasterAudio = true;
        public static bool CommandAudio = false;
        public static string Audio = "TTS";                 //TTS, File, External
        public static bool DebugMode = false;
        public static bool ExtendedLogging = false;

        /// <summary>
        /// Initializes the core features.
        /// </summary>
        /// <param name="Interface">Sets the interface type.(</param>
        /// <param name="Journal">New Journal Reader Thread.</param>
        /// <param name="Status">New Status.json Reader Thread.</param>
        public static void Initialize(bool Journal, bool Status)
        {
            string MethodName = "Initialize";

            try
            {
                //Initilize If We Have Started Up Yet.
                if (Check.Internal.TriggerEvents(true, MethodName) == false)
                {
                    //Profile Monitor (Voice Macro Only)
                    switch (IPlatform.Interface)
                    {                        
                        case IPlatform.Interfaces.VoiceMacro:

                            if (IVoiceMacro.CheckAcivteProfile("Project A.L.I.C.E") == false)
                            {
                                //Simple Logger
                                Logger.Simple("Configured For Voice Macro. Standing By To Initialize...", Logger.Purple);
                            }

                            //Monitor Profiles For Project A.L.I.C.E Profile To Be The Active Profile.
                            bool Wait = true; while (Wait)
                            {
                                //Check Profile
                                if (IVoiceMacro.CheckAcivteProfile("Project A.L.I.C.E"))
                                {
                                    //Initialize
                                    Wait = false;
                                }

                                //Pause
                                Thread.Sleep(1000);
                            }
                            break;

                        default:
                            break;
                    }


                    //Simple Logger
                    Logger.Simple("Project A.L.I.C.E " + IPlatform.Version + " Initializing...", Logger.Purple);

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Verifying Alice Binds File...", Logger.Blue);

                    //Check Alice Binds File
                    Paths.Load_UpdateBindsFile();

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Loading Game Binds...", Logger.Blue);

                    //Load Game Binds
                    Call.Key.GetGameBinds();

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Loading Keybinds...", Logger.Blue);

                    //Load Keybinds
                    switch (IPlatform.Interface)
                    {
                        case IPlatform.Interfaces.Internal:
                            break;
                        case IPlatform.Interfaces.VoiceAttack:
                            Call.Key.Load_VoiceAttackVariables();
                            break;
                        case IPlatform.Interfaces.VoiceMacro:
                            Call.Key.Load_VoiceMacroVariables();
                            break;
                        default:
                            break;
                    }

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Loading Response Files...", Logger.Blue);

                    //Load Responses
                    ISynthesizer.Response.Load(Paths.ALICE_Response);

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Loading Module Data...", Logger.Blue);

                    //Load Module Data
                    Data.Load_Modules();

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Starting Power Management...", Logger.Blue);

                    //Initialize Power Monitoring
                    Call.Power.Initialize();

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Loading Last Written User Settings...", Logger.Blue);

                    //Load User Settings
                    ISettings.User = ISettings.User.Load(ISettings.SettingsUser, MethodName);
                   
                    //Journal Monitor
                    if (Journal == true)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, "Initializing Journal Monitor...", Logger.Blue);

                        //Start Journal Monitor On New Thread
                        Thread journal = new Thread((ThreadStart)(() => { JournalReader.EventProcessor(); }))
                        { IsBackground = true }; journal.Start();
                    }

                    //Status Monitor
                    if (Status == true)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, "Initializing Status Monitor...", Logger.Blue);

                        //Start Status Monitor On New Thread
                        Thread jsonreader = new Thread((ThreadStart)(() => { M_Json.Start(); }))
                        { IsBackground = true }; jsonreader.Start();
                    }

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Initializing Variable Monitors...", Logger.Blue);

                    //Start Variable Monitors
                    Monitors.StartMonitors
                        (
                        true, //Ship
                        true, //Json
                        true, //Internal
                        true, //Panel
                        true, //Order
                        true  //Report
                        );

                    //Open Toolkit If None Are Detected
                    if (GetToolkitInstances() < 1)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, "Opening The Community Toolkit...", Logger.Blue);

                        //Open A New Toolkit Instance
                        Thread tooklit =
                        new Thread((ThreadStart)(() =>
                        {
                            try
                            {
                                if (File.Exists(Paths.DLL_Location + @"\ALICE Community Toolkit.exe"))
                                {
                                    System.Diagnostics.Process.Start(Paths.DLL_Location + @"\ALICE Community Toolkit.exe");
                                }
                            }
                            catch (Exception)
                            {
                                Logger.Error(MethodName, "Something Went Wrong While Opening The Community Toolkit...", Logger.Red);
                            }
                        }))
                        { IsBackground = true }; tooklit.Start();
                    }
                    else
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, "Community Toolkit Is Already Open...", Logger.Blue);
                    }
                    
                    //Execute Alice Online Logic
                    IEvents.AliceOnline.Logic();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(MethodName, "Execption: " + ex, Logger.Red);
                Logger.Error(MethodName, "Something Went Wrong While Initializing The Plug-In...", Logger.Red);
            }
        }

        /// <summary>
        /// Returns the number of ALICE Community Toolkit Process' running.
        /// </summary>
        /// <returns></returns>
        public static int GetToolkitInstances()
        {
            return SysDiag.Process.GetProcesses().Where(x => x.ProcessName == "ALICE Community Toolkit").Count();
        }
    }
}
