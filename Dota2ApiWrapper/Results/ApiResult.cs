using Newtonsoft.Json;

namespace Dota2ApiWrapper.Results
{
    public class ApiResult<T>
    {
        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("response")]
        public T Response { get; set; }
    }
}
