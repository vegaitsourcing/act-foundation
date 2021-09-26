using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Partials.Items;
using ACTFoundation.Models.Generated;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Pages
{
	public class VolunteerViewModel : PageViewModel
	{
		public VolunteerViewModel(IPageContext<Volunteer> context) : base(context)
		{
			VolunteerContent = new BannerCarouselItemViewModel(context.Page?.VolunteerContent);
			VolunteerContent.ButtonLinks.Select(s => s.Link.Url.Trim().Length > 1 ? s.Link.Url : s.Link.Url = "/");
		}

		public BannerCarouselItemViewModel VolunteerContent { get; }
	}
}
