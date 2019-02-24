//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 11:56 PM
//Source Journal Line: { "timestamp":"2018-11-20T22:01:00Z", "event":"PowerplayLeave", "Power":"Zachary Hudson" }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_PowerplayLeave : Base
    {
        public string Power { get; set; }

        //Default Constructor
        public ASDF_PowerplayLeave()
        {
            Power = Str();
        }
    }
    
    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_PowerplayLeave : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (PowerplayLeave)O;

                Variables.Record(Name + "_Power", Event.Power);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}
