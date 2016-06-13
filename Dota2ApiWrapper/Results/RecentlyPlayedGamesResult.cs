using System.Collections.Generic;
using Dota2ApiWrapper.ApiClasses;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.Results
{
    public class RecentlyPlayedGamesResult
    {
        [JsonProperty("games")]
        public List<RecentlyPlayedGames> RecentlyPlayedGames { get; set; }

        [JsonProperty("total_cunt")]
        public long TotalCount { get; set; }
    }
}
