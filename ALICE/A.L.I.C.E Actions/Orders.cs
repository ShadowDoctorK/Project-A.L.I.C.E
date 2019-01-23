using ALICE_Objects;
using ALICE_Synthesizer;
using ALICE_Internal;

namespace ALICE_Actions
{
    //public class Orders
    //{
    //    #region Shared Methods / Functions
    //    public bool Order_Update(bool CurrentState, bool NewState, string ItemName)
    //    {
    //        if (CurrentState == true)
    //        {
    //            if (NewState == true)
    //            {
    //                #region Audio
    //                if (PlugIn.Audio == "TTS")
    //                {
    //                    Speech.Speak
    //                        (
    //                        "".Phrase(GN_Negative.Default, true)
    //                        .Phrase(Order_Generic.Currently_Enabled)
    //                        .Replace("[ITEM]", ItemName),
    //                        true
    //                        );
    //                }
    //                else if (PlugIn.Audio == "File") { }
    //                else if (PlugIn.Audio == "External") { }
    //                #endregion
    //            }
    //            else if (NewState == false)
    //            {
    //                #region Audio
    //                if (PlugIn.Audio == "TTS")
    //                {
    //                    Speech.Speak
    //                        (
    //                        "".Phrase(GN_Positive.Default, true)
    //                        .Phrase(Order_Generic.Disabled)
    //                        .Replace("[ITEM]", ItemName),
    //                        true
    //                        );
    //                }
    //                else if (PlugIn.Audio == "File") { }
    //                else if (PlugIn.Audio == "External") { }
    //                #endregion
    //            }
    //        }
    //        else if (CurrentState == false)
    //        {
    //            if (NewState == true)
    //            {
    //                #region Audio
    //                if (PlugIn.Audio == "TTS")
    //                {
    //                    Speech.Speak
    //                        (
    //                        "".Phrase(GN_Positive.Default, true)
    //                        .Phrase(Order_Generic.Enabled)
    //                        .Replace("[ITEM]", ItemName),
    //                        true
    //                        );
    //                }
    //                else if (PlugIn.Audio == "File") { }
    //                else if (PlugIn.Audio == "External") { }
    //                #endregion
    //            }
    //            else if (NewState == false)
    //            {
    //                #region Audio
    //                if (PlugIn.Audio == "TTS")
    //                {
    //                    Speech.Speak
    //                        (
    //                        "".Phrase(GN_Negative.Default, true)
    //                        .Phrase(Order_Generic.Currently_Disabled)
    //                        .Replace("[ITEM]", ItemName),
    //                        true
    //                        );
    //                }
    //                else if (PlugIn.Audio == "File") { }
    //                else if (PlugIn.Audio == "External") { }
    //                #endregion
    //            }
    //        }
    //        return NewState;
    //    }
    //    #endregion

    //    #region Orders
    //    public void AutoSystemScans(bool State)
    //    {
    //        string Item = "Assisted System Scans";
    //        Monitors.Order.Settings.AssistSystemScan = Order_Update(Monitors.Order.Settings.AssistSystemScan, State, Item);
    //        Monitors.Order.SaveValues();
    //    }

    //    public void AutoDockingProcedure(bool State)
    //    {
    //        string Item = "Assisted Docking Procedures";
    //        Monitors.Order.Settings.AssistDocking = Order_Update(Monitors.Order.Settings.AssistDocking, State, Item);
    //        Monitors.Order.SaveValues();
    //    }

    //    public void AutoRefuel(bool State)
    //    {
    //        string Item = "Assisted Station Refueling";
    //        Monitors.Order.Settings.AssistRefuel = Order_Update(Monitors.Order.Settings.AssistRefuel, State, Item);
    //        Monitors.Order.SaveValues();
    //    }

    //    public void AutoRearm(bool State)
    //    {
    //        string Item = "Assisted Station Rearming";
    //        Monitors.Order.Settings.AssistRearm = Order_Update(Monitors.Order.Settings.AssistRearm, State, Item);
    //        Monitors.Order.SaveValues();
    //    }

    //    public void AutoRepair(bool State)
    //    {
    //        string Item = "Assisted Station Repairing";
    //        Monitors.Order.Settings.AssistRepair = Order_Update(Monitors.Order.Settings.AssistRepair, State, Item);
    //        Monitors.Order.SaveValues();
    //    }

    //    public void AutoHangerEntry(bool State)
    //    {
    //        string Item = "Assisted Hanger Entry";
    //        Monitors.Order.Settings.AssistHangerEntry = Order_Update(Monitors.Order.Settings.AssistHangerEntry, State, Item);
    //        Monitors.Order.SaveValues();
    //    }

    //    public void CombatPower(bool State)
    //    {
    //        string Item = "Combat Power Management";
    //        Monitors.Order.Settings.CombatPower = Order_Update(Monitors.Order.Settings.CombatPower, State, Item);
    //        Monitors.Order.SaveValues();
    //    }

    //    public void PostJumpSafety(bool State)
    //    {
    //        string Item = "Post Jump Safeties";
    //        Monitors.Order.Settings.PostHyperspaceSafety = Order_Update(Monitors.Order.Settings.PostHyperspaceSafety, State, Item);
    //        Monitors.Order.SaveValues();
    //    }

    //    public void WeaponSafety(bool State)
    //    {
    //        string Item = "Weapon Safety Interlocks";
    //        Monitors.Order.Settings.WeaponSafety = Order_Update(Monitors.Order.Settings.WeaponSafety, State, Item);
    //        Monitors.Order.SaveValues();
    //    }
    //    #endregion
    //}
}
