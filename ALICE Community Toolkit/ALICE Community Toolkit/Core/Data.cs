using ALICE_Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Media;
using WinForms = System.Windows.Forms;

namespace ALICE_Community_Toolkit
{
    public static class Data
    {        
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

        public static List<string> SCTravelTime = new List<string>()
        {
            "Unlimited",
            "1000 ls (1:00 Min)",
            "5000 ls (2:20 Min)",
            "10K ls (2:50 Min)",
            "25K ls (3:50 Min)",
            "50K ls (5:00 Min)",
            "100K ls (6:25 Min)",
            "150K ls (7:30 Min)",
            "200K ls (8:30 Min)",
            "300K ls (10:12 Min)",            
            "400K ls (11:45 Min)",            
            "500K ls (13:10 Min)",
            "600K ls (14:20 Min)",
            "700K ls (15:50 Min)",
            "800K ls (17:20 Min)",
            "900K ls (18:05 Min)",
            "1000K ls (19:25 Min)",
            "1100K ls (20:33 Min)",
            "1200K ls (21:40 Min)",
            "1300K ls (22:46 Min)",
            "1400K ls (23:51 Min)",
            "1500K ls (24:54 Min)",
            "1600K ls (25:58 Min)",
            "1700K ls (27:00 Min)",
            "1800K ls (28:00 Min)",
            "1900K ls (29:00 Min)",
            "2000K ls (30:00 Min)",
        };

        #region Support Methods / Functions
        public static SolidColorBrush GetTextColor(bool Value)
        {
            SolidColorBrush Brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            if (Value) { Brush = new SolidColorBrush(Color.FromRgb(0, 255, 0)); }

            return Brush;
        }

        public static SolidColorBrush GetFGLabelColor(int A, int B)
        {
            //Default Color Red
            SolidColorBrush Brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            //Return Yellow
            if ((A == 0 && B != 0) || (A != 0 && B == 0))
            {
                Brush = new SolidColorBrush(Color.FromRgb(212, 230, 30));
            }            
            //Return Green
            else if (A != 0 && B != 0)
            {
                Brush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
            
            //Return Color
            return Brush;
        }

        public static SolidColorBrush GetFGLabelColor(int A)
        {
            //Default Color Red
            SolidColorBrush Brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            //Return Green
            if (A != 0)
            {
                Brush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }

            //Return Color
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
        #endregion

    }

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
        public static readonly string ToolKitLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static readonly string Binds_Location = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Local\Frontier Developments\Elite Dangerous\Options\Bindings\");
        public static readonly string ALICE_Audio_Files = ToolKitLocation + @"\A.L.I.C.E Audio Files\";
        public static readonly string ALICE_Resources = ToolKitLocation + @"\A.L.I.C.E Resources\";
        public static readonly string ALICE_Response = ToolKitLocation + @"\A.L.I.C.E Response\Files\";
        public static readonly string ALICE_ResponseUser = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Responses\";
        public static readonly string ALICE_Log_Files = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Log Files\";
        public static readonly string ALICE_Settings = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Settings\";
        public static readonly string ALICE_SystemData = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Systems\";
        public static readonly string ALICE_RootFolder = ToolKitLocation + @"\";
        #endregion

        #region File Paths  
        public static readonly string ALICE_BindsPath = Binds_Location + FILE_BindsFile;
        public static readonly string ALICE_ManualPath = ALICE_RootFolder + FILE_AliceManual;
        #endregion

        #region Methods / Functions
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

        public static void CreateDir()
        {
            try
            {
                Directory.CreateDirectory(Paths.ALICE_Settings);
                Directory.CreateDirectory(Paths.ALICE_Response);
                Directory.CreateDirectory(Paths.ALICE_ResponseUser);
                Directory.CreateDirectory(Paths.ALICE_Log_Files);
                Directory.CreateDirectory(Paths.ALICE_Settings);
                Directory.CreateDirectory(Paths.ALICE_SystemData);
            }
            catch (Exception) { }
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
