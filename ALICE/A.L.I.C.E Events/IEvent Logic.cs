using System;
using System.Threading;
using ALICE.Properties;
using ALICE_Events;
using ALICE_Actions;
using ALICE_Objects;
using ALICE_Internal;
using ALICE_Core;
using Synth = ALICE_Synthesizer;
using ALICE_Synthesizer;
using ALICE_Settings;
using ALICE_Interface;
using System.Collections.Generic;

namespace ALICE_EventLogic
{
    /// <summary>
    /// Process class is a Data management class, it also conducts various simple Event operations.
    /// </summary>
    public static class Process
    {
        #region Custom Event Logic

        public static void AliceOnline(AliceOnline Event)
        {
            string MethodName = "Alice Online";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Alice.Online)
                    .Replace("[VERSION]", Event.Version),
                    true
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void Assult(Assult Event)
        {
            string MethodName = "Assult";

            StationHostile Temp = (StationHostile)IEvents.GetEvent(IEnums.StationHostile);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Assult)
                    .Replace("[VICTIM]", Event.Victim),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName),
                    (Event.Victim != Temp.Station)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void BlockAirlockMinor(BlockAirlockMinor Event)
        {
            string MethodName = "Block Airlock Warning";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Block_Airlock_Minor)
                    .Phrase(Crime.Block_Relocate)
                    .Phrase(Crime.Fine, true)
                    .Replace("[AMOUNT]", Event.Amount.ToString())
                    .Replace("[STATON]", Event.Station),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }
      
        public static void BlockAirlockWarning(BlockAirlockWarning Event)
        {
            string MethodName = "Block Airlock Warning";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Block_Airlock_Warning),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void BlockLandingPadMinor(BlockLandingPadMinor Event)
        {
            string MethodName = "Block Landing Pad Minor";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Block_Landing_Pad_Minor)
                    .Phrase(Crime.Block_Relocate)
                    .Phrase(Crime.Fine, true)
                    .Replace("[AMOUNT]", Event.Amount.ToString())
                    .Replace("[STATON]", Event.Station),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void BlockLandingPadWarning(BlockLandingPadWarning Event)
        {
            string MethodName = "Block Landing Pad Warning";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Block_Landing_Pad_Warning),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void FireInNoFireZone(FireInNoFireZone Event)
        {
            string MethodName = "Fire In No Fire Zone";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Fire_In_No_Fire_Zone, false, IEvents.FireInNoFireZone.FirstReport)
                    .Phrase(Crime.Fine, true)
                    .Replace("[AMOUNT]", Event.Amount.ToString()),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion

            IEvents.FireInNoFireZone.FirstReport = false;
        }

        public static void FuelCritical(FuelCritical Event)
        {
            string MethodName = "Logic: Fuel Critical";
            if (Check.Internal.JsonInitialized(true, MethodName) == false) { return; }
            if (Check.Internal.TriggerEvents(true, MethodName) == false) { return; }
            if (Check.Variable.FuelScooping(false, MethodName) == false) { return; }

            IStatus.Fuel.Critical = true;

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Fuel_Report.Critical_Level)
                    .Phrase(Speech.Pick(new List<string>[] { Fuel_Report.Level_Percent, Fuel_Report.Level_Tons }))
                    .Token("[PERCENT]", decimal.Round(IStatus.Fuel.GetPercent(), 0).ToString())
                    .Token("[FUELTONS]", decimal.Round(IStatus.Fuel.Main, 1).ToString()),
                    true
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void FuelLow(FuelLow Event)
        {
            string MethodName = "Logic: Fuel Low";
            if (Check.Internal.JsonInitialized(true, MethodName) == false) { return; }
            if (Check.Internal.TriggerEvents(true, MethodName) == false) { return; }
            if (Check.Variable.FuelScooping(false, MethodName) == false) { return; }

            IStatus.Fuel.Low = true;

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Fuel_Report.Low_Level)
                    
                    .Phrase(Speech.Pick(new List<string>[] { Fuel_Report.Level_Percent, Fuel_Report.Level_Tons }))
                    .Token("[PERCENT]", decimal.Round(IStatus.Fuel.GetPercent(), 0).ToString())
                    .Token("[FUELTONS]", decimal.Round(IStatus.Fuel.Main, 1).ToString()),
                    true
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void FuelHalfThreshold(FuelHalfThreshold Event)
        {
            string MethodName = "Logic: Fuel Half Threshold";
            if (Check.Internal.JsonInitialized(true, MethodName) == false) { return; }
            if (Check.Internal.TriggerEvents(true, MethodName) == false) { return; }
            if (Check.Variable.FuelScooping(false, MethodName) == false) { return; }

            IStatus.Fuel.HalfThreshold = true;

            #region Audio
            //if (PlugIn.Audio == "TTS")
            //{
            //    Speech.Speak
            //        (
            //        "".Phrase(Fuel_Report.Level_Percent, false, true, true, 50, Fuel_Report.Level_Tons)
            //        .Replace("[PERCENT]", decimal.Round(IObjects.Status.Fuel.Percent(), 0).ToString())
            //        .Replace("[FUELTONS]", decimal.Round(IObjects.Status.Fuel.Current, 1).ToString()),
            //        true,
            //        Check.Report.FuelStatus(true, MethodName)
            //        );
            //}
            //else if (PlugIn.Audio == "File") { }
            //else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void NoFireZone(NoFireZone Event)
        {
            string MethodName = "Logic: No Fire Zone";

            if (Check.Internal.TriggerEvents(true, MethodName) == false) { return; }

            if (Event.Entered == true)
            {
                IEvents.FireInNoFireZone.FirstReport = true;

                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(No_Fire_Zone.Entered)
                        .Replace("[STATION]", Event.Station),
                        true,
                        IEvents.TriggerEvents
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                Thread.Sleep(100);

                if (ISettings.User.WeaponSafety == true)
                {
                    IObjects.Status.WeaponSafety = true;
                    Call.Action.AnalysisMode(true, false);

                    if (Check.Variable.Hardpoints(true, MethodName) == true)
                    {
                        Call.Action.Hardpoint(false, false);

                        #region Audio
                        if (PlugIn.Audio == "TTS")
                        {
                            Speech.Speak
                                (
                                "".Phrase(Hardpoints.Retracting)
                                .Phrase(Hardpoints.Safety_Engaging),
                                true,
                                IEvents.TriggerEvents
                                );
                        }
                        else if (PlugIn.Audio == "File") { }
                        else if (PlugIn.Audio == "External") { }
                        #endregion

                        return;
                    }

                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(Hardpoints.Safety_Engaging),
                            true,
                            IEvents.TriggerEvents
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
            else if (Event.Entered == false)
            {
                IObjects.Status.WeaponSafety = false;

                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(No_Fire_Zone.Exited)
                        .Replace("[STATION]", Event.Station),
                        true,
                        IEvents.TriggerEvents
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion

                Thread.Sleep(100);

                if (Check.Order.WeaponSafety(true, MethodName))
                {
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(Hardpoints.Safety_Disengaging),
                            true,
                            IEvents.TriggerEvents
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion
                }
            }
        }

        public static void ShipyardArrived(ShipyardArrived Event)
        {
            string MethodName = "Logic: ShipyardArrived";

            Thread thread =
            new Thread((ThreadStart)(() =>
            {
                try
                {
                    if (Monitor.TryEnter(IEvents.ShipyardArrived.Montior))
                    {
                        while (IEvents.ShipyardArrived.Tranfers.Count != 0)
                        {
                            Thread.Sleep(15000); foreach (ShipyardArrived Tranfer in IEvents.ShipyardArrived.Tranfers)
                            {
                                Tranfer.Time = Tranfer.Time - 15;

                                if ((Tranfer.Time < 180) && Tranfer.ThreeMinOut)
                                {
                                    Tranfer.ThreeMinOut = false;

                                    #region Audio
                                    if (PlugIn.Audio == "TTS")
                                    {
                                        Speech.Speak
                                            (
                                            "".Phrase(Shipyard_Arrived.Three_Min_Warning)
                                            .Replace("[DESTINATION]", Tranfer.EndLocation)
                                            .Replace("[SHIP]", Tranfer.Ship)
                                            .Replace("[STATION]", Tranfer.EndStation),
                                            true,
                                            Check.Internal.TriggerEvents(true, MethodName)
                                            );
                                    }
                                    else if (PlugIn.Audio == "File") { }
                                    else if (PlugIn.Audio == "External") { }
                                    #endregion
                                }
                                else if (Tranfer.Time < 0)
                                {
                                    #region Audio
                                    if (PlugIn.Audio == "TTS")
                                    {
                                        Speech.Speak
                                            (
                                            "".Phrase(Shipyard_Arrived.Arrived)
                                            .Replace("[DESTINATION]", Tranfer.EndLocation)
                                            .Replace("[SHIP]", Tranfer.Ship)
                                            .Replace("[STATION]", Tranfer.EndStation),
                                            true,
                                            Check.Internal.TriggerEvents(true, MethodName)
                                            );
                                    }
                                    else if (PlugIn.Audio == "File") { }
                                    else if (PlugIn.Audio == "External") { }
                                    #endregion

                                    IEvents.ShipyardArrived.TriggerEvent();

                                    List<ShipyardArrived> Temp = new List<ShipyardArrived>();

                                    foreach (ShipyardArrived Item in IEvents.ShipyardArrived.Tranfers)
                                    { if (Item.Time > 0) { Temp.Add(Item); } }

                                    IEvents.ShipyardArrived.Tranfers = Temp;
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(IEvents.ShipyardArrived.Montior);
                }
            }))
            { IsBackground = true };
            thread.Start();
        }

        public static void StationDamage(StationDamage Event)
        {
            string MethodName = "Logic: Station Damage";

            StationHostile Temp = (StationHostile)IEvents.GetEvent(IEnums.StationHostile);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Station.Damaged)
                    .Replace("[STATON]", Event.Station),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void StationHostile(StationHostile Event)
        {
            string MethodName = "Logic: Station Hostile";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Station.Hostile)
                    .Replace("[STATON]", Event.Station),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        #region Under Construction

        public static void BlockAirlockMajor(BlockAirlockMajor Event)
        {
            string MethodName = "Block Airlock Major";
        }

        public static void BlockAirlockHostile(BlockAirlockHostile Event)
        {

        }

        public static void BlockLandingPadMajor(BlockLandingPadMajor Event)
        {
            string MethodName = "Block Airlock Major";
        }

        public static void BlockLandingPadHostile(BlockLandingPadHostile Event)
        {

        }

        public static void DisobeyPolice(DisobeyPolice Event)
        {
            string MethodName = "Disobey Police";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Disobey_Police),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void FireInStation(FireInStation Event)
        {
            string MethodName = "Fire In Station";
        }

        public static void IllegalCargo(IllegalCargo Event)
        {
            string MethodName = "Illegal Cargo";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Illegal_Cargo),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void Interdicting(Interdicting Event)
        {
            string MethodName = "Interdicting";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Interdicting),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void Murder(Murder Event)
        {
            string MethodName = "Murder";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Murder),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void Piracy(Piracy Event)
        {
            string MethodName = "Piracy";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Piracy),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void TrespassMinor(TrespassMinor Event)
        {
            string MethodName = "Trespass Minor";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Trespass_Minor),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void DumpingDangerous(DumpingDangerous Event)
        {
            string MethodName = "Dumping Dangerous";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Dumping_Dangerous),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void DumpingNearStation(DumpingNearStation Event)
        {
            string MethodName = "Dumping Near Station";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Dumping_Near_Station),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void TrespassMajor(TrespassMajor Event)
        {
            string MethodName = "Warning";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Block_Landing_Pad_Warning),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void WrecklessFlying(WrecklessFlying Event)
        {
            string MethodName = "Wreckless Flying";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Wreckless_Flying),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void WrecklessFlyingDamage(WrecklessFlyingDamage Event)
        {
            string MethodName = "Wreckless Flying Damage";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Wreckless_Flying_Damage),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }
        #endregion

        //End Region: Custom Event Logic
        #endregion

        #region Journal Event Logic

        public static void ApproachBody(ApproachBody Event)
        {
            string MethodName = "Logic ApproachBody";

            IStatus.Planet.OrbitalCruise(true);

            Post.ApproachBody(Event);
        }

        public static void LeaveBody(LeaveBody Event)
        {
            string MethodName = "Logic LeaveBody";
            
            IStatus.Planet.OrbitalCruise(false);
            IStatus.Planet.Response.OrbitaCruiseExit(true, Check.Internal.TriggerEvents(true, MethodName));
        }

        public static void Bounty(ALICE_Events.Bounty Event)
        {
            string MethodName = "Logic Bounty";
            //Save PilotName & ShipType before ShipTargeted Event Updates.

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(ALICE_Synthesizer.Bounty.Collected)
                    .Token("[NUM]", Event.TotalReward.ToString())
                    .Token("[SHIPTYPE]", Event.Target)
                    .Token("[PILOTNAME]", IObjects.TargetShip.PilotName_Localised),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName),
                    Check.Report.CollectedBounty(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void Commander(Commander Event)
        {
            string MethodName = "Logic Commander";
            
            ISettings.U_Commander(MethodName, Event.Name);
        }

        public static void Cargo(Cargo Event)
        {

        }

        public static void CargoDepot(CargoDepot Event)
        {

        }

        public static void CrewAssign(CrewAssign Event)
        {
            string MethodName = "Logic CrewAssign";

            #region Default Settings Update
            if (Event.Role == "Active")
            { IObjects.Status.NPC_Crew = true; }
            else
            { IObjects.Status.NPC_Crew = false; }

            Miscellanous.Default["NPC_Crew"] = IObjects.Status.NPC_Crew;
            Miscellanous.Default.Save();
            #endregion

            #region Audio: NPC Crew (Acitve Duty) || NPC Crew (On Shore Leave)
            if (PlugIn.MasterAudio == true && Check.Internal.TriggerEvents(true, MethodName) == true)
            {
                #region NPC Crew (Acitve Duty)
                if (Event.Role == "Active")
                {
                    if (PlugIn.Audio == "TTS")
                    {
                        string Line = "".Phrase(NPC_Crew.Active_Duty).Replace("[CREW MEMBER]", Event.Name);

                        Thread thread = new Thread((ThreadStart)(() => { SpeechService.Instance.Say(Line, true); }));
                        thread.IsBackground = true;
                        thread.Start();
                    }
                    else if (PlugIn.Audio == "File")
                    {

                    }
                    else if (PlugIn.Audio == "External")
                    {

                    }
                }
                #endregion

                #region NPC Crew (On Shore Leave)
                else if (Event.Role == "OnShoreLeave")
                {
                    if (PlugIn.Audio == "TTS")
                    {
                        string Line = "".Phrase(NPC_Crew.On_Shore_Leave).Replace("[CREW MEMBER]", Event.Name);

                        Thread thread = new Thread((ThreadStart)(() => { SpeechService.Instance.Say(Line, true); }));
                        thread.IsBackground = true;
                        thread.Start();
                    }
                    else if (PlugIn.Audio == "File")
                    {

                    }
                    else if (PlugIn.Audio == "External")
                    {

                    }
                }
                #endregion
            }
            #endregion
        }

        public static void CockpitBreached(CockpitBreached Event)
        {
            //Audio
        }

        public static void CodexEntry(CodexEntry Event)
        {
            Object_CodexEntry Temp = new Object_CodexEntry(); Temp.Process(Event);

            IObjects.SystemCurrent.Update_CodexEntries(Event);
        }

        public static void CommitCrime(CommitCrime Event)
        {
            string MethodName = "Logic CommitCrime";

            IEnums.CrimeType Crime = Utilities.ToEnum<IEnums.CrimeType>(Event.CrimeType);

            switch (Crime)
            {
                case IEnums.CrimeType.Assault:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    IEvents.Assult.Construct(Event);
                    break;
                case IEnums.CrimeType.MinorBlockingAirlock:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    IEvents.BlockAirlockMinor.Construct(Event);
                    break;
                case IEnums.CrimeType.MajorBlockingAirlock:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    IEvents.BlockAirlockMajor.Construct(Event);
                    break;
                case IEnums.CrimeType.MinorBlockingLandingPad:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    IEvents.BlockLandingPadMinor.Construct(Event);
                    break;
                case IEnums.CrimeType.MajorBlockingLandingPad:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    IEvents.BlockLandingPadMajor.Construct(Event);
                    break;
                case IEnums.CrimeType.FireInNoFireZone:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    IEvents.FireInNoFireZone.Construct(Event);
                    break;
                case IEnums.CrimeType.Murder:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    IEvents.Murder.Construct(Event);
                    break;
                case IEnums.CrimeType.Piracy:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.CrimeType.Interdicting:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.CrimeType.IllegalCargo:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.CrimeType.DisobeyPolice:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.CrimeType.FireInStation:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    IEvents.FireInStation.Construct(Event);
                    break;
                case IEnums.CrimeType.DumpingDangerous:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.CrimeType.DumpingNearStation:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.CrimeType.DockingMinor_Trespass:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.CrimeType.DockingMajor_Trespass:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.CrimeType.CollidedAtSpeedInNoFireZone:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.CrimeType.CollidedAtSpeedInNoFireZone_HullDamage:
                    Logger.Log(MethodName, Crime.ToString(), Logger.Yellow, true);
                    break;
                default:
                    #region Audio
                    if (PlugIn.Audio == "TTS")
                    {
                        Speech.Speak
                            (
                            "".Phrase(ALICE_Synthesizer.Crime.Default),
                            true,
                            Check.Internal.TriggerEvents(true, MethodName)
                            );
                    }
                    else if (PlugIn.Audio == "File") { }
                    else if (PlugIn.Audio == "External") { }
                    #endregion

                    Logger.Log(MethodName, "Detected New Crime Type: " + Event.CrimeType, Logger.Yellow);
                    Logger.Log(MethodName, "Please Provide Your Most Recent Journal Log To The Developers", Logger.Yellow);
                    break;
            }
        }

        public static void Docked(Docked Event)
        {
            string MethodName = "Logic Docked";

            IObjects.SystemCurrent.Update_Facility(Event);

            if (Check.Internal.TriggerEvents(true, MethodName) == true && 
                IStatus.Docking.State == IEnums.DockingState.Granted)
            { Post.Docked(Event); }

            #region Logic Table
            IObjects.Status.Docked = true;
            IObjects.Status.Vehicle = IEnums.Vehicles.Mothership;
            IObjects.Status.Hardpoints = false;
            IObjects.Status.Touchdown = false;
            IObjects.Status.LandingGear = true;
            IObjects.Status.FighterDeployed = false;
            IStatus.Docking.State = IEnums.DockingState.Docked;
            IStatus.Docking.StationName = Event.StationName;
            IStatus.Docking.StationType = Event.StationType;
            IStatus.Docking.Denial = IEnums.DockingDenial.NoReason;
            IStatus.Docking.LandingPad = -1;
            #endregion

            IStatus.Docking.Log.Status();
        }

        public static void DockFighter(DockFighter Event)
        {
            string MethodName = "Logic DockFighter";

            IObjects.Status.FighterStatus = "Docked";

            #region Audio: Fighter Docked
            if (PlugIn.MasterAudio == true && Check.Internal.TriggerEvents(true, MethodName) == true)
            {
                if (PlugIn.Audio == "TTS")
                {
                    string Line = "".Phrase(Fighter.Docked).Phrase(Fighter.Docked_Modifier, true);

                    Thread thread = new Thread((ThreadStart)(() => { SpeechService.Instance.Say(Line, true); }));
                    thread.IsBackground = true;
                    thread.Start();
                }
                else if (PlugIn.Audio == "File")
                {

                }
                else if (PlugIn.Audio == "External")
                {

                }
            }
            #endregion

            #region Logic Table
            IObjects.Status.FighterDeployed = false;
            #endregion
        }

        public static void DockingRequested(DockingRequested Event)
        {
            IStatus.Docking.State = IEnums.DockingState.Requested;
            IStatus.Docking.StationName = Event.StationName;
            IStatus.Docking.StationType = Event.StationType;
            IStatus.Docking.Denial = IEnums.DockingDenial.NoReason;

            #region Logic Table
            IStatus.Docking.Sending = false;
            IStatus.Docking.Pending = true;
            #endregion

            IStatus.Docking.Log.Status();
        }

        public static void DockingGranted(DockingGranted Event)
        {
            IStatus.Docking.State = IEnums.DockingState.Granted;
            IStatus.Docking.StationName = Event.StationName;
            IStatus.Docking.StationType = Event.StationType;
            IStatus.Docking.LandingPad = Event.LandingPad;
            IStatus.Docking.Denial = IEnums.DockingDenial.NoReason;

            #region Logic Table
            IStatus.Docking.Pending = false;
            #endregion

            IStatus.Docking.Log.Status();
        }

        public static void DockingDenied(DockingDenied Event)
        {
            string MethodName = "Logic DockingDenied";

            IStatus.Docking.State = IEnums.DockingState.Denied;
            IStatus.Docking.StationName = Event.StationName;
            IStatus.Docking.StationType = Event.StationType;
            IStatus.Docking.LandingPad = -1;
            IStatus.Docking.Denial = Utilities.ToEnum<IEnums.DockingDenial>(Event.Reason);

            if (IStatus.Docking.Denial == IEnums.DockingDenial.NotSet)
            { Logger.DevUpdateLog(MethodName, "Undefined Docking Denial State Detected: " + Event.Reason, Logger.Red); }

            #region Logic Table
            IStatus.Docking.Pending = false;
            IStatus.Docking.Sending = false;
            #endregion

            IStatus.Docking.Log.Status();
        }

        public static void DockingCancelled(DockingCancelled Event)
        {
            IStatus.Docking.State = IEnums.DockingState.Cancelled;
            IStatus.Docking.StationName = Event.StationName;
            IStatus.Docking.LandingPad = -1;

            #region Logic Table
            IStatus.Docking.Pending = false;
            IStatus.Docking.Sending = false;
            #endregion

            IStatus.Docking.Log.Status();
        }

        public static void EngineerProgress(EngineerProgress Event)
        {
            foreach (var Item in Event.Engineers)
            {
                var Target =  IObjects.Engineer.Get(Item.Engineer);

                Target.Name = Item.Engineer;
                Target.Rank = Item.Rank;
                Target.RankProgress = Item.RankProgress;
                Target.Progress = Item.Progress;

                IObjects.Engineer.Update(Target);
            }
        }

        public static void FighterDestroyed(FighterDestroyed Event)
        {
            string MethodName = "Logic FighterDestroyed";

            IObjects.Status.FighterStatus = "Destroyed";

            #region Fighter Destroyed
            if (PlugIn.MasterAudio == true && Check.Internal.TriggerEvents(true, MethodName) == true)
            {
                if (PlugIn.Audio == "TTS")
                {
                    string Line = "".Phrase(Fighter.Destroyed);

                    Thread thread = new Thread((ThreadStart)(() => { SpeechService.Instance.Say(Line, true); }));
                    thread.IsBackground = true;
                    thread.Start();
                }
                else if (PlugIn.Audio == "File")
                {

                }
                else if (PlugIn.Audio == "External")
                {

                }
            }
            #endregion

            #region Logic Table
            IObjects.Status.FighterDeployed = false;
            #endregion
        }

        public static void FighterRebuilt(FighterRebuilt Event)
        {
            string MethodName = "Logic FighterRebuilt";

            #region Audio: Fighter Rebuilt (Docked) || Fighter Rebuilt (Destroyed) || Fighter Rebuilt (Other)
            if (PlugIn.MasterAudio == true && Check.Internal.TriggerEvents(true, MethodName) == true)
            {
                #region Fighter Rebuilt (Docked)
                if (IObjects.Status.FighterStatus == "Docked")
                {
                    if (PlugIn.Audio == "TTS")
                    {
                        string Line = "".Phrase(Fighter.Rebuilt_Docked);

                        Thread thread = new Thread((ThreadStart)(() => { SpeechService.Instance.Say(Line, true); }));
                        thread.IsBackground = true;
                        thread.Start();
                    }
                    else if (PlugIn.Audio == "File")
                    {

                    }
                    else if (PlugIn.Audio == "External")
                    {

                    }
                }
                #endregion

                #region Fighter Rebuilt (Destroyed)
                else if (IObjects.Status.FighterStatus == "Destroyed")
                {
                    if (PlugIn.Audio == "TTS")
                    {
                        string Line = "".Phrase(Fighter.Rebuilt_Destroyed);

                        Thread thread = new Thread((ThreadStart)(() => { SpeechService.Instance.Say(Line, true); }));
                        thread.IsBackground = true;
                        thread.Start();
                    }
                    else if (PlugIn.Audio == "File")
                    {

                    }
                    else if (PlugIn.Audio == "External")
                    {

                    }
                }
                #endregion

                #region Fighter Rebuilt (Other)
                else
                {
                    if (PlugIn.Audio == "TTS")
                    {
                        string Line = "".Phrase(Fighter.Rebuilt_Other);

                        Thread thread = new Thread((ThreadStart)(() => { SpeechService.Instance.Say(Line, true); }));
                        thread.IsBackground = true;
                        thread.Start();
                    }
                    else if (PlugIn.Audio == "File")
                    {

                    }
                    else if (PlugIn.Audio == "External")
                    {

                    }
                }
                #endregion
            }
            #endregion

            IObjects.Status.FighterStatus = "Ready";
        }

        public static void FSDTarget(FSDTarget Event)
        {

        }

        public static void FSDJump(FSDJump Event)
        {
            string MethodName = "Logic FSDJump";

            IObjects.SysetmPrevious = IObjects.SystemCurrent;
            IObjects.SystemCurrent = new Object_System();
            IObjects.SystemCurrent = IObjects.SystemCurrent.Update_SystemData(Event);

            #region Logic Table
            IEquipment.DiscoveryScanner.FirstScan = true;

            IObjects.Status.Vehicle = IEnums.Vehicles.Mothership;
            IObjects.Status.Hardpoints = false;
            IObjects.Status.Touchdown = false;
            IObjects.Status.CargoScoop = false;
            IObjects.Status.LandingGear = false;
            IObjects.Status.Hyperspace = false;
            IObjects.Status.FighterDeployed = false;
            IObjects.Status.WeaponSafety = false;
            IStatus.Fuel.ScoopingReset();
            IStatus.Planet.OrbitalMode = false;
            IStatus.Planet.DecentReport = false;

            Call.Panel.Comms.Open = false;
            Call.Panel.System.Open = false;
            Call.Panel.Target.Open = false;
            Call.Panel.Role.Open = false;
            #endregion

            Post.FSDJump(Event);
        }

        public static void FSSAllBodiesFound(FSSAllBodiesFound Event)
        {
            string MethodName = "Logic FSSAllBodiesFound";

            IObjects.SystemCurrent.Update_SystemData(Event);
        }

        public static void FSSDiscoveryScan(FSSDiscoveryScan Event)
        {
            string MethodName = "Logic FSSDiscoveryScan";

            IEquipment.DiscoveryScanner.Waiting = false;

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(EQ_Discovery_Scanner.New_Returns)
                    .Phrase(EQ_Discovery_Scanner.Updating, false, IEquipment.DiscoveryScanner.FirstScan)
                    .Token("[SCANNUM]", Event.BodyCount),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion

            IEquipment.DiscoveryScanner.FirstScan = false;
            IObjects.SystemCurrent.Update_SystemData(Event);

            if (PlugIn.ExtendedLogging && Check.Internal.TriggerEvents(true, MethodName, true))
            { IObjects.SystemCurrent.Log_SystemBodies(); }            
        }

        public static void FuelScoop(FuelScoop Event)
        {
            string MethodName = "Logic FuelScoop";

            //Only Report If Scoop Is Enabled && Tank Is Full
            if (IStatus.Fuel.GetPercent() == 100) { IStatus.Fuel.ReportScooping(MethodName); }            
        }

        public static void HeatDamage(HeatDamage Event)
        {
            string MethodName = "Logic HeatDamage";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Heat_Damage.Default),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void HeatWarning(HeatWarning Event)
        {
            string MethodName = "Logic HeatWarning";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Heat_Warning.Default)
                    .Phrase(Heat_Warning.Modifier, true),
                    true,
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void HullDamage(HullDamage Event)
        {

        }

        public static void LaunchFighter(LaunchFighter Event)
        {
            IObjects.Status.FighterStatus = "Deployed";

            #region Logic Table
            Call.Action.Wait_FighterLaunch = false;
            IObjects.Status.FighterDeployed = true;
            #endregion
        }

        public static void Liftoff(Liftoff Event)
        {
            #region Logic Table
            IObjects.Status.WeaponSafety = false;
            #endregion

            Call.Action.LandingGear(false, false);            
        }

        public static void Location(Location Event)
        {
            if (Event.Docked == true || Event.Docked == false)
            {
                if (Event.Docked == true) { IStatus.Docking.State = IEnums.DockingState.Docked; }
                else { IStatus.Docking.State = IEnums.DockingState.Undocked; }
            }
            if (Event.StationName != null) { IStatus.Docking.StationName = Event.StationName; }
            if (Event.StationType != null) { IStatus.Docking.StationType = Event.StationType; }

            IObjects.SysetmPrevious = IObjects.SystemCurrent;
            IObjects.SystemCurrent = new Object_System();
            IObjects.SystemCurrent = IObjects.SystemCurrent.Update_SystemData(Event);

            IObjects.SystemCurrent.Update_SystemList();
            IStatus.Docking.Log.Status();
        }

        public static void MaterialCollected(MaterialCollected Event)
        {
            string MethodName = "Logic MaterialCollected";

            Logger.Log(MethodName, Event.Name.FirstCharToUpper() + " Collected", Logger.Yellow, true);

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    Event.Name + " Collected.",
                    true,
                    Check.Internal.TriggerEvents(true, MethodName),
                    Check.Report.MaterialCollected(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion         
        }

        public static void MarketBuy(MarketBuy Event)
        {
            //string Source = "Unknown";
            //if (IEvents.Events.ContainsKey("Docked"))
            //{
            //    Docked Dock = (Docked)IEvents.GetEvent("Docked");
            //    Source = Dock.StationName;
            //}

            //IObjects.Ship.Cargo_Add(Event.Type_Localised, Event.BuyPrice, Event.Count, Event.TotalCost, false, Source, Event.MarketID);
        }

        public static void MarketSell(MarketSell Event)
        {

        }

        public static void MiningRefined(MiningRefined Event)
        {
            //Audio
        }

        public static void Music(Music Event)
        {
            string MethodName = "Logic Music";

            IEnums.MusicState M = Utilities.ToEnum<IEnums.MusicState>(Event.MusicTrack);

            switch (M)
            {
                case IEnums.MusicState.CapitalShip:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Codex:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Combat_Dogfight:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Combat_SRV:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Combat_Unknown:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.CombatLargeDogFight:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.CQC:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.CQCMenu:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.DestinationFromHyperspace:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.DestinationFromSupercruise:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.DockingComputer:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Exploration:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.GalacticPowers:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.GalaxyMap:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Lifeform_FogCloud:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.MainMenu:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.NoTrack:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Supercruise:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Starport:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Squadrons:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.SystemAndSurfaceScanner:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.SystemMap:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Unknown_Exploration:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Unknown_Encounter:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                case IEnums.MusicState.Unknown_Settlement:
                    Logger.Log(MethodName, M.ToString(), Logger.Yellow, true);
                    break;
                default:
                    Logger.DevUpdateLog(MethodName, Event.MusicTrack + " Did Not Convert Or Is Not Being Tracked", Logger.Red, true);
                    break;
            }

            if (M != IEnums.MusicState.SystemAndSurfaceScanner)
            {
                IEquipment.SurfaceScanner.Mode = false;
                IEquipment.DiscoveryScanner.Mode = false;
            }
        }

        public static void NavBeconScan(NavBeaconScan Event)
        {

        }

        public static void ProspectedAsteroid(ProspectedAsteroid Event)
        {

        }

        public static void ReceivedText(ReceiveText Event)
        {
            //No Fire Zone
            if (Event.Message.Contains(IEnums.NoFireZone))
            { IEvents.NoFireZone.Construct(Event); }

            //Block Landing Pad Warning
            else if (Event.Message.Contains(IEnums.DockingPadBlockWarning))
            { IEvents.BlockLandingPadWarning.Construct(Event); }

            //Block Airlock Warning
            else if (Event.Message.Contains(IEnums.DockingDoorBlockWarning))
            { IEvents.BlockAirlockWarning.Construct(Event); }

            //Block Landing Pad Hostile
            else if (Event.Message.Contains(IEnums.DockingPadBlockHostile))
            { IEvents.BlockLandingPadWarning.Construct(Event); }

            //Block Airlock Hostile
            else if (Event.Message.Contains(IEnums.DockingDoorBlockHostile))
            { IEvents.BlockAirlockWarning.Construct(Event); }

            //Station Damage
            else if (Event.Message.Contains(IEnums.AccidentalDamage))
            { IEvents.StationDamage.Construct(Event); }

            //Station Hostile
            else if (Event.Message.Contains(IEnums.StationAggressorResponse))
            { IEvents.StationHostile.Construct(Event); }
        }

        public static void SAAScanComplete(SAAScanComplete Event)
        {
            string MethodName = "Logic SAAScanComplete";

            IObjects.SystemCurrent.Update_StellarBody(Event);

            if (PlugIn.ExtendedLogging && Check.Internal.TriggerEvents(true, MethodName, true))
            { IObjects.SystemCurrent.Log_SystemBodies(); }
        }

        public static void Scan(Scan Event)
        {
            IObjects.SystemCurrent.Update_StellarBody(Event);
        }

        public static void StartJump(StartJump Event)
        {
            string MethodName = "Logic StartJump";

            #region Logic Table
            IEquipment.FrameShiftDrive.Prepairing = false;
            IObjects.Status.Hardpoints = false;
            IObjects.Status.Touchdown = false;
            IObjects.Status.CargoScoop = false;
            IObjects.Status.LandingGear = false;
            IObjects.Status.Hyperspace = false;
            IObjects.Status.FighterDeployed = false;
            Call.Panel.System.Open = false;
            Call.Panel.Target.Open = false;
            Call.Panel.Role.Open = false;
            Call.Panel.Comms.Open = false;
            IObjects.Status.Docked = false;
            IObjects.Status.WeaponSafety = false;
            #endregion

            //Audio - Supercruise      
            if (IEquipment.FrameShiftDrive.SupercruiseCharge(true, MethodName))
            {
                IEquipment.FrameShiftDrive.SC_Entering(
                true, Check.Internal.TriggerEvents(true, MethodName));
            }
            //Audio - Hyperspace
            if (IEquipment.FrameShiftDrive.HyperspaceCharge(true, MethodName))
            {
                IEquipment.FrameShiftDrive.HS_Entering(
                true, Check.Internal.TriggerEvents(true, MethodName));
            }
        }

        public static void ShieldState(ShieldState Event)
        {
            string MethodName = "Logic Shield State";

            //Add Order to Enable/Disable Reports
        }

        public static void ShipyardTransfer(ShipyardTransfer Event)
        {
            string MethodName = "Logic Shipyard Transfer";

            //Custom Event - Shipyard Arrived.
            if (Check.Internal.TriggerEvents(true, MethodName))
            { IEvents.ShipyardArrived.Construct(Event); }            
        }

        public static void SupercruiseExit(SupercruiseExit Event)
        {
            string MethodName = "Logic SupercruiseExit";

            #region Logic Table
            IEquipment.FrameShiftDrive.Disengaging = false;            
            IStatus.Docking.Pending = false;
            IStatus.Docking.Sending = false;
            IEvents.FireInNoFireZone.FirstReport = true;

            IObjects.Status.Hardpoints = false;
            IObjects.Status.Touchdown = false;
            IObjects.Status.CargoScoop = false;
            IObjects.Status.LandingGear = false;
            IObjects.Status.Hyperspace = false;
            IObjects.Status.Supercruise = false;
            IObjects.Status.FighterDeployed = false;
            Call.Panel.System.Open = false;
            Call.Panel.Target.Open = false;
            Call.Panel.Role.Open = false;
            Call.Panel.Comms.Open = false;
            IObjects.Status.Docked = false;
            IStatus.Docking.Preparations = false;
            IObjects.Status.WeaponSafety = false;
            #endregion

            if (Check.Internal.TriggerEvents(true, MethodName) == true)
            { Post.SupercruiseExit(Event); }
        }

        public static void SupercruiseEntry(SupercruiseEntry Event)
        {
            #region Logic Table
            IStatus.Docking.Pending = false;
            IStatus.Docking.Sending = false;
            IEvents.FireInNoFireZone.FirstReport = true;

            IObjects.Status.Hardpoints = false;
            IObjects.Status.Touchdown = false;
            IObjects.Status.CargoScoop = false;
            IObjects.Status.LandingGear = false;
            IObjects.Status.Hyperspace = false;
            IObjects.Status.FighterDeployed = false;
            Call.Panel.System.Open = false;
            Call.Panel.Target.Open = false;
            Call.Panel.Role.Open = false;
            Call.Panel.Comms.Open = false;
            IObjects.Status.Docked = false;
            IStatus.Docking.Preparations = false;
            IObjects.Status.WeaponSafety = false;

            //Exiting Planet Prevents Abort Decent Report While Leaving The Planet.
            IStatus.Planet.ExitingPlanet = true;
            #endregion
        }

        public static void Touchdown(Touchdown Event)
        {
            #region Logic Table
            IObjects.Status.WeaponSafety = false;
            #endregion
        }

        public static void Undocked(Undocked Event)
        {
            string MethodName = "Logic Undocked";

            #region Logic Table
            IStatus.Docking.State = IEnums.DockingState.Undocked;
            IStatus.Docking.StationName = Event.StationName;
            IStatus.Docking.Denial = IEnums.DockingDenial.NoReason;
            IEvents.FireInNoFireZone.FirstReport = true;
            IStatus.Docking.Preparations = false;
            IObjects.Status.Hardpoints = false;
            IObjects.Status.Touchdown = false;
            IObjects.Status.CargoScoop = false;
            IObjects.Status.LandingGear = true;
            IObjects.Status.Hyperspace = false;
            IObjects.Status.Supercruise = false;
            IObjects.Status.FighterDeployed = false;
            IObjects.Status.Docked = false;
            #endregion

            if (Check.Internal.TriggerEvents(true, MethodName) == true)
            { Post.Undocked(Event); }
        }
        #endregion

        #region Json Events
        public static void Masslock(ALICE_Events.Masslock Event)
        {
            string MethodName = "Logic - Masslock";

            if (Event.Masslocked == true)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(Synth.Masslock.Entered),
                        true,
                        Check.Report.Masslock(true, MethodName),
                        Check.Internal.TriggerEvents(true, MethodName),
                        Check.Environment.Vehicle(IEnums.Vehicles.Mothership, true, MethodName)
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion
            }
            else if (Event.Masslocked == false)
            {
                #region Audio
                if (PlugIn.Audio == "TTS")
                {
                    Speech.Speak
                        (
                        "".Phrase(Synth.Masslock.Exited),
                        true,
                        Check.Report.Masslock(true, MethodName),
                        Check.Internal.TriggerEvents(true, MethodName),
                        Check.Environment.Vehicle(IEnums.Vehicles.Mothership, true, MethodName)
                        );
                }
                else if (PlugIn.Audio == "File") { }
                else if (PlugIn.Audio == "External") { }
                #endregion
            }
        }
        #endregion

        #region Json Status Updates
        public static void Position(decimal Lat, decimal Log, decimal Alt, decimal Head)
        {
            string MethodName = "Position Update";

            //Check & Record Altitude To Planets Status If In Supercruise.            
            if (Check.Environment.Space(IEnums.Supercruise, true, MethodName, true)) { IStatus.Planet.Decending(Alt); }

            //Approaching Planetary Decent Altitude.
            //1. Orbital Mode Engaged
            //2. Altitude Less Than 60km
            //3. Decent Report Not Made
            if (IStatus.Planet.OrbitalMode && Alt < 60000 && IStatus.Planet.DecentReport == false)
            {
                IStatus.Planet.Response.OrbitalDecentPreps(true, Check.Internal.TriggerEvents(true, MethodName));
                IStatus.Planet.DecentReport = true;
            }

            //Leaving Planetary Decent Alitude.
            //1. Orbital Mode Engaged
            //2. Altitude Greater Than 80km
            //3. Decent Report Made
            //4. We Are Not Exiting The Planet
            if (IStatus.Planet.OrbitalMode && Alt > 80000 && IStatus.Planet.DecentReport == true && IStatus.Planet.ExitingPlanet == false)
            {
                IStatus.Planet.Response.OrbitalDecentAborted(true, Check.Internal.TriggerEvents(true, MethodName));
                IStatus.Planet.DecentReport = false;
            }            
        }
        #endregion
    }

    /// <summary>
    /// Post is a logic processing area for events which will run on a new thread, execute a complex process or should be completed once everything else has finished.
    /// </summary>
    public static class Post
    {
        public static void ApproachBody(ApproachBody Event)
        {
            string MethodName = "Post ApproachBody";

            IStatus.Planet.Response.OrbitaCruiseEntry(true, Check.Internal.TriggerEvents(true, MethodName));

            IObjects.StellarBodyCurrent = IObjects.SystemCurrent.Get_StellarBody(Event.BodyID);
            if (IObjects.StellarBodyCurrent.ID != Event.BodyID)
            {
                IStatus.Planet.Response.OrbitalNotScanned(true, Check.Internal.TriggerEvents(true, MethodName));
            }
            else if (IObjects.StellarBodyCurrent.Gravity > 1.25M)
            {
                IStatus.Planet.Response.OrbitalGravityWarning(true, Check.Internal.TriggerEvents(true, MethodName));
            }
        }

        public static void Docked(Docked Event)
        {
            string MethodName = "Post Docked";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Facility_Report.Docked)
                    .Phrase(Facility_Report.Datalink)
                    .Token("[STATION]", IObjects.FacilityCurrent.Name),
                    true,
                    Check.Report.StationStatus(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }

            Thread.Sleep(100);
            #endregion

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Facility_Report.Government)
                    .Phrase(Facility_Report.Economy)
                    .Phrase(Facility_Report.State, false, true, (Check.State.FacilityCurrent_State("None", false, MethodName)))
                    .Token("[ECONOMY]", IObjects.FacilityCurrent.Economy)
                    .Token("[GOVERNMENT]", IObjects.FacilityCurrent.Government)
                    .Token("[ALLEGIANCE]", IObjects.FacilityCurrent.Allegiance)
                    .Token("[STATION]", IObjects.FacilityCurrent.Name)
                    .Token("[STATE]", IObjects.FacilityCurrent.ControlFactionState),
                    Check.Report.StationStatus(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion

            #region Station Services / Hanger Entry
            Thread Action =
            new Thread((ThreadStart)(() =>
            {
                #region Hanger Entry & Open Station Services
                Thread.Sleep(1000 + ISettings.User.OffsetPanels);

                Call.Key.Press(Call.Key.UI_Panel_Up_Press, 500);
                Call.Key.Press(Call.Key.UI_Panel_Up_Release, 100);

                if (Check.Order.AssistHangerEntry(true, MethodName))
                {
                    Call.Key.Press(Call.Key.UI_Panel_Down, 100);
                    Call.Key.Press(Call.Key.UI_Panel_Select, 100);
                    Call.Key.Press(Call.Key.UI_Panel_Up, 100);
                }

                Call.Key.Press(Call.Key.UI_Panel_Select, 100);
                #endregion

                #region Action: Refuel | Rearm | Repair

                //if (Check.Order.AssistRearm(true, MethodName) || Check.Order.AssistRefuel(true, MethodName) || Check.Order.AssistRepair(true, MethodName))
                //{
                //    Thread.Sleep(7000 + PlugIn.Sleep_PanelSpeed);

                //    Call.Key.Press(Call.Key.UI_Panel_Right, 100);
                //    Call.Key.Press(Call.Key.UI_Panel_Right, 100);
                //    Call.Key.Press(Call.Key.UI_Panel_Down, 100);
                //    Call.Key.Press(Call.Key.UI_Panel_Down, 100);

                //    if (Check.Order.AssistRefuel(true, MethodName))
                //    {
                //        Call.Key.Press(Call.Key.UI_Panel_Select, 100);
                //        Call.Key.Press(Call.Key.UI_Panel_Down, 100);
                //    }
                //    else if (Check.Order.AssistRepair(true, MethodName) || Check.Order.AssistRearm(true, MethodName))
                //    {
                //        Call.Key.Press(Call.Key.UI_Panel_Down, 100);
                //    }

                //    if (Check.Order.AssistRepair(true, MethodName))
                //    {
                //        Call.Key.Press(Call.Key.UI_Panel_Select, 100);
                //        Call.Key.Press(Call.Key.UI_Panel_Down, 100);
                //    }
                //    else if (Check.Order.AssistRearm(true, MethodName))
                //    {
                //        Call.Key.Press(Call.Key.UI_Panel_Down, 100);
                //    }

                //    if (Check.Order.AssistRearm(true, MethodName))
                //    {
                //        Call.Key.Press(Call.Key.UI_Panel_Select, 100);
                //    }
                //}

                #endregion
            }))
            { IsBackground = true };
            Action.Start();
            #endregion
        }

        public static void FSDJump(FSDJump Event)
        {
            string MethodName = "Post Jump Checks";

            if (Check.Internal.TriggerEvents(true, MethodName) == false) { return; }

            Thread.Sleep(100);

            #region Discovery Scan (New Thread)
            if (Check.Order.AssistSystemScan(true, MethodName))
            {
                Thread DisScan = new Thread((ThreadStart)(() => { Call.Action.DiscoveryScanner(true, true); }));
                DisScan.IsBackground = true;
                DisScan.Start();
            }
            #endregion

            #region Post Hyperspace Safety
            if (Check.Order.PostJumpSafety(true, MethodName))
            {
                Logger.DebugLine(MethodName, "Post Jump Safeties Are Enabled.", Logger.Blue);                
                Call.Key.Press(Call.Key.Set_Speed_To_0, 0);
            }
            #endregion

            #region Fuel Reports
            Logger.Log(MethodName, "Fuel Levels At " + decimal.Round(IStatus.Fuel.GetPercent(), 2).ToString() + " Percent", Logger.Blue);
            if (Check.Report.FuelStatus(true, MethodName) == true) { IStatus.Fuel.Report = true; }
            #endregion

            //System Report. Security, Allegiance, ect...
        }

        public static void SupercruiseExit(SupercruiseExit Event)
        {
            string MethodName = "Post Supercruise";

            #region Assisted Docking Procedure
            if (Check.Order.AssistDocking(true, MethodName) == true)
            {
                if (Check.Event.SupercruiseExit.BodyType(IEnums.Station, true, MethodName) == true)
                {
                    Thread thread =
                    new Thread((ThreadStart)(() =>
                    {
                        Logger.Log(MethodName, "Assisted Docking: Standing By To Send Docking Request...", Logger.Yellow, true);
                        //While Assisted Docking is True and BodyType equals Station Check For Next Trigger for 60 Seconds.
                        int i = 600; while (i > 0 && Check.Order.AssistDocking(true, MethodName, true) == true && Check.Event.SupercruiseExit.BodyType(IEnums.Station, true, MethodName, true) == true)
                        {
                            //Check NoFireZone and Masslock. If both true send a Docking Request.
                            i--; if (Check.Event.NoFireZone.Entered(true, MethodName) == true && Check.Variable.MassLocked(true, MethodName) == true)
                            {
                                Call.Action.Docking(IEnums.CMD.True, true, false);
                                return;
                            }
                            Thread.Sleep(100);
                        }
                        Logger.Log(MethodName, "Assisted Docking: Switched To Manual Docking. You Took Too Long...", Logger.Yellow, true);
                    }))
                    { IsBackground = false };
                    thread.Start();
                }
            }
            #endregion

            #region Assisted Landing Preparations
            if (Event.BodyType == IEnums.Planet && IObjects.Status.Altitude != 0)
            {
                Thread LandingPrep_thread =
                new Thread((ThreadStart)(() =>
                {                    
                    Logger.Log(MethodName, "Assisted Landing Preparations: Waiting To Exit Glide...", Logger.Yellow, true);

                    //If BodyType = Planet & FSD Cooldown = True it means the ship has left Glide.
                    int i2 = 600; while (IEquipment.FrameShiftDrive.Cooldown != true)
                    {
                        i2--; if (i2 <= 0)
                        {
                            Logger.Log(MethodName, "Assisted Landing Preparations: Landing Preparations Deactivated. Did Not Detect Exiting Glide In A Timely Manner...", Logger.Yellow, true);                            
                            return;
                        }
                        Thread.Sleep(100);
                    }

                    Logger.Log(MethodName, "Assisted Landing Preparations: Monitoring Altitude for 60 Seconds...", Logger.Yellow, true);
                    
                    //Monitor Altitude For 60 Seconds.
                    int i = 600; while (i > 0 && IObjects.Status.Altitude > 500)
                    {
                        Thread.Sleep(100); i--; if (i <= 0)
                        {
                            Logger.Log(MethodName, "Assisted Landing Preparations:  Timmed Out, You Took Too Long...", Logger.Yellow, true);
                            return;
                        }
                    }

                    if (IObjects.Status.Altitude <= 500)
                    {                        
                        Call.Action.LandingPreparations(true);
                    }

                }))
                {
                    IsBackground = false
                };
                LandingPrep_thread.Start();
            }
            #endregion

            #region Glide Montior
            if (Event.BodyType == "Planet" && IObjects.Status.Altitude != 0)
            {
                Thread Glide_thread =
                new Thread((ThreadStart)(() =>
                {
                    //If BodyType = Planet And FSD Cooldown = True it means the ship has left Glide.
                    Logger.Log(MethodName, "Glide Monitor: Monitoring...", Logger.Yellow, true);
                    int i2 = 600; while (IEquipment.FrameShiftDrive.Cooldown != true)
                    {
                        i2--; if (i2 <= 0)
                        {
                            Logger.Log(MethodName, "Glide Monitor: Stopped Montitoring, You Took To Long...", Logger.Yellow, true);
                            return;
                        }
                        Thread.Sleep(100);
                    }

                    //If Altitude is less than 10km then the Glide Should have been sucessful.
                    if (IObjects.Status.Altitude < 10000)
                    {
                        #region Audio
                        if (PlugIn.Audio == "TTS")
                        {
                            Speech.Speak
                                (
                                "".Phrase(GN_Planetary_Interaction.Glide_Complete),
                                true
                                );
                        }
                        else if (PlugIn.Audio == "File") { }
                        else if (PlugIn.Audio == "External") { }
                        #endregion
                    }
                    //if Altitdue is more then 10km then the Glide Failed.
                    else
                    {
                        Logger.Log(MethodName, "Glide Monitor: Glide Failed, Better Luck Next Time...", Logger.Yellow, true);
                        //Audio
                    }
                }))
                {
                    IsBackground = false
                };
                Glide_thread.Start();
            }
            #endregion
        }

        public static void Undocked(Undocked Event)
        {
            string MethodName = "Post Undocked";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Facility_Report.Undocked)
                    .Phrase(Facility_Report.Undocked_Modifier),
                    true,
                    Check.Report.Masslock(true, MethodName),
                    Check.Internal.TriggerEvents(true, MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion

            #region Landing Gear
            Thread.Sleep(250);
            Call.Action.LandingGear(false, false);
            #endregion

            #region Firegroup Update
            Thread Action = new Thread((ThreadStart)(() => { Call.Firegroup.Update_Total(false); }))
            { IsBackground = true }; Action.Start();
            #endregion
        }
    }
}