using System;
using ALICE_Internal;
using System.Collections.Generic;

namespace ALICE_Interface
{
    public static partial class ICommands
    {

        public static readonly string M = "Plugin (ICommands)";

        public static void Invoke(string Command)
        {
            ICommands.Search(Process(Command), Command);
        }

        public enum L0
        {
            FailToConvert,
            Synthesizer,
            Plugin,
            Actions,
            Panel,
            Target,
            Orders,
            Reports,
            Power,
            Interaction,
            Override,            
        }

        private static List<string> Process(string S)
        {
            try
            {
                //Temp List
                List<string> List = new List<string>();

                //Split Incomming Command
                string[] Temp = S.Split(':');

                //Remove Whitespace
                foreach (var Item in Temp)
                {
                    List.Add(Item.Trim());
                }

                //Add Empty Buffer To List
                List.Add("(Blank)");
                List.Add("(Blank)");
                List.Add("(Blank)");
                List.Add("(Blank)");
                List.Add("(Blank)");

                return List;
            }
            catch (Exception ex)
            {
                Logger.Exception("Plugin (Process)", "Execption: " + ex);
                return new List<string> { "!Exception!" };
            }
        }

        private static bool Check(this List<string> Str, int I, string S)
        {
            //Check Index Is Valid
            if (Str.Count - 1 >= I)
            {
                //Compair Index Value To Check Value
                if (Str[I].ToLower().Contains(S.ToLower()))
                {
                    //Debug Logger
                    Logger.DebugLine("Plugin (Check)", "[Pass] Contains \"" + S + "\"", Logger.Green);

                    //Passed, Return True
                    return true;
                }
            }

            //Failed, Return False
            return false;
        }

        public static T Lookup<T>(this string S)
        {
            string M = "Plugin (Enum)";

            try
            {
                //Replace Spaces And Convert
                var Temp = (T)Enum.Parse(typeof(T), 
                            S.Replace(" ", "_")     //Replace Spaces
                             .Replace("-", "_")     //Replace Tac
                             .Replace(".", "_"),    //Replace Periods
                            true);

                //Debug Logger
                Logger.DebugLine(M, "[Pass] Valid Command: " + S, Logger.Blue);

                //Return
                return Temp;
            }
            catch (Exception)
            {
                //Debug Logger
                Logger.DebugLine(M, "[Fail] Invalid Command: " + S, Logger.Yellow);

                //Return
                return default(T);
            }
        }

        /// <summary>
        /// Standard function to log invalid activators.
        /// </summary>
        /// <param name="M">(Method) The simple name of the calling method.</param>
        /// <param name="S">(Strings) List of strings.</param>
        /// <param name="I">(Index) Index for the invalid activator.</param>
        public static void LogInvalid(string M, List<string> S, int I)
        {
            //Don't Log "(Blank)"
            if (S[I] == "(Blank)") { return; }

            //Construct Command
            string Temp = ""; foreach (var Item in S)
            {                
                if (Item != "(Blank)")
                {
                    //Add ":"
                    if (Temp != "") { Temp = Temp + ": "; }

                    //Add Item
                    Temp = Temp + Item;
                }
            }

            //Log Items
            Logger.Log(M, Temp, Logger.Yellow);
            Logger.Log(M, S[I] + " Is Not A Valid Option.", Logger.Yellow);
        }

        public static void Search(List<string> Command, string CMD)
        {
            //Convert To Enum And Process           
            switch (Command[0].Lookup<L0>())
            {
                case L0.Synthesizer:
                    //Under Construction
                    return;

                case L0.Plugin:
                    CMDPlugin.Search(Command);
                    return;

                case L0.Actions:
                    CMDActions.Search(Command);
                    return;

                case L0.Panel:
                    CMDPanels.Search(Command);
                    return;

                case L0.Target:
                    CMDTarget.Search(Command);
                    return;

                case L0.Orders:
                    CMDOrder.Search(Command);
                    return;

                case L0.Reports:
                    CMDReport.Search(Command);
                    return;

                case L0.Power:
                    CMDPower.Search(Command);
                    return;

                case L0.Interaction:
                    CMDInteraction.Search(Command);
                    return;

                default:
                    ICommands.LogInvalid(ICommands.M, Command, 0);
                    return;
            }
        }
    }

    public class Commands
    {
        public enum L1
        {
            //====== Default Return ======
            FailToConvert,

            #region Synthesizer
            //Under Construction
            #endregion

            #region Plugin
            Initialize,
            Pip_Speed,
            Panel_Speed,
            Fire_Group_Speed,
            Throttle_Speed,
            Extended_Logging,
            Debug_Mode,
            Variable_Mode,
            Monitor_Status,
            Master_Audio,
            Logger,
            #endregion

            #region Actions
            Override,
            Docking,
            Fighter,
            Throttle,
            Cargo_Scoop,
            Frame_Shift_Drive,
            Lights,
            Landing_Gear,
            Slient_Running,
            Hardpoints,
            Heatsink,
            Shield_Cell,
            Chaff,
            Cargo_Scanner,
            Composite_Scanner,
            Discovery_Scanner,
            Full_Spectrum_Scanner,
            Surface_Scanner,
            Xeno_Scanner,
            Night_Vision,
            Flight_Assist,
            Launch,
            Wake_Scanner,
            ECM,
            Field_Neutraliser,
            FSD_Interdictor,
            Mining_Laser,
            Kill_Warrent_Scanner,
            Collector_Limpet,
            Decontamination_Limpet,
            Fuel_Limpet,
            Hatch_Breaker_Limpet,
            Prospector_Limpet,
            Recon_Limpet,
            Repair_Limpet,
            Research_Limpet,
            Landing,
            #endregion

            #region Panels
            Close,
            Target,
            Comms,
            Role,
            System,
            Galaxy_Map,
            System_Map,
            #endregion

            #region Targeting
            Wingman_One,
            Wingman_Two,
            Wingman_Three,
            Subsystem,
            Hostile,
            General,
            Scan,
            #endregion

            #region Orders
            System_Scans,
            Docking_Procedures,
            Station_Refuel,
            Station_Rearm,
            Station_Repair,
            Hanger_Entry,
            Assisted_Power,
            Post_Jump_Safety,
            Weapon_Safety,
            #endregion

            #region Reports
            No_Fire_Zone,
            Wanted_Target,
            Hostile_Faction,
            Collected_Bounties,
            Collected_Materials,
            Refined_Materials,
            Station_Status,
            Shield_State,
            Masslock,
            Fuel_Scooping,
            Fuel_Report,
            #endregion

            #region Power
            Set,
            Manager,
            Restore,
            Weapons,
            Engines,
            Systems,
            #endregion

            #region Interactions
            Response,
            //General - Shared
            Custom
            #endregion
        }

        public enum L2
        {
            //====== Default Return ======
            FailToConvert,
            
            Increase,
            Decrease,
            Enable,
            Disable,
            Toggle,            
            Request,
            Cancel,
            Prepair,
            Activate,
            Next,
            Previous,

            #region Targeting
            //====== Wingman Items ======
            Nav_Lock,
            Target,

            //====== Subsystems ======
            Shield_Generator,
            Cargo_Hatch,
            FSD_Interdictor,
            Power_Distributor,
            Life_Support,
            Hyperdrive,
            Power_Plant,
            //Engines - Shared
            Cargo_Scanner,

            //====== Series Scans ======
            Setting,
            General,
            Hostile,
            Pause,
            Unpause,
            Stop,
            Blacklist,
            Whitelist,
            #endregion

            #region Navigation
            Supercruise,
            Hyperspace,
            Disengage,           
            #endregion

            #region Fire Groups
            Select,
            Mode,
            Weapons,
            Assign,
            Default,
            Update,
            #endregion

            #region Fighters
            //====== Actions ======
            Deploy,

            //====== Orders ======
            Attack_My_Target,
            Defend,
            Engage_At_Will,
            Follow,
            Hold,
            Maintain,
            Recall,
            Retract,
            #endregion

            #region Throttles
            Boost,
            S0,
            S5,
            S10,
            S15,
            S20,
            S25,
            S30,
            S35,
            S40,
            S45,
            S50,
            S55,
            S60,
            S65,
            S70,
            S75,
            S80,
            S85,
            S90,
            S95,
            S100,
            #endregion

            #region Panels
            //====== Target Panel ======
            Navigation,
            Transactions,
            Contacts,

            //====== Comms Panel ======
            Chat,
            Inbox,
            Social,
            History,
            Squadron,
            Settings,

            //====== Role Panel ======
            All,
            Helm,
            Fighters,
            SRV,
            Crew,
            Help,

            //====== System Panel ======
            Home,
            Modules,
            Fire_Groups,
            Ship,
            Inventory,
            Status,
            Media,

            //====== Galaxy Map ======
            Open, 
            Close,
            Info,
            Search,
            Bookmarks,
            Configuration,
            Options,
            #endregion

            #region Power
            //====== Pip Controls ======
            One,
            Two,
            Three,
            Four,

            //====== Assisted Manager ======
            Maintain_Engines,
            Maintain_Systems,
            Defense,
            Offense,
            Engines,
            Systems,
            Heavy,
            Balance,
            Light,
            #endregion

            #region Overrides
            //Crew - Shared
            //Weapons - Shared
            #endregion
        }

        public enum L3
        {
            //====== Default Return ======
            FailToConvert,

            Player,
            Crew,
            Select,
            Activate,
            Combat,
            Analysis,
            Toggle,
            Mark,
            One,
            Two,
            Three,
            Four,
            Postitive,
            Negative,
            Series,
            Stop,

            #region Panels
            //====== Navigation Tab ======
            Set_Locations,
            Reset_Locations,
            Set_Filters,
            Galaxy_Map,
            System_Map,

            //====== Transactions Tab ======
            All,
            Missions,
            Passengers,
            Claims,
            Fines,
            Bounties,

            //====== Home Tab ======
            Galnet_Today,
            Holo_Me,
            Engineers,
            Codex,
            Squadrons,
            Galatic_Powers,

            //====== Ship Tab ======
            Functions,
            Preferences,
            Statistics,

            //====== Inventory Tab ======
            Ships_Cargo,
            Refinery,
            Materials,
            Data,
            Synthesis,
            Cabins,

            //====== Status Tab ======
            System_Factions,
            Reputation,
            Session_Log,
            Finance,
            Permits,

            //====== Bookmarks Tab ======
            Plot,
            Reset,
            #endregion

            #region Targeting
            //====== Settings ======
            Blacklist,
            Hostile_Faction,
            Detailed_Scan,
            Wanted,

            //====== Black And White List ======
            Add_Pilot,
            Add_Faction,
            Clear_All
            #endregion
        }

        public enum L4
        {
            //====== Default Return ======
            FailToConvert,

            Enable,
            Disable
        }

        /// <summary>
        /// Enum Used To Build Switch Logic Which Allows Access To Responses And Interactions.
        /// </summary>
        public enum R1
        {   
            //====== Default Return ======
            FailToConvert,

            #region Response Checks
            Yes,
            No,
            Mark,
            #endregion

            #region General Interactions
            ALICE,
            I_Love_You,
            Thank_You
            #endregion
        }
    }
}