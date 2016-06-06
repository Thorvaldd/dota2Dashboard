using System.Threading.Tasks;
using System.Web.Mvc;
using WebApiRepository.Implementations.ApiRequests;
using WebApiRepository.Interfaces;
using WebApiRepository.Mappers.ModelMappers;

namespace Dota2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDota2HeroesService _service;
        public HomeController(IDota2HeroesService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var model = _service.GetAllHeroes();
            var results = model.ToViewModel();
            return View("Index",results);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<JsonResult> GetHeroes()
        {
            var apiRepo = new Dota2Results();
            var results = await apiRepo.GetHores();
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}