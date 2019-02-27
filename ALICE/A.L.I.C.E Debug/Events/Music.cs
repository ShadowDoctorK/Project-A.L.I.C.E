using ALICE_Debug;
using ALICE_Events;

namespace ALICE_DebugItems
{
    public class Music : Debug
    {
        private ALICE_Events.Music E { get => IEvents.Music.I; }

        public bool MusicTrack(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Music (Track)", T, C, E.MusicTrack, L); }

        public string MusicTrack(string M, bool L = true)
        { return Get(M, "Music (Track)", E.MusicTrack, L); }
    }
}