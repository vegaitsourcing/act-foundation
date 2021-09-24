using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ACTFoundation.Core.Extensions
{
	public static class HtmlHelperExtensions
	{
		public static MvcHtmlString Action<TController>(this HtmlHelper htmlHelper, Func<TController, string> actionNameFunc, object routeValues = null)
			where TController : Controller
		{
			if (actionNameFunc == null) throw new ArgumentNullException(nameof(actionNameFunc));

			var controllerName = typeof(TController).Name.RemoveControllerSuffix();
			var actionName = actionNameFunc(null);

			return htmlHelper.Action(actionName, controllerName, routeValues);
		}

		public static void RenderAction<TController>(this HtmlHelper htmlHelper, Func<TController, string> actionNameFunc, object routeValues = null)
			where TController : Controller
		{
			if (actionNameFunc == null) throw new ArgumentNullException(nameof(actionNameFunc));

			var controllerName = typeof(TController).Name.RemoveControllerSuffix();
			var actionName = actionNameFunc(null);

			htmlHelper.RenderAction(actionName, controllerName, routeValues);
		}

		#region [Render Partial]
		public static void RenderNestedContent<TNestedContent>(this HtmlHelper html, TNestedContent model, string partialViewName = null)
		{
			string partialName = !string.IsNullOrWhiteSpace(partialViewName)
				? partialViewName
				: (model?.GetType() ?? typeof(TNestedContent)).Name;

			html.RenderPartial(partialName,
							model,
							new ViewDataDictionary(html.ViewData) { Model = model }); // ViewDataDictionary parameter is necessary to allow passing null for model value.
		}

		public static MvcHtmlString NestedContent<TNestedContent>(this HtmlHelper html, TNestedContent model, string partialViewName = null) where TNestedContent : class
			=> html.Partial(!string.IsNullOrWhiteSpace(partialViewName) ? partialViewName : (model?.GetType() ?? typeof(TNestedContent)).Name,
							model,
							new ViewDataDictionary(html.ViewData) { Model = model });   // ViewDataDictionary parameter is necessary to allow passing null for model value.
		#endregion
	}
}
