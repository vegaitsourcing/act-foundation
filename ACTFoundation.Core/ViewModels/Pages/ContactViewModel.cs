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
            SubmitStatus = SubmitStatusEnum.Default;
        }

        public BannerCarouselItemViewModel DonateContent { get; set; }

        public SubmitStatusEnum SubmitStatus{ get; set; }
    }

    public enum SubmitStatusEnum
    {
        Default,
        Success,
        Error
    }
}
