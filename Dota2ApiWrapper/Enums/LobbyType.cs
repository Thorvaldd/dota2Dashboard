using System.ComponentModel;

namespace Dota2ApiWrapper.Enums
{
    public enum LobbyType
    {
        Invalid = -1,

        [Description("Public MatchMaking")]
        PublicMatchmaking = 0,

        [Description("Practice")]
        Practice = 1,

        [Description("Tournament")]
        Tournament = 2,

        [Description("Tutorial")]
        Tutorial = 3,

        [Description("Coop with bots")]
        COOPWithBots = 4,

        [Description("Team Match")]
        TeamMatch = 5,

        [Description("Solo Queue")]
        SoloQueue = 6,

        [Description("Ranked")]
        Ranked = 7,

        [Description("Solo Mid 1 vs 1")]
        SoloMid1Vs1= 8,


    }
}
