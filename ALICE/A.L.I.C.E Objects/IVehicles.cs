using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Core;
using ALICE_Internal;

namespace ALICE_Objects
{
    /// <summary>
    /// Static Interface For Updateing Vehicle Properties.
    /// </summary>
    public static class IVehicles
    {
        public enum V
        {
            Default,
            Mothership,
            Fighter,
            SRV
        }
        
        private static V _Vehicle = V.Default;
        public static V Vehicle
        {
            get => _Vehicle;
            set => Set(value);
        }

        public static Checks C = new Checks();

        #region Support Methods  

        /// <summary>
        /// Updates the Private Property _Vechile, Then Updates the Equipment Settings To Match.
        /// </summary>
        /// <param name="Value">The Value Being Set</param>
        private static void Set(V Value)
        {
            //Set Value;
            _Vehicle = Value;

            //Update Equipment
            IEquipment.CompositeScanner.GetSettings();
            IEquipment.DiscoveryScanner.GetSettings();
            IEquipment.DockingComputer.GetSettings();
            IEquipment.ExternalLights.GetSettings();
            IEquipment.ElectronicCountermeasure.GetSettings();
            IEquipment.FighterHanger.GetSettings();
            IEquipment.FrameShiftDrive.GetSettings();
            IEquipment.FSDInterdictor.GetSettings();
            IEquipment.FuelTank.GetSettings();
            IEquipment.LimpetCollector.GetSettings();
            IEquipment.LimpetDecontamination.GetSettings();
            IEquipment.LimpetHatchBreaker.GetSettings();
            IEquipment.LimpetFuel.GetSettings();
            IEquipment.LimpetProspector.GetSettings();
            IEquipment.LimpetRecon.GetSettings();
            IEquipment.LimpetRepair.GetSettings();
            IEquipment.LimpetResearch.GetSettings();
            IEquipment.PulseWaveScanner.GetSettings();
            IEquipment.ShieldCellBank.GetSettings();
            IEquipment.ShutdownFieldNeutraliser.GetSettings();
            IEquipment.SurfaceScanner.GetSettings();
            IEquipment.WakeScanner.GetSettings();
            IEquipment.XenoScanner.GetSettings();
        }

        #region Fuel Status Methods
        /// <summary>
        /// Gets the Current Vehicles Main Fuel Tank Level.
        /// </summary>
        /// <returns>Fuel Level</returns>
        public static decimal GetFuelMain()
        {
            decimal Temp = -1; switch (Vehicle)
            {
                case V.Mothership:
                    Temp = IObjects.Mothership.F.Main;
                    break;
                case V.Fighter:
                    Temp = IObjects.Fighter.F.Main;
                    break;
                case V.SRV:
                    Temp = IObjects.SRV.F.Main;
                    break;
                default:
                    break;
            }
            return Temp;
        }

        /// <summary>
        /// Sets the Current Vehicles Main Fuel Tank Level.
        /// </summary>        
        public static void SetFuelMain(decimal Value)
        {
            switch (Vehicle)
            {
                case V.Mothership:
                    IObjects.Mothership.F.Main = Value;
                    break;
                case V.Fighter:
                    IObjects.Fighter.F.Main = Value;
                    break;
                case V.SRV:
                    IObjects.SRV.F.Main = Value;
                    break;
                default:
                    break;
            }            
        }

        /// <summary>
        /// Sets the Current Vehicles Fuel Reservoir Level.
        /// </summary>        
        public static void SetFuelReservoir(decimal Value)
        {
            switch (Vehicle)
            {
                case V.Mothership:
                    IObjects.Mothership.F.Reservoir = Value;
                    break;
                case V.Fighter:
                    IObjects.Fighter.F.Reservoir = Value;
                    break;
                case V.SRV:
                    IObjects.SRV.F.Reservoir = Value;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Method used by the Json Reader to Update Fuel Levels.
        /// </summary>
        /// <param name="Value">FuelInfo Object</param>
        public static void SetFuelLevels(ALICE_Events.FuelInfo Value)
        {
            switch (Vehicle)
            {
                case V.Mothership:
                    IObjects.Mothership.F.Update(Value);
                    break;
                case V.Fighter:
                    IObjects.Fighter.F.Update(Value);
                    break;
                case V.SRV:
                    IObjects.SRV.F.Update(Value);
                    break;
                default:
                    break;
            }
        }

        //End: Fuel Status Methods
        #endregion

        #region Equipment Config Methods
        /// <summary>
        /// Will get the Target Equipment Config based on the Current Vehicle
        /// </summary>
        /// <param name="Equip">Target Equipment</param>
        /// <returns>Will Return the Equipment's settings, or Default if it doesn't exist.</returns>
        public static EquipmentConfig Get(IEquipment.E Equip)
        {
            string MethodName = "Vehcile Interface (Get Equipment Config)";

            EquipmentConfig Temp = new EquipmentConfig(); switch (Vehicle)
            {
                case V.Default:

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Vehcile Has Not Been Set, Returning Default Config", Logger.Blue);

                    //Return Default Config Settings
                    return Temp;

                case V.Mothership:

                    //Get Settings From Mothership
                    Temp = IObjects.Mothership.E.Settings.Get(Equip);

                    //Check If Default Settings Were Returned.
                    if (Temp.Equipment == IEquipment.E.Default)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": Returning Default Config", Logger.Blue);
                    }
                    //Equipment Setting Were Returned.
                    else
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": Returning " + Equip + " Config", Logger.Blue);
                    }
                    
                    //Return Settings
                    return Temp;
                    
                case V.Fighter:

                    //Get Settings From Mothership
                    Temp = IObjects.Fighter.E.Settings.Get(Equip);

                    //Check If Default Settings Were Returned.
                    if (Temp.Equipment == IEquipment.E.Default)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": Returning Default Config", Logger.Blue);
                    }
                    //Equipment Setting Were Returned.
                    else
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": Returning " + Equip + " Config", Logger.Blue);
                    }

                    //Return Settings
                    return Temp;

                case V.SRV:

                    //Get Settings From Mothership
                    Temp = IObjects.SRV.E.Settings.Get(Equip);

                    //Check If Default Settings Were Returned.
                    if (Temp.Equipment == IEquipment.E.Default)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": Returning Default Config", Logger.Blue);
                    }
                    //Equipment Setting Were Returned.
                    else
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": Returning " + Equip + " Config", Logger.Blue);
                    }

                    //Return Settings
                    return Temp;

                default:

                    //Debug Logger
                    Logger.Error(MethodName, "Returned Using The Default Swtich, Returning Default Config", Logger.Blue);

                    //Return Default Config Settings
                    return Temp;
            }
        }

        /// <summary>
        /// Will Set the Target Equipment Config based on the Current Vehicle
        /// </summary>
        /// <param name="C">Equipment Config Object</param>
        /// <returns>True if Saved, False if Failed to Save.</returns>
        public static bool Set(EquipmentConfig C)
        {
            string MethodName = "Vehcile Interface (Set Equipment Config)";

            bool Temp = false; switch (Vehicle)
            {
                case V.Default:

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Vehcile Has Not Been Set, " + C.Equipment + " Config Failed To Saved", Logger.Blue);

                    //Return False
                    return Temp;

                case V.Mothership:

                    //Set Settings From Mothership
                    Temp = IObjects.Mothership.E.Settings.Set(C);

                    //Check If Settings Were Set
                    if (Temp)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": " + C.Equipment + " Config Saved", Logger.Blue);
                    }
                    //Settings Not Saved
                    else
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": " + C.Equipment + " Config Failed To Saved", Logger.Blue);
                    }

                    //Return True / False
                    return Temp;

                case V.Fighter:

                    //Set Settings From Mothership
                    Temp = IObjects.Fighter.E.Settings.Set(C);

                    //Check If Settings Were Set
                    if (Temp)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": " + C.Equipment + " Config Saved", Logger.Blue);
                    }
                    //Settings Not Saved
                    else
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": " + C.Equipment + " Config Failed To Saved", Logger.Blue);
                    }

                    //Return True / False
                    return Temp;

                case V.SRV:

                    //Set Settings From Mothership
                    Temp = IObjects.SRV.E.Settings.Set(C);

                    //Check If Settings Were Set
                    if (Temp)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": " + C.Equipment + " Config Saved", Logger.Blue);
                    }
                    //Settings Not Saved
                    else
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, Vehicle + ": " + C.Equipment + " Config Failed To Saved", Logger.Blue);
                    }

                    //Return True / False
                    return Temp;

                default:

                    //Debug Logger
                    Logger.Error(MethodName, "Returned Using The Default Swtich, Faile To Save Config", Logger.Blue);

                    //Return False
                    return Temp;
            }
        }

        /// <summary>
        /// Will Check the Target Equipment Config exist based on the Current Vehicle.
        /// </summary>
        /// <param name="Equip">Target Equipment</param>
        /// <returns>Default = Vehicle Not Set, Positive, Negative, or Error</returns>
        public static IEnums.A Exists(IEquipment.E Equip)
        {
            switch (Vehicle)
            {
                case V.Default:

                    //Vehcile Not Set, Return Default
                    return IEnums.A.Default;

                case V.Mothership:

                    //Check Mothership & Return Answer
                    return IObjects.Mothership.E.Settings.Exists(Equip);
                    
                case V.Fighter:

                    //Check Fighter & Return Answer
                    return IObjects.Fighter.E.Settings.Exists(Equip);

                case V.SRV:

                    //Check SRV & Return Answer
                    return IObjects.SRV.E.Settings.Exists(Equip);

                default:

                    //Return Error
                    return IEnums.A.Error;
            }
        }

        /// <summary>
        /// Will check if the Target Equipment is Installed for the current vehicle.
        /// </summary>
        /// <param name="Equip">Target Equipment</param>
        /// <returns>True if installed, False if not installed</returns>
        public static bool Installed(IEquipment.E Equip)
        {
            //Get Equipment Settings.
            var Temp = Get(Equip);

            //Check If Default Settings.
            if (Temp.Equipment == IEquipment.E.Default) { return false; }

            //Not Default Settings, Return Value
            else { return Temp.Installed; }            
        }

        /// <summary>
        /// Will check if the Target Equipment is Enabled for the current vehicle.
        /// </summary>
        /// <param name="Equip">Target Equipment</param>
        /// <returns>True if Enabled, False if not Enabled</returns>
        public static bool Enabled(IEquipment.E Equip)
        {
            //Get Equipment Settings.
            var Temp = Get(Equip);

            //Check If Default Settings.
            if (Temp.Equipment == IEquipment.E.Default) { return false; }

            //Not Default Settings, Return Value
            else { return Temp.Enabled; }
        }

        /// <summary>
        /// Will check if the Target Equipment's Total Property for the current vehicle.
        /// </summary>
        /// <param name="Equip">Target Equipment</param>
        /// <returns>Properties Value, or -1 if Not Set</returns>
        public static decimal Total(IEquipment.E Equip)
        {
            //Get Equipment Settings.
            var Temp = Get(Equip);

            //Check If Default Settings.
            if (Temp.Equipment == IEquipment.E.Default) { return -1; }

            //Not Default Settings, Return Value
            else { return Temp.Total; }
        }

        /// <summary>
        /// Will check if the Target Equipment's Capacity Property for the current vehicle.
        /// </summary>
        /// <param name="Equip">Target Equipment</param>
        /// <returns>Properties Value, or -1 if Not Set</returns>
        public static decimal Capacity(IEquipment.E Equip)
        {
            //Get Equipment Settings.
            var Temp = Get(Equip);

            //Check If Default Settings.
            if (Temp.Equipment == IEquipment.E.Default) { return -1; }

            //Not Default Settings, Return Value
            else { return Temp.Capacity; }
        }

        /// <summary>
        /// Will check if the Target Equipment's HUD Mode for the current vehicle.
        /// </summary>
        /// <param name="Equip">Target Equipment</param>
        /// <returns>Default = Not Set, Both, Analysis or Combat</returns>
        public static IEquipment.M Mode(IEquipment.E Equip)
        {
            //Get Equipment Settings.
            var Temp = Get(Equip);

            //Check If Default Settings.
            if (Temp.Equipment == IEquipment.E.Default) { return IEquipment.M.Default; }

            //Not Default Settings, Return Value
            else { return Temp.Mode; }
        }
        
        //End:Equipment Config Methods
        #endregion

        //End: Support Methods
        #endregion

        public class Checks
        {

        }
    }
}
