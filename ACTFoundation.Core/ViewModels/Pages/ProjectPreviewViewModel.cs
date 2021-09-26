using ACTFoundation.Core.Extensions;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class ProjectPreviewViewModel
    {
        private const int ShortTextLength = 208;

        public ProjectPreviewViewModel(Project project)
        {
            Title = project.Title;
            TextPreview = GetTextPreview(project.Text.ToHtmlString().StripHtml());
            MainImage = project.MainImage.ToViewModel();
            Tags = project.Tags?.Select(tag => new TagViewModel(tag as TagItem));
            Link = project.Url();
        }

        public string Title { get; }
        public ImageViewModel MainImage { get; }
        public IEnumerable<TagViewModel> Tags { get; }
        public IHtmlString TextPreview { get; }
        public string Link { get; }

        private IHtmlString GetTextPreview(string text)
        {
            return text.Length < ShortTextLength ? new HtmlString(text) : new HtmlString(text.Substring(0, ShortTextLength) + "...");
        }
    }
}
