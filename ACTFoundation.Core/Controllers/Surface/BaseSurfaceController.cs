using System.Net;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.Extensions;

namespace ACTFoundation.Core.Controllers.Surface
{
	public abstract class BaseSurfaceController : SurfaceController
	{
		protected ISiteContext CreateSiteContext()
			=> Umbraco.CreateSiteContext();
		
		/// <summary>
		/// Called when an unhandled exception occurs on a controller level (during action processing).
		/// </summary>
		/// <param name="filterContext">Information about the current request.</param>
		protected override void OnException(ExceptionContext filterContext)
		{
			if (filterContext.ExceptionHandled)
			{
				return;
			}

			Logger.Error(GetType(), filterContext.Exception, $"An unhandled exception occurred on surface controller action '{filterContext.RouteData.Values["action"]}'!");

			filterContext.ExceptionHandled = true;

			if (filterContext.IsChildAction)
	        {
				// Return empty result, to prevent the whole page failure.
		        filterContext.Result = new EmptyResult();
		        return;
	        }

			filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
		}
	}
}
