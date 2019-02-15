using ALICE_Internal;
using ALICE_Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ALICE_Community_Toolkit
{
    public static class Data
    {
        public static Settings_User User = new Settings_User();
        public static Settings_Firegroups Firegroup = new Settings_Firegroups();
        public static object LockFlag = new object();
        public static object SaveLockFlag = new object();
        public static bool Enabled = true;
        public static string TimeStampUser = null;
        public static string TimeStampFiregroup = null;
        public static bool SaveFiregroup = true;
        public static bool SettingInit = false;
        public static readonly DirectoryInfo DirSettings = new DirectoryInfo(Paths.ALICE_Settings);

        public static List<string> Group = new List<string>()
        {
            "None",
            "Alpha",
            "Bravo",
            "Charlie",
            "Delta",
            "Echo",
            "Foxtrot",
            "Golf",
            "Hotel"
        };

        public static List<string> Fire = new List<string>()
        {
            "None",
            "Primary",
            "Secondary"
        };

        #region Support Methods / Functions
        public static void SaveUserSettings()
        {
            SaveValues<Settings_User>(User, ISettings.SettingsUser + ".Settings");
        }

        public static void LoadUserSettings()
        {
            string MethodName = "User Settings (Load)";

            User = (Settings_User)LoadValues<Settings_User>(ISettings.SettingsUser + ".Settings");
            Logger.Log(MethodName, "User Settings Loaded", Logger.Yellow);
        }

        public static void SaveFiregroupSettings()
        {
            string MethodName = "Firegroup Settings (Save)";

            if (Monitor.TryEnter(SaveLockFlag))
            {
                Start:
                try
                {
                    if (SaveFiregroup == false) { return; }
                    SaveValues<Settings_Firegroups>(Firegroup, ISettings.SettingsFiregroup + ".FGConfig");
                    Logger.Log(MethodName, "Firegroup Settings Saved", Logger.Yellow);
                }
                catch (Exception)
                {
                    Logger.Exception(MethodName, "Couldn't Access The File, Trying Again...");
                    Thread.Sleep(100); goto Start;
                }
                finally
                {
                    Monitor.Exit(SaveLockFlag);
                }
            }
        }

        public static void LoadFiregroupSettings()
        {
            string MethodName = "Firegroup Settings (Load)";

            Firegroup = (Settings_Firegroups)LoadValues<Settings_Firegroups>(ISettings.SettingsFiregroup + ".FGConfig");
            Logger.Log(MethodName, "Firegroup Settings Loaded", Logger.Yellow);
        }

        public static SolidColorBrush GetTextColor(bool Value)
        {
            SolidColorBrush Brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            if (Value) { Brush = new SolidColorBrush(Color.FromRgb(0, 255, 0)); }

            return Brush;
        }

        public static void SaveValues<T>(object Settings, string FileName, string FilePath = null)
        {
            string MethodName = "(Toolkit) Save Values";

            try
            {
                if (FilePath == null) { FilePath = Paths.ALICE_Settings; }

                using (FileStream FS = new FileStream(FilePath + FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter file = new StreamWriter(FS))
                    {
                        var Line = JsonConvert.SerializeObject((T)Settings);
                        file.WriteLine(Line);
                    }
                }
            }
            catch (Exception)
            {
                Logger.Exception(MethodName, "Couldn't Access The File, Trying Again...");
            }
        }

        public static object LoadValues<T>(string FileName, string FilePath = null)
        {
            string MethodName = "(Toolkit) Load Values";

            T Temp = default(T);
            if (FilePath == null) { FilePath = Paths.ALICE_Settings; }
            if (FileName == null) { return null; }

            FileStream FS = null;
            try
            {
                if (File.Exists(FilePath + FileName))
                {
                    FS = new FileStream(FilePath + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        while (!SR.EndOfStream)
                        {
                            string Line = SR.ReadLine();
                            Temp = JsonConvert.DeserializeObject<T>(Line);
                            Logger.Log(MethodName, "Loaded Settings", Logger.Yellow);
                        }
                    }
                }

                return Temp;
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception" + ex);
                Logger.Exception(MethodName, "Somthing Went Wrong While Loading Values");
                return Temp;
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }

        public static void StartMonitor()
        {
            string MethodName = "(Toolkit) Monitor";
            Thread thread =
            new Thread((ThreadStart)(() =>
            {
                try
                {
                    if (Monitor.TryEnter(LockFlag))
                    {
                        while (Enabled)
                        {
                            Thread.Sleep(1000);

                            if (CheckSettings(ISettings.SettingsUser + ".Settings"))
                            {
                                LoadUserSettings();
                                MainWindow.UpdateButtons();
                            }

                            if (CheckSettings(ISettings.SettingsFiregroup + ".FGConfig"))
                            {
                                LoadFiregroupSettings();
                                MainWindow.UpdateButtons();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception" + ex);
                    Logger.Exception(MethodName, "Somthing Went Wrong With The Monitor");
                }
                finally
                {
                    Monitor.Exit(LockFlag);
                }
            }))
            { IsBackground = true }; thread.Start();
        }

        public static bool CheckSettings(string FileName)
        {
            string MethodName = "(Toolkit) Check Settings";
            string TimeStamp = null; switch (FileName)
            {
                case "CurrentUser.Settings":
                    TimeStamp = TimeStampUser;
                    break;
                case "CurrentFiregroup.FGConfig":
                    TimeStamp = TimeStampFiregroup;
                    break;
                default:
                    Logger.Log(MethodName, "File Name Does Not Match Expected Options.", Logger.Yellow);
                    return false;
            }

            try
            {
                foreach (FileInfo File in DirSettings.EnumerateFiles(FileName, SearchOption.TopDirectoryOnly))
                {
                    if (TimeStamp == null || TimeStamp != File.LastWriteTime.ToString())
                    {
                        switch (FileName)
                        {
                            case "CurrentUser.Settings":
                                TimeStampUser = File.LastWriteTime.ToString();
                                break;
                            case "CurrentFiregroup.FGConfig":
                                TimeStampFiregroup = File.LastWriteTime.ToString();
                                break;
                        }
                        Logger.Log(MethodName, "Settings Update Detected", Logger.Yellow);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception" + ex);
                Logger.Exception(MethodName, "We Encountered An Error While Checking The Settings File");
                return false;
            }
        }
        #endregion
    }
}
