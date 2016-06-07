using System.Collections.Generic;
using Dota2ApiWrapper.ApiClasses;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.Results
{
    public class LeagueListingResult
    {
        private List<League> _leagues;

        [JsonProperty("leagues")]
        public List<League> Leagues
        {
            get { return _leagues; }
            set { _leagues = value; }
        }

    }
}
