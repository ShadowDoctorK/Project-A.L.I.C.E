//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-14T23:24:25Z", "event":"Touchdown", "PlayerControlled":true, "Latitude":-15.108141, "Longitude":-102.934616 }

using ALICE_Status;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Touchdown : Base
    {
        public string PlayerControlled { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        //Default Constructor
        public Touchdown()
        {
            PlayerControlled = Str();
            Latitude = Dec();
            Longitude = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_Touchdown : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (Touchdown)O;

                Variables.Switch(Name + "_Helm", Event.PlayerControlled, "Commander", "NPC");
                Variables.Record(Name + "_Latitude", Event.Latitude);
                Variables.Record(Name + "_Longitude", Event.Longitude);
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
                IStatus.WeaponSafety = false;
                IStatus.Hyperspace = false;
                IStatus.Supercruise = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}