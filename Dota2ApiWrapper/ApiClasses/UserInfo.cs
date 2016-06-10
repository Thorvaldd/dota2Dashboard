using Newtonsoft.Json;

namespace Dota2ApiWrapper.ApiClasses
{
    public class UserInfo
    {
        [JsonProperty("steamid")]
        public string SteamId { get; set; }

        /// <summary>
        /// The message associated with the request status. Currently only used on resolution failures.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The status of the request. 1 if successful, 42 if there was no match.
        /// </summary>
        [JsonProperty("success")]
        public int Status { get; set; }
    }
}
