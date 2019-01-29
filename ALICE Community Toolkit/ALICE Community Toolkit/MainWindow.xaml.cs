using ALICE_Internal;
using ALICE_JournalReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinForms = System.Windows.Forms;

namespace ALICE_Community_Toolkit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Paths.CreateDir();
            Interface_StackPanel.Children.Add(Interface_Dashboard);
        }

        #region Application Shared Methods
        public static readonly string Filter_Response = ".response";
        public static readonly string Extention_Response = "Response (*.response)|*.response";
        public static readonly string Filter_ResponseUser = ".response.user";
        public static readonly string Extention_ResponseUser = "User Response (*.response.user)|*.response.user";

        public static string SelectDirectory()
        {
            string path = "";
            WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
            if (dialog.ShowDialog() == WinForms.DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }
            return path;
        }

        public static string SelectFile(string Extention = null, string Filter = null, string Path = null)
        {
            WinForms.OpenFileDialog dialog = new WinForms.OpenFileDialog();

            if (Extention != null)
            { dialog.DefaultExt = Extention; }

            if (Filter != null) //".response"
            { dialog.Filter = Filter; } //"Response (*.response)|*.response"

            dialog.FilterIndex = 2;

            if (dialog.ShowDialog() == WinForms.DialogResult.OK)
            { Path = dialog.FileName; }

            return Path;
        }

        public static bool IsDirectoryEmpty(string path)
        {
            return !System.IO.Directory.EnumerateFileSystemEntries(path).Any();
        }
        #endregion

        #region Response Generator
        Response_Generator Interface_Response = new Response_Generator();

        private void btn_ResponseGen_Click(object sender, RoutedEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_StackPanel.Children.Add(Interface_Response);
        }

        private void btn_ResponseGen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_Response = new Response_Generator();
            Interface_StackPanel.Children.Add(Interface_Response);
        }
        #endregion

        #region Synthesizer Controls
        Synthesizer_Controls Interface_Synthesizer = new Synthesizer_Controls();
        private void btn_SynthControl_Click(object sender, RoutedEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_StackPanel.Children.Add(Interface_Synthesizer);
        }

        private void btn_SynthControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_Synthesizer = new Synthesizer_Controls();
            Interface_StackPanel.Children.Add(Interface_Synthesizer);
        }
        #endregion

        #region Dashboard
        Dashboard Interface_Dashboard = new Dashboard();

        private void btn_Dashboard_Click(object sender, RoutedEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_StackPanel.Children.Add(Interface_Dashboard);
        }

        private void btn_Dashboard_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_Dashboard = new Dashboard();
            Interface_StackPanel.Children.Add(Interface_Dashboard);
        }
        #endregion

        private void Btn_Patreon_Click(object sender, RoutedEventArgs e)
        {
            try { System.Diagnostics.Process.Start("https://www.patreon.com/ALICEPROJECT/"); }
            catch (Exception) { }
        }

        private void Btn_DiscordAlice_Click(object sender, RoutedEventArgs e)
        {
            try { System.Diagnostics.Process.Start("https://discord.gg/6qCJBvn"); }
            catch (Exception) { }            
        }

        private void Btn_DiscordEDCS_Click(object sender, RoutedEventArgs e)
        {
            try { System.Diagnostics.Process.Start("https://discord.gg/DACkEgh"); }
            catch (Exception) { }        
        }
    }

    public static class Paths
    {
        #region File Names
        public static readonly string ALICE_BindsFile = "A.L.I.C.E Profile.3.0.binds";
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
        public static readonly string ALICE_Response = ToolKitLocation + @"\A.L.I.C.E Response\";
        public static readonly string ALICE_ResponseUser = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Responses\";
        public static readonly string ALICE_Log_Files = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Log Files\";
        public static readonly string ALICE_Settings = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Settings\";
        public static readonly string ALICE_SystemData = KnownFolders.GetPath(KnownFolder.Documents) + @"\A.L.I.C.E User Data\Systems\";
        public static readonly string ALICE_RootFolder = ToolKitLocation + @"\";      
        #endregion

        #region File Paths  
        public static readonly string ALICE_BindsPath = Binds_Location + ALICE_BindsFile;
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

