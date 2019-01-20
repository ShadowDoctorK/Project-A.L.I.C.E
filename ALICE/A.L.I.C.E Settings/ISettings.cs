using ALICE_Actions;
using ALICE_Internal;
using ALICE_Objects;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ALICE_Settings
{
    public static class ISettings
    {
        public static readonly string SettingsUser = "CurrentUser";
        public static readonly string SettingsFiregroup = "CurrentFiregroup";

        public static string Commander { get; set; }
        public static string MothershipFingerPrint { get; set; }

        public static Settings_User User = new Settings_User();
        public static Settings_User Reference = new Settings_User();
        public static Settings_User Toolkit = new Settings_User();

        public static Settings_Firegroups Firegroup = new Settings_Firegroups();

        #region Miscellaneous
        public static bool LogAllBodies = true;
        #endregion

        #region Propery Updates
        /// <summary>
        /// Updates the Commander Property for ISettings and any Subsettings being handled by ISettings.
        /// </summary>
        /// <param name="CMDRName">The Commanders Name</param>
        public static void U_Commander(string MethodName, string CMDRName)
        {
            //Try Loading Commanders Settings
            ISettings.User = ISettings.User.Load(CMDRName, MethodName);
            //Will Update Name If Default Is Returned
            ISettings.Commander = CMDRName;
            //Saves Settings After Update
            ISettings.User.Save(MethodName);
        }

        /// <summary>
        /// Updates The MothershipFingerPrint Property for ISettings and any Subsettings being handled by ISettings.
        /// </summary>
        /// <param name="Ship">The type of ship.</param>
        /// <param name="ShipID">This ships ID</param>
        public static void U_MothershipFingerPrint(string MethodName, string Ship, decimal ShipID)
        {
            //Update Property
            ISettings.MothershipFingerPrint = ShipID + " " + Ship + " (" + Commander + ")";
            ISettings.Firegroup = ISettings.Firegroup.Load();
            ISettings.Firegroup.Save(MethodName);
        }
        #endregion

        #region Save/Load Methods
        /// <summary>
        /// Checks/Loads the Commanders User Settings if the File Exists. Else it will load the defaults and create a User Settings file.
        /// </summary>
        /// <param name="S">The Settings Object</param>
        /// <param name="CMDRName">The Commanders Name</param>
        /// <returns>Returns the Users Settings or Default if its not found</returns>
        public static Settings_User Load(this Settings_User S, string CMDRName, string MethodName)
        {
            //Create Default Settings
            if (S == null) { S = new Settings_User(); }

            try
            {
                //Check & Load Settings
                if (File.Exists(Paths.ALICE_Settings + CMDRName + ".Settings"))
                {
                    S = (Settings_User)LoadValues<Settings_User>(CMDRName + ".Settings");
                    Logger.DebugLine(MethodName, CMDRName + ".Settings Loaded", Logger.Blue);
                }
                //Create New Settings File
                else
                {
                    S.Commander = CMDRName; S.Save(MethodName);
                    Logger.Log(MethodName, "Created " + CMDRName + "'s User Settings.", Logger.Purple);
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception:" + ex);
                Logger.Exception(MethodName, "Something Went Wrong Loading The Users Settings, Returned Default Settings");
            }

            //Return Settings
            return S;
        }

        /// <summary>
        /// Try To Save The User Settings. Catches, Logs and Reports Exceptions.
        /// </summary>
        public static void Save(this Settings_User S, string MethodName)
        {
            try
            {
                S.TimeStamp = DateTime.UtcNow;
                ISettings.SaveValues<Settings_User>(S, S.Commander + ".Settings");
                ISettings.SaveValues<Settings_User>(S, SettingsUser + ".Settings");
                Logger.DebugLine(MethodName, "User Settings Saved", Logger.Blue);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception:" + ex);
                Logger.Exception(MethodName, "Something Went Wrong And Settings Were Not Saved.");
            }
        }

        /// <summary>
        /// Checks/Loads the Motherships Firegroup Configuration if the File Exist. Else it will load the defaults and create a new File.
        /// </summary>
        /// <param name="S">The Settings Object</param>
        /// <returns>Returns the Ships Settings or Default if its not found</returns>
        public static Settings_Firegroups Load(this Settings_Firegroups S)
        {
            string MethodName = "Firegroup Settings (Load)";
            string FileName = MothershipFingerPrint + ".FGConfig";

            //Create Default Settings
            if (S == null) { S = new Settings_Firegroups(); } 

            try
            {
                //Check & Load Settings
                if (File.Exists(Paths.ALICE_Settings + FileName))
                {
                    S = (Settings_Firegroups)LoadValues<Settings_Firegroups>(FileName);
                }
                //Create New Settings File
                else
                {
                    ISettings.Firegroup.ShipAssignment = MothershipFingerPrint; ISettings.Firegroup.Save(MethodName);
                    Logger.Log(MethodName, "Created " + MothershipFingerPrint + "'s Firegroup Settings.", Logger.Purple);
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception:" + ex);
                Logger.Exception(MethodName, "Something Went Wrong Loading The Firegroup Settings, Returned Default Settings");
            }

            //Return Settings
            return S;
        }

        /// <summary>
        /// Try To Save The Ships Firegroup Settings. Catches, Logs and Reports Exceptions.
        /// </summary>
        public static void Save(this Settings_Firegroups S, string MethodName)
        {
            try
            {
                ISettings.SaveValues<Settings_Firegroups>(S, S.ShipAssignment + ".FGConfig");
                ISettings.SaveValues<Settings_Firegroups>(S, SettingsFiregroup + ".FGConfig");
                Logger.DebugLine(MethodName, "Firegroup Settings Saved", Logger.Blue);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception:" + ex);
                Logger.Exception(MethodName, "Something Went Wrong And Firegroup Settings Were Not Saved.");
            }
        }
        #endregion

        #region Base Save/Load Methods
        /// <summary>
        /// Generic Loader for Deserializing JSON settings.
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="FileName">The name of the target file.</param>
        /// <param name="FilePath">The path of the target file. Default Path is the Settings Folder.</param>
        /// <returns></returns>
        public static object LoadValues<T>(string FileName, string FilePath = null)
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
        public static void SaveValues<T>(object Settings, string FileName, string FilePath = null)
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
    }
}
