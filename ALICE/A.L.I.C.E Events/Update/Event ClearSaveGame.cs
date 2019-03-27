//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/20/2018 11:56 PM
//Source Journal Line: { "timestamp":"2018-11-20T22:01:00Z", "event":"ClearSaveGame", "Name":"Test Commander" }

using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ClearSaveGame : Base
    {
        public decimal Name { get; set; }

        //Default Constructor
        public ClearSaveGame()
        {
            Name = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_ClearSaveGame : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (ClearSaveGame)O;

                Variables.Record(Name + "_Name", Event.Name);
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }
    }
}