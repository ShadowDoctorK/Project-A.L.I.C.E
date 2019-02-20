using ALICE_Actions;
using ALICE_Core;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;
using System.Threading;

namespace ALICE_Status
{
    public class Status_Planet
    {
        public bool OrbitalMode { get; set; }
        public bool DecentReport { get; set; }
        public bool PostGlideReport { get; set; }
        public bool ExitingPlanet { get; set; }
        public decimal Altitude { get; set; }
        public decimal TempC { get; set; }
        public decimal TempF { get; set; }        

        public Responses Response = new Responses();

        public Status_Planet()
        {
            OrbitalMode = false;
            DecentReport = false;
            PostGlideReport = false;
            ExitingPlanet = false;
        }

        /// <summary>
        /// Check Altitude against last recorded altitude to determin if ship is decending. 
        /// Will line up properties to make correct reports.
        /// </summary>
        /// <param name="Check">Altitude you want to check.</param>
        /// <returns>Returns true if ship is Decending.</returns>
        public bool Decending(decimal Check)
        {
            if (Check < Altitude)
            {
                //Set ExistPlanet to false so we can make the Decent report if needed.
                ExitingPlanet = false;
                //Set DecentReport to false so we can make the Report.
                DecentReport = false;
                //We Are Decending, Return True.
                return true;
            }
            //We Are Not Decending, Return False.
            return false;
        }

        /// <summary>
        /// Sets the state of the Orbital Cruise & Resets properites.
        /// </summary>
        /// <param name="State">The State of Orbital Cruise</param>
        public void OrbitalCruise(bool State)
        {
            //Set Orbital Mode
            OrbitalMode = State;

            //Reset Report Properties
            DecentReport = false;
            PostGlideReport = false;
            ExitingPlanet = false;
        }

        /// <summary>
        /// Will monitor the status of the Glide while making reports.
        /// </summary>
        /// <param name="Event">SupercruiseExit Event</param>
        public void Glide(SupercruiseExit Event)
        {
            string MethodName = "Planet Status (Glide Monitor)";

            #region Validation Checks
            //Check BodyType is Planet
            if (Event.BodyType != IEnums.Planet)
            {
                Logger.DebugLine(MethodName, "Body Type Is Not A Planet", Logger.Yellow);
                return;
            }           

            //Check Altitude Is Being Updated
            if (IStatus.Altitude == 0)
            {
                Logger.DebugLine(MethodName, "Altitude Is Not Being Updated", Logger.Yellow);
                return;
            }

            //Check HasLatLong
            if (IStatus.HasLatLong == false)
            {
                Logger.DebugLine(MethodName, "We Do Not Have Lat / Long.", Logger.Yellow);
                return;
            }
            #endregion

            //Monitor Glide
            Thread Glide_thread =
            new Thread((ThreadStart)(() =>
            {
                //If BodyType = Planet And FSD Cooldown = True it means the ship has left Glide.
                Logger.Log(MethodName, "Monitoring...", Logger.Yellow, true);
                int i2 = 6000; while (IEquipment.FrameShiftDrive.Cooldown != true)
                {
                    //Glide Stabilized
                    if (i2 == 600)
                    {
                        IStatus.Planet.Response.GlideCommenced(true);
                    }

                    //Safe Exit Limit
                    i2--; if (i2 <= 0)
                    {
                        Logger.Log(MethodName, "Stopped Montitoring, Its Been A While...", Logger.Yellow, true);
                        return;
                    }
                    Thread.Sleep(100);
                }

                //If Altitude is less than 10km then the Glide Should have been sucessful.
                if (IStatus.Altitude < 10000)
                {
                    IStatus.Planet.Response.GlideComplete(true);
                }
                //if Altitdue is more then 10km then the Glide Failed.
                else
                {
                    Logger.Log(MethodName, "Glide Failed, Better Luck Next Time...", Logger.Yellow, true);
                    //Audio
                }
            }))
            {
                IsBackground = false
            };
            Glide_thread.Start();
        }

        /// <summary>
        /// Will wait till glide completes then monitor the altitude for assisted landing preps.
        /// </summary>
        /// <param name="Event">SupercruiseExit Event</param>
        public void AssistedLanding(SupercruiseExit Event)
        {
            string MethodName = "Planet Status (Assisted Landing)";

            #region Validation Checks
            //Check BodyType is Planet
            if (Event.BodyType != IEnums.Planet)
            {
                Logger.DebugLine(MethodName, "Body Type Is Not A Planet", Logger.Yellow);
                return;
            }

            //Check Altitude Is Being Updated
            if (IStatus.Altitude == 0)
            {
                Logger.DebugLine(MethodName, "Altitude Is Not Being Updated", Logger.Yellow);
                return;
            }

            //Check HasLatLong
            if (IStatus.HasLatLong == false)
            {
                Logger.DebugLine(MethodName, "We Do Not Have Lat / Long.", Logger.Yellow);
                return;
            }
            #endregion

            //Monitor For Landing Preps
            Thread LandingPrep_thread =
            new Thread((ThreadStart)(() =>
            {
                Logger.Log(MethodName, "Waiting To Exit Glide...", Logger.Yellow, true);

                //If BodyType = Planet & FSD Cooldown = True it means the ship has left Glide.
                int i2 = 6000; while (IEquipment.FrameShiftDrive.Cooldown != true)
                {
                    i2--; if (i2 <= 0)
                    {
                        Logger.Log(MethodName, "Preparations Deactivated. Did Not Detect Exiting Glide In A Timely Manner...", Logger.Yellow, true);
                        return;
                    }
                    Thread.Sleep(100);
                }

                Logger.Log(MethodName, "Monitoring Altitude for 90 Seconds...", Logger.Yellow, true);

                //Monitor Altitude For 90 Seconds.
                int i = 900; while (i > 0 && IStatus.Altitude > 500)
                {
                    Thread.Sleep(100); i--; if (i <= 0)
                    {
                        Logger.Log(MethodName, "Timmed Out, You Took Too Long...", Logger.Yellow, true);
                        return;
                    }
                }

                //Alitude Less Than 500 Meters Deploy Gear
                if (IStatus.Altitude <= 500)
                {
                    Call.Action.LandingPreparations(true);
                }

            }))
            {
                IsBackground = false
            };
            LandingPrep_thread.Start();
        }

        public class Responses
        {
            string MethodName = "Planet Status";

            public void GlideComplete(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Glide Complete.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Planetary_Interaction.Glide_Complete),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void GlideCommenced(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Glide Commenced.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Planetary_Interaction.Glide_Commenced),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OrbitaCruiseExit(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Orbital Guidance Systems Offline.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Planetary_Interaction.Orbital_Cruise_Exit),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OrbitaCruiseEntry(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Orbital Guidance Systems Online.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Planetary_Interaction.Orbital_Cruise_Entry),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OrbitalDecentPreps(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Prepairing For Orbital Decent", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Planetary_Interaction.Orbital_Descent_Prep),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OrbitalDecentAborted(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Aborted Orbital Decent", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Planetary_Interaction.Orbital_Descent_Aborted),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OrbitalGravityWarning(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "High Gravity Warning: " + IObjects.StellarBodyCurrent.Gravity, Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Planetary_Interaction.Orbital_Gravity_Warning),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OrbitalNotScanned(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Not Spectrum Scanned, Recommned Scanning Prior To Entry.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Planetary_Interaction.Orbital_Not_Scanned),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }   
    }
}
