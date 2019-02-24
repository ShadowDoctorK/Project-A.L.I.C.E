//Code Generated By Project A.L.I.C.E Developer Toolkit
//Class File Generated: 11/12/2018 1:27 AM
//Source Journal Line: { "timestamp":"2018-10-14T04:10:51Z", "event":"LoadGame", "Commander":"Shadow Doctor K", "Horizons":true, "Ship":"Federation_Corvette", "Ship_Localised":"Federal Corvette", "ShipID":11, "ShipName":"MORNINGSTAR", "ShipIdent":"S-117", "FuelLevel":32.000000, "FuelCapacity":32.000000, "GameMode":"Group", "Group":"Shadow Doctor K", "Credits":298658411, "Loan":0 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALICE_Objects;
using ALICE_Internal;
using ALICE_EventLogic;

namespace ALICE_Events
{
    public class Event_LoadGame : Event_Base
    {
        public Event_LoadGame()
        {
            Name = "LoadGame";
        }

        public void Logic()
        {
            if (IEvents.WriteVariables && WriteVariables)
            {
                try
                {
                    Variables_Clear();
                    Variables_Generate();
                    Variables_Write();
                }
                catch (Exception ex)
                {
                    Logger.Exception(Name, "An Exception Occured While Updating Variables");
                    Logger.Exception(Name, "Exception: " + ex);
                }
            }

            Process.LoadGame((LoadGame)GetEvent());

            TriggerEvent();
        }

        public void Variables_Generate()
        {
            LoadGame Event = (LoadGame)IEvents.GetEvent(Name);

            Variables.Clear();

            #region Custom Variables

            #endregion

            #region Event Variables
            Variable_Craft("Commander", Event.Commander.Variable());
            Variable_Craft("Horizons", Event.Horizons.Variable());
            Variable_Craft("Ship", Event.Ship.Variable());
            Variable_Craft("Ship_Localised", Event.Ship_Localised.Variable());
            Variable_Craft("ShipID", Event.ShipID.Variable());
            Variable_Craft("ShipName", Event.ShipName.Variable());
            Variable_Craft("ShipIdent", Event.ShipIdent.Variable());
            Variable_Craft("FuelLevel", Event.FuelLevel.Variable());
            Variable_Craft("FuelCapacity", Event.FuelCapacity.Variable());
            Variable_Craft("GameMode", Event.GameMode.Variable());
            Variable_Craft("Group", Event.Group.Variable());
            Variable_Craft("Credits", Event.Credits.Variable());
            Variable_Craft("Loan", Event.Loan.Variable());
            #endregion
        }
    }

    #region LoadGame Event
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

        public LoadGame()
        {
            Commander = Default.String;
            FID = Default.String;
            Horizons = Default.False;
            Ship = Default.String;
            Ship_Localised = Default.String;
            ShipID = Default.Decimal;
            ShipName = Default.String;
            ShipIdent = Default.String;
            FuelLevel = Default.Decimal;
            FuelCapacity = Default.Decimal;
            GameMode = Default.String;
            Group = Default.String;
            Credits = Default.Decimal;
            Loan = Default.Decimal;
        }
    }
    #endregion
}