using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using ALICE_Interface;
using ALICE_Events;
using ALICE_Internal;

namespace ALICE_JournalReader
{
    // Jenn Comment.
    public static class JournalReader
    {
        #region Global Variables
        public static decimal EventCount = 0;
        public static decimal TotalEvents = 0;
        private static object ProcessorLock =  new object();
        #endregion

        public static string EventName = "";
        public static string RawLine = "";
        public static string EventTimeStamp = "";        

        public static void EventProcessor()
        {
            string MethodName = "Journal Reader";

            bool LogFileReport = false;
            int LogFileCount = 0;

            #region Log Reader
            if (Monitor.TryEnter(ProcessorLock))
            {
                try
                {
                    do
                    {
                        #region Log File Check
                        try
                        {
                            LogFileCheck:
                            LogFileCheck();
                            if (LogFilePath == "")
                            {
                                // Write To Log Every 20 Seconds
                                if (LogFileReport == false)
                                {
                                    LogFileReport = true;
                                    IPlatform.WriteToInterface("A.L.I.C.E: No Log Files Located, Waiting for Log Files...", "Red");
                                }
                                Thread.Sleep(100);
                                LogFileCount++;
                                if (LogFileCount == 200)
                                {
                                    LogFileReport = false;
                                }
                                goto LogFileCheck;
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.ContactDeveloper();
                            Logger.Exception(MethodName, "Plugin Exception Occured (Log File Check) " + ex);
                        }
                        #endregion

                        try
                        {
                            Start:
                            using (FileStream FS = new FileStream(LogFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            using (StreamReader SR = new StreamReader(FS))
                            {
                                LogStorage = new List<string>();

                                while (!SR.EndOfStream)
                                {
                                    LogStorage.Add(SR.ReadLine());
                                }
                                TotalEvents = LogStorage.Count;
                            }

                            while (EventCount != TotalEvents)
                            {
                                if (TotalEvents < EventCount)
                                {
                                    EventCount = 0;
                                    LogFilePath = "";
                                    LogFileCheck();
                                    IEvents.ExecuteOnline = true;
                                    IEvents.TriggerEvents = false;

                                    Logger.Error(MethodName, "Some Went Wrong With The Journal Log, Attempting To Recover The Reader...", Logger.Red);

                                    goto Start;
                                }

                                RawLine = LogStorage[(int)EventCount];
                                EventName = RawLine.Substring(47, RawLine.IndexOf("\"", 47) - 47);
                                EventTimeStamp = RawLine.Substring(15, 20);

                                #region Event Logic Processor

                                #region A
                                if (EventName == "AfmuRepairs")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.AfmuRepairs>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.AfmuRepairs.Logic();
                                }
                                else if (EventName == "ApproachBody")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ApproachBody>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ApproachBody.Logic();
                                }
                                else if (EventName == "ApproachSettlement")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ApproachSettlement>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ApproachSettlement.Logic();
                                }
                                #endregion

                                #region B
                                else if (EventName == "Bounty")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Bounty>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Bounty.Logic();
                                }
                                else if (EventName == "BuyAmmo")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.BuyAmmo>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.BuyAmmo.Logic();
                                }
                                else if (EventName == "BuyDrones")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.BuyDrones>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.BuyDrones.Logic();
                                }
                                else if (EventName == "BuyExplorationData")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.BuyExplorationData>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.BuyExplorationData.Logic();
                                }
                                else if (EventName == "BuyTradeData")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.BuyTradeData>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.BuyTradeData.Logic();
                                }
                                #endregion

                                #region C
                                else if (EventName == "Cargo")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Cargo>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Cargo.Logic();
                                }
                                else if (EventName == "CargoDepot")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.CargoDepot>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.CargoDepot.Logic();
                                }
                                else if (EventName == "ChangeCrewRole")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ChangeCrewRole>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ChangeCrewRole.Logic();
                                }
                                else if (EventName == "ClearSaveGame")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ClearSaveGame>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ClearSaveGame.Logic();
                                }
                                else if (EventName == "CockpitBreached")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.CockpitBreached>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.CockpitBreached.Logic();
                                }
                                else if (EventName == "CollectCargo")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.CollectCargo>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.CollectCargo.Logic();
                                }
                                else if (EventName == "CodexEntry")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.CodexEntry>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.CodexEntry.Logic();
                                }
                                else if (EventName == "Commander")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Commander>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Commander.Logic();
                                }
                                else if (EventName == "CommitCrime")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.CommitCrime>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.CommitCrime.Logic();
                                }
                                else if (EventName == "CommunityGoal")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.CommunityGoal>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.CommunityGoal.Logic();
                                }
                                else if (EventName == "CrewAssign")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.CrewAssign>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.CrewAssign.Logic();
                                }
                                else if (EventName == "CrewFire")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.CrewFire>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.CrewFire.Logic();
                                }
                                else if (EventName == "CrewHire")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.CrewHire>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.CrewHire.Logic();
                                }
                                #endregion

                                #region D
                                else if (EventName == "DatalinkScan")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.DatalinkScan>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.DatalinkScan.Logic();
                                }
                                else if (EventName == "DataScanned")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.DataScanned>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.DataScanned.Logic();
                                }                            
                                else if (EventName == "Died")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Died>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Died.Logic();
                                }
                                else if (EventName == "DiscoveryScan")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.DiscoveryScan>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.DiscoveryScan.Logic();
                                }
                                else if (EventName == "Docked")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Docked>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Docked.Logic();
                                }
                                else if (EventName == "DockFighter")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.DockFighter>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.DockFighter.Logic();
                                }
                                else if (EventName == "DockingCancelled")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.DockingCancelled>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.DockingCancelled.Logic();
                                }
                                else if (EventName == "DockingDenied")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.DockingDenied>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.DockingDenied.Logic();
                                }
                                else if (EventName == "DockingGranted")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.DockingGranted>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.DockingGranted.Logic();
                                }
                                else if (EventName == "DockingRequested")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.DockingRequested>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.DockingRequested.Logic();
                                }
                                else if (EventName == "DockSRV")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.DockSRV>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.DockSRV.Logic();
                                }
                                #endregion

                                #region E
                                else if (EventName == "EjectCargo")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.EjectCargo>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.EjectCargo.Logic();
                                }
                                else if (EventName == "EngineerContribution")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.EngineerContribution>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.EngineerContribution.Logic();
                                }
                                else if (EventName == "EngineerCraft")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.EngineerCraft>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.EngineerCraft.Logic();
                                }
                                else if (EventName == "EngineerProgress")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.EngineerProgress>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.EngineerProgress.Logic();
                                }
                                else if (EventName == "EscapeInterdiction")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.EscapeInterdiction>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.EscapeInterdiction.Logic();
                                }
                                #endregion

                                #region F
                                else if (EventName == "FactionKillBond")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.FactionKillBond>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.FactionKillBond.Logic();
                                }
                                else if (EventName == "FetchRemoteModule")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.FetchRemoteModule>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.FetchRemoteModule.Logic();
                                }
                                else if (EventName == "FighterDestroyed")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.FighterDestroyed>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.FighterDestroyed.Logic();
                                }
                                else if (EventName == "FighterRebuilt")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.FighterRebuilt>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.FighterRebuilt.Logic();
                                }
                                else if (EventName == "Fileheader")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Fileheader>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Fileheader.Logic();
                                }
                                else if (EventName == "Friends")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Friends>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Friends.Logic();
                                }
                                else if (EventName == "FSDJump")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.FSDJump>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.FSDJump.Logic();
                                }
                                else if (EventName == "FSDTarget")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.FSDTarget>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.FSDTarget.Logic();
                                }
                                else if (EventName == "FSSAllBodiesFound")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.FSSAllBodiesFound>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.FSSAllBodiesFound.Logic();
                                }
                                else if (EventName == "FSSDiscoveryScan")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.FSSDiscoveryScan>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.FSSDiscoveryScan.Logic();
                                }
                                else if (EventName == "FSSSignalDiscovered")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.FSSSignalDiscovered>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.FSSSignalDiscovered.Logic();
                                }
                                else if (EventName == "FuelScoop")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.FuelScoop>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.FuelScoop.Logic();
                                }
                                #endregion

                                #region H
                                else if (EventName == "HeatDamage")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.HeatDamage>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.HeatDamage.Logic();
                                }
                                else if (EventName == "HeatWarning")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.HeatWarning>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.HeatWarning.Logic();
                                }
                                else if (EventName == "HullDamage")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.HullDamage>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.HullDamage.Logic();
                                }
                                #endregion

                                #region I
                                else if (EventName == "Interdicted")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Interdicted>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Interdicted.Logic();
                                }
                                #endregion

                                #region J
                                else if (EventName == "JetConeBoost")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.JetConeBoost>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.JetConeBoost.Logic();
                                }
                                #endregion

                                #region L
                                else if (EventName == "LaunchDrone")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.LaunchDrone>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.LaunchDrone.Logic();
                                }
                                else if (EventName == "LaunchFighter")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.LaunchFighter>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.LaunchFighter.Logic();
                                }
                                else if (EventName == "LaunchSRV")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.LaunchSRV>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.LaunchSRV.Logic();
                                }
                                else if (EventName == "LeaveBody")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.LeaveBody>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.LeaveBody.Logic();
                                }
                                else if (EventName == "Liftoff")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Liftoff>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Liftoff.Logic();
                                }
                                else if (EventName == "LoadGame")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.LoadGame>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.LoadGame.Logic();
                                }
                                else if (EventName == "Loadout")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Loadout>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Loadout.Logic();
                                }
                                else if (EventName == "Location")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Location>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Location.Logic();
                                }
                                #endregion

                                #region M
                                else if (EventName == "Market")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Market>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Market.Logic();
                                }
                                else if (EventName == "MarketBuy")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MarketBuy>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MarketBuy.Logic();
                                }
                                else if (EventName == "MarketSell")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MarketSell>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MarketSell.Logic();
                                }
                                else if (EventName == "MassModuleStore")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MassModuleStore>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MassModuleStore.Logic();
                                }
                                else if (EventName == "MaterialCollected")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MaterialCollected>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MaterialCollected.Logic();
                                }
                                else if (EventName == "MaterialDiscovered")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MaterialDiscovered>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MaterialDiscovered.Logic();
                                }
                                else if (EventName == "Materials")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Materials>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Materials.Logic();
                                }
                                else if (EventName == "MaterialTrade")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MaterialTrade>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MaterialTrade.Logic();
                                }
                                else if (EventName == "MiningRefined")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MiningRefined>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MiningRefined.Logic();
                                }
                                else if (EventName == "MissionAbandoned")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MissionAbandoned>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MissionAbandoned.Logic();
                                }
                                else if (EventName == "MissionAccepted")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MissionAccepted>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MissionAccepted.Logic();
                                }
                                else if (EventName == "MissionCompleted")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MissionCompleted>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MissionCompleted.Logic();
                                }
                                else if (EventName == "MissionFailed")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MissionFailed>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MissionFailed.Logic();
                                }
                                else if (EventName == "MissionRedirected")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MissionRedirected>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MissionRedirected.Logic();
                                }
                                else if (EventName == "Missions")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Missions>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Missions.Logic();
                                }
                                else if (EventName == "ModuleBuy")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ModuleBuy>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ModuleBuy.Logic();
                                }
                                else if (EventName == "ModuleInfo")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ModuleInfo>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ModuleInfo.Logic();
                                }
                                else if (EventName == "ModuleRetrieve")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ModuleRetrieve>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ModuleRetrieve.Logic();
                                }
                                else if (EventName == "ModuleSell")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ModuleSell>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ModuleSell.Logic();
                                }
                                else if (EventName == "ModuleSellRemote")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ModuleSellRemote>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ModuleSellRemote.Logic();
                                }
                                else if (EventName == "ModuleStore")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ModuleStore>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ModuleStore.Logic();
                                }
                                else if (EventName == "ModuleSwap")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ModuleSwap>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ModuleSwap.Logic();
                                }
                                else if (EventName == "MultiSellExplorationData")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.MultiSellExplorationData>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.MultiSellExplorationData.Logic();
                                }
                                else if (EventName == "Music")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Music>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Music.Logic();
                                }
                                #endregion

                                #region N
                                else if (EventName == "NavBeaconScan")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.NavBeaconScan>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.NavBeaconScan.Logic();
                                }
                                else if (EventName == "NpcCrewPaidWage")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.NpcCrewPaidWage>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.NpcCrewPaidWage.Logic();
                                }
                                else if (EventName == "NpcCrewRank")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.NpcCrewRank>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.NpcCrewRank.Logic();
                                }
                                #endregion

                                #region O
                                else if (EventName == "Outfitting")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Outfitting>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Outfitting.Logic();
                                }
                                #endregion

                                #region P
                                else if (EventName == "PayBounties")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.PayBounties>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.PayBounties.Logic();
                                }
                                else if (EventName == "PayFines")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.PayFines>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.PayFines.Logic();
                                }
                                else if (EventName == "Powerplay")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Powerplay>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Powerplay.Logic();
                                }
                                else if (EventName == "PowerplayCollect")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.PowerplayCollect>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.PowerplayCollect.Logic();
                                }
                                else if (EventName == "PowerplayDefect")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.PowerplayDefect>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.PowerplayDefect.Logic();
                                }
                                else if (EventName == "PowerplayDeliver")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.PowerplayDeliver>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.PowerplayDeliver.Logic();
                                }
                                else if (EventName == "PowerplayFastTrack")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.PowerplayFastTrack>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.PowerplayFastTrack.Logic();
                                }
                                else if (EventName == "PowerplayJoin")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.PowerplayJoin>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.PowerplayJoin.Logic();
                                }
                                else if (EventName == "PowerplayLeave")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.PowerplayLeave>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.PowerplayLeave.Logic();
                                }
                                else if (EventName == "PowerplaySalary")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.PowerplaySalary>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.PowerplaySalary.Logic();
                                }
                                else if (EventName == "PowerplayVote")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.PowerplayVote>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.PowerplayVote.Logic();
                                }
                                else if (EventName == "Progress")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Progress>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Progress.Logic();
                                }
                                else if (EventName == "Promotion")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Promotion>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Promotion.Logic();
                                }
                                else if (EventName == "ProspectedAsteroid")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ProspectedAsteroid>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ProspectedAsteroid.Logic();
                                }
                                #endregion

                                #region Q
                                else if (EventName == "QuitACrew")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.QuitACrew>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.QuitACrew.Logic();
                                }
                                #endregion

                                #region R
                                else if (EventName == "Rank")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Rank>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Rank.Logic();
                                }
                                else if (EventName == "RebootRepair")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.RebootRepair>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.RebootRepair.Logic();
                                }
                                else if (EventName == "ReceiveText")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ReceiveText>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ReceiveText.Logic();
                                }
                                else if (EventName == "RedeemVoucher")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.RedeemVoucher>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.RedeemVoucher.Logic();
                                }
                                else if (EventName == "RefuelAll")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.RefuelAll>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.RefuelAll.Logic();
                                }
                                else if (EventName == "Repair")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Repair>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Repair.Logic();
                                }
                                else if (EventName == "RepairAll")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.RepairAll>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.RepairAll.Logic();
                                }
                                else if (EventName == "RepairDrone")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.RepairDrone>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.RepairDrone.Logic();
                                }
                                else if (EventName == "Reputation")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Reputation>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Reputation.Logic();
                                }
                                else if (EventName == "ReservoirReplenished")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ReservoirReplenished>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ReservoirReplenished.Logic();
                                }
                                else if (EventName == "RestockVehicle")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.RestockVehicle>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.RestockVehicle.Logic();
                                }
                                else if (EventName == "Resurrect")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Resurrect>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Resurrect.Logic();
                                }
                                #endregion

                                #region S
                                else if (EventName == "SAAScanComplete")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SAAScanComplete>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SAAScanComplete.Logic();
                                }
                                else if (EventName == "Scan")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Scan>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Scan.Logic();
                                }
                                else if (EventName == "Scanned")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Scanned>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Scanned.Logic();
                                }
                                else if (EventName == "ScientificResearch")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ScientificResearch>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ScientificResearch.Logic();
                                }
                                else if (EventName == "Screenshot")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Screenshot>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Screenshot.Logic();
                                }
                                else if (EventName == "SearchAndRescue")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SearchAndRescue>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SearchAndRescue.Logic();
                                }
                                else if (EventName == "SelfDestruct")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SelfDestruct>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SelfDestruct.Logic();
                                }
                                else if (EventName == "SellDrones")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SellDrones>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SellDrones.Logic();
                                }
                                else if (EventName == "SellExplorationData")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SellExplorationData>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SellExplorationData.Logic();
                                }
                                else if (EventName == "SendText")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SendText>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SendText.Logic();
                                }
                                else if (EventName == "SetUserShipName")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SetUserShipName>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SetUserShipName.Logic();
                                }
                                else if (EventName == "ShieldState")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ShieldState>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ShieldState.Logic();
                                }
                                else if (EventName == "ShipTargeted")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ShipTargeted>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ShipTargeted.Logic();
                                }
                                else if (EventName == "Shipyard")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Shipyard>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Shipyard.Logic();
                                }
                                else if (EventName == "ShipyardBuy")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ShipyardBuy>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ShipyardBuy.Logic();
                                }
                                else if (EventName == "ShipyardNew")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ShipyardNew>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ShipyardNew.Logic();
                                }
                                else if (EventName == "ShipyardSwap")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ShipyardSwap>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ShipyardSwap.Logic();
                                }
                                else if (EventName == "ShipyardTransfer")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.ShipyardTransfer>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.ShipyardTransfer.Logic();
                                }
                                else if (EventName == "Shutdown")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Shutdown>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Shutdown.Logic();
                                }
                                else if (EventName == "SquadronStartup")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SquadronStartup>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SquadronStartup.Logic();
                                }
                                else if (EventName == "SRVDestroyed")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SRVDestroyed>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SRVDestroyed.Logic();
                                }
                                else if (EventName == "StartJump")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.StartJump>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.StartJump.Logic();
                                }
                                else if (EventName == "Statistics")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Statistics>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Statistics.Logic();
                                }
                                else if (EventName == "StoredModules")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.StoredModules>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.StoredModules.Logic();
                                }
                                else if (EventName == "StoredShips")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.StoredShips>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.StoredShips.Logic();
                                }
                                else if (EventName == "SupercruiseEntry")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SupercruiseEntry>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SupercruiseEntry.Logic();
                                }
                                else if (EventName == "SupercruiseExit")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SupercruiseExit>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SupercruiseExit.Logic();
                                }
                                else if (EventName == "Synthesis")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Synthesis>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Synthesis.Logic();
                                }
                                else if (EventName == "SystemsShutdown")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.SystemsShutdown>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.SystemsShutdown.Logic();
                                }
                                #endregion

                                #region T
                                else if (EventName == "TechnologyBroker")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.TechnologyBroker>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.TechnologyBroker.Logic();
                                }
                                else if (EventName == "Touchdown")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Touchdown>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Touchdown.Logic();
                                }
                                #endregion

                                #region U
                                else if (EventName == "UnderAttack")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.UnderAttack>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.UnderAttack.Logic();
                                }
                                else if (EventName == "Undocked")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Undocked>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.Undocked.Logic();
                                }
                                else if (EventName == "USSDrop")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.USSDrop>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.USSDrop.Logic();
                                }
                                #endregion

                                #region V
                                else if (EventName == "VehicleSwitch")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.VehicleSwitch>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.VehicleSwitch.Logic();
                                }
                                #endregion

                                #region W
                                else if (EventName == "WingAdd")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.WingAdd>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.WingAdd.Logic();
                                }
                                else if (EventName == "WingInvite")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.WingInvite>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.WingInvite.Logic();
                                }
                                else if (EventName == "WingJoin")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.WingJoin>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.WingJoin.Logic();
                                }
                                else if (EventName == "WingLeave")
                                {
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.WingLeave>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    IEvents.WingLeave.Logic();
                                }
                                #endregion

                                else //Undefined or New Event
                                {
                                    EventName = "Undefined";
                                    var Event = JsonConvert.DeserializeObject<ALICE_Events.Undefined>(RawLine);
                                    IEvents.UpdateEvents(EventName, Event);
                                    Logger.DevUpdateLog(MethodName, "I've Found A New/Untracked Event: " + EventName + " Event Recorded In The Develoer Update Log.", Logger.Purple);
                                    Logger.DevUpdateLog(MethodName, RawLine , Logger.Purple);
                                    //IEvents.RecordUndefinedEvent(RawLine);
                                    IEvents.Undefined.Logic();
                                }
                                #endregion

                                EventCount++;

                                //Enable Events & Execute Online Event
                                if (EventCount == TotalEvents && IEvents.ExecuteOnline == true)
                                {
                                    Logger.Simple("Project A.L.I.C.E " + IPlatform.Version + " Loaded, Ready for Orders.", "Purple");                                    
                                    IEvents.Online();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Exception(MethodName, "Skipping Event, Attempting To Continue Processing Remaining Events...");
                            Logger.ContactDeveloper();
                            Logger.Exception(MethodName, "Event Information: Event = " + EventName + " | Time Stamp = " + EventTimeStamp);
                            Logger.Exception(MethodName, "Plugin Exception Occured (Event Check) " + ex);

                            //Attempt To Skip Affected Event...
                            EventCount++;
                        }
                        finally { }

                        Thread.Sleep(100);

                    } while (true);
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Attempting To Recover The Log Reader... (Wait 5 Seconds)");
                    Logger.ContactDeveloper();
                    Logger.Exception(MethodName, "Plugin Exception Occured (Journal Log Reader) " + ex);
                }
                finally
                {
                    //Interface Manager - Send Command To Restart Log after 5 seconds.
                    Monitor.Exit(ProcessorLock);
                }
            }
            #endregion
        }

        #region Log Checks
        private static string LogFilePath = "";
        private static string NewFilePath = "";        
        private static List<string> LogStorage;
        private static DateTime TimeStamp;
        private static FileInfo TargetLogFile;

        public static void LogFileCheck()
        {
            try
            {
                DirectoryInfo GameDir = new DirectoryInfo(Paths.LogDirectory);
                string CurrentFile = "";

                foreach (FileInfo LogFile in GameDir.EnumerateFiles("Journal*.*.*.log", SearchOption.TopDirectoryOnly))
                {
                    if (TargetLogFile is null && TimeStamp < LogFile.LastWriteTime)
                    {
                        //New File, lets get it setup.
                        TargetLogFile = LogFile;
                        TimeStamp = LogFile.LastWriteTime;
                    }
                    else if (TimeStamp < LogFile.LastWriteTime)
                    {
                        //Same File, lets update the time stamp.
                        TimeStamp = LogFile.LastWriteTime;
                    }
                    else
                    {
                        TargetLogFile = null;
                    }

                    if (TargetLogFile != null)
                    {
                        NewFilePath = LogFile.FullName;
                        CurrentFile = LogFile.Name;
                    }
                }

                GameDir = null;

                //Lets Update the File Path if needed.
                if (LogFilePath != NewFilePath)
                {
                    if (CurrentFile != "")
                    {
                        Logger.Simple("Elite Dangerous Log: " + CurrentFile, "Purple");
                    }
                    LogFilePath = NewFilePath;
                    EventCount = 0;
                }

                TargetLogFile = null;
            }
            catch (Exception ex)
            {
                IPlatform.WriteToInterface("------------------------------------------------------------------------------------------------------------------------------", "Red");
                Logger.ContactDeveloper();
                IPlatform.WriteToInterface("A.L.I.C.E: Plugin Exception Occured (Log Detection) " + ex, "Red");
                IPlatform.WriteToInterface("------------------------------------------------------------------------------------------------------------------------------", "Red");

            }
        }
        #endregion
    }

    #region Journal Events (Remaining Events For Conversion)

    #region Event Constructors
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

    public class UndefinedEvent : Base
    {
        //Use this when you want to log the entire event.
    }
    #endregion

    #region CommunityGoalJoin Event
    public class CommunityGoalJoin : Base
    {
        public string Name { get; set; }
        public string System { get; set; }
    }
    #endregion

    #region CommunityGoalReward Event
    public class CommunityGoalReward : Base
    {
        public decimal CGID { get; set; }
        public string Name { get; set; }
        public string System { get; set; }
        public decimal Reward { get; set; }
    }
    #endregion

    #region CrewMemberJoins Event
    public class CrewMemberJoins : Base
    {
        public string Crew { get; set; }
    }
    #endregion

    #region CrewMemberRoleChange Event
    public class CrewMemberRoleChange : Base
    {
        public string Crew { get; set; }
        public string Role { get; set; }
    }
    #endregion

    #region EngineerApply Event
    public class EngineerApply : Base
    {
        public string Engineer { get; set; }
        public string Blueprint { get; set; }
        public decimal Level { get; set; }
    }
    #endregion

    #region Interdiction Event
    public class Interdiction : Base
    {
        public string Success { get; set; }
        public bool IsPlayer { get; set; }
        public string Faction { get; set; }
    }
    #endregion

    #region JoinACrew Event
    public class JoinACrew : Base
    {
        public string Captain { get; set; }
    }
    #endregion

    #region MaterialDiscarded Event
    public class MaterialDiscarded : Base
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Count { get; set; }
    }
    #endregion

    #region PayLegacyFines Event
    public class PayLegacyFines : Base
    {
        public decimal Amount { get; set; }
    }
    #endregion

    #region ShipyardSell Event
    public class ShipyardSell : Base
    {
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public decimal SellShipID { get; set; }
        public decimal ShipPrice { get; set; }
        public decimal MarketID { get; set; }
        public string System { get; set; }
        public decimal ShipMarketID { get; set; }
    }
    #endregion

    #endregion
}