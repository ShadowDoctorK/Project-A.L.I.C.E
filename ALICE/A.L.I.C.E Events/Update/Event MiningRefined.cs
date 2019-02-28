//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/22/2018 12:26 AM
//Source Journal Line: { "timestamp":"2018-11-22T03:02:28Z", "event":"MiningRefined", "Type":"$bauxite_name;", "Type_Localised":"Bauxite" }

using ALICE_Core;
using ALICE_Debug;
using ALICE_Internal;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class MiningRefined : Base
    {
        public string Type { get; set; }
        public string Type_Localised { get; set; }

        //Default Constructor
        public MiningRefined()
        {
            Type = Str();
            Type_Localised = Str();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_MiningRefined : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (MiningRefined)O;

                Variables.Switch(Name + "_Type", Event.Type_Localised, Event.Type);
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
                var Event = (MiningRefined)O;

                //Refined Audio
                IStatus.Cargo.Response.Refined(
                    Event.Type_Localised,                               //Material
                    ICheck.Initialized(ClassName),                      //Check Plugin Initialized
                    ICheck.Report.MaterialRefined(ClassName, true));    //Check Material Refined Report Enabled
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
                IStatus.Docking.Docked = false;
                IStatus.Planet.OrbitalMode = false;
                IStatus.Planet.DecentReport = false;
                IStatus.Supercruise = false;
                IStatus.Hyperspace = false;
                IStatus.Touchdown = false;
            }
            catch (Exception ex)
            {
                ExceptionAlignment(Name, ex);
            }           
        }
    }
}