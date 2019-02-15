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
        public static string MethodName = "Toolkit Settings";

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
            string MethodName = "(Toolkit) Update Buttons";

            this.Dispatcher.Invoke(() =>
            {
                try
                {
                    Label_CommanderName.Content = "CMDR " + Data.User.Commander;

                    #region PlugIn
                    //Firegroup Offset
                    Slider_DelayFiregroup.Value = Data.User.OffsetFireGroups;
                    TextBox_DelayFiregroup.Text = Data.User.OffsetFireGroups.ToString() + "ms";
                    //Panel Offset
                    Slider_DelayPanel.Value = Data.User.OffsetPanels;
                    TextBox_DelayPanel.Text = Data.User.OffsetPanels.ToString() + "ms";
                    //Power Offset
                    Slider_DelayPower.Value = Data.User.OffsetPips;
                    TextBox_DelayPower.Text = Data.User.OffsetPips.ToString() + "ms";
                    //Throttle Offset
                    Slider_DelayThrottle.Value = Data.User.OffsetThrottle;
                    TextBox_DelayThrottle.Text = Data.User.OffsetThrottle.ToString() + "ms";
                    #endregion

                    #region Reports
                    btn_FuelScoop.Foreground = Data.GetTextColor(Data.User.FuelScoop);
                    btn_FuelStatus.Foreground = Data.GetTextColor(Data.User.FuelStatus);
                    btn_MaterialCollected.Foreground = Data.GetTextColor(Data.User.MaterialCollected);
                    btn_NoFireZone.Foreground = Data.GetTextColor(Data.User.NoFireZone);
                    btn_StationStatus.Foreground = Data.GetTextColor(Data.User.StationStatus);
                    btn_ShieldStatus.Foreground = Data.GetTextColor(Data.User.ShieldState);
                    btn_CollectedBounty.Foreground = Data.GetTextColor(Data.User.CollectedBounty);
                    btn_TargetEnemy.Foreground = Data.GetTextColor(Data.User.TargetEnemy);
                    btn_WatnedTarget.Foreground = Data.GetTextColor(Data.User.TargetWanted);
                    btn_RefinedMaterials.Foreground = Data.GetTextColor(Data.User.MaterialRefined);
                    btn_Masslock.Foreground = Data.GetTextColor(Data.User.Masslock);
                    #endregion

                    #region Orders
                    btn_AssistedCombatPower.Foreground = Data.GetTextColor(Data.User.CombatPower);
                    btn_AssistedSystemScans.Foreground = Data.GetTextColor(Data.User.AssistSystemScan);
                    btn_AssistedDockingProcedures.Foreground = Data.GetTextColor(Data.User.AssistDocking);
                    btn_AssistedHangerEntry.Foreground = Data.GetTextColor(Data.User.AssistHangerEntry);
                    btn_PostJumpSafeties.Foreground = Data.GetTextColor(Data.User.PostHyperspaceSafety);
                    btn_WeaponSafty.Foreground = Data.GetTextColor(Data.User.WeaponSafety);
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

                    //Chaff 2
                    CB_CF2Fire.SelectedIndex = (int)Data.Firegroup.LauncherChaffTwo.FireMode;
                    CB_CF2Group.SelectedIndex = (int)Data.Firegroup.LauncherChaffTwo.FireGroup;

                    //ECM
                    CB_ECMFire.SelectedIndex = (int)Data.Firegroup.ECM.FireMode; 
                    CB_ECMGroup.SelectedIndex = (int)Data.Firegroup.ECM.FireGroup;

                    //FSD Interdictor
                    CB_FSDIFire.SelectedIndex = (int)Data.Firegroup.FSDInterdictor.FireMode;
                    CB_FSDIGroup.SelectedIndex = (int)Data.Firegroup.FSDInterdictor.FireGroup;


                    CB_HS1Fire.SelectedIndex = (int)Data.Firegroup.LauncherHeatSinkOne.FireMode;
                    CB_HS1Group.SelectedIndex = (int)Data.Firegroup.LauncherHeatSinkOne.FireGroup;


                    CB_HS2Fire.SelectedIndex = (int)Data.Firegroup.LauncherHeatSinkTwo.FireMode;
                    CB_HS2Group.SelectedIndex = (int)Data.Firegroup.LauncherHeatSinkTwo.FireGroup;


                    CB_LIMCOLFire.SelectedIndex = (int)Data.Firegroup.LimpetCollector.FireMode;
                    CB_LIMCOLGroup.SelectedIndex = (int)Data.Firegroup.LimpetCollector.FireGroup;


                    CB_LIMDECFire.SelectedIndex = (int)Data.Firegroup.LimpetDecontamination.FireMode;
                    CB_LIMDECGroup.SelectedIndex = (int)Data.Firegroup.LimpetDecontamination.FireGroup;


                    CB_LIMFFire.SelectedIndex = (int)Data.Firegroup.LimpetFuel.FireMode;
                    CB_LIMFGroup.SelectedIndex = (int)Data.Firegroup.LimpetFuel.FireGroup;


                    CB_LIMHBFire.SelectedIndex = (int)Data.Firegroup.LimpetHatchBreaker.FireMode;
                    CB_LIMHBGroup.SelectedIndex = (int)Data.Firegroup.LimpetHatchBreaker.FireGroup;


                    CB_LIMPROFire.SelectedIndex = (int)Data.Firegroup.LimpetProspector.FireMode;
                    CB_LIMPROGroup.SelectedIndex = (int)Data.Firegroup.LimpetProspector.FireGroup;


                    CB_LIMRECFire.SelectedIndex = (int)Data.Firegroup.LimpetRecon.FireMode;
                    CB_LIMRECGroup.SelectedIndex = (int)Data.Firegroup.LimpetRecon.FireGroup;


                    CB_LIMREPFire.SelectedIndex = (int)Data.Firegroup.LimpetRepair.FireMode;
                    CB_LIMREPGroup.SelectedIndex = (int)Data.Firegroup.LimpetRepair.FireGroup;


                    CB_LIMRESFire.SelectedIndex = (int)Data.Firegroup.LimpetResearch.FireMode;
                    CB_LIMRESGroup.SelectedIndex = (int)Data.Firegroup.LimpetResearch.FireGroup;


                    CB_SC1Fire.SelectedIndex = (int)Data.Firegroup.ShieldCellOne.FireMode;
                    CB_SC1Group.SelectedIndex = (int)Data.Firegroup.ShieldCellOne.FireGroup;


                    CB_SC2Fire.SelectedIndex = (int)Data.Firegroup.ShieldCellTwo.FireMode;
                    CB_SC2Group.SelectedIndex = (int)Data.Firegroup.ShieldCellTwo.FireGroup;


                    CB_SFNFire.SelectedIndex = (int)Data.Firegroup.FieldNeutraliser.FireMode;
                    CB_SFNGroup.SelectedIndex = (int)Data.Firegroup.FieldNeutraliser.FireGroup;


                    CB_SNCARGFire.SelectedIndex = (int)Data.Firegroup.ScannerCagro.FireMode;
                    CB_SNCARGGroup.SelectedIndex = (int)Data.Firegroup.ScannerCagro.FireGroup;


                    CB_SNCOMPFire.SelectedIndex = (int)Data.Firegroup.ScannerComposite.FireMode;
                    CB_SNCOMPGroup.SelectedIndex = (int)Data.Firegroup.ScannerComposite.FireGroup;


                    CB_SNDISCFire.SelectedIndex = (int)Data.Firegroup.ScannerDiscovery.FireMode;
                    CB_SNDISCGroup.SelectedIndex = (int)Data.Firegroup.ScannerDiscovery.FireGroup;


                    CB_SNKILLFire.SelectedIndex = (int)Data.Firegroup.ScannerKillwarrent.FireMode;
                    CB_SNKILLGroup.SelectedIndex = (int)Data.Firegroup.ScannerKillwarrent.FireGroup;


                    CB_SNSURFFire.SelectedIndex = (int)Data.Firegroup.ScannerSurface.FireMode;
                    CB_SNSURFGroup.SelectedIndex = (int)Data.Firegroup.ScannerSurface.FireGroup;


                    CB_SNWAKEFire.SelectedIndex = (int)Data.Firegroup.ScannerWake.FireMode;
                    CB_SNWAKEGroup.SelectedIndex = (int)Data.Firegroup.ScannerWake.FireGroup;


                    CB_SNXENOFire.SelectedIndex = (int)Data.Firegroup.ScannerXeno.FireMode;
                    CB_SNXENOGroup.SelectedIndex = (int)Data.Firegroup.ScannerXeno.FireGroup;

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
            Data.User.OffsetPanels = (int)Slider_DelayPanel.Value;
            Data.SaveUserSettings();
        }

        private void Slider_DelayPower_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Data.User.OffsetPips = (int)Slider_DelayPower.Value;
            Data.SaveUserSettings();
        }

        private void Slider_DelayFiregroup_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Data.User.OffsetFireGroups = (int)Slider_DelayFiregroup.Value;
            Data.SaveUserSettings();
        }

        private void Slider_DelayThrottle_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Data.User.OffsetThrottle = (int)Slider_DelayThrottle.Value;
            Data.SaveUserSettings();
        }
        #endregion

        #region Reports
        private void btn_FuelScoop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data.User.FuelScoop = !Data.User.FuelScoop;
                btn_FuelScoop.Foreground = Data.GetTextColor(Data.User.FuelScoop);
                Data.SaveUserSettings();
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
                Data.User.FuelStatus = !Data.User.FuelStatus;
                btn_FuelStatus.Foreground = Data.GetTextColor(Data.User.FuelStatus);
                Data.SaveUserSettings();
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
                Data.User.MaterialCollected = !Data.User.MaterialCollected;
                btn_MaterialCollected.Foreground = Data.GetTextColor(Data.User.MaterialCollected);
                Data.SaveUserSettings();
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
                Data.User.NoFireZone = !Data.User.NoFireZone;
                btn_NoFireZone.Foreground = Data.GetTextColor(Data.User.NoFireZone);
                Data.SaveUserSettings();
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
                Data.User.StationStatus = !Data.User.StationStatus;
                btn_StationStatus.Foreground = Data.GetTextColor(Data.User.StationStatus);
                Data.SaveUserSettings();
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
                Data.User.ShieldState = !Data.User.ShieldState;
                btn_ShieldStatus.Foreground = Data.GetTextColor(Data.User.ShieldState);
                Data.SaveUserSettings();
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
                Data.User.CollectedBounty = !Data.User.CollectedBounty;
                btn_CollectedBounty.Foreground = Data.GetTextColor(Data.User.CollectedBounty);
                Data.SaveUserSettings();
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
                Data.User.TargetEnemy = !Data.User.TargetEnemy;
                btn_TargetEnemy.Foreground = Data.GetTextColor(Data.User.TargetEnemy);
                Data.SaveUserSettings();
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
                Data.User.TargetWanted = !Data.User.TargetWanted;
                btn_WatnedTarget.Foreground = Data.GetTextColor(Data.User.TargetWanted);
                Data.SaveUserSettings();
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
                Data.User.MaterialRefined = !Data.User.MaterialRefined;
                btn_RefinedMaterials.Foreground = Data.GetTextColor(Data.User.MaterialRefined);
                Data.SaveUserSettings();
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
                Data.User.Masslock = !Data.User.Masslock;
                btn_Masslock.Foreground = Data.GetTextColor(Data.User.Masslock);
                Data.SaveUserSettings();
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
                Data.User.CombatPower = !Data.User.CombatPower;
                btn_AssistedCombatPower.Foreground = Data.GetTextColor(Data.User.CombatPower);
                Data.SaveUserSettings();
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
                Data.User.AssistSystemScan = !Data.User.AssistSystemScan;
                btn_AssistedSystemScans.Foreground = Data.GetTextColor(Data.User.AssistSystemScan);
                Data.SaveUserSettings();
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
                Data.User.AssistDocking = !Data.User.AssistDocking;
                btn_AssistedDockingProcedures.Foreground = Data.GetTextColor(Data.User.AssistDocking);
                Data.SaveUserSettings();
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
                Data.User.AssistHangerEntry = !Data.User.AssistHangerEntry;
                btn_AssistedHangerEntry.Foreground = Data.GetTextColor(Data.User.AssistHangerEntry);
                Data.SaveUserSettings();
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
                Data.User.PostHyperspaceSafety = !Data.User.PostHyperspaceSafety;
                btn_PostJumpSafeties.Foreground = Data.GetTextColor(Data.User.PostHyperspaceSafety);
                Data.SaveUserSettings();
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
                Data.User.WeaponSafety = !Data.User.WeaponSafety;
                btn_WeaponSafty.Foreground = Data.GetTextColor(Data.User.WeaponSafety);
                Data.SaveUserSettings();
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
