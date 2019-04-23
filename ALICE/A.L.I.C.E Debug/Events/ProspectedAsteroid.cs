#region ICheck
namespace ALICE_Debug
{
    using ALICE_DebugCheck;

    public static partial class ICheck
    {
        public static ProspectedAsteroid ProspectedAsteroid { get; set; } = new ProspectedAsteroid();
    }
}

namespace ALICE_DebugCheck
{
    using ALICE_Debug;
    using ALICE_Events;

    public class ProspectedAsteroid : Debug
    {
        private static readonly string Item = "Prospected Asteroid ";

        private static ALICE_Events.ProspectedAsteroid E { get => IEvents.ProspectedAsteroid.I; }

        public bool Content(string M, bool T, string C, bool L = true)
        { return Evaluate(M, Item + "(Content)", T, C, E.Content, L); }

        public bool ContentLocalised(string M, bool T, string C, bool L = true)
        { return Evaluate(M, Item + "(Content Localised)", T, C, E.Content_Localised, L); }

        public bool MotherlodeMaterial(string M, bool T, string C, bool L = true)
        { return Evaluate(M, Item + "(Motherlode Material)", T, C, E.MotherlodeMaterial, L); }

        public bool MotherlodeMaterialLocalised(string M, bool T, string C, bool L = true)
        { return Evaluate(M, Item + "(Motherlode Material Localised)", T, C, E.MotherlodeMaterial_Localised, L); }

        public bool Core(string M, bool T, string C, bool L = true)
        { return Evaluate(M, Item + "(Core)", T, C, IGet.ProspectedAsteroid.Core(Item), L); }

        public bool Remaining(string M, bool T, decimal C, bool L = true)
        { return Evaluate(M, Item + "(Remaining)", T, C, E.Remaining, L); }
    }
}
#endregion

#region IGet
namespace ALICE_Debug
{
    using ALICE_DebugGet;

    public static partial class IGet
    {
        public static ProspectedAsteroid ProspectedAsteroid { get; set; } = new ProspectedAsteroid();
    }
}

namespace ALICE_DebugGet
{
    using ALICE_Debug;
    using ALICE_Events;

    public class ProspectedAsteroid : Debug
    {
        private static ALICE_Events.ProspectedAsteroid E { get => IEvents.ProspectedAsteroid.I; }

        private static readonly string Item = "Prospected Asteroid ";

        public string Content(string M, bool L = true)
        { return Get(M, Item + "(Content)", E.Content, L); }

        public string ContentLocalised(string M, bool L = true)
        { return Get(M, Item + "(Content Localised)", E.Content_Localised, L); }

        public string MotherlodeMaterial(string M, bool L = true)
        { return Get(M, Item + "(Motherlode Material)", E.MotherlodeMaterial, L); }

        public string MotherlodeMaterialLocalised(string M, bool L = true)
        { return Get(M, Item + "(Motherlode Material Localised)", E.MotherlodeMaterial_Localised, L); }

        public string Core(string M, string C = "None", bool L = true)
        { return Resolve(M, Item + "(Core)", E.MotherlodeMaterial_Localised, E.MotherlodeMaterial, C, L); }

        public decimal Remaining(string M, bool L = true)
        { return Get(M, Item + "(Remaining)", E.Remaining, L); }
    }
}
#endregion