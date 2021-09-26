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
		public ActionResult GetMoreProjects(Guid projectsId, int pageNumber = 1, string categoryName = null)
		{
			var projectsPage = Umbraco.Content(projectsId) as Projects;
			var projects = projectsPage.DescendantsOfType(Project.ModelTypeAlias)
				.Where(project => string.IsNullOrEmpty(categoryName) || FilterProjectByCategory(project as Project, categoryName))
				.Select(project => new ProjectCardViewModel(project as Project))
				.ToList();
			
			return PartialView(new LoadmorePagination<ProjectCardViewModel>(projectsId, pageNumber, 6, projects));
		}

		private bool FilterProjectByCategory(Project project, string categoryName) =>
			project.ProjectContent.Where(content => content is ProjectTags)
					.Any(tag => (tag as ProjectTags).SelectedTags
					.Any(selectedTag => (selectedTag as TagItem)?.Name?.ToLower() == categoryName.ToLower()));
	}
}
