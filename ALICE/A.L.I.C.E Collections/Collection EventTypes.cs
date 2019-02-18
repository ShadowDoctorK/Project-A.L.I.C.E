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
    /// Custom Collection that handles EventType storage and the controls to interface with the Collection.   
    /// </summary>
    public class CollectionEventTypes
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
                { IEnums.Events.AsteroidCracked, typeof(AsteroidCracked) },
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
                { IEnums.Events.ProspectedAsteroid, typeof(ProspectedAsteroid) },
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
        /// <returns>Pass, Fail or Error</returns>
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
        /// <returns>Pass, Fail or Error</returns>
        public A Exists(string S, bool LogEx = true)
        {
            string MethodName = "Event (Exists)";
            IEnums.Events E = IEnums.Events.None;

            try
            {
                E = IEnums.ToEnum<IEnums.Events>(S, LogEx);
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
        /// <returns>Returns Event Type or Null</returns>
        public Type Get(IEnums.Events E, bool Override = true)
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
        public Type Get(string S, bool Override = true)
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
