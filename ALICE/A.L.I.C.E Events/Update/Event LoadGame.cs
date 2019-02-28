//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-14T04:10:51Z", "event":"LoadGame", "Commander":"Shadow Doctor K", "Horizons":true, "Ship":"Federation_Corvette", "Ship_Localised":"Federal Corvette", "ShipID":11, "ShipName":"MORNINGSTAR", "ShipIdent":"S-117", "FuelLevel":32.000000, "FuelCapacity":32.000000, "GameMode":"Group", "Group":"Shadow Doctor K", "Credits":298658411, "Loan":0 }

using ALICE_Actions;
using ALICE_Core;
using ALICE_Debug;
using ALICE_Equipment;
using ALICE_Internal;
using ALICE_Objects;
using ALICE_Settings;
using System;

namespace ALICE_Events
{
    /// <summary>
    /// Object Data Class
    /// </summary>
    public class LoadGame : Base
    {
        public string Commander { get; set; }
        public string FID { get; set; }
        public bool Horizons { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public decimal ShipID { get; set; }
        public string ShipName { get; set; }
        public string ShipIdent { get; set; }
        public decimal FuelLevel { get; set; }
        public decimal FuelCapacity { get; set; }
        public string GameMode { get; set; }
        public string Group { get; set; }
        public decimal Credits { get; set; }
        public decimal Loan { get; set; }

        //Default Constructor
        public LoadGame()
        {
            Commander = Str();
            FID = Str();
            Horizons = Bool();
            Ship = Str();
            Ship_Localised = Str();
            ShipID = Dec();
            ShipName = Str();
            ShipIdent = Str();
            FuelLevel = Dec();
            FuelCapacity = Dec();
            GameMode = Str();
            Group = Str();
            Credits = Dec();
            Loan = Dec();
        }
    }

    /// <summary>
    /// Event Logic & Data Storage Class
    /// </summary>
    public class Event_LoadGame : Event
    {
        //Variable Generation
        public override void Generate(object O)
        {
            try
            {
                var Event = (LoadGame)O;
                
                Variables.Record(Name + "_Commander", Event.Commander);
                Variables.Record(Name + "_PlayerID", Event.FID);
                Variables.Record(Name + "_Horizons", Event.Horizons);
                Variables.Switch(Name + "_Ship", Event.Ship_Localised, Event.Ship);
                Variables.Record(Name + "_ShipID", Event.ShipID);
                Variables.Record(Name + "_ShipName", Event.ShipName);
                Variables.Record(Name + "_ShipCallSign", Event.ShipIdent);
                Variables.Record(Name + "_FuelLevel", Event.FuelLevel);
                Variables.Record(Name + "_FuelCapacity", Event.FuelCapacity);
                Variables.Record(Name + "_GameMode", Event.GameMode);
                Variables.Record(Name + "_Group", Event.Group);
                Variables.Record(Name + "_Credits", Event.Credits);
                Variables.Record(Name + "_Load", Event.Loan);
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
                var Event = (LoadGame)O;

                //Update Commander Name
                ISettings.U_Commander(ClassName, Event.Commander);

                //Vechile = SRV
                if (Event.Ship.ToLower().Contains("testbuggy"))
                {
                    IVehicles.Vehicle = IVehicles.V.SRV;
                }
                //Vechile = Fighter
                else if (Event.Ship.ToLower().Contains("fighter"))
                {
                    IVehicles.Vehicle = IVehicles.V.Fighter;
                }
                //Vechile = Mothership
                else
                {
                    IVehicles.Vehicle = IVehicles.V.Mothership;
                }

                //Load Mothership Data
                switch (IVehicles.Vehicle)
                {
                    case IVehicles.V.Mothership:

                        //Validate Ship ID
                        if (IObjects.Mothership.I.ID != -1 ||               //Default Value For Blank Object (Fresh Ship)
                            IObjects.Mothership.I.ID != Event.ShipID)       //Ship ID Should Match, Otherwise Its A Different Ship.
                        {
                            //Event Logger
                            if (ICheck.Initialized(ClassName))
                            {
                                Logger.Event("Updating New Mothership Data.");
                            }

                            //Different Ship, Reset Object
                            IObjects.Mothership.New(Event.Event);

                            //FingerPrint Generation
                            string FP = Event.ShipID + " " + Event.Ship + " (" + ISettings.Commander + ")";

                            //Load Ship Data, If It Exist
                            IObjects.Mothership = new Object_Mothership().Load(ClassName, FP);
                        }

                        break;

                    default:

                        //Logger
                        if (ICheck.Initialized(ClassName))
                        {
                            Logger.Log(ClassName, "Mothership Loadout Is Not Available, Loading Best Guess... Hope This Works.", Logger.Yellow);
                        }

                        //Load Saved Mothership Data.                    
                        IObjects.Mothership = new Object_Mothership().Load(ClassName, null);

                        //Load Firegroup Settings
                        ISettings.Firegroup.Load();

                        break;
                }

                //Update Ship Object
                switch (IVehicles.Vehicle)
                {
                    case IVehicles.V.Mothership:

                        //Update Object Data
                        IObjects.Mothership.Update(Event);

                        //Save Data Only If Event Data Is Newer The Object Data
                        if (IObjects.Mothership.EventTimeStamp == Event.Timestamp)
                        {
                            //Save Mothership Data.
                            new Object_Mothership().Save(IObjects.Mothership, ClassName);
                        }

                        break;

                    case IVehicles.V.Fighter:
                        //No Logic
                        break;

                    case IVehicles.V.SRV:
                        //No Logic
                        break;

                    default:
                        break;
                }

                //Reset Panels
                Call.ResetPanels();

                //Load Firegroup Settings.
                ISettings.Firegroup.Load();

                //Update Fuel Status
                IEquipment.FuelTank.Update(Event);
            }
            catch (Exception ex)
            {
                ExceptionProcess(Name, ex);
            }
        }
    }
}