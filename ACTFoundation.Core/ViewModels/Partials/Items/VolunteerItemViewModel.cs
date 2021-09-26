using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Partials.Items
{
    public class VolunteerItemViewModel
    {
        public VolunteerItemViewModel(VolunteerItem volunteerItem)
        {
            ContactLink = volunteerItem.ContactLink != null ? new LinkViewModel(volunteerItem.ContactLink) : null;
            Description = volunteerItem.Description;
            FullName = volunteerItem.FullName;
            Occupation = volunteerItem.Occupation;
            Picture = new ImageViewModel(volunteerItem.Picture);
        }

        public LinkViewModel ContactLink { get; }
        public string Description { get; }
        public string FullName { get; }
        public string Occupation { get; } 
        public ImageViewModel Picture { get; }
    }
}
