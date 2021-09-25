using System.Web.Mvc;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
	public class DonateController : BasePageController<Donate>
	{
		public ActionResult Index(Donate model)
			=> CurrentTemplate(new DonateViewModel(CreatePageContext(model)));
	}
}
