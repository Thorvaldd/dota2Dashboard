using Dota2ApiWrapper.Converters;
using Dota2ApiWrapper.Enums;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.ApiClasses
{
    public class LiveLeaguePlayer : Player
    {
        private Faction _faction;

        [JsonProperty("team")]
        [JsonConverter(typeof(NumberToEnumConverter<Faction>))]
        public Faction Faction
        {
            get { return _faction; }
            set { _faction = value; }
        }

    }
}
