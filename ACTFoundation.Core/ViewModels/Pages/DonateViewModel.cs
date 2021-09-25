using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Blocks;
using ACTFoundation.Core.ViewModels.Partials.Testimonials;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Core.ViewModels.Pages
{
	public class DonateViewModel : PageViewModel
	{
		public DonateViewModel(IPageContext<Donate> context) : base(context)
		{
			
		}
	}
}
