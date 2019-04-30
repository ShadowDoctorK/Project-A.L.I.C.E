#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Mothership Mothership { get; set; } = new Mothership();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Status;

    public class Mothership : Debug
    {
        private readonly string Item = "Mothership ";

        public ValueData Value = new ValueData();
        public FuelData Fuel = new FuelData();
        public Modules M = new Modules();

        public bool ID(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, Item + "(ID)", T, C, IStatus.Mothership.ID, L); }

        public bool Name(string M, bool T, string C, bool L = true)
        { return Evaluate(M, Item + "(Name)", T, C, IStatus.Mothership.Name, L); }

        public bool Type(string M, bool T, string C, bool L = true)
        { return Evaluate(M, Item + "(Type)", T, C, IStatus.Mothership.Type, L); }

        public bool Identifier(string M, bool T, string C, bool L = true)
        { return Evaluate(M, Item + "(Identifier)", T, C, IStatus.Mothership.Identifier, L); }

        public bool UnladenMass(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, Item + "(UnladenMass)", T, C, IStatus.Mothership.UnladenMass, L); }

        public bool CargoCapacity(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, Item + "(CargoCapacity)", T, C, IStatus.Mothership.CargoCapacity, L); }

        public bool MaxJumpRange(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, Item + "(MaxJumpRange)", T, C, IStatus.Mothership.MaxJumpRange, L); }

        public class ValueData : Debug
        {
            private readonly string Item = "Mothership Value ";

            public bool Total(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, Item + "(Total)", T, C, IStatus.Mothership.Value.Total, L); }

            public bool Hull(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, Item + "(Hull)", T, C, IStatus.Mothership.Value.Hull, L); }

            public bool Modules(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, Item + "(Modules)", T, C, IStatus.Mothership.Value.Modules, L); }

            public bool Rebuy(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, Item + "(Rebuy)", T, C, IStatus.Mothership.Value.Rebuy, L); }
        }

        public class FuelData : Debug
        {
            private readonly string Item = "Mothership Value ";

            public bool Main(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, Item + "(Main)", T, C, IStatus.Mothership.Fuel.Main, L); }

            public bool Reserve(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, Item + "(Reserve)", T, C, IStatus.Mothership.Fuel.Reserve, L); }

            public bool Critical(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Critical)", T, IStatus.Mothership.Fuel.Critical, L); }

            public bool Low(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Low)", T, IStatus.Mothership.Fuel.Low, L); }

            public bool HalfThreshold(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(HalfThreshold)", T, IStatus.Mothership.Fuel.HalfThreshold, L); }
        }

        public class Modules : Debug
        {
            private readonly string Item = "Mothership Modules ";
            
            public bool MiningLaser(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Mining Laser)", T, IStatus.Mothership.Module.MiningLaser.Installed, L); }

            public bool ApproachSuite(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Approach Suite)", T, IStatus.Mothership.Module.ApproachSuite.Installed, L); }

            public bool CargoRack(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Cargo Rack)", T, IStatus.Mothership.Module.CargoRack.Installed, L); }

            public bool DockingComputer(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Docking Computer)", T, IStatus.Mothership.Module.DockingComputer.Installed, L); }

            public bool FSDInterdictor(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(FSD Interdictor)", T, IStatus.Mothership.Module.FSDInterdictor.Installed, L); }

            public bool FuelScoop(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Fuel Scoop)", T, IStatus.Mothership.Module.FuelScoop.Installed, L); }

            public bool Shields(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Shields)", T, IStatus.Mothership.Module.Shields.Installed, L); }

            public bool PassengerCabin(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Passenger Cabin)", T, IStatus.Mothership.Module.PassengerCabin.Installed, L); }

            public bool Refinery(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Refinery)", T, IStatus.Mothership.Module.Refinery.Installed, L); }

            public bool ShieldCell(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Shield Cell)", T, IStatus.Mothership.Module.ShieldCell.Installed, L); }

            public bool CargoScanner(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Cargo Scanner)", T, IStatus.Mothership.Module.CargoScanner.Installed, L); }

            public bool SurfaceScanner(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Surface Scanner)", T, IStatus.Mothership.Module.SurfaceScanner.Installed, L); }

            public bool FighterHangar(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Fighte rHangar)", T, IStatus.Mothership.Module.FighterHangar.Installed, L); }

            public bool FighterHangarTotal(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, Item + "(Fighter Hangar Total)", T, C, IStatus.Mothership.Module.FighterHangar.Total, L); }

            public bool VehicleHangar(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Refinery)", T, IStatus.Mothership.Module.Refinery.Installed, L); }
        
            public bool VehicleHangarTotal(string M, bool T, decimal C, bool L = true)
            { return Evaluate(M, Item + "(Vehicle Hangar Total)", T, C, IStatus.Mothership.Module.VehicleHangar.Total, L); }

            public bool CollectorLimpet(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Collector Limpet)", T, IStatus.Mothership.Module.CollectorLimpet.Installed, L); }

            public bool DecontaminationLimpet(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Decontamination Limpet)", T, IStatus.Mothership.Module.DecontaminationLimpet.Installed, L); }

            public bool FuelLimpet(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Refinery)", T, IStatus.Mothership.Module.FuelLimpet.Installed, L); }

            public bool HatchBreakerLimpet(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Hatch Breaker Limpet)", T, IStatus.Mothership.Module.HatchBreakerLimpet.Installed, L); }

            public bool ProspectorLimpet(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Prospector Limpet)", T, IStatus.Mothership.Module.ProspectorLimpet.Installed, L); }

            public bool ReconLimpet(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(ReconLimpet)", T, IStatus.Mothership.Module.ReconLimpet.Installed, L); }

            public bool RepairLimpet(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Repair Limpet)", T, IStatus.Mothership.Module.RepairLimpet.Installed, L); }

            public bool ResearchLimpet(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Research Limpet)", T, IStatus.Mothership.Module.ResearchLimpet.Installed, L); }

            public bool ECM(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(ECM)", T, IStatus.Mothership.Module.ECM.Installed, L); }

            public bool Chaff(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Chaff)", T, IStatus.Mothership.Module.Chaff.Installed, L); }

            public bool HeatSink(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Heatsink)", T, IStatus.Mothership.Module.HeatSink.Installed, L); }

            public bool FieldNeutraliser(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Field Neutraliser)", T, IStatus.Mothership.Module.FieldNeutraliser.Installed, L); }

            public bool KillWarrantScanner(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Kill Warrant Scanner)", T, IStatus.Mothership.Module.KillWarrantScanner.Installed, L); }

            public bool PulseWaveAnalyser(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Pulse Wave Analyser)", T, IStatus.Mothership.Module.PulseWaveAnalyser.Installed, L); }

            public bool XenoScanner(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Xeno Scanner)", T, IStatus.Mothership.Module.XenoScanner.Installed, L); }

            public bool WakeScanner(string M, bool T, bool L = true)
            { return Evaluate(M, Item + "(Wake Scanner)", T, IStatus.Mothership.Module.WakeScanner.Installed, L); }
        }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static Mothership Mothership { get; set; } = new Mothership();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Status;

    public class Mothership : Debug
    {
        private readonly string Item = "Mothership ";

        public ValueData Value = new ValueData();
        public FuelData Fuel = new FuelData();
        public Modules M = new Modules();

        public decimal ID(string M, bool L = true)
        { return Get(M, Item + "(ID)", IStatus.Mothership.ID, L); }

        public string Name(string M, bool L = true)
        { return Get(M, Item + "(Name)", IStatus.Mothership.Name, L); }

        public string Type(string M, bool L = true)
        { return Get(M, Item + "(Type)", IStatus.Mothership.Type, L); }

        public string Identifier(string M, bool L = true)
        { return Get(M, Item + "(Identifier)", IStatus.Mothership.Identifier, L); }

        public decimal UnladenMass(string M, bool L = true)
        { return Get(M, Item + "(UnladenMass)", IStatus.Mothership.UnladenMass, L); }

        public decimal CargoCapacity(string M, bool L = true)
        { return Get(M, Item + "(CargoCapacity)", IStatus.Mothership.CargoCapacity, L); }

        public decimal MaxJumpRange(string M, bool L = true)
        { return Get(M, Item + "(MaxJumpRange)", IStatus.Mothership.MaxJumpRange, L); }

        public class ValueData : Debug
        {
            private readonly string Item = "Mothership Value ";

            public decimal Total(string M, bool L = true)
            { return Get(M, Item + "(Total)", IStatus.Mothership.Value.Total, L); }

            public decimal Hull(string M, bool L = true)
            { return Get(M, Item + "(Hull)", IStatus.Mothership.Value.Hull, L); }

            public decimal Modules(string M, bool L = true)
            { return Get(M, Item + "(Modules)", IStatus.Mothership.Value.Modules, L); }

            public decimal Rebuy(string M, bool L = true)
            { return Get(M, Item + "(Rebuy)", IStatus.Mothership.Value.Rebuy, L); }
        }

        public class FuelData : Debug
        {
            private readonly string Item = "Mothership Value ";

            public decimal Main(string M, bool L = true)
            { return Get(M, Item + "(Main)", IStatus.Mothership.Fuel.Main, L); }

            public decimal Reserve(string M, bool L = true)
            { return Get(M, Item + "(Reserve)", IStatus.Mothership.Fuel.Reserve, L); }

            public bool Critical(string M, bool L = true)
            { return Get(M, Item + "(Critical)", IStatus.Mothership.Fuel.Critical, L); }

            public bool Low(string M, bool L = true)
            { return Get(M, Item + "(Low)", IStatus.Mothership.Fuel.Low, L); }

            public bool HalfThreshold(string M, bool L = true)
            { return Get(M, Item + "(HalfThreshold)", IStatus.Mothership.Fuel.HalfThreshold, L); }
        }

        public class Modules : Debug
        {
            private readonly string Item = "Mothership Modules ";

            public bool MiningLaser(string M, bool L = true)
            { return Get(M, Item + "(Mining Laser)", IStatus.Mothership.Module.MiningLaser.Installed, L); }

            public bool ApproachSuite(string M, bool L = true)
            { return Get(M, Item + "(Approach Suite)", IStatus.Mothership.Module.ApproachSuite.Installed, L); }

            public bool CargoRack(string M, bool L = true)
            { return Get(M, Item + "(Cargo Rack)", IStatus.Mothership.Module.CargoRack.Installed, L); }

            public bool DockingComputer(string M, bool L = true)
            { return Get(M, Item + "(Docking Computer)", IStatus.Mothership.Module.DockingComputer.Installed, L); }

            public bool FSDInterdictor(string M, bool L = true)
            { return Get(M, Item + "(FSD Interdictor)", IStatus.Mothership.Module.FSDInterdictor.Installed, L); }

            public bool FuelScoop(string M, bool L = true)
            { return Get(M, Item + "(Fuel Scoop)", IStatus.Mothership.Module.FuelScoop.Installed, L); }

            public bool Shields(string M, bool L = true)
            { return Get(M, Item + "(Shields)", IStatus.Mothership.Module.Shields.Installed, L); }

            public bool PassengerCabin(string M, bool L = true)
            { return Get(M, Item + "(Passenger Cabin)", IStatus.Mothership.Module.PassengerCabin.Installed, L); }

            public bool Refinery(string M, bool L = true)
            { return Get(M, Item + "(Refinery)", IStatus.Mothership.Module.Refinery.Installed, L); }

            public bool ShieldCell(string M, bool L = true)
            { return Get(M, Item + "(Shield Cell)", IStatus.Mothership.Module.ShieldCell.Installed, L); }

            public bool CargoScanner(string M, bool L = true)
            { return Get(M, Item + "(Cargo Scanner)", IStatus.Mothership.Module.CargoScanner.Installed, L); }

            public bool SurfaceScanner(string M, bool L = true)
            { return Get(M, Item + "(Surface Scanner)", IStatus.Mothership.Module.SurfaceScanner.Installed, L); }

            public bool FighterHangar(string M, bool L = true)
            { return Get(M, Item + "(Fighte rHangar)", IStatus.Mothership.Module.FighterHangar.Installed, L); }

            public decimal FighterHangarTotal(string M, bool L = true)
            { return Get(M, Item + "(Fighter Hangar Total)", IStatus.Mothership.Module.FighterHangar.Total, L); }

            public bool VehicleHangar(string M, bool L = true)
            { return Get(M, Item + "(Refinery)", IStatus.Mothership.Module.Refinery.Installed, L); }

            public decimal VehicleHangarTotal(string M, bool L = true)
            { return Get(M, Item + "(Vehicle Hangar Total)", IStatus.Mothership.Module.VehicleHangar.Total, L); }

            public bool CollectorLimpet(string M, bool L = true)
            { return Get(M, Item + "(Collector Limpet)", IStatus.Mothership.Module.CollectorLimpet.Installed, L); }

            public bool DecontaminationLimpet(string M, bool L = true)
            { return Get(M, Item + "(Decontamination Limpet)", IStatus.Mothership.Module.DecontaminationLimpet.Installed, L); }

            public bool FuelLimpet(string M, bool L = true)
            { return Get(M, Item + "(Refinery)", IStatus.Mothership.Module.FuelLimpet.Installed, L); }

            public bool HatchBreakerLimpet(string M, bool L = true)
            { return Get(M, Item + "(Hatch Breaker Limpet)", IStatus.Mothership.Module.HatchBreakerLimpet.Installed, L); }

            public bool ProspectorLimpet(string M, bool L = true)
            { return Get(M, Item + "(Prospector Limpet)", IStatus.Mothership.Module.ProspectorLimpet.Installed, L); }

            public bool ReconLimpet(string M, bool L = true)
            { return Get(M, Item + "(ReconLimpet)", IStatus.Mothership.Module.ReconLimpet.Installed, L); }

            public bool RepairLimpet(string M, bool L = true)
            { return Get(M, Item + "(Repair Limpet)", IStatus.Mothership.Module.RepairLimpet.Installed, L); }

            public bool ResearchLimpet(string M, bool L = true)
            { return Get(M, Item + "(Research Limpet)", IStatus.Mothership.Module.ResearchLimpet.Installed, L); }

            public bool ECM(string M, bool L = true)
            { return Get(M, Item + "(ECM)", IStatus.Mothership.Module.ECM.Installed, L); }

            public bool Chaff(string M, bool L = true)
            { return Get(M, Item + "(Chaff)", IStatus.Mothership.Module.Chaff.Installed, L); }

            public bool HeatSink(string M, bool L = true)
            { return Get(M, Item + "(Heatsink)", IStatus.Mothership.Module.HeatSink.Installed, L); }

            public bool FieldNeutraliser(string M, bool L = true)
            { return Get(M, Item + "(Field Neutraliser)", IStatus.Mothership.Module.FieldNeutraliser.Installed, L); }

            public bool KillWarrantScanner(string M, bool L = true)
            { return Get(M, Item + "(Kill Warrant Scanner)", IStatus.Mothership.Module.KillWarrantScanner.Installed, L); }

            public bool PulseWaveAnalyser(string M, bool L = true)
            { return Get(M, Item + "(Pulse Wave Analyser)", IStatus.Mothership.Module.PulseWaveAnalyser.Installed, L); }

            public bool XenoScanner(string M, bool L = true)
            { return Get(M, Item + "(Xeno Scanner)", IStatus.Mothership.Module.XenoScanner.Installed, L); }

            public bool WakeScanner(string M, bool L = true)
            { return Get(M, Item + "(Wake Scanner)", IStatus.Mothership.Module.WakeScanner.Installed, L); }
        }
    }
}
#endregion

#region ISet
namespace ALICE_Debug
{
    using ALICE_DebugSet;

    public static partial class ISet
    {
        public static Mothership Mothership { get; set; } = new Mothership();
    }
}

namespace ALICE_DebugSet
{
    using ALICE_Debug;
    using ALICE_Status;

    public class Mothership : Debug
    {
        private readonly string Item = "Mothership ";

        public Modules M = new Modules();

        public class Modules : Debug
        {
            private readonly string Item = "Mothership Modules ";
            
            public void MiningLaser(string M, bool V, bool L = true)
            { Set(M, Item + "(Mining Laser)", ref IStatus.Mothership.Module.MiningLaser.Installed, V, L); }

            public void ApproachSuite(string M, bool V, bool L = true)
            { Set(M, Item + "(Approach Suite)", ref IStatus.Mothership.Module.ApproachSuite.Installed, V, L); }

            public void CargoRack(string M, bool V, bool L = true)
            { Set(M, Item + "(Cargo Rack)", ref IStatus.Mothership.Module.CargoRack.Installed, V, L); }

            public void DockingComputer(string M, bool V, bool L = true)
            { Set(M, Item + "(Docking Computer)", ref IStatus.Mothership.Module.DockingComputer.Installed, V, L); }

            public void FSDInterdictor(string M, bool V, bool L = true)
            { Set(M, Item + "(FSD Interdictor)", ref IStatus.Mothership.Module.FSDInterdictor.Installed, V, L); }

            public void FuelScoop(string M, bool V, bool L = true)
            { Set(M, Item + "(Fuel Scoop)", ref IStatus.Mothership.Module.FuelScoop.Installed, V, L); }

            public void Shields(string M, bool V, bool L = true)
            { Set(M, Item + "(Shields)", ref IStatus.Mothership.Module.Shields.Installed, V, L); }

            public void PassengerCabin(string M, bool V, bool L = true)
            { Set(M, Item + "(Passenger Cabin)", ref IStatus.Mothership.Module.PassengerCabin.Installed, V, L); }

            public void Refinery(string M, bool V, bool L = true)
            { Set(M, Item + "(Refinery)", ref IStatus.Mothership.Module.Refinery.Installed, V, L); }

            public void ShieldCell(string M, bool V, bool L = true)
            { Set(M, Item + "(Shield Cell)", ref IStatus.Mothership.Module.ShieldCell.Installed, V, L); }

            public void CargoScanner(string M, bool V, bool L = true)
            { Set(M, Item + "(Cargo Scanner)", ref IStatus.Mothership.Module.CargoScanner.Installed, V, L); }

            public void SurfaceScanner(string M, bool V, bool L = true)
            { Set(M, Item + "(Surface Scanner)", ref IStatus.Mothership.Module.SurfaceScanner.Installed, V, L); }

            public void FighterHangar(string M, bool V, bool L = true)
            { Set(M, Item + "(Fighte rHangar)", ref IStatus.Mothership.Module.FighterHangar.Installed, V, L); }

            public void FighterHangarTotal(string M, decimal V, bool L = true)
            { Set(M, Item + "(Fighter Hangar Total)", ref IStatus.Mothership.Module.FighterHangar.Total, V, L); }

            public void VehicleHangar(string M, bool V, bool L = true)
            { Set(M, Item + "(Refinery)", ref IStatus.Mothership.Module.Refinery.Installed, V, L); }
        
            public void VehicleHangarTotal(string M, decimal V, bool L = true)
            { Set(M, Item + "(Vehicle Hangar Total)", ref IStatus.Mothership.Module.VehicleHangar.Total, V, L); }

            public void CollectorLimpet(string M, bool V, bool L = true)
            { Set(M, Item + "(Collector Limpet)", ref IStatus.Mothership.Module.CollectorLimpet.Installed, V, L); }

            public void DecontaminationLimpet(string M, bool V, bool L = true)
            { Set(M, Item + "(Decontamination Limpet)", ref IStatus.Mothership.Module.DecontaminationLimpet.Installed, V, L); }

            public void FuelLimpet(string M, bool V, bool L = true)
            { Set(M, Item + "(Refinery)", ref IStatus.Mothership.Module.FuelLimpet.Installed, V, L); }

            public void HatchBreakerLimpet(string M, bool V, bool L = true)
            { Set(M, Item + "(Hatch Breaker Limpet)", ref IStatus.Mothership.Module.HatchBreakerLimpet.Installed, V, L); }

            public void ProspectorLimpet(string M, bool V, bool L = true)
            { Set(M, Item + "(Prospector Limpet)", ref IStatus.Mothership.Module.ProspectorLimpet.Installed, V, L); }

            public void ReconLimpet(string M, bool V, bool L = true)
            { Set(M, Item + "(ReconLimpet)", ref IStatus.Mothership.Module.ReconLimpet.Installed, V, L); }

            public void RepairLimpet(string M, bool V, bool L = true)
            { Set(M, Item + "(Repair Limpet)", ref IStatus.Mothership.Module.RepairLimpet.Installed, V, L); }

            public void ResearchLimpet(string M, bool V, bool L = true)
            { Set(M, Item + "(Research Limpet)", ref IStatus.Mothership.Module.ResearchLimpet.Installed, V, L); }

            public void ECM(string M, bool V, bool L = true)
            { Set(M, Item + "(ECM)", ref IStatus.Mothership.Module.ECM.Installed, V, L); }

            public void Chaff(string M, bool V, bool L = true)
            { Set(M, Item + "(Chaff)", ref IStatus.Mothership.Module.Chaff.Installed, V, L); }

            public void HeatSink(string M, bool V, bool L = true)
            { Set(M, Item + "(Heatsink)", ref IStatus.Mothership.Module.HeatSink.Installed, V, L); }

            public void FieldNeutraliser(string M, bool V, bool L = true)
            { Set(M, Item + "(Field Neutraliser)", ref IStatus.Mothership.Module.FieldNeutraliser.Installed, V, L); }

            public void KillWarrantScanner(string M, bool V, bool L = true)
            { Set(M, Item + "(Kill Warrant Scanner)", ref IStatus.Mothership.Module.KillWarrantScanner.Installed, V, L); }

            public void PulseWaveAnalyser(string M, bool V, bool L = true)
            { Set(M, Item + "(Pulse Wave Analyser)", ref IStatus.Mothership.Module.PulseWaveAnalyser.Installed, V, L); }

            public void XenoScanner(string M, bool V, bool L = true)
            { Set(M, Item + "(Xeno Scanner)", ref IStatus.Mothership.Module.XenoScanner.Installed, V, L); }

            public void WakeScanner(string M, bool V, bool L = true)
            { Set(M, Item + "(Wake Scanner)", ref IStatus.Mothership.Module.WakeScanner.Installed, V, L); }
        }
    }
}
#endregion
