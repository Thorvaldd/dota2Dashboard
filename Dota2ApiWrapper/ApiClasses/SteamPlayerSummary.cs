﻿using System;
using System.Collections.Generic;
using Dota2ApiWrapper.Converters;
using Dota2ApiWrapper.Enums;
using Dota2ApiWrapper.Results;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.ApiClasses
{
    public class SteamPlayerSummary
    {
        #region Private
        private string _steamId;
        private CommunityVisibilityState _communityVisibilityState;
        private string _profileState;
        private string _displayName;
        private DateTime _lastLogOff;
        private Uri _profileUri;
        private Uri _avatarUri;
        private Uri _avatarMediumUri;
        private Uri _avatarFullUri;
        private PlayerStatus _playerStatus;
        private string _locationCountryCode;
        #endregion

        public SteamPlayerSummary()
        {
            RecentlyPlayedGames = new List<RecentlyPlayedGames>();
            MatchHistory = new List<MatchHistoryResult>();
        }

        [JsonProperty("avatarfull")]
        [JsonConverter(typeof(StringUriConverter))]
        public Uri AvatarFullUri
        {
            get { return _avatarFullUri; }
            set { _avatarFullUri = value; }
        }

        [JsonProperty("avatarmedium")]
        [JsonConverter(typeof(StringUriConverter))]
        public Uri AvatarMediumUri
        {
            get { return _avatarMediumUri; }
            set { _avatarMediumUri = value; }
        }

        [JsonProperty("avatar")]
        [JsonConverter(typeof(StringUriConverter))]
        public Uri AvatarUri
        {
            get { return _avatarUri; }
            set { _avatarUri = value; }
        }

        [JsonProperty("profileurl")]
        [JsonConverter(typeof(StringUriConverter))]
        public Uri ProfileUri
        {
            get { return _profileUri; }
            set { _profileUri = value; }
        }

        [JsonProperty("lastlogoff")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastLogOff
        {
            get { return _lastLogOff; }
            set { _lastLogOff = value; }
        }

        [JsonProperty("personaname")]
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        [JsonProperty("profileState")]
        public string ProfileState
        {
            get { return _profileState; }
            set { _profileState = value; }
        }

        [JsonProperty("communityvisibilitystate")]
        [JsonConverter(typeof(NumberToEnumConverter<CommunityVisibilityState>))]
        public CommunityVisibilityState CommunityVisibilityState
        {
            get { return _communityVisibilityState; }
            set { _communityVisibilityState = value; }
        }

        [JsonProperty("steamid")]
        public string SteamId
        {
            get { return _steamId; }
            set { _steamId = value; }
        }

        [JsonProperty("personastate")]
        [JsonConverter(typeof(NumberToEnumConverter<PlayerStatus>))]
        public PlayerStatus PlayerStatus
        {
            get { return _playerStatus; }
            set { _playerStatus = value; }
        }

        [JsonProperty("loccountrycode")]
        public string LocationCountryCode
        {
            get { return _locationCountryCode; }
            set { _locationCountryCode = value; }
        }


        public List<RecentlyPlayedGames> RecentlyPlayedGames { get; set; }

        public List<MatchHistoryResult> MatchHistory { get; set; }

    }
}
