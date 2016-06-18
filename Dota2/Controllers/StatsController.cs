using System.Threading.Tasks;
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
            var recentGames = await api.GetRecentGamesByUserId(result.SteamId, 20);
            if (recentGames?.RecentlyPlayedGames?.Count > 0)
            {
                result.RecentlyPlayedGames.AddRange(recentGames.RecentlyPlayedGames);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetStatsPartial()
        {
            return PartialView("Partials/StatsPartial");
        }
    }
}