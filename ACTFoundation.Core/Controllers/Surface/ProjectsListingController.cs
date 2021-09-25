using ACTFoundation.Core.Models;
using ACTFoundation.Core.ViewModels.Partials.Blocks;
using ACTFoundation.Models.Generated;
using System;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace ACTFoundation.Core.Controllers.Surface.Partials
{
    public class ProjectsListingController : SurfaceController 
    {
		public ActionResult GetMoreProjects(Guid projectsId, int pageNumber = 1)
		{
			var projectsPage = Umbraco.Content(projectsId) as Projects;
			var articles = projectsPage.DescendantsOfType(Project.ModelTypeAlias)
				.Select(x => new ProjectCardViewModel(x as Project))
				.ToList();

			return PartialView(new LoadmorePagination<ProjectCardViewModel>(projectsId, pageNumber, 6, articles));
		}
	}
}
