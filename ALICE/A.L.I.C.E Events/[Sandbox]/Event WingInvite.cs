//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-03T03:52:30Z", "event":"WingInvite", "Name":"Alyssa Evanline" }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_WingInvite : Base
    {
        public string Name { get; set; }

        //Default Constructor
        public ASDF_WingInvite()
        {
            Name = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_WingInvite : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (WingInvite)O;

                Variables.Record(Name + "_Name", Event.Name);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}