using System.Web.Mvc;

namespace Dota2.Controllers
{
    public class BaseController : Controller
    {
        protected override JsonResult Json(object data, string contenttype, System.Text.Encoding contentEncoding,
            JsonRequestBehavior behavior)
        {
            return new JsonResult
            {
                Data =  data,
                ContentType = contenttype,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = int.MaxValue
            };
        }
    }
}