using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Response;
using ALICE_Settings;
using ALICE_Synthesizer;
using System.Threading;

namespace ALICE_Actions
{
    public static partial class IActions
    {
        public static Fighter Fighter { get; set; } = new Fighter();    
    }

    public class Fighter
    {
        public void Deploy(decimal FighterNumber, bool PlayerDeploy, bool CommandAudio)
        {
            string MethodName = "Deploy Fighter";

            #region Validation Checks
            //Check Normal Space
            if (ICheck.Environment.Space(MethodName, true, IEnums.Normal_Space) == false)
            {
                IResponse.Fighter.NotNormalSpace(CommandAudio); return;
            }

            //Check Mothership
            if (Check.Environment.Vehicle(IVehicles.V.Mothership, true, MethodName) == false)
            {
                IResponse.Fighter.NotInMothership(CommandAudio); return;
            }

            //Check Undocked
            if (ICheck.Docking.Status(MethodName, false, IEnums.DockingState.Docked, true) == false)
            {
                IResponse.Fighter.MothershipDocked(CommandAudio); return;
            }

            //Check Touchdown
            if (ICheck.Status.Touchdown(MethodName, false) == false)
            {
                IResponse.Fighter.MothershipTouchdown(CommandAudio); return;
            }

            //Check No Fire Zone
            if (ICheck.NoFireZone.Status(MethodName, false, true) == false)
            {
                IResponse.Fighter.InNoFireZone(CommandAudio); return;
            }

            //Check Altitude
            if (IStatus.Altitude != 0 && (Check.Environment.Altitude(1, 1001, false, MethodName) == false))
            {
                IResponse.Fighter.LowAltitude(CommandAudio); return;
            }

            //Check Fighter Installed
            if (Check.Equipment.FighterHanger(true, MethodName) == false)
            {
                IResponse.Fighter.NoFighter(CommandAudio); return;
            }

            //Check Fighter Hanger
            if (Check.Equipment.FighterHangerTotal(FighterNumber, MethodName) == false)
            {
                IResponse.Fighter.NoHanger(CommandAudio); return;
            }

            //Check Crew
            if (IStatus.NPC_Crew == false && PlayerDeploy != true)
            {
                Logger.Log(MethodName, "No Crew", Logger.Red);

                //Audio - No Crew

                return;
            }
            
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

            //Audio - Postive Response
            IResponse.General.Positve(
                CommandAudio);                  //Check Command Audio

            IStatus.Fighter.WaitLaunch = true;

            #region Panel Control: Launch Figther
            if (ICheck.Panel.Role.Fighters(MethodName, true) == false)
            {
                Call.Panel.Role.Fighters.Open(MethodName);
            }

            if (ICheck.Panel.Role.Open(MethodName, true) == false)
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
                    //Audio - Fighter Launch Error
                    IResponse.Fighter.LaunchedCrew(
                        CommandAudio);                  //Check Command Audio                        

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

            //Audio - Fighter Launched (Crew)
            IResponse.Fighter.LaunchedCrew(
                CommandAudio,                   //Check Command Audio
                (PlayerDeploy == false));       //Check Player Deploy Status

            //Audio - Fighter Launched (Player)
            IResponse.Fighter.LaunchedPlayer(
                CommandAudio,                   //Check Command Audio
                (PlayerDeploy == true));        //Check Player Deploy Status   
        }

        public void Fighter_PrepairAmbush(bool CommandAudio)
        {

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
                    ICheck.Status.FighterDeployed(MethodName, true)
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
                    ICheck.Status.FighterDeployed(MethodName, true)
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
                    ICheck.Status.FighterDeployed(MethodName, true)
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
                    ICheck.Status.FighterDeployed(MethodName, true)
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
                    ICheck.Status.FighterDeployed(MethodName, true)
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
                    ICheck.Status.FighterDeployed(MethodName, true)
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
                        ICheck.Status.FighterDeployed(MethodName, true)
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
                        ICheck.Status.FighterDeployed(MethodName, true)
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
            }
            #endregion
        }
    }
}
