using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System;
using Umbraco.Core;
using Umbraco.Web;

namespace ACTFoundation.Core.ViewModels.Partials.Layout
{
    public class ProjectViewModel
    {
        private const int ShortTextLength = 208;

        public ProjectViewModel(Project project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));

            this.Title = project.Title;
            this.ShortText = project.Text.ToHtmlString().StripHtml().Substring(0, ShortTextLength);
            this.MainImage = new ImageViewModel(project.MainImage);
            this.Url = project.Url();
        }

        public string Title { get; set; }
        public string ShortText { get; set; }
        public ImageViewModel MainImage { get; set; }
        public string Url { get; set; }
    }
}
