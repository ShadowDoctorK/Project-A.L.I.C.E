﻿#region Binds File Code Generator (Commented Out)
//UserBinds = GetBindsFile(Paths.ShowBinds());
//List<string> List = new List<string>();
//string Temp = "";

//List.Add("#region Generated Binds Code");
//Console.WriteLine("#region Generated Binds Code");

//foreach (XmlNode Node in UserBinds.DocumentElement)
//{
//    Temp = "";

//    List.Add("#region " + Node.Name);
//    Console.WriteLine("#region " + Node.Name);

//    if (Node.HasChildNodes)
//    {
//        int Num1 = Node.ChildNodes.Count;
//        int Count1 = 0;
//        while (Count1 != Num1 && Num1 >= 0)
//        {
//            string ChildName = Node.ChildNodes[Count1].Name;
//            if (ChildName != "Secondary")
//            {
//                if (ChildName == "Primary")
//                {
//                    Temp = "AliceBind." + Node.Name + "." + ChildName + ".Device" +
//                        " = UserBind." + Node.Name + "." + ChildName + ".Device;";
//                    List.Add(Temp);

//                    Console.WriteLine(Temp);

//                    Temp = "AliceBind." + Node.Name + "." + Node.ChildNodes[Count1].Name + ".Key" +
//                        " = UserBind." + Node.Name + "." + Node.ChildNodes[Count1].Name + ".Key;";
//                    List.Add(Temp);

//                    Console.WriteLine(Temp);
//                }

//                else if (ChildName == "Binding")
//                {
//                    Temp = "AliceBind." + Node.Name + "." + ChildName + ".Device" +
//                        " = UserBind." + Node.Name + "." + ChildName + ".Device;";
//                    List.Add(Temp);

//                    Console.WriteLine(Temp);

//                    Temp = "AliceBind." + Node.Name + "." + Node.ChildNodes[Count1].Name + ".Key" +
//                        " = UserBind." + Node.Name + "." + Node.ChildNodes[Count1].Name + ".Key;";
//                    List.Add(Temp);

//                    Console.WriteLine(Temp);
//                }

//                else if (ChildName == "Inverted" || ChildName == "Deadzone" || ChildName == "ToggleOn")
//                {
//                    Temp = "AliceBind." + Node.Name + "." + ChildName + ".Value" +
//                        " = UserBind." + Node.Name + "." + ChildName + ".Value;";
//                    List.Add(Temp);

//                    Console.WriteLine(Temp);
//                }
//                else
//                {
//                    Temp = "AliceBind." + Node.Name + " = UserBind." + Node.Name + ";";
//                    List.Add(Temp);
//                    List.Add(@"//" + ChildName + "(ChildName) Did Not Get Processed");

//                    Console.WriteLine(Temp);
//                    Console.WriteLine(@"//" + ChildName + "(ChildName) Did Not Get Processed");
//                }

//                if (Node.ChildNodes[Count1].HasChildNodes)
//                {
//                    int Count2 = 0;
//                    int Num2 = Node.ChildNodes[Count1].ChildNodes.Count;
//                    while (Count2 != Num2 && Num2 >= 0)
//                    {
//                        string ChildName2 = Node.ChildNodes[Count1].ChildNodes[Count2].Name;
//                        if (ChildName2 == "Modifier")
//                        {
//                            Temp = "AliceBind." + Node.Name + "." + ChildName + "." + ChildName2 + ".Device" +
//                                " = UserBind." + Node.Name + "." + ChildName + "." + ChildName2 + ".Device;";
//                            List.Add(Temp);

//                            Console.WriteLine(Temp);

//                            Temp = "AliceBind." + Node.Name + "." + ChildName + "." + ChildName2 + ".Device" +
//                                " = UserBind." + Node.Name + "." + ChildName + "." + ChildName2 + ".Device;";
//                            List.Add(Temp);

//                            Console.WriteLine(Temp);
//                        }
//                        else
//                        {
//                            List.Add(@"//" + ChildName2 + "(ChildName2) Did Not Get Processed");
//                            Console.WriteLine(@"//" + ChildName2 + "(ChildName2) Did Not Get Processed");
//                        }
//                        Count2++;
//                    }
//                }
//                else
//                {
//                    List.Add(@"//" + ChildName + "(ChildName) Does Not Have Any ChildNodes");
//                    Console.WriteLine(@"//" + ChildName + "(ChildName) Does Not Have Any ChildNodes");
//                }
//            }
//            Count1++;
//        }
//    }
//    else
//    {
//        Temp = "AliceBind." + Node.Name + ".Value = UserBind." + Node.Name + ".Value;";
//        List.Add(Temp);
//        Console.WriteLine(Temp);
//    }

//    List.Add("#endregion");
//    List.Add(" ");
//    Console.WriteLine("#endregion");
//}

//List.Add(@"//End Region: Generated Binds Code");
//List.Add("#endregion");
//List.Add(" ");
//Console.WriteLine("#endregion");

//TextWriter tw = new StreamWriter(Paths.ALICE_Resources + "SavedList.txt");

//foreach (String s in List)
//    tw.WriteLine(s);

//tw.Close();
#endregion

#region Old Monitor Code
//public Settings_Orders LoadValues(string FilePath = null)
//{
//    Settings_Orders Temp = new Settings_Orders();
//    if (FilePath == null) { FilePath = Paths.ALICE_Settings; }

//    FileStream FS = null;
//    try
//    {
//        if (File.Exists(FilePath + SettingsFile))
//        {
//            FS = new FileStream(FilePath + SettingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
//            using (StreamReader SR = new StreamReader(FS))
//            {
//                while (!SR.EndOfStream)
//                {
//                    string Line = SR.ReadLine();
//                    Temp = JsonConvert.DeserializeObject<Settings_Orders>(Line);
//                }
//            }
//        }

//        return Temp;
//    }
//    catch (Exception)
//    {
//        return Temp;
//    }
//    finally
//    {
//        if (FS != null)
//        { FS.Dispose(); }
//    }
//}

//public void SaveValues(string FilePath = null)
//{
//    if (FilePath == null) { FilePath = Paths.ALICE_Settings; }

//    using (FileStream FS = new FileStream(FilePath + SettingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
//    {
//        using (StreamWriter file = new StreamWriter(FS))
//        {
//            var Line = JsonConvert.SerializeObject(Settings);
//            file.WriteLine(Line);
//        }
//    }
//}

//public class OrderSettings
//{
//    public bool WeaponSafety { get; set; }
//    public bool CombatPower { get; set; }
//    public bool AssistSystemScan { get; set; }
//    public bool AssistDocking { get; set; }
//    public bool AssistRefuel { get; set; }
//    public bool AssistRearm { get; set; }
//    public bool AssistRepair { get; set; }
//    public bool AssistHangerEntry { get; set; }
//    public bool PostHyperspaceSafety { get; set; }

//    public OrderSettings()
//    {
//        CombatPower = true;
//        AssistSystemScan = false;
//        AssistDocking = false;
//        AssistRefuel = false;
//        AssistRearm = false;
//        AssistRepair = false;
//        AssistHangerEntry = false;
//        PostHyperspaceSafety = true;
//        WeaponSafety = true;
//    }
//}
//}

//public class Reports : Base
//{
//    public ReportSettings Settings { get; set; }
//    public ReportSettings Reference { get; set; }
//    public ReportSettings Toolkit { get; set; }
//    public List<string> Updates = new List<string>();

//    public Reports()
//    {
//        Enabled = false;
//        LockFlag = new object();
//        MethodName = "Report Monitor";
//        SettingsFile = "Report.Settings";
//        Log = true;
//        UpdateNumber = 0;
//        TimeStamp = "None";
//        Settings = LoadValues();
//        Reference = LoadValues();
//        Toolkit = LoadValues();
//        CheckSettingsFile();
//    }

//    /// <summary>
//    /// Checks that the settings file exist. If not will populate the file.
//    /// </summary>
//    public void CheckSettingsFile()
//    {
//        if (!File.Exists(Paths.ALICE_Settings + SettingsFile))
//        {
//            SaveValues();
//        }
//    }

//    public void StartMonitor()
//    {
//        Thread thread =
//        new Thread((ThreadStart)(() =>
//        {
//            try
//            {
//                if (Monitor.TryEnter(LockFlag))
//                {
//                    while (Enabled)
//                    {
//                        Thread.Sleep(1000);

//                        if (CheckSettings(SettingsFile))
//                        {
//                            Toolkit = LoadValues();
//                            WatchToolkit();
//                            Settings = LoadValues();
//                            Reference = LoadValues();
//                        }

//                        WatchInternal();
//                    }

//                    Logger.Log(MethodName, "Stopped Watching...", Logger.Yellow);
//                }
//            }
//            catch (Exception ex)
//            {
//                Logger.Exception(MethodName, "Exception " + ex);
//                Logger.Exception(MethodName, "Something Went Wrong With The Montor. Its Not Working Right Now, But Shouldn't Impact Your Experience...");
//            }
//            finally
//            {
//                Monitor.Exit(LockFlag);
//            }
//        }))
//        { IsBackground = true }; thread.Start();
//    }

//    public void WatchInternal()
//    {
//        if (Reference.FuelScoop != Settings.FuelScoop)
//        {
//            Reference.FuelScoop = Settings.FuelScoop;
//            Updates.Add(MethodName + ": Fuel Scoop = " + Reference.FuelScoop);
//        }
//        if (Reference.FuelStatus != Settings.FuelStatus)
//        {
//            Reference.FuelStatus = Settings.FuelStatus;
//            Updates.Add(MethodName + ": Fuel Status = " + Reference.FuelStatus);
//        }
//        if (Reference.MaterialCollected != Settings.MaterialCollected)
//        {
//            Reference.MaterialCollected = Settings.MaterialCollected;
//            Updates.Add(MethodName + ": Material Collected = " + Reference.MaterialCollected);
//        }
//        if (Reference.MaterialRefined != Settings.MaterialRefined)
//        {
//            Reference.MaterialRefined = Settings.MaterialRefined;
//            Updates.Add(MethodName + ": Material Refined = " + Reference.MaterialRefined);
//        }
//        if (Reference.NoFireZone != Settings.NoFireZone)
//        {
//            Reference.NoFireZone = Settings.NoFireZone;
//            Updates.Add(MethodName + ": No Fire Zone = " + Reference.NoFireZone);
//        }
//        if (Reference.StationStatus != Settings.StationStatus)
//        {
//            Reference.StationStatus = Settings.StationStatus;
//            Updates.Add(MethodName + ": Station Status = " + Reference.StationStatus);
//        }
//        if (Reference.ShieldState != Settings.ShieldState)
//        {
//            Reference.ShieldState = Settings.ShieldState;
//            Updates.Add(MethodName + ": Shield State = " + Reference.ShieldState);
//        }
//        if (Reference.CollectedBounty != Settings.CollectedBounty)
//        {
//            Reference.CollectedBounty = Settings.CollectedBounty;
//            Updates.Add(MethodName + ": Collected Bounty = " + Reference.CollectedBounty);
//        }
//        if (Reference.TargetEnemy != Settings.TargetEnemy)
//        {
//            Reference.TargetEnemy = Settings.TargetEnemy;
//            Updates.Add(MethodName + ": Hostile Faction = " + Reference.TargetEnemy);
//        }
//        if (Reference.TargetWanted != Settings.TargetWanted)
//        {
//            Reference.TargetWanted = Settings.TargetWanted;
//            Updates.Add(MethodName + ": Wanted Target = " + Reference.TargetWanted);
//        }
//        if (Reference.Masslock != Settings.Masslock)
//        {
//            Reference.Masslock = Settings.Masslock;
//            Updates.Add(MethodName + ": Masslock = " + Reference.Masslock);
//        }

//        #region Write Updates
//        if (Updates.Count > 0)
//        {
//            if (Log && ICheck.Initialized(MethodName))
//            {
//                foreach (string Line in Updates)
//                {
//                    Logger.Simple(Line, Logger.Green);
//                }
//            }
//            UpdateNumber++;
//            Updates = new List<string>();
//        }
//        #endregion
//    }

//    public void WatchToolkit()
//    {
//        if (Settings.FuelScoop != Toolkit.FuelScoop)
//        {
//            Updates.Add(MethodName + " (Toolkit Update): Fuel Scoop = " + Toolkit.FuelScoop);
//            Call.Report.FuelScoop(Toolkit.FuelScoop);
//        }
//        if (Settings.FuelStatus != Toolkit.FuelStatus)
//        {
//            Updates.Add(MethodName + " (Toolkit Update): Fuel Status = " + Toolkit.FuelStatus);
//            Call.Report.FuelStatus(Toolkit.FuelStatus);
//        }
//        if (Settings.MaterialCollected != Toolkit.MaterialCollected)
//        {
//            Updates.Add(MethodName + " (Toolkit Update): Collected Materials = " + Toolkit.MaterialCollected);
//            Call.Report.MaterialCollected(Toolkit.MaterialCollected);
//        }
//        if (Settings.MaterialRefined != Toolkit.MaterialRefined)
//        {
//            Updates.Add(MethodName + " (Toolkit Update): Refined Materials = " + Toolkit.MaterialRefined);
//            Call.Report.MaterialRefined(Toolkit.MaterialRefined);
//        }
//        if (Settings.NoFireZone != Toolkit.NoFireZone)
//        {
//            Updates.Add(MethodName + " (Toolkit Update): No Fire Zone = " + Toolkit.NoFireZone);
//            Call.Report.NoFireZone(Toolkit.NoFireZone);
//        }
//        if (Settings.StationStatus != Toolkit.StationStatus)
//        {
//            Updates.Add(MethodName + " (Toolkit Update): Station Status = " + Toolkit.StationStatus);
//            Call.Report.StationStatus(Toolkit.StationStatus);
//        }
//        if (Settings.ShieldState != Toolkit.ShieldState)
//        {
//            Updates.Add(MethodName + " (Toolkit Update): Shield State = " + Toolkit.ShieldState);
//            Call.Report.ShieldState(Toolkit.ShieldState);
//        }
//        if (Settings.CollectedBounty != Toolkit.CollectedBounty)
//        {
//            Updates.Add(MethodName + " (Toolkit Update): Collected Bounties = " + Toolkit.CollectedBounty);
//            Call.Report.CollectedBounty(Toolkit.CollectedBounty);
//        }
//        if (Settings.TargetEnemy != Toolkit.TargetEnemy)
//        {
//            Updates.Add(MethodName + " (Toolkit Update): Enemy Factions = " + Toolkit.TargetEnemy);
//            Call.Report.TargetEnemy(Toolkit.TargetEnemy);
//        }
//        if (Settings.TargetWanted != Toolkit.TargetWanted)
//        {
//            Updates.Add(MethodName + " (Toolkit Update): Wanted Targets = " + Toolkit.TargetWanted);
//            Call.Report.TargetWanted(Toolkit.TargetWanted);
//        }
//        if (Settings.Masslock != Toolkit.Masslock)
//        {
//            Updates.Add(MethodName + " (Toolkit Update): Masslock = " + Toolkit.Masslock);
//            Call.Report.Masslock(Toolkit.Masslock);
//        }

//        #region Write Updates
//        if (Updates.Count > 0)
//        {
//            if (Log && ICheck.Initialized(MethodName))
//            {
//                foreach (string Line in Updates)
//                {
//                    Logger.Simple(Line, Logger.Green);
//                }
//            }
//            UpdateNumber++;
//            Updates = new List<string>();
//        }
//        #endregion
//    }

//    public ReportSettings LoadValues(string FilePath = null)
//    {
//        ReportSettings Temp = new ReportSettings();
//        if (FilePath == null) { FilePath = Paths.ALICE_Settings; }

//        FileStream FS = null;
//        try
//        {
//            if (File.Exists(FilePath + SettingsFile))
//            {
//                FS = new FileStream(FilePath + SettingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
//                using (StreamReader SR = new StreamReader(FS))
//                {
//                    while (!SR.EndOfStream)
//                    {
//                        string Line = SR.ReadLine();
//                        Temp = JsonConvert.DeserializeObject<ReportSettings>(Line);
//                    }
//                }
//            }

//            return Temp;
//        }
//        catch (Exception)
//        {
//            return Temp;
//        }
//        finally
//        {
//            if (FS != null)
//            { FS.Dispose(); }
//        }
//    }

//    public void SaveValues(string FilePath = null)
//    {
//        if (FilePath == null) { FilePath = Paths.ALICE_Settings; }

//        using (FileStream FS = new FileStream(FilePath + SettingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
//        {
//            using (StreamWriter file = new StreamWriter(FS))
//            {
//                var Line = JsonConvert.SerializeObject(Settings);
//                file.WriteLine(Line);
//            }
//        }
//    }

//    //public class ReportSettings
//    //{
//    //    public bool FuelScoop { get; set; }
//    //    public bool FuelStatus { get; set; }
//    //    public bool MaterialCollected { get; set; }
//    //    public bool MaterialRefined { get; set; }
//    //    public bool NoFireZone { get; set; }
//    //    public bool StationStatus { get; set; }
//    //    public bool ShieldState { get; set; }
//    //    public bool CollectedBounty { get; set; }
//    //    public bool TargetEnemy { get; set; }
//    //    public bool TargetWanted { get; set; }
//    //    public bool Masslock { get; set; }

//    //    public ReportSettings()
//    //    {
//    //        FuelScoop = true;
//    //        FuelStatus = true;
//    //        MaterialCollected = true;
//    //        MaterialRefined = true;
//    //        NoFireZone = true;
//    //        StationStatus = true;
//    //        ShieldState = true;
//    //        CollectedBounty = true;
//    //        TargetEnemy = true;
//    //        TargetWanted = true;
//    //        Masslock = true;
//    //    }
//    //}
//}
#endregion


#region Old Object Base
//public void SaveValues<T>(object Settings, string FileName, string FilePath = null)
//{
//    if (FilePath == null) { FilePath = Paths.ALICE_Settings; }

//    using (FileStream FS = new FileStream(FilePath + FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
//    {
//        using (StreamWriter file = new StreamWriter(FS))
//        {
//            var Line = JsonConvert.SerializeObject((T)Settings);
//            file.WriteLine(Line);
//        }
//    }
//}

//public object LoadValues<T>(string FileName, string FilePath = null)
//{
//    T Temp = default(T);
//    if (FilePath == null) { FilePath = Paths.ALICE_Settings; }
//    if (FileName == null) { return null; }

//    FileStream FS = null;
//    try
//    {
//        if (File.Exists(FilePath + FileName))
//        {
//            FS = new FileStream(FilePath + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
//            using (StreamReader SR = new StreamReader(FS))
//            {
//                while (!SR.EndOfStream)
//                {
//                    string Line = SR.ReadLine();
//                    Temp = JsonConvert.DeserializeObject<T>(Line);
//                }
//            }
//        }

//        return Temp;
//    }
//    catch (Exception)
//    {
//        return Temp;
//    }
//    finally
//    {
//        if (FS != null)
//        { FS.Dispose(); }
//    }
//}
#endregion

public class Extraction
{
    //public void Command(string Text)
    //{
    //    //Example String with position map for easy reference.
    //    //012345678911111111112222222222333333333344444444445555555555666666666677777777778888888888999999999911111111111111111111
    //    //..........01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678900000000000000000000
    //    //....................................................................................................01234567890123456789
    //    //Shield Cell One [Group;Fire Group;] [Alpha;Bravo;Charlie;Delta;Echo;Foxtrot;Golf;Hotel] [Primary;Secondary] Fire

    //    //Remove Trailing/Leading Whitespace Characters
    //    Text = Text.Trim();

    //    //Record End Index
    //    int EndIndex = Text.Length -1;

    //    //Validate Formatting
    //    if (Text.Contains("[") || Text.Contains("]"))
    //    {            

    //        int LeftBracket = Text.Length - Text.Replace("[", "").Length;
    //        int RightBracket = Text.Length - Text.Replace("]", "").Length;

    //        //Check Correct Number Opening & Closing Brackets
    //        if (LeftBracket != RightBracket)
    //        {
    //            //Warn User Formatting Is Incorrect, Do Not Allow Saving Command.
    //            return;
    //        }

    //        //Check Brackets Are In The Correct Open => Close Positions
    //        int Cursor = 0; int Count = LeftBracket; while (Count > 0)
    //        {
    //            int Open = Text.IndexOf("[", Cursor);
    //            int Close = Text.IndexOf("]", Cursor);

    //            //Check Brackets Are In Correct Positions "[" => "]"
    //            if (Open > Close)
    //            {
    //                //Warn User Formatting Is Incorrect, Do Not Allow Saving Command.
    //                return;
    //            }

    //            //Prepare Cursor Index For Next Check.
    //            Cursor = Close + 1;

    //            //Reduce Brackets Count.
    //            Count--;
    //        }
    //    }

    //    //Break Down String Into Parts
    //    string[,] Constructor = new string[50, 50]; // 50 x 50 Array To Store/Build With.
    //    int ConstructorColumn = 0;
    //    int Index = 0;

    //    //Process Text While Not At End
    //    while (Index < EndIndex)
    //    {
    //        //Resets Text Each Itteration
    //        string Normal = "";            
    //        string Bracket = "";

    //        //Validate Bracket Index & Process Bracket Text
    //        if (Text.IndexOf("[", Index) != -1 && Text.IndexOf("]", Index) != -1)
    //        {
    //            int Open = Text.IndexOf("[", Index);
    //            int Close = Text.IndexOf("[", Index);

    //            //Grab Text Between Index & Open Bracket
    //            Normal = Text.Substring(Index, Open - Index);

    //            //Grab Bracket Text
    //            Bracket = Text.Substring(Open, Close - Open);

    //            //Validate Normal Text
    //            if (string.IsNullOrWhiteSpace(Normal) == false)
    //            {
    //                //Add Normal Text To Constructor Array
    //                Constructor[ConstructorColumn, 0] = Normal.Trim();

    //                //Increase Array Column
    //                ConstructorColumn++;
    //            }

    //            //Validate Bracket Text & Split
    //            if (string.IsNullOrWhiteSpace(Bracket) == false)
    //            {
    //                //Split Bracket Text
    //                string[] Temp = Bracket.Split(';');
                    
    //                //Add Items To Constructor Array
    //                int Row = 0; foreach (var Item in Temp)
    //                {                        
    //                    Constructor[ConstructorColumn, Row] = Item.Trim();
    //                    Row++;
    //                }

    //                //Increase Array Column
    //                ConstructorColumn++;
    //            }

    //            //Update Index Position
    //            Index = Close + 1;
    //        }
    //        //Only Normal Text Remains
    //        else
    //        {
    //            //Process Remaining Normal Text
    //            if (Index < EndIndex)
    //            {                                        
    //                if (EndIndex - Index > 0)
    //                {
    //                    //Grab Normal Text
    //                    Normal = Text.Substring(Index, EndIndex - Index);

    //                    //Add Text To Constructor
    //                    Constructor[ConstructorColumn, 0] = Normal.Trim();

    //                }                    
    //                else
    //                {
    //                    //End Processing Text
    //                    Index = EndIndex;
    //                }
    //            }
    //            else
    //            {
    //                //End Processing Text
    //                Index = EndIndex;
    //            }
    //        }
    //    }

    //    //Build All Variations

    //}
}


//#region Journal Events (Remaining Events For Conversion)

//#region Event Constructors
//public class Catch
//{
//    [JsonExtensionData]
//    public IDictionary<string, object> Undefined { get; set; }

//    public IDictionary<string, object> UndefinedProperties()
//    {
//        return Undefined;
//    }
//}

//public class Base : Catch
//{
//    public DateTime Timestamp { get; set; }
//    public string Event { get; set; }
//}

//public class UndefinedEvent : Base
//{
//    //Use this when you want to log the entire event.
//}
//#endregion

//#region CommunityGoalJoin Event
//public class CommunityGoalJoin : Base
//{
//    public string Name { get; set; }
//    public string System { get; set; }
//}
//#endregion

//#region CommunityGoalReward Event
//public class CommunityGoalReward : Base
//{
//    public decimal CGID { get; set; }
//    public string Name { get; set; }
//    public string System { get; set; }
//    public decimal Reward { get; set; }
//}
//#endregion

//#region CrewMemberJoins Event
//public class CrewMemberJoins : Base
//{
//    public string Crew { get; set; }
//}
//#endregion

//#region CrewMemberRoleChange Event
//public class CrewMemberRoleChange : Base
//{
//    public string Crew { get; set; }
//    public string Role { get; set; }
//}
//#endregion

//#region EngineerApply Event
//public class EngineerApply : Base
//{
//    public string Engineer { get; set; }
//    public string Blueprint { get; set; }
//    public decimal Level { get; set; }
//}
//#endregion

//#region Interdiction Event
//public class Interdiction : Base
//{
//    public string Success { get; set; }
//    public bool IsPlayer { get; set; }
//    public string Faction { get; set; }
//}
//#endregion

//#region JoinACrew Event
//public class JoinACrew : Base
//{
//    public string Captain { get; set; }
//}
//#endregion

//#region MaterialDiscarded Event
//public class MaterialDiscarded : Base
//{
//    public string Category { get; set; }
//    public string Name { get; set; }
//    public decimal Count { get; set; }
//}
//#endregion

//#region PayLegacyFines Event
//public class PayLegacyFines : Base
//{
//    public decimal Amount { get; set; }
//}
//#endregion

//#region ShipyardSell Event
//public class ShipyardSell : Base
//{
//    public string ShipType { get; set; }
//    public string ShipType_Localised { get; set; }
//    public decimal SellShipID { get; set; }
//    public decimal ShipPrice { get; set; }
//    public decimal MarketID { get; set; }
//    public string System { get; set; }
//    public decimal ShipMarketID { get; set; }
//}
//#endregion

//#endregion