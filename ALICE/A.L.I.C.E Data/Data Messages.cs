using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Data
{
    public class Data_Messages
    {
        public readonly string NoFireZone = "NoFireZone";
        public readonly string NoFireZoneExit = "NoFireZone_exited";
        public readonly string NoFireZoneEnter = "NoFireZone_entered";
        public readonly string DockingOffenceCleared = "DockingOffenceCleared";
        public readonly string DockingPadBlockWarning = "DockingPadBlockWarningComms";
        public readonly string DockingPadBlockHostile = "DockingPadBlockHostileComms";
        public readonly string DockingDoorBlockWarning = "DockingDoorBlockWarningComms";
        public readonly string DockingDoorBlockHostile = "DockingDoorBlockHostileComms";
        public readonly string DockingChatterAllied = "DockingChatter_Allied";
        public readonly string AccidentalDamage = "AccidentalDamage";
        public readonly string StationAggressorResponse = "StationAggressorResponseMessage";
    }
}
