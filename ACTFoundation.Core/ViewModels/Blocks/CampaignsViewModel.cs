using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Blocks
{
    public class CampaignsViewModel
    {
        public CampaignsViewModel(Campaigns campaigns)
        {
            Title = campaigns.Name;
            Headline = campaigns.Headline;
        }
        public string Title { get; }
        public string Headline { get; }
    }
}
