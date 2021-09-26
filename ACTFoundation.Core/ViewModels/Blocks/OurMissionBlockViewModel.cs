using ACTFoundation.Models.Generated;
using System.Web;

namespace ACTFoundation.Core.ViewModels.Blocks
{
    public class OurMissionBlockViewModel
    {
        public OurMissionBlockViewModel(OurMissionBlock ourMissionBlock)
        {
            Title = ourMissionBlock?.Title;
            Subtitle = ourMissionBlock?.Subtitle;
            TopText = ourMissionBlock?.TopText;
        }
        public string Title { get; set; }

        public string Subtitle { get; set; }
        public IHtmlString TopText { get; set; }
    }
}