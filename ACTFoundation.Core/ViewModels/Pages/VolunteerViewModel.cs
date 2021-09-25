using ACTFoundation.Core.Contexts;
using ACTFoundation.Models.Generated;


namespace ACTFoundation.Core.ViewModels.Pages
{
	public class VolunteerViewModel : PageViewModel
	{
		public VolunteerViewModel(IPageContext<Volunteer> context) : base(context)
		{
			VolunteerContent = context.Page.VolunteerContent;
		}

		public BannerDefault VolunteerContent { get; }
	}
}
