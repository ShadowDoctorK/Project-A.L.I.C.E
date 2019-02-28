using ALICE_Debug;
using ALICE_Settings;

namespace ALICE_DebugItems
{
    public class Reports : Debug
    {
        public bool FuelStatus(string M, bool T, bool L = true)
        { return Evaluate(M, "Fuel Status Report", T, ISettings.FuelStatus, L); }

        public bool FuelScoop(string M, bool T, bool L = true)
        { return Evaluate(M, "Fuel Scoop Report", T, ISettings.FuelScoop, L); }

        public bool ShieldState(string M, bool T, bool L = true)
        { return Evaluate(M, "Shield State Report", T, ISettings.ShieldState, L); }

        public bool CollectedBounty(string M, bool T, bool L = true)
        { return Evaluate(M, "Collected Bounty Report", T, ISettings.CollectedBounty, L); }

        public bool Masslock(string M, bool T, bool L = true)
        { return Evaluate(M, "Masslock Report", T, ISettings.Masslock, L); }

        public bool StationStatus(string M, bool T, bool L = true)
        { return Evaluate(M, "Station Status Report", T, ISettings.StationStatus, L); }

        public bool MaterialCollected(string M, bool T, bool L = true)
        { return Evaluate(M, "Material Collected Report", T, ISettings.MaterialCollected, L); }

        public bool MaterialRefined(string M, bool T, bool L = true)
        { return Evaluate(M, "Material Refined Report", T, ISettings.MaterialRefined, L); }

        public bool TargetWanted(string M, bool T, bool L = true)
        { return Evaluate(M, "Wanted Target Report", T, ISettings.TargetWanted, L); }

        public bool TargetEnemy(string M, bool T, bool L = true)
        { return Evaluate(M, "Hostile Faction Report", T, ISettings.TargetEnemy, L); }
    }
}