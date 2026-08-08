using System;

namespace ALICE_Internal
{
    public static class IEnums
    {
        #region Custom Event Names
        public static readonly string BlockAirlockWarning = "BlockAirlockWarning";
        public static readonly string BlockLandingPadWarning = "BlockLandingPadWarning";
        public static readonly string Masslock = "Masslock";
        public static readonly string NoFireZone = "NoFireZone";
        public static readonly string StationHostile = "StationHostile";
        #endregion

        #region Journal Event Names
        public static readonly string Music = "Music";
        public static readonly string ReceiveText = "ReceiveText";
        public static readonly string SupercruiseExit = "SupercruiseExit";
        #endregion

        public enum Space
        {
            Unknown,
            Normal,
            Supercruise,
            Hyperspace
        }

        /// <summary>
        /// (Answer) Generic Enum to allow more feedback when doing checks and queries.
        /// </summary>
        public enum A
        {
            Default,
            Postive,
            Negative,
            Error            
        }

        public enum Events
        {
            None,                             //Default Return Value

            //Json Events         
            //Modules,                        //Modules.Json       (Temp Disabled)      
            Shipyard,                         //Shipyard.Json
            Status,                           //Status.Json

            //Shared Events                   
            Cargo,                            //Cargo.Json & Journal Log
            Market,                           //Market.Json & Journal Log
            Outfitting,                       //Outfitting.Json & Journal Log

            //Journal Log Events
            AfmuRepairs,                      //Journal Log
            AppliedToSquadron,                //Journal Log - 2026.08.07
            ApproachBody,                     //Journal Log
            ApproachSettlement,               //Journal Log
            AsteroidCracked,                  //Journal Log
            Backpack,                         //Journal Log - 2026.08.07
            BackpackChange,                   //Journal Log - 2026.08.07
            BookDropship,                     //Journal Log - 2026.08.07
            Bounty,                           //Journal Log
            BuyAmmo,                          //Journal Log
            BuyDrones,                        //Journal Log
            BuyExplorationData,               //Journal Log
            BuyTradeData,                     //Journal Log
            CargoDepot,                       //Journal Log
            CargoTransfer,                    //Journal Log - 2026.08.07
            CarrierBankTransfer,              //Journal Log - 2026.08.07
            CarrierBuy,                       //Journal Log - 2026.08.07
            CarrierCrewServices,              //Journal Log - 2026.08.07
            CarrierDecommission,              //Journal Log - 2026.08.07
            CarrierDepositFuel,               //Journal Log - 2026.08.07
            CarrierDockingPermission,         //Journal Log - 2026.08.07
            CarrierFinance,                   //Journal Log - 2026.08.07
            CarrierJump,                      //Journal Log - 2026.08.07
            CarrierJumpCancelled,             //Journal Log - 2026.08.07
            CarrierJumpRequest,               //Journal Log - 2026.08.07
            CarrierLocation,                  //Journal Log - 2026.08.07
            CarrierStats,                     //Journal Log - 2026.08.07
            CarrierTradeOrder,                //Journal Log - 2026.08.07
            ChangeCrewRole,                   //Journal Log
            ClearSaveGame,                    //Journal Log
            CockpitBreached,                  //Journal Log
            CodexEntry,                       //Journal Log
            CollectCargo,                     //Journal Log
            Commander,                        //Journal Log
            CommitCrime,                      //Journal Log
            CommunityGoal,                    //Journal Log
            CommunityGoalDiscard,             //Journal Log - 2026.08.07
            CommunityGoalJoin,                //Journal Log - 2026.08.07
            CommunityGoalReward,              //Journal Log - 2026.08.07
            CrewAssign,                       //Journal Log
            CrewFire,                         //Journal Log
            CrewHire,                         //Journal Log
            CrewLaunchFighter,                //Journal Log - 2026.08.07
            CrimeVictim,                      //Journal Log - 2026.08.07
            DatalinkScan,                     //Journal Log
            DatalinkVoucher,                  //Journal Log
            DataScanned,                      //Journal Log
            Died,                             //Journal Log
            Disembark,                        //Journal Log - 2026.08.07
            Docked,                           //Journal Log
            DockFighter,                      //Journal Log
            DockingCancelled,                 //Journal Log
            DockingDenied,                    //Journal Log - 2026.08.07
            DockingGranted,                   //Journal Log
            DockingRequested,                 //Journal Log
            DockingTimeout,                   //Journal Log
            DockSRV,                          //Journal Log
            DropshipDeploy,                   //Journal Log - 2026.08.07
            EjectCargo,                       //Journal Log
            Embark,                           //Journal Log - 2026.08.07
            EngineerContribution,             //Journal Log
            EngineerCraft,                    //Journal Log
            EngineerLegacyConvert,            //Journal Log - 2026.08.07
            EngineerProgress,                 //Journal Log
            EscapeInterdiction,               //Journal Log
            FactionKillBond,                  //Journal Log
            FetchRemoteModule,                //Journal Log
            FighterDestroyed,                 //Journal Log
            FighterRebuilt,                   //Journal Log
            Fileheader,                       //Journal Log
            Friends,                          //Journal Log
            FSDJump,                          //Journal Log
            FSDTarget,                        //Journal Log
            FSSAllBodiesFound,                //Journal Log
            FSSDiscoveryScan,                 //Journal Log
            FSSSignalDiscovered,              //Journal Log
            FuelScoop,                        //Journal Log
            HeatDamage,                       //Journal Log
            HeatWarning,                      //Journal Log
            HullDamage,                       //Journal Log
            Interdicted,                      //Journal Log
            JetConeBoost,                     //Journal Log
            JoinedSquadron,                   //Journal Log - 2026.08.07
            LaunchDrone,                      //Journal Log
            LaunchFighter,                    //Journal Log
            LaunchSRV,                        //Journal Log
            LeaveBody,                        //Journal Log
            Liftoff,                          //Journal Log
            LoadGame,                         //Journal Log
            Loadout,                          //Journal Log
            LoadoutEquipModule,               //Journal Log - 2026.08.07
            Location,                         //Journal Log
            MarketBuy,                        //Journal Log
            MarketSell,                       //Journal Log
            MassModuleStore,                  //Journal Log
            MaterialCollected,                //Journal Log
            MaterialDiscovered,               //Journal Log
            Materials,                        //Journal Log
            MaterialTrade,                    //Journal Log
            MiningRefined,                    //Journal Log
            MissionAbandoned,                 //Journal Log
            MissionAccepted,                  //Journal Log
            MissionCompleted,                 //Journal Log
            MissionFailed,                    //Journal Log
            MissionRedirected,                //Journal Log
            Missions,                         //Journal Log
            ModuleBuy,                        //Journal Log
            ModuleInfo,                       //Journal Log
            ModuleRetrieve,                   //Journal Log
            ModuleSell,                       //Journal Log
            ModuleSellRemote,                 //Journal Log
            ModuleStore,                      //Journal Log
            ModuleSwap,                       //Journal Log
            MultiSellExplorationData,         //Journal Log
            Music,                            //Journal Log
            NavBeaconScan,                    //Journal Log
            NavRoute,                         //Journal Log - 2026.08.07
            NavRouteClear,                    //Journal Log - 2026.08.07
            NpcCrewPaidWage,                  //Journal Log
            NpcCrewRank,                      //Journal Log
            PayBounties,                      //Journal Log
            PayFines,                         //Journal Log
            Powerplay,                        //Journal Log
            PowerplayCollect,                 //Journal Log
            PowerplayDefect,                  //Journal Log
            PowerplayDeliver,                 //Journal Log
            PowerplayFastTrack,               //Journal Log
            PowerplayJoin,                    //Journal Log
            PowerplayLeave,                   //Journal Log
            PowerplayMerits,                  //Journal Log - 2026.08.07
            PowerplaySalary,                  //Journal Log
            PowerplayVote,                    //Journal Log
            Progress,                         //Journal Log
            Promotion,                        //Journal Log
            ProspectedAsteroid,               //Journal Log
            QuitACrew,                        //Journal Log
            Rank,                             //Journal Log
            RebootRepair,                     //Journal Log
            ReceiveText,                      //Journal Log
            RedeemVoucher,                    //Journal Log
            RefuelAll,                        //Journal Log
            Repair,                           //Journal Log
            RepairAll,                        //Journal Log
            RepairDrone,                      //Journal Log
            Reputation,                       //Journal Log
            ReservoirReplenished,             //Journal Log
            RestockVehicle,                   //Journal Log
            Resurrect,                        //Journal Log
            SAAScanComplete,                  //Journal Log
            Scan,                             //Journal Log
            ScanBaryCentre,                   //Journal Log - 2026.08.07
            Scanned,                          //Journal Log
            ScientificResearch,               //Journal Log
            Screenshot,                       //Journal Log
            SearchAndRescue,                  //Journal Log
            SelfDestruct,                     //Journal Log
            SellDrones,                       //Journal Log
            SellExplorationData,              //Journal Log
            SendText,                         //Journal Log
            SetUserShipName,                  //Journal Log
            SharedBookmarkToSquadron,         //Journal Log - 2026.08.07
            ShieldState,                      //Journal Log
            ShipLocker,                       //Journal Log - 2026.08.07
            ShipRedeemed,                     //Journal Log - 2026.08.07
            ShipTargeted,                     //Journal Log
            ShipyardBankDeposit,              //Journal Log - 2026.08.07
            ShipyardBuy,                      //Journal Log
            ShipyardNew,                      //Journal Log
            ShipyardRedeem,                   //Journal Log - 2026.08.07
            ShipyardSwap,                     //Journal Log
            ShipyardTransfer,                 //Journal Log
            Shutdown,                         //Journal Log
            SquadronApplicationApproved,      //Journal Log - 2026.08.07
            SquadronDemotion,                 //Journal Log - 2026.08.07
            SquadronPromotion,                //Journal Log - 2026.08.07
            SquadronStartup,                  //Journal Log
            SRVDestroyed,                     //Journal Log
            StartJump,                        //Journal Log
            Statistics,                       //Journal Log
            StoredModules,                    //Journal Log
            StoredShips,                      //Journal Log
            SuitLoadout,                      //Journal Log - 2026.08.07
            SupercruiseDestinationDrop,       //Journal Log - 2026.08.07
            SupercruiseEntry,                 //Journal Log
            SupercruiseExit,                  //Journal Log
            Synthesis,                        //Journal Log
            SystemsShutdown,                  //Journal Log
            TechnologyBroker,                 //Journal Log
            Touchdown,                        //Journal Log            
            UnderAttack,                      //Journal Log
            Undocked,                         //Journal Log
            UseConsumable,                    //Journal Log - 2026.08.07
            USSDrop,                          //Journal Log
            VehicleSwitch,                    //Journal Log
            WingAdd,                          //Journal Log
            WingInvite,                       //Journal Log
            WingJoin,                         //Journal Log
            WingLeave,                        //Journal Log

            //Custom Internal Events
            AliceOnline,                      //Alice Event  

            //Custom Event (Mulit Source)
            BlockAirlock,                     //Alice Event - CommitCrime / Receive Text
            BlockLandingPad,                  //Alice Event - CommitCrime / Receive Text

            //Custom CommitCrime Events              
            Assault,                          //Alice Event
            DisobeyPolice,                    //Alice Event
            DockingTrespass,                  //Alice Event
            DumpingDangerous,                 //Alice Event
            DumpingNearStation,               //Alice Event            
            FireInNoFireZone,                 //Alice Event
            FireInStation,                    //Alice Event
            IllegalCargo,                     //Alice Event
            Interdicting,                     //Alice Event
            Murder,                           //Alice Event
            Piracy,                           //Alice Event
            WrecklessFlying,                  //Alice Event

            //Custom ReceiveText Events
            StationHostile,                   //Alice Event
            StationDamage,                    //Alice Event
            NoFireZone,                       //Alice Event

            //Custom Status.Json Events
            FuelLow,                          //Alice Event
            FuelCritical,                     //Alice Event
            FuelHalfThreshold,                //Alice Event
            Masslock,                         //Alice Event
        }

        public enum CMD
        {
            Default,
            True,
            False,
            Error
        }

        public enum CodexRegion
        {
            NotSet,
            Codex_RegionName_10,
            Codex_RegionName_11,
            Codex_RegionName_12,
            Codex_RegionName_13,
            Codex_RegionName_14,
            Codex_RegionName_15,
            Codex_RegionName_16,
            Codex_RegionName_17,
            Codex_RegionName_18,       //Inner Orion Spur
            Codex_RegionName_19,
            Codex_RegionName_20
        }

        public enum CodexEntry
        {
            NotSet,

            Codex_Ent_L_Cry_MetCry_Red_Name,                  //Rubeus Metallic Crystals
            Codex_Ent_L_Cry_MetCry_Pur_Name,                  //Purpureus Metallic Crystals
            Codex_Ent_L_Cry_MetCry_Gr_Name,                   //Prasinus Metallic Crystals
            Codex_Ent_Gas_Clds_Light_Name,                    //Proto-Lagrange Cloud

            Codex_Ent_Seed_Name,

            Codex_Ent_Gas_Vents_SulphurDioxideMagma_Name,     //Sulphur Dioxide Gas Vent
            Codex_Ent_Fumarole_SulphurDioxideMagma_Name,      //Sulphur Dioxide Fumarole
            Codex_Ent_IceFumarole_WaterGeysers_Name,          //Water Ice Fumarole

            Codex_Ent_Standard_Giant_With_Ammonia_Life_Name,  //Standard Gas Giant
            Codex_Ent_Standard_Giant_With_Water_Life_Name,    //Standard Gas Giant
            Codex_Ent_Standard_Sudarsky_Class_I_Name,         //Standard Gas Giant
            Codex_Ent_Standard_Sudarsky_Class_II_Name,        //Standard Gas Giant
            Codex_Ent_Standard_Sudarsky_Class_III_Name,       //Standard Gas Giant

            Codex_Ent_Standard_Ter_Rocky_Name                 //Non Terraformable

        }

        public enum MusicState
        {
            NotSet,
            CapitalShip,
            Codex,
            Combat_Dogfight,
            Combat_SRV,
            Combat_Unknown,
            Combat_LargeDogFight,
            CQC,
            CQCMenu,
            DestinationFromHyperspace,
            DestinationFromSupercruise,
            DockingComputer,
            Exploration,
            GalacticPowers,
            GalaxyMap,
            Interdiction,
            Lifeform_FogCloud,
            MainMenu,
            NoTrack,
            Supercruise,
            Starport,
            Squadrons,
            SystemAndSurfaceScanner,
            SystemMap,
            Unknown_Exploration,
            Unknown_Encounter,
            Unknown_Settlement
        }

        public static readonly string SystemMap = "SystemMap";
        public static readonly string GalaxyMap = "GalaxyMap";
        public static readonly string GalacticPowers = "GalacticPowers";
        public static readonly string Codex = "Codex";
        public static readonly string Squadrons = "Squadrons";

        #region Environment
        public static readonly string Hyperspace = "Hyperspace";
        public static readonly string Supercruise = "Supercruise";
        public static readonly string Normal_Space = "Normal Space";
        #endregion

        #region Body Types
        public static readonly string Null;
        public static readonly string Station = "Station";
        public static readonly string Star = "Star";
        public static readonly string Planet = "Planet";
        public static readonly string PlanetaryRing = "PlanetaryRing";
        public static readonly string StellarRing = "StellarRing";
        public static readonly string AsteroidCluster = "AsteroidCluser";
        #endregion

        public enum CrimeType
        {
            NotSet,
            Assault,
            MinorBlockingAirlock,
            MajorBlockingAirlock,
            MinorBlockingLandingPad,
            MajorBlockingLandingPad,
            FireInNoFireZone,
            Murder,
            Piracy,
            Interdicting,
            IllegalCargo,
            DisobeyPolice,
            FireInStation,
            DumpingDangerous,
            DumpingNearStation,
            DockingMinor_Trespass,
            DockingMajor_Trespass,
            CollidedAtSpeedInNoFireZone,
            CollidedAtSpeedInNoFireZone_HullDamage
        }

        public enum DockingState
        {
            NotSet,
            Granted,
            Cancelled,
            Denied,
            Requested,
            Timeout,
            Undocked,
            Docked
        }

        public enum DockingDenial
        {
            NotSet,
            ActiveFighter,
            Distance,
            Offences,
            Hostile,
            TooLarge,
            NoSpace,
            NoReason
        }

        #region Docking
        public static readonly string Granted = "Granted";
        public static readonly string Cancelled = "Cancelled";
        public static readonly string Denied = "Denied";
        public static readonly string Requested = "Requested";
        public static readonly string Timeout = "Timeout";
        public static readonly string Undocked = "Undocked";
        public static readonly string Docked = "Docked";

        public static readonly string ActiveFighter = "ActiveFighter";
        public static readonly string Distance = "Distance";
        public static readonly string Offences = "Offences";
        public static readonly string Hositle = "Hostile";
        public static readonly string TooLarge = "TooLarge";
        public static readonly string NoSpace = "NoSpace";
        public static readonly string NoReason = "NoReason";
        #endregion

        #region Panels
        public static readonly string System = "System";
        public static readonly string Role = "Role";
        public static readonly string Target = "Target";
        public static readonly string Comms = "Comms";
        public static readonly string MapGalaxy = "GalaxyMap";
        public static readonly string MapSystem = "SystemMap";
        public static readonly string Starport = "Starport";
        #endregion

        #region FSS Signal Names
        public static readonly string Sig_NavBeacon = "MULTIPLAYER_SCENARIO42_TITLE";
        public static readonly string Sig_RES_Hazardous = "MULTIPLAYER_SCENARIO79_TITLE";
        public static readonly string Sig_RES_High = "MULTIPLAYER_SCENARIO78_TITLE";
        public static readonly string Sig_RES_Low = "MULTIPLAYER_SCENARIO77_TITLE";
        public static readonly string Sig_RES_Regular = "MULTIPLAYER_SCENARIO14_TITLE";
        #endregion

        public static T ToEnum<T>(this string value, bool LogEx = true)
        {
            string MethodName = "To Enum (Conversion)";

            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch (Exception ex)
            {
                if (LogEx)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "(Failed) The Check Hamster Made A Mistake And Returned The Default Solution...");
                }                
                return default(T);
            }
        }
    }
}
