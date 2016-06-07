using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.ApiClasses
{
    public class LiveLeagueTeam
    {

        #region Private
        private int _score;
        private List<LiveLeaguePlayer> _players;
        #endregion

        [JsonProperty("players")]
        public List<LiveLeaguePlayer> Players
        {
            get { return _players; }
            set { _players = value; }
        }
        
        [JsonProperty("score")]
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
    }
}
