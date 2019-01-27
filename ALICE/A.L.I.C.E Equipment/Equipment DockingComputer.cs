using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Core;
using ALICE_Internal;
using ALICE_Synthesizer;

namespace ALICE_Equipment
{
    public class Equipment_DockingComputer : Equipment_General
    {
        public bool AsisstedDockingReport { get; set; }     //Allows Tracking Docking Computer Report For Assisted Docking.

        public Equipment_DockingComputer()
        {
            Settings.Equipment = IEquipment.E.Standard_Docking_Computer;
            Settings.Mode = IEquipment.M.Default;
            Settings.Installed = false;
            Settings.Enabled = true;

            //Custom Properites
            AsisstedDockingReport = true;
        }

        public Equipment_DockingComputer New() { return new Equipment_DockingComputer(); }

        #region Audio
        public override void NotInstalled(bool CommandAudio, bool Var1 = true, bool Var2 = true,
            bool Var3 = true, int Priority = 3, string Voice = null)
        {
            if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Docking Computer Not Installed.", Logger.Yellow); }

            Speech.Speak("Docking Computer Not Installed.", CommandAudio, Var1, Var2, Var3, Priority, Voice);
        }
        #endregion
    }
}