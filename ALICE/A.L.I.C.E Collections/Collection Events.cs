using ALICE_Events;
using ALICE_Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Collections
{
    /// <summary>
    /// Custom Collection that handles Event storage and the controls to interface with the Collection.
    /// </summary>
    public class CollectionEvents
    {
        /// <summary>
        /// Collection of variable Name / Value for each Property processed by the generator for an Event
        /// </summary>
        public Dictionary<IEnums.Events, object> Storage = new Dictionary<IEnums.Events, object>();

        /// <summary>
        /// Readonly string defining the Class Name for tracking use with the Logger function.
        /// </summary>
        private readonly string ClassName = "Event";

        /// <summary>
        /// Records the event object in Event Storage.
        /// </summary>
        /// <param name="E">(Event Name) Target Event's Name</param>
        /// <param name="O">(Object) The Associated Event's Object</param>
        /// <returns>Postive = Recorded, Negative = Not Recorded</returns>
        public IEnums.A Record(IEnums.Events E, object O)
        {
            string MethodName = ClassName + " (Record)";

            switch (Exist(E))
            {
                case IEnums.A.Postive:

                    //Event Exist, Update
                    Storage[E] = O;

                    //Event Recorded
                    return IEnums.A.Postive;

                case IEnums.A.Negative:

                    //Does Not Exist, Add
                    Storage.Add(E, O);

                    //Event Recorded
                    return IEnums.A.Postive;

                case IEnums.A.Error:

                    //Event Not Recorded
                    return IEnums.A.Negative;

                default:

                    //Error Logger
                    Logger.Error(MethodName, "Returned Using Default Swtich, Event Was Not Recorded", Logger.Red);

                    //Event Not Recorded
                    return IEnums.A.Negative;
            }
        }

        /// <summary>
        /// Checks if the target Event Exists in Storage.
        /// </summary>
        /// <param name="E">(Event Name) Target Event</param>
        /// <returns>Postive, Negative or Error</returns>
        public IEnums.A Exist(IEnums.Events E)
        {
            string MethodName = ClassName + " (Exist)";

            try
            {
                //Check For Event
                if (Storage.ContainsKey(E) == true)
                {
                    //Exists, Return Postive
                    return IEnums.A.Postive;
                }

                //Debug Logger
                Logger.DebugLine(MethodName, E + " Has Not Been Recorded Yet.", Logger.Yellow);

                //Event Does Not Exist, Return Negative
                return IEnums.A.Negative;
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);

                //Exception Occured, Return Error
                return IEnums.A.Error;
            }
        }

        /// <summary>
        /// Gets the target Event
        /// </summary>
        /// <param name="E">(Event Name) Target Event</param>
        /// <returns>Object Data or Null</returns>
        public object Get(IEnums.Events E)
        {
            string MethodName = ClassName + " (Get)";
            object Temp = null;

            switch (Exist(E))
            {
                case IEnums.A.Postive:

                    //Get Object
                    Temp = Storage[E];

                    //Return Object
                    return Temp;

                case IEnums.A.Negative:

                    //Return Null
                    return Temp;

                case IEnums.A.Error:

                    //Return Null
                    return Temp;

                default:

                    //Error Logger
                    Logger.Error(MethodName, "Returned Using Default Swtich, Returning Null", Logger.Red);

                    //Return Null
                    return Temp;
            }
        }

        public E_AsteroidCracked AsteroidCracked = new E_AsteroidCracked();

        public void Process(IEnums.Events E)
        {
            switch (E)
            {
                case IEnums.Events.None:
                    break;
                case IEnums.Events.Shipyard:
                    break;
                case IEnums.Events.Status:
                    break;
                case IEnums.Events.Cargo:
                    break;
                case IEnums.Events.Market:
                    break;
                case IEnums.Events.Outfitting:
                    break;
                case IEnums.Events.AfmuRepairs:
                    break;
                case IEnums.Events.ApproachBody:
                    break;
                case IEnums.Events.ApproachSettlement:
                    break;
                case IEnums.Events.AsteroidCracked:
                    AsteroidCracked.Logic();
                    break;
                case IEnums.Events.Bounty:
                    break;
                case IEnums.Events.BuyAmmo:
                    break;
                case IEnums.Events.BuyDrones:
                    break;
                case IEnums.Events.BuyExplorationData:
                    break;
                case IEnums.Events.BuyTradeData:
                    break;
                case IEnums.Events.CargoDepot:
                    break;
                case IEnums.Events.ChangeCrewRole:
                    break;
                case IEnums.Events.ClearSaveGame:
                    break;
                case IEnums.Events.CockpitBreached:
                    break;
                case IEnums.Events.CodexEntry:
                    break;
                case IEnums.Events.CollectCargo:
                    break;
                case IEnums.Events.Commander:
                    break;
                case IEnums.Events.CommitCrime:
                    break;
                case IEnums.Events.CommunityGoal:
                    break;
                case IEnums.Events.CrewAssign:
                    break;
                case IEnums.Events.CrewFire:
                    break;
                case IEnums.Events.CrewHire:
                    break;
                case IEnums.Events.DatalinkScan:
                    break;
                case IEnums.Events.DatalinkVoucher:
                    break;
                case IEnums.Events.DataScanned:
                    break;
                case IEnums.Events.Died:
                    break;
                case IEnums.Events.Docked:
                    break;
                case IEnums.Events.DockFighter:
                    break;
                case IEnums.Events.DockingCancelled:
                    break;
                case IEnums.Events.DockingGranted:
                    break;
                case IEnums.Events.DockingRequested:
                    break;
                case IEnums.Events.DockSRV:
                    break;
                case IEnums.Events.EjectCargo:
                    break;
                case IEnums.Events.EngineerContribution:
                    break;
                case IEnums.Events.EngineerCraft:
                    break;
                case IEnums.Events.EngineerProgress:
                    break;
                case IEnums.Events.EscapeInterdiction:
                    break;
                case IEnums.Events.FactionKillBond:
                    break;
                case IEnums.Events.FetchRemoteModule:
                    break;
                case IEnums.Events.FighterDestroyed:
                    break;
                case IEnums.Events.FighterRebuilt:
                    break;
                case IEnums.Events.Fileheader:
                    break;
                case IEnums.Events.Friends:
                    break;
                case IEnums.Events.FSDJump:
                    break;
                case IEnums.Events.FSDTarget:
                    break;
                case IEnums.Events.FSSAllBodiesFound:
                    break;
                case IEnums.Events.FSSDiscoveryScan:
                    break;
                case IEnums.Events.FSSSignalDiscovered:
                    break;
                case IEnums.Events.FuelScoop:
                    break;
                case IEnums.Events.HeatDamage:
                    break;
                case IEnums.Events.HeatWarning:
                    break;
                case IEnums.Events.HullDamage:
                    break;
                case IEnums.Events.Interdicted:
                    break;
                case IEnums.Events.JetConeBoost:
                    break;
                case IEnums.Events.LaunchDrone:
                    break;
                case IEnums.Events.LaunchFighter:
                    break;
                case IEnums.Events.LaunchSRV:
                    break;
                case IEnums.Events.LeaveBody:
                    break;
                case IEnums.Events.Liftoff:
                    break;
                case IEnums.Events.LoadGame:
                    break;
                case IEnums.Events.Loadout:
                    break;
                case IEnums.Events.Location:
                    break;
                case IEnums.Events.MarketBuy:
                    break;
                case IEnums.Events.MarketSell:
                    break;
                case IEnums.Events.MassModuleStore:
                    break;
                case IEnums.Events.MaterialCollected:
                    break;
                case IEnums.Events.MaterialDiscovered:
                    break;
                case IEnums.Events.Materials:
                    break;
                case IEnums.Events.MaterialTrade:
                    break;
                case IEnums.Events.MiningRefined:
                    break;
                case IEnums.Events.MissionAbandoned:
                    break;
                case IEnums.Events.MissionAccepted:
                    break;
                case IEnums.Events.MissionCompleted:
                    break;
                case IEnums.Events.MissionFailed:
                    break;
                case IEnums.Events.MissionRedirected:
                    break;
                case IEnums.Events.Missions:
                    break;
                case IEnums.Events.ModuleBuy:
                    break;
                case IEnums.Events.ModuleInfo:
                    break;
                case IEnums.Events.ModuleRetrieve:
                    break;
                case IEnums.Events.ModuleSell:
                    break;
                case IEnums.Events.ModuleSellRemote:
                    break;
                case IEnums.Events.ModuleStore:
                    break;
                case IEnums.Events.ModuleSwap:
                    break;
                case IEnums.Events.MultiSellExplorationData:
                    break;
                case IEnums.Events.Music:
                    break;
                case IEnums.Events.NavBeaconScan:
                    break;
                case IEnums.Events.NpcCrewPaidWage:
                    break;
                case IEnums.Events.NpcCrewRank:
                    break;
                case IEnums.Events.PayBounties:
                    break;
                case IEnums.Events.PayFines:
                    break;
                case IEnums.Events.Powerplay:
                    break;
                case IEnums.Events.PowerplayCollect:
                    break;
                case IEnums.Events.PowerplayDefect:
                    break;
                case IEnums.Events.PowerplayDeliver:
                    break;
                case IEnums.Events.PowerplayFastTrack:
                    break;
                case IEnums.Events.PowerplayJoin:
                    break;
                case IEnums.Events.PowerplayLeave:
                    break;
                case IEnums.Events.PowerplaySalary:
                    break;
                case IEnums.Events.PowerplayVote:
                    break;
                case IEnums.Events.Progress:
                    break;
                case IEnums.Events.Promotion:
                    break;
                case IEnums.Events.ProspectedAsteroid:
                    break;
                case IEnums.Events.QuitACrew:
                    break;
                case IEnums.Events.Rank:
                    break;
                case IEnums.Events.RebootRepair:
                    break;
                case IEnums.Events.ReceiveText:
                    break;
                case IEnums.Events.RedeemVoucher:
                    break;
                case IEnums.Events.RefuelAll:
                    break;
                case IEnums.Events.Repair:
                    break;
                case IEnums.Events.RepairAll:
                    break;
                case IEnums.Events.RepairDrone:
                    break;
                case IEnums.Events.Reputation:
                    break;
                case IEnums.Events.ReservoirReplenished:
                    break;
                case IEnums.Events.RestockVehicle:
                    break;
                case IEnums.Events.Resurrect:
                    break;
                case IEnums.Events.SAAScanComplete:
                    break;
                case IEnums.Events.Scan:
                    break;
                case IEnums.Events.Scanned:
                    break;
                case IEnums.Events.ScientificResearch:
                    break;
                case IEnums.Events.Screenshot:
                    break;
                case IEnums.Events.SearchAndRescue:
                    break;
                case IEnums.Events.SelfDestruct:
                    break;
                case IEnums.Events.SellDrones:
                    break;
                case IEnums.Events.SellExplorationData:
                    break;
                case IEnums.Events.SendText:
                    break;
                case IEnums.Events.SetUserShipName:
                    break;
                case IEnums.Events.ShieldState:
                    break;
                case IEnums.Events.ShipTargeted:
                    break;
                case IEnums.Events.ShipyardBuy:
                    break;
                case IEnums.Events.ShipyardNew:
                    break;
                case IEnums.Events.ShipyardSwap:
                    break;
                case IEnums.Events.ShipyardTransfer:
                    break;
                case IEnums.Events.Shutdown:
                    break;
                case IEnums.Events.SRVDestroyed:
                    break;
                case IEnums.Events.StartJump:
                    break;
                case IEnums.Events.Statistics:
                    break;
                case IEnums.Events.StoredModules:
                    break;
                case IEnums.Events.StoredShips:
                    break;
                case IEnums.Events.SupercruiseEntry:
                    break;
                case IEnums.Events.SupercruiseExit:
                    break;
                case IEnums.Events.Synthesis:
                    break;
                case IEnums.Events.SystemsShutdown:
                    break;
                case IEnums.Events.SquadronStartup:
                    break;
                case IEnums.Events.TechnologyBroker:
                    break;
                case IEnums.Events.Touchdown:
                    break;
                case IEnums.Events.Undefined:
                    break;
                case IEnums.Events.UnderAttack:
                    break;
                case IEnums.Events.Undocked:
                    break;
                case IEnums.Events.USSDrop:
                    break;
                case IEnums.Events.VehicleSwitch:
                    break;
                case IEnums.Events.WingAdd:
                    break;
                case IEnums.Events.WingInvite:
                    break;
                case IEnums.Events.WingJoin:
                    break;
                case IEnums.Events.WingLeave:
                    break;
                default:
                    break;
            }
        }

        //#region Custom Events

        //#region A
        //public Event_AliceOnline AliceOnline = new Event_AliceOnline();
        //public Event_Assult Assult = new Event_Assult();
        //#endregion

        //#region B
        //public Event_BlockAirlockMajor BlockAirlockMajor = new Event_BlockAirlockMajor();
        //public Event_BlockAirlockMinor BlockAirlockMinor = new Event_BlockAirlockMinor();
        //public Event_BlockAirlockWarning BlockAirlockWarning = new Event_BlockAirlockWarning();
        //public Event_BlockLandingPadMajor BlockLandingPadMajor = new Event_BlockLandingPadMajor();
        //public Event_BlockLandingPadMinor BlockLandingPadMinor = new Event_BlockLandingPadMinor();
        //public Event_BlockLandingPadWarning BlockLandingPadWarning = new Event_BlockLandingPadWarning();
        //#endregion

        //#region D
        //public Event_DisobeyPolice DisobeyPolice = new Event_DisobeyPolice();
        //public Event_DumpingDangerous DumpingDangerous = new Event_DumpingDangerous();
        //public Event_DumpingNearStation DumpingNearStation = new Event_DumpingNearStation();
        //#endregion

        //#region F
        //public Event_FireInNoFireZone FireInNoFireZone = new Event_FireInNoFireZone();
        //public Event_FireInStation FireInStation = new Event_FireInStation();
        //public Event_FuelCritical FuelCritical = new Event_FuelCritical();
        //public Event_FuelHalfThreshold FuelHalfThreshold = new Event_FuelHalfThreshold();
        //public Event_FuelLow FuelLow = new Event_FuelLow();
        //#endregion

        //#region I
        //public Event_IllegalCargo IllegalCargo = new Event_IllegalCargo();
        //public Event_Interdicting Interdicting = new Event_Interdicting();
        //#endregion

        //#region M
        //public Event_Murder Murder = new Event_Murder();
        //#endregion

        //#region N
        //public Event_NoFireZone NoFireZone = new Event_NoFireZone();
        //#endregion

        //#region P
        //public Event_Piracy Piracy = new Event_Piracy();
        //#endregion

        //#region S
        //public Event_ShipyardArrived ShipyardArrived = new Event_ShipyardArrived();
        //public Event_StationDamage StationDamage = new Event_StationDamage();
        //public Event_StationHostile StationHostile = new Event_StationHostile();
        //#endregion

        //#region T
        //public Event_TrespassMajor TrespassMajor = new Event_TrespassMajor();
        //public Event_TrespassMinor TrespassMinor = new Event_TrespassMinor();
        //#endregion

        //#region W
        //public Event_WrecklessFlying WrecklessFlying = new Event_WrecklessFlying();
        //public Event_WrecklessFlyingDamage WrecklessFlyingDamage = new Event_WrecklessFlyingDamage();
        //#endregion

        ////End Region: Custom Events
        //#endregion

        //#region Journal Events

        //#region A
        //public Event_AfmuRepairs AfmuRepairs = new Event_AfmuRepairs();
        //public Event_ApproachBody ApproachBody = new Event_ApproachBody();
        //public Event_ApproachSettlement ApproachSettlement = new Event_ApproachSettlement();
        //public Event_AsteroidCracked AsteroidCracked = new Event_AsteroidCracked();
        //#endregion

        //#region B
        //public Event_Bounty Bounty = new Event_Bounty();
        //public Event_BuyAmmo BuyAmmo = new Event_BuyAmmo();
        //public Event_BuyDrones BuyDrones = new Event_BuyDrones();
        //public Event_BuyExplorationData BuyExplorationData = new Event_BuyExplorationData();
        //public Event_BuyTradeData BuyTradeData = new Event_BuyTradeData();
        //#endregion

        //#region C
        //public Event_Cargo Cargo = new Event_Cargo();
        //public Event_CargoDepot CargoDepot = new Event_CargoDepot();
        //public Event_ChangeCrewRole ChangeCrewRole = new Event_ChangeCrewRole();
        //public Event_ClearSaveGame ClearSaveGame = new Event_ClearSaveGame();
        //public Event_CockpitBreached CockpitBreached = new Event_CockpitBreached();
        //public Event_CodexEntry CodexEntry = new Event_CodexEntry();
        //public Event_CollectCargo CollectCargo = new Event_CollectCargo();
        //public Event_Commander Commander = new Event_Commander();
        //public Event_CommitCrime CommitCrime = new Event_CommitCrime();
        //public Event_CommunityGoal CommunityGoal = new Event_CommunityGoal();
        //public Event_CrewAssign CrewAssign = new Event_CrewAssign();
        //public Event_CrewFire CrewFire = new Event_CrewFire();
        //public Event_CrewHire CrewHire = new Event_CrewHire();
        //#endregion

        //#region D
        //public Event_DatalinkScan DatalinkScan = new Event_DatalinkScan();
        //public Event_DataScanned DataScanned = new Event_DataScanned();
        //public Event_DatalinkVoucher DatalinkVoucher = new Event_DatalinkVoucher();
        //public Event_Died Died = new Event_Died();
        //public Event_DiscoveryScan DiscoveryScan = new Event_DiscoveryScan();
        //public Event_Docked Docked = new Event_Docked();
        //public Event_DockFighter DockFighter = new Event_DockFighter();
        //public Event_DockingCancelled DockingCancelled = new Event_DockingCancelled();
        //public Event_DockingDenied DockingDenied = new Event_DockingDenied();
        //public Event_DockingGranted DockingGranted = new Event_DockingGranted();
        //public Event_DockingRequested DockingRequested = new Event_DockingRequested();
        //public Event_DockSRV DockSRV = new Event_DockSRV();
        //#endregion

        //#region E
        //public Event_EjectCargo EjectCargo = new Event_EjectCargo();
        //public Event_EscapeInterdiction EscapeInterdiction = new Event_EscapeInterdiction();
        //public Event_EngineerContribution EngineerContribution = new Event_EngineerContribution();
        //public Event_EngineerCraft EngineerCraft = new Event_EngineerCraft();
        //public Event_EngineerProgress EngineerProgress = new Event_EngineerProgress();
        //#endregion

        //#region F
        //public Event_FactionKillBond FactionKillBond = new Event_FactionKillBond();
        //public Event_FighterDestroyed FighterDestroyed = new Event_FighterDestroyed();
        //public Event_FighterRebuilt FighterRebuilt = new Event_FighterRebuilt();
        //public Event_Fileheader Fileheader = new Event_Fileheader();
        //public Event_Friends Friends = new Event_Friends();
        //public Event_FSDJump FSDJump = new Event_FSDJump();
        //public Event_FSDTarget FSDTarget = new Event_FSDTarget();
        //public Event_FSSAllBodiesFound FSSAllBodiesFound = new Event_FSSAllBodiesFound();
        //public Event_FSSDiscoveryScan FSSDiscoveryScan = new Event_FSSDiscoveryScan();
        //public Event_FSSSignalDiscovered FSSSignalDiscovered = new Event_FSSSignalDiscovered();
        //public Event_FuelScoop FuelScoop = new Event_FuelScoop();
        //public Event_FetchRemoteModule FetchRemoteModule = new Event_FetchRemoteModule();
        //#endregion

        //#region G
        //#endregion

        //#region H
        //public Event_HeatDamage HeatDamage = new Event_HeatDamage();
        //public Event_HeatWarning HeatWarning = new Event_HeatWarning();
        //public Event_HullDamage HullDamage = new Event_HullDamage();
        //#endregion

        //#region I
        //public Event_Interdicted Interdicted = new Event_Interdicted();
        //#endregion

        //#region J
        //public Event_JetConeBoost JetConeBoost = new Event_JetConeBoost();
        //#endregion

        //#region K
        //#endregion

        //#region L
        //public Event_LaunchDrone LaunchDrone = new Event_LaunchDrone();
        //public Event_LaunchFighter LaunchFighter = new Event_LaunchFighter();
        //public Event_LaunchSRV LaunchSRV = new Event_LaunchSRV();
        //public Event_LeaveBody LeaveBody = new Event_LeaveBody();
        //public Event_Liftoff Liftoff = new Event_Liftoff();
        //public Event_LoadGame LoadGame = new Event_LoadGame();
        //public Event_Loadout Loadout = new Event_Loadout();
        //public Event_Location Location = new Event_Location();
        //#endregion

        //#region M
        //public Event_Market Market = new Event_Market();
        //public Event_MarketBuy MarketBuy = new Event_MarketBuy();
        //public Event_MarketSell MarketSell = new Event_MarketSell();
        //public Event_MassModuleStore MassModuleStore = new Event_MassModuleStore();
        //public Event_MaterialCollected MaterialCollected = new Event_MaterialCollected();
        //public Event_MaterialDiscovered MaterialDiscovered = new Event_MaterialDiscovered();
        //public Event_Materials Materials = new Event_Materials();
        //public Event_MaterialTrade MaterialTrade = new Event_MaterialTrade();
        //public Event_MiningRefined MiningRefined = new Event_MiningRefined();
        //public Event_MissionAbandoned MissionAbandoned = new Event_MissionAbandoned();
        //public Event_MissionAccepted MissionAccepted = new Event_MissionAccepted();
        //public Event_MissionCompleted MissionCompleted = new Event_MissionCompleted();
        //public Event_MissionFailed MissionFailed = new Event_MissionFailed();
        //public Event_MissionRedirected MissionRedirected = new Event_MissionRedirected();
        //public Event_Missions Missions = new Event_Missions();
        //public Event_ModuleBuy ModuleBuy = new Event_ModuleBuy();
        //public Event_ModuleInfo ModuleInfo = new Event_ModuleInfo();
        //public Event_ModuleRetrieve ModuleRetrieve = new Event_ModuleRetrieve();
        //public Event_ModuleSell ModuleSell = new Event_ModuleSell();
        //public Event_ModuleSellRemote ModuleSellRemote = new Event_ModuleSellRemote();
        //public Event_ModuleStore ModuleStore = new Event_ModuleStore();
        //public Event_ModuleSwap ModuleSwap = new Event_ModuleSwap();
        //public Event_MultiSellExplorationData MultiSellExplorationData = new Event_MultiSellExplorationData();
        //public Event_Music Music = new Event_Music();
        //#endregion

        //#region N
        //public Event_NavBeaconScan NavBeaconScan = new Event_NavBeaconScan();
        //public Event_NpcCrewPaidWage NpcCrewPaidWage = new Event_NpcCrewPaidWage();
        //public Event_NpcCrewRank NpcCrewRank = new Event_NpcCrewRank();
        //#endregion

        //#region O
        //public Event_Outfitting Outfitting = new Event_Outfitting();
        //#endregion

        //#region P
        //public Event_PayBounties PayBounties = new Event_PayBounties();
        //public Event_PayFines PayFines = new Event_PayFines();
        //public Event_Powerplay Powerplay = new Event_Powerplay();
        //public Event_PowerplayCollect PowerplayCollect = new Event_PowerplayCollect();
        //public Event_PowerplayDeliver PowerplayDeliver = new Event_PowerplayDeliver();
        //public Event_PowerplayFastTrack PowerplayFastTrack = new Event_PowerplayFastTrack();
        //public Event_PowerplaySalary PowerplaySalary = new Event_PowerplaySalary();
        //public Event_PowerplayDefect PowerplayDefect = new Event_PowerplayDefect();
        //public Event_PowerplayJoin PowerplayJoin = new Event_PowerplayJoin();
        //public Event_PowerplayLeave PowerplayLeave = new Event_PowerplayLeave();
        //public Event_PowerplayVote PowerplayVote = new Event_PowerplayVote();
        //public Event_Progress Progress = new Event_Progress();
        //public Event_Promotion Promotion = new Event_Promotion();
        //public Event_ProspectedAsteroid ProspectedAsteroid = new Event_ProspectedAsteroid();
        //#endregion

        //#region Q
        //public Event_QuitACrew QuitACrew = new Event_QuitACrew();
        //#endregion

        //#region R
        //public Event_Rank Rank = new Event_Rank();
        //public Event_RebootRepair RebootRepair = new Event_RebootRepair();
        //public Event_ReceiveText ReceiveText = new Event_ReceiveText();
        //public Event_RedeemVoucher RedeemVoucher = new Event_RedeemVoucher();
        //public Event_RefuelAll RefuelAll = new Event_RefuelAll();
        //public Event_Repair Repair = new Event_Repair();
        //public Event_RepairAll RepairAll = new Event_RepairAll();
        //public Event_RepairDrone RepairDrone = new Event_RepairDrone();
        //public Event_Reputation Reputation = new Event_Reputation();
        //public Event_ReservoirReplenished ReservoirReplenished = new Event_ReservoirReplenished();
        //public Event_RestockVehicle RestockVehicle = new Event_RestockVehicle();
        //public Event_Resurrect Resurrect = new Event_Resurrect();
        //#endregion

        //#region S
        //public Event_SAAScanComplete SAAScanComplete = new Event_SAAScanComplete();
        //public Event_Scan Scan = new Event_Scan();
        //public Event_Scanned Scanned = new Event_Scanned();
        //public Event_Screenshot Screenshot = new Event_Screenshot();
        //public Event_SellDrones SellDrones = new Event_SellDrones();
        //public Event_SellExplorationData SellExplorationData = new Event_SellExplorationData();
        //public Event_SendText SendText = new Event_SendText();
        //public Event_SetUserShipName SetUserShipName = new Event_SetUserShipName();
        //public Event_ShieldState ShieldState = new Event_ShieldState();
        //public Event_ShipTargeted ShipTargeted = new Event_ShipTargeted();
        //public Event_Shipyard Shipyard = new Event_Shipyard();
        //public Event_ShipyardBuy ShipyardBuy = new Event_ShipyardBuy();
        //public Event_ShipyardNew ShipyardNew = new Event_ShipyardNew();
        //public Event_ShipyardSwap ShipyardSwap = new Event_ShipyardSwap();
        //public Event_ShipyardTransfer ShipyardTransfer = new Event_ShipyardTransfer();
        //public Event_Shutdown Shutdown = new Event_Shutdown();
        //public Event_StartJump StartJump = new Event_StartJump();
        //public Event_Statistics Statistics = new Event_Statistics();
        //public Event_StoredModules StoredModules = new Event_StoredModules();
        //public Event_StoredShips StoredShips = new Event_StoredShips();
        //public Event_SupercruiseEntry SupercruiseEntry = new Event_SupercruiseEntry();
        //public Event_SupercruiseExit SupercruiseExit = new Event_SupercruiseExit();
        //public Event_Synthesis Synthesis = new Event_Synthesis();
        //public Event_SystemsShutdown SystemsShutdown = new Event_SystemsShutdown();
        //public Event_ScientificResearch ScientificResearch = new Event_ScientificResearch();
        //public Event_SearchAndRescue SearchAndRescue = new Event_SearchAndRescue();
        //public Event_SelfDestruct SelfDestruct = new Event_SelfDestruct();
        //public Event_SRVDestroyed SRVDestroyed = new Event_SRVDestroyed();
        //public Event_SquadronStartup SquadronStartup = new Event_SquadronStartup();
        //#endregion

        //#region T
        //public Event_TechnologyBroker TechnologyBroker = new Event_TechnologyBroker();
        //public Event_Touchdown Touchdown = new Event_Touchdown();
        //#endregion

        //#region U
        //public Event_UnderAttack UnderAttack = new Event_UnderAttack();
        //public Event_Undocked Undocked = new Event_Undocked();
        //public Event_USSDrop USSDrop = new Event_USSDrop();
        //public Event_Undefined Undefined = new Event_Undefined();
        //#endregion

        //#region V
        //public static Event_VehicleSwitch VehicleSwitch = new Event_VehicleSwitch();
        //#endregion

        //#region W
        //public Event_WingAdd WingAdd = new Event_WingAdd();
        //public Event_WingInvite WingInvite = new Event_WingInvite();
        //public Event_WingJoin WingJoin = new Event_WingJoin();
        //public Event_WingLeave WingLeave = new Event_WingLeave();
        //#endregion

        //#region X
        //#endregion

        //#region Y
        //#endregion

        //#region Z
        //#endregion

        ////End Region: Events
        //#endregion

        //#region Json Events
        //public Event_Masslock Masslock = new Event_Masslock();
        //#endregion
    }
}
