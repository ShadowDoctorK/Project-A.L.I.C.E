
using ALICE_Events;
using ALICE_Interface;
using ALICE_Internal;
using ALICE_Status;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ALICE_Settings
{
    public static class ISettings
    {
        public static bool LogAllBodies = true;

        //Collections Of Settings
        public static SettingsUser User = new SettingsUser();       
        public static SettingsShipyard Shipyard = new SettingsShipyard();
        public static SettingsHardpoints Firegroups = new SettingsHardpoints();

        //Under Construction
        public static SettingsPlugIn Plugin = new SettingsPlugIn();

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
                if (File.Exists(Paths.ALICE_Settings + "Shipyard.Settings") == false)
                {
                    //Save New Default File
                    Shipyard.Save();
                }

                //Check File Exist
                if (File.Exists(Paths.ALICE_Settings + "Firegroup.Settings") == false)
                {
                    //Save New Default File
                    Firegroups.Save();
                }
            }
            catch (Exception ex)
            {
                //Debug Logger
                Logger.Exception("ISettings (File Validation)", "Exception: " + ex);
            }
        }

        public static void StartupLoad()
        {
            string MethodName = "ISettings (Startup)";
            try
            {
                //Set Last Commander
                IStatus.Commander = User.Commander;

                //Get Last Ship Loadout
                string Ship = Shipyard.GetShip(MethodName, IStatus.Commander, Shipyard.LastID);

                //Process Ship Loadout
                if (Ship != "None")
                {
                    //Deserialize Loadout
                    Loadout I = (Loadout)INewtonSoft.Deserialize(Ship, 
                        IEvents.Types.Get(IEnums.Events.Loadout), true, IEnums.Events.Loadout);

                    //Update Event Collection
                    IEvents.Event.Record(IEnums.Events.Loadout, I);

                    //Process Event
                    IEvents.Process(IEnums.Events.Loadout);
                }

                //Load Firegroup Settings
                Firegroups.GetConfig(MethodName, IStatus.Mothership.ID, IStatus.Mothership.FingerPrint);
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);
            }
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
