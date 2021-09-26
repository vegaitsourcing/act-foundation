using ACTFoundation.Core.Caching;
using ACTFoundation.Core.Models;
using ACTFoundation.Core.ViewModels.Partials.Blocks;
using ACTFoundation.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace ACTFoundation.Core.Controllers.Surface.Partials
{
    public class ProjectsListingController : SurfaceController 
    {
        private const int ItemsPerPage = 6;
        private const string CacheName = "projects-";

        public ActionResult GetMoreProjects(Guid projectsId, int pageNumber = 1, string categoryName = null)
		{
            var projects = GetArticlesFromCache(projectsId, pageNumber, categoryName);
			
			return PartialView(new LoadmorePagination<ProjectCardViewModel>(projectsId, pageNumber, ItemsPerPage, projects));
		}

		private bool FilterProjectByCategory(Project project, string categoryName) =>
			project.ProjectContent.Where(content => content is ProjectTags)
					.Any(tag => (tag as ProjectTags).SelectedTags
					.Any(selectedTag => (selectedTag as TagItem)?.Name?.ToLower() == categoryName.ToLower()));

        private List<ProjectCardViewModel> GetArticlesFromCache(Guid projectsId, int pageNumber, string categoryName)
        {
            var key = $"{CacheName}{projectsId}-{pageNumber}-${categoryName}";

            if (!(CacheHelper.Instance.TryRead(key) is List<ProjectCardViewModel> projects))
            {
                var projectsPage = Umbraco.Content(projectsId) as Projects;
                projects = projectsPage.DescendantsOfType(Project.ModelTypeAlias)
                    .OrderByDescending(x => x.UpdateDate)
                    .Where(project => string.IsNullOrEmpty(categoryName) || FilterProjectByCategory(project as Project, categoryName))
                    .Select(project => new ProjectCardViewModel(project as Project))
                    .ToList();

                CacheHelper.Instance.Write(key, projects);
            }
            return projects;
        }
    }
}
