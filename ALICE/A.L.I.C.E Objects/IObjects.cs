using System;
using System.IO;
using Newtonsoft.Json;
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
        private static Object_Engineers _Engineer = new Object_Engineers();
        public static Object_Engineers Engineer
        {
            get => _Engineer; set => _Engineer = value;
        }

        private static Object_Mothership _Mothership = new Object_Mothership();
        public static Object_Mothership Mothership
        {
            get => _Mothership; set => _Mothership = value;
        }

        private static Object_SRV _SRV = new Object_SRV();
        public static Object_SRV SRV
        {
            get => _SRV; set => _SRV = value;
        }

        private static Object_Fighter _Fighter = new Object_Fighter();
        public static Object_Fighter Fighter
        {
            get => _Fighter; set => _Fighter = value;
        }

        private static Object_System _SystemCurrent = new Object_System();
        public static Object_System SystemCurrent
        {
            get => _SystemCurrent; set => _SystemCurrent = value;
        }

        private static Object_System _SysetmPrevious = new Object_System();
        public static Object_System SysetmPrevious
        {
            get => _SysetmPrevious; set => _SysetmPrevious = value;
        }

        private static Object_StellarBody _StellarBodyCurrent = new Object_StellarBody();
        public static Object_StellarBody StellarBodyCurrent
        {
            get => _StellarBodyCurrent; set => _StellarBodyCurrent = value;
        }

        private static Object_Facility _FacilityCurrent = new Object_Facility();
        public static Object_Facility FacilityCurrent
        {
            get => _FacilityCurrent; set => _FacilityCurrent = value;
        }

        private static Object_Facility _FacilityPrevious = new Object_Facility();
        public static Object_Facility FacilityPrevious
        {
            get => _FacilityPrevious; set => _FacilityPrevious = value;
        }

        private static Object_Target _TargetCurrent = new Object_Target();
        public static Object_Target TargetCurrent
        {
            get => _TargetCurrent; set => _TargetCurrent = value;
        }
        #endregion
    }

    public class ObjectCore
    {
        public DateTime TimeStamp { get; set; }
    }

    public class Object_Utilities : Object_Base
    {
        //Removed Save And Load Methods
    }

    public class Object_Base
    {
        public DateTime EventTimeStamp { get; set; }
        public string ModfyingEvent { get; set; }
    }
}
