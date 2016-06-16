using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace WebApiRepository.Implementations.DotaBuffParser.JsonClasses
{
    public class Items
    {
        [JsonProperty("Dotabuff")]
        public string DotaBuff { get; set; }

        public string Parser { get; set; }

        public string Name { get; set; }
    }
}
