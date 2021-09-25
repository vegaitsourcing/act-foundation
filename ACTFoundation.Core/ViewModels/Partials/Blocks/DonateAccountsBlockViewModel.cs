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
            DonateAccounts = donateAccountsBlock.Projects.Select(dab => new DonateAccountInfoViewModel
            {
                Id = (dab as Project).Id,
                Account = (dab as Project).Account,
                Title = (dab as Project).Title,
                CallingModel = (dab as Project).CallingModel,
                CallNumber = (dab as Project).CallNumber,
                Recepient = (dab as Project).Recepient,
                Url = Current.UmbracoContext.UrlProvider.GetUrl((dab as Project).Id)
            }); 
        }

        public string Title { get; }
        public string Description { get; }
        public IEnumerable<DonateAccountInfoViewModel> DonateAccounts { get; }
    }
}
