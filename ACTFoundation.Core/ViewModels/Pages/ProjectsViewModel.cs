using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.ViewModels.Partials.Blocks;
using ACTFoundation.Models.Generated;
using System;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class ProjectsViewModel : PageViewModel
    {
        public ProjectsViewModel(IPageContext<Projects> context) : base(context)
        {
            ProjectsId = context.Page?.Key;
            DonateAccountsBlock = context.Page.ProjectContent
                .FirstOrDefault(content => content is DonateAccountsBlock) is DonateAccountsBlock donateAccountsBlock ? 
                new DonateAccountsBlockViewModel(donateAccountsBlock) : null;
        }

        public Guid? ProjectsId { get; set; }
        public DonateAccountsBlockViewModel DonateAccountsBlock { get; set; }
    }
}
