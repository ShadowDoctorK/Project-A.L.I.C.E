﻿using ALICE_Internal;
using ALICE_JournalReader;
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
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
            Thread.Sleep(50000000);
        }

        public static void Debug()
        {
            PlugIn.Initialize(true, true);
            Thread.Sleep(500000);
            //JournalReader.EventProcessor();
        }
    }
}