﻿using System;
using System.Windows.Forms;
using ALICE_Internal;

namespace ALICE_Interface
{
    public static class IVoiceAttack
    {
        static readonly string MethodName = "Voice Attack Interface";

        #region Voice Attack Interface

        public static string VA_DisplayName()
        {
            return "Project A.L.I.C.E: Command Interface - " + IPlatform.Version;
        }

        public static string VA_DisplayInfo()
        {
            return "Project A.L.I.C.E: Command Interface - " + IPlatform.Version;
        }

        public static Guid VA_Id()
        {
            return new Guid("{A1C09FFD-1996-41F4-90EF-BDB0DABC0473}");
        }

        public static void VA_StopCommand()
        {

        }

        public static void VA_Invoke1(dynamic vaProxy)
        {
            try
            {
                //Update Proxy Object
                IPlatform.ProxyObject = vaProxy;

                //Debug Logger
                Logger.DebugLine(MethodName, "(" + IPlatform.Interface.ToString() + ") Sent Command: " + vaProxy.Context, Logger.Blue);

                //Pass To Command Logic
                ICommands.Invoke(vaProxy.Context);
            }
            catch (Exception ex) { Logger.Exception(MethodName, "(" + IPlatform.Interface.ToString() + ") Invoke Exception: " + ex); }
        }

        public static void VA_Exit1(dynamic vaProxy)
        {
            //Log Shutdown
            Logger.Simple("Interface Shutting Down...", Logger.Purple);
        }

        public static void VA_Init1(dynamic vaProxy)
        {
            try
            {
                //Set Platform
                IPlatform.Interface = IPlatform.Interfaces.VoiceAttack;

                //Initialize Plugin Settings
                PlugIn.Respond = PlugIn.Output.TTS;
                Paths.CreateDir();
                Paths.Load_UpdateBindsFile();                
                IPlatform.ProxyObject = vaProxy;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Start-up Hamsters Reported An Issue: " + ex);
                Logger.Exception(MethodName, "Initialization Exception: " + ex);
            }

            Logger.Simple("Configured For Voice Attack. Standing By To Initialize...", Logger.Purple);
        }
        #endregion
    }
}
