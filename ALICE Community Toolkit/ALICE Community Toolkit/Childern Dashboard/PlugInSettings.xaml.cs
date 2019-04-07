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
using Newtonsoft.Json;
using System.IO;
using ALICE_Internal;
using ALICE_Settings;

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
                    Slider_DelayFiregroup.Value = Data.OffsetFireGroups;
                    TextBox_DelayFiregroup.Text = Data.OffsetFireGroups.ToString() + "ms";
                    //Panel Offset
                    Slider_DelayPanel.Value = Data.OffsetPanels;
                    TextBox_DelayPanel.Text = Data.OffsetPanels.ToString() + "ms";
                    //Power Offset
                    Slider_DelayPower.Value = Data.OffsetPips;
                    TextBox_DelayPower.Text = Data.OffsetPips.ToString() + "ms";
                    //Throttle Offset
                    Slider_DelayThrottle.Value = Data.OffsetThrottle;
                    TextBox_DelayThrottle.Text = Data.OffsetThrottle.ToString() + "ms";
                    #endregion

                    #region Reports
                    btn_FuelScoop.Foreground = Data.GetTextColor(Data.FuelScoop);
                    btn_FuelStatus.Foreground = Data.GetTextColor(Data.FuelStatus);
                    btn_MaterialCollected.Foreground = Data.GetTextColor(Data.MaterialCollected);
                    btn_NoFireZone.Foreground = Data.GetTextColor(Data.NoFireZone);
                    btn_StationStatus.Foreground = Data.GetTextColor(Data.StationStatus);
                    btn_ShieldStatus.Foreground = Data.GetTextColor(Data.ShieldState);
                    btn_CollectedBounty.Foreground = Data.GetTextColor(Data.CollectedBounty);
                    btn_TargetEnemy.Foreground = Data.GetTextColor(Data.TargetEnemy);
                    btn_WatnedTarget.Foreground = Data.GetTextColor(Data.TargetWanted);
                    btn_RefinedMaterials.Foreground = Data.GetTextColor(Data.MaterialRefined);
                    btn_Masslock.Foreground = Data.GetTextColor(Data.Masslock);
                    btn_HighGravity.Foreground = Data.GetTextColor(Data.HighGravDescent);
                    btn_TravelDistance.Foreground = Data.GetTextColor(Data.ScanTravelDist);
                    btn_LandableVolcanism.Foreground = Data.GetTextColor(Data.LandableVolcanism);
                    btn_GlideStatus.Foreground = Data.GetTextColor(Data.GlideStatus);
                    #endregion

                    #region Orders
                    btn_AssistedCombatPower.Foreground = Data.GetTextColor(Data.CombatPower);
                    btn_AssistedSystemScans.Foreground = Data.GetTextColor(Data.AssistSystemScan);
                    btn_AssistedDockingProcedures.Foreground = Data.GetTextColor(Data.AssistDocking);
                    btn_AssistedHangerEntry.Foreground = Data.GetTextColor(Data.AssistHangerEntry);
                    btn_PostJumpSafeties.Foreground = Data.GetTextColor(Data.PostHyperspaceSafety);
                    btn_WeaponSafty.Foreground = Data.GetTextColor(Data.WeaponSafety);
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
            Data.SaveFiregroup = false;

            this.Dispatcher.Invoke(() =>
            {
                try
                {
                    Label_CurrentShip.Content = Data.Firegroup.ShipAssignment;

                    //Chaff 1
                    CB_CF1Fire.SelectedIndex = (int)Data.Firegroup.LauncherChaffOne.FireMode;
                    CB_CF1Group.SelectedIndex = (int)Data.Firegroup.LauncherChaffOne.FireGroup;
                    Label_CH1.Foreground = Data.GetFGLabelColor(CB_CF1Fire.SelectedIndex, CB_CF1Group.SelectedIndex);

                    //Chaff 2
                    CB_CF2Fire.SelectedIndex = (int)Data.Firegroup.LauncherChaffTwo.FireMode;
                    CB_CF2Group.SelectedIndex = (int)Data.Firegroup.LauncherChaffTwo.FireGroup;
                    Label_CH2.Foreground = Data.GetFGLabelColor(CB_CF2Fire.SelectedIndex, CB_CF2Group.SelectedIndex);

                    //ECM
                    CB_ECMFire.SelectedIndex = (int)Data.Firegroup.ECM.FireMode; 
                    CB_ECMGroup.SelectedIndex = (int)Data.Firegroup.ECM.FireGroup;
                    Label_ECM.Foreground = Data.GetFGLabelColor(CB_ECMFire.SelectedIndex, CB_ECMGroup.SelectedIndex);

                    //FSD Interdictor
                    CB_FSDIFire.SelectedIndex = (int)Data.Firegroup.FSDInterdictor.FireMode;
                    CB_FSDIGroup.SelectedIndex = (int)Data.Firegroup.FSDInterdictor.FireGroup;
                    Label_FSDI.Foreground = Data.GetFGLabelColor(CB_FSDIFire.SelectedIndex, CB_FSDIGroup.SelectedIndex);

                    //Heatsink 1
                    CB_HS1Fire.SelectedIndex = (int)Data.Firegroup.LauncherHeatSinkOne.FireMode;
                    CB_HS1Group.SelectedIndex = (int)Data.Firegroup.LauncherHeatSinkOne.FireGroup;
                    Label_HS1.Foreground = Data.GetFGLabelColor(CB_HS1Fire.SelectedIndex, CB_HS1Group.SelectedIndex);

                    //Heatsink 2
                    CB_HS2Fire.SelectedIndex = (int)Data.Firegroup.LauncherHeatSinkTwo.FireMode;
                    CB_HS2Group.SelectedIndex = (int)Data.Firegroup.LauncherHeatSinkTwo.FireGroup;
                    Label_HS2.Foreground = Data.GetFGLabelColor(CB_HS2Fire.SelectedIndex, CB_HS2Group.SelectedIndex);

                    //Collector Limpet
                    CB_LIMCOLFire.SelectedIndex = (int)Data.Firegroup.LimpetCollector.FireMode;
                    CB_LIMCOLGroup.SelectedIndex = (int)Data.Firegroup.LimpetCollector.FireGroup;
                    Label_LIMCOL.Foreground = Data.GetFGLabelColor(CB_LIMCOLFire.SelectedIndex, CB_LIMCOLGroup.SelectedIndex);

                    //Decon Limpet
                    CB_LIMDECFire.SelectedIndex = (int)Data.Firegroup.LimpetDecontamination.FireMode;
                    CB_LIMDECGroup.SelectedIndex = (int)Data.Firegroup.LimpetDecontamination.FireGroup;
                    Label_LIMDEC.Foreground = Data.GetFGLabelColor(CB_LIMDECFire.SelectedIndex, CB_LIMDECGroup.SelectedIndex);

                    //Fuel Limpet
                    CB_LIMFFire.SelectedIndex = (int)Data.Firegroup.LimpetFuel.FireMode;
                    CB_LIMFGroup.SelectedIndex = (int)Data.Firegroup.LimpetFuel.FireGroup;
                    Label_LIMF.Foreground = Data.GetFGLabelColor(CB_LIMFFire.SelectedIndex, CB_LIMFGroup.SelectedIndex);

                    //Hatch Breaker Limpet
                    CB_LIMHBFire.SelectedIndex = (int)Data.Firegroup.LimpetHatchBreaker.FireMode;
                    CB_LIMHBGroup.SelectedIndex = (int)Data.Firegroup.LimpetHatchBreaker.FireGroup;
                    Label_LIMHB.Foreground = Data.GetFGLabelColor(CB_LIMHBFire.SelectedIndex, CB_LIMHBGroup.SelectedIndex);

                    //Prospector Limpet
                    CB_LIMPROFire.SelectedIndex = (int)Data.Firegroup.LimpetProspector.FireMode;
                    CB_LIMPROGroup.SelectedIndex = (int)Data.Firegroup.LimpetProspector.FireGroup;
                    Label_LIMPRO.Foreground = Data.GetFGLabelColor(CB_LIMPROFire.SelectedIndex, CB_LIMPROGroup.SelectedIndex);

                    //Recon Limpet
                    CB_LIMRECFire.SelectedIndex = (int)Data.Firegroup.LimpetRecon.FireMode;
                    CB_LIMRECGroup.SelectedIndex = (int)Data.Firegroup.LimpetRecon.FireGroup;
                    Label_LIMREC.Foreground = Data.GetFGLabelColor(CB_LIMRECFire.SelectedIndex, CB_LIMRECGroup.SelectedIndex);

                    //Repair Limpet
                    CB_LIMREPFire.SelectedIndex = (int)Data.Firegroup.LimpetRepair.FireMode;
                    CB_LIMREPGroup.SelectedIndex = (int)Data.Firegroup.LimpetRepair.FireGroup;
                    Label_LIMREP.Foreground = Data.GetFGLabelColor(CB_LIMREPFire.SelectedIndex, CB_LIMREPGroup.SelectedIndex);

                    //Research Limpet
                    CB_LIMRESFire.SelectedIndex = (int)Data.Firegroup.LimpetResearch.FireMode;
                    CB_LIMRESGroup.SelectedIndex = (int)Data.Firegroup.LimpetResearch.FireGroup;
                    Label_LIMRES.Foreground = Data.GetFGLabelColor(CB_LIMRESFire.SelectedIndex, CB_LIMRESGroup.SelectedIndex);

                    //Shield Cell 1
                    CB_SC1Fire.SelectedIndex = (int)Data.Firegroup.ShieldCellOne.FireMode;
                    CB_SC1Group.SelectedIndex = (int)Data.Firegroup.ShieldCellOne.FireGroup;
                    Label_SC1.Foreground = Data.GetFGLabelColor(CB_SC1Fire.SelectedIndex, CB_SC1Group.SelectedIndex);

                    //Shield Cell 2
                    CB_SC2Fire.SelectedIndex = (int)Data.Firegroup.ShieldCellTwo.FireMode;
                    CB_SC2Group.SelectedIndex = (int)Data.Firegroup.ShieldCellTwo.FireGroup;
                    Label_SC2.Foreground = Data.GetFGLabelColor(CB_SC2Fire.SelectedIndex, CB_SC2Group.SelectedIndex);

                    //Shutdown Field Neutralizer
                    CB_SFNFire.SelectedIndex = (int)Data.Firegroup.FieldNeutraliser.FireMode;
                    CB_SFNGroup.SelectedIndex = (int)Data.Firegroup.FieldNeutraliser.FireGroup;
                    Label_SFN.Foreground = Data.GetFGLabelColor(CB_SFNFire.SelectedIndex, CB_SFNGroup.SelectedIndex);

                    //Cargo Scanner
                    CB_SNCARGFire.SelectedIndex = (int)Data.Firegroup.ScannerCagro.FireMode;
                    CB_SNCARGGroup.SelectedIndex = (int)Data.Firegroup.ScannerCagro.FireGroup;
                    Label_SNCARG.Foreground = Data.GetFGLabelColor(CB_SNCARGFire.SelectedIndex, CB_SNCARGGroup.SelectedIndex);

                    //Composite Scanner
                    CB_SNCOMPFire.SelectedIndex = (int)Data.Firegroup.ScannerComposite.FireMode;
                    CB_SNCOMPGroup.SelectedIndex = (int)Data.Firegroup.ScannerComposite.FireGroup;
                    Label_SNCOMP.Foreground = Data.GetFGLabelColor(CB_SNCOMPFire.SelectedIndex, CB_SNCOMPGroup.SelectedIndex);

                    //Discovery Scanner
                    CB_SNDISCFire.SelectedIndex = (int)Data.Firegroup.ScannerDiscovery.FireMode;
                    CB_SNDISCGroup.SelectedIndex = (int)Data.Firegroup.ScannerDiscovery.FireGroup;
                    Label_SNDISC.Foreground = Data.GetFGLabelColor(CB_SNDISCFire.SelectedIndex, CB_SNDISCGroup.SelectedIndex);
                    
                    //Kill Warrent Scanner
                    CB_SNKILLFire.SelectedIndex = (int)Data.Firegroup.ScannerKillwarrent.FireMode;
                    CB_SNKILLGroup.SelectedIndex = (int)Data.Firegroup.ScannerKillwarrent.FireGroup;
                    Label_SNKILL.Foreground = Data.GetFGLabelColor(CB_SNKILLFire.SelectedIndex, CB_SNKILLGroup.SelectedIndex);

                    //Detailed Surface Scanner
                    CB_SNSURFFire.SelectedIndex = (int)Data.Firegroup.ScannerSurface.FireMode;
                    CB_SNSURFGroup.SelectedIndex = (int)Data.Firegroup.ScannerSurface.FireGroup;
                    Label_SNSURF.Foreground = Data.GetFGLabelColor(CB_SNSURFFire.SelectedIndex, CB_SNSURFGroup.SelectedIndex);

                    //Wake Scanner
                    CB_SNWAKEFire.SelectedIndex = (int)Data.Firegroup.ScannerWake.FireMode;
                    CB_SNWAKEGroup.SelectedIndex = (int)Data.Firegroup.ScannerWake.FireGroup;
                    Label_SNWAKE.Foreground = Data.GetFGLabelColor(CB_SNWAKEFire.SelectedIndex, CB_SNWAKEGroup.SelectedIndex);

                    //Xeno Scanner
                    CB_SNXENOFire.SelectedIndex = (int)Data.Firegroup.ScannerXeno.FireMode;
                    CB_SNXENOGroup.SelectedIndex = (int)Data.Firegroup.ScannerXeno.FireGroup;
                    Label_SNXENO.Foreground = Data.GetFGLabelColor(CB_SNXENOFire.SelectedIndex, CB_SNXENOGroup.SelectedIndex);
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception" + ex);
                    Logger.Exception(MethodName, "Somthing Went Wrong While Updating The UI");
                }
            });

            //Enable Saving
            Data.SaveFiregroup = true;
        }

        #region PlugIn
        private void Slider_DelayPanel_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Data.OffsetPanels = (int)Slider_DelayPanel.Value;
        }

        private void Slider_DelayPower_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Data.OffsetPips = (int)Slider_DelayPower.Value;
        }

        private void Slider_DelayFiregroup_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Data.OffsetFireGroups = (int)Slider_DelayFiregroup.Value;
        }

        private void Slider_DelayThrottle_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Data.OffsetThrottle = (int)Slider_DelayThrottle.Value;
        }
        #endregion

        #region Reports
        private void btn_FuelScoop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data.FuelScoop = !Data.FuelScoop;
                btn_FuelScoop.Foreground = Data.GetTextColor(Data.FuelScoop);
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
                Data.FuelStatus = !Data.FuelStatus;
                btn_FuelStatus.Foreground = Data.GetTextColor(Data.FuelStatus);
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
                Data.MaterialCollected = !Data.MaterialCollected;
                btn_MaterialCollected.Foreground = Data.GetTextColor(Data.MaterialCollected);
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
                Data.NoFireZone = !Data.NoFireZone;
                btn_NoFireZone.Foreground = Data.GetTextColor(Data.NoFireZone);
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
                Data.StationStatus = !Data.StationStatus;
                btn_StationStatus.Foreground = Data.GetTextColor(Data.StationStatus);
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
                Data.ShieldState = !Data.ShieldState;
                btn_ShieldStatus.Foreground = Data.GetTextColor(Data.ShieldState);
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
                Data.CollectedBounty = !Data.CollectedBounty;
                btn_CollectedBounty.Foreground = Data.GetTextColor(Data.CollectedBounty);
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
                Data.TargetEnemy = !Data.TargetEnemy;
                btn_TargetEnemy.Foreground = Data.GetTextColor(Data.TargetEnemy);
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
                Data.TargetWanted = !Data.TargetWanted;
                btn_WatnedTarget.Foreground = Data.GetTextColor(Data.TargetWanted);
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
                Data.MaterialRefined = !Data.MaterialRefined;
                btn_RefinedMaterials.Foreground = Data.GetTextColor(Data.MaterialRefined);
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
                Data.Masslock = !Data.Masslock;
                btn_Masslock.Foreground = Data.GetTextColor(Data.Masslock);
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
                Data.CombatPower = !Data.CombatPower;
                btn_AssistedCombatPower.Foreground = Data.GetTextColor(Data.CombatPower);
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
                Data.AssistSystemScan = !Data.AssistSystemScan;
                btn_AssistedSystemScans.Foreground = Data.GetTextColor(Data.AssistSystemScan);
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
                Data.AssistDocking = !Data.AssistDocking;
                btn_AssistedDockingProcedures.Foreground = Data.GetTextColor(Data.AssistDocking);
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
                Data.AssistHangerEntry = !Data.AssistHangerEntry;
                btn_AssistedHangerEntry.Foreground = Data.GetTextColor(Data.AssistHangerEntry);
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
                Data.PostHyperspaceSafety = !Data.PostHyperspaceSafety;
                btn_PostJumpSafeties.Foreground = Data.GetTextColor(Data.PostHyperspaceSafety);
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
                Data.WeaponSafety = !Data.WeaponSafety;
                btn_WeaponSafty.Foreground = Data.GetTextColor(Data.WeaponSafety);
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
                Data.GlideStatus = !Data.GlideStatus;
                btn_GlideStatus.Foreground = Data.GetTextColor(Data.GlideStatus);
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
                btn_HighGravity.Foreground = Data.GetTextColor(Data.HighGravDescent);
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
                btn_LandableVolcanism.Foreground = Data.GetTextColor(Data.LandableVolcanism);
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
                btn_TravelDistance.Foreground = Data.GetTextColor(Data.ScanTravelDist);
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
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ECM.FireGroup = (Settings_Firegroups.Group)CB_ECMGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_ECMFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ECM.FireMode = (Settings_Firegroups.Fire)CB_ECMFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SFNGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.FieldNeutraliser.FireGroup = (Settings_Firegroups.Group)CB_SFNGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SFNFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.FieldNeutraliser.FireMode = (Settings_Firegroups.Fire)CB_SFNFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_FSDIGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.FSDInterdictor.FireGroup = (Settings_Firegroups.Group)CB_FSDIGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_FSDIFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.FSDInterdictor.FireMode = (Settings_Firegroups.Fire)CB_FSDIFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMCOLGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetCollector.FireGroup = (Settings_Firegroups.Group)CB_LIMCOLGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMCOLFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetCollector.FireMode = (Settings_Firegroups.Fire)CB_LIMCOLFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMDECGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetDecontamination.FireGroup = (Settings_Firegroups.Group)CB_LIMDECGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMDECFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetDecontamination.FireMode = (Settings_Firegroups.Fire)CB_LIMDECFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMFGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetFuel.FireGroup = (Settings_Firegroups.Group)CB_LIMFGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMFFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetFuel.FireMode = (Settings_Firegroups.Fire)CB_LIMFFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMHBGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetHatchBreaker.FireGroup = (Settings_Firegroups.Group)CB_LIMHBGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMHBFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetHatchBreaker.FireMode = (Settings_Firegroups.Fire)CB_LIMHBFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMRECGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetRecon.FireGroup = (Settings_Firegroups.Group)CB_LIMRECGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMRECFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetRecon.FireMode = (Settings_Firegroups.Fire)CB_LIMRECFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMREPGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetRepair.FireGroup = (Settings_Firegroups.Group)CB_LIMREPGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMREPFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetRepair.FireMode = (Settings_Firegroups.Fire)CB_LIMREPFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMRESGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetResearch.FireGroup = (Settings_Firegroups.Group)CB_LIMRESGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMRESFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetResearch.FireMode = (Settings_Firegroups.Fire)CB_LIMRESFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMPROGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetProspector.FireGroup = (Settings_Firegroups.Group)CB_LIMPROGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_LIMPROFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LimpetProspector.FireMode = (Settings_Firegroups.Fire)CB_LIMPROFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_HS1GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LauncherHeatSinkOne.FireGroup = (Settings_Firegroups.Group)CB_HS1Group.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_HS1FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LauncherHeatSinkOne.FireMode = (Settings_Firegroups.Fire)CB_HS1Fire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_HS2GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LauncherHeatSinkTwo.FireGroup = (Settings_Firegroups.Group)CB_HS2Group.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_HS2FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LauncherHeatSinkTwo.FireMode = (Settings_Firegroups.Fire)CB_HS2Fire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SC1GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ShieldCellOne.FireGroup = (Settings_Firegroups.Group)CB_SC1Group.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SC1FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ShieldCellOne.FireMode = (Settings_Firegroups.Fire)CB_SC1Fire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SC2GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ShieldCellTwo.FireGroup = (Settings_Firegroups.Group)CB_SC2Group.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SC2FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ShieldCellTwo.FireMode = (Settings_Firegroups.Fire)CB_SC2Fire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_CF1GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LauncherChaffOne.FireGroup = (Settings_Firegroups.Group)CB_CF1Group.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_CF1FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LauncherChaffOne.FireMode = (Settings_Firegroups.Fire)CB_CF1Fire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_CF2GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LauncherChaffTwo.FireGroup = (Settings_Firegroups.Group)CB_CF2Group.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_CF2FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.LauncherChaffTwo.FireMode = (Settings_Firegroups.Fire)CB_CF2Fire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNCARGGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerCagro.FireGroup = (Settings_Firegroups.Group)CB_SNCARGGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNCARGFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerCagro.FireMode = (Settings_Firegroups.Fire)CB_SNCARGFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNCOMPGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerComposite.FireGroup = (Settings_Firegroups.Group)CB_SNCOMPGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNCOMPFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerComposite.FireMode = (Settings_Firegroups.Fire)CB_SNCOMPFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNDISCGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerDiscovery.FireGroup = (Settings_Firegroups.Group)CB_SNDISCGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNDISCFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerDiscovery.FireMode = (Settings_Firegroups.Fire)CB_SNDISCFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNKILLGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerKillwarrent.FireGroup = (Settings_Firegroups.Group)CB_SNKILLGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNKILLFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerKillwarrent.FireMode = (Settings_Firegroups.Fire)CB_SNKILLFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNSURFGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerSurface.FireGroup = (Settings_Firegroups.Group)CB_SNSURFGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNSURFFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerSurface.FireMode = (Settings_Firegroups.Fire)CB_SNSURFFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNXENOGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerXeno.FireGroup = (Settings_Firegroups.Group)CB_SNXENOGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNXENOFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerXeno.FireMode = (Settings_Firegroups.Fire)CB_SNXENOFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNWAKEGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerWake.FireGroup = (Settings_Firegroups.Group)CB_SNWAKEGroup.SelectedIndex;
            Data.SaveFiregroupSettings();
        }

        private void CB_SNWAKEFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SettingInit == false) { return; }
            Data.Firegroup.ScannerWake.FireMode = (Settings_Firegroups.Fire)CB_SNWAKEFire.SelectedIndex;
            Data.SaveFiregroupSettings();
        }
        #endregion
    }
}
