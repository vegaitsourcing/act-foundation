using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using Umbraco.Core.Models;

namespace ACTFoundation.Core.ViewModels.Partials.Blocks
{
    public class OurMissionViewModel
    {
        public OurMissionViewModel(OurMissionBlock ourMissionBlock)
        {
            this.Title = ourMissionBlock.Title;
            this.Subtitle = ourMissionBlock.Subtitle;
            this.TopText = ourMissionBlock.TopText;
            this.BottomText = ourMissionBlock.BottomText;
            this.Gallery = ourMissionBlock.Gallery;
        }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public IHtmlString TopText { get; set; }

        public IEnumerable<MediaWithCrops> Gallery { get; set; }

        public IHtmlString BottomText { get; set; }
    }
}
