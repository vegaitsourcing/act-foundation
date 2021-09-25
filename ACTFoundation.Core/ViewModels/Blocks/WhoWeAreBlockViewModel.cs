using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Web;
using Umbraco.Core.Models;

namespace ACTFoundation.Core.ViewModels.Blocks
{
    public class WhoWeAreBlockViewModel
    {
        public WhoWeAreBlockViewModel(WhoWeAreBlock whoWeAre)
        {
            this.Title = whoWeAre.Title;
            this.Text = whoWeAre.Text;
            this.Pictures = whoWeAre.Picture;
        }

        public string Title { get; }
        public IHtmlString Text { get; }
        public IEnumerable<MediaWithCrops> Pictures { get; }
    }
}
