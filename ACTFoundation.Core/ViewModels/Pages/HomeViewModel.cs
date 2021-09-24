using ACTFoundation.Core.Contexts;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class HomeViewModel : PageViewModel
	{
		public HomeViewModel(IPageContext<Home> context) : base(context)
		{
			MainContent = context.Page.MainContent;
		}

        public IEnumerable<IPublishedElement> MainContent { get; }
    }
}
