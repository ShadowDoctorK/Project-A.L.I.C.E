//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-07T10:54:57Z", "event":"Statistics", "Bank_Account":{ "Current_Wealth":1906944578, "Spent_On_Ships":479577540, "Spent_On_Outfitting":569137977, "Spent_On_Repairs":2828425, "Spent_On_Fuel":116440, "Spent_On_Ammo_Consumables":499018, "Insurance_Claims":24, "Spent_On_Insurance":74328387 }, "Combat":{ "Bounties_Claimed":403, "Bounty_Hunting_Profit":22291478, "Combat_Bonds":242, "Combat_Bond_Profits":6563339, "Assassinations":1, "Assassination_Profits":10000, "Highest_Single_Reward":540269, "Skimmers_Killed":180 }, "Crime":{ "Notoriety":0, "Fines":62, "Total_Fines":1574271, "Bounties_Received":628, "Total_Bounties":1429645, "Highest_Bounty":10000 }, "Smuggling":{ "Black_Markets_Traded_With":6, "Black_Markets_Profits":494806, "Resources_Smuggled":106, "Average_Profit":70686.571428571, "Highest_Single_Transaction":485900 }, "Trading":{ "Markets_Traded_With":57, "Market_Profits":32073012, "Resources_Traded":22389, "Average_Profit":121950.61596958, "Highest_Single_Transaction":2726336 }, "Mining":{ "Mining_Profits":8354903, "Quantity_Mined":508, "Materials_Collected":8405 }, "Exploration":{ "Systems_Visited":1896, "Exploration_Profits":34946948, "Planets_Scanned_To_Level_2":144, "Planets_Scanned_To_Level_3":371, "Highest_Payout":1653085, "Total_Hyperspace_Distance":87761, "Total_Hyperspace_Jumps":2851, "Greatest_Distance_From_Start":12990.674998588, "Time_Played":3660360 }, "Passengers":{ "Passengers_Missions_Accepted":242, "Passengers_Missions_Disgruntled":0, "Passengers_Missions_Bulk":1531, "Passengers_Missions_VIP":538, "Passengers_Missions_Delivered":2069, "Passengers_Missions_Ejected":2 }, "Search_And_Rescue":{ "SearchRescue_Traded":0, "SearchRescue_Profit":0, "SearchRescue_Count":0 }, "TG_ENCOUNTERS":{ "TG_ENCOUNTER_TOTAL":2, "TG_ENCOUNTER_TOTAL_LAST_SYSTEM":"Pleiades Sector YP-O b6-1", "TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP":"3304-06-28 01:02", "TG_ENCOUNTER_TOTAL_LAST_SHIP":"Alliance Chieftain", "TG_SCOUT_COUNT":2 }, "Crafting":{ "Count_Of_Used_Engineers":13, "Recipes_Generated":795, "Recipes_Generated_Rank_1":227, "Recipes_Generated_Rank_2":181, "Recipes_Generated_Rank_3":170, "Recipes_Generated_Rank_4":144, "Recipes_Generated_Rank_5":73 }, "Crew":{ "NpcCrew_TotalWages":88044645, "NpcCrew_Hired":3, "NpcCrew_Died":3 }, "Multicrew":{ "Multicrew_Time_Total":46135, "Multicrew_Gunner_Time_Total":24833, "Multicrew_Fighter_Time_Total":20195, "Multicrew_Credits_Total":10305372, "Multicrew_Fines_Total":41700 }, "Material_Trader_Stats":{ "Trades_Completed":61, "Materials_Traded":826, "Encoded_Materials_Traded":361, "Raw_Materials_Traded":72, "Grade_1_Materials_Traded":107, "Grade_2_Materials_Traded":167, "Grade_3_Materials_Traded":191, "Grade_4_Materials_Traded":260, "Grade_5_Materials_Traded":101 }, "CQC":{ "CQC_Credits_Earned":22156, "CQC_Time_Played":16200, "CQC_KD":0.4070796460177, "CQC_Kills":46, "CQC_WL":0.028571428571429 } }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;

namespace ALICE_Events
{
    public class Event_Statistics : Event_Base
    {
        public Event_Statistics()
        {
            Name = "Statistics";
        }

        public void Logic()
        {
            if (IEvents.WriteVariables && WriteVariables)
            {
                try
                {
                    Variables_Clear();
                    Variables_Generate();
                    Variables_Write();
                }
                catch (Exception ex)
                {
                    Logger.Exception(Name, "An Exception Occured While Updating Variables");
                    Logger.Exception(Name, "Exception: " + ex);
                }
            }

            //Custom Logic Here.

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            Statistics Event = (Statistics)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            //Variable_Craft("Bank_Account", Event.Bank_Account.Variable());
            //Variable_Craft("Combat", Event.Combat.Variable());
            //Variable_Craft("Crime", Event.Crime.Variable());
            //Variable_Craft("Smuggling", Event.Smuggling.Variable());
            //Variable_Craft("Trading", Event.Trading.Variable());
            //Variable_Craft("Mining", Event.Mining.Variable());
            //Variable_Craft("Exploration", Event.Exploration.Variable());
            //Variable_Craft("Passengers", Event.Passengers.Variable());
            //Variable_Craft("Search_And_Rescue", Event.Search_And_Rescue.Variable());
            //Variable_Craft("TG_ENCOUNTERS", Event.TG_ENCOUNTERS.Variable());
            //Variable_Craft("Crafting", Event.Crafting.Variable());
            //Variable_Craft("Crew", Event.Crew.Variable());
            //Variable_Craft("Multicrew", Event.Multicrew.Variable());
            //Variable_Craft("Material_Trader_Stats", Event.Material_Trader_Stats.Variable());
            //Variable_Craft("CQC", Event.CQC.Variable());
            #endregion
        }
    }

    #region Statistics Event
    public class Statistics : Base
    {
        public BankAccountStat Bank_Account { get; set; }
        public CombatStat Combat { get; set; }
        public CrimeStat Crime { get; set; }
        public SmugglingStat Smuggling { get; set; }
        public TradingStat Trading { get; set; }
        public MiningStat Mining { get; set; }
        public ExplorationStat Exploration { get; set; }
        public PassengersStat Passengers { get; set; }
        public Search_And_RescueStat Search_And_Rescue { get; set; }
        public CraftingStat Crafting { get; set; }
        public CrewStat Crew { get; set; }
        public MulticrewStat Multicrew { get; set; }
        public Material_TraderStat Material_Trader_Stats { get; set; }
        public TG_Encounters TG_ENCOUNTERS { get; set; }
        public CQCStat CQC { get; set; }

        public class BankAccountStat : Catch
        {
            public decimal Current_Wealth { get; set; }
            public decimal Spent_On_Ships { get; set; }
            public decimal Spent_On_Outfitting { get; set; }
            public decimal Spent_On_Repairs { get; set; }
            public decimal Spent_On_Fuel { get; set; }
            public decimal Spent_On_Ammo_Consumables { get; set; }
            public decimal Insurance_Claims { get; set; }
            public decimal Spent_On_Insurance { get; set; }
        }

        public class CombatStat : Catch
        {
            public decimal Bounties_Claimed { get; set; }
            public decimal Bounty_Hunting_Profit { get; set; }
            public decimal Combat_Bonds { get; set; }
            public decimal Combat_Bond_Profits { get; set; }
            public decimal Assassinations { get; set; }
            public decimal Assassination_Profits { get; set; }
            public decimal Highest_Single_Reward { get; set; }
            public decimal Skimmers_Killed { get; set; }
        }

        public class CrimeStat : Catch
        {
            public decimal Notoriety { get; set; }
            public decimal Fines { get; set; }
            public decimal Total_Fines { get; set; }
            public decimal Bounties_Received { get; set; }
            public decimal Total_Bounties { get; set; }
            public decimal Highest_Bounty { get; set; }
        }

        public class SmugglingStat : Catch
        {
            public decimal Black_Markets_Traded_With { get; set; }
            public decimal Black_Markets_Profits { get; set; }
            public decimal Resources_Smuggled { get; set; }
            public decimal Average_Profit { get; set; }
            public decimal Highest_Single_Transaction { get; set; }
        }

        public class TradingStat : Catch
        {
            public decimal Markets_Traded_With { get; set; }
            public decimal Market_Profits { get; set; }
            public decimal Resources_Traded { get; set; }
            public decimal Average_Profit { get; set; }
            public decimal Highest_Single_Transaction { get; set; }
        }

        public class MiningStat : Catch
        {
            public decimal Mining_Profits { get; set; }
            public decimal Quantity_Mined { get; set; }
            public decimal Materials_Collected { get; set; }
        }

        public class ExplorationStat : Catch
        {
            public decimal Systems_Visited { get; set; }
            public decimal Exploration_Profits { get; set; }
            public decimal Planets_Scanned_To_Level_2 { get; set; }
            public decimal Planets_Scanned_To_Level_3 { get; set; }
            public decimal Highest_Payout { get; set; }
            public decimal Total_Hyperspace_Distance { get; set; }
            public decimal Total_Hyperspace_Jumps { get; set; }
            public decimal Greatest_Distance_From_Start { get; set; }
            public decimal Time_Played { get; set; }
        }

        public class PassengersStat : Catch
        {
            public decimal Passengers_Missions_Accepted { get; set; }
            public decimal Passengers_Missions_Disgruntled { get; set; }
            public decimal Passengers_Missions_Bulk { get; set; }
            public decimal Passengers_Missions_VIP { get; set; }
            public decimal Passengers_Missions_Delivered { get; set; }
            public decimal Passengers_Missions_Ejected { get; set; }
        }

        public class Search_And_RescueStat : Catch
        {
            public decimal SearchRescue_Traded { get; set; }
            public decimal SearchRescue_Profit { get; set; }
            public decimal SearchRescue_Count { get; set; }
        }

        public class TG_Encounters : Catch
        {
            public decimal TG_ENCOUNTER_IMPRINT { get; set; }
            public decimal TG_ENCOUNTER_TOTAL { get; set; }
            public string TG_ENCOUNTER_TOTAL_LAST_SYSTEM { get; set; }
            public DateTime TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP { get; set; }
            public string TG_ENCOUNTER_TOTAL_LAST_SHIP { get; set; }
            public decimal TG_SCOUT_COUNT { get; set; }
        }

        public class CraftingStat : Catch
        {
            public decimal Count_Of_Used_Engineers { get; set; }
            public decimal Recipes_Generated { get; set; }
            public decimal Recipes_Generated_Rank_1 { get; set; }
            public decimal Recipes_Generated_Rank_2 { get; set; }
            public decimal Recipes_Generated_Rank_3 { get; set; }
            public decimal Recipes_Generated_Rank_4 { get; set; }
            public decimal Recipes_Generated_Rank_5 { get; set; }
        }

        public class CrewStat : Catch
        {
            public decimal NpcCrew_TotalWages { get; set; }
            public decimal NpcCrew_Hired { get; set; }
            public decimal NpcCrew_Fired { get; set; }
            public decimal NpcCrew_Died { get; set; }
        }

        public class MulticrewStat : Catch
        {
            public decimal Multicrew_Time_Total { get; set; }
            public decimal Multicrew_Gunner_Time_Total { get; set; }
            public decimal Multicrew_Fighter_Time_Total { get; set; }
            public decimal Multicrew_Credits_Total { get; set; }
            public decimal Multicrew_Fines_Total { get; set; }
        }

        public class Material_TraderStat : Catch
        {
            public decimal Trades_Completed { get; set; }
            public decimal Materials_Traded { get; set; }
            public decimal Encoded_Materials_Traded { get; set; }
            public decimal Raw_Materials_Traded { get; set; }
            public decimal Grade_1_Materials_Traded { get; set; }
            public decimal Grade_2_Materials_Traded { get; set; }
            public decimal Grade_3_Materials_Traded { get; set; }
            public decimal Grade_4_Materials_Traded { get; set; }
            public decimal Grade_5_Materials_Traded { get; set; }
        }

        public class CQCStat : Catch
        {
            public decimal CQC_Credits_Earned { get; set; }
            public decimal CQC_Time_Played { get; set; }
            public decimal CQC_KD { get; set; }
            public decimal CQC_Kills { get; set; }
            public decimal CQC_WL { get; set; }
        }
    }
    #endregion
}

//Journal Reader Code Chunk.

// else if (EventName == Statistics)
// {
//     var Event = JsonConvert.DeserializeObject<ALICE_Events.Statistics>(RawLine);
//     IEvents.UpdateEvents(EventName, Event);
//     IEvents.Bounty.Logic();
// }