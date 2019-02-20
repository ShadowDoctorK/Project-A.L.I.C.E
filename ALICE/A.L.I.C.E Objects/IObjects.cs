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
    }

    public class ObjectCore
    {
        public DateTime TimeStamp { get; set; }
    }

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
