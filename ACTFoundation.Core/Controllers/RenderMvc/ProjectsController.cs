using System.Web.Mvc;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;
using Umbraco.Web;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
	public class ProjectsController : BasePageController<Projects>
	{
		private readonly IUmbracoContextAccessor _umbracoContextAccessor;

		public ProjectsController(IUmbracoContextAccessor umbracoContextAccessor)
        {
			_umbracoContextAccessor = umbracoContextAccessor;
		}

		public ActionResult Index(Projects model)
			=> CurrentTemplate(new ProjectsViewModel(CreatePageContext(model), _umbracoContextAccessor));
	}
}
