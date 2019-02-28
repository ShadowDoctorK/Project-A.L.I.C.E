//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-14T23:20:55Z", "event":"Scan", "ScanType":"Detailed", "BodyName":"Col 173 Sector KY-Q d5-47 9 a", "BodyID":33, "Parents":[ {"Planet":31}, {"Null":30}, {"Star":0} ], "DistanceFromArrivalLS":1443.539429, "TidalLock":true, "TerraformState":"", "PlanetClass":"Rocky body", "Atmosphere":"", "AtmosphereType":"None", "Volcanism":"major silicate vapour geysers volcanism", "MassEM":0.004034, "Radius":1115522.125000, "SurfaceGravity":1.291939, "SurfaceTemperature":277.356445, "SurfacePressure":0.000000, "Landable":true, "Materials":[ { "Name":"iron", "Percent":20.781742 }, { "Name":"sulphur", "Percent":20.289942 }, { "Name":"carbon", "Percent":17.061741 }, { "Name":"nickel", "Percent":15.718439 }, { "Name":"phosphorus", "Percent":10.923221 }, { "Name":"germanium", "Percent":5.985801 }, { "Name":"selenium", "Percent":3.175548 }, { "Name":"arsenic", "Percent":2.676932 }, { "Name":"yttrium", "Percent":1.241269 }, { "Name":"tin", "Percent":1.237855 }, { "Name":"mercury", "Percent":0.907504 } ], "Composition":{ "Ice":0.000000, "Rock":0.910457, "Metal":0.089543 }, "SemiMajorAxis":467320096.000000, "Eccentricity":0.000644, "OrbitalInclination":-0.697309, "Periapsis":138.517532, "OrbitalPeriod":73245.484375, "RotationPeriod":69701.476563, "AxialTilt":-0.231764 }

using ALICE_Core;
using ALICE_Objects;
using System;
using System.Collections.Generic;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class Scan : Base
    {
        public string ScanType { get; set; }
        public string BodyName { get; set; }
        public decimal BodyID { get; set; }
        public List<ScanParent> Parents { get; set; }
        public decimal DistanceFromArrivalLS { get; set; }
        public bool TidalLock { get; set; }
        public string TerraformState { get; set; }
        public string PlanetClass { get; set; }
        public string Atmosphere { get; set; }
        public string AtmosphereType { get; set; }
        public List<ScanComposition> AtmosphereComposition { get; set; }
        public string Volcanism { get; set; }
        public decimal MassEM { get; set; }
        public string StarType { get; set; }
        public decimal StellarMass { get; set; }
        public decimal Radius { get; set; }
        public decimal SurfaceGravity { get; set; }
        public decimal AbsoluteMagnitude { get; set; }
        public decimal Age_MY { get; set; }
        public decimal SurfaceTemperature { get; set; }
        public decimal SurfacePressure { get; set; }
        public bool Landable { get; set; }
        public List<ScanMaterial> Materials { get; set; }
        public ScanComposite Composition { get; set; }
        public string Luminosity { get; set; }
        public decimal SemiMajorAxis { get; set; }
        public decimal Eccentricity { get; set; }
        public decimal OrbitalInclination { get; set; }
        public decimal Periapsis { get; set; }
        public decimal OrbitalPeriod { get; set; }
        public decimal RotationPeriod { get; set; }
        public decimal AxialTilt { get; set; }
        public List<ScanRings> Rings { get; set; }
        public string ReserveLevel { get; set; }

        //Default Constructor
        public Scan()
        {
            ScanType = Str();
            BodyName = Str();
            BodyID = Dec();
            Parents = new List<ScanParent>();
            DistanceFromArrivalLS = Dec();
            TidalLock = Bool();
            TerraformState = Str();
            PlanetClass = Str();
            Atmosphere = Str();
            AtmosphereType = Str();
            AtmosphereComposition = new List<ScanComposition>();
            Volcanism = Str();
            MassEM = Dec();
            StarType = Str();
            StellarMass = Dec();
            Radius = Dec();
            SurfaceGravity = Dec();
            AbsoluteMagnitude = Dec();
            Age_MY = Dec();
            SurfaceTemperature = Dec();
            SurfacePressure = Dec();
            Landable = Bool();
            Materials = new List<ScanMaterial>();
            Composition = new ScanComposite();
            Luminosity = Str();
            SemiMajorAxis = Dec();
            Eccentricity = Dec();
            OrbitalInclination = Dec();
            Periapsis = Dec();
            OrbitalPeriod = Dec();
            RotationPeriod = Dec();
            AxialTilt = Dec();
            Rings = new List<ScanRings>();
            ReserveLevel = Str();
        }

        public class ScanComposition : Catch
        {
            public string Name { get; set; }
            public decimal Percent { get; set; }

            public ScanComposition()
            {
                Name = Str();
                Percent = Dec();
            }
        }

        public class ScanParent : Catch
        {
            public decimal Null { get; set; }
            public decimal Planet { get; set; }
            public decimal Star { get; set; }
            public decimal Ring { get; set; }

            public ScanParent()
            {
                Null = Dec();
                Planet = Dec();
                Star = Dec();
                Ring = Dec();
            }
        }

        public class ScanMaterial : Catch
        {
            public string Name { get; set; }
            public decimal Percent { get; set; }

            public ScanMaterial()
            {
                Name = Str();
                Percent = Dec();
            }
        }

        public class ScanComposite : Catch
        {
            public decimal Ice { get; set; }
            public decimal Rock { get; set; }
            public decimal Metal { get; set; }

            public ScanComposite()
            {
                Ice = Dec();
                Rock = Dec();
                Metal = Dec();
            }
        }

        public class ScanRings : Catch
        {
            public string Name { get; set; }
            public string RingClass { get; set; }
            public decimal MassMT { get; set; }
            public decimal InnerRad { get; set; }
            public decimal OuterRad { get; set; }

            public ScanRings()
            {
                Name = Str();
                RingClass = Str();
                MassMT = Dec();
                InnerRad = Dec();
                OuterRad = Dec();
            }
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_Scan : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (Scan)O;

                Variables.Record(Name + "_Type", Event.ScanType);
                Variables.Record(Name + "_Name", Event.BodyName);
                Variables.Record(Name + "_ID", Event.BodyID);
                Variables.Record(Name + "_ArrivalDistance", Event.DistanceFromArrivalLS);
                Variables.Record(Name + "_TidalLock", Event.TidalLock);
                Variables.Record(Name + "_TerraformState", Event.TerraformState);
                Variables.Record(Name + "_PlanetClass", Event.PlanetClass);
                Variables.Record(Name + "_Atmosphere", Event.Atmosphere);
                Variables.Record(Name + "_AtmosphereType", Event.AtmosphereType);
                Variables.Record(Name + "_Volcanism", Event.Volcanism);
                Variables.Record(Name + "_MassEM", Event.MassEM);
                Variables.Record(Name + "_StarType", Event.StarType);
                Variables.Record(Name + "_StellarMass", Event.StellarMass);
                Variables.Record(Name + "_Radius", Event.Radius);
                Variables.Record(Name + "_SurfaceGravity", Event.SurfaceGravity);
                Variables.Record(Name + "_AbsoluteMagnitude", Event.AbsoluteMagnitude);
                Variables.Record(Name + "_Age_MY", Event.Age_MY);
                Variables.Record(Name + "_SurfaceTemperature", Event.SurfaceTemperature);
                Variables.Record(Name + "_SurfacePressure", Event.SurfacePressure);
                Variables.Record(Name + "_Landable", Event.Landable);
                Variables.Record(Name + "_Luminosity", Event.Luminosity);
                Variables.Record(Name + "_SemiMajorAxis", Event.SemiMajorAxis);
                Variables.Record(Name + "_Eccentricity", Event.Eccentricity);
                Variables.Record(Name + "_OrbitalInclination", Event.Landable);
                Variables.Record(Name + "_Periapsis", Event.Periapsis);
                Variables.Record(Name + "_OrbitalPeriod", Event.OrbitalPeriod);
                Variables.Record(Name + "_RotationPeriod", Event.RotationPeriod);
                Variables.Record(Name + "_AxialTilt", Event.AxialTilt);
                Variables.Record(Name + "_ReserveLevel", Event.ReserveLevel);
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
                var Event = (Scan)O;

                //Update Current System Information
                IObjects.SystemCurrent.Update_StellarBody(Event);

                //Evaluate Scan Data
                IStatus.Scan.Evaluate(Event.BodyID);
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}