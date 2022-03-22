using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;
using System.Web.Mvc;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
    public class CampaignController : BasePageController<Campaign>
    {
        public ActionResult Index(Campaign model)
            => View("~/Views/Campaign.cshtml",new CampaignViewModel(CreatePageContext(model)));
    }
}
