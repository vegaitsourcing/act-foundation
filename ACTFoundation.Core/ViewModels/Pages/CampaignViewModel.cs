using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.Extensions;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class CampaignViewModel : PageViewModel
    {
        private const int RelatedCampaignsToDisplay = 4;
        public CampaignViewModel(IPageContext<Campaign> context) : base(context)
        {
            PageTitle = context.Page.PageTitle;
            NavigationTitle = context.Page.NavigationTitle;
            Title = context.Page.Title;
            MainImage = context.Page.MainImage.ToViewModel();
            Author = context.Page.Author;
            Text = context.Page.Text;
            CreateDate = context.Page.CreateDate;
            Tags = context.Page.Tags?.Select(tag => new TagViewModel(tag as TagItem));
            CampaignId = context.Page.Id;
            RelatedCampaigns = GetRelatedCampaigns(context.Page.Parent.Children);
        }

        public string PageTitle { get; }
        public string NavigationTitle { get; }
        public string Title { get; }
        public ImageViewModel MainImage { get; }
        public string Author { get; }
        public IEnumerable<TagViewModel> Tags { get; }
        public DateTime CreateDate { get; }
        public IHtmlString Text { get; }
        public IEnumerable<CampaignPreviewViewModel> RelatedCampaigns { get; }

        private int CampaignId { get; }

        private IEnumerable<CampaignPreviewViewModel> GetRelatedCampaigns(IEnumerable<IPublishedContent> contentItems)
        {
            var relatedCampaigns = contentItems
                .Select(campaign => campaign as Campaign)
                .Where(campaign => campaign.Id != CampaignId && campaign.Tags != null && Tags != null && campaign.Tags.Any(tag => MatchingProvidedTags(tag as TagItem, Tags)))
                .Take(RelatedCampaignsToDisplay)
                .Select(campaign => new CampaignPreviewViewModel(campaign))
                .ToArray();

            if (relatedCampaigns == null || relatedCampaigns.Length == 0)
            {
                return GetNewestCampaigns(contentItems, RelatedCampaignsToDisplay);
            }
            return relatedCampaigns;
        }
        private IEnumerable<CampaignPreviewViewModel> GetNewestCampaigns(IEnumerable<IPublishedContent> contentItems, int count)
        {
            return contentItems
                .Select(campaign => campaign as Campaign)
                .Where(campaign => campaign.Id != CampaignId)
                .OrderByDescending(campaign => campaign.CreateDate)
                .Take(count)
                .Select(campaign => new CampaignPreviewViewModel(campaign))
                .ToArray();
        }

        private bool MatchingProvidedTags(TagItem tag, IEnumerable<TagViewModel> tags)
            => tags.Any(t => t.Name == tag.Name);
    }
}
