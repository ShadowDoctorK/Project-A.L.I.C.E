using ALICE_Internal;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Status
{
    public class Status_Materials
    {
        public List<Material> Raw { get; set; }
        public List<Material> Manufactured { get; set; }
        public List<Material> Encoded { get; set; }


        public Responses Response = new Responses();
        public Checks Check = new Checks();
        public Logging Log = new Logging();

        public void Update()
        {

        }

        public class Material
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public decimal Count { get; set; }

            public Material()
            {
                Name = "None";
                Name_Localised = "None";
                Count = -1;
            }
        }

        public class Responses
        {
            string MethodName = "Materials Status";

            public void Collected(string Material, bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Collected: " + Material, Logger.Yellow); }

                Speech.Speak(Material + "Collected.",
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }

        public class Checks
        {

        }

        public class Logging
        {

        }
    }
}