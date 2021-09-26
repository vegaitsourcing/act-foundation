using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Blocks;
using ACTFoundation.Core.ViewModels.Partials.Items;
using ACTFoundation.Core.ViewModels.Shared;
using System.Linq;
using ACTFoundation.Models.Generated;
using ACTFoundation.Core.ViewModels.Partials.Blocks;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class AboutUsViewModel : PageViewModel
    {
        public AboutUsViewModel(IPageContext<AboutUs> context) : base(context)
        {
            var bannerCarousel = context.Page.Content.FirstOrDefault(item => item is BannerDefault);
            if (bannerCarousel != null)
            {
                OurStoryBanner = new BannerCarouselItemViewModel(bannerCarousel as BannerDefault);
            }

            var whoWeAre = context.Page.Content.FirstOrDefault(item => item is WhoWeAreBlock);
            if (bannerCarousel != null)
            {
                WhoWeAre = new WhoWeAreBlockViewModel(whoWeAre as WhoWeAreBlock);
            }

            var volunteers = context.Page.Content.FirstOrDefault(item => item is Volunteers);
            if (bannerCarousel != null)
            {
                Volunteers = new VolunteersViewModel(volunteers as Volunteers);
            }

            var ourStory = context.Page.Content.FirstOrDefault(item => item is OurStoryBlock);
            if (bannerCarousel != null)
            {
                OurStory = new OurStoryViewModel(ourStory as OurStoryBlock);
            }

            var ourMission = context.Page.Content.FirstOrDefault(item => item is OurMissionBlock);
            if (bannerCarousel != null)
            {
                OurMission = new OurMissionViewModel(ourMission as OurMissionBlock);
            }
        }

        //private TViewModel GetViewModel<TGenerated, TViewModel>(IPublishedElement element) 
        //{
        //    return element is TGenerated ? (TViewModel)Activator.CreateInstance(typeof(TViewModel), element) : null;
        //}
        public BannerCarouselItemViewModel OurStoryBanner { get; set; }

        public WhoWeAreBlockViewModel WhoWeAre { get; set; }

        public VolunteersViewModel Volunteers { get; set; }
        public OurStoryViewModel OurStory { get; set; }

        public OurMissionViewModel OurMission { get; set; }
    }
}