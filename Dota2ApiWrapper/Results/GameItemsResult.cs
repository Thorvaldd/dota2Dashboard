using System.Collections.Generic;
using Dota2ApiWrapper.ApiClasses;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.Results
{
    public class GameItemsResult
    {
        [JsonProperty("items")]
        public List<GameItems> GameItems { get; set; }
    }
}
