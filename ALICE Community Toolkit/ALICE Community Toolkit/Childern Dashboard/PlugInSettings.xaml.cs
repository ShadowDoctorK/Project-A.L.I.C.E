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
        public Settings_User User = new Settings_User();
        public Settings_Firegroups Firegroup = new Settings_Firegroups();
        public static object LockFlag = new object();
        public static object SaveLockFlag = new object();
        public static bool Enabled = true;
        public string TimeStampUser = null;
        public string TimeStampFiregroup = null;
        private bool Init = false;
        private bool SaveFiregroup = true;

        private static DirectoryInfo DirSettings = new DirectoryInfo(Paths.ALICE_Settings);

        public static string MethodName = "Toolkit Settings";

        public List<string> Group = new List<string>()
        {
            "None",
            "Alpha",
            "Bravo",
            "Charlie",
            "Delta",
            "Echo",
            "Foxtrot",
            "Golf",
            "Hotel"
        };

        public List<string> Fire = new List<string>()
        {
            "None",
            "Primary",
            "Secondary"
        };

        public Reports()
        {
            InitializeComponent();

            SetBindings();
            LoadUserSettings();
            UpdateButtons();
            StartMonitor();
            Init = true;
        }

        public void SetBindings()
        {
            CB_CF1Fire.ItemsSource = Fire;            
            CB_CF2Fire.ItemsSource = Fire;
            CB_ECMFire.ItemsSource = Fire;
            CB_FSDIFire.ItemsSource = Fire;
            CB_HS1Fire.ItemsSource = Fire;
            CB_HS2Fire.ItemsSource = Fire;
            CB_LIMCOLFire.ItemsSource = Fire;
            CB_LIMDECFire.ItemsSource = Fire;
            CB_LIMFFire.ItemsSource = Fire;
            CB_LIMHBFire.ItemsSource = Fire;
            CB_LIMPROFire.ItemsSource = Fire;
            CB_LIMRECFire.ItemsSource = Fire;
            CB_LIMREPFire.ItemsSource = Fire;
            CB_LIMRESFire.ItemsSource = Fire;
            CB_SC1Fire.ItemsSource = Fire;
            CB_SC2Fire.ItemsSource = Fire;
            CB_SFNFire.ItemsSource = Fire;
            CB_SNCARGFire.ItemsSource = Fire;
            CB_SNCOMPFire.ItemsSource = Fire;
            CB_SNDISCFire.ItemsSource = Fire;
            CB_SNKILLFire.ItemsSource = Fire;
            CB_SNSURFFire.ItemsSource = Fire;
            CB_SNWAKEFire.ItemsSource = Fire;
            CB_SNXENOFire.ItemsSource = Fire;

            CB_CF1Group.ItemsSource = Group;
            CB_CF2Group.ItemsSource = Group;
            CB_ECMGroup.ItemsSource = Group;
            CB_FSDIGroup.ItemsSource = Group;
            CB_HS1Group.ItemsSource = Group;
            CB_HS2Group.ItemsSource = Group;
            CB_LIMCOLGroup.ItemsSource = Group;
            CB_LIMDECGroup.ItemsSource = Group;
            CB_LIMFGroup.ItemsSource = Group;
            CB_LIMHBGroup.ItemsSource = Group;
            CB_LIMPROGroup.ItemsSource = Group;
            CB_LIMRECGroup.ItemsSource = Group;
            CB_LIMREPGroup.ItemsSource = Group;
            CB_LIMRESGroup.ItemsSource = Group;
            CB_SC1Group.ItemsSource = Group;
            CB_SC2Group.ItemsSource = Group;
            CB_SFNGroup.ItemsSource = Group;
            CB_SNCARGGroup.ItemsSource = Group;
            CB_SNCOMPGroup.ItemsSource = Group;
            CB_SNDISCGroup.ItemsSource = Group;
            CB_SNKILLGroup.ItemsSource = Group;
            CB_SNSURFGroup.ItemsSource = Group;
            CB_SNWAKEGroup.ItemsSource = Group;
            CB_SNXENOGroup.ItemsSource = Group;
        }

        public void UpdateButtons()
        {
            string MethodName = "(Toolkit) Update Buttons";

            this.Dispatcher.Invoke(() =>
            {
                try
                {
                    Label_CommanderName.Content = "CMDR " + User.Commander;

                    #region PlugIn
                    //Firegroup Offset
                    Slider_DelayFiregroup.Value = User.OffsetFireGroups;
                    TextBox_DelayFiregroup.Text = User.OffsetFireGroups.ToString() + "ms";
                    //Panel Offset
                    Slider_DelayPanel.Value = User.OffsetPanels;
                    TextBox_DelayPanel.Text = User.OffsetPanels.ToString() + "ms";
                    //Power Offset
                    Slider_DelayPower.Value = User.OffsetPips;
                    TextBox_DelayPower.Text = User.OffsetPips.ToString() + "ms";
                    //Throttle Offset
                    Slider_DelayThrottle.Value = User.OffsetThrottle;
                    TextBox_DelayThrottle.Text = User.OffsetThrottle.ToString() + "ms";
                    #endregion

                    #region Reports
                    btn_FuelScoop.Foreground = GetTextColor(User.FuelScoop);
                    btn_FuelStatus.Foreground = GetTextColor(User.FuelStatus);
                    btn_MaterialCollected.Foreground = GetTextColor(User.MaterialCollected);
                    btn_NoFireZone.Foreground = GetTextColor(User.NoFireZone);
                    btn_StationStatus.Foreground = GetTextColor(User.StationStatus);
                    btn_ShieldStatus.Foreground = GetTextColor(User.ShieldState);
                    btn_CollectedBounty.Foreground = GetTextColor(User.CollectedBounty);
                    btn_TargetEnemy.Foreground = GetTextColor(User.TargetEnemy);
                    btn_WatnedTarget.Foreground = GetTextColor(User.TargetWanted);
                    btn_RefinedMaterials.Foreground = GetTextColor(User.MaterialRefined);
                    btn_Masslock.Foreground = GetTextColor(User.Masslock);
                    #endregion

                    #region Orders
                    btn_AssistedCombatPower.Foreground = GetTextColor(User.CombatPower);
                    btn_AssistedSystemScans.Foreground = GetTextColor(User.AssistSystemScan);
                    btn_AssistedDockingProcedures.Foreground = GetTextColor(User.AssistDocking);
                    btn_AssistedHangerEntry.Foreground = GetTextColor(User.AssistHangerEntry);
                    btn_PostJumpSafeties.Foreground = GetTextColor(User.PostHyperspaceSafety);
                    btn_WeaponSafty.Foreground = GetTextColor(User.WeaponSafety);
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
            SaveFiregroup = false;

            this.Dispatcher.Invoke(() =>
            {
                try
                {
                    Label_CurrentShip.Content = Firegroup.ShipAssignment;

                    //Chaff 1
                    CB_CF1Fire.SelectedIndex = (int)Firegroup.LauncherChaffOne.FireMode;
                    CB_CF1Group.SelectedIndex = (int)Firegroup.LauncherChaffOne.FireGroup;

                    //Chaff 2
                    CB_CF2Fire.SelectedIndex = (int)Firegroup.LauncherChaffTwo.FireMode;
                    CB_CF2Group.SelectedIndex = (int)Firegroup.LauncherChaffTwo.FireGroup;

                    //ECM
                    CB_ECMFire.SelectedIndex = (int)Firegroup.ECM.FireMode; 
                    CB_ECMGroup.SelectedIndex = (int)Firegroup.ECM.FireGroup;

                    //FSD Interdictor
                    CB_FSDIFire.SelectedIndex = (int)Firegroup.FSDInterdictor.FireMode;
                    CB_FSDIGroup.SelectedIndex = (int)Firegroup.FSDInterdictor.FireGroup;


                    CB_HS1Fire.SelectedIndex = (int)Firegroup.LauncherHeatSinkOne.FireMode;
                    CB_HS1Group.SelectedIndex = (int)Firegroup.LauncherHeatSinkOne.FireGroup;


                    CB_HS2Fire.SelectedIndex = (int)Firegroup.LauncherHeatSinkTwo.FireMode;
                    CB_HS2Group.SelectedIndex = (int)Firegroup.LauncherHeatSinkTwo.FireGroup;


                    CB_LIMCOLFire.SelectedIndex = (int)Firegroup.LimpetCollector.FireMode;
                    CB_LIMCOLGroup.SelectedIndex = (int)Firegroup.LimpetCollector.FireGroup;


                    CB_LIMDECFire.SelectedIndex = (int)Firegroup.LimpetDecontamination.FireMode;
                    CB_LIMDECGroup.SelectedIndex = (int)Firegroup.LimpetDecontamination.FireGroup;


                    CB_LIMFFire.SelectedIndex = (int)Firegroup.LimpetFuel.FireMode;
                    CB_LIMFGroup.SelectedIndex = (int)Firegroup.LimpetFuel.FireGroup;


                    CB_LIMHBFire.SelectedIndex = (int)Firegroup.LimpetHatchBreaker.FireMode;
                    CB_LIMHBGroup.SelectedIndex = (int)Firegroup.LimpetHatchBreaker.FireGroup;


                    CB_LIMPROFire.SelectedIndex = (int)Firegroup.LimpetProspector.FireMode;
                    CB_LIMPROGroup.SelectedIndex = (int)Firegroup.LimpetProspector.FireGroup;


                    CB_LIMRECFire.SelectedIndex = (int)Firegroup.LimpetRecon.FireMode;
                    CB_LIMRECGroup.SelectedIndex = (int)Firegroup.LimpetRecon.FireGroup;


                    CB_LIMREPFire.SelectedIndex = (int)Firegroup.LimpetRepair.FireMode;
                    CB_LIMREPGroup.SelectedIndex = (int)Firegroup.LimpetRepair.FireGroup;


                    CB_LIMRESFire.SelectedIndex = (int)Firegroup.LimpetResearch.FireMode;
                    CB_LIMRESGroup.SelectedIndex = (int)Firegroup.LimpetResearch.FireGroup;


                    CB_SC1Fire.SelectedIndex = (int)Firegroup.ShieldCellOne.FireMode;
                    CB_SC1Group.SelectedIndex = (int)Firegroup.ShieldCellOne.FireGroup;


                    CB_SC2Fire.SelectedIndex = (int)Firegroup.ShieldCellTwo.FireMode;
                    CB_SC2Group.SelectedIndex = (int)Firegroup.ShieldCellTwo.FireGroup;


                    CB_SFNFire.SelectedIndex = (int)Firegroup.FieldNeutraliser.FireMode;
                    CB_SFNGroup.SelectedIndex = (int)Firegroup.FieldNeutraliser.FireGroup;


                    CB_SNCARGFire.SelectedIndex = (int)Firegroup.ScannerCagro.FireMode;
                    CB_SNCARGGroup.SelectedIndex = (int)Firegroup.ScannerCagro.FireGroup;


                    CB_SNCOMPFire.SelectedIndex = (int)Firegroup.ScannerComposite.FireMode;
                    CB_SNCOMPGroup.SelectedIndex = (int)Firegroup.ScannerComposite.FireGroup;


                    CB_SNDISCFire.SelectedIndex = (int)Firegroup.ScannerDiscovery.FireMode;
                    CB_SNDISCGroup.SelectedIndex = (int)Firegroup.ScannerDiscovery.FireGroup;


                    CB_SNKILLFire.SelectedIndex = (int)Firegroup.ScannerKillwarrent.FireMode;
                    CB_SNKILLGroup.SelectedIndex = (int)Firegroup.ScannerKillwarrent.FireGroup;


                    CB_SNSURFFire.SelectedIndex = (int)Firegroup.ScannerSurface.FireMode;
                    CB_SNSURFGroup.SelectedIndex = (int)Firegroup.ScannerSurface.FireGroup;


                    CB_SNWAKEFire.SelectedIndex = (int)Firegroup.ScannerWake.FireMode;
                    CB_SNWAKEGroup.SelectedIndex = (int)Firegroup.ScannerWake.FireGroup;


                    CB_SNXENOFire.SelectedIndex = (int)Firegroup.ScannerXeno.FireMode;
                    CB_SNXENOGroup.SelectedIndex = (int)Firegroup.ScannerXeno.FireGroup;

                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception" + ex);
                    Logger.Exception(MethodName, "Somthing Went Wrong While Updating The UI");
                }
            });

            //Enable Saving
            SaveFiregroup = true;
        }

        #region PlugIn
        private void Slider_DelayPanel_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            User.OffsetPanels = (int)Slider_DelayPanel.Value;
            SaveUserSettings();
        }

        private void Slider_DelayPower_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            User.OffsetPips = (int)Slider_DelayPower.Value;
            SaveUserSettings();
        }

        private void Slider_DelayFiregroup_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            User.OffsetFireGroups = (int)Slider_DelayFiregroup.Value;
            SaveUserSettings();
        }

        private void Slider_DelayThrottle_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            User.OffsetThrottle = (int)Slider_DelayThrottle.Value;
            SaveUserSettings();
        }
        #endregion

        #region Reports
        private void btn_FuelScoop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User.FuelScoop = !User.FuelScoop;
                btn_FuelScoop.Foreground = GetTextColor(User.FuelScoop);
                SaveUserSettings();
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
                User.FuelStatus = !User.FuelStatus;
                btn_FuelStatus.Foreground = GetTextColor(User.FuelStatus);
                SaveUserSettings();
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
                User.MaterialCollected = !User.MaterialCollected;
                btn_MaterialCollected.Foreground = GetTextColor(User.MaterialCollected);
                SaveUserSettings();
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
                User.NoFireZone = !User.NoFireZone;
                btn_NoFireZone.Foreground = GetTextColor(User.NoFireZone);
                SaveUserSettings();
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
                User.StationStatus = !User.StationStatus;
                btn_StationStatus.Foreground = GetTextColor(User.StationStatus);
                SaveUserSettings();
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
                User.ShieldState = !User.ShieldState;
                btn_ShieldStatus.Foreground = GetTextColor(User.ShieldState);
                SaveUserSettings();
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
                User.CollectedBounty = !User.CollectedBounty;
                btn_CollectedBounty.Foreground = GetTextColor(User.CollectedBounty);
                SaveUserSettings();
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
                User.TargetEnemy = !User.TargetEnemy;
                btn_TargetEnemy.Foreground = GetTextColor(User.TargetEnemy);
                SaveUserSettings();
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
                User.TargetWanted = !User.TargetWanted;
                btn_WatnedTarget.Foreground = GetTextColor(User.TargetWanted);
                SaveUserSettings();
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
                User.MaterialRefined = !User.MaterialRefined;
                btn_RefinedMaterials.Foreground = GetTextColor(User.MaterialRefined);
                SaveUserSettings();
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
                User.Masslock = !User.Masslock;
                btn_Masslock.Foreground = GetTextColor(User.Masslock);
                SaveUserSettings();
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
                User.CombatPower = !User.CombatPower;
                btn_AssistedCombatPower.Foreground = GetTextColor(User.CombatPower);
                SaveUserSettings();
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
                User.AssistSystemScan = !User.AssistSystemScan;
                btn_AssistedSystemScans.Foreground = GetTextColor(User.AssistSystemScan);
                SaveUserSettings();
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
                User.AssistDocking = !User.AssistDocking;
                btn_AssistedDockingProcedures.Foreground = GetTextColor(User.AssistDocking);
                SaveUserSettings();
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
                User.AssistHangerEntry = !User.AssistHangerEntry;
                btn_AssistedHangerEntry.Foreground = GetTextColor(User.AssistHangerEntry);
                SaveUserSettings();
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
                User.PostHyperspaceSafety = !User.PostHyperspaceSafety;
                btn_PostJumpSafeties.Foreground = GetTextColor(User.PostHyperspaceSafety);
                SaveUserSettings();
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
                User.WeaponSafety = !User.WeaponSafety;
                btn_WeaponSafty.Foreground = GetTextColor(User.WeaponSafety);
                SaveUserSettings();
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
            if (Init == false) { return; }
            Firegroup.ECM.FireGroup = (Settings_Firegroups.Group)CB_ECMGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_ECMFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ECM.FireMode = (Settings_Firegroups.Fire)CB_ECMFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SFNGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.FieldNeutraliser.FireGroup = (Settings_Firegroups.Group)CB_SFNGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SFNFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.FieldNeutraliser.FireMode = (Settings_Firegroups.Fire)CB_SFNFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_FSDIGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.FSDInterdictor.FireGroup = (Settings_Firegroups.Group)CB_FSDIGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_FSDIFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.FSDInterdictor.FireMode = (Settings_Firegroups.Fire)CB_FSDIFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMCOLGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetCollector.FireGroup = (Settings_Firegroups.Group)CB_LIMCOLGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMCOLFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetCollector.FireMode = (Settings_Firegroups.Fire)CB_LIMCOLFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMDECGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetDecontamination.FireGroup = (Settings_Firegroups.Group)CB_LIMDECGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMDECFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetDecontamination.FireMode = (Settings_Firegroups.Fire)CB_LIMDECFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMFGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetFuel.FireGroup = (Settings_Firegroups.Group)CB_LIMFGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMFFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetFuel.FireMode = (Settings_Firegroups.Fire)CB_LIMFFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMHBGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetHatchBreaker.FireGroup = (Settings_Firegroups.Group)CB_LIMHBGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMHBFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetHatchBreaker.FireMode = (Settings_Firegroups.Fire)CB_LIMHBFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMRECGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetRecon.FireGroup = (Settings_Firegroups.Group)CB_LIMRECGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMRECFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetRecon.FireMode = (Settings_Firegroups.Fire)CB_LIMRECFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMREPGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetRepair.FireGroup = (Settings_Firegroups.Group)CB_LIMREPGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMREPFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetRepair.FireMode = (Settings_Firegroups.Fire)CB_LIMREPFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMRESGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetResearch.FireGroup = (Settings_Firegroups.Group)CB_LIMRESGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMRESFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetResearch.FireMode = (Settings_Firegroups.Fire)CB_LIMRESFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMPROGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetProspector.FireGroup = (Settings_Firegroups.Group)CB_LIMPROGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_LIMPROFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LimpetProspector.FireMode = (Settings_Firegroups.Fire)CB_LIMPROFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_HS1GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LauncherHeatSinkOne.FireGroup = (Settings_Firegroups.Group)CB_HS1Group.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_HS1FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LauncherHeatSinkOne.FireMode = (Settings_Firegroups.Fire)CB_HS1Fire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_HS2GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LauncherHeatSinkTwo.FireGroup = (Settings_Firegroups.Group)CB_HS2Group.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_HS2FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LauncherHeatSinkTwo.FireMode = (Settings_Firegroups.Fire)CB_HS2Fire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SC1GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ShieldCellOne.FireGroup = (Settings_Firegroups.Group)CB_SC1Group.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SC1FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ShieldCellOne.FireMode = (Settings_Firegroups.Fire)CB_SC1Fire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SC2GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ShieldCellTwo.FireGroup = (Settings_Firegroups.Group)CB_SC2Group.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SC2FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ShieldCellTwo.FireMode = (Settings_Firegroups.Fire)CB_SC2Fire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_CF1GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LauncherChaffOne.FireGroup = (Settings_Firegroups.Group)CB_CF1Group.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_CF1FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LauncherChaffOne.FireMode = (Settings_Firegroups.Fire)CB_CF1Fire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_CF2GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LauncherChaffTwo.FireGroup = (Settings_Firegroups.Group)CB_CF2Group.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_CF2FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.LauncherChaffTwo.FireMode = (Settings_Firegroups.Fire)CB_CF2Fire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNCARGGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerCagro.FireGroup = (Settings_Firegroups.Group)CB_SNCARGGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNCARGFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerCagro.FireMode = (Settings_Firegroups.Fire)CB_SNCARGFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNCOMPGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerComposite.FireGroup = (Settings_Firegroups.Group)CB_SNCOMPGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNCOMPFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerComposite.FireMode = (Settings_Firegroups.Fire)CB_SNCOMPFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNDISCGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerDiscovery.FireGroup = (Settings_Firegroups.Group)CB_SNDISCGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNDISCFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerDiscovery.FireMode = (Settings_Firegroups.Fire)CB_SNDISCFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNKILLGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerKillwarrent.FireGroup = (Settings_Firegroups.Group)CB_SNKILLGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNKILLFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerKillwarrent.FireMode = (Settings_Firegroups.Fire)CB_SNKILLFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNSURFGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerSurface.FireGroup = (Settings_Firegroups.Group)CB_SNSURFGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNSURFFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerSurface.FireMode = (Settings_Firegroups.Fire)CB_SNSURFFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNXENOGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerXeno.FireGroup = (Settings_Firegroups.Group)CB_SNXENOGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNXENOFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerXeno.FireMode = (Settings_Firegroups.Fire)CB_SNXENOFire.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNWAKEGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerWake.FireGroup = (Settings_Firegroups.Group)CB_SNWAKEGroup.SelectedIndex;
            SaveFiregroupSettings();
        }

        private void CB_SNWAKEFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Init == false) { return; }
            Firegroup.ScannerWake.FireMode = (Settings_Firegroups.Fire)CB_SNWAKEFire.SelectedIndex;
            SaveFiregroupSettings();
        }
        #endregion

        #region Support Methods / Functions
        public void SaveUserSettings()
        {
            SaveValues<Settings_User>(User, ISettings.SettingsUser + ".Settings");
        }

        public void LoadUserSettings()
        {            
            User = (Settings_User)LoadValues<Settings_User>(ISettings.SettingsUser + ".Settings");
            Logger.Log(MethodName, "User Settings Loaded", Logger.Yellow);
        }

        public void SaveFiregroupSettings()
        {
            if (Monitor.TryEnter(SaveLockFlag))
            {
                Start:
                try
                {
                    if (SaveFiregroup == false) { return; }
                    SaveValues<Settings_Firegroups>(Firegroup, ISettings.SettingsFiregroup + ".FGConfig");
                    Logger.Log(MethodName, "Firegroup Settings Saved", Logger.Yellow);
                }
                catch (Exception)
                {
                    Logger.Exception(MethodName, "Couldn't Access The File, Trying Again...");
                    Thread.Sleep(100); goto Start;
                }
                finally
                {
                    Monitor.Exit(SaveLockFlag);
                }
            }
        }

        public void LoadFiregroupSettings()
        {
            Firegroup = (Settings_Firegroups)LoadValues<Settings_Firegroups>(ISettings.SettingsFiregroup + ".FGConfig");
            Logger.Log(MethodName, "Firegroup Settings Loaded", Logger.Yellow);
        }

        public SolidColorBrush GetTextColor(bool Value)
        {
            SolidColorBrush Brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            if (Value) { Brush = new SolidColorBrush(Color.FromRgb(0, 255, 0)); }

            return Brush;
        }

        public void SaveValues<T>(object Settings, string FileName, string FilePath = null)
        {
            string MethodName = "(Toolkit) Save Values";

            try
            {
                if (FilePath == null) { FilePath = Paths.ALICE_Settings; }

                using (FileStream FS = new FileStream(FilePath + FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter file = new StreamWriter(FS))
                    {
                        var Line = JsonConvert.SerializeObject((T)Settings);
                        file.WriteLine(Line);
                    }
                }
            }
            catch (Exception)
            {
                Logger.Exception(MethodName, "Couldn't Access The File, Trying Again...");
            }
        }

        public static object LoadValues<T>(string FileName, string FilePath = null)
        {
            string MethodName = "(Toolkit) Load Values";

            T Temp = default(T);
            if (FilePath == null) { FilePath = Paths.ALICE_Settings; }
            if (FileName == null) { return null; }

            FileStream FS = null;
            try
            {
                if (File.Exists(FilePath + FileName))
                {
                    FS = new FileStream(FilePath + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        while (!SR.EndOfStream)
                        {
                            string Line = SR.ReadLine();
                            Temp = JsonConvert.DeserializeObject<T>(Line);
                            Logger.Log(MethodName, "Loaded Settings", Logger.Yellow);
                        }
                    }
                }

                return Temp;
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception" + ex);
                Logger.Exception(MethodName, "Somthing Went Wrong While Loading Values");
                return Temp;
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }

        public void StartMonitor()
        {
            string MethodName = "(Toolkit) Monitor";
            Thread thread =
            new Thread((ThreadStart)(() =>
            {
                try
                {
                    if (Monitor.TryEnter(LockFlag))
                    {
                        while (Enabled)
                        {
                            Thread.Sleep(1000);

                            if (CheckSettings(ISettings.SettingsUser + ".Settings"))
                            {
                                LoadUserSettings();
                                UpdateButtons();
                            }

                            if (CheckSettings(ISettings.SettingsFiregroup + ".FGConfig"))
                            {
                                LoadFiregroupSettings();
                                UpdateFiregroupItems();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception" + ex);
                    Logger.Exception(MethodName, "Somthing Went Wrong With The Monitor");
                }
                finally
                {
                    Monitor.Exit(LockFlag);
                }
            }))
            { IsBackground = true }; thread.Start();
        }

        public bool CheckSettings(string FileName)
        {
            string MethodName = "(Toolkit) Check Settings";
            string TimeStamp = null; switch (FileName)
            {
                case "CurrentUser.Settings":
                    TimeStamp = TimeStampUser;
                    break;
                case "CurrentFiregroup.FGConfig":
                    TimeStamp = TimeStampFiregroup;
                    break;
                default:
                    Logger.Log(MethodName, "File Name Does Not Match Expected Options.", Logger.Yellow);
                    return false;
            }

            try
            {
                foreach (FileInfo File in DirSettings.EnumerateFiles(FileName, SearchOption.TopDirectoryOnly))
                {
                    if (TimeStamp == null || TimeStamp != File.LastWriteTime.ToString())
                    {
                        switch (FileName)
                        {
                            case "CurrentUser.Settings":
                                TimeStampUser = File.LastWriteTime.ToString();
                                break;
                            case "CurrentFiregroup.FGConfig":
                                TimeStampFiregroup = File.LastWriteTime.ToString();
                                break;
                        }                        
                        Logger.Log(MethodName, "Settings Update Detected", Logger.Yellow);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception" + ex);
                Logger.Exception(MethodName, "We Encountered An Error While Checking The Settings File");
                return false;
            }
        }
        #endregion
    }
}
