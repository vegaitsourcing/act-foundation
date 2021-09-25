using System.Web.Mvc;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
	public class ProjectsController : BasePageController<Projects>
	{
		public ActionResult Index(Projects model)
			=> CurrentTemplate(new ProjectsViewModel(CreatePageContext(model)));
	}
}
