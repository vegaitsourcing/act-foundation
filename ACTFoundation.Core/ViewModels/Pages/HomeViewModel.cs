using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Partials.Testimonials;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class HomeViewModel : PageViewModel
	{
		public HomeViewModel(IPageContext<Home> context) : base(context)
		{
			var bannerCarousel = context.Page.MainContent.FirstOrDefault(item => item is BannerCarousel);
            if(bannerCarousel != null)
			{
				BannerCarousel = new BannerCarouselViewModel(bannerCarousel as BannerCarousel);
            }

			var testimonials = context.Page.MainContent.FirstOrDefault(item => item is Testimonials);
			if(testimonials != null)
            {
				Testimonials = new TestimonialsViewModel(testimonials as Testimonials);
            }
		}

		public BannerCarouselViewModel BannerCarousel { get; set; }

		public TestimonialsViewModel Testimonials { get; }
    }
}
