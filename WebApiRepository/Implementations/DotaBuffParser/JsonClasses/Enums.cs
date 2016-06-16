using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WebApiRepository.Implementations.DotaBuffParser.JsonClasses
{
    public class Enums
    {
        [JsonProperty("Items")]
        public Items Items { get; set; }
    }
}
