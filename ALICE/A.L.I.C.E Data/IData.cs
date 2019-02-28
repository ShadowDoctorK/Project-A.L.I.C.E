using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Data
{
    public static class IData
    {
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
    }
}
