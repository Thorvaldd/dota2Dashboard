using System.Collections.Generic;
using Dota2ApiWrapper.ApiClasses;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.Results
{
    public class SteamPlayerSummaryResult
    {
        private List<SteamPlayerSummary> _players;

        [JsonProperty("players")]
        public List<SteamPlayerSummary> Players
        {
            get { return _players; }
            set { _players = value; }
        }

    }
}
