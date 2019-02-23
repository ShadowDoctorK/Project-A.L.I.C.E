//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-28T15:54:58Z", "event":"EscapeInterdiction", "Interdictor":"Colin McCulloch", "IsPlayer":false }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_EscapeInterdiction : Base
    {
        public string Interdictor { get; set; }
        public string Interdictor_Localised { get; set; }
        public bool IsPlayer { get; set; }

        //Default Constructor
        public ASDF_EscapeInterdiction()
        {
            Interdictor = Str();
            Interdictor_Localised = Str();
            IsPlayer = Bool();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_EscapeInterdiction : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (EscapeInterdiction)O;

                //Pilots Name
                if (Event.Interdictor_Localised != "None")
                {
                    Variables.Record(Name + "_Pilot", Event.Interdictor_Localised);
                }
                else
                {
                    Variables.Record(Name + "_Pilot", Event.Interdictor);
                }

                //Pilot Type
                if (Event.IsPlayer)
                {
                    Variables.Record(Name + "_Type", "Commander");
                }
                else
                {
                    Variables.Record(Name + "_Type", "NPC");
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
                var Event = (EscapeInterdiction)O;
            }
            catch (Exception ex)
            {
                ExceptionProcess(ex);
            }
        }

        //Plugin Property Aligment
        public override void Alignment()
        {
            IStatus.Supercruise = true;
            IStatus.Hyperspace = false;
            IStatus.Touchdown = false;
            IStatus.Docked = false;
            IStatus.Hardpoints = false;
            IStatus.LandingGear = false;
            IStatus.CargoScoop = false;
            IStatus.Fighter.Deployed = false;
        }
    }
}
