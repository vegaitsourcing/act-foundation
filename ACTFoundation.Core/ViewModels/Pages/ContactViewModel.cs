using ACTFoundation.Core.Contexts;
using ACTFoundation.Models.Generated;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class ContactViewModel : PageViewModel
    {
        public ContactViewModel(IPageContext<Contact> context) : base(context)
        {
            MainContent = context.Page.ContactContent;
            IsSubmitted = false;
        }

        public IPublishedElement MainContent { get; set; }

        public bool IsSubmitted { get; set; }
    }
}
