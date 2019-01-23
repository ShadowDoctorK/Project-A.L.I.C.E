using System.Collections.Generic;

namespace ALICE_Synthesizer
{
    #region Response Wrappers | Auto Generated: 01/23/2019 1:23 AM

    public static class Crime
    {
        public static List<string> Block_Relocate = new List<string> { "Crime", "Block Relocate" };
        public static List<string> Bounty = new List<string> { "Crime", "Bounty" };
        public static List<string> Fine = new List<string> { "Crime", "Fine" };
        public static List<string> Wreckless_Flying_Damage = new List<string> { "Crime", "Wreckless Flying Damage" };
        public static List<string> Wreckless_Flying = new List<string> { "Crime", "Wreckless Flying" };
        public static List<string> Trespass_Minor = new List<string> { "Crime", "Trespass Minor" };
        public static List<string> Piracy = new List<string> { "Crime", "Piracy" };
        public static List<string> Murder = new List<string> { "Crime", "Murder" };
        public static List<string> Interdicting = new List<string> { "Crime", "Interdicting" };
        public static List<string> Illegal_Cargo = new List<string> { "Crime", "Illegal Cargo" };
        public static List<string> Fire_In_No_Fire_Zone = new List<string> { "Crime", "Fire In No Fire Zone" };
        public static List<string> Dumping_Near_Station = new List<string> { "Crime", "Dumping Near Station" };
        public static List<string> Dumping_Dangerous = new List<string> { "Crime", "Dumping Dangerous" };
        public static List<string> Disobey_Police = new List<string> { "Crime", "Disobey Police" };
        public static List<string> Block_Landing_Pad_Warning = new List<string> { "Crime", "Block Landing Pad Warning" };
        public static List<string> Block_Landing_Pad_Minor = new List<string> { "Crime", "Block Landing Pad Minor" };
        public static List<string> Block_Airlock_Warning = new List<string> { "Crime", "Block Airlock Warning" };
        public static List<string> Block_Airlock_Minor = new List<string> { "Crime", "Block Airlock Minor" };
        public static List<string> Assult = new List<string> { "Crime", "Assult" };
        public static List<string> Default = new List<string> { "Crime", "Default" };
    }

    public static class EQ_Cargo_Scoop
    {
        public static List<string> Docked = new List<string> { "EQ Cargo Scoop", "Docked" };
        public static List<string> Deploying = new List<string> { "EQ Cargo Scoop", "Deploying" };
        public static List<string> Retracting = new List<string> { "EQ Cargo Scoop", "Retracting" };
        public static List<string> Currently_Retracted = new List<string> { "EQ Cargo Scoop", "Currently Retracted" };
        public static List<string> Currently_Deployed = new List<string> { "EQ Cargo Scoop", "Currently Deployed" };
        public static List<string> Touchdown = new List<string> { "EQ Cargo Scoop", "Touchdown" };
        public static List<string> Fighter = new List<string> { "EQ Cargo Scoop", "Fighter" };
        public static List<string> Not_Normal_Space = new List<string> { "EQ Cargo Scoop", "Not Normal Space" };
    }

    public static class EQ_Chaff_Launcher
    {
        public static List<string> Supercruise = new List<string> { "EQ Chaff Launcher", "Supercruise" };
        public static List<string> Hyperspace = new List<string> { "EQ Chaff Launcher", "Hyperspace" };
        public static List<string> Activating = new List<string> { "EQ Chaff Launcher", "Activating" };
    }

    public static class EQ_Discovery_Scanner
    {
        public static List<string> FSS_Currently_Activated = new List<string> { "EQ Discovery Scanner", "FSS Currently Activated" };
        public static List<string> FSS_Currently_Deactivated = new List<string> { "EQ Discovery Scanner", "FSS Currently Deactivated" };
        public static List<string> FSS_Deactivating = new List<string> { "EQ Discovery Scanner", "FSS Deactivating" };
        public static List<string> FSS_Activating = new List<string> { "EQ Discovery Scanner", "FSS Activating" };
        public static List<string> Updating = new List<string> { "EQ Discovery Scanner", "Updating" };
        public static List<string> Scan_Commenced = new List<string> { "EQ Discovery Scanner", "Scan Commenced" };
        public static List<string> Scan_Complete = new List<string> { "EQ Discovery Scanner", "Scan Complete" };
        public static List<string> Not_Installed = new List<string> { "EQ Discovery Scanner", "Not Installed" };
        public static List<string> Not_Assigned = new List<string> { "EQ Discovery Scanner", "Not Assigned" };
        public static List<string> No_Returns = new List<string> { "EQ Discovery Scanner", "No Returns" };
        public static List<string> New_Returns = new List<string> { "EQ Discovery Scanner", "New Returns" };
        public static List<string> Scan_Failed = new List<string> { "EQ Discovery Scanner", "Scan Failed" };
        public static List<string> Entered_Hyperspace = new List<string> { "EQ Discovery Scanner", "Entered Hyperspace" };
    }

    public static class EQ_External_Lights
    {
        public static List<string> No_Hyperspace = new List<string> { "EQ External Lights", "No Hyperspace" };
        public static List<string> Deenergizing = new List<string> { "EQ External Lights", "Deenergizing" };
        public static List<string> Energizing = new List<string> { "EQ External Lights", "Energizing" };
        public static List<string> Currently_Deenergized = new List<string> { "EQ External Lights", "Currently Deenergized" };
        public static List<string> Currently_Energized = new List<string> { "EQ External Lights", "Currently Energized" };
    }

    public static class EQ_Fighter
    {
        public static List<string> Hanger_Total = new List<string> { "EQ Fighter", "Hanger Total" };
        public static List<string> No_Fighter_Hanger = new List<string> { "EQ Fighter", "No Fighter Hanger" };
        public static List<string> Altitude = new List<string> { "EQ Fighter", "Altitude" };
        public static List<string> No_Fire_Zone = new List<string> { "EQ Fighter", "No Fire Zone" };
        public static List<string> Touchdown = new List<string> { "EQ Fighter", "Touchdown" };
        public static List<string> Mothership_Docked = new List<string> { "EQ Fighter", "Mothership Docked" };
        public static List<string> Not_Mothership = new List<string> { "EQ Fighter", "Not Mothership" };
        public static List<string> Not_Normal_Space = new List<string> { "EQ Fighter", "Not Normal Space" };
        public static List<string> Docked_Modifier = new List<string> { "EQ Fighter", "Docked Modifier" };
        public static List<string> Launch_Player_Modifer = new List<string> { "EQ Fighter", "Launch Player Modifer" };
        public static List<string> Rebuilt_Other = new List<string> { "EQ Fighter", "Rebuilt Other" };
        public static List<string> Rebuilt_Docked = new List<string> { "EQ Fighter", "Rebuilt Docked" };
        public static List<string> Rebuilt_Destroyed = new List<string> { "EQ Fighter", "Rebuilt Destroyed" };
        public static List<string> Order_Recall_Player = new List<string> { "EQ Fighter", "Order Recall Player" };
        public static List<string> Order_Recall_NPC = new List<string> { "EQ Fighter", "Order Recall NPC" };
        public static List<string> Order_Maintain_Formation = new List<string> { "EQ Fighter", "Order Maintain Formation" };
        public static List<string> Order_Hold_Position = new List<string> { "EQ Fighter", "Order Hold Position" };
        public static List<string> Order_Follow = new List<string> { "EQ Fighter", "Order Follow" };
        public static List<string> Order_Engage_At_Will = new List<string> { "EQ Fighter", "Order Engage At Will" };
        public static List<string> Order_Defend = new List<string> { "EQ Fighter", "Order Defend" };
        public static List<string> Order_Attack_Target = new List<string> { "EQ Fighter", "Order Attack Target" };
        public static List<string> Launch = new List<string> { "EQ Fighter", "Launch" };
        public static List<string> Launch_Error = new List<string> { "EQ Fighter", "Launch Error" };
        public static List<string> Docked = new List<string> { "EQ Fighter", "Docked" };
        public static List<string> Destroyed = new List<string> { "EQ Fighter", "Destroyed" };
    }

    public static class EQ_Frame_Shift_Drive
    {
        public static List<string> SC_Currently_Supercruise = new List<string> { "EQ Frame Shift Drive", "SC Currently Supercruise" };
        public static List<string> SC_Currently_Normal_Space = new List<string> { "EQ Frame Shift Drive", "SC Currently Normal Space" };
        public static List<string> SC_Currently_Hyperspace = new List<string> { "EQ Frame Shift Drive", "SC Currently Hyperspace" };
        public static List<string> HS_Currently_Hyperspace = new List<string> { "EQ Frame Shift Drive", "HS Currently Hyperspace" };
        public static List<string> SC_Preparing = new List<string> { "EQ Frame Shift Drive", "SC Preparing" };
        public static List<string> HS_Preparing = new List<string> { "EQ Frame Shift Drive", "HS Preparing" };
        public static List<string> Cooldown = new List<string> { "EQ Frame Shift Drive", "Cooldown" };
        public static List<string> Touchdown = new List<string> { "EQ Frame Shift Drive", "Touchdown" };
        public static List<string> Too_Fast = new List<string> { "EQ Frame Shift Drive", "Too Fast" };
        public static List<string> Masslock = new List<string> { "EQ Frame Shift Drive", "Masslock" };
        public static List<string> Failed_to_Disengage = new List<string> { "EQ Frame Shift Drive", "Failed to Disengage" };
        public static List<string> Failed_to_Engage = new List<string> { "EQ Frame Shift Drive", "Failed to Engage" };
        public static List<string> Docked = new List<string> { "EQ Frame Shift Drive", "Docked" };
        public static List<string> Abort_Failed = new List<string> { "EQ Frame Shift Drive", "Abort Failed" };
        public static List<string> Abort_Successful = new List<string> { "EQ Frame Shift Drive", "Abort Successful" };
        public static List<string> HS_Entering = new List<string> { "EQ Frame Shift Drive", "HS Entering" };
        public static List<string> SC_Currently_Charging = new List<string> { "EQ Frame Shift Drive", "SC Currently Charging" };
        public static List<string> HS_Currently_Charging = new List<string> { "EQ Frame Shift Drive", "HS Currently Charging" };
        public static List<string> Drive_Charging = new List<string> { "EQ Frame Shift Drive", "Drive Charging" };
        public static List<string> SC_Disengaging = new List<string> { "EQ Frame Shift Drive", "SC Disengaging" };
        public static List<string> SC_Entering = new List<string> { "EQ Frame Shift Drive", "SC Entering" };
        public static List<string> Negaive = new List<string> { "EQ Frame Shift Drive", "Negaive" };
    }

    public static class EQ_Full_Spectrum_Scanner
    {
        public static List<string> FSS_Currently_Activated = new List<string> { "EQ Full Spectrum Scanner", "FSS Currently Activated" };
        public static List<string> FSS_Currently_Deactivated = new List<string> { "EQ Full Spectrum Scanner", "FSS Currently Deactivated" };
        public static List<string> FSS_Deactivating = new List<string> { "EQ Full Spectrum Scanner", "FSS Deactivating" };
        public static List<string> FSS_Activating = new List<string> { "EQ Full Spectrum Scanner", "FSS Activating" };
        public static List<string> Updating = new List<string> { "EQ Full Spectrum Scanner", "Updating" };
        public static List<string> DS_Commenced = new List<string> { "EQ Full Spectrum Scanner", "DS Commenced" };
        public static List<string> DS_Complete = new List<string> { "EQ Full Spectrum Scanner", "DS Complete" };
        public static List<string> DS_Not_Assigned = new List<string> { "EQ Full Spectrum Scanner", "DS Not Assigned" };
        public static List<string> No_Returns = new List<string> { "EQ Full Spectrum Scanner", "No Returns" };
        public static List<string> New_Returns = new List<string> { "EQ Full Spectrum Scanner", "New Returns" };
        public static List<string> DS_Failed = new List<string> { "EQ Full Spectrum Scanner", "DS Failed" };
        public static List<string> Entered_Hyperspace = new List<string> { "EQ Full Spectrum Scanner", "Entered Hyperspace" };
    }

    public static class EQ_Generic_Module
    {
        public static List<string> Not_Installed = new List<string> { "EQ Generic Module", "Not Installed" };
    }

    public static class EQ_Hardpoints
    {
        public static List<string> Safety_Disengaging = new List<string> { "EQ Hardpoints", "Safety Disengaging" };
        public static List<string> Safety_Engaging = new List<string> { "EQ Hardpoints", "Safety Engaging" };
        public static List<string> Safety_Disengaged = new List<string> { "EQ Hardpoints", "Safety Disengaged" };
        public static List<string> Supercruise = new List<string> { "EQ Hardpoints", "Supercruise" };
        public static List<string> Safety_Remains = new List<string> { "EQ Hardpoints", "Safety Remains" };
        public static List<string> Safety_Engaged = new List<string> { "EQ Hardpoints", "Safety Engaged" };
        public static List<string> Retracting = new List<string> { "EQ Hardpoints", "Retracting" };
        public static List<string> Hyperspace = new List<string> { "EQ Hardpoints", "Hyperspace" };
        public static List<string> Deploying = new List<string> { "EQ Hardpoints", "Deploying" };
        public static List<string> Currently_Retracted = new List<string> { "EQ Hardpoints", "Currently Retracted" };
        public static List<string> Currently_Deployed = new List<string> { "EQ Hardpoints", "Currently Deployed" };
    }

    public static class EQ_Heatsink_Launcher
    {
        public static List<string> Hyperspace = new List<string> { "EQ Heatsink Launcher", "Hyperspace" };
        public static List<string> Activating = new List<string> { "EQ Heatsink Launcher", "Activating" };
    }

    public static class EQ_Landing_Gear
    {
        public static List<string> Retracting = new List<string> { "EQ Landing Gear", "Retracting" };
        public static List<string> Deploying = new List<string> { "EQ Landing Gear", "Deploying" };
        public static List<string> Currently_Retracted = new List<string> { "EQ Landing Gear", "Currently Retracted" };
        public static List<string> Currently_Deployed = new List<string> { "EQ Landing Gear", "Currently Deployed" };
        public static List<string> Touchdown = new List<string> { "EQ Landing Gear", "Touchdown" };
        public static List<string> Docked = new List<string> { "EQ Landing Gear", "Docked" };
        public static List<string> Fighter_Deployed = new List<string> { "EQ Landing Gear", "Fighter Deployed" };
        public static List<string> Not_Mothership = new List<string> { "EQ Landing Gear", "Not Mothership" };
        public static List<string> Not_Normal_Space = new List<string> { "EQ Landing Gear", "Not Normal Space" };
    }

    public static class EQ_Shield_Cell
    {
        public static List<string> Hyperspace = new List<string> { "EQ Shield Cell", "Hyperspace" };
        public static List<string> Activating = new List<string> { "EQ Shield Cell", "Activating" };
    }

    public static class EQ_Shields
    {
        public static List<string> Offline = new List<string> { "EQ Shields", "Offline" };
        public static List<string> Online = new List<string> { "EQ Shields", "Online" };
    }

    public static class EQ_Silent_Running
    {
        public static List<string> Securing = new List<string> { "EQ Silent Running", "Securing" };
        public static List<string> Activating = new List<string> { "EQ Silent Running", "Activating" };
        public static List<string> Currently_Secured = new List<string> { "EQ Silent Running", "Currently Secured" };
        public static List<string> Currently_Active = new List<string> { "EQ Silent Running", "Currently Active" };
        public static List<string> Not_Mothership = new List<string> { "EQ Silent Running", "Not Mothership" };
        public static List<string> Not_Normal_Space = new List<string> { "EQ Silent Running", "Not Normal Space" };
    }

    public static class EVT_Bounty
    {
        public static List<string> Collected = new List<string> { "EVT Bounty", "Collected" };
    }

    public static class EVT_HeatDamage
    {
        public static List<string> Default = new List<string> { "EVT HeatDamage", "Default" };
    }

    public static class EVT_HeatWarning
    {
        public static List<string> Modifier = new List<string> { "EVT HeatWarning", "Modifier" };
        public static List<string> Default = new List<string> { "EVT HeatWarning", "Default" };
    }

    public static class EVT_HullDamage
    {
        public static List<string> Default = new List<string> { "EVT HullDamage", "Default" };
    }

    public static class EVT_Masslock
    {
        public static List<string> Current = new List<string> { "EVT Masslock", "Current" };
        public static List<string> Exited = new List<string> { "EVT Masslock", "Exited" };
        public static List<string> Entered = new List<string> { "EVT Masslock", "Entered" };
    }

    public static class EVT_NoFireZone
    {
        public static List<string> Exited = new List<string> { "EVT NoFireZone", "Exited" };
        public static List<string> Entered = new List<string> { "EVT NoFireZone", "Entered" };
    }

    public static class EVT_Ship_Targeted
    {
        public static List<string> Enemy_Faction = new List<string> { "EVT Ship Targeted", "Enemy Faction" };
        public static List<string> Wanted = new List<string> { "EVT Ship Targeted", "Wanted" };
    }

    public static class EVT_ShipTargeted
    {
        public static List<string> Enemy_Faction = new List<string> { "EVT ShipTargeted", "Enemy Faction" };
        public static List<string> Wanted = new List<string> { "EVT ShipTargeted", "Wanted" };
    }

    public static class EVT_Shipyard_Arrived
    {
        public static List<string> Three_Min_Warning = new List<string> { "EVT Shipyard Arrived", "Three Min Warning" };
        public static List<string> Undocked = new List<string> { "EVT Shipyard Arrived", "Undocked" };
        public static List<string> Arrived = new List<string> { "EVT Shipyard Arrived", "Arrived" };
    }

    public static class GN_Alice
    {
        public static List<string> Online = new List<string> { "GN Alice", "Online" };
        public static List<string> Default = new List<string> { "GN Alice", "Default" };
    }

    public static class GN_Apology
    {
        public static List<string> Default = new List<string> { "GN Apology", "Default" };
    }

    public static class GN_Combat_Power
    {
        public static List<string> Defense_Systems = new List<string> { "GN Combat Power", "Defense Systems" };
        public static List<string> Defense_Engines = new List<string> { "GN Combat Power", "Defense Engines" };
        public static List<string> Maintain_Systems = new List<string> { "GN Combat Power", "Maintain Systems" };
        public static List<string> Maintain_Engines = new List<string> { "GN Combat Power", "Maintain Engines" };
        public static List<string> Weapons_Heavy = new List<string> { "GN Combat Power", "Weapons Heavy" };
        public static List<string> Weapons_Balance = new List<string> { "GN Combat Power", "Weapons Balance" };
        public static List<string> Weapons_Light = new List<string> { "GN Combat Power", "Weapons Light" };
        public static List<string> Offline = new List<string> { "GN Combat Power", "Offline" };
        public static List<string> Online = new List<string> { "GN Combat Power", "Online" };
    }

    public static class GN_Docking_Preparations
    {
        public static List<string> Modifier = new List<string> { "GN Docking Preparations", "Modifier" };
        public static List<string> Default = new List<string> { "GN Docking Preparations", "Default" };
    }

    public static class GN_Docking_Request
    {
        public static List<string> No_Docking_Computer_Modifier = new List<string> { "GN Docking Request", "No Docking Computer Modifier" };
        public static List<string> No_Docking_Computer = new List<string> { "GN Docking Request", "No Docking Computer" };
        public static List<string> Reason_No_Space = new List<string> { "GN Docking Request", "Reason No Space" };
        public static List<string> Reason_Too_Large = new List<string> { "GN Docking Request", "Reason Too Large" };
        public static List<string> Reason_Hostile = new List<string> { "GN Docking Request", "Reason Hostile" };
        public static List<string> Reason_Offences = new List<string> { "GN Docking Request", "Reason Offences" };
        public static List<string> Reason_Distance = new List<string> { "GN Docking Request", "Reason Distance" };
        public static List<string> Reason_Active_Fighter = new List<string> { "GN Docking Request", "Reason Active Fighter" };
        public static List<string> Reason_None_Given = new List<string> { "GN Docking Request", "Reason None Given" };
        public static List<string> Landing_Pad = new List<string> { "GN Docking Request", "Landing Pad" };
        public static List<string> Granted = new List<string> { "GN Docking Request", "Granted" };
        public static List<string> Docking_Computer_Handover = new List<string> { "GN Docking Request", "Docking Computer Handover" };
        public static List<string> Docked = new List<string> { "GN Docking Request", "Docked" };
        public static List<string> Denied = new List<string> { "GN Docking Request", "Denied" };
        public static List<string> Already_Granted = new List<string> { "GN Docking Request", "Already Granted" };
    }

    public static class GN_Facility_Report
    {
        public static List<string> Docked = new List<string> { "GN Facility Report", "Docked" };
        public static List<string> Government = new List<string> { "GN Facility Report", "Government" };
        public static List<string> Economy = new List<string> { "GN Facility Report", "Economy" };
        public static List<string> Datalink = new List<string> { "GN Facility Report", "Datalink" };
        public static List<string> State = new List<string> { "GN Facility Report", "State" };
        public static List<string> Undocked_Modifier = new List<string> { "GN Facility Report", "Undocked Modifier" };
        public static List<string> Undocked = new List<string> { "GN Facility Report", "Undocked" };
    }

    public static class GN_Fuel_Report
    {
        public static List<string> Level_Tons = new List<string> { "GN Fuel Report", "Level Tons" };
        public static List<string> Low_Level = new List<string> { "GN Fuel Report", "Low Level" };
        public static List<string> Critical_Level = new List<string> { "GN Fuel Report", "Critical Level" };
        public static List<string> Scoop_Collected = new List<string> { "GN Fuel Report", "Scoop Collected" };
        public static List<string> Scoop_End = new List<string> { "GN Fuel Report", "Scoop End" };
        public static List<string> Scoop_Start = new List<string> { "GN Fuel Report", "Scoop Start" };
        public static List<string> Level_Percent = new List<string> { "GN Fuel Report", "Level Percent" };
    }

    public static class GN_Galaxy_Map
    {
        public static List<string> Close = new List<string> { "GN Galaxy Map", "Close" };
        public static List<string> Failed_To_Open = new List<string> { "GN Galaxy Map", "Failed To Open" };
        public static List<string> Currently_Closed = new List<string> { "GN Galaxy Map", "Currently Closed" };
        public static List<string> Currently_Open = new List<string> { "GN Galaxy Map", "Currently Open" };
        public static List<string> Not_Mothership = new List<string> { "GN Galaxy Map", "Not Mothership" };
        public static List<string> Hyperspace = new List<string> { "GN Galaxy Map", "Hyperspace" };
        public static List<string> Searching = new List<string> { "GN Galaxy Map", "Searching" };
        public static List<string> Options = new List<string> { "GN Galaxy Map", "Options" };
        public static List<string> Configuration = new List<string> { "GN Galaxy Map", "Configuration" };
        public static List<string> Bookmarks = new List<string> { "GN Galaxy Map", "Bookmarks" };
        public static List<string> Search = new List<string> { "GN Galaxy Map", "Search" };
        public static List<string> Open = new List<string> { "GN Galaxy Map", "Open" };
    }

    public static class GN_I_Love_You
    {
        public static List<string> Default = new List<string> { "GN I Love You", "Default" };
    }

    public static class GN_Landing_Preparations
    {
        public static List<string> Modifier = new List<string> { "GN Landing Preparations", "Modifier" };
        public static List<string> Default = new List<string> { "GN Landing Preparations", "Default" };
    }

    public static class GN_Negative
    {
        public static List<string> Default = new List<string> { "GN Negative", "Default" };
    }

    public static class GN_Order_Updated
    {
        public static List<string> Enabled = new List<string> { "GN Order Updated", "Enabled" };
        public static List<string> Disabled = new List<string> { "GN Order Updated", "Disabled" };
        public static List<string> Currently_Enabled = new List<string> { "GN Order Updated", "Currently Enabled" };
        public static List<string> Currently_Disabled = new List<string> { "GN Order Updated", "Currently Disabled" };
    }

    public static class GN_Planetary_Interaction
    {
        public static List<string> Orbital_Not_Scanned = new List<string> { "GN Planetary Interaction", "Orbital Not Scanned" };
        public static List<string> Orbital_Gravity_Warning = new List<string> { "GN Planetary Interaction", "Orbital Gravity Warning" };
        public static List<string> Orbital_Descent_Aborted = new List<string> { "GN Planetary Interaction", "Orbital Descent Aborted" };
        public static List<string> Orbital_Descent_Prep = new List<string> { "GN Planetary Interaction", "Orbital Descent Prep" };
        public static List<string> Orbital_Cruise_Exit = new List<string> { "GN Planetary Interaction", "Orbital Cruise Exit" };
        public static List<string> Orbital_Cruise_Entry = new List<string> { "GN Planetary Interaction", "Orbital Cruise Entry" };
        public static List<string> Glide_Failed = new List<string> { "GN Planetary Interaction", "Glide Failed" };
        public static List<string> Glide_Commenced = new List<string> { "GN Planetary Interaction", "Glide Commenced" };
        public static List<string> Glide_Complete = new List<string> { "GN Planetary Interaction", "Glide Complete" };
        public static List<string> Approach_Settlement = new List<string> { "GN Planetary Interaction", "Approach Settlement" };
        public static List<string> Ship_Dismissed = new List<string> { "GN Planetary Interaction", "Ship Dismissed" };
        public static List<string> Ship_Recalled = new List<string> { "GN Planetary Interaction", "Ship Recalled" };
        public static List<string> Takeoff_Modifier = new List<string> { "GN Planetary Interaction", "Takeoff Modifier" };
        public static List<string> Takeoff = new List<string> { "GN Planetary Interaction", "Takeoff" };
        public static List<string> Landing_Modifier = new List<string> { "GN Planetary Interaction", "Landing Modifier" };
        public static List<string> Landing = new List<string> { "GN Planetary Interaction", "Landing" };
    }

    public static class GN_Positive
    {
        public static List<string> Default = new List<string> { "GN Positive", "Default" };
    }

    public static class GN_Report_Updated
    {
        public static List<string> Enabled = new List<string> { "GN Report Updated", "Enabled" };
        public static List<string> Disabled = new List<string> { "GN Report Updated", "Disabled" };
        public static List<string> Currently_Enabled = new List<string> { "GN Report Updated", "Currently Enabled" };
        public static List<string> Currently_Disabled = new List<string> { "GN Report Updated", "Currently Disabled" };
    }

    public static class GN_Station_Reports
    {
        public static List<string> Player_Targeted = new List<string> { "GN Station Reports", "Player Targeted" };
        public static List<string> Hostile = new List<string> { "GN Station Reports", "Hostile" };
        public static List<string> Damaged = new List<string> { "GN Station Reports", "Damaged" };
    }

    public static class GN_System_Map
    {
        public static List<string> Not_Mothership = new List<string> { "GN System Map", "Not Mothership" };
        public static List<string> Hyperspace = new List<string> { "GN System Map", "Hyperspace" };
        public static List<string> Close = new List<string> { "GN System Map", "Close" };
        public static List<string> Currently_Closed = new List<string> { "GN System Map", "Currently Closed" };
        public static List<string> Currently_Open = new List<string> { "GN System Map", "Currently Open" };
        public static List<string> Failed_To_Open = new List<string> { "GN System Map", "Failed To Open" };
        public static List<string> Points_Of_Interest = new List<string> { "GN System Map", "Points Of Interest" };
        public static List<string> Local_Bookmarks = new List<string> { "GN System Map", "Local Bookmarks" };
        public static List<string> Body_Info = new List<string> { "GN System Map", "Body Info" };
        public static List<string> Summary = new List<string> { "GN System Map", "Summary" };
        public static List<string> Open = new List<string> { "GN System Map", "Open" };
    }

    public static class GN_System_Report
    {
        public static List<string> Entry_Report = new List<string> { "GN System Report", "Entry Report" };
        public static List<string> Security = new List<string> { "GN System Report", "Security" };
        public static List<string> Government = new List<string> { "GN System Report", "Government" };
        public static List<string> Allegiance = new List<string> { "GN System Report", "Allegiance" };
        public static List<string> Arrived = new List<string> { "GN System Report", "Arrived" };
    }

    public static class GN_Targeting_System
    {
        public static List<string> Blacklist_Contains = new List<string> { "GN Targeting System", "Blacklist Contains" };
        public static List<string> Blacklist_Empty = new List<string> { "GN Targeting System", "Blacklist Empty" };
        public static List<string> Blacklist_Clear = new List<string> { "GN Targeting System", "Blacklist Clear" };
        public static List<string> Blacklist_Faction = new List<string> { "GN Targeting System", "Blacklist Faction" };
        public static List<string> Blacklist_Pilot = new List<string> { "GN Targeting System", "Blacklist Pilot" };
        public static List<string> Whitelist_Contains = new List<string> { "GN Targeting System", "Whitelist Contains" };
        public static List<string> Whitelist_Empty = new List<string> { "GN Targeting System", "Whitelist Empty" };
        public static List<string> Scan_Start_Hostile_Modifier = new List<string> { "GN Targeting System", "Scan Start Hostile Modifier" };
        public static List<string> Scan_Continue = new List<string> { "GN Targeting System", "Scan Continue" };
        public static List<string> Scan_Terminated = new List<string> { "GN Targeting System", "Scan Terminated" };
        public static List<string> Scan_Pause = new List<string> { "GN Targeting System", "Scan Pause" };
        public static List<string> Scan_Target_Lost = new List<string> { "GN Targeting System", "Scan Target Lost" };
        public static List<string> Scan_Target_Aquired = new List<string> { "GN Targeting System", "Scan Target Aquired" };
        public static List<string> Scan_Data_Standby = new List<string> { "GN Targeting System", "Scan Data Standby" };
        public static List<string> Scan_No_Targets = new List<string> { "GN Targeting System", "Scan No Targets" };
        public static List<string> Scan_Start = new List<string> { "GN Targeting System", "Scan Start" };
        public static List<string> SRV = new List<string> { "GN Targeting System", "SRV" };
        public static List<string> Hyperspace = new List<string> { "GN Targeting System", "Hyperspace" };
        public static List<string> Whitelist_Clear = new List<string> { "GN Targeting System", "Whitelist Clear" };
        public static List<string> Whitelist_Faction = new List<string> { "GN Targeting System", "Whitelist Faction" };
        public static List<string> Whitelist_Pilot = new List<string> { "GN Targeting System", "Whitelist Pilot" };
    }

    public static class GN_Thank_You
    {
        public static List<string> Default = new List<string> { "GN Thank You", "Default" };
    }

    public static class NPC_Crew
    {
        public static List<string> On_Shore_Leave = new List<string> { "NPC Crew", "On Shore Leave" };
        public static List<string> Active_Duty = new List<string> { "NPC Crew", "Active Duty" };
    }

    public static class Weapons_Safety
    {
        public static List<string> Engaged = new List<string> { "Weapons Safety", "Engaged" };
        public static List<string> Disengaged = new List<string> { "Weapons Safety", "Disengaged" };
    }

    #endregion

}
