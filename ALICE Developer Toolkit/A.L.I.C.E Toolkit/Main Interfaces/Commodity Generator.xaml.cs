using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace A.L.I.C.E_Toolkit
{
    /// <summary>
    /// Interaction logic for Commodity_Generator.xaml
    /// </summary>
    public partial class Commodity_Generator : UserControl
    {
        public Commodity_Generator()
        {
            InitializeComponent();
        }

        public static List<RawCommodity> RawCommodities = new List<RawCommodity>();
        public static Dictionary<string, ConvertedCommodity> ConvertedCommodities = new Dictionary<string, ConvertedCommodity>();

        public void ConvertCommodities(List<RawCommodity> RawItems)
        {
            Dictionary<string, ConvertedCommodity> Temp = new Dictionary<string, ConvertedCommodity>();

            foreach (var Item in RawItems)
            {
                ConvertedCommodity NewItem = new ConvertedCommodity
                {
                    Name = Item.name,
                    Category = Item.category.name,
                    PriceAverage = Item.average_price,
                    PriceBuyMin = Item.min_buy_price,
                    PriceBuyMax = Item.max_buy_price,
                    PriceSellMin = Item.min_sell_price,
                    PriceSellMax = Item.max_sell_price,
                    ItemID = Item.id
                };

                if (Item.is_rare == "1") { NewItem.Rare = "true"; }
                else { NewItem.Rare = "false"; }

                Temp.Add(NewItem.Name, NewItem);
            }

            var Keys = Temp.Keys.ToList();
            Keys.Sort();

            foreach (var Key in Keys)
            {
                ConvertedCommodities.Add(Temp[Key].Name, Temp[Key]);
            }
        }

        public void Deserialize(string FilePath)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            FileStream FS = null;
            try
            {
                if (FilePath == null || FilePath == "")
                { FilePath = MainWindow.SelectFile(); }

                if (FilePath != null && FilePath != "")
                {
                    FS = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        string Line = SR.ReadLine();
                        var Items = JsonConvert.DeserializeObject<List<RawCommodity>>(Line);
                        RawCommodities = Items;
                        ConvertCommodities(RawCommodities);
                    }
                }
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
                ListBox_Commodities_Update();
            }
        }

        public void Serialize(string FilePath = null)
        {
            if (FilePath == null || FilePath == "")
            { FilePath = MainWindow.SelectDirectory(); }

            List<ConvertedCommodity> Items = new List<ConvertedCommodity>();
            foreach (var Item in ConvertedCommodities)
            {
                Items.Add(Item.Value);
            }

            FileStream FS = null;
            try
            {
                string path = FilePath + @"\" + "Commodities.Json";
                FS = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                using (StreamWriter file = new StreamWriter(FS))
                {
                    var JSON = JsonConvert.SerializeObject(Items);
                    file.WriteLine(JSON);
                }
                System.Windows.MessageBox.Show("Exported All Commodities To: " + "Commodities.Json");
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }

        private void ListBox_Commodities_Update()
        {
            ListBox_Commodities.ItemsSource = null;
            ListBox_Commodities.ItemsSource = ConvertedCommodities.Keys;
        }

        private void Item_Properties_Update()
        {
            ConvertedCommodity Item = GetCommodity();

            if (Item != null)
            {
                TextBox_Name.Text = Item.Name;
                TextBox_AvgPrice.Text = Item.PriceAverage;
                TextBox_Category.Text = Item.Category;
                TextBox_ItemID.Text = Item.ItemID;
                TextBox_Rare.Text = Item.Rare;
            }            
        }

        private ConvertedCommodity GetCommodity()
        {
            ConvertedCommodity Temp = null;
            if (GetSelectedItem() != null)
            {
                Temp = ConvertedCommodities[GetSelectedItem()];
            }
            return Temp;
        }

        private string GetSelectedItem()
        {
            string Temp = null;
            try
            {
                Temp = ListBox_Commodities.SelectedItem.ToString();
            }
            catch (Exception)
            {

            }
            return Temp;
        }

        private void ListBox_Commodities_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Item_Properties_Update();
        }

        private void btn_LoadFile_Click(object sender, RoutedEventArgs e)
        {
            Deserialize(MainWindow.SelectFile());
        }

        private void btn_SaveCombine_Click(object sender, RoutedEventArgs e)
        {
            Serialize();
        }

        private void btn_GenerateCode_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class ConvertedCommodity
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

    public class RawCommodity : Catch
    {
        public string id { get; set; }
        public string name { get; set; }
        public string average_price { get; set; }
        public string is_rare { get; set; }
        public string max_buy_price { get; set; }
        public string max_sell_price { get; set; }
        public string min_buy_price { get; set; }
        public string min_sell_price { get; set; }
        public string buy_price_lower_average { get; set; }
        public string sell_price_upper_average { get; set; }
        public string is_non_marketable { get; set; }
        public string ed_id { get; set; }
        public RawCategory category { get; set; }

        public class RawCategory
        {
            public string id { get; set; }
            public string name { get; set; }
        }
    }

}
