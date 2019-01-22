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
        }

        #region Data / Collections
        //Responses Dictionary stores all the data used for export.
        public ResponseCollection Responses = new ResponseCollection();

        //Working Items
        public Response R_Response = new Response();
        public Response.Segment R_Segment = new Response.Segment();
        public Response.Segment.Line R_Line = new Response.Segment.Line();

        //Display Items
        //public List<string> SegmentNames = new List<string>();
        //public List<string> SegmentLines = new List<string>();

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
            public Response(string N)
            {
                Name = N;
                Default = true;
            }

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
                public decimal LinesCount()
                {
                    return Lines.Count();
                }

                public void DeleteAllLines()
                {
                    Lines = new List<Line>();
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

                /// <summary>
                /// Allows Replaceing a Target Line if it exists, Otherwise Adds it.
                /// </summary>
                /// <param name="O">Old Line</param>
                /// <param name="N">New Line</param>
                public void ReplaceLine(Line O, Line N)
                {
                    DeleteLine(O);
                    AddLine(N);
                }

                public Answer LineExists(Line L)
                {
                    string MethodName = "Response (Line Exists)";

                    int Temp = -1; try
                    {
                        Temp = Lines.FindIndex(X => X.Text == L.Text && X.Alternate == L.Alternate);
                        if (Temp != -1) return Answer.Positive;
                    }
                    catch (Exception ex)
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

                public Answer TokenExists(Token T)
                {
                    string MethodName = "Response (Token Exists)";

                    int Temp = -1; try
                    {
                        Temp = Tokens.FindIndex(X => X.Name == T.Name);
                        if (Temp != -1) return Answer.Positive;
                    }
                    catch (Exception ex)
                    {
                        //Logger.Exception(MethodName, "Exception Occured, Returning Defaults And Continuing");
                        return Answer.Error;
                    }

                    return Answer.Negative;
                }

                public void AddToken(Token L)
                {
                    string MethodName = "Reponse (Add Token)";

                    switch (TokenExists(L))
                    {
                        //Token Already Exists, Don't Add, Return False
                        case Answer.Positive:
                            return;

                        //Token Does Not Exist, Add Token, Return True
                        case Answer.Negative:
                            Tokens.Add(L);
                            return;

                        //Check Returned An Error State
                        case Answer.Error:
                            //Logger.Error(MethodName, "Error Was Returned During Check. Aborted Adding Token", //Logger.Red);
                            return;

                        default:
                            //Logger.Error(MethodName, "Returned Using The Default Swtich", //Logger.Red);
                            return;
                    }
                }

                public void DeleteToken(Token L)
                {
                    string MethodName = "Reponse (Delete Token)";

                    int Temp = GetTokenIndex(L); switch (Temp)
                    {
                        case -1:
                            //Logger.Error(MethodName, "Unable To Remove The Token. Index Not Found.", //Logger.Red);
                            return;

                        default:
                            try
                            {
                                Tokens.RemoveAt(Temp);
                            }
                            catch (Exception ex)
                            {
                                //Logger.Exception(MethodName, "Exception: " + ex);
                                //Logger.Exception(MethodName, "We Found The Token But Was Unable To Remove It");
                            }
                            return;
                    }
                }

                /// <summary>
                /// Allows Replaceing a Target Token if it exists, Otherwise Adds it.
                /// </summary>
                /// <param name="O">Old Token</param>
                /// <param name="N">New Token</param>
                public void ReplaceToken(Token O, Token N)
                {
                    DeleteToken(O);
                    AddToken(N);
                }

                public int GetTokenIndex(Token T)
                {
                    string MethodName = "Response (Token Index)";

                    int Answer = -1; try
                    {
                        Answer = Tokens.FindIndex(X => X.Name == T.Name);
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

            #region Support Methods
            public ref List<Segment> GetSegments()
            {
                return ref Segments;
            }

            /// <summary>
            /// Generates Users Templet
            /// </summary>
            public void GenerateUserTemplet()
            {
                int Count = Segments.Count() - 1;
                while (Count != -1)
                {
                    Segments[Count].DeleteAllLines();
                    Count--;
                }
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

            /// <summary>
            /// Gets the target Segment if it exists
            /// </summary>
            /// <param name="S">Segment Name</param>
            /// <returns>Returns Segment if it exists, otherwise returns null</returns>
            public Segment GetSegment(string S)
            {
                //Check Segment Exists
                if (SegmentExists(S))
                {
                    //Return Segment
                    return Segments[GetSegmentIndex(S)];
                }

                return null;
            }

            /// <summary>
            /// Adds Segment to the Response if it doesn't arelady exist.
            /// </summary>
            /// <param name="S">Segment Object</param>
            public void AddSegment(Segment S)
            {
                //Check Segment Does Not Exist
                if (SegmentExists(S.Name) == false)
                {
                    //Add Segment
                    Segments.Add(S);
                }
            }

            /// <summary>
            /// Deletes Segment from the Response if it exists.
            /// </summary>
            /// <param name="S">Segment Name</param>
            public void DeleteSegment(string S)
            {
                //Check Segment Exists
                if (SegmentExists(S))
                {
                    //Delete Segment
                    Segments.RemoveAt(GetSegmentIndex(S));
                }
            }

            /// <summary>
            /// Updates Segment in the Response if it exists, Otherwise Adds it.
            /// </summary>
            /// <param name="S">Segment Object</param>
            public void UpdateSegment(Segment S)
            {
                DeleteSegment(S.Name);
                AddSegment(S);
            }

            /// <summary>
            /// Adds a Line to the Target Segment if it exists.
            /// </summary>
            /// <param name="S">Target Segement Name</param>
            /// <param name="L">Line You're Adding</param>
            /// <returns>True if line was added</returns>
            public void AddLine(string S, Segment.Line L)
            {
                if (SegmentExists(S))
                {
                    Segments[GetSegmentIndex(S)].AddLine(L);
                }
            }

            /// <summary>
            /// Deletes a Line to the Target Segment if it exists.
            /// </summary>
            /// <param name="S">Target Segement Name</param>
            /// <param name="L">Line You're Adding</param>
            public void DeleteLine(string S, Segment.Line L)
            {
                if (SegmentExists(S))
                {
                    Segments[GetSegmentIndex(S)].DeleteLine(L);
                }
            }

            /// <summary>
            /// Updates a Line in the Target Segment, Otherwise Adds it.
            /// </summary>
            /// <param name="S">Segment Name</param>
            /// <param name="L">Line Object</param>
            public void UpdateLine(string S, Segment.Line L)
            {
                DeleteLine(S, L);
                AddLine(S, L);
            }

            public Segment.Line GetNewLine()
            {
                return new Segment.Line();
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
            /// Delete A Response To the Collection of Responses.
            /// </summary>
            /// <param name="R">The Response you want to Delete.</param>            
            public void Delete(Response R)
            {
                //Check If Response Is In the Dictionary
                if (Storage.ContainsKey(R.Name))
                {
                    //Add New Response
                    Storage.Remove(R.Name);
                }
            }

            /// <summary>
            /// Delete A Response To the Collection of Responses.
            /// </summary>
            /// <param name="R">The Response you want to Delete.</param>            
            public void Delete(string R)
            {
                //Check If Response Is In the Dictionary
                if (Storage.ContainsKey(R))
                {
                    //Add New Response
                    Storage.Remove(R);
                }
            }

            /// <summary>
            /// Will Update the Target Response if it exists, otherwise it will add the Target Response.
            /// </summary>
            /// <param name="R">The Response Object</param>
            public void Update(Response R)
            {
                //Check If Response Exists
                if (Exists(R.Name))
                {
                    //Delete Old Response
                    Delete(R.Name);
                }

                //Add Updated Response, Do Not Merge
                Add(R, false);
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

            /// <summary>
            /// Erases all the Lines for the currently Loaded Responses.
            /// </summary>
            public void GenUserTemplets()
            {
                var Keys = Storage.Keys.ToList();

                foreach (var Key in Keys)
                {
                    Storage[Key].GenerateUserTemplet();
                }
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
            catch (Exception ex) { }
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
                        if (Responses.Exists(SelectedResposneText()))
                        {
                            FileName = SelectedResposneText();
                            //Create StreamWriter, Get FileStream For Selected Response
                            using (StreamWriter SW = new StreamWriter(GetFileStream(FullFileName(FilePath, FileName))))
                            {
                                //Serialize Object, Write To File.
                                SW.WriteLine(JsonConvert.SerializeObject(Responses.Get(SelectedResposneText())));
                            }
                        }

                        System.Windows.MessageBox.Show("Exported Selected Response To: " + FileName + ".Response");
                    }
                    catch (Exception ex) { }
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
                    catch (Exception ex) { }
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
                    catch (Exception ex) { }
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

        #endregion

        #region Buttons

        #region Top Menu Buttons
        private void btn_LoadFile_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = MainWindow.SelectFile();
            if (FilePath != "" || FilePath != null)
            {
                Deserialize(FilePath);
                U_Responses();
            }
        }

        private void btn_LoadDirectory_Click(object sender, RoutedEventArgs e)
        {
            string Dir = MainWindow.SelectDirectory() + @"\";
            DirectoryInfo directory = new DirectoryInfo(Dir);
            foreach (FileInfo ResponseFile in directory.EnumerateFiles("*.Response", SearchOption.TopDirectoryOnly))
            {
                Deserialize(ResponseFile.FullName);
            }
            U_Responses();
        }

        private void btn_LoadUserFiles_Click(object sender, RoutedEventArgs e)
        {
            Responses.Storage = new Dictionary<string, Response>();

            DirectoryInfo directory = new DirectoryInfo(Paths.ALICE_ResponseUser);
            foreach (FileInfo ResponseFile in directory.EnumerateFiles("*.Response", SearchOption.TopDirectoryOnly))
            {
                Deserialize(ResponseFile.FullName);
            }
            U_Responses();
        }

        private void btn_SaveSelected_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string TargetResponse = ListBox_Responses.SelectedItem.ToString();
                string FilePath = MainWindow.SelectDirectory();
                if (TargetResponse != null && FilePath != null)
                {
                    Serialize(Save.Selected, FilePath, TargetResponse);
                }
            }
            catch (Exception ex) { }
        }

        private void btn_SaveUserFiles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string FilePath = Paths.ALICE_ResponseUser;
                if (FilePath != null) { Serialize(Save.Individual, FilePath); }
            }
            catch (Exception ex) { }
        }

        private void btn_SaveIndividual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string FilePath = MainWindow.SelectDirectory();
                if (FilePath != null) { Serialize(Save.Individual, FilePath); }
            }
            catch (Exception ex) { }
        }

        private void btn_SaveCombine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBox_CombineFileName.Text == null || TextBox_CombineFileName.Text == "")
                {
                    MessageBox.Show("Please Enter a Filename and try again..."); return;
                }
                string FilePath = MainWindow.SelectDirectory();
                if (FilePath != null) { Serialize(Save.Combine, FilePath); }
            }
            catch (Exception ex) { }
        }

        private void btn_CreateUserTemplets_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(Paths.ALICE_Response);
            foreach (FileInfo ResponseFile in directory.EnumerateFiles("*.Response", SearchOption.TopDirectoryOnly))
            {
                Deserialize(ResponseFile.FullName);
            }

            Responses.GenUserTemplets();

            U_Responses();
        }

        //End: Top Menu Buttons
        #endregion

        #region String Buttons
        private void btn_String_New_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get A New Blank Line
                Response.Segment.Line Temp = R_Response.GetNewLine();
                //Set Text
                if (TextBox_Strings.Text != null) { Temp.Text = TextBox_Strings.Text; }
                else { return; }
                //Set Alternate
                if (CheckBox_Alternate.IsChecked == true) { Temp.Alternate = true; }
                else { Temp.Alternate = false; }

                //Add New Line
                R_Segment.AddLine(Temp);

                //Save Update
                R_Response.UpdateSegment(R_Segment);
                Responses.Update(R_Response);

                //Update Listbox
                U_Strings();
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_String_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Record Old Line
                Response.Segment.Line Old = SelectedLine();

                //Record Old Line & Update Information
                Response.Segment.Line New = SelectedLine();
                if (TextBox_Strings.Text != null) { New.Text = TextBox_Strings.Text; }
                else { return; }
                //Set Alternate
                if (CheckBox_Alternate.IsChecked == true) { New.Alternate = true; }
                else { New.Alternate = false; }

                //Replace Old Line With New Line
                R_Segment.ReplaceLine(Old, New);

                //Save Update
                R_Response.UpdateSegment(R_Segment);
                Responses.Update(R_Response);

                //Update Listbox
                U_Strings();
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Strings_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Record Old Line
                Response.Segment.Line Old = SelectedLine();

                //Delete Line
                R_Segment.DeleteLine(Old);

                //Save Update
                R_Response.UpdateSegment(R_Segment);
                Responses.Update(R_Response);

                //Update Listbox
                U_Strings();
            }
            catch (Exception ex)
            {

            }
        }

        //End: String Buttons
        #endregion

        #region Miscellaneous UI Controls
        private void btn_SegmentInfo_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Update Reference Segment's Info
                R_Segment.Info = TextBox_SegmentDescription.Text;
                //Save Reference Segment
                R_Response.UpdateSegment(R_Segment);
                //Save Reference Response
                Responses.Update(R_Response);
            }
            catch (Exception ex)
            {

            }

        }

        private void ListBox_Tokens_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //Copy Token to Text Box
                Response.Segment.Token Temp = SelectedToken();
                TextBox_TokenDescription.Text = Temp.Info;
            }
            catch (Exception ex)
            {

            }
        }

        private void ListBox_Strings_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //Copy Line to Text Box
                Response.Segment.Line Temp = SelectedLine();
                TextBox_Strings.Text = Temp.Text;
                CheckBox_Alternate.IsChecked = Temp.Alternate;
            }
            catch (Exception ex)
            {

            }
        }

        private void ListBox_Segments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //Clear Items
                TextBox_TokenDescription.Text = null;

                //Update Reference Segment
                R_Segment = R_Response.GetSegment(SelectedSegmentText());

                //Update Tokens

                //Update Segment Information
                U_SegmentInfo();

                //Update Tokens
                U_Tokens();

                //Update String Item Source
                U_Strings();
            }
            catch (Exception ex)
            {

            }
        }

        private void ListBox_Responses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //Clear Information
                TextBox_SegmentDescription.Text = null;
                TextBox_TokenDescription.Text = null;
                ListBox_Strings.ItemsSource = null;

                //Update Reference Repsonse
                R_Response = Responses.Get(SelectedResposneText());
                //Update List Of Segments For New Response
                U_Segments();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        //End: Buttons
        #endregion

        #region Support Methods / Functions
        private string SelectedResposneText()
        {
            return ListBox_Responses.SelectedItem.ToString();
        }

        private string SelectedSegmentText()
        {
            var Temp = (Response.Segment)ListBox_Segments.SelectedItem;
            return Temp.Name;
        }

        private string SelectedStringText()
        {
            var Temp = (Response.Segment.Line)ListBox_Strings.SelectedItem;
            return Temp.Text;
        }

        private Response.Segment.Line SelectedLine()
        {
            return (Response.Segment.Line)ListBox_Strings.SelectedItem;
        }

        private Response.Segment.Token SelectedToken()
        {
            return (Response.Segment.Token)ListBox_Tokens.SelectedItem;
        }

        private Response.Segment SelectedSegment()
        {
            return (Response.Segment)ListBox_Segments.SelectedItem;
        }

        private void U_Responses()
        {
            try
            {
                ListBox_Responses.ItemsSource = null;
                ListBox_Responses.ItemsSource = Responses.Storage.Keys;

                //Clear Items
                ListBox_Tokens.ItemsSource = null;
                TextBox_TokenDescription.Text = null;

                ListBox_Segments.ItemsSource = null;
                TextBox_SegmentDescription.Text = null;

                TextBox_Strings.Text = null;
                ListBox_Strings.ItemsSource = null;
            }
            catch (Exception) { }
        }

        private void U_Segments()
        {
            try
            {
                ListBox_Segments.ItemsSource = null;
                ListBox_Segments.ItemsSource = R_Response.Segments;
                ListBox_Segments.DisplayMemberPath = "Name";

                //Clear Token List
                ListBox_Tokens.ItemsSource = null;
                TextBox_TokenDescription.Text = null;

                ListBox_Strings.ItemsSource = null;
            }
            catch (Exception) { }
        }

        private void U_SegmentInfo()
        {
            try
            {
                TextBox_SegmentDescription.Text = SelectedSegment().Info;
            }
            catch (Exception) { }
        }

        private void U_Tokens()
        {
            try
            {
                ListBox_Tokens.ItemsSource = null;
                ListBox_Tokens.ItemsSource = R_Segment.Tokens;
                ListBox_Tokens.DisplayMemberPath = "Name";
            }
            catch (Exception) { }
        }

        private void U_Strings()
        {
            try
            {
                ListBox_Strings.ItemsSource = null;
                ListBox_Strings.ItemsSource = R_Segment.Lines;
                ListBox_Strings.DisplayMemberPath = "Text";
            }
            catch (Exception) { }
        }
        #endregion
    }
}
