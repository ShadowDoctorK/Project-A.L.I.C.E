using System;
using ALICE.Properties;
using ALICE_Status;

namespace ALICE_Core
{
    public static class IStatus
    {
        public static Status_Cargo Cargo = new Status_Cargo();
        public static Status_Crew Crew = new Status_Crew();
        public static Status_Bounty Bounty = new Status_Bounty();
        public static Status_Docking Docking = new Status_Docking();
        public static Status_Fighter Fighter = new Status_Fighter();
        public static Status_Heat Heat = new Status_Heat();
        public static Status_Interaction Interaction = new Status_Interaction();
        public static Status_Materials Materials = new Status_Materials();
        public static Status_Messages Messages = new Status_Messages();
        public static Status_Music Music = new Status_Music();
        public static Status_Planet Planet = new Status_Planet();
        public static Status_Scan Scan = new Status_Scan();
        public static Status_Scanned Scanned = new Status_Scanned();
        public static Status_System System = new Status_System();

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
        public static bool Masslocked = false;
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
        public static bool Shields = false;
        public static bool LandingGear = false;
        public static bool Touchdown = false;

        //StartJump Event
        public static bool Hyperspace = false;

        //Music Event
        public static bool FSSMode = false;

        //Custom
        public static bool WeaponSafety = false;

        //Miscellaneous
        public static bool NPC_Crew = Convert.ToBoolean(Miscellanous.Default["NPC_Crew"]);
        public static bool LandingPreps = false;
    }
}