using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Pages
{
	public class DonateViewModel : PageViewModel
	{
		public DonateViewModel(IPageContext<Donate> context) : base(context)
		{
			var bannerCarousel = context.Page.DonateContent;
			if (bannerCarousel != null && bannerCarousel is BannerCarousel)
			{
				DonateContent = new BannerCarouselViewModel(bannerCarousel as BannerCarousel);
			}
		}

		public BannerCarouselViewModel DonateContent { get; set; }
	}
}
