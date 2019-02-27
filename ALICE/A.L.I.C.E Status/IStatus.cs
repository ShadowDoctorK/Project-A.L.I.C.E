using System;
using ALICE.Properties;
using ALICE_Equipment;
using ALICE_Events;
using ALICE_Status;

namespace ALICE_Core
{
    public static class IStatus
    {
        private static Status_Cargo _Cargo = new Status_Cargo();
        public static Status_Cargo Cargo
        {
            get => _Cargo;
            set => _Cargo = value;
        }

        private static Status_Crew _Crew = new Status_Crew();
        public static Status_Crew Crew
        {
            get => _Crew;
            set => _Crew = value;
        }

        private static Status_Crime _Crime = new Status_Crime();
        public static Status_Crime Crime
        {
            get => _Crime;
            set => _Crime = value;
        }

        private static Status_Bounty _Bounty = new Status_Bounty();
        public static Status_Bounty Bounty
        {
            get => _Bounty;
            set => _Bounty = value;
        }

        private static Status_Docking _Docking = new Status_Docking();
        public static Status_Docking Docking
        {
            get => _Docking;
            set => _Docking = value;
        }

        private static Status_Fighter _Fighter = new Status_Fighter();
        public static Status_Fighter Fighter
        {
            get => _Fighter;
            set => _Fighter = value;
        }

        private static Status_Heat _Heat = new Status_Heat();
        public static Status_Heat Heat
        {
            get => _Heat;
            set => _Heat = value;
        }

        private static Status_Interaction _Interaction = new Status_Interaction();
        public static Status_Interaction Interaction
        {
            get => _Interaction;
            set => _Interaction = value;
        }

        private static Status_Materials _Materials = new Status_Materials();
        public static Status_Materials Materials
        {
            get => _Materials;
            set => _Materials = value;
        }

        private static Status_Messages _Messages = new Status_Messages();
        public static Status_Messages Messages
        {
            get => _Messages;
            set => _Messages = value;
        }

        private static Status_Music _Music = new Status_Music();
        public static Status_Music Music
        {
            get => _Music;
            set => _Music = value;
        }

        private static Status_Planet _Planet = new Status_Planet();
        public static Status_Planet Planet
        {
            get => _Planet;
            set => _Planet = value;
        }

        private static Status_Scan _Scan = new Status_Scan();
        public static Status_Scan Scan
        {
            get => _Scan;
            set => _Scan = value;
        }

        private static Status_Scanned _Scanned = new Status_Scanned();
        public static Status_Scanned Scanned
        {
            get => _Scanned;
            set => _Scanned = value;
        }

        private static Status_Shipyard _Shipyard = new Status_Shipyard();
        public static Status_Shipyard Shipyard
        {
            get => _Shipyard;
            set => _Shipyard = value;
        }

        private static Status_System _System = new Status_System();
        public static Status_System System
        {
            get => _System;
            set => _System = value;
        }

        public static bool Masslocked
        {
            get => IEvents.Masslock.I.Status;
            set => IEvents.Masslock.I.Status = value;
        }
        public static bool LandingGear
        {
            get => IEquipment.LandingGear.Status;
            set => IEquipment.LandingGear.Status = value;
        }

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
        public static bool Shields = false;
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