using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Partials.Items;
using ACTFoundation.Models.Generated;


namespace ACTFoundation.Core.ViewModels.Pages
{
	public class VolunteerViewModel : PageViewModel
	{
		public VolunteerViewModel(IPageContext<Volunteer> context) : base(context)
		{
			VolunteerContent = new BannerCarouselItemViewModel(context.Page?.VolunteerContent);
		}

		public BannerCarouselItemViewModel VolunteerContent { get; }
	}
}
