using ACTFoundation.Core.Extensions;
using ACTFoundation.Models.Generated;
using Umbraco.Core;

namespace ACTFoundation.Core.ViewModels.Partials.Items
{
    public class PurposeOfPaymentViewModel
    {
        public PurposeOfPaymentViewModel(PurposeOfPayment model)
        {

            Purpose = model.Purpose;
            Description = model.Description.ToHtmlString().StripHtml().GetTextPreview(750);
        }

        public string Purpose { get; }
        public string Description { get; }
    }
}
