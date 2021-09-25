using ACTFoundation.Core.Contexts;
using ACTFoundation.Models.Generated;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Core.ViewModels.Pages
{
	public class DonateViewModel : PageViewModel
	{
		public DonateViewModel(IPageContext<Donate> context) : base(context)
		{
			this.DonateContent = (BannerDefault) context.Page.DonateContent;
		}

		public BannerDefault DonateContent { get; }
	}
}
