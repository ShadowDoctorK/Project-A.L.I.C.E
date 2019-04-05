#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static Music Music { get; set; } = new Music();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Events;

    public class Music : Debug
    {
        private static ALICE_Events.Music E { get => IEvents.Music.I; }

        public bool MusicTrack(string M, bool T, string C, bool L = true)
        { return Evaluate(M, "Music (Track)", T, C, E.MusicTrack, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static Music Music { get; set; } = new Music();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Events;

    public class Music : Debug
    {
        private static ALICE_Events.Music E { get => IEvents.Music.I; }

        public string MusicTrack(string M, bool L = true)
        { return Get(M, "Music (Track)", E.MusicTrack, L); }
    }
}
#endregion