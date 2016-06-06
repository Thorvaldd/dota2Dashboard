using System;
using System.Web.Mvc;

namespace Dota2.Extensions
{
    public static class HtmlExtension
    {
        /// <summary>
        /// Byte image
        /// </summary>
        /// <param name="html"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        public static MvcHtmlString Image(this HtmlHelper html, byte[] image)
        {
            var img = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(image));
            return new MvcHtmlString("<img src='" + img +"' />");
        }
    }
}