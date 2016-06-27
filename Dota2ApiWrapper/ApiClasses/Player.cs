using Newtonsoft.Json;

namespace Dota2ApiWrapper.ApiClasses
{
    public class Player
    {
        #region Private
        private int _heroId;
        private static long ANONYMOUS = 4294967295;
        private long _accountId;
        #endregion

        [JsonProperty("account_id")]
        public long AccountId
        {
            get { return _accountId; }
            set { _accountId = value; }
        }

        [JsonProperty("hero_id")]
        public int HeroId
        {
            get { return _heroId; }
            set { _heroId = value; }
        }

        public bool IsAnonymous
        {
            get { return _accountId == ANONYMOUS; }
        }

        public string AccountId64
        {
            get { return (AccountId + 76561197960265728).ToString(); }
        }
    }
}
