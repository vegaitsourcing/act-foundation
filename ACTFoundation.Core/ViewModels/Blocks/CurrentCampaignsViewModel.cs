using ACTFoundation.Models.Generated;
using System;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Blocks
{
    public class CurrentCampaignsViewModel
    {
        public CurrentCampaignsViewModel(CurrentCampaigns campaigns)
        {
            CampaignId = campaigns.Campaigns.FirstOrDefault()?.Key;
        }
        public Guid? CampaignId { get; }
    }
}
