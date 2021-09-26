using ACTFoundation.Models.Generated;
using System.Web;

namespace ACTFoundation.Core.ViewModels.Blocks
{
    public class OurStoryBlockViewModel
    {
        public OurStoryBlockViewModel(OurStoryBlock ourStory)
        {
            Title = ourStory?.Title;
            Subtitle = ourStory?.Subtitle;
            Text = ourStory?.Text;
        }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public IHtmlString Text { get; set; }
    }
}