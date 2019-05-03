using ALICE_Events;
using ALICE_Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ALICE_Data
{
    public class D_Modules
    {
        public static List<GameModule> Modules { get; private set; } = Load();

        /// <summary>
        /// Collection of Modules We Can Ignore In The Developer Log.
        /// </summary>
        private readonly List<string> Ignore = new List<string>()
        {
            "PaintJob",
            "Decal",
            "Nameplate",
            "Shipkit",
            "Customisation",
            "VoicePack",
            "Cockpit",
            "ModularCargoBayDoor"
        };

        public bool IgnoreCheck(string Module)
        {
            foreach (string Item in Ignore)
            {
                if (Module.ToLower().Contains(Item.ToLower())) { return true; }
            }

            return false;
        }

        public GameModule GetData(string ModuleItem)
        {
            string MethodName = "Module Data (Get)";

            var Temp = Modules.Where(x => x.Item.ToLower() == ModuleItem.ToLower()).FirstOrDefault();

            if (Temp == null)
            {
                Temp = new GameModule();
                Logger.DebugLine(MethodName, "Returned Null, Passing Default Values.", Logger.Blue);
            }

            return Temp;
        }

        public static List<GameModule> Load()
        {
            string MethodName = "Module Data (Load)";

            List<GameModule> Items = new List<GameModule>();

            string Dir = Paths.ALICE_Resources;
            DirectoryInfo directory = new DirectoryInfo(Dir);
            foreach (FileInfo ModuleFile in directory.EnumerateFiles("Modules.Json", SearchOption.TopDirectoryOnly))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                { MissingMemberHandling = MissingMemberHandling.Ignore };

                FileStream FS = null;
                try
                {
                    FS = new FileStream(ModuleFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        while (!SR.EndOfStream)
                        {
                            string Line = SR.ReadLine();
                            Items = JsonConvert.DeserializeObject<List<GameModule>>(Line);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                }
                finally
                {
                    if (FS != null)
                    { FS.Dispose(); }
                }
            }

            return Items;
        }
    }

    public class GameModule
    {
        public string Item { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Class { get; set; }
        public string Price { get; set; }
        public string Capacity { get; set; }
        public string Ship { get; set; }
        public string Mount { get; set; }

        public GameModule()
        {
            Item = Default.String;
            Name = Default.String;
            Rating = Default.String;
            Class = Default.String;
            Price = Default.String;
            Capacity = Default.String;
            Ship = Default.String;
            Mount = Default.String;
        }
    }
}
