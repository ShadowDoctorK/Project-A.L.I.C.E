using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Media;
using System.IO;
using ALICE_Core;
using ALICE_Events;
using ALICE_Interface;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Objects;
using ALICE.Properties;
using ALICE_Panels;
using ALICE_Synthesizer;
using ALICE_Settings;

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
        public static AliceKeys Key = new AliceKeys();        
        public static Overrides Overrides = new Overrides();
        public static IPower Power = new IPower();
        public static IPanels Panel = new IPanels();
        public static IFiregroups Firegroup = new IFiregroups();     
        
        //Merging Orders With User Settings
        public static Reports Report = new Reports();

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

        }

        public void Check_PreLaunch(bool HaltLaunch = false)
        {
            string MethodName = "Pre-Launch Checks";

            bool Report_NoCrew = false;
            bool Report_RefuelShip = false;
            bool Report_Limpets = false;

            if (Check.Equipment.FighterHanger(true, MethodName) == true)
            {
                if (Check.Variable.NPC_Crew(true, MethodName) == false)
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
        public decimal Num_Boost = 0;
        public bool Wait_FighterLaunch = false;
        #endregion

        public Actions() { }

        #region Simple / Sinlge Actions
        public void Activate_Chaff(bool CommandAudio)
        {
            string MethodName = "Activate Chaff";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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

            if (Check.Environment.Space(IEnums.Supercruise, false, MethodName) == false)
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
            Call.Key.Press(Call.Key.Use_Chaff_Launcher, 0);

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

        public void Activate_Heatsink(bool CommandAudio)
        {
            string MethodName = "Activate Heatsink";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
            Call.Key.Press(Call.Key.Deploy_Heat_Sink, 0);

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

        public void Activate_ShieldCell(bool CommandAudio)
        {
            string MethodName = "Activate Shield Cell";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
            Call.Key.Press(Call.Key.Use_Shield_Cell, 0);

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
                    Call.Key.Press(Call.Key.Toggle_HUD_Mode, 0);
                    IStatus.AnalysisMode = true;
                    return;
                }
                else if (CMD_State == false)
                {
                    Call.Key.Press(Call.Key.Toggle_HUD_Mode, 0);
                    IStatus.AnalysisMode = false;
                    return;
                }
            }
            #endregion
        }

        public void Boost(decimal Times, bool ModifyPower, bool CommandAudio)
        {
            string MethodName = "Boost";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                //Audio
                return;
            }

            if (Check.Environment.Space(IEnums.Supercruise, false, MethodName) == false)
            {
                //Audio
                return;
            }
            #endregion

            #region Module Checks
            bool Pause = false;

            if (Check.Variable.CargoScoop(false, MethodName) == false)
            {
                Call.Action.CargoScoop(false, false);
                Pause = true;
            }

            if (Check.Variable.LandingGear(false, MethodName) == false)
            {
                Call.Action.LandingGear(false, false);
                Pause = true;
            }

            if (Pause == true)
            { Thread.Sleep(100); }
            #endregion

            #region Action: Set Power
            if (ModifyPower && (Check.Variable.Hardpoints(false, MethodName) == true && Check.Order.CombatPower(true, MethodName)) == false)
            { Call.Power.Set(0, 4, 8, true); }
            #endregion

            #region Action: Boost
            Num_Boost = Times; while (Num_Boost >= 1)
            { Num_Boost--; Call.Key.Press(Call.Key.Engine_Boost, 8000); }
            #endregion

            #region Action: Set Saved Power
            if (ModifyPower && (Check.Variable.Hardpoints(false, MethodName) == true && Check.Order.CombatPower(true, MethodName)) == false)
            { Call.Power.SetRecorded(); }
            #endregion
        }

        public void CargoScoop(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Cargo Scoop";

            #region Valid Command Checks
            //If Not In Normal Space...
            if (Check.Environment.Space(IEnums.Normal_Space, true, MethodName, true) == false)
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
            if (Check.Environment.Vehicle(IVehicles.V.Fighter, false, MethodName) == false)
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
            if (Check.Docking.Status(IEnums.DockingState.Docked, false, MethodName) == false)
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
            if (Check.Variable.Touchdown(false, MethodName) == false)
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
            if (Check.Variable.CargoScoop(MethodName) == CMD_State)
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
            else if (Check.Variable.CargoScoop(MethodName) != CMD_State)
            {
                if (CMD_State == true)
                {
                    Call.Key.Press(Call.Key.Cargo_Scoop, 0);

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
                    Call.Key.Press(Call.Key.Cargo_Scoop, 0);

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
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
                    Call.Key.Press(Call.Key.Ship_Lights, 0);
                    IEquipment.ExternalLights.Energizing(CommandAudio);
                    return;
                }
                else if (CMD_State == false)
                {
                    Call.Key.Press(Call.Key.Ship_Lights, 0);
                    IEquipment.ExternalLights.Deenergizing(CommandAudio);
                    return;
                }
            }
            #endregion
        }

        public void Fighter_AttackMyTarget(bool CommandAudio)
        {
            string MethodName = "Fighter (Attack My Target)";

            Call.Key.Press(Call.Key.Attack_Target, 0);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(EQ_Fighter.Order_Attack_Target),
                    CommandAudio,
                    Check.Variable.FighterDeployed(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Fighter_Defending(bool CommandAudio)
        {
            string MethodName = "Fighter (Defend)";

            Call.Key.Press(Call.Key.Defend, 0);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(EQ_Fighter.Order_Defend),
                    CommandAudio,
                    Check.Variable.FighterDeployed(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Fighter_EngageAtWill(bool CommandAudio)
        {
            string MethodName = "Fighter (Engage At Will)";

            Call.Key.Press(Call.Key.Engage_At_Will, 0);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(EQ_Fighter.Order_Engage_At_Will),
                    CommandAudio,
                    Check.Variable.FighterDeployed(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Fighter_Follow(bool CommandAudio)
        {
            string MethodName = "Fighter (Follow)";

            Call.Key.Press(Call.Key.Follow_Me, 0);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(EQ_Fighter.Order_Follow),
                    CommandAudio,
                    Check.Variable.FighterDeployed(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Fighter_HoldPosition(bool CommandAudio)
        {
            string MethodName = "Fighter (Hold Position)";

            Call.Key.Press(Call.Key.Hold_Position, 0);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(EQ_Fighter.Order_Hold_Position),
                    CommandAudio,
                    Check.Variable.FighterDeployed(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Fighter_MaintainFormation(bool CommandAudio)
        {
            string MethodName = "Fighter (Maintain Formation)";

            Call.Key.Press(Call.Key.Maintain_Formation, 0);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true)
                    .Phrase(EQ_Fighter.Order_Maintain_Formation),
                    CommandAudio,
                    Check.Variable.FighterDeployed(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Fighter_Recall(bool CommandAudio)
        {
            string MethodName = "Fighter (Recall)";

            Call.Key.Press(Call.Key.Recall_Fighter, 0);

            #region Audio: Fighter Order (Recall NPC)
            if (Check.Environment.Vehicle(IVehicles.V.Mothership, true, MethodName) == true)
            {
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Positive.Default, true)
                        .Phrase(EQ_Fighter.Order_Recall_NPC),
                        CommandAudio,
                        Check.Variable.FighterDeployed(true, MethodName)
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
            }
            #endregion

            #region Audio: Fighter Order (Recall Player)
            else if (Check.Environment.Vehicle(IVehicles.V.Fighter, true, MethodName) == true)
            {
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Positive.Default, true)
                        .Phrase(EQ_Fighter.Order_Recall_Player),
                        CommandAudio,
                        Check.Variable.FighterDeployed(true, MethodName)
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
            }
            #endregion
        }

        public void Full_Spectrum_Scanner(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Full Spectrum Scanner";

            #region Valid Command Checks
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                IEquipment.DiscoveryScanner.NoHyperspace(CommandAudio);
                return;
            }

            if (Check.Environment.Space(IEnums.Supercruise, true, MethodName) == false)
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
                    IEquipment.DiscoveryScanner.FSSCurrentlyActivated(CommandAudio);
                    return;
                }
                else if (CMD_State == false)
                {
                    IEquipment.DiscoveryScanner.FSSCurrentlyDeactivated(CommandAudio);
                    return;
                }
            }
            #endregion

            #region Status != Command
            else if (IEquipment.DiscoveryScanner.Mode != CMD_State)
            {
                if (CMD_State == true)
                {
                    IEquipment.DiscoveryScanner.FSSActivating(CommandAudio);
                    Call.Key.Press(Call.Key.FSS_Enter, 0);
                    IEquipment.DiscoveryScanner.Mode = CMD_State;

                    return;
                }
                else if (CMD_State == false)
                {
                    IEquipment.DiscoveryScanner.FSSDeactivating(CommandAudio);
                    Call.Key.Press(Call.Key.FSS_Exit, 0);
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
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
            if (Check.Docking.Status(IEnums.DockingState.Docked, false, MethodName) == false)
            {
                return;
            }

            //If Touchdown Is Not False...
            if (Check.Variable.Touchdown(false, MethodName) == false)
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
            if (Check.Environment.Space(IEnums.Supercruise, true, MethodName) == true && CMD_State == true)
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
            if (Check.Variable.Hardpoints(MethodName) == CMD_State)
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
            else if (Check.Variable.Hardpoints(MethodName) != CMD_State)
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

                    if (Check.Variable.Hardpoints(false, MethodName) == true)
                    {
                        Call.Firegroup.Select(Call.Firegroup.Default, false);                        
                        Thread.Sleep(100);
                    }

                    Call.Key.Press(Call.Key.Deploy_Hardpoints, 0);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Hardpoints.Deploying)
                            .Phrase(GN_Combat_Power.Online, false, Check.Order.CombatPower(true, MethodName)),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else if (CMD_State == false)
                {
                    Call.Key.Press(Call.Key.Deploy_Hardpoints, 0);

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(EQ_Hardpoints.Retracting)
                            .Phrase(GN_Combat_Power.Offline, false, Check.Order.CombatPower(true, MethodName)),
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
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
                    Call.Key.Press(Call.Key.Night_Vision_Toggle, 0);

                    return;
                }
                else if (CMD_State == false)
                {
                    Call.Key.Press(Call.Key.Night_Vision_Toggle, 0);

                    return;
                }
            }
            #endregion
        }

        public void LandingGear(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Landing Gear";

            #region Valid Command Checks
            //If Not In Normal Space...
            if (Check.Environment.Space(IEnums.Normal_Space, true, MethodName) == false)
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
            if (Check.Environment.Vehicle(IVehicles.V.Mothership, true, MethodName) == false)
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
            if (Check.Variable.FighterDeployed(false, MethodName) == false)
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
            if (Check.Docking.Status(IEnums.DockingState.Docked, true, MethodName) == true && CMD_State == false)
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
            if (Check.Variable.Touchdown(false, MethodName) == false)
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
            if (Check.Variable.LandingGear(MethodName) == CMD_State)
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
            else if (Check.Variable.LandingGear(MethodName) != CMD_State)
            {
                if (CMD_State == true)
                {
                    Call.Key.Press(Call.Key.Landing_Gear, 0);
                    IStatus.LandingGear = true;

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
                    Call.Key.Press(Call.Key.Landing_Gear, 0);
                    IStatus.LandingGear = false;

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
            if (Check.Environment.Space(IEnums.Normal_Space, true, MethodName) == false)
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
            if (Check.Environment.Vehicle(IVehicles.V.Mothership, true, MethodName) == false)
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
            if (Check.Variable.SilentRunning(MethodName) == CMD_State)
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
            else if (Check.Variable.SilentRunning(MethodName) != CMD_State)
            {
                if (CMD_State == true)
                {
                    Call.Key.Press(Call.Key.Silent_Running, 0);

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
                    Call.Key.Press(Call.Key.Silent_Running, 0);

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

        #region Throttle Methods
        public void Throttle_100(bool Negative = false)
        {
            string MethodName = "Throttle 100 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative) { Call.Key.Press(Call.Key.Set_Speed_To_Minus_100, 0, Call.Key.DelayThrottle); }
            else { Call.Key.Press(Call.Key.Set_Speed_To_100, 0); }
            #endregion
        }

        public void Throttle_95(bool Negative = false)
        {
            string MethodName = "Throttle 95 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_90(bool Negative = false)
        {
            string MethodName = "Throttle 90 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_100, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_100, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_85(bool Negative = false)
        {
            string MethodName = "Throttle 85 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_80(bool Negative = false)
        {
            string MethodName = "Throttle 80 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_100, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_100, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_75(bool Negative = false)
        {
            string MethodName = "Throttle 75 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_75, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_75, 0);
            }
            #endregion
        }

        public void Throttle_70(bool Negative = false)
        {
            string MethodName = "Throttle 70 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_65(bool Negative = false)
        {
            string MethodName = "Throttle 65 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_60(bool Negative = false)
        {
            string MethodName = "Throttle 60 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_55(bool Negative = false)
        {
            string MethodName = "Throttle 55 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_75, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_50(bool Negative = false)
        {
            string MethodName = "Throttle 50 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_50, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_50, 0);
            }
            #endregion
        }

        public void Throttle_45(bool Negative = false)
        {
            string MethodName = "Throttle 45 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_40(bool Negative = false)
        {
            string MethodName = "Throttle 40 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_35(bool Negative = false)
        {
            string MethodName = "Throttle 35 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_30(bool Negative = false)
        {
            string MethodName = "Throttle 30 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_50, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_25(bool Negative = false)
        {
            string MethodName = "Throttle 25 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_25, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_25, 0);
            }
            #endregion
        }

        public void Throttle_20(bool Negative = false)
        {
            string MethodName = "Throttle 20 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_0, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_0, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_15(bool Negative = false)
        {
            string MethodName = "Throttle 15 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_10(bool Negative = false)
        {
            string MethodName = "Throttle 10 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_0, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_0, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_5(bool Negative = false)
        {
            string MethodName = "Throttle 5 (" + Negative.ToString() + ")";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            if (Negative)
            {
                Call.Key.Press(Call.Key.Set_Speed_To_Minus_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Increase_Throttle, 0);
            }
            else
            {
                Call.Key.Press(Call.Key.Set_Speed_To_25, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 100, Call.Key.DelayThrottle);
                Call.Key.Press(Call.Key.Decrease_Throttle, 0);
            }
            #endregion
        }

        public void Throttle_0()
        {
            string MethodName = "Throttle 0";

            #region Validation Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }
            #endregion

            #region Action: Set Throttle
            Call.Key.Press(Call.Key.Set_Speed_To_0, 0);
            #endregion
        }
        //End Region: Throttle Methods
        #endregion

        //End Region: Simple / Sinlge Actions
        #endregion

        #region Compound / Complex Actions

        public void Supercruise(bool CMD_State, bool CommandAudio, bool OnMyMark = false)
        {
            string MethodName = "Supercruise";

            #region Validation Checks
            //Vehicle Check
            if (Check.Environment.Vehicle(IVehicles.V.Mothership, true, MethodName) == false)
            {
                IEquipment.FrameShiftDrive.NotInMothership(CommandAudio);
                return;
            }

            //Hyperspace Check
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                IEquipment.FrameShiftDrive.SC_CurrentlyHyperspace(CommandAudio);
                return;
            }

            //Touchdown Check
            if (Check.Variable.Touchdown(false, MethodName) == false)
            {
                IEquipment.FrameShiftDrive.NoTouchdown(CommandAudio);
                return;
            }

            //Docked Check
            if (Check.Docking.Status(IEnums.DockingState.Docked, false, MethodName) == false)
            {
                IEquipment.FrameShiftDrive.NoDocked(CommandAudio);
                return;
            }

            //Check Charging State && Prepare For Charging
            if (IEquipment.FrameShiftDrive.ChargingState(false, MethodName) == false)
            {
                //Check Hyperspace Charge
                if (IEquipment.FrameShiftDrive.HyperspaceCharge(false, MethodName) == false)
                {
                    Call.Key.Press(Call.Key.Hyperspace_Jump, 100);
                    IEquipment.FrameShiftDrive.Hyperspace = false;

                    //Wait For Charing To End
                    while (IEquipment.FrameShiftDrive.ChargingState(false, MethodName) == false)
                    { Thread.Sleep(50); }
                }
            }
            //Not Charging
            else
            {
                IEquipment.FrameShiftDrive.Hyperspace = false;
                IEquipment.FrameShiftDrive.Supercruise = false;
            }

            //Check Preparing State
            if (IEquipment.FrameShiftDrive.PreparingState(false, MethodName) == false)
            {
                //Check Supercruise Preps
                if (IEquipment.FrameShiftDrive.PreparingSupercruise(false, MethodName) == false)
                {
                    //Add Audio
                    return;
                }

                //Reset Hyperspace Preps & Continue
                IEquipment.FrameShiftDrive.PrepHyperspace = false;                
            }   
            //Not Preparing
            else
            {
                IEquipment.FrameShiftDrive.PrepHyperspace = false;
                IEquipment.FrameShiftDrive.PrepSupercruise = false;
            }
            #endregion

            #region Equipment Line-Up
            //Cargo Scoop Check
            if (Check.Variable.CargoScoop(false, MethodName) == false)
            {
                Call.Action.CargoScoop(false, false);
            }

            //Landing Gear Check
            if (Check.Variable.LandingGear(false, MethodName) == false)
            {
                Call.Action.LandingGear(false, false);
            }
            #endregion

            #region Normal Space
            //Operating In Normal Space
            if (Check.Environment.Space(IEnums.Normal_Space, true, MethodName) == true)
            {
                //Enter Supercruise
                if (CMD_State == true)
                {
                    #region Validation Checks                    

                    //Preparing Frameshift Drive
                    IEquipment.FrameShiftDrive.Prepairing = true;
                    IEquipment.FrameShiftDrive.PrepSupercruise = true;

                    //Supercruse Charge Check
                    if (IEquipment.FrameShiftDrive.SupercruiseCharge(false, MethodName) == false)
                    {
                        IEquipment.FrameShiftDrive.SC_CurrentlyCharging(CommandAudio);
                        return;
                    }
                    else
                    {
                        IEquipment.FrameShiftDrive.SC_Prepairing(CommandAudio);
                    }

                    //Check If We Are Waiting On A Mark
                    if (OnMyMark)
                    {
                        //Sleep To Queue Audio In Synthesizer Correctly
                        Thread.Sleep(100);

                        //On Your Mark Audio
                        IStatus.Interaction.Response.OnYourMark(CommandAudio, false);

                        //Wait 30 Seconds For Mark
                        switch (IStatus.Interaction.WaitForMark(30000, ref IEquipment.FrameShiftDrive.PrepSupercruise, MethodName))
                        {
                            case ALICE_Status.Status_Interaction.Marks.NoResponse:
                                return;

                            case ALICE_Status.Status_Interaction.Marks.Mark:
                                break;

                            case ALICE_Status.Status_Interaction.Marks.EarlyReturn:
                                return;

                            default:
                                return;
                        }
                    }

                    //Masslock Check
                    if (Check.Variable.MassLocked(false, MethodName) == false)
                    {
                        IEquipment.FrameShiftDrive.Masslocked(CommandAudio);

                        while (IStatus.Masslocked == true && IEquipment.FrameShiftDrive.Prepairing == true)
                        {
                            //Wait Till Free Of Masslock.
                            Thread.Sleep(100);
                        }
                    }

                    //Cooldown Check
                    if (IEquipment.FrameShiftDrive.CooldownState(false, MethodName) == false)
                    {
                        IEquipment.FrameShiftDrive.CoolingDown(CommandAudio);

                        while (IEquipment.FrameShiftDrive.Cooldown == true && IEquipment.FrameShiftDrive.Prepairing == true)
                        {
                            //Wait For FSD To Cool Down.
                            Thread.Sleep(100);
                        }
                    }

                    //Prepairing Check
                    if (IEquipment.FrameShiftDrive.PreparingState(true, MethodName) == false || 
                        IEquipment.FrameShiftDrive.PreparingSupercruise(true, MethodName) == false)
                    {
                        //Jump Was Aborted While We Waited, Exit Method.
                        Logger.Log(MethodName, "We Stopped FSD Preparations Cause The Supercruise Was Cancelled", Logger.Yellow, true);
                        return;
                    }
                    #endregion

                    #region Equipment Line-Up
                    //Cargo Scoop Check (Incase It Was Lowered While Waiting)
                    if (Check.Variable.CargoScoop(false, MethodName) == false)
                    {
                        Call.Action.CargoScoop(false, false);
                    }

                    //Landing Gear Check (Incase It Was Lowered While Waiting)
                    if (Check.Variable.LandingGear(false, MethodName) == false)
                    {
                        Call.Action.LandingGear(false, false);
                    }

                    //Hardpoints Check
                    if (Check.Variable.Hardpoints(false, MethodName) == false)
                    {
                        Call.Action.Hardpoint(false, false);
                    }
                    #endregion

                    #region Operate Frameshift Drive
                    //Notes: Charge Audio Controlled By Status.Json Events.
                    
                    //Start & Monitor
                    if (IEquipment.FrameShiftDrive.Start(false) == false)
                    {
                        IEquipment.FrameShiftDrive.FailedToEngage(CommandAudio);
                    }
                    #endregion
                }
                //Currently In Normal Space
                else if (CMD_State == false)
                {
                    IEquipment.FrameShiftDrive.SC_CurrentlyNormalSpace(CommandAudio);
                }
            }
            #endregion

            #region Supercruise
            //Operating In Supercruise
            else if (Check.Environment.Space(IEnums.Supercruise, true, MethodName) == true)
            {
                //Exit Supercruise
                if (CMD_State == false)
                {
                    //Check If We Are Waiting On A Mark
                    if (OnMyMark)
                    {
                        //On Your Mark Audio
                        IStatus.Interaction.Response.OnYourMark(CommandAudio, true);

                        //Fake Reference Bool
                        bool Temp = true;

                        //Wait 30 Seconds For Mark
                        switch (IStatus.Interaction.WaitForMark(30000, ref Temp, MethodName))
                        {
                            case ALICE_Status.Status_Interaction.Marks.NoResponse:
                                return;

                            case ALICE_Status.Status_Interaction.Marks.Mark:
                                break;

                            default:
                                return;
                        }
                    }

                    //Disengagin Audio
                    IEquipment.FrameShiftDrive.SC_Disengaging(CommandAudio);

                    //Stop & Monitor
                    if (IEquipment.FrameShiftDrive.Stop() == false)
                    {
                        //Too Fast Audio
                        IEquipment.FrameShiftDrive.TooFast(CommandAudio);

                        //Watch Response For 10 Seconds
                        switch (IStatus.Interaction.Question(10000))
                        {
                            case ALICE_Status.Status_Interaction.Answers.NoResponse:

                                //Log
                                Logger.Log(MethodName, "No Response Detected", Logger.Yellow, true);

                                break;
                            case ALICE_Status.Status_Interaction.Answers.Yes:

                                //Postive Response Audio
                                IEquipment.FrameShiftDrive.PositiveResponse(CommandAudio);
                                
                                //Emergency Stop & Montor
                                if (IEquipment.FrameShiftDrive.Stop(true) == false)
                                {
                                    IEquipment.FrameShiftDrive.FailedToDisengage(CommandAudio);
                                    IEquipment.FrameShiftDrive.Disengaging = false;
                                }

                                break;

                            case ALICE_Status.Status_Interaction.Answers.No:

                                //Postive Response Audio
                                IEquipment.FrameShiftDrive.PositiveResponse(CommandAudio);

                                //Reset
                                IEquipment.FrameShiftDrive.Disengaging = false;

                                break;

                            default:
                                break;
                        }
                    }
                }
                //Currently In Supercruse
                else if (CMD_State == true)
                {
                    IEquipment.FrameShiftDrive.SC_CurrentlySupercruise(CommandAudio);
                    return;
                }
            }
            #endregion
        }

        public void Hyperspace(bool CMD_State, bool CommandAudio, bool OnMyMark = false)
        {
            string MethodName = "Hyperspace";

            #region Validation Checks
            //Vehicle Check
            if (Check.Environment.Vehicle(IVehicles.V.Mothership, true, MethodName) == false)
            {
                IEquipment.FrameShiftDrive.NotInMothership(CommandAudio);
                return;
            }

            //Touchdown Check
            if (Check.Variable.Touchdown(false, MethodName) == false)
            {
                IEquipment.FrameShiftDrive.NoTouchdown(CommandAudio);
                return;
            }

            //Docked Check
            if (Check.Docking.Status(IEnums.DockingState.Docked, false, MethodName) == false)
            {
                IEquipment.FrameShiftDrive.NoDocked(CommandAudio);
                return;
            }

            //Check Charging State && Prepare For Charging
            if (IEquipment.FrameShiftDrive.ChargingState(false, MethodName) == false)
            {
                //Check Supercruise Charge
                if (IEquipment.FrameShiftDrive.SupercruiseCharge(false, MethodName) == false)
                {
                    Call.Key.Press(Call.Key.Supercruise, 100);
                    IEquipment.FrameShiftDrive.Supercruise = false;

                    //Wait For Charing To End
                    while (IEquipment.FrameShiftDrive.ChargingState(false, MethodName) == false)
                    { Thread.Sleep(50); }
                }
            }
            //Not Charging
            else
            {
                IEquipment.FrameShiftDrive.Hyperspace = false;
                IEquipment.FrameShiftDrive.Supercruise = false;
            }

            //Check Preparing State
            if (IEquipment.FrameShiftDrive.PreparingState(false, MethodName) == false)
            {
                //Check Hyperspace Preps
                if (IEquipment.FrameShiftDrive.PreparingHyperspace(false, MethodName) == false)
                {
                    //Add Audio
                    return;
                }

                //Reset Supercruise Preps & Continue
                IEquipment.FrameShiftDrive.PrepSupercruise = false;
            }
            //Not Preparing
            else
            {
                IEquipment.FrameShiftDrive.PrepHyperspace = false;
                IEquipment.FrameShiftDrive.PrepSupercruise = false;
            }
            #endregion

            #region Hyperspace
            //Operating In Hyperspace
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                //Trying To Enter
                if (CMD_State == true)
                {
                    IEquipment.FrameShiftDrive.HS_CurrentlyHyperspace(CommandAudio);
                    return;
                }
            }
            #endregion

            #region Equipment Line-Up
            //Cargo Scoop Check
            if (Check.Variable.CargoScoop(false, MethodName) == false)
            {
                Call.Action.CargoScoop(false, false);
            }

            //Landing Gear Check
            if (Check.Variable.LandingGear(false, MethodName) == false)
            {
                Call.Action.LandingGear(false, false);
            }
            #endregion

            #region Supercruise / Normal Space
            //Operating In Supercruise/Normal Space
            if (CMD_State == true)
            {
                #region Validation Checks
                //Preparing Frameshift Drive
                IEquipment.FrameShiftDrive.Prepairing = true;
                IEquipment.FrameShiftDrive.PrepHyperspace = true;

                //Supercruse Charge Check
                if (IEquipment.FrameShiftDrive.HyperspaceCharge(false, MethodName) == false)
                {
                    IEquipment.FrameShiftDrive.HS_CurrentlyCharging(CommandAudio);
                    return;
                }
                else
                {
                    IEquipment.FrameShiftDrive.HS_Prepairing(CommandAudio);
                }

                //Check If We Are Waiting On A Mark
                if (OnMyMark)
                {
                    //Sleep To Queue Audio In Synthesizer Correctly
                    Thread.Sleep(100);

                    //On Your Mark Audio
                    IStatus.Interaction.Response.OnYourMark(CommandAudio, false);

                    //Wait 30 Seconds For Mark
                    switch (IStatus.Interaction.WaitForMark(30000, ref IEquipment.FrameShiftDrive.PrepHyperspace, MethodName))
                    {
                        case ALICE_Status.Status_Interaction.Marks.NoResponse:
                            return;

                        case ALICE_Status.Status_Interaction.Marks.Mark:
                            break;

                        case ALICE_Status.Status_Interaction.Marks.EarlyReturn:
                            return;

                        default:
                            return;
                    }
                }

                //Masslock Check
                if (Check.Variable.MassLocked(false, MethodName) == false)
                {
                    IEquipment.FrameShiftDrive.Masslocked(CommandAudio);

                    while (IStatus.Masslocked == true && IEquipment.FrameShiftDrive.Prepairing == true)
                    {
                        //Wait Till Free Of Masslock.
                        Thread.Sleep(100);
                    }
                }

                //Cooldown Check
                if (IEquipment.FrameShiftDrive.CooldownState(false, MethodName) == false)
                {
                    IEquipment.FrameShiftDrive.CoolingDown(CommandAudio);

                    while (IEquipment.FrameShiftDrive.Cooldown == true && IEquipment.FrameShiftDrive.Prepairing == true)
                    {
                        //Wait For FSD To Cool Down.
                        Thread.Sleep(100);
                    }
                }

                //Prepairing Check
                if (IEquipment.FrameShiftDrive.PreparingState(true, MethodName) == false ||
                    IEquipment.FrameShiftDrive.PreparingHyperspace(true, MethodName) == false)
                {
                    //Jump Was Aborted While We Waited, Exit Method.
                    Logger.Log(MethodName, "We Stopped FSD Preparations Cause The Hyperspace Was Cancelled", Logger.Yellow, true);
                    return;
                }
                #endregion

                #region Equipment Line-Up
                //Cargo Scoop Check (Incase It Was Lowered While Waiting)
                if (Check.Variable.CargoScoop(false, MethodName) == false)
                {
                    Call.Action.CargoScoop(false, false);
                }

                //Landing Gear Check (Incase It Was Lowered While Waiting)
                if (Check.Variable.LandingGear(false, MethodName) == false)
                {
                    Call.Action.LandingGear(false, false);
                }

                //Hardpoints Check
                if (Check.Variable.Hardpoints(false, MethodName) == false)
                {
                    Call.Action.Hardpoint(false, false);
                }
                #endregion

                #region Operate Frameshift Drive
                //Notes: Charge Audio Controlled By Status.Json Events.

                //Start & Monitor
                if (IEquipment.FrameShiftDrive.Start(true) == false)
                {
                    IEquipment.FrameShiftDrive.FailedToEngage(CommandAudio);
                }
                #endregion
            }
            #endregion
        }

        public void AbortJump(bool CommandAudio)
        {
            string MethodName = "Abort Jump";

            //Operating In Hyperspace
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                return;
            }

            //Check Charging State
            if (IEquipment.FrameShiftDrive.ChargingState(true, MethodName) == true)
            {
                //Abort Sucessful
                if (IEquipment.FrameShiftDrive.Abort() == true)
                {
                    IEquipment.FrameShiftDrive.AbortSuccessful(CommandAudio);
                }
                //Abort Failed
                else
                {
                    IEquipment.FrameShiftDrive.AbortFailed(CommandAudio);
                    return;
                }

                IEquipment.FrameShiftDrive.Hyperspace = false;
                IEquipment.FrameShiftDrive.Supercruise = false;
                IEquipment.FrameShiftDrive.Prepairing = false;
            }
        }

        public void CompositeScaner(bool CommandAudio, bool SelectOnly = false)
        {
            string MethodName = "Composite Scan";

            //Record Current Firegroup
            decimal Temp = Call.Firegroup.Current;

            #region Vaildtion Checks
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                IEquipment.CompositeScanner.NoHyperspace(CommandAudio);
                return;
            }
            #endregion

            #region Fire Group Management
            Settings_Firegroups.Assignemnt Module = ISettings.Firegroup.GetAssignemnt(Settings_Firegroups.Item.ScannerComposite);

            //Select Firegroup
            switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerComposite))
            {
                case Settings_Firegroups.S.CurrentlySelected:
                    if (SelectOnly) { IEquipment.CompositeScanner.CurrentlySelected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.Selected:
                    if (SelectOnly) { IEquipment.CompositeScanner.Selected(CommandAudio); }                    
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.CompositeScanner.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    IEquipment.CompositeScanner.SelectionFailed(CommandAudio);
                    return;
                case Settings_Firegroups.S.InHyperspace:
                    IEquipment.General.InHyperspace();
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Commenced Audio
            if (Module.FireGroup != Settings_Firegroups.Group.None &&
                Module.FireMode != Settings_Firegroups.Fire.None)
            {
                IEquipment.CompositeScanner.ScanCommenced(CommandAudio);
            }

            //Acivate Module
            switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.ScannerComposite, 8000))
            {
                case Settings_Firegroups.A.Hyperspace:
                    IEquipment.CompositeScanner.EnteredHyperspace(CommandAudio);
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.CompositeScanner.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:
                    IEquipment.CompositeScanner.ScanComplete(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            Call.Firegroup.Select(Temp, false);
        }

        public void DeployFighter(decimal FighterNumber, bool PlayerDeploy, bool CommandAudio)
        {
            string MethodName = "Deploy Fighter";

            #region Validation Checks
            //If Not In Normal Space...
            if (Check.Environment.Space(IEnums.Normal_Space, true, MethodName) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Fighter.Not_Normal_Space),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Not In Mothership...
            if (Check.Environment.Vehicle(IVehicles.V.Mothership, true, MethodName) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Fighter.Not_Mothership),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Not Undocked...
            if (Check.Docking.Status(IEnums.DockingState.Docked, false, MethodName) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Fighter.Mothership_Docked),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Touchdown Is Not False...
            if (Check.Variable.Touchdown(false, MethodName) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Fighter.Touchdown),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Not Outside No Fire Zone...
            if (Check.Event.NoFireZone.Entered(false, MethodName) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Fighter.No_Fire_Zone),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Altitude Is Not Zero && Ship Is Not Outside Altitude Band...
            if (IStatus.Altitude != 0 && (Check.Environment.Altitude(1, 1001, false, MethodName) == false))
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Fighter.Altitude),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            //If Fighter Hanger Not Installed...
            if (Check.Equipment.FighterHanger(true, MethodName) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Fighter.No_Fighter_Hanger),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            if (Check.Equipment.FighterHangerTotal(FighterNumber, MethodName) == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(GN_Negative.Default, true)
                        .Phrase(EQ_Fighter.Hanger_Total),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                return;
            }

            #region Crew Check
            if (IStatus.NPC_Crew == false && PlayerDeploy != true)
            {
                Logger.Log(MethodName, "No Crew", Logger.Red);
                
                //Audio - No Crew

                return;
            }
            #endregion

            Logger.DebugLine(MethodName, "Passed All Checks, Attempting Fighter Deployment", Logger.Red);
            #endregion

            #region Landing Gear Check
            //If Landing Gear Is True...
            if (Check.Variable.LandingGear(true, MethodName) == true)
            {
                Call.Action.LandingGear(false, CommandAudio);

                Thread.Sleep(1000);

                //If Landing Gear Is True...
                if (Check.Variable.LandingGear(true, MethodName) == true)
                {
                    Logger.DebugLine(MethodName, "Landing Gear Failed To Retract.", Logger.Red);

                    return;
                }
            }
            #endregion

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Positive.Default, true),
                    CommandAudio
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion

            Wait_FighterLaunch = true;

            #region Panel Control: Launch Figther
            if (Check.Panel.Fighters(MethodName) == false)
            { Call.Panel.Role.Fighters.Open(MethodName); }

            if (Check.Panel.Role(true, MethodName) == false)
            {
                Call.Panel.Role.Panel(true);
                Call.Key.Press(Call.Key.Previous_Panel_Tab, 100, Call.Key.DelayPanel);
                Call.Key.Press(Call.Key.Next_Panel_Tab, 100, Call.Key.DelayPanel);
            }

            if (FighterNumber == 2)
            {
                Thread.Sleep(100 + ISettings.OffsetPanels);
                Call.Key.Press(Call.Key.UI_Panel_Down, 100, Call.Key.DelayPanel);
            }

            Call.Key.Press(Call.Key.UI_Panel_Select, 100, Call.Key.DelayPanel);
            Call.Key.Press(Call.Key.UI_Panel_Down_Press, 750, Call.Key.DelayPanel);
            Call.Key.Press(Call.Key.UI_Panel_Down_Release, 100, Call.Key.DelayPanel);
            Call.Key.Press(Call.Key.UI_Panel_Up_Press, 750, Call.Key.DelayPanel);
            Call.Key.Press(Call.Key.UI_Panel_Up_Release, 100, Call.Key.DelayPanel);
            Call.Key.Press(Call.Key.UI_Panel_Select, 250, Call.Key.DelayPanel);

            //Fighter Sub Menu
            Call.Key.Press(Call.Key.UI_Panel_Up, 100, Call.Key.DelayPanel);
            Call.Key.Press(Call.Key.UI_Panel_Up, 100, Call.Key.DelayPanel);
            Call.Key.Press(Call.Key.UI_Panel_Up, 100, Call.Key.DelayPanel);
            Call.Key.Press(Call.Key.UI_Panel_Down, 100, Call.Key.DelayPanel);

            if (PlayerDeploy == false)
            {
                Logger.DebugLine(MethodName, "Crew Selected for Launch", Logger.Yellow);
                Call.Key.Press(Call.Key.UI_Panel_Down, 100, Call.Key.DelayPanel);
            }

            Call.Key.Press(Call.Key.UI_Panel_Select, 250, Call.Key.DelayPanel);
            Call.Panel.Role.Panel(false);
            #endregion

            #region Wait: LaunchFighter Event
            int LaunchCounter = 0; while (Wait_FighterLaunch == true && Check.Environment.Space(IEnums.Normal_Space, true, MethodName, true) == true)
            {
                Logger.DebugLine(MethodName, "Checking: (Wait) LaunchFighter Event = " + Wait_FighterLaunch + " | Environment Is Normalspace = " + Check.Environment.Space(IEnums.Normal_Space, true, MethodName), Logger.Blue);

                if (LaunchCounter > 100)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(EQ_Fighter.Launch_Error),
                            CommandAudio
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                
                    Wait_FighterLaunch = false;
                    return;
                } Thread.Sleep(100); LaunchCounter++;
            }

            Logger.DebugLine(MethodName, "Checking: (Wait) LaunchFighter Event = " + Wait_FighterLaunch + " | Environment Is Normalspace = " + Check.Environment.Space(IEnums.Normal_Space, true, MethodName), Logger.Blue);

            if (Check.Environment.Space(IEnums.Normal_Space, false, MethodName, true) == true)
            {
                return;
            }
            #endregion

            Thread.Sleep(6000);

            #region Fighter Launched (Crew)
            if (PlayerDeploy == false)
            {
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(EQ_Fighter.Launch),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
            }
            #endregion

            #region Fighter Launched (Player)
            if (PlayerDeploy == true)
            {
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(EQ_Fighter.Launch)
                        .Phrase(EQ_Fighter.Launch_Player_Modifer),
                        CommandAudio
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
            }
            #endregion
        }

        public void DiscoveryScanner(bool CommandAudio, bool Sleep = false, bool SelectOnly = false)
        {
            string MethodName = "Discovery Scan";

            //Record Current Firegroup
            decimal Temp = Call.Firegroup.Current;

            #region Vaildtion Checks
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
            {
                //Audio
                return;
            }
            #endregion

            #region Fire Group Management
            if (Sleep == true) { Thread.Sleep(3000); }

            Settings_Firegroups.Assignemnt Module = ISettings.Firegroup.GetAssignemnt(Settings_Firegroups.Item.ScannerDiscovery);

            //Select Firegroup
            switch (ISettings.Firegroup.Select(Settings_Firegroups.Item.ScannerDiscovery))
            {
                case Settings_Firegroups.S.CurrentlySelected:
                    if (SelectOnly) { IEquipment.DiscoveryScanner.CurrentlySelected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.Selected:
                    if (SelectOnly) { IEquipment.DiscoveryScanner.Selected(CommandAudio); }
                    break;
                case Settings_Firegroups.S.NotAssigned:
                    IEquipment.DiscoveryScanner.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.S.Failed:
                    IEquipment.DiscoveryScanner.SelectionFailed(CommandAudio);
                    return;
                case Settings_Firegroups.S.InHyperspace:
                    IEquipment.General.InHyperspace();
                    return;
                default:
                    return;
            }

            //Exit If Only Selecting Item.
            if (SelectOnly) { return; }

            //Commenced Audio
            if (Module.FireGroup != Settings_Firegroups.Group.None && 
                Module.FireMode != Settings_Firegroups.Fire.None)
            {
                IEquipment.DiscoveryScanner.ScanCommenced(CommandAudio);
            }

            //Acivate Module && Watch Return
            switch (ISettings.Firegroup.Activate(Settings_Firegroups.Item.ScannerDiscovery, 
                8000, true, IEquipment.DiscoveryScanner.Watcher))
            {
                case Settings_Firegroups.A.Hyperspace:
                    IEquipment.DiscoveryScanner.EnteredHyperspace(CommandAudio);
                    return;
                case Settings_Firegroups.A.NotAssigned:
                    IEquipment.DiscoveryScanner.NotAssigned(CommandAudio);
                    return;
                case Settings_Firegroups.A.Complete:

                    IEquipment.DiscoveryScanner.ScanComplete(CommandAudio);
                    break;
                case Settings_Firegroups.A.Fail:
                    IEquipment.DiscoveryScanner.ScanFailed(CommandAudio);
                    break;
                default:
                    return;
            }
            #endregion

            //Return To Previou Firegroup.
            Call.Firegroup.Select(Temp, false);
        }

        public void Docking(IEnums.CMD Request, bool CommandAudio, bool PlayerCMD = true)
        {
            string MethodName = "Docking";

            switch (Request)
            {
                //Request Docking
                case IEnums.CMD.True:

                    #region Validation
                    //Pending Request Check 
                    if (IStatus.Docking.Sending == true || IStatus.Docking.Pending == true)
                    {
                        //Audio - Request Pending.
                        Logger.DebugLine(MethodName, "Request Pending", Logger.Blue);
                        return;
                    }

                    //Check Docking State
                    switch (IStatus.Docking.State)
                    {
                        case IEnums.DockingState.Granted:
                            IStatus.Docking.Response.AlreadyGranted(CommandAudio);
                            return;

                        case IEnums.DockingState.Docked:
                            IStatus.Docking.Response.Docked(CommandAudio);
                            return;

                        default:
                            break;
                    }
                    #endregion

                    #region Send Request
                    //Send Request
                    IStatus.Docking.Response.Positve(CommandAudio, PlayerCMD);
                    IStatus.Docking.Sending = true;
                    Call.Panel.Target.Contacts.DockingRequest();
                    Call.Panel.Target.Panel(false);

                    //Watch For Request To Send
                    if (IStatus.Docking.WatchRequest() == false)
                    {
                        Logger.Log(MethodName, "Looks Like Something Went Wrong, Reqeust Didnt Send. Try Again.", Logger.Red);
                        return;
                    }

                    //Watch For Station Response
                    if (IStatus.Docking.WatchResponse() == false)
                    {
                        Logger.Log(MethodName, "Looks Like The Station Is Taking Too Long To Respond. I've Lost Intrest.", Logger.Red);
                        return;
                    }

                    //Station Response
                    switch (IStatus.Docking.State)
                    {
                        case IEnums.DockingState.Granted:

                            IStatus.Docking.Response.Granted(CommandAudio);
                            break;

                        case IEnums.DockingState.Denied:

                            switch (IStatus.Docking.Denial)
                            {
                                case IEnums.DockingDenial.ActiveFighter:
                                    IStatus.Docking.Response.ActiveFighter(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.Distance:
                                    IStatus.Docking.Response.Distance(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.Offences:
                                    IStatus.Docking.Response.Offences(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.Hostile:
                                    IStatus.Docking.Response.Hostile(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.TooLarge:
                                    IStatus.Docking.Response.TooLarge(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.NoSpace:
                                    IStatus.Docking.Response.NoSpace(CommandAudio);
                                    break;

                                case IEnums.DockingDenial.NoReason:
                                    IStatus.Docking.Response.NoReason(CommandAudio);
                                    break;

                                default:
                                    IStatus.Docking.Response.Unknown(CommandAudio);
                                    break;
                            }
                            break;

                        default:
                            break;
                    }
                    #endregion

                    #region Assisted Docking
                    if (Check.Order.AssistDocking(true, MethodName))
                    {
                        switch (Check.Equipment.DockingComputer(true, MethodName))
                        {
                            case true:
                                Call.Key.Press(Call.Key.Set_Speed_To_0, 0, Call.Key.DelayThrottle);
                                IStatus.Docking.Response.StationHandover(CommandAudio);

                                //Resets the Report Bool for if the docking computer is not
                                //installed. This allows us to report again if Assisted Docking
                                //is enabled and there is no docking computer again.
                                IEquipment.DockingComputer.AsisstedDockingReport = true;

                                //Return: Docking Preps Controlled By Auto Docking.
                                return;

                            case false:
                                IEquipment.DockingComputer.NotInstalled(CommandAudio, IEquipment.DockingComputer.AsisstedDockingReport);

                                //Prevents Reporting No Docking Computer more then once.
                                IEquipment.DockingComputer.AsisstedDockingReport = false;
                                break;
                        }
                    }
                    #endregion

                    #region Docking Preparations
                    IStatus.Docking.WatchStarportEntry();
                    #endregion

                    break;

                //Cancel Docking
                case IEnums.CMD.False:

                    switch (IStatus.Docking.State)
                    {
                        case IEnums.DockingState.Granted:
                            if (Check.Variable.LandingGear(true, MethodName) == true)
                            { Call.Action.LandingGear(false, false); }
                            Call.Panel.Target.Contacts.DockingRequest();
                            Call.Panel.Target.Panel(false);
                            return;

                        case IEnums.DockingState.Docked:
                            IStatus.Docking.Response.Docked(CommandAudio);
                            return;

                        default:
                            break;
                    }

                    return;
            }
        }

        public void DockingPreparations(bool CommandAudio)
        {
            string MethodName = "Docking Preparations";

            IStatus.Docking.Preparations = true;

            if (Check.Variable.SilentRunning(true, MethodName) == true)
            {
                Call.Action.SilentRunning(false, CommandAudio);
                Call.Power.Set(0, 4, 8);
            }
            else
            {
                Call.Power.Set(0, 8, 4);
            }

            Call.Action.LandingGear(true, false);
            Call.Action.CargoScoop(false, false);

            Thread.Sleep(2000);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(GN_Docking_Preparations.Modifier, true)
                    .Phrase(EQ_Shields.Offline, false, !IStatus.Shields, false)
                    .Phrase(GN_Docking_Preparations.Default),
                    CommandAudio
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public void Interdict(bool CommandAudio)
        {
            string MethodName = "Interdict";

            #region Vaildtion Checks
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
            if (SelectOnly == false && Check.Environment.Space(IEnums.Supercruise, true, MethodName) == false)
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
                    Call.Key.Press(Call.Key.UI_Back, 0);

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
            if (Check.Environment.Space(IEnums.Normal_Space, true, MethodName) == false)
            {
                IEquipment.XenoScanner.NotInNormalSpace(CommandAudio);
                return;
            }

            if (Check.Environment.Vehicle(IVehicles.V.Mothership, true, MethodName) == false)
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
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
        public void Fighter_PrepairAmbush(bool CommandAudio)
        {

        }

        public void FlightAssist(bool CMD_State, bool CommandAudio)
        {
            string MethodName = "Flight Assist";

            #region Valid Command Checks
            //Check Not In Hyperspace
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
            if (Check.Variable.FlightAssist(MethodName) == CMD_State)
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
            else if (Check.Variable.FlightAssist(MethodName) != CMD_State)
            {
                if (CMD_State == true)
                {
                    Call.Key.Press(Call.Key.Toggle_Flight_Assist, 0);

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
                    Call.Key.Press(Call.Key.Toggle_Flight_Assist, 0);

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

            if (Check.Docking.Status(IEnums.DockingState.Docked, true, MethodName) == true)
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
                Call.Key.Press(Call.Key.UI_Panel_Down_Press, 2000);
                Call.Key.Press(Call.Key.UI_Panel_Down_Release, 100);
                Call.Key.Press(Call.Key.UI_Panel_Select, 250);

                //Wait For Launch (30 seconds)
                decimal Count = 300; while (Check.Docking.Status(IEnums.DockingState.Undocked, true, MethodName) == false && Count > 0)
                {
                    Count--; if (Count == 0)
                    {
                        //Add Audio - Failed To Launch
                        Logger.Log(MethodName, "Failed To Launch, Try Again.", Logger.Yellow, true);
                    }
                    Thread.Sleep(100);
                }

                //Move Ship Away From Ground                
                Call.Key.Press(Call.Key.Thrust_Up_Press, 3000);
                Call.Key.Press(Call.Key.Thrust_Up_Release);

                //Add Audio - Handover                      
                Logger.Log(MethodName, "Undocking Complete, Controls Released.", Logger.Yellow, true);
            }

            else if (Check.Variable.Touchdown(true, MethodName) == true)
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
                Call.Key.Press(Call.Key.Thrust_Up_Press);
                //Wait For Engines To Engage / Takeoff
                decimal Count = 50; while(Check.Variable.Touchdown(false, MethodName) == false && Count > 0)
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
                Call.Key.Press(Call.Key.Thrust_Up_Release);

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
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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

            if (Check.Environment.Space(IEnums.Normal_Space, true, MethodName) == false)
            {
                return;
            }

            while (Cycle != 0 && Cycle > 0)
            {
                if (Forward == true)
                {
                    Call.Key.Press(Call.Key.Cycle_Next_Subsystem, 150);
                }
                else if (Forward == false)
                {
                    Call.Key.Press(Call.Key.Cycle_Previous_Subsystem, 150);
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

            if (Check.Environment.Space(IEnums.Hyperspace, true, MethodName) == true)
            {
                //Audio
                return;
            }

            while (Cycle != 0 && Cycle > 0)
            {
                if (Forward == true)
                {
                    Call.Key.Press(Call.Key.Cycle_Next_Hostile_Target, 0);
                }
                else if (Forward == false)
                {
                    Call.Key.Press(Call.Key.Cycle_Previous_Hostile_Ship, 0);
                }
                Cycle--;
                Thread.Sleep(100);
            }
        }

        public static void Cycle_Targets(decimal Cycle, bool Forward)
        {
            string MethodName = "Cycle Target";

            if (Check.Environment.Space(IEnums.Hyperspace, true, MethodName) == true)
            {
                //Audio
                return;
            }

            while (Cycle != 0 && Cycle > 0)
            {
                if (Forward == true)
                {
                    Call.Key.Press(Call.Key.Cycle_Next_Target , 0);
                }
                else if (Forward == false)
                {
                    Call.Key.Press(Call.Key.Cycle_Previous_Ship , 0);
                }
                Cycle--;
                Thread.Sleep(100);
            }
        }

        public static void Select_Wingman(decimal Wingman, bool CommandAudio)
        {
            string MethodName = "Select Wingman";

            if (Check.Environment.Space(IEnums.Hyperspace, false, MethodName) == false)
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
                Call.Key.Press(Call.Key.Select_Wingman_1 , 0);
            }
            else if (Wingman == 2)
            {
                Call.Key.Press(Call.Key.Select_Wingman_2, 0);
            }
            else if (Wingman == 3)
            {
                Call.Key.Press(Call.Key.Select_Wingman_3, 0);
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

            Call.Key.Press(Call.Key.Select_Wingmans_Target, 100);

            //DYNAMIC AUDIO
        }

        public static void Select_Wingmans_NavLock(decimal Wingman, bool CommandAudio)
        {
            if (Wingman != 0)
            {
                Select_Wingman(Wingman, false);
            }
            Call.Key.Press(Call.Key.Wingman_NavLock, 100);

            //DYNAMIC AUDIO
        }

        #endregion
    }
}
