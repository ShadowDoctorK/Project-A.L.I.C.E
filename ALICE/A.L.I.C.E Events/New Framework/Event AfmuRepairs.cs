//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 4:40 PM
//Source Journal Line: { "timestamp":"2018-10-17T08:06:45Z", "event":"AfmuRepairs", "Module":"$int_powerdistributor_size8_class5_name;", "Module_Localised":"Power Distributor", "FullyRepaired":true, "Health":1.000000 }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_AfmuRepairs : Base
    {
        public string Module { get; set; }
        public string Module_Localised { get; set; }
        public string FullyRepaired { get; set; }
        public decimal Health { get; set; }

        //Default Constructor
        public ASDF_AfmuRepairs()
        {
            Module = Str();
            Module_Localised = Str();
            FullyRepaired = Str();
            Health = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_AfmuRepairs : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (AfmuRepairs)O;

                Variables.Record(Name + "_Name", Event.Module_Localised);
                Variables.Record(Name + "_Health", Event.Health);
                Variables.Record(Name + "_Item", Event.Module);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}
