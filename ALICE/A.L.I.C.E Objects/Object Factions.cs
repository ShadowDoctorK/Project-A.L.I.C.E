using ALICE_Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Objects
{
    public class Object_Factions : Object_Base
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Government { get; set; }
        public decimal Influence { get; set; }
        public string Allegiance { get; set; }
        public string Happiness { get; set; }        
        public List<States> PendingStates { get; set; }
        public List<States> RecoveringStates { get; set; }

        #region Constructors
        public Object_Factions()
        {
            Name = IObjects.String;
            State = IObjects.String;
            Government = IObjects.String;
            Influence = IObjects.Decimal;
            Allegiance = IObjects.String;
            Happiness = IObjects.String;            
            PendingStates = new List<States>();
            RecoveringStates = new List<States>();
        }

        public Object_Factions(FSDJump.Faction Faction)
        {
            Name = IObjects.StringCheck(Faction.Name);
            State = IObjects.StringCheck(Faction.FactionState);
            Government = IObjects.StringCheck(Faction.Government);
            Influence = Faction.Influence;
            Allegiance = IObjects.StringCheck(Faction.Allegiance);
            Happiness = IObjects.StringCheck(Faction.Happiness_Localised);
            PendingStates = new List<States>();
            foreach (var FactState in Faction.PendingStates)
            {
                Object_Factions.States TempState = new Object_Factions.States(FactState);
                PendingStates.Add(TempState);
            }
            RecoveringStates = new List<States>();
            foreach (var FactState in Faction.RecoveringStates)
            {
                Object_Factions.States TempState = new Object_Factions.States(FactState);
                this.RecoveringStates.Add(TempState);
            }
        }

        public Object_Factions(Location.Faction Faction)
        {
            Name = IObjects.StringCheck(Faction.Name);
            State = IObjects.StringCheck(Faction.FactionState);
            Government = IObjects.StringCheck(Faction.Government);
            Influence = Faction.Influence;
            Allegiance = IObjects.StringCheck(Faction.Allegiance);
            Happiness = IObjects.String;
            PendingStates = new List<States>();
            foreach (var FactState in Faction.PendingStates)
            {
                Object_Factions.States TempState = new Object_Factions.States(FactState);
                PendingStates.Add(TempState);
            }
            RecoveringStates = new List<States>();
            foreach (var FactState in Faction.RecoveringStates)
            {
                Object_Factions.States TempState = new Object_Factions.States(FactState);
                this.RecoveringStates.Add(TempState);
            }
        }
        #endregion

        public class States
        {
            public string State { get; set; }
            public decimal Trend { get; set; }

            public States()
            {
                State = IObjects.String;
                Trend = IObjects.Decimal;
            }

            public States(FSDJump.Faction.States Value)
            {
                State = Value.State;
                Trend = Value.Trend;
            }

            public States(Location.Faction.States Value)
            {
                State = Value.State;
                Trend = Value.Trend;
            }
        }

        public void Update_PendingStates(List<FSDJump.Faction.States> Pending)
        {
            foreach (var FactState in Pending)
            {
                Object_Factions.States TempState = new Object_Factions.States(FactState);
                this.PendingStates.Add(TempState);
            }
        }

        public void Update_RecoveringStates(List<FSDJump.Faction.States> Recovering)
        {
            foreach (var FactState in Recovering)
            {
                Object_Factions.States TempState = new Object_Factions.States(FactState);
                this.RecoveringStates.Add(TempState);
            }
        }
    }
}
