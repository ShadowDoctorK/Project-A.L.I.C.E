using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Equipment;

namespace ALICE_Core
{
    public static class IEquipment
    {
        public static Equipment_General General = new Equipment_General();

        public static Equipment_CompositeScanner CompositeScanner = new Equipment_CompositeScanner();

        public static Equipment_DiscoveryScanner DiscoveryScanner = new Equipment_DiscoveryScanner();
        public static Equipment_DockingComputer DockingComputer = new Equipment_DockingComputer();

        public static Equipment_ExternalLights ExternalLights = new Equipment_ExternalLights();
        public static Equipment_ElectronicCountermeasure ElectronicCountermeasure = new Equipment_ElectronicCountermeasure();

        public static Equipment_FrameShiftDrive FrameShiftDrive = new Equipment_FrameShiftDrive();
        public static Equipment_FSDInterdictor FSDInterdictor = new Equipment_FSDInterdictor();

        public static Equipment_LimpetCollector LimpetCollector = new Equipment_LimpetCollector();
        public static Equipment_LimpetDecontamination LimpetDecontamination = new Equipment_LimpetDecontamination();
        public static Equipment_LimpetHatchBreaker LimpetHatchBreaker = new Equipment_LimpetHatchBreaker();
        public static Equipment_LimpetFuel LimpetFuel = new Equipment_LimpetFuel();
        public static Equipment_LimpetRecon LimpetRecon = new Equipment_LimpetRecon();
        public static Equipment_LimpetRepair LimpetRepair = new Equipment_LimpetRepair();
        public static Equipment_LimpetResearch LimpetResearch = new Equipment_LimpetResearch();
        public static Equipment_LimpetProspector LimpetProspector = new Equipment_LimpetProspector();

        public static Equipment_PulseWaveScanner PulseWaveScanner = new Equipment_PulseWaveScanner();

        public static Equipment_ShieldCellBank ShieldCellBank = new Equipment_ShieldCellBank();
        public static Equipment_SurfaceScanner SurfaceScanner = new Equipment_SurfaceScanner();
        public static Equipment_ShutdownFieldNeutraliser ShutdownFieldNeutraliser = new Equipment_ShutdownFieldNeutraliser();

        public static Equipment_WakeScanner WakeScanner = new Equipment_WakeScanner();

        public static Equipment_XenoScanner XenoScanner = new Equipment_XenoScanner();
    }

    public class Equipment_Base
    {
        public T New<T>() { return default(T); }
    }
}