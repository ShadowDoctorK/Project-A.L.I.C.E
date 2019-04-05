using ALICE_Equipment;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Response
{
    public static partial class IResponse
    {
        public static Discovery_Scanner DiscoveryScanner = new Discovery_Scanner();
    }

    public class Discovery_Scanner : Generic_Equipment
    {
        public override void Assigned(string Group, string FireMode, bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "Discovery Scanner Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase("Discovery Scanner Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CA, V1, V2, V3, P, V);
        }

        public override void NotAssigned(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Discovery_Scanner.Not_Assigned), 
                CA, V1, V2, V3, P, V);
        }

        public override void EnteredHyperspace(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(EQ_Discovery_Scanner.Entered_Hyperspace),
                CA, V1, V2, V3, P, V);
        }

        public override void ScanComplete(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(EQ_Discovery_Scanner.Scan_Complete), 
                CA, V1, V2, V3, P, V);
        }

        public override void ScanCommenced(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(EQ_Discovery_Scanner.Scan_Commenced), 
                CA, V1, V2, V3, P, V);
        }

        public override void ScanFailed(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(EQ_Discovery_Scanner.Scan_Failed), 
                CA, V1, V2, V3, P, V);
        }

        public void NewReturns(decimal Returns, bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, Returns + "New Returns Detected.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Discovery_Scanner.New_Returns)
                .Phrase(EQ_Discovery_Scanner.Updating, false, IEquipment.DiscoveryScanner.FirstScan)
                .Token("[SCANNUM]", Returns)                        //Number Of Bodies
                .Token("Bodies", "Body", (Returns == 1))            //Check Singular Tense
                .Token("Returns", "Return", (Returns == 1)),        //Check Singular Tense
                CA, V1, V2, V3, P, V);
        }

        public void NoReturns(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(ClassName, "No New Returns Detected.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Discovery_Scanner.No_Returns),
                CA, V1, V2, V3, P, V);
        }

        public void FSSActivating(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_Discovery_Scanner.FSS_Activating), 
                CA, V1, V2, V3, P, V);
        }

        public void FSSDeactivating(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase(EQ_Discovery_Scanner.FSS_Deactivating), 
                CA, V1, V2, V3, P, V);
        }

        public void FSSCurrentlyActivated(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Discovery_Scanner.FSS_Currently_Activated),
                CA, V1, V2, V3, P, V);
        }

        public void FSSCurrentlyDeactivated(bool CA, bool V1 = true, bool V2 = true, bool V3 = true, int P = 3, string V = null)
        {
            Speech.Speak(""
                .Phrase(GN_Negative.Default, true)
                .Phrase(EQ_Discovery_Scanner.FSS_Currently_Deactivated), 
                CA, V1, V2, V3, P, V);
        }
    }
}