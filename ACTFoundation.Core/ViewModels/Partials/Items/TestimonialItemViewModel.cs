using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Partials.Items
{
    public class TestimonialItemViewModel
    {
        public TestimonialItemViewModel(TestimonialItem testimonialItem)
        {
            Picture = new ImageViewModel(testimonialItem.Picture);
            FullName = testimonialItem.FullName;
            TestimonialText = testimonialItem.Testimonial;
            Occupation = testimonialItem.Occupation;
        }

        public ImageViewModel Picture { get; }

        public string FullName { get; }

        public string TestimonialText { get; }

        public string Occupation { get; }


    }
}
