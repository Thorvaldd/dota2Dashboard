using System.Web.Mvc;
using WebApiRepository.Interfaces;
using WebApiRepository.Mappers.ModelMappers;

namespace Dota2.Controllers
{
    public class HeroesController : BaseController
    {
        #region Fields & constructor
        private readonly IDota2HeroesService _service;

        public HeroesController(IDota2HeroesService service)
        {
            _service = service;
        }
        #endregion


        // GET: Heroes page
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetHeroes()
        {
            var model = _service.GetAllHeroes();
            var results = model.ToViewModel();
            //return Json(results, JsonRequestBehavior.AllowGet);
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetHeroesPartial()
        {
            return PartialView("Partials/HeroesPartial");
        }
    }
}