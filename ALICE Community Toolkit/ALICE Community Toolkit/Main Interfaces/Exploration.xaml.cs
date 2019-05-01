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
                    btn_AssistedSystemScans.Foreground = Data.GetTextColor(TKSettings.User.AssistSystemScan());
                    #endregion

                    #region Reports
                    btn_GlideStatus.Foreground = Data.GetTextColor(TKSettings.User.GlideStatus());
                    btn_LandableVolcanism.Foreground = Data.GetTextColor(TKSettings.User.LandableVolcanism());
                    btn_HighGravity.Foreground = Data.GetTextColor(TKSettings.User.HighGravDescent());
                    btn_TravelDistance.Foreground = Data.GetTextColor(TKSettings.User.ScanTravelDist());
                    #endregion

                    #region Scan Items
                    CB_SCTravelDist.SelectedIndex = TKSettings.User.ScanDistLimit();

                    CheckBox_Earthlike.IsChecked = TKSettings.User.BodyEarthLike();
                    CheckBox_WaterTerra.IsChecked = TKSettings.User.BodyWaterTerra();
                    CheckBox_HMCTera.IsChecked = TKSettings.User.BodyHMCTerra();
                    CheckBox_Ammonia.IsChecked = TKSettings.User.BodyAmmonia();
                    CheckBox_RockyTerra.IsChecked = TKSettings.User.BodyRockyTerra();
                    CheckBox_Water.IsChecked = TKSettings.User.BodyWater();
                    CheckBox_MetalRich.IsChecked = TKSettings.User.BodyMetalRich();
                    CheckBox_GasGiantII.IsChecked = TKSettings.User.BodyGasGiantII();
                    CheckBox_HMC.IsChecked = TKSettings.User.BodyHMC();
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
                TKSettings.User.AssistSystemScan(MethodName, !TKSettings.User.AssistSystemScan(), true);
                btn_AssistedSystemScans.Foreground = Data.GetTextColor(TKSettings.User.AssistSystemScan());
                
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
                TKSettings.User.GlideStatus(MethodName, !TKSettings.User.GlideStatus(), true);                
                btn_GlideStatus.Foreground = Data.GetTextColor(TKSettings.User.GlideStatus());
                
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
                TKSettings.User.LandableVolcanism(MethodName, !TKSettings.User.LandableVolcanism(), true);
                btn_LandableVolcanism.Foreground = Data.GetTextColor(TKSettings.User.LandableVolcanism());
                
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
                TKSettings.User.ScanTravelDist(MethodName, !TKSettings.User.ScanTravelDist(), true);                
                btn_TravelDistance.Foreground = Data.GetTextColor(TKSettings.User.ScanTravelDist());
                
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
                TKSettings.User.HighGravDescent(MethodName, !TKSettings.User.HighGravDescent(), true);                
                btn_HighGravity.Foreground = Data.GetTextColor(TKSettings.User.HighGravDescent());
                
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
            TKSettings.User.ScanDistLimit(MethodName, CB_SCTravelDist.SelectedIndex, true);
        }

        private void CheckBox_EarthlikeChanged(object sender, RoutedEventArgs e)
        {
            TKSettings.User.BodyEarthLike(MethodName, (bool)CheckBox_Earthlike.IsChecked, true);            
        }

        private void CheckBox_WaterTeraChanged(object sender, RoutedEventArgs e)
        {
            TKSettings.User.BodyWaterTerra(MethodName, (bool)CheckBox_WaterTerra.IsChecked, true);                      
        }

        private void CheckBox_HMCTeraChanged(object sender, RoutedEventArgs e)
        {
            TKSettings.User.BodyHMCTerra(MethodName, (bool)CheckBox_HMCTera.IsChecked, true);
        }

        private void CheckBox_AmmoniaChanged(object sender, RoutedEventArgs e)
        {
            TKSettings.User.BodyAmmonia(MethodName, (bool)CheckBox_Ammonia.IsChecked, true);
        }

        private void CheckBox_RockyTeraChanged(object sender, RoutedEventArgs e)
        {            
            TKSettings.User.BodyRockyTerra(MethodName, (bool)CheckBox_RockyTerra.IsChecked, true);
        }

        private void CheckBox_WaterChanged(object sender, RoutedEventArgs e)
        {            
            TKSettings.User.BodyWater(MethodName, (bool)CheckBox_Water.IsChecked, true);
        }

        private void CheckBox_MetalRichChanged(object sender, RoutedEventArgs e)
        {            
            TKSettings.User.BodyMetalRich(MethodName, (bool)CheckBox_MetalRich.IsChecked, true);
        }

        private void CheckBox_GasGiantIIChanged(object sender, RoutedEventArgs e)
        {            
            TKSettings.User.BodyGasGiantII(MethodName, (bool)CheckBox_GasGiantII.IsChecked, true);
        }

        private void CheckBox_HMCChanged(object sender, RoutedEventArgs e)
        {           
            TKSettings.User.BodyHMC(MethodName, (bool)CheckBox_HMC.IsChecked, true);
        }
        #endregion
    }
}
