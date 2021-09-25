using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Partials.Items
{
    public class BannerCarouselItemViewModel
    {
        public BannerCarouselItemViewModel(BannerDefault bannerDefault)
        {
            BackgroundImage = new ImageViewModel(bannerDefault.BackgroundImage);
            ButtonLinks = bannerDefault.ButtonLinks.Select(bl => new ButtonLinkItemViewModel(bl));
            Description = bannerDefault.Description;
            Title = bannerDefault.Title;
        }

        public ImageViewModel BackgroundImage { get; }
        public IEnumerable<ButtonLinkItemViewModel> ButtonLinks { get; }
        public string Description { get; }
        public string Title { get; }
    }
}
