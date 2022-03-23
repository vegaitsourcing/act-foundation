using ACTFoundation.Core.Models;
using ACTFoundation.Core.ViewModels.Pages;

namespace ACTFoundation.Core.ViewModels.Blocks
{
    public class LoadCampaignsViewModel
    {
        public LoadCampaignsViewModel(LoadmorePagination<CampaignPreviewViewModel> loadmorePaginationItems, CampaignsViewModel campaigns)
        {
            LoadPaginationItems = loadmorePaginationItems;
            Campaigns = campaigns;
        }
        public LoadmorePagination<CampaignPreviewViewModel> LoadPaginationItems { get; set; }
        public CampaignsViewModel Campaigns { get; set; }
    }
}
