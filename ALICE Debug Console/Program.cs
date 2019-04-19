using ALICE_Actions;
using ALICE_Events;
using ALICE_Internal;
using ALICE_Interface;
using ALICE_Monitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALICE_Debug_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PlugIn.DebugMode = true;            

            Debug();
            Thread.Sleep(500000);
        }

        public static void Debug()
        {
            //PlugIn.Initialize(true, true);

            ICommands.Invoke("Actions: Fighter: Deploy: Players");

            Thread.Sleep(50000);            
        }
    }
}