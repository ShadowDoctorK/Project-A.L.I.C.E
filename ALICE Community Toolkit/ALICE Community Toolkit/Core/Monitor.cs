using ALICE_Internal;
using ALICE_Settings;
using System;
using System.IO;
using System.Threading;

namespace ALICE_Community_Toolkit
{
    public class Monitor_Settings : ALICE_Monitors.MonitorBase
    {
        #region Properties
        //Settings
        public MonitorSettings Settings { get; set; }

        //FileData Objects
        public FileUser User = new FileUser(false);        
        public FileFiregroups Firegroups = new FileFiregroups(false);
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
        public Monitor_Settings(bool E, bool I, bool R, bool Use = true, bool Shi = true, bool Fir = true)
        {
            Settings = new MonitorSettings(E, I, R);
            User = new FileUser(Use);            
            Firegroups = new FileFiregroups(Fir);
        }
        #endregion

        public void Start()
        {
            string MethodName = "Settings Monitor";

            try
            {
                //Enter Monitor State And Lock The Door Behind Us...
                if (Monitor.TryEnter(Settings.Lock))
                {
                    //Start Monitoring
                    Start: try
                    {
                        while (Settings.Enabled)
                        {
                            //Sleep for 1/10th Of A Second
                            Thread.Sleep(100);

                            //Check User.Settings
                            try
                            {
                                if (User.Enabled && User.File == null) { User.GetFileInfo(); }
                                if (User.Enabled && User.File != null && CheckFile(ref User.File, ref User.InitialLoad))
                                {
                                    Update1(); User.InitialLoad = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "[User.Settings] The Hamster Is Trying To Fix His Wheel...");
                            }

                            //Check Firegroup.Settings
                            try
                            {
                                if (Firegroups.Enabled && Firegroups.File == null) { Firegroups.GetFileInfo(); }
                                if (Firegroups.Enabled && Firegroups.File != null && CheckFile(ref Firegroups.File, ref Firegroups.InitialLoad))
                                {
                                    Update3(); Firegroups.InitialLoad = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "[Firegroup.Settings] The Hamster Is Trying To Fix His Wheel...");
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
                var Temp = new SettingsUser().Load();
                TKSettings.User = Temp;
                MainWindow.UpdateButtons();
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "[Failed] The Hamster Made A Mistake And Forgot What He Was Doing...");
            }
        }

        public override void Update3()
        {
            string MethodName = "Firegroup Settings (Update)";

            try
            {
                var Temp = new SettingsHardpoints().Load();
                TKSettings.Firegroup = Temp;
                MainWindow.UpdateButtons();
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "[Failed] The Hamster Made A Mistake And Forgot What He Was Doing...");
            }
        }

        #region Settings
        public class FileFiregroups : FileBase
        {
            public FileFiregroups(bool E)
            {
                File = null;
                Stamp = new DateTime();
                Enabled = E;
                Name = "Firegroup.Settings";
                Dir = new DirectoryInfo(Paths.ALICE_Settings);
            }
        }

        public class FileUser : FileBase
        {
            public FileUser(bool E)
            {
                File = null;
                Stamp = new DateTime();
                Enabled = E;
                Name = "User.Settings";
                Dir = new DirectoryInfo(Paths.ALICE_Settings);
            }
        }
        #endregion
    }
}
