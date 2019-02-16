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
            //Data.LoadUserSettings();
            //Data.LoadFiregroupSettings();

            InitializeComponent();
            Paths.CreateDir();
            Interface_StackPanel.Children.Add(Interface_Dashboard);

            Win = (MainWindow)Application.Current.MainWindow;

            Data.StartMonitor();
            Data.Watcher.Watch();
            UpdateButtons();
            Data.SettingInit = true;
        }

        public static MainWindow Win;

        public static void UpdateButtons()
        {
            //Update MainWindow Items
            Win.UpdateUI();

            //Update Plugin Settings Buttons
            Interface_Dashboard.Interface_Reports.UpdateButtons();

            //Update Exploration Buttons
            Interface_Exploration.UpdateButtons();
        }

        public void UpdateUI()
        {
            string MethodName = "(Toolkit) Update Main UI";

            //MainWindow UI Items
            try
            {
                this.Dispatcher.Invoke(() =>
                {
                    Label_Commander.Content = "CMDR " + Data.Commander;
                });
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception" + ex);
                Logger.Exception(MethodName, "Somthing Went Wrong While Updating The UI");
            }
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
        private static Response_Generator Interface_Response = new Response_Generator();

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
        private static Synthesizer_Controls Interface_Synthesizer = new Synthesizer_Controls();
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
        private static Dashboard Interface_Dashboard = new Dashboard();

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

        #region Exploration
        private static Exploration Interface_Exploration = new Exploration();

        private void btn_Exploration_Click(object sender, RoutedEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_StackPanel.Children.Add(Interface_Exploration);
        }

        private void btn_Exploration_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_Exploration = new Exploration();
            Interface_StackPanel.Children.Add(Interface_Exploration);
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
}

