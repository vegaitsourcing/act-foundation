using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Partials.Blocks;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class ProjectsViewModel : PageViewModel
    {
        public ProjectsViewModel(IPageContext<Projects> context) : base(context)
        {
            DonateAccountsBlock = context.Page.ProjectContent
                .FirstOrDefault(content => content is DonateAccountsBlock) is DonateAccountsBlock donateAccountsBlock ? 
                new DonateAccountsBlockViewModel(donateAccountsBlock) : null;
        }

        public DonateAccountsBlockViewModel DonateAccountsBlock { get; set; }
    }
}
