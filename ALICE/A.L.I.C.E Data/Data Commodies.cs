using ALICE_Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ALICE_Data
{
    public class Data_Commodies
    {
        private static List<GameCommodity> _Commodities = Load();
        public static List<GameCommodity> Commodities
        {
            get => _Commodities;
            private set => _Commodities = value;
        }

        private static List<GameCommodity> Load()
        {
            List<GameCommodity> Items = null;

            string Dir = Paths.ALICE_Resources;
            DirectoryInfo directory = new DirectoryInfo(Dir);
            foreach (FileInfo ModuleFile in directory.EnumerateFiles("Commodities.Json", SearchOption.TopDirectoryOnly))
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
                            var NewCom = JsonConvert.DeserializeObject<List<GameCommodity>>(Line);
                            Items = NewCom;
                        }
                    }
                }
                finally
                {
                    if (FS != null)
                    { FS.Dispose(); }
                }
            }

            return Items;
        }

        public GameCommodity GetData(string CommodityName)
        {
            return Commodities.Where(x => x.Name.ToLower() == CommodityName.ToLower()).FirstOrDefault();
        }
    }

    public class GameCommodity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string PriceAverage { get; set; }
        public string PriceBuyMin { get; set; }
        public string PriceBuyMax { get; set; }
        public string PriceSellMin { get; set; }
        public string PriceSellMax { get; set; }
        public string Rare { get; set; }
        public string ItemID { get; set; }
    }
}
