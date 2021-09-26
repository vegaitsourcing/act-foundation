using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Blocks;
using ACTFoundation.Core.ViewModels.Partials.Layout;
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
            if (bannerCarousel != null)
            {
                BannerCarousel = new BannerCarouselViewModel(bannerCarousel as BannerCarousel);
            }

            var partnerLogos = context.Page.MainContent.FirstOrDefault(item => item is PartnerLogosItem);
            if (partnerLogos != null)
            {
                PartnerLogos = new PartnerLogosViewModel(partnerLogos as PartnerLogosItem);
            }


            var testimonials = context.Page.MainContent.FirstOrDefault(item => item is Testimonials);
            if (testimonials != null)
            {
                Testimonials = new TestimonialsViewModel(testimonials as Testimonials);
            }

            var volunteers = context.Page.MainContent.FirstOrDefault(item => item is Volunteers);
            if (volunteers != null)
            {
                Volunteers = new VolunteersViewModel(volunteers as Volunteers);
            }

            var donateBlock = context.Page.MainContent.FirstOrDefault(item => item is DonateBlock);
            if (donateBlock != null)
            {
                DonateBlock = new DonateBlockViewModel((DonateBlock)donateBlock);
            }
        }

        public BannerCarouselViewModel BannerCarousel { get; set; }

        public TestimonialsViewModel Testimonials { get; }

        public VolunteersViewModel Volunteers { get; }

        public DonateBlockViewModel DonateBlock { get; }

        public PartnerLogosViewModel PartnerLogos { get; }
    }
}
