using ALICE_Debug;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Settings;
using System;
using System.IO;
using System.Threading;

namespace ALICE_Monitors
{
    public class Monitor_Keybinds : MonitorBase
    {
        #region Properties
        //Settings
        public MonitorSettings Settings { get; set; }

        //FileData Objects
        public FileKeybinds Keybinds = new FileKeybinds(false);
        #endregion

        #region Constructors
        /// <summary>
        /// Will create a Settings Monitor with all the options set by the User.
        /// </summary>
        /// <param name="E">Enable Monitor</param>
        /// <param name="I">Monitor Initiliaztion State On Start</param>
        /// <param name="R">AutoRestart on Failure / Exceptions</param>
        /// <param name="Use">Monitor User.Settings</param>
        /// <param name="Shi">Monitor Shipyard.Settings</param>
        /// <param name="Fir">Monitor Firegroup.Settings</param>
        public Monitor_Keybinds(bool E, bool I, bool R, bool Key = true)
        {
            Settings = new MonitorSettings(E, I, R);
            Keybinds = new FileKeybinds(Key);
        }
        #endregion

        public void Start()
        {
            string MethodName = "Keybinds Monitor";
           
            try
            {                               
                //Enter Monitor State And Lock The Door Behind Us...
                if (Monitor.TryEnter(Settings.Lock))
                {
                    #region Pre Monitoring Items
                    //Retrieve Config Variables From Platform
                    PlugIn.KeybindLogging = IGet.External.KeybindLogging(MethodName);

                    //Log Setting
                    if (PlugIn.VariableLogging)
                    {
                        Logger.Log(MethodName, "Keybind Logging Enabled", Logger.Yellow);
                    }

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Verifying Alice Binds File...", Logger.Blue);

                    //Check Alice Binds File
                    Paths.Load_UpdateBindsFile();

                    //Debug Logger                    
                    Logger.DebugLine(MethodName, "Loading Keybinds...", Logger.Blue);
                    #endregion

                    //Start Monitoring
                    Start: try
                    {                        
                        while (Settings.Enabled)
                        {
                            //Sleep for 1/10th Of A Second
                            Thread.Sleep(100);

                            //Check keybinds File
                            try
                            {
                                //Get Initial File Info
                                if (Keybinds.Enabled && Keybinds.File == null)
                                {
                                    Keybinds.GetFileInfo();
                                }

                                //Valitdate Keybinds File
                                if (Keybinds.Name != ISettings.User.BindsFile())
                                {
                                    Keybinds = new FileKeybinds(true, ISettings.User.BindsFile());
                                    Keybinds.GetFileInfo();
                                }

                                //Proces New Changes
                                if (Keybinds.Enabled && Keybinds.File != null && CheckFile(ref Keybinds.File, ref Keybinds.InitialLoad))
                                {
                                    Update1(); Keybinds.InitialLoad = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "[Keybinds] The Hamster Is Trying To Fix His Wheel...");
                            }
                
                            //Check Initialized
                            if (Settings.Initialized == false)
                            {
                                //Log Init
                                Settings.Initialized = true;
                            }
                        }                         
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(MethodName, "Exception: " + ex);
                        Logger.Exception(MethodName, "[Monitor Error] The Hamsters Are Running Away...");

                        if (Settings.AutoRestart)
                        {
                            //Log Restarting
                            Logger.Exception(MethodName, "[Restarting] We Caught The Hamsters, Lets Try Again...");
                            goto Start;
                        }
                        else
                        {
                            //Log Exiting
                            Logger.Exception(MethodName, "[Stopping] The Hamsters Got Away...");
                        }
                    }
                    finally
                    {
                        Monitor.Exit(Settings.Lock);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "[Monitor Failed] All The Hamsters Died, The Wheels Stopped Turning...");
            }
        }

        public override void Update1()
        {
            string MethodName = "User Settings (Update)";

            try
            {
                //Load Game Binds
                IKeyboard.LoadKeybinds();
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "[Failed] The Hamster Made A Mistake And Forgot What He Was Doing...");
            }
        }        

        #region Settings
        public class FileKeybinds : FileBase
        {
            public FileKeybinds(bool E, string F = "A.L.I.C.E Profile.3.0.binds")
            {
                File = null;
                Stamp = new DateTime();
                Enabled = E;
                Name = F;
                Dir = new DirectoryInfo(Paths.Binds_Location);
            }
        }       
        #endregion
    }
}
