using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Data
{
    public static class IData
    {
        public static List<string> ShipModules { get; set; } = new List<string>();
        public static Data_Codex Codex { get; } = new Data_Codex();
        public static Data_Commodies Commodie { get; } = new Data_Commodies();
        public static Data_CrimeTypes CrimeType { get; } = new Data_CrimeTypes();
        public static Data_Messages Messages { get; } = new Data_Messages();
        public static D_Modules Module { get; } = new D_Modules();
        public static Data_Systems Systems { get; } = new Data_Systems();
    }
}
