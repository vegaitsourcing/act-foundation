using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Web.Composing;

namespace ACTFoundation.Core.ViewModels.Partials.Blocks
{
    public class ProjectCardViewModel
    {
        private const int ShortTextLength = 208;

        public ProjectCardViewModel(Project project)
        {
            Title = project.Title;
            string temp = project.Text.ToHtmlString().StripHtml();
            Description = (temp.Length > ShortTextLength) ? temp.Substring(0, ShortTextLength) : temp;

            Url = Current.UmbracoContext.UrlProvider.GetUrl(project.Id);
            Image = new ImageViewModel(project.MainImage);
            Tags = (project.ProjectContent.FirstOrDefault(content => content is ProjectTags) as ProjectTags)?
                .SelectedTags?.Select(tag => new TagViewModel(tag as TagItem)) ?? new List<TagViewModel>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public ImageViewModel Image { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}
