using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dota2ApiWrapper.ApiClasses
{
    public class GameItems
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cost")]
        public int Cost { get; set; }


        [JsonProperty("secret_shop")]
        public bool IsInSecrectShop { get; set; }

        [JsonProperty("side_shop")]
        public bool SideShopAvailable { get; set; }


        [JsonProperty("recipe")]
        public bool IsRecipe { get; set; }


        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }


    }
}
