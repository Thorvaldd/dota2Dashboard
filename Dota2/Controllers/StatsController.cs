using System.Threading.Tasks;
using System.Web.DynamicData;
using System.Web.Mvc;
using WebApiRepository.Implementations.ApiRequests;

namespace Dota2.Controllers
{
    public class StatsController : Controller
    {
        // GET: Stats
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetUserInfo(string nickName)
        {
            var api = new Dota2Results();

            var result = await api.GetUserInfoByNick(nickName);
            var recentgames = await api.GetRecentGamesByUserId(result.SteamId);
           // var matchHistory = await api.GetMatchHistory(result.SteamId);
            if (recentgames.RecentlyPlayedGames.Count > 0)
            {
                result.RecentlyPlayedGames.AddRange(recentgames.RecentlyPlayedGames);
            }
            //if (matchHistory.Matches?.Count > 0)
            //{
            //    result.MatchHistory.Add(matchHistory);
            //}
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetMatchHistor(string accountId)
        {
            var api = new Dota2Results();
            var history = await api.GetMatchHistory(accountId);

            return Json(history, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetStatsPartial()
        {
            return PartialView("Partials/StatsPartial");
        }
    }
}