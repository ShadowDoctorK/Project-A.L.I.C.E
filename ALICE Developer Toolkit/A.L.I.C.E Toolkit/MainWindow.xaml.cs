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
using WinForms = System.Windows.Forms;

namespace A.L.I.C.E_Toolkit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Application Shared Methods
        public static string SelectDirectory(string Root = null)
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

        Module_Generator Interface_Module = new Module_Generator();

        private void btn_ModuleGen_Click(object sender, RoutedEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_StackPanel.Children.Add(Interface_Module);
        }

        #region Commodity Generator
        Commodity_Generator Interface_CommodityGen = new Commodity_Generator();

        private void btn_CommodityGen_Click(object sender, RoutedEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_StackPanel.Children.Add(Interface_CommodityGen);
        }

        private void btn_CommodityGen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_Response = new Response_Generator();
            Interface_StackPanel.Children.Add(Interface_CommodityGen);
        }
        #endregion


        Journal_Tool Interface_Journal = new Journal_Tool();

        private void btn_Journal_Click(object sender, RoutedEventArgs e)
        {
            Interface_StackPanel.Children.Clear();
            Interface_StackPanel.Children.Add(Interface_Journal);
        }

        private void Btn_DiscordEDCS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_DiscordAlice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Patreon_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
