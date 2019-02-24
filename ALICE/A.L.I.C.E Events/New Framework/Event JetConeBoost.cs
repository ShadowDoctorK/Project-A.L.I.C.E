//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 12/20/2018 8:58 PM
//Source Journal Line: { "timestamp":"2018-12-20T20:56:52Z", "event":"JetConeBoost", "BoostValue":1.500000 }

using ALICE_Core;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class ASDF_JetConeBoost : Base
    {
        public decimal BoostValue { get; set; }

        //Default Constructor
        public ASDF_JetConeBoost()
        {
            BoostValue = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class QWER_JetConeBoost : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (JetConeBoost)O;

                Variables.Record(Name + "_Amount", Event.BoostValue);
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
                IStatus.Planet.OrbitalMode = false;
                IStatus.Planet.DecentReport = false;
                IStatus.Touchdown = false;
                IStatus.Docking.Docked = false;
                IStatus.LandingGear = false;
                IStatus.CargoScoop = false;
                IStatus.Fighter.Deployed = false;
                IStatus.Hardpoints = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }
        }
    }
}