﻿using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Settings;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALICE_Actions
{
    public class Fighter
    {
        public void Deploy(decimal FighterNumber, bool PlayerDeploy, bool CommandAudio)
        {
            string MethodName = "Deploy Fighter";

            #region Validation Checks
            //If Not In Normal Space...
            if (ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space) == false)
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
            if (ICheck.Docking.Status(MethodName, false, IEnums.DockingState.Docked, true) == false)
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
            if (ICheck.NoFireZone.Status(MethodName, false, true) == false)
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
            if (ICheck.LandingGear.Status(MethodName, true, true) == true)
            {
                Call.Action.LandingGear(false, CommandAudio);

                Thread.Sleep(1000);

                //If Landing Gear Is True...
                if (ICheck.LandingGear.Status(MethodName, true, true) == true)
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

            IStatus.Fighter.WaitLaunch = true;

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
            int LaunchCounter = 0; while (IStatus.Fighter.WaitLaunch == true && ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space, true) == true)
            {
                Logger.DebugLine(MethodName, "Checking: (Wait) LaunchFighter Event = " + IStatus.Fighter.WaitLaunch + " | Environment Is Normalspace = " + ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space), Logger.Blue);

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

                    IStatus.Fighter.WaitLaunch = false;
                    return;
                }
                Thread.Sleep(100); LaunchCounter++;
            }

            Logger.DebugLine(MethodName, "Checking: (Wait) LaunchFighter Event = " + IStatus.Fighter.WaitLaunch + " | Environment Is Normalspace = " + ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space), Logger.Blue);

            if (ICheck.Environment.Space(MethodName, false, IEnums.Normal_Space, true) == true)
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

        public void AttackMyTarget(bool CommandAudio)
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

        public void Defending(bool CommandAudio)
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

        public void EngageAtWill(bool CommandAudio)
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

        public void Follow(bool CommandAudio)
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

        public void HoldPosition(bool CommandAudio)
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

        public void MaintainFormation(bool CommandAudio)
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

        public void Recall(bool CommandAudio)
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
    }
}