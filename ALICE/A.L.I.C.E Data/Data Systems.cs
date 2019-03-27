using ALICE_Internal;
using ALICE_Interface;
using System;
using System.Collections.Generic;
using System.IO;
using ALICE_Objects;

namespace ALICE_Data
{
    public class Data_Systems
    {
        private Dictionary<decimal, Object_System> _Data = Load();
        public Dictionary<decimal, Object_System> Data
        {
            get => _Data;
            private set => _Data = value;
        }

        private static Dictionary<decimal, Object_System> Load()
        {
            string MethodName = "Game Commodities (Load)";

            Dictionary<decimal, Object_System> Temp = new Dictionary<decimal, Object_System>();

            string P = Paths.ALICE_SystemData;      //Systems Folder
            string F = "*.System";                  //Systems Extension

            foreach (FileInfo SystemFile in new DirectoryInfo(P).EnumerateFiles(F, SearchOption.TopDirectoryOnly))
            {
                try
                {
                    //Deserialize System Object
                    Object_System System = INewtonSoft.Load2<Object_System>(SystemFile.Name, P);

                    //Check Loaded Data For Data Version Updates.
                    System = UpdateDataVersion(System);

                    //Add Data To Temp Dictionary
                    Temp.Add(System.Address, System);
                }
                catch (Exception ex)
                {
                    Logger.Exception(MethodName, "Exception: " + ex);
                }
            }

            //Return Temp Dictionary
            return Temp;
        }

        public static Object_System UpdateDataVersion(Object_System Sys)
        {
            string MethodName = "System Data Version Update";

            bool DataUpdated = false;

            #region Update To Version 340.0
            if (Sys.DataVersion == -1)
            {
                //NOTES: Updates Stellar Body Gravity Data. Logged Gravity Is 10X the Actual.
                //1. Divides Gravity By 10.
                //2. Sets Intial Data Version
                try
                {
                    DataUpdated = true;
                    Dictionary<decimal, Object_StellarBody> TempBodies = new Dictionary<decimal, Object_StellarBody>();
                    foreach (var Body in Sys.Bodies.Values)
                    {
                        if (Body.Gravity != -1) { Body.Gravity = Body.Gravity / 10; }
                        TempBodies.Add(Body.ID, Body);
                    }
                    Sys.Bodies = TempBodies;
                    Sys.DataVersion = 340.0M;
                }
                catch (Exception ex)
                {
                    Logger.ContactDeveloper();
                    Logger.Exception(MethodName, "Exception: " + ex);
                    Logger.Exception(MethodName, "System Name: " + Sys.Name);
                    Logger.Exception(MethodName, "Updating To 340.0");
                }
            }
            #endregion

            if (DataUpdated) { INewtonSoft.Save<Object_System>(Sys, Sys.Name + ".System", Paths.ALICE_SystemData); }

            return Sys;
        }
    }
}
