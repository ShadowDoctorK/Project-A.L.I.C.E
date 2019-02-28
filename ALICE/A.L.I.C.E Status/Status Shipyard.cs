using ALICE_Debug;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;
using System.Collections.Generic;
using System.Threading;

namespace ALICE_Status
{
    public class Status_Shipyard
    {
        public readonly string MethodName = "Shipyard Status";

        private List<ShipyardArrived> Tranfers = new List<ShipyardArrived>();
        private object Montior = new object();

        public Responses Response = new Responses();

        public void Update(Shipyard Event)
        {
            //Pending Logic
        }

        public void Update(ShipyardTransfer Event)
        {
            //Pending Logic
        }

        public void Update(ShipyardBuy Event)
        {
            //Pending Logic
        }

        public void Update(ShipyardNew Event)
        {
            //Pending Logic
        }

        public void Update(ShipyardSwap Event)
        {
            //Pending Logic
        }

        public void Update(ShipyardArrived Event)
        {
            //Don't Track Old Ships
            if (ICheck.Initialized(MethodName)) { return; }

            //Add Ship To Tranfers
            Tranfers.Add(Event);

            //Monitor Transfers
            Transfering();
        }

        public void Transfering()
        {
            Thread thread =
            new Thread((ThreadStart)(() =>
            {
                try
                {
                    if (Monitor.TryEnter(Montior))
                    {
                        //Watch Till All Ships Are Finished Transit
                        while (Tranfers.Count != 0)
                        {
                            //Update Each Ships Transfer Time
                            Thread.Sleep(5000); foreach (ShipyardArrived Ship in Tranfers)
                            {
                                Ship.Time = Ship.Time - 5;

                                //Check For This Min Warning
                                if ((Ship.Time < 180) && Ship.ThreeMinOut)
                                {
                                    //Set Three Min Out
                                    Ship.ThreeMinOut = false;

                                    //Update Event Instance
                                    IEvents.ShipyardArrived.I = Ship;

                                    //Execute Logic
                                    IEvents.ShipyardArrived.Logic();
                                }

                                //Check For Arrival
                                else if (Ship.Time < 0)
                                {                                    
                                    //Set Time To Zero
                                    Ship.Time = 0;

                                    //Update Event Instance
                                    IEvents.ShipyardArrived.I = Ship;

                                    //Execute Logic
                                    IEvents.ShipyardArrived.Logic();

                                    //Remove Completed Tranfers
                                    Clean();
                                }
                            }
                        }
                    }
                }
                finally
                {
                    //Release Monitor & Exit
                    Monitor.Exit(Montior);
                }
            }))
            {
                IsBackground = true
            };
            thread.Start();
        }

        private void Clean()
        {
            List<ShipyardArrived> Temp = new List<ShipyardArrived>();

            foreach (ShipyardArrived Item in Tranfers)
            {
                if (Item.Time > 0)
                {
                    Temp.Add(Item);
                }
            }

            Tranfers = Temp;
        }

        public class Responses
        {
            string MethodName = "Shipyard Status";

            public void ThreeMinWarning(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "3 Min Till Your " + IEvents.ShipyardArrived.I.Ship + " Arrived In " + IEvents.ShipyardArrived.I.EndLocation, Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EVT_Shipyard_Arrived.Three_Min_Warning)
                    .Token("[DESTINATION]", ICheck.ShipyardArrived.EndLocation(MethodName))
                    .Token("[SHIP]", ICheck.ShipyardArrived.Ship(MethodName))
                    .Token("[STATION]", ICheck.ShipyardArrived.EndStation(MethodName)),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Arrived(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Your " + IEvents.ShipyardArrived.I.Ship + " Arrived In " + IEvents.ShipyardArrived.I.EndLocation, Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(EVT_Shipyard_Arrived.Arrived)
                    .Token("[DESTINATION]", ICheck.ShipyardArrived.EndStation(MethodName))
                    .Token("[SHIP]", ICheck.ShipyardArrived.Ship(MethodName))
                    .Token("[STATION]", ICheck.ShipyardArrived.EndStation(MethodName)),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }
    }
}
