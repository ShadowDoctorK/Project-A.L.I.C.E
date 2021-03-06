//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-28T15:54:58Z", "event":"EscapeInterdiction", "Interdictor":"Colin McCulloch", "IsPlayer":false }

using ALICE_Debug;
using ALICE_Status;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class EscapeInterdiction : Base
    {
        public string Interdictor { get; set; }
        public string Interdictor_Localised { get; set; }
        public bool IsPlayer { get; set; }

        //Default Constructor
        public EscapeInterdiction()
        {
            Interdictor = Str();
            Interdictor_Localised = Str();
            IsPlayer = Bool();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_EscapeInterdiction : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (EscapeInterdiction)O;

                Variables.Switch(Name + "_Pilot", Event.Interdictor_Localised, Event.Interdictor);
                Variables.Switch(Name + "_Type", Event.IsPlayer, "Commander", "NPC");
            }
            catch (Exception ex)
            {
                ExceptionGenerate(Name, ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment(object O)
        {
            try
            {
                IStatus.Supercruise = true;
                IStatus.Hyperspace = false;
                IStatus.Touchdown = false;
                IStatus.Docking.Docked = false;
                IStatus.Hardpoints = false;
                ISet.Status.LandingGear(ClassName, false);
                IStatus.CargoScoop = false;
                IStatus.Fighter.Deployed = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}
