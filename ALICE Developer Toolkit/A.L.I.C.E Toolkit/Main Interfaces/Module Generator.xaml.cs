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
    /// Interaction logic for Module_Generator.xaml
    /// </summary>
    public partial class Module_Generator : UserControl
    {
        public Module_Generator()
        {
            InitializeComponent();
        }

        public static Dictionary<string, Dictionary<string, ConvertedModule>> Modules = new Dictionary<string, Dictionary<string, ConvertedModule>>();
        public static Dictionary<string, ConvertedModule> GroupModules = new Dictionary<string, ConvertedModule>();
        public static Dictionary<string, ConvertedModule> Ungrouped_Modules = new Dictionary<string, ConvertedModule>();

        public static List<ConvertedModule> ModuleList = new List<ConvertedModule>();
        public static List<string> Pizza = new List<string>();


        public void ConvertModules(List<ModuleItem> ModList)
        {
            foreach (var Mod in ModList)
            {
                ConvertedModule NewModule = new ConvertedModule
                {
                    Item = Mod.ed_symbol,
                    Class = Mod.Class,
                    Rating = Mod.rating,
                    Price = Mod.price,
                    Name = Mod.group.name,
                    Capacity = Mod.capacity,
                    Ship = Mod.ship,
                    Mount = Mod.weapon_mode

                };
                if (NewModule.Item != null)
                {
                    Ungrouped_Modules.Add(NewModule.Item, NewModule);
                    ModuleList.Add(NewModule);
                    if (Pizza.Contains(NewModule.Name) == false)
                    {
                        Pizza.Add(NewModule.Name);
                    }
                }

                foreach (var Module in Ungrouped_Modules)
                {
                    if (Modules.ContainsKey(Module.Value.Name) == false)
                    {
                        Dictionary<string, ConvertedModule> Dic = new Dictionary<string, ConvertedModule>();
                        Modules.Add(Module.Value.Name, Dic);
                    }

                    if (Modules[Module.Value.Name].ContainsKey(Module.Value.Item) == false)
                    {
                        Modules[Module.Value.Name].Add(Module.Value.Item, Module.Value);
                    }
                }
            }
        }

        public void Serialize(string FilePath = null, string GroupKey = null, bool Group = false, bool Individual = false)
        {
            if (FilePath == null || FilePath == "")
            { FilePath = MainWindow.SelectDirectory(); }

            FileStream FS = null;
            try
            {
                string path = FilePath + @"\" + "Modules.Json";
                FS = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                using (StreamWriter file = new StreamWriter(FS))
                {
                    var JSON = JsonConvert.SerializeObject(ModuleList);
                    file.WriteLine(JSON);
                }
                System.Windows.MessageBox.Show("Exported All Responses To: " + "Modules.Json");
                //if (Group)
                //{
                //    string path = FilePath + @"\" + "ModuleCollection.module";
                //    FS = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                //    using (StreamWriter file = new StreamWriter(FS))
                //    {
                //        //Dictionary<string, ConvertedModule>
                //        foreach (var ModuleGroup in Modules)
                //        {
                //            ModGroup MG = new ModGroup();
                //            MG.Modules = ModuleGroup.Value;
                //            MG.Group = ModuleGroup.Key;
                //            var JSON = JsonConvert.SerializeObject(MG);
                //            file.WriteLine(JSON);
                //        }
                //    }

                //    System.Windows.MessageBox.Show("Exported All Responses To: " + "ModuleCollection.module");
                //}
                //if (Individual)
                //{
                //    foreach (var ModuleGroup in Modules)
                //    {
                //        string path = FilePath + @"\" + ModuleGroup.Key.ToString() + ".module";
                //        FS = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                //        using (StreamWriter file = new StreamWriter(FS))
                //        {
                //            var JSON = JsonConvert.SerializeObject(MG);
                //            file.WriteLine(JSON);
                //        }
                //    }

                //    System.Windows.MessageBox.Show("Exported All Modules");
                //}
                //else
                //{
                //    string ListBoxItem = ListBox_ModuleGroup.SelectedItem.ToString();
                //    string path = FilePath + @"\" + ListBoxItem + ".Module";
                //    FS = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                //    using (StreamWriter file = new StreamWriter(FS))
                //    {
                //        ModGroup MG = new ModGroup();
                //        MG.Modules = Modules[GroupKey];
                //        MG.Group = GroupKey;
                //        var JSON = JsonConvert.SerializeObject(MG);
                //        file.WriteLine(JSON);
                //    }

                //    System.Windows.MessageBox.Show("Exported Selected Module Group");
                //}
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
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

                FS = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader SR = new StreamReader(FS))
                {
                    while (!SR.EndOfStream)
                    {
                        string Line = SR.ReadLine();
                        var Mod = JsonConvert.DeserializeObject<ModGroup>(Line);
                        if (Modules.ContainsKey(Mod.Group) == false)
                        { Modules.Add(Mod.Group, Mod.Modules); }
                    }
                }
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }

        public void DeserializeJson(string FilePath = null)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            FileStream FS = null;
            try
            {
                if (FilePath == null || FilePath == "")
                { FilePath = MainWindow.SelectFile(); }

                FS = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader SR = new StreamReader(FS))
                {
                    while (!SR.EndOfStream)
                    {
                        string Line = SR.ReadLine();
                        var ModArray = JsonConvert.DeserializeObject<List<ModuleItem>>(Line);
                        ConvertModules(ModArray);
                    }
                }
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }

        public void GenerateCode()
        {
            string FilePath = MainWindow.SelectDirectory();
            FilePath = FilePath + @"\" + "Module Formatted Code.txt";

            FileStream FS = null;
            try
            {
                FS = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                using (StreamWriter file = new StreamWriter(FS))
                {
                    Pizza = Pizza.OrderBy(x => x).ToList();

                    file.WriteLine("//Module Wrapper Emum (" + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt") + ")");

                    file.WriteLine("");
                    file.WriteLine("public enum ModuleGroup");
                    file.WriteLine("{");

                    foreach (string Name in Pizza)
                    {
                        file.WriteLine("    " + Name.Replace(" ", "_").Replace("-", "_"));
                    }
                    file.WriteLine("}");
                    file.WriteLine("");
                    file.WriteLine("#endregion");
                    file.WriteLine("");


                    file.WriteLine("");
                    file.WriteLine("#region Ship Module Variables (" + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt") + ")");
                    file.WriteLine("");
                    foreach (string Name in Pizza)
                    {
                        file.WriteLine("    public static bool " + Name.Replace(" ", "_").Replace("-", "_") + " = false;");
                    }
                    file.WriteLine("");
                    file.WriteLine("#endregion");
                    file.WriteLine("");


                    file.WriteLine("");
                    file.WriteLine("#region Reset Ship Modules (" + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt") + ")");
                    file.WriteLine("");
                    foreach (string Name in Pizza)
                    {
                        file.WriteLine("    GameState.Ship." + Name.Replace(" ", "_").Replace("-", "_") + " = false;");
                    }
                    file.WriteLine("");
                    file.WriteLine("#endregion");
                    file.WriteLine("");


                    file.WriteLine("");
                    file.WriteLine("#region Module Detection / Toggles (" + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt") + ")");
                    file.WriteLine("");
                    file.WriteLine("switch (YOURCLASSNAME.ModuleGroup)");
                    file.WriteLine("{");
                    foreach (string Name in Pizza)
                    {
                        file.WriteLine("    case YOURCLASSNAME.ModuleGroup.ModuleGroup." + Name.Replace(" ", "_").Replace("-", "_") + ":");
                        file.WriteLine("        IObjects.Mothership." + Name.Replace(" ", "_").Replace("-", "_") + " = true;");
                        file.WriteLine("        Data.ShipModules.Add(\"A.L.I.C.E: \" + GenerateModuleName(Module));");
                        file.WriteLine("        break;");
                        file.WriteLine("");
                    }
                    file.WriteLine("    default:");
                    file.WriteLine("        break;");
                    file.WriteLine("");
                    file.WriteLine("}");
                    file.WriteLine("");
                    file.WriteLine("#endregion");
                }

                //FS = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                //using (StreamWriter file = new StreamWriter(FS))
                //{
                //    file.WriteLine("#region Ship Module Variables (" + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt") + ")");
                //    file.WriteLine("");
                //    foreach (string Name in Pizza)
                //    {
                //        file.WriteLine("    public static bool " + Name.Replace(" ", "_").Replace("-", "_") + " = false;");
                //    }
                //    file.WriteLine("");
                //    file.WriteLine("#endregion");
                //    file.WriteLine("");


                //    file.WriteLine("");
                //    file.WriteLine("#region Reset Ship Modules (" + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt") + ")");
                //    file.WriteLine("");
                //    foreach (string Name in Pizza)
                //    {
                //        file.WriteLine("    GameState.Ship." + Name.Replace(" ", "_").Replace("-", "_") + " = false;");
                //    }
                //    file.WriteLine("");
                //    file.WriteLine("#endregion");
                //    file.WriteLine("");


                //    file.WriteLine("");
                //    file.WriteLine("#region Module Detection / Toggles (" + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt") + ")");
                //    file.WriteLine("");
                //    foreach (string Name in Pizza)
                //    {
                //        file.WriteLine("else if (Module.Name == \"" + Name.Replace(" ", "_").Replace("-", "_") + "\")");
                //        file.WriteLine("{");
                //        file.WriteLine("    GameState.Ship." + Name.Replace(" ", "_").Replace("-", "_") + " = true;");
                //        file.WriteLine("");
                //        file.WriteLine("    Interface_Manager.WriteToLog(\"A.L.I.C.E: Module Status: \" + GenerateModuleName(Module) + \" Detected\", \"Yellow\");");
                //        file.WriteLine("}");
                //    }
                //    file.WriteLine("");
                //    file.WriteLine("#endregion");
                //}
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }

            var content = File.ReadAllText(FilePath);
            Clipboard.SetText(content);
            MessageBox.Show("Generated Code Coppied To Clipboard");
        }

        #region ListBox Methods
        public void ModuleGroups_Update()
        {
            ListBox_ModuleGroup.ItemsSource = Modules.Keys;
        }

        public void ModuleName_Update(string GroupKey)
        {
            GroupModules = new Dictionary<string, ConvertedModule>();
            foreach (ConvertedModule Module in Modules[GroupKey].Values)
            {
                GroupModules.Add(Module.Item, Module);
            }
            ListBox_Modules.ItemsSource = GroupModules.Keys;
        }

        public void ModuleProperty_Update(string ModuleKey)
        {
            ConvertedModule Module = GroupModules[ModuleKey];
            TextBox_Item.Text = Module.Item;
            TextBox_Name.Text = Module.Name;
            TextBox_Rating.Text = Module.Rating;
            TextBox_Class.Text = Module.Class;
            TextBox_Price.Text = Module.Price;
            TextBox_Capacity.Text = Module.Capacity;
            TextBox_Ship.Text = Module.Ship;
            TextBox_Mount.Text = Module.Mount;
        }
        #endregion

        #region User Interface
        private void btn_GroupName_New_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_GroupName_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_GroupName_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_GroupName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string GroupKey = ListBox_ModuleGroup.SelectedItem.ToString();
            ModuleName_Update(GroupKey);
        }

        private void btn_Module_New_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Module_Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Module_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_ModuleName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ModuleProperty_Update(ListBox_Modules.SelectedItem.ToString());
        }

        #region File Management
        private void btn_LoadFile_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = MainWindow.SelectFile();
            if (FilePath.ToLower().Contains("modules.json") == true)
            {
                DeserializeJson(FilePath);
            }
            else
            {
                Deserialize(FilePath);
            }
            ModuleGroups_Update();
        }

        private void btn_LoadDirectory_Click(object sender, RoutedEventArgs e)
        {
            string Dir = MainWindow.SelectDirectory() + @"\";
            DirectoryInfo directory = new DirectoryInfo(Dir);
            foreach (FileInfo ModuleFile in directory.EnumerateFiles("*.module", SearchOption.TopDirectoryOnly))
            {
                Deserialize(ModuleFile.FullName);
            }
            ModuleGroups_Update();
        }

        private void btn_SaveSelected_Click(object sender, RoutedEventArgs e)
        {
            Serialize(MainWindow.SelectDirectory(), ListBox_ModuleGroup.SelectedItem.ToString());
        }

        private void btn_SaveIndividual_Click(object sender, RoutedEventArgs e)
        {
            Serialize(MainWindow.SelectDirectory(), null, false, true);
        }

        private void btn_SaveCombine_Click(object sender, RoutedEventArgs e)
        {
            Serialize(MainWindow.SelectDirectory(), null, true, false);
        }

        private void btn_GenerateCode_Click(object sender, RoutedEventArgs e)
        {
            GenerateCode();
        }
        #endregion

        //End: User Interface
        #endregion
    }

    #region Objects
    public class ModGroup
    {
        public string Group { get; set; }
        public Dictionary<string, ConvertedModule> Modules { get; set; }
    }

    public class ConvertedModule
    {
        public string Item { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Class { get; set; }
        public string Price { get; set; }
        public string Capacity { get; set; }
        public string Ship { get; set; }
        public string Mount { get; set; }
    }

    public class ModuleItem : Catch
    {
        public Group group { get; set; }
        public string id { get; set; }
        public string group_id { get; set; }
        public string Class { get; set; }
        public string rating { get; set; }
        public string price { get; set; }
        public string weapon_mode { get; set; }
        public string missle_type { get; set; }
        public string name { get; set; }
        public string belongs_to { get; set; }
        public string ed_id { get; set; }
        public string ed_symbol { get; set; }
        public string ship { get; set; }
        public string capacity { get; set; }

        public class Group
        {
            public string id { get; set; }
            public string category_id { get; set; }
            public string name { get; set; }
            public string category { get; set; }
        }

        #region Extras
        public string missile_type { get; set; }
        public string mass { get; set; }
        public string dps { get; set; }
        public string power { get; set; }
        public string damage { get; set; }
        public string ammo { get; set; }
        public string range_km { get; set; }
        public string efficiency { get; set; }
        public string power_produced { get; set; }
        public string duration { get; set; }
        public string cells { get; set; }
        public string recharge_rating { get; set; }
        public string count { get; set; }
        public string range_ls { get; set; }
        public string rate { get; set; }
        public string bins { get; set; }
        public string additional_armour { get; set; }
        public string vehicle_count { get; set; }
        #endregion
    }

    public class Catch
    {
        [JsonExtensionData]
        public IDictionary<string, object> Undefined { get; set; }

        public IDictionary<string, object> UndefinedProperties()
        {
            return Undefined;
        }
    }
    #endregion
}
