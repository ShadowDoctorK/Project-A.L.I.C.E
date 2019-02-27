using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Data
{
    public class Data_Messages
    {
        private Dictionary<string, string> Associations = new Dictionary<string, string>
        {
            { "$STATION_docking_timeexpired", "DockingTimeout" },                        //Docking took too long, permission removed.
            { "$STATION_docking_granted", "DockingGranted" },                            //Docking request granted.
            { "$DockingChatter_Allied", "DockingChatterAllied" },                        //Docking request granted.
            { "$DockingOffenceCleared", "DockingOffenceCleared" },                       //Starport infractions cleared, docking privileges restored.

            { "$Smuggler_NearDeath02", "SmugglerNearDeath" },                            //I won't let it end like this!
            { "$Smuggler_NearDeath03", "SmugglerNearDeath" },                            //You almost had me there!
            { "$Commuter_HostileScan01", "HostileScan" },                                //Please cease your unauthorised scan immediately.
            { "$Commuter_HostileScan02", "HostileScan" }                                 //It is an offence to scan this vessel unless you are an authorised member of system security.           
        };

        public enum Messages
        {
            Default,
            DockingTimeout,
            DockingGranted,
            DockingChatterAllied,
            DockingOffenceCleared,
            SmugglerNearDeath,
            HostileScan
        }

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

        public readonly string InitializedComms = "CHAT_Intro";
        public readonly string EnteredComms = "COMMS_entered";

        public readonly string DockingAllied = "DockingChatter_Allied";                             //An ally like you is always welcome here.
        public readonly string DockingGranted = "STATION_docking_granted";                          //Docking request granted.
        public readonly string DockingCancelled = "STATION_docking_cancelled";                      //Docking request cancelled.

        public readonly string SmugglerNearDeath03 = "Smuggler_NearDeath03";                          //You almost had me there!
    }
}