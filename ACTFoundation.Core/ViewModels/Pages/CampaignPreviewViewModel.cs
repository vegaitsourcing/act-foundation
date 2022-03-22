using ACTFoundation.Core.Extensions;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class CampaignPreviewViewModel
    {
        private const int ShortTextLength = 208;
        public CampaignPreviewViewModel(Campaign campaign)
        {
            Title = campaign.Title;
            TextPreview = new HtmlString(campaign.Text.ToHtmlString().StripHtml().GetTextPreview(ShortTextLength));
            MainImage = campaign.MainImage.ToViewModel();
            Tags = campaign.Tags?.Select(tag => new TagViewModel(tag as TagItem));
            Link = campaign.Url();

        }

        public string Title { get; }
        public ImageViewModel MainImage { get; }
        public IEnumerable<TagViewModel> Tags { get; }
        public IHtmlString TextPreview { get; }
        public string Link { get; }
    }
}
