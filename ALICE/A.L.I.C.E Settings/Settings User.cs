using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Settings
{
    /// <summary>
    /// This is a collection of the users settings from various parts of the Core Files.
    /// These settings are controlled completely by the user and have no source from the game.
    /// </summary>
    public class Settings_User
    {
        public DateTime TimeStamp { get; set; }
        public string Commander { get; set; }

        #region Plugin
        public int OffsetPanels { get; set; }
        public int OffsetPips { get; set; }
        public int OffsetFireGroups { get; set; }
        public int OffsetThrottle { get; set; }
        #endregion

        #region Orders
        public bool WeaponSafety { get; set; }
        public bool CombatPower { get; set; }
        public bool AssistSystemScan { get; set; }
        public bool AssistDocking { get; set; }
        public bool AssistRefuel { get; set; }
        public bool AssistRearm { get; set; }
        public bool AssistRepair { get; set; }
        public bool AssistHangerEntry { get; set; }
        public bool PostHyperspaceSafety { get; set; }
        #endregion

        #region Reports
        public bool FuelScoop { get; set; }
        public bool FuelStatus { get; set; }
        public bool MaterialCollected { get; set; }
        public bool MaterialRefined { get; set; }
        public bool NoFireZone { get; set; }
        public bool StationStatus { get; set; }
        public bool ShieldState { get; set; }
        public bool CollectedBounty { get; set; }
        public bool TargetEnemy { get; set; }
        public bool TargetWanted { get; set; }
        public bool Masslock { get; set; }
        #endregion

        #region Exploration
        public decimal ScanDistLimit { get; set; }
        public bool BodyEarthLike { get; set; }
        public bool BodyWaterTerra { get; set; }
        public bool BodyHMCTerra { get; set; }
        public bool BodyAmmonia { get; set; }
        public bool BodyRockyTerra { get; set; }
        public bool BodyWater { get; set; }
        public bool BodyMetalRich { get; set; }
        public bool BodyGasGiantII { get; set; }
        public bool BodyHMC { get; set; }

        #endregion

        #region Miscellaneous

        #endregion

        public Settings_User()
        {           
            Commander = "Default";
            //Plugin
            OffsetFireGroups = 0;
            OffsetPanels = 0;
            OffsetPips = 0;
            OffsetThrottle = 0;

            //Orders
            CombatPower = true;
            AssistSystemScan = false;
            AssistDocking = false;
            AssistRefuel = false;
            AssistRearm = false;
            AssistRepair = false;
            AssistHangerEntry = false;
            PostHyperspaceSafety = true;
            WeaponSafety = true;

            //Reports
            FuelScoop = true;
            FuelStatus = true;
            MaterialCollected = true;
            MaterialRefined = true;
            NoFireZone = true;
            StationStatus = true;
            ShieldState = true;
            CollectedBounty = true;
            TargetEnemy = true;
            TargetWanted = true;
            Masslock = true;

            //Exploration
            ScanDistLimit = 250000;     //Distance In Light Seconds.
            BodyEarthLike = true;       
            BodyWaterTerra = true;
            BodyHMCTerra = true;
            BodyAmmonia = true;
            BodyRockyTerra = true;
            BodyWater = true;
            BodyMetalRich = false;
            BodyGasGiantII = false;
            BodyHMC = false;
        }

        #region PlugIn
        /// <summary>
        /// Increase or Decrease the Pip Speed by 25ms 
        /// </summary>
        /// <param name="Increase">True = Increase & False = Decrease</param>
        public void PipSpeed(bool Increase)
        {
            string MethodName = "Pip Offset";

            if (Increase == true)
            {
                OffsetPips = OffsetPips + 25;
            }
            else if (Increase == false)
            {
                OffsetPips = OffsetPips - 25;
                if (OffsetPips < 0) { OffsetPips = 0; }
            }

            ISettings.User.Save(MethodName);
            Logger.DebugLine(MethodName, "Offset = " + OffsetPips, Logger.Purple);
        }

        /// <summary>
        /// Increase or Decrease the Panel Speed by 25ms 
        /// </summary>
        /// <param name="Increase">True = Increase & False = Decrease</param>
        public void PanelSpeed(bool Increase)
        {
            string MethodName = "Panel Offset";

            if (Increase == true)
            {
                OffsetPanels = OffsetPanels + 25;
            }
            else if (Increase == false)
            {
                OffsetPanels = OffsetPanels - 25;
                if (OffsetPanels < 0) { OffsetPanels = 0; }
            }

            ISettings.User.Save(MethodName);
            Logger.DebugLine(MethodName, "Offset = " + OffsetPanels, Logger.Purple);
        }

        /// <summary>
        /// Increase or Decrease the Fire Group Speed by 25ms 
        /// </summary>
        /// <param name="Increase">True = Increase & False = Decrease</param>
        public void FireGroupSpeed(bool Increase)
        {
            string MethodName = "Fire Group Offset";

            if (Increase == true)
            {
                OffsetFireGroups = OffsetFireGroups + 25;
            }
            else if (Increase == false)
            {
                OffsetFireGroups = OffsetFireGroups - 25;
                if (OffsetFireGroups < 0) { OffsetFireGroups = 0; }
            }

            ISettings.User.Save(MethodName);
            Logger.DebugLine(MethodName, "Offset = " + OffsetFireGroups, Logger.Purple);
        }

        /// <summary>
        /// Increase or Decrease the Pip Speed by 25ms 
        /// </summary>
        /// <param name="Increase">True = Increase & False = Decrease</param>
        public void ThrottleSpeed(bool Increase)
        {
            string MethodName = "Throttle Speed";

            if (Increase == true)
            {
                OffsetThrottle = OffsetThrottle + 25;
            }
            else if (Increase == false)
            {
                OffsetThrottle = OffsetThrottle - 25;
                if (OffsetThrottle < 0) { OffsetThrottle = 0; }
            }

            ISettings.User.Save(MethodName);
            Logger.DebugLine(MethodName, "Offset = " + OffsetThrottle, Logger.Purple);
        }
        #endregion

        #region Orders
        public bool Order_Update(bool CurrentState, bool NewState, string ItemName)
        {
            if (CurrentState == true)
            {
                if (NewState == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Order_Updated.Currently_Enabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else if (NewState == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Order_Updated.Disabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
            else if (CurrentState == false)
            {
                if (NewState == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Order_Updated.Enabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else if (NewState == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Order_Updated.Currently_Disabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
            return NewState;
        }

        public void U_AutoSystemScans(bool State)
        {
            string Item = "Assisted System Scans";
            AssistSystemScan = Order_Update(AssistSystemScan, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_AutoDockingProcedure(bool State)
        {
            string Item = "Assisted Docking Procedures";
            AssistDocking = Order_Update(AssistDocking, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_AutoRefuel(bool State)
        {
            string Item = "Assisted Station Refueling";
            AssistRefuel = Order_Update(AssistRefuel, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_AutoRearm(bool State)
        {
            string Item = "Assisted Station Rearming";
            AssistRearm = Order_Update(AssistRearm, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_AutoRepair(bool State)
        {
            string Item = "Assisted Station Repairing";
            AssistRepair = Order_Update(AssistRepair, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_AutoHangerEntry(bool State)
        {
            string Item = "Assisted Hanger Entry";
            AssistHangerEntry = Order_Update(AssistHangerEntry, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_CombatPower(bool State)
        {
            string Item = "Combat Power Management";
            CombatPower = Order_Update(CombatPower, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_PostJumpSafety(bool State)
        {
            string Item = "Post Jump Safeties";
            PostHyperspaceSafety = Order_Update(PostHyperspaceSafety, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_WeaponSafety(bool State)
        {
            string Item = "Weapon Safety Interlocks";
            WeaponSafety = Order_Update(WeaponSafety, State, Item);
            ISettings.User.Save(Item);
        }
        #endregion

        #region Reports
        public bool Report_Update(bool CurrentState, bool NewState, string ItemName)
        {
            if (CurrentState == true)
            {
                if (NewState == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Report_Updated.Currently_Enabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else if (NewState == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Report_Updated.Disabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
            else if (CurrentState == false)
            {
                if (NewState == true)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Positive.Default, true)
                            .Phrase(GN_Report_Updated.Enabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
                else if (NewState == false)
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(GN_Negative.Default, true)
                            .Phrase(GN_Report_Updated.Currently_Disabled)
                            .Replace("[ITEM]", ItemName),
                            true
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }

            return NewState;
        }

        public void U_FuelScoop(bool State)
        {
            string Item = "Fuel Scooping";
            FuelScoop = Report_Update(FuelScoop, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_FuelStatus(bool State)
        {
            string Item = "Fuel Status";
            FuelStatus = Report_Update(FuelStatus, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_MaterialCollected(bool State)
        {
            string Item = "Material Collection";
            MaterialCollected = Report_Update(MaterialCollected, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_MaterialRefined(bool State)
        {
            string Item = "Material Refining";
            MaterialRefined = Report_Update(MaterialRefined, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_NoFireZone(bool State)
        {
            string Item = "No Fire Zone";
            NoFireZone = Report_Update(NoFireZone, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_StationStatus(bool State)
        {
            string Item = "Station Status";
            StationStatus = Report_Update(StationStatus, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_ShieldState(bool State)
        {
            string Item = "Shield State";
            ShieldState = Report_Update(ShieldState, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_CollectedBounty(bool State)
        {
            string Item = "Target Bounty";
            CollectedBounty = Report_Update(CollectedBounty, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_TargetEnemy(bool State)
        {
            string Item = "Enemy Faction";
            TargetEnemy = Report_Update(TargetEnemy, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_TargetWanted(bool State)
        {
            string Item = "Wanted Target";
            TargetWanted = Report_Update(TargetWanted, State, Item);
            ISettings.User.Save(Item);
        }

        public void U_Masslock(bool State)
        {
            string Item = "Masslock";
            Masslock = Report_Update(Masslock, State, Item);
            ISettings.User.Save(Item);
        }
        #endregion

        #region Navigation
        /// <summary>
        /// Will Update the Scan Distance Limit setting.
        /// </summary>
        /// <param name="D">New Distance Limit In LS</param>
        public void U_ScanDistLimit(decimal D)
        {
            string MethodName = "Scan Distance Limit";

            if (D != ScanDistLimit)
            {
                ScanDistLimit = D;
            }
            
            ISettings.User.Save(MethodName);
        }
        #endregion
    }
}
