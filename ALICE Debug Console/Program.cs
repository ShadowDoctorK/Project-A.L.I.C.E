using ALICE_Internal;
using System.Threading;

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
            PlugIn.Initialize(true, true, true);
           

            Thread.Sleep(50000);            
        }
    }
}