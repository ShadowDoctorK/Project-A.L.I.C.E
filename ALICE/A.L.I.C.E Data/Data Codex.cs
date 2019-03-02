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
            string MethodName = "Game Commodities (Load)";

            Dictionary<decimal, Object_CodexEntry> Temp = new Dictionary<decimal, Object_CodexEntry>();

            string P = Paths.ALICE_CodexDiscoveries;    //Codex Entry Folder
            string F = "*.Codex";                       //Codex Extension

            foreach (FileInfo SystemFile in new DirectoryInfo(P).EnumerateFiles(F, SearchOption.TopDirectoryOnly))
            {
                try
                {
                    //Deserialize System Object
                    Object_CodexEntry System = INewtonSoft.Load2<Object_CodexEntry>(SystemFile.Name, P);

                    //Add Data To Temp Dictionary
                    Temp.Add(System.Address, System);
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
