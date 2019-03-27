//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 12/20/2018 9:05 PM
//Source Journal Line: { "timestamp":"2018-12-20T20:41:19Z", "event":"FSSAllBodiesFound", "SystemName":"Col 285 Sector MZ-D b13-6", "SystemAddress":13862678111625, "Count":3 }

using ALICE_Objects;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class FSSAllBodiesFound : Base
    {
        public string SystemName { get; set; }
        public decimal SystemAddress { get; set; }
        public decimal Count { get; set; }

        //Default Constructor
        public FSSAllBodiesFound()
        {
            SystemName = Str();
            SystemAddress = Dec();            
            Count = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_FSSAllBodiesFound : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (FSSAllBodiesFound)O;

                Variables.Record(Name + "_System", Event.SystemName);
                Variables.Record(Name + "_Address", Event.SystemAddress);
                Variables.Record(Name + "_Count", Event.Count);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }

        //Plugin Logic Process
        public override void Process(object O)
        {
            try
            {
                var Event = (FSSAllBodiesFound)O;

                //Update Current System Data
                IObjects.SystemCurrent.Update_SystemData(Event);
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}