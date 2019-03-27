using ALICE_Internal;
using ALICE_Interface;
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
            string MethodName = "Game Commodities (Load)";

            List<GameCommodity> Items = null;

            string P = Paths.ALICE_Resources;
            string F = "Commodities.Json";

            foreach (FileInfo ModuleFile in new DirectoryInfo(Paths.ALICE_Resources)
                .EnumerateFiles(F, SearchOption.TopDirectoryOnly))
            {
                try
                {
                    Items = INewtonSoft.Load2<List<GameCommodity>>(F, P);
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
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
