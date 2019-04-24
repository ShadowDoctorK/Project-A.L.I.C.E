using System;

namespace ALICE_Settings
{
    /// <summary>
    /// This is a collection of the users settings from various parts of the Core Files.
    /// These settings are controlled completely by the user and have no source from the game.
    /// </summary>
    public class Settings_User
    {
        public DateTime TimeStamp { get; set; }
        public string Commander { get; set; } = "Default";

        #region Plugin
        //Speed Offsets
        public int OffsetPanels { get; set; } = 0;
        public int OffsetPips { get; set; } = 0;
        public int OffsetFireGroups { get; set; } = 0;
        public int OffsetThrottle { get; set; } = 0;

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

        Settings_Events Events { get; set; } = new Settings_Events();

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

    public class Settings_Events
    {
        public bool Shipyard { get; set; }
        public bool Status { get; set; }

        //Shared Events                
        public bool Cargo { get; set; }
        public bool Market { get; set; }
        public bool Outfitting { get; set; }

        //Journal Log Events             
        public bool AfmuRepairs { get; set; }
        public bool ApproachBody { get; set; }
        public bool ApproachSettlement { get; set; }
        public bool AsteroidCracked { get; set; }
        public bool Bounty { get; set; }
        public bool BuyAmmo { get; set; }
        public bool BuyDrones { get; set; }
        public bool BuyExplorationData { get; set; }
        public bool BuyTradeData { get; set; }
        public bool CargoDepot { get; set; }
        public bool ChangeCrewRole { get; set; }
        public bool ClearSaveGame { get; set; }
        public bool CockpitBreached { get; set; }
        public bool CodexEntry { get; set; }
        public bool CollectCargo { get; set; }
        public bool Commander { get; set; }
        public bool CommitCrime { get; set; }
        public bool CommunityGoal { get; set; }
        public bool CrewAssign { get; set; }
        public bool CrewFire { get; set; }
        public bool CrewHire { get; set; }
        public bool DatalinkScan { get; set; }
        public bool DatalinkVoucher { get; set; }
        public bool DataScanned { get; set; }
        public bool Died { get; set; }
        public bool Docked { get; set; }
        public bool DockFighter { get; set; }
        public bool DockingCancelled { get; set; }
        public bool DockingGranted { get; set; }
        public bool DockingRequested { get; set; }
        public bool DockingTimeout { get; set; }
        public bool DockSRV { get; set; }
        public bool EjectCargo { get; set; }
        public bool EngineerContribution { get; set; }
        public bool EngineerCraft { get; set; }
        public bool EngineerProgress { get; set; }
        public bool EscapeInterdiction { get; set; }
        public bool FactionKillBond { get; set; }
        public bool FetchRemoteModule { get; set; }
        public bool FighterDestroyed { get; set; }
        public bool FighterRebuilt { get; set; }
        public bool Fileheader { get; set; }
        public bool Friends { get; set; }
        public bool FSDJump { get; set; }
        public bool FSDTarget { get; set; }
        public bool FSSAllBodiesFound { get; set; }
        public bool FSSDiscoveryScan { get; set; }
        public bool FSSSignalDiscovered { get; set; }
        public bool FuelScoop { get; set; }
        public bool HeatDamage { get; set; }
        public bool HeatWarning { get; set; }
        public bool HullDamage { get; set; }
        public bool Interdicted { get; set; }
        public bool JetConeBoost { get; set; }
        public bool LaunchDrone { get; set; }
        public bool LaunchFighter { get; set; }
        public bool LaunchSRV { get; set; }
        public bool LeaveBody { get; set; }
        public bool Liftoff { get; set; }
        public bool LoadGame { get; set; }
        public bool Loadout { get; set; }
        public bool Location { get; set; }
        public bool MarketBuy { get; set; }
        public bool MarketSell { get; set; }
        public bool MassModuleStore { get; set; }
        public bool MaterialCollected { get; set; }
        public bool MaterialDiscovered { get; set; }
        public bool Materials { get; set; }
        public bool MaterialTrade { get; set; }
        public bool MiningRefined { get; set; }
        public bool MissionAbandoned { get; set; }
        public bool MissionAccepted { get; set; }
        public bool MissionCompleted { get; set; }
        public bool MissionFailed { get; set; }
        public bool MissionRedirected { get; set; }
        public bool Missions { get; set; }
        public bool ModuleBuy { get; set; }
        public bool ModuleInfo { get; set; }
        public bool ModuleRetrieve { get; set; }
        public bool ModuleSell { get; set; }
        public bool ModuleSellRemote { get; set; }
        public bool ModuleStore { get; set; }
        public bool ModuleSwap { get; set; }
        public bool MultiSellExplorationData { get; set; }
        public bool Music { get; set; }
        public bool NavBeaconScan { get; set; }
        public bool NpcCrewPaidWage { get; set; }
        public bool NpcCrewRank { get; set; }
        public bool PayBounties { get; set; }
        public bool PayFines { get; set; }
        public bool Powerplay { get; set; }
        public bool PowerplayCollect { get; set; }
        public bool PowerplayDefect { get; set; }
        public bool PowerplayDeliver { get; set; }
        public bool PowerplayFastTrack { get; set; }
        public bool PowerplayJoin { get; set; }
        public bool PowerplayLeave { get; set; }
        public bool PowerplaySalary { get; set; }
        public bool PowerplayVote { get; set; }
        public bool Progress { get; set; }
        public bool Promotion { get; set; }
        public bool ProspectedAsteroid { get; set; }
        public bool QuitACrew { get; set; }
        public bool Rank { get; set; }
        public bool RebootRepair { get; set; }
        public bool ReceiveText { get; set; }
        public bool RedeemVoucher { get; set; }
        public bool RefuelAll { get; set; }
        public bool Repair { get; set; }
        public bool RepairAll { get; set; }
        public bool RepairDrone { get; set; }
        public bool Reputation { get; set; }
        public bool ReservoirReplenished { get; set; }
        public bool RestockVehicle { get; set; }
        public bool Resurrect { get; set; }
        public bool SAAScanComplete { get; set; }
        public bool Scan { get; set; }
        public bool Scanned { get; set; }
        public bool ScientificResearch { get; set; }
        public bool Screenshot { get; set; }
        public bool SearchAndRescue { get; set; }
        public bool SelfDestruct { get; set; }
        public bool SellDrones { get; set; }
        public bool SellExplorationData { get; set; }
        public bool SendText { get; set; }
        public bool SetUserShipName { get; set; }
        public bool ShieldState { get; set; }
        public bool ShipTargeted { get; set; }
        public bool ShipyardBuy { get; set; }
        public bool ShipyardNew { get; set; }
        public bool ShipyardSwap { get; set; }
        public bool ShipyardTransfer { get; set; }
        public bool Shutdown { get; set; }
        public bool SRVDestroyed { get; set; }
        public bool StartJump { get; set; }
        public bool Statistics { get; set; }
        public bool StoredModules { get; set; }
        public bool StoredShips { get; set; }
        public bool SupercruiseEntry { get; set; }
        public bool SupercruiseExit { get; set; }
        public bool Synthesis { get; set; }
        public bool SystemsShutdown { get; set; }
        public bool SquadronStartup { get; set; }
        public bool TechnologyBroker { get; set; }
        public bool Touchdown { get; set; }
        public bool UnderAttack { get; set; }
        public bool Undocked { get; set; }
        public bool USSDrop { get; set; }
        public bool VehicleSwitch { get; set; }
        public bool WingAdd { get; set; }
        public bool WingInvite { get; set; }
        public bool WingJoin { get; set; }
        public bool WingLeave { get; set; }

        //Custom Internal Events             
        public bool AliceOnline { get; set; }

        //Custom Event (Mulit Source)      
        public bool BlockAirlock { get; set; }
        public bool BlockLandingPad { get; set; }

        //Custom CommitCrime Events          
        public bool Assault { get; set; }
        public bool DisobeyPolice { get; set; }
        public bool DockingTrespass { get; set; }
        public bool DumpingDangerous { get; set; }
        public bool DumpingNearStation { get; set; }
        public bool FireInNoFireZone { get; set; }
        public bool FireInStation { get; set; }
        public bool IllegalCargo { get; set; }
        public bool Interdicting { get; set; }
        public bool Murder { get; set; }
        public bool Piracy { get; set; }
        public bool WrecklessFlying { get; set; }

        //Custom ReceiveText Events        
        public bool StationHostile { get; set; }
        public bool StationDamage { get; set; }
        public bool NoFireZone { get; set; }

        //Custom Status.Json Events        
        public bool FuelLow { get; set; }
        public bool FuelCritical { get; set; }
        public bool FuelHalfThreshold { get; set; }
        public bool Masslock { get; set; }
    }
}
