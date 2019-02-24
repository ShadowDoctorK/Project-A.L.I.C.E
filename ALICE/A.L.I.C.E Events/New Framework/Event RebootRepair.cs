//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T04:28:34Z", "event":"RebootRepair", "Modules":[ "MainEngines", "Tinyhardpoint1" ] }

using System;
using System.Collections.Generic;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_RebootRepair : Base
    {
        public List<string> Modules { get; set; }

        //Default Constructor
        public ASDF_RebootRepair()
        {
            Modules = new List<string>();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_RebootRepair : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (RebootRepair)O;

                int C = 0; foreach (var Module in Event.Modules)
                {
                    Variables.Record(Name + "_Module" + C, Module);
                }
            }
            catch (Exception ex)
            {
                ExceptionGenerate(ex);
            }
        }

        //Plugin Logic Process
        public override void Process(object O)
        {
            try
            {
                var Event = (RebootRepair)O;
            }
            catch (Exception ex)
            {
                ExceptionProcess(ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment()
        {
            //No Updates
        }
    }
}