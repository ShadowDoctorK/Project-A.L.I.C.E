//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T04:54:56Z", "event":"FighterDestroyed" }

using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class FighterDestroyed : Base
    {
        //No Properties
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_FighterDestroyed : Event
    {
        //Plugin Logic Process
        public override void Process(object O)
        {
            try
            {
                var Event = (FighterDestroyed)O;

                //Fighter Destroyed Audio
                IStatus.Fighter.Response.Destroyed(
                    ICheck.Initialized(ClassName));    //Check Plugin Initialized

                //Update Status Object
                IStatus.Fighter.Update(Event);
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment(object O)
        {
            try
            {
                IStatus.Supercruise = false;
                IStatus.Hyperspace = false;
                IStatus.Touchdown = false;
                IStatus.Docking.Docked = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}