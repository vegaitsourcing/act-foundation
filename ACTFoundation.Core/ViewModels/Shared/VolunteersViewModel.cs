using ACTFoundation.Core.ViewModels.Partials.Items;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Shared
{
    public class VolunteersViewModel
    {
        public VolunteersViewModel(VolunteersShared volunteersShared)
        {
            BackgroundImage = new ImageViewModel(volunteersShared.BackgroundImage);
            Description = volunteersShared.Description;
            Link = new LinkViewModel(volunteersShared.Link);
            Title = volunteersShared.Title;
            Volunteers = volunteersShared.Volunteers.Select(item => new VolunteerItemViewModel(item));
        }

        public ImageViewModel BackgroundImage { get; }
        public string Description { get; }
        public LinkViewModel Link { get; }
        public string Title { get; }
        public IEnumerable<VolunteerItemViewModel> Volunteers { get; }
    }
}
