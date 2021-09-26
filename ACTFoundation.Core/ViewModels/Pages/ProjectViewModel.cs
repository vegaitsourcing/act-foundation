using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.Extensions;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class ProjectViewModel : PageViewModel
    {
        private const int RelatedProjectsToDisplay = 2;

        public ProjectViewModel(IPageContext<Project> context) : base(context)
        {
            Title = context.Page.Title;
            MainImage = context.Page.MainImage.ToViewModel();
            Text = context.Page.Text;
            CreateDate = context.Page.CreateDate;
            Tags = context.Page.Tags?.Select(tag => new TagViewModel(tag as TagItem));
            ProjectId = context.Page.Id;
            RelatedProjects = GetRelatedProjects(context.Page.Parent.Children);
        }

        public string Title { get; }
        public ImageViewModel MainImage { get; }
        public IEnumerable<TagViewModel> Tags { get; }
        public IHtmlString Text { get; }
        public System.DateTime CreateDate { get; }
        public IEnumerable<ProjectPreviewViewModel> RelatedProjects { get; }

        private int ProjectId { get; }

        private IEnumerable<ProjectPreviewViewModel> GetRelatedProjects(IEnumerable<IPublishedContent> contentItems)
        {
            var relatedProjects = contentItems
                .Select(project => project as Project)
                .Where(project => project.Id != ProjectId && project.Tags != null && Tags != null && project.Tags.Any(tag => MatchingProvidedTags(tag as TagItem, Tags)))
                .Take(RelatedProjectsToDisplay)
                .Select(project => new ProjectPreviewViewModel(project))
                .ToArray();

            if (relatedProjects == null || relatedProjects.Length == 0)
            {
                return GetNewestProjects(contentItems, RelatedProjectsToDisplay);
            }
            return relatedProjects;
        }

        private IEnumerable<ProjectPreviewViewModel> GetNewestProjects(IEnumerable<IPublishedContent> contentItems, int count)
        {
            return contentItems
                .Select(project => project as Project)
                .Where(project => project.Id != ProjectId)
                .OrderByDescending(project => project.CreateDate)
                .Take(count)
                .Select(project => new ProjectPreviewViewModel(project))
                .ToArray();
        }
        
        private bool MatchingProvidedTags(TagItem tag, IEnumerable<TagViewModel> tags)
            => tags.Any(t => t.Name == tag.Name);

        private class MatchingProjects
        {
            public MatchingProjects(ProjectPreviewViewModel matchingProject, int matchingProjectNumber)
            {
                MatchingProject = matchingProject;
                MatchingProjectNumber = matchingProjectNumber;
            }

            private ProjectPreviewViewModel MatchingProject { get; }
            private int MatchingProjectNumber { get; }
        }
    }
}
