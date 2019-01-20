using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Objects
{
    /// <summary>
    /// This class records users system stats locally to compair the changes the next time they enter the system.
    /// </summary>
    public class Object_SystemPlayerData : Object_Utilities
    {
        public string Name { get; set; }
        public decimal Address { get; set; }
        public decimal StellarBodies { get; set; }
        public List<string> Powers { get; set; }
        public string PowerplayState { get; set; }
        public string ControlFaction { get; set; }
        public string ControlFactionState { get; set; }
        public Dictionary<string, Object_Factions> Factions { get; set; }
    }
}
