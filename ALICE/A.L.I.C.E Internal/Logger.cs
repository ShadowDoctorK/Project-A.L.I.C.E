using System;
using System.IO;
using System.Threading;
using ALICE_Events;
using ALICE_Interface;

namespace ALICE_Internal
{
    public static class Logger
    {
        public static object LogLockFlag = new object();
        public static object UpdatesLockFlag = new object();

        #region Color Wrapper
        public static readonly string Red = "Red";
        public static readonly string Yellow = "Yellow";
        public static readonly string Green = "Green";
        public static readonly string Blue = "Blue";
        public static readonly string Purple = "Purple";
        #endregion

        public static void DebugLine(this string MethodName, string DebugText, string Color)
        {
            string Text = "A.L.I.C.E (Debug Mode): " + MethodName + " - " + DebugText;
            if (PlugIn.DebugMode) { IPlatform.WriteToInterface(Text, Color); }
        }

        public static void Error(this string MethodName, string DebugText, string Color)
        {
            string Text = "A.L.I.C.E (Error): " + MethodName + " - " + DebugText;
            IPlatform.WriteToInterface(Text, Color);
        }

        public static void Exception(this string MethodName, string DebugText)
        {
            string Text = "A.L.I.C.E (Exception): " + MethodName + " - " + DebugText;
            IPlatform.WriteToInterface(Text, Red);
        }

        public static void DevUpdateLog(this string MethodName, string DebugText, string Color, bool IsExtendedLogItem = false)
        {
            bool LogItem = true; string Text = "A.L.I.C.E: " + MethodName + " - " + DebugText;
            if (IsExtendedLogItem) { if (PlugIn.ExtendedLogging == false) { LogItem = false; } }
            if (LogItem != false) { IPlatform.WriteToInterface(Text, Color); }
            DeveloperLog(Text);
        }

        public static void RecordUpdate(string Text, string MethodName)
        {            
            DeveloperLog("(Update Required): " + MethodName + " | " + Text);
        }

        public static void Log(this string MethodName, string DebugText, string Color, bool IsExtendedLogItem = false)
        {
            if (IsExtendedLogItem && IEvents.TriggerEvents == false) { return; }

            bool LogItem = true; string Text = "A.L.I.C.E: " + MethodName + " - " + DebugText;
            if (IsExtendedLogItem) { if (PlugIn.ExtendedLogging == false) { LogItem = false; } }
            if (LogItem != false) { IPlatform.WriteToInterface(Text, Color); }
        }

        public static void Event(this string Text)
        {
            Text = "A.L.I.C.E: " + Text;
            IPlatform.WriteToInterface(Text, Logger.Purple);
        }

        public static void Simple(this string DebugText, string Color, bool IsExtendedLogItem = false)
        {
            bool LogItem = true; string Text = "A.L.I.C.E: " + DebugText;
            if (IsExtendedLogItem) { if (PlugIn.ExtendedLogging == false) { LogItem = false; } }
            if (LogItem != false) { IPlatform.WriteToInterface(Text, Color); }
        }

        public static void Basic(this string DebugText, string Color, string LinePrefix = null)
        {
            string Text = ""; if (LinePrefix != null) { Text = LinePrefix + ": "; }
            Text = Text + DebugText; IPlatform.WriteToInterface(Text, Color);
        }

        public static void ContactDeveloper()
        {
            Logger.Simple("Contact The Developer: Please Provide Your Most Current Journal Log & Alice Log To Troubleshoot", Logger.Red);
        }

        public static void AliceLog(string Text)
        {
            Log:
            if (Monitor.TryEnter(LogLockFlag))
            {
                try
                {
                    string Line = DateTime.UtcNow + " - (" + IPlatform.Interface + ") " + Text;
                    string LogName = Paths.ALICE_LogName();
                    string FilePath = Paths.ALICE_Log_Files + LogName;
                    StreamWriter Write = new StreamWriter(FilePath, append: true);

                    Write.WriteLine(Line);
                    Write.Close();
                    Write.Dispose();
                }
                catch(Exception)
                {
                    
                }
                finally
                {
                    Monitor.Exit(LogLockFlag);
                }
            }
            else
            {
                Thread.Sleep(10);
                goto Log;
            }
        }

        public static void DeveloperLog(string Text)
        {
            Log:
            if (Monitor.TryEnter(UpdatesLockFlag))
            {
                try
                {
                    string Line = DateTime.UtcNow + " - (" + IPlatform.Interface + ") " + Text;
                    string LogName = "A.L.I.C.E - Tracked Developer Updates.Log";
                    string FilePath = Paths.ALICE_Log_Files + LogName;
                    StreamWriter Write = new StreamWriter(FilePath, append: true);

                    Write.WriteLine(Line);
                    Write.Close();
                    Write.Dispose();
                }
                finally
                {
                    Monitor.Exit(UpdatesLockFlag);
                }
            }
            else
            {
                Thread.Sleep(10);
                goto Log;
            }
        }
    }

}
