using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using ALICE_Keybinds;
using ALICE_Objects;
using ALICE_Response;
using ALICE_Settings;
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
            if (ICheck.Status.Vehicle(MethodName, IVehicles.V.Mothership, true) == false)
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
            if (IStatus.Altitude != 0 && (ICheck.Status.Altitude(MethodName, 1, 1001, false) == false))
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
                IKeyboard.Press(IKey.Previous_Panel_Tab, 100, IKey.DelayPanel);
                IKeyboard.Press(IKey.Next_Panel_Tab, 100, IKey.DelayPanel);
            }

            if (FighterNumber == 2)
            {
                Thread.Sleep(100 + ISettings.OffsetPanels);
                IKeyboard.Press(IKey.UI_Panel_Down, 100, IKey.DelayPanel);
            }

            IKeyboard.Press(IKey.UI_Panel_Select, 100, IKey.DelayPanel);
            IKeyboard.Press(IKey.UI_Panel_Down_Press, 750, IKey.DelayPanel);
            IKeyboard.Press(IKey.UI_Panel_Down_Release, 100, IKey.DelayPanel);
            IKeyboard.Press(IKey.UI_Panel_Up_Press, 750, IKey.DelayPanel);
            IKeyboard.Press(IKey.UI_Panel_Up_Release, 100, IKey.DelayPanel);
            IKeyboard.Press(IKey.UI_Panel_Select, 250, IKey.DelayPanel);

            //Fighter Sub Menu
            IKeyboard.Press(IKey.UI_Panel_Up, 100, IKey.DelayPanel);
            IKeyboard.Press(IKey.UI_Panel_Up, 100, IKey.DelayPanel);
            IKeyboard.Press(IKey.UI_Panel_Up, 100, IKey.DelayPanel);
            IKeyboard.Press(IKey.UI_Panel_Down, 100, IKey.DelayPanel);

            if (PlayerDeploy == false)
            {
                Logger.DebugLine(MethodName, "Crew Selected for Launch", Logger.Yellow);
                IKeyboard.Press(IKey.UI_Panel_Down, 100, IKey.DelayPanel);
            }

            IKeyboard.Press(IKey.UI_Panel_Select, 250, IKey.DelayPanel);
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

            IKeyboard.Press(IKey.Attack_Target, 0);

            //Audio - Attack My Target
            IResponse.Fighter.AttackMyTarget(
                CommandAudio,                                       //Check Command Audio
                ICheck.Status.FighterDeployed(MethodName, true));   //Check Fighter Deployed
        }

        public void Defending(bool CommandAudio)
        {
            string MethodName = "Fighter (Defend)";

            IKeyboard.Press(IKey.Defend, 0);

            //Audio - Defending
            IResponse.Fighter.Defending(
                CommandAudio,                                       //Check Command Audio
                ICheck.Status.FighterDeployed(MethodName, true));   //Check Fighter Deployed
        }

        public void EngageAtWill(bool CommandAudio)
        {
            string MethodName = "Fighter (Engage At Will)";

            IKeyboard.Press(IKey.Engage_At_Will, 0);
            
            //Audio - Engage At Will
            IResponse.Fighter.EngageAtWill(
                CommandAudio,                                       //Check Command Audio
                ICheck.Status.FighterDeployed(MethodName, true));   //Check Fighter Deployed
        }

        public void Follow(bool CommandAudio)
        {
            string MethodName = "Fighter (Follow)";

            IKeyboard.Press(IKey.Follow_Me, 0);

            //Audio - Follow
            IResponse.Fighter.Follow(
                CommandAudio,                                       //Check Command Audio
                ICheck.Status.FighterDeployed(MethodName, true));   //Check Fighter Deployed
        }

        public void HoldPosition(bool CommandAudio)
        {
            string MethodName = "Fighter (Hold Position)";

            IKeyboard.Press(IKey.Hold_Position, 0);

            //Audio - Hold Position
            IResponse.Fighter.HoldPosition(
                CommandAudio,                                       //Check Command Audio
                ICheck.Status.FighterDeployed(MethodName, true));   //Check Fighter Deployed
        }

        public void MaintainFormation(bool CommandAudio)
        {
            string MethodName = "Fighter (Maintain Formation)";

            IKeyboard.Press(IKey.Maintain_Formation, 0);

            //Audio - Maintain Formation
            IResponse.Fighter.MaintainFormation(
                CommandAudio,                                       //Check Command Audio
                ICheck.Status.FighterDeployed(MethodName, true));   //Check Fighter Deployed
        }

        public void Recall(bool CommandAudio)
        {
            string MethodName = "Fighter (Recall)";

            IKeyboard.Press(IKey.Recall_Fighter, 0);

            //Audio - Recall (NPC)
            IResponse.Fighter.RecallNPC(
                CommandAudio,                                                       //Check Command Audio
                ICheck.Status.FighterDeployed(MethodName, true),                    //Check Fighter Deployed
                ICheck.Status.Vehicle(MethodName, IVehicles.V.Mothership, true));   //Check Vehicle

            //Audio - Recall (Player)
            IResponse.Fighter.RecallPlayer(
                CommandAudio,                                                   //Check Command Audio
                ICheck.Status.FighterDeployed(MethodName, true),                //Check Fighter Deployed
                ICheck.Status.Vehicle(MethodName, IVehicles.V.Fighter, true));  //Check Vehicle
        }
    }
}
