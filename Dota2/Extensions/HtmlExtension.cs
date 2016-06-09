using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using JetBrains.Annotations;

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
            return new MvcHtmlString("<img src='" + img + "' />");
        }

        public static string IsActive(this HtmlHelper html, [AspMvcController] string controllers = "", [AspMvcAction]string actions = "",
            string cssClass = "active")
        {
            ViewContext viewContext = html.ViewContext;

            bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;
            if (isChildAction)
                viewContext = html.ViewContext.ParentActionViewContext;

            RouteValueDictionary routeValues = viewContext.RouteData.Values;
            string currentAction = routeValues["action"].ToString();
            string currentController = routeValues["controller"].ToString();

            if (string.IsNullOrEmpty(actions))
                actions = currentAction;

            if (string.IsNullOrEmpty(controllers))
                controllers = currentController;

            string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();
            string[] accpetedController = controllers.Trim().Split(',').Distinct().ToArray();

            return acceptedActions.Contains(currentAction) && accpetedController.Contains(currentController)
                ? cssClass
                : string.Empty;
        }


        public static IHtmlString MyActionLink(
      this AjaxHelper ajaxHelper,
      string linkText,
      string actionName,
      string controllerName,
      AjaxOptions ajaxOptions
  )
        {
            var targetUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, null, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true);
            return MvcHtmlString.Create(ajaxHelper.GenerateLink(linkText, targetUrl, ajaxOptions ?? new AjaxOptions(), null));
        }

        private static string GenerateLink(
            this AjaxHelper ajaxHelper,
            string linkText,
            string targetUrl,
            AjaxOptions ajaxOptions,
            IDictionary<string, object> htmlAttributes
        )
        {
            var a = new TagBuilder("a")
            {
                InnerHtml = linkText
            };
            a.MergeAttributes<string, object>(htmlAttributes);
            a.MergeAttribute("href", targetUrl);
            a.MergeAttributes<string, object>(ajaxOptions.ToUnobtrusiveHtmlAttributes());
            return a.ToString(TagRenderMode.Normal);
        }

    }



}