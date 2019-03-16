using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ALICE_Interface;
using ALICE_Internal;
using ALICE_Collections;

namespace ALICE_Events
{
    public static class IEvents
    {
        #region Old Collections
        //Most Current Processed Event
        public static Dictionary<string, object> Events = new Dictionary<string, object>();
        //Previously Stored Event
        public static Dictionary<string, object> PreviousEvents = new Dictionary<string, object>();
        #endregion

        /// <summary>
        /// Static Instatnce of the Event Type collection.
        /// </summary>
        public static CollectionEventTypes Types = new CollectionEventTypes();

        /// <summary>
        /// Statis Instance of the Events collection which contains all the processed Journal Log Events      
        /// </summary>
        public static CollectionEvents Event = new CollectionEvents();

        /// <summary>
        /// Enables / Disables the Variable Write feature for all Events.
        /// </summary>
        public static bool WriteVariables = true;

        /// <summary>
        /// Enables / Disables the Event Triggering feature for all Events.
        /// </summary>
        public static bool TriggerEvents = false;

        /// <summary>
        /// Tracks the Initial execution of the AliceOnline Event.
        /// </summary>
        public static bool ExecuteOnline = true;

        /// <summary>
        /// Simple Method To Update TriggerEvents & ExecuteOnline Properies
        /// once the initial Joural Read has processed.
        /// </summary>
        public static void Online()
        {
            TriggerEvents = true;
            ExecuteOnline = false;
        }

        public static void Process(IEnums.Events E)
        {
            string MethodName = "Logic (Process)";

            //Debug Logger
            Logger.DebugLine(MethodName, "Executing " + E, Logger.Blue);

            switch (E)
            {
                case IEnums.Events.Shipyard: Shipyard.Logic(); break;
                //case IEnums.Events.Status: Status.Logic(); break;
                case IEnums.Events.Cargo: Cargo.Logic(); break;
                case IEnums.Events.Market: Market.Logic(); break;
                case IEnums.Events.Outfitting: Outfitting.Logic(); break;
                case IEnums.Events.AfmuRepairs: AfmuRepairs.Logic(); break;
                case IEnums.Events.ApproachBody: ApproachBody.Logic(); break;
                case IEnums.Events.ApproachSettlement: ApproachSettlement.Logic(); break;
                case IEnums.Events.AsteroidCracked: AsteroidCracked.Logic(); break;
                case IEnums.Events.Bounty: Bounty.Logic(); break;
                case IEnums.Events.BuyAmmo: BuyAmmo.Logic(); break;
                case IEnums.Events.BuyDrones: BuyDrones.Logic(); break;
                case IEnums.Events.BuyExplorationData: BuyExplorationData.Logic(); break;
                case IEnums.Events.BuyTradeData: BuyTradeData.Logic(); break;
                case IEnums.Events.CargoDepot: CargoDepot.Logic(); break;
                case IEnums.Events.ChangeCrewRole: ChangeCrewRole.Logic(); break;
                case IEnums.Events.ClearSaveGame: ClearSaveGame.Logic(); break;
                case IEnums.Events.CockpitBreached: CockpitBreached.Logic(); break;
                case IEnums.Events.CodexEntry: CodexEntry.Logic(); break;
                case IEnums.Events.CollectCargo: CollectCargo.Logic(); break;
                case IEnums.Events.Commander: Commander.Logic(); break;
                case IEnums.Events.CommitCrime: CommitCrime.Logic(); break;
                case IEnums.Events.CommunityGoal: CommunityGoal.Logic(); break;
                case IEnums.Events.CrewAssign: CrewAssign.Logic(); break;
                case IEnums.Events.CrewFire: CrewFire.Logic(); break;
                case IEnums.Events.CrewHire: CrewHire.Logic(); break;
                case IEnums.Events.DatalinkScan: DatalinkScan.Logic(); break;
                case IEnums.Events.DatalinkVoucher: DatalinkVoucher.Logic(); break;
                case IEnums.Events.DataScanned: DataScanned.Logic(); break;
                case IEnums.Events.Died: Died.Logic(); break;
                case IEnums.Events.Docked: Docked.Logic(); break;
                case IEnums.Events.DockFighter: DockFighter.Logic(); break;
                case IEnums.Events.DockingCancelled: DockingCancelled.Logic(); break;
                case IEnums.Events.DockingGranted: DockingGranted.Logic(); break;
                case IEnums.Events.DockingRequested: DockingRequested.Logic(); break;
                case IEnums.Events.DockingTimeout: DockingTimeout.Logic(); break;
                case IEnums.Events.DockSRV: DockSRV.Logic(); break;
                case IEnums.Events.EjectCargo: EjectCargo.Logic(); break;
                case IEnums.Events.EngineerContribution: EngineerContribution.Logic(); break;
                case IEnums.Events.EngineerCraft: EngineerCraft.Logic(); break;
                case IEnums.Events.EngineerProgress: EngineerProgress.Logic(); break;
                case IEnums.Events.EscapeInterdiction: EscapeInterdiction.Logic(); break;
                case IEnums.Events.FactionKillBond: FactionKillBond.Logic(); break;
                case IEnums.Events.FetchRemoteModule: FetchRemoteModule.Logic(); break;
                case IEnums.Events.FighterDestroyed: FighterDestroyed.Logic(); break;
                case IEnums.Events.FighterRebuilt: FighterRebuilt.Logic(); break;
                case IEnums.Events.Fileheader: Fileheader.Logic(); break;
                case IEnums.Events.Friends: Friends.Logic(); break;
                case IEnums.Events.FSDJump: FSDJump.Logic(); break;
                case IEnums.Events.FSDTarget: FSDTarget.Logic(); break;
                case IEnums.Events.FSSAllBodiesFound: FSSAllBodiesFound.Logic(); break;
                case IEnums.Events.FSSDiscoveryScan: FSSDiscoveryScan.Logic(); break;
                case IEnums.Events.FSSSignalDiscovered: FSSSignalDiscovered.Logic(); break;
                case IEnums.Events.FuelScoop: FuelScoop.Logic(); break;
                case IEnums.Events.HeatDamage: HeatDamage.Logic(); break;
                case IEnums.Events.HeatWarning: HeatWarning.Logic(); break;
                case IEnums.Events.HullDamage: HullDamage.Logic(); break;
                case IEnums.Events.Interdicted: Interdicted.Logic(); break;
                case IEnums.Events.JetConeBoost: JetConeBoost.Logic(); break;
                case IEnums.Events.LaunchDrone: LaunchDrone.Logic(); break;
                case IEnums.Events.LaunchFighter: LaunchFighter.Logic(); break;
                case IEnums.Events.LaunchSRV: LaunchSRV.Logic(); break;
                case IEnums.Events.LeaveBody: LeaveBody.Logic(); break;
                case IEnums.Events.Liftoff: Liftoff.Logic(); break;
                case IEnums.Events.LoadGame: LoadGame.Logic(); break;
                case IEnums.Events.Loadout: Loadout.Logic(); break;
                case IEnums.Events.Location: Location.Logic(); break;
                case IEnums.Events.MarketBuy: MarketBuy.Logic(); break;
                case IEnums.Events.MarketSell: MarketSell.Logic(); break;
                case IEnums.Events.MassModuleStore: MassModuleStore.Logic(); break;
                case IEnums.Events.MaterialCollected: MaterialCollected.Logic(); break;
                case IEnums.Events.MaterialDiscovered: MaterialDiscovered.Logic(); break;
                case IEnums.Events.Materials: Materials.Logic(); break;
                case IEnums.Events.MaterialTrade: MaterialTrade.Logic(); break;
                case IEnums.Events.MiningRefined: MiningRefined.Logic(); break;
                case IEnums.Events.MissionAbandoned: MissionAbandoned.Logic(); break;
                case IEnums.Events.MissionAccepted: MissionAccepted.Logic(); break;
                case IEnums.Events.MissionCompleted: MissionCompleted.Logic(); break;
                case IEnums.Events.MissionFailed: MissionFailed.Logic(); break;
                case IEnums.Events.MissionRedirected: MissionRedirected.Logic(); break;
                case IEnums.Events.Missions: Missions.Logic(); break;
                case IEnums.Events.ModuleBuy: ModuleBuy.Logic(); break;
                case IEnums.Events.ModuleInfo: ModuleInfo.Logic(); break;
                case IEnums.Events.ModuleRetrieve: ModuleRetrieve.Logic(); break;
                case IEnums.Events.ModuleSell: ModuleSell.Logic(); break;
                case IEnums.Events.ModuleSellRemote: ModuleSellRemote.Logic(); break;
                case IEnums.Events.ModuleStore: ModuleStore.Logic(); break;
                case IEnums.Events.ModuleSwap: ModuleSwap.Logic(); break;
                case IEnums.Events.MultiSellExplorationData: MultiSellExplorationData.Logic(); break;
                case IEnums.Events.Music: Music.Logic(); break;
                case IEnums.Events.NavBeaconScan: NavBeaconScan.Logic(); break;
                case IEnums.Events.NpcCrewPaidWage: NpcCrewPaidWage.Logic(); break;
                case IEnums.Events.NpcCrewRank: NpcCrewRank.Logic(); break;
                case IEnums.Events.PayBounties: PayBounties.Logic(); break;
                case IEnums.Events.PayFines: PayFines.Logic(); break;
                case IEnums.Events.Powerplay: Powerplay.Logic(); break;
                case IEnums.Events.PowerplayCollect: PowerplayCollect.Logic(); break;
                case IEnums.Events.PowerplayDefect: PowerplayDefect.Logic(); break;
                case IEnums.Events.PowerplayDeliver: PowerplayDeliver.Logic(); break;
                case IEnums.Events.PowerplayFastTrack: PowerplayFastTrack.Logic(); break;
                case IEnums.Events.PowerplayJoin: PowerplayJoin.Logic(); break;
                case IEnums.Events.PowerplayLeave: PowerplayLeave.Logic(); break;
                case IEnums.Events.PowerplaySalary: PowerplaySalary.Logic(); break;
                case IEnums.Events.PowerplayVote: PowerplayVote.Logic(); break;
                case IEnums.Events.Progress: Progress.Logic(); break;
                case IEnums.Events.Promotion: Promotion.Logic(); break;
                case IEnums.Events.ProspectedAsteroid: ProspectedAsteroid.Logic(); break;
                case IEnums.Events.QuitACrew: QuitACrew.Logic(); break;
                case IEnums.Events.Rank: Rank.Logic(); break;
                case IEnums.Events.RebootRepair: RebootRepair.Logic(); break;
                case IEnums.Events.ReceiveText: ReceiveText.Logic(); break;
                case IEnums.Events.RedeemVoucher: RedeemVoucher.Logic(); break;
                case IEnums.Events.RefuelAll: RefuelAll.Logic(); break;
                case IEnums.Events.Repair: Repair.Logic(); break;
                case IEnums.Events.RepairAll: RepairAll.Logic(); break;
                case IEnums.Events.RepairDrone: RepairDrone.Logic(); break;
                case IEnums.Events.Reputation: Reputation.Logic(); break;
                case IEnums.Events.ReservoirReplenished: ReservoirReplenished.Logic(); break;
                case IEnums.Events.RestockVehicle: RestockVehicle.Logic(); break;
                case IEnums.Events.Resurrect: Resurrect.Logic(); break;
                case IEnums.Events.SAAScanComplete: SAAScanComplete.Logic(); break;
                case IEnums.Events.Scan: Scan.Logic(); break;
                case IEnums.Events.Scanned: Scanned.Logic(); break;
                case IEnums.Events.ScientificResearch: ScientificResearch.Logic(); break;
                case IEnums.Events.Screenshot: Screenshot.Logic(); break;
                case IEnums.Events.SearchAndRescue: SearchAndRescue.Logic(); break;
                case IEnums.Events.SelfDestruct: SelfDestruct.Logic(); break;
                case IEnums.Events.SellDrones: SellDrones.Logic(); break;
                case IEnums.Events.SellExplorationData: SellExplorationData.Logic(); break;
                case IEnums.Events.SendText: SendText.Logic(); break;
                case IEnums.Events.SetUserShipName: SetUserShipName.Logic(); break;
                case IEnums.Events.ShieldState: ShieldState.Logic(); break;
                case IEnums.Events.ShipTargeted: ShipTargeted.Logic(); break;
                case IEnums.Events.ShipyardBuy: ShipyardBuy.Logic(); break;
                case IEnums.Events.ShipyardNew: ShipyardNew.Logic(); break;
                case IEnums.Events.ShipyardSwap: ShipyardSwap.Logic(); break;
                case IEnums.Events.ShipyardTransfer: ShipyardTransfer.Logic(); break;
                case IEnums.Events.Shutdown: Shutdown.Logic(); break;
                case IEnums.Events.SRVDestroyed: SRVDestroyed.Logic(); break;
                case IEnums.Events.StartJump: StartJump.Logic(); break;
                case IEnums.Events.Statistics: Statistics.Logic(); break;
                case IEnums.Events.StoredModules: StoredModules.Logic(); break;
                case IEnums.Events.StoredShips: StoredShips.Logic(); break;
                case IEnums.Events.SupercruiseEntry: SupercruiseEntry.Logic(); break;
                case IEnums.Events.SupercruiseExit: SupercruiseExit.Logic(); break;
                case IEnums.Events.Synthesis: Synthesis.Logic(); break;
                case IEnums.Events.SystemsShutdown: SystemsShutdown.Logic(); break;
                case IEnums.Events.SquadronStartup: SquadronStartup.Logic(); break;
                case IEnums.Events.TechnologyBroker: TechnologyBroker.Logic(); break;
                case IEnums.Events.Touchdown: Touchdown.Logic(); break;
                case IEnums.Events.UnderAttack: UnderAttack.Logic(); break;
                case IEnums.Events.Undocked: Undocked.Logic(); break;
                case IEnums.Events.USSDrop: USSDrop.Logic(); break;
                case IEnums.Events.VehicleSwitch: VehicleSwitch.Logic(); break;
                case IEnums.Events.WingAdd: WingAdd.Logic(); break;
                case IEnums.Events.WingInvite: WingInvite.Logic(); break;
                case IEnums.Events.WingJoin: WingJoin.Logic(); break;
                case IEnums.Events.WingLeave: WingLeave.Logic(); break;

                default:
                    break;
            }
        }

        #region Custom Events

        #region A
        public static Event_AliceOnline AliceOnline = new Event_AliceOnline();
        public static Event_Assault Assault = new Event_Assault();
        #endregion

        #region B
        public static Event_BlockAirlock BlockAirlock = new Event_BlockAirlock();
        public static Event_BlockLandingPad BlockLandingPad = new Event_BlockLandingPad();       
        #endregion

        #region D
        public static Event_DisobeyPolice DisobeyPolice = new Event_DisobeyPolice();
        public static Event_DumpingDangerous DumpingDangerous = new Event_DumpingDangerous();
        public static Event_DumpingNearStation DumpingNearStation = new Event_DumpingNearStation();
        #endregion

        #region F
        public static Event_FireInNoFireZone FireInNoFireZone = new Event_FireInNoFireZone();
        public static Event_FireInStation FireInStation = new Event_FireInStation();
        public static Event_FuelCritical FuelCritical = new Event_FuelCritical();
        public static Event_FuelHalfThreshold FuelHalfThreshold = new Event_FuelHalfThreshold();
        public static Event_FuelLow FuelLow = new Event_FuelLow();
        #endregion

        #region I
        public static Event_IllegalCargo IllegalCargo = new Event_IllegalCargo();
        public static Event_Interdicting Interdicting = new Event_Interdicting();
        #endregion

        #region M
        public static Event_Murder Murder = new Event_Murder();
        #endregion

        #region N
        public static Event_NoFireZone NoFireZone = new Event_NoFireZone();
        #endregion

        #region P
        public static Event_Piracy Piracy = new Event_Piracy();
        #endregion

        #region S
        public static Event_ShipyardArrived ShipyardArrived = new Event_ShipyardArrived();
        public static Event_StationDamage StationDamage = new Event_StationDamage();
        public static Event_StationHostile StationHostile = new Event_StationHostile();
        #endregion

        #region T
        public static Event_TrespassMajor TrespassMajor = new Event_TrespassMajor();
        public static Event_TrespassMinor TrespassMinor = new Event_TrespassMinor();
        #endregion

        #region W
        public static Event_WrecklessFlying WrecklessFlying = new Event_WrecklessFlying();
        public static Event_WrecklessFlyingDamage WrecklessFlyingDamage = new Event_WrecklessFlyingDamage();
        #endregion

        //End Region: Custom Events
        #endregion

        #region Journal Events

        #region A
        public static Event_AfmuRepairs AfmuRepairs = new Event_AfmuRepairs();
        public static Event_ApproachBody ApproachBody = new Event_ApproachBody();
        public static Event_ApproachSettlement ApproachSettlement = new Event_ApproachSettlement();
        public static Event_AsteroidCracked AsteroidCracked = new Event_AsteroidCracked();
        #endregion

        #region B
        public static Event_Bounty Bounty = new Event_Bounty();
        public static Event_BuyAmmo BuyAmmo = new Event_BuyAmmo();
        public static Event_BuyDrones BuyDrones = new Event_BuyDrones();
        public static Event_BuyExplorationData BuyExplorationData = new Event_BuyExplorationData();
        public static Event_BuyTradeData BuyTradeData = new Event_BuyTradeData();
        #endregion

        #region C
        public static Event_Cargo Cargo = new Event_Cargo();
        public static Event_CargoDepot CargoDepot = new Event_CargoDepot();
        public static Event_ChangeCrewRole ChangeCrewRole = new Event_ChangeCrewRole();
        public static Event_ClearSaveGame ClearSaveGame = new Event_ClearSaveGame();
        public static Event_CockpitBreached CockpitBreached = new Event_CockpitBreached();
        public static Event_CodexEntry CodexEntry = new Event_CodexEntry();
        public static Event_CollectCargo CollectCargo = new Event_CollectCargo();
        public static Event_Commander Commander = new Event_Commander();
        public static Event_CommitCrime CommitCrime = new Event_CommitCrime();
        public static Event_CommunityGoal CommunityGoal = new Event_CommunityGoal();
        public static Event_CrewAssign CrewAssign = new Event_CrewAssign();
        public static Event_CrewFire CrewFire = new Event_CrewFire();
        public static Event_CrewHire CrewHire = new Event_CrewHire();
        #endregion

        #region D
        public static Event_DatalinkScan DatalinkScan = new Event_DatalinkScan();
        public static Event_DataScanned DataScanned = new Event_DataScanned();
        public static Event_DatalinkVoucher DatalinkVoucher = new Event_DatalinkVoucher();
        public static Event_Died Died = new Event_Died();        
        public static Event_Docked Docked = new Event_Docked();
        public static Event_DockFighter DockFighter = new Event_DockFighter();
        public static Event_DockingCancelled DockingCancelled = new Event_DockingCancelled();
        public static Event_DockingTimeout DockingTimeout = new Event_DockingTimeout();
        public static Event_DockingDenied DockingDenied = new Event_DockingDenied();
        public static Event_DockingGranted DockingGranted = new Event_DockingGranted();
        public static Event_DockingRequested DockingRequested = new Event_DockingRequested();
        public static Event_DockSRV DockSRV = new Event_DockSRV();
        #endregion

        #region E
        public static Event_EjectCargo EjectCargo = new Event_EjectCargo();
        public static Event_EscapeInterdiction EscapeInterdiction = new Event_EscapeInterdiction();
        public static Event_EngineerContribution EngineerContribution = new Event_EngineerContribution();
        public static Event_EngineerCraft EngineerCraft = new Event_EngineerCraft();
        public static Event_EngineerProgress EngineerProgress = new Event_EngineerProgress();
        #endregion

        #region F
        public static Event_FactionKillBond FactionKillBond = new Event_FactionKillBond();
        public static Event_FighterDestroyed FighterDestroyed = new Event_FighterDestroyed();
        public static Event_FighterRebuilt FighterRebuilt = new Event_FighterRebuilt();
        public static Event_Fileheader Fileheader = new Event_Fileheader();
        public static Event_Friends Friends = new Event_Friends();
        public static Event_FSDJump FSDJump = new Event_FSDJump();
        public static Event_FSDTarget FSDTarget = new Event_FSDTarget();
        public static Event_FSSAllBodiesFound FSSAllBodiesFound = new Event_FSSAllBodiesFound();
        public static Event_FSSDiscoveryScan FSSDiscoveryScan = new Event_FSSDiscoveryScan();
        public static Event_FSSSignalDiscovered FSSSignalDiscovered = new Event_FSSSignalDiscovered();
        public static Event_FuelScoop FuelScoop = new Event_FuelScoop();
        public static Event_FetchRemoteModule FetchRemoteModule = new Event_FetchRemoteModule();
        #endregion

        #region G
        #endregion

        #region H
        public static Event_HeatDamage HeatDamage = new Event_HeatDamage();
        public static Event_HeatWarning HeatWarning = new Event_HeatWarning();
        public static Event_HullDamage HullDamage = new Event_HullDamage();
        #endregion

        #region I
        public static Event_Interdicted Interdicted = new Event_Interdicted();
        #endregion

        #region J
        public static Event_JetConeBoost JetConeBoost = new Event_JetConeBoost();
        #endregion

        #region K
        #endregion

        #region L
        public static Event_LaunchDrone LaunchDrone = new Event_LaunchDrone();
        public static Event_LaunchFighter LaunchFighter = new Event_LaunchFighter();
        public static Event_LaunchSRV LaunchSRV = new Event_LaunchSRV();
        public static Event_LeaveBody LeaveBody = new Event_LeaveBody();
        public static Event_Liftoff Liftoff = new Event_Liftoff();
        public static Event_LoadGame LoadGame = new Event_LoadGame();
        public static Event_Loadout Loadout = new Event_Loadout();
        public static Event_Location Location = new Event_Location();
        #endregion

        #region M
        public static Event_Market Market = new Event_Market();
        public static Event_MarketBuy MarketBuy = new Event_MarketBuy();
        public static Event_MarketSell MarketSell = new Event_MarketSell();
        public static Event_MassModuleStore MassModuleStore = new Event_MassModuleStore();
        public static Event_MaterialCollected MaterialCollected = new Event_MaterialCollected();
        public static Event_MaterialDiscovered MaterialDiscovered = new Event_MaterialDiscovered();
        public static Event_Materials Materials = new Event_Materials();
        public static Event_MaterialTrade MaterialTrade = new Event_MaterialTrade();
        public static Event_MiningRefined MiningRefined = new Event_MiningRefined();
        public static Event_MissionAbandoned MissionAbandoned = new Event_MissionAbandoned();
        public static Event_MissionAccepted MissionAccepted = new Event_MissionAccepted();
        public static Event_MissionCompleted MissionCompleted = new Event_MissionCompleted();
        public static Event_MissionFailed MissionFailed = new Event_MissionFailed();
        public static Event_MissionRedirected MissionRedirected = new Event_MissionRedirected();
        public static Event_Missions Missions = new Event_Missions();
        public static Event_ModuleBuy ModuleBuy = new Event_ModuleBuy();
        public static Event_ModuleInfo ModuleInfo = new Event_ModuleInfo();
        public static Event_ModuleRetrieve ModuleRetrieve = new Event_ModuleRetrieve();
        public static Event_ModuleSell ModuleSell = new Event_ModuleSell();
        public static Event_ModuleSellRemote ModuleSellRemote = new Event_ModuleSellRemote();
        public static Event_ModuleStore ModuleStore = new Event_ModuleStore();
        public static Event_ModuleSwap ModuleSwap = new Event_ModuleSwap();
        public static Event_MultiSellExplorationData MultiSellExplorationData = new Event_MultiSellExplorationData();
        public static Event_Music Music = new Event_Music();
        #endregion

        #region N
        public static Event_NavBeaconScan NavBeaconScan = new Event_NavBeaconScan();
        public static Event_NpcCrewPaidWage NpcCrewPaidWage = new Event_NpcCrewPaidWage();
        public static Event_NpcCrewRank NpcCrewRank = new Event_NpcCrewRank();
        #endregion

        #region O
        public static Event_Outfitting Outfitting = new Event_Outfitting();
        #endregion

        #region P
        public static Event_PayBounties PayBounties = new Event_PayBounties();
        public static Event_PayFines PayFines = new Event_PayFines();
        public static Event_Powerplay Powerplay = new Event_Powerplay();
        public static Event_PowerplayCollect PowerplayCollect = new Event_PowerplayCollect();
        public static Event_PowerplayDeliver PowerplayDeliver = new Event_PowerplayDeliver();
        public static Event_PowerplayFastTrack PowerplayFastTrack = new Event_PowerplayFastTrack();
        public static Event_PowerplaySalary PowerplaySalary = new Event_PowerplaySalary();
        public static Event_PowerplayDefect PowerplayDefect = new Event_PowerplayDefect();
        public static Event_PowerplayJoin PowerplayJoin = new Event_PowerplayJoin();
        public static Event_PowerplayLeave PowerplayLeave = new Event_PowerplayLeave();
        public static Event_PowerplayVote PowerplayVote = new Event_PowerplayVote();
        public static Event_Progress Progress = new Event_Progress();
        public static Event_Promotion Promotion = new Event_Promotion();
        public static Event_ProspectedAsteroid ProspectedAsteroid = new Event_ProspectedAsteroid();
        #endregion

        #region Q
        public static Event_QuitACrew QuitACrew = new Event_QuitACrew();
        #endregion

        #region R
        public static Event_Rank Rank = new Event_Rank();
        public static Event_RebootRepair RebootRepair = new Event_RebootRepair();
        public static Event_ReceiveText ReceiveText = new Event_ReceiveText();
        public static Event_RedeemVoucher RedeemVoucher = new Event_RedeemVoucher();
        public static Event_RefuelAll RefuelAll = new Event_RefuelAll();
        public static Event_Repair Repair = new Event_Repair();
        public static Event_RepairAll RepairAll = new Event_RepairAll();
        public static Event_RepairDrone RepairDrone = new Event_RepairDrone();
        public static Event_Reputation Reputation = new Event_Reputation();
        public static Event_ReservoirReplenished ReservoirReplenished = new Event_ReservoirReplenished();
        public static Event_RestockVehicle RestockVehicle = new Event_RestockVehicle();
        public static Event_Resurrect Resurrect = new Event_Resurrect();
        #endregion

        #region S
        public static Event_SAAScanComplete SAAScanComplete = new Event_SAAScanComplete();
        public static Event_Scan Scan = new Event_Scan();
        public static Event_Scanned Scanned = new Event_Scanned();
        public static Event_Screenshot Screenshot = new Event_Screenshot();
        public static Event_SellDrones SellDrones = new Event_SellDrones();
        public static Event_SellExplorationData SellExplorationData = new Event_SellExplorationData();
        public static Event_SendText SendText = new Event_SendText();
        public static Event_SetUserShipName SetUserShipName = new Event_SetUserShipName();
        public static Event_ShieldState ShieldState = new Event_ShieldState();
        public static Event_ShipTargeted ShipTargeted = new Event_ShipTargeted();
        public static Event_Shipyard Shipyard = new Event_Shipyard();
        public static Event_ShipyardBuy ShipyardBuy = new Event_ShipyardBuy();
        public static Event_ShipyardNew ShipyardNew = new Event_ShipyardNew();
        public static Event_ShipyardSwap ShipyardSwap = new Event_ShipyardSwap();
        public static Event_ShipyardTransfer ShipyardTransfer = new Event_ShipyardTransfer();
        public static Event_Shutdown Shutdown = new Event_Shutdown();
        public static Event_StartJump StartJump = new Event_StartJump();
        public static Event_Statistics Statistics = new Event_Statistics();
        public static Event_StoredModules StoredModules = new Event_StoredModules();
        public static Event_StoredShips StoredShips = new Event_StoredShips();
        public static Event_SupercruiseEntry SupercruiseEntry = new Event_SupercruiseEntry();
        public static Event_SupercruiseExit SupercruiseExit = new Event_SupercruiseExit();
        public static Event_Synthesis Synthesis = new Event_Synthesis();
        public static Event_SystemsShutdown SystemsShutdown = new Event_SystemsShutdown();
        public static Event_ScientificResearch ScientificResearch = new Event_ScientificResearch();
        public static Event_SearchAndRescue SearchAndRescue = new Event_SearchAndRescue();
        public static Event_SelfDestruct SelfDestruct = new Event_SelfDestruct();
        public static Event_SRVDestroyed SRVDestroyed = new Event_SRVDestroyed();
        public static Event_SquadronStartup SquadronStartup = new Event_SquadronStartup();
        #endregion

        #region T
        public static Event_TechnologyBroker TechnologyBroker = new Event_TechnologyBroker();
        public static Event_Touchdown Touchdown = new Event_Touchdown();
        #endregion

        #region U
        public static Event_UnderAttack UnderAttack = new Event_UnderAttack();
        public static Event_Undocked Undocked = new Event_Undocked();
        public static Event_USSDrop USSDrop = new Event_USSDrop();        
        #endregion

        #region V
        public static Event_VehicleSwitch VehicleSwitch = new Event_VehicleSwitch();
        #endregion

        #region W
        public static Event_WingAdd WingAdd = new Event_WingAdd();
        public static Event_WingInvite WingInvite = new Event_WingInvite();
        public static Event_WingJoin WingJoin = new Event_WingJoin();
        public static Event_WingLeave WingLeave = new Event_WingLeave();
        #endregion

        #region X
        #endregion

        #region Y
        #endregion

        #region Z
        #endregion

        //End Region: Events
        #endregion

        //Old Items To Remove After Conversion


        #region Json Events
        public static Event_Masslock Masslock = new Event_Masslock();
        #endregion

        #region Methods / Functions
        public static void UpdateEvents(string EventName, object Event)
        {
            if (Events.ContainsKey(EventName) == false)
            {
                Events.Add(EventName, Event);
            }
            else
            {
                var Temp = Events[EventName];
                PreviousEvents[EventName] = Temp;
                Events[EventName] = Event;
            }
        }

        public static bool EventExist(string EventName, bool Answer = false)
        {
            string MethodName = "Event Manager (Event Exist)";

            string DebugText = "Event Exist Check Failed, " + EventName + " Has Not Been Recorded.";
            string Color = Logger.Yellow;

            if (IEvents.Events.ContainsKey(EventName) == true)
            { Answer = true; }

            if (Answer == false)
            { Logger.DebugLine(MethodName, DebugText, Color); }

            return Answer;
        }

        public static object GetEvent(string EventName)
        {
            object Temp = null;

            if (EventExist(EventName))
            {
                Temp = Events[EventName];
            }

            return Temp;
        }
        #endregion

        #region Extension Methods
        public static string Variable(this decimal Dec)
        {            
            return Dec.ToString();
        }

        public static string Variable(this string Str)
        {
            if (Str == null)
            { return "None"; }

            return Str;
        }

        public static string Variable(this bool Bol)
        {
            return Bol.ToString();
        }

        public static string Variable(this DateTime time)
        {
            if (time != null)
            { return time.ToString(); }

            return null;
        }
        #endregion
    }

    public class Event
    {
        /// <summary>
        /// Custom Collection with all the controls to handle variable tracking and generation per Event.
        /// </summary>
        public CollectionVariables Variables = new CollectionVariables();

        /// <summary>
        /// Name Property for each event as an Enum.
        /// </summary>
        public IEnums.Events Name
        {
            get
            {                
                //Format & Convert
                string Name = this.GetType().Name.Replace("Event_", "");

                //Process Event Type & Return Enum Name
                try { return IEnums.ToEnum<IEnums.Events>(Name); }

                //Exception Handling
                catch (Exception ex)
                {
                    //Exception Logger
                    Logger.Exception("Event (Name)", "Exception: " + ex);
                    Logger.Exception("Event (Name)", "Exception Occured While Processing " + Name + " Event");

                    //Default Return
                    return IEnums.Events.None;                    
                }
            }
        }

        /// <summary>
        /// Simple String call for the class name.
        /// </summary>
        public string ClassName => Name.ToString();

        /// <summary>
        /// Enables / Disables event triggering on the event level.
        /// </summary>
        public bool TriggerEvent = true;

        /// <summary>
        /// Enables / Disables writing variables on the event level.
        /// </summary>
        public bool WriteVariables = true;

        /// <summary>
        /// Validates Triggers Are Enabled & Triggers Events
        /// </summary>
        public void Trigger()
        {
            string MethodName = "Trigger (" + Name + ")";

            //Debug Logger
            Logger.DebugLine(MethodName, "Evaluating Event Triggers", Logger.Blue);

            //Check Main Trigger Control
            if (IEvents.TriggerEvents == false)
            {
                //Debug Logger
                Logger.DebugLine(MethodName, "Global Event Triggers Disabled.", Logger.Yellow);

                return;
            }

            //Check Event Trigger Control
            if (TriggerEvent == false)
            {
                //Debug Logger
                Logger.DebugLine(MethodName, "Local Event Triggers Disabled.", Logger.Yellow);

                return;
            }

            //Debug Logger
            Logger.DebugLine(MethodName, "Executing Event Trigger", Logger.Blue);

            //Execute Event
            IPlatform.ExecuteCommand("EVENT - " + Name);

            //Log Event Execution For Game Tracking Purposes.
            Logger.AliceLog("Event: " + Name);
        }

        /// <summary>
        /// Checks If The Target Event Exists
        /// </summary>
        /// <param name="E">(Event Name) Target Event</param>
        /// <returns>True or False</returns>
        public bool Exist(IEnums.Events E)
        {
            string MethodName = "Event Manager (Event Exist)";
            
            switch (IEvents.Event.Exist(E))
            {                
                case IEnums.A.Postive:
                    return true;

                case IEnums.A.Negative:
                    return false;

                case IEnums.A.Error:
                    return false;

                default:

                    //Error Logger
                    Logger.Error(MethodName, "Returned Using Default Swtich, Returning False", Logger.Red);
                    return false;
            }
        }

        /// <summary>
        /// Will Get the calling class' event from the dictionary if it exists.
        /// </summary>
        /// <returns>Event Object, or Null if doesn't exist.</returns>
        public object Get()
        {
            //Return Event or Null
            return IEvents.Event.Get(Name);            
        }

        /// <summary>
        /// Will Get the target event from the dictionary if it exists.
        /// </summary>
        /// <returns>Event Object, or Null if doesn't exist.</returns>
        public object Get(IEnums.Events E)
        {
            //Return Event or Null
            return IEvents.Event.Get(E);
        }

        /// <summary>
        /// Will Record the passed Event to the Event Storage
        /// </summary>
        /// <param name="E">(Event Name) Target Event's Name</param>
        /// <param name="O">(Object) Event's Object</param>
        public void Record(IEnums.Events E, object O)
        {
            //Pass Event To Collections Record Method
            IEvents.Event.Record(E, O);
        }

        /// <summary>
        /// Method Used To Generate The Event Variables
        /// </summary>
        public virtual void Generate(object O)
        {
            //No Code In Virtual Method, Override Method Will Contain The Logic
            //This Is Here For The Structured Calls
        }

        /// <summary>
        /// Method Used To Process Plugin Functions Based On Event Data.
        /// </summary>
        public virtual void Process(object O)
        {
            //No Code In Virtual Method, Override Method Will Contain The Logic
            //This Is Here For The Structured Calls
        }

        /// <summary>
        /// Method Used To Align Plugin States To Known True Values Based On Event Execution.
        /// </summary>
        public virtual void Alignment(object O)
        {
            //No Code In Virtual Method, Override Method Will Contain The Logic
            //This Is Here For The Structured Calls
        }

        /// <summary>
        /// Method Used To Align Plugin States To Known True Values Prior To Executing The Logic Process.
        /// </summary>
        public virtual void Prepare(object O)
        {
            //No Code In Virtual Method, Override Method Will Contain The Logic
            //This Is Here For The Structured Calls
        }

        /// <summary>
        /// Method Use To Update Game State Logic Per Event
        /// </summary>
        public void Logic()
        {
            //Get Recorded Event
            object Event = Get();

            //Prepare For Event Logic
            Prepare(Event);

            //Process Event Logic
            Process(Event);

            //Plugin Alignment
            Alignment(Event);

            //Process Variables
            if (WriteVariables)
            {
                Variables.Clear();
                Generate(Event);
                Variables.Write();
            }

            //Trigger
            Trigger();
        }

        public void ExceptionAlignment(IEnums.Events E, Exception ex)
        {
            Logger.Exception(E.ToString(), "Exception: " + ex);
            Logger.Exception(E.ToString(), "An Exception Occured While Aligning Post Event Properties");
        }

        public void ExceptionConstruct(IEnums.Events E, Exception ex)
        {
            Logger.Exception(E.ToString(), "Exception: " + ex);
            Logger.Exception(E.ToString(), "An Exception Occured While Custom Events");
        }

        public void ExceptionGenerate(IEnums.Events E, Exception ex)
        {
            Logger.Exception(E.ToString(), "Exception: " + ex);
            Logger.Exception(E.ToString(), "An Exception Occured While Generating Variables");
        }

        public void ExceptionPrepare(IEnums.Events E, Exception ex)
        {
            Logger.Exception(E.ToString(), "Exception: " + ex);
            Logger.Exception(E.ToString(), "An Exception Occured While Preparing For The Event");
        }

        public void ExceptionProcess(IEnums.Events E, Exception ex)
        {
            Logger.Exception(E.ToString(), "Exception: " + ex);
            Logger.Exception(E.ToString(), "An Exception Occured While Processing The Event");
        }

        /// <summary>
        /// Support Function To Format Ship Slots
        /// </summary>
        /// <param name="SlotName">Ship Slot To Be Processed</param>
        /// <param name="Dash">Enable Disable The "_" During Formatting</param>
        /// <returns>Formatted Slot</returns>
        public string GetSlot(string SlotName, bool Dash = true)
        {
            string Underscore = "";
            if (Dash) { Underscore = "_"; }

            //Remove All Slot Variations
            int i = 10; while (i != 0)
            {
                SlotName = SlotName.Replace("_Size" + i, ""); i--;
            }

            //Return Formmated Slot Name
            return Underscore + SlotName;
        }

        /// <summary>
        /// Atempts to cast objects to the passed type.
        /// </summary>
        /// <typeparam name="T">(Type) Object Type</typeparam>
        /// <param name="O">(Object) The Data</param>
        /// <returns>Casted Object or Default on Exception</returns>
        public T Caster<T>(object O)
        {                        
            try
            {
                return (T)O;
            }
            catch (Exception ex)
            {
                Logger.Exception(ClassName, "Exception: " + ex);
            }

            return default(T);
        }
    }

    public class Base : Catch
    {
        /// <summary>
        /// Shared Timestamp property used by all Events.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Shared Event property used by all Events.
        /// </summary>
        public string Event { get; set; }
    }

    public class Catch
    {
        /// <summary>
        /// Function that returns a standard Default String value duing contstruction
        /// to prevent null values from being assinged in unused event properties.
        /// </summary>
        /// <returns>"None"</returns>
        public string Str()
        {
            return "None";
        }

        /// <summary>
        /// /// Function that returns a standard Default Decimal value duing contstruction
        /// to allow tracking of unused properties in events.
        /// </summary>
        /// <returns>"-1"</returns>
        public decimal Dec()
        {
            return -1;
        }

        /// <summary>
        /// Function that returns a standard Default Boolean (false) value duing contstruction
        /// to prevent null values from being assinged in unused event properties.
        /// </summary>
        /// <returns>"false"</returns>
        public bool Bool()
        {
            return false;
        }

        /// <summary>
        /// /// Function that returns a standard Default DateTime value duing contstruction
        /// to allow tracking of unused properties in events.
        /// </summary>
        /// <returns>"1/1/0001 12:00:00 AM"</returns>
        public DateTime Dtg()
        {
            return default(DateTime);
        }

        [JsonExtensionData]
        public IDictionary<string, object> Undefined { get; set; }

        public IDictionary<string, object> UndefinedProperties()
        {
            return Undefined;
        }
    }

    #region Old Items To Remove After Framework Conversion
    public class Event_Base
    {
        #region Collctions
        //Dictionary, String (Variable Name), string (Variable Value) 
        public static Dictionary<string, string> Variables = new Dictionary<string, string>();
        #endregion

        #region Variables
        //Individual Event Toggle
        public bool WriteVariables { get; set; }
        public string Name { get; set; }

        //public string Name
        //{
        //    get => this.GetType().Name.Replace("Event_", "");
        //}
        #endregion

        #region Methods / Functions
        public Event_Base()
        {
            WriteVariables = true;
        }

        public void Variables_Write()
        {
            if (IEvents.WriteVariables == false) { return; }
            foreach (var Variable in Variables)
            { IPlatform.SetText(Variable.Key, Variable.Value); }
        }

        public void Variables_Clear()
        {
            if (IEvents.WriteVariables == false) { return; }
            foreach (var Variable in Variables)
            { IPlatform.SetText(Variable.Key, null); }
        }

        public void Variable_Craft(string VariableName, string VariableValue)
        {
            if (IEvents.WriteVariables == false) { return; }
            if (VariableValue != null)
            { Variables.Add(Name + VariableName, VariableValue); }            
        }

        public void TriggerEvent()
        {
            if (IEvents.TriggerEvents)
            {
                IPlatform.ExecuteCommand("EVENT - " + Name);
                Logger.AliceLog("Event: " + Name);
            }            
        }

        public bool EventExist(string EventName, bool Answer = false)
        {
            string MethodName = "Event Manager (Event Exist)";

            string DebugText = "Event Exist Check Failed, " + EventName + " Has Not Been Recorded.";
            string Color = Logger.Yellow;

            if (IEvents.Events.ContainsKey(EventName) == true)
            { Answer = true; }

            if (Answer == false)
            { Logger.DebugLine(MethodName, DebugText, Color); }

            return Answer;
        }

        public object GetEvent()
        {
            object Temp = null;

            if (EventExist(Name))
            {
                Temp = IEvents.Events[Name];
            }

            return Temp;
        }

        public object GetEvent(string EventName)
        {
            object Temp = null;

            if (EventExist(EventName))
            {
                Temp = IEvents.Events[EventName];
            }

            return Temp;
        }

        public static void UpdateEvents(string EventName, object Event)
        {
            IEvents.UpdateEvents(EventName, Event);
        }
        #endregion
    }

    /// <summary>
    /// These Defaults are used to prevent working with optionally logged properties and the need to track and check if an item was set.
    /// </summary>
    public static class Default
    {
        public static readonly string String = "None";
        public static readonly decimal Decimal = -1;
        public static readonly bool False = false;
        public static readonly bool True = true;
        public static readonly DateTime DTime = default(DateTime);

        //FSDJump Event
        public static readonly string Independant = "Independant";
    }
    #endregion
}