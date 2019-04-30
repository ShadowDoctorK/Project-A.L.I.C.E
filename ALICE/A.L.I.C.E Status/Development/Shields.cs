using ALICE_Debug;
using ALICE_Response;

namespace ALICE_Status
{
    public static partial class IStatus
    {
        public static Shields Shields { get; set; } = new Shields();
    }

    public class Shields
    {
        private readonly string MethodName = "Status (Shields)";

        public bool Status = true;

        public void Update(bool B)
        {
            //Only Process Chagnes
            if (B == Status) { return; }

            //Update Shield State
            Status = B;

            //Audio - Online
            IResponse.Shields.Online(
                ICheck.InitializedStatus(MethodName),               //Check Status.Json Initialized
                ICheck.Status.Shields(MethodName, true, true));     //Check Shields Online

            //Audio - Offline
            IResponse.Shields.Offline(
                ICheck.InitializedStatus(MethodName),               //Check Status.Json Initialized
                ICheck.Status.Shields(MethodName, false, true));    //Check Shields Offline                
        }   
    }
}