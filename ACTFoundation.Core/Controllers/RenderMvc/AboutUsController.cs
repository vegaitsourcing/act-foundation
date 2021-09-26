using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;
using System.Web.Mvc;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
    public class AboutUsController : BasePageController<AboutUs>
    {
        public ActionResult Index(AboutUs model)
        => CurrentTemplate(new AboutUsViewModel(CreatePageContext(model)));
    }
}