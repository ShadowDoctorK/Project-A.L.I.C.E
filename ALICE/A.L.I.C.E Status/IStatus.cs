using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Status;

namespace ALICE_Core
{
    public static class IStatus
    {
        public static Status_Bounty Bounty = new Status_Bounty();
        public static Status_Docking Docking = new Status_Docking();
        public static Status_Planet Planet = new Status_Planet();
        public static Status_Scan Scan = new Status_Scan();
    }
}
