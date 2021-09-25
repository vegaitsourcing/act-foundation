using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;

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
                Account = (dab as Project).Account,
                Title = (dab as Project).Title,
                CallingModel = (dab as Project).CallingModel,
                CallNumber = (dab as Project).CallNumber,
                Recepient = (dab as Project).Recepient
            }); 
        }

        public string Title { get; }

        public string Description { get; }

        public IEnumerable<DonateAccountInfoViewModel> DonateAccounts { get; }
    }
}
