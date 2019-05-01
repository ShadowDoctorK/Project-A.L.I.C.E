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

            SetBindings();
            UpdateButtons();
        }

        public void SetBindings()
        {
            CB_CF1Fire.ItemsSource = Data.Fire;            
            CB_CF2Fire.ItemsSource = Data.Fire;
            CB_ECMFire.ItemsSource = Data.Fire;
            CB_FSDIFire.ItemsSource = Data.Fire;
            CB_HS1Fire.ItemsSource = Data.Fire;
            CB_HS2Fire.ItemsSource = Data.Fire;
            CB_LIMCOLFire.ItemsSource = Data.Fire;
            CB_LIMDECFire.ItemsSource = Data.Fire;
            CB_LIMFFire.ItemsSource = Data.Fire;
            CB_LIMHBFire.ItemsSource = Data.Fire;
            CB_LIMPROFire.ItemsSource = Data.Fire;
            CB_LIMRECFire.ItemsSource = Data.Fire;
            CB_LIMREPFire.ItemsSource = Data.Fire;
            CB_LIMRESFire.ItemsSource = Data.Fire;
            CB_SC1Fire.ItemsSource = Data.Fire;
            CB_SC2Fire.ItemsSource = Data.Fire;
            CB_SFNFire.ItemsSource = Data.Fire;
            CB_SNCARGFire.ItemsSource = Data.Fire;
            CB_SNCOMPFire.ItemsSource = Data.Fire;
            CB_SNDISCFire.ItemsSource = Data.Fire;
            CB_SNKILLFire.ItemsSource = Data.Fire;
            CB_SNSURFFire.ItemsSource = Data.Fire;
            CB_SNWAKEFire.ItemsSource = Data.Fire;
            CB_SNXENOFire.ItemsSource = Data.Fire;

            CB_CF1Group.ItemsSource = Data.Group;
            CB_CF2Group.ItemsSource = Data.Group;
            CB_ECMGroup.ItemsSource = Data.Group;
            CB_FSDIGroup.ItemsSource = Data.Group;
            CB_HS1Group.ItemsSource = Data.Group;
            CB_HS2Group.ItemsSource = Data.Group;
            CB_LIMCOLGroup.ItemsSource = Data.Group;
            CB_LIMDECGroup.ItemsSource = Data.Group;
            CB_LIMFGroup.ItemsSource = Data.Group;
            CB_LIMHBGroup.ItemsSource = Data.Group;
            CB_LIMPROGroup.ItemsSource = Data.Group;
            CB_LIMRECGroup.ItemsSource = Data.Group;
            CB_LIMREPGroup.ItemsSource = Data.Group;
            CB_LIMRESGroup.ItemsSource = Data.Group;
            CB_SC1Group.ItemsSource = Data.Group;
            CB_SC2Group.ItemsSource = Data.Group;
            CB_SFNGroup.ItemsSource = Data.Group;
            CB_SNCARGGroup.ItemsSource = Data.Group;
            CB_SNCOMPGroup.ItemsSource = Data.Group;
            CB_SNDISCGroup.ItemsSource = Data.Group;
            CB_SNKILLGroup.ItemsSource = Data.Group;
            CB_SNSURFGroup.ItemsSource = Data.Group;
            CB_SNWAKEGroup.ItemsSource = Data.Group;
            CB_SNXENOGroup.ItemsSource = Data.Group;
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
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception" + ex);
                    Logger.Exception(MethodName, "Somthing Went Wrong While Updating The UI");
                }
            });
        }

        public void UpdateFiregroupItems()
        {
            //Disables Saving So Changed Event Doesn't Trigger Saving The File.
            TKSettings.Save = false;

            this.Dispatcher.Invoke(() =>
            {
                try
                {
                    Label_CurrentShip.Content = TKSettings.Firegroup.Config.ShipAssignment;

                    //Chaff 1
                    CB_CF1Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffOne.FireMode;
                    CB_CF1Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffOne.FireGroup;
                    Label_CH1.Foreground = Data.GetFGLabelColor(CB_CF1Fire.SelectedIndex, CB_CF1Group.SelectedIndex);

                    //Chaff 2
                    CB_CF2Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffTwo.FireMode;
                    CB_CF2Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffTwo.FireGroup;
                    Label_CH2.Foreground = Data.GetFGLabelColor(CB_CF2Fire.SelectedIndex, CB_CF2Group.SelectedIndex);

                    //ECM
                    CB_ECMFire.SelectedIndex = (int)TKSettings.Firegroup.Config.ECM.FireMode; 
                    CB_ECMGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.ECM.FireGroup;
                    Label_ECM.Foreground = Data.GetFGLabelColor(CB_ECMFire.SelectedIndex, CB_ECMGroup.SelectedIndex);

                    //FSD Interdictor
                    CB_FSDIFire.SelectedIndex = (int)TKSettings.Firegroup.Config.FSDInterdictor.FireMode;
                    CB_FSDIGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.FSDInterdictor.FireGroup;
                    Label_FSDI.Foreground = Data.GetFGLabelColor(CB_FSDIFire.SelectedIndex, CB_FSDIGroup.SelectedIndex);

                    //Heatsink 1
                    CB_HS1Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkOne.FireMode;
                    CB_HS1Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkOne.FireGroup;
                    Label_HS1.Foreground = Data.GetFGLabelColor(CB_HS1Fire.SelectedIndex, CB_HS1Group.SelectedIndex);

                    //Heatsink 2
                    CB_HS2Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkTwo.FireMode;
                    CB_HS2Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkTwo.FireGroup;
                    Label_HS2.Foreground = Data.GetFGLabelColor(CB_HS2Fire.SelectedIndex, CB_HS2Group.SelectedIndex);

                    //Collector Limpet
                    CB_LIMCOLFire.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetCollector.FireMode;
                    CB_LIMCOLGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetCollector.FireGroup;
                    Label_LIMCOL.Foreground = Data.GetFGLabelColor(CB_LIMCOLFire.SelectedIndex, CB_LIMCOLGroup.SelectedIndex);

                    //Decon Limpet
                    CB_LIMDECFire.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetDecontamination.FireMode;
                    CB_LIMDECGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetDecontamination.FireGroup;
                    Label_LIMDEC.Foreground = Data.GetFGLabelColor(CB_LIMDECFire.SelectedIndex, CB_LIMDECGroup.SelectedIndex);

                    //Fuel Limpet
                    CB_LIMFFire.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetFuel.FireMode;
                    CB_LIMFGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetFuel.FireGroup;
                    Label_LIMF.Foreground = Data.GetFGLabelColor(CB_LIMFFire.SelectedIndex, CB_LIMFGroup.SelectedIndex);

                    //Hatch Breaker Limpet
                    CB_LIMHBFire.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetHatchBreaker.FireMode;
                    CB_LIMHBGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetHatchBreaker.FireGroup;
                    Label_LIMHB.Foreground = Data.GetFGLabelColor(CB_LIMHBFire.SelectedIndex, CB_LIMHBGroup.SelectedIndex);

                    //Prospector Limpet
                    CB_LIMPROFire.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetProspector.FireMode;
                    CB_LIMPROGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetProspector.FireGroup;
                    Label_LIMPRO.Foreground = Data.GetFGLabelColor(CB_LIMPROFire.SelectedIndex, CB_LIMPROGroup.SelectedIndex);

                    //Recon Limpet
                    CB_LIMRECFire.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetRecon.FireMode;
                    CB_LIMRECGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetRecon.FireGroup;
                    Label_LIMREC.Foreground = Data.GetFGLabelColor(CB_LIMRECFire.SelectedIndex, CB_LIMRECGroup.SelectedIndex);

                    //Repair Limpet
                    CB_LIMREPFire.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetRepair.FireMode;
                    CB_LIMREPGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetRepair.FireGroup;
                    Label_LIMREP.Foreground = Data.GetFGLabelColor(CB_LIMREPFire.SelectedIndex, CB_LIMREPGroup.SelectedIndex);

                    //Research Limpet
                    CB_LIMRESFire.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetResearch.FireMode;
                    CB_LIMRESGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.LimpetResearch.FireGroup;
                    Label_LIMRES.Foreground = Data.GetFGLabelColor(CB_LIMRESFire.SelectedIndex, CB_LIMRESGroup.SelectedIndex);

                    //Shield Cell 1
                    CB_SC1Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellOne.FireMode;
                    CB_SC1Group.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellOne.FireGroup;
                    Label_SC1.Foreground = Data.GetFGLabelColor(CB_SC1Fire.SelectedIndex, CB_SC1Group.SelectedIndex);

                    //Shield Cell 2
                    CB_SC2Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellTwo.FireMode;
                    CB_SC2Group.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellTwo.FireGroup;
                    Label_SC2.Foreground = Data.GetFGLabelColor(CB_SC2Fire.SelectedIndex, CB_SC2Group.SelectedIndex);

                    //Shutdown Field Neutralizer
                    CB_SFNFire.SelectedIndex = (int)TKSettings.Firegroup.Config.FieldNeutraliser.FireMode;
                    CB_SFNGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.FieldNeutraliser.FireGroup;
                    Label_SFN.Foreground = Data.GetFGLabelColor(CB_SFNFire.SelectedIndex, CB_SFNGroup.SelectedIndex);

                    //Cargo Scanner
                    CB_SNCARGFire.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerCagro.FireMode;
                    CB_SNCARGGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerCagro.FireGroup;
                    Label_SNCARG.Foreground = Data.GetFGLabelColor(CB_SNCARGFire.SelectedIndex, CB_SNCARGGroup.SelectedIndex);

                    //Composite Scanner
                    CB_SNCOMPFire.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerComposite.FireMode;
                    CB_SNCOMPGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerComposite.FireGroup;
                    Label_SNCOMP.Foreground = Data.GetFGLabelColor(CB_SNCOMPFire.SelectedIndex, CB_SNCOMPGroup.SelectedIndex);

                    //Discovery Scanner
                    CB_SNDISCFire.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerDiscovery.FireMode;
                    CB_SNDISCGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerDiscovery.FireGroup;
                    Label_SNDISC.Foreground = Data.GetFGLabelColor(CB_SNDISCFire.SelectedIndex, CB_SNDISCGroup.SelectedIndex);
                    
                    //Kill Warrent Scanner
                    CB_SNKILLFire.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerKillwarrent.FireMode;
                    CB_SNKILLGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerKillwarrent.FireGroup;
                    Label_SNKILL.Foreground = Data.GetFGLabelColor(CB_SNKILLFire.SelectedIndex, CB_SNKILLGroup.SelectedIndex);

                    //Detailed Surface Scanner
                    CB_SNSURFFire.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerSurface.FireMode;
                    CB_SNSURFGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerSurface.FireGroup;
                    Label_SNSURF.Foreground = Data.GetFGLabelColor(CB_SNSURFFire.SelectedIndex, CB_SNSURFGroup.SelectedIndex);

                    //Wake Scanner
                    CB_SNWAKEFire.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerWake.FireMode;
                    CB_SNWAKEGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerWake.FireGroup;
                    Label_SNWAKE.Foreground = Data.GetFGLabelColor(CB_SNWAKEFire.SelectedIndex, CB_SNWAKEGroup.SelectedIndex);

                    //Xeno Scanner
                    CB_SNXENOFire.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerXeno.FireMode;
                    CB_SNXENOGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.ScannerXeno.FireGroup;
                    Label_SNXENO.Foreground = Data.GetFGLabelColor(CB_SNXENOFire.SelectedIndex, CB_SNXENOGroup.SelectedIndex);
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception" + ex);
                    Logger.Exception(MethodName, "Somthing Went Wrong While Updating The UI");
                }
            });

            //Enable Saving
            TKSettings.Save = true;
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

        #region Firegroup Items
        private void CB_ECMGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ECM.FireGroup = (ConfigurationHardpoints.Group)CB_ECMGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_ECMFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ECM.FireMode = (ConfigurationHardpoints.Fire)CB_ECMFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SFNGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.FieldNeutraliser.FireGroup = (ConfigurationHardpoints.Group)CB_SFNGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SFNFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.FieldNeutraliser.FireMode = (ConfigurationHardpoints.Fire)CB_SFNFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_FSDIGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.FSDInterdictor.FireGroup = (ConfigurationHardpoints.Group)CB_FSDIGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_FSDIFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.FSDInterdictor.FireMode = (ConfigurationHardpoints.Fire)CB_FSDIFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMCOLGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetCollector.FireGroup = (ConfigurationHardpoints.Group)CB_LIMCOLGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMCOLFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetCollector.FireMode = (ConfigurationHardpoints.Fire)CB_LIMCOLFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMDECGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetDecontamination.FireGroup = (ConfigurationHardpoints.Group)CB_LIMDECGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMDECFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetDecontamination.FireMode = (ConfigurationHardpoints.Fire)CB_LIMDECFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMFGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetFuel.FireGroup = (ConfigurationHardpoints.Group)CB_LIMFGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMFFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetFuel.FireMode = (ConfigurationHardpoints.Fire)CB_LIMFFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMHBGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetHatchBreaker.FireGroup = (ConfigurationHardpoints.Group)CB_LIMHBGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMHBFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetHatchBreaker.FireMode = (ConfigurationHardpoints.Fire)CB_LIMHBFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMRECGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetRecon.FireGroup = (ConfigurationHardpoints.Group)CB_LIMRECGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMRECFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetRecon.FireMode = (ConfigurationHardpoints.Fire)CB_LIMRECFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMREPGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetRepair.FireGroup = (ConfigurationHardpoints.Group)CB_LIMREPGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMREPFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetRepair.FireMode = (ConfigurationHardpoints.Fire)CB_LIMREPFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMRESGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetResearch.FireGroup = (ConfigurationHardpoints.Group)CB_LIMRESGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMRESFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetResearch.FireMode = (ConfigurationHardpoints.Fire)CB_LIMRESFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMPROGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetProspector.FireGroup = (ConfigurationHardpoints.Group)CB_LIMPROGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_LIMPROFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LimpetProspector.FireMode = (ConfigurationHardpoints.Fire)CB_LIMPROFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_HS1GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherHeatSinkOne.FireGroup = (ConfigurationHardpoints.Group)CB_HS1Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_HS1FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherHeatSinkOne.FireMode = (ConfigurationHardpoints.Fire)CB_HS1Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_HS2GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherHeatSinkTwo.FireGroup = (ConfigurationHardpoints.Group)CB_HS2Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_HS2FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherHeatSinkTwo.FireMode = (ConfigurationHardpoints.Fire)CB_HS2Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SC1GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ShieldCellOne.FireGroup = (ConfigurationHardpoints.Group)CB_SC1Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SC1FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ShieldCellOne.FireMode = (ConfigurationHardpoints.Fire)CB_SC1Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SC2GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ShieldCellTwo.FireGroup = (ConfigurationHardpoints.Group)CB_SC2Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SC2FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ShieldCellTwo.FireMode = (ConfigurationHardpoints.Fire)CB_SC2Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_CF1GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherChaffOne.FireGroup = (ConfigurationHardpoints.Group)CB_CF1Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_CF1FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherChaffOne.FireMode = (ConfigurationHardpoints.Fire)CB_CF1Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_CF2GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherChaffTwo.FireGroup = (ConfigurationHardpoints.Group)CB_CF2Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_CF2FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherChaffTwo.FireMode = (ConfigurationHardpoints.Fire)CB_CF2Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNCARGGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerCagro.FireGroup = (ConfigurationHardpoints.Group)CB_SNCARGGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNCARGFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerCagro.FireMode = (ConfigurationHardpoints.Fire)CB_SNCARGFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNCOMPGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerComposite.FireGroup = (ConfigurationHardpoints.Group)CB_SNCOMPGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNCOMPFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerComposite.FireMode = (ConfigurationHardpoints.Fire)CB_SNCOMPFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNDISCGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerDiscovery.FireGroup = (ConfigurationHardpoints.Group)CB_SNDISCGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNDISCFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerDiscovery.FireMode = (ConfigurationHardpoints.Fire)CB_SNDISCFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNKILLGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerKillwarrent.FireGroup = (ConfigurationHardpoints.Group)CB_SNKILLGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNKILLFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerKillwarrent.FireMode = (ConfigurationHardpoints.Fire)CB_SNKILLFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNSURFGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerSurface.FireGroup = (ConfigurationHardpoints.Group)CB_SNSURFGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNSURFFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerSurface.FireMode = (ConfigurationHardpoints.Fire)CB_SNSURFFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNXENOGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerXeno.FireGroup = (ConfigurationHardpoints.Group)CB_SNXENOGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNXENOFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerXeno.FireMode = (ConfigurationHardpoints.Fire)CB_SNXENOFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNWAKEGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerWake.FireGroup = (ConfigurationHardpoints.Group)CB_SNWAKEGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNWAKEFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ScannerWake.FireMode = (ConfigurationHardpoints.Fire)CB_SNWAKEFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }
        #endregion
    }
}
