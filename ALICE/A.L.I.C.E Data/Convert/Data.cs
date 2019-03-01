using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using ALICE_Objects;
using ALICE_Interface;

namespace ALICE_Internal
{
    public static class Data
    {
        public static Dictionary<decimal, Object_CodexEntry> CodexEntries = Load_CodexEntries();

        public static List<string> ShipModules = new List<string>();

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