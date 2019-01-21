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
    /// Interaction logic for Response_Generator.xaml
    /// </summary>
    public partial class Response_Generator : System.Windows.Controls.UserControl
    {
        public Response_Generator()
        {
            InitializeComponent();
        }

        #region Form Data / Collections
        //Responses Dictionary stores all the data used for export.
        public ResponseCollection Responses = new ResponseCollection();

        //Enum Used to feedback more data when a Boolean doesn't meet the requirements
        public enum Answer { Default, Positive, Negative, Error }

        //Enum Used to allow more range of selection when interfacing with the Responeses
        public enum Line { Default, Standard, Alternate }

        //Enum Used to define how to group files when Serializing
        public enum Save { Default, Selected, Individual, Combine }

        /// <summary>
        /// Response Object. Contains a Undefined Catch to prevent exceptions.
        /// </summary>
        public class Response : Base
        {
            public string Creator { get; set; }
            public string Version { get; set; }
            public bool Default { get; set; }
            public List<Segment> Segments = new List<Segment>();
            public Response() { Default = true; }

            public class Segment : Base
            {
                public List<Token> Tokens { get; set; }
                public List<Line> Lines = new List<Line>();
                public Segment()
                {
                    Tokens = new List<Token>();
                    Lines = new List<Line>();
                }

                public class Token : Base { }
                public class Line
                {
                    public bool Alternate { get; set; }
                    public int Weight { get; set; }
                    public string Text { get; set; }
                }

                #region Support Methods
                public ref List<Line> GetLines()
                {
                    return ref Lines;
                }

                public decimal LinesCount()
                {
                    return Lines.Count();
                }

                public bool AddLine(Line L)
                {
                    string MethodName = "Reponse (Add Line)";

                    switch (LineExists(L))
                    {
                        //Line Already Exists, Don't Add, Return False
                        case Answer.Positive:                            
                            return false;

                        //Line Does Not Exist, Add Line, Return True
                        case Answer.Negative:
                            Lines.Add(L);
                            return true;
                        
                        //Check Returned An Error State
                        case Answer.Error:
                            //Logger.Error(MethodName, "Error Was Returned During Check. Aborted Adding Line", //Logger.Red);
                            return false;

                        default:
                            //Logger.Error(MethodName, "Returned Using The Default Swtich", //Logger.Red);
                            return false;
                    }
                }

                public bool DeleteLine(Line L)
                {
                    string MethodName = "Reponse (Delete Line)";

                    int Temp = GetLineIndex(L); switch (Temp)
                    {
                        case -1:
                            //Logger.Error(MethodName, "Unable To Remove The Line. Index Not Found.", //Logger.Red);
                            return false;

                        default:
                            try
                            {
                                Lines.RemoveAt(Temp);
                            }
                            catch (Exception ex)
                            {
                                //Logger.Exception(MethodName, "Exception: " + ex);
                                //Logger.Exception(MethodName, "We Found The Line But Was Unable To Remove It");
                            }
                            return true;
                    }
                }

                public Answer LineExists(Line L)
                {
                    string MethodName = "Response (Line Exists)";

                    try
                    {
                        int Temp = Lines.FindIndex(X => X.Text == L.Text && X.Alternate == L.Alternate);
                        if (Temp != -1) return Answer.Positive;
                    }
                    catch (Exception)
                    {
                        //Logger.Exception(MethodName, "Exception Occured, Returning Defaults And Continuing");
                        return Answer.Error;
                    }

                    return Answer.Negative;
                }

                public int GetLineIndex(Line L)
                {
                    string MethodName = "Response (Line Index)";

                    int Answer = -1; try
                    {
                        Answer = Lines.FindIndex(X => X.Text == L.Text && X.Alternate == L.Alternate);
                    }
                    catch (Exception ex)
                    {
                        //Logger.Exception(MethodName, "Exception: " + ex);
                        //Logger.Exception(MethodName, "Exception Occured, Returning Default Value And Continuing");
                    }

                    return Answer;
                }

                public string GetLine(bool W, bool A)
                {
                    string MethodName = "Response (Get Alternate)";

                    string Text = "";
                    Random RanNum = new Random();

                    //Get The Average Weight Of The Segment.
                    int Weight = GetWeight(A);

                    //Emtpy List Of Int's To Store Valid Line Index's
                    List<int> ValidLines = new List<int>();

                    //Check Each Line In The Segment
                    int Index = 0; foreach (Line L in Lines)
                    {
                        //Alternate = true
                        if (L.Alternate == true)
                        {
                            //Weight Is Enabled & Line Weight Less Than Avg + 2
                            if (W == true && L.Weight < Weight + 2)
                            {
                                ValidLines.Add(Index);
                            }
                            //Weight Is Disabled
                            else if (W == false)
                            {
                                ValidLines.Add(Index);
                            }
                        }

                        //Track Index
                        Index++;
                    }

                    //Get ValidLines Count & Pick Random String
                    int Count = ValidLines.Count(); if (Count != 0)
                    {
                        //Pick A Random Valid Number Index
                        int Select = ValidLines[RanNum.Next(0, Count - 1)];

                        //Increase Line Weight Count
                        Lines[Select].Weight++;

                        //Return Line
                        Text = Lines[Select].Text;
                    }
                    else
                    {
                        //Logger.DebugLine(MethodName, "There Wasn't Any Valid Returns Found", //Logger.Blue);
                    }

                    return Text;
                }

                /// <summary>
                /// Will return the Avegrage Weight for the Select Line types.
                /// </summary>
                /// <param name="A">True = Alternate Lines, False = Standard Lines</param>
                /// <returns>The Average Weight</returns>
                public int GetWeight(bool A)
                {
                    string MethodName = "Response (Get Weight)";

                    try
                    {
                        //Collect Weight From Each Line
                        decimal Answer = 0; decimal Count = 0; foreach (Line L in Lines)
                        {
                            //Looking For Alternate Lines Only
                            if (A && L.Alternate)
                            {
                                Answer = Answer + L.Weight; Count++;
                            }
                            else
                            {
                                Answer = Answer + L.Weight; Count++;
                            }

                        }

                        //If We Processed Any Lines Average The Answer
                        if (Count != 0) { Answer = Answer / Count; }

                        //Round The Decimal, Cast To Int.
                        return (int)Decimal.Round(Answer, 0);
                    }
                    catch (Exception ex)
                    {
                        //Logger.Exception(MethodName, "Exception: " + ex);
                        //Logger.Exception(MethodName, "Exception Occured, Returning Default Value And Continuing");
                        return 0;
                    }
                }
                #endregion
            }

            #region Support Methods
            public ref List<Segment> GetSegments()
            {
                return ref Segments;
            }

            public bool SegmentExists(string S)
            {
                return Segments.Any(X => X.Name == S);
            }

            public int GetSegmentIndex(Segment S)
            {
                string MethodName = "Response (Segment Index)";

                int Answer = -1; try
                {
                    Answer = Segments.FindIndex(X => X.Name == S.Name);
                }
                catch (Exception ex)
                {
                    //Logger.Exception(MethodName, "Exception: " + ex);
                    //Logger.Exception(MethodName, "Exception Occured, Returning Default Value And Continuing");
                }

                return Answer;
            }

            public int GetSegmentIndex(string S)
            {
                string MethodName = "Response (Segment Index)";

                int Answer = -1; try
                {
                    Answer = Segments.FindIndex(X => X.Name == S);
                }
                catch (Exception ex)
                {
                    //Logger.Exception(MethodName, "Exception: " + ex);
                    //Logger.Exception(MethodName, "Exception Occured, Returning Default Value And Continuing");
                }

                return Answer;
            }
            #endregion
        }

        public class Base
        {
            public string Name { get; set; }
            public string Info { get; set; }
        }

        public class ResponseCollection
        {
            //Collection Of Responses
            public Dictionary<string, Response> Storage = new Dictionary<string, Response>();

            #region Support Methods
            /// <summary>
            /// Add A Response To the Collection of Responses.
            /// </summary>
            /// <param name="R">The Response you want to add.</param>
            /// <param name="M">When set to true and the same response exists it will merge the reponse your adding to the existing data.</param>
            public void Add(Response R, bool M)
            {
                //Check If Response Is In the Dictionary
                if (Storage.ContainsKey(R.Name) == false)
                {
                    //Add New Response
                    Storage.Add(R.Name, R);
                }
                //Response Exists, Do We Merge...
                else if (M)
                {
                    //Pass Response To Merge
                    Merge(R);
                }
            }

            /// <summary>
            /// Will Merge the Response you pass with the Collection if the response exists.
            /// </summary>
            /// <param name="A">The Response you want to add to the collection.</param>      
            private void Merge(Response A)
            {
                string MethodName = "Response (Merge)";

                try
                {
                    //Check Response Exists
                    if (Exists(A.Name) == false)
                    {
                        //Response Doesn't Exist, Return
                        //Logger.DebugLine(MethodName, A.Name + " Doesn't Exist. Skipping The Merge.", //Logger.Blue);
                        return;
                    }

                    //Begin Merging Responses
                    foreach (var Seg in A.Segments)
                    {
                        //Get Reference To The Segment List
                        List<Response.Segment> SegList = Storage[A.Name].GetSegments();

                        //Check Response A Contains Target Segment
                        if (Storage[A.Name].SegmentExists(A.Name))
                        {
                            //Get Response A's Index For The Target Segment
                            int Index = Storage[A.Name].GetSegmentIndex(Seg);

                            //Attempt To Add New Information
                            foreach (var Line in Seg.Lines)
                            {
                                //This Is The Most Likely To Fail, Catching Errors
                                //To Allow The Foreach Loop To Continue To Process
                                try
                                {
                                    //Response Methods Will Auto Filter Duplicates
                                    SegList[Index].AddLine(Line);
                                }
                                catch (Exception ex)
                                {
                                    //Logger.Exception(MethodName, "Exception: " + ex);
                                    //Logger.Exception(MethodName, "Exception Occured While Merging Response Data, Attempting To Continuing");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Logger.Exception(MethodName, "Exception: " + ex);
                    //Logger.Exception(MethodName, "(Failed) The Hamster That Merges Responses Died...");
                }
            }

            /// <summary>
            /// Validates that the Target Response and Segement Exists for use.
            /// </summary>
            /// <param name="R">Response Name</param>
            /// <param name="S">Segment Name</param>
            /// <returns>Postive, Negative or Error</returns>
            public Answer Validation(string R, string S)
            {
                string MethodName = "Response (Validation)";

                try
                {
                    //Check If Response Exists
                    if (Exists(R))
                    {
                        //Check If Segment Exists
                        if (Storage[R].SegmentExists(S))
                        {
                            //Validation Passed, Return Postive Answer
                            return Answer.Positive;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Logger.Exception(MethodName, "Exception: " + ex);
                    //Logger.Exception(MethodName, "Exception Occured, Returing Failed Validation.");
                    return Answer.Error;
                }

                //Validation Failed, Return Negative Answer
                return Answer.Negative;
            }

            /// <summary>
            /// Get the target Response if it exists.
            /// </summary>
            /// <param name="R">Response Name</param>
            /// <returns>Response if it exists, Null if it does not.</returns>
            public Response Get(string R)
            {
                if (Exists(R)) { return Storage[R]; }
                return null;
            }

            /// <summary>
            /// Updates the target Response if it exists.
            /// </summary>
            /// <param name="R">Response Name</param>
            public void Set(Response R)
            {
                if (Exists(R.Name)) { Storage[R.Name] = R; }
            }

            /// <summary>
            /// Simple Check To Verify the Reponse Exists
            /// </summary>
            /// <param name="R">Response Name</param>
            /// <returns>True if exists</returns>
            public bool Exists(string R)
            {
                if (R == null) { return false; }
                if (Storage.ContainsKey(R)) { return true; }
                return false;
            }
            #endregion
        }
        #endregion

        #region Form Methods
        public void Deserialize(string FilePath)
        {
            try
            {                
                using (StreamReader SR = new StreamReader(new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    while (!SR.EndOfStream)
                    {
                        string Line = SR.ReadLine();
                        var Res = JsonConvert.DeserializeObject<Response>(Line);
                        Responses.Add(Res, true);
                    }
                }
            }
            catch (Exception) { }
        }

        public void Serialize(Save S, string FilePath = null, string R = null, string FileName = null)
        {
            if (FilePath == null || FilePath == "") { FilePath = MainWindow.SelectDirectory(); }

            switch (S)
            {
                case Save.Selected:

                    try
                    {
                        //Checks Selected Reponse Exists
                        if (Responses.Exists(SelectedResposne()))
                        {
                            FileName = SelectedResposne();
                            //Create StreamWriter, Get FileStream For Selected Response
                            using (StreamWriter SW = new StreamWriter(GetFileStream(FullFileName(FilePath, FileName))))
                            {
                                //Serialize Object, Write To File.
                                SW.WriteLine(JsonConvert.SerializeObject(Responses.Get(SelectedResposne())));
                            }
                        }

                        System.Windows.MessageBox.Show("Exported Selected Response To: " + FileName + ".Response");
                    }
                    catch (Exception) { }
                    break;

                case Save.Individual:

                    try
                    {
                        //Save Each Response To A File
                        foreach (Response Res in Responses.Storage.Values)
                        {
                            FileName = Res.Name;
                            //Create StreamWriter, Get FileStream For Selected Response
                            using (StreamWriter SW = new StreamWriter(GetFileStream(FullFileName(FilePath, FileName))))
                            {
                                //Serialize Object, Write To File.
                                SW.WriteLine(JsonConvert.SerializeObject(Res));
                            }
                        }

                        System.Windows.MessageBox.Show("Exported All Responses");
                    }
                    catch (Exception) { }
                    break;

                case Save.Combine:

                    try
                    {
                        //Check & Grab File Name
                        if (TextBox_CombineFileName.Text != null)
                        {
                            FileName = TextBox_CombineFileName.Text;
                            TextBox_CombineFileName.Text = null;
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("No Combined File Name Given");
                            return;
                        }

                        //Create StreamWriter, Get FileStream For Selected Response
                        using (StreamWriter SW = new StreamWriter(GetFileStream(FullFileName(FilePath, FileName))))
                        {
                            //Write Each Reponse To The File
                            foreach (Response Res in Responses.Storage.Values)
                            {
                                //Serialize Object, Write To File.
                                SW.WriteLine(JsonConvert.SerializeObject(Res));
                            }
                        }

                        System.Windows.MessageBox.Show("Exported All Responses To: " + FileName + ".Response");
                    }
                    catch (Exception) { }
                    break;

                default:
                    break;
            }
        }

        public string FullFileName(string FilePath, string FileName)
        {
            return FilePath + @"\" + FileName + ".Response";
        }

        public FileStream GetFileStream(string FullFileName)
        {
            return new FileStream(FullFileName, FileMode.Create, FileAccess.Write, FileShare.None);
        }

        public void CodeConstructor()
        {
            string FilePath = MainWindow.SelectDirectory();
            FilePath = FilePath + @"\" + "Formatted Code.txt";

            FileStream FS = null;
            try
            {
                FS = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                using (StreamWriter file = new StreamWriter(FS))
                {
                    file.WriteLine("#region Response Wrappers (" + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt") + ")");

                    foreach (KeyValuePair<string, Response> Res in Responses)
                    {
                        int Count = 0;

                        file.WriteLine("");
                        file.WriteLine("public static class " + Res.Key.Replace(" ", "_"));
                        file.WriteLine("{");
                        foreach (string Seg in Responses[Res.Key].SegmentNames)
                        {
                            file.WriteLine("    public static List<string> " + Seg.Replace(" ", "_") + " " + " = new List<string> { \"" + Res.Key + "\", \"S" + Count.ToString() + "\"};");
                            Count++;
                        }
                        file.WriteLine("}");
                    }

                    file.WriteLine("");
                    file.WriteLine("#endregion");
                }
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

        public void LB_Response_Update()
        {
            ListBox_Responses.ItemsSource = null;
            ListBox_Responses.ItemsSource = Responses.Keys;
        }
        #endregion

        #region Buttons

        #region Top Menu Buttons
        private void btn_LoadFile_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = MainWindow.SelectFile();
            if (FilePath != "" || FilePath != null)
            {
                Deserialize(FilePath);
                LB_Response_Update();
            }
        }

        private void btn_LoadDirectory_Click(object sender, RoutedEventArgs e)
        {
            string Dir = MainWindow.SelectDirectory() + @"\";
            DirectoryInfo directory = new DirectoryInfo(Dir);
            foreach (FileInfo ResponseFile in directory.EnumerateFiles("*.response", SearchOption.TopDirectoryOnly))
            {
                Deserialize(ResponseFile.FullName);
            }
            LB_Response_Update();
        }

        private void btn_SaveSelected_Click(object sender, RoutedEventArgs e)
        {
            string TargetResponse = ListBox_Responses.SelectedItem.ToString();
            string FilePath = MainWindow.SelectDirectory();
            if (TargetResponse != null)
            {
                Serialize(FilePath, TargetResponse);
            }
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

        private void btn_GenerateCode_Click(object sender, RoutedEventArgs e)
        {
            CodeConstructor();
        }

        //End: Top Menu Buttons
        #endregion

        #region Response Buttons
        private void btn_Response_New_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void btn_Response_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void btn_Resposne_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }


        //End: Response Buttons
        #endregion

        #region Segment Buttons
        private void btn_Segment_New_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void btn_Segment_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void btn_Segment_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        //End: Segment Buttons
        #endregion

        #region String Buttons
        private void btn_String_New_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void btn_String_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void btn_Strings_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        //End: String Buttons
        #endregion

        #region Token Buttons
        private void btn_Token_New_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void btn_Token_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void btn_Token_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }
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
            {
 
            }
        }

        private void ListBox_Segments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void ListBox_Responses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void btn_SegmentInformation_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private string SelectedResposne()
        {
            return ListBox_Responses.SelectedItem.ToString();
        }

        private string SelectedSegment()
        {
            return ListBox_Segments.SelectedItem.ToString();
        }

        private string SelectedString()
        {
            return ListBox_Strings.SelectedItem.ToString();
        }
    }
}
