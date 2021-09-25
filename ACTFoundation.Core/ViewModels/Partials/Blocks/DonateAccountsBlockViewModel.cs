using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web.Composing;

namespace ACTFoundation.Core.ViewModels.Partials.Blocks
{
    public class DonateAccountsBlockViewModel
    {
        public DonateAccountsBlockViewModel(DonateAccountsBlock donateAccountsBlock)
        {
            Title = donateAccountsBlock.Title;
            Description = donateAccountsBlock.Description;
            CtaText = donateAccountsBlock.CtaText;
            DonateAccounts = donateAccountsBlock.Projects.Select(dab => {
                var project = dab as Project;
                return new DonateAccountInfoViewModel
                {
                    Id = project.Id,
                    Account = project.Account,
                    Title = project.Title,
                    CallingModel = project.CallingModel,
                    CallNumber = project.CallNumber,
                    Recepient = project.Recepient,
                    Url = Current.UmbracoContext.UrlProvider.GetUrl(project.Id)
                };
            });
        }

        public string Title { get; }
        public string Description { get; }

        public string CtaText { get;  }
        public IEnumerable<DonateAccountInfoViewModel> DonateAccounts { get; }
    }
}
