using System;
using System.IO;
using System.Runtime.InteropServices;
using WinForms = System.Windows.Forms;
using ALICE_Interface;

namespace ALICE_Internal
{
    public static class Paths
    {
        #region File Names
        public static readonly string FILE_BindsFile = "A.L.I.C.E Profile.3.0.binds";
        public static readonly string FILE_AliceManual = "Project A.L.I.C.E.pdf";
        #endregion

        #region Folder Names
        public static readonly string Folder_Default = @"\Default";
        #endregion

        #region Folder Paths
        public static readonly string LogDirectory = KnownFolders.GetPath(KnownFolder.SavedGames) + "\\Frontier Developments\\Elite Dangerous\\";
        public static readonly string Binds_Location = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Local\Frontier Developments\Elite Dangerous\Options\Bindings\");
        public static readonly string DLL_Location = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static readonly string ALICE_Audio_Files = DLL_Location + @"\A.L.I.C.E Audio Files\";
        public static readonly string ALICE_Resources = DLL_Location + @"\A.L.I.C.E Resources\";
        public static readonly string ALICE_Response = DLL_Location + @"\A.L.I.C.E Response\Files\";
        public static readonly string ALICE_ResponseUser = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Responses\";
        public static readonly string ALICE_Log_Files = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Log Files\";
        public static readonly string ALICE_Settings = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Settings\";
        public static readonly string ALICE_Screenshots = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Screenshots\";
        public static readonly string ALICE_CodexDiscoveries = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Codex Discoveries\";
        public static readonly string ALICE_Anomalies = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Codex Discoveries\Anomalies\";
        public static readonly string ALICE_SystemData = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Systems\";
        public static readonly string ALICE_RootFolder = DLL_Location + @"\";
        #endregion

        #region File Paths  
        public static readonly string ALICE_BindsPath = Binds_Location + FILE_BindsFile;
        public static readonly string ALICE_ManualPath = ALICE_RootFolder + FILE_AliceManual;
        #endregion

        #region Methods / Functions
        public static string ALICE_LogName()
        {
            return @"A.L.I.C.E_" + DateTime.Today.Year.ToString() + "." + GetMonth() + "." + DateTime.Today.Day.ToString() + ".log";
        }

        public static void Load_UpdateBindsFile()
        {
            string MethodName = "Install Binds File";

            if (File.Exists(ALICE_BindsPath) == false)
            {
                IPlatform.WriteToInterface("A.L.I.C.E: Installing Alice Binds File...", Logger.Purple);

                try
                {
                    FileInfo fileInfo = new FileInfo(ALICE_Resources + FILE_BindsFile);
                    fileInfo.CopyTo(ALICE_BindsPath);                    
                    IPlatform.WriteToInterface("A.L.I.C.E: A.L.I.C.E Profile.3.0.binds Installed", Logger.Purple);
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "Something Went Wrong Installing The Binds File...");
                }
            }
            else
            {
                //Logger.DebugLine(MethodName, "Project A.L.I.C.E Binds File Located.", Logger.Blue);
            }
        }

        public static void CreateDir()
        {
            string MethodName = "Create Directory";

            try
            {
                Directory.CreateDirectory(Paths.ALICE_Settings);
                Directory.CreateDirectory(Paths.ALICE_Screenshots);
                Directory.CreateDirectory(Paths.ALICE_Response);
                Directory.CreateDirectory(Paths.ALICE_ResponseUser);
                Directory.CreateDirectory(Paths.ALICE_Log_Files);
                Directory.CreateDirectory(Paths.ALICE_Settings);
                Directory.CreateDirectory(Paths.ALICE_SystemData);
                Directory.CreateDirectory(Paths.ALICE_Anomalies);
                Directory.CreateDirectory(Paths.ALICE_CodexDiscoveries);
            }
            catch (Exception ex)
            {
                Logger.Error(MethodName, "Execption: " + ex, Logger.Red);
                Logger.Error(MethodName, "Something Went Wrong While Creating Missing Directories...", Logger.Red);
            }
        }

        public static string GetMonth()
        {
            int I = DateTime.Today.Month;
            string Answer = "";

            if (I == 1) { Answer = "01"; }
            else if (I == 2) { Answer = "02"; }
            else if (I == 3) { Answer = "03"; }
            else if (I == 4) { Answer = "04"; }
            else if (I == 5) { Answer = "05"; }
            else if (I == 6) { Answer = "06"; }
            else if (I == 7) { Answer = "07"; }
            else if (I == 8) { Answer = "08"; }
            else if (I == 9) { Answer = "09"; }
            else if (I == 10) { Answer = "10"; }
            else if (I == 11) { Answer = "11"; }
            else if (I == 12) { Answer = "12"; }

            return Answer;
        }

        public static string ShowBinds(string path = "")
        {
            WinForms.OpenFileDialog dialog = new WinForms.OpenFileDialog
            {
                DefaultExt = ".binds",
                Filter = "Binds (*.binds)|*.binds",
                FilterIndex = 2,
                InitialDirectory = Paths.Binds_Location
            };
            if (dialog.ShowDialog() == WinForms.DialogResult.OK)
            {
                path = dialog.FileName;
            }
            return path;
        }
        #endregion

        #region Known Folder Paths

        /// <summary>
        /// Class containing methods to retrieve specific file system paths.
        /// </summary>
        public static class KnownFolders
        {
            private static string[] _knownFolderGuids = new string[]
            {
                "{56784854-C6CB-462B-8169-88E350ACB882}", // Contacts
                "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", // Desktop
                "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}", // Documents
                "{374DE290-123F-4565-9164-39C4925E467B}", // Downloads
                "{1777F761-68AD-4D8A-87BD-30B759FA33DD}", // Favorites
                "{BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968}", // Links
                "{4BD8D571-6D19-48D3-BE97-422220080E43}", // Music
                "{33E28130-4E1E-4676-835A-98395C3BC3BB}", // Pictures
                "{4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4}", // SavedGames
                "{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}", // SavedSearches
                "{18989B1D-99B5-455B-841C-AB7C74E4DDFC}", // Videos
            };

            /// <summary>
            /// Gets the current path to the specified known folder as currently configured. This does
            /// not require the folder to be existent.
            /// </summary>
            /// <param name="knownFolder">The known folder which current path will be returned.</param>
            /// <returns>The default path of the known folder.</returns>
            /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path
            ///     could not be retrieved.</exception>
            public static string GetPath(KnownFolder knownFolder)
            {
                return GetPath(knownFolder, false);
            }

            /// <summary>
            /// Gets the current path to the specified known folder as currently configured. This does
            /// not require the folder to be existent.
            /// </summary>
            /// <param name="knownFolder">The known folder which current path will be returned.</param>
            /// <param name="defaultUser">Specifies if the paths of the default user (user profile
            ///     template) will be used. This requires administrative rights.</param>
            /// <returns>The default path of the known folder.</returns>
            /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path
            ///     could not be retrieved.</exception>
            public static string GetPath(KnownFolder knownFolder, bool defaultUser)
            {
                return GetPath(knownFolder, KnownFolderFlags.DontVerify, defaultUser);
            }

            private static string GetPath(KnownFolder knownFolder, KnownFolderFlags flags,
                bool defaultUser)
            {
                int result = SHGetKnownFolderPath(new Guid(_knownFolderGuids[(int)knownFolder]),
                    (uint)flags, new IntPtr(defaultUser ? -1 : 0), out IntPtr outPath);
                if (result >= 0)
                {
                    return Marshal.PtrToStringUni(outPath);
                }
                else
                {
                    throw new ExternalException("Unable to retrieve the known folder path. It may not "
                        + "be available on this system.", result);
                }
            }

            [DllImport("Shell32.dll")]
            private static extern int SHGetKnownFolderPath(
                [MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken,
                out IntPtr ppszPath);

            [Flags]
            private enum KnownFolderFlags : uint
            {
                SimpleIDList = 0x00000100,
                NotParentRelative = 0x00000200,
                DefaultPath = 0x00000400,
                Init = 0x00000800,
                NoAlias = 0x00001000,
                DontUnexpand = 0x00002000,
                DontVerify = 0x00004000,
                Create = 0x00008000,
                NoAppcontainerRedirection = 0x00010000,
                AliasOnly = 0x80000000
            }
        }

        /// <summary>
        /// Standard folders registered with the system. These folders are installed with Windows Vista
        /// and later operating systems, and a computer will have only folders appropriate to it
        /// installed.
        /// </summary>
        public enum KnownFolder
        {
            Contacts,
            Desktop,
            Documents,
            Downloads,
            Favorites,
            Links,
            Music,
            Pictures,
            SavedGames,
            SavedSearches,
            Videos
        }
        #endregion
    }
}
