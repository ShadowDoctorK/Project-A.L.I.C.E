using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using ALICE_Debug;
using ALICE_Internal;

namespace ALICE_Interface
{
    public static class IPlatform
    {
        static readonly string M = "Platform Interface";
        public static readonly string Version = "v3.4.0.3";
        public static string VersionLong { get => IPlatform.Version + " (Open Beta 1.3.4)"; }

        public enum Interfaces { Internal, VoiceAttack, VoiceMacro }
        public static Interfaces Interface = Interfaces.Internal;

        /// <summary>
        /// Enum containing all possible External profile variables used in function calls.
        /// </summary>
        public enum IVar
        {
            //Formatting:
            //Variable Name     Conversion: Description

            //Platform Startup And Configuraton
            DebugMode,          //Bool:
            ExtendedLogging,    //Bool:
            StatusLogging,      //Bool:
            VariableLogging,    //Bool:
            KeybindLogging,     //Bool:

            //Miscellaneous Variables:
            CommandAudio,       //Bool: Command Audio (All Commands)
            ColdMod,            //Bool: Cold Modifer (Shield Cells)
            FighterNumber,      //Deci: Fighter Number (Deploy Command)
            TargetCycle,        //Deci: Target Cycle (Targeting Commands)
            BoostNum,           //Deci: Boost Number (Throttle Command)
            BookmarkNum,        //Deci: Bookmart Number (System And Galaxy Map Commands)

            //Fire Group Management Variables:
            FireGroup,          //Deci:
            FireMode,           //Str:
            FireGroupSelect,    //Deci: 
            FireGroupNum,       //Deci:

            //Power Management Variables:
            EnginePower,        //Deci: Engines Power
            WeaponPower,        //Deci: Weapons Power
            SystemPower,        //Deci: Systems Power
            RecordPower,        //Bool: Record Power

            //Location Filter Variables:
            NavStars,           //Bool: Stars
            NavAsteroids,       //Bool: Asteroid Clusters
            NavPlanets,         //Bool: Planets And Moons
            NavLandfalls,       //Bool: Landfall Planets And Moons
            NavSettlements,     //Bool: Settlements
            NavStations,        //Bool: Stations
            NavPoints,          //Bool: Points Of Interest
            NavSignals,         //Bool: Signal Sources
            NavSystems          //Bool: Systems
        }

        public static dynamic ProxyObject; //This is the object thats allows interfacing with Voice Attack.

        /// <summary>
        /// Readonly String To Color Association Dictionary.
        /// </summary>
        public static readonly Dictionary<string, Color> Colors = new Dictionary<string, Color>
        {
            { "Red", Color.Red },                       { "Orange", Color.Orange },
            { "Yellow", Color.Yellow },                 { "Green", Color.Green },
            { "Blue", Color.Blue },                     { "Indigo", Color.Indigo },
            { "Violet", Color.Violet },                 { "Black", Color.Black },
            { "Brown", Color.Brown },                   { "Cyan", Color.Cyan },
            { "HotPink", Color.HotPink },               { "Purple", Color.Purple },
            { "Silver", Color.Silver },                 { "YellowGreen", Color.YellowGreen },
            { "RoyalBlue", Color.RoyalBlue },           { "White", Color.White }
        };

        /// <summary>
        /// Readonly String To Console Color Association Dictionary.
        /// </summary>
        private static readonly Dictionary<string, ConsoleColor> ConsoleColors = new Dictionary<string, ConsoleColor>
        {
            { "Red", ConsoleColor.Red },                { "Orange", ConsoleColor.DarkRed },
            { "Yellow", ConsoleColor.Yellow },          { "Green", ConsoleColor.Green },
            { "Blue", ConsoleColor.Blue },              { "Purple", ConsoleColor.Magenta },
            { "Black", ConsoleColor.Black },            { "Cyan", ConsoleColor.Cyan },
            { "DarkYellow", ConsoleColor.DarkYellow },  { "White", ConsoleColor.White },
            { "None", ConsoleColor.White }
        };

        /// <summary>
        /// Function To Execute A Command In The Target Profile.
        /// </summary>
        /// <param name="C">(Command) The Command You Want To Activate.</param>
        /// <param name="E">(Exist) Check If The Command Exists Before Execution.</param>
        public static void ExecuteCommand(string C, bool E = true)
        {
            string M = IPlatform.M + " (Execute Command)";

            try
            {
                if (E) { if (CommandExists(C) == false) { return; } }

                switch (Interface)
                {
                    case Interfaces.Internal:
                        Logger.Log(M, "(" + Interface.ToString() + "): Simulated Executing " + C, Logger.Yellow);
                        break;

                    case Interfaces.VoiceAttack:
                        ProxyObject.ExecuteCommand(C);
                        break;

                    case Interfaces.VoiceMacro:
                        IVoiceMacro.CommandExecute(C, true);
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex) { Logger.Exception(M, "Execption: " + ex); }
        }

        /// <summary>
        /// Function To Check A Command Exists In The Target Profile.
        /// </summary>
        /// <param name="C">(Command) Command Name As String</param>
        /// <returns>True If Command Exists</returns>
        public static bool CommandExists(string C)
        {
            string M = IPlatform.M + " (Command Exists)";

            bool Answer = false;

            try
            {
                switch (Interface)
                {
                    case Interfaces.Internal:
                        Logger.Log(M, "(" + Interface.ToString() + "): Simulated Check For " + C, Logger.Yellow);
                        Answer = true;
                        break;

                    case Interfaces.VoiceAttack:
                        Answer = ProxyObject.CommandExists(C);
                        break;

                    case Interfaces.VoiceMacro:
                        Answer = IVoiceMacro.CommandExists(C, true);
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(M, "Command Exist Exception " + ex);
            }

            if (Answer == false)
            {
                //Debug Logger
                Logger.DebugLine(M, "(" + Interface.ToString() + ") Command Does Not Exist - " + C, Logger.Red);
            }

            return Answer;
        }

        /// <summary>
        /// (Enum) Function Used To Get Variable Values From The Starting Platform.
        /// </summary>
        /// <param name="Var">(Variable) The Target Variable By Enum.</param>
        /// <param name="A">(Answer) The Fallback Value You Want Returned If Value Was Not
        /// Able To Be Retrieved. Null By Default.</param>
        /// <returns></returns>
        public static string GetText(IVar Var, string A = null)
        {
            string M = "Get Variable (Enums)";

            switch (Interface)
            {
                case Interfaces.Internal:
                    //No Actions
                    break;

                case Interfaces.VoiceAttack:
                    A = ProxyObject.GetText("ALICE_" + Var.ToString());
                    break;

                case Interfaces.VoiceMacro:
                    A = IVoiceMacro.GetText("ALICE_" + Var.ToString());
                    break;

                default:
                    break;
            }
            
            if (A == null)
            {
                Logger.DebugLine(M, Var.ToString() + " Was Not Set Or Was Null", Logger.Red);
            }

            return A;
        }

        /// <summary>
        /// (Enum) Fucntion Used To Set Variable Values In The Starting Platform.
        /// </summary>
        /// <param name="Var">(Variable) The Target Variable By Enum.</param>
        /// <param name="Val">(Value) The Value Being Set.</param>
        /// <param name="P">(Prefix) "ALICE_", True = Add Prefix, False = No Prefix.</param>
        public static void SetText(IVar Var, string Val, bool P = true)
        {
            string M = "Set Variable (Enums)";
            string Prefix = ""; if (P) { Prefix = "ALICE_"; }

            switch (Interface)
            {
                case Interfaces.Internal:
                    Logger.Log(M, "(" + Interface.ToString() + ") Text Variable: " + Var.ToString() + " = " + Val, Logger.Yellow);
                    break;

                case Interfaces.VoiceAttack:
                    Logger.DebugLine(M, Prefix + Var.ToString() + " = " + Val, Logger.Yellow);
                    ProxyObject.SetText(Prefix + Var.ToString(), Val);
                    break;

                case Interfaces.VoiceMacro:
                    Logger.DebugLine(M, Prefix + Var.ToString() + " = " + Val, Logger.Yellow);
                    IVoiceMacro.SetText(Prefix + Var.ToString(), Val);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// (String) Fucntion Used To Set Variable Values In The Starting Platform.
        /// </summary>
        /// <param name="Var">(Variable) The Target Variable By String.</param>
        /// <param name="Val">(Value) The Value Being Set.</param>
        /// <param name="P">(Prefix) "ALICE_", True = Add Prefix, False = No Prefix.</param>
        /// <param name="L">(Log) Enable Or Disable Logging In This Function.</param>
        public static void SetText(string Var, string Val, bool P = true, bool L = true)
        {
            string MethodName = "Set Variable (String)";
            string Prefix = ""; if (P) { Prefix = "ALICE_"; }

            switch (Interface)
            {
                case Interfaces.Internal:
                    Logger.Log(MethodName, "(" + Interface + ") Text Variable: " + Prefix + Var + " = " + Val, Logger.Yellow);
                    break;

                case Interfaces.VoiceAttack:
                    
                    if (L)
                    {
                        //Logger.DebugLine(MethodName, Prefix + Var + " = " + Val, Logger.Yellow);
                    }
                    ProxyObject.SetText(Prefix + Var.ToString(), Val);
                    break;

                case Interfaces.VoiceMacro:
                    if (L)
                    {
                        //Logger.DebugLine(MethodName, Prefix + Var.ToString() + " = " + Val, Logger.Yellow);
                    }
                    IVoiceMacro.SetText(Prefix + Var.ToString(), Val);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Function To Write Log Text To The Starting Platforms Log.
        /// </summary>
        /// <param name="LT">(Log Text) The Text Being Written To The Log.</param>
        /// <param name="C">(Color) The Annotation Color.</param>
        /// <param name="S">(Sign) The Annotation Sign. (Voice Macro)</param>
        /// <param name="St">(Status Text) The Plugin Status Text (Voice Macro)</param>
        public static void WriteToInterface(string LT, string C, string S = "ℙ", string ST = "")
        {
            //Sign Validation
            if (S.Length > 1) { S = ""; }

            switch (Interface)
            {
                case Interfaces.Internal:

                    //Internal Interface Is Used To Operate Without A Starting Platform.
                    //Logging Will Be Sent To A Command Terminal For The Running Instance.

                    //Check Console Color
                    if (ConsoleColors.ContainsKey(C))
                    {
                        Console.ForegroundColor = (ConsoleColor)ConsoleColors[C];
                    }

                    //Write Entry
                    Console.WriteLine(LT);

                    //Reset Console Color
                    Console.ForegroundColor = ConsoleColor.White;

                    //Write To Alice Log
                    Logger.AliceLog(LT);

                    return;

                case Interfaces.VoiceAttack:

                    //Write To Alice Log
                    Logger.AliceLog(LT);

                    //Write To Voice Attack Log
                    ProxyObject.WriteToLog(LT, C);

                    return;

                case Interfaces.VoiceMacro:

                    //Write To Alice Log
                    Logger.AliceLog(LT);

                    //Write To Voice Macro Log
                    IVoiceMacro.WriteToLog(LT, C, S, ST);

                    return;

                default:
                    //No Action
                    return;
            }
        }

        /// <summary>
        /// Function Used To Pull Config Variable From The Starting Platform.
        /// </summary>
        public static void Configure()
        {
            string M = IPlatform.M + " (Configure)";

            //Retrieve Config Variables From Platform
            PlugIn.DebugMode = IGet.External.DebugMode(M);
            PlugIn.ExtendedLogging = IGet.External.ExtendedLogging(M);
            PlugIn.VariableLogging = IGet.External.VariableLogging(M);

            //Log Settings
            if (PlugIn.DebugMode)
            {
                Logger.Log(M, "Debug Mode Enabled", Logger.Yellow);
            }

            if (PlugIn.ExtendedLogging)
            {
                Logger.Log(M, "Extended Logging Enabled", Logger.Yellow);
            }

            if (PlugIn.VariableLogging)
            {
                Logger.Log(M, "Event Variable Logging Enabled", Logger.Yellow);
            }            
        }
    }
}