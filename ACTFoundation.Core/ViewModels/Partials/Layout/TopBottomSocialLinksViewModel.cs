using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Partials.Layout
{
    public class TopBottomSocialLinksViewModel
    {
        public TopBottomSocialLinksViewModel(ITopBottomSocialLinks topBottomSocialLinks)
        {
            DonateLink = new LinkViewModel(topBottomSocialLinks.DonateLink);
            FacebookLink = topBottomSocialLinks.FacebookLink;
            LinkedinLink = topBottomSocialLinks.LinkedinLink;
            InstagramLink = topBottomSocialLinks.InstagramLink;
        }

        public LinkViewModel DonateLink { get; }

        public string FacebookLink { get; }

        public string LinkedinLink { get; }

        public string InstagramLink { get; }
    }
}
