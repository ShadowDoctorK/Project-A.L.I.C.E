using ALICE_Events;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Settings;
using ALICE_Synthesizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Status
{
    public class Status_Scanned
    {
        private readonly string MethodName = "Scanned Status";

        public enum S { Default, Cargo, Crime, Cabin, Data, Unknown }

        public Responses Response = new Responses();

        public void Update(Scanned Event)
        {
            S Scan = S.Default;

            //Generate Custom Events
            try
            {
                Scan = IEnums.ToEnum<S>(Event.ScanType, false);

                switch (Scan)
                {
                    case S.Cargo:
                        break;

                    case S.Crime:
                        break;

                    case S.Cabin:
                        break;

                    case S.Data:
                        break;

                    case S.Unknown:
                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
                
            }            
        }        



        public class Responses
        {
            string MethodName = "Scanned Status";
        }
    }
}
