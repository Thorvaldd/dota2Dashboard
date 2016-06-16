using System.Threading.Tasks;
using System.Web.DynamicData;
using System.Web.Mvc;
using WebApiRepository.Implementations.ApiRequests;
using WebApiRepository.Implementations.DotaBuffParser;

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
            var dbuf = new DotaBuffParser();

            var result = await api.GetUserInfoByNick(nickName);
            var recentgames = await api.GetRecentGamesByUserId(result.SteamId);

            dbuf.UpdateItemsEnum();
        //    var pInfo = dbuf.GetPlayerInfo(result.SteamId);
            if (recentgames.RecentlyPlayedGames.Count > 0)
            {
                result.RecentlyPlayedGames.AddRange(recentgames.RecentlyPlayedGames);
            }
          
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