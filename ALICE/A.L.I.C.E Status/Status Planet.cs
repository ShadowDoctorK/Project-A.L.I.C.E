using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;

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

        public void OrbitalCruise(bool State)
        {
            //Set Orbital Mode
            OrbitalMode = State;

            //Reset Report Properties
            DecentReport = false;
            PostGlideReport = false;
            ExitingPlanet = false;
        }

        public class Responses
        {
            string MethodName = "Orbital Status";

            public void OrbitaCruiseExit(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Orbital Guidance Systems Offline.", Logger.Yellow); }

                Speech.Response(""
                    .Speak(GN_Planetary_Interaction.Orbital_Cruise_Exit),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OrbitaCruiseEntry(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Orbital Guidance Systems Online.", Logger.Yellow); }

                Speech.Response(""
                    .Speak(GN_Planetary_Interaction.Orbital_Cruise_Entry),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OrbitalDecentPreps(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Prepairing For Orbital Decent", Logger.Yellow); }

                Speech.Response(""
                    .Speak(GN_Planetary_Interaction.Orbital_Descent_Prep),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OrbitalDecentAborted(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Aborted Orbital Decent", Logger.Yellow); }

                Speech.Response(""
                    .Speak(GN_Planetary_Interaction.Orbital_Descent_Aborted),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OrbitalGravityWarning(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "High Gravity Warning: " + IObjects.StellarBodyCurrent.Gravity, Logger.Yellow); }

                Speech.Response(""
                    .Speak(GN_Planetary_Interaction.Orbital_Gravity_Warning),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OrbitalNotScanned(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Not Spectrum Scanned, Recommned Scanning Prior To Entry.", Logger.Yellow); }

                Speech.Response(""
                    .Speak(GN_Planetary_Interaction.Orbital_Not_Scanned),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }   
    }
}
