using ALICE_Internal;
using ALICE_Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ALICE_Objects;

namespace ALICE_Data
{
    public class Data_Codex
    {
        private Dictionary<decimal, Object_CodexEntry> _Entries = Load();
        public Dictionary<decimal, Object_CodexEntry> Entries
        {
            get => _Entries;
            private set => _Entries = value;
        }

        private static Dictionary<decimal, Object_CodexEntry> Load()
        {
            string MethodName = "Codex (Load)";

            Dictionary<decimal, Object_CodexEntry> Temp = new Dictionary<decimal, Object_CodexEntry>();

            string P = Paths.ALICE_CodexDiscoveries;    //Codex Entry Folder
            string F = "*.Codex";                       //Codex Extension

            foreach (FileInfo CodexFile in new DirectoryInfo(P).EnumerateFiles(F, SearchOption.TopDirectoryOnly))
            {
                try
                {
                    //Deserialize System Object
                    Object_CodexEntry Entry = INewtonSoft.Load2<Object_CodexEntry>(CodexFile.Name, P);

                    //Add Data To Temp Dictionary
                    Temp.Add(Entry.CodexID, Entry);
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                }
            }

            //Return Temp Dictionary
            return Temp;
        }
    }
}
