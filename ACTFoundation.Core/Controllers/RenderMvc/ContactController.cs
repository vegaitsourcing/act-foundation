using System;
using System.Linq;
using System.Web.Mvc;
using ACTFoundation.Core.Models;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;
using Umbraco.Core.Logging;
using Umbraco.Web;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
    public class ContactController : BasePageController<Contact>
    {
        private ILogger _logger;

        public ContactController(ILogger logger)
        {
            _logger = logger;
        }

        public ActionResult Index(Contact model)
            => CurrentTemplate(new ContactViewModel(CreatePageContext(model)));


        [HttpPost]
        public ActionResult Contact(string name, string email, string contactReason, string text)
        {
            var settings = Umbraco.ContentSingleAtXPath("//siteSettings") as SiteSettings;
            var emailSettings = new EmailSettings(settings);
            var isError = false;
            try
            {
                SmtpHelper.SendEmail(emailSettings, name, email, contactReason, text);
            }
            catch (Exception ex)
            {
                isError = true;
                _logger.Error(GetType(), ex, "Error sending contact email");
            }

            var model = new ContactViewModel(CreatePageContext(new Contact(Umbraco.AssignedContentItem)))
            {
                SubmitStatus = isError ? SubmitStatusEnum.Error : SubmitStatusEnum.Success
            };


            return CurrentTemplate(model);
        }
    }
}