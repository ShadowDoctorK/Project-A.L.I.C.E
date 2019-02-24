//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-28T18:51:15Z", "event":"NpcCrewPaidWage", "NpcCrewName":"Justine Schwarz", "NpcCrewId":101648352, "Amount":1099568 }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_NpcCrewPaidWage : Base
    {
        public string NpcCrewName { get; set; }
        public decimal NpcCrewId { get; set; }
        public decimal Amount { get; set; }

        //Default Constructor
        public ASDF_NpcCrewPaidWage()
        {
            NpcCrewName = Str();
            NpcCrewId = Dec();
            Amount = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_NpcCrewPaidWage : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (NpcCrewPaidWage)O;

                Variables.Record(Name + "_Name", Event.NpcCrewName);
                Variables.Record(Name + "_ID", Event.NpcCrewId);
                Variables.Record(Name + "_Credits", Event.Amount);
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
                var Event = (NpcCrewPaidWage)O;

                //Update Status Object
                IStatus.Crew.Update(Event);
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