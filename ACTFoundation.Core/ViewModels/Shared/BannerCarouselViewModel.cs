using ACTFoundation.Core.ViewModels.Partials.Items;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Shared
{
    public class BannerCarouselViewModel
    {
        public BannerCarouselViewModel(BannerCarousel bannerCarousel)
        {
            Items = bannerCarousel?.Items.Select(item => new BannerCarouselItemViewModel(item));
        }

        public IEnumerable<BannerCarouselItemViewModel> Items { get; }

    }
}
