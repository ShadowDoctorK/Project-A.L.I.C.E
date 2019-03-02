using ALICE_Debug;
using ALICE_Internal;
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
            Online(
                ICheck.InitializedStatus(MethodName),               //Check Status.Json Initialized
                ICheck.Shields.Status(MethodName, true, true));     //Check Shields Online

            //Audio - Offline
            Offline(
                ICheck.InitializedStatus(MethodName),               //Check Status.Json Initialized
                ICheck.Shields.Status(MethodName, false, true));    //Check Shields Offline
                
        }

        #region Audio
        public override void NotInstalled(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Shield Generator Not Installed.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase("Shield Generator Not Installed."),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void Offline(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Shields Offline.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Shields.Offline),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void Online(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Shields Online.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Shields.Online),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion
    }
}