using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ALICE_Interface;
using ALICE_Objects;
using ALICE_Internal;
using ALICE_EventLogic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ALICE_Events
{
    public static class IEvents
    {
        #region Collections
        public static EventType Types = new EventType();

        //Most Current Processed Event
        public static Dictionary<string, object> Events = new Dictionary<string, object>();
        //Previously Stored Event
        public static Dictionary<string, object> PreviousEvents = new Dictionary<string, object>();
        #endregion

        #region Variables
        public static bool WriteVariables = false;
        public static bool TriggerEvents = false;
        public static bool ExecuteOnline = true;
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

        //public static void RecordUndefinedEvent(string RawLine)
        //{
        //    //Undefined.Events.Add(RawLine);
        //    Logger.DevUpdateLog(MethodName, "I've Found A New/Untracked Event: " + )
        //}

        public static void Online()
        {
            TriggerEvents = true;
            ExecuteOnline = false;
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

        #region Custom Events

        #region A
        public static Event_AliceOnline AliceOnline = new Event_AliceOnline();
        public static Event_Assult Assult = new Event_Assult();
        #endregion

        #region B
        public static Event_BlockAirlockMajor BlockAirlockMajor = new Event_BlockAirlockMajor();
        public static Event_BlockAirlockMinor BlockAirlockMinor = new Event_BlockAirlockMinor();
        public static Event_BlockAirlockWarning BlockAirlockWarning = new Event_BlockAirlockWarning();
        public static Event_BlockLandingPadMajor BlockLandingPadMajor = new Event_BlockLandingPadMajor();
        public static Event_BlockLandingPadMinor BlockLandingPadMinor = new Event_BlockLandingPadMinor();
        public static Event_BlockLandingPadWarning BlockLandingPadWarning = new Event_BlockLandingPadWarning();
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
        public static Event_DiscoveryScan DiscoveryScan = new Event_DiscoveryScan();
        public static Event_Docked Docked = new Event_Docked();
        public static Event_DockFighter DockFighter = new Event_DockFighter();
        public static Event_DockingCancelled DockingCancelled = new Event_DockingCancelled();
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
        public static Event_Undefined Undefined = new Event_Undefined();
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

        #region Json Events
        public static Event_Masslock Masslock = new Event_Masslock();
        #endregion

        public class EventType
        {
            /// <summary>
            /// (Answer) Enum Used as a return value to give more detailed information.
            /// </summary>
            public enum A { Default, Pass, Fail, Error }

            //Collection Of Event Types Accesed Via Enums
            public static readonly Dictionary<IEnums.Events, Type> Type = new Dictionary<IEnums.Events, Type>()
            {
                //Json Events:
                //{ IEnums.Events.Modules, typeof(Modules) }
                { IEnums.Events.Shipyard, typeof(Shipyard) },
                { IEnums.Events.Status, typeof(Status) },

                //Shared Events:
                { IEnums.Events.Cargo, typeof(Cargo) },
                { IEnums.Events.Market, typeof(Market) },
                { IEnums.Events.Outfitting, typeof(Outfitting) },

                //Journal Events:
                { IEnums.Events.AfmuRepairs, typeof(AfmuRepairs) },
                { IEnums.Events.ApproachBody, typeof(ApproachBody) },
                { IEnums.Events.ApproachSettlement, typeof(ApproachSettlement) },
                { IEnums.Events.Bounty, typeof(Bounty) },
                { IEnums.Events.BuyAmmo, typeof(BuyAmmo) },
                { IEnums.Events.BuyDrones, typeof(BuyDrones) },
                { IEnums.Events.BuyExplorationData, typeof(BuyExplorationData) },
                { IEnums.Events.BuyTradeData, typeof(BuyTradeData) },
                { IEnums.Events.CargoDepot, typeof(CargoDepot) },
                { IEnums.Events.ChangeCrewRole, typeof(ChangeCrewRole) },
                { IEnums.Events.ClearSaveGame, typeof(ClearSaveGame) },
                { IEnums.Events.CockpitBreached, typeof(CockpitBreached) },
                { IEnums.Events.CodexEntry, typeof(CodexEntry) },
                { IEnums.Events.CollectCargo, typeof(CollectCargo) },
                { IEnums.Events.Commander, typeof(Commander) },
                { IEnums.Events.CommitCrime, typeof(CommitCrime) },
                { IEnums.Events.CommunityGoal, typeof(CommunityGoal) },
                { IEnums.Events.CrewAssign, typeof(CrewAssign) },
                { IEnums.Events.CrewFire, typeof(CrewFire) },
                { IEnums.Events.CrewHire, typeof(CrewHire) },
                { IEnums.Events.DatalinkScan, typeof(DatalinkScan) },
                { IEnums.Events.DatalinkVoucher, typeof(DatalinkVoucher) },
                { IEnums.Events.DataScanned, typeof(DataScanned) },
                { IEnums.Events.Died, typeof(Died) },
                { IEnums.Events.Docked, typeof(Docked) },
                { IEnums.Events.DockFighter, typeof(DockFighter) },
                { IEnums.Events.DockingCancelled, typeof(DockingCancelled) },
                { IEnums.Events.DockingGranted, typeof(DockingGranted) },
                { IEnums.Events.DockingRequested, typeof(DockingRequested) },
                { IEnums.Events.DockSRV, typeof(DockSRV) },
                { IEnums.Events.EjectCargo, typeof(EjectCargo) },
                { IEnums.Events.EngineerContribution, typeof(EngineerContribution) },
                { IEnums.Events.EngineerCraft, typeof(EngineerCraft) },
                { IEnums.Events.EngineerProgress, typeof(EngineerProgress) },
                { IEnums.Events.EscapeInterdiction, typeof(EscapeInterdiction) },
                { IEnums.Events.FactionKillBond, typeof(FactionKillBond) },
                { IEnums.Events.FetchRemoteModule, typeof(FetchRemoteModule) },
                { IEnums.Events.FighterDestroyed, typeof(FighterDestroyed) },
                { IEnums.Events.FighterRebuilt, typeof(FighterRebuilt) },
                { IEnums.Events.Fileheader, typeof(Fileheader) },
                { IEnums.Events.Friends, typeof(Friends) },
                { IEnums.Events.FSDJump, typeof(FSDJump) },
                { IEnums.Events.FSDTarget, typeof(FSDTarget) },
                { IEnums.Events.FSSAllBodiesFound, typeof(FSSAllBodiesFound) },
                { IEnums.Events.FSSDiscoveryScan, typeof(FSSDiscoveryScan) },
                { IEnums.Events.FSSSignalDiscovered, typeof(FSSSignalDiscovered) },
                { IEnums.Events.FuelScoop, typeof(FuelScoop) },
                { IEnums.Events.HeatDamage, typeof(HeatDamage) },
                { IEnums.Events.HeatWarning, typeof(HeatWarning) },
                { IEnums.Events.HullDamage, typeof(HullDamage) },
                { IEnums.Events.Interdicted, typeof(Interdicted) },
                { IEnums.Events.JetConeBoost, typeof(JetConeBoost) },
                { IEnums.Events.LaunchDrone, typeof(LaunchDrone) },
                { IEnums.Events.LaunchFighter, typeof(LaunchFighter) },
                { IEnums.Events.LaunchSRV, typeof(LaunchSRV) },
                { IEnums.Events.LeaveBody, typeof(LeaveBody) },
                { IEnums.Events.Liftoff, typeof(Liftoff) },
                { IEnums.Events.LoadGame, typeof(LoadGame) },
                { IEnums.Events.Loadout, typeof(Loadout) },
                { IEnums.Events.Location, typeof(Location) },
                { IEnums.Events.MarketBuy, typeof(MarketBuy) },
                { IEnums.Events.MarketSell, typeof(MarketSell) },
                { IEnums.Events.MassModuleStore, typeof(MassModuleStore) },
                { IEnums.Events.MaterialCollected, typeof(MaterialCollected) },
                { IEnums.Events.MaterialDiscovered, typeof(MaterialDiscovered) },
                { IEnums.Events.Materials, typeof(Materials) },
                { IEnums.Events.MaterialTrade, typeof(MaterialTrade) },
                { IEnums.Events.MiningRefined, typeof(MiningRefined) },
                { IEnums.Events.MissionAbandoned, typeof(MissionAbandoned) },
                { IEnums.Events.MissionAccepted, typeof(MissionAccepted) },
                { IEnums.Events.MissionCompleted, typeof(MissionCompleted) },
                { IEnums.Events.MissionFailed, typeof(MissionFailed) },
                { IEnums.Events.MissionRedirected, typeof(MissionRedirected) },
                { IEnums.Events.Missions, typeof(Missions) },
                { IEnums.Events.ModuleBuy, typeof(ModuleBuy) },
                { IEnums.Events.ModuleInfo, typeof(ModuleInfo) },
                { IEnums.Events.ModuleRetrieve, typeof(ModuleRetrieve) },
                { IEnums.Events.ModuleSell, typeof(ModuleSell) },
                { IEnums.Events.ModuleSellRemote, typeof(ModuleSellRemote) },
                { IEnums.Events.ModuleStore, typeof(ModuleStore) },
                { IEnums.Events.ModuleSwap, typeof(ModuleSwap) },
                { IEnums.Events.MultiSellExplorationData, typeof(MultiSellExplorationData) },
                { IEnums.Events.Music, typeof(Music) },
                { IEnums.Events.NavBeaconScan, typeof(NavBeaconScan) },
                { IEnums.Events.NpcCrewPaidWage, typeof(NpcCrewPaidWage) },
                { IEnums.Events.NpcCrewRank, typeof(NpcCrewRank) },
                { IEnums.Events.PayBounties, typeof(PayBounties) },
                { IEnums.Events.PayFines, typeof(PayFines) },
                { IEnums.Events.Powerplay, typeof(Powerplay) },
                { IEnums.Events.PowerplayCollect, typeof(PowerplayCollect) },
                { IEnums.Events.PowerplayDefect, typeof(PowerplayDefect) },
                { IEnums.Events.PowerplayDeliver, typeof(PowerplayDeliver) },
                { IEnums.Events.PowerplayFastTrack, typeof(PowerplayFastTrack) },
                { IEnums.Events.PowerplayJoin, typeof(PowerplayJoin) },
                { IEnums.Events.PowerplayLeave, typeof(PowerplayLeave) },
                { IEnums.Events.PowerplaySalary, typeof(PowerplaySalary) },
                { IEnums.Events.PowerplayVote, typeof(PowerplayVote) },
                { IEnums.Events.Progress, typeof(Progress) },
                { IEnums.Events.Promotion, typeof(Promotion) },
                { IEnums.Events.QuitACrew, typeof(QuitACrew) },
                { IEnums.Events.Rank, typeof(Rank) },
                { IEnums.Events.RebootRepair, typeof(RebootRepair) },
                { IEnums.Events.ReceiveText, typeof(ReceiveText) },
                { IEnums.Events.RedeemVoucher, typeof(RedeemVoucher) },
                { IEnums.Events.RefuelAll, typeof(RefuelAll) },
                { IEnums.Events.Repair, typeof(Repair) },
                { IEnums.Events.RepairAll, typeof(RepairAll) },
                { IEnums.Events.RepairDrone, typeof(RepairDrone) },
                { IEnums.Events.Reputation, typeof(Reputation) },
                { IEnums.Events.ReservoirReplenished, typeof(ReservoirReplenished) },
                { IEnums.Events.RestockVehicle, typeof(RestockVehicle) },
                { IEnums.Events.Resurrect, typeof(Resurrect) },
                { IEnums.Events.SAAScanComplete, typeof(SAAScanComplete) },
                { IEnums.Events.Scan, typeof(Scan) },
                { IEnums.Events.Scanned, typeof(Scanned) },
                { IEnums.Events.ScientificResearch, typeof(ScientificResearch) },
                { IEnums.Events.Screenshot, typeof(Screenshot) },
                { IEnums.Events.SearchAndRescue, typeof(SearchAndRescue) },
                { IEnums.Events.SelfDestruct, typeof(SelfDestruct) },
                { IEnums.Events.SellDrones, typeof(SellDrones) },
                { IEnums.Events.SellExplorationData, typeof(SellExplorationData) },
                { IEnums.Events.SendText, typeof(SendText) },
                { IEnums.Events.SetUserShipName, typeof(SetUserShipName) },
                { IEnums.Events.ShieldState, typeof(ShieldState) },
                { IEnums.Events.ShipTargeted, typeof(ShipTargeted) },
                { IEnums.Events.ShipyardBuy, typeof(ShipyardBuy) },
                { IEnums.Events.ShipyardNew, typeof(ShipyardNew) },
                { IEnums.Events.ShipyardSwap, typeof(ShipyardSwap) },
                { IEnums.Events.ShipyardTransfer, typeof(ShipyardTransfer) },
                { IEnums.Events.Shutdown, typeof(Shutdown) },
                { IEnums.Events.SRVDestroyed, typeof(SRVDestroyed) },
                { IEnums.Events.StartJump, typeof(StartJump) },
                { IEnums.Events.Statistics, typeof(Statistics) },
                { IEnums.Events.StoredModules, typeof(StoredModules) },
                { IEnums.Events.StoredShips, typeof(StoredShips) },
                { IEnums.Events.SupercruiseEntry, typeof(SupercruiseEntry) },
                { IEnums.Events.SupercruiseExit, typeof(SupercruiseExit) },
                { IEnums.Events.Synthesis, typeof(Synthesis) },
                { IEnums.Events.SystemsShutdown, typeof(SystemsShutdown) },
                { IEnums.Events.SquadronStartup, typeof(SquadronStartup) },
                { IEnums.Events.TechnologyBroker, typeof(TechnologyBroker) },
                { IEnums.Events.Touchdown, typeof(Touchdown) },
                { IEnums.Events.Undefined, typeof(Undefined) },
                { IEnums.Events.UnderAttack, typeof(UnderAttack) },
                { IEnums.Events.Undocked, typeof(Undocked) },
                { IEnums.Events.USSDrop, typeof(USSDrop) },
                { IEnums.Events.VehicleSwitch, typeof(VehicleSwitch) },
                { IEnums.Events.WingAdd, typeof(WingAdd) },
                { IEnums.Events.WingInvite, typeof(WingInvite) },
                { IEnums.Events.WingJoin, typeof(WingJoin) },
                { IEnums.Events.WingLeave, typeof(WingLeave) }
            };

            /// <summary>
            /// Checks the Event Type Dictionary to see if the Passed Event Exists
            /// </summary>
            /// <param name="E">Event to Check</param>
            /// <returns></returns>
            public A Exists(IEnums.Events E)
            {
                string MethodName = "Event (Exists)";

                try
                {
                    //Check If Event Is In The Type Dictionary
                    if (Type.ContainsKey(E)) { return A.Pass; }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "(Failed) The Check Hamster Made A Mistake And Forgot What He Was Doing...");
                    return A.Error;
                }

                //Event Didnt' Exist
                return A.Fail;
            }

            /// <summary>
            /// Checks the Event Type Dictionary to see if the Passed Event Exists
            /// </summary>
            /// <param name="S">Event string to Check</param>
            /// <returns></returns>
            public A Exists(string S)
            {
                string MethodName = "Event (Exists)";
                IEnums.Events E = IEnums.Events.None;

                try
                {
                    E = IEnums.ToEnum<IEnums.Events>(S);
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "(Failed) The Lookup Hamster Made A Mistake And Forgot What He Was Doing...");
                }

                try
                {
                    //Check If Event Is In The Type Dictionary
                    if (E != IEnums.Events.None && Type.ContainsKey(E)) { return A.Pass; }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "(Failed) The Check Hamster Made A Mistake And Forgot What He Was Doing...");
                    return A.Error;
                }

                //Event Didnt' Exist
                return A.Fail;
            }

            /// <summary>
            /// Gets the Event Type from the Dictionary.
            /// </summary>
            /// <param name="E">Event your requesting the type of.</param>
            /// <param name="Override">When Override is set to false it will perform a check on the Dictionary</param>
            /// <returns></returns>
            public Type GetType(IEnums.Events E, bool Override = true)
            {
                string MethodName = "Event (Get Type)";

                if (Override == false)
                {
                    switch (Exists(E))
                    {
                        case A.Pass:
                            Logger.DebugLine(MethodName, E + " Found, Returning Type", Logger.Blue);
                            break;
                        case A.Fail:
                            Logger.DebugLine(MethodName, E + " Not Found, Returning Null", Logger.Blue);
                            return null;
                        case A.Error:
                            Logger.Error(MethodName, "An Error Was Detected While Procssing " + E, Logger.Red);
                            return null;
                        default:
                            Logger.Error(MethodName, "Returned Using The Default Switch", Logger.Red);
                            return null;
                    }
                }

                return Type[E];
            }

            /// <summary>
            /// Gets the Event Type from the Dictionary.
            /// </summary>
            /// <param name="S">Event string your requesting the type of.</param>
            /// <param name="Override">When Override is set to false it will perform a check on the Dictionary</param>
            /// <returns></returns>
            public Type GetType(string S, bool Override = true)
            {
                string MethodName = "Event (Get Type)";
                IEnums.Events E = IEnums.Events.None;

                try
                {
                    E = IEnums.ToEnum<IEnums.Events>(S);
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "(Failed) The Lookup Hamster Made A Mistake And Forgot What He Was Doing...");
                }

                if (Override == false && E != IEnums.Events.None)
                {
                    switch (Exists(E))
                    {
                        case A.Pass:
                            Logger.DebugLine(MethodName, E + " Found, Returning Type", Logger.Blue);
                            break;
                        case A.Fail:
                            Logger.DebugLine(MethodName, E + " Not Found, Returning Null", Logger.Blue);
                            return null;
                        case A.Error:
                            Logger.Error(MethodName, "An Error Was Detected While Procssing " + E, Logger.Red);
                            return null;
                        default:
                            Logger.Error(MethodName, "Returned Using The Default Switch", Logger.Red);
                            return null;
                    }
                }

                return Type[E];
            }
        }
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

    public class Catch
    {
        [JsonExtensionData]
        public IDictionary<string, object> Undefined { get; set; }

        public IDictionary<string, object> UndefinedProperties()
        {
            return Undefined;
        }
    }

    public class Base : Catch
    {
        public DateTime Timestamp { get; set; }
        public string Event { get; set; }
    }
}