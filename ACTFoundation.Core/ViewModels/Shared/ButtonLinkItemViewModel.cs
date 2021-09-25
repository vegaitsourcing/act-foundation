using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Shared
{
    public class ButtonLinkItemViewModel
    {
        public ButtonLinkItemViewModel(ButtonLinkItem buttonLinkItem)
        {
            ButtonColor = buttonLinkItem.ButtonColor;
            Link = new LinkViewModel(buttonLinkItem.Link);
        }

        public string ButtonColor { get; }

        public LinkViewModel Link { get; }
    }
}
