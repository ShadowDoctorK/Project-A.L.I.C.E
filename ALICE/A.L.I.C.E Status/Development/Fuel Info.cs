using ALICE_Debug;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Response;
using System;

namespace ALICE_Status
{
    public static partial class IStatus
    {
        public static FuelStatus Fuel { get; set; } = new FuelStatus();
    }

    public class FuelStatus
    {
        private readonly string ClassName = "Status (Fuel)";

        //Status Tracking Properties
        public bool ScoopingCompleted = false;          //Custom Property
        public bool ScoopingCommenced = false;          //Custom Property
        public bool Report = false;                     //Custom Property
        public decimal Scooped { get; set; }            //FuelScoop Event Property
        public decimal ScoopStartLv { get; set; }       //Custom Property

        //Vehicle Referenced Properties
        public decimal Main                             //Status.json Property
        {
            get
            {
                switch (IStatus.Vehicle)
                {                    
                    case IStatus.V.Mothership: return IStatus.Mothership.Fuel.Main;
                    //case IStatus.V.Fighter: return 1;
                    case IStatus.V.SRV:  return IStatus.SRV.Fuel.Main;
                    default: return 1;
                }
            }

            set
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: IStatus.Mothership.Fuel.Main = value; return;
                    //case IStatus.V.Fighter: return;
                    case IStatus.V.SRV: IStatus.SRV.Fuel.Main = value; return;
                    default: return;
                }
            }
        }
        public decimal Reserve                          //Status.json Property
        {
            get
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: return IStatus.Mothership.Fuel.Reserve;
                    //case IStatus.V.Fighter: return 1;
                    case IStatus.V.SRV: return IStatus.SRV.Fuel.Reserve;
                    default: return 1;
                }
            }

            set
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: IStatus.Mothership.Fuel.Reserve = value; return;
                    //case IStatus.V.Fighter: return;                    
                    case IStatus.V.SRV: IStatus.SRV.Fuel.Reserve = value;  return;
                    default: return;
                }
            }
        }
        public decimal Capacity                         //IStatus Vehicle
        {
            get
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: return IStatus.Mothership.Fuel.Capacity;
                    //case IStatus.V.Fighter: return 1;
                    case IStatus.V.SRV: return IStatus.SRV.Fuel.Capacity;
                    default: return 1;
                }
            }

            set
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: IStatus.Mothership.Fuel.Capacity = value; return;
                    //case IStatus.V.Fighter: return;
                    //case IStatus.V.SRV: return;
                    default: return;
                }
            }
        }
        public decimal Reservoir                        //IStatus Vehicle
        {
            get
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: return IStatus.Mothership.Fuel.Reservior;
                    case IStatus.V.Fighter: return 1;
                    case IStatus.V.SRV: return IStatus.SRV.Fuel.Reservior;
                    default: return 1;
                }
            }

            set
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: IStatus.Mothership.Fuel.Reservior = value; return;
                    //case IStatus.V.Fighter: return;
                    //case IStatus.V.SRV: return;
                    default: return;
                }
            }
        }
        public bool Critical                            //Custom Property
        {
            get
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: return IStatus.Mothership.Fuel.Critical;
                    //case IStatus.V.Fighter: return true;
                    case IStatus.V.SRV: return IStatus.SRV.Fuel.Critical;
                    default: return true;
                }
            }

            set
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: IStatus.Mothership.Fuel.Critical = value; return;
                    //case IStatus.V.Fighter: return;
                    case IStatus.V.SRV: IStatus.SRV.Fuel.Critical = value; return;
                    default: return;
                }
            }
        }
        public bool Low                                 //Status.json Property
        {
            get
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: return IStatus.Mothership.Fuel.Low;
                    //case IStatus.V.Fighter: return true;
                    case IStatus.V.SRV: return IStatus.SRV.Fuel.Low;
                    default: return true;
                }
            }

            set
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: IStatus.Mothership.Fuel.Low = value; return;
                    //case IStatus.V.Fighter: return;
                    case IStatus.V.SRV: IStatus.SRV.Fuel.Low = value; return;
                    default: return;
                }
            }
        }
        public bool HalfThreshold                       //Custom Property
        {
            get
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: return IStatus.Mothership.Fuel.HalfThreshold;
                    //case IStatus.V.Fighter: return true;
                    case IStatus.V.SRV: return IStatus.SRV.Fuel.HalfThreshold;
                    default: return true;
                }
            }

            set
            {
                switch (IStatus.Vehicle)
                {
                    case IStatus.V.Mothership: IStatus.Mothership.Fuel.HalfThreshold = value; return;
                    //case IStatus.V.Fighter: return;
                    case IStatus.V.SRV: IStatus.SRV.Fuel.HalfThreshold = value; return;
                    default: return;
                }
            }
        }

        /// <summary>
        /// Updates Fuel status Object with the FuelScoop Event Data.
        /// </summary>
        /// <param name="Event">FuelScoop Event</param>
        public void Update(FuelScoop Event)
        {
            string MethodName = "Fuel Status (FuelScoop)";

            //Only Report If Scoop Is Enabled && Tank Is Full
            if (GetPercent() >= 100)
            {
                Scooping(MethodName);
            }
        }

        /// <summary>
        /// Updates Fuel status Object with the LoadGame Event Data.
        /// </summary>
        /// <param name="Event">LoadGame Event</param>
        public void Update(LoadGame Event)
        {
            string ClassName = "Fuel Status (LoadGame)";

            try
            {
                //Capacity = Event.FuelCapacity;
                Main = Event.FuelLevel;
            }
            catch (Exception ex)
            {
                Logger.Exception(ClassName, "Execption: " + ex);
                Logger.Exception(ClassName, "Ingnoring Expection, Attempting To Continue...");
                Logger.Exception(ClassName, "Something Went Wrong Processing The " + Event.Event + " Event");
            }
        }

        /// <summary>
        /// Updates Fuel status Object with the Loadout Event Data.
        /// </summary>
        /// <param name="Event">Loadout Event</param>
        public void Update(Loadout Event)
        {
            string ClassName = "Fuel Status (Loadout)";

            try
            {
                Capacity = Event.FuelCapacity.Main;
                Reservoir = Event.FuelCapacity.Reserve;
            }
            catch (Exception ex)
            {
                Logger.Exception(ClassName, "Execption: " + ex);
                Logger.Exception(ClassName, "Ingnoring Expection, Attempting To Continue...");
                Logger.Exception(ClassName, "Something Went Wrong Processing The " + Event.Event + " Event");
            }
        }

        #region Conversions
        /// <summary>
        /// Converts Percent To String. Rounds Percent Logically.
        /// </summary>
        /// <param name="Decimals">The number of decimals you'd like to keep.</param>
        /// <returns>Returns string of the current fuel percent.</returns>
        public string PercentToString(int Decimals)
        {
            //Get Current Fuel Percent
            decimal Percent = GetPercent();

            //Check If Fuel Percent Returned "Not Set/Unknown"
            if (Percent == -1)
            {
                return "Unknown";
            }

            //Check If Fuel Percent Is A Whole Number
            else if ((Percent % 1) == 0)
            {
                return Decimal.Round(Percent, 0).ToString();
            }

            //Round & Convert To String
            else
            {
                return Decimal.Round(Percent, Decimals).ToString();
            }

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
            {
                return "Unknown";
            }

            //Check If Fuel Tons Is A Whole Number
            else if ((Main % 1) == 0)
            {
                return Decimal.Round(Main, 0).ToString();
            }

            //Round & Convert To String
            else
            {
                return Decimal.Round(Main, Decimals).ToString();
            }
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
            {
                return "Unknown";
            }

            //Check If Fuel Tons Is A Whole Number
            else if ((ScoopingDiff() % 1) == 0)
            {
                return Decimal.Round(Main, 0).ToString();
            }

            //Round & Convert To String
            else
            {
                return Decimal.Round(ScoopingDiff(), Decimals).ToString();
            }
        }
        #endregion

        #region Support Methods

        /// <summary>
        /// Gets The Current Vehicles Fuel Level As A Percent.
        /// </summary>
        /// <returns></returns>
        public decimal GetPercent()
        {
            string MethodName = "Fuel Status (Get Percent)";

            //Default Value
            decimal Percent = 100;

            try
            {
                //Process
                if (Capacity != -1 && Capacity != 0)
                {
                    //Calculate
                    Percent = Main / Capacity;

                    //Check Larger Than 1
                    if (Percent > 1)
                    {
                        Percent = 1;
                    }

                    //Return X 100
                    return Percent * 100;
                }

                //Default
                else
                {
                    //Debug Logger
                    Logger.DebugLine(MethodName, "Returning Default Value. Capacity = " + Capacity, Logger.Yellow);

                    return Percent;
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ClassName, "Exception: " + ex);
                return 100;
            }
        }

        /// <summary>
        /// Resets The Fuel Scooping Items For Next Scooping Event.
        /// </summary>
        public void ScoopingReset()
        {
            ScoopingCompleted = false;
            ScoopingCommenced = false;
            Scooped = 0;
        }

        /// <summary>
        /// Returns The Amount Of Fuel Collected While Scooping.
        /// </summary>
        /// <returns></returns>
        public decimal ScoopingDiff()
        {
            return Main - ScoopStartLv;
        }

        /// <summary>
        /// Updates Fuel Status Object with the Status.JSON Data.
        /// </summary>
        /// <param name="Level">FuelInfo Object</param>
        public void Update(FuelInfo Level)
        {
            string ClassName = "Fuel Status (Update)";

            try
            {
                //Check If Levels Decreased
                bool Decreased = (Main > Level.FuelMain);

                //Update Vehicles Levels
                Main = Level.FuelMain;
                Reserve = Level.FuelReservoir;

                //Custom Events
                if (ICheck.InitializedStatus(ClassName, false))
                {
                    //Event = FuelHalfThreshold (50% - 25.1%)
                    if (Decreased == true && HalfThreshold == false && GetPercent() <= 50 && GetPercent() > 25)
                    {
                        IEvents.FuelHalfThreshold.Logic(); Report = true;
                    }

                    //Event - FuelLow (25% - 10.1%)
                    else if (Decreased == true && Low == false && GetPercent() <= 25 && GetPercent() > 10)
                    {
                        IEvents.FuelLow.Logic(); Report = true;
                    }

                    //Event - FuelCritical (10% or less)
                    else if (Decreased == true && Critical == false && GetPercent() <= 10)
                    {
                        IEvents.FuelCritical.Logic(); Report = true;
                    }

                    //Reset Bool
                    else if (GetPercent() > 50)
                    {
                        Critical = false;
                        Low = false;
                        HalfThreshold = false;
                    }
                }

                if (Report)
                {
                    IResponse.Fuel.Level(true, ICheck.Report.FuelStatus(ClassName, true, true));
                    Report = false;
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ClassName, "Execption: " + ex);
                Logger.Exception(ClassName, "Ingnoring Exception, Attempting To Continue...");
                Logger.Exception(ClassName, "Something Went Wrong Processing The (Status.Json) Fuel Level");
            }
        }

        /// <summary>
        /// Method Controls The Scooping Status Reports.
        /// </summary>
        /// <param name="TriggeredMethodName"></param>
        public void Scooping(string TriggeredMethodName)
        {
            string MethodName = "Fuel Status Scooping" + " (" + TriggeredMethodName + ")";

            //Fuel Scoop Report Check
            if (ICheck.Report.FuelScoop(MethodName, true, true) == false && ScoopingCompleted != true) { return; }

            //Scooping Commenced Report Not Made
            if (ScoopingCommenced == false)
            {
                ScoopingCommenced = true; ScoopStartLv = Main;
                IResponse.Fuel.ScoopingStart(true, 
                    ICheck.Report.FuelScoop(MethodName, true, true),
                    ICheck.Initialized(MethodName));
            }

            //Scooping Complete Report Not Made && Scooping Has Stopped
            //Scooping Complete Report Not Made && Fuel Level Is 100%
            else if ((ScoopingCompleted == false && IStatus.FuelScooping == false) || (ScoopingCompleted == false && GetPercent() == 100))
            {
                ScoopingCompleted = true;
                IResponse.Fuel.ScoopingEnd(true, 
                    ICheck.Report.FuelScoop(MethodName, true, true),
                    ICheck.Initialized(MethodName));
            }
        }
        #endregion
    }
}