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
using System.Runtime.InteropServices;
using WinForm = System.Windows.Forms;
using ALICE_Events;

namespace A.L.I.C.E_Toolkit
{
    /// <summary>
    /// Interaction logic for Journal_Tool.xaml
    /// </summary>
    public partial class Journal_Tool : UserControl
    {
        public Journal_Tool()
        {
            InitializeComponent();
        }

        #region Variables
        private bool MissingMembers = false;
        public static string TargetedLog;
        public static bool RegenLog = true;
        public static string JournalDir = Journal.KnownFolders.GetPath(Journal.KnownFolder.SavedGames) + "\\Frontier Developments\\Elite Dangerous\\";
        #endregion

        #region Journal Items
        public string EventName = "";
        public string TimeStamp = "";
        public decimal Count = 0;
        public Dictionary<string, object> Events = new Dictionary<string, object>();
        public string RawLine = "";


        private Dictionary<string, string> UndefinedEventNames = new Dictionary<string, string>();
        private List<string> UndefinedEventStrings = new List<string>();

        public decimal Counter = 1;
        public List<string> EventList = new List<string>();
        #endregion

        private void btn_AllLog_Click(object sender, RoutedEventArgs e)
        {
            string Directory = MainWindow.SelectDirectory();
            List<string> Events = ParseLogs(Directory);
            string Output = MainWindow.SelectDirectory();

            List<string> ManagerList = new List<string>();
            List<string> JournalList = new List<string>();

            //public static Event_Bounty Bounty = new Event_Bounty();

            foreach (string Event in Events)
            {
                string EventName = Event.Substring(47, Event.IndexOf("\"", 47) - 47);
                GenerateCode(EventName, Event, Output);

                #region Event Manager Code
                ManagerList.Add("public static Event_" + EventName + " " + EventName + " = new Event_" + EventName + "();");
                #endregion

                #region Journal Reader Code
                JournalList.Add("else if (EventName == \"" + EventName + "\")");
                JournalList.Add("{");
                JournalList.Add("    var Event = JsonConvert.DeserializeObject<ALICE_Events." + EventName + ">(RawLine);");
                JournalList.Add("    Manager.UpdateEvents(EventName, Event);");
                JournalList.Add("    Manager." + EventName + ".Logic();");
                JournalList.Add("}");
                #endregion
            }

            WriteListToFile(ManagerList, Output, "ManagerCode.txt");
            WriteListToFile(JournalList, Output, "JournalCode.txt");
        }

        private void btn_Log_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TargetedLog == null)
                {
                    WinForm.OpenFileDialog dialog = new WinForm.OpenFileDialog();
                    dialog.DefaultExt = "*.log";
                    dialog.Filter = "Log (*.log)|*.log";
                    dialog.FilterIndex = 2;
                    dialog.InitialDirectory = Journal.LogDir;
                    if (dialog.ShowDialog() == WinForm.DialogResult.OK)
                    {
                        TargetedLog = dialog.FileName;
                        //DebugOutput("SELECTED: " + TargetedLog);
                    }
                }

                Deserialise_Log(TargetedLog);
            }
            catch (Exception)
            {                
            }         
        }

        private void btn_Event_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Output.Clear();
        }

        private void btn_SelectLog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_MissingMember_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBox_MissingMember.IsChecked == true)
            { MissingMembers = true; }
            else
            { MissingMembers = false; }
        }

        private void btn_GenerateCode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string EventLine = TextBox_Events.Text;
                string EventName = EventLine.Substring(47, EventLine.IndexOf("\"", 47) - 47);
                string Directory = MainWindow.SelectDirectory();

                GenerateCode(EventName, EventLine, Directory, true);
            }
            catch (Exception) { }
        }

        public List<string> ParseLogs(string Directory)
        {
            Dictionary<string, string> Events = new Dictionary<string, string>();
            List<string> Strings = new List<string>();
            
            try
            {
                DirectoryInfo Dir = new DirectoryInfo(Directory);
                foreach (FileInfo LogFile in Dir.EnumerateFiles("Journal*.*.*.log", SearchOption.TopDirectoryOnly))
                {
                    using (var Stream = new StreamReader(LogFile.FullName))
                    {
                        while (Stream.EndOfStream != true)
                        {
                            string Line = Stream.ReadLine();
                            string Name = Line.Substring(47, Line.IndexOf("\"", 47) - 47);

                            if (Events.ContainsKey(Name))
                            {
                                string OldEvent = Events[Name];
                                if (OldEvent.Length < Line.Length)
                                {
                                    Events[Name] = Line;
                                }
                            }
                            else
                            {
                                Events.Add(Name, Line);
                            }
                        }
                    }
                }
                Strings = SortDictionary(Events).Values.ToList();
            }
            catch (Exception ex) { }

            return Strings;
        }

        public void WriteListToFile(List<string> Strings,string OutputDir, string FileName)
        {
            try
            {
                if (OutputDir == null)
                { OutputDir = MainWindow.SelectDirectory(); }

                string FilePath = OutputDir + @"\" +  FileName;

                FileStream FS = null;
                try
                {
                    FS = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                    using (StreamWriter File = new StreamWriter(FS))
                    {
                        foreach (string Line in Strings)
                        {
                            File.WriteLine(Line);
                        }
                    }
                }
                finally
                {
                    if (FS != null)
                    { FS.Dispose(); }
                }
            }
            catch(Exception ex) { }
        }

        public Dictionary<string, string> SortDictionary(Dictionary<string, string> Unsorted)
        {
            Dictionary<string, string> Temp = new Dictionary<string, string>();
            List<string> Keys = Unsorted.Keys.ToList();
            Keys.Sort();

            foreach (string Key in Keys)
            {
                Temp.Add(Key, Unsorted[Key]);
            }

            return Temp;
        }

        public void GenerateCode(string EventName, string EventLine, string Directory = null, bool Clipboard = false)
        {
            try
            {
                if (Directory == null)
                { Directory = MainWindow.SelectDirectory(); }

                string FileName = @"\Event " + EventName + ".cs";
                string FilePath = Directory + FileName;

                FileStream FS = null;
                try
                {
                    FS = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                    using (StreamWriter File = new StreamWriter(FS))
                    {
                        List<string> Temp = Deserialise_Event(EventLine);
                        foreach (string Line in Temp)
                        {
                            File.WriteLine(Line);
                        }
                    }
                }
                finally
                {
                    if (FS != null)
                    { FS.Dispose(); }
                }

                if (Clipboard)
                {
                    var content = File.ReadAllText(FilePath);
                    System.Windows.Clipboard.SetText(content);
                    MessageBox.Show("Generated Code Coppied To Clipboard");
                }
            }
            catch (Exception)
            { }         
        }

        public List<string> Deserialise_Event(string JsonLine)
        {            
            List<string> Event = new List<string>();
            EventName = JsonLine.Substring(47, JsonLine.IndexOf("\"", 47) - 47);
            TimeStamp = JsonLine.Substring(15, 20);

            JsonSerializerSettings settings = new JsonSerializerSettings();
            if (MissingMembers == true)
            { settings.MissingMemberHandling = MissingMemberHandling.Error; }
            else
            { settings.MissingMemberHandling = MissingMemberHandling.Ignore; }

            var Temp = JsonConvert.DeserializeObject<UndefinedEvent>(JsonLine, settings);

            IDictionary<string, object> UndefinedObject = Temp.Undefined;

            #region Class File Generation

            Event.Add(@"//Code Generated By Project A.L.I.C.E Developer Toolkit");
            Event.Add(@"//Class File Generated: " + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));
            Event.Add(@"//Source Journal Line: " + JsonLine);
            Event.Add(@"");

            #region Using Statements
            Event.Add(@"using System;");
            Event.Add(@"using System.Collections.Generic;");
            Event.Add(@"using System.Linq;");
            Event.Add(@"using System.Text;");
            Event.Add(@"using System.Threading.Tasks;");
            Event.Add(@"using ALICE_Ships_Datalink_Interface;");
            Event.Add(@"using ALICE_Command_Interface;");
            Event.Add(@"using ALICE_Internal;");
            Event.Add(@"");
            #endregion

            #region Name Space
            Event.Add(@"namespace ALICE_Events");
            Event.Add(@"{");

            #region Public Class
            Event.Add("    public class Event_" + EventName + " : Event_Base");
            Event.Add(@"    {");

            #region Public Event (Name)
            Event.Add(@"        public Event_" + EventName + "()");
            Event.Add(@"        {");
            Event.Add("            Name = \"" + EventName + "\";");
            Event.Add(@"        }");
            Event.Add(@"");
            //End Region: Pubic Event (Name)
            #endregion

            #region Public Void Logic()
            Event.Add(@"        public void Logic()");
            Event.Add(@"        {");
            Event.Add(@"            if (Manager.WriteVariables && WriteVariables)");
            Event.Add(@"            {");
            Event.Add(@"                try");
            Event.Add(@"                {");
            Event.Add(@"                    Variables_Clear();");
            Event.Add(@"                    Variables_Generate();");
            Event.Add(@"                    Variables_Write();");
            Event.Add(@"                }");
            Event.Add(@"                catch (Exception ex)");
            Event.Add(@"                {");
            Event.Add("                    Internal.Exception(Name, \"An Exception Occured While Updating Variables\");");
            Event.Add("                    Internal.Exception(Name, \"Exception: \" + ex);");
            Event.Add(@"                }");
            Event.Add(@"            }");
            Event.Add(@"");
            Event.Add(@"            //GameState.Logic_" + EventName + "((" + EventName + ")GetEvent());");
            Event.Add(@"");
            Event.Add(@"            TriggerEvent();");
            Event.Add(@"        }");
            //End Region: Public Void Logic()
            Event.Add(@"");
            #endregion

            #region Public void Variable_Generator()
            Event.Add(@"        public void Variables_Generate()");
            Event.Add(@"        {");
            Event.Add(@"            " + EventName + " Event = (" + EventName + ")Manager.GetEvent(Name);");
            Event.Add(@"");
            Event.Add(@"            Variables.Clear();");
            Event.Add(@"");
            Event.Add(@"            #region Custom Variables");
            Event.Add(@"");
            Event.Add(@"            #endregion");
            Event.Add(@"");
            #region Variable Generation
            Event.Add(@"            #region Event Variables");

            if (UndefinedObject != null && UndefinedObject.Count > 0)
            {
                foreach (KeyValuePair<string, object> Prop in UndefinedObject)
                {
                    Event.Add("            Variable_Craft(\"" + Property(Prop.Key) + "\", Event." + Property(Prop.Key) + ".ToString());");
                }
            }
            Event.Add(@"            #endregion");
            #endregion
            Event.Add(@"        }");
            //End Region: Public Void Variable_Generator()
            #endregion

            Event.Add(@"    }");
            //End Region: Public Class
            #endregion

            #region Public Class (Name) : Event_Base
            Event.Add(@"");
            Event.Add("    #region " + EventName + " Event");
            Event.Add("    public class " + EventName + " : Base");
            Event.Add("    {");

            if (UndefinedObject != null && UndefinedObject.Count > 0)
            {
                foreach (KeyValuePair<string, object> Propery in UndefinedObject)
                {
                    string str = CodeConstructor(Propery);
                    if (str != null) { Event.Add("        " + str); }
                }
            }

            Event.Add("    }");
            Event.Add("    #endregion");
            #endregion

            Event.Add(@"}");
            //End Region: Name Space
            #endregion

            Event.Add(@"");
            //End Region: Class File Generation
            #endregion

            #region Journal Reader Logic Code
            Event.Add("");
            Event.Add("//Journal Reader Code Chunk.");
            Event.Add("");
            Event.Add("// else if (EventName == \"" + EventName + "\")");
            Event.Add("// {");
            Event.Add("//     var Event = JsonConvert.DeserializeObject<ALICE_Events." + EventName + ">(RawLine);");
            Event.Add("//     Manager.UpdateEvents(EventName, Event);");
            Event.Add("//     Manager." + EventName + ".Logic();");
            Event.Add("// }");
            #endregion

            return Event;
        }

        public string CodeConstructor(KeyValuePair<string, object> Prop)
        {
            string Line = null;

            if (decimal.TryParse(Prop.Value.ToString(), out decimal DeciResult))
            {
                Line = ("public decimal " + Property(Prop.Key) + " { get; set; }");
            }
            else if (Prop.Value.ToString() == "true" || Prop.Value.ToString() == "false")
            {
                Line = ("public bool " + Property(Prop.Key) + " { get; set; }");
            }
            else
            {
                Line = ("public string " + Property(Prop.Key) + " { get; set; }");
            }

            return Line;
        }

        public string Property(string Name)
        {
            if (Name == null)
                return null;

            if (Name.Length > 1)
                return char.ToUpper(Name[0]) + Name.Substring(1);

            return Name.ToUpper();
        }

        public void UpdateEvents(object Event)
        {
            if (Events.ContainsKey(EventName) == false)
            {
                Events.Add(EventName, Event);
            }
            else
            {
                Events[EventName] = Event;
            }
        }

        private void Deserialise_Log(string LogFilePath)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                if (MissingMembers == true)
                { settings.MissingMemberHandling = MissingMemberHandling.Error; }
                else
                { settings.MissingMemberHandling = MissingMemberHandling.Ignore; }

                using (var Stream = new StreamReader(LogFilePath))
                {
                    while (Stream.EndOfStream != true)
                    {
                        RawLine = Stream.ReadLine();

                        if (RegenLog == false) { EventName = RawLine.Substring(47, RawLine.IndexOf("\"", 47) - 47); }   
                        else { EventName = ""; }

                        TimeStamp = RawLine.Substring(15, 20);

                        #region A
                        if (EventName == "AfmuRepairs")
                        {
                            var Event = JsonConvert.DeserializeObject<AfmuRepairs>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ApproachBody")
                        {
                            var Event = JsonConvert.DeserializeObject<ApproachBody>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ApproachSettlement")
                        {
                            var Event = JsonConvert.DeserializeObject<ApproachSettlement>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region B
                        else if (EventName == "Bounty")
                        {
                            var Event = JsonConvert.DeserializeObject<Bounty>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "BuyAmmo")
                        {
                            var Event = JsonConvert.DeserializeObject<BuyAmmo>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "BuyDrones")
                        {
                            var Event = JsonConvert.DeserializeObject<BuyDrones>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "BuyExplorationData")
                        {
                            var Event = JsonConvert.DeserializeObject<BuyExplorationData>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region C
                        else if (EventName == "Cargo")
                        {
                            var Event = JsonConvert.DeserializeObject<Cargo>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CargoDepot")
                        {
                            var Event = JsonConvert.DeserializeObject<CargoDepot>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ChangeCrewRole")
                        {
                            var Event = JsonConvert.DeserializeObject<ChangeCrewRole>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CollectCargo")
                        {
                            var Event = JsonConvert.DeserializeObject<CollectCargo>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CockpitBreached")
                        {
                            var Event = JsonConvert.DeserializeObject<CockpitBreached>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Commander")
                        {
                            var Event = JsonConvert.DeserializeObject<Commander>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CommitCrime")
                        {
                            var Event = JsonConvert.DeserializeObject<CommitCrime>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CommunityGoal")
                        {
                            var Event = JsonConvert.DeserializeObject<CommunityGoal>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CommunityGoalJoin")
                        {
                            var Event = JsonConvert.DeserializeObject<CommunityGoalJoin>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CommunityGoalReward")
                        {
                            var Event = JsonConvert.DeserializeObject<CommunityGoalReward>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CrewAssign")
                        {
                            var Event = JsonConvert.DeserializeObject<CrewAssign>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CrewFire")
                        {
                            var Event = JsonConvert.DeserializeObject<CrewFire>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CrewHire")
                        {
                            var Event = JsonConvert.DeserializeObject<CrewHire>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CrewMemberJoins")
                        {
                            var Event = JsonConvert.DeserializeObject<CrewMemberJoins>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "CrewMemberRoleChange")
                        {
                            var Event = JsonConvert.DeserializeObject<CrewMemberRoleChange>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region D
                        else if (EventName == "DatalinkScan")
                        {
                            var Event = JsonConvert.DeserializeObject<DatalinkScan>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "DatalinkVoucher")
                        {
                            var Event = JsonConvert.DeserializeObject<DatalinkVoucher>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "DataScanned")
                        {
                            var Event = JsonConvert.DeserializeObject<DataScanned>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Died")
                        {
                            var Event = JsonConvert.DeserializeObject<Died>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "DiscoveryScan")
                        {
                            var Event = JsonConvert.DeserializeObject<DiscoveryScan>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Docked")
                        {
                            var Event = JsonConvert.DeserializeObject<Docked>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "DockFighter")
                        {
                            var Event = JsonConvert.DeserializeObject<DockFighter>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "DockingCancelled")
                        {
                            var Event = JsonConvert.DeserializeObject<DockingCancelled>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "DockingDenied")
                        {
                            var Event = JsonConvert.DeserializeObject<DockingDenied>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "DockingGranted")
                        {
                            var Event = JsonConvert.DeserializeObject<DockingGranted>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "DockingRequested")
                        {
                            var Event = JsonConvert.DeserializeObject<DockingRequested>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "DockSRV")
                        {
                            var Event = JsonConvert.DeserializeObject<DockSRV>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region E
                        else if (EventName == "EngineerApply")
                        {
                            var Event = JsonConvert.DeserializeObject<EngineerApply>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "EngineerContribution")
                        {
                            var Event = JsonConvert.DeserializeObject<EngineerContribution>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "EngineerCraft")
                        {
                            var Event = JsonConvert.DeserializeObject<EngineerCraft>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "EngineerProgress")
                        {
                            var Event = JsonConvert.DeserializeObject<EngineerProgress>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "EscapeInterdiction")
                        {
                            var Event = JsonConvert.DeserializeObject<EscapeInterdiction>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "EjectCargo")
                        {
                            var Event = JsonConvert.DeserializeObject<EjectCargo>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region F
                        else if (EventName == "FactionKillBond")
                        {
                            var Event = JsonConvert.DeserializeObject<FactionKillBond>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "FetchRemoteModule")
                        {
                            var Event = JsonConvert.DeserializeObject<FetchRemoteModule>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "FighterDestroyed")
                        {
                            var Event = JsonConvert.DeserializeObject<FighterDestroyed>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "FighterRebuilt")
                        {
                            var Event = JsonConvert.DeserializeObject<FighterRebuilt>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Fileheader")
                        {
                            var Event = JsonConvert.DeserializeObject<Fileheader>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Friends")
                        {
                            var Event = JsonConvert.DeserializeObject<Friends>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "FSDJump")
                        {
                            var Event = JsonConvert.DeserializeObject<FSDJump>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "FuelScoop")
                        {
                            var Event = JsonConvert.DeserializeObject<FuelScoop>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region H
                        else if (EventName == "HeatDamage")
                        {
                            var Event = JsonConvert.DeserializeObject<HeatDamage>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "HeatWarning")
                        {
                            var Event = JsonConvert.DeserializeObject<HeatWarning>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "HullDamage")
                        {
                            var Event = JsonConvert.DeserializeObject<HullDamage>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region I
                        else if (EventName == "Interdicted")
                        {
                            var Event = JsonConvert.DeserializeObject<Interdicted>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Interdiction")
                        {
                            var Event = JsonConvert.DeserializeObject<Interdiction>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region J
                        else if (EventName == "JetConeBoost")
                        {
                            var Event = JsonConvert.DeserializeObject<JetConeBoost>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "JoinACrew")
                        {
                            var Event = JsonConvert.DeserializeObject<JoinACrew>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region L
                        else if (EventName == "LaunchDrone")
                        {
                            var Event = JsonConvert.DeserializeObject<LaunchDrone>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "LaunchFighter")
                        {
                            var Event = JsonConvert.DeserializeObject<LaunchFighter>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "LaunchSRV")
                        {
                            var Event = JsonConvert.DeserializeObject<LaunchSRV>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "LeaveBody")
                        {
                            var Event = JsonConvert.DeserializeObject<LeaveBody>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Liftoff")
                        {
                            var Event = JsonConvert.DeserializeObject<Liftoff>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "LoadGame")
                        {
                            var Event = JsonConvert.DeserializeObject<LoadGame>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Loadout")
                        {
                            var Event = JsonConvert.DeserializeObject<Loadout>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Location")
                        {
                            var Event = JsonConvert.DeserializeObject<Location>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region M
                        else if (EventName == "Market")
                        {
                            Market Pizza = JsonConvert.DeserializeObject<Market>(RawLine);
                            UpdateEvents(Pizza);
                        }
                        else if (EventName == "MarketBuy")
                        {
                            var Event = JsonConvert.DeserializeObject<MarketBuy>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "MarketSell")
                        {
                            var Event = JsonConvert.DeserializeObject<MarketSell>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "MassModuleStore")
                        {
                            var Event = JsonConvert.DeserializeObject<MassModuleStore>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "MaterialCollected")
                        {
                            var Event = JsonConvert.DeserializeObject<MaterialCollected>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "MaterialDiscarded")
                        {
                            var Event = JsonConvert.DeserializeObject<MaterialDiscarded>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "MaterialDiscovered")
                        {
                            var Event = JsonConvert.DeserializeObject<MaterialDiscovered>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "MaterialTrade")
                        {
                            var Event = JsonConvert.DeserializeObject<MaterialTrade>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Materials")
                        {
                            var Event = JsonConvert.DeserializeObject<Materials>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "MiningRefined")
                        {
                            var Event = JsonConvert.DeserializeObject<MiningRefined>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "MissionAbandoned")
                        {
                            var Event = JsonConvert.DeserializeObject<MissionAbandoned>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "MissionAccepted")
                        {
                            var Event = JsonConvert.DeserializeObject<MissionAccepted>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "MissionCompleted")
                        {
                            var Event = JsonConvert.DeserializeObject<MissionCompleted>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "MissionRedirected")
                        {
                            var Event = JsonConvert.DeserializeObject<MissionRedirected>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Missions")
                        {
                            var Event = JsonConvert.DeserializeObject<Missions>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ModuleBuy")
                        {
                            var Event = JsonConvert.DeserializeObject<ModuleBuy>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ModuleInfo") //Notification of JSON file update.
                        {
                            var Event = JsonConvert.DeserializeObject<ModuleInfo>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ModuleStore")
                        {
                            var Event = JsonConvert.DeserializeObject<ModuleStore>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ModuleSwap")
                        {
                            var Event = JsonConvert.DeserializeObject<ModuleSwap>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ModuleRetrieve")
                        {
                            var Event = JsonConvert.DeserializeObject<ModuleRetrieve>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ModuleSell")
                        {
                            var Event = JsonConvert.DeserializeObject<ModuleSell>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ModuleSellRemote")
                        {
                            var Event = JsonConvert.DeserializeObject<ModuleSellRemote>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Music")
                        {
                            var Event = JsonConvert.DeserializeObject<Music>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region N
                        else if (EventName == "NavBeaconScan")
                        {
                            var Event = JsonConvert.DeserializeObject<NavBeaconScan>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "NpcCrewPaidWage")
                        {
                            var Event = JsonConvert.DeserializeObject<NpcCrewPaidWage>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "NpcCrewRank")
                        {
                            var Event = JsonConvert.DeserializeObject<NpcCrewRank>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region O
                        else if (EventName == "Outfitting")
                        {
                            var Event = JsonConvert.DeserializeObject<Outfitting>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region P
                        else if (EventName == "PayBounties")
                        {
                            var Event = JsonConvert.DeserializeObject<PayBounties>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "PayFines")
                        {
                            var Event = JsonConvert.DeserializeObject<PayFines>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "PayLegacyFines")
                        {
                            var Event = JsonConvert.DeserializeObject<PayLegacyFines>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Powerplay")
                        {
                            var Event = JsonConvert.DeserializeObject<Powerplay>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "PowerplayDefect")
                        {
                            var Event = JsonConvert.DeserializeObject<PowerplayDefect>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "PowerplayLeave")
                        {
                            var Event = JsonConvert.DeserializeObject<PowerplayLeave>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "PowerplaySalary")
                        {
                            var Event = JsonConvert.DeserializeObject<PowerplaySalary>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Progress")
                        {
                            var Event = JsonConvert.DeserializeObject<Progress>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Promotion")
                        {
                            var Event = JsonConvert.DeserializeObject<Promotion>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region Q
                        else if (EventName == "QuitACrew")
                        {
                            var Event = JsonConvert.DeserializeObject<QuitACrew>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region R
                        else if (EventName == "Rank")
                        {
                            var Event = JsonConvert.DeserializeObject<Rank>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "RebootRepair")
                        {
                            var Event = JsonConvert.DeserializeObject<RebootRepair>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ReceiveText")
                        {
                            var Event = JsonConvert.DeserializeObject<ReceiveText>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "RedeemVoucher")
                        {
                            var Event = JsonConvert.DeserializeObject<RedeemVoucher>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "RefuelAll")
                        {
                            var Event = JsonConvert.DeserializeObject<RefuelAll>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Repair")
                        {
                            var Event = JsonConvert.DeserializeObject<Repair>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "RepairAll")
                        {
                            var Event = JsonConvert.DeserializeObject<RepairAll>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "RepairDrone")
                        {
                            RepairDrone Event = JsonConvert.DeserializeObject<RepairDrone>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Reputation")
                        {
                            var Event = JsonConvert.DeserializeObject<Reputation>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "RestockVehicle")
                        {
                            var Event = JsonConvert.DeserializeObject<RestockVehicle>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Resurrect")
                        {
                            var Event = JsonConvert.DeserializeObject<Resurrect>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region S
                        else if (EventName == "Scan")
                        {
                            var Event = JsonConvert.DeserializeObject<Scan>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Scanned")
                        {
                            var Event = JsonConvert.DeserializeObject<Scanned>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Screenshot")
                        {
                            var Event = JsonConvert.DeserializeObject<Screenshot>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "SendText")
                        {
                            var Event = JsonConvert.DeserializeObject<SendText>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "SellDrones")
                        {
                            var Event = JsonConvert.DeserializeObject<SellDrones>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "SellExplorationData")
                        {
                            var Event = JsonConvert.DeserializeObject<SellExplorationData>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "SetUserShipName")
                        {
                            var Event = JsonConvert.DeserializeObject<SetUserShipName>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ShieldState")
                        {
                            var Event = JsonConvert.DeserializeObject<ShieldState>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ShipTargeted")
                        {
                            var Event = JsonConvert.DeserializeObject<ShipTargeted>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Shipyard")
                        {
                            var Event = JsonConvert.DeserializeObject<Shipyard>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ShipyardBuy")
                        {
                            var Event = JsonConvert.DeserializeObject<ShipyardBuy>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ShipyardNew")
                        {
                            var Event = JsonConvert.DeserializeObject<ShipyardNew>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ShipyardSell")
                        {
                            var Event = JsonConvert.DeserializeObject<ShipyardSell>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ShipyardSwap")
                        {
                            var Event = JsonConvert.DeserializeObject<ShipyardSwap>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "ShipyardTransfer")
                        {
                            var Event = JsonConvert.DeserializeObject<ShipyardTransfer>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Shutdown")
                        {
                            var Event = JsonConvert.DeserializeObject<Shutdown>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "SRVDestroyed")
                        {
                            var Event = JsonConvert.DeserializeObject<SRVDestroyed>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "StartJump")
                        {
                            var Event = JsonConvert.DeserializeObject<StartJump>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "StoredModules")
                        {
                            var Event = JsonConvert.DeserializeObject<StoredModules>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "StoredShips")
                        {
                            var Event = JsonConvert.DeserializeObject<StoredShips>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Statistics")
                        {
                            var Event = JsonConvert.DeserializeObject<Statistics>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "SupercruiseEntry")
                        {
                            var Event = JsonConvert.DeserializeObject<SupercruiseEntry>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "SupercruiseExit")
                        {
                            var Event = JsonConvert.DeserializeObject<SupercruiseExit>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Synthesis")
                        {
                            var Event = JsonConvert.DeserializeObject<Synthesis>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region T
                        else if (EventName == "TechnologyBroker")
                        {
                            var Event = JsonConvert.DeserializeObject<TechnologyBroker>(RawLine, settings);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Touchdown")
                        {
                            var Event = JsonConvert.DeserializeObject<Touchdown>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region U
                        else if (EventName == "UnderAttack")
                        {
                            var Event = JsonConvert.DeserializeObject<UnderAttack>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "Undocked")
                        {
                            var Event = JsonConvert.DeserializeObject<Undocked>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "USSDrop")
                        {
                            var Event = JsonConvert.DeserializeObject<USSDrop>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region V
                        else if (EventName == "VehicleSwitch")
                        {
                            var Event = JsonConvert.DeserializeObject<VehicleSwitch>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        #region W
                        else if (EventName == "WingAdd")
                        {
                            var Event = JsonConvert.DeserializeObject<WingAdd>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "WingInvite")
                        {
                            var Event = JsonConvert.DeserializeObject<WingInvite>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "WingJoin")
                        {
                            var Event = JsonConvert.DeserializeObject<WingJoin>(RawLine);
                            UpdateEvents(Event);
                        }
                        else if (EventName == "WingLeave")
                        {
                            var Event = JsonConvert.DeserializeObject<WingLeave>(RawLine);
                            UpdateEvents(Event);
                        }
                        #endregion

                        else if (EventName != "Pizza")
                        {
                            EventName = RawLine.Substring(47, RawLine.IndexOf("\"", 47) - 47);
                            var Event = JsonConvert.DeserializeObject<UndefinedEvent>(RawLine);
                            UpdateEvents(Event);
                            if (UndefinedEventNames.ContainsKey(Event.Event.ToString()) == false)
                            {
                                UndefinedEventNames[Event.Event.ToString()] = TimeStamp;
                                UndefinedEventStrings.Add(RawLine);
                            }
                        }

                        if (EventList.Contains(EventName) == false)
                        {
                            EventList.Add(EventName);
                            //DebugOutput(Counter + ". " + EventName);
                            Counter++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //DebugOutput("JSON Deserialise: (Exception) Event " + EventName + " | Time Stamp " + TimeStamp + " | Error: " + ex.Message.ToString());

                //DebugOutput("-----------------------------------------------------");
                //DebugOutput("JSON Event From Logfile");
                //DebugOutput("-----------------------------------------------------");
                //DebugOutput(RawLine);
                //DebugOutput("-----------------------------------------------------");
            }
            finally
            {
                foreach (KeyValuePair<string, string> Event in UndefinedEventNames)
                {
                    //DebugOutput("[New/Undefined Event]: (" + Event.Value + ") " + Event.Key);
                }

                string Directory = MainWindow.SelectDirectory();

                foreach (string Event in UndefinedEventStrings)
                {
                    string EventName = Event.Substring(47, Event.IndexOf("\"", 47) - 47);

                    GenerateCode(EventName, Event, Directory);
                    //DebugOutput(" ");
                }
            }
        }
    }

    public class Journal
    {
        public static string LogFilePath = "";
        public static string NewFilePath = "";
        public static string LogDir = KnownFolders.GetPath(KnownFolder.SavedGames) + "\\Frontier Developments\\Elite Dangerous\\";
        public static List<string> LogStorage;
        public static DateTime TimeStamp;
        public static FileInfo TargetLogFile;
        public static decimal EventCount = 0;
        public static string TargetFile = "";

        public static void LogFileCheck()
        {

            try
            {
                DirectoryInfo GameDir = new DirectoryInfo(LogDir);
                string CurrentFilePath = "";

                foreach (FileInfo LogFile in GameDir.EnumerateFiles("*.log", SearchOption.TopDirectoryOnly))
                {
                    if (TargetLogFile is null && TimeStamp < LogFile.LastWriteTime)
                    {
                        //New File, lets get it setup.
                        TargetLogFile = LogFile;
                        TimeStamp = LogFile.LastWriteTime;
                    }
                    else if (TimeStamp < LogFile.LastWriteTime)
                    {
                        //Same File, lets update the time stamp.
                        TimeStamp = LogFile.LastWriteTime;
                    }
                    else
                    {
                        TargetLogFile = null;
                    }

                    if (TargetLogFile != null)
                    {
                        NewFilePath = LogDir + LogFile.Name;
                        CurrentFilePath = LogFile.Name;
                        TargetFile = LogFile.Name;
                    }
                }

                GameDir = null;

                //Lets Update the File Path if needed.
                if (LogFilePath != NewFilePath)
                {
                    LogFilePath = NewFilePath;
                    EventCount = 0;
                }
                TargetFile = TargetLogFile.FullName;
                TargetLogFile = null;
            }
            catch (Exception ex)
            {

            }
        }

        #region Known Folder Paths

        /// <summary>
        /// Class containing methods to retrieve specific file system paths.
        /// </summary>
        public static class KnownFolders
        {
            private static string[] _knownFolderGuids = new string[]
            {
                "{56784854-C6CB-462B-8169-88E350ACB882}", // Contacts
                "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}", // Desktop
                "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}", // Documents
                "{374DE290-123F-4565-9164-39C4925E467B}", // Downloads
                "{1777F761-68AD-4D8A-87BD-30B759FA33DD}", // Favorites
                "{BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968}", // Links
                "{4BD8D571-6D19-48D3-BE97-422220080E43}", // Music
                "{33E28130-4E1E-4676-835A-98395C3BC3BB}", // Pictures
                "{4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4}", // SavedGames
                "{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}", // SavedSearches
                "{18989B1D-99B5-455B-841C-AB7C74E4DDFC}", // Videos
            };

            /// <summary>
            /// Gets the current path to the specified known folder as currently configured. This does
            /// not require the folder to be existent.
            /// </summary>
            /// <param name="knownFolder">The known folder which current path will be returned.</param>
            /// <returns>The default path of the known folder.</returns>
            /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path
            ///     could not be retrieved.</exception>
            public static string GetPath(KnownFolder knownFolder)
            {
                return GetPath(knownFolder, false);
            }

            /// <summary>
            /// Gets the current path to the specified known folder as currently configured. This does
            /// not require the folder to be existent.
            /// </summary>
            /// <param name="knownFolder">The known folder which current path will be returned.</param>
            /// <param name="defaultUser">Specifies if the paths of the default user (user profile
            ///     template) will be used. This requires administrative rights.</param>
            /// <returns>The default path of the known folder.</returns>
            /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown if the path
            ///     could not be retrieved.</exception>
            public static string GetPath(KnownFolder knownFolder, bool defaultUser)
            {
                return GetPath(knownFolder, KnownFolderFlags.DontVerify, defaultUser);
            }

            private static string GetPath(KnownFolder knownFolder, KnownFolderFlags flags,
                bool defaultUser)
            {
                IntPtr outPath;
                int result = SHGetKnownFolderPath(new Guid(_knownFolderGuids[(int)knownFolder]),
                    (uint)flags, new IntPtr(defaultUser ? -1 : 0), out outPath);
                if (result >= 0)
                {
                    return Marshal.PtrToStringUni(outPath);
                }
                else
                {
                    throw new ExternalException("Unable to retrieve the known folder path. It may not "
                        + "be available on this system.", result);
                }
            }

            [DllImport("Shell32.dll")]
            private static extern int SHGetKnownFolderPath(
                [MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken,
                out IntPtr ppszPath);

            [Flags]
            private enum KnownFolderFlags : uint
            {
                SimpleIDList = 0x00000100,
                NotParentRelative = 0x00000200,
                DefaultPath = 0x00000400,
                Init = 0x00000800,
                NoAlias = 0x00001000,
                DontUnexpand = 0x00002000,
                DontVerify = 0x00004000,
                Create = 0x00008000,
                NoAppcontainerRedirection = 0x00010000,
                AliasOnly = 0x80000000
            }
        }

        /// <summary>
        /// Standard folders registered with the system. These folders are installed with Windows Vista
        /// and later operating systems, and a computer will have only folders appropriate to it
        /// installed.
        /// </summary>
        public enum KnownFolder
        {
            Contacts,
            Desktop,
            Documents,
            Downloads,
            Favorites,
            Links,
            Music,
            Pictures,
            SavedGames,
            SavedSearches,
            Videos
        }
        #endregion
    }
}

namespace ALICE_Events
{
    #region Journal Events

    #region Event Constructors
    public class Catch
    {
        [JsonExtensionData]
        public IDictionary<string, object> Undefined { get; set; }

        public IDictionary<string, object> UndefinedProperties()
        {
            return Undefined;
        }
    }

    public class Base : Catch
    {
        public DateTime Timestamp { get; set; }
        public string Event { get; set; }
    }

    public class UndefinedEvent : Base
    {
        //Use this when you want to log the entire event.
    }
    #endregion

    #region AfmuRepairs Event
    public class AfmuRepairs : Base
    {
        public string Module { get; set; }
        public string Module_Localised { get; set; }
        public string FullyRepaired { get; set; }
        public decimal Health { get; set; }
    }
    #endregion

    #region ApproachBody Event
    public class ApproachBody : Base
    {
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public string Body { get; set; }
        public decimal BodyID { get; set; }
    }
    #endregion

    #region ApproachSettlement Event
    public class ApproachSettlement : Base
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public decimal MarketID { get; set; }
    }
    #endregion

    #region Bounty Event
    public class Bounty : Base
    {
        public List<BountyReward> Rewards { get; set; }
        public string Target { get; set; }
        public decimal TotalReward { get; set; }
        public string VictimFaction { get; set; }
        public string VictimFaction_Localised { get; set; }
        public decimal SharedWithOthers { get; set; }

        //Target is Skimmer
        public string Faction { get; set; }
        public decimal Reward { get; set; }

        public class BountyReward : Catch
        {
            public string Faction { get; set; }
            public decimal Reward { get; set; }
        }
    }
    #endregion

    #region BuyAmmo Event
    public class BuyAmmo : Base
    {
        public decimal Cost { get; set; }
    }
    #endregion

    #region BuyDrones Event
    public class BuyDrones : Base
    {
        public string Type { get; set; }
        public decimal Count { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal TotalCost { get; set; }
    }
    #endregion

    #region BuyExplorationData Event
    public class BuyExplorationData : Base
    {
        public string System { get; set; }
        public decimal Cost { get; set; }
    }
    #endregion

    #region Cargo Event
    public class Cargo : Base
    {
        public List<CargoItem> Inventory { get; set; }
    }

    public class CargoItem : Catch
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public decimal Count { get; set; }
        public decimal Stolen { get; set; }
    }
    #endregion

    #region CargoDepot Event
    public class CargoDepot : Base
    {
        public decimal MissionID { get; set; }
        public string UpdateType { get; set; }
        public string CargoType { get; set; }
        public string CargoType_Localised { get; set; }
        public decimal Count { get; set; }
        public decimal StartMarketID { get; set; }
        public decimal EndMarketID { get; set; }
        public decimal ItemsCollected { get; set; }
        public decimal ItemsDelivered { get; set; }
        public decimal TotalItemsToDeliver { get; set; }
        public decimal Progress { get; set; }
    }
    #endregion

    #region ChangeCrewRole Event
    public class ChangeCrewRole : Base
    {
        public string Role { get; set; }
    }
    #endregion

    #region CockpitBreached Event
    public class CockpitBreached : Base
    {
    }
    #endregion

    #region CollectCargo Event
    public class CollectCargo : Base
    {
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public bool Stolen { get; set; }
    }
    #endregion

    #region Commander Event
    public class Commander : Base
    {
        public string Name { get; set; }
    }
    #endregion

    #region CommitCrime Event
    public class CommitCrime : Base
    {
        public string CrimeType { get; set; }
        public string Faction { get; set; }
        public string Victim { get; set; }
        public string Victim_Localised { get; set; }
        public decimal Fine { get; set; }
        public decimal Bounty { get; set; }
    }
    #endregion

    #region CommunityGoal Event
    public class CommunityGoal : Base
    {
        public List<CurrentGoal> CurrentGoals { get; set; }
    }

    public class CurrentGoal : Catch
    {
        public decimal CGID { get; set; }
        public string Title { get; set; }
        public string SystemName { get; set; }
        public string MarketName { get; set; }
        public DateTime Expiry { get; set; }
        public string IsComplete { get; set; }
        public decimal CurrentTotal { get; set; }
        public decimal PlayerContribution { get; set; }
        public decimal NumContributors { get; set; }
        public Tier TopTier { get; set; }
        public decimal TopRankSize { get; set; }
        public string PlayerInTopRank { get; set; }
        public string TierReached { get; set; }
        public decimal PlayerPercentileBand { get; set; }
        public decimal Bonus { get; set; }

        public class Tier : Catch
        {
            public string Name { get; set; }
            public string Bonus { get; set; }
        }
    }
    #endregion

    #region CommunityGoalJoin Event
    public class CommunityGoalJoin : Base
    {
        public string Name { get; set; }
        public string System { get; set; }
    }
    #endregion

    #region CommunityGoalReward Event
    public class CommunityGoalReward : Base
    {
        public decimal CGID { get; set; }
        public string Name { get; set; }
        public string System { get; set; }
        public decimal Reward { get; set; }
    }
    #endregion

    #region CrewAssign Event
    public class CrewAssign : Base
    {
        public string Name { get; set; }
        public decimal CrewID { get; set; }
        public string Role { get; set; }
    }
    #endregion

    #region CrewFire Event
    public class CrewFire : Base
    {
        public string Name { get; set; }
        public decimal CrewID { get; set; }
    }
    #endregion

    #region CrewHire Event
    public class CrewHire : Base
    {
        public string Name { get; set; }
        public decimal CrewID { get; set; }
        public string Faction { get; set; }
        public decimal Cost { get; set; }
        public decimal CombatRank { get; set; }
    }
    #endregion

    #region CrewMemberJoins Event
    public class CrewMemberJoins : Base
    {
        public string Crew { get; set; }
    }
    #endregion

    #region CrewMemberRoleChange Event
    public class CrewMemberRoleChange : Base
    {
        public string Crew { get; set; }
        public string Role { get; set; }
    }
    #endregion

    #region DatalinkScan Event
    public class DatalinkScan : Base
    {
        public string Message { get; set; }
        public string Message_Localised { get; set; }
    }
    #endregion

    #region DatalinkVoucher Event
    public class DatalinkVoucher : Base
    {
        public decimal Reward { get; set; }
        public string VictimFaction { get; set; }
        public string PayeeFaction { get; set; }
    }
    #endregion

    #region DataScanned Event
    public class DataScanned : Base
    {
        public string Type { get; set; }
    }
    #endregion

    #region Died Event
    public class Died : Base
    {
        public string KillerName { get; set; }
        public string KillerName_Localised { get; set; }
        public string KillerShip { get; set; }
        public string KillerRank { get; set; }
    }
    #endregion

    #region DiscoveryScan Event
    public class DiscoveryScan : Base
    {
        public decimal SystemAddress { get; set; }
        public decimal Bodies { get; set; }
    }
    #endregion

    #region Docked Event
    public class Docked : Base
    {
        public string StationName { get; set; }
        public string StationType { get; set; }
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public decimal MarketID { get; set; }
        public string StationFaction { get; set; }
        public string FactionState { get; set; }
        public string StationGovernment { get; set; }
        public string StationGovernment_Localised { get; set; }
        public string StationAllegiance { get; set; }
        public List<string> StationServices { get; set; }
        public string StationEconomy { get; set; }
        public string StationEconomy_Localised { get; set; }
        public List<StationEco> StationEconomies { get; set; }
        public decimal DistFromStarLS { get; set; }
        public bool CockpitBreach { get; set; }

        public class StationEco
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public decimal Proportion { get; set; }
        }
    }
    #endregion

    #region DockFighter Event
    public class DockFighter : Base
    {
    }
    #endregion

    #region DockingCancelled Event
    public class DockingCancelled : Base
    {
        public string StationName { get; set; }
    }
    #endregion

    #region DockingDenied Event
    public class DockingDenied : Base
    {
        public string Reason { get; set; }
        public decimal MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
    }
    #endregion

    #region DockingGranted Event
    public class DockingGranted : Base
    {
        public decimal LandingPad { get; set; }
        public decimal MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
    }
    #endregion

    #region DockingRequested Event
    public class DockingRequested : Base
    {
        public decimal MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
    }
    #endregion

    #region DockSRV Event
    public class DockSRV : Base
    {
    }
    #endregion

    #region EngineerApply Event
    public class EngineerApply : Base
    {
        public string Engineer { get; set; }
        public string Blueprint { get; set; }
        public decimal Level { get; set; }
    }
    #endregion

    #region EngineerContribution Event
    public class EngineerContribution : Base
    {
        public string Engineer { get; set; }
        public decimal EngineerID { get; set; }
        public string Type { get; set; }
        public string Commodity { get; set; }
        public string Commodity_Localised { get; set; }
        public string Material { get; set; }
        public string Material_Localised { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalQuantity { get; set; }
    }
    #endregion

    #region EngineerCraft Event
    public class EngineerCraft : Base
    {
        public string Slot { get; set; }
        public string Module { get; set; }
        public string ApplyExperimentalEffect { get; set; }
        public string Engineer { get; set; }
        public decimal EngineerID { get; set; }
        public string BlueprintName { get; set; }
        public decimal BlueprintID { get; set; }
        public decimal Level { get; set; }
        public decimal Quality { get; set; }
        public string ExperimentalEffect { get; set; }
        public string ExperimentalEffect_Localised { get; set; }
        public List<CraftModifier> Modifiers { get; set; }
        public List<CraftIngredient> Ingredients { get; set; }

        public class CraftModifier
        {
            public string Label { get; set; }
            public decimal Value { get; set; }
            public decimal OriginalValue { get; set; }
            public decimal LessIsGood { get; set; }
            public string ValueStr { get; set; }
            public string ValueStr_Localised { get; set; }
        }

        public class CraftIngredient : Catch
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public decimal Count { get; set; }
        }
    }
    #endregion

    #region EngineerProgress Event
    public class EngineerProgress : Base
    {
        public string Engineer { get; set; }
        public decimal EngineerID { get; set; }
        public string Progress { get; set; }
        public decimal Rank { get; set; }
    }
    #endregion

    #region EscapeInterdiction Event
    public class EscapeInterdiction : Base
    {
        public string Interdictor { get; set; }
        public string Interdictor_Localised { get; set; }
        public string IsPlayer { get; set; }
    }
    #endregion

    #region EjectCargo Event
    public class EjectCargo : Base
    {
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public decimal Count { get; set; }
        public bool Abandoned { get; set; }
    }
    #endregion

    #region FactionKillBond Event
    public class FactionKillBond : Base
    {
        public decimal Reward { get; set; }
        public string AwardingFaction { get; set; }
        public string AwardingFaction_Localised { get; set; }
        public string VictimFaction { get; set; }
        public string VictimFaction_Localised { get; set; }
    }
    #endregion

    #region FetchRemoteModule Event
    public class FetchRemoteModule : Base
    {
        public decimal StorageSlot { get; set; }
        public string StoredItem { get; set; }
        public string StoredItem_Localised { get; set; }
        public decimal ServerId { get; set; }
        public decimal TransferCost { get; set; }
        public decimal TransferTime { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }
    }
    #endregion

    #region FighterDestroyed Event
    public class FighterDestroyed : Base
    {
    }
    #endregion

    #region FighterRebuilt Event
    public class FighterRebuilt : Base
    {
        public string Loadout { get; set; }
    }
    #endregion

    #region Fileheader Event
    public class Fileheader : Base
    {
        public decimal Part { get; set; }
        public string Language { get; set; }
        public string Gameversion { get; set; }
        public string Build { get; set; }
    }
    #endregion

    #region Friends Event
    public class Friends : Base
    {
        public string Status { get; set; }
        public string Name { get; set; }
    }
    #endregion

    #region FSDJump Event
    public class FSDJump : Base
    {
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public List<decimal> StarPos { get; set; }
        public string SystemAllegiance { get; set; }
        public string SystemEconomy { get; set; }
        public string SystemEconomy_Localised { get; set; }
        public string SystemSecondEconomy { get; set; }
        public string SystemSecondEconomy_Localised { get; set; }
        public string SystemGovernment { get; set; }
        public string SystemGovernment_Localised { get; set; }
        public string SystemSecurity { get; set; }
        public string SystemSecurity_Localised { get; set; }
        public decimal Population { get; set; }
        public List<string> Powers { get; set; }
        public string PowerplayState { get; set; }
        public decimal JumpDist { get; set; }
        public decimal FuelUsed { get; set; }
        public decimal FuelLevel { get; set; }
        public decimal BoostUsed { get; set; }
        public List<Faction> Factions { get; set; }
        public string SystemFaction { get; set; }
        public string FactionState { get; set; }

        public class Faction : Catch
        {
            public string Name { get; set; }
            public string FactionState { get; set; }
            public string Government { get; set; }
            public decimal Influence { get; set; }
            public string Allegiance { get; set; }
            public List<States> PendingStates { get; set; }
            public List<States> RecoveringStates { get; set; }

            public class States : Catch
            {
                public string State { get; set; }
                public decimal Trend { get; set; }
            }
        }
    }
    #endregion

    #region FuelScoop Event
    public class FuelScoop : Base
    {
        public decimal Scooped { get; set; }
        public decimal Total { get; set; }
    }
    #endregion

    #region HeatDamage Event
    public class HeatDamage : Base
    {
    }
    #endregion

    #region HeatWarning Event
    public class HeatWarning : Base
    {
    }
    #endregion

    #region HullDamage Event
    public class HullDamage : Base
    {
        public decimal Health { get; set; }
        public string PlayerPilot { get; set; }
        public string Fighter { get; set; }
    }
    #endregion

    #region Interdicted Event
    public class Interdicted : Base
    {
        public bool Submitted { get; set; }
        public string Interdictor { get; set; }
        public bool IsPlayer { get; set; }
        public string Faction { get; set; }
        public decimal CombatRank { get; set; }
    }
    #endregion

    #region Interdiction Event
    public class Interdiction : Base
    {
        public string Success { get; set; }
        public bool IsPlayer { get; set; }
        public string Faction { get; set; }
    }
    #endregion

    #region JetConeBoost Event
    public class JetConeBoost : Base
    {
        public decimal BoostValue { get; set; }
    }
    #endregion

    #region JoinACrew Event
    public class JoinACrew : Base
    {
        public string Captain { get; set; }
    }
    #endregion

    #region LaunchDrone Event
    public class LaunchDrone : Base
    {
        public string Type { get; set; }
    }
    #endregion

    #region LaunchFighter Event
    public class LaunchFighter : Base
    {
        public string Loadout { get; set; }
        public string PlayerControlled { get; set; }
    }
    #endregion

    #region LaunchSRV Event
    public class LaunchSRV : Base
    {
        public string Loadout { get; set; }
        public string PlayerControlled { get; set; }
    }
    #endregion

    #region LeaveBody Event
    public class LeaveBody : Base
    {
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public string Body { get; set; }
        public decimal BodyID { get; set; }
    }
    #endregion

    #region Liftoff Event
    public class Liftoff : Base
    {
        public bool PlayerControlled { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
    #endregion

    #region LoadGame Event
    public class LoadGame : Base
    {
        public string Commander { get; set; }
        public string Horizons { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public decimal ShipID { get; set; }
        public string ShipName { get; set; }
        public string ShipIdent { get; set; }
        public decimal FuelLevel { get; set; }
        public decimal FuelCapacity { get; set; }
        public string GameMode { get; set; }
        public string Group { get; set; }
        public decimal Credits { get; set; }
        public decimal Loan { get; set; }
    }
    #endregion

    #region Loadout Event
    public class Loadout : Base
    {
        public string Ship { get; set; }
        public decimal ShipID { get; set; }
        public string ShipName { get; set; }
        public string ShipIdent { get; set; }
        public decimal HullValue { get; set; }
        public decimal ModulesValue { get; set; }
        public decimal Rebuy { get; set; }
        public List<Module> Modules { get; set; }

        public class Module : Catch
        {
            //Always Used
            public string Slot { get; set; }
            public string Item { get; set; }
            public bool On { get; set; }
            public decimal Priority { get; set; }
            public decimal Health { get; set; }
            public decimal Value { get; set; }

            //Sometimes Used
            public decimal AmmoInHopper { get; set; }
            public decimal AmmoInClip { get; set; }
            public EngineeringInfo Engineering { get; set; }


            public class EngineeringInfo : Catch
            {
                public string Engineer { get; set; }
                public decimal EngineerID { get; set; }
                public decimal BlueprintID { get; set; }
                public string BlueprintName { get; set; }
                public decimal Level { get; set; }
                public decimal Quality { get; set; }
                public string ExperimentalEffect { get; set; }
                public string ExperimentalEffect_Localised { get; set; }
                public List<Modifer> Modifiers { get; set; }

                public class Modifer : Catch
                {
                    public string Label { get; set; }
                    public decimal Value { get; set; }
                    public decimal OriginalValue { get; set; }
                    public decimal LessIsGood { get; set; }
                }
            }
        }
    }
    #endregion

    #region Location Event
    public class Location : Base
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool Docked { get; set; }
        public decimal MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public List<decimal> StarPos { get; set; }
        public string SystemAllegiance { get; set; }
        public string SystemEconomy { get; set; }
        public string SystemEconomy_Localised { get; set; }
        public string SystemSecondEconomy { get; set; }
        public string SystemSecondEconomy_Localised { get; set; }
        public string SystemGovernment { get; set; }
        public string SystemGovernment_Localised { get; set; }
        public string SystemSecurity { get; set; }
        public string SystemSecurity_Localised { get; set; }
        public decimal Population { get; set; }
        public string Body { get; set; }
        public decimal BodyID { get; set; }
        public string BodyType { get; set; }
        public List<string> Powers { get; set; }
        public string PowerplayState { get; set; }
        public List<Faction> Factions { get; set; }
        public string SystemFaction { get; set; }
        public string FactionState { get; set; }

        public class Faction : Catch
        {
            public string Name { get; set; }
            public string FactionState { get; set; }
            public string Government { get; set; }
            public decimal Influence { get; set; }
            public string Allegiance { get; set; }
            public List<States> PendingStates { get; set; }
            public List<States> RecoveringStates { get; set; }

            public class States : Catch
            {
                public string State { get; set; }
                public decimal Trend { get; set; }
            }
        }
    }
    #endregion

    #region Market Event
    public class Market : Base
    {
        public decimal MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }
    }
    #endregion

    #region MarketBuy Event
    public class MarketBuy : Base
    {
        public decimal MarketID { get; set; }
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public decimal Count { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal TotalCost { get; set; }
    }
    #endregion

    #region MarketSell Event
    public class MarketSell : Base
    {
        public decimal MarketID { get; set; }
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public decimal Count { get; set; }
        public decimal SellPrice { get; set; }
        public decimal TotalSale { get; set; }
        public decimal AvgPricePaid { get; set; }
    }
    #endregion

    #region MaterialCollected Event
    public class MaterialCollected : Base
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public decimal Count { get; set; }
    }
    #endregion

    #region MaterialDiscarded Event
    public class MaterialDiscarded : Base
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Count { get; set; }
    }
    #endregion

    #region MaterialDiscovered Event
    public class MaterialDiscovered : Base
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public decimal DiscoveryNumber { get; set; }
    }
    #endregion

    #region MaterialTrade Event
    public class MaterialTrade : Base
    {
        public decimal MarketID { get; set; }
        public string TraderType { get; set; }
        public TradeMat Paid { get; set; }
        public TradeMat Received { get; set; }

        public class TradeMat
        {
            public string Material { get; set; }
            public string Material_Localised { get; set; }
            public string Category { get; set; }
            public string Category_Localised { get; set; }
            public decimal Quantity { get; set; }
        }
    }
    #endregion

    #region Materials Event
    public class Materials : Base
    {
        public List<Material> Raw { get; set; }
        public List<Material> Manufactured { get; set; }
        public List<Material> Encoded { get; set; }
    }

    public class Material : Catch
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public decimal Count { get; set; }
    }
    #endregion

    #region MassModuleStore Event
    public class MassModuleStore : Base
    {
        public decimal MarketID { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }
        public List<Item> Items { get; set; }

        public class Item
        {
            public string Slot { get; set; }
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public string Hot { get; set; }
        }
    }
    #endregion

    #region MiningRefined Event
    public class MiningRefined : Base
    {
        public string Type { get; set; }
        public string Type_Localised { get; set; }
    }
    #endregion

    #region MissionAbandoned Event
    public class MissionAbandoned : Base
    {
        public string Name { get; set; }
        public decimal MissionID { get; set; }
    }
    #endregion

    #region MissionAccepted Event
    public class MissionAccepted : Base
    {
        public string Faction { get; set; }
        public string Name { get; set; }
        public string LocalisedName { get; set; }
        public string TargetType { get; set; }
        public string TargetType_Localised { get; set; }
        public string Donation { get; set; }
        public string Commodity { get; set; }
        public string Commodity_Localised { get; set; }
        public decimal Count { get; set; }
        public string TargetFaction { get; set; }
        public decimal KillCount { get; set; }
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public string Target { get; set; }
        public string Target_Localised { get; set; }
        public DateTime Expiry { get; set; }
        public bool Wing { get; set; }
        public string Influence { get; set; }
        public string Reputation { get; set; }
        public decimal Reward { get; set; }
        public decimal MissionID { get; set; }
    }
    #endregion

    #region MissionCompleted Event
    public class MissionCompleted : Base
    {
        public string Faction { get; set; }
        public string Name { get; set; }
        public decimal MissionID { get; set; }
        public string TargetType { get; set; }
        public string TargetType_Localised { get; set; }
        public string Commodity { get; set; }
        public string Commodity_Localised { get; set; }
        public decimal Count { get; set; }
        public string TargetFaction { get; set; }
        public decimal KillCount { get; set; }
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public string Target { get; set; }
        public string Target_Localised { get; set; }
        public decimal Reward { get; set; }
        public List<MatReward> MaterialsReward { get; set; }
        public List<MatReward> CommodityReward { get; set; }
        public decimal Donation { get; set; }
        public List<FactionReport> FactionEffects { get; set; }

        public class MatReward
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public string Category { get; set; }
            public string Category_Localised { get; set; }
            public decimal Count { get; set; }
        }

        public class FactionReport
        {
            public string Faction { get; set; }
            public string Reputation { get; set; }
            public List<FactionEffect> Effects { get; set; }
            public List<FactionInfluence> Influence { get; set; }

            public class FactionEffect
            {
                public string Effect { get; set; }
                public string Effect_Localised { get; set; }
                public string Trend { get; set; }
            }

            public class FactionInfluence
            {
                public decimal SystemAddress { get; set; }
                public string Trend { get; set; }
            }
        }
    }
    #endregion

    #region MissionRedirected Event
    public class MissionRedirected : Base
    {
        public decimal MissionID { get; set; }
        public string Name { get; set; }
        public string NewDestinationStation { get; set; }
        public string NewDestinationSystem { get; set; }
        public string OldDestinationStation { get; set; }
        public string OldDestinationSystem { get; set; }
    }
    #endregion

    #region Missions Event
    public class Missions : Base
    {
        public List<Mission> Active { get; set; }
        public List<Mission> Failed { get; set; }
        public List<Mission> Complete { get; set; }

        public class Mission : Catch
        {
            public decimal MissionID { get; set; }
            public string Name { get; set; }
            public bool PassengerMission { get; set; }
            public decimal Expires { get; set; }
        }
    }
    #endregion

    #region ModuleBuy Event
    public class ModuleBuy : Base
    {
        public string Slot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public string StoredItem { get; set; }
        public string StoredItem_Localised { get; set; }
        public decimal SellPrice { get; set; }
        public string BuyItem { get; set; }
        public string BuyItem_Localised { get; set; }
        public decimal MarketID { get; set; }
        public decimal BuyPrice { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }
    }
    #endregion

    #region ModuleInfo Event
    public class ModuleInfo : Base
    {
    }
    #endregion

    #region ModuleStore Event
    public class ModuleStore : Base
    {
        public decimal MarketID { get; set; }
        public string Slot { get; set; }
        public string StoredItem { get; set; }
        public string StoredItem_Localised { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }
        public string EngineerModifications { get; set; }
        public decimal Level { get; set; }
        public decimal Quality { get; set; }
        public bool Hot { get; set; }
    }
    #endregion

    #region ModuleSwap Event
    public class ModuleSwap : Base
    {
        public decimal MarketID { get; set; }
        public string FromSlot { get; set; }
        public string ToSlot { get; set; }
        public string FromItem { get; set; }
        public string FromItem_Localised { get; set; }
        public string ToItem { get; set; }
        public string ToItem_Localised { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }
    }
    #endregion

    #region ModuleRetrieve Event
    public class ModuleRetrieve : Base
    {
        public decimal MarketID { get; set; }
        public string Slot { get; set; }
        public string RetrievedItem { get; set; }
        public string RetrievedItem_Localised { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }
        public bool Hot { get; set; }
        public string EngineerModifications { get; set; }
        public decimal Level { get; set; }
        public decimal Quality { get; set; }
        public string SwapOutItem { get; set; }
        public string SwapOutItem_Localised { get; set; }
    }
    #endregion

    #region ModuleSell Event
    public class ModuleSell : Base
    {
        public decimal MarketID { get; set; }
        public string Slot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public decimal SellPrice { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }
    }
    #endregion

    #region ModuleSellRemote Event
    public class ModuleSellRemote : Base
    {
        public decimal StorageSlot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public decimal ServerId { get; set; }
        public decimal SellPrice { get; set; }
        public string Ship { get; set; }
        public decimal ShipID { get; set; }
    }
    #endregion

    #region Music Event
    public class Music : Base
    {
        public string MusicTrack { get; set; }
    }
    #endregion

    #region NavBeaconScan Event
    public class NavBeaconScan : Base
    {
        public decimal SystemAddress { get; set; }
        public decimal NumBodies { get; set; }
    }
    #endregion

    #region NpcCrewPaidWage Event
    public class NpcCrewPaidWage : Base
    {
        public string NpcCrewName { get; set; }
        public decimal NpcCrewId { get; set; }
        public decimal Amount { get; set; }
    }
    #endregion

    #region NpcCrewRank Event
    public class NpcCrewRank : Base
    {
        public string NpcCrewName { get; set; }
        public decimal NpcCrewId { get; set; }
        public decimal RankCombat { get; set; }
    }
    #endregion

    #region Outfitting Event
    public class Outfitting : Base
    {
        public decimal MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }
    }
    #endregion

    #region PayBounties Event
    public class PayBounties : Base
    {
        public decimal Amount { get; set; }
        public string Faction { get; set; }
        public string Faction_Localised { get; set; }
        public decimal ShipID { get; set; }
        public decimal BrokerPercentage { get; set; }
    }
    #endregion

    #region PayFines Event
    public class PayFines : Base
    {
        public decimal Amount { get; set; }
        public bool AllFines { get; set; }
        public decimal ShipID { get; set; }
    }
    #endregion

    #region PayLegacyFines Event
    public class PayLegacyFines : Base
    {
        public decimal Amount { get; set; }
    }
    #endregion

    #region Powerplay Event
    public class Powerplay : Base
    {
        public string Power { get; set; }
        public decimal Rank { get; set; }
        public decimal Merits { get; set; }
        public decimal Votes { get; set; }
        public decimal TimePledged { get; set; }
    }
    #endregion

    #region PowerplayDefect Event
    public class PowerplayDefect : Base
    {
        public string FromPower { get; set; }
        public string ToPower { get; set; }
    }
    #endregion

    #region PowerplayLeave Event
    public class PowerplayLeave : Base
    {
        public string Power { get; set; }
    }
    #endregion

    #region PowerplaySalary Event
    public class PowerplaySalary : Base
    {
        public string Power { get; set; }
        public decimal Amount { get; set; }
    }
    #endregion

    #region Progress Event
    public class Progress : Base
    {
        public decimal Combat { get; set; }
        public decimal Trade { get; set; }
        public decimal Explore { get; set; }
        public decimal Empire { get; set; }
        public decimal Federation { get; set; }
        public decimal CQC { get; set; }
    }
    #endregion

    #region Promotion Event
    public class Promotion : Base
    {
        public decimal Empire { get; set; }
        public decimal Combat { get; set; }
        public decimal Trade { get; set; }
        public decimal Federation { get; set; }
        public decimal Alliance { get; set; }
        public decimal Independent { get; set; }
    }
    #endregion

    #region QuitACrew Event
    public class QuitACrew : Base
    {
        public string Captain { get; set; }
    }
    #endregion

    #region Rank Event
    public class Rank : Base
    {
        public decimal Combat { get; set; }
        public decimal Trade { get; set; }
        public decimal Explore { get; set; }
        public decimal Empire { get; set; }
        public decimal Federation { get; set; }
        public decimal CQC { get; set; }
    }
    #endregion

    #region RebootRepair Event
    public class RebootRepair : Base
    {
        public List<string> Modules { get; set; }
    }
    #endregion

    #region ReceiveText Event
    public class ReceiveText : Base
    {
        public string From { get; set; }
        public string From_Localised { get; set; }
        public string Message { get; set; }
        public string Message_Localised { get; set; }
        public string Channel { get; set; }
    }
    #endregion

    #region RedeemVoucher Event
    public class RedeemVoucher : Base
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public List<Fact> Factions { get; set; }
        public string Faction { get; set; }
        public decimal BrokerPercentage { get; set; }

        public class Fact : Catch
        {
            public string Faction { get; set; }
            public decimal Amount { get; set; }
        }
    }
    #endregion

    #region RefuelAll Event
    public class RefuelAll : Base
    {
        public decimal Cost { get; set; }
        public decimal Amount { get; set; }
    }
    #endregion

    #region Repair Event
    public class Repair : Base
    {
        public string Item { get; set; }
        public string Item_Localised { get; set; }
        public decimal Cost { get; set; }
    }
    #endregion

    #region RepairAll Event
    public class RepairAll : Base
    {
        public decimal Cost { get; set; }
    }
    #endregion

    #region RepairDrone Event
    public class RepairDrone : Base
    {
        public decimal HullRepaired { get; set; }
    }
    #endregion

    #region Reputation Event
    public class Reputation : Base
    {
        public decimal Empire { get; set; }
        public decimal Federation { get; set; }
        public decimal Independent { get; set; }
        public decimal Alliance { get; set; }
    }
    #endregion

    #region RestockVehicle Event
    public class RestockVehicle : Base
    {
        public string Type { get; set; }
        public string Loadout { get; set; }
        public decimal Cost { get; set; }
        public decimal Count { get; set; }
    }
    #endregion

    #region Resurrect Event
    public class Resurrect : Base
    {
        public string Option { get; set; }
        public decimal Cost { get; set; }
        public string Bankrupt { get; set; }
    }
    #endregion

    #region Scan Event
    public class Scan : Base
    {
        public string ScanType { get; set; }
        public string BodyName { get; set; }
        public decimal BodyID { get; set; }
        public List<ScanParent> Parents { get; set; }
        public decimal DistanceFromArrivalLS { get; set; }
        public bool TidalLock { get; set; }
        public string TerraformState { get; set; }
        public string PlanetClass { get; set; }
        public string Atmosphere { get; set; }
        public string AtmosphereType { get; set; }
        public List<ScanComposition> AtmosphereComposition { get; set; }
        public string Volcanism { get; set; }
        public decimal MassEM { get; set; }
        public string StarType { get; set; }
        public decimal StellarMass { get; set; }
        public decimal Radius { get; set; }
        public decimal SurfaceGravity { get; set; }
        public decimal AbsoluteMagnitude { get; set; }
        public decimal Age_MY { get; set; }
        public decimal SurfaceTemperature { get; set; }
        public decimal SurfacePressure { get; set; }
        public bool Landable { get; set; }
        public List<ScanMaterial> Materials { get; set; }
        public ScanComposite Composition { get; set; }
        public string Luminosity { get; set; }
        public decimal SemiMajorAxis { get; set; }
        public decimal Eccentricity { get; set; }
        public decimal OrbitalInclination { get; set; }
        public decimal Periapsis { get; set; }
        public decimal OrbitalPeriod { get; set; }
        public decimal RotationPeriod { get; set; }
        public decimal AxialTilt { get; set; }
        public List<ScanRings> Rings { get; set; }
        public string ReserveLevel { get; set; }

        public class ScanComposition
        {
            public string Name { get; set; }
            public decimal Percent { get; set; }
        }

        public class ScanParent : Catch
        {
            public decimal Null { get; set; }
            public decimal Planet { get; set; }
            public decimal Star { get; set; }
            public decimal Ring { get; set; }
        }

        public class ScanMaterial : Catch
        {
            public string Name { get; set; }
            public decimal Percent { get; set; }
        }

        public class ScanComposite : Catch
        {
            public decimal Ice { get; set; }
            public decimal Rock { get; set; }
            public decimal Metal { get; set; }
        }

        public class ScanRings : Catch
        {
            public string Name { get; set; }
            public string RingClass { get; set; }
            public decimal MassMT { get; set; }
            public decimal InnerRad { get; set; }
            public decimal OuterRad { get; set; }
        }
    }
    #endregion

    #region Scanned Event
    public class Scanned : Base
    {
        public string ScanType { get; set; }
    }
    #endregion

    #region Screenshot Event
    public class Screenshot : Base
    {
        public string Filename { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string System { get; set; }
        public string Body { get; set; }
    }
    #endregion

    #region SendText Event
    public class SendText : Base
    {
        public string To { get; set; }
        public string Message { get; set; }
    }
    #endregion

    #region SellDrones Event
    public class SellDrones : Base
    {
        public string Type { get; set; }
        public decimal Count { get; set; }
        public decimal SellPrice { get; set; }
        public decimal TotalSale { get; set; }
    }
    #endregion

    #region SellExplorationData Event
    public class SellExplorationData : Base
    {
        public List<string> Systems { get; set; }
        public List<string> Discovered { get; set; }
        public decimal BaseValue { get; set; }
        public decimal Bonus { get; set; }
        public decimal TotalEarnings { get; set; }
    }
    #endregion

    #region SetUserShipName Event
    public class SetUserShipName : Base
    {
        public string Ship { get; set; }
        public decimal ShipID { get; set; }
        public string UserShipName { get; set; }
        public string UserShipId { get; set; }
    }
    #endregion

    #region ShieldState Event
    public class ShieldState : Base
    {
        public string ShieldsUp { get; set; }
    }
    #endregion

    #region ShipTargeted Event
    public class ShipTargeted : Base
    {
        public bool TargetLocked { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public decimal ScanStage { get; set; }
        public string PilotName { get; set; }
        public string PilotName_Localised { get; set; }
        public string PilotRank { get; set; }
        public decimal ShieldHealth { get; set; }
        public decimal HullHealth { get; set; }
        public string Faction { get; set; }
        public string LegalStatus { get; set; }
        public decimal Bounty { get; set; }
        public string Subsystem { get; set; }
        public string Subsystem_Localised { get; set; }
        public decimal SubsystemHealth { get; set; }
    }
    #endregion

    #region Shipyard Event
    public class Shipyard : Base
    {
        public decimal MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }
    }
    #endregion

    #region ShipyardBuy Event
    public class ShipyardBuy : Base
    {
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public decimal ShipPrice { get; set; }
        public string SellOldShip { get; set; }
        public decimal SellShipID { get; set; }
        public decimal SellPrice { get; set; }
        public decimal MarketID { get; set; }
        public string StoreOldShip { get; set; }
        public decimal StoreShipID { get; set; }
    }
    #endregion

    #region ShipyardNew Event
    public class ShipyardNew : Base
    {
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public decimal NewShipID { get; set; }
    }
    #endregion

    #region ShipyardSell Event
    public class ShipyardSell : Base
    {
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public decimal SellShipID { get; set; }
        public decimal ShipPrice { get; set; }
        public decimal MarketID { get; set; }
        public string System { get; set; }
        public decimal ShipMarketID { get; set; }
    }
    #endregion

    #region ShipyardSwap Event
    public class ShipyardSwap : Base
    {
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public decimal ShipID { get; set; }
        public string StoreOldShip { get; set; }
        public decimal StoreShipID { get; set; }
        public decimal MarketID { get; set; }
    }
    #endregion

    #region ShipyardTransfer Event
    public class ShipyardTransfer : Base
    {
        public string ShipType { get; set; }
        public string ShipType_Localised { get; set; }
        public decimal ShipID { get; set; }
        public string System { get; set; }
        public decimal ShipMarketID { get; set; }
        public decimal Distance { get; set; }
        public decimal TransferPrice { get; set; }
        public decimal TransferTime { get; set; }
        public decimal MarketID { get; set; }
    }
    #endregion

    #region Shutdown Event
    public class Shutdown : Base
    {
    }
    #endregion

    #region SRVDestroyed Event
    public class SRVDestroyed : Base
    {
    }
    #endregion

    #region StartJump Event
    public class StartJump : Base
    {
        public string JumpType { get; set; }
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public string StarClass { get; set; }
    }
    #endregion

    #region StoredModules Event
    public class StoredModules : Base
    {
        public decimal MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item : Catch
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public decimal StorageSlot { get; set; }
        public string StarSystem { get; set; }
        public decimal MarketID { get; set; }
        public decimal TransferCost { get; set; }
        public decimal TransferTime { get; set; }
        public decimal BuyPrice { get; set; }
        public bool Hot { get; set; }
        public string EngineerModifications { get; set; }
        public decimal Level { get; set; }
        public decimal Quality { get; set; }
        public bool InTransit { get; set; }
    }
    #endregion

    #region StoredShips Event
    public class StoredShips : Base
    {
        public string StationName { get; set; }
        public decimal MarketID { get; set; }
        public string StarSystem { get; set; }
        public List<Ship> ShipsHere { get; set; }
        public List<Ship> ShipsRemote { get; set; }

        public class Ship
        {
            public decimal ShipID { get; set; }
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public string Name { get; set; }
            public string StarSystem { get; set; }
            public decimal ShipMarketID { get; set; }
            public decimal TransferPrice { get; set; }
            public decimal TransferTime { get; set; }
            public decimal Value { get; set; }
            public bool Hot { get; set; }
            public bool InTransit { get; set; }
        }
    }
    #endregion

    #region Statistics Event
    public class Statistics : Base
    {
        public BankAccountStat Bank_Account { get; set; }
        public CombatStat Combat { get; set; }
        public CrimeStat Crime { get; set; }
        public SmugglingStat Smuggling { get; set; }
        public TradingStat Trading { get; set; }
        public MiningStat Mining { get; set; }
        public ExplorationStat Exploration { get; set; }
        public PassengersStat Passengers { get; set; }
        public Search_And_RescueStat Search_And_Rescue { get; set; }
        public CraftingStat Crafting { get; set; }
        public CrewStat Crew { get; set; }
        public MulticrewStat Multicrew { get; set; }
        public Material_TraderStat material_Trader_Stats { get; set; }
        public TG_Encounters TG_ENCOUNTERS { get; set; }
        public CQCStat CQC { get; set; }

        public class BankAccountStat : Catch
        {
            public decimal Current_Wealth { get; set; }
            public decimal Spent_On_Ships { get; set; }
            public decimal Spent_On_Outfitting { get; set; }
            public decimal Spent_On_Repairs { get; set; }
            public decimal Spent_On_Fuel { get; set; }
            public decimal Spent_On_Ammo_Consumables { get; set; }
            public decimal Insurance_Claims { get; set; }
            public decimal Spent_On_Insurance { get; set; }
        }

        public class CombatStat : Catch
        {
            public decimal Bounties_Claimed { get; set; }
            public decimal Bounty_Hunting_Profit { get; set; }
            public decimal Combat_Bonds { get; set; }
            public decimal Combat_Bond_Profits { get; set; }
            public decimal Assassinations { get; set; }
            public decimal Assassination_Profits { get; set; }
            public decimal Highest_Single_Reward { get; set; }
            public decimal Skimmers_Killed { get; set; }
        }

        public class CrimeStat : Catch
        {
            public decimal Notoriety { get; set; }
            public decimal Fines { get; set; }
            public decimal Total_Fines { get; set; }
            public decimal Bounties_Received { get; set; }
            public decimal Total_Bounties { get; set; }
            public decimal Highest_Bounty { get; set; }
        }

        public class SmugglingStat : Catch
        {
            public decimal Black_Markets_Traded_With { get; set; }
            public decimal Black_Markets_Profits { get; set; }
            public decimal Resources_Smuggled { get; set; }
            public decimal Average_Profit { get; set; }
            public decimal Highest_Single_Transaction { get; set; }
        }

        public class TradingStat : Catch
        {
            public decimal Markets_Traded_With { get; set; }
            public decimal Market_Profits { get; set; }
            public decimal Resources_Traded { get; set; }
            public decimal Average_Profit { get; set; }
            public decimal Highest_Single_Transaction { get; set; }
        }

        public class MiningStat : Catch
        {
            public decimal Mining_Profits { get; set; }
            public decimal Quantity_Mined { get; set; }
            public decimal Materials_Collected { get; set; }
        }

        public class ExplorationStat : Catch
        {
            public decimal Systems_Visited { get; set; }
            public decimal Exploration_Profits { get; set; }
            public decimal Planets_Scanned_To_Level_2 { get; set; }
            public decimal Planets_Scanned_To_Level_3 { get; set; }
            public decimal Highest_Payout { get; set; }
            public decimal Total_Hyperspace_Distance { get; set; }
            public decimal Total_Hyperspace_Jumps { get; set; }
            public decimal Greatest_Distance_From_Start { get; set; }
            public decimal Time_Played { get; set; }
        }

        public class PassengersStat : Catch
        {
            public decimal Passengers_Missions_Accepted { get; set; }
            public decimal Passengers_Missions_Disgruntled { get; set; }
            public decimal Passengers_Missions_Bulk { get; set; }
            public decimal Passengers_Missions_VIP { get; set; }
            public decimal Passengers_Missions_Delivered { get; set; }
            public decimal Passengers_Missions_Ejected { get; set; }
        }

        public class Search_And_RescueStat : Catch
        {
            public decimal SearchRescue_Traded { get; set; }
            public decimal SearchRescue_Profit { get; set; }
            public decimal SearchRescue_Count { get; set; }
        }

        public class TG_Encounters : Catch
        {
            public decimal TG_ENCOUNTER_IMPRINT { get; set; }
            public decimal TG_ENCOUNTER_TOTAL { get; set; }
            public string TG_ENCOUNTER_TOTAL_LAST_SYSTEM { get; set; }
            public DateTime TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP { get; set; }
            public string TG_ENCOUNTER_TOTAL_LAST_SHIP { get; set; }
            public decimal TG_SCOUT_COUNT { get; set; }
        }

        public class CraftingStat : Catch
        {
            public decimal Count_Of_Used_Engineers { get; set; }
            public decimal Recipes_Generated { get; set; }
            public decimal Recipes_Generated_Rank_1 { get; set; }
            public decimal Recipes_Generated_Rank_2 { get; set; }
            public decimal Recipes_Generated_Rank_3 { get; set; }
            public decimal Recipes_Generated_Rank_4 { get; set; }
            public decimal Recipes_Generated_Rank_5 { get; set; }
        }

        public class CrewStat : Catch
        {
            public decimal NpcCrew_TotalWages { get; set; }
            public decimal NpcCrew_Hired { get; set; }
            public decimal NpcCrew_Fired { get; set; }
            public decimal NpcCrew_Died { get; set; }
        }

        public class MulticrewStat : Catch
        {
            public decimal Multicrew_Time_Total { get; set; }
            public decimal Multicrew_Gunner_Time_Total { get; set; }
            public decimal Multicrew_Fighter_Time_Total { get; set; }
            public decimal Multicrew_Credits_Total { get; set; }
            public decimal Multicrew_Fines_Total { get; set; }
        }

        public class Material_TraderStat : Catch
        {
            public decimal Trades_Completed { get; set; }
            public decimal Materials_Traded { get; set; }
            public decimal Encoded_Materials_Traded { get; set; }
            public decimal Raw_Materials_Traded { get; set; }
            public decimal Grade_1_Materials_Traded { get; set; }
            public decimal Grade_2_Materials_Traded { get; set; }
            public decimal Grade_3_Materials_Traded { get; set; }
            public decimal Grade_4_Materials_Traded { get; set; }
            public decimal Grade_5_Materials_Traded { get; set; }
        }

        public class CQCStat : Catch
        {
            public decimal CQC_Credits_Earned { get; set; }
            public decimal CQC_Time_Played { get; set; }
            public decimal CQC_KD { get; set; }
            public decimal CQC_Kills { get; set; }
            public decimal CQC_WL { get; set; }
        }
    }
    #endregion

    #region SupercruiseEntry Event
    public class SupercruiseEntry : Base
    {
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
    }
    #endregion

    #region SupercruiseExit Event
    public class SupercruiseExit : Base
    {
        public string StarSystem { get; set; }
        public decimal SystemAddress { get; set; }
        public string Body { get; set; }
        public decimal BodyID { get; set; }
        public string BodyType { get; set; }
    }
    #endregion

    #region Synthesis Event
    public class Synthesis : Base
    {
        public string Name { get; set; }
        public List<SynthMaterial> Materials { get; set; }

        public class SynthMaterial
        {
            public string Name { get; set; }
            public decimal Count { get; set; }
        }
    }
    #endregion

    #region TechnologyBroker Event
    public class TechnologyBroker : Base
    {
        public string BrokerType { get; set; }
        public decimal MarketID { get; set; }
        public List<ItemUnlock> ItemsUnlocked { get; set; }
        public List<Commoditie> Commodities { get; set; }
        public List<Material> Materials { get; set; }

        public class ItemUnlock
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
        }

        public class Commoditie
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
        }

        public class Material
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
            public string Category { get; set; }
        }
    }
    #endregion

    #region Touchdown Event
    public class Touchdown : Base
    {
        public string PlayerControlled { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
    #endregion

    #region UnderAttack Event
    public class UnderAttack : Base
    {
        public string Target { get; set; }
    }
    #endregion

    #region Undocked Event
    public class Undocked : Base
    {
        public string StationName { get; set; }
        public string StationType { get; set; }
        public decimal MarketID { get; set; }
    }
    #endregion

    #region USSDrop Event
    public class USSDrop : Base
    {
        public string USSType { get; set; }
        public string USSType_Localised { get; set; }
        public decimal USSThreat { get; set; }
    }
    #endregion

    #region VehicleSwitch Event
    public class VehicleSwitch : Base
    {
        public string To { get; set; }
    }
    #endregion

    #region WingAdd Event
    public class WingAdd : Base
    {
        public string Name { get; set; }
    }
    #endregion

    #region WingInvite Event
    public class WingInvite : Base
    {
        public string Name { get; set; }
    }
    #endregion

    #region WingJoin Event
    public class WingJoin : Base
    {
        public List<string> Others { get; set; }
    }
    #endregion

    #region WingLeave Event
    public class WingLeave : Base
    {
    }
    #endregion

    #endregion
}