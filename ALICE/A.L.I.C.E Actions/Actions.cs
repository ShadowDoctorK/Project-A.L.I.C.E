using System.Threading;
using ALICE_Core;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Objects;
using ALICE.Properties;
using ALICE_Panels;
using ALICE_Synthesizer;
using ALICE_Settings;
using ALICE_Debug;
using ALICE_Response;
using ALICE_Status;

namespace ALICE_Actions
{
    /// <summary>
    /// Static Interface for Complex Systems to enhance or improve default gameplay.
    /// </summary>
    public static class Assisted
    {
        public static System_Targeting Targeting = new System_Targeting();
        public static System_AssistedPower Power = new System_AssistedPower();
    }

    /// <summary>
    /// Static Interface for Simple Items that control features already in game.
    /// </summary>
    public static class Call
    {
        public static Actions Action = new Actions();   
        public static Overrides Overrides = new Overrides();
        public static IPower Power = new IPower();
        public static IPanels Panel = new IPanels();    
        
        #region Methods
        public static void ResetPanels() { Panel = new IPanels(); }
        #endregion
    }

    /// <summary>
    /// Test Area for Building/Devloping New Commands.
    /// </summary>
    public class Sandbox
    {
        public Sandbox()
        {
            //Empty
        }

        //public void Check_PreLaunch(bool HaltLaunch = false)
        //{
        //    string MethodName = "Pre-Launch Checks";

        //    bool Report_NoCrew = false;
        //    bool Report_RefuelShip = false;
        //    bool Report_Limpets = false;

        //    if (Check.Equipment.FighterHanger(true, MethodName) == true)
        //    {
        //        if (ICheck.Status.Crew(MethodName, true) == false)
        //        {
        //            HaltLaunch = true;
        //            Report_NoCrew = true;
        //        }
        //    }

        //    if (Check.Equipment.MiningLaser(true, MethodName) == true)
        //    {
        //        if (Check.Equipment.CollectorLimpetController(true, MethodName) == true || Check.Equipment.ProspectorLimpetController(true, MethodName) == true)
        //        {

        //        }
        //    }
        //}
    }

    /// <summary>
    /// List of Actions to execute tasks in game. Used either as a command or a building block for complex commands.
    /// </summary>
    public class Actions
    {
        #region Properties
        public bool Default = true;
        //public bool Wait_FighterLaunch = false;
        #endregion

        public Actions() { }

        #region Simple / Sinlge Actions
        public void Activate_Chaff(bool CommandAudio)
        {
            string MethodName = "Activate Chaff";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Chaff_Launcher.Hyperspace),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            if (ICheck.Environment.Space(MethodName, false, IEnums.Supercruise) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Chaff_Launcher.Supercruise),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }
            #endregion

            #region Module Checks
            if (ICheck.Mothership.M.Chaff(MethodName, true) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(EQ_Generic_Module.Not_Installed)
                        .Replace("[MODULE]", "Chaff Launchers"),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }
            #endregion

            #region Activation
            IKeyboard.Press(IKey.Use_Chaff_Launcher, 0);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(EQ_Chaff_Launcher.Activating),
                    CommandAudio
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion

            #endregion
        }      

        public void CargoScoop(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Cargo Scoop";

            #region Valid Command Checks
            //If Not In Normal Space...
            if (ICheck.Environment.Space(MethodName, true , IEnums.Normal_Space) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Cargo_Scoop.Not_Normal_Space),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Not Outside The Fighter...
            if (ICheck.Status.Vehicle(MethodName, IStatus.V.Fighter, false) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Cargo_Scoop.Fighter),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Touchdown Is Not False...
            if (ICheck.Docking.Status(MethodName, false, IEnums.DockingState.Docked, true) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Cargo_Scoop.Docked),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Touchdown Is Not False...
            if (ICheck.Status.Touchdown(MethodName, false) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Cargo_Scoop.Touchdown),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }
            #endregion

            #region Status = Command
            if (IGet.Status.CargoScoop(MethodName) == CMD_State)
            {
                if (CMD_State == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(EQ_Cargo_Scoop.Currently_Deployed, true),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
                else if (CMD_State == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(EQ_Cargo_Scoop.Currently_Retracted, true),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
            }
            #endregion

            #region Status != Command
            else if (IGet.Status.CargoScoop(MethodName) != CMD_State)
            {
                if (CMD_State == true)
                {
                    IKeyboard.Press(IKey.Cargo_Scoop, 0);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Cargo_Scoop.Deploying, true),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
                else if (CMD_State == false)
                {
                    IKeyboard.Press(IKey.Cargo_Scoop, 0);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Cargo_Scoop.Retracting, true),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
            }
            #endregion
        }

        /// <summary>
        /// Controls Ships External Lights.
        /// </summary>
        /// <param name="CMD_State">True = Enabled, False = Disabled.</param>
        /// <param name="CommandAudio">Enables or Disables Audio At The Command Level.</param>
        public void ExternalLights(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "External Lights";

            #region Valid Command Checks
            //If Not In Normal Space...
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IResponse.Lights.NoHyperspace(CommandAudio);
                return;
            }
            #endregion

            #region Status == Command
            if (IStatus.Lights == CMD_State)
            {
                if (CMD_State == true)
                {
                    IResponse.Lights.Energized(CommandAudio);
                    return;
                }
                else if (CMD_State == false)
                {
                    IResponse.Lights.Deenergized(CommandAudio);
                    return;
                }
            }
            #endregion

            #region Status != Command
            else if (IStatus.Lights != CMD_State)
            {
                if (CMD_State == true)
                {
                    IKeyboard.Press(IKey.Ship_Lights, 0);
                    IResponse.Lights.Energizing(CommandAudio);
                    return;
                }
                else if (CMD_State == false)
                {
                    IKeyboard.Press(IKey.Ship_Lights, 0);
                    IResponse.Lights.Deenergizing(CommandAudio);
                    return;
                }
            }
            #endregion
        }

        public void Full_Spectrum_Scanner(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Full Spectrum Scanner";

            #region Valid Command Checks
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IResponse.DiscoveryScanner.NoHyperspace(CommandAudio);
                return;
            }

            if (ICheck.Environment.Space(MethodName, true, IEnums.Supercruise) == false)
            {
                IResponse.DiscoveryScanner.NotInSupercruise(CommandAudio);
                return;
            }
            #endregion

            #region Status == Command
            if (IStatus.FSSMode == CMD_State)
            {
                if (CMD_State == true)
                {
                    IResponse.DiscoveryScanner.FSSCurrentlyActivated(CommandAudio);
                    return;
                }
                else if (CMD_State == false)
                {
                    IResponse.DiscoveryScanner.FSSCurrentlyDeactivated(CommandAudio);
                    return;
                }
            }
            #endregion

            #region Status != Command
            else if (IStatus.FSSMode != CMD_State)
            {
                if (CMD_State == true)
                {
                    IResponse.DiscoveryScanner.FSSActivating(CommandAudio);
                    IKeyboard.Press(IKey.FSS_Enter, 0);
                    IStatus.FSSMode = CMD_State;

                    return;
                }
                else if (CMD_State == false)
                {
                    IResponse.DiscoveryScanner.FSSDeactivating(CommandAudio);
                    IKeyboard.Press(IKey.FSS_Exit, 0);
                    IStatus.FSSMode = CMD_State;

                    return;
                }
            }
            #endregion
        }

        public void NightVision(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Night Vision";

            #region Valid Command Checks
            //If Not In Normal Space...
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                Logger.Log(MethodName, "Can Not Use In Hyperspace", Logger.Red);
                return;
            }
            #endregion

            #region Status == Command
            if (IStatus.NightVision == CMD_State)
            {
                if (CMD_State == true)
                {
                    return;
                }
                else if (CMD_State == false)
                {
                    return;
                }
            }
            #endregion

            #region Status != Command
            else if (IStatus.NightVision != CMD_State)
            {
                if (CMD_State == true)
                {
                    IKeyboard.Press(IKey.Night_Vision_Toggle, 0);

                    return;
                }
                else if (CMD_State == false)
                {
                    IKeyboard.Press(IKey.Night_Vision_Toggle, 0);

                    return;
                }
            }
            #endregion
        }

        public void LandingGear(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Landing Gear";

            #region Valid Command Checks
            //Check Plugin Initialized
            if (ICheck.Initialized(MethodName) == false)
            {
                //Debug Logger
                Logger.DebugLine(MethodName, "Plugin Not Initialized", Logger.Yellow);
                return;
            }

            //If Not In Normal Space...
            if (ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Landing_Gear.Not_Normal_Space),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Not In Mothership...
            if (ICheck.Status.Vehicle(MethodName, IStatus.V.Mothership, true) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Landing_Gear.Not_Mothership),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Fighter is Deployed...
            if (ICheck.Status.FighterDeployed(MethodName, false) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Landing_Gear.Fighter_Deployed),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Docked is True...
            if (ICheck.Docking.Status(MethodName, true, IEnums.DockingState.Docked) == true && CMD_State == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Landing_Gear.Docked),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Touchdown Is Not False...
            if (ICheck.Status.Touchdown(MethodName, false) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Landing_Gear.Touchdown),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }
            #endregion

            #region Status == Command
            if (ICheck.Status.LandingGear(MethodName, true, true) == CMD_State)
            {
                if (CMD_State == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(EQ_Landing_Gear.Currently_Deployed, true),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
                else if (CMD_State == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(EQ_Landing_Gear.Currently_Retracted, true),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
            }
            #endregion

            #region Status != Command
            else if (ICheck.Status.LandingGear(MethodName, true, true) != CMD_State)
            {
                if (CMD_State == true)
                {
                    IKeyboard.Press(IKey.Landing_Gear, 0);
                    ISet.Status.LandingGear(MethodName, true);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Landing_Gear.Deploying),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
                else if (CMD_State == false)
                {
                    IKeyboard.Press(IKey.Landing_Gear, 0);
                    ISet.Status.LandingGear(MethodName, false);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Landing_Gear.Retracting),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
            }
            #endregion
        }

        public void SilentRunning(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Silent Running";

            #region Valid Command Checks
            //If Not In Normal Space...
            if (ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Silent_Running.Not_Normal_Space),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Not In Mothership...
            if (ICheck.Status.Vehicle(MethodName, IStatus.V.Mothership, true) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Silent_Running.Not_Mothership),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }
            #endregion

            #region Status = Command
            if (IGet.Status.SilentRunning(MethodName) == CMD_State)
            {
                if (CMD_State == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(EQ_Silent_Running.Currently_Active, true),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
                else if (CMD_State == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(EQ_Silent_Running.Currently_Secured, true),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
            }
            #endregion

            #region Status != Command
            else if (IGet.Status.SilentRunning(MethodName) != CMD_State)
            {
                if (CMD_State == true)
                {
                    IKeyboard.Press(IKey.Silent_Running, 0);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Silent_Running.Activating, true),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
                else if (CMD_State == false)
                {
                    IKeyboard.Press(IKey.Silent_Running, 0);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Silent_Running.Securing, true),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
            }
            #endregion
        }

        //End Region: Simple / Sinlge Actions
        #endregion

        #region Compound / Complex Actions    

        public void Interdict(bool CommandAudio)
        {
            string MethodName = "Interdict";

            #region Vaildtion Checks
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IResponse.FSDInterdictor.NoHyperspace(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            switch (ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.FSDInterdictor))
            {
                case ConfigurationHardpoints.S.Selected:
                    break;
                case ConfigurationHardpoints.S.NotAssigned:
                    IResponse.FSDInterdictor.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.Failed:
                    return;
                default:
                    return;
            }

            switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.FSDInterdictor, 75, ref IStatus.False))
            {
                case ConfigurationHardpoints.A.Hyperspace:
                    IResponse.FSDInterdictor.EnteredHyperspace(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.NotAssigned:
                    IResponse.FSDInterdictor.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.Complete:
                    //Audio - Commencing...
                    break;
                default:
                    return;
            }
            #endregion
        }

        public void SurfaceScaner(bool CMD_State, bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Surface Scan";

            #region Vaildtion Checks
            if (SelectOnly == false && ICheck.Environment.Space(MethodName, true, IEnums.Supercruise) == false)
            {
                Logger.Log(MethodName, "Can Not Use Outside Supercruise", Logger.Red);
                //Audio - Environtment Not 
                return;
            }
            #endregion

            #region Status = Command
            if (IStatus.ModeSurfScanner == CMD_State)
            {
                if (CMD_State == true)
                {
                    //Audio - Already Active
                    return;
                }
                else if (CMD_State == false)
                {
                    //Audio - Already Inactive
                    return;
                }
            }
            #endregion

            #region Status != Command
            else if (IStatus.ModeSurfScanner != CMD_State)
            {
                if (CMD_State == true)
                {
                    #region Fire Group Management
                    switch (ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.ScannerSurface))
                    {
                        case ConfigurationHardpoints.S.CurrentlySelected:
                            if (SelectOnly) { IResponse.SurfaceScanner.CurrentlySelected(CommandAudio); }
                            break;
                        case ConfigurationHardpoints.S.Selected:
                            if (SelectOnly) { IResponse.SurfaceScanner.Selected(CommandAudio); }
                            break;
                        case ConfigurationHardpoints.S.NotAssigned:
                            IResponse.SurfaceScanner.NotAssigned(CommandAudio);
                            return;
                        case ConfigurationHardpoints.S.Failed:
                            IResponse.SurfaceScanner.SelectionFailed(CommandAudio);                            
                            return;
                        case ConfigurationHardpoints.S.InHyperspace:
                            IResponse.SurfaceScanner.NoHyperspace(CommandAudio);
                            return;
                        default:
                            return;
                    }

                    //Exit If Only Selecting Item.
                    if (SelectOnly) { return; }

                    switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.ScannerSurface, 75, ref IStatus.False))
                    {
                        case ConfigurationHardpoints.A.Hyperspace:
                            IResponse.SurfaceScanner.EnteredHyperspace(CommandAudio);
                            return;
                        case ConfigurationHardpoints.A.NotAssigned:
                            IResponse.SurfaceScanner.NotAssigned(CommandAudio);
                            return;
                        case ConfigurationHardpoints.A.Complete:
                            //Audio - Activated
                            break;
                        default:
                            return;
                    }
                    #endregion

                    IStatus.ModeSurfScanner = CMD_State;

                    return;
                }
                else if (CMD_State == false)
                {
                    IKeyboard.Press(IKey.UI_Back, 0);

                    //Add Music State Checks To Verify Closed.
                    IStatus.ModeSurfScanner = CMD_State;
                    return;
                }
            }
            #endregion
        }

        public void LandingPreparations(bool CommandAudio)
        {
            string MethodName = "Landing Preparations";

            IStatus.LandingPreps = true;

            Call.Power.Set(0, 8, 4);
            Thread.Sleep(100);
            Call.Action.LandingGear(true, false);
            Thread.Sleep(100);
            Call.Action.CargoScoop(false, false);
            Thread.Sleep(100);
            Call.Action.ExternalLights(true, false);
            Thread.Sleep(2000);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (""
                    .Phrase(GN_Landing_Preparations.Modifier, true)
                    .Phrase(GN_Landing_Preparations.Default),
                    CommandAudio
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void XenoScanner(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Xeno Scan";

            //Record Current Firegroup
            decimal Temp = IActions.Hardpoints.Current;

            #region Vaildtion Checks
            if (ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space) == false)
            {
                IResponse.XenoScanner.NotInNormalSpace(CommandAudio);
                return;
            }

            if (ICheck.Status.Vehicle(MethodName, IStatus.V.Mothership, true) == false)
            {
                Logger.Log(MethodName, "Only Available In The Mothership", Logger.Red);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.ScannerXeno))
            {
                case ConfigurationHardpoints.S.CurrentlySelected:
                    if (SelectOnly) { IResponse.XenoScanner.CurrentlySelected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.Selected:
                    if (SelectOnly) { IResponse.XenoScanner.Selected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.NotAssigned:
                    IResponse.XenoScanner.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.Failed:
                    IResponse.XenoScanner.SelectionFailed(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.InHyperspace:
                    IResponse.XenoScanner.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.ScannerXeno, 8000, ref IStatus.False))
            {
                case ConfigurationHardpoints.A.Hyperspace:
                    IResponse.XenoScanner.EnteredHyperspace(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.NotAssigned:
                    IResponse.XenoScanner.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.Complete:
                    IResponse.XenoScanner.ScanComplete(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            IActions.Hardpoints.Select(Temp, false);
        }

        //End Region: Compound / Complex Actions
        #endregion

        #region Sandbox
        public void FlightAssist(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Flight Assist";

            #region Valid Command Checks
            //Check Not In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Flight_Assist.No_Hyperspace),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }
            #endregion

            #region Status = Command
            if (IGet.Status.FlightAssist(MethodName) == CMD_State)
            {
                if (CMD_State == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(EQ_Flight_Assist.Currently_Enabled),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
                else if (CMD_State == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(EQ_Flight_Assist.Currently_Disabled),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
            }
            #endregion

            #region Status != Command
            else if (IGet.Status.FlightAssist(MethodName) != CMD_State)
            {
                if (CMD_State == true)
                {
                    IKeyboard.Press(IKey.Toggle_Flight_Assist, 0);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Flight_Assist.Enabled),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
                else if (CMD_State == false)
                {
                    IKeyboard.Press(IKey.Toggle_Flight_Assist, 0);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Flight_Assist.Disabled),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    return;
                }
            }
            #endregion
        }

        public void Launch(bool CommandAudio, bool PreFlightCheck = true)
        {
            string MethodName = "Launch";

            if (ICheck.Docking.Status(MethodName, true, IEnums.DockingState.Docked, true) == true)
            {
                //Checks & Returns to HUD / Logs & Exits on Failure.
                if (Call.Panel.HudFocus(250) == false)
                {
                    Logger.Log(MethodName, "Failed To Return To HUD, Try Again.", Logger.Red);
                    return;
                }

                //Add Preflight Checks

                //Add Aduio - Postive / Commencing Launch

                //Selects Launch Button & Press' It.
                IKeyboard.Press(IKey.UI_Panel_Down_Press, 2000);
                IKeyboard.Press(IKey.UI_Panel_Down_Release, 100);
                IKeyboard.Press(IKey.UI_Panel_Select, 250);

                //Wait For Launch (30 seconds)
                decimal Count = 300; while (ICheck.Docking.Status(MethodName, true, IEnums.DockingState.Undocked, true) == false && Count > 0)
                {
                    Count--; if (Count == 0)
                    {
                        //Add Audio - Failed To Launch
                        Logger.Log(MethodName, "Failed To Launch, Try Again.", Logger.Yellow, true);
                    }
                    Thread.Sleep(100);
                }

                //Move Ship Away From Ground                
                IKeyboard.Press(IKey.Thrust_Up_Press, 3000);
                IKeyboard.Press(IKey.Thrust_Up_Release);

                //Add Audio - Handover                      
                Logger.Log(MethodName, "Undocking Complete, Controls Released.", Logger.Yellow, true);
            }

            else if (ICheck.Status.Touchdown(MethodName, true) == true)
            {
                //Checks & Returns to HUD / Logs & Exits on Failure.
                if (Call.Panel.HudFocus(250) == false)
                {
                    Logger.Log(MethodName, "Failed To Return To HUD, Try Again.", Logger.Red);
                    return;
                }

                //Add Preflight Checks

                //Add Audio - Postive / Engine Start Up

                //Begin Takeoff
                IKeyboard.Press(IKey.Thrust_Up_Press);
                //Wait For Engines To Engage / Takeoff
                decimal Count = 50; while(ICheck.Status.Touchdown(MethodName, false) == false && Count > 0)
                {
                    Count--; if (Count == 0)
                    {
                        //Add Audio - Failed Engine Start
                        Logger.Log(MethodName, "Failed To Engage Engines, Try Again.", Logger.Yellow, true);
                    } Thread.Sleep(100);
                }
                //Move Ship Away From Ground
                Count = 40; while(Count > 0)
                {
                    Count--; Thread.Sleep(100);
                }
                //Release Upward Thrust
                IKeyboard.Press(IKey.Thrust_Up_Release);

                //Add Audio - Handover                               
                Logger.Log(MethodName, "Liftoff Complete, Controls Released.", Logger.Yellow, true);
            }
        }

        public void CollectorLimpet(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Collector Limpet Controller";

            //Record Current Firegroup
            decimal Temp = IActions.Hardpoints.Current;

            #region Vaildtion Checks
            //Check Not In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IResponse.CollectorLimpets.NoHyperspace(CommandAudio);
                return;
            }

            //Check Installed
            if (ICheck.Mothership.M.CollectorLimpet(MethodName, true) == false)
            {
                IResponse.CollectorLimpets.NotInstalled(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.LimpetCollector))
            {
                case ConfigurationHardpoints.S.CurrentlySelected:
                    if (SelectOnly) { IResponse.CollectorLimpets.CurrentlySelected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.Selected:
                    if (SelectOnly) { IResponse.CollectorLimpets.Selected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.NotAssigned:
                    IResponse.CollectorLimpets.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.Failed:
                    IResponse.CollectorLimpets.SelectionFailed(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.InHyperspace:
                    IResponse.CollectorLimpets.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.LimpetCollector, 75, ref IStatus.False))
            {
                case ConfigurationHardpoints.A.Hyperspace:
                    //Audio
                    return;
                case ConfigurationHardpoints.A.NotAssigned:
                    IResponse.CollectorLimpets.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.Complete:
                    IResponse.CollectorLimpets.Activating(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            IActions.Hardpoints.Select(Temp, false);
        }

        public void FuelLimpet(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Fuel Limpet Controller";

            //Record Current Firegroup
            decimal Temp = IActions.Hardpoints.Current;

            #region Vaildtion Checks
            //Check Not In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IResponse.FuelLimpets.NoHyperspace(CommandAudio);
                return;
            }

            //Check Installed
            if (ICheck.Mothership.M.FuelLimpet(MethodName, true) == false)
            {
                IResponse.FuelLimpets.NotInstalled(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.LimpetFuel))
            {
                case ConfigurationHardpoints.S.CurrentlySelected:
                    if (SelectOnly) { IResponse.FuelLimpets.CurrentlySelected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.Selected:
                    if (SelectOnly) { IResponse.FuelLimpets.Selected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.NotAssigned:
                    IResponse.FuelLimpets.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.Failed:
                    IResponse.FuelLimpets.SelectionFailed(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.InHyperspace:
                    IResponse.FuelLimpets.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.LimpetFuel, 75, ref IStatus.False))
            {
                case ConfigurationHardpoints.A.Hyperspace:
                    //Audio
                    return;
                case ConfigurationHardpoints.A.NotAssigned:
                    IResponse.FuelLimpets.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.Complete:
                    IResponse.FuelLimpets.Activating(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            IActions.Hardpoints.Select(Temp, false);
        }

        public void ProspectorLimpet(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Prospector Limpet Controller";

            //Record Current Firegroup
            decimal Temp = IActions.Hardpoints.Current;

            #region Vaildtion Checks
            //Check Not In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IResponse.ProspectorLimpets.NoHyperspace(CommandAudio);
                return;
            }

            //Check Installed
            if (ICheck.Mothership.M.ProspectorLimpet(MethodName, true) == false)
            {
                IResponse.ProspectorLimpets.NotInstalled(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.LimpetProspector))
            {
                case ConfigurationHardpoints.S.CurrentlySelected:
                    if (SelectOnly) { IResponse.ProspectorLimpets.CurrentlySelected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.Selected:
                    if (SelectOnly) { IResponse.ProspectorLimpets.Selected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.NotAssigned:
                    IResponse.ProspectorLimpets.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.Failed:
                    IResponse.ProspectorLimpets.SelectionFailed(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.InHyperspace:
                    IResponse.ProspectorLimpets.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.LimpetProspector, 75, ref IStatus.False))
            {
                case ConfigurationHardpoints.A.Hyperspace:
                    //Audio
                    return;
                case ConfigurationHardpoints.A.NotAssigned:
                    IResponse.ProspectorLimpets.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.Complete:
                    IResponse.ProspectorLimpets.Activating(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            IActions.Hardpoints.Select(Temp, false);
        }

        public void ReconLimpet(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Recon Limpet Controller";

            //Record Current Firegroup
            decimal Temp = IActions.Hardpoints.Current;

            #region Vaildtion Checks
            //Check Not In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IResponse.ReconLimpets.NoHyperspace(CommandAudio);
                return;
            }

            //Check Installed
            if (ICheck.Mothership.M.ReconLimpet(MethodName, true) == false)
            {
                IResponse.ReconLimpets.NotInstalled(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Managements
            //Select Firegroup
            switch (ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.LimpetRecon))
            {
                case ConfigurationHardpoints.S.CurrentlySelected:
                    if (SelectOnly) { IResponse.ReconLimpets.CurrentlySelected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.Selected:
                    if (SelectOnly) { IResponse.ReconLimpets.Selected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.NotAssigned:
                    IResponse.ReconLimpets.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.Failed:
                    IResponse.ReconLimpets.SelectionFailed(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.InHyperspace:
                    IResponse.ReconLimpets.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.LimpetRecon, 75, ref IStatus.False))
            {
                case ConfigurationHardpoints.A.Hyperspace:
                    //Audio
                    return;
                case ConfigurationHardpoints.A.NotAssigned:
                    IResponse.ReconLimpets.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.Complete:
                    IResponse.ReconLimpets.Activating(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            IActions.Hardpoints.Select(Temp, false);
        }

        public void RepairLimpet(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Repair Limpet Controller";

            //Record Current Firegroup
            decimal Temp = IActions.Hardpoints.Current;

            #region Vaildtion Checks
            //Check Not In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IResponse.ReconLimpets.NoHyperspace(CommandAudio);
                return;
            }

            //Check Installed
            if (ICheck.Mothership.M.RepairLimpet(MethodName, true) == false)
            {
                IResponse.ReconLimpets.NotInstalled(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroups.Config.Select(ConfigurationHardpoints.Item.LimpetRepair))
            {
                case ConfigurationHardpoints.S.CurrentlySelected:
                    if (SelectOnly) { IResponse.ReconLimpets.CurrentlySelected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.Selected:
                    if (SelectOnly) { IResponse.ReconLimpets.Selected(CommandAudio); }
                    break;
                case ConfigurationHardpoints.S.NotAssigned:
                    IResponse.ReconLimpets.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.Failed:
                    IResponse.ReconLimpets.SelectionFailed(CommandAudio);
                    return;
                case ConfigurationHardpoints.S.InHyperspace:
                    IResponse.ReconLimpets.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroups.Config.Activate(ConfigurationHardpoints.Item.LimpetRepair, 75, ref IStatus.False))
            {
                case ConfigurationHardpoints.A.Hyperspace:
                    //Audio
                    return;
                case ConfigurationHardpoints.A.NotAssigned:
                    IResponse.ReconLimpets.NotAssigned(CommandAudio);
                    return;
                case ConfigurationHardpoints.A.Complete:
                    IResponse.ReconLimpets.Activating(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            IActions.Hardpoints.Select(Temp, false);
        }
        #endregion
    }

    /// <summary>
    /// Collection of User Override Commands to allow actions that could potentially get out of sync or need immediate access and is behind interlocks.
    /// </summary>
    public class Overrides
    {
        string ClassName = "Override: ";

        public void Crew(bool CommandAudio)
        {
            string MethodName = ClassName + "Crew";

            IStatus.NPC_Crew = true;
            Miscellanous.Default["NPC_Crew"] = IStatus.NPC_Crew;
            Miscellanous.Default.Save();

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "Crew Override Activated.",
                    CommandAudio
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion

            Logger.Log(MethodName, "Crew Override Acivated.", Logger.Yellow);
        }
    }

    public static class Targeting
    {
        public static string Scan_OrdSubsystemName = "";

        #region Simple Target Actions
        public static void Cycle_Subsystems(decimal Cycle, bool Forward, bool CommandAudio) //ref decimal CurrentSubsystemPos)
        {
            string MethodName = "Cycle Subsystems";

            if (ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space) == false)
            {
                return;
            }

            while (Cycle != 0 && Cycle > 0)
            {
                if (Forward == true)
                {
                    IKeyboard.Press(IKey.Cycle_Next_Subsystem, 150);
                }
                else if (Forward == false)
                {
                    IKeyboard.Press(IKey.Cycle_Previous_Subsystem, 150);
                }

                if (IObjects.TargetCurrent.Targeted == false)
                {
                    return;
                }

                Cycle--;
                //CurrentSubsystemPos++;
            }
        }

        public static void Cycle_Hostile_Targets(decimal Cycle, bool Forward)
        {
            string MethodName = "Cycle Hostile Target";

            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio
                return;
            }

            while (Cycle != 0 && Cycle > 0)
            {
                if (Forward == true)
                {
                    IKeyboard.Press(IKey.Cycle_Next_Hostile_Target, 0);
                }
                else if (Forward == false)
                {
                    IKeyboard.Press(IKey.Cycle_Previous_Hostile_Ship, 0);
                }
                Cycle--;
                Thread.Sleep(100);
            }
        }

        public static void Cycle_Targets(decimal Cycle, bool Forward)
        {
            string MethodName = "Cycle Target";

            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio
                return;
            }

            while (Cycle != 0 && Cycle > 0)
            {
                if (Forward == true)
                {
                    IKeyboard.Press(IKey.Cycle_Next_Target , 0);
                }
                else if (Forward == false)
                {
                    IKeyboard.Press(IKey.Cycle_Previous_Ship , 0);
                }
                Cycle--;
                Thread.Sleep(100);
            }
        }

        public static void Select_Wingman(decimal Wingman, bool CommandAudio)
        {
            string MethodName = "Select Wingman";

            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                //Audio
                return;
            }

            if (IStatus.InWing == false)
            {
                //Audio - We are not in a wing.
                return;
            }

            if (Wingman == 1)
            {
                IKeyboard.Press(IKey.Select_Wingman_1 , 0);
            }
            else if (Wingman == 2)
            {
                IKeyboard.Press(IKey.Select_Wingman_2, 0);
            }
            else if (Wingman == 3)
            {
                IKeyboard.Press(IKey.Select_Wingman_3, 0);
            }

            Thread.Sleep(100);

            //Variable Audio Responce based on Deicmal "Wingman"
        }

        public static void Select_Wingmans_Target(decimal Wingman, bool CommandAudio)
        {
            if (Wingman != 0)
            {
                Select_Wingman(Wingman, false);
            }

            IKeyboard.Press(IKey.Select_Wingmans_Target, 100);

            //DYNAMIC AUDIO
        }

        public static void Select_Wingmans_NavLock(decimal Wingman, bool CommandAudio)
        {
            if (Wingman != 0)
            {
                Select_Wingman(Wingman, false);
            }
            IKeyboard.Press(IKey.Wingman_NavLock, 100);

            //DYNAMIC AUDIO
        }

        #endregion
    }
}
