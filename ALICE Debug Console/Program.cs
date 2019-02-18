using ALICE_Internal;
using ALICE_JournalReader;
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

        public static Monitor_Journal Journal = new Monitor_Journal();

        public static void Debug()
        {
            //PlugIn.Initialize(true, true);
            //Thread.Sleep(500000);
            //JournalReader.EventProcessor();

            Journal.Start();
        }
    }
}