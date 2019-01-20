using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading;
using WinForms = System.Windows.Forms;
using ALICE_Actions;
using System.IO;

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
            try
            {
                #region Audio
                string Line = "Select The File You Want To Import From";

                //Thread thread = new Thread((ThreadStart)(() => { SpeechService.Instance.Say(Line, true, 3, null); })) { IsBackground = true };
                //thread.Start();
                #endregion

                Call.Key.ImportUserBinds(ShowBinds());
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
