using ALICE_Events;

namespace ALICE_Status
{
    public class Status_Crew
    {
        public string Name { get; set; }
        public decimal ID { get; set; }
        public string DutyStatus { get; set; }

        public Status_Crew()
        {
            Name = "Crew Memeber";
            ID = -1;
            DutyStatus = "Unknown";
        }

        public void Update(CrewAssign Event)
        {
            Name = Event.Name;
            ID = Event.CrewID;
            DutyStatus = Event.Role;
        }

        public void Update(CrewFire Event)
        {
            Name = Event.Name;
            ID = Event.CrewID;
        }

        public void Update(CrewHire Event)
        {
            Name = Event.Name;
            ID = Event.CrewID;
        }

        public void Update(NpcCrewPaidWage Event)
        {

        }

        public void Update(NpcCrewRank Event)
        {

        }    
    }
}