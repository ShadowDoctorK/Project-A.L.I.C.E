using ALICE_Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALICE_Objects
{
    public class Object_StellarBody : Object_Base
    {
        #region Properties
        public string Name { get; set; }
        public decimal ID { get; set; }
        public string BodyType { get; set; }
        public string ScanType { get; set; }
        public bool SurfaceScanned { get; set; }
        public List<Parent> Parents { get; set; }
        public decimal DistFromArrival { get; set; }
        public bool TidalLock { get; set; }
        public string TerraformState { get; set; }
        public string PlanetClass { get; set; }
        public string Atmosphere { get; set; }
        public string AtmosphereType { get; set; }
        public List<AirComposite> AtmosphereComposition { get; set; }
        public string Volcanism { get; set; }
        public decimal MassEM { get; set; }
        public string StarType { get; set; }
        public decimal StellarMass { get; set; }
        public decimal Radius { get; set; }
        public decimal Gravity { get; set; }
        public decimal AbsoluteMagnitude { get; set; }
        public decimal Age { get; set; }
        public decimal Temperature { get; set; }
        public decimal Pressure { get; set; }
        public bool Landable { get; set; }
        public List<Material> Materials { get; set; }
        public LandComposite Composition { get; set; }
        public string Luminosity { get; set; }
        public decimal SemiMajorAxis { get; set; }
        public decimal Eccentricity { get; set; }
        public decimal OrbitalInclination { get; set; }
        public decimal Periapsis { get; set; }
        public decimal OrbitalPeriod { get; set; }
        public decimal RotationPeriod { get; set; }
        public decimal AxialTilt { get; set; }
        public List<Ring> Rings { get; set; }
        public string ReserveLevel { get; set; }
        #endregion

        public Object_StellarBody()
        {
            ModfyingEvent = Default.String;
            EventTimeStamp = Default.DTime;
            Name = Default.String;
            ID = Default.Decimal;
            BodyType = Default.String;
            ScanType = Default.String;
            SurfaceScanned = Default.False;
            Parents = new List<Parent>();
            DistFromArrival = Default.Decimal;
            TidalLock = Default.False;
            TerraformState = Default.String;
            PlanetClass = Default.String;
            Atmosphere = Default.String;
            AtmosphereType = Default.String;
            AtmosphereComposition = new List<AirComposite>();
            Volcanism = Default.String;
            MassEM = Default.Decimal;
            StarType = Default.String;
            StellarMass = Default.Decimal;
            Radius = Default.Decimal;
            Gravity = Default.Decimal;
            AbsoluteMagnitude = Default.Decimal;
            Age = Default.Decimal;
            Temperature = Default.Decimal;
            Pressure = Default.Decimal;
            Landable = Default.False;
            Materials = new List<Material>();
            Composition = new LandComposite();
            Luminosity = Default.String;
            SemiMajorAxis = Default.Decimal;
            Eccentricity = Default.Decimal;
            OrbitalInclination = Default.Decimal;
            Periapsis = Default.Decimal;
            OrbitalPeriod = Default.Decimal;
            RotationPeriod = Default.Decimal;
            Rings = new List<Ring>();
            ReserveLevel = Default.String;
        }

        #region Update Methods
        public void Update_ModfyingEvent(string Value) { this.ModfyingEvent = Value; }
        public void Update_EventTimeStamp(DateTime Value) { this.EventTimeStamp = Value; }

        public void Update_Name(string Value) { this.Name = IObjects.StringCheck(Value); }
        public void Update_ID(decimal Value) { this.ID = Value; }
        public void Update_ScanType(string Value) { this.ScanType = Value; }
        public void Update_DistFromArrival(decimal Value) { this.DistFromArrival = Value; }
        public void Update_TidalLock(bool Value) { this.TidalLock = Value; }
        public void Update_TerraformState(string Value) { this.TerraformState = IObjects.StringCheck(Value); }
        public void Update_PlanetClass(string Value) { this.PlanetClass = IObjects.StringCheck(Value); }
        public void Update_Atmosphere(string Value) { this.Atmosphere = IObjects.StringCheck(Value); }
        public void Update_AtmosphereType(string Value) { this.AtmosphereType = IObjects.StringCheck(Value); }
        public void Update_Volcanism(string Value) { this.Volcanism = IObjects.StringCheck(Value); }
        public void Update_MassEM(decimal Value) { this.MassEM = Value; }
        public void Update_StarType(string Value) { this.StarType = IObjects.StringCheck(Value); }
        public void Update_StellarMass(decimal Value) { this.StellarMass = Value; }
        public void Update_Radius(decimal Value) { this.Radius = Value; }
        public void Update_Gravity(decimal Value) { this.Gravity = Value/10; }                                     //Gravity's Decimal Is In The Wrong Position. Dividing By 10 To Correct.
        public void Update_AbsoluteMagnitude(decimal Value) { this.AbsoluteMagnitude = Value; }
        public void Update_Age(decimal Value) { this.Age = Value; }
        public void Update_Temperature(decimal Value) { this.Temperature = Value; }
        public void Update_Pressure(decimal Value) { this.Pressure = Value; }
        public void Update_Landable(bool Value) { this.Landable = Value; }
        public void Update_Luminosity(string Value) { this.Luminosity = IObjects.StringCheck(Value); }
        public void Update_SemiMajorAxis(decimal Value) { this.SemiMajorAxis = Value; }
        public void Update_Eccentricity(decimal Value) { this.Eccentricity = Value; }
        public void Update_OrbitalInclination(decimal Value) { this.OrbitalInclination = Value; }
        public void Update_Periapsis(decimal Value) { this.Periapsis = Value; }
        public void Update_OrbitalPeriod(decimal Value) { this.OrbitalPeriod = Value; }
        public void Update_RotationPeriod(decimal Value) { this.RotationPeriod = Value; }
        public void Update_AxialTilt(decimal Value) { this.AxialTilt = Value; }
        public void Update_ReserveLevel(string Value) { this.ReserveLevel = IObjects.StringCheck(Value); }
        public void Update_Parents(List<Scan.ScanParent> ParentsList)
        {
            this.Parents = new List<Parent>();

            foreach (var Item in ParentsList)
            {
                Parent Temp = new Parent()
                {
                    Null = Item.Null,
                    Planet = Item.Planet,
                    Star = Item.Star,
                    Ring = Item.Ring
                };
                Parents.Add(Temp);
            }
        }
        public void Update_AtmosphereComposition(List<Scan.ScanComposition> ScanCompositionsList)
        {
            this.AtmosphereComposition = new List<AirComposite>();
            foreach (var Item in ScanCompositionsList)
            {
                AirComposite Temp = new AirComposite()
                {
                    Name = Item.Name,
                    Percent = Item.Percent
                };
                AtmosphereComposition.Add(Temp);
            }
                        
        }
        public void Update_Materials(List<Scan.ScanMaterial> ScanMaterialsList)
        {
            this.Materials = new List<Material>();
            foreach (var Item in ScanMaterialsList)
            {
                Material Temp = new Material()
                {
                    Name = Item.Name,
                    Percent = Item.Percent
                };
                Materials.Add(Temp);
            }
        }
        public void Update_Composition(Scan.ScanComposite ScanCompositeItem)
        {
            Composition = new LandComposite()
            {
                Ice = ScanCompositeItem.Ice,
                Rock = ScanCompositeItem.Rock,
                Metal = ScanCompositeItem.Metal
            };
        }
        public void Update_Rings(List<Scan.ScanRings> ScanRingsList)
        {
            Rings = new List<Ring>();
            foreach (var Item in ScanRingsList)
            {
                Ring Temp = new Ring()
                {
                    Name = Item.Name,
                    Class = Item.RingClass,
                    Mass = Item.MassMT,
                    Outer = Item.OuterRad,
                    Inner = Item.InnerRad
                };
                Rings.Add(Temp);
            }
        }
        #endregion

        public class AirComposite
        {
            public string Name { get; set; }
            public decimal Percent { get; set; }

            public AirComposite()
            {
                Name = Default.String;
                Percent = Default.Decimal;
            }
        }

        public class Parent
        {
            public decimal Null { get; set; }
            public decimal Planet { get; set; }
            public decimal Star { get; set; }
            public decimal Ring { get; set; }

            public Parent()
            {
                Null = Default.Decimal;
                Planet = Default.Decimal;
                Star = Default.Decimal;
                Ring = Default.Decimal;
            }
        }

        public class Material
        {
            public string Name { get; set; }
            public decimal Percent { get; set; }

            public Material()
            {
                Name = Default.String;
                Percent = Default.Decimal;
            }
        }

        public class LandComposite
        {
            public decimal Ice { get; set; }
            public decimal Rock { get; set; }
            public decimal Metal { get; set; }

            public LandComposite()
            {
                Ice = Default.Decimal;
                Rock = Default.Decimal;
                Metal = Default.Decimal;
            }
        }

        public class Ring
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public decimal Mass { get; set; }
            public decimal Inner { get; set; }
            public decimal Outer { get; set; }

            public Ring()
            {
                Name = Default.String;
                Class = Default.String;
                Mass = Default.Decimal;
                Inner = Default.Decimal;
                Outer = Default.Decimal;
            }
        }
    }
}
