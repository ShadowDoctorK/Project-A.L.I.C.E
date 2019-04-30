namespace ALICE_Status
{
    public static partial class IStatus
    {
        public static SRV SRV { get; set; } = new SRV();
    }

    public class SRV
    {
        private readonly string C = "SRV";

        /// <summary>
        /// Allows tracking and control for updating older data version when updates occur.
        /// </summary>
        public string DataVersion = "1.0.0";                //Custom

        public decimal ID = 99;                             //Custom        
        public string Type = "SRV";                         //Custom        
        public decimal CargoCapacity = 2;                   //Custom
        public FuelData Fuel = new FuelData                 //Custom
        {
            Main = 0.45M,
            Reserve = 1
        };
        public string FingerPrint                           //Derived
        {
            get => ID + " " + Type + " (" + IStatus.Commander + ")";
        }

        //Cargo

        public SRV()
        {
            //No Logic
        }     
    }   
}