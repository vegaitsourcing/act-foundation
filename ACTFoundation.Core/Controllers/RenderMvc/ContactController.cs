using System.Linq;
using System.Web.Mvc;
using ACTFoundation.Core.Models;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;
using Umbraco.Web;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
    public class ContactController : BasePageController<Contact>
    {
        public ActionResult Index(Contact model)
            => CurrentTemplate(new ContactViewModel(CreatePageContext(model)));


        [HttpPost]
        public ActionResult Contact(string name, string email, string contactReason, string text)
        {
            var settings = Umbraco.ContentSingleAtXPath("//siteSettings") as SiteSettings;
            var emailSettings = new EmailSettings(settings);
            SmtpHelper.SendEmail(emailSettings, name, email, contactReason, text);

            var model = new ContactViewModel(CreatePageContext(new Contact(Umbraco.AssignedContentItem)))
            {
                IsSubmitted = true
            };

            return CurrentTemplate(model);
        }
    }
}