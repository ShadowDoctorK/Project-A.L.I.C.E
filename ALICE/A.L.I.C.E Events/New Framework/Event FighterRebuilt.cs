//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T04:56:40Z", "event":"FighterRebuilt", "Loadout":"three" }

using ALICE_Core;
using ALICE_Internal;
using ALICE_Status;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_FighterRebuilt : Base
    {
        public string Loadout { get; set; }

        //Default Constructor
        public ASDF_FighterRebuilt()
        {
            Loadout = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_FighterRebuilt : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (FighterRebuilt)O;

                Variables.Record(Name + "_Loadout", Event.Loadout);
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
                var Event = (FighterRebuilt)O;

                //Fighter Rebuilt Audio
                switch (IStatus.Fighter.Status)
                {
                    case Status_Fighter.S.Docked:

                        //Fighter Rebuilt (Docked)
                        IStatus.Fighter.Response.RebuiltDocked(
                            Check.Internal.TriggerEvents(true, ClassName));    //Check Plugin Initialized

                        break;

                    case Status_Fighter.S.Destroyed:

                        //Fighter Rebuilt (Destroyed)
                        IStatus.Fighter.Response.RebuiltDestroyed(
                            Check.Internal.TriggerEvents(true, ClassName));    //Check Plugin Initialized

                        break;

                    default:

                        //Fighter Rebuilt (Other)
                        IStatus.Fighter.Response.RebuiltOther(
                            Check.Internal.TriggerEvents(true, ClassName));    //Check Plugin Initialized

                        break;
                }

                //Update Status Object
                IStatus.Fighter.Update(Event);
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