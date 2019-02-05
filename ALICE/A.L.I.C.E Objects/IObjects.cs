using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using ALICE.Properties;
using ALICE_Internal;

namespace ALICE_Objects
{
    /// <summary>
    /// Static Game State Data.
    /// </summary>
    public static class IObjects
    {
        #region Default Values
        public static readonly string String = "None";
        public static readonly decimal Decimal = -1;
        public static readonly bool False = false;
        public static readonly bool True = true;

        public static string StringCheck(this string Value)
        {
            if (Value == "" || Value == null) { Value = IObjects.String; }
            return Value;
        }
        #endregion

        #region Static Objects
        public static Object_Engineers Engineer = new Object_Engineers();
        public static Object_Mothership Mothership = new Object_Mothership();
        public static Object_SRV SRV = new Object_SRV();
        public static Object_Fighter Fighter = new Object_Fighter();
        public static Object_System SystemCurrent = new Object_System();
        public static Object_System SysetmPrevious = new Object_System();
        public static Object_StellarBody StellarBodyCurrent = new Object_StellarBody();
        public static Object_Facility FacilityCurrent = new Object_Facility();
        public static Object_Facility FacilityPrevious = new Object_Facility();
        public static Object_Target TargetCurrent = new Object_Target();
        //public static Object_Target TargetPrevious = new Object_Target();
        #endregion

        //Status Object Need Moved To IStatus
        public static Status Status = new Status();
    }

    #region Old Items (Requires Updates / Conversion)

    public class ObjectCore
    {
        public DateTime TimeStamp { get; set; }
    }

    public class Status
    {
        #region Status.Json Properties
        //public IVehicles.V Vehicle = IVehicles.V.Mothership;

        //public decimal FireGroup = 1;
        public decimal GUI_Focus = 0;
        public decimal Latitude = -1;
        public decimal Longitude = -1;
        public decimal Heading = -1;
        public decimal Altitude = -1;
        //public Status_Fuel Fuel = new Status_Fuel();
        public decimal CargoMass = -1;

        public bool NightVision = false;
        public bool AnalysisMode = false;
        public bool Interdiction = false;
        public bool InDanger = false;
        public bool HasLatLong = false;
        public bool Overheating = false;
        public bool LowFuel = false;
        //public bool FSD_Cooldown = false;
        //public bool FSD_Charging = false;
        public bool Masslocked = false;
        public bool SRV_DriveAssist = false;
        public bool SRV_NearMothership = false;
        public bool SRV_Turret = false;
        public bool SRV_Handbreak = false;
        public bool FuelScooping = false;
        public bool SilentRunning = false;
        public bool CargoScoop = false;
        public bool Lights = false;
        public bool InWing = false;
        public bool Hardpoints = false;
        public bool FlightAssist = false;
        public bool Supercruise = false;
        public bool Shields = false;
        public bool LandingGear = false;
        public bool Touchdown = false;
        public bool Docked = false;
        #endregion

        #region Event Based Properties
        //StartJump Event
        public bool Hyperspace = false;

        //Launch, Destroyed & Docked Fighter Event
        public bool FighterDeployed = false;

        //Music Event
        public bool FSSMode = false;
        #endregion

        #region Equipment
        public bool WeaponSafety = false;
        #endregion

        #region Miscellaneous
        public bool NPC_Crew = Convert.ToBoolean(Miscellanous.Default["NPC_Crew"]);
        public string FighterStatus = "Ready";
        public bool LandingPreps = false;
        #endregion
    }

    //End Region: Old Items (Requires Updates / Conversion)
    #endregion

    public class Object_Utilities : Object_Base
    {
        public void SaveValues<T>(object Settings, string FileName, string FilePath = null)
        {
            if (FilePath == null) { FilePath = Paths.ALICE_Settings; }

            using (FileStream FS = new FileStream(FilePath + FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter file = new StreamWriter(FS))
                {
                    var Line = JsonConvert.SerializeObject((T)Settings);
                    file.WriteLine(Line);
                }
            }
        }

        public object LoadValues<T>(string FileName, string FilePath = null)
        {
            T Temp = default(T);
            if (FilePath == null) { FilePath = Paths.ALICE_Settings; }
            if (FileName == null) { return null; }

            FileStream FS = null;
            try
            {
                if (File.Exists(FilePath + FileName))
                {
                    FS = new FileStream(FilePath + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        while (!SR.EndOfStream)
                        {
                            string Line = SR.ReadLine();
                            Temp = JsonConvert.DeserializeObject<T>(Line);
                        }
                    }
                }

                return Temp;
            }
            catch (Exception)
            {
                return Temp;
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }
    }

    public class Object_Base
    {
        public DateTime EventTimeStamp { get; set; }
        public string ModfyingEvent { get; set; }
    }
}
