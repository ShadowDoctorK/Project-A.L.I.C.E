using ALICE_Internal;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ALICE_Community_Toolkit
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : UserControl
    {
        public static string MethodName = "(Toolkit) Plugin Settings";

        public Reports()
        {
            InitializeComponent();

            UpdateButtons();
        }

        public void UpdateButtons()
        {
            this.Dispatcher.Invoke(() =>
            {
                try
                {
                    #region PlugIn
                    //Firegroup Offset
                    Slider_DelayFiregroup.Value = TKSettings.User.OffsetFireGroups();
                    TextBox_DelayFiregroup.Text = TKSettings.User.OffsetFireGroups().ToString() + "ms";
                    
                    //Panel Offset
                    Slider_DelayPanel.Value = TKSettings.User.OffsetPanels();
                    TextBox_DelayPanel.Text = TKSettings.User.OffsetPanels().ToString() + "ms";
                    
                    //Power Offset
                    Slider_DelayPower.Value = TKSettings.User.OffsetPips();
                    TextBox_DelayPower.Text = TKSettings.User.OffsetPips().ToString() + "ms";
                    
                    //Throttle Offset
                    Slider_DelayThrottle.Value = TKSettings.User.OffsetThrottle();
                    TextBox_DelayThrottle.Text = TKSettings.User.OffsetThrottle().ToString() + "ms";
                    #endregion

                    #region Reports
                    btn_FuelScoop.Foreground = Data.GetTextColor(TKSettings.User.FuelScoop());
                    btn_FuelStatus.Foreground = Data.GetTextColor(TKSettings.User.FuelStatus());
                    btn_MaterialCollected.Foreground = Data.GetTextColor(TKSettings.User.MaterialCollected());
                    btn_NoFireZone.Foreground = Data.GetTextColor(TKSettings.User.NoFireZone());
                    btn_StationStatus.Foreground = Data.GetTextColor(TKSettings.User.StationStatus());
                    btn_ShieldStatus.Foreground = Data.GetTextColor(TKSettings.User.ShieldState());
                    btn_CollectedBounty.Foreground = Data.GetTextColor(TKSettings.User.CollectedBounty());
                    btn_TargetEnemy.Foreground = Data.GetTextColor(TKSettings.User.TargetEnemy());
                    btn_WatnedTarget.Foreground = Data.GetTextColor(TKSettings.User.TargetWanted());
                    btn_RefinedMaterials.Foreground = Data.GetTextColor(TKSettings.User.MaterialRefined());
                    btn_Masslock.Foreground = Data.GetTextColor(TKSettings.User.Masslock());
                    btn_HighGravity.Foreground = Data.GetTextColor(TKSettings.User.HighGravDescent());
                    btn_TravelDistance.Foreground = Data.GetTextColor(TKSettings.User.ScanTravelDist());
                    btn_LandableVolcanism.Foreground = Data.GetTextColor(TKSettings.User.LandableVolcanism());
                    btn_GlideStatus.Foreground = Data.GetTextColor(TKSettings.User.GlideStatus());
                    #endregion

                    #region Orders
                    btn_AssistedCombatPower.Foreground = Data.GetTextColor(TKSettings.User.CombatPower());
                    btn_AssistedSystemScans.Foreground = Data.GetTextColor(TKSettings.User.AssistSystemScan());
                    btn_AssistedDockingProcedures.Foreground = Data.GetTextColor(TKSettings.User.AssistDocking());
                    btn_AssistedHangerEntry.Foreground = Data.GetTextColor(TKSettings.User.AssistHangerEntry());
                    btn_PostJumpSafeties.Foreground = Data.GetTextColor(TKSettings.User.PostHyperspaceSafety());
                    btn_WeaponSafty.Foreground = Data.GetTextColor(TKSettings.User.WeaponSafety());
                    #endregion

                    #region Planets
                    btn_Earthlike.Foreground = Data.GetTextColor(TKSettings.User.BodyEarthLike());
                    btn_WaterTerra.Foreground = Data.GetTextColor(TKSettings.User.BodyWaterTerra());
                    btn_HMCTerra.Foreground = Data.GetTextColor(TKSettings.User.BodyHMCTerra());
                    btn_Ammonia.Foreground = Data.GetTextColor(TKSettings.User.BodyAmmonia());
                    btn_RockyTerra.Foreground = Data.GetTextColor(TKSettings.User.BodyRockyTerra());
                    btn_Water.Foreground = Data.GetTextColor(TKSettings.User.BodyWater());
                    btn_MetalRich.Foreground = Data.GetTextColor(TKSettings.User.BodyMetalRich());
                    btn_GasGiantII.Foreground = Data.GetTextColor(TKSettings.User.BodyGasGiantII());
                    btn_HMC.Foreground = Data.GetTextColor(TKSettings.User.BodyHMC());
                    #endregion
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception" + ex);
                    Logger.Exception(MethodName, "Somthing Went Wrong While Updating The UI");
                }
            });
        }

        #region PlugIn
        private void Slider_DelayPanel_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TKSettings.User.OffsetPanels(MethodName, (int)Slider_DelayPanel.Value, TKSettings.Save);
        }

        private void Slider_DelayPower_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TKSettings.User.OffsetPips(MethodName, (int)Slider_DelayPower.Value, TKSettings.Save);            
        }

        private void Slider_DelayFiregroup_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TKSettings.User.OffsetFireGroups(MethodName, (int)Slider_DelayFiregroup.Value, TKSettings.Save);            
        }

        private void Slider_DelayThrottle_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TKSettings.User.OffsetThrottle(MethodName, (int)Slider_DelayThrottle.Value, TKSettings.Save);            
        }
        #endregion

        #region Reports
        private void btn_FuelScoop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.FuelScoop(MethodName, !TKSettings.User.FuelScoop(), true);                
                btn_FuelScoop.Foreground = Data.GetTextColor(TKSettings.User.FuelScoop());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_FuelStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.FuelStatus(MethodName, !TKSettings.User.FuelStatus(), true);
                btn_FuelStatus.Foreground = Data.GetTextColor(TKSettings.User.FuelStatus());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_MaterialCollected_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.MaterialCollected(MethodName, !TKSettings.User.MaterialCollected(), true);
                btn_MaterialCollected.Foreground = Data.GetTextColor(TKSettings.User.MaterialCollected());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_NoFireZone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.NoFireZone(MethodName, !TKSettings.User.NoFireZone(), true);
                btn_NoFireZone.Foreground = Data.GetTextColor(TKSettings.User.NoFireZone());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_StationStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.StationStatus(MethodName, !TKSettings.User.StationStatus(), true);
                btn_StationStatus.Foreground = Data.GetTextColor(TKSettings.User.StationStatus());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_ShieldStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.ShieldState(MethodName, !TKSettings.User.ShieldState(), true);
                btn_ShieldStatus.Foreground = Data.GetTextColor(TKSettings.User.ShieldState());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_CollectedBounty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.CollectedBounty(MethodName, !TKSettings.User.CollectedBounty(), true);
                btn_CollectedBounty.Foreground = Data.GetTextColor(TKSettings.User.CollectedBounty());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_TargetEnemy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.TargetEnemy(MethodName, !TKSettings.User.TargetEnemy(), true);
                btn_TargetEnemy.Foreground = Data.GetTextColor(TKSettings.User.TargetEnemy());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_WatnedTarget_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.TargetWanted(MethodName, !TKSettings.User.TargetWanted(), true);
                btn_WatnedTarget.Foreground = Data.GetTextColor(TKSettings.User.TargetWanted());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_RefinedMaterials_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.MaterialRefined(MethodName, !TKSettings.User.MaterialRefined(), true);
                btn_RefinedMaterials.Foreground = Data.GetTextColor(TKSettings.User.MaterialRefined());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_Masslock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.Masslock(MethodName, !TKSettings.User.Masslock(), true);
                btn_Masslock.Foreground = Data.GetTextColor(TKSettings.User.Masslock());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }
        #endregion

        #region Orders
        private void btn_AssistedCombatPower_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.CombatPower(MethodName, !TKSettings.User.CombatPower(), true);
                btn_AssistedCombatPower.Foreground = Data.GetTextColor(TKSettings.User.CombatPower());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }          
        }

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

        private void btn_AssistedDockingProcedures_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.AssistDocking(MethodName, !TKSettings.User.AssistDocking(), true);
                btn_AssistedDockingProcedures.Foreground = Data.GetTextColor(TKSettings.User.AssistDocking());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_AssistedHangerEntry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.AssistHangerEntry(MethodName, !TKSettings.User.AssistHangerEntry(), true);
                btn_AssistedHangerEntry.Foreground = Data.GetTextColor(TKSettings.User.AssistHangerEntry());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_PostJumpSafeties_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.PostHyperspaceSafety(MethodName, !TKSettings.User.PostHyperspaceSafety(), true);
                btn_PostJumpSafeties.Foreground = Data.GetTextColor(TKSettings.User.PostHyperspaceSafety());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_WeaponSafty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.WeaponSafety(MethodName, !TKSettings.User.WeaponSafety(), true);
                btn_WeaponSafty.Foreground = Data.GetTextColor(TKSettings.User.WeaponSafety());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }


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
        #endregion

        #region Planets
        private void btn_Earthlike_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.BodyEarthLike(MethodName, !TKSettings.User.BodyEarthLike(), true);
                btn_Earthlike.Foreground = Data.GetTextColor(TKSettings.User.BodyEarthLike());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_WaterTerra_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.BodyWaterTerra(MethodName, !TKSettings.User.BodyWaterTerra(), true);
                btn_WaterTerra.Foreground = Data.GetTextColor(TKSettings.User.BodyWaterTerra());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_HMCTerra_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.BodyHMCTerra(MethodName, !TKSettings.User.BodyHMCTerra(), true);
                btn_HMCTerra.Foreground = Data.GetTextColor(TKSettings.User.BodyHMCTerra());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_Ammonia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.BodyAmmonia(MethodName, !TKSettings.User.BodyAmmonia(), true);
                btn_Ammonia.Foreground = Data.GetTextColor(TKSettings.User.BodyAmmonia());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_RockyTerra_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.BodyRockyTerra(MethodName, !TKSettings.User.BodyRockyTerra(), true);
                btn_RockyTerra.Foreground = Data.GetTextColor(TKSettings.User.BodyRockyTerra());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_Water_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.BodyWater(MethodName, !TKSettings.User.BodyWater(), true);
                btn_Water.Foreground = Data.GetTextColor(TKSettings.User.BodyWater());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_MetalRich_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.BodyMetalRich(MethodName, !TKSettings.User.BodyMetalRich(), true);
                btn_MetalRich.Foreground = Data.GetTextColor(TKSettings.User.BodyMetalRich());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_GasGiantII_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.BodyGasGiantII(MethodName, !TKSettings.User.BodyGasGiantII(), true);
                btn_GasGiantII.Foreground = Data.GetTextColor(TKSettings.User.BodyGasGiantII());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }

        private void btn_HMC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TKSettings.User.BodyHMC(MethodName, !TKSettings.User.BodyHMC(), true);
                btn_HMC.Foreground = Data.GetTextColor(TKSettings.User.BodyHMC());
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
            }
        }
        #endregion
    }
}
