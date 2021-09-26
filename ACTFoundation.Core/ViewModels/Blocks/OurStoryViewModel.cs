using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Blocks
{
    public class OurStoryViewModel
    {
        public OurStoryViewModel(OurStoryBlock ourStoryBlock)
        {
            this.Title = ourStoryBlock.Title;
            this.Subtitle = ourStoryBlock.Subtitle;
            this.Text = ourStoryBlock.Text;
            this.Image = new ImageViewModel(ourStoryBlock.Image);
        }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public IHtmlString Text { get; set; }

        public ImageViewModel Image { get; set; }
    }
}
