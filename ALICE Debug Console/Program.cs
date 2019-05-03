using ALICE_Internal;
using ALICE_Response;
using ALICE_Synthesizer;
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

            IResponse.FullSpectrumScanner.AllBodiesDiscovered(true);
            IResponse.FullSpectrumScanner.AllBodiesDiscovered(true);
            IResponse.FullSpectrumScanner.AllBodiesDiscovered(true);
            IResponse.FullSpectrumScanner.AllBodiesDiscovered(true);
            IResponse.FullSpectrumScanner.AllBodiesDiscovered(true);
            IResponse.FullSpectrumScanner.AllBodiesDiscovered(true);
            IResponse.FullSpectrumScanner.AllBodiesDiscovered(true);
            IResponse.FullSpectrumScanner.AllBodiesDiscovered(true);
            IResponse.FullSpectrumScanner.AllBodiesDiscovered(true);
            IResponse.FullSpectrumScanner.AllBodiesDiscovered(true);
            IResponse.FullSpectrumScanner.AllBodiesDiscovered(true);


            Thread.Sleep(50000);            
        }
    }
}