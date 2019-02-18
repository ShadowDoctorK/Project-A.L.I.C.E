using ALICE_Internal;
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

namespace ALICE_Community_Toolkit
{
    /// <summary>
    /// Interaction logic for Exploration.xaml
    /// </summary>
    public partial class Exploration : UserControl
    {
        public static string MethodName = "(Toolkit) Exploration Settings";

        public Exploration()
        {
            InitializeComponent();

            SetBindings();
        }

        public void SetBindings()
        {
            CB_SCTravelDist.ItemsSource = Data.SCTravelTime;
        }

        public void UpdateButtons()
        {
            this.Dispatcher.Invoke(() =>
            {
                try
                {
                    #region Orders
                    btn_AssistedSystemScans.Foreground = Data.GetTextColor(Data.AssistSystemScan);
                    #endregion

                    #region Reports
                    btn_GlideStatus.Foreground = Data.GetTextColor(Data.GlideStatus);
                    btn_LandableVolcanism.Foreground = Data.GetTextColor(Data.LandableVolcanism);
                    btn_HighGravity.Foreground = Data.GetTextColor(Data.HighGravDescent);
                    btn_TravelDistance.Foreground = Data.GetTextColor(Data.ScanTravelDist);
                    #endregion

                    #region Scan Items
                    CB_SCTravelDist.SelectedIndex = Data.ScanDistLimit;

                    CheckBox_Earthlike.IsChecked = Data.BodyEarthLike;
                    CheckBox_WaterTerra.IsChecked = Data.BodyWaterTerra;
                    CheckBox_HMCTera.IsChecked = Data.BodyHMCTerra;
                    CheckBox_Ammonia.IsChecked = Data.BodyAmmonia;
                    CheckBox_RockyTerra.IsChecked = Data.BodyRockyTerra;
                    CheckBox_Water.IsChecked = Data.BodyWater;
                    CheckBox_MetalRich.IsChecked = Data.BodyMetalRich;
                    CheckBox_GasGiantII.IsChecked = Data.BodyGasGiantII;
                    CheckBox_HMC.IsChecked = Data.BodyHMC;
                    #endregion
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception" + ex);
                    Logger.Exception(MethodName, "Somthing Went Wrong While Updating The UI");
                }
            });
        }

        #region Orders
        private void btn_AssistedSystemScans_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data.AssistSystemScan = !Data.AssistSystemScan;
                btn_AssistedSystemScans.Foreground = Data.GetTextColor(Data.FuelScoop);
                
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }
        #endregion

        #region Reports
        private void btn_GlideStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data.GlideStatus = !Data.GlideStatus;
                btn_GlideStatus.Foreground = Data.GetTextColor(Data.FuelScoop);
                
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_LandableVolcanism_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data.LandableVolcanism = !Data.LandableVolcanism;
                btn_LandableVolcanism.Foreground = Data.GetTextColor(Data.FuelScoop);
                
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_TravelDistance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data.ScanTravelDist = !Data.ScanTravelDist;
                btn_TravelDistance.Foreground = Data.GetTextColor(Data.FuelScoop);
                
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_HighGravityDescent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data.HighGravDescent = !Data.HighGravDescent;
                btn_HighGravity.Foreground = Data.GetTextColor(Data.FuelScoop);
                
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }
        #endregion

        #region Scan Items
        private void CB_SCTravelDistChanged(object sender, SelectionChangedEventArgs e)
        {
            Data.ScanDistLimit = CB_SCTravelDist.SelectedIndex;
            
        }

        private void CheckBox_EarthlikeChanged(object sender, RoutedEventArgs e)
        {
            Data.BodyEarthLike = (bool)CheckBox_Earthlike.IsChecked;
            
        }

        private void CheckBox_WaterTeraChanged(object sender, RoutedEventArgs e)
        {
            Data.BodyWaterTerra = (bool)CheckBox_WaterTerra.IsChecked;
            
        }

        private void CheckBox_HMCTeraChanged(object sender, RoutedEventArgs e)
        {
            Data.BodyHMCTerra = (bool)CheckBox_HMCTera.IsChecked;
            
        }

        private void CheckBox_AmmoniaChanged(object sender, RoutedEventArgs e)
        {
            Data.BodyAmmonia = (bool)CheckBox_Ammonia.IsChecked;
            
        }

        private void CheckBox_RockyTeraChanged(object sender, RoutedEventArgs e)
        {
            Data.BodyRockyTerra = (bool)CheckBox_RockyTerra.IsChecked;
            
        }

        private void CheckBox_WaterChanged(object sender, RoutedEventArgs e)
        {
            Data.BodyWater = (bool)CheckBox_Water.IsChecked;
            
        }

        private void CheckBox_MetalRichChanged(object sender, RoutedEventArgs e)
        {
            Data.BodyMetalRich = (bool)CheckBox_MetalRich.IsChecked;
            
        }

        private void CheckBox_GasGiantIIChanged(object sender, RoutedEventArgs e)
        {
            Data.BodyGasGiantII = (bool)CheckBox_GasGiantII.IsChecked;
            
        }

        private void CheckBox_HMCChanged(object sender, RoutedEventArgs e)
        {
            Data.BodyHMC = (bool)CheckBox_HMC.IsChecked;
            
        }
        #endregion
    }
}
