using ALICE_Events;
using ALICE_Internal;
using ALICE_Synthesizer;
using System;
using System.IO;
using System.Media;
using System.Threading;

namespace ALICE_Status
{
    public class Status_Interaction
    {
        public enum Answers { NoResponse, Yes, No }
        public enum Marks { NoResponse, Mark, EarlyReturn }

        public Answers Answer = Answers.NoResponse;
        public Marks Marker = Marks.NoResponse;

        public Responses Response = new Responses();

        /// <summary>
        /// Watches For The Users Response To A Question. Checks For The Response Every 100 ms.
        /// </summary>
        /// <param name="Duration">How Long In Milliseconds You Want To Watch.</param>
        /// <returns>Yes, No or NoResponse</returns>
        public Answers Question(decimal Duration)
        {
            string MethodName = "Interaction Status (Qusetion)";

            //Reset Answer
            Answer = Answers.NoResponse;

            //Debug Logging
            Logger.DebugLine(MethodName, "Waiting " + Duration + " ms For A Response...", Logger.Blue);

            //Watch Response For "Duration" Of Time.
            decimal ResponseCounter = Duration / 100;
            while (Answer == Answers.NoResponse && ResponseCounter > 0)
            {
                ResponseCounter++; Thread.Sleep(100);
            }

            //Return Result
            return Answer;
        }

        /// <summary>
        /// Watches For The Users Mark. Checks For The Command Every 100 ms.
        /// </summary>
        /// <param name="M">(Method) The Simple Name Of The Method</param>
        /// <param name="D">(Duration) How Long In Milliseconds You Want To Watch</param>
        /// <param name="T">(Tracker) Tracking Reference To Allow Fucntion To Exit If No Longer Required</param>
        /// <returns></returns>
        public Marks WaitForMark(string M, decimal D, ref bool T, ref Marks MK)
        {
            string MethodName = "Interaction Status (" + M + ")";

            try
            {
                //Reset Answer
                MK = Marks.NoResponse;

                //Log
                Logger.Log(MethodName, "Waiting " + D + " ms For Your Mark...", Logger.Yellow);

                //Watch Response For "Duration" Of Time.
                decimal ResponseCounter = D / 100;
                while (MK == Marks.NoResponse && ResponseCounter > 0)
                {
                    ResponseCounter++; Thread.Sleep(100);

                    if (T == false)
                    {
                        //Debug Logger
                        Logger.DebugLine(MethodName, "Stopped Watching Early", Logger.Yellow);

                        return Marks.EarlyReturn;
                    }
                }

                //No Response Check
                if (MK == Marks.NoResponse)
                {
                    //Log
                    Logger.Log(MethodName, "No Mark Given, Stopped Waiting...", Logger.Yellow);

                    //Play Notification Sound
                    #region Sound Effect
                    string FilePath = Paths.ALICE_Audio_Files + "Mark_StoppedWaiting.wav";
                    SoundPlayer player = new SoundPlayer();

                    if (File.Exists(FilePath))
                    {
                        player.SoundLocation = FilePath;
                        player.Play();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                //Exception Logger
                Logger.Exception(MethodName, "Exception: " + ex);
            }

            //Return Result
            return MK;
        }

        public void Yes()
        {
            string MethodName = "Interaction Status (Yes)";

            //Set Answer To Yes
            Answer = Answers.Yes;

            //New Thread To Reset Answer
            Thread thread =
            new Thread((ThreadStart)(() =>
            {
                Thread.Sleep(1000);
                Answer = Answers.NoResponse;
                Logger.DebugLine(MethodName, "Reset Answer To Default", Logger.Blue);
            }))
            { IsBackground = false };
            thread.Start();
        }

        public void No()
        {
            string MethodName = "Interaction Status (No)";

            //Set Answer To No
            Answer = Answers.No;

            //New Thread To Reset Answer
            Thread thread =
            new Thread((ThreadStart)(() =>
            {
                Thread.Sleep(1000);
                Answer = Answers.NoResponse;
                Logger.DebugLine(MethodName, "Reset Answer To Default", Logger.Blue);
            }))
            { IsBackground = false };
            thread.Start();
        }

        public void Mark()
        {
            string MethodName = "Interaction Status (Mark)";

            //Set Answer To No
            Marker = Marks.Mark;
            Logger.DebugLine(MethodName, "Marker = Mark", Logger.Yellow);

            //New Thread To Reset Answer
            Thread thread =
            new Thread((ThreadStart)(() =>
            {
                Thread.Sleep(1000);
                Marker = Marks.NoResponse;
                Logger.DebugLine(MethodName, "Reset Marker To Default", Logger.Blue);
            }))
            { IsBackground = false };
            thread.Start();
        }

        public class Responses
        {
            string MethodName = "Interaction Status";

            public void Online(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Yes Commander?.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Alice.Online)
                    .Token("[VERSION]", IEvents.AliceOnline.I.Version),     //Pass Version
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void Alice(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Yes Commander?.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Alice.Default),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void ThankYou(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "You're Welcome.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Thank_You.Default),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void ILoveYou(bool CommandAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "You're Such A Sweet Talker.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_I_Love_You.Default),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }

            public void OnYourMark(bool CommandAudio, bool PositiveAudio, bool Var1 = true, bool Var2 = true,
                bool Var3 = true, int Priority = 3, string Voice = null)
            {
                if (PlugIn.MasterAudio == false) { Logger.Log(MethodName, "Standing By For Your Mark.", Logger.Yellow); }

                Speech.Speak(""
                    .Phrase(GN_Positive.Default, true, PositiveAudio)
                    .Phrase(GN_Alice.On_Your_Mark),
                    CommandAudio, Var1, Var2, Var3, Priority, Voice);
            }
        }
    }
}
