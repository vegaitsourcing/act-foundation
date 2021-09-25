using ACTFoundation.Core.Contexts;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class ProjectsViewModel : PageViewModel
    {
        public ProjectsViewModel(IPageContext<Projects> context) : base(context)
        {
            ProjectContent = context.Page.ProjectContent;
        }

        public IEnumerable<IPublishedElement> ProjectContent { get; }
    }
}
