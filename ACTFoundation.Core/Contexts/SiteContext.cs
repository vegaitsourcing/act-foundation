using System;
using Umbraco.Web;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.Contexts
{
	public class SiteContext : ISiteContext
	{
		public SiteContext(UmbracoHelper umbracoHelper)
		{
			UmbracoHelper = umbracoHelper ?? throw new ArgumentNullException(nameof(umbracoHelper));

			LazyCurrentPage = new Lazy<IPage>(() => UmbracoHelper.AssignedContentItem as IPage);
			LazyHome = new Lazy<Home>(() => UmbracoHelper.AssignedContentItem?.AncestorOrSelf<Home>());
		}

		public IPage CurrentPage => LazyCurrentPage.Value;
		public Home Home => LazyHome.Value;

		protected UmbracoHelper UmbracoHelper { get; }

		private Lazy<IPage> LazyCurrentPage { get; }
		private Lazy<Home> LazyHome { get; }
	}
}
