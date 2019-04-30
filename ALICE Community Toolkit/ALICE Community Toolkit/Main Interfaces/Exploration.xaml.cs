using ALICE_Internal;
using System;
using System.Windows;
using System.Windows.Controls;

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
                    btn_AssistedSystemScans.Foreground = Data.GetTextColor(Settings.User.AssistSystemScan());
                    #endregion

                    #region Reports
                    btn_GlideStatus.Foreground = Data.GetTextColor(Settings.User.GlideStatus());
                    btn_LandableVolcanism.Foreground = Data.GetTextColor(Settings.User.LandableVolcanism());
                    btn_HighGravity.Foreground = Data.GetTextColor(Settings.User.HighGravDescent());
                    btn_TravelDistance.Foreground = Data.GetTextColor(Settings.User.ScanTravelDist());
                    #endregion

                    #region Scan Items
                    CB_SCTravelDist.SelectedIndex = Settings.User.ScanDistLimit();

                    CheckBox_Earthlike.IsChecked = Settings.User.BodyEarthLike();
                    CheckBox_WaterTerra.IsChecked = Settings.User.BodyWaterTerra();
                    CheckBox_HMCTera.IsChecked = Settings.User.BodyHMCTerra();
                    CheckBox_Ammonia.IsChecked = Settings.User.BodyAmmonia();
                    CheckBox_RockyTerra.IsChecked = Settings.User.BodyRockyTerra();
                    CheckBox_Water.IsChecked = Settings.User.BodyWater();
                    CheckBox_MetalRich.IsChecked = Settings.User.BodyMetalRich();
                    CheckBox_GasGiantII.IsChecked = Settings.User.BodyGasGiantII();
                    CheckBox_HMC.IsChecked = Settings.User.BodyHMC();
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
                Settings.User.AssistSystemScan(MethodName, !Settings.User.AssistSystemScan(), true);
                btn_AssistedSystemScans.Foreground = Data.GetTextColor(Settings.User.AssistSystemScan());
                
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
                Settings.User.GlideStatus(MethodName, !Settings.User.GlideStatus(), true);                
                btn_GlideStatus.Foreground = Data.GetTextColor(Settings.User.GlideStatus());
                
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
                Settings.User.LandableVolcanism(MethodName, !Settings.User.LandableVolcanism(), true);
                btn_LandableVolcanism.Foreground = Data.GetTextColor(Settings.User.LandableVolcanism());
                
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
                Settings.User.ScanTravelDist(MethodName, !Settings.User.ScanTravelDist(), true);                
                btn_TravelDistance.Foreground = Data.GetTextColor(Settings.User.ScanTravelDist());
                
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
                Settings.User.HighGravDescent(MethodName, !Settings.User.HighGravDescent(), true);                
                btn_HighGravity.Foreground = Data.GetTextColor(Settings.User.HighGravDescent());
                
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
            Settings.User.ScanDistLimit(MethodName, CB_SCTravelDist.SelectedIndex, true);
        }

        private void CheckBox_EarthlikeChanged(object sender, RoutedEventArgs e)
        {
            Settings.User.BodyEarthLike(MethodName, (bool)CheckBox_Earthlike.IsChecked, true);            
        }

        private void CheckBox_WaterTeraChanged(object sender, RoutedEventArgs e)
        {
            Settings.User.BodyWaterTerra(MethodName, (bool)CheckBox_WaterTerra.IsChecked, true);                      
        }

        private void CheckBox_HMCTeraChanged(object sender, RoutedEventArgs e)
        {
            Settings.User.BodyHMCTerra(MethodName, (bool)CheckBox_HMCTera.IsChecked, true);
        }

        private void CheckBox_AmmoniaChanged(object sender, RoutedEventArgs e)
        {
            Settings.User.BodyAmmonia(MethodName, (bool)CheckBox_Ammonia.IsChecked, true);
        }

        private void CheckBox_RockyTeraChanged(object sender, RoutedEventArgs e)
        {            
            Settings.User.BodyRockyTerra(MethodName, (bool)CheckBox_RockyTerra.IsChecked, true);
        }

        private void CheckBox_WaterChanged(object sender, RoutedEventArgs e)
        {            
            Settings.User.BodyWater(MethodName, (bool)CheckBox_Water.IsChecked, true);
        }

        private void CheckBox_MetalRichChanged(object sender, RoutedEventArgs e)
        {            
            Settings.User.BodyMetalRich(MethodName, (bool)CheckBox_MetalRich.IsChecked, true);
        }

        private void CheckBox_GasGiantIIChanged(object sender, RoutedEventArgs e)
        {            
            Settings.User.BodyGasGiantII(MethodName, (bool)CheckBox_GasGiantII.IsChecked, true);
        }

        private void CheckBox_HMCChanged(object sender, RoutedEventArgs e)
        {           
            Settings.User.BodyHMC(MethodName, (bool)CheckBox_HMC.IsChecked, true);
        }
        #endregion
    }
}
