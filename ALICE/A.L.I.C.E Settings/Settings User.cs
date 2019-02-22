using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Settings
{
    /// <summary>
    /// This is a collection of the users settings from various parts of the Core Files.
    /// These settings are controlled completely by the user and have no source from the game.
    /// </summary>
    public class Settings_User
    {
        public DateTime TimeStamp { get; set; }

        public string Commander = "Default";

        #region Plugin
        //Speed Offsets
        public int OffsetPanels { get; set; }
        public int OffsetPips { get; set; }
        public int OffsetFireGroups { get; set; }
        public int OffsetThrottle { get; set; }

        //Keybinds
        public bool UsersBindFile { get; set; }
        public string BindsFile { get; set; }
        #endregion

        #region Orders
        public bool WeaponSafety { get; set; }
        public bool CombatPower { get; set; }
        public bool AssistSystemScan { get; set; }
        public bool AssistDocking { get; set; }
        public bool AssistRefuel { get; set; }
        public bool AssistRearm { get; set; }
        public bool AssistRepair { get; set; }
        public bool AssistHangerEntry { get; set; }
        public bool PostHyperspaceSafety { get; set; }
        #endregion

        #region Reports
        public bool FuelScoop { get; set; }
        public bool FuelStatus { get; set; }
        public bool MaterialCollected { get; set; }
        public bool MaterialRefined { get; set; }
        public bool NoFireZone { get; set; }
        public bool StationStatus { get; set; }
        public bool ShieldState { get; set; }
        public bool CollectedBounty { get; set; }
        public bool TargetEnemy { get; set; }
        public bool TargetWanted { get; set; }
        public bool Masslock { get; set; }
        public bool HighGravDescent { get; set; }
        public bool GlideStatus { get; set; }
        public bool ScanTravelDist { get; set; }
        public bool LandableVolcanism { get; set; }
        #endregion

        #region Exploration
        public int ScanDistLimit { get; set; }
        public bool BodyEarthLike { get; set; }
        public bool BodyWaterTerra { get; set; }
        public bool BodyHMCTerra { get; set; }
        public bool BodyAmmonia { get; set; }
        public bool BodyRockyTerra { get; set; }
        public bool BodyWater { get; set; }
        public bool BodyMetalRich { get; set; }
        public bool BodyGasGiantII { get; set; }
        public bool BodyHMC { get; set; }
        #endregion

        public Settings_User()
        {
            Commander = "Default";
            OffsetFireGroups = 0;
            OffsetPanels = 0;
            OffsetPips = 0;
            OffsetThrottle = 0;

            UsersBindFile = false;
            BindsFile = "A.L.I.C.E Profile.3.0.binds";

            WeaponSafety = true;
            CombatPower = true;
            AssistSystemScan = false;
            AssistDocking = false;
            AssistRefuel = false;
            AssistRearm = false;
            AssistRepair = false;
            AssistHangerEntry = false;
            PostHyperspaceSafety = true;

            FuelScoop = true;
            FuelStatus = true;
            MaterialCollected = true;
            MaterialRefined = true;
            NoFireZone = true;
            StationStatus = true;
            ShieldState = true;
            CollectedBounty = true;
            TargetEnemy = true;
            TargetWanted = true;
            Masslock = true;
            HighGravDescent = true;
            GlideStatus = true;
            ScanTravelDist = true;
            LandableVolcanism = true;

            ScanDistLimit = 0;
            BodyAmmonia = true;
            BodyEarthLike = true;
            BodyHMCTerra = true;
            BodyMetalRich = true;
            BodyRockyTerra = true;
            BodyWater = true;
            BodyWaterTerra = true;
            BodyGasGiantII = false;
            BodyHMC = false;
        }    
    }
}
