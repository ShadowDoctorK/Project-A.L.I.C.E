using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ALICE_Events;
using ALICE_Objects;
using ALICE_Interface;

namespace ALICE_Internal
{
    public static class Data
    {
        public static Dictionary<decimal, Object_System> Systems = Load_Systems();
        public static Dictionary<decimal, Object_CodexEntry> CodexEntries = Load_CodexEntries();

        public static List<string> ShipModules = new List<string>();

        #region System Data
        public static Dictionary<decimal, Object_System> Load_Systems()
        {
            Dictionary<decimal, Object_System> Temp = new Dictionary<decimal, Object_System>();
            DirectoryInfo GameDir = new DirectoryInfo(Paths.ALICE_SystemData);

            foreach (FileInfo FileData in GameDir.EnumerateFiles("*.System", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    Object_System System = (Object_System)LoadValues<Object_System>(FileData.FullName);

                    //Check Loaded Data For Data Version Updates.
                    System = UpdateDataVersion(System);

                    Temp.Add(System.Address, System);
                }
                catch (Exception) { }
            }
            return Temp;
        }

        public static Object_System UpdateDataVersion(Object_System Sys)
        {
            string MethodName = "System Data Version Update";

            bool DataUpdated = false;

            #region Update To Version 340.0
            if (Sys.DataVersion == -1)
            {
                //NOTES: Updates Stellar Body Gravity Data. Logged Gravity Is 10X the Actual.
                //1. Divides Gravity By 10.
                //2. Sets Intial Data Version
                try
                {
                    DataUpdated = true;
                    Dictionary<decimal, Object_StellarBody> TempBodies = new Dictionary<decimal, Object_StellarBody>();
                    foreach (var Body in Sys.Bodies.Values)
                    {
                        if (Body.Gravity != -1) { Body.Gravity = Body.Gravity / 10; }
                        TempBodies.Add(Body.ID, Body);
                    }
                    Sys.Bodies = TempBodies;
                    Sys.DataVersion = 340.0M;
                }
                catch (Exception ex)
                {
                    Logger.ContactDeveloper();
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "System Name: " + Sys.Name);
                    Logger.Exception(MethodName, "Updating To 340.0");
                }
            }
            #endregion

            if (DataUpdated) { INewtonSoft.Save<Object_System>(Sys, Sys.Name + ".System", Paths.ALICE_SystemData); }

            return Sys;
        }

        #endregion

        #region Codex Entries
        public static Dictionary<decimal, Object_CodexEntry> Load_CodexEntries()
        {
            Dictionary<decimal, Object_CodexEntry> Temp = new Dictionary<decimal, Object_CodexEntry>();
            DirectoryInfo GameDir = new DirectoryInfo(Paths.ALICE_CodexDiscoveries);

            foreach (FileInfo FileData in GameDir.EnumerateFiles("*.Codex", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    Object_CodexEntry System = (Object_CodexEntry)LoadValues<Object_CodexEntry>(FileData.FullName);
                    Temp.Add(System.Address, System);
                }
                catch (Exception) { }
            }
            return Temp;
        }
        #endregion

        #region Support Methods
        public static void SaveValues<T>(object Settings, string FileName, string FilePath = null)
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

        public static object LoadValues<T>(string FileName, string FilePath = null)
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

        public static object LoadValues<T>(string FilePath = null)
        {
            T Temp = default(T);
            if (FilePath == null) { FilePath = Paths.ALICE_Settings; }

            FileStream FS = null;
            try
            {
                if (File.Exists(FilePath))
                {
                    FS = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
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
        #endregion
    }
}