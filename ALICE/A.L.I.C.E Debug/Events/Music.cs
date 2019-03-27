using ALICE_Debug;
using ALICE_Events;

namespace ALICE_DebugCheck
{
    public class Music : Debug
    {
        private static ALICE_Events.Music E { get => IEvents.Music.I; }

        public bool MusicTrack(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Music (Track)", T, C, E.MusicTrack, L); }
    }
}

namespace ALICE_DebugGet
{
    public class Music : Debug
    {
        private static ALICE_Events.Music E { get => IEvents.Music.I; }

        public string MusicTrack(string M, bool L = true)
        { return Get(M, "Music (Track)", E.MusicTrack, L); }
    }
}