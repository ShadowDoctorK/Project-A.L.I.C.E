using ALICE_Events;
using ALICE_Interface;
using ALICE_Internal;
using ALICE_Status;
using System.Collections.Generic;

namespace ALICE_Settings
{
    public class SettingsShipyard : SettingsUtilities
    {
        private readonly string ClassName = "Shipyard";

        /// <summary>
        /// Allows tracking and control for updating older data version when updates occur.
        /// </summary>
        public string DataVersion = "1.0.0";                        //Custom

        //public string LastCommander
        public decimal LastID = -1;

        /// <summary>
        /// Collection Of Commanders And Their Ships.
        /// </summary>
        public Dictionary<string, Dictionary<decimal, string>> Commanders { get; set; } = new Dictionary<string, Dictionary<decimal, string>>();

        /// <summary>
        /// Collection Of Ship Loadouts.
        /// </summary>
        //private Dictionary<decimal, string> Ships { get; set; } = new Dictionary<decimal, string>();

        public SettingsShipyard()
        {
            Commanders = new Dictionary<string, Dictionary<decimal, string>>();
            //Ships = new Dictionary<decimal, string>();
        }

        public bool LoadShip(string MethodName, string Commander, decimal ShipID)
        {            
            try
            {
                //Get Ship Loadout
                string Ship = GetShip(MethodName, Commander, ShipID);

                //Process Ship Loadout
                if (Ship != "None")
                {
                    //Deserialize Loadout
                    Loadout I = (Loadout)INewtonSoft.Deserialize(Ship,
                        IEvents.Types.Get(IEnums.Events.Loadout), true, IEnums.Events.Loadout);

                    //Update Ship Data
                    IStatus.Mothership.Update(I);

                    Logger.Log("Shipyard Settings", "[Loaded] " + IStatus.Mothership.FingerPrint, Logger.Purple);

                    return true;
                }
                else
                {
                    Logger.Log(MethodName, "Ship " + ShipID + " Has Not Been Recorded Yet.", Logger.Yellow);
                }                
            }
            catch (System.Exception ex)
            {
                Logger.Exception(MethodName, "Exception: " + ex);               
            }

            return false;
        }

        /// <summary>
        /// Gets Target Ship From Commander If Exists.
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="C">(Commander) The Name Of The Commander.</param>
        /// <param name="ID">(Ship ID) The Games Ship ID Number.</param>
        /// <returns>Ships Saved Loadout Event</returns>
        public string GetShip(string M, string C, decimal ID)
        {
            string MethodName = ClassName + " (Get Ship)";

            //Search Commander
            if (Commanders.ContainsKey(C))
            {
                //Search Ship
                if (Commanders[C].ContainsKey(ID))
                {
                    return Commanders[C][ID];
                }                
            }

            //Debug Logger
            Logger.DebugLine(MethodName, "Does Not Contain Ship ID " + ID + " For Commander " + C, Logger.Yellow);

            return "None";
        }

        /// <summary>
        /// Removes Target Ship From Commander If Exists.
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="C">(Commander) The Name Of The Commander.</param>
        /// <param name="ID">(Ship ID) The Games Ship ID Number.</param>
        public void RemoveShip(string M, string C, decimal ID)
        {
            string MethodName = ClassName + " (Remove Ship)";

            //Search Commander
            if (Commanders.ContainsKey(C))
            {
                //Search Ship
                if (Commanders[C].ContainsKey(ID))
                {
                    Commanders[C].Remove(ID);

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Removed Ship ID " + ID + " From Commander " + C, Logger.Yellow);

                    return;
                }
            }

            //Debug Logger
            Logger.DebugLine(MethodName, "Does Not Contain Ship ID " + ID + " For Commander " + C, Logger.Yellow);
        }

        /// <summary>
        /// Adds a Ship To The Collection.
        /// </summary>
        /// <param name="M">(Method Name) The Simple Name Of The Calling Method.</param>
        /// <param name="C">(Commander) The Name Of The Commander.</param>
        /// <param name="ID">(Ship ID) The Games Ship ID Number.</param>
        /// <param name="LO">(Loadout Event) The Journal Entry For The Ships Loadout Event.</param>
        public void UpdateShip(string M, string C, decimal ID, string LO)
        {
            string MethodName = ClassName + " (Update Ship)";

            //Search Commander
            if (Commanders.ContainsKey(C))
            {
                //Update Ship
                if (Commanders[C].ContainsKey(ID))
                {
                    Commanders[C][ID] = LO;

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Updated Ship ID " + ID + " For Commander " + C, Logger.Yellow);
                }

                //New Ship
                else
                {
                    Commanders[C].Add(ID, LO);

                    //Debug Logger
                    Logger.DebugLine(MethodName, "Added Ship ID " + ID + " To Commander " + C, Logger.Yellow);
                }
            }

            //New Commander
            else
            {
                //New Commander
                Commanders.Add(C, new Dictionary<decimal, string>());

                //Debug Logger
                Logger.DebugLine(MethodName, "Added Commander " + C, Logger.Yellow);

                //New Ship
                Commanders[C].Add(ID, LO);

                //Debug Logger
                Logger.DebugLine(MethodName, "Added Ship ID " + ID, Logger.Yellow);
            }
        }

        public string Convert(string M, Loadout Event)
        {
            return Serialize<Loadout>(M, Event);
        }

        public void Save()
        {
            SaveValues<SettingsShipyard>(ISettings.Shipyard, "Shipyard.Settings");
        }

        public SettingsShipyard Load()
        {
            return (SettingsShipyard)LoadValues<SettingsShipyard>("Shipyard.Settings");
        }
    }
}
