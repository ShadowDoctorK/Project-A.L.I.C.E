using ALICE_Internal;
using System;
using System.IO;

namespace ALICE_Monitors
{
    public static partial class IMonitors
    {
        /// <summary>
        /// Static Instance Of the Journal Monitor.
        /// </summary>
        public static Monitor_Journal Journal = new Monitor_Journal();

        /// <summary>
        /// Static Instance Of The Json Mointor.
        /// </summary>
        public static Monitor_Json Json = new Monitor_Json(
            true,       //Enabled
            false,      //Initialization State
            true,       //Auto Restart On Failure
            false,      //Cargo.Json Monitoring
            false,      //Market.Json Monitoring
            false,      //Modules.Json Monitoring
            false,      //Outfitting.Json Monitoring
            false,      //Shipyard.Json Monitoring
            true);      //Status.Json Monitoring

        /// <summary>
        /// Static Instance Of The Settings Mointor.
        /// </summary>
        public static Monitor_Settings Settings = new Monitor_Settings(
            true,       //Enabled
            false,      //Initialization State
            true,       //Auto Restart On Failure
            true,       //Monitor User.Settings
            true,       //Monitor Shipyard.Settings
            true);      //Monitor Firegroup.Settings
    }

    public class MonitorBase
    {
        /// <summary>
        /// Checks Referenced File for Changes.
        /// </summary>
        /// <param name="F">FileInfo you want to check.</param>
        /// <returns>True for Updates</returns>
        public bool CheckFile(ref FileInfo F, ref bool InitialLoad)
        {
            string MethodName = "Monitor (Check File)";

            try
            {
                //Check File Exist
                if (File.Exists(F.FullName) == false)
                {
                    //Log File Doesn't Exist
                    Logger.DebugLine(MethodName, F.Name + " Does Not Exist", Logger.Blue);
                    return false;
                }

                //Check For Newer Write Time.
                FileInfo Temp = new FileInfo(F.FullName);
                if (Temp.LastWriteTime != F.LastWriteTime || InitialLoad)
                {
                    //Save New FileInfo, Return True.
                    Logger.DebugLine(MethodName, F.Name + " Updated", Logger.Blue);
                    F = Temp; return true;
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "(Failed) The Check Hamster Made A Mistake And Forgot What He Was Doing...");
            }

            //No Change, Return False.
            return false;
        }

        /// <summary>
        /// Opens A Readonly FileStream with ReadWrite sharing.
        /// </summary>
        /// <param name="FilePath">Path of your file.</param>
        /// <returns>Returns a FileStream.</returns>
        public FileStream GetFileStream(string FilePath)
        {
            return new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        #region Virtual Update Methods
        //Virtual Methods To Allow Custom Control Of Incomming Changes

        public virtual void Update1()
        {
            //No Logic
        }

        public virtual void Update2()
        {
            //No Logic
        }

        public virtual void Update3()
        {
            //No Logic
        }

        public virtual void Update4()
        {
            //No Logic
        }

        public virtual void Update5()
        {
            //No Logic
        }

        public virtual void Update6()
        {
            //No Logic
        }
        #endregion

        public class FileBase
        {
            public FileInfo File = null;
            public DateTime Stamp { get; set; }
            public bool Enabled { get; set; }
            public string Name { get; set; }
            public bool InitialLoad = true;
            public DirectoryInfo Dir = new DirectoryInfo(Paths.ALICE_Settings);

            public void GetFileInfo()
            {
                string MethodName = "Mointor (File Target)";

                try
                {
                    //Find FileInfo
                    foreach (FileInfo Temp in Dir.EnumerateFiles(Name, SearchOption.TopDirectoryOnly))
                    {
                        File = Temp;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "(Failed) The File Hamster Made A Mistake And Forgot What He Was Doing...");
                }

                //Check If We Located File
                if (File != null)
                {
                    Logger.DebugLine(MethodName, Name + " Located", Logger.Blue);
                }
                else
                {
                    Logger.DebugLine(MethodName, Name + " Not Found", Logger.Red);
                }
            }
        }

        public class MonitorSettings
        {
            public bool Enabled { get; set; }
            public bool Initialized { get; set; }
            public bool AutoRestart { get; set; }
            public object Lock { get; set; }

            public MonitorSettings(bool E, bool I, bool R)
            {
                Lock = new object();
                Enabled = E;
                Initialized = I;
                AutoRestart = R;
            }
        }
    }
}
