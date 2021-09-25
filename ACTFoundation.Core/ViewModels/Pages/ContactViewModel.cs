using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Partials.Items;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class ContactViewModel : PageViewModel
    {
        public ContactViewModel(IPageContext<Contact> context) : base(context)
        {
            DonateContent = new BannerCarouselItemViewModel(context.Page.ContactContent);
            IsSubmitted = false;
        }

        public BannerCarouselItemViewModel DonateContent { get; set; }

        public bool IsSubmitted { get; set; }
    }
}
