using ACTFoundation.Core.ViewModels.Shared;
using System;
using System.Collections.Generic;

namespace ACTFoundation.Core.ViewModels.Partials.Blocks
{
    public class ProjectsCategoriesViewModel
    {
        public ProjectsCategoriesViewModel(Guid? projectsId, IEnumerable<TagViewModel> categories)
        {
            ProjectsId = projectsId;
            Categories = categories;
        }

        public IEnumerable<TagViewModel> Categories { get; set; }
        public Guid? ProjectsId { get; set; }

    }
}
