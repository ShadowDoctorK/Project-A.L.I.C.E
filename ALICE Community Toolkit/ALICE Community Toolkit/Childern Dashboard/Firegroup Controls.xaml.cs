using ALICE_Internal;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ALICE_Community_Toolkit
{
    /// <summary>
    /// Interaction logic for Firegroup_Controls.xaml
    /// </summary>
    public partial class Firegroup_Controls : UserControl
    {
        public Firegroup_Controls()
        {
            InitializeComponent();
            SetBindings();
            UpdateButtons();
            UpdateFiregroupItems();
        }

        public string MethodName = "Firegroup Controls";

        public void SetBindings()
        {
            #region Fire Modes
            //Chaff
            CB_CF1Fire.ItemsSource = Data.Fire;
            CB_CF2Fire.ItemsSource = Data.Fire;
            CB_CF3Fire.ItemsSource = Data.Fire;
            CB_CF4Fire.ItemsSource = Data.Fire;

            //ECM
            CB_ECMFire.ItemsSource = Data.Fire;

            //FSD Interdictor
            CB_FSDIFire.ItemsSource = Data.Fire;

            //Heatsink
            CB_HS1Fire.ItemsSource = Data.Fire;
            CB_HS2Fire.ItemsSource = Data.Fire;
            CB_HS3Fire.ItemsSource = Data.Fire;
            CB_HS4Fire.ItemsSource = Data.Fire;

            //Limpet Controllers
            CB_LIMCOLFire.ItemsSource = Data.Fire;
            CB_LIMDECFire.ItemsSource = Data.Fire;
            CB_LIMHBFire.ItemsSource = Data.Fire;
            CB_LIMFFire.ItemsSource = Data.Fire;
            CB_LIMPROFire.ItemsSource = Data.Fire;
            CB_LIMRECFire.ItemsSource = Data.Fire;
            CB_LIMREPFire.ItemsSource = Data.Fire;
            CB_LIMRESFire.ItemsSource = Data.Fire;

            //Shield Cell Banks
            CB_SC1Fire.ItemsSource = Data.Fire;
            CB_SC2Fire.ItemsSource = Data.Fire;
            CB_SC3Fire.ItemsSource = Data.Fire;
            CB_SC4Fire.ItemsSource = Data.Fire;

            //Field Neut.
            CB_SFNFire.ItemsSource = Data.Fire;

            #region Mining
            CB_MINEFire.ItemsSource = Data.Fire;
            CB_ABRSBFire.ItemsSource = Data.Fire;
            CB_DISPMFire.ItemsSource = Data.Fire;
            CB_CHRGLFire.ItemsSource = Data.Fire;
            #endregion

            //Scanners
            CB_SNCARGFire.ItemsSource = Data.Fire;
            CB_SNCOMPFire.ItemsSource = Data.Fire;
            CB_SNDISCFire.ItemsSource = Data.Fire;
            CB_SNKILLFire.ItemsSource = Data.Fire;
            CB_SNSURFFire.ItemsSource = Data.Fire;
            CB_SNWAKEFire.ItemsSource = Data.Fire;
            CB_SNXENOFire.ItemsSource = Data.Fire;
            CB_SNPULSFire.ItemsSource = Data.Fire;
            #endregion

            #region Fire Groups
            //Chaff
            CB_CF1Group.ItemsSource = Data.Group;
            CB_CF2Group.ItemsSource = Data.Group;
            CB_CF3Group.ItemsSource = Data.Group;
            CB_CF4Group.ItemsSource = Data.Group;

            //ECM
            CB_ECMGroup.ItemsSource = Data.Group;

            //FSD Interdictor
            CB_FSDIGroup.ItemsSource = Data.Group;

            //Heatsink
            CB_HS1Group.ItemsSource = Data.Group;
            CB_HS2Group.ItemsSource = Data.Group;
            CB_HS3Group.ItemsSource = Data.Group;
            CB_HS4Group.ItemsSource = Data.Group;

            //Limpet Controllers
            CB_LIMCOLGroup.ItemsSource = Data.Group;
            CB_LIMDECGroup.ItemsSource = Data.Group;
            CB_LIMFGroup.ItemsSource = Data.Group;
            CB_LIMHBGroup.ItemsSource = Data.Group;
            CB_LIMPROGroup.ItemsSource = Data.Group;
            CB_LIMRECGroup.ItemsSource = Data.Group;
            CB_LIMREPGroup.ItemsSource = Data.Group;
            CB_LIMRESGroup.ItemsSource = Data.Group;

            //Shield Cell Banks
            CB_SC1Group.ItemsSource = Data.Group;
            CB_SC2Group.ItemsSource = Data.Group;
            CB_SC3Group.ItemsSource = Data.Group;
            CB_SC4Group.ItemsSource = Data.Group;

            //Field Neut.
            CB_SFNGroup.ItemsSource = Data.Group;

            #region Mining
            CB_MINEGroup.ItemsSource = Data.Group;
            CB_ABRSBGroup.ItemsSource = Data.Group;
            CB_DISPMGroup.ItemsSource = Data.Group;
            CB_CHRGLGroup.ItemsSource = Data.Group;            
            #endregion

            //Scanners
            CB_SNCARGGroup.ItemsSource = Data.Group;
            CB_SNDISCGroup.ItemsSource = Data.Group;
            CB_SNCOMPGroup.ItemsSource = Data.Group;
            CB_SNKILLGroup.ItemsSource = Data.Group;
            CB_SNSURFGroup.ItemsSource = Data.Group;
            CB_SNWAKEGroup.ItemsSource = Data.Group;
            CB_SNXENOGroup.ItemsSource = Data.Group;
            CB_SNPULSGroup.ItemsSource = Data.Group;
            #endregion

            #region Grouping Assignments
            CB_GPWEP1Group.ItemsSource = Data.Group;
            CB_GPWEP2Group.ItemsSource = Data.Group;
            CB_GPPROSGroup.ItemsSource = Data.Group;
            CB_GPCOLLGroup.ItemsSource = Data.Group;
            CB_GPEXTRGroup.ItemsSource = Data.Group;
            #endregion
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
                    #endregion

                    #region Orders
                    btn_AssistedCombatPower.Foreground = Data.GetTextColor(TKSettings.User.CombatPower());                   
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

                    #region Chaff Launchers
                    //Chaff 1
                    CB_CF1Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffOne.FireMode;
                    CB_CF1Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffOne.FireGroup;
                    Label_CH1.Foreground = Data.GetFGLabelColor(CB_CF1Fire.SelectedIndex, CB_CF1Group.SelectedIndex);

                    //Chaff 2
                    CB_CF2Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffTwo.FireMode;
                    CB_CF2Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffTwo.FireGroup;
                    Label_CH2.Foreground = Data.GetFGLabelColor(CB_CF2Fire.SelectedIndex, CB_CF2Group.SelectedIndex);

                    //Chaff 3
                    CB_CF3Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffThree.FireMode;
                    CB_CF3Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffThree.FireGroup;
                    Label_CH3.Foreground = Data.GetFGLabelColor(CB_CF3Fire.SelectedIndex, CB_CF3Group.SelectedIndex);

                    //Chaff 4
                    CB_CF4Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffFour.FireMode;
                    CB_CF4Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherChaffFour.FireGroup;
                    Label_CH4.Foreground = Data.GetFGLabelColor(CB_CF4Fire.SelectedIndex, CB_CF4Group.SelectedIndex);
                    #endregion

                    #region Heatsinks
                    //Heatsink 1
                    CB_HS1Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkOne.FireMode;
                    CB_HS1Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkOne.FireGroup;
                    Label_HS1.Foreground = Data.GetFGLabelColor(CB_HS1Fire.SelectedIndex, CB_HS1Group.SelectedIndex);

                    //Heatsink 2
                    CB_HS2Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkTwo.FireMode;
                    CB_HS2Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkTwo.FireGroup;
                    Label_HS2.Foreground = Data.GetFGLabelColor(CB_HS2Fire.SelectedIndex, CB_HS2Group.SelectedIndex);

                    //Heatsink 3
                    CB_HS3Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkThree.FireMode;
                    CB_HS3Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkThree.FireGroup;
                    Label_HS3.Foreground = Data.GetFGLabelColor(CB_HS3Fire.SelectedIndex, CB_HS3Group.SelectedIndex);

                    //Heatsink 4
                    CB_HS4Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkFour.FireMode;
                    CB_HS4Group.SelectedIndex = (int)TKSettings.Firegroup.Config.LauncherHeatSinkFour.FireGroup;
                    Label_HS4.Foreground = Data.GetFGLabelColor(CB_HS4Fire.SelectedIndex, CB_HS4Group.SelectedIndex);
                    #endregion

                    #region Limpet Controllers
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
                    #endregion

                    #region Shield Cell Banks
                    //Shield Cell 1
                    CB_SC1Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellOne.FireMode;
                    CB_SC1Group.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellOne.FireGroup;
                    Label_SC1.Foreground = Data.GetFGLabelColor(CB_SC1Fire.SelectedIndex, CB_SC1Group.SelectedIndex);

                    //Shield Cell 2
                    CB_SC2Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellTwo.FireMode;
                    CB_SC2Group.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellTwo.FireGroup;
                    Label_SC2.Foreground = Data.GetFGLabelColor(CB_SC2Fire.SelectedIndex, CB_SC2Group.SelectedIndex);

                    //Shield Cell 3
                    CB_SC3Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellThree.FireMode;
                    CB_SC3Group.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellThree.FireGroup;
                    Label_SC3.Foreground = Data.GetFGLabelColor(CB_SC3Fire.SelectedIndex, CB_SC3Group.SelectedIndex);

                    //Shield Cell 4
                    CB_SC4Fire.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellFour.FireMode;
                    CB_SC4Group.SelectedIndex = (int)TKSettings.Firegroup.Config.ShieldCellFour.FireGroup;
                    Label_SC4.Foreground = Data.GetFGLabelColor(CB_SC4Fire.SelectedIndex, CB_SC4Group.SelectedIndex);
                    #endregion

                    #region Scanners
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

                    //Pulse Wave Scanner
                    CB_SNPULSFire.SelectedIndex = (int)TKSettings.Firegroup.Config.PulseWaveAnalyser.FireMode;
                    CB_SNPULSGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.PulseWaveAnalyser.FireGroup;
                    Label_SNPULS.Foreground = Data.GetFGLabelColor(CB_SNPULSFire.SelectedIndex, CB_SNPULSGroup.SelectedIndex);
                    #endregion

                    #region Other Utilities And Defense
                    //ECM
                    CB_ECMFire.SelectedIndex = (int)TKSettings.Firegroup.Config.ECM.FireMode;
                    CB_ECMGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.ECM.FireGroup;
                    Label_ECM.Foreground = Data.GetFGLabelColor(CB_ECMFire.SelectedIndex, CB_ECMGroup.SelectedIndex);

                    //FSD Interdictor
                    CB_FSDIFire.SelectedIndex = (int)TKSettings.Firegroup.Config.FSDInterdictor.FireMode;
                    CB_FSDIGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.FSDInterdictor.FireGroup;
                    Label_FSDI.Foreground = Data.GetFGLabelColor(CB_FSDIFire.SelectedIndex, CB_FSDIGroup.SelectedIndex);

                    //Shutdown Field Neutralizer
                    CB_SFNFire.SelectedIndex = (int)TKSettings.Firegroup.Config.FieldNeutraliser.FireMode;
                    CB_SFNGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.FieldNeutraliser.FireGroup;
                    Label_SFN.Foreground = Data.GetFGLabelColor(CB_SFNFire.SelectedIndex, CB_SFNGroup.SelectedIndex);
                    #endregion

                    #region Mining
                    //Mining Laser
                    CB_MINEFire.SelectedIndex = (int)TKSettings.Firegroup.Config.LaserMinning.FireMode;
                    CB_MINEGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.LaserMinning.FireGroup;
                    Label_MINE.Foreground = Data.GetFGLabelColor(CB_MINEFire.SelectedIndex, CB_MINEGroup.SelectedIndex);

                    //Abrasion Blaster
                    CB_ABRSBFire.SelectedIndex = (int)TKSettings.Firegroup.Config.AbrasionBlaster.FireMode;
                    CB_ABRSBGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.AbrasionBlaster.FireGroup;
                    Label_ABRSB.Foreground = Data.GetFGLabelColor(CB_ABRSBFire.SelectedIndex, CB_ABRSBGroup.SelectedIndex);

                    //Charge Launcher
                    CB_CHRGLFire.SelectedIndex = (int)TKSettings.Firegroup.Config.SeismicChargeLauncher.FireMode;
                    CB_CHRGLGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.SeismicChargeLauncher.FireGroup;
                    Label_CHRGL.Foreground = Data.GetFGLabelColor(CB_ABRSBGroup.SelectedIndex, CB_CHRGLGroup.SelectedIndex);

                    //Displacement Missle
                    CB_DISPMFire.SelectedIndex = (int)TKSettings.Firegroup.Config.DisplacementMissile.FireMode;
                    CB_DISPMGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.DisplacementMissile.FireGroup;
                    Label_DISPM.Foreground = Data.GetFGLabelColor(CB_DISPMFire.SelectedIndex, CB_DISPMGroup.SelectedIndex);
                    #endregion

                    #region Groupings
                    //Weapon Group 1                    
                    CB_GPWEP1Group.SelectedIndex = (int)TKSettings.Firegroup.Config.Weapons1.FireGroup;
                    Label_GPWEP1.Foreground = Data.GetFGLabelColor(CB_GPWEP1Group.SelectedIndex);

                    //Weapon Group 2                  
                    CB_GPWEP2Group.SelectedIndex = (int)TKSettings.Firegroup.Config.Weapons2.FireGroup;
                    Label_GPWEP2.Foreground = Data.GetFGLabelColor(CB_GPWEP2Group.SelectedIndex);

                    //Prospecting Group                   
                    CB_GPPROSGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.Prospecting.FireGroup;
                    Label_GPPROS.Foreground = Data.GetFGLabelColor(CB_GPPROSGroup.SelectedIndex);

                    //Collection Group               
                    CB_GPCOLLGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.Collecting.FireGroup;
                    Label_GPCOLL.Foreground = Data.GetFGLabelColor(CB_GPCOLLGroup.SelectedIndex);

                    //Extraction Group                   
                    CB_GPEXTRGroup.SelectedIndex = (int)TKSettings.Firegroup.Config.Extracting.FireGroup;
                    Label_GPEXTR.Foreground = Data.GetFGLabelColor(CB_GPEXTRGroup.SelectedIndex);
                    #endregion
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

        #region PlugIn Methods
        private void Slider_DelayFiregroup_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TKSettings.User.OffsetFireGroups(MethodName, (int)Slider_DelayFiregroup.Value, TKSettings.Save);
        }
        #endregion

        #region Orders Methods
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
        #endregion

        #region Firegroup Methods

        #region Groupings
        private void CB_GPWEP1GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.Weapons1.FireGroup = (ConfigurationHardpoints.Group)CB_GPWEP1Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_GPWEP2GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.Weapons2.FireGroup = (ConfigurationHardpoints.Group)CB_GPWEP2Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_GPPROSGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.Prospecting.FireGroup = (ConfigurationHardpoints.Group)CB_GPPROSGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_GPCOLLGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.Collecting.FireGroup = (ConfigurationHardpoints.Group)CB_GPCOLLGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_GPEXTRGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.Extracting.FireGroup = (ConfigurationHardpoints.Group)CB_GPEXTRGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }
        #endregion

        #region Other Utilities And Defense
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

        //End: Other Utilities And Defense
        #endregion

        #region Limpet Controllers
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

        //End: Limpet Controllers 
        #endregion

        #region Heatsinks
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

        private void CB_HS3GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherHeatSinkThree.FireGroup = (ConfigurationHardpoints.Group)CB_HS3Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_HS3FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherHeatSinkThree.FireMode = (ConfigurationHardpoints.Fire)CB_HS3Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_HS4GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherHeatSinkFour.FireGroup = (ConfigurationHardpoints.Group)CB_HS4Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_HS4FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherHeatSinkFour.FireMode = (ConfigurationHardpoints.Fire)CB_HS4Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        //End: Heatsinks
        #endregion

        #region Shield Cell Banks
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

        private void CB_SC3GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ShieldCellThree.FireGroup = (ConfigurationHardpoints.Group)CB_SC3Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SC3FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ShieldCellThree.FireMode = (ConfigurationHardpoints.Fire)CB_SC3Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SC4GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ShieldCellFour.FireGroup = (ConfigurationHardpoints.Group)CB_SC4Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SC4FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.ShieldCellFour.FireMode = (ConfigurationHardpoints.Fire)CB_SC4Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        //End: Shield Cell Banks
        #endregion

        #region Chaff
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

        private void CB_CF3GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherChaffThree.FireGroup = (ConfigurationHardpoints.Group)CB_CF3Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_CF3FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherChaffThree.FireMode = (ConfigurationHardpoints.Fire)CB_CF3Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_CF4GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherChaffFour.FireGroup = (ConfigurationHardpoints.Group)CB_CF4Group.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_CF4FireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LauncherChaffFour.FireMode = (ConfigurationHardpoints.Fire)CB_CF4Fire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        //End: Chaff
        #endregion

        #region Scanners
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

        private void CB_SNPULSGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.PulseWaveAnalyser.FireGroup = (ConfigurationHardpoints.Group)CB_SNPULSGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_SNPULSFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.PulseWaveAnalyser.FireMode = (ConfigurationHardpoints.Fire)CB_SNPULSFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        //End: Scanners
        #endregion

        #region Mining
        private void CB_MINEGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LaserMinning.FireGroup = (ConfigurationHardpoints.Group)CB_MINEGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_MINEFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.LaserMinning.FireMode = (ConfigurationHardpoints.Fire)CB_MINEFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_ABRSBGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.AbrasionBlaster.FireGroup = (ConfigurationHardpoints.Group)CB_ABRSBGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_ABRSBFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.AbrasionBlaster.FireMode = (ConfigurationHardpoints.Fire)CB_ABRSBFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_DISPMGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.DisplacementMissile.FireGroup = (ConfigurationHardpoints.Group)CB_DISPMGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_DISPMFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.DisplacementMissile.FireMode = (ConfigurationHardpoints.Fire)CB_DISPMFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_CHRGLGroupChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.SeismicChargeLauncher.FireGroup = (ConfigurationHardpoints.Group)CB_CHRGLGroup.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }

        private void CB_CHRGLFireChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TKSettings.InitUI == false) { return; }
            TKSettings.Firegroup.Config.SeismicChargeLauncher.FireMode = (ConfigurationHardpoints.Fire)CB_CHRGLFire.SelectedIndex;
            TKSettings.Firegroup.UpdateConfig();
        }
        #endregion

        #endregion
    }
}
