using ALICE_Debug;
using ALICE_Internal;
using ALICE_Response;
using ALICE_Settings;
using ALICE_Status;
using System.Threading;

namespace ALICE_Actions
{
    public static partial class IActions
    {
        public static PulseWaveAnalyser PulseWaveAnalyser = new PulseWaveAnalyser();
    }

    public class PulseWaveAnalyser
    {
        public bool Maintain = false;
        public decimal Group = -1;

        public bool Operate(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Pulse Wave Analyser (Operate)";

            //Record Current Firegroup
            decimal Temp = IActions.Hardpoints.Current;

            #region Vaildtion Checks
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio
                return false;
            }

            if (ICheck.Status.Hardpoints(MethodName, true) == false)
            {
                IActions.Hardpoints.Operate(true, false, Hardpoints.M.Analysis);
                Thread.Sleep(1000);
            }
            #endregion

            #region Fire Group Management
            ConfigurationHardpoints.Assignemnt Module = ISettings.Firegroups.Config.GetAssignemnt(ConfigurationHardpoints.Item.PulseWaveAnalyser);

            //Select Firegroup
            switch (ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.PulseWaveAnalyser))
            {
                case ConfigurationHardpoints.S.CurrentlySelected:
                    if (SelectOnly) { IResponse.PulseWaveAnalyser.CurrentlySelected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.Selected:
                    if (SelectOnly) { IResponse.PulseWaveAnalyser.Selected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.NotAssigned:
                    IResponse.PulseWaveAnalyser.NotAssigned(CommandAudio);
                    return false;
                case ConfigurationHardpoints.S.Failed:
                    IResponse.PulseWaveAnalyser.SelectionFailed(CommandAudio);
                    return false;
                case ConfigurationHardpoints.S.InHyperspace:
                    IResponse.PulseWaveAnalyser.NoHyperspace(CommandAudio);
                    return false;
                default:
                    return false;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return true; }

            //Commenced Audio
            if (Module.FireGroup != ConfigurationHardpoints.Group.None &&
                Module.FireMode != ConfigurationHardpoints.Fire.None)
            {
                IResponse.PulseWaveAnalyser.ScanCommenced(CommandAudio);
            }

            //Acivate Module
            switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.PulseWaveAnalyser, 75, ref IStatus.False))
            {
                case ConfigurationHardpoints.A.Hyperspace:
                    IResponse.PulseWaveAnalyser.EnteredHyperspace(CommandAudio);
                    return false;
                case ConfigurationHardpoints.A.NotAssigned:
                    IResponse.PulseWaveAnalyser.NotAssigned(CommandAudio);
                    return false;
                case ConfigurationHardpoints.A.Complete:
                    //Audio Removed, Not Required.
                    break;
                case ConfigurationHardpoints.A.Fail:
                    IResponse.PulseWaveAnalyser.ScanFailed(CommandAudio);
                    break;
                default:
                    return false;
            }
            #endregion

            //Return To Previou Firegroup.
            IActions.Hardpoints.Select(Temp, false);

            return true;
        }

        public void Scan()
        {
            string MethodName = "Discovery Scan";

            //Check Plugin Initialized
            if (ICheck.Initialized(MethodName) == false) { return; }

            if (ICheck.Order.AssistSystemScan(MethodName, true, true))
            {
                Thread Scan = new Thread((ThreadStart)(() =>
                {
                    //Quiet Selection
                    if (Operate(false, true))
                    {
                        //Record Current Group
                        Group = IActions.Hardpoints.Current;

                        Maintain = true;

                        while (Maintain                                     //Check Order Is Active
                            && IStatus.Hardpoints == true                   //Check Hardpoints Deployed
                            && Group == IActions.Hardpoints.Current)        //Check Firegroup
                        {
                            //Acivate Module
                            switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.PulseWaveAnalyser, 75, ref IStatus.False))
                            {
                                case ConfigurationHardpoints.A.Hyperspace:
                                    IResponse.PulseWaveAnalyser.EnteredHyperspace(true);
                                    Maintain = false;
                                    return;
                                case ConfigurationHardpoints.A.NotAssigned:
                                    IResponse.PulseWaveAnalyser.NotAssigned(true);
                                    Maintain = false;
                                    return;
                                case ConfigurationHardpoints.A.Complete:
                                    //Audio Removed, Not Required.
                                    break;
                                case ConfigurationHardpoints.A.Fail:
                                    IResponse.PulseWaveAnalyser.ScanFailed(true);
                                    Maintain = false;
                                    break;
                                default:
                                    Maintain = false;
                                    return;
                            }

                            Thread.Sleep(8000);
                        }

                        Maintain = false;
                    }
                    
                }));
                Scan.IsBackground = true;
                Scan.Start();
            }
        }


    }
}
