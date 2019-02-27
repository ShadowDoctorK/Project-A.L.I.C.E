using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Data
{
    public class Data_CrimeTypes
    {
        //dockingMinorBlockingLandingPad

        private Dictionary<string, string> Associations = new Dictionary<string, string>
        {
            { "dockingMinorBlockingLandingPad", "MinorBlockingLandingPad" },
            { "dockingMajorBlockingLandingPad", "MajorBlockingLandingPad" },
            { "dockingMinorBlockingAirlock", "MinorBlockingAirlock" },
            { "dockingMajorBlockingAirlock", "MajorBlockingAirlock" }
        };

        public string Convert(string C)
        {
            if (Associations.ContainsKey(C))
            {
                return Associations[C];
            }

            return C;
        }
    }
}
