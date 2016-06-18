using System.ComponentModel;

namespace Dota2ApiWrapper.Enums
{
    public enum GameMode
    {
        [Description("None")]
        None = 0,

        [Description("All Pick")]
        AllPick = 1,

        [Description("Capitans Mode")]
        CaptainsMode = 2,

        [Description("Random Draft")]
        RandomDraft = 3,

        [Description("Signle Draft")]
        SingleDraft = 4,

        [Description("All Random")]
        AllRandom = 5,

        [Description("Intro")]
        Intro = 6,

        [Description("Diretide")]
        Diretide = 7,

        [Description("Reverse Captians Mode")]
        ReverseCaptainsMode = 8,

        [Description("The Greeviling")]
        TheGreeviling = 9,

        [Description("Tutorial")]
        Tutorial = 10,

        [Description("Mid Only")]
        MidOnly = 11,

        [Description("Least Played")]
        LeastPlayed = 12,

        [Description("New Player Pool")]
        NewPlayerPool = 13,

        [Description("Compendium MatchMaking")]
        CompendiumMatchmaking = 14,

        [Description("Captains Draft")]
        CaptainsDraft = 15,

        [Description("All games Modes")]
        AllGameModes = 100
    }
}
