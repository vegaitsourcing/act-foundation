using System.Web.Mvc;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
	public class ProjectController : BasePageController<Project>
	{
		public ActionResult Index(Project model) 
			=> CurrentTemplate(new ProjectViewModel(CreatePageContext(model)));
	}
}
