using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Collections;
using ALICE_Interface;

namespace ALICE_Monitors
{
    public class Monitor_Journal
    {
        public class SettingsJournal
        {
            public object Lock = new object();
            public bool Enabled { get; set; }
            public bool Initialized { get; set; }
            public bool AutoRestart { get; set; }

            public SettingsJournal()
            {
                Enabled = true;
                Initialized = false;
                AutoRestart = true;
            }

            public SettingsJournal(bool E, bool I, bool A)
            {
                Enabled = E;
                Initialized = I;
                AutoRestart = A;
            }
        }

        public class LogFile
        {
            public FileInfo File = null;
            public DateTime Stamp { get; set; }
            public DateTime Processed { get; set; }
            readonly DirectoryInfo GameData = new DirectoryInfo(Paths.LogDirectory);
            public List<string> Storage = new List<string>();
            public bool InitialLoad = true;
            public decimal EventCount = 0;
            public decimal EventTotal = 0;
            public string Line = "";
            public string EventName = "";

            /// <summary>
            /// Will Check The Logs and Update the LogFile's Settings to maintain target on the most current Log.
            /// </summary>
            /// <returns>Returns True if Changes are detected</returns>
            public bool Check()
            {
                string MethodName = "Journal Monitor (Check Files)";
                bool Answer = false;

                try
                {
                    //Track Processing File Name
                    string FileCurrent = "";
                    if (File != null)
                    {
                        FileCurrent = File.Name;
                    }

                    string FileName = null;

                    //Check For New / Updated Logs
                    foreach (FileInfo Log in GameData.EnumerateFiles("Journal*.log", SearchOption.TopDirectoryOnly))
                    {
                        if (File != null) { FileName = File.Name; }

                        //Check If File Is Null
                        if (File == null)
                        {
                            //New File, lets get it setup.
                            File = Log;
                            Stamp = Log.LastWriteTime;
                            Answer = true;
                        }
                        //Update File Information
                        else if (Stamp < Log.LastWriteTime)
                        {
                            //New Log File
                            if (File.Name != Log.Name)
                            {
                                File = Log;
                                EventCount = 0;
                                EventTotal = 0;
                                Stamp = Log.LastWriteTime;
                                Answer = true;
                            }
                            //Update Time Stamp
                            else
                            {
                                Stamp = Log.LastWriteTime;
                                Answer = true;
                            }
                        }
                    }

                    //Log New Target Log File.
                    if (FileCurrent != File.Name)
                    {
                        FileCurrent = File.Name;
                        Logger.Event("Elite Dangerous Log: " + File.Name);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "(Failed) The Check Hamster Made A Mistake And Forgot What He Was Doing...");
                }

                //Debug Mode
                if (Answer) { Logger.DebugLine(MethodName, "Log Change Detected", Logger.Blue); }

                //Return If Log Changes Were Found.
                return Answer;
            }

            public void ResetProcessors()
            {
                Line = "";
                EventName = "";
            }
        }

        public SettingsJournal Settings { get; set; } = new SettingsJournal();
        public LogFile Journal { get; private set; } = new LogFile();
        private readonly string MethodName = "Journal Reader";

        public void Start()
        {
            //Start Monitoring And Lock The Door Behind Us...
            if (Monitor.TryEnter(Settings.Lock))
            {
                try
                {
                    while (Settings.Enabled)
                    {
                        //Check Journal File
                        Journal.Check();

                        //Update Log Data
                        using (StreamReader SR = new StreamReader(GetFileStream(Journal.File.FullName)))
                        {
                            //Clear Storage For New Read Of The Log.
                            Journal.Storage = new List<string>();

                            //Read Entire Log.
                            while (!SR.EndOfStream) { Journal.Storage.Add(SR.ReadLine()); }

                            //Set Total Events
                            Journal.EventTotal = Journal.Storage.Count;
                        }

                        //Validation Checks
                        if (Journal.EventCount > Journal.EventTotal)
                        {
                            Journal.EventCount = 0;
                            IEvents.ExecuteOnline = true;
                            IEvents.TriggerEvents = false;

                            Logger.Error(MethodName, "The Journal Hamsters Lost Track Of the Logs, They Are Attempting To Start Over...", Logger.Red);
                        }

                        //Process New Events
                        while (Journal.EventCount < Journal.EventTotal)
                        {
                            //Reset Line & EventName
                            Journal.ResetProcessors();

                            //Track Event Enum Name
                            IEnums.Events E = IEnums.Events.None;

                            //Find Event, Convert To Enum
                            try
                            {
                                //Grab Line To Process
                                Journal.Line = Journal.Storage[(int)Journal.EventCount];

                                //Get Event Name
                                Journal.EventName = Journal.Line.Substring(47, Journal.Line.IndexOf("\"", 47) - 47);

                                //Check Event & Type Exists, Increase EventCount
                                switch (IEvents.Types.Exists(Journal.EventName, false))
                                {
                                    //Event Exists, Convert Enum
                                    case CollectionEventTypes.A.Pass:

                                        //Enum Conversion
                                        E = IEnums.ToEnum<IEnums.Events>(Journal.EventName);

                                        //Debug Logger
                                        Logger.DebugLine(MethodName, E + " Converted", Logger.Blue);

                                        //Increase Event Count
                                        Journal.EventCount++;

                                        break;

                                    //Event Does Not Exist, 
                                    case CollectionEventTypes.A.Fail:

                                        //Log & Record Event To Developer Log
                                        if (Settings.Initialized == true)
                                        {
                                            Logger.DevUpdateLog(MethodName, "Untracked Event [" + Journal.EventName + "] " + Journal.Line, Logger.Purple);
                                        }

                                        //Increase Event Count
                                        Journal.EventCount++;

                                        break;

                                    //Checking The Event Returned A Error
                                    case CollectionEventTypes.A.Error:

                                        //Log Error
                                        Logger.Error(MethodName, "An Error Was Detected While Procssing " + Journal.EventName, Logger.Red);

                                        //Increase Event Count
                                        Journal.EventCount++;

                                        break;

                                    default:

                                        //Error Logger
                                        Logger.Error(MethodName, "Returned Using The Default Switch", Logger.Red);

                                        //Increase Event Count
                                        Journal.EventCount++;

                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "(Failed) The Cypher Hamster Made A Mistake And Forgot What He Was Doing...");
                                Journal.EventCount++;
                            }

                            try
                            {
                                //Deserialize Valid Events
                                if (E != IEnums.Events.None)
                                {
                                    //Deserialize
                                    var Event = INewtonSoft.Deserialize(Journal.Line, IEvents.Types.Get(E));

                                    //Null Check Event
                                    if (Event != null)
                                    {
                                        //Update Event Collection
                                        IEvents.Event.Record(E, Event);

                                        //Process Event
                                        IEvents.Process(E);
                                    }
                                }
                                else
                                {
                                    //New Event Detection Handler
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Exception(MethodName, "Exception: " + ex);
                                Logger.Exception(MethodName, "(Failed) The Decoder Hamster Made A Mistake And Forgot What He Was Doing...");
                            }
                        }

                        //Update Processed Time Stamp
                        Journal.Processed = Journal.Stamp;

                        //Check If We Initialized
                        if (Settings.Initialized != true)
                        {
                            //Execute Alice Online
                            Settings.Initialized = true;
                            IEvents.TriggerEvents = true;

                            //Record Alice Online Event
                            IEvents.AliceOnline.Logic();
                        }

                        //Sleep
                        Thread.Sleep(100);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "(Failed) All The Hamsters Died A Horible Death...");
                }
                finally
                {
                    Monitor.Exit(Settings.Lock);
                    Logger.Log(MethodName, "(Shutdown) All The Hamsters Went To Sleep.", Logger.Red);
                }
            }
        }

        /// <summary>
        /// Opens A Readonly FileStream with ReadWrite sharing.
        /// </summary>
        /// <param name="FilePath">Path of your file.</param>
        /// <returns>Returns a FileStream.</returns>
        private FileStream GetFileStream(string FilePath)
        {
            return new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

    }
}