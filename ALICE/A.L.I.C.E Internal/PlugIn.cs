using ALICE_Actions;
using ALICE_Debug;
using ALICE_Interface;
using ALICE_Monitors;
using ALICE_Settings;
using ALICE_Synthesizer;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using SysDiag = System.Diagnostics;

namespace ALICE_Internal
{
    public static class PlugIn
    {
        //public static Monitor_Json M_Json = new Monitor_Json(true, false, true, false, false, false, false, false, true);
        //public static Monitor_Journal M_Journal = new Monitor_Journal();

        public static readonly decimal DataVersion = 340.0M;

        public enum Output { TTS, File, External }
        public static Output Respond { get; set; }

        public static bool MasterAudio = true;
        public static bool CommandAudio = false;
        public static string Audio = "TTS";                 //TTS, File, External
        public static bool DebugMode = false;
        public static bool ExtendedLogging = false;
        public static bool VariableLogging = false;
        public static bool KeybindLogging = false;

        /// <summary>
        /// Initializes the core features.
        /// </summary>
        /// <param name="Interface">Sets the interface type.(</param>
        /// <param name="Journal">New Journal Reader Thread.</param>
        /// <param name="Status">New Status.json Reader Thread.</param>
        /// <param name="Config">New Settings Monitor Thread.</param>
        public static void Initialize(bool Journal, bool Status, bool Config)
        {
            string MethodName = "Initialize";

            try
            {
                //Initilize If We Have Started Up Yet.
                if (ICheck.Initialized(MethodName) == false)
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
                 
                    //Log Plugin Information
                    Logger.Simple("Project A.L.I.C.E " + IPlatform.Version + " Initializing...", Logger.Purple);
                    Logger.AliceLog("Project A.L.I.C.E " + IPlatform.Version + " (Open Beta 1.3.5)");

                    //Execute External Command
                    IPlatform.ExecuteCommand("Startup Configuration");
                    
                    //Sleep To Allow Platform Time To Process
                    Thread.Sleep(1000);

                    //Settings File Verification
                    ISettings.FileVerification();

                    //Settings Monitor
                    if (Config == true)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, "Initializing Settings Monitor...", Logger.Blue);

                        //Start Journal Monitor On New Thread
                        Thread config = new Thread((ThreadStart)(() => { IMonitors.Settings.Start(); }))
                        { IsBackground = true }; config.Start();
                    }

                    //Wait For Settings To Load
                    while (ICheck.InitializedSettings(MethodName) == false)
                    {
                        //Sleep
                        Thread.Sleep(100);
                    }

                    //Load Last Settings
                    Thread.Sleep(100);
                    ISettings.StartupLoad();

                    //Start Keybinds Monitor On New Thread
                    Thread Key = new Thread((ThreadStart)(() => { IMonitors.Keybinds.Start(); }))
                    { IsBackground = true }; Key.Start();                    
                    
                    //Debug Logger
                    Logger.DebugLine(MethodName, "Loading Response Files...", Logger.Blue);

                    //Load Responses
                    ISynthesizer.Response.Load(Paths.ALICE_Response);
                    ISynthesizer.Response.Load(Paths.ALICE_ResponseUser, true);

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Loading Module Data...", Logger.Blue);

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Starting Power Management...", Logger.Blue);

                    //Initialize Power Monitoring
                    Call.Power.Initialize();

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Loading Last Written User Settings...", Logger.Blue);

                    //Journal Monitor
                    if (Journal == true)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, "Initializing Journal Monitor...", Logger.Blue);

                        //Start Journal Monitor On New Thread
                        Thread journal = new Thread((ThreadStart)(() => { IMonitors.Journal.Start(); }))
                        { IsBackground = true }; journal.Start();
                    }

                    //Status Monitor
                    if (Status == true)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, "Initializing Status Monitor...", Logger.Blue);

                        //Start Status Monitor On New Thread
                        Thread jsonreader = new Thread((ThreadStart)(() => { IMonitors.Json.Start(); }))
                        { IsBackground = true }; jsonreader.Start();
                    }

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Initializing Variable Monitors...", Logger.Blue);

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

                    //Wait Till Initialzied
                    while (IMonitors.Journal.Settings.Initialized == false)
                    {
                        Thread.Sleep(100);
                    }

                    //Configure Plugin Variables
                    IPlatform.Configure();
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
