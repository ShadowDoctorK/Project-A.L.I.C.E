using ALICE_Debug;
using ALICE_Events;

namespace ALICE_DebugItems
{
    public class ShipyardArrived : Debug
    {
        private ALICE_Events.ShipyardArrived E { get => IEvents.ShipyardArrived.I; }

        public bool StartLocation(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "StartLocation", T, C, E.StartLocation, L); }

        public string StartLocation(string M, bool L = true)
        { return Get(M, "StartLocation", E.StartLocation, L); }

        public bool EndLocation(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "EndLocation", T, C, E.EndLocation, L); }

        public string EndLocation(string M, bool L = true)
        { return Get(M, "EndLocation", E.EndLocation, L); }

        public bool EndStation(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "EndStation", T, C, E.EndStation, L); }

        public string EndStation(string M, bool L = true)
        { return Get(M, "EndStation", E.EndStation, L); }

        public bool Time(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, "Time", T, C, E.Time, L); }

        public bool Ship(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Ship", T, C, E.Ship, L); }

        public string Ship(string M, bool L = true)
        { return Get(M, "Ship", E.Ship, L); }

        public bool ThreeMinOut(string M, bool C, bool L = true)
        { return Evaluate(M, "ThreeMinOut", C, E.ThreeMinOut, L); }
    }
}