using ACTFoundation.Models.Generated;
using Umbraco.Web.Models;
using System.Collections.Generic;

namespace ACTFoundation.Core.ViewModels.Blocks
{
    public class DonateBlockViewModel
    {
        public DonateBlockViewModel(DonateBlock donate)
        {
            this.Title = donate.Title;
            this.Text = donate.Text;
            this.images = donate.Picture;
            this.SeeMoreLink = donate.SeeMoreLink;
        }

        public string Title { get; }
        public string Text { get; }
        public Link SeeMoreLink { get; }
        public IEnumerable<Umbraco.Core.Models.MediaWithCrops> images { get; }

    }
}
