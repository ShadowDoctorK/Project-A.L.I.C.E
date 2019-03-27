using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Data
{
    public static class IData
    {
        private static List<string> _ShipModules = new List<string>();
        public static List<string> ShipModules
        {
            get => _ShipModules;
            set => _ShipModules = value;
        }

        private static Data_Codex _Codex = new Data_Codex();
        public static Data_Codex Codex
        {
            get => _Codex;
        }

        private static Data_Commodies _Commodies = new Data_Commodies();
        public static Data_Commodies Commodie
        {
            get => _Commodies;
        }

        private static Data_CrimeTypes _CrimeType = new Data_CrimeTypes();
        public static Data_CrimeTypes CrimeType
        {
            get => _CrimeType;
        }

        private static Data_Messages _Messages = new Data_Messages();
        public static Data_Messages Messages
        {
            get => _Messages;
        }

        private static Data_Modules _Modules = new Data_Modules();
        public static Data_Modules Module
        {
            get => _Modules;
        }

        private static Data_Systems _Systems = new Data_Systems();
        public static Data_Systems Systems
        {
            get => _Systems;
        }
    }
}
