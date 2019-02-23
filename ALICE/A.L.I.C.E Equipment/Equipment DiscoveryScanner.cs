using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ALICE_Actions;
using ALICE_Core;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Synthesizer;

namespace ALICE_Equipment
{
    public class Equipment_DiscoveryScanner : Equipment_General
    {
        public bool Active = false;           //Allows Tracking The Status Of Active Scans.
        public bool FirstScan = true;         //Allows Tracking The First Scan In System.
        public bool Mode { get; set; }

        public Equipment_DiscoveryScanner()
        {
            Settings.Equipment = IEquipment.E.Discovery_Scanner;
            Settings.Mode = IEquipment.M.Analysis;
            Settings.Installed = true;
            Settings.Enabled = true;
        }

        public void Scan()
        {
            if (Check.Order.AssistSystemScan(true, MethodName))
            {
                Thread DisScan = new Thread((ThreadStart)(() => 
                {
                    Call.Action.DiscoveryScanner(true, true);
                }));
                DisScan.IsBackground = true;
                DisScan.Start();
            }
        }

        #region Watcher
        //Sets "Active" to true when constructed. Then watches the variable for 2 seconds when Invoked.
        public override WaitHandler Watch() { Active = true; return new WaitHandler(Watcher); }
        public override bool Watcher()
        {
            decimal Count = 2000 / 50; while (Active != false)
            {
                Count--; if (Count <= 0)
                {
                    Active = false; return false;
                }
                Thread.Sleep(50);
            }

            return true;
        }
        #endregion

        #region Audio
        public override void Assigned(string Group, string FireMode, bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Discovery Scanner Assigned To Group " + Group + " " + FireMode + " Fire.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(GN_Positive.Default, true)
                .Phrase("Discovery Scanner Assigned To Group [GROUP], [FIREMODE] Fire.")
                .Token("[GROUP]", Group)
                .Token("[FIREMODE]", FireMode),
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void NotAssigned(bool CommandAudio, bool Var1 = true, bool Var2 = true, 
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true).Phrase(EQ_Discovery_Scanner.Not_Assigned), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void EnteredHyperspace(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Speak("".Phrase(EQ_Discovery_Scanner.Entered_Hyperspace), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void ScanComplete(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Speak("".Phrase(EQ_Discovery_Scanner.Scan_Complete), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void ScanCommenced(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Speak("".Phrase(EQ_Discovery_Scanner.Scan_Commenced), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public override void ScanFailed(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Speak("".Phrase(EQ_Discovery_Scanner.Scan_Failed), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void NewReturns(decimal Returns, bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, Returns + "New Returns Detected.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Discovery_Scanner.New_Returns)
                .Phrase(EQ_Discovery_Scanner.Updating, false, IEquipment.DiscoveryScanner.FirstScan)
                .Token("[SCANNUM]", Returns)                        //Number Of Bodies
                .Token("Bodies", "Body", (Returns == 1))            //Singular Tense
                .Token("Returns", "Return", (Returns == 1)),        //Singular Tense
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void NoReturns(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "No New Returns Detected.", Logger.Yellow); }

            Speech.Speak(""
                .Phrase(EQ_Discovery_Scanner.No_Returns), 
                CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void FSSActivating(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Speak("".Phrase(GN_Positive.Default, true).Phrase(EQ_Discovery_Scanner.FSS_Activating), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void FSSDeactivating(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Speak("".Phrase(GN_Positive.Default, true).Phrase(EQ_Discovery_Scanner.FSS_Deactivating), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void FSSCurrentlyActivated(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true).Phrase(EQ_Discovery_Scanner.FSS_Currently_Activated), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }

        public void FSSCurrentlyDeactivated(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            Speech.Speak("".Phrase(GN_Negative.Default, true).Phrase(EQ_Discovery_Scanner.FSS_Currently_Deactivated), CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion
    }
}