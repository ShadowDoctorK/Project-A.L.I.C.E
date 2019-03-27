//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-28T18:45:50Z", "event":"CommunityGoal", "CurrentGoals":[ { "CGID":544, "Title":"Senator Appeals for Aid", "SystemName":"Niflhel", "MarketName":"Biruni Port", "Expiry":"2018-11-01T15:00:00Z", "IsComplete":false, "CurrentTotal":2666596, "PlayerContribution":0, "NumContributors":1250, "TopTier":{ "Name":"Tier 8", "Bonus":"" }, "TopRankSize":10, "PlayerInTopRank":false, "TierReached":"Tier 3", "PlayerPercentileBand":100, "Bonus":300000 }, { "CGID":545, "Title":"Defending Trade in Niflhel", "SystemName":"Niflhel", "MarketName":"Biruni Port", "Expiry":"2018-11-01T15:00:00Z", "IsComplete":false, "CurrentTotal":14515558851, "PlayerContribution":0, "NumContributors":2222, "TopTier":{ "Name":"Tier 8", "Bonus":"" }, "TopRankSize":10, "PlayerInTopRank":false, "TierReached":"Tier 4", "PlayerPercentileBand":100, "Bonus":400000 } ] }

using System;
using System.Collections.Generic;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class CommunityGoal : Base
    {
        public List<CurrentGoal> CurrentGoals { get; set; }

        //Default Constructor
        public CommunityGoal()
        {
            //No Properties
        }

        public class CurrentGoal : Catch
        {
            public decimal CGID { get; set; }
            public string Title { get; set; }
            public string SystemName { get; set; }
            public string MarketName { get; set; }
            public DateTime Expiry { get; set; }
            public bool IsComplete { get; set; }
            public decimal CurrentTotal { get; set; }
            public decimal PlayerContribution { get; set; }
            public decimal NumContributors { get; set; }
            public Tier TopTier { get; set; }
            public decimal TopRankSize { get; set; }
            public bool PlayerInTopRank { get; set; }
            public string TierReached { get; set; }
            public decimal PlayerPercentileBand { get; set; }
            public decimal Bonus { get; set; }

            public CurrentGoal()
            {
                CGID = Dec();
                Title = Str();
                SystemName = Str();
                MarketName = Str();
                Expiry = Dtg();
                IsComplete = Bool();
                CurrentTotal = Dec();
                PlayerContribution = Dec();
                NumContributors = Dec();
                TopTier = new Tier();
                TopRankSize = Dec();
                PlayerInTopRank = Bool();
                TierReached = Str();
                PlayerPercentileBand = Dec();
                Bonus = Dec();
            }
        }

        public class Tier : Catch
        {
            public string Name { get; set; }
            public string Bonus { get; set; }

            public Tier()
            {
                Name = Str();
                Bonus = Str();
            }
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_CommunityGoal : Event
    {
        //Event Instance
        public CommunityGoal I { get; set; } = new CommunityGoal();

        //Plugin Logic Preparations
        public override void Prepare(object O)
        {
            try
            {
                //Update Event Instance
                I = (CommunityGoal)O;
            }
            catch (Exception ex)
            {
                ExceptionPrepare(Name, ex);
            }
        }
    }
}