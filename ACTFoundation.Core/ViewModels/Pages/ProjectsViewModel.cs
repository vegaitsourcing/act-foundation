using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Partials.Blocks;
using ACTFoundation.Core.ViewModels.Partials.Items;
using ACTFoundation.Models.Generated;
using System;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class ProjectsViewModel : PageViewModel
    {
        public ProjectsViewModel(IPageContext<Projects> context) : base(context)
        {
            var bannerCarousel = context.Page.ProjectContent.FirstOrDefault(item => item is BannerDefault);
            if (bannerCarousel != null)
            {
                BannerItem = new BannerCarouselItemViewModel(bannerCarousel as BannerDefault);
            }
            ProjectsId = context.Page?.Key;
            DonateAccountsBlock = context.Page.ProjectContent
                .FirstOrDefault(content => content is DonateAccountsBlock) is DonateAccountsBlock donateAccountsBlock ?
                new DonateAccountsBlockViewModel(donateAccountsBlock) : null;
        }

        public Guid? ProjectsId { get; set; }
        public DonateAccountsBlockViewModel DonateAccountsBlock { get; set; }
        public BannerCarouselItemViewModel BannerItem { get; set; }
    }
}
