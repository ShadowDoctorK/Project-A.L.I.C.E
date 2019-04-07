using ALICE_Debug;
using ALICE_Internal;
using ALICE_Response;
using ALICE_Synthesizer;

namespace ALICE_Equipment
{
    public class Shields : Equipment_General
    {
        public bool Status { get; set; }        //Status.Json Property

        public Shields()
        {
            Settings.Equipment = IEquipment.E.Shield_Generator;
            Settings.Mode = IEquipment.M.Default;
            Settings.Installed = false;
            Settings.Enabled = true;
            Settings.Total = -1;
            Settings.Capacity = -1;

            Status = false;
        }

        public void Update(bool B)
        {
            //Only Process Chagnes
            if (B == Status) { return; }

            //Update Shield State
            Status = B;

            //Audio - Online
            IResponse.Shields.Online(
                ICheck.InitializedStatus(MethodName),               //Check Status.Json Initialized
                ICheck.Shields.Status(MethodName, true, true));     //Check Shields Online

            //Audio - Offline
            IResponse.Shields.Offline(
                ICheck.InitializedStatus(MethodName),               //Check Status.Json Initialized
                ICheck.Shields.Status(MethodName, false, true));    //Check Shields Offline
                
        }   
    }
}