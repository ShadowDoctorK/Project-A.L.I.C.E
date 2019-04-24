using System.Collections.Generic;

namespace ALICE_Events
{
    public class Status : Base
    {
        public decimal Flags { get; set; }
        public List<decimal> Pips = new List<decimal>(new decimal[3]);
        public decimal FireGroup { get; set; }
        public decimal GuiFocus { get; set; }
        public FuelInfo Fuel { get; set; }
        public decimal Cargo { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Heading { get; set; }
        public decimal Altitude { get; set; }

        #region 2019.04.23 Update
        public string LegalStatus { get; set; }
        public string BodyName { get; set; }
        public decimal PlanetRadius { get; set; }
        #endregion

        public Status()
        {
            Flags = -1;
            Pips = new List<decimal>();
            FireGroup = -1;
            GuiFocus = -1;
            Fuel = new FuelInfo()
            {
                FuelMain = -1,
                FuelReservoir = -1
            };
            Cargo = -1;
            Latitude = -1;
            Longitude = -1;
            Heading = -1;
            Altitude = -1;

            #region 2019.04.23 Update
            LegalStatus = Str();
            BodyName = Str();
            PlanetRadius = Dec();
            #endregion
        }
    }
    
    public class FuelInfo : Base
    {
        public decimal FuelMain { get; set; }
        public decimal FuelReservoir { get; set; }

        public FuelInfo()
        {
            FuelMain = -1;
            FuelReservoir = -1;
        }
    }
}