using System;
using Dota2ApiWrapper.Converters;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.ApiClasses
{
    public class RecentlyPlayedGames
    {
        #region properties

        private string _programIconUrl;
        private string _programLogoUrl;
        #endregion

        /// <summary>
        /// An integer containing the program's ID.
        /// </summary>
        [JsonProperty("appid")]
        public int ApplicationId { get; set; }

        /// <summary>
        /// A string containing the program's publicly facing title.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// An integer of the the player's total playtime, denoted in minutes.
        /// </summary>
        [JsonProperty("playtime_forever")]
        [JsonConverter(typeof(MinuteDateTimeConverter))]
        public string TotalPLayTime { get; set; }

        /// <summary>
        /// The program icon's file name, accessible at: http://media.steampowered.com/steamcommunity/public/images/apps/APPID/IMG_ICON_URL.jpg, 
        /// replacing "APPID" and "IMG_ICON_URL" as necessary.
        /// </summary>
        [JsonProperty("img_icon_url")]

        public string ProgramIconUrl
        {
            get { return $"http://media.steampowered.com/steamcommunity/public/images/apps/{ApplicationId}/{_programIconUrl}.jpg"; }
            set { _programIconUrl = value; }
        }

        [JsonProperty("img_logo_url")]
        public string ProgramLogoUrl { get { return $"http://media.steampowered.com/steamcommunity/public/images/apps/{ApplicationId}/{_programLogoUrl}.jpg"; }
            set { _programLogoUrl = value; }
        }

    }
}
