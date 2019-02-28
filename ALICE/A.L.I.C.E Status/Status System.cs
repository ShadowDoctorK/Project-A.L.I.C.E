using ALICE_Debug;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;

namespace ALICE_Status
{
    public class Status_System
    {
        private readonly string MethodName = "System Status";

        public string TargetSystem = "";
        public decimal TargetAddress = -1;

        public Responses Response = new Responses();

        public void Update(FSDTarget Event)
        {
            TargetAddress = Event.SystemAddress;
            TargetSystem = Event.Name;
        }

        public void TargetArrival(FSDJump Event)
        {
            //Check Plugin Initialized
            if (ICheck.Initialized(MethodName) == false) { return; }

            //Check If We Have Arrived At Our Target Destination
            if (TargetAddress == Event.SystemAddress)
            {
                //Arrival Audio
                Response.Arrived(
                    Event.StarSystem,                                   //Pass The System Name
                    ICheck.Initialized(MethodName));    //Check Plugin Initialized
            }
        }

        public void Status(FSDJump Event)
        {
            //Load Target System Data Or Return New Object
            Object_System System = IObjects.SystemCurrent.Get_SystemData(Event.SystemAddress);

            //Check First Visit
            if (System.FirstVisit == true)
            {
                //System Report
                Logger.Log(MethodName, "This Is The First Time You've Visited " + Event.StarSystem, Logger.Yellow, true);

            }
            //Check For Updates
            else
            {
                //System Status Update Report
                Logger.Log(MethodName, "Welcome Back To " + Event.StarSystem, Logger.Yellow, true);

            }

            //Update Current System Information
            IObjects.SystemCurrent = IObjects.SystemCurrent.Update_SystemData(Event);
        }

        public class Responses
        {
            string MethodName = "System Status";

            public void Arrived(string  SystemName, bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Target Destination Reached: " + IObjects.SystemCurrent.Name, Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_System_Report.Arrived)
                    .Token("[STARSYSTEM]", SystemName),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }
    }
}
