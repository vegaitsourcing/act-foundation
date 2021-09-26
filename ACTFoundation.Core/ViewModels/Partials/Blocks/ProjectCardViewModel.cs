using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
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
            Description = project.Text.ToHtmlString().StripHtml().Substring(0, ShortTextLength);
            Url = Current.UmbracoContext.UrlProvider.GetUrl(project.Id);
            Image = new ImageViewModel(project.MainImage);
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public ImageViewModel Image { get; set; }
    }
}
