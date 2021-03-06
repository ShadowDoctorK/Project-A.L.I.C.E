﻿using ALICE_Internal;
using ALICE_Synthesizer;
using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
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

            Win = (MainWindow)Application.Current.MainWindow;

            Startup();
        }

        //Static Reference Of The Main Window
        public static MainWindow Win;

        public static void Startup()
        {
            //File Verification
            TKSettings.FileVerification();

            //Load Audio Files
            ISynthesizer.Response.Load(Paths.ALICE_Response);

            //Start Settings Monitor On New Thread
            Thread config = new Thread((ThreadStart)(() => { TKSettings.Monitor_Settings.Start(); }))
            { IsBackground = true }; config.Start();

            //Wait For All Settings To Load
            while (TKSettings.InitFiregroups() == false || TKSettings.InitUser() == false)
            {
                Thread.Sleep(250);
            }

            //Initial UI Update
            UpdateButtons();

            TKSettings.InitUI = true;
        }

        public static void UpdateButtons()
        {
            //Update MainWindow Items
            Win.UpdateUI();

            //Update Plugin Settings Buttons
            Interface_Dashboard.Interface_Reports.UpdateButtons();

            //Update Firegroup Controls
            Interface_Dashboard.Interface_Firegroups.UpdateButtons();
            Interface_Dashboard.Interface_Firegroups.UpdateFiregroupItems();

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
                    if (TKSettings.User.Commander == null) { return; }

                    Label_Commander.Content = "CMDR " + TKSettings.User.Commander;
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

