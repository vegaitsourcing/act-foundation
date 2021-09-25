using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using ACTFoundation.Common;
using ACTFoundation.Core.Extensions;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.HttpHandlers
{
	public class RobotsHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			HttpContextBase contextBase = context.ToBase();
			RobotsTxtSource robotsTxtSource;

			if (!Enum.TryParse(AppSettings.RobotsTxtSource, out robotsTxtSource))
			{
				Current.Logger.Warn<RobotsHandler>("Invalid robots.txt source");
				throw new HttpException((int) HttpStatusCode.InternalServerError, "Invalid robots.txt source, please check your configs.");
			}

			if (robotsTxtSource == RobotsTxtSource.File)
			{
				string path = context.Server.MapPath(context.Request.RawUrl);
				HandleFileRequest(path, contextBase);
				return;
			}
			
			// Ensure there is an Umbraco context that is necessary for data access.
			var umbracoContextFactory = Current.Factory.GetInstance(typeof(IUmbracoContextFactory)) as IUmbracoContextFactory;
			if(umbracoContextFactory == null) throw new HttpException((int) HttpStatusCode.InternalServerError, "Can't get Umbraco Context Factory.");

			contextBase.Response.Clear();
			contextBase.Response.ContentType = "text/plain";

			using (var contextReference = umbracoContextFactory.EnsureUmbracoContext(contextBase))
			{
				var umbracoContext = contextReference.UmbracoContext;
				// Lets try and find the robots file contents from Umbraco.
				/*
				var siteSettings = umbracoContext
						.Content
						.GetAtRoot()
						.FirstOrDefault(c => context.Request.Url.AbsoluteUri.StartsWith(c.Url(mode: UrlMode.Absolute)))
					as ISiteSettings;
				

				contextBase.Response.Write(siteSettings?.Robots ?? string.Empty);
				*/
			}

			contextBase.Response.End();
		}

		public bool IsReusable => true;

		private static void HandleFileRequest(string path, HttpContextBase contextBase)
		{
			if (!System.IO.File.Exists(path))
			{
				throw new FileNotFoundException("Can't find robots.txt");
			}

			Current.Logger.Debug<RobotsHandler>("Streaming specified robots file from disk.");

			contextBase.Response.TransmitFileContent(path);
		}
	}

	public enum RobotsTxtSource
	{
		Cms,
		File
	}
}
