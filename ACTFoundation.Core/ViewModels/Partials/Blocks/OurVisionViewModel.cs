using ACTFoundation.Models.Generated;
using System.Web;

namespace ACTFoundation.Core.ViewModels.Partials.Blocks
{
    public class OurVisionViewModel
    {
        public OurVisionViewModel(OurVisionBlock model)
        {
            Title = model.Title;
            Subtitle = model.Subtitle;
            Text = model.Text;
        }

        public string Title { get; }
        public string Subtitle { get; }
        public IHtmlString Text { get; }

    }
}
