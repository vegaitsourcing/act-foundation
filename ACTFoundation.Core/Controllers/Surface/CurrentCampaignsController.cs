using ACTFoundation.Core.Caching;
using ACTFoundation.Core.Models;
using ACTFoundation.Core.ViewModels.Blocks;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace ACTFoundation.Core.Controllers.Surface
{
    public class CurrentCampaignsController : SurfaceController
    {
        private const int ItemsPerPage = 6;
        private const string CacheName = "campaigns-";

        public ActionResult GetCampaigns(Guid campaignId, int pageNumber = 1)
        {
            var campaigns = GetCampaignsFromCache(campaignId, pageNumber);
            var campaignsPage = Umbraco.Content(campaignId) as Campaigns;

            var temp =
                new LoadCampaignsViewModel(
                    new LoadmorePagination<CampaignPreviewViewModel>(campaignId, pageNumber, ItemsPerPage, campaigns)
                    , new CampaignsViewModel(campaignsPage));
            return PartialView(temp);
        }

        public ActionResult GetMoreCampaigns(Guid campaignId, int pageNumber = 1)
        {
            var campaigns = GetCampaignsFromCache(campaignId, pageNumber);

            return PartialView(new LoadmorePagination<CampaignPreviewViewModel>(campaignId, pageNumber, ItemsPerPage, campaigns));
        }

        private List<CampaignPreviewViewModel> GetCampaignsFromCache(Guid campaignId, int pageNumber)
        {
            var key = $"{CacheName}{campaignId}-{pageNumber}";
            if (!(CacheHelper.Instance.TryRead(key) is List<CampaignPreviewViewModel> campaigns))
            {
                var campaignPage = Umbraco.Content(campaignId) as Campaigns;
                campaigns = campaignPage.DescendantsOfType(Campaign.ModelTypeAlias)
                    .OrderByDescending(x => x.UpdateDate)
                    .Select(x => new CampaignPreviewViewModel(x as Campaign))
                    .ToList();
                CacheHelper.Instance.Write(key, campaigns);
            }

            return campaigns;
        }
    }
}
