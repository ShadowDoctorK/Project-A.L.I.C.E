using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALICE_Debug_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug();
        }

        public static Extraction Extract = new Extraction();

        public static void Debug()
        {
            //Valid String With Simple Text & Brackets
            string Text1 = "Shield Cell One [Group;Fire Group] [Alpha;Bravo;Charlie;Delta;Echo;Foxtrot;Golf;Hotel] [Primary;Secondary] Fire";

            //Valid String That Creates 3072 Command Activators
            //string Text1 = "Shield Cell One [Group;Fire Group;] [Alpha;Bravo;Charlie;Delta;Echo;Foxtrot;Golf;Hotel] [Alpha;Bravo;Charlie;Delta;Echo;Foxtrot;Golf;Hotel] [Alpha;Bravo;Charlie;Delta;Echo;Foxtrot;Golf;Hotel] [Primary;Secondary] Fire";

            //Valid String To Test Optional Brackets
            //string Text1 = "Alice [Activate;Fire] All [Rockets;Missiles] [Please;]";
                        
            //Valid String With Only Brackets
            string Text2 = "[Group;Fire Group;] [Alpha;Bravo;Charlie;Delta;Echo;Foxtrot;Golf;Hotel] [Primary;Secondary]";
            
            //Invalid String Missing A Brackets (At The End)
            string Text3 = "[Group;Fire Group;] [Alpha;Bravo;Charlie;Delta;Echo;Foxtrot;Golf;Hotel] [Primary;Secondary";
            
            //Invalid String Open / Close Brackets Swapped. (Middle Section)
            string Text4 = "[Group;Fire Group;] ]Alpha;Bravo;Charlie;Delta;Echo;Foxtrot;Golf;Hotel[ [Primary;Secondary]";
            
            //Simple String No Brackets.
            string Text5 = "This Is A Simple String";

            string T = "Text1";
            switch (Extract.Check(Text1))
            {
                case Extraction.A.Brackets:
                    Console.WriteLine(T + " Validated And Has Brackets");
                    break;
                case Extraction.A.NoBrackets:
                    Console.WriteLine(T + " Is A Simple Command");
                    break;
                case Extraction.A.InvalidNumber:
                    Console.WriteLine(T + " Invalid Number Of Brackets");
                    break;
                case Extraction.A.InvalidOpenClose:
                    Console.WriteLine(T + " Invalid Open / Close Brackets Detected");
                    break;
                case Extraction.A.Error:
                    Console.WriteLine(T + " Validation Cause An Error");
                    break;
                default:
                    break;
            }

            T = "Text2";
            switch (Extract.Check(Text2))
            {
                case Extraction.A.Brackets:
                    Console.WriteLine(T + " Validated And Has Brackets");
                    break;
                case Extraction.A.NoBrackets:
                    Console.WriteLine(T + " Is A Simple Command");
                    break;
                case Extraction.A.InvalidNumber:
                    Console.WriteLine(T + " Invalid Number Of Brackets");
                    break;
                case Extraction.A.InvalidOpenClose:
                    Console.WriteLine(T + " Invalid Open / Close Brackets Detected");
                    break;
                case Extraction.A.Error:
                    Console.WriteLine(T + " Validation Cause An Error");
                    break;
                default:
                    break;
            }

            T = "Text3";
            switch (Extract.Check(Text3))
            {
                case Extraction.A.Brackets:
                    Console.WriteLine(T + " Validated And Has Brackets");
                    break;
                case Extraction.A.NoBrackets:
                    Console.WriteLine(T + " Is A Simple Command");
                    break;
                case Extraction.A.InvalidNumber:
                    Console.WriteLine(T + " Invalid Number Of Brackets");
                    break;
                case Extraction.A.InvalidOpenClose:
                    Console.WriteLine(T + " Invalid Open / Close Brackets Detected");
                    break;
                case Extraction.A.Error:
                    Console.WriteLine(T + " Validation Cause An Error");
                    break;
                default:
                    break;
            }

            T = "Text4";
            switch (Extract.Check(Text4))
            {
                case Extraction.A.Brackets:
                    Console.WriteLine(T + " Validated And Has Brackets");
                    break;
                case Extraction.A.NoBrackets:
                    Console.WriteLine(T + " Is A Simple Command");
                    break;
                case Extraction.A.InvalidNumber:
                    Console.WriteLine(T + " Invalid Number Of Brackets");
                    break;
                case Extraction.A.InvalidOpenClose:
                    Console.WriteLine(T + " Invalid Open / Close Brackets Detected");
                    break;
                case Extraction.A.Error:
                    Console.WriteLine(T + " Validation Cause An Error");
                    break;
                default:
                    break;
            }

            T = "Text5";
            switch (Extract.Check(Text5))
            {
                case Extraction.A.Brackets:
                    Console.WriteLine(T + " Validated And Has Brackets");
                    break;
                case Extraction.A.NoBrackets:
                    Console.WriteLine(T + " Is A Simple Command");
                    break;
                case Extraction.A.InvalidNumber:
                    Console.WriteLine(T + " Invalid Number Of Brackets");
                    break;
                case Extraction.A.InvalidOpenClose:
                    Console.WriteLine(T + " Invalid Open / Close Brackets Detected");
                    break;
                case Extraction.A.Error:
                    Console.WriteLine(T + " Validation Cause An Error");
                    break;
                default:
                    break;
            }

            //Process Text1
            T = "Text1";
            switch (Extract.Check(Text1))
            {
                case Extraction.A.Brackets:
                    Console.WriteLine(T + " Validated And Has Brackets");
                    var Temp = Extract.Command(Text1);
                    foreach (var Str in Temp)
                    {
                        Console.WriteLine(Str);
                    }

                    break;
                case Extraction.A.NoBrackets:
                    Console.WriteLine(T + " Is A Simple Command");
                    break;
                case Extraction.A.InvalidNumber:
                    Console.WriteLine(T + " Invalid Number Of Brackets");
                    break;
                case Extraction.A.InvalidOpenClose:
                    Console.WriteLine(T + " Invalid Open / Close Brackets Detected");
                    break;
                case Extraction.A.Error:
                    Console.WriteLine(T + " Validation Cause An Error");
                    break;
                default:
                    break;
            }
        }
    }

    public class Extraction
    {
        /// <summary>
        /// Enum To Provide More Infomration On Validation.
        /// </summary>
        public enum A
        {
            Brackets,           //Returns When Command Contains Brackets & Format Pass' Validation.
            NoBrackets,         //Returns When Command Is A Simple String With No Brackets.
            InvalidNumber,      //Returns When Validation Fails Because The Number Of "[" & "]" Don't Match.
            InvalidOpenClose,   //Returns When Validation Fails Because Not All Brackets Close Properly.
            Error               //Returns When There Is An Error During Validation.
        }

        /// <summary>
        /// Pass Activator To Check If Processing Is Required.
        /// </summary>
        /// <param name="Text">String you want to check.</param>
        /// <returns>Brackets, NoBrackets, InvalidNumber, InvalidOpenClose, Error</returns>
        public A Check(string Text)
        {
            try
            {
                //Validate Formatting
                if (Text.Contains("[") || Text.Contains("]"))
                {
                    int LeftBracket = Text.Length - Text.Replace("[", "").Length;
                    int RightBracket = Text.Length - Text.Replace("]", "").Length;

                    //Check Correct Number Opening & Closing Brackets
                    if (LeftBracket != RightBracket)
                    {
                        //Warn User Formatting Is Incorrect, Do Not Allow Saving Command.
                        return A.InvalidNumber;
                    }

                    //Check Brackets Are In The Correct Open => Close Positions
                    int Cursor = 0; int Count = LeftBracket; while (Count > 0)
                    {
                        int Open = Text.IndexOf("[", Cursor);
                        int Close = Text.IndexOf("]", Cursor);

                        //Check Brackets Are In Correct Positions "[" => "]"
                        if (Open > Close)
                        {
                            //Warn User Formatting Is Incorrect, Do Not Allow Saving Command.
                            return A.InvalidOpenClose;
                        }

                        //Prepare Cursor Index For Next Check.
                        Cursor = Close + 1;

                        //Reduce Brackets Count.
                        Count--;
                    }

                    //Validation Passed
                    return A.Brackets;
                }

                //Does Not Contain Brackets
                return A.NoBrackets;
            }
            catch (Exception ex)
            {
                //Exception Handling...
                return A.Error;
            }           
        }

        /// <summary>
        /// Process' strings with Valid Brackets and creates all possible ways to speak the command activator.
        /// </summary>
        /// <param name="Text">String required to be processed</param>
        /// <returns>Array of Command Activators or Null if Greater than the upper Limit</returns>
        public string[] Command(string Text)
        {
            string[] Commands = { "***BaseConstructorArray***" };    //Working Copy Of The Commands

            //Example String with position map for easy reference.
            //012345678911111111112222222222333333333344444444445555555555666666666677777777778888888888999999999911111111111111111111
            //..........01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678900000000000111111111
            //....................................................................................................01234567890123456789
            //Shield Cell One [Group;Fire Group;] [Alpha;Bravo;Charlie;Delta;Echo;Foxtrot;Golf;Hotel] [Primary;Secondary] Fire
            
            Text = Text.Trim();                         //Remove Trailing/Leading Whitespace Characters
            int EndIndex = Text.Length;                 //Record EndIndex
            string[,] Constructor = new string[50, 50]; //50 x 50 Array To Store/Build Activators With.
            int ConstructorColumn = 0;                  //Used To Track Our Working Column While Saving Items
            int Index = 0;                              //Used To Track Our Working Position For The String

            //Break Down String Into Parts
            try
            {
                //Process Text While Not At End
                while (Index < EndIndex)
                {
                    //Resets Text Each Itteration
                    string Normal = "";
                    string Bracket = "";

                    //Validate Bracket Index & Process Bracket Text
                    if (Text.IndexOf("[", Index) != -1 && Text.IndexOf("]", Index) != -1)
                    {
                        int Open = Text.IndexOf("[", Index);
                        int Close = Text.IndexOf("]", Index);

                        //Grab Text Between Index & Open Bracket
                        Normal = Text.Substring(Index, Open - Index);

                        //Grab Bracket Text
                        //+1 / -1 is to Remove Brackets
                        Bracket = Text.Substring(Open + 1, Close - Open - 1);

                        //Validate Normal Text
                        if (string.IsNullOrWhiteSpace(Normal) == false)
                        {
                            //Add Normal Text To Constructor Array
                            Constructor[ConstructorColumn, 0] = Normal.Trim();

                            //Increase Array Column
                            ConstructorColumn++;
                        }

                        //Validate Bracket Text & Split
                        if (string.IsNullOrWhiteSpace(Bracket) == false)
                        {
                            //Split Bracket Text
                            string[] Temp = Bracket.Split(';');

                            //Add Items To Constructor Array
                            int Row = 0; foreach (var Item in Temp)
                            {
                                Constructor[ConstructorColumn, Row] = Item.Trim();
                                Row++;
                            }

                            //Increase Array Column
                            ConstructorColumn++;
                        }

                        //Update Index Position
                        Index = Close + 1;
                    }
                    //Only Normal Text Remains
                    else
                    {
                        //Process Remaining Normal Text
                        if (Index < EndIndex)
                        {
                            //Validate Substring Indexing
                            if (EndIndex - Index > 0)
                            {
                                //Grab Normal Text
                                Normal = Text.Substring(Index, EndIndex - Index);

                                //Add Text To Constructor
                                Constructor[ConstructorColumn, 0] = Normal.Trim();

                                //End Processing Text
                                Index = EndIndex;
                            }
                            else
                            {
                                //End Processing Text
                                Index = EndIndex;
                            }
                        }
                        else
                        {
                            //End Processing Text
                            Index = EndIndex;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Your Exception Handling Here...

                //Return Null
                return null;
            }            

            //Build All Command Variations
            try
            {
                int ValidColumns = 0;       //Index For The Last Column That Isn't Empty In The Constructor Array

                //Find Total Valid Columns
                while (Constructor[ValidColumns, 0] != null)
                {
                    ValidColumns++;
                }

                //Calculate Total Activators
                List<int> StringCount = new List<int>();
                int Column = 0; while (Column < ValidColumns)
                {
                    //Copy Each String Out Of Working Column
                    int Row = 0; int C = 0; while (Constructor[Column, Row] != null)
                    {
                        //Count Item
                        C++;

                        //Target Next Item
                        Row++;
                    }

                    //Add Count To StringCount
                    StringCount.Add(C);

                    //Target Next Column
                    Column++;
                }

                int Total = 1; foreach (int I in StringCount)
                {
                    Total = Total * I;
                }

                //Report Excessive Activators For Command
                if (Total > 300)
                {
                    //Message Box To User With Your Text

                    //Return Null
                    return null;
                }


                //Process Columns In The Constructor Array
                Column = 0; while (Column < ValidColumns)
                {
                    //Reset Temp List
                    List<string> Temp = new List<string>();

                    //Copy Each String Out Of Working Column
                    int Row = 0; while (Constructor[Column, Row] != null)
                    {
                        //Add To Temp List
                        Temp.Add(Constructor[Column, Row]);

                        //Target Next Item
                        Row++;
                    }

                    //Combine New Working Column With Our Current Commands Array
                    Commands = Construct(Commands, Temp.ToArray());

                    //Target Next Column
                    Column++;
                }
            }
            catch (Exception ex)
            {
                //Your Exception Handling Here...

                //Return Null
                return null;
            }           

            //Return Array Of Activators
            return Commands;
        }

        /// <summary>
        /// Constructs a new array from the two Arrays Passed by combining all variations.
        /// </summary>
        /// <param name="A">Array being added to.</param>
        /// <param name="B">Array your adding on the end.</param>
        /// <returns>New Combines Array.</returns>
        public string[] Construct(string[] A, string[] B)
        {
            List<string> Temp = new List<string>();

            //Check If We Are Processing The First Column Only
            if (A[0] == "***BaseConstructorArray***")
            {
                return B;
            }

            //Build Commands
            foreach (var StrA in A)
            {
                foreach (var StrB in B)
                {
                    string T = StrA + " " + StrB;
                    Temp.Add(T.Trim());
                }
            }

            return Temp.ToArray();
        }
    }
}
