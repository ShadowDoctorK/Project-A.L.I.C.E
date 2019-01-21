using ALICE_Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Synthesizer
{
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
                    case ISynthesizer.Answer.Positive:
                        Logger.DebugLine(MethodName, "Skipped Adding Line, Line Already Exists", Logger.Blue);
                        return false;
                    case ISynthesizer.Answer.Negative:
                        Lines.Add(L);
                        return true;
                    case ISynthesizer.Answer.Error:
                        Logger.Error(MethodName, "Error Was Returned During Check. Aborted Adding Line", Logger.Red);
                        return false;
                    default:
                        Logger.Error(MethodName, "Returned Using The Default Swtich", Logger.Red);
                        return false;
                }                
            }

            public bool DeleteLine(Line L)
            {
                string MethodName = "Reponse (Delete Line)";

                int Temp = GetLineIndex(L); switch (Temp)
                {
                    case -1:
                        Logger.Error(MethodName, "Unable To Remove The Line. Index Not Found.", Logger.Red);
                        return false;

                    default:
                        try
                        {
                            Lines.RemoveAt(Temp);
                        }
                        catch (Exception ex)
                        {
                            Logger.Exception(MethodName, "Exception: " + ex);
                            Logger.Exception(MethodName, "We Found The Line But Was Unable To Remove It");
                        }
                        return true;
                }
            }

            public ISynthesizer.Answer LineExists(Line L)
            {
                string MethodName = "Response (Line Exists)";

                try
                {
                    int Temp = Lines.FindIndex(X => X.Text == L.Text && X.Alternate == L.Alternate);
                    if (Temp != -1) return ISynthesizer.Answer.Positive;
                }
                catch (Exception)
                {
                    Logger.Exception(MethodName, "Exception Occured, Returning Defaults And Continuing");
                    return ISynthesizer.Answer.Error;
                }

                return ISynthesizer.Answer.Negative;
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
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "Exception Occured, Returning Default Value And Continuing");   
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
                    Logger.DebugLine(MethodName, "There Wasn't Any Valid Returns Found", Logger.Blue);
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
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "Exception Occured, Returning Default Value And Continuing");
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
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "Exception Occured, Returning Default Value And Continuing");
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
                Logger.Exception(MethodName, "Exception: " + ex);
                Logger.Exception(MethodName, "Exception Occured, Returning Default Value And Continuing");
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
}
