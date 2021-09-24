using System;
using Umbraco.Web;
using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.Extensions;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.DocumentTypes;
using ACTFoundation.Models.Extensions;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Partials.Layout
{
	public class OpenGraphViewModel
	{
		public OpenGraphViewModel(IPageContext<IPage> context, ISeo seo)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));
			if (seo == null) throw new ArgumentNullException(nameof(seo));

			Title = GetTitle(context.Page);
			Description = GetDescription(context.Page);
			//TODO if Open Graph Image is null use banner image
			Image = context.Page.OpenGraphImage.ToViewModel();
			CanonicalUrl = seo.GetCanonicalUrl(context.SiteSettings.CanonicalDomain);
			Locale = context.Page.GetCultureFromDomains();
			SiteName = context.SiteSettings.SiteName;
		}

		public string Title { get; }
		public string Description { get; }
		public ImageViewModel Image { get; }
		public string CanonicalUrl { get; }
		public string Locale { get; }
		public string SiteName { get; }

		private static string GetTitle(IPage page)
		{
			if (!string.IsNullOrWhiteSpace(page.OpenGraphTitle)) return page.OpenGraphTitle;
			if (!string.IsNullOrWhiteSpace(page.SeoTitle)) return page.SeoTitle;
			if (!string.IsNullOrWhiteSpace(page.PageTitle)) return page.PageTitle;

			return page.Name;
		}

		private static string GetDescription(IPage page)
		{
			if (!string.IsNullOrWhiteSpace(page.OpenGraphDescription)) return page.OpenGraphDescription;

			return page.SeoDescription;
		}
	}
}
