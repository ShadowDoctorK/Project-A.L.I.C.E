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

namespace ALICE_Community_Toolkit
{
    /// <summary>
    /// Interaction logic for Response_Generator.xaml
    /// </summary>
    public partial class Response_Generator : System.Windows.Controls.UserControl
    {
        public Response_Generator()
        {
            InitializeComponent();
            TextBox_UserFilesDirectory.Text = Paths.ALICE_ResponseUser;
        }

        #region Form Data / Collections
        //Responses Dictionary stores all the data used for export.
        public volatile static Dictionary<string, Response> Responses = new Dictionary<string, Response>();

        //Segments, SegmentNames and Strings only display data in the ListBox's
        //Actual Data is Stored and Updated in the Responses Dictionary and repopulates
        //in the display colletions.
        public volatile static Dictionary<string, List<string>> Segments = new Dictionary<string, List<string>>();
        public volatile static List<string> SegmentNames = new List<string>();
        public volatile static List<string> SegmentInformation = new List<string>();
        public volatile static List<string> Strings = new List<string>();

        /// <summary>
        /// Response Object. Contains a Undefined Catch to prevent exceptions.
        /// </summary>
        public class Response
        {
            public string ResponseName { get; set; }
            public List<string> SegmentNames { get; set; }
            public List<string> SegmentInformation { get; set; }
            public Dictionary<string, List<string>> Segments { get; set; }

            public Response()
            {
                ResponseName = null;
                SegmentNames = new List<string>();
                SegmentInformation = new List<string>();
                Segments = new Dictionary<string, List<string>>();
            }

            [JsonExtensionData]
            public IDictionary<string, object> Undefined { get; set; }

            public IDictionary<string, object> UndefinedProperties()
            {
                return Undefined;
            }
        }

        public void ResetAllCollections()
        {
            Responses = new Dictionary<string, Response>();
            Segments = new Dictionary<string, List<string>>();
            SegmentNames = new List<string>();
            SegmentInformation = new List<string>();
            Strings = new List<string>();
        }
        #endregion

        #region Form Methods
        public void Deserialize(string FilePath)
        {
            FileStream FS = null;
            try
            {
                FS = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader SR = new StreamReader(FS))
                {
                    while (!SR.EndOfStream)
                    {
                        string Line = SR.ReadLine();
                        var NewRes = JsonConvert.DeserializeObject<Response>(Line);

                        Response_Add(NewRes);
                    }                  
                }
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }

        public void Serialize(string FilePath = null, string ResKey = null, bool Group = false, bool Individual = false, bool User = false)
        {
            FileStream FS = null;
            try
            {
                if (Group)
                {
                    if (FilePath == null || FilePath == "")
                    { FilePath = MainWindow.SelectDirectory(); }

                    string path = FilePath + @"\" + TextBox_CombineFileName.Text + ".response";
                    FS = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                    using (StreamWriter file = new StreamWriter(FS))
                    {
                        foreach (KeyValuePair<string, Response> Res in Responses)
                        {
                            Response res = Res.Value;
                            var JSON = JsonConvert.SerializeObject(res);
                            file.WriteLine(JSON);
                        }
                    }

                    System.Windows.MessageBox.Show("Exported All Responses To: " + TextBox_CombineFileName.Text + ".response");
                }
                else if (Individual)
                {
                    try
                    {
                        foreach (var Res in Responses)
                        {
                            string path = "";
                            if (User == false)
                            {
                                if (FilePath == null || FilePath == "") { FilePath = MainWindow.SelectDirectory(); }
                                 path = FilePath + @"\" + Res.Key.ToString() + ".response";
                            }
                            else if (User == true) { path = Paths.ALICE_ResponseUser + Res.Key.ToString() + ".response"; }

                            FS = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                            using (StreamWriter file = new StreamWriter(FS))
                            {
                                Response res = Res.Value;
                                var JSON = JsonConvert.SerializeObject(res);
                                file.WriteLine(JSON);
                            }
                        }
                        System.Windows.MessageBox.Show("Exported All Responses");
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    string ListBoxItem = ListBox_Responses.SelectedItem.ToString();
                    string path = FilePath + @"\" + ListBoxItem + ".response";
                    FS = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
                    using (StreamWriter file = new StreamWriter(FS))
                    {
                        Response res = Responses[ResKey];
                        var JSON = JsonConvert.SerializeObject(res);
                        file.WriteLine(JSON);
                    }

                    System.Windows.MessageBox.Show("Exported Selected Response");
                }
            }
            finally
            {
                if (FS != null)
                { FS.Dispose(); }
            }
        }

        /// <summary>
        /// Method used during deserialization.
        /// </summary>
        /// <param name="NewRes"></param>
        public void Response_Add(Response NewRes)
        {
            if (!Responses.ContainsKey(NewRes.ResponseName))
            { Responses.Add(NewRes.ResponseName, NewRes); }
        }

        public void LB_Response_Update()
        {
            ListBox_Responses.ItemsSource = null;
            ListBox_Responses.ItemsSource = Responses.Keys;
        }

        public void LB_Segment_Update(string ResKey)
        {
            Segments = new Dictionary<string, List<string>>();
            SegmentNames = new List<string>();
            if (Responses[ResKey].Segments != null)
            {
                foreach (var Seg in Responses[ResKey].Segments)
                {
                    Segments.Add(Seg.Key, Seg.Value);
                }
                foreach (string SegName in Responses[ResKey].SegmentNames)
                {
                    SegmentNames.Add(SegName);
                }
            }
            ListBox_Segments.ItemsSource = null;
            ListBox_Segments.ItemsSource = SegmentNames;
        }

        public void LB_String_Update(int SegIndex)
        {
            Strings = new List<string>();
            if (Segments.Count != 0)
            {
                foreach (string SegString in Segments["S" + SegIndex.ToString()])
                {
                    Strings.Add(SegString);
                }
            }
            ListBox_Strings.ItemsSource = null;
            ListBox_Strings.ItemsSource = Strings;
        }

        public void TB_SegmentInfo_Update(string ResKey)
        {
            SegmentInformation = new List<string>();
            if (Responses[ResKey].Segments != null)
            {
                foreach (string SegInfo in Responses[ResKey].SegmentInformation)
                {
                    SegmentInformation.Add(SegInfo);
                }
            }
        }
        #endregion

        #region Buttons

        #region Top Menu Buttons
        private void btn_LoadFile_Click(object sender, RoutedEventArgs e)
        {
            ResetAllCollections();

            bool Empty = MainWindow.IsDirectoryEmpty(Paths.ALICE_ResponseUser);
            if (Directory.Exists(Paths.ALICE_ResponseUser) && Empty == false)
            {
                DirectoryInfo directory = new DirectoryInfo(Paths.ALICE_ResponseUser);
                foreach (FileInfo ResponseFile in directory.EnumerateFiles("*.response", SearchOption.AllDirectories))
                {
                    Deserialize(ResponseFile.FullName);
                }
                LB_Response_Update();
            }
            else
            {
                CreateUserTemplets();
                System.Windows.MessageBox.Show("No User Responses Detected. Generated New Templets.");
            }
        }

        private void btn_LoadDirectory_Click(object sender, RoutedEventArgs e)
        {
            ResetAllCollections();

            try
            {
                string Dir = MainWindow.SelectDirectory() + @"\";
                DirectoryInfo directory = new DirectoryInfo(Dir);
                foreach (FileInfo ResponseFile in directory.EnumerateFiles("*.response", SearchOption.TopDirectoryOnly))
                {
                    Deserialize(ResponseFile.FullName);
                }
                LB_Response_Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured While Loading The Files: " + ex);
            }
        }

        private void btn_SaveSelected_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = Paths.ALICE_ResponseUser;
            Serialize(FilePath, null, false, true, true);
        }

        private void btn_SaveIndividual_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = MainWindow.SelectDirectory();
            Serialize(FilePath, null, false, true);
        }

        private void btn_SaveCombine_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_CombineFileName.Text == null || TextBox_CombineFileName.Text == "")
            {
                MessageBox.Show("Please Enter a Filename and try again...");
                return;
            }
            string FilePath = MainWindow.SelectDirectory();
            Serialize(FilePath, null, true);
        }

        //End: Top Menu Buttons
        #endregion

        #region String Buttons
        private void btn_String_New_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Responses[TargetResponse()].Segments[TargetSegment()].Add(TextBox_Strings.Text);
                TextBox_Strings.Clear();
                LB_String_Update(SegmentIndex());
            }
            catch (Exception) { }
        }

        private void btn_String_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ListBox_Responses.SelectedItem != null)
                {
                    int TargetIndex = StringIndex(SelectedString());
                    Responses[TargetResponse()].Segments[TargetSegment()].Insert(TargetIndex, TextBox_Strings.Text);
                    Responses[TargetResponse()].Segments[TargetSegment()].RemoveAt(TargetIndex + 1);
                    TextBox_Strings.Clear();
                    LB_String_Update(SegmentIndex());
                }
            }
            catch (Exception)
            { }
        }

        private void btn_Strings_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Text = ListBox_Strings.SelectedItem.ToString();
                Responses[TargetResponse()].Segments[TargetSegment()].RemoveAt(StringIndex(Text));
                LB_String_Update(SegmentIndex());
            }
            catch (Exception)
            { }
        }

        //End: String Buttons
        #endregion

        //End: Buttons
        #endregion

        private void ListBox_Strings_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TextBox_Strings.Text = SelectedString();
            }
            catch (Exception)
            { }
        }

        private void ListBox_Segments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (SelectedSegment() != null && SelectedSegment() != "")
                {
                    LB_String_Update(SegmentIndex());
                    TextBox_SegmentDescription.Text = SegmentInformation[SegmentIndex()];
                }
            }
            catch (Exception)
            { }
        }

        private void ListBox_Responses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                LB_Segment_Update(TargetResponse());
                TB_SegmentInfo_Update(TargetResponse());
                TextBox_SegmentDescription.Clear();
            }
            catch (Exception)
            { }            
        }

        private void btn_CreateUserTemplets_Click(object sender, RoutedEventArgs e)
        {
            ResetAllCollections();
            CreateUserTemplets();
        }

        public void CreateUserTemplets()
        {
            Dictionary<string, Response> UserTempStorage = new Dictionary<string, Response>();
            string Dir = Paths.ALICE_Response + Paths.Folder_Default;
            DirectoryInfo directory = new DirectoryInfo(Dir);
            foreach (FileInfo ResponseFile in directory.EnumerateFiles("*.response", SearchOption.TopDirectoryOnly))
            {
                Deserialize(ResponseFile.FullName);
            }

            Dictionary<string, List<string>> NewSegments = new Dictionary<string, List<string>>();

            foreach (var Res in Responses.Values)
            {
                Response NewResponse = new Response
                {
                    ResponseName = Res.ResponseName,
                    SegmentNames = Res.SegmentNames,
                    SegmentInformation = Res.SegmentInformation,
                    Segments = new Dictionary<string, List<string>>()
                };

                foreach (var Seg in Res.Segments)
                {
                    NewResponse.Segments.Add(Seg.Key, new List<string>());
                }

                UserTempStorage.Add(Res.ResponseName, NewResponse);
            }

            Responses = UserTempStorage;

            LB_Response_Update();
        }

        #region Functions
        private string TargetResponse()
        {
            try { return ListBox_Responses.SelectedItem.ToString(); }
            catch (Exception ex) { return null; }            
        }

        private string TargetSegment()
        {
            return "S" + SegmentIndex().ToString();
        }

        private string SelectedSegment()
        {
            return ListBox_Segments.SelectedItem.ToString();
        }

        private string SelectedString()
        {
            return ListBox_Strings.SelectedItem.ToString();
        }

        private int SegmentIndex()
        {
            return SegmentNames.FindIndex(x => x == SelectedSegment());
        }

        private int SegmentIndex(string TargetSegment)
        {
            return SegmentNames.FindIndex(x => x == TargetSegment);
        }

        private int StringIndex(string Text)
        {
            return Responses[TargetResponse()].Segments[TargetSegment()].FindIndex(x => x == Text);
        }
        #endregion
    }
}
