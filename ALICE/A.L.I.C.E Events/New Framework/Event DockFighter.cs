//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-08T15:55:02Z", "event":"DockFighter" }

using ALICE_Core;
using ALICE_Internal;
using ALICE_Objects;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_DockFighter : Base
    {
        //No Properties
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_DockFighter : Event
    {
        //Plugin Logic Process
        public override void Process(object O)
        {
            try
            {
                var Event = (DockFighter)O;

                //Fighter Docked Audio
                IStatus.Fighter.Response.Docked(
                    Check.Internal.TriggerEvents(true, ClassName));    //Check Plugin Initialized
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
                IStatus.Fighter.Deployed = false;
                IStatus.Supercruise = false;
                IStatus.Hyperspace = false;
                IStatus.LandingGear = false;
                IStatus.Touchdown = false;
                IStatus.Docking.Docked = false;
                IStatus.Docking.State = IEnums.DockingState.Undocked;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}