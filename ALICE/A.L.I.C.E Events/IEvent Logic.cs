using ALICE_Events;
using ALICE_Internal;
using ALICE_Core;
using ALICE_Synthesizer;
using ALICE_Equipment;
using ALICE_Debug;

namespace ALICE_EventLogic
{
    /// <summary>
    /// Process class is a Data management class, it also conducts various simple Event operations.
    /// </summary>
    public static class Process
    {
        #region Custom Event Logic        

        //public static void NoFireZone(NoFireZone Event)
        //{
        //    string MethodName = "Logic: No Fire Zone";

        //    //Entering No Fire Zone
        //    if (ICheck.NoFireZone.Status(MethodName, true) == true)
        //    {
        //        IEvents.FireInNoFireZone.FirstReport = true;

        //        //Audio - Entered No Fire Zone
        //        IStatus.Docking.Response.NoFireZoneEntered(
        //            Event.Station,                                      //Pass Station Name
        //            ICheck.Initialized(MethodName));    //Check Plugin Initialized

        //        Thread.Sleep(100);

        //        if (Check.Order.WeaponSafety(true, MethodName))
        //        {
        //            IStatus.WeaponSafety = true;
        //            Call.Action.AnalysisMode(true, false);

        //            if (Check.Variable.Hardpoints(true, MethodName) == true)
        //            {
        //                Call.Action.Hardpoint(false, false);

        //                //Audio - Enabling Weapon Safeties (Deployed)
        //                IStatus.Docking.Response.WeaponSafetiesEnablingDeployed(                            
        //                    ICheck.Initialized(MethodName));    //Check Plugin Initialized

        //                return;
        //            }

        //            //Audio - Enabling Weapon Safeties
        //            IStatus.Docking.Response.WeaponSafetiesEnablingDeployed(                        
        //                ICheck.Initialized(MethodName));    //Check Plugin Initialized
        //        }
        //    }

        //    //Exiting No Fire Zone
        //    else if (ICheck.NoFireZone.Status(MethodName, true) == false)
        //    {
        //        IStatus.WeaponSafety = false;

        //        //Audio - Exited No Fire Zone
        //        IStatus.Docking.Response.NoFireZoneExited(
        //            Event.Station,                                      //Pass Station Name
        //            ICheck.Initialized(MethodName));    //Check Plugin Initialized

        //        Thread.Sleep(100);

        //        if (Check.Order.WeaponSafety(true, MethodName))
        //        {
        //            //Audio - Disabling Weapon Safeties
        //            IStatus.Docking.Response.WeaponSafetiesDisabling(
        //                ICheck.Initialized(MethodName));    //Check Plugin Initialized
        //        }
        //    }
        //}      

        #region Under Construction
        public static void DisobeyPolice(DisobeyPolice Event)
        {
            string MethodName = "Disobey Police";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Disobey_Police),
                    true,
                    ICheck.Initialized(MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void IllegalCargo(IllegalCargo Event)
        {
            string MethodName = "Illegal Cargo";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Illegal_Cargo),
                    true,
                    ICheck.Initialized(MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void Interdicting(Interdicting Event)
        {
            string MethodName = "Interdicting";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Interdicting),
                    true,
                    ICheck.Initialized(MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void Murder(Murder Event)
        {
            string MethodName = "Murder";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Murder),
                    true,
                    ICheck.Initialized(MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void Piracy(Piracy Event)
        {
            string MethodName = "Piracy";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Piracy),
                    true,
                    ICheck.Initialized(MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void TrespassMinor(TrespassMinor Event)
        {
            string MethodName = "Trespass Minor";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Trespass_Minor),
                    true,
                    ICheck.Initialized(MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void DumpingDangerous(DumpingDangerous Event)
        {
            string MethodName = "Dumping Dangerous";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Dumping_Dangerous),
                    true,
                    ICheck.Initialized(MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void DumpingNearStation(DumpingNearStation Event)
        {
            string MethodName = "Dumping Near Station";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Dumping_Near_Station),
                    true,
                    ICheck.Initialized(MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void TrespassMajor(TrespassMajor Event)
        {
            string MethodName = "Warning";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Block_Landing_Pad_Warning),
                    true,
                    ICheck.Initialized(MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void WrecklessFlying(WrecklessFlying Event)
        {
            string MethodName = "Wreckless Flying";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Wreckless_Flying),
                    true,
                    ICheck.Initialized(MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }

        public static void WrecklessFlyingDamage(WrecklessFlyingDamage Event)
        {
            string MethodName = "Wreckless Flying Damage";

            #region Audio
            if (PlugIn.Audio == "TTS")
            {
                Speech.Speak
                    (
                    "".Phrase(Crime.Wreckless_Flying_Damage),
                    true,
                    ICheck.Initialized(MethodName)
                    );
            }
            else if (PlugIn.Audio == "File") { }
            else if (PlugIn.Audio == "External") { }
            #endregion
        }
        #endregion

        //End Region: Custom Event Logic
        #endregion

        #region Json Status Updates
        public static void Position(decimal Lat, decimal Log, decimal Alt, decimal Head)
        {
            string MethodName = "Position Update";

            //Check & Record Altitude To Planets Status If In Supercruise.            
            if (Check.Environment.Space(IEnums.Supercruise, true, MethodName, true)) { IStatus.Planet.Decending(Alt); }

            //Approaching Planetary Decent Altitude.
            //1. Orbital Mode Engaged
            //2. Altitude Less Than 60km
            //3. Decent Report Not Made
            if (IStatus.Planet.OrbitalMode && Alt < 60000 && IStatus.Planet.DecentReport == false)
            {
                IStatus.Planet.Response.OrbitalDecentPreps(true, ICheck.Initialized(MethodName));
                IStatus.Planet.DecentReport = true;
            }

            //Leaving Planetary Decent Alitude.
            //1. Orbital Mode Engaged
            //2. Altitude Greater Than 80km
            //3. Decent Report Made
            //4. We Are Not Exiting The Planet
            if (IStatus.Planet.OrbitalMode && Alt > 80000 && IStatus.Planet.DecentReport == true && IStatus.Planet.ExitingPlanet == false)
            {
                IStatus.Planet.Response.OrbitalDecentAborted(true, ICheck.Initialized(MethodName));
                IStatus.Planet.DecentReport = false;
            }            
        }
        #endregion
    }
}