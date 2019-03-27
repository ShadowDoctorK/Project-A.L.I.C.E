using ALICE_Core;
using ALICE_Equipment;
using ALICE_Events;
using ALICE_Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Status
{
    public class Status_Music
    {
        private readonly string MethodName = "Music Status";

        public Responses Response = new Responses();

        public void Update(Music Event)
        {
            IEnums.MusicState M = IEnums.MusicState.NotSet;

            try
            {
                M = IEnums.ToEnum<IEnums.MusicState>(Event.MusicTrack, false);
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);
            }

            //Process Music Tied Events
            switch (M)
            {
                case IEnums.MusicState.CapitalShip:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Codex:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Combat_Dogfight:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Combat_SRV:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Combat_Unknown:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Combat_LargeDogFight:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.CQC:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.CQCMenu:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.DestinationFromHyperspace:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.DestinationFromSupercruise:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.DockingComputer:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Exploration:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.GalacticPowers:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.GalaxyMap:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Interdiction:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Lifeform_FogCloud:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.MainMenu:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.NoTrack:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Supercruise:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Starport:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Squadrons:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.SystemAndSurfaceScanner:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.SystemMap:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Unknown_Exploration:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Unknown_Encounter:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                case IEnums.MusicState.Unknown_Settlement:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;

                default:
                    Logger.Log(MethodName, "New Music State Detected. " + Event.MusicTrack + " Recorded In The Devloper Update Log.", Logger.Yellow);
                    Logger.RecordUpdate(Event.MusicTrack, MethodName);
                    break;
            }

            //Update Plugin Properties
            if (M != IEnums.MusicState.SystemAndSurfaceScanner)
            {
                IEquipment.SurfaceScanner.Mode = false;
                IEquipment.DiscoveryScanner.Mode = false;
            }
        }

        public class Responses
        {
            string MethodName = "Music Status";
        }
    }
}
