using System.Collections.Generic;
using Dota2ApiWrapper;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dota2ApiWrapper.ApiClasses;
using Dota2ApiWrapper.Enums;
using Dota2ApiWrapper.Results;
using ViewModels;
using WebApiRepository.Mappers.ApiMappers;

namespace WebApiRepository.Implementations.ApiRequests
{
    public class Dota2Results
    {
        #region private
        private readonly string _apikey = ConfigurationManager.AppSettings["steamApi"];
        private readonly ApiHandler _api;
        #endregion
        #region Constructor
        public Dota2Results()
        {
            var api = new ApiHandler(_apikey);
            _api = api;
        }
        #endregion

        public async Task<HeroResultsViewModel> GetHores()
        {

            var result = await _api.GetHeroes();
            var vm = result.ToViewModel();
            return vm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dashedHeroName">valve hero name</param>
        /// <param name="herosize"></param>
        /// <returns></returns>
        public async Task<byte[]> HeroImage(string dashedHeroName, HeroPortraitSize herosize)
        {

            var picture = await _api.GetHeroPortrait(dashedHeroName, herosize);
            return picture;
        }

        public async Task<SteamPlayerSummary> GetUserInfoByNick(string nickName)
        {
            var byId = await _api.GetPlayerSummary(new[] {nickName});
            if (byId?.Players.Count > 0)
            {
                return byId.Players.First();
            }
            var byNick = await _api.GetUserInfoByNickName(nickName);
            return byNick;
        }

        public async Task<RecentlyPlayedGamesResult> GetRecentGamesByUserId(string id, int? count = null)
        {
            var recentGames = await _api.GetRecentlyPlayedGames(id, count);
            return recentGames;
        }

        public async Task<MatchHistoryResult> GetMatchHistory(string accountId)
        {
            var account32bit = (long.Parse(accountId) - 76561197960265728).ToString();
           // var history = await _api.GetMatchHistory(accountId: account32bit, matchesRequested:"20");
            var sq = await _api.GetMatchHistoryBySequenceNumber( matchesRequested:20, accountid:account32bit);

            return new MatchHistoryResult();
            //var dM = new List<DetailedMatch>();
            //foreach (var m in history.Matches)
            //{
            //    //TODO cache requests
            //    Thread.Sleep(30000);
            //    var matchDetails = await _api.GetDetailedMatch(m.MatchId.ToString());
            //    dM.Add(matchDetails);
            //}
        }

        public async Task<List<GameItems>> GetItems()
        {
            var result = await _api.GetGameItems("en_us");

            return result.GameItems;
        }
    }
}
