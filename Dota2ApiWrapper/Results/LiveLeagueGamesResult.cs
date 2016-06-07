using System.Collections.Generic;
using Dota2ApiWrapper.ApiClasses;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.Results
{
    public class LiveLeagueGamesResult
    {
        private List<LiveLeagueMatch> _games;

        [JsonProperty("games")]
        public List<LiveLeagueMatch> Games
        {
            get { return _games; }
            set { _games = value; }
        }
        
    }
}
