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
using ALICE_Equipment;
using ALICE_Response;

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
        public static IFiregroups Firegroup = new IFiregroups();     
        
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

        public void Check_PreLaunch(bool HaltLaunch = false)
        {
            string MethodName = "Pre-Launch Checks";

            bool Report_NoCrew = false;
            bool Report_RefuelShip = false;
            bool Report_Limpets = false;

            if (Check.Equipment.FighterHanger(true, MethodName) == true)
            {
                if (ICheck.Status.Crew(MethodName, true) == false)
                {
                    HaltLaunch = true;
                    Report_NoCrew = true;
                }
            }

            if (Check.Equipment.MiningLaser(true, MethodName) == true)
            {
                if (Check.Equipment.CollectorLimpetController(true, MethodName) == true || Check.Equipment.ProspectorLimpetController(true, MethodName) == true)
                {

                }
            }
        }
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
            if (Check.Equipment.ChaffLauncher(true, MethodName) == false)
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

        public void Activate_Heatsink(bool CommandAudio, bool Cold = false)
        {
            string MethodName = "Activate Heatsink";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Heatsink_Launcher.Hyperspace),
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
            if (Check.Equipment.HeatSinkLauncher(true, MethodName) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Generic_Module.Not_Installed)
                        .Replace("[MODULE]", "Heatsink Launchers"),
                        (CommandAudio || Cold)                          //Enable Audio For Cold Activation
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }
            #endregion

            #region Activation
            IKeyboard.Press(IKey.Deploy_Heat_Sink, 0);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(EQ_Heatsink_Launcher.Activating),
                    CommandAudio
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion

            #endregion
        }

        public void Activate_ShieldCell(bool CommandAudio, bool Cold = false)
        {
            string MethodName = "Activate Shield Cell";

            #region Validation Check
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default)
                        .Phrase(EQ_Shield_Cell.Hyperspace),
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
            if (Check.Equipment.ShieldCellBank(true, MethodName) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Generic_Module.Not_Installed)
                        .Replace("[MODULE]", "Shield Cells"),
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
            IKeyboard.Press(IKey.Use_Shield_Cell, 0);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(EQ_Shield_Cell.Activating),
                    CommandAudio
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion

            //Activate When Cold Modifier Is Used
            if (Cold)
            {
                //Delay Activation
                Thread.Sleep(1500);

                //Activate Heatsink
                Activate_Heatsink(false, true);
            }

            #endregion
        }

        public void AnalysisMode(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Analysis Mode";

            #region Status == Command
            if (IStatus.AnalysisMode == CMD_State)
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
            else if (IStatus.AnalysisMode != CMD_State)
            {
                if (CMD_State == true)
                {
                    IKeyboard.Press(IKey.Toggle_HUD_Mode, 0);
                    IStatus.AnalysisMode = true;
                    return;
                }
                else if (CMD_State == false)
                {
                    IKeyboard.Press(IKey.Toggle_HUD_Mode, 0);
                    IStatus.AnalysisMode = false;
                    return;
                }
            }
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
            if (ICheck.Status.Vehicle(MethodName, IVehicles.V.Fighter, false) == false)
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
                IEquipment.ExternalLights.NoHyperspace(CommandAudio);
                return;
            }
            #endregion

            #region Status == Command
            if (IStatus.Lights == CMD_State)
            {
                if (CMD_State == true)
                {
                    IEquipment.ExternalLights.CurrentlyEnergized(CommandAudio);
                    return;
                }
                else if (CMD_State == false)
                {
                    IEquipment.ExternalLights.CurrentlyDeenergized(CommandAudio);
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
                    IEquipment.ExternalLights.Energizing(CommandAudio);
                    return;
                }
                else if (CMD_State == false)
                {
                    IKeyboard.Press(IKey.Ship_Lights, 0);
                    IEquipment.ExternalLights.Deenergizing(CommandAudio);
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
                IEquipment.DiscoveryScanner.NoHyperspace(CommandAudio);
                return;
            }

            if (ICheck.Environment.Space(MethodName, true, IEnums.Supercruise) == false)
            {
                IEquipment.DiscoveryScanner.NotInSupercruise(CommandAudio);
                return;
            }
            #endregion

            #region Status == Command
            if (IEquipment.DiscoveryScanner.Mode == CMD_State)
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
            else if (IEquipment.DiscoveryScanner.Mode != CMD_State)
            {
                if (CMD_State == true)
                {
                    IResponse.DiscoveryScanner.FSSActivating(CommandAudio);
                    IKeyboard.Press(IKey.FSS_Enter, 0);
                    IEquipment.DiscoveryScanner.Mode = CMD_State;

                    return;
                }
                else if (CMD_State == false)
                {
                    IResponse.DiscoveryScanner.FSSDeactivating(CommandAudio);
                    IKeyboard.Press(IKey.FSS_Exit, 0);
                    IEquipment.DiscoveryScanner.Mode = CMD_State;

                    return;
                }
            }
            #endregion
        }

        public void Hardpoint(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Hardpoints";

            #region Valid Command Checks
            //If Hyperspace Is Not False...
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(EQ_Hardpoints.Hyperspace),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Docked Is Not False...
            if (ICheck.Docking.Status(MethodName, false, IEnums.DockingState.Docked, true) == false)
            {
                return;
            }

            //If Touchdown Is Not False...
            if (ICheck.Status.Touchdown(MethodName, false) == false)
            {
                #region Audio
                //if (PlugIn.Audio == "TTS")
                //{
                //    Speech.Speak
                //        (
                //        "".Phrase(GN_Negative.Default, true)
                //        .Phrase(EQ_Hardpoints.Touchdown),
                //        CommandAudio
                //        );
                //}
                //else if (PlugIn.Audio == "File") { }
                //else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If In Supercruse && State Is True...
            if (ICheck.Environment.Space(MethodName, true, IEnums.Supercruise) == true && CMD_State == true)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(EQ_Hardpoints.Supercruise),
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
            if (IGet.Status.Hardpoints(MethodName) == CMD_State)
            {
                if (CMD_State == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(EQ_Hardpoints.Currently_Deployed),
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
                            "".Phrase(EQ_Hardpoints.Currently_Retracted),
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
            else if (IGet.Status.Hardpoints(MethodName) != CMD_State)
            {
                if (CMD_State == true)
                {
                    #region Weapon Safety Check
                    if (IStatus.WeaponSafety == true)
                    {
                        #region Audio
                        if (PlugIn.Audio == "TTS")
                        {
                            Speech.Speak
                                (
                                "".Phrase(EQ_Hardpoints.Safety_Engaged) +
                                "... Would You Like To Override?",
                                CommandAudio
                                );
                        }
                        else if (PlugIn.Audio == "File") { }
                        else if (PlugIn.Audio == "External") { }
                        #endregion

                        Thread.Sleep(1500); switch (IStatus.Interaction.Question(10000))
                        {
                            case ALICE_Status.Status_Interaction.Answers.NoResponse:

                                //Debug Logger
                                Logger.DebugLine(MethodName, "No Response.", Logger.Yellow);

                                return;

                            case ALICE_Status.Status_Interaction.Answers.Yes:

                                IStatus.WeaponSafety = false;

                                break;

                            case ALICE_Status.Status_Interaction.Answers.No:

                                #region Audio
                                if (PlugIn.Audio == "TTS")
                                {
                                    Speech.Speak
                                        (
                                        "".Phrase(GN_Positive.Default, true)
                                        .Phrase(EQ_Hardpoints.Safety_Remains),
                                        CommandAudio
                                        );
                                }
                                else if (PlugIn.Audio == "File") { }
                                else if (PlugIn.Audio == "External") { }
                                #endregion

                                return;

                            default:
                                break;
                        }
                    }
                    #endregion

                    if (ICheck.Status.Hardpoints(MethodName, false) == true)
                    {
                        Call.Firegroup.Select(Call.Firegroup.Default, false);                        
                        Thread.Sleep(100);
                    }

                    IKeyboard.Press(IKey.Deploy_Hardpoints, 0);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Hardpoints.Deploying)
                            .Phrase(GN_Combat_Power.Online, false, ICheck.Order.CombatPower(MethodName, true, true)),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else if (CMD_State == false)
                {
                    IKeyboard.Press(IKey.Deploy_Hardpoints, 0);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Hardpoints.Retracting)
                            .Phrase(GN_Combat_Power.Offline, false, ICheck.Order.CombatPower(MethodName, true, true)),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion                
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
            if (ICheck.Status.Vehicle(MethodName, IVehicles.V.Mothership, true) == false)
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
            if (ICheck.LandingGear.Status(MethodName, true, true) == CMD_State)
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
            else if (ICheck.LandingGear.Status(MethodName, true, true) != CMD_State)
            {
                if (CMD_State == true)
                {
                    IKeyboard.Press(IKey.Landing_Gear, 0);
                    ISet.LandingGear.Status(MethodName, true);

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
                    ISet.LandingGear.Status(MethodName, false);

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
            if (ICheck.Status.Vehicle(MethodName, IVehicles.V.Mothership, true) == false)
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
                IEquipment.FSDInterdictor.NoHyperspace(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.FSDInterdictor))
            {
                case Settings_Firegroups.S.Selected:
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.FSDInterdictor.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    return;
                default:
                    return;
            }

            switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.FSDInterdictor))
            {
                case Settings_Firegroups.A.Hyperspace:
                    IEquipment.FSDInterdictor.EnteredHyperspace(CommandAudio);
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.FSDInterdictor.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:
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
            if (IEquipment.SurfaceScanner.Mode == CMD_State)
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
            else if (IEquipment.SurfaceScanner.Mode != CMD_State)
            {
                if (CMD_State == true)
                {
                    #region Fire Group Management
                    switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerSurface))
                    {
                        case Settings_Firegroups.S.CurrentlySelected:
                            if (SelectOnly) { IEquipment.SurfaceScanner.CurrentlySelected(CommandAudio); }
                            break;
                        case Settings_Firegroups.S.Selected:
                            if (SelectOnly) { IEquipment.SurfaceScanner.Selected(CommandAudio); }
                            break;
                        case Settings_Firegroups.S.NotAssigned:
                            IEquipment.SurfaceScanner.NotAssigned(CommandAudio);
                            return;
                        case Settings_Firegroups.S.Failed:
                            IEquipment.SurfaceScanner.SelectionFailed(CommandAudio);                            
                            return;
                        case Settings_Firegroups.S.InHyperspace:
                            IEquipment.General.InHyperspace();
                            return;
                        default:
                            return;
                    }

                    //Exit If Only Selecting Item.
                    if (SelectOnly) { return; }

                    switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.ScannerSurface))
                    {
                        case Settings_Firegroups.A.Hyperspace:
                            IEquipment.SurfaceScanner.EnteredHyperspace(CommandAudio);
                            return;
                        case Settings_Firegroups.A.NotAssigned:
                            IEquipment.SurfaceScanner.NotAssigned(CommandAudio);
                            return;
                        case Settings_Firegroups.A.Complete:
                            //Audio - Activated
                            break;
                        default:
                            return;
                    }
                    #endregion

                    IEquipment.SurfaceScanner.Mode = CMD_State;

                    return;
                }
                else if (CMD_State == false)
                {
                    IKeyboard.Press(IKey.UI_Back, 0);

                    //Add Music State Checks To Verify Closed.
                    IEquipment.SurfaceScanner.Mode = CMD_State;
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
            decimal Temp = Call.Firegroup.Current;

            #region Vaildtion Checks
            if (ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space) == false)
            {
                IEquipment.XenoScanner.NotInNormalSpace(CommandAudio);
                return;
            }

            if (ICheck.Status.Vehicle(MethodName, IVehicles.V.Mothership, true) == false)
            {
                Logger.Log(MethodName, "Only Available In The Mothership", Logger.Red);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerXeno))
            {
                case Settings_Firegroups.S.CurrentlySelected:
                    if (SelectOnly) { IEquipment.XenoScanner.CurrentlySelected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.Selected:
                    if (SelectOnly) { IEquipment.XenoScanner.Selected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.XenoScanner.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    IEquipment.XenoScanner.SelectionFailed(CommandAudio);
                    return;
                case Settings_Firegroups.S.InHyperspace:
                    IEquipment.General.InHyperspace();
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.ScannerXeno, 8000))
            {
                case Settings_Firegroups.A.Hyperspace:
                    IEquipment.XenoScanner.EnteredHyperspace(CommandAudio);
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.XenoScanner.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:
                    IEquipment.XenoScanner.ScanComplete(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            Call.Firegroup.Select(Temp, false);
        }

        public void SheildCell(bool CommandAudio, Settings_Firegroups.Item BankNumber, bool Cold = false, bool SelectOnly = false)
        {
            string MethodName = "Sheild Cell";

            //Record Current Firegroup
            decimal Temp = Call.Firegroup.Current;

            #region Vaildtion Checks
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IEquipment.ShieldCellBank.NoHyperspace(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroup.Select(BankNumber))
            {
                case Settings_Firegroups.S.CurrentlySelected:
                    if (SelectOnly) { IEquipment.ShieldCellBank.CurrentlySelected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.Selected:
                    if (SelectOnly) { IEquipment.ShieldCellBank.Selected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.ShieldCellBank.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    IEquipment.ShieldCellBank.SelectionFailed(CommandAudio);
                    return;
                case Settings_Firegroups.S.InHyperspace:
                    IEquipment.General.InHyperspace();
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroup.Activate(BankNumber))
            {
                case Settings_Firegroups.A.Hyperspace:
                    //Audio
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.ShieldCellBank.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:
                    IEquipment.ShieldCellBank.Activating(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            Call.Firegroup.Select(Temp, false);

            //If "Cold" Modifer Used, Launch Heatsink.
            if (Cold && SelectOnly == false) { Call.Action.Activate_Heatsink(false); }
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
            decimal Temp = Call.Firegroup.Current;

            #region Vaildtion Checks
            //Check Not In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IEquipment.LimpetCollector.NoHyperspace(CommandAudio);
                return;
            }

            //Check Installed
            if (Check.Equipment.CollectorLimpetController(true, MethodName) == false)
            {
                IEquipment.LimpetCollector.NotInstalled(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.LimpetCollector))
            {
                case Settings_Firegroups.S.CurrentlySelected:
                    if (SelectOnly) { IEquipment.LimpetCollector.CurrentlySelected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.Selected:
                    if (SelectOnly) { IEquipment.LimpetCollector.Selected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.LimpetCollector.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    IEquipment.LimpetCollector.SelectionFailed(CommandAudio);
                    return;
                case Settings_Firegroups.S.InHyperspace:
                    IEquipment.LimpetCollector.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.LimpetCollector))
            {
                case Settings_Firegroups.A.Hyperspace:
                    //Audio
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.LimpetCollector.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:
                    IEquipment.LimpetCollector.Activating(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            Call.Firegroup.Select(Temp, false);
        }

        public void FuelLimpet(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Fuel Limpet Controller";

            //Record Current Firegroup
            decimal Temp = Call.Firegroup.Current;

            #region Vaildtion Checks
            //Check Not In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IEquipment.LimpetFuel.NoHyperspace(CommandAudio);
                return;
            }

            //Check Installed
            if (Check.Equipment.FuelLimpetController(true, MethodName) == false)
            {
                IEquipment.LimpetFuel.NotInstalled(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.LimpetFuel))
            {
                case Settings_Firegroups.S.CurrentlySelected:
                    if (SelectOnly) { IEquipment.LimpetFuel.CurrentlySelected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.Selected:
                    if (SelectOnly) { IEquipment.LimpetFuel.Selected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.LimpetFuel.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    IEquipment.LimpetFuel.SelectionFailed(CommandAudio);
                    return;
                case Settings_Firegroups.S.InHyperspace:
                    IEquipment.LimpetFuel.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.LimpetFuel))
            {
                case Settings_Firegroups.A.Hyperspace:
                    //Audio
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.LimpetFuel.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:
                    IEquipment.LimpetFuel.Activating(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            Call.Firegroup.Select(Temp, false);
        }

        public void ProspectorLimpet(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Prospector Limpet Controller";

            //Record Current Firegroup
            decimal Temp = Call.Firegroup.Current;

            #region Vaildtion Checks
            //Check Not In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IEquipment.LimpetProspector.NoHyperspace(CommandAudio);
                return;
            }

            //Check Installed
            if (Check.Equipment.ProspectorLimpetController(true, MethodName) == false)
            {
                IEquipment.LimpetProspector.NotInstalled(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.LimpetProspector))
            {
                case Settings_Firegroups.S.CurrentlySelected:
                    if (SelectOnly) { IEquipment.LimpetProspector.CurrentlySelected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.Selected:
                    if (SelectOnly) { IEquipment.LimpetProspector.Selected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.LimpetProspector.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    IEquipment.LimpetProspector.SelectionFailed(CommandAudio);
                    return;
                case Settings_Firegroups.S.InHyperspace:
                    IEquipment.LimpetProspector.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.LimpetProspector))
            {
                case Settings_Firegroups.A.Hyperspace:
                    //Audio
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.LimpetProspector.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:
                    IEquipment.LimpetProspector.Activating(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            Call.Firegroup.Select(Temp, false);
        }

        public void ReconLimpet(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Recon Limpet Controller";

            //Record Current Firegroup
            decimal Temp = Call.Firegroup.Current;

            #region Vaildtion Checks
            //Check Not In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IEquipment.LimpetRecon.NoHyperspace(CommandAudio);
                return;
            }

            //Check Installed
            if (Check.Equipment.ReconLimpetController(true, MethodName) == false)
            {
                IEquipment.LimpetRecon.NotInstalled(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.LimpetRecon))
            {
                case Settings_Firegroups.S.CurrentlySelected:
                    if (SelectOnly) { IEquipment.LimpetRecon.CurrentlySelected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.Selected:
                    if (SelectOnly) { IEquipment.LimpetRecon.Selected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.LimpetRecon.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    IEquipment.LimpetRecon.SelectionFailed(CommandAudio);
                    return;
                case Settings_Firegroups.S.InHyperspace:
                    IEquipment.LimpetRecon.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.LimpetRecon))
            {
                case Settings_Firegroups.A.Hyperspace:
                    //Audio
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.LimpetRecon.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:
                    IEquipment.LimpetRecon.Activating(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            Call.Firegroup.Select(Temp, false);
        }

        public void RepairLimpet(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Repair Limpet Controller";

            //Record Current Firegroup
            decimal Temp = Call.Firegroup.Current;

            #region Vaildtion Checks
            //Check Not In Hyperspace
            if (ICheck.Environment.Space(MethodName, false, IEnums.Hyperspace) == false)
            {
                IEquipment.LimpetRecon.NoHyperspace(CommandAudio);
                return;
            }

            //Check Installed
            if (Check.Equipment.RepairLimpetController(true, MethodName) == false)
            {
                IEquipment.LimpetRepair.NotInstalled(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            //Select Firegroup
            switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.LimpetRepair))
            {
                case Settings_Firegroups.S.CurrentlySelected:
                    if (SelectOnly) { IEquipment.LimpetRepair.CurrentlySelected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.Selected:
                    if (SelectOnly) { IEquipment.LimpetRepair.Selected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.LimpetRepair.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    IEquipment.LimpetRepair.SelectionFailed(CommandAudio);
                    return;
                case Settings_Firegroups.S.InHyperspace:
                    IEquipment.LimpetRepair.NoHyperspace(CommandAudio);
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Activate Module
            switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.LimpetRepair))
            {
                case Settings_Firegroups.A.Hyperspace:
                    //Audio
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.LimpetRepair.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:
                    IEquipment.LimpetRepair.Activating(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            Call.Firegroup.Select(Temp, false);
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
