using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Core.ViewModels.Partials.Listing;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.DocumentTypes;
using ACTFoundation.Models.Generated;
using ACTFoundation.Search.Models;
using Umbraco.Web.Models;
using ACTFoundation.Core.ViewModels.Partials.Items;

namespace ACTFoundation.Core.Extensions
{
	public static class ViewModelExtensions
	{
		public static ImageViewModel ToViewModel(this Image image)
			=> image != null ? new ImageViewModel(image) : default(ImageViewModel);

		public static ImageViewModel TryCreateImageViewModel(this IPublishedContent content)
		{
			return (content as Image)?.ToViewModel();
		}

		public static XMLSitemapItemViewModel ToViewModel(this ISeo page)
			=> page != null ? new XMLSitemapItemViewModel(page) : default(XMLSitemapItemViewModel);

		public static SearchResultsItemViewModel ToViewModel(this ISearchResultItem item)
			=> new SearchResultsItemViewModel(item);

		public static IEnumerable<SearchResultsItemViewModel> ToViewModel(this IEnumerable<ISearchResultItem> items)
		{
			if (items == null) return Enumerable.Empty<SearchResultsItemViewModel>();

			return items.Select(ToViewModel);
		}

		public static IEnumerable<LinkViewModel> ToViewModel(this IEnumerable<Link> links)
        {
			return links.Any() && links != null
				? links.Select(x => new LinkViewModel(x))
				: Enumerable.Empty<LinkViewModel>();
        }

		public static IEnumerable<PurposeOfPaymentViewModel> ToViewModel(this IPublishedContent purposesPage)
        {
			if(purposesPage != null)
            {
				var page = purposesPage as PurposeOfPaymentPage;
				return page.PurposesOfPayment != null && page.PurposesOfPayment.Any()
					? page.PurposesOfPayment.Select(x => new PurposeOfPaymentViewModel(x))
					: Enumerable.Empty<PurposeOfPaymentViewModel>();

			}
			return Enumerable.Empty<PurposeOfPaymentViewModel>();
		}
	}
}
