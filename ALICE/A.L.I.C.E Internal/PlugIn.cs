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

        public static readonly string VersionShort = "3.4.0.0";
        public static readonly string VersionLong = "3.4.0.0 (Closed Beta 1.12)";
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
                if (Check.Internal.TriggerEvents(true, MethodName) == false)
                {
                    Logger.Simple("Project A.L.I.C.E " + IPlatform.Version + " Initializing...", Logger.Purple);

                    Paths.Load_UpdateBindsFile();
                    Call.Key.GetGameBinds();

                    switch (IPlatform.Interface)
                    {
                        case IPlatform.Interfaces.Internal:
                            break;
                        case IPlatform.Interfaces.VoiceAttack:
                            Call.Key.Load_VoiceAttackVariables();
                            break;
                        case IPlatform.Interfaces.VoiceMacro:
                            break;
                        default:
                            break;
                    }

                    ISynthesizer.Response.Load(Paths.ALICE_Response);
                    Data.Load_Modules();
                    Call.Power.Initialize();
                    ISettings.User = ISettings.User.Load(ISettings.SettingsUser, MethodName);

                    if (Journal == true)
                    {
                        Thread journal = new Thread((ThreadStart)(() => { JournalReader.EventProcessor(); }))
                        { IsBackground = true }; journal.Start();
                    }

                    if (Status == true)
                    {
                        Thread jsonreader = new Thread((ThreadStart)(() => { M_Json.Start(); }))
                        { IsBackground = true }; jsonreader.Start();
                    }

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
