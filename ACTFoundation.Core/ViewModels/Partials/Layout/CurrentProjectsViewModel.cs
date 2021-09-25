using ACTFoundation.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Partials.Layout
{
    public class CurrentProjectsViewModel
    {
        public CurrentProjectsViewModel(CurrentProjects currentProjects)
        {
            if (currentProjects == null) throw new ArgumentNullException(nameof(currentProjects));

            this.Title = currentProjects.Title;
            this.Subtitle = currentProjects.Subtitle;
            this.Projects = currentProjects.Projects.Select(project => new Project(project)).Select(project => new ProjectViewModel(project)).ToList();
        }

        public string Title { get; set; }
        public string Subtitle { get; set; }
        public List<ProjectViewModel> Projects { get; set; }

    }
}
