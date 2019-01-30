using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Core;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;

namespace ALICE_Equipment
{
    public class Equipment_FuelTank : Equipment_General
    {
        //Status Tracking Properties
        public bool ScoopingCompleted = false;          //Custom Property
        public bool ScoopingCommenced = false;          //Custom Property
        public bool Critical = false;                   //Custom Property
        public bool Low = false;                        //Status.json Property
        public bool HalfThreshold = false;              //Custom Property
        public bool Report = false;                     //Custom Property
        public decimal ScoopStartLv { get; set; }       //Custom Property
        public decimal Main { get; set; }               //Status.json Property
        public decimal Reservoir { get; set; }          //Status.json Property
        public decimal Scooped { get; set; }            //FuelScoop Event Property
        public readonly decimal SRVCapacity = 0.45M;    //Custom Property

        public Equipment_FuelTank()
        {
            Settings.Equipment = IEquipment.E.Fuel_Tank;
            Settings.Mode = IEquipment.M.Default;
            Settings.Installed = true;
            Settings.Enabled = true;
            Settings.Total = -1;       //Loadout Event Property - Total Number Of Fuel Tanks
            Settings.Capacity = -1;    //Loadout Event Property - Total Capacity Of Fuel
        }

        public Equipment_FuelTank New() { return new Equipment_FuelTank(); }

        #region Conversions
        /// <summary>
        /// Converts Percent To String. Rounds Percent Logically.
        /// </summary>
        /// <param name="Decimals">The number of decimals you'd like to keep.</param>
        /// <returns>Returns string of the current fuel percent.</returns>
        public string PercentToString(int Decimals)
        {
            string MethodName = "Percent To String";
            string Text = "";

            //Get Current Fuel Percent
            decimal Percent = GetPercent();

            //Check If Fuel Percent Returned "Not Set/Unknown"
            if (Percent == -1)
            { Text = "Unknown"; }

            //Check If Fuel Percent Is A Whole Number
            else if ((Percent % 1) == 0)
            { Text =  Decimal.Round(Percent, 0).ToString(); }

            //Round & Convert To String
            else { Text = Decimal.Round(Percent, Decimals).ToString(); }

            //Debug Logger
            Logger.DebugLine(MethodName, Text, Logger.Blue);

            return Text;
        }

        /// <summary>
        /// Converts Tons To String. Rounds Percent Logically.
        /// </summary>
        /// <param name="Decimals">The number of decimals you'd like to keep.</param>
        /// <returns>Returns string of the current fuel tons.</returns>
        public string TonsToString(int Decimals)
        {
            //Check If Fuel Tons Is Not Set / Unknown
            if (Main == -1)
            { return "Unknown"; }
            //Check If Fuel Tons Is A Whole Number
            else if ((Main % 1) == 0)
            { return Decimal.Round(Main, 0).ToString(); }
            //Round & Convert To String
            else
            { return Decimal.Round(Main, Decimals).ToString(); }
        }

        /// <summary>
        /// Converts Fuel Scooped To String. Rounds Percent Logically.
        /// </summary>
        /// <param name="Decimals">The number of decimals you'd like to keep.</param>
        /// <returns>Returns string of the scooped fuel.</returns>
        public string ScoopingDiffToString(int Decimals)
        {
            //Check If Fuel Tons Is Not Set / Unknown
            if (ScoopingDiff() == -1)
            { return "Unknown"; }
            //Check If Fuel Tons Is A Whole Number
            else if ((ScoopingDiff() % 1) == 0)
            { return Decimal.Round(Main, 0).ToString(); }
            //Round & Convert To String
            else
            { return Decimal.Round(ScoopingDiff(), Decimals).ToString(); }
        }
        #endregion

        #region Support Methods
        public decimal GetPercent()
        {
            string MethodName = "Fuel Percent";

            Logger.DebugLine(MethodName, "Fuel Level: " + Main + " | Fuel Capacity: " + Settings.Capacity, Logger.Blue);

            //Calculate Percent Based On Vehicle
            decimal Percent = 0; switch (IVehicles.Vehicle)
            {
                case IVehicles.V.Default:
                    Logger.DebugLine(MethodName, "Vehicle: " + IVehicles.Vehicle.ToString(), Logger.Blue);
                    return -1;

                case IVehicles.V.Mothership:
                    Logger.DebugLine(MethodName, "Vehicle: " + IVehicles.Vehicle.ToString(), Logger.Blue);
                    if (Settings.Capacity >= 0) { Percent = Main / Settings.Capacity; }
                    if (Percent > 1) { Percent = 1; }
                    Logger.DebugLine(MethodName, "Fuel Percent: " + Percent * 100 + "%", Logger.Blue);
                    return Percent * 100;

                case IVehicles.V.Fighter:
                    Logger.DebugLine(MethodName, "Vehicle: " + IVehicles.Vehicle.ToString(), Logger.Blue);
                    return -1;

                case IVehicles.V.SRV:
                    Logger.DebugLine(MethodName, "Vehicle: " + IVehicles.Vehicle.ToString(), Logger.Blue);
                    Percent = Main / SRVCapacity;
                    if (Percent > 1) { Percent = 1; }
                    Logger.DebugLine(MethodName, "Fuel Percent: " + Percent * 100 + "%", Logger.Blue);
                    return Percent * 100;

                default:
                    return -1;
            }
        }

        public void ScoopingReset()
        {
            ScoopingCompleted = false;
            ScoopingCommenced = false;
            Scooped = 0;
        }

        public decimal ScoopingDiff()
        { return Main - ScoopStartLv; }

        /// <summary>
        /// Updates Fuel Status Object with the Status.JSON Data.
        /// </summary>
        /// <param name="Level">FuelInfo Object</param>
        public void Update(FuelInfo Level)
        {
            string MethodName = "Fuel Status (Update)";

            try
            {
                //Only Report Mothership & SRV Levels
                if (GetPercent() == -1) { return; }

                bool Decreased = (Main > Level.FuelMain);
                Main = Level.FuelMain;
                Reservoir = Level.FuelReservoir;

                //Custom Events
                if (ALICE_Internal.Check.Internal.JsonInitialized(true, MethodName, true))
                {
                    //Event = FuelHalfThreshold
                    if (Decreased == true && HalfThreshold == false && GetPercent() <= 50 && GetPercent() > 25)
                    { IEvents.FuelHalfThreshold.Logic(); Report = true; }
                    //Event - FuelLow
                    else if (Decreased == true && Low == false && GetPercent() <= 25 && GetPercent() > 10)
                    { IEvents.FuelLow.Logic(); Report = true; }
                    //Event - FuelCritical
                    else if (Decreased == true && Critical == false && GetPercent() <= 10)
                    { IEvents.FuelCritical.Logic(); Report = true; }
                    //Reset Bool
                    else if (GetPercent() > 50)
                    { Critical = false; Low = false; HalfThreshold = false; }
                }

                if (Report)
                {
                    FuelLevel(true, ALICE_Internal.Check.Report.FuelStatus(true, MethodName));
                    Report = false;
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
                Logger.Exception(MethodName, "Ingnoring Expection, Attempting To Continue...");
                Logger.Exception(MethodName, "Something Went Wrong Processing The (Status.Json) Fuel Level");
            }
        }

        /// <summary>
        /// Updates Fuel status Object with the LoadGame Event Data.
        /// </summary>
        /// <param name="Event">LoadGame Event</param>
        public void Update(LoadGame Event)
        {
            string MethodName = "Fuel Status (Update)";

            try
            {
                Settings.Capacity = Event.FuelCapacity;
                Main = Event.FuelLevel;
            }
            catch (Exception ex)
            {
                Logger.Exception(MethodName, "Execption: " + ex);
                Logger.Exception(MethodName, "Ingnoring Expection, Attempting To Continue...");
                Logger.Exception(MethodName, "Something Went Wrong Processing The " + Event.Event + " Event");
            }
        }

        //Convert This To Update Method Structure.
        public void ReportScooping(string TriggeredMethodName)
        {
            string MethodName = "Fuel Status Scooping" + " (" + TriggeredMethodName + ")";

            //Fuel Scoop Report Check
            if (ALICE_Internal.Check.Report.FuelScoop(true, MethodName) == false && ScoopingCompleted != true) { return; }

            //Scooping Commenced Report Not Made
            if (ScoopingCommenced == false)
            {
                ScoopingCommenced = true; ScoopStartLv = Main;
                ScoopingStart(true, ALICE_Internal.Check.Report.FuelScoop(true, MethodName), ALICE_Internal.Check.Internal.TriggerEvents(true, MethodName));
            }

            //Scooping Complete Report Not Made && Scooping Has Stopped
            //Scooping Complete Report Not Made && Fuel Level Is 100%
            else if ((ScoopingCompleted == false && IObjects.Status.FuelScooping == false) || (ScoopingCompleted == false && GetPercent() == 100))
            {
                ScoopingCompleted = true;
                ScoopingEnd(true, ALICE_Internal.Check.Report.FuelScoop(true, MethodName), ALICE_Internal.Check.Internal.TriggerEvents(true, MethodName));
            }
        }
        #endregion

        #region Audio
        public void ScoopingEnd(bool CommandAudio, bool Var1 = true, bool Var2 = true,
        bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Scooping Complete. Reserves: " + GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Fuel_Report.Scoop_End)
                .Phrase(GN_Fuel_Report.Scoop_Collected, true)
                .Phrase(GN_Fuel_Report.Level_Percent, true)
                .Replace("[PERCENT]", PercentToString(2))
                .Replace("[FUELTONS]", ScoopingDiffToString(2)),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void ScoopingStart(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Scooping Commenced. Reserves: " + GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Fuel_Report.Scoop_Start),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void FuelLevel(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fuel Level. Reserves: " + GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(Speech.Pick(new List<string>[] { GN_Fuel_Report.Level_Percent, GN_Fuel_Report.Level_Tons }))
                .Replace("[PERCENT]", PercentToString(2))
                .Replace("[FUELTONS]", TonsToString(2)),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void FuelCritical(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fuel Critical. Reserves: " + GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Fuel_Report.Critical_Level)
                .Phrase(Speech.Pick(new List<string>[] { GN_Fuel_Report.Level_Percent, GN_Fuel_Report.Level_Tons }))
                .Token("[PERCENT]", decimal.Round(GetPercent(), 0).ToString())
                .Token("[FUELTONS]", decimal.Round(Main, 1).ToString()),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void FuelLow(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fuel Low. Reserves: " + GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Fuel_Report.Low_Level)
                .Phrase(Speech.Pick(new List<string>[] { GN_Fuel_Report.Level_Percent, GN_Fuel_Report.Level_Tons }))
                .Token("[PERCENT]", decimal.Round(GetPercent(), 0).ToString())
                .Token("[FUELTONS]", decimal.Round(Main, 1).ToString()),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void FuelHalf(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Fuel Half Capacity. Reserves: " + GetPercent() + "%", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(Speech.Pick(new List<string>[] { GN_Fuel_Report.Level_Percent, GN_Fuel_Report.Level_Tons }))
                .Token("[PERCENT]", decimal.Round(GetPercent(), 0).ToString())
                .Token("[FUELTONS]", decimal.Round(Main, 1).ToString()),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion
    }
}