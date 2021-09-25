using ACTFoundation.Core.ViewModels.Partials.Items;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Partials.Testimonials
{
    public class TestimonialsViewModel
    {
        public TestimonialsViewModel(ACTFoundation.Models.Generated.Testimonials testimonials)
        {
            Title = testimonials.Title;
            Subtitle = testimonials.Subtitle;
            Description = testimonials.Description.ToHtmlString();
            TestimonialItems = testimonials.TestimonialItems.Select(testimonial => new TestimonialItemViewModel(testimonial)).ToArray();
        }

        public string Title { get; }

        public string Subtitle { get; }

        public string Description { get; }

        public TestimonialItemViewModel[] TestimonialItems { get; }
    }
}
