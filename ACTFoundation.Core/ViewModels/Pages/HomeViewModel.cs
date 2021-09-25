using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Partials.Testimonials;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class HomeViewModel : PageViewModel
	{
		public HomeViewModel(IPageContext<Home> context) : base(context)
		{
			MainContent = context.Page.MainContent.Where(item => !(item is Testimonials));
			
			var testimonials = context.Page.MainContent.FirstOrDefault(item => item is Testimonials);
			if(testimonials != null)
            {
				Testimonials = new TestimonialsViewModel((Testimonials)testimonials);
            }
		}

        public IEnumerable<IPublishedElement> MainContent { get; }

		public TestimonialsViewModel Testimonials { get; }
    }
}
