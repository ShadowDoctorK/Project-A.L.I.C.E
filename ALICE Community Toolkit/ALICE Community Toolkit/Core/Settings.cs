using ALICE_Internal;
using ALICE_Settings;
using System;
using System.IO;

namespace ALICE_Community_Toolkit
{
    public static class Settings
    {
        /// <summary>
        /// Globally Enable or Disables Saving Settings. Used For UI Updates.
        /// </summary>
        public static bool Save = true;

        /// <summary>
        /// Tracks If The User Interface Has Finished Its Initial Update.
        /// </summary>
        public static bool InitUI = false;

        public static SettingsUser User = new SettingsUser().Load();
        public static SettingsShipyard Shipyard = new SettingsShipyard().Load();
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
                if (File.Exists(Paths.ALICE_Settings + "Shipyard.Settings") == false)
                {
                    //Save New Default File
                    Shipyard.Save();
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

        public static bool InitShipyard()
        {
            return Monitor_Settings.Shipyard.InitialLoad;
        }

        public static bool InitFiregroups()
        {
            return Monitor_Settings.Firegroups.InitialLoad;
        }
    }    
}