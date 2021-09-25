using System.Web.Mvc;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
	public class VolunteerController : BasePageController<Volunteer>
	{
		public ActionResult Index(Volunteer model)
			=> CurrentTemplate(new VolunteerViewModel(CreatePageContext(model)));
	}
}
