using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebApiRepository.Implementations.DotaBuffParser.Results
{
    public class EnumItemsResult<T> where T: JsonClasses.Enums
    {
        [JsonProperty("Enums")]
        public T Enums { get; set; }
    }
}
