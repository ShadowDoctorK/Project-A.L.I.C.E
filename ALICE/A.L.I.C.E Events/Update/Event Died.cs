//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-19T04:52:51Z", "event":"Died", "KillerName":"Shakez", "KillerShip":"anaconda", "KillerRank":"Deadly" }

using System;
using System.Collections.Generic;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Died : Base
    {
        //Killed By Wing
        public List<Killer> Killers { get; set; }

        //Killed By Single Pilot
        public string KillerName { get; set; }
        public string KillerName_Localised { get; set; }
        public string KillerShip { get; set; }
        public string KillerRank { get; set; }

        //Default Constructor
        public Died()
        {
            KillerName = Str();
            KillerName_Localised = Str();
            KillerShip = Str();
            KillerRank = Str();
        }

        public class Killer : Catch
        {
            public string Name { get; set; }
            public string Ship { get; set; }
            public string Rank { get; set; }

            public Killer()
            {
                Name = Str();
                Ship = Str();
                Rank = Str();
            }
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_Died : Event
    {
        //No Processing
    }
}