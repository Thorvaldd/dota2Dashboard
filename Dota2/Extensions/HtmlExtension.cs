using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

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

        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string cssClass)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            if (actionName == currentAction && controllerName == currentController)
            {
                return htmlHelper.ActionLink(linkText, actionName, controllerName, null, new
                {
                    @class = cssClass
                });
            }

            return htmlHelper.ActionLink(linkText, actionName, controllerName, null, new {@class = cssClass});
        }
    }
}