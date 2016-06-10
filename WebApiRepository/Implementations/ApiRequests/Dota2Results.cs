﻿using Dota2ApiWrapper;
using System.Configuration;
using System.Threading.Tasks;
using Dota2ApiWrapper.ApiClasses;
using Dota2ApiWrapper.Enums;
using ViewModels;
using WebApiRepository.Mappers.ApiMappers;

namespace WebApiRepository.Implementations.ApiRequests
{
    public class Dota2Results
    {
        #region private
        private readonly string _apikey = ConfigurationManager.AppSettings["apikey"];
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
            var user = await _api.GetUserInfoByNickName(nickName);
            return user;
        }
    }
}
