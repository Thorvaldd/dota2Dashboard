using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using HtmlAgilityPack;

namespace Dota2.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/dotabuff")]
    public class DotaBuffController : ApiController
    {
        // GET api/<controller>
        [Route("main")]
        public async Task<HttpResponseMessage> Get()
        {
            var response = new HttpResponseMessage();
               
                var htmlString = LoadDocumentNode("http://www.dotabuff.com/search?utf8=%E2%9C%93&q=76561198053977899&commit=Search");

                return response;
            
        }


        private HtmlNode LoadDocumentNode(string url)
        {
            var html = new HtmlDocument();

            using (var wc = new WebClient())
            {
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:43.0) Gecko/20100101 Firefox/43.0");
                wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                wc.Headers.Add("Accept-Language", "de,en-US;q=0.7,en;q=0.3");
                wc.Encoding = Encoding.UTF8;


                html.Load(wc.DownloadString(url));
            }

            return html.DocumentNode;
        }
    }
}