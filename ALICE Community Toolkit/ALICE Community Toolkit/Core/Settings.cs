using ALICE_Internal;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ALICE_Community_Toolkit
{
    public static class TKSettings
    {
        /// <summary>
        /// Globally Enable or Disables Saving Settings. Used For UI Updates.
        /// </summary>
        public static bool Save = true;

        /// <summary>
        /// Tracks If The User Interface Has Finished Its Initial Update.
        /// </summary>
        public static bool InitUI = false;

        public static SettingsUser User = new SettingsUser();
        public static SettingsHardpoints Firegroup = new SettingsHardpoints();

        /// <summary>
        /// Static Instance Of The Settings Mointor.
        /// </summary>
        public static Monitor_Settings Monitor_Settings = new Monitor_Settings(
            true,       //Enabled
            false,      //Initialization State
            true,       //Auto Restart On Failure
            true,       //Monitor User.Settings
            true,       //Monitor Shipyard.Settings
            true);      //Monitor Firegroup.Settings

        public static void FileVerification()
        {
            try
            {
                //Check File Exist
                if (File.Exists(Paths.ALICE_Settings + "User.Settings") == false)
                {
                    //Save New Default File
                    User.Save();
                }

                //Check File Exist
                if (File.Exists(Paths.ALICE_Settings + "Firegroup.Settings") == false)
                {
                    //Save New Default File
                    Firegroup.Save();
                }
            }
            catch (Exception ex)
            {
                //Debug Logger
                Logger.Exception("ISettings (File Validation)", "Exception: " + ex);
            }
        }

        public static bool InitUser()
        {
            return Monitor_Settings.User.InitialLoad;
        }

        public static bool InitFiregroups()
        {
            return Monitor_Settings.Firegroups.InitialLoad;
        }
    }

    public class SettingsUtilities
    {
        #region Base Save/Load Methods
        /// <summary>
        /// Generic Loader for Deserializing JSON settings.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="FileName">The name of the target file.</param>
        /// <param name="FilePath">The path of the target file. Default Path is the Settings Folder.</param>
        /// <returns></returns>
        public object LoadValues<T>(string FileName, string FilePath = null)
        {
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
                        }
                    }
                }

                return Temp;
            }
            catch (Exception)
            {
                return Temp;
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }

        /// <summary>
        /// Generic Saver for Serializing object settings to JSON.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="Settings">The Object</param>
        /// <param name="FileName">The name of the target file.</param>
        /// <param name="FilePath">The path of the target file. Default Path is the Settings Folder.</param>
        public void SaveValues<T>(object Settings, string FileName, string FilePath = null)
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
        #endregion

        #region Json Conversions
        /// <summary>
        /// Will Serialize The Passed Object And Return A String.
        /// </summary>
        /// <typeparam name="T">(Type) The Objects Type</typeparam>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method</param>
        /// <param name="O">(Object) The Object You Want To Serialize</param>
        /// <returns></returns>
        public string Serialize<T>(string M, object O)
        {
            try
            {
                return JsonConvert.SerializeObject((T)O);
            }
            catch (Exception ex)
            {
                Logger.Exception(M, "Exception: " + ex);
            }

            return null;
        }
        #endregion
    }
}