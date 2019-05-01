using ALICE_Events;
using System.Collections.Generic;
using System.Linq;

//Developer Notes:
//Disabled use of this feature until it is required.

namespace ALICE_Objects
{
    public class Object_Engineers : Object_Utilities
    {
        public string FileName { get; set; }

        public Object_Engineers()
        {
            FileName = "Engineers.Update";
            Status = new List<EngData>();
        }

        public List<EngData> Status { get; set; }

        public class EngData
        {
            public string Name { get; set; }
            public string Progress { get; set; }
            public decimal RankProgress { get; set; }
            public decimal Rank { get; set; }

            public EngData()
            {
                Progress = "Undiscovered";
                RankProgress = 0;
                Rank = 0;
            }
        }

        public void Update(EngineerProgress Event)
        {
            foreach (var Eng in Event.Engineers)
            {
                var Target = Get(Eng.Engineer);

                Target.Name = Eng.Engineer;
                Target.Rank = Eng.Rank;
                Target.RankProgress = Eng.RankProgress;
                Target.Progress = Eng.Progress;

                Update(Target);
            }
        }

        #region Collection Management
        public void Add(EngData EngineerData)
        {
            Status.Add(EngineerData);
        }

        public EngData Get(string EngineerName)
        {
            EngData Temp = new EngData();
            if (ObjectExist(EngineerName)) { Temp = Status.FirstOrDefault(x => x.Name == EngineerName); }
            return Temp;
        }

        public void Update(EngData EngineerData)
        {
            int Index = GetObjectIndex(EngineerData.Name);

            if (Index != -1)
            {
                Status[Index] = EngineerData;
            }
            else
            {
                Add(EngineerData);
            }

            //INewtonSoft.Save<Object_Engineers>(IObjects.Engineer, FileName, Paths.ALICE_Settings);
        }

        public int GetObjectIndex(string EngineerName)
        {
            if (ObjectExist(EngineerName))
            {
                var Temp = Status.Select(x => x.Name).ToList();
                return Temp.FindIndex(x => x.Equals(EngineerName));
            }
            else { return -1; }
        }

        public bool ObjectExist(string EngineerName)
        {
            if (Status == null) { return false; }
            return Status.Any(x => x.Name.Equals(EngineerName));
        }
        #endregion
    }
}