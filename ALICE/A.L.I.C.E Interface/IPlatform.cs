using System;
using System.Collections.Generic;
using System.Drawing;
using ALICE_Internal;

namespace ALICE_Interface
{
    public static class IPlatform
    {
        static readonly string MethodName = "Interface Manager";
        public static readonly string Version = "v3.4.0.2";

        #region Shared Interface Items
        public enum Interfaces { Internal, VoiceAttack, VoiceMacro }
        public static Interfaces Interface = Interfaces.Internal;
        public enum IVar
        {
            CommandAudio,
            ColdMod,
            FighterNumber,
            FireGroup,
            FireMode,
            TargetCycle,
            FireGroupSelect,
            FireGroupNum,
            BoostNum,
            EnginePower,
            WeaponPower,
            SystemPower,
            RecordPower,
            BookmarkNum
        }

        public static dynamic ProxyObject; //This is the object thats allows interfacing with Voice Attack.

        private static readonly Dictionary<string, Color> Colors = new Dictionary<string, Color>
        {
            { "Red", Color.Red }, { "Orange", Color.Orange }, { "Yellow", Color.Yellow }, { "Green", Color.Green }, { "Blue", Color.Blue },
            { "Indigo", Color.Indigo }, { "Violet", Color.Violet }, { "Black", Color.Black }, { "Brown", Color.Brown }, { "Cyan", Color.Cyan },
            { "HotPink", Color.HotPink }, { "Purple", Color.Purple }, { "Silver", Color.Silver }, { "YellowGreen", Color.YellowGreen },
            { "RoyalBlue", Color.RoyalBlue }, { "White", Color.White }
        };

        private static readonly Dictionary<string, ConsoleColor> ConsoleColors = new Dictionary<string, ConsoleColor>
        {
            { "Red", ConsoleColor.Red }, { "Orange", ConsoleColor.DarkRed }, { "Yellow", ConsoleColor.Yellow }, { "Green", ConsoleColor.Green }, { "Blue", ConsoleColor.Blue },
            { "Purple", ConsoleColor.Magenta }, { "Black", ConsoleColor.Black }, { "Cyan", ConsoleColor.Cyan }, { "DarkYellow", ConsoleColor.DarkYellow }, { "White", ConsoleColor.White },
            { "None", ConsoleColor.White }
        };

        public static void ExecuteCommand(string Command, bool CheckExists = true)
        {
            try
            {
                if (CheckExists) { if (CommandExists(Command) == false) { return; } }

                switch (Interface)
                {
                    case Interfaces.Internal:
                        Logger.Log(MethodName, "(" + Interface.ToString() + ") Command Does Not Exist - " + Command, Logger.Yellow);
                        break;

                    case Interfaces.VoiceAttack:
                        ProxyObject.ExecuteCommand(Command);
                        break;

                    case Interfaces.VoiceMacro:
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex) { Logger.Exception(MethodName, "Execute Command Execption: " + ex); }
        }

        public static bool CommandExists(string Command, bool Answer = false)
        {
            try
            {
                switch (Interface)
                {
                    case Interfaces.Internal:
                        Logger.Log(MethodName, "(" + Interface.ToString() + ") Returning True.", Logger.Yellow);
                        break;

                    case Interfaces.VoiceAttack:
                        Answer = ProxyObject.CommandExists(Command);
                        break;

                    case Interfaces.VoiceMacro:                      
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex) { Logger.Exception(MethodName, "Command Exist Exception " + ex); }
            if (Answer == false) { Logger.Log(MethodName, "(" + Interface.ToString() + ") Command Does Not Exist - " + Command, Logger.Red); }

            return Answer;
        }

        public static string GetText(IVar Variable, string Answer = null)
        {
            switch (Interface)
            {
                case Interfaces.Internal:
                    break;

                case Interfaces.VoiceAttack:
                    Answer = ProxyObject.GetText("ALICE_" + Variable.ToString());
                    break;

                case Interfaces.VoiceMacro:
                    break;

                default:
                    break;
            }
            
            if (Answer == null) { Logger.DebugLine(MethodName, Variable.ToString() + " Was Not Set Or Was Null", Logger.Red); }
            return Answer;
        }

        public static void SetText(IVar Variable, string Value)
        {
            string MethodName = "Set Variable (Enums)";

            switch (Interface)
            {
                case Interfaces.Internal:
                    Logger.Log(MethodName, "(" + Interface.ToString() + ") Text Variable: " + Variable.ToString() + " = " + Value, Logger.Yellow);
                    break;

                case Interfaces.VoiceAttack:
                    Logger.DebugLine(MethodName, "ALICE_" + Variable.ToString() + " = " + Value, Logger.Yellow);
                    ProxyObject.SetText("ALICE_" + Variable.ToString(), Value);
                    break;

                case Interfaces.VoiceMacro:
                    break;

                default:
                    break;
            }
        }

        public static void SetText(string Variable, string Value)
        {
            string MethodName = "Set Variable (Manual)";

            switch (Interface)
            {
                case Interfaces.Internal:
                    Logger.Log(MethodName, "(" + Interface + ") Text Variable: " + Variable + " = " + Value, Logger.Yellow);
                    break;

                case Interfaces.VoiceAttack:
                    Logger.DebugLine(MethodName, "ALICE_" + Variable + " = " + Value, Logger.Yellow);
                    ProxyObject.SetText("ALICE_" + Variable.ToString(), Value);
                    break;

                case Interfaces.VoiceMacro:
                    break;

                default:
                    break;
            }
        }

        public static void WriteToInterface(string LogText, string Color, string Debug = "")
        {
            switch (Interface)
            {
                case Interfaces.Internal:
                    if (ConsoleColors.ContainsKey(Color)) { Console.ForegroundColor = (ConsoleColor)ConsoleColors[Color]; }
                    Console.WriteLine(LogText); Console.ForegroundColor = ConsoleColor.White;
                    Logger.AliceLog(LogText);
                    break;

                case Interfaces.VoiceAttack:
                    Logger.AliceLog(LogText); ProxyObject.WriteToLog(LogText, Color);
                    break;

                case Interfaces.VoiceMacro:
                    break;

                default:
                    break;
            }
        }

        #endregion
    }
}