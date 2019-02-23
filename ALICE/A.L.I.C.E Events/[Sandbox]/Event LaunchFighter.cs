//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-02T04:16:49Z", "event":"LaunchFighter", "Loadout":"three", "PlayerControlled":false }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_LaunchFighter : Base
    {
        public string Loadout { get; set; }
        public bool PlayerControlled { get; set; }

        //Default Constructor
        public ASDF_LaunchFighter()
        {
            Loadout = Str();
            PlayerControlled = Bool();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_LaunchFighter : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (LaunchFighter)O;

                Variables.Record(Name + "_Loadout", Event.Loadout);
                Variables.Switch(Name + "_Pilot", Event.PlayerControlled, "Commander", "NPC");
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
                var Event = (LaunchFighter)O;

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
            IStatus.Supercruise = false;
            IStatus.Hyperspace = false;
            IStatus.Touchdown = false;
            IStatus.Docking.Docked = false;
            IStatus.LandingGear = false;            
        }
    }
}