using System.Collections.Generic;
using Dota2ApiWrapper.ApiClasses;
using Newtonsoft.Json;

namespace Dota2ApiWrapper.Results
{
    public class GetMatchHistoryBySequenceNumResult
    {
        #region Private
        private int _status;
        private List<DetailedMatch> _matches;
        #endregion

        [JsonProperty("matches")]
        public List<DetailedMatch> Matches
        {
            get { return _matches; }
            set { _matches = value; }
        }

        [JsonProperty("status")]
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }



    }
}
