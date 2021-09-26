using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Partials.Blocks;
using ACTFoundation.Core.ViewModels.Partials.Items;
using ACTFoundation.Models.Generated;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class DonateViewModel : PageViewModel
    {
        public DonateViewModel(IPageContext<Donate> context) : base(context)
        {
            var bannerCarousel = context.Page.DonateContent.FirstOrDefault(item => item is BannerDefault);
            if (bannerCarousel != null)
            {
                DonateContent = new BannerCarouselItemViewModel(bannerCarousel as BannerDefault);
            }

            var donateAccountsBlock = context.Page.DonateContent.FirstOrDefault(item => item is DonateAccountsBlock);
            if (donateAccountsBlock != null)
            {
                DonateAccountsBlockViewModel = new DonateAccountsBlockViewModel(donateAccountsBlock as DonateAccountsBlock);
            }
        }

        public BannerCarouselItemViewModel DonateContent { get; }

        public DonateAccountsBlockViewModel DonateAccountsBlockViewModel { get; }
    }
}
