using ALICE_Synthesizer;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using WinForms = System.Windows.Forms;

namespace ALICE_Community_Toolkit
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            Dashboard_StackPanel.Children.Add(Interface_Reports);            
        }

        #region KeyBinds
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

        private void btn_LoadUserKeybinds_Click(object sender, RoutedEventArgs e)
        {
            string MethodName = "Target Keybinds";
            try
            {
                #region Audio
                string Line = "Please Select The File You Want Me To Use To Import Keybinds From.";

                Thread thread = new Thread((ThreadStart)(() => 
                { Speech.Speak(Line, true); })) { IsBackground = true };
                thread.Start();
                #endregion

                string FilePath = ShowBinds();

                //Validate File Path
                if (string.IsNullOrWhiteSpace(FilePath) == false)
                {
                    string FileName = FilePath.Replace(Paths.Binds_Location, "");
                    Settings.User.BindsFile(MethodName, FileName, true);
                }                
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Menu Bar
        public Home Interface_Home = new Home();
        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            Dashboard_StackPanel.Children.Clear();
            Dashboard_StackPanel.Children.Add(Interface_Home);
        }

        //public Orders Interface_Orders = new Orders();
        //private void btn_Orders_Click(object sender, RoutedEventArgs e)
        //{
        //    Dashboard_StackPanel.Children.Clear();
        //    Dashboard_StackPanel.Children.Add(Interface_Orders);
        //}

        public Reports Interface_Reports = new Reports();
        private void btn_Reports_Click(object sender, RoutedEventArgs e)
        {
            Dashboard_StackPanel.Children.Clear();
            Dashboard_StackPanel.Children.Add(Interface_Reports);
        }

        private void Btn_OpenManual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(Paths.ALICE_ManualPath)) { System.Diagnostics.Process.Start(Paths.ALICE_ManualPath); }
                else { System.Windows.Forms.MessageBox.Show("Unable To Open The Manual, Did You Move It?"); }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Something Went Wrong Opening The Manual" + ex);
            }
        }
        #endregion
    }
}
