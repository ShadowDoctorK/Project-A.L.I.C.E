using ALICE.Properties;
using ALICE_Internal;
using ALICE_Settings;
using System;

namespace ALICE_Status
{
    public static partial class IStatus
    {
        public static bool False = false;

        public enum V
        {
            Default,
            Mothership,
            Fighter,
            SRV
        }

        //Track Current Commander
        public static string _Commander = "Default";
        public static string Commander
        {
            get => _Commander;
            set
            {
                //Check Value
                if (_Commander == value) { return; }

                //Debug Logger
                Logger.DebugLine("Commander Property", "Updated: " + value, Logger.Yellow);

                //Property Value
                _Commander = value;

                //User Settings
                ISettings.User.CMDR("Commander Property", value);
            }
        }

        //Track Vehicle
        private static V _Vehicle = V.Default;
        public static V Vehicle
        {
            get => _Vehicle;
            set
            {
                if (_Vehicle == value) { return; }

                if (value == V.Mothership)
                {
                    ISettings.Firegroups.GetConfig("IStatus Vehicle", IStatus.Mothership.ID, IStatus.Mothership.FingerPrint);
                }
                else if (value == V.SRV)
                {
                    ISettings.Firegroups.GetConfig("IStatus Vehicle", 98, "SRV");
                }
                else if (value == V.Fighter)
                {
                    ISettings.Firegroups.GetConfig("IStatus Vehicle", 97, "Fighter");
                }

                _Vehicle = value;
            }
        }

        /// <summary>
        /// Returns FingerPrint Based On Current Vehicle. Used With Equipment Configurations.
        /// </summary>
        public static string FingerPrint
        {
            get
            {
                switch (Vehicle)
                {                    
                    case V.Mothership:
                        return IStatus.Mothership.FingerPrint;
                    case V.Fighter:
                        return "Fighter";
                    case V.SRV:
                        return "SRV";
                    default:
                        return "Default";
                }
            }
        }

        /// <summary>
        /// Returns ID Based On Current Vehicle. Used With Equipment Configurations.
        /// </summary>
        public static decimal VehicleID
        {
            get
            {
                switch (Vehicle)
                {
                    case V.Mothership:
                        return IStatus.Mothership.ID;
                    case V.Fighter:
                        return 97;
                    case V.SRV:
                        return 98;
                    default:
                        return 99;
                }
            }
        }

        public static Status_Cargo Cargo { get; set; } = new Status_Cargo();
        public static Status_Crew Crew { get; set; } = new Status_Crew();
        public static Status_Crime Crime { get; set; } = new Status_Crime();
        public static Status_Bounty Bounty { get; set; } = new Status_Bounty();
        public static Status_Docking Docking { get; set; } = new Status_Docking();
        public static Status_Fighter Fighter { get; set; } = new Status_Fighter();
        public static Status_Heat Heat { get; set; } = new Status_Heat();
        public static Status_Interaction Interaction { get; set; } = new Status_Interaction();
        public static Status_Materials Materials { get; set; } = new Status_Materials();
        public static Status_Messages Messages { get; set; } = new Status_Messages();
        public static Status_Music Music { get; set; } = new Status_Music();
        public static Status_Planet Planet { get; set; } = new Status_Planet();
        public static Status_Scan Scan { get; set; } = new Status_Scan();
        public static Status_Scanned Scanned { get; set; } = new Status_Scanned();
        public static Status_Shipyard Shipyard { get; set; } = new Status_Shipyard();
        public static Status_System System { get; set; } = new Status_System();

        public static string BodyName = "None";
        public static string LegalStatus = "None";

        public static decimal PlanetRadius = -1;
        public static decimal GUI_Focus = 0;
        public static decimal Latitude = -1;
        public static decimal Longitude = -1;
        public static decimal Heading = -1;
        public static decimal Altitude = -1;
        public static decimal CargoMass = -1;

        public static bool NightVision = false;
        public static bool AnalysisMode = false;
        public static bool Interdiction = false;
        public static bool InDanger = false;
        public static bool HasLatLong = false;
        public static bool Overheating = false;
        public static bool LowFuel = false;
        public static bool SRV_DriveAssist = false;
        public static bool SRV_NearMothership = false;
        public static bool SRV_Turret = false;
        public static bool SRV_Handbreak = false;
        public static bool FuelScooping = false;
        public static bool SilentRunning = false;
        public static bool CargoScoop = false;
        public static bool Lights = false;
        public static bool InWing = false;
        public static bool Hardpoints = false;
        public static bool FlightAssist = false;
        public static bool Supercruise = false;
        public static bool Touchdown = false;
        public static bool LandingGear = false;
        public static bool ExternalLights = false;
        public static bool AltFromAvgRad = false;

        //Custom Variables                                  //Variable Control Source
        public static bool Hyperspace = false;              //StartJump Event
        public static bool FSSMode = false;                 //Music Event        
        public static bool ModeSurfScanner = false;         //Custom & Music Event
        public static bool WeaponSafety = false;            //Custom

        //Miscellaneous
        public static bool NPC_Crew = Convert.ToBoolean(Miscellanous.Default["NPC_Crew"]);
        public static bool LandingPreps = false;
    }

    public class FuelData
    {
        public decimal Main = -1;                      //Multi Source
        public decimal Reserve = -1;                   //Multi Source
        public decimal Capacity = -1;
        public decimal Reservior = -1;
        public bool Critical = false;                  //Custom Property
        public bool Low = false;                       //Status.json Property
        public bool HalfThreshold = false;             //Custom Property
    }
}