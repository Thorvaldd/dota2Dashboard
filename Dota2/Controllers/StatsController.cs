using System.Threading.Tasks;
using System.Web.DynamicData;
using System.Web.Mvc;
using WebApiRepository.Implementations.ApiRequests;
using WebApiRepository.Implementations.DotaBuffParser;

namespace Dota2.Controllers
{
    public class StatsController : Controller
    {
        private readonly Dota2Results _api;
        private readonly DotaBuffParser _dotaBuff;

        public StatsController(DotaBuffParser dotaBuff, Dota2Results api)
        {
            _dotaBuff = dotaBuff;
            _api = api;
        }

        // GET: Stats
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetUserInfo(string nickName)
        {
            var result = await _api.GetUserInfoByNick(nickName);
            var games = _dotaBuff.GetPlayerInfo(result.SteamId);
            result.RecentlyPlayedGames.AddRange(games);

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